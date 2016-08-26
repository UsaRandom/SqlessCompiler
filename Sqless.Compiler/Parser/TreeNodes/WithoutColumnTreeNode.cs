using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class WithoutColumnTreeNode : AbstractSyntaxTreeNode
	{
		public WithoutColumnTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base (stream, symbolTable)
		{
			Type = stream.Current.Type;
			stream.Read();

			stream.Read();

			m_column = stream.Current.Content;

			stream.Read();
			stream.Read();


		}



		public override void Pass()
		{
			var select = (SelectTreeNode) Parent.Parent.Parent;

			if (select.FromNode.Tables.Count != 0)
			{
				var table = select.FromNode.Tables[0];
				int maxColsPerRow = 6;
				int colCount = 0;
				foreach (var column in table.Columns)
				{
					if (column.Name.ToLower() != m_column.ToLower())
					{
						colCount++;
						builtText += column.Name + ", ";
					}

					if (colCount == maxColsPerRow)
					{
						builtText += "\n       ";
						colCount = 0;
					}
				}

				builtText = builtText.Substring(0, builtText.Length - 2);
			}
		}



		
		public override string GetMSSqlText()
		{
			return builtText;
		}


		private string builtText = "";

		private string m_column = "";

	}
}
