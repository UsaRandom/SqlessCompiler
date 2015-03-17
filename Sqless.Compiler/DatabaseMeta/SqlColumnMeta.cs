using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta.Types;

namespace Sqless.Compiler.DatabaseMeta
{
class SqlColumnMeta<T> : ISqlColumnMeta<T> where T : ISqlDataType
{

	public SqlColumnMeta(string name, T sqlDataType, ISqlTableMeta table)
	{
		Name = name;
		SqlDataType = sqlDataType;
		TableMeta = table;
	} 

	public string Name { get; private set; }
	public T SqlDataType { get; private set; }
	public ISqlColumnMeta<ISqlDataType> References { get; private set; }
	public ICollection<ISqlColumnMeta<ISqlDataType>> ReferencingColumns { get; private set; }
	public ISqlTableMeta TableMeta { get; private set; }
}
}
