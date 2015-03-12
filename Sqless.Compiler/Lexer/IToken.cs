using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer
{
public interface IToken
{
	string Content { get; }

	TokenType Type { get; }

	int LineNumber { get; set; }

	int LineColumnStart { get; }

	int LineColumnEnd { get; }

	int SourceIndexStart { get; set; }

	int SourceIndexEnd { get; set; }

	bool Overlaps(IToken token);

	bool Inside(int start, int end);
}
}
