//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/sokirko/smart_parser/Antlr/src/RealtyTypeAndOwnType.g4 by ANTLR 4.8

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
/// by <see cref="RealtyTypeAndOwnType"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IRealtyTypeAndOwnTypeVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.realty_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty_list([NotNull] RealtyTypeAndOwnType.Realty_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.realty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty([NotNull] RealtyTypeAndOwnType.RealtyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.realty_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty_id([NotNull] RealtyTypeAndOwnType.Realty_idContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.square_value_without_spaces"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare_value_without_spaces([NotNull] RealtyTypeAndOwnType.Square_value_without_spacesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.square_value_with_spaces"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare_value_with_spaces([NotNull] RealtyTypeAndOwnType.Square_value_with_spacesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.square_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare_value([NotNull] RealtyTypeAndOwnType.Square_valueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.own_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOwn_type([NotNull] RealtyTypeAndOwnType.Own_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.realty_share"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty_share([NotNull] RealtyTypeAndOwnType.Realty_shareContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.square"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSquare([NotNull] RealtyTypeAndOwnType.SquareContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.realty_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRealty_type([NotNull] RealtyTypeAndOwnType.Realty_typeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RealtyTypeAndOwnType.country"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCountry([NotNull] RealtyTypeAndOwnType.CountryContext context);
}
