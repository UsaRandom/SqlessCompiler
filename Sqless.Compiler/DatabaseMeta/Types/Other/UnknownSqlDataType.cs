using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta.Types
{
class UnknownSqlDataType : NullableSqlDataType
{	

	public UnknownSqlDataType(string sourceName, bool isNullable)
		: base(isNullable)
	{
		m_sourceName = sourceName;
	}
	
	protected override string GetTypeName()
	{
		return $"{SQL_TYPE_NAME} ({m_sourceName})";
	}

	private string m_sourceName;
	private const string SQL_TYPE_NAME = "Unknown";

}
}
