using Sqless.Compiler;
using System;
using System.Collections.Generic;
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

var floatTest = 3.2

var doubleTest = 25215.0352d


//null coalesce
//SELECT [val] ?? [val2] ?? [val3] ?? i
//FROM Object

//SELECT * WITHOUT(Geography), COUNT(OGW.Id)
//FROM OGPA
//	JOIN OilGasWellPRoductionArea_OilGasWell OGW
//WHERE OGPA.Id = i
";

			var sqlssCompiler = new Sqless.Compiler.SqlessCompiler();

			var result = sqlssCompiler.TranspileToMSSql(source);

			Console.WriteLine(result);
			Console.ReadLine();
		}
	}
}
