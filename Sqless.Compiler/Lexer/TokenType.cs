using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Lexer
{
public enum TokenType
{
	
	Select,
	From,
	Where,
	Join,
	Left,
	Right,
	Full,
	Order,
	By,

	Without,


	Sum,
	Avg,
	Count,

	Byte,
	Short,
	Int,
	Long,
	NullableByte,
	NullableShort,
	NullableInt,
	NullableLong,
	ByteLiteral,
	ShortLiteral,
	IntLiteral,
	LongLiteral,

	Float,
	Double,
	NullableFloat,
	NullableDouble,
	FloatLiteral,
	DecimalLiteral,

	Char,
	NChar,
	String,
	NString,
	NullableChar,
	NullableNChar,
	NullableString,
	NullableNString,
	CharLiteral,
	NCharLiteral,
	StringLiteral,
	NStringLiteral,

	Date,
	Time,
	DateTime,
	NullableDate,
	NullableTime,
	NullableDateTime,

	
	Bool,
	NullableBool,
	BoolLiteral,


	Import,
	Using,
	
	Var,
	
	Def,
	TempTable,
	TableVariable,
	DropExisting,

	If,
	Else,
	While,
	Break,
	Continue,

	
	Null,
	NullCoalesce,
	NullEquality,
	NullNegatedEquality,

	//Symbol, represents tables, named variables, etc...
	Symbol,
	Dot,
	Comma,

	//Operators,
	Asterisk,
	Plus,
	Minus,
	Divide,
	
	Equals,


	//Boolean Operators
	And,
	Or,
	Not,

	//Scope
	LeftParenthesis,
	RightParenthesis,
	LeftCurlyBracket,
	RightCurlyBracket,
	LeftBracket,
	RightBracket,
	Semicolon
}
}
