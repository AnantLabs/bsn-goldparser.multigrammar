using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class ViewParamList: QueryToken {
		private readonly ViewParamList next;
		private readonly ViewParam param;

		[Rule("<View Param Opt> ::=")]
		public ViewParamList(): this(null, null) {}

		[Rule("<View Param Opt> ::= <View Param> <View Param Opt>")]
		public ViewParamList(ViewParam param, ViewParamList next) {
			this.param = param;
			this.next = next;
		}

		public ViewParamList Next {
			get {
				return next;
			}
		}

		public ViewParam Param {
			get {
				return param;
			}
		}
	}
}