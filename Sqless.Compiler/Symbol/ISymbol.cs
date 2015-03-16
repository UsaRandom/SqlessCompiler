using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Symbol
{
interface ISymbol
{
	string Name { get; }

	SymbolType Type { get; }
}
}
