//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/sokirko/smart_parser/Antlr/src/Soup.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="Soup"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface ISoupVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.any_realty_item_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAny_realty_item_list([NotNull] Soup.Any_realty_item_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.any_realty_item"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAny_realty_item([NotNull] Soup.Any_realty_itemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.realty_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty_id([NotNull] Soup.Realty_idContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.square_value_without_spaces"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare_value_without_spaces([NotNull] Soup.Square_value_without_spacesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.square_value_with_spaces"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare_value_with_spaces([NotNull] Soup.Square_value_with_spacesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.square_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare_value([NotNull] Soup.Square_valueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.own_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOwn_type([NotNull] Soup.Own_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.realty_share"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty_share([NotNull] Soup.Realty_shareContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.square"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare([NotNull] Soup.SquareContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.realty_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty_type([NotNull] Soup.Realty_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="Soup.country"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCountry([NotNull] Soup.CountryContext context);
}
