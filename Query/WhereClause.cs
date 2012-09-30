using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class WhereClause: ViewParam {
		private readonly ExpressionHandle<bool> predicate;

		[Rule("<Where Clause> ::= ~WHERE Predicate")]
		public WhereClause(ExpressionHandle<bool> predicate) {
			this.predicate = predicate;
		}

		public ExpressionHandle<bool> Predicate {
			get {
				return predicate;
			}
		}
	}
}
