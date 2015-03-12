using Sqless.Compiler.Analysis.Lexer.Automata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sqless.Compiler.Analysis.Lexer
{
class LexerDefinition
{
	public LexerDefinition(TokenType tokenType, string regexString, params State[] states)
	{
		if(states != null && states.Length != 0)
			m_stateMachine = new StateMachine(states);

		m_tokenType = tokenType;
		m_regex = new Regex(regexString);
		
	}

	public bool Matches(string source, out IList<IToken> tokens)
	{  
		tokens = default(IList<IToken>);

		var match = m_regex.Match(source);

		if (!match.Success)
			return false;
		
		tokens = new List<IToken>();

		do
		{
			IToken newToken;

			newToken = new Token(m_tokenType, match.Value, match.Index);

			//use state machine if present for extra validation
			if (m_stateMachine != null && m_stateMachine.IsValid(match.Value))
			{
				tokens.Add(newToken);
			}
			else if (m_stateMachine == null)
			{
				tokens.Add(newToken);
			}


			match = match.NextMatch();

		} while (match.Success);

		return true;
	}
	
	private readonly Regex m_regex;
	private readonly TokenType m_tokenType;
	private readonly StateMachine m_stateMachine;
}
}
