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
	class IdentifierTreeNode : AbstractSyntaxTreeNode
	{
		public IdentifierTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base (stream, symbolTable)
		{

			//IDENTIFIER = { IDENTIFIER | [IDENTIFIER] DOT [IDENTIFIER] | [IDENTIFIER] DOT IDENTIFIER | IDENTIFIER DOT [IDENTIFIER] }

			Type = stream.Current.Type;
			SymbolItem symbol = null;


			//get fully qualified name...

			string name = stream.Current.Content;

			while (stream.Peek(1).Type == TokenType.Dot)
			{
				stream.Read();
				stream.Read();

				name += "." + stream.Current.Content;
			}


			if (!SymbolTable.TryGetSymbol(name, out symbol))
			{
				if (Type != TokenType.Identifier)
				{
					symbol = new SymbolItem(name, Type);
				}
				else
				{
					symbol = new SymbolItem(name, TokenType.Unknown);
				}
				SymbolTable.Add(symbol);
			}

			Symbol = symbol;

			stream.Read();
		}
		
		public override string GetMSSqlText()
		{
			switch (Symbol.Type)
			{
				case SymbolType.Unknown:
					return Symbol.Name;
				default:
					return $"@{Symbol.Name}";
			}
		}


		public SymbolItem Symbol
		{
			get; set;
		}
	}
}
