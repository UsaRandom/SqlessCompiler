using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta.Types;

namespace Sqless.Compiler.DatabaseMeta
{
interface IRDMSSqlTypeRelationshipMap
{
	ISqlDataType GetSqlDataType(string typeName, int length = 0, bool isNullable = false);

	string GetRDMSDataType(ISqlDataType type);

}
}
