using Sqless.Compiler.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Log
{
interface ICompilerLog
{
	void AddObserver(IMessageObserver observer);

	void Info(string message);
	void Verbose(string message);
}
}
