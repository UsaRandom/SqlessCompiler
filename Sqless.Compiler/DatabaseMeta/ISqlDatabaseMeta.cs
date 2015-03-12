using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta
{
interface ISqlDatabaseMeta
{
	ICollection<ISqlSchemaMeta> Schemas { get; }

	ICollection<ISqlTableMeta> Tables { get; }

	string Name { get; }
}
}
