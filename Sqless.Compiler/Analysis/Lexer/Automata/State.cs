using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Analysis.Lexer.Automata
{
class State : IState
{
	public State(Func<char, int> testFunc)
	{
		m_testFunc = testFunc;
	}

	public bool TryGetNext(char inputCharacter, StateMachine stateMachine, out IState nextState)
	{
		nextState = default(IState);
		
		if(!stateMachine.TryGetStateAtIndex(m_testFunc.Invoke(inputCharacter), out nextState))
			return false;

		return true;
	}


	private Func<char, int> m_testFunc;
}
}
