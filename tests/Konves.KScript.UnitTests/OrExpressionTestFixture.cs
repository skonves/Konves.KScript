using Konves.KScript.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class OrExpressionTestFixture
	{
		[TestCategory("OrExpression")]
		[TestMethod]
		public void TestEvaluate()
		{
			DoTestEvaluate(new TrueExpression(), new TrueExpression(), true);
			DoTestEvaluate(new TrueExpression(), new FalseExpression(), true);
			DoTestEvaluate(new FalseExpression(), new TrueExpression(), true);
			DoTestEvaluate(new FalseExpression(), new FalseExpression(), false);
		}

		private void DoTestEvaluate(IExpression a, IExpression b, bool expected)
		{
			// Arrange
			IExpression expression = new OrExpression(a, b);

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
