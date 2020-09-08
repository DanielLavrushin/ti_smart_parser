//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\tmp\smart_parser\smart_parser\Antlr\src\SquareList.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class SquareList : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SEMICOLON=1, COMMA=2, OPN_BRK=3, CLS_BRK=4, FRACTION_UNICODE=5, HYPHEN=6, 
		FLOATING=7, BULLET=8, INT=9, OT=10, WEB_LINK=11, SQUARE_METER=12, HECTARE=13, 
		FRACTION_ASCII=14, DOLYA_WORD=15, SPC=16, OWN_TYPE=17, COUNTRY=18, REALTY_TYPE=19, 
		OTHER=20;
	public const int
		RULE_bareSquares = 0, RULE_bareScore = 1, RULE_realty_id = 2, RULE_square_value_without_spaces = 3, 
		RULE_square_value_with_spaces = 4, RULE_square_value = 5, RULE_own_type = 6, 
		RULE_realty_share = 7, RULE_square = 8, RULE_realty_type = 9, RULE_country = 10;
	public static readonly string[] ruleNames = {
		"bareSquares", "bareScore", "realty_id", "square_value_without_spaces", 
		"square_value_with_spaces", "square_value", "own_type", "realty_share", 
		"square", "realty_type", "country"
	};

	private static readonly string[] _LiteralNames = {
		null, "';'", "','", "'('", "')'", null, "'-'", null, null, null, "'\u043E\u0442'", 
		null, null, "'\u0433\u0430'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SEMICOLON", "COMMA", "OPN_BRK", "CLS_BRK", "FRACTION_UNICODE", 
		"HYPHEN", "FLOATING", "BULLET", "INT", "OT", "WEB_LINK", "SQUARE_METER", 
		"HECTARE", "FRACTION_ASCII", "DOLYA_WORD", "SPC", "OWN_TYPE", "COUNTRY", 
		"REALTY_TYPE", "OTHER"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "SquareList.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static SquareList() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public SquareList(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public SquareList(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class BareSquaresContext : ParserRuleContext {
		public BareScoreContext[] bareScore() {
			return GetRuleContexts<BareScoreContext>();
		}
		public BareScoreContext bareScore(int i) {
			return GetRuleContext<BareScoreContext>(i);
		}
		public BareSquaresContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_bareSquares; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterBareSquares(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitBareSquares(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBareSquares(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BareSquaresContext bareSquares() {
		BareSquaresContext _localctx = new BareSquaresContext(Context, State);
		EnterRule(_localctx, 0, RULE_bareSquares);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 23;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 22; bareScore();
				}
				}
				State = 25;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==FLOATING || _la==INT );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BareScoreContext : ParserRuleContext {
		public Square_value_without_spacesContext square_value_without_spaces() {
			return GetRuleContext<Square_value_without_spacesContext>(0);
		}
		public BareScoreContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_bareScore; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterBareScore(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitBareScore(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBareScore(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BareScoreContext bareScore() {
		BareScoreContext _localctx = new BareScoreContext(Context, State);
		EnterRule(_localctx, 2, RULE_bareScore);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 27; square_value_without_spaces();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Realty_idContext : ParserRuleContext {
		public IToken _INT;
		public ITerminalNode INT() { return GetToken(SquareList.INT, 0); }
		public Realty_idContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_realty_id; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterRealty_id(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitRealty_id(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRealty_id(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Realty_idContext realty_id() {
		Realty_idContext _localctx = new Realty_idContext(Context, State);
		EnterRule(_localctx, 4, RULE_realty_id);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29; _localctx._INT = Match(INT);
			State = 30;
			if (!((_localctx._INT!=null?int.Parse(_localctx._INT.Text):0) > 6000000)) throw new FailedPredicateException(this, "$INT.int > 6000000");
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Square_value_without_spacesContext : ParserRuleContext {
		public IToken _INT;
		public ITerminalNode FLOATING() { return GetToken(SquareList.FLOATING, 0); }
		public ITerminalNode INT() { return GetToken(SquareList.INT, 0); }
		public Square_value_without_spacesContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_square_value_without_spaces; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterSquare_value_without_spaces(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitSquare_value_without_spaces(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSquare_value_without_spaces(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Square_value_without_spacesContext square_value_without_spaces() {
		Square_value_without_spacesContext _localctx = new Square_value_without_spacesContext(Context, State);
		EnterRule(_localctx, 6, RULE_square_value_without_spaces);
		try {
			State = 35;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case FLOATING:
				EnterOuterAlt(_localctx, 1);
				{
				State = 32; Match(FLOATING);
				}
				break;
			case INT:
				EnterOuterAlt(_localctx, 2);
				{
				State = 33; _localctx._INT = Match(INT);
				State = 34;
				if (!((_localctx._INT!=null?int.Parse(_localctx._INT.Text):0) < 6000000)) throw new FailedPredicateException(this, "$INT.int < 6000000");
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Square_value_with_spacesContext : ParserRuleContext {
		public IToken _INT;
		public ITerminalNode[] INT() { return GetTokens(SquareList.INT); }
		public ITerminalNode INT(int i) {
			return GetToken(SquareList.INT, i);
		}
		public ITerminalNode FLOATING() { return GetToken(SquareList.FLOATING, 0); }
		public Square_value_with_spacesContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_square_value_with_spaces; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterSquare_value_with_spaces(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitSquare_value_with_spaces(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSquare_value_with_spaces(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Square_value_with_spacesContext square_value_with_spaces() {
		Square_value_with_spacesContext _localctx = new Square_value_with_spacesContext(Context, State);
		EnterRule(_localctx, 8, RULE_square_value_with_spaces);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 37; _localctx._INT = Match(INT);
			State = 39;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				{
				State = 38; _localctx._INT = Match(INT);
				}
				break;
			}
			State = 41;
			_la = TokenStream.LA(1);
			if ( !(_la==FLOATING || _la==INT) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			State = 42;
			if (!((_localctx._INT!=null?int.Parse(_localctx._INT.Text):0) < 1000)) throw new FailedPredicateException(this, "$INT.int < 1000");
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Square_valueContext : ParserRuleContext {
		public Square_value_without_spacesContext square_value_without_spaces() {
			return GetRuleContext<Square_value_without_spacesContext>(0);
		}
		public Square_value_with_spacesContext square_value_with_spaces() {
			return GetRuleContext<Square_value_with_spacesContext>(0);
		}
		public Square_valueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_square_value; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterSquare_value(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitSquare_value(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSquare_value(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Square_valueContext square_value() {
		Square_valueContext _localctx = new Square_valueContext(Context, State);
		EnterRule(_localctx, 10, RULE_square_value);
		try {
			State = 46;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 44; square_value_without_spaces();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 45; square_value_with_spaces();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Own_typeContext : ParserRuleContext {
		public ITerminalNode OWN_TYPE() { return GetToken(SquareList.OWN_TYPE, 0); }
		public Realty_shareContext realty_share() {
			return GetRuleContext<Realty_shareContext>(0);
		}
		public ITerminalNode[] DOLYA_WORD() { return GetTokens(SquareList.DOLYA_WORD); }
		public ITerminalNode DOLYA_WORD(int i) {
			return GetToken(SquareList.DOLYA_WORD, i);
		}
		public ITerminalNode COMMA() { return GetToken(SquareList.COMMA, 0); }
		public ITerminalNode OT() { return GetToken(SquareList.OT, 0); }
		public Own_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_own_type; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterOwn_type(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitOwn_type(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitOwn_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Own_typeContext own_type() {
		Own_typeContext _localctx = new Own_typeContext(Context, State);
		EnterRule(_localctx, 12, RULE_own_type);
		int _la;
		try {
			State = 63;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,8,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 48; Match(OWN_TYPE);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				{
				State = 49; Match(OWN_TYPE);
				State = 51;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==DOLYA_WORD) {
					{
					State = 50; Match(DOLYA_WORD);
					}
				}

				State = 54;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==COMMA) {
					{
					State = 53; Match(COMMA);
					}
				}

				State = 56; realty_share();
				State = 58;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==DOLYA_WORD) {
					{
					State = 57; Match(DOLYA_WORD);
					}
				}

				State = 61;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==OT) {
					{
					State = 60; Match(OT);
					}
				}

				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Realty_shareContext : ParserRuleContext {
		public ITerminalNode FRACTION_UNICODE() { return GetToken(SquareList.FRACTION_UNICODE, 0); }
		public ITerminalNode FRACTION_ASCII() { return GetToken(SquareList.FRACTION_ASCII, 0); }
		public Realty_shareContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_realty_share; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterRealty_share(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitRealty_share(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRealty_share(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Realty_shareContext realty_share() {
		Realty_shareContext _localctx = new Realty_shareContext(Context, State);
		EnterRule(_localctx, 14, RULE_realty_share);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 65;
			_la = TokenStream.LA(1);
			if ( !(_la==FRACTION_UNICODE || _la==FRACTION_ASCII) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class SquareContext : ParserRuleContext {
		public Square_valueContext square_value() {
			return GetRuleContext<Square_valueContext>(0);
		}
		public ITerminalNode SQUARE_METER() { return GetToken(SquareList.SQUARE_METER, 0); }
		public ITerminalNode HECTARE() { return GetToken(SquareList.HECTARE, 0); }
		public SquareContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_square; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterSquare(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitSquare(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSquare(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SquareContext square() {
		SquareContext _localctx = new SquareContext(Context, State);
		EnterRule(_localctx, 16, RULE_square);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 67; square_value();
			State = 68;
			_la = TokenStream.LA(1);
			if ( !(_la==SQUARE_METER || _la==HECTARE) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Realty_typeContext : ParserRuleContext {
		public ITerminalNode REALTY_TYPE() { return GetToken(SquareList.REALTY_TYPE, 0); }
		public Realty_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_realty_type; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterRealty_type(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitRealty_type(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRealty_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Realty_typeContext realty_type() {
		Realty_typeContext _localctx = new Realty_typeContext(Context, State);
		EnterRule(_localctx, 18, RULE_realty_type);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 70; Match(REALTY_TYPE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CountryContext : ParserRuleContext {
		public ITerminalNode COUNTRY() { return GetToken(SquareList.COUNTRY, 0); }
		public CountryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_country; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.EnterCountry(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListListener typedListener = listener as ISquareListListener;
			if (typedListener != null) typedListener.ExitCountry(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListVisitor<TResult> typedVisitor = visitor as ISquareListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCountry(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CountryContext country() {
		CountryContext _localctx = new CountryContext(Context, State);
		EnterRule(_localctx, 20, RULE_country);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 72; Match(COUNTRY);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2: return realty_id_sempred((Realty_idContext)_localctx, predIndex);
		case 3: return square_value_without_spaces_sempred((Square_value_without_spacesContext)_localctx, predIndex);
		case 4: return square_value_with_spaces_sempred((Square_value_with_spacesContext)_localctx, predIndex);
		}
		return true;
	}
	private bool realty_id_sempred(Realty_idContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return (_localctx._INT!=null?int.Parse(_localctx._INT.Text):0) > 6000000;
		}
		return true;
	}
	private bool square_value_without_spaces_sempred(Square_value_without_spacesContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1: return (_localctx._INT!=null?int.Parse(_localctx._INT.Text):0) < 6000000;
		}
		return true;
	}
	private bool square_value_with_spaces_sempred(Square_value_with_spacesContext _localctx, int predIndex) {
		switch (predIndex) {
		case 2: return (_localctx._INT!=null?int.Parse(_localctx._INT.Text):0) < 1000;
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x16', 'M', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', 
		'\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', 
		'\x4', '\f', '\t', '\f', '\x3', '\x2', '\x6', '\x2', '\x1A', '\n', '\x2', 
		'\r', '\x2', '\xE', '\x2', '\x1B', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x5', '\x5', '&', '\n', '\x5', '\x3', '\x6', '\x3', '\x6', '\x5', 
		'\x6', '*', '\n', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\a', '\x3', '\a', '\x5', '\a', '\x31', '\n', '\a', '\x3', '\b', '\x3', 
		'\b', '\x3', '\b', '\x5', '\b', '\x36', '\n', '\b', '\x3', '\b', '\x5', 
		'\b', '\x39', '\n', '\b', '\x3', '\b', '\x3', '\b', '\x5', '\b', '=', 
		'\n', '\b', '\x3', '\b', '\x5', '\b', '@', '\n', '\b', '\x5', '\b', '\x42', 
		'\n', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', 
		'\x2', '\x2', '\r', '\x2', '\x4', '\x6', '\b', '\n', '\f', '\xE', '\x10', 
		'\x12', '\x14', '\x16', '\x2', '\x5', '\x4', '\x2', '\t', '\t', '\v', 
		'\v', '\x4', '\x2', '\a', '\a', '\x10', '\x10', '\x3', '\x2', '\xE', '\xF', 
		'\x2', 'J', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x4', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\x6', '\x1F', '\x3', '\x2', '\x2', '\x2', 
		'\b', '%', '\x3', '\x2', '\x2', '\x2', '\n', '\'', '\x3', '\x2', '\x2', 
		'\x2', '\f', '\x30', '\x3', '\x2', '\x2', '\x2', '\xE', '\x41', '\x3', 
		'\x2', '\x2', '\x2', '\x10', '\x43', '\x3', '\x2', '\x2', '\x2', '\x12', 
		'\x45', '\x3', '\x2', '\x2', '\x2', '\x14', 'H', '\x3', '\x2', '\x2', 
		'\x2', '\x16', 'J', '\x3', '\x2', '\x2', '\x2', '\x18', '\x1A', '\x5', 
		'\x4', '\x3', '\x2', '\x19', '\x18', '\x3', '\x2', '\x2', '\x2', '\x1A', 
		'\x1B', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x3', '\x3', 
		'\x2', '\x2', '\x2', '\x1D', '\x1E', '\x5', '\b', '\x5', '\x2', '\x1E', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x1F', ' ', '\a', '\v', '\x2', '\x2', 
		' ', '!', '\x6', '\x4', '\x2', '\x3', '!', '\a', '\x3', '\x2', '\x2', 
		'\x2', '\"', '&', '\a', '\t', '\x2', '\x2', '#', '$', '\a', '\v', '\x2', 
		'\x2', '$', '&', '\x6', '\x5', '\x3', '\x3', '%', '\"', '\x3', '\x2', 
		'\x2', '\x2', '%', '#', '\x3', '\x2', '\x2', '\x2', '&', '\t', '\x3', 
		'\x2', '\x2', '\x2', '\'', ')', '\a', '\v', '\x2', '\x2', '(', '*', '\a', 
		'\v', '\x2', '\x2', ')', '(', '\x3', '\x2', '\x2', '\x2', ')', '*', '\x3', 
		'\x2', '\x2', '\x2', '*', '+', '\x3', '\x2', '\x2', '\x2', '+', ',', '\t', 
		'\x2', '\x2', '\x2', ',', '-', '\x6', '\x6', '\x4', '\x3', '-', '\v', 
		'\x3', '\x2', '\x2', '\x2', '.', '\x31', '\x5', '\b', '\x5', '\x2', '/', 
		'\x31', '\x5', '\n', '\x6', '\x2', '\x30', '.', '\x3', '\x2', '\x2', '\x2', 
		'\x30', '/', '\x3', '\x2', '\x2', '\x2', '\x31', '\r', '\x3', '\x2', '\x2', 
		'\x2', '\x32', '\x42', '\a', '\x13', '\x2', '\x2', '\x33', '\x35', '\a', 
		'\x13', '\x2', '\x2', '\x34', '\x36', '\a', '\x11', '\x2', '\x2', '\x35', 
		'\x34', '\x3', '\x2', '\x2', '\x2', '\x35', '\x36', '\x3', '\x2', '\x2', 
		'\x2', '\x36', '\x38', '\x3', '\x2', '\x2', '\x2', '\x37', '\x39', '\a', 
		'\x4', '\x2', '\x2', '\x38', '\x37', '\x3', '\x2', '\x2', '\x2', '\x38', 
		'\x39', '\x3', '\x2', '\x2', '\x2', '\x39', ':', '\x3', '\x2', '\x2', 
		'\x2', ':', '<', '\x5', '\x10', '\t', '\x2', ';', '=', '\a', '\x11', '\x2', 
		'\x2', '<', ';', '\x3', '\x2', '\x2', '\x2', '<', '=', '\x3', '\x2', '\x2', 
		'\x2', '=', '?', '\x3', '\x2', '\x2', '\x2', '>', '@', '\a', '\f', '\x2', 
		'\x2', '?', '>', '\x3', '\x2', '\x2', '\x2', '?', '@', '\x3', '\x2', '\x2', 
		'\x2', '@', '\x42', '\x3', '\x2', '\x2', '\x2', '\x41', '\x32', '\x3', 
		'\x2', '\x2', '\x2', '\x41', '\x33', '\x3', '\x2', '\x2', '\x2', '\x42', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\x43', '\x44', '\t', '\x3', '\x2', 
		'\x2', '\x44', '\x11', '\x3', '\x2', '\x2', '\x2', '\x45', '\x46', '\x5', 
		'\f', '\a', '\x2', '\x46', 'G', '\t', '\x4', '\x2', '\x2', 'G', '\x13', 
		'\x3', '\x2', '\x2', '\x2', 'H', 'I', '\a', '\x15', '\x2', '\x2', 'I', 
		'\x15', '\x3', '\x2', '\x2', '\x2', 'J', 'K', '\a', '\x14', '\x2', '\x2', 
		'K', '\x17', '\x3', '\x2', '\x2', '\x2', '\v', '\x1B', '%', ')', '\x30', 
		'\x35', '\x38', '<', '?', '\x41',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
