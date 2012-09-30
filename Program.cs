using System;
using System.IO;

using MultiGrammar.Expression;
using MultiGrammar.Query;

using bsn.GoldParser.Grammar;
using bsn.GoldParser.Parser;
using bsn.GoldParser.Semantic;

namespace MultiGrammar {
	internal class Program {
		private static void Main(string[] args) {
			SemanticTypeActions<QueryToken> queryActions = new SemanticTypeActions<QueryToken>(CompiledGrammar.Load(typeof(QueryToken), "Query.cgt"));
			queryActions.Initialize(true);
			SemanticTypeActions<ExpressionToken> expressionActions = new SemanticTypeActions<ExpressionToken>(CompiledGrammar.Load(typeof(ExpressionToken), "Expression.cgt"));
			expressionActions.Initialize(true);
			string input = "VIEW a WHERE 1 + x ORDER BY y";
			using (StringReader reader = new StringReader(input)) {
				QueryProcessor processor = new QueryProcessor(new QueryTokenizer(reader, queryActions, expressionActions));
				ParseMessage message = processor.ParseAll();
				Console.WriteLine("Parsing result: "+message);
				if (message != ParseMessage.Accept) {
					Console.WriteLine(input);
					Console.Write(new string(' ', (int)((IToken)processor.CurrentToken).Position.Index));
					Console.WriteLine('^');
				}
			}
			Console.ReadKey(false);
		}
	}
}
