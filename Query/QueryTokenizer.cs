using System;
using System.Collections.Generic;
using System.IO;

using MultiGrammar.Expression;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar.Query {
	public class QueryTokenizer: Tokenizer<QueryToken> {
		private readonly SemanticActions<ExpressionToken> expressionActions;
		private readonly Symbol expressionSymbol;
		private readonly HashSet<Symbol> grammarSwitchSymbols;
		private readonly Symbol predicateSymbol;
		private readonly SemanticActions<QueryToken> queryActions;
		private bool expectExpression;

		public QueryTokenizer(TextReader textReader, SemanticActions<QueryToken> queryActions, SemanticActions<ExpressionToken> expressionActions): base(textReader, queryActions.Grammar) {
			this.queryActions = queryActions;
			this.expressionActions = expressionActions;
			expressionSymbol = queryActions.Grammar.GetSymbolByName("Expression");
			predicateSymbol = queryActions.Grammar.GetSymbolByName("Predicate");
			grammarSwitchSymbols = new HashSet<Symbol> {
					queryActions.Grammar.GetSymbolByName("WHERE")
			};
		}

		public SemanticActions<QueryToken> QueryActions {
			get {
				return queryActions;
			}
		}

		public override ParseMessage NextToken(out QueryToken token) {
			if (expectExpression) {
				ExpressionProcessor processor = new ExpressionProcessor(new ExpressionTokenizer(Buffer, expressionActions, true));
				ParseMessage message = processor.ParseAll();
				if (message == ParseMessage.Accept) {
					expectExpression = false;
					Expression<bool> predicate = processor.CurrentToken as Expression<bool>;
					if (predicate != null) {
						token = ExpressionHandle<bool>.Create(predicate, predicateSymbol);
						return ParseMessage.TokenRead;
					}
					Expression<double> expression = processor.CurrentToken as Expression<double>;
					if (expression != null) {
						token = ExpressionHandle<double>.Create(expression, expressionSymbol);
						return ParseMessage.TokenRead;
					}
				}
				token = QueryToken.Create(Grammar.ErrorSymbol, new LineInfo(InputIndex, LineNumber, LineColumn));
				return ParseMessage.LexicalError;
			}
			return base.NextToken(out token);
		}

		protected override QueryToken CreateToken(Symbol tokenSymbol, LineInfo tokenPosition, string text) {
			SemanticTerminalFactory<QueryToken> factory;
			if (!queryActions.TryGetTerminalFactory(tokenSymbol, out factory)) {
				throw new InvalidOperationException("Factory not found for terminal "+tokenSymbol.Name);
			}
			expectExpression = grammarSwitchSymbols.Contains(tokenSymbol);
			return factory.CreateAndInitialize(tokenSymbol, tokenPosition, text);
		}
	}
}
