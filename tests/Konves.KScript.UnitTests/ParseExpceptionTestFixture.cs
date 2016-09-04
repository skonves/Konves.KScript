using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Konves.KScript.UnitTests
{
	public class ParseExpceptionTestFixture
	{
		[TestCategory(nameof(ParseException))]
		[TestMethod]
		public void ConstructorTest()
		{
			// Arrange
			string message = "message";
			int lineNumber = 5;
			int characterPosition = 7;

			// Act
			ParseException result = new ParseException(message, lineNumber, characterPosition);

			// Assert
			Assert.AreEqual(message, result.Message);
			Assert.AreEqual(lineNumber, result.LineNumber);
			Assert.AreEqual(characterPosition, result.CharacterPosition);
		}
	}
}
