using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class WhereClause: ViewParam {
		private readonly ExpressionHandle expression;

		[Rule("<Where Clause> ::= ~WHERE Expression")]
		public WhereClause(ExpressionHandle expression) {
			this.expression = expression;
		}

		public ExpressionHandle Expression {
			get {
				return expression;
			}
		}
	}
}