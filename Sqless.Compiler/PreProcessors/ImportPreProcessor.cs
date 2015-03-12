using Sqless.Compiler.Analysis.Lexer;
using Sqless.Compiler.GlobalScriptCache;
using Sqless.Compiler.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.PreProcessors
{
class ImportPreProcessor : IPreProcessor
{
	public ImportPreProcessor(IGlobalScriptCache globalScriptCache, ICompilerLog compilerLog)
	{
		m_compilerLog = compilerLog;
		m_globalScriptCache = globalScriptCache;
	}

	public void PreProcess(ILexer lexer)
	{

	}

	
	private ICompilerLog m_compilerLog;
	private IGlobalScriptCache m_globalScriptCache;
}
}
