﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Ast;
using Irony.Parsing;

namespace Pash.ParserIntrinsics.Nodes
{
    public class script_block_body_node : _node
    {
public script_block_body_node(AstContext astContext, ParseTreeNode parseTreeNode) : base(astContext, parseTreeNode) { 
}

        internal override void Execute(Implementation.ExecutionContext context, System.Management.Automation.ICommandRuntime commandRuntime)
        {
            throw new NotImplementedException();
        }

        internal override object GetValue(Implementation.ExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}