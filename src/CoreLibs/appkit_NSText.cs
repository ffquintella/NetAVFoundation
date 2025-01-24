#region USING
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreFoundation;
using CoreImage;
using CoreAnimation;
//using CoreData;
using CoreLibs;
//using Intents;
//using SharedWithYouCore;
//using Symbols;
#if !__MACCATALYST__
using OpenGL;
#endif
using CoreVideo;
using UIKit;
//using CloudKit;
using UniformTypeIdentifiers;

#if __MACCATALYST__
//using UIKit;
#else
using UIMenu = Foundation.NSObject;
using UIMenuElement = Foundation.NSObject;
#endif

using CGGlyph = System.UInt16;
#if __MACCATALYST__
using CAOpenGLLayer = Foundation.NSObject;
using CGLContext = Foundation.NSObject;
using CGLPixelFormat = Foundation.NSObject;
//using Color = UIKit.UIColor;
using NSColorList = Foundation.NSObject;
#else
using Color = AppKit.NSColor;
using IUIActivityItemsConfigurationReading = System.Object;
using UIBarButtonItem = Foundation.NSObject;
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

#endregion

namespace AppKit
{
	public interface INSTextDelegate { }
	
	
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	public class NSTextDelegate {
		[Export ("textShouldBeginEditing:"), DelegateName ("NSTextPredicate"), DefaultValue (true)]
		public extern bool TextShouldBeginEditing (NSText textObject);

		[Export ("textShouldEndEditing:"), DelegateName ("NSTextPredicate"), DefaultValue (true)]
		public extern bool TextShouldEndEditing (NSText textObject);

		[Export ("textDidBeginEditing:"), EventArgs ("NSNotification")]
		public extern void TextDidBeginEditing (NSNotification notification);

		[Export ("textDidEndEditing:"), EventArgs ("NSNotification")]
		public extern void TextDidEndEditing (NSNotification notification);

		[Export ("textDidChange:"), EventArgs ("NSNotification")]
		public extern void TextDidChange (NSNotification notification);
	}
	
