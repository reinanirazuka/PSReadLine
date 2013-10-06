﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;

namespace PSConsoleUtilities
{
    public class PSConsoleReadlineOptions
    {
        public const ConsoleColor DefaultCommentForegroundColor   = ConsoleColor.DarkGreen;
        public const ConsoleColor DefaultKeywordForegroundColor   = ConsoleColor.Green;
        public const ConsoleColor DefaultStringForegroundColor    = ConsoleColor.DarkCyan;
        public const ConsoleColor DefaultOperatorForegroundColor  = ConsoleColor.DarkGray;
        public const ConsoleColor DefaultVariableForegroundColor  = ConsoleColor.Green;
        public const ConsoleColor DefaultCommandForegroundColor   = ConsoleColor.Yellow;
        public const ConsoleColor DefaultParameterForegroundColor = ConsoleColor.DarkGray;
        public const ConsoleColor DefaultTypeForegroundColor      = ConsoleColor.Gray;
        public const ConsoleColor DefaultNumberForegroundColor    = ConsoleColor.White;
        public const ConsoleColor DefaultMemberForegroundColor    = ConsoleColor.Gray;

        public const string DefaultContinuationPrompt = ">>> ";

        /// <summary>
        /// The maximum number of commands to store in the history.
        /// </summary>
        public const int DefaultMaximumHistoryCount = 1024;

        /// <summary>
        /// The maximum number of items to store in the kill ring.
        /// </summary>
        public const int DefaultMaximumKillRingCount = 10;

        /// <summary>
        /// In Emacs, when searching history, the cursor doesn't move.
        /// In 4NT, the cursor moves to the end.  This option allows
        /// for either behavior.
        /// </summary>
        public const bool DefaultHistorySearchCursorMovesToEnd = false;

        /// <summary>
        /// When displaying possible completions, either display
        /// tooltips or dipslay just the completions.
        /// </summary>
        public const bool DefaultShowToolTips = false;

        /// <summary>
        /// When ringing the bell, what frequency do we use?
        /// </summary>
        public const int DefaultDingTone = 1221;

        public const int DefaultDingDuration = 50;

        /// <summary>
        /// When ringing the bell, what should be done?
        /// </summary>
        public const BellStyle DefaultBellStyle = BellStyle.Audible;

        public PSConsoleReadlineOptions()
        {
            ResetColors();
            ContinuationPrompt = DefaultContinuationPrompt;
            ContinuationPromptBackgroundColor = Console.BackgroundColor;
            ContinuationPromptForegroundColor = Console.ForegroundColor;
            ExtraPromptLineCount = DefaultExtraPromptLineCount;
            AddToHistoryHandler = null;
            HistoryNoDuplicates = DefaultHistoryNoDuplicates;
            MaximumHistoryCount = DefaultMaximumHistoryCount;
            MaximumKillRingCount = DefaultMaximumKillRingCount;
            HistorySearchCursorMovesToEnd = DefaultHistorySearchCursorMovesToEnd;
            ShowToolTips = DefaultShowToolTips;
            DingDuration = DefaultDingDuration;
            DingTone = DefaultDingTone;
            BellStyle = DefaultBellStyle;
        }

        public string ContinuationPrompt { get; set; }
        public ConsoleColor ContinuationPromptForegroundColor { get; set; }
        public ConsoleColor ContinuationPromptBackgroundColor { get; set; }

        /// <summary>
        /// Prompts are typically 1 line, but sometimes they may span lines.  This
        /// count is used to make sure we can display the full prompt after showing
        /// ambiguous completions
        /// </summary>
        public int ExtraPromptLineCount { get; set; }
        public const int DefaultExtraPromptLineCount = 0;

        /// <summary>
        /// 
        /// </summary>
        public Func<string, bool> AddToHistoryHandler { get; set; }

        /// <summary>
        /// When true, duplicates will not be added to the history.
        /// </summary>
        public bool HistoryNoDuplicates { get; set; }
        public const bool DefaultHistoryNoDuplicates = false;

        public int MaximumHistoryCount { get; set; }
        public int MaximumKillRingCount { get; set; }
        public bool HistorySearchCursorMovesToEnd { get; set; }
        public bool ShowToolTips { get; set; }
        public int DingTone { get; set; }

        /// <summary>
        /// When ringing the bell, how long (in ms)?
        /// </summary>
        public int DingDuration { get; set; }
        public BellStyle BellStyle { get; set; }

