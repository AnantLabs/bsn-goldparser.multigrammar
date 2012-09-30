using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression.Operators {
	[Terminal("+")]
	public class PlusOperator: Operator<double, double> {
		public override double Compute(IComputationContext context, Expression<double> left, Expression<double> right) {
			return left.Compute(context)+right.Compute(context);
		}
	}
}
