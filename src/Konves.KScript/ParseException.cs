using System;

namespace Konves.KScript
{
	public class ParseException : Exception
	{
		public ParseException(string message, int lineNumber, int characterPosition) : base(message)
		{
			LineNumber = lineNumber;
			CharacterPosition = characterPosition;
		}

		public int LineNumber { get; }
		public int CharacterPosition { get; }
	}
}
