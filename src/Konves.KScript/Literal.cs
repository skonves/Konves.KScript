using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konves.KScript
{
	internal sealed class Literal
	{
		public Literal(object value, LiteralType type)
		{
			_value = value;
			_type = type;
		}

		public LiteralValue GetLiteralValue(IDictionary<string, object> state)
		{
			switch (_type)
			{
				case LiteralType.Token:
					object value;
					return new LiteralValue(state.TryGetValue(_value as string, out value) ? value : null);

				case LiteralType.Date:
					return new LiteralValue(DateTime.UtcNow);

				case LiteralType.Value:
					return new LiteralValue(_value);

				default:
					throw new InvalidOperationException();
			}
		}

		readonly object _value;
		readonly LiteralType _type;
	}
}
