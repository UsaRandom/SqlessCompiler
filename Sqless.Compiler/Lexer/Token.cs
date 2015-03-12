using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer
{
public class Token : IToken
{

	public Token(TokenType type, string content, int lineColumnStart)
	{
		Type = type;
		Content = content;
		LineColumnStart = lineColumnStart;
	}

	public string Content
	{
		get;
		private set;
	}

	public TokenType Type
	{
		get;
		private set;
	}

	public int LineNumber
	{
		get;
		set;
	}

	public int LineColumnStart
	{
		get;
		private set;
	}
	
	public int LineColumnEnd
	{
		get
		{
			return LineColumnStart + Content.Length - 1;
		}
	}

	public int SourceIndexStart { get; set; }

	public int SourceIndexEnd { get; set; }


	public bool Overlaps(IToken token)
	{
		var startInside = token.LineColumnStart >= this.LineColumnStart && token.LineColumnStart <= this.LineColumnEnd;
		var endInside = token.LineColumnEnd >= this.LineColumnStart && token.LineColumnEnd <= this.LineColumnEnd;

		var startsBefore = token.LineColumnStart < this.LineColumnStart;
		var endsAfter = token.LineColumnEnd > this.LineColumnEnd;

		return (startInside|| startsBefore) && (endInside || endsAfter);
	}


	public bool Inside(int start, int end)
	{
		return this.LineColumnStart >= start && this.LineColumnEnd <= end;
	}
}
}
