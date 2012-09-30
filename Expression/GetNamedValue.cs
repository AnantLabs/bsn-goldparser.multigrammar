using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	public class GetNamedValue: Expression {
		private readonly string name;

		[Rule("<Value> ::= Identifier")]
		public GetNamedValue(Identifier name) {
			this.name = name.Name;
		}

		public string Name {
			get {
				return name;
			}
		}

		public override double Compute(IComputationContext context) {
			return context.GetValue(name);
		}
	}
}