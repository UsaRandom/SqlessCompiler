using Sqless.Compiler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

			source = File.ReadAllText("C:/users/marti/Desktop/SqlessWorkspace/Sqless.sql");
			if (source != string.Empty)
			{
				
				var sqlssCompiler = new Sqless.Compiler.SqlessCompiler();
				var stopWatch = new Stopwatch();

				stopWatch.Start();

				var result = sqlssCompiler.TranspileToMSSql(source);

				stopWatch.Stop();

				Console.ForegroundColor = ConsoleColor.Green;
			
				Console.WriteLine("Transpiled in: " + stopWatch.Elapsed);

				Console.ForegroundColor = ConsoleColor.Gray;
			

				Console.WriteLine(result);

				File.WriteAllText("C:/users/marti/Desktop/SqlessWorkspace/TSqlResult.sql", result);
			}
			else
			{
				
				File.WriteAllText("C:/users/marti/Desktop/SqlessWorkspace/TSqlResult.sql", string.Empty);
			}
	

		}
	}
}
