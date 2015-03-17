using Sqless.Compiler.DatabaseMeta.Context;
using Sqless.Compiler.DatabaseMeta;
using Sqless.Compiler.GlobalScriptCache;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Log;
using Sqless.Compiler.PreProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler
{
public class SqlessCompiler
{

	public string Compile(string source)
	{
		ICompilerLog  log;
		IDatabaseContext context;
		ILexer lexer;
		

		context = new TSqlDatabaseContext("Data Source=SqlServer;Initial Catalog=CrudeFlow;Integrated Security=True;");

		ISqlDatabaseMeta databaseMeta = context.GetDatabaseMeta("CrudeFlow");


		foreach(var table in databaseMeta.Tables)
		{
			Console.WriteLine(table.Name);
			foreach(var column in table.Columns)
			{
				Console.WriteLine("    " + column.Name + " " + column.SqlDataType.TypeName);
			}
		}

		log = new CompilerLog();

		log.AddObserver(new StandardCompilerObserver());
		log.AddObserver(new VerboseCompilerObserver());

		lexer = new SqlessLexer(log);

		//source = PreProcess(cache, log, lexer, source);

		foreach(var token in lexer.Tokenize(source))
		{
			Console.Write(string.Empty);
		}

		return string.Empty;
	}


	private string PreProcess(IGlobalScriptCache globalScriptCache, ICompilerLog log, ILexer lexer, string source)
	{
		var preProcessors = new List<IPreProcessor>();

		//add additional preprocessors here
		preProcessors.Add(new ImportPreProcessor(globalScriptCache, log, lexer));

		foreach (var preProcessor in preProcessors)
		{
			source = preProcessor.PreProcess(source);
		}

		return source;
	}

	//string Compile(string source, string connectionString, string sqlessDatabase);

}
}
