using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class OrderByClause: ViewParam {
		private readonly Identifier identifier;

		[Rule("<OrderBy Clause> ::= ~ORDER ~BY Identifier")]
		public OrderByClause(Identifier identifier) {
			this.identifier = identifier;
		}

		public Identifier Identifier {
			get {
				return identifier;
			}
		}
	}
}