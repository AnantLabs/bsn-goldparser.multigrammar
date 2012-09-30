using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class WhereClause: ViewParam {
		private readonly Expression expression;

		[Rule("<Where Clause> ::= ~WHERE Expression")]
		public WhereClause(Expression expression) {
			this.expression = expression;
		}

		public Expression Expression {
			get {
				return expression;
			}
		}
	}
}