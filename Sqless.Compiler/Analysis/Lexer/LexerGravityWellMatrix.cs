using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Analysis.Lexer
{
class LexerGravityWellMatrix
{
	
	public IList<IToken> Prioritize(IList<IList<IToken>> tokenMatrix, int lineLength)
	{
		return PrioritizeRange(tokenMatrix, 0, lineLength - 1);
	}

	/*
	 * This is a recursive way of finding the priority tokens in a line.
	 * We look to see which token is the 'highest priority' in a given range (start with entire range)
	 * 
	 * We then recursively check the remaining left and right ranges (areas not containing the
	 * high priority token), then we concatenate all the tokens together to get our list.
	 * 
	 */

	private IList<IToken> PrioritizeRange(IList<IList<IToken>> tokenMatrix, int min, int max)
	{
		IList<IToken> childResults = default(IList<IToken>);

		var tokenList = new List<IToken>();

		//get the highest priority token in this range
		var priorityToken = GetMaximumPriorityTokenInRange(tokenMatrix, min, max);

		if(priorityToken == null)
			return null;

		//do we need to get left tokens?
		if(priorityToken.LineColumnStart > min)
		{
			childResults = PrioritizeRange(tokenMatrix, min, priorityToken.LineColumnStart - 1);

			if(childResults != null)
				tokenList.AddRange(childResults);
		}

		tokenList.Add(priorityToken);

		//do we need to get right tokens?
		if(priorityToken.LineColumnEnd < max)
		{
			childResults = PrioritizeRange(tokenMatrix, priorityToken.LineColumnEnd + 1, max);
			
			if(childResults != null)
				tokenList.AddRange(childResults);
		}

		return tokenList;
	}


	private IToken GetMaximumPriorityTokenInRange(IList<IList<IToken>> tokenMatrix, int min, int max)
	{	
		
		IToken currentToken  = default(IToken);

		// Tokens may overlap
		//
		// Rules here are simple:
		//
		// Tokens are tested in a prioritiezed order,
		// if two tokens are overlaping we check to see
		// if the newer lower priority token is longer
		// than the previous higher priority token.
		// If it is, the new token wins.
		// If they are equal in length or the new token is
		// shorter than the previous, the previous token 
		// remains, and the new token is ignored.

		//Note: This is probably not the most ideal way to go about this... probably a better data structure.
		foreach(var tokenList in tokenMatrix)
		{
			foreach (var token in tokenList)
			{
				//is token inside our given range?
				if (token.Inside(min, max))
				{
					if(currentToken == null)
					{
						//have we found a token in this range yet?
						currentToken = token;
					}
					else if(token.Content.Length > currentToken.Content.Length)
					{
						//did we find a larger token?
						currentToken = token;
					}
				}
			}
		}


		return currentToken;
	}

}
}
