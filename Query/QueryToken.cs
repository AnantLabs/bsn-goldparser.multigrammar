using System;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	[Terminal("(EOF)")]
	[Terminal("(Error)")]
	[Terminal("(Whitespace)")]
	[Terminal("BY")]
	[Terminal("OPTIMIZE")]
	[Terminal("ORDER")]
	[Terminal("PRELOAD")]
	[Terminal("VIEW")]
	[Terminal("WHERE")]
	public class QueryToken: SemanticToken {
		internal static QueryToken Create(Symbol symbol, LineInfo position) {
			QueryToken result = new QueryToken();
			result.Initialize(symbol, position);
			return result;
		}
	}
}
