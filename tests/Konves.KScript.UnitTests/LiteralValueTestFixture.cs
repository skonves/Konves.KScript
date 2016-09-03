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
		}
	}
}
