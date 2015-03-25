using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.GlobalScriptCache
{
class SqlServerGlobalScriptCache : IGlobalScriptCache
{
	public bool ScriptExists(string fullyQualifiedName)
	{
		return true;
	}

	public bool TryGetSource(string fullyQualifiedName, out string scriptSource)
	{
		scriptSource = "using WHATEVER = Test;";
		return true;
	}

	public void Register(string fullyQualifiedName, string source, string compiledSql)
	{
		throw new NotImplementedException();
	}

	public void Register(string fullyQualifiedName, string source, string compiledSql, bool overwrite)
	{
		throw new NotImplementedException();
	}
}
}
