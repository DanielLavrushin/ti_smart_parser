//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/sokirko/smart_parser/Antlr/src/RealtyTypeList.g4 by ANTLR 4.8

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
public partial class RealtyTypeList : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SEMICOLON=1, COMMA=2, OPN_BRK=3, CLS_BRK=4, FRACTION_UNICODE=5, HYPHEN=6, 
		FLOATING=7, BULLET=8, INT=9, OT=10, WEB_LINK=11, SQUARE_METER=12, HECTARE=13, 
		FRACTION_ASCII=14, DOLYA_WORD=15, SPC=16, OWN_TYPE=17, COUNTRY=18, REALTY_TYPE=19, 
		OTHER=20;
	public const int
		RULE_realty_type_list = 0, RULE_realty_type = 1;
	public static readonly string[] ruleNames = {
		"realty_type_list", "realty_type"
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

	public override string GrammarFileName { get { return "RealtyTypeList.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static RealtyTypeList() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public RealtyTypeList(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public RealtyTypeList(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class Realty_type_listContext : ParserRuleContext {
		public Realty_typeContext[] realty_type() {
			return GetRuleContexts<Realty_typeContext>();
		}
		public Realty_typeContext realty_type(int i) {
			return GetRuleContext<Realty_typeContext>(i);
		}
		public Realty_type_listContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_realty_type_list; } }
		public override void EnterRule(IParseTreeListener listener) {
			IRealtyTypeListListener typedListener = listener as IRealtyTypeListListener;
			if (typedListener != null) typedListener.EnterRealty_type_list(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IRealtyTypeListListener typedListener = listener as IRealtyTypeListListener;
			if (typedListener != null) typedListener.ExitRealty_type_list(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRealtyTypeListVisitor<TResult> typedVisitor = visitor as IRealtyTypeListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRealty_type_list(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Realty_type_listContext realty_type_list() {
		Realty_type_listContext _localctx = new Realty_type_listContext(Context, State);
		EnterRule(_localctx, 0, RULE_realty_type_list);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 5;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 4; realty_type();
				}
				}
				State = 7;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( _la==REALTY_TYPE );
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
		public ITerminalNode REALTY_TYPE() { return GetToken(RealtyTypeList.REALTY_TYPE, 0); }
		public ITerminalNode COMMA() { return GetToken(RealtyTypeList.COMMA, 0); }
		public Realty_typeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_realty_type; } }
		public override void EnterRule(IParseTreeListener listener) {
			IRealtyTypeListListener typedListener = listener as IRealtyTypeListListener;
			if (typedListener != null) typedListener.EnterRealty_type(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IRealtyTypeListListener typedListener = listener as IRealtyTypeListListener;
			if (typedListener != null) typedListener.ExitRealty_type(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IRealtyTypeListVisitor<TResult> typedVisitor = visitor as IRealtyTypeListVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRealty_type(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Realty_typeContext realty_type() {
		Realty_typeContext _localctx = new Realty_typeContext(Context, State);
		EnterRule(_localctx, 2, RULE_realty_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			{
			State = 9; Match(REALTY_TYPE);
			State = 11;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==COMMA) {
				{
				State = 10; Match(COMMA);
				}
			}

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

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x16', '\x10', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x3', '\x2', '\x6', '\x2', '\b', '\n', '\x2', '\r', '\x2', 
		'\xE', '\x2', '\t', '\x3', '\x3', '\x3', '\x3', '\x5', '\x3', '\xE', '\n', 
		'\x3', '\x3', '\x3', '\x2', '\x2', '\x4', '\x2', '\x4', '\x2', '\x2', 
		'\x2', '\xF', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x4', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x6', '\b', '\x5', '\x4', '\x3', '\x2', '\a', '\x6', 
		'\x3', '\x2', '\x2', '\x2', '\b', '\t', '\x3', '\x2', '\x2', '\x2', '\t', 
		'\a', '\x3', '\x2', '\x2', '\x2', '\t', '\n', '\x3', '\x2', '\x2', '\x2', 
		'\n', '\x3', '\x3', '\x2', '\x2', '\x2', '\v', '\r', '\a', '\x15', '\x2', 
		'\x2', '\f', '\xE', '\a', '\x4', '\x2', '\x2', '\r', '\f', '\x3', '\x2', 
		'\x2', '\x2', '\r', '\xE', '\x3', '\x2', '\x2', '\x2', '\xE', '\x5', '\x3', 
		'\x2', '\x2', '\x2', '\x4', '\t', '\r',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
