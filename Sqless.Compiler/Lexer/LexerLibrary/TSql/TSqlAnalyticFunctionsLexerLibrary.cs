using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer.LexerLibrary.TSql
{
class TSqlAnalyticFunctionsLexerLibrary : ILexerLibrary
{
	public IList<LexerDefinition> LexerDefinitions
	{
		get { return lexerDefinitions; }
	}


	static TSqlAnalyticFunctionsLexerLibrary()
	{
		lexerDefinitions = new List<LexerDefinition>
		{
	//		new LexerDefinition(TokenType.Cube_Dist, "(?i)cube_dist"),
	//		new LexerDefinition(TokenType.Lead, "(?i)lead"),
	//		new LexerDefinition(TokenType.First_Value, "(?i)first_value"),
	//		new LexerDefinition(TokenType.Percentile_Cont, "(?i)percentile_cont"),
	//		new LexerDefinition(TokenType.Lag, "(?i)lag"),
	//		new LexerDefinition(TokenType.Percentile_Disc, "(?i)percentile_disc"),
	//		new LexerDefinition(TokenType.Last_Value, "(?i)last_value"),
	//		new LexerDefinition(TokenType.Percent_Rank, "(?i)percent_rank")
		};
	}
	
	private static readonly List<LexerDefinition> lexerDefinitions; 
}
}
