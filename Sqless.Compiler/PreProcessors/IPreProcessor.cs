using Sqless.Compiler.Analysis.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.PreProcessors
{
interface IPreProcessor
{
	void PreProcess(ILexer lexer);
}
}
