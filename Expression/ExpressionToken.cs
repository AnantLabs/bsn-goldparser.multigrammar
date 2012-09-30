using System;

using MultiGrammar.Expression;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

[assembly: RuleTrim("<Value> ::= '(' <Expression> ')'", "<Expression>", SemanticTokenType = typeof(ExpressionToken))]

namespace MultiGrammar.Expression {
	[Terminal("(EOF)")]
	[Terminal("(Error)")]
	[Terminal("(Whitespace)")]
	[Terminal("(")]
	[Terminal(")")]
	public class ExpressionToken: SemanticToken {
		internal static ExpressionToken Create(Symbol symbol, LineInfo position) {
			ExpressionToken result = new ExpressionToken();
			result.Initialize(symbol, position);
			return result;
		}
	}
}
