using System;
using System.Collections.Generic;

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
					return new LiteralValue(_value is string && state.TryGetValue(_value as string, out value) ? value : null);

				case LiteralType.Date:
					return new LiteralValue(DateTime.UtcNow);

				case LiteralType.Value:
					return new LiteralValue(_value);

				default:
					throw new InvalidOperationException();
			}
		}

		public override bool Equals(object obj)
		{
			Literal other = obj as Literal;

			return !ReferenceEquals(other, null) &&
				((ReferenceEquals(_value, null) && ReferenceEquals(other._value, null)) || (!ReferenceEquals(_value, null) && _value.Equals(other._value)))
				&& (_type == other._type);
		}

		public override int GetHashCode()
		{
			return (_type.GetHashCode() * 8191) ^ (_value?.GetHashCode() ?? 0);
		}

		readonly object _value;
		readonly LiteralType _type;
	}
}
