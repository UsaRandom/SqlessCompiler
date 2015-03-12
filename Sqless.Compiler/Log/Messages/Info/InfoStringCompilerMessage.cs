using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Log.Messages
{
class InfoStringCompilerMessage : ICompilerMessage
{
	public InfoStringCompilerMessage(string message)
	{
		Message = message;
	}

	public string Message
	{
		get;
		private set;
	}
}
}
