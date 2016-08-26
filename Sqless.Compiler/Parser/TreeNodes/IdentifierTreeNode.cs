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
			Type = stream.Current.Type;
			SymbolItem symbol = null;


			if (!SymbolTable.TryGetSymbol(stream.Current.Content, out symbol))
			{
				symbol = new SymbolItem(stream.Current.Content, stream.Current.Type);
				SymbolTable.Add(symbol);
			}

			Symbol = symbol;

			stream.Read();
		}
		
		public override string GetMSSqlText()
		{
			return string.Format("@{0}", Symbol.Name);
		}


		public SymbolItem Symbol
		{
			get; set;
		}
	}
}
