using System;
using System.Collections.Generic;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class QueryProcessor: LalrProcessor<QueryToken> {
		private readonly QueryTokenizer tokenizer;

		public QueryProcessor(QueryTokenizer tokenizer): base(tokenizer) {
			this.tokenizer = tokenizer;
		}

		protected override bool CanTrim(Rule rule) {
			return false;
		}

		protected override QueryToken CreateReduction(Rule rule, IList<QueryToken> children) {
			SemanticNonterminalFactory<QueryToken> factory;
			if (!tokenizer.QueryActions.TryGetNonterminalFactory(rule, out factory)) {
				throw new InvalidOperationException("Factory not found for rule "+rule.Name);
			}
			return factory.CreateAndInitialize(rule, children);
		}
	}
}
