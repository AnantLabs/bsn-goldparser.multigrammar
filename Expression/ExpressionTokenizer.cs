using System;
using System.IO;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	public class ExpressionTokenizer: Tokenizer<ExpressionToken> {
		private readonly SemanticActions<ExpressionToken> actions;
		private readonly bool handleErrorAsEof;
		private bool eof;

		public ExpressionTokenizer(TextReader textReader, SemanticActions<ExpressionToken> actions): this(new TextBuffer(textReader), actions, false) {}

		internal ExpressionTokenizer(TextBuffer textBuffer, SemanticActions<ExpressionToken> actions, bool handleErrorAsEof)
				: base(textBuffer, actions.Grammar) {
			this.handleErrorAsEof = handleErrorAsEof;
			this.actions = actions;
		}

		public SemanticActions<ExpressionToken> Actions {
			get {
				return actions;
			}
		}

		public bool HandleErrorAsEof {
			get {
				return handleErrorAsEof;
			}
		}

		public override ParseMessage NextToken(out ExpressionToken token) {
			if (eof) {
				token = ExpressionToken.Create(Grammar.EndSymbol, new LineInfo(InputIndex, LineNumber, LineColumn));
				return ParseMessage.TokenRead;
			}
			ParseMessage result = base.NextToken(out token);
			if ((result == ParseMessage.LexicalError) && (handleErrorAsEof)) {
				RollbackAndSetEnd();
				return NextToken(out token);
			}
			return result;
		}

		protected override ExpressionToken CreateToken(Symbol tokenSymbol, LineInfo tokenPosition, string text) {
			SemanticTerminalFactory<ExpressionToken> factory;
			if (!actions.TryGetTerminalFactory(tokenSymbol, out factory)) {
				throw new InvalidOperationException("Factory not found for terminal "+tokenSymbol.Name);
			}
			return factory.CreateAndInitialize(tokenSymbol, tokenPosition, text);
		}

		internal void RollbackAndSetEnd() {
			Buffer.Rollback();
			eof = true;
		}
	}
}
