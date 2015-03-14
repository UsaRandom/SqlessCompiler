using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer
{
interface ILexerLibrary
{
	IList<LexerDefinition> LexerDefinitions { get; } 
}
}
