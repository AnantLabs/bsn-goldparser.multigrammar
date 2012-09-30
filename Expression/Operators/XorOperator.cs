using System;

using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression.Operators {
	[Terminal("NOT")]
	public class XorOperator: Operator<bool, bool> {
		public override bool Compute(IComputationContext context, Expression<bool> left, Expression<bool> right) {
			return left.Compute(context)^right.Compute(context);
		}
	}
}
