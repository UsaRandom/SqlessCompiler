using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.GlobalScriptCache
{
interface IGlobalScriptCache
{
	bool ScriptExists(string fullyQualifiedName);

	bool TryGetSource(string fullyQualifiedName, out string scriptSource);
        
	void Register(string fullyQualifiedName, string source, bool overwrite = false);
	//void Register(string fullyQualifiedName, string source, string compiledSql);
	//void Register(string fullyQualifiedName, string source, string compiledSql, bool overwrite);
}
}
