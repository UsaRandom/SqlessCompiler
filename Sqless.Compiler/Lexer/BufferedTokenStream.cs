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
		m_tokenEnumerator = tokens.GetEnumerator();
		m_tokenQueue = new Queue<IToken>();

	}

	public bool Read()
	{
		if(m_tokenQueue.Count > 0)
		{
			m_tokenQueue.Dequeue();
			BufferNextToken();
			return HasNextToken;
		}

		BufferNextToken();
		return HasNextToken;
	}


	public bool HasNextToken
	{
		get
		{ 
			return m_tokenQueue.Count != 0;
		}
	}

	public IToken Current
	{
		get
		{
			if(m_tokenQueue.Count == 0)
				return null;
			return m_tokenQueue.Peek();
		}
	}

	public IToken Peek(int distanceFromCurrent)
	{
		if(distanceFromCurrent < 0)
			throw new Exception("Umm no");


		var tokenDifference = distanceFromCurrent - m_tokenQueue.Count + 1;

		if (tokenDifference > 0)
		{
			for(var i = 0; i < tokenDifference; i++)
			{
				BufferNextToken();
			}
		}

		return m_tokenQueue.ElementAt(distanceFromCurrent);
	}

	private void BufferNextToken()
	{
		if(m_tokenEnumerator.MoveNext())
		{
			m_tokenQueue.Enqueue(m_tokenEnumerator.Current);
		}
	}

	private Queue<IToken> m_tokenQueue;
	private IEnumerator<IToken> m_tokenEnumerator;
}
}
