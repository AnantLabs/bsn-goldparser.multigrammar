using System;
using System.Globalization;

using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	[Terminal("Number", typeof(double))]
	[Terminal("Boolean", typeof(bool))]
	public class Constant<T>: Expression<T> {
		private readonly T value;

		public Constant(): this(default(T)) {}

		public Constant(T value) {
			this.value = value;
		}

		public Constant(string value): this((T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture)) {}

		public T Value {
			get {
				return value;
			}
		}

		public override T Compute(IComputationContext context) {
			return value;
		}
	}
}
