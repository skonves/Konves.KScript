using Konves.KScript.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class NotExpressionTestFixture
	{
		[TestCategory(nameof(NotExpression))]
		[TestMethod]
		public void TestEvaluate()
		{
			DoTestEvaluate(new TrueExpression(), false);
			DoTestEvaluate(new FalseExpression(), true);
		}

		private void DoTestEvaluate(IExpression expr, bool expected)
		{
			// Arrange
			IExpression expression = new NotExpression(expr);

			// Act
			bool result = expression.Evaluate(null);

			// Assert
			Assert.AreEqual(expected, result);
		}

		private class TrueExpression : IExpression
		{
			public bool Evaluate(IDictionary<string, object> state)
			{
				return true;
			}
		}

		private class FalseExpression : IExpression
		{
			public bool Evaluate(IDictionary<string, object> state)
			{
				return false;
			}
		}
	}
}
