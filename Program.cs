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

import Energy;

using OGPA = dbo.OilGasProductionArea;
using OGPA_OGW = Energy.dbo.OilGasProductionArea_OilGasWell;

var permianId = 43;

SELECT * without (Geography)
FROM OGPA
	JOIN OGPA_OGW
WHERE OPGA.Id = permianId

";

			var sqlssCompiler = new Sqless.Compiler.SqlessCompiler();

			var result = sqlssCompiler.Compile(source);

			Console.WriteLine(result);
			Console.ReadLine();
		}
	}
}
