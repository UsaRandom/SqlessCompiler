using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Analysis.Lexer
{
public enum TokenType
{
	//Sql Keywords
	Select,
	From,
	Join,
	Where,
	
	//Sqlss Keywords
	Import,
	Using,
	Without,
	Var,

	//Value Literals
	StringLiteral,
	IntegerLiteral,


	//Symbol, represents tables, named variables, etc...
	Symbol,

	//Operators,
	Equals,
	Asterisk,
	Dot, //:D


	//Scope
	Left_Parenthesis,
	Right_Parenthesis,
	Semicolon
}
}
