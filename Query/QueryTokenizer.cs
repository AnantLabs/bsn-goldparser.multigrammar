using System;
using System.IO;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class QueryTokenizer: Tokenizer<QueryToken> {
		private readonly SemanticActions<QueryToken> actions;
		private readonly Symbol expressionSymbol;
		private readonly Symbol whereSymbol;

		public QueryTokenizer(TextReader textReader, SemanticActions<QueryToken> actions): base(textReader, actions.Grammar) {
			this.actions = actions;
			expressionSymbol = actions.Grammar.GetSymbolByName("Expression");
			whereSymbol = actions.Grammar.GetSymbolByName("WHERE");
		}

		public SemanticActions<QueryToken> Actions {
			get {
				return actions;
			}
		}

		protected override QueryToken CreateToken(Symbol tokenSymbol, LineInfo tokenPosition, string text) {
			SemanticTerminalFactory<QueryToken> factory;
			if (!actions.TryGetTerminalFactory(tokenSymbol, out factory)) {
				throw new InvalidOperationException("Factory not found for terminal "+tokenSymbol.Name);
			}
			return factory.CreateAndInitialize(tokenSymbol, tokenPosition, text);
		}
	}
}
