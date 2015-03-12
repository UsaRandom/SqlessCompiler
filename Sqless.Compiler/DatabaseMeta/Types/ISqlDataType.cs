using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta.Types
{
interface ISqlDataType
{
	T Convert<T>() where T : ISqlDataType;

	string TypeName { get; }

	bool IsNullable { get; }
}
}
