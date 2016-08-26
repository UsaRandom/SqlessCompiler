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
	class AstriskTreeNode : AbstractSyntaxTreeNode
	{
		public AstriskTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base (stream, symbolTable)
		{
			Type = stream.Current.Type;
			stream.Read();

			if (stream.Current.Type == TokenType.Without)
			{
				m_children.Add(new WithoutColumnTreeNode(stream, symbolTable));
				m_children[0].Parent = this;
			}

		}





		
		public override string GetMSSqlText()
		{
			if(m_children.Count == 0)
				return "*";

			return m_children[0].GetMSSqlText();
		}

		
	}
}
