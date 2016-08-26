using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class WhereTreeNode : AbstractSyntaxTreeNode
	{
		public WhereTreeNode(IBufferedTokenStream tokenStream, ISymbolTable symbolTable)
			: base(tokenStream, symbolTable)
		{
			
			//select *

			tokenStream.Read();

            

			bool onFirstColumn = true;

			do
			{

				if (!onFirstColumn)
				{
					
					if (tokenStream.Current.Type == TokenType.NewLine)
					{
						m_children.Add(new NewLineTreeNode(tokenStream, symbolTable));
					}
					

				}

				

				if (tokenStream.Current.Type == TokenType.Identifier)
				{
					m_children.Add(new ExpressionTreeNode(tokenStream, symbolTable));
					break;
				}

				onFirstColumn = false;

			} while (tokenStream.Current.Type != TokenType.Semicolon && 
					 tokenStream.Current.Type != TokenType.From && (tokenStream.Current.Type == TokenType.Comma
																	|| tokenStream.Current.Type == TokenType.NewLine));



			foreach (var child in m_children)
			{
				child.Parent = this;
			}


		}


		public override void Pass()
		{
			foreach (var child in m_children)
			{
				child.Pass();
			}
		}
		

		public override string GetMSSqlText()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("WHERE ");

			foreach (var child in m_children)
			{
				sb.Append(child.GetMSSqlText());

				if (child is CommaTreeNode)
				{
					sb.Append(" ");
				}
			}
			
			return sb.ToString();
		}
		

	}
}
