using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class LiteralTestFixture
	{
		[TestCategory("Literal")]
		[TestMethod]
		public void GetLiteralValueTest_Token()
		{
			string stringValue = "string value";
			decimal decimalValue = 5m;
			DateTime dateValue = DateTime.Parse("2015-1-1");
			bool boolValue = true;


			IDictionary<string, object> state = new Dictionary<string, object> {
				{ nameof(stringValue), stringValue },
				{ nameof(decimalValue), decimalValue },
				{ nameof(dateValue), dateValue },
				{ nameof(boolValue), boolValue }
			};

			DoGetLiteralValueTest_Token(nameof(stringValue), state, new LiteralValue(stringValue));
			DoGetLiteralValueTest_Token(nameof(decimalValue), state, new LiteralValue(decimalValue));
			DoGetLiteralValueTest_Token(nameof(dateValue), state, new LiteralValue(dateValue));
			DoGetLiteralValueTest_Token(nameof(boolValue), state, new LiteralValue(boolValue));

			DoGetLiteralValueTest_Token("invalid string key", state, new LiteralValue(null));
			DoGetLiteralValueTest_Token(decimalValue, state, new LiteralValue(null));
			DoGetLiteralValueTest_Token(dateValue, state, new LiteralValue(null));
			DoGetLiteralValueTest_Token(boolValue, state, new LiteralValue(null));
		}

		private void DoGetLiteralValueTest_Token(object value, IDictionary<string, object> state, LiteralValue expected)
		{
			// Arrange
			Literal sut = new Literal(value, LiteralType.Token);

			// Act
			LiteralValue result = sut.GetLiteralValue(state);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(expected.Equals(result));
		}
	}
}
