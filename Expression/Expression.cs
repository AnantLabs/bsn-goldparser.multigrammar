namespace MultiGrammar.Expression {
	public abstract class Expression<TOut>: ExpressionToken {
		public abstract TOut Compute(IComputationContext context);
	}
}
