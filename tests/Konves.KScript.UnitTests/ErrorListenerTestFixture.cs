using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class ErrorListenerTestFixture
	{
		[TestCategory("ErrorListener")]
		[TestMethod]
		[ExpectedException(typeof(ParseException))]
		public void SyntaxErrorTest_IntSymbol()
		{
			DoSyntaxErrorTest_IntSymbol("string", 5, 10);
		}

		[TestCategory("ErrorListener")]
		[TestMethod]
		[ExpectedException(typeof(ParseException))]
		public void SyntaxErrorTest_TokenSymbol()
		{
			DoSyntaxErrorTest_TokenSymbol("string", 5, 10);
		}

		private void DoSyntaxErrorTest_IntSymbol(string message, int line, int pos)
		{
			// Arrange
			IRecognizer recognizer = null;
			int symbol = default(int);
			ErrorListener sut = new ErrorListener();

			// Act
			sut.SyntaxError(recognizer, symbol, line, pos, message, null);

			// Assert
			Assert.Fail();
		}

		private void DoSyntaxErrorTest_TokenSymbol(string message, int line, int pos)
		{
			// Arrange
			IRecognizer recognizer = null;
			IToken symbol = null;
			ErrorListener sut = new ErrorListener();

			// Act
			sut.SyntaxError(recognizer, symbol, line, pos, message, null);

			// Assert
			Assert.Fail();
		}
	}
}
