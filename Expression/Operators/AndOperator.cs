using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression.Operators {
	[Terminal("AND")]
	public class AndOperator: Operator<bool, bool> {
		public override bool Compute(IComputationContext context, Expression<bool> left, Expression<bool> right) {
			return left.Compute(context) && right.Compute(context);
		}
	}
}
