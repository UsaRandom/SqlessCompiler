using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta;

namespace Sqless.Compiler.DatabaseMeta.Context
{
interface IDatabaseContext
{
	ISqlDatabaseMeta GetDatabaseMeta(string databaseName);

}
}
