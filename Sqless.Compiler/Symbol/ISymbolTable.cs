using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Symbol
{
interface ISymbolTable
{
	
	void Add(ISymbol symbol, int scopeDepth);

	bool TryGetSymbol(string name, int scopeDepth, out ISymbol symbol);

	bool HasSymbol(string name, int scopeDepth, out ISymbol symbol);
	
}
}
