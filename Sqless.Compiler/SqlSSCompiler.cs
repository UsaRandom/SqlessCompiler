using Sqless.Compiler.Analysis.Lexer;
using Sqless.Compiler.Log;
using Sqless.Compiler.PreProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler
{
public class SqlSSCompiler
{

	public string Compile(string source)
	{
		ICompilerLog  log;
		
		ILexer lexer;
		
		log = new CompilerLog();

		log.AddObserver(new StandardCompilerObserver());
		log.AddObserver(new VerboseCompilerObserver());

		lexer = new Lexer(log);

		foreach(var token in lexer.Tokenize(source))
		{
			Console.Write(string.Empty);
		}

		return string.Empty;
	}


	private string PreProcess(ILexer lexer, string source)
	{
		m_preProcessors = new List<IPreProcessor>();

		//m_preProcessors.Add(new ImportPreProcessor());
		return source;
	}

	//string Compile(string source, string connectionString, string sqlessDatabase);

	private IList<IPreProcessor> m_preProcessors;
}
}
