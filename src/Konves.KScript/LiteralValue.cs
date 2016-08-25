using System;

namespace Konves.KScript
{
	internal sealed class LiteralValue
	{
		public LiteralValue(object value)
		{
			_value = value;
		}

		readonly object _value;

		public static bool operator ==(LiteralValue a, LiteralValue b)
		{
			DateTime dateA;
			DateTime dateB;

			bool aIsDate = DateTime.TryParse(a._value as string, out dateA);
			bool bIsDate = DateTime.TryParse(b._value as string, out dateB);

			if (ReferenceEquals(a._value, null) && ReferenceEquals(b._value, null))
				return true;
			else if (a._value is bool && b._value is bool)
				return (bool)a._value == (bool)b._value;
			else if (a._value is decimal && b._value is decimal)
				return (decimal)a._value == (decimal)b._value;
			else if (a._value is DateTime && b._value is DateTime)
				return (DateTime)a._value == (DateTime)b._value;
			else if (a._value is string && b._value is string && !aIsDate && !bIsDate)
				return (string)a._value == (string)b._value;
			else if (a._value is string && aIsDate && b._value is string && bIsDate)
				return dateA == dateB;
			else if (a._value is DateTime && b._value is string && bIsDate)
				return (DateTime)a._value == dateB;
			else if (a._value is string && b._value is DateTime && aIsDate)
				return dateA == (DateTime)b._value;
			else
				return false;
		}

		public static bool operator !=(LiteralValue a, LiteralValue b)
		{
			DateTime dateA;
			DateTime dateB;

			bool aIsDate = DateTime.TryParse(a._value as string, out dateA);
			bool bIsDate = DateTime.TryParse(b._value as string, out dateB);

			if (ReferenceEquals(a._value, null) && ReferenceEquals(b._value, null))
				return false;
			else if (a._value is bool && b._value is bool)
				return (bool)a._value != (bool)b._value;
			else if (a._value is decimal && b._value is decimal)
				return (decimal)a._value != (decimal)b._value;
			else if (a._value is DateTime && b._value is DateTime)
				return (DateTime)a._value != (DateTime)b._value;
			else if (a._value is string && b._value is string && !aIsDate && !bIsDate)
				return (string)a._value != (string)b._value;
			else if (a._value is string && aIsDate && b._value is string && bIsDate)
				return dateA != dateB;
			else if (a._value is DateTime && b._value is string && bIsDate)
				return (DateTime)a._value != dateB;
			else if (a._value is string && b._value is DateTime && aIsDate)
				return dateA != (DateTime)b._value;
			else
				return true;
		}

		public static bool operator >=(LiteralValue a, LiteralValue b)
		{
			DateTime dateA;
			DateTime dateB;

			bool aIsDate = DateTime.TryParse(a._value as string, out dateA);
			bool bIsDate = DateTime.TryParse(b._value as string, out dateB);

			if (ReferenceEquals(a._value, null) && ReferenceEquals(b._value, null))
				return false;
			else if (a._value is bool && b._value is bool)
				return false;
			else if (a._value is decimal && b._value is decimal)
				return (decimal)a._value >= (decimal)b._value;
			else if (a._value is DateTime && b._value is DateTime)
				return (DateTime)a._value >= (DateTime)b._value;
			else if (a._value is string && b._value is string && !aIsDate && !bIsDate)
				return false;
			else if (a._value is string && aIsDate && b._value is string && bIsDate)
				return dateA >= dateB;
			else if (a._value is DateTime && b._value is string && bIsDate)
				return (DateTime)a._value >= dateB;
			else if (a._value is string && b._value is DateTime && aIsDate)
				return dateA >= (DateTime)b._value;
			else
				return true;
		}

		public static bool operator <=(LiteralValue a, LiteralValue b)
		{
			DateTime dateA;
			DateTime dateB;

			bool aIsDate = DateTime.TryParse(a._value as string, out dateA);
			bool bIsDate = DateTime.TryParse(b._value as string, out dateB);

			if (ReferenceEquals(a._value, null) && ReferenceEquals(b._value, null))
				return false;
			else if (a._value is bool && b._value is bool)
				return false;
			else if (a._value is decimal && b._value is decimal)
				return (decimal)a._value <= (decimal)b._value;
			else if (a._value is DateTime && b._value is DateTime)
				return (DateTime)a._value <= (DateTime)b._value;
			else if (a._value is string && b._value is string && !aIsDate && !bIsDate)
				return false;
			else if (a._value is string && aIsDate && b._value is string && bIsDate)
				return dateA <= dateB;
			else if (a._value is DateTime && b._value is string && bIsDate)
				return (DateTime)a._value <= dateB;
			else if (a._value is string && b._value is DateTime && aIsDate)
				return dateA <= (DateTime)b._value;
			else
				return true;
		}

		public static bool operator <(LiteralValue a, LiteralValue b)
		{
			DateTime dateA;
			DateTime dateB;

			bool aIsDate = DateTime.TryParse(a._value as string, out dateA);
			bool bIsDate = DateTime.TryParse(b._value as string, out dateB);

			if (ReferenceEquals(a._value, null) && ReferenceEquals(b._value, null))
				return false;
			else if (a._value is bool && b._value is bool)
				return false;
			else if (a._value is decimal && b._value is decimal)
				return (decimal)a._value < (decimal)b._value;
			else if (a._value is DateTime && b._value is DateTime)
				return (DateTime)a._value < (DateTime)b._value;
			else if (a._value is string && b._value is string && !aIsDate && !bIsDate)
				return false;
			else if (a._value is string && aIsDate && b._value is string && bIsDate)
				return dateA < dateB;
			else if (a._value is DateTime && b._value is string && bIsDate)
				return (DateTime)a._value < dateB;
			else if (a._value is string && b._value is DateTime && aIsDate)
				return dateA < (DateTime)b._value;
			else
				return false;
		}

		public static bool operator >(LiteralValue a, LiteralValue b)
		{
			DateTime dateA;
			DateTime dateB;

			bool aIsDate = DateTime.TryParse(a._value as string, out dateA);
			bool bIsDate = DateTime.TryParse(b._value as string, out dateB);

			if (ReferenceEquals(a._value, null) && ReferenceEquals(b._value, null))
				return false;
			else if (a._value is bool && b._value is bool)
				return false;
			else if (a._value is decimal && b._value is decimal)
				return (decimal)a._value > (decimal)b._value;
			else if (a._value is DateTime && b._value is DateTime)
				return (DateTime)a._value > (DateTime)b._value;
			else if (a._value is string && b._value is string && !aIsDate && !bIsDate)
				return false;
			else if (a._value is string && aIsDate && b._value is string && bIsDate)
				return dateA > dateB;
			else if (a._value is DateTime && b._value is string && bIsDate)
				return (DateTime)a._value > dateB;
			else if (a._value is string && b._value is DateTime && aIsDate)
				return dateA > (DateTime)b._value;
			else
				return false;
		}
	}
}
