namespace MultiGrammar.Expression {
	public abstract class Operator: ExpressionToken {
		public abstract double Compute(IComputationContext context, Expression left, Expression right);
	}
}