using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)select"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)from"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)where"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)inner"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)left"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)right"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)full"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)order"));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)without"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)sum"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)avg"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)count"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)byte"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)short"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)int"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)long"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)byte\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "(?i)using"));

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
		lexerDefinitions.Add(new LexerDefinition(TokenType.LeftParenthesis, "\\("));
		lexerDefinitions.Add(new LexerDefinition(TokenType.RightParenthesis, "\\)"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Semicolon, ";"));

		//Literals
		lexerDefinitions.Add(new LexerDefinition(TokenType.StringLiteral, "'[^']+'"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.StringLiteral, "\"[^\"]+\""));
		lexerDefinitions.Add(new LexerDefinition(TokenType.IntLiteral, "[0-9]+"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.IntLiteral, "[0-9]+"));
	}

	private static readonly List<LexerDefinition> lexerDefinitions; 
}
}
