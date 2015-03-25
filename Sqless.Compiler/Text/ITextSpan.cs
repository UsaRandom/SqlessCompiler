using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Text
{
interface ITextSpan
{
	bool ContainsTextSpan(ITextSpan span);

	bool OverlapsWithTextSpan(ITextSpan span);

	ITextSpan GetOverlapingTextSpan(ITextSpan span);

	int Start
	{
		get;
	}

	int End
	{
		get;
	}

	int Length
	{
		get;
	}

	bool IsEmpty
	{
		get;
	}
}
}
