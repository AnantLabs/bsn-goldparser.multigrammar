using System;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	[Terminal("Expression")]
	public class ExpressionHandle: QueryToken {
		internal static ExpressionHandle Create(Expression.Expression expression, Symbol symbol) {
			ExpressionHandle result = new ExpressionHandle(expression);
			result.Initialize(symbol, ((IToken)expression).Position);
			return result;
		}

		private readonly Expression.Expression expression;

		public ExpressionHandle() {
			throw new NotSupportedException("This token is virtual and must be instantiated via the static 'Create' method");
		}

		private ExpressionHandle(Expression.Expression expression) {
			this.expression = expression;
		}

		public Expression.Expression Expression {
			get {
				return expression;
			}
		}
	}
}
