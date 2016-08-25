using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Konves.KScript.Expressions;
using Konves.KScript.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using static Konves.KScript.Parsing.KScriptParser;

namespace Konves.KScript
{
	internal static class ExpressionFactory
	{
		internal static IExpression Create(ExpressionContext context)
		{
			if (context.children.Count == 1)
			{
				ITerminalNode first = context.children[0] as ITerminalNode;

				if (first != null && first.Symbol.Type == KScriptLexer.TRUE)
				{
					return new BooleanLiteralExpression(true);
				}
				else if (first != null && first.Symbol.Type == KScriptLexer.FALSE)
				{
					return new BooleanLiteralExpression(false);
				}
				else if (context.children[0] is BetweenExpressionContext)
				{
					BetweenExpressionContext btContext = context.children[0] as BetweenExpressionContext;

					Literal a = LiteralFactory.Create(btContext.literal(0));
					Literal b = LiteralFactory.Create(btContext.literal(1));
					Literal c = LiteralFactory.Create(btContext.literal(2));

					return new AndExpression(
						new RelationalExpression(a, b, KScriptLexer.GT_ET),
						new RelationalExpression(a, c, KScriptLexer.LT));
				}
				else if (context.children[0] is InExpressionContext)
				{
					InExpressionContext inContext = context.children[0] as InExpressionContext;

					Literal literal = LiteralFactory.Create(inContext.literal());

					IReadOnlyCollection<Literal> list = inContext.list().literal().Select(LiteralFactory.Create).ToList();

					return new InExpression(literal, list);
				}
				else if (context.children[0] is RelationalExpressionContext)
				{
					RelationalExpressionContext relContext = context.children[0] as RelationalExpressionContext;

					Literal a = LiteralFactory.Create(relContext.literal(0));
					IToken operatorToken = (relContext.children[1] as ITerminalNode).Symbol;
					Literal b = LiteralFactory.Create(relContext.literal(1));

					return new RelationalExpression(a, b, operatorToken.Type);
				}
				else
				{
					throw new InvalidOperationException();
				}
			}
			if (context.children.Count == 2)
			{
				ITerminalNode first = context.children[0] as ITerminalNode;
				ITerminalNode last = context.children[1] as ITerminalNode;

				if (first.Symbol.Type == KScriptLexer.NOT)
				{
					return new NotExpression(Create(context.expression()[0]));
				}
				else
				{
					throw new InvalidOperationException();
				}
			}
			else if (context.children.Count == 3)
			{
				ITerminalNode first = context.children[0] as ITerminalNode;
				ITerminalNode middle = context.children[1] as ITerminalNode;
				ITerminalNode last = context.children[2] as ITerminalNode;

				if (middle != null && middle.Symbol.Type == KScriptLexer.AND)
				{
					IExpression a = Create(context.children[0] as ExpressionContext);
					IExpression b = Create(context.children[2] as ExpressionContext);
					return new AndExpression(a, b);
				}
				else if (middle != null && middle.Symbol.Type == KScriptLexer.OR)
				{
					IExpression a = Create(context.children[0] as ExpressionContext);
					IExpression b = Create(context.children[2] as ExpressionContext);
					return new OrExpression(a, b);
				}
				else if (first != null && last != null && first.Symbol.Type == KScriptLexer.OPEN_PAREN && last.Symbol.Type == KScriptLexer.CLOSE_PAREN)
				{
					return Create(context.children[1] as ExpressionContext);
				}
				else
				{
					throw new InvalidOperationException();
				}
			}
			else
			{
				throw new InvalidOperationException();
			}

			throw new NotImplementedException();
		}
	}
}
