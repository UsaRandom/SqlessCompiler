using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class ExpressionTreeNode : AbstractSyntaxTreeNode
	{
		public ExpressionTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base(stream, symbolTable)
		{

		
			if (stream.Current.Type == TokenType.LeftParenthesis)
			{
				stream.Read();
				LeftHandSide = new ExpressionTreeNode(stream, symbolTable);
				WrappedInParenthesis = true;
				stream.Read();
			}
			else if (stream.Current.Type == TokenType.Identifier)
			{
				LeftHandSide = new IdentifierTreeNode(stream, symbolTable);
			}
			else
			{
				LeftHandSide = new LiteralTreeNode(stream, symbolTable);

			}


			var nextTokenIsOperator = false;

			switch (stream.Current.Type)
			{
				case TokenType.Plus:
				case TokenType.Minus:
				case TokenType.Asterisk:
				case TokenType.Divide:
				case TokenType.And:
				case TokenType.Or:
				case TokenType.Equals:
				case TokenType.DoubleEquals:
					nextTokenIsOperator = true;
					break;
			}

			if (nextTokenIsOperator)
			{
				Operator = new OperatorTreeNode(stream, symbolTable);


				if (WrappedInParenthesis && stream.Current.Type == TokenType.RightParenthesis)
				{
					RightHandSide = new ExpressionTreeNode(stream, symbolTable);
				}
				else if (stream.Current.Type == TokenType.Identifier)
				{
					RightHandSide = new ExpressionTreeNode(stream, symbolTable);
				}
				else
				{
					RightHandSide = new ExpressionTreeNode(stream, symbolTable);
				}
			}

			Type = LeftHandSide.Type;

		}
		

		
		public override string GetMSSqlText()
		{
			var lhsText = LeftHandSide.GetMSSqlText();

			if (LeftHandSide is ExpressionTreeNode)
			{
				if(((ExpressionTreeNode)LeftHandSide).WrappedInParenthesis)
				{
				
					lhsText = $"({lhsText})";
				}
				else
				{
					lhsText = $"{lhsText}";
				}
			}

			if (RightHandSide != null && Operator != null)
			{
				var rhsText = RightHandSide.GetMSSqlText();
				
				if (RightHandSide is ExpressionTreeNode)
				{
					if(((ExpressionTreeNode)RightHandSide).WrappedInParenthesis)
					{
				
						rhsText = $"({rhsText})";
					}
					else
					{
						rhsText = $"{rhsText}";
					}
				}

				if(Operator.Type == TokenType.Equals)
				{
					
					return string.Format("SET {0} {1} {2};", lhsText, Operator.GetMSSqlText(), rhsText);
				}
				else
				{
				
					return string.Format("{0} {1} {2}", lhsText, Operator.GetMSSqlText(), rhsText);
				}


			}
			return string.Format("{0}", lhsText);
		}

		public Boolean WrappedInParenthesis = false;

		AbstractSyntaxTreeNode LeftHandSide = null;
		AbstractSyntaxTreeNode Operator = null;
		AbstractSyntaxTreeNode RightHandSide = null;
		
		
	}
}
