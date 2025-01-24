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
	delegate void NSWindowTrackEventsMatchingCompletionHandler (NSEvent evt, ref bool stop);

	public partial class NSWindow: NSObject {
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("allowsAutomaticWindowTabbing")]
		public static extern bool AllowsAutomaticWindowTabbing { get; set; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("userTabbingPreference")]
		public static extern NSWindowUserTabbingPreference UserTabbingPreference { get; }

		[MacCatalyst (13, 1)]
		[Export ("tabbingMode", ArgumentSemantic.Assign)]
		public static extern NSWindowTabbingMode TabbingMode { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tabbingIdentifier")]
		public extern string TabbingIdentifier { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("selectNextTab:")]
		public extern void SelectNextTab ([NullAllowed] NSObject sender);

		[MacCatalyst (13, 1)]
		[Export ("selectPreviousTab:")]
		public extern void SelectPreviousTab ([NullAllowed] NSObject sender);

		[MacCatalyst (13, 1)]
		[Export ("moveTabToNewWindow:")]
		public extern void MoveTabToNewWindow ([NullAllowed] NSObject sender);

		[MacCatalyst (13, 1)]
		[Export ("mergeAllWindows:")]
		public extern void MergeAllWindows ([NullAllowed] NSObject sender);

		[MacCatalyst (13, 1)]
		[Export ("toggleTabBar:")]
		public extern void ToggleTabBar ([NullAllowed] NSObject sender);

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("tabbedWindows", ArgumentSemantic.Copy)]
		public extern NSWindow [] TabbedWindows { get; }

		[MacCatalyst (13, 1)]
		[Export ("addTabbedWindow:ordered:")]
		public extern void AddTabbedWindow (NSWindow window, NSWindowOrderingMode ordered);

		[MacCatalyst (13, 1)]
		[Export ("windowTitlebarLayoutDirection")]
		public extern  NSUserInterfaceLayoutDirection WindowTitlebarLayoutDirection { get; }

		[MacCatalyst (13, 1)]
		[Export ("toggleTabOverview:")]
		public extern void ToggleTabOverview ([NullAllowed] NSObject sender);

		[MacCatalyst (13, 1)]
		[Export ("tab", ArgumentSemantic.Strong)]
		public extern NSWindowTab Tab { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("tabGroup", ArgumentSemantic.Weak)]
		public extern NSWindowTabGroup TabGroup { get; }

		//[Mac (13, 3), MacCatalyst (16, 4)]
		[Async]
		[Export ("transferWindowSharingToWindow:completionHandler:")]
		public extern void TransferWindowSharing (NSWindow window, Action<NSError> completionHandler);

		//[Mac (13, 3), MacCatalyst (16, 4)]
		[Export ("hasActiveWindowSharingSession")]
		public extern bool HasActiveWindowSharingSession { get; }

		[Async]
		//[Mac (15, 0), NoMacCatalyst]
		[Export ("requestSharingOfWindow:completionHandler:")]
		public extern void RequestSharingOfWindow (NSWindow window, Action<NSError> completionHandler);

		[Async]
		//[Mac (15, 0), NoMacCatalyst]
		[Export ("requestSharingOfWindowUsingPreview:title:completionHandler:")]
		public extern void RequestSharingOfWindow (NSImage previewImage, string title, Action<NSError> completionHandler);
	}
	
	
	[NoMacCatalyst]
	[BaseType (typeof (NSResponder), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSWindowDelegate) })]
	[DisableDefaultCtor]
	public partial class NSWindow {// : NSAnimatablePropertyContainer, NSUserInterfaceItemIdentification, NSAppearanceCustomization, NSAccessibilityElementProtocol, NSAccessibility, NSMenuItemValidation, NSUserInterfaceValidations {
		[Static, Export ("frameRectForContentRect:styleMask:")]
		public static extern CGRect FrameRectFor (CGRect contectRect, NSWindowStyle styleMask);

		[Static]
		[Export ("contentRectForFrameRect:styleMask:")]
		public static extern CGRect ContentRectFor (CGRect forFrameRect, NSWindowStyle styleMask);

		[Static]
		[Export ("minFrameWidthWithTitle:styleMask:")]
		public static extern nfloat MinFrameWidthWithTitle (string aTitle, NSWindowStyle aStyle);

		[Static]
		[Export ("defaultDepthLimit")]
		public static extern NSWindowDepth DefaultDepthLimit { get; }

		[Export ("frameRectForContentRect:")]
		public extern CGRect FrameRectFor (CGRect contentRect);

		[Export ("contentRectForFrameRect:")]
		public extern CGRect ContentRectFor (CGRect frameRect);

		[Export ("init")]
		[PostSnippet ("InitializeReleasedWhenClosed ();", Optimizable = true)]
		public extern NativeHandle Constructor ();

		[DesignatedInitializer]
		[Export ("initWithContentRect:styleMask:backing:defer:")]
		[PostSnippet ("InitializeReleasedWhenClosed ();", Optimizable = true)]
		public extern NativeHandle Constructor (CGRect contentRect, NSWindowStyle aStyle, NSBackingStore bufferingType, bool deferCreation);

		[Export ("initWithContentRect:styleMask:backing:defer:screen:")]
		[PostSnippet ("InitializeReleasedWhenClosed ();", Optimizable = true)]
		public extern NativeHandle Constructor (CGRect contentRect, NSWindowStyle aStyle, NSBackingStore bufferingType, bool deferCreation, NSScreen screen);

#if NET
		[return: NullAllowed]
		[Deprecated (PlatformName.MacOSX, 15, 0, message: "Do not use this method.")]
		[Export ("initWithWindowRef:")]
		[PostSnippet ("InitializeReleasedWhenClosed ();", Optimizable = true)]
		public extern NativeHandle Constructor (IntPtr windowRef);
#endif

		[Export ("title")]
		public extern string Title { get; set; }

		[Export ("representedURL", ArgumentSemantic.Copy)]
		public extern NSUrl RepresentedUrl { get; set; }

		[Export ("representedFilename")]
		public extern string RepresentedFilename { get; set; }

		[Export ("setTitleWithRepresentedFilename:")]
		public extern void SetTitleWithRepresentedFilename (string filename);

		[Export ("setExcludedFromWindowsMenu:")]
		public extern void SetExcludedFromWindowsMenu (bool flag);

		[Export ("isExcludedFromWindowsMenu")]
		public extern bool ExcludedFromWindowsMenu { get; }

		[Export ("contentView", ArgumentSemantic.Retain)]
		[NullAllowed]
		public extern NSView ContentView { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		public extern INSWindowDelegate Delegate { get; set; }

		[Export ("windowNumber")]
		public extern nint WindowNumber { get; }

		[Export ("styleMask")]
		public extern NSWindowStyle StyleMask { get; set; }

		[Export ("fieldEditor:forObject:")]
		public extern NSText FieldEditor (bool createFlag, [NullAllowed] NSObject forObject);

		[Export ("endEditingFor:")]
		public extern void EndEditingFor ([NullAllowed] NSObject anObject);

		[Export ("constrainFrameRect:toScreen:")]
		public extern CGRect ConstrainFrameRect (CGRect frameRect, [NullAllowed] NSScreen screen);

		[Export ("setFrame:display:")]
		public extern void SetFrame (CGRect frameRect, bool display);

		[Export ("setContentSize:")]
		public extern void SetContentSize (CGSize aSize);

		[Export ("setFrameOrigin:")]
		public extern void SetFrameOrigin (CGPoint aPoint);

		[Export ("setFrameTopLeftPoint:")]
		public extern void SetFrameTopLeftPoint (CGPoint aPoint);

		[Export ("cascadeTopLeftFromPoint:")]
		public extern CGPoint CascadeTopLeftFromPoint (CGPoint topLeftPoint);

		[Export ("frame")]
		[ThreadSafe] // Bug 22909 - This can be called from a non-ui thread <= OS X 10.9
		public extern CGRect Frame { get; }

		[Export ("animationResizeTime:")]
		public extern double AnimationResizeTime (CGRect newFrame);

		[Export ("setFrame:display:animate:")]
		public extern void SetFrame (CGRect frameRect, bool display, bool animate);

		[Export ("inLiveResize")]
		public extern bool InLiveResize { get; }

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "This property doesn't do anything.")]
		[Export ("showsResizeIndicator")]
		public extern bool ShowsResizeIndicator { get; set; }

		[Export ("resizeIncrements")]
		public extern CGSize ResizeIncrements { get; set; }

		[Export ("aspectRatio")]
		public extern CGSize AspectRatio { get; set; }

		[Export ("contentResizeIncrements")]
		public extern CGSize ContentResizeIncrements { get; set; }

		[Export ("contentAspectRatio")]
		public extern CGSize ContentAspectRatio { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("useOptimizedDrawing:")]
		public extern void UseOptimizedDrawing (bool flag);

		[Export ("disableFlushWindow")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSAnimationContext.RunAnimation'.")]
		public extern void DisableFlushWindow ();

		[Export ("enableFlushWindow")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSAnimationContext.RunAnimation'.")]
		public extern void EnableFlushWindow ();

		[Export ("isFlushWindowDisabled")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSAnimationContext.RunAnimation'.")]
		public extern bool FlushWindowDisabled { get; }

		[Export ("flushWindow")]
		[Deprecated (PlatformName.MacOSX, 10, 14)]
		public extern void FlushWindow ();

		[Export ("flushWindowIfNeeded")]
		[Deprecated (PlatformName.MacOSX, 10, 14)]
		public extern void FlushWindowIfNeeded ();

		[Export ("viewsNeedDisplay")]
		public extern bool ViewsNeedDisplay { get; set; }

		[Export ("displayIfNeeded")]
		public extern void DisplayIfNeeded ();

		[Export ("display")]
		public extern void Display ();

		[Export ("autodisplay")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSAnimationContext.RunAnimation'.")]
		public extern bool Autodisplay { [Bind ("isAutodisplay")] get; set; }

		[Export ("preservesContentDuringLiveResize")]
		public extern bool PreservesContentDuringLiveResize { get; set; }

		[Export ("update")]
		public extern void Update ();

		[Export ("makeFirstResponder:")]
		 extern bool MakeFirstResponder ([NullAllowed] NSResponder aResponder);

		[Export ("firstResponder")]
		 extern NSResponder FirstResponder { get; }

		[Export ("resizeFlags")]
		public extern nint ResizeFlags { get; }

		// Inherits from NSResponder
		// [Export ("keyDown:")]
		// void KeyDown (NSEvent  theEvent);

		/* NSWindow.Close by default calls [window release]
		 * This will cause a double free in our code since we're not aware of this
		 * and we end up GCing the proxy eventually and sending our own release
		 */
		[Internal, Export ("close")]
		public extern void _Close ();

#if !XAMCORE_5_0
		[Obsolete ("Call 'ReleaseWhenClosed ()' instead.")]
		[Export ("releasedWhenClosed")]
		public extern bool ReleasedWhenClosed { [Bind ("isReleasedWhenClosed")] get; set; }
#endif

		// releasedWhenClosed is a variation of sending a delayed 'autorelease', and since
		// we've bound release/retain/autorelease with a 'Dangerous' prefix, we're adding
		// one for this property as well.
		[Sealed]
		[Export ("releasedWhenClosed")]
		public extern bool DangerousReleasedWhenClosed { [Bind ("isReleasedWhenClosed")] get; set; }

		[Export ("miniaturize:")]
		public extern void Miniaturize ([NullAllowed] NSObject sender);

		[Export ("deminiaturize:")]
		public extern void Deminiaturize ([NullAllowed] NSObject sender);

		[Export ("isZoomed")]
		public extern bool IsZoomed {
			get;
#if !XAMCORE_5_0
			// https://github.com/xamarin/xamarin-macios/issues/14359
			[Obsolete ("Setting 'IsZoomed' will probably behave unexpectedly, since it comes from the NSScripting protocol (and not like the getter, which is defined on the NSWindow type). If this is the expected behavior, call 'SetIsZoomed(bool)' instead.")]
			set;
#endif
		}

		// The setIsZoomed: selector is defined on the NSScripting protocol, and
		// is not directly related to the isZoomed getter defined on the NSWindow
		// type, so use a separate method to express this distinction in managed code.
		// Ref: https://github.com/xamarin/xamarin-macios/issues/14359
#if !XAMCORE_5_0
		[Sealed]
#endif
		[Export ("setIsZoomed:")]
		public extern void SetIsZoomed (bool value);

		[Export ("zoom:")]
		public extern void Zoom ([NullAllowed] NSObject sender);

		[Export ("isMiniaturized")]
		public extern bool IsMiniaturized {
			get;
#if !XAMCORE_5_0
			// https://github.com/xamarin/xamarin-macios/issues/14359
			[Obsolete ("Setting 'IsMiniaturized' will probably behave unexpectedly, since it comes from the NSScripting protocol (and not like the getter, which is defined on the NSWindow type). If this is the expected behavior, call 'SetIsMiniaturized(bool)' instead.")]
			set;
#endif
		}

		// The setIsMiniaturized: selector is defined on the NSScripting protocol, and
		// is not directly related to the isMiniaturized getter defined on the NSWindow
		// type, so use a separate method to express this distinction in managed code.
		// Ref: https://github.com/xamarin/xamarin-macios/issues/14359
#if !XAMCORE_5_0
		[Sealed]
#endif
		[Export ("setIsMiniaturized:")]
		public extern void SetIsMiniaturized (bool value);

		[Export ("tryToPerform:with:")]
		public extern bool TryToPerform (Selector anAction, NSObject anObject);

		[Export ("validRequestorForSendType:returnType:")]
		public extern NSObject ValidRequestorForSendType (string sendType, string returnType);

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		public extern NSColor BackgroundColor { get; set; }

		[Export ("setContentBorderThickness:forEdge:")]
		public extern void SetContentBorderThickness (nfloat thickness, NSRectEdge edge);

		[Export ("contentBorderThicknessForEdge:")]
		public extern nfloat ContentBorderThicknessForEdge (NSRectEdge edge);

		[Export ("setAutorecalculatesContentBorderThickness:forEdge:")]
		public extern void SetAutorecalculatesContentBorderThickness (bool flag, NSRectEdge forEdge);

		[Export ("autorecalculatesContentBorderThicknessForEdge:")]
		public extern bool AutorecalculatesContentBorderThickness (NSRectEdge forEdgeedge);

		[Export ("movable")]
		public extern bool IsMovable { [Bind ("isMovable")] get; set; }

		[Export ("movableByWindowBackground")]
		public extern bool MovableByWindowBackground { [Bind ("isMovableByWindowBackground")] get; set; }

		[Export ("hidesOnDeactivate")]
		public extern bool HidesOnDeactivate { get; set; }

		[Export ("canHide")]
		public extern bool CanHide { get; set; }

		[Export ("center")]
		public extern void Center ();

		[Export ("makeKeyAndOrderFront:")]
		public extern void MakeKeyAndOrderFront ([NullAllowed] NSObject sender);

		[Export ("orderFront:")]
		public extern void OrderFront ([NullAllowed] NSObject sender);

		[Export ("orderBack:")]
		public extern void OrderBack ([NullAllowed] NSObject sender);

		[Export ("orderOut:")]
		public extern void OrderOut ([NullAllowed] NSObject sender);

		[Export ("orderWindow:relativeTo:")]
		public extern void OrderWindow (NSWindowOrderingMode place, nint relativeTo);

		[Export ("orderFrontRegardless")]
		public extern void OrderFrontRegardless ();

		[Export ("miniwindowImage", ArgumentSemantic.Retain)]
		public extern NSImage MiniWindowImage { get; set; }

		[Export ("miniwindowTitle")]
		public extern string MiniWindowTitle { get; set; }

		[Export ("dockTile")]
		 extern NSDockTile DockTile { get; }

		[Export ("documentEdited")]
		public extern bool DocumentEdited { [Bind ("isDocumentEdited")] get; set; }

		[Export ("isVisible")]
		public extern bool IsVisible {
			get;
#if !XAMCORE_5_0
			// https://github.com/xamarin/xamarin-macios/issues/14359
			[Obsolete ("Setting 'IsVisible' will probably behave unexpectedly, since it comes from the NSScripting protocol (and not like the getter, which is defined on the NSWindow type). Typically the correct way to change the visibility of an NSWindow is to use the 'OrderOut' or 'OrderFront' methods. However, if this is the expected behavior, call 'SetIsVisible(bool)' instead. ")]
			set;
#endif
		}

		// The setIsVisible: selector is defined on the NSScripting protocol, and
		// is not directly related to the isVisible getter defined on the NSWindow
		// type, so use a separate method to express this distinction in managed code.
#if !XAMCORE_5_0
		[Sealed]
#endif
		[Export ("setIsVisible:")]
		public extern void SetIsVisible (bool value);

		[Export ("isKeyWindow")]
		public extern bool IsKeyWindow { get; }

		[Export ("isMainWindow")]
		public extern bool IsMainWindow { get; }

		[Export ("canBecomeKeyWindow")]
		public extern bool CanBecomeKeyWindow { get; }

		[Export ("canBecomeMainWindow")]
		public extern bool CanBecomeMainWindow { get; }

		[Export ("makeKeyWindow")]
		public extern void MakeKeyWindow ();

		[Export ("makeMainWindow")]
		public extern void MakeMainWindow ();

		[Export ("becomeKeyWindow")]
		public extern void BecomeKeyWindow ();

		[Export ("resignKeyWindow")]
		public extern void ResignKeyWindow ();

		[Export ("becomeMainWindow")]
		public extern void BecomeMainWindow ();

		[Export ("resignMainWindow")]
		public extern void ResignMainWindow ();

		[Export ("worksWhenModal")]
#if NET
		public extern bool WorksWhenModal { get; }
#else
		public extern bool WorksWhenModal ();
#endif

		[Export ("preventsApplicationTerminationWhenModal")]
		public extern bool PreventsApplicationTerminationWhenModal { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use ConvertRectToScreen instead.")]
		[Export ("convertBaseToScreen:")]
		public extern CGPoint ConvertBaseToScreen (CGPoint aPoint);

		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use ConvertRectFromScreen instead.")]
		[Export ("convertScreenToBase:")]
		public extern CGPoint ConvertScreenToBase (CGPoint aPoint);

		[Export ("performClose:")]
		public extern void PerformClose ([NullAllowed] NSObject sender);

		[Export ("performMiniaturize:")]
		public extern void PerformMiniaturize ([NullAllowed] NSObject sender);

		[Export ("performZoom:")]
		public extern void PerformZoom ([NullAllowed] NSObject sender);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("gState")]
		public extern nint GState ();

		[Deprecated (PlatformName.MacOSX, 10, 14)]
		[Export ("setOneShot:")]
		public extern void SetOneShot (bool flag);

		[Export ("isOneShot")]
		[Deprecated (PlatformName.MacOSX, 10, 14)]
		public extern bool IsOneShot { get; }

		[Export ("dataWithEPSInsideRect:")]
		public extern NSData DataWithEpsInsideRect (CGRect rect);

		[Export ("dataWithPDFInsideRect:")]
		public extern NSData DataWithPdfInsideRect (CGRect rect);

		[Export ("print:")]
		public extern void Print ([NullAllowed] NSObject sender);

		[Export ("disableCursorRects")]
		public extern void DisableCursorRects ();

		[Export ("enableCursorRects")]
		public extern void EnableCursorRects ();

		[Export ("discardCursorRects")]
		public extern void DiscardCursorRects ();

		[Export ("areCursorRectsEnabled")]
		public extern bool AreCursorRectsEnabled { get; }

		[Export ("invalidateCursorRectsForView:")]
		public extern void InvalidateCursorRectsForView (NSView aView);

		[Export ("resetCursorRects")]
		public extern void ResetCursorRects ();

		[Export ("allowsToolTipsWhenApplicationIsInactive")]
		public extern bool AllowsToolTipsWhenApplicationIsInactive { get; set; }

		[Export ("backingType")]
		[Deprecated (PlatformName.MacOSX, 10, 14)]
		public extern NSBackingStore BackingType { get; set; }

		[Export ("level")]
		public extern NSWindowLevel Level { get; set; }

		[Export ("depthLimit")]
		public extern NSWindowDepth DepthLimit { get; set; }

		[Export ("dynamicDepthLimit")]
		public extern bool HasDynamicDepthLimit { [Bind ("hasDynamicDepthLimit")] get; set; }

		[Export ("screen")]
		public extern NSScreen Screen { get; }

		[Export ("deepestScreen")]
		public extern NSScreen DeepestScreen { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("canStoreColor")]
		public extern bool CanStoreColor { get; }

		[Export ("hasShadow")]
		public extern bool HasShadow { get; set; }

		[Export ("invalidateShadow")]
		public extern void InvalidateShadow ();

		[Export ("alphaValue")]
		public extern nfloat AlphaValue { get; set; }

		[Export ("opaque")]
		public extern bool IsOpaque { [Bind ("isOpaque")] get; set; }

		[Export ("sharingType")]
		public extern NSWindowSharingType SharingType { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 14)]
		[Export ("preferredBackingLocation")]
		public extern NSWindowBackingLocation PreferredBackingLocation { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 14)]
		[Export ("backingLocation")]
		public extern NSWindowBackingLocation BackingLocation { get; }

		[Export ("allowsConcurrentViewDrawing")]
		public extern bool AllowsConcurrentViewDrawing { get; set; }

		[Export ("displaysWhenScreenProfileChanges")]
		public extern bool DisplaysWhenScreenProfileChanges { get; set; }

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "This method doesn't do anything.")]
		[Export ("disableScreenUpdatesUntilFlush")]
		public extern void DisableScreenUpdatesUntilFlush ();

		[Export ("canBecomeVisibleWithoutLogin")]
		public extern bool CanBecomeVisibleWithoutLogin { get; set; }

		[Export ("collectionBehavior")]
		public extern NSWindowCollectionBehavior CollectionBehavior { get; set; }

		[Export ("isOnActiveSpace")]
		public extern bool IsOnActiveSpace { get; }

		[Export ("stringWithSavedFrame")]
		public extern string StringWithSavedFrame ();

		[Export ("setFrameFromString:")]
		public extern void SetFrameFrom (string str);

		[Export ("saveFrameUsingName:")]
		public extern void SaveFrameUsingName (string name);

		[Export ("setFrameUsingName:force:")]
		public extern bool SetFrameUsingName (string name, bool force);

		[Export ("setFrameUsingName:")]
		public extern bool SetFrameUsingName (string name);

		[Export ("frameAutosaveName"), Protected]
		public extern string GetFrameAutosaveName ();

		[Export ("setFrameAutosaveName:"), Protected]
		public extern bool SetFrameAutosaveName (string frameName);

		[Static]
		[Export ("removeFrameUsingName:")]
		public extern void RemoveFrameUsingName (string name);

		[Export ("cacheImageInRect:")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "This method shouldn’t be used as it doesn’t work in all drawing situations; instead, a subview should be used that implements the desired drawing behavior.")]
		public extern void CacheImageInRect (CGRect aRect);

		[Export ("restoreCachedImage")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "This method shouldn’t be used as it doesn’t work in all drawing situations; instead, a subview should be used that implements the desired drawing behavior.")]
		public extern void RestoreCachedImage ();

		[Export ("discardCachedImage")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "This method shouldn’t be used as it doesn’t work in all drawing situations; instead, a subview should be used that implements the desired drawing behavior.")]
		public extern void DiscardCachedImage ();

		[Export ("minSize")]
		public extern CGSize MinSize { get; set; }

		[Export ("maxSize")]
		public extern CGSize MaxSize { get; set; }

		[Export ("contentMinSize")]
		public extern CGSize ContentMinSize { get; set; }

		[Export ("contentMaxSize")]
		public extern CGSize ContentMaxSize { get; set; }

		[Export ("nextEventMatchingMask:"), Protected]
		public extern NSEvent NextEventMatchingMask (nuint mask);

		[Export ("nextEventMatchingMask:untilDate:inMode:dequeue:"), Protected]
		public extern NSEvent NextEventMatchingMask (nuint mask, NSDate expiration, string mode, bool deqFlag);

		[Export ("discardEventsMatchingMask:beforeEvent:"), Protected]
		public extern void DiscardEventsMatchingMask (nuint mask, NSEvent beforeLastEvent);

		[Export ("postEvent:atStart:")]
		public extern void PostEvent (NSEvent theEvent, bool atStart);

		[Export ("currentEvent")]
		public extern NSEvent CurrentEvent ();

		[Export ("acceptsMouseMovedEvents")]
		public extern bool AcceptsMouseMovedEvents { get; set; }

		[Export ("ignoresMouseEvents")]
		public extern bool IgnoresMouseEvents { get; set; }

		[Export ("deviceDescription")]
		public extern NSDictionary DeviceDescription { get; }

		[Export ("sendEvent:")]
		public extern void SendEvent (NSEvent theEvent);

		[Export ("mouseLocationOutsideOfEventStream")]
		public extern CGPoint MouseLocationOutsideOfEventStream { get; }

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "This method does not do anything and should not be called.")]
		[Static]
		[Export ("menuChanged:")]
		public extern void MenuChanged (NSMenu menu);

		[Export ("windowController")]
		[NullAllowed]
