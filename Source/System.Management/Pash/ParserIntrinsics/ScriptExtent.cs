﻿// Copyright (C) Pash Contributors. License: GPL/BSD. See https://github.com/Pash-Project/Pash/
using System;
using System.Text;
using System.Management.Automation.Language;
using Irony.Parsing;

namespace Pash.ParserIntrinsics
{
    class ScriptExtent : IScriptExtent
    {
        readonly ParseTreeNode _parseTreeNode;
        readonly SourceSpan _span;
        private readonly string _text;

        public ScriptExtent(SourceSpan origSpan, int startOffset, int endOffset, string textValue = null)
        {
            _text = textValue;
            if (startOffset == 0 && endOffset == 0)
            {
                _span = origSpan;
                return;
            }
            // create a new span with offsets
            var location = origSpan.Location;
            // we don't adjust line and column for artifical offsets. This is hopefully okay.
            var newLocation = new SourceLocation(location.Position + startOffset, location.Line, location.Column);
            // don't forget to subtract the start offset here
            _span = new SourceSpan(newLocation, origSpan.Length + endOffset - startOffset);
        }

        public ScriptExtent(ParseTreeNode parseTreeNode) : this(parseTreeNode.Span, 0, 0)
        {
            this._parseTreeNode = parseTreeNode;
        }

        int IScriptExtent.EndColumnNumber
        {
            get { return Location.Column + Span.Length + 1; }
        }

        int IScriptExtent.EndLineNumber
        {
            get { return Location.Line + 1; }
        }

        int IScriptExtent.EndOffset
        {
            get { return Span.EndPosition; }
        }

        IScriptPosition IScriptExtent.EndScriptPosition
        {
            get { throw new NotImplementedException(); }
        }

        string IScriptExtent.File
        {
            get { return null; }
        }

        int IScriptExtent.StartColumnNumber
        {
            get { return Location.Column + 1; }
        }

        int IScriptExtent.StartLineNumber
        {
            get { return Location.Line + 1; }
        }

        int IScriptExtent.StartOffset
        {
            get { return Location.Position; }
        }

        IScriptPosition IScriptExtent.StartScriptPosition
        {
            get { throw new NotImplementedException(); }
        }

        string IScriptExtent.Text
        {
            get
            {
                if (_text != null)
                {
                    return _text;
                }

                if (_parseTreeNode == null)
                {
                    return string.Empty;
                }

                return _parseTreeNode.FindTokenAndGetText() ?? string.Empty;
            }
        }

        string IScriptExtent.FullText
        {
            get { return _text ?? GetParseTreeNodeText(_parseTreeNode); }
        }

        private SourceLocation Location
        {
            get { return Span.Location; }
        }

        private SourceSpan Span
        {
            get { return _span; }
        }

        private static string GetParseTreeNodeText(ParseTreeNode parseTreeNode)
        {
            if (parseTreeNode == null)
            {
                return string.Empty;
            }

            // We cannot use FindTokenAndGetText always because it will give us only the text of the root node in
            // case of complex expressions. So we have to do that:
            if (parseTreeNode.ChildNodes.Count > 0)
            {
                var result = new StringBuilder();
                foreach (var node in parseTreeNode.ChildNodes)
                {
                    int offset = node.Span.Location.Position - parseTreeNode.Span.Location.Position;
                    if (result.Length < offset)
                    {
                        result.Append(' ', offset - result.Length);
                    }

                    result.Append(GetParseTreeNodeText(node));
                }

                return result.ToString();
            }

            return parseTreeNode.FindTokenAndGetText() ?? string.Empty;
        }
    }
}