    [NoMacCatalyst]
	[BaseType (typeof (NSView), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSTextDelegate) })]
	public partial class NSText {
		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		public extern NativeHandle Constructor (CGRect frameRect);

		[Export ("replaceCharactersInRange:withString:")]
		public extern void Replace (NSRange range, string aString);

		[Export ("replaceCharactersInRange:withRTF:")]
		public extern void ReplaceWithRtf (NSRange range, NSData rtfData);

		[Export ("replaceCharactersInRange:withRTFD:")]
		public extern void ReplaceWithRtfd (NSRange range, NSData rtfdData);

		[Export ("RTFFromRange:")]
		public extern NSData RtfFromRange (NSRange range);

		[Export ("RTFDFromRange:")]
		public extern NSData RtfdFromRange (NSRange range);

		[Export ("writeRTFDToFile:atomically:")]
		public extern bool WriteRtfd (string path, bool atomically);

		[Export ("readRTFDFromFile:")]
		public extern bool FromRtfdFile (string path);

		[Export ("isRulerVisible")]
		public extern bool IsRulerVisible { get; }

		[Export ("scrollRangeToVisible:")]
		public extern void ScrollRangeToVisible (NSRange range);

		[Export ("setTextColor:range:")]
		public extern void SetTextColor (NSColor color, NSRange range);

		[Export ("setFont:range:")]
		public extern void SetFont (NSFont font, NSRange range);

		[Export ("sizeToFit")]
		public extern void SizeToFit ();

		[Export ("copy:")]
		public extern void Copy (NSObject sender);

		[Export ("copyFont:")]
		public extern void CopyFont (NSObject sender);

		[Export ("copyRuler:")]
		public extern void CopyRuler (NSObject sender);

		[Export ("cut:")]
		public extern void Cut (NSObject sender);

		[Export ("delete:")]
		public extern void Delete (NSObject sender);

		[Export ("paste:")]
		public extern void Paste (NSObject sender);

		[Export ("pasteFont:")]
		public extern void PasteFont (NSObject sender);

		[Export ("pasteRuler:")]
		public extern void PasteRuler (NSObject sender);

		[Export ("selectAll:")]
		public extern void SelectAll (NSObject sender);

		[Export ("changeFont:")]
		public extern void ChangeFont (NSObject sender);

		[Export ("alignLeft:")]
		public extern void AlignLeft (NSObject sender);

		[Export ("alignRight:")]
		public extern void AlignRight (NSObject sender);

		[Export ("alignCenter:")]
		public extern void AlignCenter (NSObject sender);

		[Export ("subscript:")]
		public extern void Subscript (NSObject sender);

		[Export ("superscript:")]
		public extern void Superscript (NSObject sender);

		[Export ("underline:")]
		public extern void Underline (NSObject sender);

		[Export ("unscript:")]
		public extern void Unscript (NSObject sender);

		[Export ("showGuessPanel:")]
		public extern void ShowGuessPanel (NSObject sender);

		[Export ("checkSpelling:")]
		public extern void CheckSpelling (NSObject sender);

		[Export ("toggleRuler:")]
		public extern void ToggleRuler (NSObject sender);

		//Detected properties
		[Export ("string")]
		public extern string Value { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		public extern INSTextDelegate Delegate { get; set; }

		[Export ("editable")]
		public extern bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("selectable")]
		public extern bool Selectable { [Bind ("isSelectable")] get; set; }

		[Export ("richText")]
		public extern bool RichText { [Bind ("isRichText")] get; set; }

		[Export ("importsGraphics")]
		public extern bool ImportsGraphics { get; set; }

		[Export ("fieldEditor")]
		public extern bool FieldEditor { [Bind ("isFieldEditor")] get; set; }

		[Export ("usesFontPanel")]
		public extern bool UsesFontPanel { get; set; }

		[Export ("drawsBackground")]
		public extern bool DrawsBackground { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		public extern NSColor BackgroundColor { get; set; }

		[Export ("selectedRange")]
		public extern NSRange SelectedRange { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		public extern NSFont Font { get; set; }

		[Export ("textColor", ArgumentSemantic.Copy)]
		public extern NSColor TextColor { get; set; }

		[Export ("alignment")]
		public extern NSTextAlignment Alignment { get; set; }

		[Export ("baseWritingDirection")]
		public extern NSWritingDirection BaseWritingDirection { get; set; }

		[Export ("maxSize")]
		public extern CGSize MaxSize { get; set; }

		[Export ("minSize")]
		public extern CGSize MinSize { get; set; }

		[Export ("horizontallyResizable")]
		public extern bool HorizontallyResizable { [Bind ("isHorizontallyResizable")] get; set; }

		[Export ("verticallyResizable")]
		public extern bool VerticallyResizable { [Bind ("isVerticallyResizable")] get; set; }
	}
    public partial class NSText {
        [Notification, Field ("NSTextDidBeginEditingNotification")]
        public extern NSString DidBeginEditingNotification { get; }

        [Notification (typeof (NSTextDidEndEditingEventArgs))]
        [Field ("NSTextDidEndEditingNotification")]
        public extern NSString DidEndEditingNotification { get; }

        [Notification, Field ("NSTextDidChangeNotification")]
        public extern NSString DidChangeNotification { get; }

        [MacCatalyst (13, 1)]
        [Field ("NSTextMovementUserInfoKey")]
        public extern NSString MovementUserInfoKey { get; }
    }

    public partial class NSTextInputContext {
        [Notification, Field ("NSTextInputContextKeyboardSelectionDidChangeNotification")]
        public extern NSString KeyboardSelectionDidChangeNotification { get; }
    }
    
    public interface INSTextInputClient { }

    [NoMacCatalyst]
    [BaseType (typeof (NSObject))]
    public partial class NSTextInputContext {
	    [Export ("initWithClient:")]
	    [DesignatedInitializer]
	    public extern NativeHandle Constructor (INSTextInputClient client);

	    [Static]
	    [Export ("currentInputContext")]
	    public static extern NSTextInputContext CurrentInputContext { get; }

	    [Export ("client")]
	    public extern INSTextInputClient Client { get; }

	    [Export ("acceptsGlyphInfo")]
	    public extern bool AcceptsGlyphInfo { get; set; }

	    [NullAllowed, Export ("keyboardInputSources")]
	    public extern string []? KeyboardInputSources { get; }

	    [NullAllowed, Export ("selectedKeyboardInputSource")]
	    public extern string? SelectedKeyboardInputSource { get; set; }

	    [NullAllowed, Export ("allowedInputSourceLocales", ArgumentSemantic.Copy)]
	    public extern string []? AllowedInputSourceLocales { get; set; }

	    [Export ("activate")]
	    public extern void Activate ();

	    [Export ("deactivate")]
	    public extern void Deactivate ();

	    [Export ("handleEvent:")]
	    public extern bool HandleEvent (NSEvent theEvent);

	    [Export ("discardMarkedText")]
	    public extern void DiscardMarkedText ();

	    [Export ("invalidateCharacterCoordinates")]
	    public extern void InvalidateCharacterCoordinates ();

	    [Static]
	    [Export ("localizedNameForInputSource:")]
	    public static extern string LocalizedNameForInputSource (string inputSourceIdentifier);

	    //[Mac (14, 0)]
	    [Export ("textInputClientWillStartScrollingOrZooming")]
	    public extern void TextInputClientWillStartScrollingOrZooming ();

	    //[Mac (14, 0)]
	    [Export ("textInputClientDidEndScrollingOrZooming")]
	    public extern void TextInputClientDidEndScrollingOrZooming ();
    }
    
	public partial class NSTextViewDidChangeSelectionEventArgs {
		// FIXME: verify property type "NSValue object containing an NSRange structure"
		[Export ("NSOldSelectedCharacterRange")]
		public extern NSValue OldSelectedCharacterRange { get; }
	}

	public partial class NSTextViewWillChangeNotifyingTextViewEventArgs {
		[Export ("NSOldNotifyingTextView")]
		public extern NSTextView OldView { get; }

		[Export ("NSNewNotifyingTextView")]
		public extern NSTextView NewView { get; }
	}

	partial class NSTextView  {//: NSTextLayoutOrientationProvider {
		[Export ("setLayoutOrientation:")]
		public extern void SetLayoutOrientation (NSTextLayoutOrientation theOrientation);

		[Export ("changeLayoutOrientation:")]
		public extern void ChangeLayoutOrientation (NSObject sender);

		[Export ("usesInspectorBar")]
		public extern bool UsesInspectorBar { get; set; }

		[Export ("usesFindBar")]
		public extern bool UsesFindBar { get; set; }

		[Export ("incrementalSearchingEnabled")]
		public extern bool IsIncrementalSearchingEnabled { [Bind ("isIncrementalSearchingEnabled")] get; set; }

		[Export ("quickLookPreviewableItemsInRanges:")]
		public extern NSArray QuickLookPreviewableItemsInRanges (NSArray ranges);

		[Export ("updateQuickLookPreviewPanel")]
		public extern void UpdateQuickLookPreviewPanel ();

		[Notification (typeof (NSTextViewWillChangeNotifyingTextViewEventArgs))]
		[Field ("NSTextViewWillChangeNotifyingTextViewNotification")]
		public extern NSString WillChangeNotifyingTextViewNotification { get; }

		[Notification (typeof (NSTextViewDidChangeSelectionEventArgs))]
		[Field ("NSTextViewDidChangeSelectionNotification")]
		public extern NSString DidChangeSelectionNotification { get; }

		[Notification, Field ("NSTextViewDidChangeTypingAttributesNotification")]
		public extern NSString DidChangeTypingAttributesNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification, Field ("NSTextViewWillSwitchToNSLayoutManagerNotification")]
		public extern NSString WillSwitchToNSLayoutManagerNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification, Field ("NSTextViewDidSwitchToNSLayoutManagerNotification")]
		public extern NSString DidSwitchToNSLayoutManagerNotification { get; }

		[MacCatalyst (13, 1)]
		[Export ("usesAdaptiveColorMappingForDarkAppearance")]
		public extern bool UsesAdaptiveColorMappingForDarkAppearance { get; set; }
	}
	
	[NoMacCatalyst]
	[ BaseType (typeof (NSTextView))]
	public partial class NSTextView_SharingService: NSTextView {

		[Export ("orderFrontSharingServicePicker:")]
		public extern void OrderFrontSharingServicePicker (NSObject sender);
	}
	
	public interface INSTextViewDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSCell))]
	public class NSTextAttachmentCell { //: NSTextAttachmentCellProtocol {
		[Export ("initImageCell:")]
		public extern NativeHandle Constructor (NSImage image);

		[Export ("initTextCell:")]
		public extern NativeHandle Constructor (string aString);
	}
	
	[NoiOS]
	[NoMacCatalyst]
	[BaseType (typeof (NSTextDelegate))]
	[Model]
	[Protocol]
	public partial class NSTextViewDelegate {
		[Export ("textView:clickedOnLink:atIndex:"), DelegateName ("NSTextViewLink"), DefaultValue (false)]
		public extern bool LinkClicked (NSTextView textView, NSObject link, nuint charIndex);

		[Export ("textView:clickedOnCell:inRect:atIndex:"), EventArgs ("NSTextViewClicked")]
		public extern void CellClicked (NSTextView textView, NSTextAttachmentCell cell, CGRect cellFrame, nuint charIndex);

		[Export ("textView:doubleClickedOnCell:inRect:atIndex:"), EventArgs ("NSTextViewDoubleClick")]
		public extern void CellDoubleClicked (NSTextView textView, NSTextAttachmentCell cell, CGRect cellFrame, nuint charIndex);

		// 
		[Export ("textView:writablePasteboardTypesForCell:atIndex:"), DelegateName ("NSTextViewCellPosition"), DefaultValue (null)]
		public extern string [] GetWritablePasteboardTypes (NSTextView view, NSTextAttachmentCell forCell, nuint charIndex);

		[Export ("textView:writeCell:atIndex:toPasteboard:type:"), DelegateName ("NSTextViewCellPasteboard"), DefaultValue (true)]
		public extern bool WriteCell (NSTextView view, NSTextAttachmentCell cell, nuint charIndex, NSPasteboard pboard, string type);

		[Export ("textView:willChangeSelectionFromCharacterRange:toCharacterRange:"), DelegateName ("NSTextViewSelectionChange"), DefaultValueFromArgument ("newSelectedCharRange")]
		public extern NSRange WillChangeSelection (NSTextView textView, NSRange oldSelectedCharRange, NSRange newSelectedCharRange);

		[Export ("textView:willChangeSelectionFromCharacterRanges:toCharacterRanges:"), DelegateName ("NSTextViewSelectionWillChange"), DefaultValueFromArgument ("newSelectedCharRanges")]
		public extern NSValue [] WillChangeSelectionFromRanges (NSTextView textView, NSValue [] oldSelectedCharRanges, NSValue [] newSelectedCharRanges);

		[Export ("textView:shouldChangeTextInRanges:replacementStrings:"), DelegateName ("NSTextViewSelectionShouldChange"), DefaultValue (true)]
		public extern bool ShouldChangeTextInRanges (NSTextView textView, NSValue [] affectedRanges, string [] replacementStrings);

		[Export ("textView:shouldChangeTypingAttributes:toAttributes:"), DelegateName ("NSTextViewTypeAttribute"), DefaultValueFromArgument ("newTypingAttributes")]
		public extern NSDictionary ShouldChangeTypingAttributes (NSTextView textView, NSDictionary oldTypingAttributes, NSDictionary newTypingAttributes);

		[Export ("textViewDidChangeSelection:"), EventArgs ("NSTextViewNotification")]
		public extern void DidChangeSelection (NSNotification notification);

		[Export ("textViewDidChangeTypingAttributes:"), EventArgs ("NSTextViewNotification")]
		public extern void DidChangeTypingAttributes (NSNotification notification);

		[Export ("textView:willDisplayToolTip:forCharacterAtIndex:"), DelegateName ("NSTextViewTooltip"), DefaultValueFromArgument ("tooltip")]
		[return: NullAllowed]
		public extern string WillDisplayToolTip (NSTextView textView, string tooltip, nuint characterIndex);

		[Export ("textView:completions:forPartialWordRange:indexOfSelectedItem:"), DelegateName ("NSTextViewCompletion"), DefaultValue (null)]
		public extern string [] GetCompletions (NSTextView textView, string [] words, NSRange charRange, ref nint index);

		[Export ("textView:shouldChangeTextInRange:replacementString:"), DelegateName ("NSTextViewChangeText"), DefaultValue (true)]
		public extern bool ShouldChangeTextInRange (NSTextView textView, NSRange affectedCharRange, string replacementString);

		[Export ("textView:doCommandBySelector:"), DelegateName ("NSTextViewSelectorCommand"), DefaultValue (false)]
		public extern bool DoCommandBySelector (NSTextView textView, Selector commandSelector);

		[Export ("textView:shouldSetSpellingState:range:"), DelegateName ("NSTextViewSpellingQuery"), DefaultValue (0)]
		public extern nint ShouldSetSpellingState (NSTextView textView, nint value, NSRange affectedCharRange);

		[Export ("textView:menu:forEvent:atIndex:"), DelegateName ("NSTextViewEventMenu"), DefaultValueFromArgument ("menu")]
		public extern NSMenu MenuForEvent (NSTextView view, NSMenu menu, NSEvent theEvent, nuint charIndex);

		[Export ("textView:willCheckTextInRange:options:types:"), DelegateName ("NSTextViewOnTextCheck"), DefaultValueFromArgument ("options")]
		public extern NSDictionary WillCheckText (NSTextView view, NSRange range, NSDictionary options, NSTextCheckingTypes checkingTypes);

		[Export ("textView:didCheckTextInRange:types:options:results:orthography:wordCount:"), DelegateName ("NSTextViewTextChecked"), DefaultValueFromArgument ("results")]
		public extern NSTextCheckingResult [] DidCheckText (NSTextView view, NSRange range, NSTextCheckingTypes checkingTypes, NSDictionary options, NSTextCheckingResult [] results, NSOrthography orthography, nint wordCount);

#if !NET
		[Export ("textView:draggedCell:inRect:event:"), EventArgs ("NSTextViewDraggedCell")]
		vvoid DraggedCell (NSTextView view, NSTextAttachmentCell cell, CGRect rect, NSEvent theevent);
#else
		[Export ("textView:draggedCell:inRect:event:atIndex:"), EventArgs ("NSTextViewDraggedCell")]
		public extern void DraggedCell (NSTextView view, NSTextAttachmentCell cell, CGRect rect, NSEvent theEvent, nuint charIndex);
#endif

		[Export ("undoManagerForTextView:"), DelegateName ("NSTextViewGetUndoManager"), DefaultValue (null)]
		public extern NSUndoManager GetUndoManager (NSTextView view);

		[Export ("textView:shouldUpdateTouchBarItemIdentifiers:"), DelegateName ("NSTextViewUpdateTouchBarItemIdentifiers"), NoDefaultValue]
		public extern string [] ShouldUpdateTouchBarItemIdentifiers (NSTextView textView, string [] identifiers);

		[Export ("textView:candidatesForSelectedRange:"), DelegateName ("NSTextViewGetCandidates"), NoDefaultValue]
		[return: NullAllowed]
		public extern NSObject [] GetCandidates (NSTextView textView, NSRange selectedRange);

		[Export ("textView:candidates:forSelectedRange:"), DelegateName ("NSTextViewTextCheckingResults"), NoDefaultValue]
		public extern NSTextCheckingResult [] GetTextCheckingCandidates (NSTextView textView, NSTextCheckingResult [] candidates, NSRange selectedRange);

		[Export ("textView:shouldSelectCandidateAtIndex:"), DelegateName ("NSTextViewSelectCandidate"), NoDefaultValue]
		public extern bool ShouldSelectCandidates (NSTextView textView, nuint index);

#if NET
		//[Mac (15, 0)]
		[Export ("textViewWritingToolsWillBegin:"), EventArgs ("NSTextView")]
		public extern void WritingToolsWillBegin (NSTextView textView);

		//[Mac (15, 0)]
		[Export ("textViewWritingToolsDidEnd:"), EventArgs ("NSTextView")]
		public extern void WritingToolsDidEnd (NSTextView textView);

		//[Mac (15, 0)]
		[Export ("textView:writingToolsIgnoredRangesInEnclosingRange:"), DelegateName ("NSTextViewRange"), NoDefaultValue]
		// Can't use BindAs in a protocol [return: BindAs (typeof (NSRange[]))]
		public extern NSValue [] GetWritingToolsIgnoredRangesInEnclosingRange (NSTextView textView, NSRange enclosingRange);
#endif
	}
	
	[NoMacCatalyst]
	[BaseType (typeof (NSText), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSTextViewDelegate) })]
	public partial class NSTextView : NSText
		//NSTextInputClient, NSTextLayoutOrientationProvider, NSDraggingSource, NSAccessibilityNavigableStaticText, NSCandidateListTouchBarItemDelegate, NSTouchBarDelegate, NSMenuItemValidation, NSUserInterfaceValidations, NSTextInput, NSTextContent
