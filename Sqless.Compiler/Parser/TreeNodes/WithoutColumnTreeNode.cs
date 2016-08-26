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
             m_columns= new List<string>();
			Type = stream.Current.Type;
			stream.Read();

		//	stream.Read();
            
			bool onFirstColumn = true;

			do
			{
                
				stream.Read();
                    

				if (stream.Current.Type != TokenType.RightParenthesis && stream.Current.Type != TokenType.NewLine && stream.Current.Type != TokenType.Comma)
				{
					m_columns.Add(stream.Current.Content);
				}
                

			} while (stream.Current.Type != TokenType.RightParenthesis);


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
			    int columnIndex = 0;
				foreach (var column in table.Columns)
				{
				    columnIndex++;
				    var columnMatchesAny = false;

				    foreach (var hiddenColumn in m_columns)
				    {
				        
					    if (column.Name.ToLower() == hiddenColumn.ToLower())
					    {
					        columnMatchesAny = true;
					        break;
					    }
				    }

					if (!columnMatchesAny)
					{
						colCount++;
						builtText += column.Name + ", ";
					}

					if (colCount == maxColsPerRow && table.Columns.Count  != columnIndex)
					{
						builtText += "\n       ";
						colCount = 0;
					}
				}

			    builtText = builtText.Remove(builtText.LastIndexOf(", "), 2);
			}
		}



		
		public override string GetMSSqlText()
		{
			return builtText;
		}


		private string builtText = "";
        

	    private List<string> m_columns;

	}
}
