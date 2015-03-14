using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer.LexerLibrary.TSql;

namespace Sqless.Compiler.Lexer
{
class SqlessLexerLibrary : ILexerLibrary
{
	public IList<LexerDefinition> LexerDefinitions
	{
		get { return lexerDefinitions; }
	}


	static SqlessLexerLibrary()
	{
		lexerDefinitions = new List<LexerDefinition>();

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

	private static readonly List<LexerDefinition> lexerDefinitions; 
}
}
