using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta
{
class SqlDatabaseMeta : ISqlDatabaseMeta
{
	public SqlDatabaseMeta(string databaseName)
	{
		Name = databaseName;
	}

	public ICollection<ISqlSchemaMeta> Schemas
	{
		get;
		set;
	}

	public ICollection<ISqlTableMeta> Tables
	{
		get;
		set;
	}

	public string Name
	{
		get;
		private set;
	}
}
}
