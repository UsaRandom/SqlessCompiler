using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Analysis.Lexer
{
public interface ILexer
{
	IEnumerable<IToken> Tokenize(string source);
}
}
