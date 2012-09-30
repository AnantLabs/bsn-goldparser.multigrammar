using System;

using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression.Operators {
	[Terminal(">=")]
	public class GteOperator: Operator<double, bool> {
		public override bool Compute(IComputationContext context, Expression<double> left, Expression<double> right) {
#warning A proper equality comparison with doubles should use an epsilon value to account for floating-point computation errors
			return left.Compute(context) >= right.Compute(context);
		}
	}
}
