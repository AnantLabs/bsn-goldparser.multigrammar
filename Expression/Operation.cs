using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	public class Operation: Expression {
		private readonly Expression left;
		private readonly Operator op;
		private readonly Expression right;

		[Rule("<Negate Exp> ::= '-' <Value>")]
		public Operation(Operator op, Expression right): this(new Number(0.0), op, right) {}

		[Rule("<Expression> ::= <Expression> '+' <Mult Exp>")]
		[Rule("<Expression> ::= <Expression> '-' <Mult Exp>")]
		[Rule("<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>")]
		[Rule("<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>")]
		public Operation(Expression left, Operator op, Expression right) {
			this.left = left;
			this.op = op;
			this.right = right;
		}

		public Expression Left {
			get {
				return left;
			}
		}

		public Operator Op {
			get {
				return op;
			}
		}

		public Expression Right {
			get {
				return right;
			}
		}

		public override double Compute(IComputationContext context) {
			return op.Compute(context, left, right);
		}
	}
}