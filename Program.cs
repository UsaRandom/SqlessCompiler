using Sqless.Compiler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlessCompiler
{
	class Program
	{
		static void Main(string[] args)
		{

			string source = @"

var intTest = 532;

var expressionTest = (2-1)+-1;

var floatTest = 3.2;

var doubleTest = 25215.0352d;

SELECT *, (2+1),2,63,intTest
FROM dbo.OilGasWell


//null coalesce
//SELECT [val] ?? [val2] ?? [val3] ?? i
//FROM Object

//SELECT * WITHOUT(Geography), COUNT(OGW.Id)
//FROM OGPA
//	JOIN OilGasWellPRoductionArea_OilGasWell OGW
//WHERE OGPA.Id = i
";

			var sqlssCompiler = new Sqless.Compiler.SqlessCompiler();
			var stopWatch = new Stopwatch();

			stopWatch.Start();

			var result = sqlssCompiler.TranspileToMSSql(source);

			stopWatch.Stop();

			Console.ForegroundColor = ConsoleColor.Green;
			
			Console.WriteLine("Transpiled in: " + stopWatch.Elapsed);

			Console.ForegroundColor = ConsoleColor.Gray;
			

			Console.WriteLine(result);
			Console.ReadLine();
		}
	}
}
