using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class OperatorTreeNode : AbstractSyntaxTreeNode
	{
		public OperatorTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base (stream, symbolTable)
		{
			Type = stream.Current.Type;
			m_operator = stream.Current.Content;
			stream.Read();
		}
		
		public override string GetMSSqlText()
		{
			switch(Type)
			{
				case TokenType.And:
					return "AND";
				case TokenType.Or:
					return "OR";
				case TokenType.DoubleEquals:
					return "=";
				default:
					return m_operator;

			}
			
		}

		private string m_operator;

	}
}
