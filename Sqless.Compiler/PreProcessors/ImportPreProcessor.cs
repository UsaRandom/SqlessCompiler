using System.Runtime.ExceptionServices;
using Sqless.Compiler.GlobalScriptCache;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Log;
using System;
using System.Collections.Generic;
using System.IO;
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
		/*
		 * This needs to track which scripts we've imported already, to avoid
		 * recursive references...
		 * 
		 * It also has to restart lexing after every import. (due to index changes)
		 * 
		 */

		var preProcessedSource = new StringBuilder(source);
		var tokenStream = new BufferedTokenStream(m_lexer.Tokenize(source));


		IToken currentToken;


		while(tokenStream.Read())
		{
			currentToken = tokenStream.Current;
			if(currentToken.Type == TokenType.Import)
			{
				//we found an 'import' token.
				var expectedScriptIdentifier = tokenStream.Peek(1);
				var expectedSemicolon = tokenStream.Peek(2);

				if((expectedScriptIdentifier != default(IToken) && (expectedScriptIdentifier.Type == TokenType.Identifier || expectedScriptIdentifier.Type == TokenType.CharLiteral)) &&
					(expectedSemicolon != default(IToken) && expectedSemicolon.Type == TokenType.Semicolon))
				{
					//the import token was follwed by an equals and a symbol, we should import a script!
					string scriptSource;

				    if (File.Exists(Path.Combine(Environment.CurrentDirectory, expectedScriptIdentifier.Content.Replace("'", string.Empty))))
				    {
                        //remove the import
						preProcessedSource.Remove(currentToken.SourceIndexStart - 2, expectedSemicolon.SourceIndexEnd - currentToken.SourceIndexStart + 2);

						//add the script (and process imports on that script)
						preProcessedSource.Insert(currentToken.SourceIndexStart - 2, ProcessImports(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, expectedScriptIdentifier.Content.Replace("'", string.Empty)))));
				        
				    }
					else if(m_globalScriptCache.TryGetSource(expectedScriptIdentifier.Content, out scriptSource))
					{

						//remove the import
						preProcessedSource.Remove(currentToken.SourceIndexStart , expectedSemicolon.SourceIndexEnd - currentToken.SourceIndexStart + 2);

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
