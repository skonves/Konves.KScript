using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class ExpressionTestFixture
	{
		[TestCategory(nameof(Expression))]
		[TestMethod]
		public void EvaluateTest()
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

			DoEvaluateTest($"{{{nameof(stringValue)}}} = '{stringValue}'", state, true);
			DoEvaluateTest($"TRUE != FALSE", state, true);
			DoEvaluateTest($"NOW > '2000-1-1'", state, true);
			DoEvaluateTest($"NULL IS NOT NULL", state, false);
			DoEvaluateTest($"(5) > (1)", state, true);
		}

		private void DoEvaluateTest(string s, IDictionary<string, object> state, bool expected)
		{
			// Arrange
			IExpression expression = new Expression(s);

			// Act
			bool result = expression.Evaluate(state);

			// Assert
			Assert.AreEqual(expected, result);
		}

		[TestCategory(nameof(Expression))]
		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void EvaluateTest_BadSyntax()
		{
			DoEvaluateTest_BadSyntax("not a valid expression", null);
		}

		private void DoEvaluateTest_BadSyntax(string s, IDictionary<string, object> state)
		{
			// Arrange
			IExpression expression = new Expression(s);

			// Act
			bool result = expression.Evaluate(state);

			// Assert
			Assert.Fail();
		}
	}
}
