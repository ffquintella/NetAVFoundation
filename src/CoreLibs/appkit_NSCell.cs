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
using CoreData;
//using Intents;
//using SharedWithYouCore;
//using Symbols;
#if !__MACCATALYST__
using OpenGL;
#endif
using CoreVideo;
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
	[NoMacCatalyst]
	//[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	public class NSCell : NSObject {  //NSUserInterfaceItemIdentification, NSCoding, NSCopying, NSAccessibilityElementProtocol, NSAccessibility, NSObjectAccessibilityExtensions
		[Static, Export ("prefersTrackingUntilMouseUp")]
		public static extern bool PrefersTrackingUntilMouseUp { get; }

		[DesignatedInitializer]
		[Export ("initTextCell:")]
		public  extern NativeHandle Constructor (string aString);

		[DesignatedInitializer]
		[Export ("initImageCell:")]
		public  extern NativeHandle Constructor (NSImage image);

		[Export ("controlView")]
		public  extern NSView ControlView { get; set; }

		[Export ("type")]
		public  extern NSCellType CellType { get; set; }

		[Export ("state")]
		public  extern NSCellStateValue State { get; set; }

		[Export ("target", ArgumentSemantic.Weak), NullAllowed]
		public  extern NSObject Target { get; set; }

		[Export ("action"), NullAllowed]
		public  extern Selector Action { get; set; }

		[Export ("tag")]
		public  extern nint Tag { get; set; }

		[Export ("title")]
		public extern string Title { get; set; }

		[Export ("isOpaque")]
		public extern bool IsOpaque { get; }

		[Export ("enabled")]
		public extern bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("sendActionOn:")]
		public extern nint SendActionOn (NSEventType mask);

		[Export ("continuous")]
		public extern bool IsContinuous { [Bind ("isContinuous")] get; set; }

		[Export ("editable")]
		public extern bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("selectable")]
		public extern bool Selectable { [Bind ("isSelectable")] get; set; }

		[Export ("bordered")]
		public extern bool Bordered { [Bind ("isBordered")] get; set; }

		[Export ("bezeled")]
		public extern bool Bezeled { [Bind ("isBezeled")] get; set; }

		[Export ("scrollable")]
		public extern bool Scrollable { [Bind ("isScrollable")] get; set; }

		[Export ("highlighted")]
		public extern bool Highlighted { [Bind ("isHighlighted")] get; set; }

		[Export ("alignment")]
		public extern NSTextAlignment Alignment { get; set; }

		[Export ("wraps")]
		public extern bool Wraps { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		public extern NSFont Font { get; set; }

		[Export ("isEntryAcceptable:")]
		public extern bool IsEntryAcceptable (string aString);

		[Export ("keyEquivalent")]
		public extern string KeyEquivalent { get; }

		[Export ("formatter", ArgumentSemantic.Retain), NullAllowed]
		public extern NSFormatter Formatter { get; set; }

		[Export ("objectValue", ArgumentSemantic.Copy), NullAllowed]
		public extern NSObject ObjectValue { get; set; }

		[Export ("hasValidObjectValue")]
		public extern bool HasValidObjectValue { get; }

		[Export ("stringValue")]
		public extern string StringValue { get; set; }

		[Export ("compare:")]
		public extern NSComparisonResult Compare (NSObject otherCell);

		[Export ("intValue")]
		public extern int IntValue { get; set; } /* int, not NSInteger */

		[Export ("floatValue")]
		public extern float FloatValue { get; set; } /* float, not CGFloat */

		[Export ("doubleValue")]
		public extern double DoubleValue { get; set; }

		[Export ("takeIntValueFrom:")]
		public extern void TakeIntValueFrom (NSObject sender);

		[Export ("takeFloatValueFrom:")]
		public extern void TakeFloatValueFrom (NSObject sender);

		[Export ("takeDoubleValueFrom:")]
		public extern void TakeDoubleValueFrom (NSObject sender);

		[Export ("takeStringValueFrom:")]
		public extern void TakeStringValueFrom (NSObject sender);

		[Export ("takeObjectValueFrom:")]
		public extern void TakeObjectValueFrom (NSObject sender);

		[Export ("image", ArgumentSemantic.Retain)]
		public extern NSImage Image { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "'ControlTint' property not honored on 10.14. For custom cells, use 'NSColor.ControlAccentColor'.")]
		[Export ("controlTint")]
		public extern NSControlTint ControlTint { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Implement 'ViewDidChangeEffectiveAppearance' on NSView or observe 'NSApplication.EffectiveAppearance'.")]
		[Notification, Field ("NSControlTintDidChangeNotification")]
		public extern NSString ControlTintChangedNotification { get; }

		[Export ("controlSize")]
		public extern NSControlSize ControlSize { get; set; }

		[Export ("representedObject", ArgumentSemantic.Retain)]
		public extern NSObject RepresentedObject { get; set; }

		[Export ("cellAttribute:")]
		public extern nint CellAttribute (NSCellAttribute aParameter);

		[Export ("setCellAttribute:to:")]
		public extern void SetCellAttribute (NSCellAttribute aParameter, nint value);

		[Export ("imageRectForBounds:")]
		public extern CGRect ImageRectForBounds (CGRect theRect);

		[Export ("titleRectForBounds:")]
		public extern CGRect TitleRectForBounds (CGRect theRect);

		[Export ("drawingRectForBounds:")]
		public extern CGRect DrawingRectForBounds (CGRect theRect);

		[Export ("cellSize")]
		public extern CGSize CellSize { get; }

		[Export ("cellSizeForBounds:")]
		public extern CGSize CellSizeForBounds (CGRect bounds);

		[Export ("highlightColorWithFrame:inView:")]
		[return: NullAllowed]
		public extern NSColor? HighlightColor (CGRect cellFrame, NSView controlView);

		[Export ("calcDrawInfo:")]
		public extern void CalcDrawInfo (CGRect aRect);

		[Export ("setUpFieldEditorAttributes:")]
		public extern NSText SetUpFieldEditorAttributes (NSText textObj);

		[Export ("drawInteriorWithFrame:inView:")]
		public extern void DrawInteriorWithFrame (CGRect cellFrame, NSView inView);

		[Export ("drawWithFrame:inView:")]
		public extern void DrawWithFrame (CGRect cellFrame, NSView inView);

		[Export ("highlight:withFrame:inView:")]
		public extern void Highlight (bool highlight, CGRect withFrame, NSView inView);

		[Export ("mouseDownFlags")]
		public extern nint MouseDownFlags { get; }

		[Export ("getPeriodicDelay:interval:")]
		public extern void GetPeriodicDelay (ref float /* float, not CGFloat */ delay, ref float /* float, not CGFloat */ interval);

		[Export ("startTrackingAt:inView:")]
		public extern bool StartTracking (CGPoint startPoint, NSView inView);

		[Export ("continueTracking:at:inView:")]
		public extern bool ContinueTracking (CGPoint lastPoint, CGPoint currentPoint, NSView inView);

		[Export ("stopTracking:at:inView:mouseIsUp:")]
		public extern void StopTracking (CGPoint lastPoint, CGPoint stopPoint, NSView inView, bool mouseIsUp);

		[Export ("trackMouse:inRect:ofView:untilMouseUp:")]
		public extern bool TrackMouse (NSEvent theEvent, CGRect cellFrame, NSView controlView, bool untilMouseUp);

		[Export ("editWithFrame:inView:editor:delegate:event:")]
		public extern void EditWithFrame (CGRect aRect, [NullAllowed] NSView inView, [NullAllowed] NSText editor, [NullAllowed] NSObject delegateObject, NSEvent theEvent);

		[Export ("selectWithFrame:inView:editor:delegate:start:length:")]
		public extern void SelectWithFrame (CGRect aRect, [NullAllowed] NSView inView, [NullAllowed] NSText editor, [NullAllowed] NSObject delegateObject, nint selStart, nint selLength);

		[Export ("endEditing:")]
		public extern void EndEditing ([NullAllowed] NSText textObj);

		[Export ("resetCursorRect:inView:")]
		public extern void ResetCursorRect (CGRect cellFrame, NSView inView);

		[Export ("menu", ArgumentSemantic.Retain)]
		[NullAllowed]
		public extern NSMenu? Menu { get; set; }

		[Export ("menuForEvent:inRect:ofView:")]
		public extern NSMenu MenuForEvent (NSEvent theEvent, CGRect cellFrame, NSView view);

		[Static]
		[Export ("defaultMenu")]
		[NullAllowed]
		public static extern NSMenu? DefaultMenu { get; }

		[Export ("setSendsActionOnEndEditing:")]
		public extern void SetSendsActionOnEndEditing (bool flag);

		[Export ("sendsActionOnEndEditing")]
		public extern bool SendsActionOnEndEditing ();

		[Export ("baseWritingDirection")]
		public extern NSWritingDirection BaseWritingDirection { get; set; }

		[Export ("lineBreakMode")]
		public extern NSLineBreakMode LineBreakMode { get; set; }

		[Export ("allowsUndo")]
		public extern bool AllowsUndo { get; set; }

		[Export ("integerValue")]
		public extern nint IntegerValue { get; set; }

		[Export ("takeIntegerValueFrom:")]
		public extern void TakeIntegerValueFrom (NSObject sender);

		[Export ("truncatesLastVisibleLine")]
		public extern bool TruncatesLastVisibleLine { get; set; }

		[Export ("userInterfaceLayoutDirection")]
		public extern NSUserInterfaceLayoutDirection UserInterfaceLayoutDirection { get; set; }

		[Export ("fieldEditorForView:")]
		public extern NSTextView FieldEditorForView (NSView aControlView);

		[Export ("usesSingleLineMode")]
		public extern bool UsesSingleLineMode { get; set; }

		//  NSCell(NSCellAttributedStringMethods)
		[Export ("refusesFirstResponder")]
		public extern bool RefusesFirstResponder ();

		[Export ("acceptsFirstResponder")]
		public extern bool AcceptsFirstResponder ();

		[Export ("showsFirstResponder")]
		public extern bool ShowsFirstResponder { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 8, message: "Mnemonic methods have typically not been used.")]
		[Export ("mnemonicLocation")]
		public extern nint MnemonicLocation { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 8, message: "Mnemonic methods have typically not been used.")]
		[Export ("mnemonic")]
		public extern string Mnemonic { get; }

		[Deprecated (PlatformName.MacOSX, 10, 8, message: "Mnemonic methods have typically not been used.")]
		[Export ("setTitleWithMnemonic:")]
		public extern void SetTitleWithMnemonic (string stringWithAmpersand);

		[Export ("performClick:")]
		public extern void PerformClick (NSObject sender);

		[Export ("focusRingType")]
		public extern NSFocusRingType FocusRingType { get; set; }

		[Static, Export ("defaultFocusRingType")]
		public extern NSFocusRingType DefaultFocusRingType { get; }

		[Export ("wantsNotificationForMarkedText")]
		public extern bool WantsNotificationForMarkedText { get; [NotImplemented] set; }

		// NSCell(NSCellAttributedStringMethods)
		[Export ("attributedStringValue")]
		public extern NSAttributedString AttributedStringValue { get; set; }

		[Export ("allowsEditingTextAttributes")]
		public extern bool AllowsEditingTextAttributes { get; set; }

		[Export ("importsGraphics")]
		public extern bool ImportsGraphics { get; set; }

		// NSCell(NSCellMixedState) {
		[Export ("allowsMixedState")]
		public extern bool AllowsMixedState { get; set; }

		[Export ("nextState")]
		public extern nint NextState { get; }

		[Export ("setNextState")]
		public extern void SetNextState ();

		[Export ("hitTestForEvent:inRect:ofView:")]
		public extern NSCellHit HitTest (NSEvent forEvent, CGRect inRect, NSView ofView);

		// NSCell(NSCellExpansion) 
		[Export ("expansionFrameWithFrame:inView:")]
		public extern CGRect ExpansionFrame (CGRect withFrame, NSView inView);

		[Export ("drawWithExpansionFrame:inView:")]
		public extern void DrawWithExpansionFrame (CGRect cellFrame, NSView inView);

		[Export ("backgroundStyle")]
		public extern NSBackgroundStyle BackgroundStyle { get; set; }

		[Export ("interiorBackgroundStyle")]
		public extern NSBackgroundStyle InteriorBackgroundStyle { get; }

		[Export ("draggingImageComponentsWithFrame:inView:")]
		public extern NSDraggingImageComponent [] GenerateDraggingImageComponents (CGRect frame, NSView view);

		[Export ("drawFocusRingMaskWithFrame:inView:")]
		public extern void DrawFocusRing (CGRect cellFrameMask, NSView inControlView);

		[Export ("focusRingMaskBoundsForFrame:inView:")]
		public extern CGRect GetFocusRingMaskBounds (CGRect cellFrame, NSView controlView);
	}
	
	public interface INSDraggingInfo { }

	public interface INSDraggingDestination { }
}