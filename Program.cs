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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="args">
		/// 
		///  "InputFile" "OutputFile"
		/// 
		/// </param>

		static void Main(string[] args)
		{
			if(args.Length != 2)
				return;
			
			var inputFile = args[0];
			var outputFile = args[1];

			


			if(!File.Exists(inputFile))
				throw new Exception(inputFile + " was not found.");
			if(!File.Exists(outputFile))
				throw new Exception(outputFile + " was not found.");
				
		    if(!Directory.Exists(Path.GetDirectoryName(outputFile)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
			}


		    Environment.CurrentDirectory = Path.GetDirectoryName(inputFile);

			var source = File.ReadAllText(inputFile);

			if (source != string.Empty)
			{
				
				var sqlssCompiler = new Sqless.Compiler.SqlessCompiler();
				var stopWatch = new Stopwatch();

				stopWatch.Start();

				var result = sqlssCompiler.TranspileToMSSql(source);

				stopWatch.Stop();
				
				File.WriteAllText(outputFile, result);
			}
			else
			{
				
				File.WriteAllText(outputFile, string.Empty);
			}
	

		}
	}
}
