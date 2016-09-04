using System;
using Konves.KScript.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class InExpressionTestFixture
	{
		[TestCategory(nameof(InExpression))]
		[TestMethod]
		public void TestEvaluate()
		{
			string stringValue = "string value";
			decimal decimalValue = 5m;
			DateTime dateValue = DateTime.Parse("2015-1-1");
			bool boolValue = true;

			IReadOnlyCollection<object> list = new List<object> { stringValue, decimalValue, dateValue, boolValue };

			DoTestEvaluate(null, list, false);
			DoTestEvaluate(stringValue, list, true);
			DoTestEvaluate(decimalValue, list, true);
			DoTestEvaluate(dateValue, list, true);
			DoTestEvaluate(boolValue, list, true);

			DoTestEvaluate("not found", list, false);
			DoTestEvaluate(1234m, list, false);
			DoTestEvaluate(DateTime.Parse("2000-1-1"), list, false);
			DoTestEvaluate(!boolValue, list, false);
		}

		private void DoTestEvaluate(object value, IReadOnlyCollection<object> list, bool expected)
		{
			// Arrange
			Literal literal = new Literal(value, LiteralType.Value);
			IReadOnlyCollection<Literal> literals = list.Select(item => new Literal(item, LiteralType.Value)).ToList();

			IExpression expression = new InExpression(literal, literals);

			// Act
			bool result = expression.Evaluate(null);

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}