#if NET
		//, NSColorChanging // ChangeColor has the wrong param type
#else
		//, NSTextFinderClient
#endif
	{
		[DesignatedInitializer]
		[Export ("initWithFrame:textContainer:")]
		public extern NativeHandle Constructor (CGRect frameRect, NSTextContainer container);

		[Export ("initWithFrame:")]
		public extern NativeHandle Constructor (CGRect frameRect);

		[Export ("replaceTextContainer:")]
		public extern void ReplaceTextContainer (NSTextContainer newContainer);

		[Export ("textContainerOrigin")]
		public extern CGPoint TextContainerOrigin { get; }

		[Export ("invalidateTextContainerOrigin")]
		public extern void InvalidateTextContainerOrigin ();

		[Export ("layoutManager")]
		public extern NSLayoutManager LayoutManager { get; }

		[Export ("textStorage")]
		public extern NSTextStorage TextStorage { get; }

		[NullAllowed]
		[Export ("textLayoutManager", ArgumentSemantic.Weak)]
		public extern NSTextLayoutManager TextLayoutManager { get; }

		[NullAllowed]
		[Export ("textContentStorage", ArgumentSemantic.Weak)]
		public extern NSTextContentStorage TextContentStorage { get; }

		[Export ("setConstrainedFrameSize:")]
		public extern void SetConstrainedFrameSize (CGSize desiredSize);

		[Export ("setAlignment:range:")]
		public extern void SetAlignmentRange (NSTextAlignment alignment, NSRange range);

		[Export ("setBaseWritingDirection:range:")]
		public extern void SetBaseWritingDirection (NSWritingDirection writingDirection, NSRange range);

		[Export ("turnOffKerning:")]
		public extern void TurnOffKerning (NSObject sender);

		[Export ("tightenKerning:")]
		public extern void TightenKerning (NSObject sender);

		[Export ("loosenKerning:")]
		public extern void LoosenKerning (NSObject sender);

		[Export ("useStandardKerning:")]
		public extern void UseStandardKerning (NSObject sender);

		[Export ("turnOffLigatures:")]
		public extern void TurnOffLigatures (NSObject sender);

		[Export ("useStandardLigatures:")]
		public extern void UseStandardLigatures (NSObject sender);

		[Export ("useAllLigatures:")]
		public extern void UseAllLigatures (NSObject sender);

		[Export ("raiseBaseline:")]
		public extern void RaiseBaseline (NSObject sender);

		[Export ("lowerBaseline:")]
		public extern void LowerBaseline (NSObject sender);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use unicode characters via the character palette.")]
		[Export ("toggleTraditionalCharacterShape:")]
		public extern void ToggleTraditionalCharacterShape (NSObject sender);

		[Export ("outline:")]
		public extern void Outline (NSObject sender);

		[Export ("performFindPanelAction:")]
		public extern void PerformFindPanelAction (NSObject sender);

		[Export ("alignJustified:")]
		public extern void AlignJustified (NSObject sender);

#if !NET
		[Export ("changeColor:")]
		void ChangeColor (NSObject sender);
#endif

		[Export ("changeAttributes:")]
		public extern void ChangeAttributes (NSObject sender);

		[Export ("changeDocumentBackgroundColor:")]
		public extern void ChangeDocumentBackgroundColor (NSObject sender);

		[Export ("orderFrontSpacingPanel:")]
		public extern void OrderFrontSpacingPanel (NSObject sender);

		[Export ("orderFrontLinkPanel:")]
		public extern void OrderFrontLinkPanel (NSObject sender);

		[Export ("orderFrontListPanel:")]
		public extern void OrderFrontListPanel (NSObject sender);

		[Export ("orderFrontTablePanel:")]
		public extern void OrderFrontTablePanel (NSObject sender);

		[Export ("rulerView:didMoveMarker:")]
		public extern void RulerViewDidMoveMarker (NSRulerView ruler, NSRulerMarker marker);

		[Export ("rulerView:didRemoveMarker:")]
		public extern void RulerViewDidRemoveMarker (NSRulerView ruler, NSRulerMarker marker);

		[Export ("rulerView:didAddMarker:")]
		public extern void RulerViewDidAddMarker (NSRulerView ruler, NSRulerMarker marker);

		[Export ("rulerView:shouldMoveMarker:")]
		public extern bool RulerViewShouldMoveMarker (NSRulerView ruler, NSRulerMarker marker);

		[Export ("rulerView:shouldAddMarker:")]
		public extern bool RulerViewShouldAddMarker (NSRulerView ruler, NSRulerMarker marker);

		[Export ("rulerView:willMoveMarker:toLocation:")]
		public extern nfloat RulerViewWillMoveMarker (NSRulerView ruler, NSRulerMarker marker, nfloat location);

		[Export ("rulerView:shouldRemoveMarker:")]
		public extern bool RulerViewShouldRemoveMarker (NSRulerView ruler, NSRulerMarker marker);

		[Export ("rulerView:willAddMarker:atLocation:")]
		public extern nfloat RulerViewWillAddMarker (NSRulerView ruler, NSRulerMarker marker, nfloat location);

		[Export ("rulerView:handleMouseDown:")]
		public extern void RulerViewHandleMouseDown (NSRulerView ruler, NSEvent theEvent);

		[Export ("setNeedsDisplayInRect:avoidAdditionalLayout:")]
		public extern void SetNeedsDisplay (CGRect rect, bool avoidAdditionalLayout);

		[Export ("shouldDrawInsertionPoint")]
		public extern bool ShouldDrawInsertionPoint { get; }

		[Export ("drawInsertionPointInRect:color:turnedOn:")]
		public extern void DrawInsertionPoint (CGRect rect, NSColor color, bool turnedOn);

		[Export ("drawViewBackgroundInRect:")]
		public extern void DrawViewBackgroundInRect (CGRect rect);

		[Export ("updateRuler")]
		public extern void UpdateRuler ();

		[Export ("updateFontPanel")]
		public extern void UpdateFontPanel ();

		[Export ("updateDragTypeRegistration")]
		public extern void UpdateDragTypeRegistration ();

		[Export ("selectionRangeForProposedRange:granularity:")]
		public extern NSRange SelectionRange (NSRange proposedCharRange, NSSelectionGranularity granularity);

		[Export ("clickedOnLink:atIndex:")]
		public extern void ClickedOnLink (NSObject link, nuint charIndex);

		[Export ("startSpeaking:")]
		public extern void StartSpeaking (NSObject sender);

		[Export ("stopSpeaking:")]
		public extern void StopSpeaking (NSObject sender);

		[Export ("characterIndexForInsertionAtPoint:")]
		public extern nuint CharacterIndex (CGPoint point);

		//Detected properties
		[Export ("textContainer")]
		public extern NSTextContainer TextContainer { get; set; }

		[Export ("textContainerInset")]
		public extern CGSize TextContainerInset { get; set; }

		//
		// Completion support
		//
		[Export ("complete:")]
		public extern void Complete ([NullAllowed] NSObject sender);

		[Export ("rangeForUserCompletion")]
		public extern NSRange RangeForUserCompletion ();

		[Export ("completionsForPartialWordRange:indexOfSelectedItem:")]
		public extern string [] CompletionsForPartialWord (NSRange charRange, out nint index);

		[Export ("insertCompletion:forPartialWordRange:movement:isFinal:")]
		public extern void InsertCompletion (string completion, NSRange partialWordCharRange, nint movement, bool isFinal);

		// Pasteboard
		[Export ("writablePasteboardTypes")]
		public extern string [] WritablePasteboardTypes ();

		[Export ("writeSelectionToPasteboard:type:")]
		public extern bool WriteSelectionToPasteboard (NSPasteboard pboard, string type);

		[Export ("writeSelectionToPasteboard:types:")]
		public extern bool WriteSelectionToPasteboard (NSPasteboard pboard, string [] types);

		[Export ("readablePasteboardTypes")]
		public extern string [] ReadablePasteboardTypes ();

		[Export ("preferredPasteboardTypeFromArray:restrictedToTypesFromArray:")]
		public extern string GetPreferredPasteboardType (string [] availableTypes, string [] allowedTypes);

		[Export ("readSelectionFromPasteboard:type:")]
		public extern bool ReadSelectionFromPasteboard (NSPasteboard pboard, string type);

		[Export ("readSelectionFromPasteboard:")]
		public extern bool ReadSelectionFromPasteboard (NSPasteboard pboard);

		[Static]
		[Export ("registerForServices")]
		public static extern void RegisterForServices ();

		[Export ("validRequestorForSendType:returnType:")]
		public extern NSObject ValidRequestorForSendType (string sendType, string returnType);

		[Export ("pasteAsPlainText:")]
		public extern void PasteAsPlainText ([NullAllowed] NSObject sender);

		[Export ("pasteAsRichText:")]
		public extern void PasteAsRichText ([NullAllowed] NSObject sender);

		//
		// Dragging support
		//

		// FIXME: Binding
		//[Export ("dragImageForSelectionWithEvent:origin:")]
		//NSImage DragImageForSelection (NSEvent theEvent, NSPointPointer origin);

		[Export ("acceptableDragTypes")]
		public extern string [] AcceptableDragTypes ();

		[Export ("dragOperationForDraggingInfo:type:")]
#if NET
		public extern NSDragOperation DragOperationForDraggingInfo (INSDraggingInfo dragInfo, string type);
#else
		public extern NSDragOperation DragOperationForDraggingInfo (NSDraggingInfo dragInfo, string type);
#endif

		[Export ("cleanUpAfterDragOperation")]
		public extern void CleanUpAfterDragOperation ();

		[Export ("setSelectedRanges:affinity:stillSelecting:")]
		public extern void SetSelectedRanges (NSArray /*NSRange []*/ ranges, NSSelectionAffinity affinity, bool stillSelectingFlag);

		[Export ("setSelectedRange:affinity:stillSelecting:")]
		public extern void SetSelectedRange (NSRange charRange, NSSelectionAffinity affinity, bool stillSelectingFlag);

		[Export ("selectionAffinity")]
		public extern NSSelectionAffinity SelectionAffinity ();

		[Export ("updateInsertionPointStateAndRestartTimer:")]
		public extern void UpdateInsertionPointStateAndRestartTimer (bool restartFlag);

		[Export ("toggleContinuousSpellChecking:")]
		public extern void ToggleContinuousSpellChecking (NSObject sender);

		[Export ("spellCheckerDocumentTag")]
		public extern nint SpellCheckerDocumentTag ();

		[Export ("toggleGrammarChecking:")]
		public extern void ToggleGrammarChecking (NSObject sender);

		[Export ("setSpellingState:range:")]
		public extern void SetSpellingState (nint value, NSRange charRange);

		[Export ("shouldChangeTextInRanges:replacementStrings:")]
		public extern bool ShouldChangeText (NSArray /* NSRange [] */ affectedRanges, string [] replacementStrings);

		[Export ("rangesForUserTextChange")]
		public extern NSArray /* NSRange [] */ RangesForUserTextChange ();

		[Export ("rangesForUserCharacterAttributeChange")]
		public extern NSArray /* NSRange [] */ RangesForUserCharacterAttributeChange ();

		[Export ("rangesForUserParagraphAttributeChange")]
		public extern NSArray /* NSRange [] */ RangesForUserParagraphAttributeChange ();

		//[Export ("shouldChangeTextInRange:replacementString:")]
		//bool ShouldChangeText (NSRange affectedCharRange, string replacementString);

		[Export ("rangeForUserTextChange")]
		public extern NSRange RangeForUserTextChange ();

		[Export ("rangeForUserCharacterAttributeChange")]
		public extern NSRange RangeForUserCharacterAttributeChange ();

		[Export ("rangeForUserParagraphAttributeChange")]
		public extern NSRange RangeForUserParagraphAttributeChange ();

		[Export ("breakUndoCoalescing")]
		public extern void BreakUndoCoalescing ();

		[Export ("isCoalescingUndo")]
		public extern bool IsCoalescingUndo ();

		[Export ("showFindIndicatorForRange:")]
		public extern void ShowFindIndicatorForRange (NSRange charRange);

		[Export ("setSelectedRange:")]
		public extern void SetSelectedRange (NSRange charRange);

		[Export ("selectionGranularity")]
		public extern NSSelectionGranularity SelectionGranularity { get; set; }

		[Export ("selectedTextAttributes")]
		public extern NSDictionary SelectedTextAttributes { get; set; }

		[NullAllowed]
		[Export ("insertionPointColor")]
		public extern NSColor? InsertionPointColor { get; set; }

		[Export ("markedTextAttributes")]
		public extern NSDictionary MarkedTextAttributes { get; set; }

		[Export ("linkTextAttributes")]
		public extern NSDictionary LinkTextAttributes { get; set; }

		[Export ("displaysLinkToolTips")]
		public extern bool DisplaysLinkToolTips { get; set; }

		[Export ("acceptsGlyphInfo")]
		public extern bool AcceptsGlyphInfo { get; set; }

		[Export ("rulerVisible")]
		public extern bool RulerVisible { [Bind ("isRulerVisible")] get; set; }

		[Export ("usesRuler")]
		public extern bool UsesRuler { get; set; }

		[Export ("continuousSpellCheckingEnabled")]
		public extern bool ContinuousSpellCheckingEnabled { [Bind ("isContinuousSpellCheckingEnabled")] get; set; }

		[Export ("grammarCheckingEnabled")]
		public extern bool GrammarCheckingEnabled { [Bind ("isGrammarCheckingEnabled")] get; set; }

		[Export ("typingAttributes")]
		public extern NSDictionary TypingAttributes { get; set; }

		[Export ("usesFindPanel")]
		public extern bool UsesFindPanel { get; set; }

		[Export ("allowsDocumentBackgroundColorChange")]
		public extern bool AllowsDocumentBackgroundColorChange { get; set; }

		[Export ("defaultParagraphStyle")]
		public extern NSParagraphStyle DefaultParagraphStyle { get; set; }

		[Export ("allowsUndo")]
		public extern bool AllowsUndo { get; set; }

		[Export ("allowsImageEditing")]
		public extern bool AllowsImageEditing { get; set; }

		[Wrap ("WeakDelegate")]
		public extern INSTextViewDelegate Delegate { get; set; }

#pragma warning disable 0109 // warning CS0109: The member 'NSTextView.Editable' does not hide an accessible member. The new keyword is not required.
		[Export ("editable")]
		public extern new bool Editable { [Bind ("isEditable")] get; set; }
#pragma warning restore

#pragma warning disable 0109 // warning CS0109: The member 'NSTextView.Selectable' does not hide an accessible member. The new keyword is not required.
		[Export ("selectable")]
		public extern new bool Selectable { [Bind ("isSelectable")] get; set; }
#pragma warning restore

		[Export ("richText")]
		public extern bool RichText { [Bind ("isRichText")] get; set; }

		[Export ("importsGraphics")]
		public extern bool ImportsGraphics { get; set; }

		[Export ("drawsBackground")]
		public extern bool DrawsBackground { get; set; }

		[Export ("backgroundColor")]
		public extern NSColor BackgroundColor { get; set; }

		[Export ("fieldEditor")]
		public extern bool FieldEditor { [Bind ("isFieldEditor")] get; set; }

		[Export ("usesFontPanel")]
		public extern bool UsesFontPanel { get; set; }

		[Export ("allowedInputSourceLocales")]
		public extern string [] AllowedInputSourceLocales { get; set; }

		// FIXME: binding
		//[Export ("shouldChangeTextInRanges:replacementStrings:")]
		//bool ShouldChangeTextInRanges (NSArray affectedRanges, NSArray replacementStrings);

		// FIXME: binding
		//[Export ("rangesForUserTextChange")]
		//NSArray RangesForUserTextChange ();

		// FIXME: binding
		//[Export ("rangesForUserCharacterAttributeChange")]
		//NSArray RangesForUserCharacterAttributeChange ();

		// FIXME: binding
		//[Export ("rangesForUserParagraphAttributeChange")]
		//NSArray RangesForUserParagraphAttributeChange ();

		[Export ("shouldChangeTextInRange:replacementString:")]
		public extern bool ShouldChangeText (NSRange affectedCharRange, string replacementString);

		[Export ("didChangeText")]
		public extern void DidChangeText ();

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		//
		// Smart copy/paset support
		//
		[Export ("smartDeleteRangeForProposedRange:")]
		public extern NSRange SmartDeleteRangeForProposedRange (NSRange proposedCharRange);

		[Export ("toggleSmartInsertDelete:")]
		public extern void ToggleSmartInsertDelete (NSObject sender);

#if !NET
		[Obsolete ("Use 'SmartInsert(string, NSRange, out string, out string)' overload instead.")]
		[Wrap ("throw new NotSupportedException ()", IsVirtual = true)]
		void SmartInsert (string pasteString, NSRange charRangeToReplace, string beforeString, string afterString);
#endif

		[Export ("smartInsertForString:replacingRange:beforeString:afterString:")]
		public extern void SmartInsert (string pasteString, NSRange charRangeToReplace, [NullAllowed] out string beforeString, [NullAllowed] out string afterString);

		[Export ("smartInsertBeforeStringForString:replacingRange:")]
		public extern string SmartInsertBefore (string pasteString, NSRange charRangeToReplace);

		[Export ("smartInsertAfterStringForString:replacingRange:")]
		public extern 	string SmartInsertAfter (string pasteString, NSRange charRangeToReplace);

		[Export ("toggleAutomaticQuoteSubstitution:")]
		public extern void ToggleAutomaticQuoteSubstitution (NSObject sender);

		[Export ("toggleAutomaticLinkDetection:")]
		public extern void ToggleAutomaticLinkDetection (NSObject sender);

		[Export ("toggleAutomaticDataDetection:")]
		public extern void ToggleAutomaticDataDetection (NSObject sender);

		[Export ("toggleAutomaticDashSubstitution:")]
		public extern void ToggleAutomaticDashSubstitution (NSObject sender);

		[Export ("toggleAutomaticTextReplacement:")]
		public extern void ToggleAutomaticTextReplacement (NSObject sender);

		[Export ("toggleAutomaticSpellingCorrection:")]
		public extern void ToggleAutomaticSpellingCorrection (NSObject sender);

		[Export ("checkTextInRange:types:options:")]
		public extern void CheckText (NSRange range, NSTextCheckingTypes checkingTypes, NSDictionary options);

		[Export ("handleTextCheckingResults:forRange:types:options:orthography:wordCount:")]
		public extern void HandleTextChecking (NSTextCheckingResult [] results, NSRange range, NSTextCheckingTypes checkingTypes, NSDictionary options, NSOrthography orthography, nint wordCount);

		[Export ("orderFrontSubstitutionsPanel:")]
		public extern void OrderFrontSubstitutionsPanel (NSObject sender);

		[Export ("checkTextInSelection:")]
		public extern void CheckTextInSelection (NSObject sender);

		[Export ("checkTextInDocument:")]
		public extern void CheckTextInDocument (NSObject sender);

		//Detected properties
		[Export ("smartInsertDeleteEnabled")]
		public extern bool SmartInsertDeleteEnabled { get; set; }

		[Export ("automaticQuoteSubstitutionEnabled")]
		public extern bool AutomaticQuoteSubstitutionEnabled { [Bind ("isAutomaticQuoteSubstitutionEnabled")] get; set; }

		[Export ("automaticLinkDetectionEnabled")]
		public extern bool AutomaticLinkDetectionEnabled { [Bind ("isAutomaticLinkDetectionEnabled")] get; set; }

		[Export ("automaticDataDetectionEnabled")]
		public extern bool AutomaticDataDetectionEnabled { [Bind ("isAutomaticDataDetectionEnabled")] get; set; }

		[Export ("automaticDashSubstitutionEnabled")]
		public extern bool AutomaticDashSubstitutionEnabled { [Bind ("isAutomaticDashSubstitutionEnabled")] get; set; }

		[Export ("automaticTextReplacementEnabled")]
		public extern bool AutomaticTextReplacementEnabled { [Bind ("isAutomaticTextReplacementEnabled")] get; set; }

		[Export ("automaticSpellingCorrectionEnabled")]
		public extern bool AutomaticSpellingCorrectionEnabled { [Bind ("isAutomaticSpellingCorrectionEnabled")] get; set; }

		[Export ("enabledTextCheckingTypes")]
		public extern NSTextCheckingTypes EnabledTextCheckingTypes { get; set; }

		[Export ("usesRolloverButtonForSelection")]
		public extern bool UsesRolloverButtonForSelection { get; set; }

		[Export ("toggleQuickLookPreviewPanel:")]
		public extern void ToggleQuickLookPreviewPanel (NSObject sender);

		[Static]
		[Export ("stronglyReferencesTextStorage")]
		public static extern bool StronglyReferencesTextStorage { get; }

		[Export ("automaticTextCompletionEnabled")]
		public extern bool AutomaticTextCompletionEnabled { [Bind ("isAutomaticTextCompletionEnabled")] get; set; }

		[Export ("toggleAutomaticTextCompletion:")]
		public extern void ToggleAutomaticTextCompletion ([NullAllowed] NSObject sender);

		[Export ("allowsCharacterPickerTouchBarItem")]
		public extern bool AllowsCharacterPickerTouchBarItem { get; set; }

		[Export ("updateTouchBarItemIdentifiers")]
		public extern void UpdateTouchBarItemIdentifiers ();

		[Export ("updateTextTouchBarItems")]
		public extern void UpdateTextTouchBarItems ();

		[Export ("updateCandidates")]
		public extern void UpdateCandidates ();

		[NullAllowed, Export ("candidateListTouchBarItem", ArgumentSemantic.Strong)]
		public extern NSCandidateListTouchBarItem CandidateListTouchBarItem { get; }

		[Export ("performValidatedReplacementInRange:withAttributedString:")]
		public extern bool PerformValidatedReplacement (NSRange range, NSAttributedString attributedString);

		[Static]
		[Export ("scrollableTextView")]
		public extern NSScrollView CreateScrollableTextView ();

		[Static]
		[Export ("fieldEditor")]
		public extern NSTextView CreateFieldEditor ();

		[Static]
		[Export ("scrollableDocumentContentTextView")]
		public extern NSScrollView CreateScrollableDocumentContentTextView ();

		[Static]
		[Export ("scrollablePlainDocumentContentTextView")]
		public extern NSScrollView CreateScrollablePlainDocumentContentTextView ();

		public NSTextContentType ContentType {
			[Wrap ("NSTextContentTypeExtensions.GetValue (GetContentType ()!)")]
			get;
			[Wrap ("SetContentType (value.GetConstant()!)")]
			set;
		}

#if NET
		// This came from the NSTextFinderClient protocol in legacy Xamarin, but NSTextView doesn't really implement that protocol,
		// so when it was removed for .NET, we still need to expose the API from NSTextFinderClient that NSTextView actually has.
		[Export ("selectedRanges", ArgumentSemantic.Copy)]
		public extern NSArray SelectedRanges { get; set;  }
#endif

		[NoiOS]
		//[Mac (13, 0)]
		[Export ("initUsingTextLayoutManager:")]
		public extern NativeHandle Constructor (bool usingTextLayoutManager);

		[NoiOS]
		[Static]
		//[Mac (13, 0)]
		[Export ("textViewUsingTextLayoutManager:")]
		public extern NSTextView Create (bool usingTextLayoutManager);

		//[Mac (14, 0)]
		[Export ("inlinePredictionType", ArgumentSemantic.Assign)]
		public extern NSTextInputTraitType InlinePredictionType { get; set; }

		// Inlined from the NSTextView (NSSharing) category
		//[Mac (15, 0)]
		[Export ("writingToolsActive")]
		public extern bool WritingToolsActive { [Bind ("isWritingToolsActive")] get; }

		// Inlined from the NSTextView (NSSharing) category
		//[Mac (15, 0)]
		[Export ("writingToolsBehavior")]
		public extern NSWritingToolsBehavior WritingToolsBehavior { get; set; }

		// Inlined from the NSTextView (NSSharing) category
		//[Mac (15, 0)]
		[Export ("allowedWritingToolsResultOptions")]
		public extern NSWritingToolsResultOptions AllowedWritingToolsResultOptions { get; set; }

		// Inlined from the NSTextView (NSTextChecking) category
		//[Mac (15, 0)]
		[Export ("mathExpressionCompletionType")]
		public extern NSTextInputTraitType MathExpressionCompletionType { get; set; }

		// Inlined from the NSTextView (NSTextView_TextHighlight) category
		//[Mac (15, 0)]
		[Export ("textHighlightAttributes", ArgumentSemantic.Copy)]
		public extern NSDictionary<NSString, NSObject> TextHighlightAttributes { get; set; }

		//[Mac (15, 0)]
		[Export ("drawTextHighlightBackgroundForTextRange:origin:")]
		public extern void DrawTextHighlightBackground (NSTextRange textRange, CGPoint origin);

		//[Mac (15, 0)]
		[Export ("highlight:")]
		public extern void Highlight ([NullAllowed] NSObject sender);
	}
	
	[Flags]
	[Native]
	//[Mac (15, 0), NoMacCatalyst]
	public enum NSWritingToolsResultOptions : ulong {
		Default = 0,
		PlainText = 1 << 0,
		RichText = 1 << 1,
		List = 1 << 2,
		Table = 1 << 3,
	}
	
	[Native]
	//[Mac (15, 0), NoMacCatalyst]
	public enum NSWritingToolsBehavior : long {
		None = -1,
		Default = 0,
		Complete,
		Limited,
	}
	
	[NoMacCatalyst]
	public enum NSTextContentType {
		[Field ("NSTextContentTypeUsername")]
		Username,

		[Field ("NSTextContentTypePassword")]
		Password,

		[Field ("NSTextContentTypeOneTimeCode")]
		OneTimeCode,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeAddressCity")]
		AddressCity,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeAddressCityAndState")]
		AddressCityAndState,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeAddressState")]
		AddressState,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeBirthdate")]
		Birthdate,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeBirthdateDay")]
		BirthdateDay,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeBirthdateMonth")]
		BirthdateMonth,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeBirthdateYear")]
		BirthdateYear,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCountryName")]
		CountryName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardExpiration")]
		CreditCardExpiration,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardExpirationMonth")]
		CreditCardExpirationMonth,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardExpirationYear")]
		CreditCardExpirationYear,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardFamilyName")]
		CreditCardFamilyName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardGivenName")]
		CreditCardGivenName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardMiddleName")]
		CreditCardMiddleName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardName")]
		CreditCardName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardNumber")]
		CreditCardNumber,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardSecurityCode")]
		CreditCardSecurityCode,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeCreditCardType")]
		CreditCardType,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeDateTime")]
		DateTime,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeEmailAddress")]
		EmailAddress,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeFamilyName")]
		FamilyName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeFlightNumber")]
		FlightNumber,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeFullStreetAddress")]
		FullStreetAddress,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeGivenName")]
		GivenName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeJobTitle")]
		JobTitle,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeLocation")]
		Location,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeMiddleName")]
		MiddleName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeName")]
		Name,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeNamePrefix")]
		NamePrefix,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeNameSuffix")]
		NameSuffix,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeNewPassword")]
		NewPassword,

	//	[Mac (14, 0)]
		[Field ("NSTextContentTypeNickname")]
		Nickname,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeOrganizationName")]
		OrganizationName,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypePostalCode")]
		PostalCode,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeShipmentTrackingNumber")]
		ShipmentTrackingNumber,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeStreetAddressLine1")]
		StreetAddressLine1,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeStreetAddressLine2")]
		AddressLine2,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeSublocality")]
		Sublocality,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeTelephoneNumber")]
		TelephoneNumber,

		//[Mac (14, 0)]
		[Field ("NSTextContentTypeURL")]
		Url,
	}
}