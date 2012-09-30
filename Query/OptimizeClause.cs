using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class OptimizeClause: ViewParam {
		private readonly Identifier identifier;

		[Rule("<Optimize Clause> ::= ~OPTIMIZE Identifier")]
		public OptimizeClause(Identifier identifier) {
			this.identifier = identifier;
		}

		public Identifier Identifier {
			get {
				return identifier;
			}
		}
	}
}
