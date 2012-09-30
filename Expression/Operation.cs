using MultiGrammar.Expression.Operators;

using bsn.GoldParser.Semantic;

namespace MultiGrammar.Expression {
	public class Operation<TIn, TOut>: Expression<TOut> {
		private readonly Expression<TIn> left;
		private readonly Operator<TIn, TOut> op;
		private readonly Expression<TIn> right;

		[Rule("<Negate Exp> ::= '-' <Value>", typeof(double), typeof(double))]
		[Rule("<Not Pred> ::= NOT <Boolean>", typeof(bool), typeof(bool))]
		public Operation(Operator<TIn, TOut> op, Expression<TIn> right): this(new Constant<TIn>(), op, right) {}

		[Rule("<Expression> ::= <Expression> '+' <Mult Exp>", typeof(double), typeof(double))]
		[Rule("<Expression> ::= <Expression> '-' <Mult Exp>", typeof(double), typeof(double))]
		[Rule("<Mult Exp> ::= <Mult Exp> '*' <Negate Exp>", typeof(double), typeof(double))]
		[Rule("<Mult Exp> ::= <Mult Exp> '/' <Negate Exp>", typeof(double), typeof(double))]
		[Rule("<Predicate> ::= <Predicate> OR <And Pred>", typeof(bool), typeof(bool))]
		[Rule("<And Pred> ::= <And Pred> AND <Comparison>", typeof(bool), typeof(bool))]
		[Rule("<Comparison> ::= <Expression> Eq <Expression>", typeof(double), typeof(bool))]
		[Rule("<Comparison> ::= <Expression> Neq <Expression>", typeof(double), typeof(bool))]
		[Rule("<Comparison> ::= <Expression> '>=' <Expression>", typeof(double), typeof(bool))]
		[Rule("<Comparison> ::= <Expression> '>' <Expression>", typeof(double), typeof(bool))]
		[Rule("<Comparison> ::= <Expression> '<=' <Expression>", typeof(double), typeof(bool))]
		[Rule("<Comparison> ::= <Expression> '<' <Expression>", typeof(double), typeof(bool))]
		public Operation(Expression<TIn> left, Operator<TIn, TOut> op, Expression<TIn> right) {
			this.left = left;
			this.op = op;
			this.right = right;
		}

		public Expression<TIn> Left {
			get {
				return left;
			}
		}

		public Operator<TIn, TOut> Op {
			get {
				return op;
			}
		}

		public Expression<TIn> Right {
			get {
				return right;
			}
		}

		public override TOut Compute(IComputationContext context) {
			return op.Compute(context, left, right);
		}
	}
}
