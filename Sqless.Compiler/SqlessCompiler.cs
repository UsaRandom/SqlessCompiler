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
using Sqless.Compiler.Parser;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler
{
public class SqlessCompiler
{

	public string TranspileToMSSql(string source)
	{
		ICompilerLog log;
		IDatabaseContext context;
		ILexer lexer;

		/*
		context = new TSqlDatabaseContext("Data Source=localhost;Initial Catalog=CrudeFlow;Integrated Security=True;");

		ISqlDatabaseMeta databaseMeta = context.GetDatabaseMeta("CrudeFlow");


		foreach (var table in databaseMeta.Tables)
		{
			Console.WriteLine(table.Name);
			foreach (var column in table.Columns)
			{
				Console.WriteLine("    " + column.Name + " " + column.SqlDataType.TypeName);
			}
		}
			*/
		var cache = new SqlServerGlobalScriptCache();

		log = new CompilerLog();

		log.AddObserver(new StandardCompilerObserver());
		//log.AddObserver(new VerboseCompilerObserver());

		lexer = new SqlessLexer(log);

		source = PreProcess(cache, log, lexer, source);


		lexer = new SqlessLexer(log);
		IBufferedTokenStream tokenStream = new BufferedTokenStream(lexer.Tokenize(source));


		var symbolTable = new SymbolTable();

		//while(tokenStream.Read())
		//{
		//	Console.WriteLine("[{0}] - {1}", tokenStream.Current.Type, tokenStream.Current.Content);
		//}

		var sqlessParser = new AbstractSyntaxTreeNode(tokenStream, symbolTable);

		sqlessParser.Parse();
		

		
		

		return sqlessParser.GetMSSqlText();
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

	//string TranspileToMSSql(string source, string connectionString, string sqlessDatabase);

}
}
