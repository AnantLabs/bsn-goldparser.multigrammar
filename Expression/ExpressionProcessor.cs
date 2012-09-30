using System;
using System.Collections.Generic;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	public class ExpressionProcessor: LalrProcessor<ExpressionToken> {
		private readonly ExpressionTokenizer tokenizer;

		public ExpressionProcessor(ExpressionTokenizer tokenizer): base(tokenizer) {
			this.tokenizer = tokenizer;
		}

		protected override bool CanTrim(Rule rule) {
			return false;
		}

		protected override bool RetrySyntaxError(ref ExpressionToken currentToken) {
			IToken token = currentToken;
			if (tokenizer.HandleErrorAsEof && (token.Symbol.Kind != SymbolKind.End)) {
				tokenizer.RollbackAndSetEnd();
				currentToken = null;
				return true;
			}
			return base.RetrySyntaxError(ref currentToken);
		}

		protected override ExpressionToken CreateReduction(Rule rule, IList<ExpressionToken> children) {
			SemanticNonterminalFactory<ExpressionToken> factory;
			if (!tokenizer.Actions.TryGetNonterminalFactory(rule, out factory)) {
				throw new InvalidOperationException("Factory not found for rule "+rule.Name);
			}
			return factory.CreateAndInitialize(rule, children);
		}
	}
}
