using Sqless.Compiler.Log.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Log
{
class VerboseCompilerObserver : IMessageObserver
{
	public void Message(ICompilerMessage message)
	{
		if(message is VerboseStringCompilerMessage)
		{
			Console.WriteLine(message.Message);
		}
	}
}
}
