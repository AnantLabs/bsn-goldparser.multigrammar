using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	[Terminal("Number")]
	public class Number: Expression {
		private readonly double value;

		public Number(double value) {
			this.value = value;
		}

		public Number(string value): this((double)double.Parse(value, NumberFormatInfo.InvariantInfo)) {}

		public double Value {
			get {
				return value;
			}
		}

		public override double Compute(IComputationContext context) {
			return value;
		}
	}
}