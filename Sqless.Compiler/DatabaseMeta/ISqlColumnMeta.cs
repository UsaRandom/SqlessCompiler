using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta.Types;

namespace Sqless.Compiler.DatabaseMeta
{
interface ISqlColumnMeta<out T> where T : ISqlDataType
{

	string Name { get; }

	T SqlDataType { get; }

	ISqlColumnMeta<ISqlDataType> References { get; }

	ICollection<ISqlColumnMeta<ISqlDataType>> ReferencingColumns { get; }

	ISqlTableMeta TableMeta { get; }
}
}
