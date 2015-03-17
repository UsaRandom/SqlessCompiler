using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta.Types
{
abstract class NullableSqlDataType : SqlDataType
{
	protected NullableSqlDataType(bool isNullable)
		: base(isNullable)
	{

	}


	

}
}
