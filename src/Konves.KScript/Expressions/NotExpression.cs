using System.Collections.Generic;

namespace Konves.KScript.Expressions
{
	internal sealed class NotExpression : IExpression
	{
		public NotExpression(IExpression expression)
		{
			_expression = expression;
		}

		public bool Evaluate(IDictionary<string, object> state)
		{
			return !_expression.Evaluate(state);
		}

		readonly IExpression _expression;
	}
}
