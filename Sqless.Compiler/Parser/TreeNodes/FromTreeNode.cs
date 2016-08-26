using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sqless.Compiler.DatabaseMeta;
using Sqless.Compiler.Lexer;
using Sqless.Compiler.Symbol;

namespace Sqless.Compiler.Parser.TreeNodes
{
	class FromTreeNode : AbstractSyntaxTreeNode
	{
		public FromTreeNode(IBufferedTokenStream tokenStream, ISymbolTable symbolTable)
			: base(tokenStream, symbolTable)
		{
			Tables = new List<ISqlTableMeta>();
			//FROM = FROM { ALIAS | IDENTIFIER }

			tokenStream.Read();

			m_children.Add(IdentNode = new IdentifierTreeNode(tokenStream, symbolTable));

			var table = symbolTable.GetTableMetaByName(IdentNode.Symbol.Name);

			if (table != null)
			{
				Tables.Add(table);
			}
		}

		public IList<ISqlTableMeta> Tables;
		
		public override string GetMSSqlText()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("FROM ");

			foreach (var child in m_children)
			{
				sb.Append(child.GetMSSqlText());
			}

			return sb.ToString();
		}


		IdentifierTreeNode IdentNode = null;
	}
}
