using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	[Terminal("Identifier")]
	public class Identifier: QueryToken {
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
