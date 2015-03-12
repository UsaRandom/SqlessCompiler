using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer
{
public class BufferedTokenStream : IBufferedTokenStream
{

	public BufferedTokenStream(IEnumerable<IToken> tokens)
	{

	}

	public IToken Read()
	{
		throw new NotImplementedException();
	}

	public IToken Current
	{
		get { throw new NotImplementedException(); }
	}

	public bool HasNextToken
	{
		get { throw new NotImplementedException(); }
	}

	public IToken Peek(int distanceFromCurrent)
	{
		throw new NotImplementedException();
	}
}
}
