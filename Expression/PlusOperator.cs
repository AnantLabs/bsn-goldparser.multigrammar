using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	[Terminal("+")]
	public class PlusOperator: Operator {
		public override double Compute(IComputationContext context, Expression left, Expression right) {
			return left.Compute(context)+right.Compute(context);
		}
	}
}