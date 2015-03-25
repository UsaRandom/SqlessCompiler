using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;

namespace Sqless.Compiler.Lexer
{
interface IBufferedTokenStream
{
	bool Read();

	IToken Current { get; }

	bool HasNextToken { get; }

	IToken Peek(int distanceFromCurrent);
}
}
