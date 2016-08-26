using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class CommentTreeNode : AbstractSyntaxTreeNode
	{
		public CommentTreeNode(IBufferedTokenStream stream, ISymbolTable symbolTable)
			: base (stream, symbolTable)
		{
			Type = stream.Current.Type;
			m_comment = stream.Current.Content;
			stream.Read();
		}
		
		public override string GetMSSqlText()
		{
			Regex r = new Regex("//(.+)");
			
			var match = r.Match(m_comment);

			return string.Format("-- {0}\n",match.Groups[1].Value.Replace("\r", string.Empty).Replace("\n", string.Empty));
		}

		private string m_comment;

	}
}
