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
		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Select, "(?i)select"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.From, "(?i)from"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Where, "(?i)where"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Left, "(?i)left"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Right, "(?i)right"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Full, "(?i)full"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Order, "(?i)order"));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Without, "(?i)without"));


		lexerDefinitions.Add(new LexerDefinition(TokenType.Sum, "(?i)sum"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Avg, "(?i)avg"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Count, "(?i)count"));


		lexerDefinitions.Add(new LexerDefinition(TokenType.Byte, "byte"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Short, "short"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Int, "int"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Long, "long"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableByte, "byte\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableShort, "short\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableInt, "int\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableLong, "long\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.ByteLiteral, "[1-9][0-9].b"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.ShortLiteral, "[1-9][0-9].s"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.IntLiteral, "[1-9][0-9]."));
		lexerDefinitions.Add(new LexerDefinition(TokenType.LongLiteral, "[1-9][0-9].l"));


		lexerDefinitions.Add(new LexerDefinition(TokenType.Float, "float"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Double, "double"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableFloat, "float\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableDouble, "double\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.FloatLiteral, "[0-9]+\\.[0-9]+"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.DoubleLiteral, "[0-9]+\\.[0-9]+d"));


		
		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Char, "char"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NChar, "nchar"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.String, "string"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NString, "nstring"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableChar, "char\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableNChar, "nchar\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableString, "string\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableNString, "nstring\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.CharLiteral, "'[^']+'"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.StringLiteral, "\"[^\"]+\""));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NCharLiteral, "n'[^']+'"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NStringLiteral, "n\"[^\"]+\""));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Date, "date"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Time, "time"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Time, "datetime"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableDate, "date\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableTime, "time\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableTime, "datetime\\?"));
		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Bool, "bool"));		
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullableBool, "bool\\?"));		
		lexerDefinitions.Add(new LexerDefinition(TokenType.BoolLiteral, "true|false"));		

		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Import, "import"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Using, "using"));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Var, "var"));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Def, "def"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.TempTable, "(?i)#[a-z]+"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.TableVariable, "(?i)@[a-z]+"));

		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Null, "null"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullCoalesce, "\\?\\?"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullEquality, "\\?="));
		lexerDefinitions.Add(new LexerDefinition(TokenType.NullNegatedEquality, "\\?!="));
		
		lexerDefinitions.Add(new LexerDefinition(TokenType.Identifier, @"(?i)[a-z_]+"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Dot, "\\."));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Comma, ","));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Asterisk, "\\*"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Plus, "\\+"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Minus, "-"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Divide, "\\\\"));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Equals, "="));

		lexerDefinitions.Add(new LexerDefinition(TokenType.And, "and|&&"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Or, "or|\\|\\|"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.Not, "not|!"));

		
		
		lexerDefinitions.Add(new LexerDefinition(TokenType.LeftParenthesis, "\\("));
		lexerDefinitions.Add(new LexerDefinition(TokenType.RightParenthesis, "\\)"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.LeftCurlyBracket, "{"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.RightCurlyBracket, "}"));
		lexerDefinitions.Add(new LexerDefinition(TokenType.LeftBracket, "\\["));
		lexerDefinitions.Add(new LexerDefinition(TokenType.RightBracket, "\\]"));

		lexerDefinitions.Add(new LexerDefinition(TokenType.Semicolon, ";"));

	}

	private static readonly List<LexerDefinition> lexerDefinitions; 
}
}
