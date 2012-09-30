using System;
using System.IO;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	public class ExpressionTokenizer: Tokenizer<ExpressionToken> {
		private readonly SemanticActions<ExpressionToken> actions;

		public ExpressionTokenizer(TextReader textReader, SemanticActions<ExpressionToken> actions): base(textReader, actions.Grammar) {
			this.actions = actions;
		}

		public SemanticActions<ExpressionToken> Actions {
			get {
				return actions;
			}
		}

		protected override ExpressionToken CreateToken(Symbol tokenSymbol, LineInfo tokenPosition, string text) {
			SemanticTerminalFactory<ExpressionToken> factory;
			if (!actions.TryGetTerminalFactory(tokenSymbol, out factory)) {
				throw new InvalidOperationException("Factory not found for terminal "+tokenSymbol.Name);
			}
			return factory.CreateAndInitialize(tokenSymbol, tokenPosition, text);
		}
	}
}
