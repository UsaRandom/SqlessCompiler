using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer.LexerLibrary.TSql;

namespace Sqless.Compiler.Lexer
{
class TSqlLexerLibrary : ILexerLibrary
{
	public IList<LexerDefinition> LexerDefinitions
	{
		get { return lexerDefinitions; }
	}


	static TSqlLexerLibrary()
	{
		lexerDefinitions = new List<LexerDefinition>();

		
		lexerDefinitions.AddRange(new TSqlAggregateFunctionsLexerLibrary().LexerDefinitions);
		lexerDefinitions.AddRange(new TSqlAnalyticFunctionsLexerLibrary().LexerDefinitions);

	}

	private static readonly List<LexerDefinition> lexerDefinitions; 
}
}
