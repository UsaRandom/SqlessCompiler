using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer.Automata
{
class StateMachine
{
	public StateMachine(params IState[] states)
	{
		if (states == null || states.Length == 0)
			throw new ApplicationException("Invalid state machine");

		m_states = new List<IState>(states);
	}

	public bool IsValid(string token)
	{
		if(string.IsNullOrWhiteSpace(token))
			return false;

		IState currentState = m_states[0];
		char currentChar = default(char);


		for(var tokenIndex = 0; tokenIndex < token.Length - 1; tokenIndex++)
		{
			currentChar = token[tokenIndex];

			if(!currentState.TryGetNext(currentChar, this, out currentState))
				return false;
		}


		return true;
	}

	public bool TryGetStateAtIndex(int stateIndex, out IState nextState)
	{
		if(stateIndex > m_states.Count - 1)
			throw new Exception("State machine attempted to move to invalid state");

		nextState = default(IState);

		if(stateIndex == -1)
			return false;

		nextState = m_states[stateIndex];

		return true;
	}


	private IList<IState> m_states;

}
}
