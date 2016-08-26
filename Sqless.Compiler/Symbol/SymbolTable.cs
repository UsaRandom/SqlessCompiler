using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Symbol
{
	class SymbolTable : ISymbolTable
	{
		public SymbolTable()
		{
			m_scopeTable = new List<Dictionary<string, SymbolItem>>();

			m_currentScopeTable = new Dictionary<string, SymbolItem>();

			m_scopeTable.Add(m_currentScopeTable);
		}


		public void Add(SymbolItem symbolItem)
		{
			symbolItem.ScopeDepth = m_scopeLevel;
			m_currentScopeTable.Add(symbolItem.Name, symbolItem);
		}

		public int CurrentScopeLevel()
		{
			return m_scopeLevel;
		}
		
		public bool HasSymbol(string name)
		{
			return m_currentScopeTable.ContainsKey(name);
		}

		public bool HasSymbol(string name, SymbolType type)
		{
			SymbolItem symbolItem = null;

			return TryGetSymbol(name, out symbolItem) && symbolItem.Type == type;
		}

		public void MoveScopeDown()
		{
			if(m_scopeLevel == 0)
			{
				throw new ApplicationException("Compiler error, cannot move scope lower than 0.");
			}

			//exiting scope, we can throw it out..
			m_scopeTable.RemoveAt(m_scopeLevel);

			m_scopeLevel--;

			m_currentScopeTable = m_scopeTable[m_scopeLevel];
		}

		public void MoveScopeUp()
		{
			m_scopeLevel++;
		
			m_scopeTable.Add(new Dictionary<string, SymbolItem>());
		}

		public bool TryGetSymbol(string name, out SymbolItem symbolItem)
		{
			return m_currentScopeTable.TryGetValue(name, out symbolItem);
		}

		private Dictionary<string, SymbolItem> m_currentScopeTable;
		private List<Dictionary<string, SymbolItem>> m_scopeTable;
		private int m_scopeLevel = 0;
		
	}
}
