using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer
{
public enum TokenType
{
	//Sql Keywords
	//For a full list see https://msdn.microsoft.com/en-us/library/ms189822.aspx
	Select,
	From,
	Where,
	Null,
	Go,
	As,
	Join,
	Inner,
	Outer,
	Left,
	Right,
	Full,
	On,
	Order,
	By,

	//Sql Functions , see https://msdn.microsoft.com/en-us/library/ms174318.aspx

	//Sql Aggregate Functions
	Avg,
	Min,
	Sum,
	Count,
	Max,
	

	//Sql Types
	Bit,
	TinyInt,
	SmallInt,
	BigInt,
	SmallDateTime,
	Varchar,
	NVarchar,
	NText,

	//Shared Keywords
	If,
	Var, //Var is aggregate function in SqlServer, and variable declaration in Sqless
	While,
	Break,
	Continue,

	//Shared Types
	Int,
	Float,
	Char,
	NChar,
	Decimal,
	Date,
	Text,
	Time,
	DateTime,
	DateTime2,
	Geography,
	Geometry,
	
	//Sqless Keywords
	Import,
	Using,
	Without,
	Def,

	//Sqless Types
	String,
	Bool,
	Byte,
	Short,
	NullableString,
	NullableBool,
	NullableByte,
	NullableShort,
	NullableInt,
	NullableFloat,


	//Value Literals
	StringLiteral,
	NStringLiteral,
	IntegerLiteral,
	FloatLiteral,
	DecimalLiteral,
	BoolLiteral,
	



	//Symbol, represents tables, named variables, etc...
	Symbol,

	//Operators,
	Equals,
	Asterisk,
	Dot, 


	//Scope
	Left_Parenthesis,
	Right_Parenthesis,
	Semicolon
}
}
