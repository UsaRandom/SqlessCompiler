using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Analysis.Lexer.Automata
{
interface IState
{
	bool TryGetNext(char inputCharacter, StateMachine stateMachine, out IState nextState);
}
}
