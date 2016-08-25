﻿using System.Collections.Generic;

namespace Konves.KScript.Expressions
{
	internal sealed class OrExpression : IExpression
	{
		public OrExpression(IExpression a, IExpression b)
		{
			_a = a;
			_b = b;
		}

		public bool Evaluate(IDictionary<string, object> state)
		{
			return _a.Evaluate(state) || _b.Evaluate(state);
		}

		readonly IExpression _a;
		readonly IExpression _b;
	}
}
