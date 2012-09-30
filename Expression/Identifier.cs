using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	[Terminal("Identifier")]
	public class Identifier: ExpressionToken {
		private readonly string name;

		public Identifier(string name) {
			this.name = name;
		}

		public string Name {
			get {
				return name;
			}
		}
	}
}