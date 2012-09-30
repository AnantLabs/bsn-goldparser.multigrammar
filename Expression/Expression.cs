namespace MultiGrammar.Expression {
	public abstract class Expression: ExpressionToken {
		public abstract double Compute(IComputationContext context);
	}
}