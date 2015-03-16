using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sqless.Compiler.Symbol
{
enum SymbolType
{
	Batch,
	Int,
	NullableInt,
	Long,
	NullableLong,
	Float,
	NullableFloat,
	Double,
	NullableDouble,
	String,
	NullableString,
	UnicodeString,
	NullableUnicodeString,
	Char,
	NullableChar,
	CharArray,
	NullableCharArray,
	UnicodeChar,
	NullableUnicodeChar,
	UnicodeCharArray,
	NullableUnicodeCharArray,
	Bool,
	NullableBool,
	TableVariable,
	TempTable,
	Alias
}
}
