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

			DoGetLiteralValueTest_Token(null, state, new LiteralValue(null));
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

		[TestCategory("Literal")]
		[TestMethod]
		public void GetLiteralValueTest_Date()
		{
			DoGetLiteralValueTest_Date(null);
			DoGetLiteralValueTest_Date("asdf");
			DoGetLiteralValueTest_Date(5m);
			DoGetLiteralValueTest_Date(DateTime.Parse("2015-1-1"));
			DoGetLiteralValueTest_Date(true);
		}

		private void DoGetLiteralValueTest_Date(object value)
		{
			// Arrange
			Literal literal = new Literal(value, LiteralType.Date);

			LiteralValue lowerBound = new LiteralValue(DateTime.UtcNow.AddMinutes(-1));
			LiteralValue upperBound = new LiteralValue(DateTime.UtcNow.AddMinutes(1));

			// Act
			LiteralValue result = literal.GetLiteralValue(null);

			// Assert
			Assert.IsTrue(result > lowerBound);
			Assert.IsTrue(result < upperBound);
		}

		[TestCategory("Literal")]
		[TestMethod]
		public void GetLiteralValueTest_Literal()
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

			DoGetLiteralValueTest_Literal(null, new LiteralValue(null));
			DoGetLiteralValueTest_Literal(stringValue, new LiteralValue(stringValue));
			DoGetLiteralValueTest_Literal(decimalValue, new LiteralValue(decimalValue));
			DoGetLiteralValueTest_Literal(dateValue, new LiteralValue(dateValue));
			DoGetLiteralValueTest_Literal(boolValue, new LiteralValue(boolValue));
		}

		private void DoGetLiteralValueTest_Literal(object value, LiteralValue expected)
		{
			// Arrange
			Literal sut = new Literal(value, LiteralType.Value);

			// Act
			LiteralValue result = sut.GetLiteralValue(null);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(expected.Equals(result));
		}

		[TestCategory("Literal")]
		[ExpectedException(typeof(InvalidOperationException))]
		[TestMethod]
		public void GetLiteralValueTest_OutOfBounds()
		{
			Literal literal = new Literal(null, (LiteralType)int.MaxValue);

			literal.GetLiteralValue(null);
		}

		[TestCategory("Literal")]
		[TestMethod]
		public void EqualsTest()
		{
			DoEqualsTest("asdf", LiteralType.Value, "asdf", LiteralType.Value, true);
			DoEqualsTest("asdf", LiteralType.Value, "asdf", LiteralType.Date, false);
			DoEqualsTest("asdf", LiteralType.Value, "qwerty", LiteralType.Value, false);
			DoEqualsTest("asdf", LiteralType.Value, "qwerty", LiteralType.Date, false);

			DoEqualsTest(DateTime.Parse("2015-1-1"), LiteralType.Value, DateTime.Parse("2015-1-1"), LiteralType.Value, true);
			DoEqualsTest(DateTime.Parse("2015-1-1"), LiteralType.Value, DateTime.Parse("2015-1-1"), LiteralType.Date, false);
			DoEqualsTest(DateTime.Parse("2015-1-1"), LiteralType.Value, DateTime.Parse("2015-2-1"), LiteralType.Value, false);
			DoEqualsTest(DateTime.Parse("2015-1-1"), LiteralType.Value, DateTime.Parse("2015-2-1"), LiteralType.Date, false);
		}

		private void DoEqualsTest(object a, LiteralType aType, object b, LiteralType bType, bool expected)
		{
			// Arrange
			Literal aa = new Literal(a, aType);
			Literal bb = new Literal(b, bType);

			// Act
			bool result = aa.Equals(bb);

			// Assert
			Assert.AreEqual(expected, result);
		}

		[TestCategory("Literal")]
		[TestMethod]
		public void GetHashCodeTest()
		{
			DoGetHashCodeTest(null, LiteralType.Value);
			DoGetHashCodeTest("asdf", LiteralType.Value);
			DoGetHashCodeTest(5m, LiteralType.Value);
			DoGetHashCodeTest(DateTime.Parse("2015-1-1"), LiteralType.Value);
			DoGetHashCodeTest(true, LiteralType.Value);
		}

		private void DoGetHashCodeTest(object obj, LiteralType type)
		{
			// Arrange
			Literal sut = new Literal(obj, type);

			// Act
			int result = sut.GetHashCode();

			// Assert
		}
	}
}
