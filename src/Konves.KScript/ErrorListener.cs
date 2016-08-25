using Antlr4.Runtime;

namespace Konves.KScript
{
	internal sealed class ErrorListener : BaseErrorListener, IAntlrErrorListener<int>
	{
		public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
		{
			throw new ParseException(msg, line, charPositionInLine);
		}

		public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
		{
			throw new ParseException(msg, line, charPositionInLine);
		}
	}
}
