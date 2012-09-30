using System;

using MultiGrammar.Expression;

using bsn.GoldParser.Semantic;

[assembly: RuleTrim("<Value> ::= '(' <Expression> ')'", "<Expression>", SemanticTokenType = typeof(ExpressionToken))]

namespace MultiGrammar.Expression {
	[Terminal("(EOF)")]
	[Terminal("(Error)")]
	[Terminal("(Whitespace)")]
	[Terminal("(")]
	[Terminal(")")]
	public class ExpressionToken: SemanticToken {}
}
