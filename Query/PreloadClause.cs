using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class PreloadClause: ViewParam {
		[Rule("<Preload Clause> ::= ~PRELOAD")]
		public PreloadClause() {}
	}
}
