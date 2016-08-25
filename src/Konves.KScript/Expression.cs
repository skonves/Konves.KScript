using Antlr4.Runtime;
using Konves.KScript.Parsing;
using System;
using System.Collections.Generic;

namespace Konves.KScript
{
	public sealed class Expression : IExpression
	{
		public Expression(string s)
		{
			try
			{
				AntlrInputStream inputStream = new AntlrInputStream(s);

				KScriptLexer lexer = new KScriptLexer(inputStream);
				lexer.RemoveErrorListeners();
				lexer.AddErrorListener(new ErrorListener());

				CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
				KScriptParser parser = new KScriptParser(commonTokenStream);
				parser.RemoveErrorListeners();
				parser.AddErrorListener(new ErrorListener());

				_expression = ExpressionFactory.Create(parser.root().expression());
			}
			catch (ParseException ex)
			{
				throw new ArgumentException($"{ex.LineNumber}:{ex.CharacterPosition}: {ex.Message}", ex);
			}
		}

		public bool Evaluate(IDictionary<string, object> state)
		{
			return _expression.Evaluate(state);
		}

		readonly IExpression _expression;
	}
}
