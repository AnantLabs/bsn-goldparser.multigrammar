using System.Collections.Generic;

using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class ViewStatement: QueryToken {
		private readonly Identifier identifier;
		private readonly IList<ViewParam> viewParams;

		[Rule("<View Stmt> ::= ~VIEW Identifier <View Param Opt>")]
		public ViewStatement(Identifier identifier, ViewParamList viewParams) {
			this.identifier = identifier;
			List<ViewParam> viewParamList = new List<ViewParam>();
			while (viewParams != null) {
				if (viewParams.Param != null) {
					viewParamList.Add(viewParams.Param);
				}
				viewParams = viewParams.Next;
			}
			this.viewParams = viewParamList.AsReadOnly();
		}

		public Identifier Identifier {
			get {
				return identifier;
			}
		}

		public IList<ViewParam> ViewParams {
			get {
				return viewParams;
			}
		}
	}
}
