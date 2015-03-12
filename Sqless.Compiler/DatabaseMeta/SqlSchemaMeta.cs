using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta
{
class SqlSchemaMeta : ISqlSchemaMeta
{
	public string Name
	{
		get { throw new NotImplementedException(); }
	}

	public IList<ISqlTableMeta> Tables
	{
		get { throw new NotImplementedException(); }
	}
}
}
