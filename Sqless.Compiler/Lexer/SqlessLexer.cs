using Sqless.Compiler.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer
{
class SqlessLexer : ILexer
{
	public SqlessLexer(ICompilerLog compilerLog)
	{
		m_compilerLog = compilerLog;
	}

	public IEnumerable<IToken> Tokenize(string source)
	{
		if(string.IsNullOrWhiteSpace(source))
			throw new Exception("Empty Source");

		int currentSourceIndex = 0;
		string[] sourceLines = source.Split('\n');
		
		var gravityWellMatrix = new LexerGravityWellMatrix();
		IList<IList<IToken>> matchedTokenMatrix;
		
		m_compilerLog.Verbose("Lexer Source Lines: " + sourceLines.Length);

		string line = string.Empty;
		
		//process source, line by line.
		for (var lineIndex = 0; lineIndex < sourceLines.Length; lineIndex++)
		{
			line = sourceLines[lineIndex];
			
			if (line == string.Empty)
				continue;

			matchedTokenMatrix = new List<IList<IToken>>();

			foreach(var lexerDefinition in lexerDefinitions)
			{
				IList<IToken> lexerDefinitionTokenMatches;

				if(lexerDefinition.Matches(line, out lexerDefinitionTokenMatches))
				{
					matchedTokenMatrix.Add(lexerDefinitionTokenMatches);
				}
			}


			if (matchedTokenMatrix.Count == 0)
			{
				//no tokens on this line
				continue;
			}

			var prioritizedTokenResults = gravityWellMatrix.Prioritize(matchedTokenMatrix, line.Length);

			
			
			foreach(var validToken in prioritizedTokenResults)
			{
				validToken.LineNumber = lineIndex + 1;
				validToken.SourceIndexStart = currentSourceIndex + validToken.LineColumnStart;
				validToken.SourceIndexEnd = currentSourceIndex + validToken.LineColumnEnd;

				m_compilerLog.Verbose("Token : " + validToken.Type);

				yield return validToken;
			}

			currentSourceIndex += line.Length + 1; //length of line, plus new line
		}
	}


	private ICompilerLog m_compilerLog;

	static SqlessLexer()
	{
		lexerDefinitions = new List<LexerDefinition>();


		//Lexer Definitions (Order defines priority)

		//TSql Keywords
		lexerDefinitions.Add(new LexerDefinition(TokenType.Select, "(?i)select"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.From, "(?i)from"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Join, "(?i)join"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Where, "(?i)where"));

		//SqlSS Keywords
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Without, "(?i)without"));		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Var, "(?i)var"));		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Import, "(?i)import"));

		//Operators
		lexerDefinitions.Add(new LexerDefinition(TokenType.Equals, "="));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Asterisk, "\\*"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Dot, "\\."));

		//Symbol
		lexerDefinitions.Add(new LexerDefinition(TokenType.Symbol, @"(?i)[a-z_]+"));

		//Scope (kinda...)
		lexerDefinitions.Add(new LexerDefinition(TokenType.Left_Parenthesis, "\\("));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Right_Parenthesis, "\\)"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Semicolon, ";"));

		//Literals
		lexerDefinitions.Add(new LexerDefinition(TokenType.StringLiteral, "'[^']+'"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.StringLiteral, "\"[^\"]+\""));
		lexerDefinitions.Add(new LexerDefinition(TokenType.IntegerLiteral, "[0-9]+"));

	}

	private static IList<LexerDefinition> lexerDefinitions;

}
}
