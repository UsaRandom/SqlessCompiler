using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta;

namespace Sqless.Compiler.Symbol
{
interface ISymbolTable
{
	
	void Add(SymbolItem symbolItem);

	bool TryGetSymbol(string name, out SymbolItem symbolItem);
		
	bool HasSymbol(string name);
	bool HasSymbol(string name, SymbolType symbolType);

	void AddDatabaseMeta(ISqlDatabaseMeta databaseMeta);

	void MoveScopeUp();

	void MoveScopeDown();
	

	int CurrentScopeLevel();
}
}
