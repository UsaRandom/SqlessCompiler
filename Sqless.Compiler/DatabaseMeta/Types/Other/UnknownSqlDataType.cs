using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta.Types
{
class UnknownSqlDataType : NullableSqlDataType
{	

	public UnknownSqlDataType(bool isNullable)
		: base(isNullable)
	{

	}
	
	protected override string GetTypeName()
	{
		return SQL_TYPE_NAME;
	}

	private const string SQL_TYPE_NAME = "Unknown";

}
}
