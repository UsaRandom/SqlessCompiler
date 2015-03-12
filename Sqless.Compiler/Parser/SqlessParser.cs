using Sqless.Compiler.Lexer;
using Sqless.Compiler.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Parser
{
class SqlessParser : IParser
{
	public IList<ISqlBatchParseTree> Parse(IEnumerable<IToken> tokens)
	{
		throw new NotImplementedException();
	}
}
}
