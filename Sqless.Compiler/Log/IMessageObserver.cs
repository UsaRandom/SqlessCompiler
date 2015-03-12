using Sqless.Compiler.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Log
{
interface IMessageObserver
{
	void Message(ICompilerMessage message);
}
}
