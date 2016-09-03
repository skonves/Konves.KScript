using Microsoft.VisualStudio.TestTools.UnitTesting;
using Konves.KScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konves.KScript.UnitTests
{
	public class LiteralTestFixture
	{
		[TestClass]
		public class LiteralValueTestFixture
		{
			[TestCategory("LiteralValue")]
			[TestMethod]
			public void ConstructorTest()
			{
				DoConstructorTest(DateTime.Parse("2015-1-1"));
				DoConstructorTest("2015-1-1");
				DoConstructorTest((decimal)5);
				DoConstructorTest(true);
			}

			[TestCategory("LiteralValue")]
			[ExpectedException(typeof(ArgumentException))]
			[TestMethod]
			public void ConstructorExceoptionTest()
			{
				DoConstructorTest((int)5);
				DoConstructorTest((long)5);
				DoConstructorTest((float)5);
				DoConstructorTest((double)5);
			}

			public void DoConstructorTest(object value)
			{
				// Arrange

				// Act
				LiteralValue result = new LiteralValue(value);

				// Assert
				Assert.IsNotNull(result);
			}

			[TestCategory("LiteralValue")]
			[TestMethod]
			public void EqualityOperatorTest()
			{
				DoEqualityOperatorTest(null, null, true);

				DoEqualityOperatorTest("asdf", "asdf", true);
				DoEqualityOperatorTest("asdf", "ASDF", false);

				DoEqualityOperatorTest(DateTime.Parse("2015-1-1"), "2015-1-1", true);
				DoEqualityOperatorTest("2015-1-1", DateTime.Parse("2015-1-1"), true);
				DoEqualityOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-1-1"), true);
				DoEqualityOperatorTest("2015-1-1", "2015-1-1T00:00:00", true);

				DoEqualityOperatorTest((decimal)5, (decimal)5, true);
				DoEqualityOperatorTest("5", (decimal)5, false);
				DoEqualityOperatorTest((decimal)5, "5", false);
				DoEqualityOperatorTest((decimal)6, (decimal)5, false);

				DoEqualityOperatorTest(true, true, true);
				DoEqualityOperatorTest(true, false, false);
				DoEqualityOperatorTest("true", true, false);
				DoEqualityOperatorTest(true, "true", false);
			}

			public void DoEqualityOperatorTest(object a, object b, bool expectedResult)
			{
				// Arrange
				LiteralValue aa = new LiteralValue(a);
				LiteralValue bb = new LiteralValue(b);

				// Act
				bool result = aa == bb;

				// Assert
				Assert.AreEqual(expectedResult, result);
			}

			[TestCategory("LiteralValue")]
			[TestMethod]
			public void InqualityOperatorTest()
			{
				DoInequalityOperatorTest(null, null, false);

				DoInequalityOperatorTest("asdf", "asdf", false);
				DoInequalityOperatorTest("asdf", "ASDF", true);

				DoInequalityOperatorTest(DateTime.Parse("2015-1-1"), "2015-1-1", false);
				DoInequalityOperatorTest("2015-1-1", DateTime.Parse("2015-1-1"), false);
				DoInequalityOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-1-1"), false);
				DoInequalityOperatorTest("2015-1-1", "2015-1-1T00:00:00", false);

				DoInequalityOperatorTest((decimal)5, (decimal)5, false);
				DoInequalityOperatorTest("5", (decimal)5, true);
				DoInequalityOperatorTest((decimal)5, "5", true);
				DoInequalityOperatorTest((decimal)6, (decimal)5, true);

				DoInequalityOperatorTest(true, true, false);
				DoInequalityOperatorTest(true, false, true);
				DoInequalityOperatorTest("true", true, true);
				DoInequalityOperatorTest(true, "true", true);
			}

			public void DoInequalityOperatorTest(object a, object b, bool expectedResult)
			{
				// Arrange
				LiteralValue aa = new LiteralValue(a);
				LiteralValue bb = new LiteralValue(b);

				// Act
				bool result = aa != bb;

				// Assert
				Assert.AreEqual(expectedResult, result);
			}

			[TestCategory("LiteralValue")]
			[TestMethod]
			public void GreaterThanOperatorTest()
			{
				DoGreaterThanOperatorTest(null, null, false);

				DoGreaterThanOperatorTest("asdf", "asdf", false);
				DoGreaterThanOperatorTest("asdf", "ASDF", false);

				DoGreaterThanOperatorTest(DateTime.Parse("2015-1-1"), "2015-1-1", false);
				DoGreaterThanOperatorTest("2015-1-1", DateTime.Parse("2015-1-1"), false);
				DoGreaterThanOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-1-1"), false);
				DoGreaterThanOperatorTest("2015-1-1", "2015-1-1T00:00:00", false);

				DoGreaterThanOperatorTest(DateTime.Parse("2015-2-1"), "2015-1-1", true);
				DoGreaterThanOperatorTest("2015-2-1", DateTime.Parse("2015-1-1"), true);
				DoGreaterThanOperatorTest(DateTime.Parse("2015-2-1"), DateTime.Parse("2015-1-1"), true);
				DoGreaterThanOperatorTest("2015-2-1", "2015-1-1T00:00:00", true);

				DoGreaterThanOperatorTest((decimal)5, (decimal)5, false);
				DoGreaterThanOperatorTest("5", (decimal)5, false);
				DoGreaterThanOperatorTest((decimal)5, "5", false);
				DoGreaterThanOperatorTest((decimal)6, (decimal)5, true);

				DoGreaterThanOperatorTest(true, true, false);
				DoGreaterThanOperatorTest(true, false, false);
				DoGreaterThanOperatorTest("true", true, false);
				DoGreaterThanOperatorTest(true, "true", false);
			}

			public void DoGreaterThanOperatorTest(object a, object b, bool expectedResult)
			{
				// Arrange
				LiteralValue aa = new LiteralValue(a);
				LiteralValue bb = new LiteralValue(b);

				// Act
				bool result = aa > bb;

				// Assert
				Assert.AreEqual(expectedResult, result);
			}

			[TestCategory("LiteralValue")]
			[TestMethod]
			public void LessThanOperatorTest()
			{
				DoLessThanOperatorTest(null, null, false);

				DoLessThanOperatorTest("asdf", "asdf", false);
				DoLessThanOperatorTest("asdf", "ASDF", false);

				DoLessThanOperatorTest(DateTime.Parse("2015-1-1"), "2015-1-1", false);
				DoLessThanOperatorTest("2015-1-1", DateTime.Parse("2015-1-1"), false);
				DoLessThanOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-1-1"), false);
				DoLessThanOperatorTest("2015-1-1", "2015-1-1T00:00:00", false);

				DoLessThanOperatorTest(DateTime.Parse("2015-1-1"), "2015-2-1", true);
				DoLessThanOperatorTest("2015-1-1", DateTime.Parse("2015-2-1"), true);
				DoLessThanOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-2-1"), true);
				DoLessThanOperatorTest("2015-1-1", "2015-2-1T00:00:00", true);

				DoLessThanOperatorTest((decimal)5, (decimal)5, false);
				DoLessThanOperatorTest("5", (decimal)5, false);
				DoLessThanOperatorTest((decimal)5, "5", false);
				DoLessThanOperatorTest((decimal)5, (decimal)6, true);

				DoLessThanOperatorTest(true, true, false);
				DoLessThanOperatorTest(true, false, false);
				DoLessThanOperatorTest("true", true, false);
				DoLessThanOperatorTest(true, "true", false);
			}

			public void DoLessThanOperatorTest(object a, object b, bool expectedResult)
			{
				// Arrange
				LiteralValue aa = new LiteralValue(a);
				LiteralValue bb = new LiteralValue(b);

				// Act
				bool result = aa < bb;

				// Assert
				Assert.AreEqual(expectedResult, result);
			}

			[TestCategory("LiteralValue")]
			[TestMethod]
			public void GreaterThanOrEqualToOperatorTest()
			{
				DoGreaterThanOrEqualToOperatorTest(null, null, false);

				DoGreaterThanOrEqualToOperatorTest("asdf", "asdf", false);
				DoGreaterThanOrEqualToOperatorTest("asdf", "ASDF", false);

				DoGreaterThanOrEqualToOperatorTest(DateTime.Parse("2015-1-1"), "2015-1-1", true);
				DoGreaterThanOrEqualToOperatorTest("2015-1-1", DateTime.Parse("2015-1-1"), true);
				DoGreaterThanOrEqualToOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-1-1"), true);
				DoGreaterThanOrEqualToOperatorTest("2015-1-1", "2015-1-1T00:00:00", true);

				DoGreaterThanOrEqualToOperatorTest(DateTime.Parse("2015-2-1"), "2015-1-1", true);
				DoGreaterThanOrEqualToOperatorTest("2015-2-1", DateTime.Parse("2015-1-1"), true);
				DoGreaterThanOrEqualToOperatorTest(DateTime.Parse("2015-2-1"), DateTime.Parse("2015-1-1"), true);
				DoGreaterThanOrEqualToOperatorTest("2015-2-1", "2015-1-1T00:00:00", true);

				DoGreaterThanOrEqualToOperatorTest((decimal)5, (decimal)5, true);
				DoGreaterThanOrEqualToOperatorTest("5", (decimal)5, false);
				DoGreaterThanOrEqualToOperatorTest((decimal)5, "5", false);
				DoGreaterThanOrEqualToOperatorTest((decimal)6, (decimal)5, true);
				DoGreaterThanOrEqualToOperatorTest((decimal)5, (decimal)6, false);

				DoGreaterThanOrEqualToOperatorTest(true, true, false);
				DoGreaterThanOrEqualToOperatorTest(true, false, false);
				DoGreaterThanOrEqualToOperatorTest("true", true, false);
				DoGreaterThanOrEqualToOperatorTest(true, "true", false);
			}

			public void DoGreaterThanOrEqualToOperatorTest(object a, object b, bool expectedResult)
			{
				// Arrange
				LiteralValue aa = new LiteralValue(a);
				LiteralValue bb = new LiteralValue(b);

				// Act
				bool result = aa >= bb;

				// Assert
				Assert.AreEqual(expectedResult, result);
			}
			[TestCategory("LiteralValue")]
			[TestMethod]
			public void LessThanOrEqualToOperatorTest()
			{
				DoLessThanOrEqualToOperatorTest(null, null, false);

				DoLessThanOrEqualToOperatorTest("asdf", "asdf", false);
				DoLessThanOrEqualToOperatorTest("asdf", "ASDF", false);

				DoLessThanOrEqualToOperatorTest(DateTime.Parse("2015-1-1"), "2015-1-1", true);
				DoLessThanOrEqualToOperatorTest("2015-1-1", DateTime.Parse("2015-1-1"), true);
				DoLessThanOrEqualToOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-1-1"), true);
				DoLessThanOrEqualToOperatorTest("2015-1-1", "2015-1-1T00:00:00", true);

				DoLessThanOrEqualToOperatorTest(DateTime.Parse("2015-1-1"), "2015-2-1", true);
				DoLessThanOrEqualToOperatorTest("2015-1-1", DateTime.Parse("2015-2-1"), true);
				DoLessThanOrEqualToOperatorTest(DateTime.Parse("2015-1-1"), DateTime.Parse("2015-2-1"), true);
				DoLessThanOrEqualToOperatorTest("2015-1-1", "2015-2-1T00:00:00", true);

				DoLessThanOrEqualToOperatorTest((decimal)5, (decimal)5, true);
				DoLessThanOrEqualToOperatorTest("5", (decimal)5, false);
				DoLessThanOrEqualToOperatorTest((decimal)5, "5", false);
				DoLessThanOrEqualToOperatorTest((decimal)5, (decimal)6, true);
				DoLessThanOrEqualToOperatorTest((decimal)6, (decimal)5, false);

				DoLessThanOrEqualToOperatorTest(true, true, false);
				DoLessThanOrEqualToOperatorTest(true, false, false);
				DoLessThanOrEqualToOperatorTest("true", true, false);
				DoLessThanOrEqualToOperatorTest(true, "true", false);
			}

			public void DoLessThanOrEqualToOperatorTest(object a, object b, bool expectedResult)
			{
				// Arrange
				LiteralValue aa = new LiteralValue(a);
				LiteralValue bb = new LiteralValue(b);

				// Act
				bool result = aa <= bb;

				// Assert
				Assert.AreEqual(expectedResult, result);
			}
		}
	}
}
