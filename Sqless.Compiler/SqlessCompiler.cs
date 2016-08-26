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
		ISymbolTable symbolTable;
		
		context = new TSqlDatabaseContext("Data Source=MARTIN-HOME\\SQLSERVER;Initial Catalog=Astrid;Integrated Security=True;");

		ISqlDatabaseMeta databaseMeta = context.GetDatabaseMeta("Astrid");
			
			
		var cache = new SqlServerGlobalScriptCache();

		log = new CompilerLog();

		log.AddObserver(new StandardCompilerObserver());
		//log.AddObserver(new VerboseCompilerObserver());
		
		symbolTable = new SymbolTable(log);

		symbolTable.DatabaseMeta = databaseMeta;
		
		lexer = new SqlessLexer(log);

		source = PreProcess(cache, log, lexer, source);


	//	lexer = new SqlessLexer(log);
		IBufferedTokenStream tokenStream = new BufferedTokenStream(lexer.Tokenize(source));



		//while(tokenStream.Read())
		//{
		//	Console.WriteLine("[{0}] - {1}", tokenStream.Current.Type, tokenStream.Current.Content);
		//}

		var sqlessParser = new AbstractSyntaxTreeNode(tokenStream, symbolTable);

		sqlessParser.Parse();
		sqlessParser.Pass();

		
		

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
