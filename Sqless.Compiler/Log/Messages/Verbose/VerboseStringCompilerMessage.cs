using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Log.Messages
{
class VerboseStringCompilerMessage : ICompilerMessage
{
	public VerboseStringCompilerMessage(string message)
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
