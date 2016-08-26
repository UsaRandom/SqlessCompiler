using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class SelectColumnTreeNode : AbstractSyntaxTreeNode
	{
		public SelectColumnTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base(stream, symbolTable)
		{

			//SelectColumn = { Expression | Identifier | Astrisk}


			switch (stream.Current.Type)
			{
				
				case TokenType.Asterisk:
					Child = new AstriskTreeNode(stream, symbolTable);
					break;
				default: 
					Child = new ExpressionTreeNode(stream, symbolTable);
					break;
			}

			Child.Parent = this;

		}
		
		
		
		public override void Pass()
		{
			Child.Pass();
		}
		
		public override string GetMSSqlText()
		{
			return Child.GetMSSqlText();
		}

		AbstractSyntaxTreeNode Child;

	}
}
