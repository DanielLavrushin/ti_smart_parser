//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\tmp\smart_parser\smart_parser\Antlr\src\SquareListParser.g4 by ANTLR 4.8

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
public partial class SquareListParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SEMICOLON=1, COMMA=2, OPN_BRK=3, CLS_BRK=4, SPC=5, FRACTION_UNICODE=6, 
		HYPHEN=7, OT=8, REALTY_ID=9, FRACTION_ASCII=10, DOLYA_WORD=11, OWN_TYPE=12, 
		COUNTRY=13, REALTY_TYPE=14, SQUARE_METER=15, HECTARE=16, NUMBER=17;
	public const int
		RULE_squares = 0, RULE_own_type = 1, RULE_realty_share = 2, RULE_square = 3, 
		RULE_realty_type = 4, RULE_country = 5;
	public static readonly string[] ruleNames = {
		"squares", "own_type", "realty_share", "square", "realty_type", "country"
	};

	private static readonly string[] _LiteralNames = {
		null, "';'", "','", "'('", "')'", null, null, "'-'", "'\u043E\u0442'", 
		null, null, null, null, null, null, null, "'\u0433\u0430'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SEMICOLON", "COMMA", "OPN_BRK", "CLS_BRK", "SPC", "FRACTION_UNICODE", 
		"HYPHEN", "OT", "REALTY_ID", "FRACTION_ASCII", "DOLYA_WORD", "OWN_TYPE", 
		"COUNTRY", "REALTY_TYPE", "SQUARE_METER", "HECTARE", "NUMBER"
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

	public override string GrammarFileName { get { return "SquareListParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static SquareListParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public SquareListParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public SquareListParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class SquaresContext : ParserRuleContext {
		public SquareContext[] square() {
			return GetRuleContexts<SquareContext>();
		}
		public SquareContext square(int i) {
			return GetRuleContext<SquareContext>(i);
		}
		public SquaresContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_squares; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.EnterSquares(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.ExitSquares(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListParserVisitor<TResult> typedVisitor = visitor as ISquareListParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSquares(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SquaresContext squares() {
		SquaresContext _localctx = new SquaresContext(Context, State);
		EnterRule(_localctx, 0, RULE_squares);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 13;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 12; square();
				}
				}
				State = 15;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==NUMBER );
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
		public ITerminalNode OWN_TYPE() { return GetToken(SquareListParser.OWN_TYPE, 0); }
		public Realty_shareContext realty_share() {
			return GetRuleContext<Realty_shareContext>(0);
		}
		public ITerminalNode[] DOLYA_WORD() { return GetTokens(SquareListParser.DOLYA_WORD); }
		public ITerminalNode DOLYA_WORD(int i) {
			return GetToken(SquareListParser.DOLYA_WORD, i);
		}
		public ITerminalNode COMMA() { return GetToken(SquareListParser.COMMA, 0); }
		public ITerminalNode OT() { return GetToken(SquareListParser.OT, 0); }
		public Own_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_own_type; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.EnterOwn_type(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.ExitOwn_type(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListParserVisitor<TResult> typedVisitor = visitor as ISquareListParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitOwn_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Own_typeContext own_type() {
		Own_typeContext _localctx = new Own_typeContext(Context, State);
		EnterRule(_localctx, 2, RULE_own_type);
		int _la;
		try {
			State = 32;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 17; Match(OWN_TYPE);
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				{
				State = 18; Match(OWN_TYPE);
				State = 20;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==DOLYA_WORD) {
					{
					State = 19; Match(DOLYA_WORD);
					}
				}

				State = 23;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==COMMA) {
					{
					State = 22; Match(COMMA);
					}
				}

				State = 25; realty_share();
				State = 27;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==DOLYA_WORD) {
					{
					State = 26; Match(DOLYA_WORD);
					}
				}

				State = 30;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==OT) {
					{
					State = 29; Match(OT);
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
		public ITerminalNode FRACTION_UNICODE() { return GetToken(SquareListParser.FRACTION_UNICODE, 0); }
		public ITerminalNode FRACTION_ASCII() { return GetToken(SquareListParser.FRACTION_ASCII, 0); }
		public Realty_shareContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_realty_share; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.EnterRealty_share(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.ExitRealty_share(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListParserVisitor<TResult> typedVisitor = visitor as ISquareListParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRealty_share(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Realty_shareContext realty_share() {
		Realty_shareContext _localctx = new Realty_shareContext(Context, State);
		EnterRule(_localctx, 4, RULE_realty_share);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 34;
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
		public ITerminalNode NUMBER() { return GetToken(SquareListParser.NUMBER, 0); }
		public ITerminalNode SQUARE_METER() { return GetToken(SquareListParser.SQUARE_METER, 0); }
		public ITerminalNode HECTARE() { return GetToken(SquareListParser.HECTARE, 0); }
		public SquareContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_square; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.EnterSquare(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.ExitSquare(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListParserVisitor<TResult> typedVisitor = visitor as ISquareListParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitSquare(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public SquareContext square() {
		SquareContext _localctx = new SquareContext(Context, State);
		EnterRule(_localctx, 6, RULE_square);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 36; Match(NUMBER);
			State = 37;
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
		public ITerminalNode REALTY_TYPE() { return GetToken(SquareListParser.REALTY_TYPE, 0); }
		public Realty_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_realty_type; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.EnterRealty_type(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.ExitRealty_type(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListParserVisitor<TResult> typedVisitor = visitor as ISquareListParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRealty_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Realty_typeContext realty_type() {
		Realty_typeContext _localctx = new Realty_typeContext(Context, State);
		EnterRule(_localctx, 8, RULE_realty_type);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39; Match(REALTY_TYPE);
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
		public ITerminalNode COUNTRY() { return GetToken(SquareListParser.COUNTRY, 0); }
		public CountryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_country; } }
		public override void EnterRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.EnterCountry(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ISquareListParserListener typedListener = listener as ISquareListParserListener;
			if (typedListener != null) typedListener.ExitCountry(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ISquareListParserVisitor<TResult> typedVisitor = visitor as ISquareListParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCountry(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CountryContext country() {
		CountryContext _localctx = new CountryContext(Context, State);
		EnterRule(_localctx, 10, RULE_country);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 41; Match(COUNTRY);
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

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x13', '.', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x6', '\x2', 
		'\x10', '\n', '\x2', '\r', '\x2', '\xE', '\x2', '\x11', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x5', '\x3', '\x17', '\n', '\x3', '\x3', 
		'\x3', '\x5', '\x3', '\x1A', '\n', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x5', '\x3', '\x1E', '\n', '\x3', '\x3', '\x3', '\x5', '\x3', '!', '\n', 
		'\x3', '\x5', '\x3', '#', '\n', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x2', '\x2', '\b', '\x2', '\x4', '\x6', 
		'\b', '\n', '\f', '\x2', '\x4', '\x4', '\x2', '\b', '\b', '\f', '\f', 
		'\x3', '\x2', '\x11', '\x12', '\x2', '-', '\x2', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x4', '\"', '\x3', '\x2', '\x2', '\x2', '\x6', '$', '\x3', 
		'\x2', '\x2', '\x2', '\b', '&', '\x3', '\x2', '\x2', '\x2', '\n', ')', 
		'\x3', '\x2', '\x2', '\x2', '\f', '+', '\x3', '\x2', '\x2', '\x2', '\xE', 
		'\x10', '\x5', '\b', '\x5', '\x2', '\xF', '\xE', '\x3', '\x2', '\x2', 
		'\x2', '\x10', '\x11', '\x3', '\x2', '\x2', '\x2', '\x11', '\xF', '\x3', 
		'\x2', '\x2', '\x2', '\x11', '\x12', '\x3', '\x2', '\x2', '\x2', '\x12', 
		'\x3', '\x3', '\x2', '\x2', '\x2', '\x13', '#', '\a', '\xE', '\x2', '\x2', 
		'\x14', '\x16', '\a', '\xE', '\x2', '\x2', '\x15', '\x17', '\a', '\r', 
		'\x2', '\x2', '\x16', '\x15', '\x3', '\x2', '\x2', '\x2', '\x16', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x17', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\x18', '\x1A', '\a', '\x4', '\x2', '\x2', '\x19', '\x18', '\x3', '\x2', 
		'\x2', '\x2', '\x19', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x1B', 
		'\x3', '\x2', '\x2', '\x2', '\x1B', '\x1D', '\x5', '\x6', '\x4', '\x2', 
		'\x1C', '\x1E', '\a', '\r', '\x2', '\x2', '\x1D', '\x1C', '\x3', '\x2', 
		'\x2', '\x2', '\x1D', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x1E', ' ', 
		'\x3', '\x2', '\x2', '\x2', '\x1F', '!', '\a', '\n', '\x2', '\x2', ' ', 
		'\x1F', '\x3', '\x2', '\x2', '\x2', ' ', '!', '\x3', '\x2', '\x2', '\x2', 
		'!', '#', '\x3', '\x2', '\x2', '\x2', '\"', '\x13', '\x3', '\x2', '\x2', 
		'\x2', '\"', '\x14', '\x3', '\x2', '\x2', '\x2', '#', '\x5', '\x3', '\x2', 
		'\x2', '\x2', '$', '%', '\t', '\x2', '\x2', '\x2', '%', '\a', '\x3', '\x2', 
		'\x2', '\x2', '&', '\'', '\a', '\x13', '\x2', '\x2', '\'', '(', '\t', 
		'\x3', '\x2', '\x2', '(', '\t', '\x3', '\x2', '\x2', '\x2', ')', '*', 
		'\a', '\x10', '\x2', '\x2', '*', '\v', '\x3', '\x2', '\x2', '\x2', '+', 
		',', '\a', '\xF', '\x2', '\x2', ',', '\r', '\x3', '\x2', '\x2', '\x2', 
		'\b', '\x11', '\x16', '\x19', '\x1D', ' ', '\"',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
