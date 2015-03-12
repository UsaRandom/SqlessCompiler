using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Analysis.Lexer
{
public interface IToken
{
	string Content { get; }

	TokenType Type { get; }

	int LineNumber { get; set; }

	int LineColumnStart { get; }

	int LineColumnEnd { get; }

	bool Overlaps(IToken token);

	bool Inside(int start, int end);
}
}
