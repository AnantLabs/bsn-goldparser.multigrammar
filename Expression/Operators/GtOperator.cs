using System;

using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression.Operators {
	[Terminal(">")]
	public class GtOperator: Operator<double, bool> {
		public override bool Compute(IComputationContext context, Expression<double> left, Expression<double> right) {
			return left.Compute(context) > right.Compute(context);
		}
	}
}
