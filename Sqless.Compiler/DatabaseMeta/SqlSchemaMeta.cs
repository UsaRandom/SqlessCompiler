using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta
{
class SqlSchemaMeta : ISqlSchemaMeta
{
	public SqlSchemaMeta(string name)
	{
		Name = name;
		Tables = new List<ISqlTableMeta>();
	}

	public string Name
	{
		get;
		private set;
	}

	public IList<ISqlTableMeta> Tables
	{
		get;
		set;
	}
}
}
