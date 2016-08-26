using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class SelectTreeNode : AbstractSyntaxTreeNode
	{
		public SelectTreeNode(IBufferedTokenStream tokenStream, ISymbolTable symbolTable)
			: base(tokenStream, symbolTable)
		{
			
			//select *

		}
	}
}
