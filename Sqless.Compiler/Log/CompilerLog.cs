using Sqless.Compiler.Log.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Log
{
class CompilerLog : ICompilerLog
{

	public CompilerLog()
	{
		m_observers = new List<IMessageObserver>();
	}

	public void AddObserver(IMessageObserver observer)
	{
		m_observers.Add(observer);
	}

	public void Info(string message)
	{
		Log(new InfoStringCompilerMessage(message));
	}

	public void Verbose(string message)
	{
		Log(new VerboseStringCompilerMessage(message));
	}

	private void Log(ICompilerMessage message)
	{
		foreach(var observer in m_observers)
		{
			observer.Message(message);
		}
	}


	private IList<IMessageObserver> m_observers;
}
}
