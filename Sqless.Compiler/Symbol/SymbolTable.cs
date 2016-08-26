using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Sqless.Compiler.DatabaseMeta;
using Sqless.Compiler.Log;

namespace Sqless.Compiler.Symbol
{
	class SymbolTable : ISymbolTable
	{
		public SymbolTable(ICompilerLog log)
		{
			m_log = log;

			m_scopeTable = new List<Dictionary<string, SymbolItem>>();

			m_currentScopeTable = new Dictionary<string, SymbolItem>();

			m_scopeTable.Add(m_currentScopeTable);
		}


		public void Add(SymbolItem symbolItem)
		{
			symbolItem.ScopeDepth = m_scopeLevel;
			m_currentScopeTable.Add(symbolItem.Name, symbolItem);
		}

		public ISqlDatabaseMeta DatabaseMeta
		{
			get;
			set;
		}



		public ISqlTableMeta GetTableMetaByName(string name)
		{
			if (!name.Contains("."))
			{
				name = this.m_defaultSchema + "." + name;
			}

			name = name.ToLower();

			foreach (var table in DatabaseMeta.Tables)
			{
				if (table.FullName.ToLower() == name)
				{
					return table;
				}
			}
			return null;
		}

		public void AddTable(string name)
		{		
			//	foreach (var schema in databaseMeta.Schemas)
		//	{
		//		this.Add(new SymbolItem(schema.Name, SymbolType.Schema));

		//		foreach (var table in schema.Tables)
		//		{
		//			this.Add(new SymbolItem(schema.Name + "." + table.Name, SymbolType.Table));

		//			foreach (var column in table.Columns)
		//			{
		//				this.Add(new SymbolItem(schema.Name + "." + table.Name + "." + column.Name, SymbolType.Column));
		//			}
		//		}

		//	}
			
		}

		//public void AddDatabaseMeta(ISqlDatabaseMeta databaseMeta)
		//{
		//	foreach (var schema in databaseMeta.Schemas)
		//	{
		//		this.Add(new SymbolItem(schema.Name, SymbolType.Schema));

		//		foreach (var table in schema.Tables)
		//		{
		//			this.Add(new SymbolItem(schema.Name + "." + table.Name, SymbolType.Table));

		//			foreach (var column in table.Columns)
		//			{
		//				this.Add(new SymbolItem(schema.Name + "." + table.Name + "." + column.Name, SymbolType.Column));
		//			}
		//		}

		//	}
		//}


		public int CurrentScopeLevel()
		{
			return m_scopeLevel;
		}


		public void SetDefaultSchema(string schema)
		{
			m_defaultSchema = schema;
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


		private string m_defaultSchema = "dbo";
		private ICompilerLog m_log;
	}
}
