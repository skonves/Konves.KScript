//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\steve\Konves.KScript\src\Konves.KScript.Grammar\KScript.g4 by ANTLR 4.5.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Konves.KScript.Parsing {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="KScriptParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.3")]
[System.CLSCompliant(false)]
internal interface IKScriptListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="KScriptParser.root"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRoot([NotNull] KScriptParser.RootContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KScriptParser.root"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRoot([NotNull] KScriptParser.RootContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="KScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] KScriptParser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KScriptParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] KScriptParser.LiteralContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="KScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] KScriptParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KScriptParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] KScriptParser.ExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="KScriptParser.betweenExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBetweenExpression([NotNull] KScriptParser.BetweenExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KScriptParser.betweenExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBetweenExpression([NotNull] KScriptParser.BetweenExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="KScriptParser.inExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInExpression([NotNull] KScriptParser.InExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KScriptParser.inExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInExpression([NotNull] KScriptParser.InExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="KScriptParser.relationalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelationalExpression([NotNull] KScriptParser.RelationalExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KScriptParser.relationalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelationalExpression([NotNull] KScriptParser.RelationalExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="KScriptParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterList([NotNull] KScriptParser.ListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="KScriptParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitList([NotNull] KScriptParser.ListContext context);
}
} // namespace Konves.KScript.Parsing
