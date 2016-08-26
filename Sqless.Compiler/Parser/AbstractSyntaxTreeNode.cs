using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Parser.TreeNodes;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser
{
	class AbstractSyntaxTreeNode
	{

		public AbstractSyntaxTreeNode(IBufferedTokenStream tokenStream, ISymbolTable symbolTable)
		{
			m_children = new List<AbstractSyntaxTreeNode>();
			m_tokenStream = tokenStream;
			SymbolTable = symbolTable;
		}
		
		public virtual void Parse()
		{
			m_tokenStream.Read();
			while (m_tokenStream.HasNextToken)
			{
				AbstractSyntaxTreeNode childStatement;
				switch (m_tokenStream.Current.Type)
				{
					case TokenType.Var:
						childStatement = new VariableDeclarationTreeNode(m_tokenStream, SymbolTable);
						m_children.Add(childStatement);
						break;
					case TokenType.Comment:
						childStatement = new CommentTreeNode(m_tokenStream, SymbolTable);
						m_children.Add(childStatement);
						break;
					case TokenType.NewLine:
						childStatement = new NewLineTreeNode(m_tokenStream, SymbolTable);
						m_children.Add(childStatement);
						break;
					case TokenType.Select:
						childStatement = new SelectTreeNode(m_tokenStream, SymbolTable);
						m_children.Add(childStatement);
						break;
					default:
						Console.WriteLine("Unmatched Token of type {0}\n \t\tat line {1}", m_tokenStream.Current.Type, m_tokenStream.Current.LineNumber);
						m_tokenStream.Read();
						break;
				}
			}
		}


		public virtual string GetMSSqlText()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var child in m_children)
			{
				sb.Append(child.GetMSSqlText());
			}

			return sb.ToString();
		}


		protected string GetMSSqlType(SymbolType type)
		{
			switch (type)
			{
				case SymbolType.Int:
				case SymbolType.NullableInt:
					return "INT";
				case SymbolType.Float:
				case SymbolType.NullableFloat:
					return "FLOAT(24)";
				case SymbolType.Double:
				case SymbolType.NullableDouble:
					return "FLOAT(53)";
			}
			return "UNKNOWN_MSSQL_TYPE";
		}


		public bool TokenIsOperator(TokenType type)
		{
			switch (type)
			{
				case TokenType.Plus:
				case TokenType.Minus:
				case TokenType.Asterisk:
				case TokenType.Divide:
					return true;
			}

			return false;
		}
		
		public ISymbolTable SymbolTable
		{
			get;
			private set;
		}
		

		public virtual TokenType Type
		{
			get; set;
		}

		protected IBufferedTokenStream m_tokenStream;
		protected IList<AbstractSyntaxTreeNode> m_children;
	}
}
