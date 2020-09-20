//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/sokirko/smart_parser/Antlr/src/BaseLexer.g4 by ANTLR 4.8

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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class BaseLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SEMICOLON=1, COMMA=2, OPN_BRK=3, CLS_BRK=4, FRACTION_UNICODE=5, HYPHEN=6, 
		FLOATING=7, BULLET=8, INT=9, OT=10, WEB_LINK=11, SQUARE_METER=12, HECTARE=13, 
		FRACTION_ASCII=14, DOLYA_WORD=15, SPC=16;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"SEMICOLON", "COMMA", "OPN_BRK", "CLS_BRK", "FRACTION_UNICODE", "HYPHEN", 
		"FLOATING", "BULLET", "INT", "OT", "WEB_LINK", "SQUARE_METER", "HECTARE", 
		"FRACTION_ASCII", "DOLYA_WORD", "SPC"
	};


	public BaseLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public BaseLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "','", "'('", "')'", null, "'-'", null, null, null, "'\u043E\u0442'", 
		null, null, "'\u0433\u0430'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SEMICOLON", "COMMA", "OPN_BRK", "CLS_BRK", "FRACTION_UNICODE", 
		"HYPHEN", "FLOATING", "BULLET", "INT", "OT", "WEB_LINK", "SQUARE_METER", 
		"HECTARE", "FRACTION_ASCII", "DOLYA_WORD", "SPC"
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

	public override string GrammarFileName { get { return "BaseLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static BaseLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x12', '~', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x6', '\b', 
		'\x31', '\n', '\b', '\r', '\b', '\xE', '\b', '\x32', '\x3', '\b', '\x3', 
		'\b', '\x6', '\b', '\x37', '\n', '\b', '\r', '\b', '\xE', '\b', '\x38', 
		'\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x6', '\n', '?', 
		'\n', '\n', '\r', '\n', '\xE', '\n', '@', '\x3', '\v', '\x3', '\v', '\x3', 
		'\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', 
		'\x3', '\f', '\x5', '\f', 'L', '\n', '\f', '\x3', '\f', '\x3', '\f', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x6', '\f', 'S', '\n', '\f', '\r', '\f', 
		'\xE', '\f', 'T', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x5', '\r', 
		'\x65', '\n', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x10', '\x5', '\x10', 'v', '\n', '\x10', '\x3', '\x11', '\x6', 
		'\x11', 'y', '\n', '\x11', '\r', '\x11', '\xE', '\x11', 'z', '\x3', '\x11', 
		'\x3', '\x11', '\x2', '\x2', '\x12', '\x3', '\x3', '\x5', '\x4', '\a', 
		'\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', 
		'\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', 
		'\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '\x3', '\x2', '\t', '\x4', 
		'\x2', '\xBE', '\xC0', '\x2152', '\x2160', '\x3', '\x2', '\x32', ';', 
		'\x4', '\x2', '.', '.', '\x30', '\x30', '\x3', '\x2', '\x33', ';', '\x3', 
		'\x2', '\x30', '\x30', '\x4', '\x2', '\x30', ';', '\x63', '|', '\x3', 
		'\x2', '\x31', '\x31', '\x2', '\x87', '\x2', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x3', '#', '\x3', 
		'\x2', '\x2', '\x2', '\x5', '%', '\x3', '\x2', '\x2', '\x2', '\a', '\'', 
		'\x3', '\x2', '\x2', '\x2', '\t', ')', '\x3', '\x2', '\x2', '\x2', '\v', 
		'+', '\x3', '\x2', '\x2', '\x2', '\r', '-', '\x3', '\x2', '\x2', '\x2', 
		'\xF', '\x30', '\x3', '\x2', '\x2', '\x2', '\x11', ':', '\x3', '\x2', 
		'\x2', '\x2', '\x13', '>', '\x3', '\x2', '\x2', '\x2', '\x15', '\x42', 
		'\x3', '\x2', '\x2', '\x2', '\x17', '\x45', '\x3', '\x2', '\x2', '\x2', 
		'\x19', '\x64', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x66', '\x3', '\x2', 
		'\x2', '\x2', '\x1D', 'i', '\x3', '\x2', '\x2', '\x2', '\x1F', 'u', '\x3', 
		'\x2', '\x2', '\x2', '!', 'x', '\x3', '\x2', '\x2', '\x2', '#', '$', '\a', 
		'=', '\x2', '\x2', '$', '\x4', '\x3', '\x2', '\x2', '\x2', '%', '&', '\a', 
		'.', '\x2', '\x2', '&', '\x6', '\x3', '\x2', '\x2', '\x2', '\'', '(', 
		'\a', '*', '\x2', '\x2', '(', '\b', '\x3', '\x2', '\x2', '\x2', ')', '*', 
		'\a', '+', '\x2', '\x2', '*', '\n', '\x3', '\x2', '\x2', '\x2', '+', ',', 
		'\t', '\x2', '\x2', '\x2', ',', '\f', '\x3', '\x2', '\x2', '\x2', '-', 
		'.', '\a', '/', '\x2', '\x2', '.', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'/', '\x31', '\t', '\x3', '\x2', '\x2', '\x30', '/', '\x3', '\x2', '\x2', 
		'\x2', '\x31', '\x32', '\x3', '\x2', '\x2', '\x2', '\x32', '\x30', '\x3', 
		'\x2', '\x2', '\x2', '\x32', '\x33', '\x3', '\x2', '\x2', '\x2', '\x33', 
		'\x34', '\x3', '\x2', '\x2', '\x2', '\x34', '\x36', '\t', '\x4', '\x2', 
		'\x2', '\x35', '\x37', '\t', '\x3', '\x2', '\x2', '\x36', '\x35', '\x3', 
		'\x2', '\x2', '\x2', '\x37', '\x38', '\x3', '\x2', '\x2', '\x2', '\x38', 
		'\x36', '\x3', '\x2', '\x2', '\x2', '\x38', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\x39', '\x10', '\x3', '\x2', '\x2', '\x2', ':', ';', '\t', '\x5', 
		'\x2', '\x2', ';', '<', '\t', '\x6', '\x2', '\x2', '<', '\x12', '\x3', 
		'\x2', '\x2', '\x2', '=', '?', '\t', '\x3', '\x2', '\x2', '>', '=', '\x3', 
		'\x2', '\x2', '\x2', '?', '@', '\x3', '\x2', '\x2', '\x2', '@', '>', '\x3', 
		'\x2', '\x2', '\x2', '@', '\x41', '\x3', '\x2', '\x2', '\x2', '\x41', 
		'\x14', '\x3', '\x2', '\x2', '\x2', '\x42', '\x43', '\a', '\x440', '\x2', 
		'\x2', '\x43', '\x44', '\a', '\x444', '\x2', '\x2', '\x44', '\x16', '\x3', 
		'\x2', '\x2', '\x2', '\x45', '\x46', '\a', 'j', '\x2', '\x2', '\x46', 
		'G', '\a', 'v', '\x2', '\x2', 'G', 'H', '\a', 'v', '\x2', '\x2', 'H', 
		'I', '\a', 'r', '\x2', '\x2', 'I', 'K', '\x3', '\x2', '\x2', '\x2', 'J', 
		'L', '\a', 'u', '\x2', '\x2', 'K', 'J', '\x3', '\x2', '\x2', '\x2', 'K', 
		'L', '\x3', '\x2', '\x2', '\x2', 'L', 'M', '\x3', '\x2', '\x2', '\x2', 
		'M', 'N', '\a', '<', '\x2', '\x2', 'N', 'O', '\a', '\x31', '\x2', '\x2', 
		'O', 'P', '\a', '\x31', '\x2', '\x2', 'P', 'R', '\x3', '\x2', '\x2', '\x2', 
		'Q', 'S', '\t', '\a', '\x2', '\x2', 'R', 'Q', '\x3', '\x2', '\x2', '\x2', 
		'S', 'T', '\x3', '\x2', '\x2', '\x2', 'T', 'R', '\x3', '\x2', '\x2', '\x2', 
		'T', 'U', '\x3', '\x2', '\x2', '\x2', 'U', '\x18', '\x3', '\x2', '\x2', 
		'\x2', 'V', 'W', '\a', '\x43C', '\x2', '\x2', 'W', 'X', '\a', '\x434', 
		'\x2', '\x2', 'X', 'Y', '\a', '\x30', '\x2', '\x2', 'Y', '\x65', '\a', 
		'\x43E', '\x2', '\x2', 'Z', '[', '\a', '\x43C', '\x2', '\x2', '[', '\\', 
		'\a', '\x434', '\x2', '\x2', '\\', ']', '\a', '\x30', '\x2', '\x2', ']', 
		'^', '\a', '\x43E', '\x2', '\x2', '^', '\x65', '\a', '\x30', '\x2', '\x2', 
		'_', '`', '\a', '\x43E', '\x2', '\x2', '`', '\x61', '\a', '\x34', '\x2', 
		'\x2', '\x61', '\x65', '\a', '\x30', '\x2', '\x2', '\x62', '\x63', '\a', 
		'\x43E', '\x2', '\x2', '\x63', '\x65', '\a', '\x34', '\x2', '\x2', '\x64', 
		'V', '\x3', '\x2', '\x2', '\x2', '\x64', 'Z', '\x3', '\x2', '\x2', '\x2', 
		'\x64', '_', '\x3', '\x2', '\x2', '\x2', '\x64', '\x62', '\x3', '\x2', 
		'\x2', '\x2', '\x65', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x66', 'g', 
		'\a', '\x435', '\x2', '\x2', 'g', 'h', '\a', '\x432', '\x2', '\x2', 'h', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', 'i', 'j', '\x5', '\x13', '\n', '\x2', 
		'j', 'k', '\t', '\b', '\x2', '\x2', 'k', 'l', '\x5', '\x13', '\n', '\x2', 
		'l', '\x1E', '\x3', '\x2', '\x2', '\x2', 'm', 'n', '\a', '\x436', '\x2', 
		'\x2', 'n', 'o', '\a', '\x440', '\x2', '\x2', 'o', 'p', '\a', '\x43D', 
		'\x2', '\x2', 'p', 'v', '\a', '\x43A', '\x2', '\x2', 'q', 'r', '\a', '\x436', 
		'\x2', '\x2', 'r', 's', '\a', '\x440', '\x2', '\x2', 's', 't', '\a', '\x43D', 
		'\x2', '\x2', 't', 'v', '\a', '\x451', '\x2', '\x2', 'u', 'm', '\x3', 
		'\x2', '\x2', '\x2', 'u', 'q', '\x3', '\x2', '\x2', '\x2', 'v', ' ', '\x3', 
		'\x2', '\x2', '\x2', 'w', 'y', '\a', '\"', '\x2', '\x2', 'x', 'w', '\x3', 
		'\x2', '\x2', '\x2', 'y', 'z', '\x3', '\x2', '\x2', '\x2', 'z', 'x', '\x3', 
		'\x2', '\x2', '\x2', 'z', '{', '\x3', '\x2', '\x2', '\x2', '{', '|', '\x3', 
		'\x2', '\x2', '\x2', '|', '}', '\b', '\x11', '\x2', '\x2', '}', '\"', 
		'\x3', '\x2', '\x2', '\x2', '\v', '\x2', '\x32', '\x38', '@', 'K', 'T', 
		'\x64', 'u', 'z', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}