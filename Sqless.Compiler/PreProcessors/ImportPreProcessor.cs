using System.Runtime.ExceptionServices;
using Sqless.Compiler.GlobalScriptCache;
using Sqless.Compiler.Lexer;
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
	public ImportPreProcessor(IGlobalScriptCache globalScriptCache, ICompilerLog compilerLog, ILexer lexer)
	{
		m_lexer = lexer;
		m_compilerLog = compilerLog;
		m_globalScriptCache = globalScriptCache;

	}

	public string PreProcess(string source)
	{
		return ProcessImports(source);
	}



	private string ProcessImports(string source)
	{
		throw new NotImplementedException("Not Finished implementing");

		/*
		 * This needs to track which scripts we've imported already, to avoid
		 * recursive references... aka, shit storm.
		 * 
		 * It also has to restart lexing after every import. (due to index changes)
		 * 
		 */

		var preProcessedSource = new StringBuilder(source);
		var tokenStream = new BufferedTokenStream(m_lexer.Tokenize(source));


		IToken currentToken;


		while((currentToken = tokenStream.Read()) != default(IToken))
		{
			if(currentToken.Type == TokenType.Import)
			{
				//we found an 'import' token.
				var expectedEquals = tokenStream.Peek(1);
				var expectedScriptIdentifier = tokenStream.Peek(2);

				if((expectedEquals != default(IToken) && expectedEquals.Type == TokenType.Equals) &&
					(expectedScriptIdentifier != default(IToken) && expectedScriptIdentifier.Type == TokenType.Symbol))
				{
					//the import token was follwed by an equals and a symbol, we should import a script!
					string scriptSource;

					if(m_globalScriptCache.TryGetSource(expectedScriptIdentifier.Content, out scriptSource))
					{

						//remove the import
						preProcessedSource.Remove(currentToken.SourceIndexStart, expectedScriptIdentifier.SourceIndexEnd - currentToken.SourceIndexStart);

						//add the script (and process imports on that script)
						preProcessedSource.Insert(currentToken.SourceIndexStart, ProcessImports(scriptSource));
						
						break;
					}
					else
					{
						//couldn't find the script in the GSC
						m_compilerLog.Info("The requested script doesn't exists");
						throw new Exception("Compiler Exception");
					}

				}
				else
				{
					//We may have an issue here... lets log it.
					m_compilerLog.Info("ImportPreProcessor found an IMPORT statement that may not be valid");
				}
			}
		}

		return preProcessedSource.ToString();
	}

	


	private ILexer m_lexer;
	private ICompilerLog m_compilerLog;
	private IGlobalScriptCache m_globalScriptCache;
}
}