#if NET
		 extern NSWindowController WindowController { get; set; }
#else
		public extern NSObject WindowController { get; set; }
#endif

		[Export ("isSheet")]
		public extern bool IsSheet { get; }

		[Export ("attachedSheet")]
		public extern NSWindow AttachedSheet { get; }

		[Static]
		[Export ("standardWindowButton:forStyleMask:")]
		static extern NSButton StandardWindowButton (NSWindowButton b, NSWindowStyle styleMask);

		[Export ("standardWindowButton:")]
		 extern NSButton StandardWindowButton (NSWindowButton b);

		[Export ("addChildWindow:ordered:")]
		public extern void AddChildWindow (NSWindow childWin, NSWindowOrderingMode place);

		[Export ("removeChildWindow:")]
		public extern void RemoveChildWindow (NSWindow childWin);

		[Export ("childWindows")]
		public extern NSWindow [] ChildWindows { get; }

		[Export ("parentWindow")]
		public extern NSWindow ParentWindow { get; set; }

		[Export ("graphicsContext")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Add instances of NSView to display content in a window.")]
		 extern NSGraphicsContext GraphicsContext { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("userSpaceScaleFactor")]
		public extern nfloat UserSpaceScaleFactor { get; }

		[Export ("colorSpace", ArgumentSemantic.Retain)]
		public extern NSColorSpace ColorSpace { get; set; }

		[Static]
		[Export ("windowNumbersWithOptions:")]
		static extern NSArray WindowNumbersWithOptions (NSWindowNumberListOptions options);

		[Static]
		[Export ("windowNumberAtPoint:belowWindowWithWindowNumber:")]
		public extern nint WindowNumberAtPoint (CGPoint point, nint windowNumber);

		[Export ("initialFirstResponder")]
		public extern NSView InitialFirstResponder { get; set; }

		[Export ("selectNextKeyView:")]
		public extern void SelectNextKeyView ([NullAllowed] NSObject sender);

		[Export ("selectPreviousKeyView:")]
		public extern void SelectPreviousKeyView ([NullAllowed] NSObject sender);

		[Export ("selectKeyViewFollowingView:")]
		public extern void SelectKeyViewFollowingView (NSView aView);

		[Export ("selectKeyViewPrecedingView:")]
		public extern void SelectKeyViewPrecedingView (NSView aView);

		[Export ("keyViewSelectionDirection")]
		public extern NSSelectionDirection KeyViewSelectionDirection ();

		[Export ("defaultButtonCell")]
		[NullAllowed]
		 extern NSButtonCell DefaultButtonCell { get; set; }

		[Export ("disableKeyEquivalentForDefaultButtonCell")]
		public extern void DisableKeyEquivalentForDefaultButtonCell ();

		[Export ("enableKeyEquivalentForDefaultButtonCell")]
		public extern void EnableKeyEquivalentForDefaultButtonCell ();

		[Export ("autorecalculatesKeyViewLoop")]
		public extern bool AutorecalculatesKeyViewLoop { get; set; }

		[Export ("recalculateKeyViewLoop")]
		public extern void RecalculateKeyViewLoop ();

		[Export ("toolbar")]
		[NullAllowed]
		 extern NSToolbar Toolbar { get; set; }

		[Export ("toggleToolbarShown:")]
		public extern void ToggleToolbarShown (NSObject sender);

		[Export ("runToolbarCustomizationPalette:")]
		public extern void RunToolbarCustomizationPalette (NSObject sender);

		[Deprecated (PlatformName.MacOSX, 14, 0)]
		[Export ("showsToolbarButton")]
		public extern bool ShowsToolbarButton { get; set; }

		[Export ("registerForDraggedTypes:")]
		public extern void RegisterForDraggedTypes (string [] newTypes);

		[Export ("unregisterDraggedTypes")]
		public extern void UnregisterDraggedTypes ();

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "This property should not be used.")]
		[Export ("windowRef")]
		public extern IntPtr WindowRef { get; }

		// This one comes from the NSUserInterfaceRestoration category ('@interface NSWindow (NSUserInterfaceRestoration)')
		[Export ("disableSnapshotRestoration")]
		public extern void DisableSnapshotRestoration ();

		// This one comes from the NSUserInterfaceRestoration category ('@interface NSWindow (NSUserInterfaceRestoration)')
		[Export ("enableSnapshotRestoration")]
		public extern void EnableSnapshotRestoration ();

		// This one comes from the NSUserInterfaceRestoration category ('@interface NSWindow (NSUserInterfaceRestoration)')
		[Export ("restorable")]
		public extern bool Restorable { [Bind ("isRestorable")] get; set; }

		// This one comes from the NSUserInterfaceRestoration category ('@interface NSWindow (NSUserInterfaceRestoration)')
		[Export ("restorationClass")]
		public extern Class RestorationClass { get; set; }

		//Detected properties
		[Export ("updateConstraintsIfNeeded")]
		public extern void UpdateConstraintsIfNeeded ();

		[Export ("layoutIfNeeded")]
		public extern void LayoutIfNeeded ();

		[Export ("setAnchorAttribute:forOrientation:")]
		public extern void SetAnchorAttribute (NSLayoutAttribute layoutAttribute, NSLayoutConstraintOrientation forOrientation);

		[Export ("visualizeConstraints:")]
		public extern void VisualizeConstraints ([NullAllowed] NSLayoutConstraint [] constraints);

		[Export ("convertRectToScreen:")]
		public extern CGRect ConvertRectToScreen (CGRect aRect);

		[Export ("convertRectFromScreen:")]
		public extern CGRect ConvertRectFromScreen (CGRect aRect);

		[Export ("convertRectToBacking:")]
		public extern CGRect ConvertRectToBacking (CGRect aRect);

		[Export ("convertRectFromBacking:")]
		public extern CGRect ConvertRectFromBacking (CGRect aRect);

		[Export ("backingAlignedRect:options:")]
		public extern CGRect BackingAlignedRect (CGRect aRect, NSAlignmentOptions options);

		[Export ("backingScaleFactor")]
		public extern nfloat BackingScaleFactor { get; }

		[Export ("toggleFullScreen:")]
		public extern void ToggleFullScreen ([NullAllowed] NSObject sender);

		//Detected properties
		[Export ("animationBehavior")]
		public extern NSWindowAnimationBehavior AnimationBehavior { get; set; }

		//
		// Fields
		//

		[Field ("NSWindowDidBecomeKeyNotification")]
		[Notification]
		public extern NSString DidBecomeKeyNotification { get; }

		[Field ("NSWindowDidBecomeMainNotification")]
		[Notification]
		public extern NSString DidBecomeMainNotification { get; }

		[Field ("NSWindowDidChangeScreenNotification")]
		[Notification]
		public extern NSString DidChangeScreenNotification { get; }

		[Field ("NSWindowDidDeminiaturizeNotification")]
		[Notification]
		public extern NSString DidDeminiaturizeNotification { get; }

		[Field ("NSWindowDidExposeNotification")]
		[Notification (typeof (NSWindowExposeEventArgs))]
		public extern NSString DidExposeNotification { get; }

		[Field ("NSWindowDidMiniaturizeNotification")]
		[Notification]
		public extern NSString DidMiniaturizeNotification { get; }

		[Field ("NSWindowDidMoveNotification")]
		[Notification]
		public extern NSString DidMoveNotification { get; }

		[Field ("NSWindowDidResignKeyNotification")]
		[Notification]
		public extern NSString DidResignKeyNotification { get; }

		[Field ("NSWindowDidResignMainNotification")]
		[Notification]
		public extern NSString DidResignMainNotification { get; }

		[Field ("NSWindowDidResizeNotification")]
		[Notification]
		public extern NSString DidResizeNotification { get; }

		[Field ("NSWindowDidUpdateNotification")]
		[Notification]
		public extern NSString DidUpdateNotification { get; }

		[Field ("NSWindowWillCloseNotification")]
		[Notification]
		public extern NSString WillCloseNotification { get; }

		[Field ("NSWindowWillMiniaturizeNotification")]
		[Notification]
		public extern NSString WillMiniaturizeNotification { get; }

		[Field ("NSWindowWillMoveNotification")]
		[Notification]
		public extern NSString WillMoveNotification { get; }

		[Field ("NSWindowWillBeginSheetNotification")]
		[Notification]
		public extern NSString WillBeginSheetNotification { get; }

		[Field ("NSWindowDidEndSheetNotification")]
		[Notification]
		public extern NSString DidEndSheetNotification { get; }

		[Field ("NSWindowDidChangeScreenProfileNotification")]
		[Notification]
		public extern NSString DidChangeScreenProfileNotification { get; }

		[Field ("NSWindowWillStartLiveResizeNotification")]
		[Notification]
		public extern NSString WillStartLiveResizeNotification { get; }

		[Field ("NSWindowDidEndLiveResizeNotification")]
		[Notification]
		public extern NSString DidEndLiveResizeNotification { get; }

		[Field ("NSWindowWillEnterFullScreenNotification")]
		[Notification]
		public extern NSString WillEnterFullScreenNotification { get; }

		[Field ("NSWindowDidEnterFullScreenNotification")]
		[Notification]
		public extern NSString DidEnterFullScreenNotification { get; }

		[Field ("NSWindowWillExitFullScreenNotification")]
		[Notification]
		public extern NSString WillExitFullScreenNotification { get; }

		[Field ("NSWindowDidExitFullScreenNotification")]
		[Notification]
		public extern NSString DidExitFullScreenNotification { get; }

		[Field ("NSWindowWillEnterVersionBrowserNotification")]
		[Notification]
		public extern NSString WillEnterVersionBrowserNotification { get; }

		[Field ("NSWindowDidEnterVersionBrowserNotification")]
		[Notification]
		public extern NSString DidEnterVersionBrowserNotification { get; }

		[Field ("NSWindowWillExitVersionBrowserNotification")]
		[Notification]
		public extern NSString WillExitVersionBrowserNotification { get; }

		[Field ("NSWindowDidExitVersionBrowserNotification")]
		[Notification]
		public extern NSString DidExitVersionBrowserNotification { get; }

		[Field ("NSWindowDidChangeBackingPropertiesNotification")]
		[Notification (typeof (NSWindowBackingPropertiesEventArgs))]
		public extern NSString DidChangeBackingPropertiesNotification { get; }

		// 10.10
		[Export ("titleVisibility")]
		public extern NSWindowTitleVisibility TitleVisibility { get; set; }

		[Export ("titlebarAppearsTransparent")]
		public extern bool TitlebarAppearsTransparent { get; set; }

		[Export ("contentLayoutRect")]
		public extern CGRect ContentLayoutRect { get; }

		[Export ("contentLayoutGuide")]
		public extern NSObject ContentLayoutGuide { get; }

		[Export ("titlebarAccessoryViewControllers", ArgumentSemantic.Copy)]
		// Header says this is a r/w property, but it fails at runtime.
		//  -[NSWindow setTitlebarAccessoryViewControllers:]: unrecognized selector sent to instance 0x6180001e0f00
		 extern NSTitlebarAccessoryViewController [] TitlebarAccessoryViewControllers { get; }

		[Export ("addTitlebarAccessoryViewController:")]
		 extern void AddTitlebarAccessoryViewController (NSTitlebarAccessoryViewController childViewController);

		[Export ("insertTitlebarAccessoryViewController:atIndex:")]
		 extern void InsertTitlebarAccessoryViewController (NSTitlebarAccessoryViewController childViewController, nint index);

		[Export ("removeTitlebarAccessoryViewControllerAtIndex:")]
		public extern void RemoveTitlebarAccessoryViewControllerAtIndex (nint index);

		//[Static, Export ("windowWithContentViewController:")]
		// extern NSWindow GetWindowWithContentViewController (NSViewController contentViewController);

		//[Export ("contentViewController", ArgumentSemantic.Strong)]
		//public extern NSViewController ContentViewController { get; set; }

		[Export ("trackEventsMatchingMask:timeout:mode:handler:")]
		 extern void TrackEventsMatching (NSEventMask mask, double timeout, string mode, NSWindowTrackEventsMatchingCompletionHandler trackingHandler);

		[Export ("sheets", ArgumentSemantic.Copy)]
		public extern NSWindow [] Sheets { get; }

		[Export ("sheetParent", ArgumentSemantic.Retain)]
		public extern NSWindow SheetParent { get; }

		[Export ("occlusionState")]
		public extern NSWindowOcclusionState OcclusionState { get; }

		[Export ("beginSheet:completionHandler:")]
		public extern void BeginSheet (NSWindow sheetWindow, Action<nint> completionHandler);

		[Export ("beginCriticalSheet:completionHandler:")]
		public extern void BeginCriticalSheet (NSWindow sheetWindow, Action<nint> completionHandler);

		[Export ("endSheet:")]
		public extern void EndSheet (NSWindow sheetWindow);

		[Export ("endSheet:returnCode:")]
		public extern void EndSheet (NSWindow sheetWindow, NSModalResponse returnCode);
