using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta
{
class SqlTableMeta : ISqlTableMeta
{
	public string Name
	{
		get { throw new NotImplementedException(); }
	}

	public ISqlDatabaseMeta DatabaseMeta
	{
		get { throw new NotImplementedException(); }
	}

	public ISqlSchemaMeta SchemaMeta
	{
		get { throw new NotImplementedException(); }
	}

	public IDictionary<string, ISqlColumnMeta<Types.ISqlDataType>> Columns
	{
		get { throw new NotImplementedException(); }
	}
}
}
