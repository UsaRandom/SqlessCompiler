using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;

namespace Sqless.Compiler.Symbol
{
	class SymbolItem
	{

		public SymbolItem(string name, SymbolType type)
		{
			this.Name = name;
			this.Type = type;
		}

		public SymbolItem(string name, SymbolType type, object data)
		{
			this.Name = name;
			this.Type = type;
		}

		public SymbolItem(string name, TokenType type)
		{
			switch (type)
			{
				case TokenType.IntLiteral:
					this.Type = SymbolType.Int;
					break;
				case TokenType.FloatLiteral:
					this.Type = SymbolType.Float;
					break;
				case TokenType.DoubleLiteral:
					this.Type = SymbolType.Double;
					break;

				case TokenType.Unknown:
					this.Type = SymbolType.Unknown;
					break;
				default:
					throw new Exception("Not a valid Type");
			}
			this.Name = name;
		}

		public string Name { get; set;  }

		public SymbolType Type { get; set; }

		public int ScopeDepth { get; set; }
	}
}
