//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\tmp\smart_parser\smart_parser\Antlr\src\StrictParser.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="StrictParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IStrictParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="StrictParser.realty_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRealty_list([NotNull] StrictParser.Realty_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="StrictParser.realty_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRealty_list([NotNull] StrictParser.Realty_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="StrictParser.realty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRealty([NotNull] StrictParser.RealtyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="StrictParser.realty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRealty([NotNull] StrictParser.RealtyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="StrictParser.own_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOwn_type([NotNull] StrictParser.Own_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="StrictParser.own_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOwn_type([NotNull] StrictParser.Own_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="StrictParser.realty_share"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRealty_share([NotNull] StrictParser.Realty_shareContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="StrictParser.realty_share"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRealty_share([NotNull] StrictParser.Realty_shareContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="StrictParser.square"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSquare([NotNull] StrictParser.SquareContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="StrictParser.square"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSquare([NotNull] StrictParser.SquareContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="StrictParser.realty_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRealty_type([NotNull] StrictParser.Realty_typeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="StrictParser.realty_type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRealty_type([NotNull] StrictParser.Realty_typeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="StrictParser.country"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCountry([NotNull] StrictParser.CountryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="StrictParser.country"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCountry([NotNull] StrictParser.CountryContext context);
}
