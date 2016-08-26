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


	ISqlTableMeta GetTableMetaByName(string name);
	
	ISqlDatabaseMeta DatabaseMeta { get; set; }

	void MoveScopeUp();

	void MoveScopeDown();
	

	int CurrentScopeLevel();
}
}
