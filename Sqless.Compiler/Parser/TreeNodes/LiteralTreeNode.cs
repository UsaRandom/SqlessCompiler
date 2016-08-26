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
	class LiteralTreeNode : AbstractSyntaxTreeNode
	{
		public LiteralTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base (stream, symbolTable)
		{
			Value = "";

			//this should be handeled above this...
			if (TokenIsOperator(stream.Current.Type))
			{
				Value += stream.Current.Content;
				stream.Read();
			}

			Type = stream.Current.Type;

			switch (Type)
			{
				case TokenType.DoubleLiteral:
					Value += stream.Current.Content.Substring(0, stream.Current.Content.Length - 1);
					break;
				default:
					Value += stream.Current.Content;
					break;
			}

			stream.Read();
		}

		
		public override string GetMSSqlText()
		{
			return Value;
		}


		public string Value
		{
			get; set;
		}
		
		
	}
}