        public ConsoleColor DefaultTokenForegroundColor { get; set; }
        public ConsoleColor CommentForegroundColor { get; set; }
        public ConsoleColor KeywordForegroundColor { get; set; }
        public ConsoleColor StringForegroundColor { get; set; }
        public ConsoleColor OperatorForegroundColor { get; set; }
        public ConsoleColor VariableForegroundColor { get; set; }
        public ConsoleColor CommandForegroundColor { get; set; }
        public ConsoleColor ParameterForegroundColor { get; set; }
        public ConsoleColor TypeForegroundColor { get; set; }
        public ConsoleColor NumberForegroundColor { get; set; }
        public ConsoleColor MemberForegroundColor { get; set; }
        public ConsoleColor DefaultTokenBackgroundColor { get; set; }
        public ConsoleColor CommentBackgroundColor { get; set; }
        public ConsoleColor KeywordBackgroundColor { get; set; }
        public ConsoleColor StringBackgroundColor { get; set; }
        public ConsoleColor OperatorBackgroundColor { get; set; }
        public ConsoleColor VariableBackgroundColor { get; set; }
        public ConsoleColor CommandBackgroundColor { get; set; }
        public ConsoleColor ParameterBackgroundColor { get; set; }
        public ConsoleColor TypeBackgroundColor { get; set; }
        public ConsoleColor NumberBackgroundColor { get; set; }
        public ConsoleColor MemberBackgroundColor { get; set; }

        internal void ResetColors()
        {
            DefaultTokenForegroundColor = Console.ForegroundColor;
            CommentForegroundColor      = DefaultCommentForegroundColor;
            KeywordForegroundColor      = DefaultKeywordForegroundColor;
            StringForegroundColor       = DefaultStringForegroundColor;
            OperatorForegroundColor     = DefaultOperatorForegroundColor;
            VariableForegroundColor     = DefaultVariableForegroundColor;
            CommandForegroundColor      = DefaultCommandForegroundColor;
            ParameterForegroundColor    = DefaultParameterForegroundColor;
            TypeForegroundColor         = DefaultTypeForegroundColor;
            NumberForegroundColor       = DefaultNumberForegroundColor;
            MemberForegroundColor       = DefaultNumberForegroundColor;
            DefaultTokenBackgroundColor = Console.BackgroundColor;
            CommentBackgroundColor      = Console.BackgroundColor;
            KeywordBackgroundColor      = Console.BackgroundColor;
            StringBackgroundColor       = Console.BackgroundColor;
            OperatorBackgroundColor     = Console.BackgroundColor;
            VariableBackgroundColor     = Console.BackgroundColor;
            CommandBackgroundColor      = Console.BackgroundColor;
            ParameterBackgroundColor    = Console.BackgroundColor;
            TypeBackgroundColor         = Console.BackgroundColor;
            NumberBackgroundColor       = Console.BackgroundColor;
            MemberBackgroundColor       = Console.BackgroundColor;
        }

        internal void SetForegroundColor(TokenClassification tokenKind, ConsoleColor color)
        {
            switch (tokenKind)
            {
            case TokenClassification.None:      DefaultTokenForegroundColor = color; break;
            case TokenClassification.Comment:   CommentForegroundColor = color; break;
            case TokenClassification.Keyword:   KeywordForegroundColor = color; break;
            case TokenClassification.String:    StringForegroundColor = color; break;
            case TokenClassification.Operator:  OperatorForegroundColor = color; break;
            case TokenClassification.Variable:  VariableForegroundColor = color; break;
            case TokenClassification.Command:   CommandForegroundColor = color; break;
            case TokenClassification.Parameter: ParameterForegroundColor = color; break;
            case TokenClassification.Type:      TypeForegroundColor = color; break;
            case TokenClassification.Number:    NumberForegroundColor = color; break;
            case TokenClassification.Member:    MemberForegroundColor = color; break;
            }
        }

        internal void SetBackgroundColor(TokenClassification tokenKind, ConsoleColor color)
        {
            switch (tokenKind)
            {
            case TokenClassification.None:      DefaultTokenBackgroundColor = color; break;
            case TokenClassification.Comment:   CommentBackgroundColor = color; break;
            case TokenClassification.Keyword:   KeywordBackgroundColor = color; break;
            case TokenClassification.String:    StringBackgroundColor = color; break;
            case TokenClassification.Operator:  OperatorBackgroundColor = color; break;
            case TokenClassification.Variable:  VariableBackgroundColor = color; break;
            case TokenClassification.Command:   CommandBackgroundColor = color; break;
            case TokenClassification.Parameter: ParameterBackgroundColor = color; break;
            case TokenClassification.Type:      TypeBackgroundColor = color; break;
            case TokenClassification.Number:    NumberBackgroundColor = color; break;
            case TokenClassification.Member:    MemberBackgroundColor = color; break;
            }
        }
    }

