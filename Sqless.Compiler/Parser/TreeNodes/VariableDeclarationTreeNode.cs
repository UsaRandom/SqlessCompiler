using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class VariableDeclarationTreeNode : AbstractSyntaxTreeNode
	{
		public VariableDeclarationTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base (stream, symbolTable)
		{
			if (stream.Current.Type != TokenType.Var)
				throw new Exception();

			stream.Read();
			var identifier = stream.Current;
			stream.Read();
			var equals = stream.Current;
			stream.Read();
			
			RightHandSide = new ExpressionTreeNode(stream, symbolTable);
			m_symbol = new SymbolItem(identifier.Content, RightHandSide.Type);
			SymbolTable.Add(m_symbol);
			
			//Ignore Semicolons at the end.
			if (stream.Current.Type == TokenType.Semicolon)
			{
				stream.Read();
			}
		}


		public override string GetMSSqlText()
		{
			return string.Format("DECLARE @{0} {1} = {2};", m_symbol.Name, GetMSSqlType(m_symbol.Type), RightHandSide.GetMSSqlText());
		}

		private SymbolItem m_symbol;
		AbstractSyntaxTreeNode RightHandSide;
	}
}
