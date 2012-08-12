﻿///////////////////////////////////////////////////////////////////
//
// Autogenerated file. Do not edit.
//
///////////////////////////////////////////////////////////////////


using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;

using GoldParser;

namespace Pash.ParserIntrinsics
{
    class SymbolConstants
    {
        public static List<SymbolConstants> All = new List<SymbolConstants>();
        
        public readonly int Index;
        public readonly string Description;
        public readonly SymbolType SymbolType;
        
        SymbolConstants(
            int index,
            string description,
            SymbolType symbolType
        ) 
        {
            this.Index = index;
            this.Description = description;
            this.SymbolType = symbolType;
            
            All.Add(this);
        }
        
        public override string ToString()
        {
            return this.Description;
        }
        
        readonly public SymbolConstants Symbol_Eof = new SymbolConstants (
            0,
            "(EOF)",
            (SymbolType) 3
        );

        readonly public SymbolConstants Symbol_Error = new SymbolConstants (
            1,
            "(Error)",
            (SymbolType) 7
        );

        readonly public SymbolConstants Symbol_Whitespace = new SymbolConstants (
            2,
            "Whitespace",
            (SymbolType) 2
        );

        readonly public SymbolConstants Symbol_Commentend = new SymbolConstants (
            3,
            "'Comment End'",
            (SymbolType) 5
        );

        readonly public SymbolConstants Symbol_Commentline = new SymbolConstants (
            4,
            "'Comment Line'",
            (SymbolType) 6
        );

        readonly public SymbolConstants Symbol_Commentstart = new SymbolConstants (
            5,
            "'Comment Start'",
            (SymbolType) 4
        );

        readonly public SymbolConstants Symbol_Dollarlparan = new SymbolConstants (
            6,
            "'$('",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Lparan = new SymbolConstants (
            7,
            "'('",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Rparan = new SymbolConstants (
            8,
            "')'",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Pipe = new SymbolConstants (
            9,
            "'|'",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Additionoperatortoken = new SymbolConstants (
            10,
            "AdditionOperatorToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Anywordtoken = new SymbolConstants (
            11,
            "AnyWordToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Assignmentoperatortoken = new SymbolConstants (
            12,
            "AssignmentOperatorToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Commatoken = new SymbolConstants (
            13,
            "CommaToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Commenttoken = new SymbolConstants (
            14,
            "CommentToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Execcall = new SymbolConstants (
            15,
            "ExecCall",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Newline = new SymbolConstants (
            16,
            "NewLine",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Numbertoken = new SymbolConstants (
            17,
            "NumberToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Parametertoken = new SymbolConstants (
            18,
            "ParameterToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Rangeoperatortoken = new SymbolConstants (
            19,
            "RangeOperatorToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Stringtoken = new SymbolConstants (
            20,
            "StringToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Variabletoken = new SymbolConstants (
            21,
            "VariableToken",
            (SymbolType) 1
        );

        readonly public SymbolConstants Symbol_Addexpressionrule = new SymbolConstants (
            22,
            "<addExpressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Arrayliteralrule = new SymbolConstants (
            23,
            "<arrayLiteralRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Assignmentstatementrule = new SymbolConstants (
            24,
            "<assignmentStatementRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Bitwiseexpressionrule = new SymbolConstants (
            25,
            "<bitwiseExpressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Cmdletcall = new SymbolConstants (
            26,
            "<cmdletCall>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Cmdletname = new SymbolConstants (
            27,
            "<cmdletName>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Cmletparamslist = new SymbolConstants (
            28,
            "<cmletParamsList>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Comparisonexpressionrule = new SymbolConstants (
            29,
            "<comparisonExpressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Expressionrule = new SymbolConstants (
            30,
            "<expressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Formatexpressionrule = new SymbolConstants (
            31,
            "<formatExpressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Logicalexpressionrule = new SymbolConstants (
            32,
            "<logicalExpressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Lvalue = new SymbolConstants (
            33,
            "<lvalue>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Lvalueexpression = new SymbolConstants (
            34,
            "<lvalueExpression>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Multiplyexpressionrule = new SymbolConstants (
            35,
            "<multiplyExpressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Parameterargumenttoken = new SymbolConstants (
            36,
            "<ParameterArgumentToken>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Pipelinerule = new SymbolConstants (
            37,
            "<pipelineRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Postfixoperatorrule = new SymbolConstants (
            38,
            "<postfixOperatorRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Propertyorarrayreferencerule = new SymbolConstants (
            39,
            "<propertyOrArrayReferenceRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Rangeexpressionrule = new SymbolConstants (
            40,
            "<rangeExpressionRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Simplelvalue = new SymbolConstants (
            41,
            "<simpleLvalue>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Statementlistrule = new SymbolConstants (
            42,
            "<statementListRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Statementrule = new SymbolConstants (
            43,
            "<statementRule>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Statementseparatortoken = new SymbolConstants (
            44,
            "<statementSeparatorToken>",
            (SymbolType) 0
        );

        readonly public SymbolConstants Symbol_Valuerule = new SymbolConstants (
            45,
            "<valueRule>",
            (SymbolType) 0
        );

    };
}