#if !NET
		[Obsolete ("Use the EndSheet(NSWindow,NSModalResponse) overload.")]
		[Wrap ("EndSheet (sheetWindow, (NSModalResponse)(long)returnCode)", IsVirtual = true)]
		public extern void EndSheet (NSWindow sheetWindow, nint returnCode);
#endif

		[Export ("minFullScreenContentSize", ArgumentSemantic.Assign)]
		public extern CGSize MinFullScreenContentSize { get; set; }

		[Export ("maxFullScreenContentSize", ArgumentSemantic.Assign)]
		public extern CGSize MaxFullScreenContentSize { get; set; }

		[Export ("performWindowDragWithEvent:")]
		public extern void PerformWindowDrag (NSEvent theEvent);

		[Export ("canRepresentDisplayGamut:")]
		public extern bool CanRepresentDisplayGamut (NSDisplayGamut displayGamut);

		[Export ("convertPointToScreen:")]
		public extern CGPoint ConvertPointToScreen (CGPoint point);

		[Export ("convertPointFromScreen:")]
		public extern CGPoint ConvertPointFromScreen (CGPoint point);

		[Export ("convertPointToBacking:")]
		public extern CGPoint ConvertPointToBacking (CGPoint point);

		[Export ("convertPointFromBacking:")]
		public extern CGPoint ConvertPointFromBacking (CGPoint point);

		[NullAllowed]
		[Export ("appearanceSource", ArgumentSemantic.Weak)]
		 extern INSAppearanceCustomization AppearanceSource { get; set; }

		[Export ("subtitle")]
		string Subtitle { get; set; }

		[Export ("toolbarStyle", ArgumentSemantic.Assign)]
		public extern NSWindowToolbarStyle ToolbarStyle { get; set; }

		[Export ("titlebarSeparatorStyle", ArgumentSemantic.Assign)]
		public extern NSTitlebarSeparatorStyle TitlebarSeparatorStyle { get; set; }

		//[Mac (14, 0)]
		[Export ("displayLinkWithTarget:selector:")]
		public extern CADisplayLink GetDisplayLink (NSObject target, Selector selector);

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "Use BeginDraggingSession instead.")]
		[Export ("dragImage:at:offset:event:pasteboard:source:slideBack:")]
		public extern void DragImage (NSImage anImage, CGPoint baseLocation, CGSize initialOffset, NSEvent theEvent, NSPasteboard pasteboard, NSObject sourceObject, bool slideFlag);

		//[Mac (15, 0)]
		[Export ("beginDraggingSessionWithItems:event:source:")]
		 extern NSDraggingSession BeginDraggingSession (NSDraggingItem [] items, NSEvent evnt, INSDraggingSource source);

		//[Mac (15, 0)]
		[Export ("cascadingReferenceFrame")]
		public extern CGRect CascadingReferenceFrame { get; }
	}
}