using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta.Types;

namespace Sqless.Compiler.DatabaseMeta
{
interface ISqlTableMeta
{

	string Name { get; }

	string FullName { get; }

	ISqlDatabaseMeta DatabaseMeta { get; }

	ISqlSchemaMeta SchemaMeta { get; }

	IList<ISqlColumnMeta<Types.ISqlDataType>> Columns { get; }

	//Some other object should have this responsibility... should have a concept of 'confidence'
	//IList<ISqlColumn<ISqlDataType>> GetColumnsToJoinOn(ISqlTable other);  
}
}
