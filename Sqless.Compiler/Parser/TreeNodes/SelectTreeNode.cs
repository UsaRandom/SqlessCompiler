using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class SelectTreeNode : AbstractSyntaxTreeNode
	{
		public SelectTreeNode(IBufferedTokenStream tokenStream, ISymbolTable symbolTable)
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
					else if (tokenStream.Current.Type == TokenType.Comma)
					{
						m_children.Add(new CommaTreeNode(tokenStream, symbolTable));
					}

				}

				if (tokenStream.Current.Type != TokenType.Semicolon &&
				    tokenStream.Current.Type != TokenType.From)
				{
					m_children.Add(new SelectColumnTreeNode(tokenStream, symbolTable));
				}

				onFirstColumn = false;

			} while (tokenStream.Current.Type != TokenType.Semicolon && 
					 tokenStream.Current.Type != TokenType.From && (tokenStream.Current.Type == TokenType.Comma
																	|| tokenStream.Current.Type == TokenType.NewLine));


			if (tokenStream.Current.Type == TokenType.From)
			{
				FromNode = new FromTreeNode(tokenStream, symbolTable);
				FromNode.Parent = this;
			}

			foreach (var child in m_children)
			{
				child.Parent = this;
			}


		}


		public override void Pass()
		{
			if (FromNode != null)
				FromNode.Pass();

			foreach (var child in m_children)
			{
				child.Pass();
			}
		}
		

		public override string GetMSSqlText()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("SELECT ");

			foreach (var child in m_children)
			{
				sb.Append(child.GetMSSqlText());

				if (child is CommaTreeNode)
				{
					sb.Append(" ");
				}
			}

			if(FromNode != null)
				sb.Append(FromNode.GetMSSqlText());

			return sb.ToString();
		}

		public FromTreeNode FromNode;

	}
}