    [Cmdlet("Get", "PSReadlineOption")]
    [OutputType(typeof(PSConsoleReadlineOptions))]
    public class GetPSReadlineOption : PSCmdlet
    {
        [ExcludeFromCodeCoverage]
        protected override void EndProcessing()
        {
            WriteObject(PSConsoleReadLine.GetOptions());
        }
    }

    [Cmdlet("Set", "PSReadlineOption")]
    public class SetPSReadlineOption : PSCmdlet
    {
        [Parameter(ParameterSetName = "OptionsSet")]
        public EditMode EditMode
        {
            get { return _editMode.GetValueOrDefault(); }
            set { _editMode = value; }
        }
        internal EditMode? _editMode;

        [Parameter(ParameterSetName = "OptionsSet")]
        [AllowEmptyString]
        public string ContinuationPrompt { get; set; }

        [Parameter(ParameterSetName = "OptionsSet")]
        public ConsoleColor ContinuationPromptForegroundColor
        {
            get { return _continuationPromptForegroundColor.GetValueOrDefault(); }
            set { _continuationPromptForegroundColor = value; }
        }
        internal ConsoleColor? _continuationPromptForegroundColor;

        [Parameter(ParameterSetName = "OptionsSet")]
        public ConsoleColor ContinuationPromptBackgroundColor
        {
            get { return _continuationPromptBackgroundColor.GetValueOrDefault(); }
            set { _continuationPromptBackgroundColor = value; }
        }
        internal ConsoleColor? _continuationPromptBackgroundColor;

        [Parameter(ParameterSetName = "OptionsSet")]
        public SwitchParameter HistoryNoDuplicates
        {
            get { return _historyNoDuplicates.GetValueOrDefault(); }
            set { _historyNoDuplicates = value; }
        }
        internal SwitchParameter? _historyNoDuplicates;

        [Parameter(ParameterSetName = "OptionsSet")]
        [AllowNull]
        public Func<string, bool> AddToHistoryHandler
        {
            get { return _addToHistoryHandler; }
            set
            {
                _addToHistoryHandler = value;
                _addToHistoryHandlerSpecified = true;
            }
        }
        private Func<string, bool> _addToHistoryHandler;
        internal bool _addToHistoryHandlerSpecified;

        [Parameter(ParameterSetName = "OptionsSet")]
        public SwitchParameter HistorySearchCursorMovesToEnd
        {
            get { return _historySearchCursorMovesToEnd.GetValueOrDefault(); }
            set { _historySearchCursorMovesToEnd = value; }
        }
        internal SwitchParameter? _historySearchCursorMovesToEnd;

        [Parameter(ParameterSetName = "OptionsSet")]
        public int MaximumHistoryCount
        {
            get { return _maximumHistoryCount.GetValueOrDefault(); }
            set { _maximumHistoryCount = value; }
        }
        internal int? _maximumHistoryCount;

        [Parameter(ParameterSetName = "OptionsSet")]
        public int MaximumKillRingCount
        {
            get { return _maximumKillRingCount.GetValueOrDefault(); }
            set { _maximumKillRingCount = value; }
        }
        internal int? _maximumKillRingCount;

        [Parameter(ParameterSetName = "OptionsSet")]
        public SwitchParameter ResetTokenColors
        {
            get { return _resetTokenColors.GetValueOrDefault(); }
            set { _resetTokenColors = value; }
        }
        internal SwitchParameter? _resetTokenColors;

        [Parameter(ParameterSetName = "OptionsSet")]
        public SwitchParameter ShowToolTips
        {
            get { return _showToolTips.GetValueOrDefault(); }
            set { _showToolTips = value; }
        }
        internal SwitchParameter? _showToolTips;

        [Parameter(ParameterSetName = "OptionsSet")]
        public int ExtraPromptLineCount
        {
            get { return _extraPromptLineCount.GetValueOrDefault(); }
            set { _extraPromptLineCount = value; }
        }
        internal int? _extraPromptLineCount;

