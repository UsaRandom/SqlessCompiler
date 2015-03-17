using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.DatabaseMeta.Types
{
abstract class SqlDataType : ISqlDataType
{
	protected SqlDataType(bool isNullable)
	{
		m_isNullable = isNullable;
	}

	public virtual T Convert<T>() where T : ISqlDataType
	{
		throw new NotImplementedException();
	}

	public string TypeName
	{
		get { return GetTypeName(); }
	}

	public bool IsNullable
	{
		get { return m_isNullable; }
	}

	public int Length
	{
		get;
		set;
	}

	protected abstract string GetTypeName();

	private readonly bool m_isNullable;
}
}
