using System;

using MultiGrammar.Expression;
using MultiGrammar.Query;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Semantic;

namespace MultiGrammar {
	internal class Program {
		private static void Main(string[] args) {
			SemanticTypeActions<QueryToken> queryActions = new SemanticTypeActions<QueryToken>(CompiledGrammar.Load(typeof(QueryToken), "Query.cgt"));
			queryActions.Initialize(true);
			SemanticTypeActions<ExpressionToken> expressionActions = new SemanticTypeActions<ExpressionToken>(CompiledGrammar.Load(typeof(QueryToken), "Expression.cgt"));
			expressionActions.Initialize(true);
		}
	}
}