        [Parameter(ParameterSetName = "OptionsSet")]
        public int DingTone
        {
            get { return _dingTone.GetValueOrDefault(); }
            set { _dingTone = value; }
        }
        internal int? _dingTone;

        [Parameter(ParameterSetName = "OptionsSet")]
        public int DingDuration
        {
            get { return _dingDuration.GetValueOrDefault(); }
            set { _dingDuration = value; }
        }
        internal int? _dingDuration;

        [Parameter(ParameterSetName = "OptionsSet")]
        public BellStyle BellStyle
        {
            get { return _bellStyle.GetValueOrDefault(); }
            set { _bellStyle = value; }
        }
        internal BellStyle? _bellStyle;

        [Parameter(ParameterSetName = "ColorSet", Position = 0, Mandatory = true)]
        public TokenClassification TokenKind
        {
            get { return _tokenKind.GetValueOrDefault(); }
            set { _tokenKind = value; }
        }
        internal TokenClassification? _tokenKind;

        [Parameter(ParameterSetName = "ColorSet", Position = 1)]
        public ConsoleColor ForegroundColor
        {
            get { return _foregroundColor.GetValueOrDefault(); }
            set { _foregroundColor = value; }
        }
        internal ConsoleColor? _foregroundColor;

        [Parameter(ParameterSetName = "ColorSet", Position = 2)]
        public ConsoleColor BackgroundColor
        {
            get { return _backgroundColor.GetValueOrDefault(); }
            set { _backgroundColor = value; }
        }
        internal ConsoleColor? _backgroundColor;

        [ExcludeFromCodeCoverage]
        protected override void EndProcessing()
        {
            PSConsoleReadLine.SetOptions(this);
        }
    }

    [Cmdlet("Set", "PSReadlineKeyHandler")]
    public class SetKeyHandlerCommand : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        [Alias("Key")]
        [ValidateNotNullOrEmpty]
        public string[] Chord { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = "ScriptBlock")]
        [ValidateNotNull]
        public ScriptBlock ScriptBlock { get; set; }

        [Parameter(ParameterSetName = "ScriptBlock")]
        public string BriefDescription { get; set; }

        [Parameter(ParameterSetName = "ScriptBlock")]
        public string LongDescription { get; set; }

        // ValidateSet attribute is generated by the script GenerateBuiltinList
        [ValidateSet("AcceptLine", "AddLine", "BackwardChar", "BackwardDeleteChar",
                     "BackwardDeleteLine", "BackwardKillLine", "BackwardWord", "BeginningOfHistory", "BeginningOfLine",
                     "CancelLine", "Complete", "DeleteChar", "DisableDemoMode", "EmacsBackwardWord",
                     "EmacsForwardWord", "EnableDemoMode", "EndOfHistory", "EndOfLine", "ExchangePointAndMark",
                     "ForwardChar", "ForwardDeleteLine", "ForwardWord", "HistorySearchBackward", "HistorySearchForward",
                     "KillBackwardWord", "KillLine", "KillWord", "NextHistory", "Paste",
                     "PossibleCompletions", "PreviousHistory", "Redo", "RevertLine", "SetKeyHandler",
                     "SetMark", "TabCompleteNext", "TabCompletePrevious", "Undo", "Yank",
                     "YankPop")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = "Function")]
        public string Function { get; set; }

        [ExcludeFromCodeCoverage]
        protected override void EndProcessing()
        {
            Action<ConsoleKeyInfo?, object> keyHandler;
            if (ParameterSetName.Equals("Function"))
            {
                keyHandler = (Action<ConsoleKeyInfo?, object>)
                    Delegate.CreateDelegate(typeof (Action<ConsoleKeyInfo?, object>),
                                            typeof (PSConsoleReadLine).GetMethod(Function));
                BriefDescription = Function;
            }
            else
            {
                keyHandler = (key, arg) => ScriptBlock.Invoke(key, arg);
            }
            PSConsoleReadLine.SetKeyHandler(Chord, keyHandler, BriefDescription, LongDescription);
        }
    }

    [Cmdlet("Get", "PSReadlineKeyHandler")]
    public class GetKeyHandlerCommand : PSCmdlet
    {
        [ExcludeFromCodeCoverage]
        protected override void EndProcessing()
        {
            WriteObject(PSConsoleReadLine.GetKeyHandlers(), true);
        }
    }
}
