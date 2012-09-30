using System;

using MultiGrammar.Expression;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	[Terminal("Expression", typeof(double))]
	[Terminal("Predicate", typeof(bool))]
	public class ExpressionHandle<T>: QueryToken {
		internal static ExpressionHandle<T> Create(Expression<T> expression, Symbol symbol) {
			ExpressionHandle<T> result = new ExpressionHandle<T>(expression);
			result.Initialize(symbol, ((IToken)expression).Position);
			return result;
		}

		private readonly Expression<T> expression;

		public ExpressionHandle() {
			throw new NotSupportedException("This token is virtual and must be instantiated via the static 'Create' method");
		}

		private ExpressionHandle(Expression<T> expression) {
			this.expression = expression;
		}

		public Expression<T> Expression {
			get {
				return expression;
			}
		}
	}
}
