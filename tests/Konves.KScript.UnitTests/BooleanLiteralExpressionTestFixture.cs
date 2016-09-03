using Konves.KScript.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class BooleanLiteralExpressionTestFixture
	{
		[TestMethod]
		[TestCategory("BooleanLiteralExpression")]
		public void TestEvaluate()
		{
			DoTestEvaluate(true, true);
			DoTestEvaluate(false, false);
		}

		private void DoTestEvaluate(bool value, bool expected)
		{
			// Arrange
			IExpression expression = new BooleanLiteralExpression(value);

			// Act
			bool result = expression.Evaluate(null);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}
