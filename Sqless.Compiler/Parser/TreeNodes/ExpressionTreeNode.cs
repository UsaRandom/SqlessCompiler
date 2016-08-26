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


			var hasStartParenthesis = false;

			if (stream.Current.Type == TokenType.LeftParenthesis)
			{
				stream.Read();
				LeftHandSide = new ExpressionTreeNode(stream, symbolTable);
				hasStartParenthesis = true;
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
					nextTokenIsOperator = true;
					break;
			}

			if (nextTokenIsOperator)
			{
				Operator = new OperatorTreeNode(stream, symbolTable);


				if (hasStartParenthesis && stream.Current.Type == TokenType.RightParenthesis)
				{
					RightHandSide = new ExpressionTreeNode(stream, symbolTable);
				}
				else if (stream.Current.Type == TokenType.Identifier)
				{
					RightHandSide = new IdentifierTreeNode(stream, symbolTable);
				}
				else
				{
					RightHandSide = new LiteralTreeNode(stream, symbolTable);
				}
			}

			Type = LeftHandSide.Type;

		}
		

		
		public override string GetMSSqlText()
		{
			var lhsText = LeftHandSide.GetMSSqlText();

			if (LeftHandSide is ExpressionTreeNode)
			{
				lhsText = $"({lhsText})";
			}

			if (RightHandSide != null && Operator != null)
			{
				var rhsText = RightHandSide.GetMSSqlText();
				
				if (RightHandSide is ExpressionTreeNode)
				{
					rhsText = $"({rhsText})";
				}

				return string.Format("{0} {1} {2}", lhsText, Operator.GetMSSqlText(), rhsText);

			}
			return string.Format("{0}", lhsText);
		}

		AbstractSyntaxTreeNode LeftHandSide = null;
		AbstractSyntaxTreeNode Operator = null;
		AbstractSyntaxTreeNode RightHandSide = null;
		
		
	}
}
