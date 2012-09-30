using System;

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
	public class QueryToken: SemanticToken {}
}
