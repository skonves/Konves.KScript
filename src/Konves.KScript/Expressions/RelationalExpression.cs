using Konves.KScript.Parsing;
using System;
using System.Collections.Generic;

namespace Konves.KScript.Expressions
{
	internal sealed class RelationalExpression : IExpression
	{
		public RelationalExpression(Literal a, Literal b, int operatorToken)
		{
			_a = a;
			_b = b;
			_operatorToken = operatorToken;
		}

		public bool Evaluate(IDictionary<string, object> state)
		{
			switch (_operatorToken)
			{
				case KScriptLexer.GT:
					return _a.GetLiteralValue(state) > _b.GetLiteralValue(state);
				case KScriptLexer.GT_ET:
					return _a.GetLiteralValue(state) >= _b.GetLiteralValue(state);
				case KScriptLexer.LT:
					return _a.GetLiteralValue(state) < _b.GetLiteralValue(state);
				case KScriptLexer.LT_ET:
					return _a.GetLiteralValue(state) <= _b.GetLiteralValue(state);
				case KScriptLexer.EQ:
					return _a.GetLiteralValue(state) == _b.GetLiteralValue(state);
				case KScriptLexer.NE:
					return _a.GetLiteralValue(state) != _b.GetLiteralValue(state);
				default:
					throw new InvalidOperationException();
			}

			throw new NotImplementedException();
		}

		readonly Literal _a;
		readonly Literal _b;
		readonly int _operatorToken;
	}
}
