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
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not Supported: Without isn't supported just yet...");
				Console.ForegroundColor = ConsoleColor.White;
				stream.Read();
				stream.Read();
				stream.Read();
			}

		}





		
		public override string GetMSSqlText()
		{
			return "*";
		}

		
	}
}
