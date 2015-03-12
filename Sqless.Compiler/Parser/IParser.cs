using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;

namespace Sqless.Compiler.Parser
{
interface IParser
{
	IList<ISqlBatchParseTree> Parse(IEnumerable<IToken> tokens);
}
}
