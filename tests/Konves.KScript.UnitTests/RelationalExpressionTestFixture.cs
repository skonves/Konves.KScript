using Konves.KScript.Expressions;
using Konves.KScript.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Konves.KScript.UnitTests
{
	[TestClass]
	public class RelationalExpressionTestFixture
	{
		[TestCategory(nameof(RelationalExpression))]
		[TestMethod]
		public void TestEvaluate()
		{
			DoTestEvaluate(5m, 5m, KScriptLexer.EQ, true);
			DoTestEvaluate(6m, 5m, KScriptLexer.EQ, false);
			DoTestEvaluate(5m, 6m, KScriptLexer.EQ, false);

			DoTestEvaluate(5m, 5m, KScriptLexer.NE, false);
			DoTestEvaluate(6m, 5m, KScriptLexer.NE, true);
			DoTestEvaluate(5m, 6m, KScriptLexer.NE, true);

			DoTestEvaluate(5m, 5m, KScriptLexer.GT, false);
			DoTestEvaluate(6m, 5m, KScriptLexer.GT, true);
			DoTestEvaluate(5m, 6m, KScriptLexer.GT, false);

			DoTestEvaluate(5m, 5m, KScriptLexer.LT, false);
			DoTestEvaluate(6m, 5m, KScriptLexer.LT, false);
			DoTestEvaluate(5m, 6m, KScriptLexer.LT, true);

			DoTestEvaluate(5m, 5m, KScriptLexer.GT_ET, true);
			DoTestEvaluate(6m, 5m, KScriptLexer.GT_ET, true);
			DoTestEvaluate(5m, 6m, KScriptLexer.GT_ET, false);

			DoTestEvaluate(5m, 5m, KScriptLexer.LT_ET, true);
			DoTestEvaluate(6m, 5m, KScriptLexer.LT_ET, false);
			DoTestEvaluate(5m, 6m, KScriptLexer.LT_ET, true);
		}

		[TestCategory(nameof(RelationalExpression))]
		[ExpectedException(typeof(InvalidOperationException))]
		[TestMethod]
		public void TestEvaluate_OutOfRange()
		{
			// Arrange
			Literal aa = new Literal(5m, LiteralType.Value);
			Literal bb = new Literal(5m, LiteralType.Value);

			IExpression expression = new RelationalExpression(aa, bb, int.MaxValue);

			// Act
			bool result = expression.Evaluate(null);

			// Assert
			Assert.Fail();
		}

		private void DoTestEvaluate(object a, object b, int operatorToken, bool expected)
		{
			// Arrange
			Literal aa = new Literal(a, LiteralType.Value);
			Literal bb = new Literal(b, LiteralType.Value);

			IExpression expression = new RelationalExpression(aa, bb, operatorToken);

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
