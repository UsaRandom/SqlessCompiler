using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta.Types;

namespace Sqless.Compiler.DatabaseMeta
{
class SqlTableMeta : ISqlTableMeta
{
	public SqlTableMeta( ISqlDatabaseMeta database, ISqlSchemaMeta schema, string name)
	{
		SchemaMeta = schema;
		DatabaseMeta = database;
		Columns = new List<ISqlColumnMeta<ISqlDataType>>();

		schema.Tables.Add(this);

		Name = name;
	}

	public string Name
	{
		get;
		private set;
	}

	public ISqlDatabaseMeta DatabaseMeta
	{
		get;
		private set;
	}

	public ISqlSchemaMeta SchemaMeta
	{
		get;
		private set;
	}

	public IList<ISqlColumnMeta<Types.ISqlDataType>> Columns
	{
		get;
		set;
	}
}
}
