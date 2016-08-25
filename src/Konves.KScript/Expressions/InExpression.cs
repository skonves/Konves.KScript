using System.Collections.Generic;
using System.Linq;

namespace Konves.KScript.Expressions
{
	internal sealed class InExpression : IExpression
	{
		public InExpression(Literal literal, IReadOnlyCollection<Literal> list)
		{
			_literal = literal;
			_list = list;
		}

		public bool Evaluate(IDictionary<string, object> state)
		{
			return _list.Any(item => _literal.GetLiteralValue(state) == item.GetLiteralValue(state));
		}

		readonly Literal _literal;
		readonly IReadOnlyCollection<Literal> _list;
	}
}
