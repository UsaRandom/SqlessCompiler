using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta
{
class SqlDatabaseMeta : ISqlDatabaseMeta
{
	public ICollection<ISqlSchemaMeta> Schemas
	{
		get { throw new NotImplementedException(); }
	}

	public ICollection<ISqlTableMeta> Tables
	{
		get { throw new NotImplementedException(); }
	}

	public string Name
	{
		get { throw new NotImplementedException(); }
	}
}
}
