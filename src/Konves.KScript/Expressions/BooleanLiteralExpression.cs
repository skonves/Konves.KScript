using System.Collections.Generic;

namespace Konves.KScript.Expressions
{
	internal sealed class BooleanLiteralExpression : IExpression
	{
		public BooleanLiteralExpression(bool value)
		{
			_value = value;
		}

		public bool Evaluate(IDictionary<string, object> state)
		{
			return _value;
		}

		readonly bool _value;
	}
}
