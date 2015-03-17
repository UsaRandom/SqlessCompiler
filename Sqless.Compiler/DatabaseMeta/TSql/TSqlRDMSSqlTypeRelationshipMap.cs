using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta.Types;

namespace Sqless.Compiler.DatabaseMeta.TSql
{
class TSqlRDMSSqlTypeRelationshipMap : IRDMSSqlTypeRelationshipMap
{
	
	public Types.ISqlDataType GetSqlDataType(string typeName, int length, bool isNullable = false)
	{
		if(string.IsNullOrWhiteSpace(typeName))
			throw new Exception("Type name cannot be null or whitespace");

		switch(typeName.ToLower())
		{
			case "tinyint":
				return new Int8SqlDataType(isNullable);
			case "smallint":
				return new Int16SqlDataType(isNullable);
			case "int":
				return new Int32SqlDataType(isNullable);
			case "bigint":
				return new Int64SqlDataType(isNullable);

			case "char":
				return new CharSqlDataType(isNullable) { Length = length };
			case "varchar":
				return new VarCharSqlDataType(isNullable) { Length = length };


			//see: https://msdn.microsoft.com/en-us/library/ms173773.aspx
			case "real":
				return new FloatSqlDataType(isNullable);
			case "float":
				return new DoubleSqlDataType(isNullable);
			default:
				return new UnknownSqlDataType(isNullable);
		}
	}

	public string GetRDMSDataType(Types.ISqlDataType type)
	{
		throw new NotImplementedException();
	}
}
}
