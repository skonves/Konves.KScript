using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Konves.KScript.Parsing;
using System;
using static Konves.KScript.Parsing.KScriptParser;

namespace Konves.KScript
{
	internal static class LiteralFactory
	{
		internal static Literal Create(LiteralContext context)
		{
			if (context.literal() != null)
			{
				return Create(context.literal());
			}
			else
			{
				IToken token = (context.children[0] as ITerminalNode).Symbol;
				switch (token.Type)
				{
					case KScriptLexer.NAMED_TOKEN:
						return new Literal(token.Text.Substring(1, token.Text.Length - 2).Trim(), LiteralType.Token);
					case KScriptLexer.TRUE:
						return new Literal(true, LiteralType.Value);
					case KScriptLexer.FALSE:
						return new Literal(false, LiteralType.Value);
					case KScriptLexer.NUMBER:
						return new Literal(decimal.Parse(token.Text), LiteralType.Value);
					case KScriptLexer.STRING:
						return new Literal(token.Text.Substring(1, token.Text.Length - 2), LiteralType.Value);
					case KScriptLexer.NOW:
						return new Literal(null, LiteralType.Date);
					case KScriptLexer.NULL:
						return new Literal(null, LiteralType.Value);
					default:
						throw new InvalidOperationException();
				}
			}
		}
	}
}
