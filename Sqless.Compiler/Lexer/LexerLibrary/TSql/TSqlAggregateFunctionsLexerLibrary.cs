using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer.LexerLibrary.TSql
{
class TSqlAggregateFunctionsLexerLibrary : ILexerLibrary
{
	public IList<LexerDefinition> LexerDefinitions
	{
		get { return lexerDefinitions; }
	}


	static TSqlAggregateFunctionsLexerLibrary()
	{
		lexerDefinitions = new List<LexerDefinition>
		{
			new LexerDefinition(TokenType.Avg, "(?i)avg"),
			new LexerDefinition(TokenType.Min, "(?i)min"),
	//		new LexerDefinition(TokenType.CheckSum_Agg, "(?i)checksum_agg"),
			new LexerDefinition(TokenType.Sum, "(?i)sum"),
			new LexerDefinition(TokenType.Count, "(?i)count"),
	//		new LexerDefinition(TokenType.StDev, "(?i)stdev"),
	//		new LexerDefinition(TokenType.Count_Big, "(?i)count_big"),
	//		new LexerDefinition(TokenType.StDevP, "(?i)stdevp"),
	//		new LexerDefinition(TokenType.Grouping, "(?i)grouping"),
	//		new LexerDefinition(TokenType.Var, "(?i)var"),
	//		new LexerDefinition(TokenType.Grouping_Id, "(?i)grouping_id"),
	//		new LexerDefinition(TokenType.VarP, "(?i)varp"),
			new LexerDefinition(TokenType.Max, "(?i)max")
		};
	}
	
	private static readonly List<LexerDefinition> lexerDefinitions; 
}
}
