namespace MultiGrammar.Expression.Operators {
	public abstract class Operator<TIn, TOut>: ExpressionToken {
		public abstract TOut Compute(IComputationContext context, Expression<TIn> left, Expression<TIn> right);
	}
}
