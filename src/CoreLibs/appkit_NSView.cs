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
	
    public partial class NSView {

        [Export ("wantsUpdateLayer")]
        public extern bool WantsUpdateLayer { get; }

        [Export ("updateLayer")]
        public extern void UpdateLayer ();

        [Export ("rectForSmartMagnificationAtPoint:inRect:")]
        public extern CGRect RectForSmartMagnificationAtPoint (CGPoint atPoint, CGRect inRect);
    }

    [NoMacCatalyst]
    [BaseType(typeof(NSResponder))]
    public partial class NSView 
	    //: NSDraggingDestination, NSAnimatablePropertyContainer,
	    //NSUserInterfaceItemIdentification, NSAppearanceCustomization, NSAccessibilityElementProtocol, NSAccessibility,
	    //NSObjectAccessibilityExtensions
    {
	    [DesignatedInitializer]
	    [Export("initWithFrame:")]
	    public extern NativeHandle Constructor(CGRect frameRect);

	    [NullAllowed] [Export("window")] public extern NSWindow Window { get; }

	    [NullAllowed] [Export("superview")] public extern NSView Superview { get; }

	    [Export("isDescendantOf:")]
	    public extern bool IsDescendantOf(NSView aView);

	    [return: NullAllowed]
	    [Export("ancestorSharedWithView:")]
	    public extern NSView AncestorSharedWithView(NSView aView);

	    [NullAllowed]
	    [Export("opaqueAncestor")]
	    public extern NSView OpaqueAncestor { get; }

	    [Export("isHiddenOrHasHiddenAncestor")]
	    public extern bool IsHiddenOrHasHiddenAncestor { get; }

	    //[Export ("getRectsBeingDrawn:count:")]
	    // void GetRectsBeingDrawn

	    [Export("needsToDrawRect:")]
	    public extern bool NeedsToDraw(CGRect aRect);

	    [Export("wantsDefaultClipping")] public extern bool WantsDefaultClipping { get; }

	    [Export("viewDidHide")]
	    public extern void ViewDidHide();

	    [Export("viewDidUnhide")]
	    public extern void ViewDidUnhide();

	    [Export("addSubview:")]
	    public extern void AddSubview(NSView aView);

	    [Export("addSubview:positioned:relativeTo:")]
	    public extern void AddSubview(NSView aView, NSWindowOrderingMode place, [NullAllowed] NSView otherView);

	    [Export("viewWillMoveToWindow:")]
	    public extern void ViewWillMoveToWindow([NullAllowed] NSWindow newWindow);

	    [Export("viewDidMoveToWindow")]
	    public extern void ViewDidMoveToWindow();

	    [Export("viewWillMoveToSuperview:")]
	    public extern void ViewWillMoveToSuperview([NullAllowed] NSView newSuperview);

	    [Export("viewDidMoveToSuperview")]
	    public extern void ViewDidMoveToSuperview();

	    [Export("didAddSubview:")]
	    public extern void DidAddSubview(NSView subview);

	    [Export("willRemoveSubview:")]
	    public extern void WillRemoveSubview(NSView subview);

	    [Export("removeFromSuperview")]
	    public extern void RemoveFromSuperview();

	    [Export("replaceSubview:with:")]
	    public extern void ReplaceSubviewWith(NSView oldView, NSView newView);

	    [Export("removeFromSuperviewWithoutNeedingDisplay")]
	    public extern void RemoveFromSuperviewWithoutNeedingDisplay();

	    [Export("resizeSubviewsWithOldSize:")]
	    public extern void ResizeSubviewsWithOldSize(CGSize oldSize);

	    [Export("resizeWithOldSuperviewSize:")]
	    public extern void ResizeWithOldSuperviewSize(CGSize oldSize);

	    [Export("setFrameOrigin:")]
	    public extern void SetFrameOrigin(CGPoint newOrigin);

	    [Export("setFrameSize:")]
	    public extern void SetFrameSize(CGSize newSize);

	    [Export("setBoundsOrigin:")]
	    public extern void SetBoundsOrigin(CGPoint newOrigin);

	    [Export("setBoundsSize:")]
	    public extern void SetBoundsSize(CGSize newSize);

	    [Export("translateOriginToPoint:")]
	    public extern void TranslateOriginToPoint(CGPoint translation);

	    [Export("scaleUnitSquareToSize:")]
	    public extern void ScaleUnitSquareToSize(CGSize newUnitSize);

	    [Export("rotateByAngle:")]
	    public extern void RotateByAngle(nfloat angle);

	    [Export("isFlipped")] public extern bool IsFlipped { get; }

	    [Export("isRotatedFromBase")] public extern bool IsRotatedFromBase { get; }

	    [Export("isRotatedOrScaledFromBase")] public extern bool IsRotatedOrScaledFromBase { get; }

	    [Export("isOpaque")] public extern bool IsOpaque { get; }

	    [Export("convertPoint:fromView:")]
	    public extern CGPoint ConvertPointFromView(CGPoint aPoint, [NullAllowed] NSView aView);

	    [Export("convertPoint:toView:")]
	    public extern CGPoint ConvertPointToView(CGPoint aPoint, [NullAllowed] NSView aView);

	    [Export("convertSize:fromView:")]
	    public extern CGSize ConvertSizeFromView(CGSize aSize, [NullAllowed] NSView aView);

	    [Export("convertSize:toView:")]
	    public extern CGSize ConvertSizeToView(CGSize aSize, [NullAllowed] NSView aView);

	    [Export("convertRect:fromView:")]
	    public extern CGRect ConvertRectFromView(CGRect aRect, [NullAllowed] NSView aView);

	    [Export("convertRect:toView:")]
	    public extern CGRect ConvertRectToView(CGRect aRect, [NullAllowed] NSView aView);

	    [Export("centerScanRect:")]
	    public extern CGRect CenterScanRect(CGRect aRect);

	    [Deprecated(PlatformName.MacOSX, 10, 7)]
	    [Export("convertPointToBase:")]
	    public extern CGPoint ConvertPointToBase(CGPoint aPoint);

	    [Deprecated(PlatformName.MacOSX, 10, 7)]
	    [Export("convertPointFromBase:")]
	    public extern CGPoint ConvertPointFromBase(CGPoint aPoint);

	    [Deprecated(PlatformName.MacOSX, 10, 7)]
	    [Export("convertSizeToBase:")]
	    public extern CGSize ConvertSizeToBase(CGSize aSize);

	    [Deprecated(PlatformName.MacOSX, 10, 7)]
	    [Export("convertSizeFromBase:")]
	    public extern CGSize ConvertSizeFromBase(CGSize aSize);

	    [Deprecated(PlatformName.MacOSX, 10, 7)]
	    [Export("convertRectToBase:")]
	    public extern CGRect ConvertRectToBase(CGRect aRect);

	    [Deprecated(PlatformName.MacOSX, 10, 7)]
	    [Export("convertRectFromBase:")]
	    public extern CGRect ConvertRectFromBase(CGRect aRect);

	    [Export("canDraw")]
	    [Deprecated(PlatformName.MacOSX, 10, 14,
		    message: "'DrawRect' or 'UpdateLayer' will be called when it is able to draw.")]
	    public extern bool CanDraw();

	    [Export("setNeedsDisplayInRect:")]
	    public extern void SetNeedsDisplayInRect(CGRect invalidRect);

	    [Export("clipsToBounds")] public extern bool ClipsToBounds { get; set; }

	    [Deprecated(PlatformName.MacOSX, 10, 14, message: "Subclass NSView and implement 'DrawRect'.")]
	    [Export("lockFocus")]
	    public extern void LockFocus();

	    [Deprecated(PlatformName.MacOSX, 10, 14, message: "Subclass NSView and implement 'DrawRect'.")]
	    [Export("unlockFocus")]
	    [ThreadSafe]
	    public extern void UnlockFocus();

	    [Deprecated(PlatformName.MacOSX, 10, 14, message: "Subclass NSView and implement 'DrawRect'.")]
	    [Export("lockFocusIfCanDraw")]
	    [ThreadSafe]
	    public extern bool LockFocusIfCanDraw();

	    [Export("lockFocusIfCanDrawInContext:")]
	    [Deprecated(PlatformName.MacOSX, 10, 13,
		    message:
		    "Use 'NSView.DisplayRectIgnoringOpacity (CGRect, NSGraphicsContext)' to draw into a graphics context.")]
	    extern bool LockFocusIfCanDrawInContext(NSGraphicsContext context);

	    [Export("focusView")]
	    [Static]
	    [return: NullAllowed]
	    public static extern NSView? FocusView();

	    [Export("visibleRect")]
	    public extern CGRect VisibleRect();

	    [Export("display")]
	    public extern void Display();

	    [Export("displayIfNeeded")]
	    public extern void DisplayIfNeeded();

	    [Export("displayIfNeededIgnoringOpacity")]
	    public extern void DisplayIfNeededIgnoringOpacity();

	    [Export("displayRect:")]
	    public extern void DisplayRect(CGRect rect);

	    [Export("displayIfNeededInRect:")]
	    public extern void DisplayIfNeededInRect(CGRect rect);

	    [Export("displayRectIgnoringOpacity:")]
	    public extern void DisplayRectIgnoringOpacity(CGRect rect);

	    [Export("displayIfNeededInRectIgnoringOpacity:")]
	    public extern void DisplayIfNeededInRectIgnoringOpacity(CGRect rect);

	    [Export("drawRect:")]
	    [ThreadSafe] // Bug 22909 - This can be called from a non-ui thread <= OS X 10.9
	    public extern void DrawRect(CGRect dirtyRect);

	    [Export("displayRectIgnoringOpacity:inContext:")]
	    extern void DisplayRectIgnoringOpacity(CGRect aRect, NSGraphicsContext context);

	    [return: NullAllowed]
	    [Export("bitmapImageRepForCachingDisplayInRect:")]
	    extern NSBitmapImageRep? BitmapImageRepForCachingDisplayInRect(CGRect rect);

	    [Export("cacheDisplayInRect:toBitmapImageRep:")]
	    extern void CacheDisplay(CGRect rect, NSBitmapImageRep bitmapImageRep);

	    [Export("viewWillDraw")]
	    public extern void ViewWillDraw();

	    [Deprecated(PlatformName.MacOSX, 10, 10)]
	    [Export("gState")]
	    public extern nint GState();

	    [Deprecated(PlatformName.MacOSX, 10, 10)]
	    [Export("allocateGState")]
	    public extern void AllocateGState();

	    [Deprecated(PlatformName.MacOSX, 10, 10)]
	    [Export("releaseGState")]
	    public extern void ReleaseGState();

	    [Deprecated(PlatformName.MacOSX, 10, 10)]
	    [Export("setUpGState")]
	    public extern void SetUpGState();

	    [Deprecated(PlatformName.MacOSX, 10, 10)]
	    [Export("renewGState")]
	    public extern void RenewGState();

	    [Export("scrollPoint:")]
	    public extern void ScrollPoint(CGPoint aPoint);

	    [Export("scrollRectToVisible:")]
	    public extern bool ScrollRectToVisible(CGRect aRect);

	    [Export("autoscroll:")]
	    public extern bool Autoscroll(NSEvent theEvent);

	    [Export("adjustScroll:")]
	    public extern CGRect AdjustScroll(CGRect newVisible);

	    [Export("scrollRect:by:")]
	    [Deprecated(PlatformName.MacOSX, 10, 14, message: "Use NSScrollView to achieve scrolling views.")]
	    public extern void ScrollRect(CGRect aRect, CGSize delta);

	    [Export("translateRectsNeedingDisplayInRect:by:")]
	    public extern void TranslateRectsNeedingDisplay(CGRect clipRect, CGSize delta);

	    [return: NullAllowed]
	    [Export("hitTest:")]
	    public extern NSView HitTest(CGPoint aPoint);

	    [Export("mouse:inRect:")]
	    public extern bool IsMouseInRect(CGPoint aPoint, CGRect aRect);

	    [return: NullAllowed]
	    [Export("viewWithTag:")]
	    public extern NSObject ViewWithTag(nint aTag);

	    [Export("tag")] public extern nint Tag { get; }

	    [Export("performKeyEquivalent:")]
	    public extern bool PerformKeyEquivalent(NSEvent theEvent);

	    [Export("acceptsFirstMouse:")]
	    public extern bool AcceptsFirstMouse([NullAllowed] NSEvent theEvent);

	    [Export("shouldDelayWindowOrderingForEvent:")]
	    public extern bool ShouldDelayWindowOrderingForEvent(NSEvent theEvent);

	    [Export("needsPanelToBecomeKey")] public extern bool NeedsPanelToBecomeKey { get; }

	    [Export("mouseDownCanMoveWindow")] public extern bool MouseDownCanMoveWindow { get; }

	    [Export("addCursorRect:cursor:")]
	    public extern void AddCursorRect(CGRect aRect, NSCursor cursor);

	    [Export("removeCursorRect:cursor:")]
	    public extern void RemoveCursorRect(CGRect aRect, NSCursor cursor);

	    [Export("discardCursorRects")]
	    public extern void DiscardCursorRects();

	    [Export("resetCursorRects")]
	    public extern void ResetCursorRects();

	    [Export("addTrackingRect:owner:userData:assumeInside:")]
	    public extern nint AddTrackingRect(CGRect aRect, NSObject anObject, IntPtr data, bool assumeInside);

	    [Export("removeTrackingRect:")]
	    public extern void RemoveTrackingRect(nint tag);

	    [Export("makeBackingLayer")]
	    extern CALayer MakeBackingLayer();

	    [Export("addTrackingArea:")]
	    extern void AddTrackingArea(NSTrackingArea trackingArea);

	    [Export("removeTrackingArea:")]
	    extern void RemoveTrackingArea(NSTrackingArea trackingArea);

	    [Export("trackingAreas")]
	    extern NSTrackingArea[] TrackingAreas();

	    [Export("updateTrackingAreas")]
	    public extern void UpdateTrackingAreas();

	    [Deprecated(PlatformName.MacOSX, 10, 10)]
	    [Export("shouldDrawColor")]
	    public extern bool ShouldDrawColor { get; }

	    [NullAllowed]
	    [Export("enclosingScrollView")]
	    public extern NSScrollView EnclosingScrollView { get; }

	    [return: NullAllowed]
	    [Export("menuForEvent:")]
	    public extern NSMenu MenuForEvent(NSEvent theEvent);

	    [return: NullAllowed]
	    [Static]
	    [Export("defaultMenu")]
	    public extern NSMenu DefaultMenu();

	    [Export("addToolTipRect:owner:userData:")]
#if !NET
	    public extern nint AddToolTip (CGRect rect, NSObject owner, IntPtr userData);
#else
	   extern nint AddToolTip(CGRect rect, INSToolTipOwner owner, IntPtr userData);
#endif

#if NET
	    [Sealed]
	    [Export("addToolTipRect:owner:userData:")]
	    public extern nint AddToolTip(CGRect rect, NSObject owner, IntPtr userData);
#endif

#if NET
	    [Wrap("AddToolTip (rect, owner, IntPtr.Zero)")]
#else
	    [Wrap ("AddToolTip (rect, (NSObject)owner, IntPtr.Zero)")]
#endif
	   extern nint AddToolTip(CGRect rect, INSToolTipOwner owner);

	    [Wrap("AddToolTip (rect, owner, IntPtr.Zero)")]
	    public extern nint AddToolTip(CGRect rect, NSObject owner);

	    [Export("removeToolTip:")]
	    public extern void RemoveToolTip(nint tag);

	    [Export("removeAllToolTips")]
	    public extern void RemoveAllToolTips();

	    [Export("viewWillStartLiveResize")]
	    public extern void ViewWillStartLiveResize();

	    [Export("viewDidEndLiveResize")]
	    public extern void ViewDidEndLiveResize();

	    [Export("inLiveResize")] public extern bool InLiveResize { get; }

	    [Export("preservesContentDuringLiveResize")]
	    public extern bool PreservesContentDuringLiveResize { get; }

	    [Export("rectPreservedDuringLiveResize")]
	    public extern CGRect RectPreservedDuringLiveResize { get; }

	    //[Export ("getRectsExposedDuringLiveResize:count:")]
	    // void GetRectsExposedDuringLiveResizecount

	    [NullAllowed] [Export("inputContext")] public extern NSTextInputContext InputContext { get; }

	    //Detected properties
	    [Export("hidden")] public extern bool Hidden { [Bind("isHidden")] get; set; }

	    [Export("subviews", ArgumentSemantic.Copy)]
	    public extern NSView[] Subviews { get; set; }

	    [Export("postsFrameChangedNotifications")]
	    public extern bool PostsFrameChangedNotifications { get; set; }

	    [Export("autoresizesSubviews")] public extern bool AutoresizesSubviews { get; set; }

	    [Export("autoresizingMask")] public extern NSViewResizingMask AutoresizingMask { get; set; }

	    [Export("frame")] public extern CGRect Frame { get; set; }

	    [Export("frameRotation")] public extern nfloat FrameRotation { get; set; }

	    [Export("frameCenterRotation")] public extern nfloat FrameCenterRotation { get; set; }

	    [Export("boundsRotation")] public extern nfloat BoundsRotation { get; set; }

	    [Export("bounds")] public extern CGRect Bounds { get; set; }

	    [Export("canDrawConcurrently")] public extern bool CanDrawConcurrently { get; set; }

	    [Export("needsDisplay")] public extern bool NeedsDisplay { get; set; }

	    [Deprecated(PlatformName.MacOSX, 10, 12, 2)]
	    [Export("acceptsTouchEvents")]
	    public extern bool AcceptsTouchEvents { get; set; }

	    [Export("wantsRestingTouches")] public extern bool WantsRestingTouches { get; set; }

	    [Export("layerContentsRedrawPolicy")]
	    public extern NSViewLayerContentsRedrawPolicy LayerContentsRedrawPolicy { get; set; }

	    [Export("layerContentsPlacement")]
	    public extern NSViewLayerContentsPlacement LayerContentsPlacement { get; set; }

	    [Export("wantsLayer")] public extern bool WantsLayer { get; set; }

	    [Export("layer", ArgumentSemantic.Retain), NullAllowed]
	    extern CALayer Layer { get; set; }

	    [Export("alphaValue")] public extern nfloat AlphaValue { get; set; }

	    [Export("backgroundFilters", ArgumentSemantic.Copy)]
	    public extern CIFilter[] BackgroundFilters { get; set; }

	    [NullAllowed]
	    [Export("compositingFilter", ArgumentSemantic.Retain)]
	    public extern CIFilter CompositingFilter { get; set; }

	    [Export("contentFilters", ArgumentSemantic.Copy)]
	    public extern CIFilter[] ContentFilters { get; set; }

	    [NullAllowed]
	    [Export("shadow", ArgumentSemantic.Copy)]
	    public extern NSShadow Shadow { get; set; }

	    [Export("postsBoundsChangedNotifications")]
	    public extern bool PostsBoundsChangedNotifications { get; set; }

	    [Export("toolTip"), NullAllowed] public extern string ToolTip { get; set; }

	    [Export("registerForDraggedTypes:")]
	    public extern void RegisterForDraggedTypes(string[] newTypes);

	    [Export("unregisterDraggedTypes")]
	    public extern void UnregisterDraggedTypes();

	    [Export("registeredDraggedTypes")]
	    public extern string[] RegisteredDragTypes();

	    [Export("beginDraggingSessionWithItems:event:source:")]
	    extern NSDraggingSession BeginDraggingSession(NSDraggingItem[] items, NSEvent evnt,
		    INSDraggingSource source);

	    [Deprecated(PlatformName.MacOSX, 10, 7, message: "Use BeginDraggingSession instead.")]
	    [Export("dragImage:at:offset:event:pasteboard:source:slideBack:")]
	    public extern void DragImage(NSImage anImage, CGPoint viewLocation, CGSize initialOffset, NSEvent theEvent,
		    NSPasteboard pboard, NSObject sourceObj, bool slideFlag);

	    [Export("dragFile:fromRect:slideBack:event:")]
	    [Deprecated(PlatformName.MacOSX, 10, 13,
		    message: "Use 'BeginDraggingSession (NSDraggingItem [], NSEvent, NSDraggingSource)' instead.")]
	    public extern bool DragFile(string filename, CGRect aRect, bool slideBack, NSEvent theEvent);

	    [Export("dragPromisedFilesOfTypes:fromRect:source:slideBack:event:")]
	    [Deprecated(PlatformName.MacOSX, 10, 13,
		    message: "Use 'BeginDraggingSession (NSDraggingItem [], NSEvent, NSDraggingSource)' instead.")]
	    public extern bool DragPromisedFilesOfTypes(string[] typeArray, CGRect aRect, NSObject sourceObject,
		    bool slideBack, NSEvent theEvent);

	    [Export("exitFullScreenModeWithOptions:")]
	    public extern void ExitFullscreenModeWithOptions([NullAllowed] NSDictionary options);

	    [Export("enterFullScreenMode:withOptions:")]
	    public extern bool EnterFullscreenModeWithOptions(NSScreen screen, [NullAllowed] NSDictionary options);

	    [Export("isInFullScreenMode")] public extern bool IsInFullscreenMode { get; }

	    [Field("NSFullScreenModeApplicationPresentationOptions")]
	    public extern NSString NSFullScreenModeApplicationPresentationOptions { get; }

	    // Fields
	    [Field("NSFullScreenModeAllScreens")] public extern NSString NSFullScreenModeAllScreens { get; }

	    [Field("NSFullScreenModeSetting")] public extern NSString NSFullScreenModeSetting { get; }

	    [Field("NSFullScreenModeWindowLevel")] public extern NSString NSFullScreenModeWindowLevel { get; }

	    [Notification, Field("NSViewFrameDidChangeNotification")]
	    public extern NSString FrameChangedNotification { get; }

	    [Notification, Field("NSViewFocusDidChangeNotification")]
	    [Deprecated(PlatformName.MacOSX, 10, 4)]
	    public extern NSString FocusChangedNotification { get; }

	    [Notification, Field("NSViewBoundsDidChangeNotification")]
	    public extern NSString BoundsChangedNotification { get; }

	    [Deprecated(PlatformName.MacOSX, 10, 14, message: "Use 'Metal' instead.")]
	    [Notification, Field("NSViewGlobalFrameDidChangeNotification")]
	    public extern NSString GlobalFrameChangedNotification { get; }

	    [Notification, Field("NSViewDidUpdateTrackingAreasNotification")]
	    public extern NSString UpdatedTrackingAreasNotification { get; }

	    [Export("constraints")] public extern NSLayoutConstraint[] Constraints { get; }

	    [Export("addConstraint:")]
	    public extern void AddConstraint(NSLayoutConstraint constraint);

	    [Export("addConstraints:")]
	    public extern void AddConstraints(NSLayoutConstraint[] constraints);

	    [Export("removeConstraint:")]
	    public extern void RemoveConstraint(NSLayoutConstraint constraint);

	    [Export("removeConstraints:")]
	    public extern void RemoveConstraints(NSLayoutConstraint[] constraints);

	    [Export("layoutSubtreeIfNeeded")]
	    public extern void LayoutSubtreeIfNeeded();

	    [Export("layout")]
	    public extern void Layout();

	    [Export("needsUpdateConstraints")] public extern bool NeedsUpdateConstraints { get; set; }

	    [Export("needsLayout")] public extern bool NeedsLayout { get; set; }

	    [Export("updateConstraints")]
	    [RequiresSuper]
	    public extern void UpdateConstraints();

	    [Export("updateConstraintsForSubtreeIfNeeded")]
	    public extern void UpdateConstraintsForSubtreeIfNeeded();

	    [Static]
	    [Export("requiresConstraintBasedLayout")]
	    public extern bool RequiresConstraintBasedLayout();

	    //Detected properties
	    [Export("translatesAutoresizingMaskIntoConstraints")]
	    public extern bool TranslatesAutoresizingMaskIntoConstraints { get; set; }

	    [Export("alignmentRectForFrame:")]
	    public extern CGRect GetAlignmentRectForFrame(CGRect frame);

	    [Export("frameForAlignmentRect:")]
	    public extern CGRect GetFrameForAlignmentRect(CGRect alignmentRect);

	    [Export("alignmentRectInsets")] public extern NSEdgeInsets AlignmentRectInsets { get; }

	    [Export("baselineOffsetFromBottom")] public extern nfloat BaselineOffsetFromBottom { get; }

	    [Export("intrinsicContentSize")] public extern CGSize IntrinsicContentSize { get; }

	    [Export("invalidateIntrinsicContentSize")]
	    public extern void InvalidateIntrinsicContentSize();

	    [Export("contentHuggingPriorityForOrientation:")]
	    public extern float GetContentHuggingPriorityForOrientation(NSLayoutConstraintOrientation orientation);

	    [Export("setContentHuggingPriority:forOrientation:")]
	    public extern void SetContentHuggingPriorityForOrientation(float priority,
		    NSLayoutConstraintOrientation orientation);

	    [Export("contentCompressionResistancePriorityForOrientation:")]
	    public extern float GetContentCompressionResistancePriority(NSLayoutConstraintOrientation orientation);

	    [Export("setContentCompressionResistancePriority:forOrientation:")]
	    public extern void SetContentCompressionResistancePriority(float priority,
		    NSLayoutConstraintOrientation orientation);

	    [Export("fittingSize")] public extern CGSize FittingSize { get; }

	    [Export("constraintsAffectingLayoutForOrientation:")]
	    public extern NSLayoutConstraint[] GetConstraintsAffectingLayout(NSLayoutConstraintOrientation orientation);

	    [Export("hasAmbiguousLayout")] public extern bool HasAmbiguousLayout { get; }

	    [Export("exerciseAmbiguityInLayout")]
	    public extern void ExerciseAmbiguityInLayout();

	    [Deprecated(PlatformName.MacOSX, 10, 8)]
	    [Export("performMnemonic:")]
	    public extern bool PerformMnemonic(string mnemonic);

	    [NullAllowed] [Export("nextKeyView")] public extern NSView NextKeyView { get; set; }

	    [NullAllowed]
	    [Export("previousKeyView")]
	    public extern NSView PreviousKeyView { get; }

	    [NullAllowed]
	    [Export("nextValidKeyView")]
	    public extern NSView NextValidKeyView { get; }

	    [NullAllowed]
	    [Export("previousValidKeyView")]
	    public extern NSView PreviousValidKeyView { get; }

	    [Export("canBecomeKeyView")] public extern bool CanBecomeKeyView { get; }

	    [Export("setKeyboardFocusRingNeedsDisplayInRect:")]
	    public extern void SetKeyboardFocusRingNeedsDisplay(CGRect rect);

	    [Export("focusRingType")] public extern NSFocusRingType FocusRingType { get; set; }

	    [Static, Export("defaultFocusRingType")]
	    public extern NSFocusRingType DefaultFocusRingType { get; }

	    [Export("drawFocusRingMask")]
	    public extern void DrawFocusRingMask();

	    [Export("focusRingMaskBounds")] public extern CGRect FocusRingMaskBounds { get; }

	    [Export("noteFocusRingMaskChanged")]
	    public extern void NoteFocusRingMaskChanged();

	    [Export("isDrawingFindIndicator")] public extern bool IsDrawingFindIndicator { get; }

	    [Export("dataWithEPSInsideRect:")]
	    public extern NSData DataWithEpsInsideRect(CGRect rect);

	    [Export("dataWithPDFInsideRect:")]
	    public extern NSData DataWithPdfInsideRect(CGRect rect);

	    [Export("print:")]
	    public extern void Print([NullAllowed] NSObject sender);

	    [Export("printJobTitle")] public extern string PrintJobTitle { get; }

	    [Export("beginDocument")]
	    public extern void BeginDocument();

	    [Export("endDocument")]
	    public extern void EndDocument();

	    [Export("beginPageInRect:atPlacement:")]
	    public extern void BeginPage(CGRect rect, CGPoint placement);

	    [Export("endPage")]
	    public extern void EndPage();

	    [Export("pageHeader")] public extern NSAttributedString PageHeader { get; }

	    [Export("pageFooter")] public extern NSAttributedString PageFooter { get; }

	    [Export("writeEPSInsideRect:toPasteboard:")]
	    public extern void WriteEpsInsideRect(CGRect rect, NSPasteboard pboard);

	    [Export("writePDFInsideRect:toPasteboard:")]
	    public extern void WritePdfInsideRect(CGRect rect, NSPasteboard pboard);

	    [Export("drawPageBorderWithSize:")]
	    public extern void DrawPageBorder(CGSize borderSize);

	    [Deprecated(PlatformName.MacOSX, 10, 14, message: "Never called.")]
	    [Export("drawSheetBorderWithSize:")]
	    public extern void DrawSheetBorder(CGSize borderSize);

	    [Export("heightAdjustLimit")] public extern nfloat HeightAdjustLimit { get; }

	    [Export("widthAdjustLimit")] public extern nfloat WidthAdjustLimit { get; }

	    [Export("adjustPageWidthNew:left:right:limit:")]
	    public extern void AdjustPageWidthNew(ref nfloat newRight, nfloat left, nfloat proposedRight,
		    nfloat rightLimit);

	    [Export("adjustPageHeightNew:top:bottom:limit:")]
	    public extern void AdjustPageHeightNew(ref nfloat newBottom, nfloat top, nfloat proposedBottom,
		    nfloat bottomLimit);

	    [Export("knowsPageRange:")]
	    public extern bool KnowsPageRange(ref NSRange aRange);

	    [Export("rectForPage:")]
	    public extern CGRect RectForPage(nint pageNumber);

	    [Export("locationOfPrintRect:")]
	    public extern CGPoint LocationOfPrintRect(CGRect aRect);

	    [Deprecated(PlatformName.MacOSX, 10, 14, message: "Use 'Metal' Framework instead.")]
	    [Export("wantsBestResolutionOpenGLSurface")]
	    public extern bool WantsBestResolutionOpenGLSurface { get; set; }

	    [Export("backingAlignedRect:options:")]
	    public extern CGRect BackingAlignedRect(CGRect aRect, NSAlignmentOptions options);

	    [Export("convertRectFromBacking:")]
	    public extern CGRect ConvertRectFromBacking(CGRect aRect);

	    [Export("convertRectToBacking:")]
	    public extern CGRect ConvertRectToBacking(CGRect aRect);

	    [Export("convertRectFromLayer:")]
	    public extern CGRect ConvertRectFromLayer(CGRect aRect);

	    [Export("convertRectToLayer:")]
	    public extern CGRect ConvertRectToLayer(CGRect aRect);

	    [Export("convertPointFromBacking:")]
	    public extern CGPoint ConvertPointFromBacking(CGPoint aPoint);

	    [Export("convertPointToBacking:")]
	    public extern CGPoint ConvertPointToBacking(CGPoint aPoint);

	    [Export("convertPointFromLayer:")]
	    public extern CGPoint ConvertPointFromLayer(CGPoint aPoint);

	    [Export("convertPointToLayer:")]
	    public extern CGPoint ConvertPointToLayer(CGPoint aPoint);

	    [Export("convertSizeFromBacking:")]
	    public extern CGSize ConvertSizeFromBacking(CGSize aSize);

	    [Export("convertSizeToBacking:")]
	    public extern CGSize ConvertSizeToBacking(CGSize aSize);

	    [Export("convertSizeFromLayer:")]
	    public extern CGSize ConvertSizeFromLayer(CGSize aSize);

	    [Export("convertSizeToLayer:")]
	    public extern CGSize ConvertSizeToLayer(CGSize aSize);

	    [Export("viewDidChangeBackingProperties")]
	    public extern void DidChangeBackingProperties();

	    [Export("allowsVibrancy")] public extern bool AllowsVibrancy { get; }

	    [Export("gestureRecognizers", ArgumentSemantic.Copy)]
	    extern NSGestureRecognizer[] GestureRecognizers { get; set; }

	    [Export("addGestureRecognizer:")]
	    extern void AddGestureRecognizer(NSGestureRecognizer gestureRecognizer);

	    [Export("removeGestureRecognizer:")]
	    extern void RemoveGestureRecognizer(NSGestureRecognizer gestureRecognizer);

	    [Export("prepareForReuse")]
	    public extern void PrepareForReuse();

	    [Static, Export("isCompatibleWithResponsiveScrolling")]
	    public extern bool IsCompatibleWithResponsiveScrolling { get; }

	    [Export("prepareContentInRect:")]
	    public extern void PrepareContentInRect(CGRect rect);

	    [Export("canDrawSubviewsIntoLayer")] public extern bool CanDrawSubviewsIntoLayer { get; set; }

	    [Export("layerUsesCoreImageFilters")] public extern bool LayerUsesCoreImageFilters { get; set; }

	    [Export("userInterfaceLayoutDirection")]
	    public extern NSUserInterfaceLayoutDirection UserInterfaceLayoutDirection { get; set; }

	    [Export("preparedContentRect")] public extern CGRect PreparedContentRect { get; set; }

	    [NullAllowed]
	    [Export("pressureConfiguration", ArgumentSemantic.Strong)]
	    extern NSPressureConfiguration PressureConfiguration { get; set; }

	    [Export("willOpenMenu:withEvent:")]
	    public extern void WillOpenMenu(NSMenu menu, NSEvent theEvent);

	    [Export("didCloseMenu:withEvent:")]
	    public extern void DidCloseMenu(NSMenu menu, [NullAllowed] NSEvent theEvent);

	    // NSConstraintBasedLayoutCoreMethods

	    [Export("leadingAnchor", ArgumentSemantic.Strong)]
	    extern NSLayoutXAxisAnchor LeadingAnchor { get; }

	    [Export("trailingAnchor", ArgumentSemantic.Strong)]
	    extern NSLayoutXAxisAnchor TrailingAnchor { get; }

	    [Export("leftAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutXAxisAnchor LeftAnchor { get; }

	    [Export("rightAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutXAxisAnchor RightAnchor { get; }

	    [Export("topAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutYAxisAnchor TopAnchor { get; }

	    [Export("bottomAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutYAxisAnchor BottomAnchor { get; }

	    [Export("widthAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutDimension WidthAnchor { get; }

	    [Export("heightAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutDimension HeightAnchor { get; }

	    [Export("centerXAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutXAxisAnchor CenterXAnchor { get; }

	    [Export("centerYAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutYAxisAnchor CenterYAnchor { get; }

	    [Export("firstBaselineAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutYAxisAnchor FirstBaselineAnchor { get; }

	    [Export("lastBaselineAnchor", ArgumentSemantic.Strong)]
	     extern NSLayoutYAxisAnchor LastBaselineAnchor { get; }

	    [Export("firstBaselineOffsetFromTop")] public extern nfloat FirstBaselineOffsetFromTop { get; }

	    [Export("lastBaselineOffsetFromBottom")]
	    public extern nfloat LastBaselineOffsetFromBottom { get; }

	    [Field("NSViewNoIntrinsicMetric")] public extern nfloat NoIntrinsicMetric { get; }

	    [Export("addLayoutGuide:")]
	     extern void AddLayoutGuide(NSLayoutGuide guide);

	    [Export("removeLayoutGuide:")]
	     extern void RemoveLayoutGuide(NSLayoutGuide guide);

	    [Export("layoutGuides", ArgumentSemantic.Copy)]
	     extern NSLayoutGuide[] LayoutGuides { get; }

	    [Export("viewDidChangeEffectiveAppearance")]
	    public extern void ViewDidChangeEffectiveAppearance();

	    [Internal]
	    [Export("sortSubviewsUsingFunction:context:")]
	    public extern void SortSubviews(IntPtr function_pointer, IntPtr context);

	    [Export("horizontalContentSizeConstraintActive")]
	    public extern bool HorizontalContentSizeConstraintActive
	    {
		    [Bind("isHorizontalContentSizeConstraintActive")]
		    get;
		    set;
	    }

	    [Export("verticalContentSizeConstraintActive")]
	    public extern bool VerticalContentSizeConstraintActive
	    {
		    [Bind("isVerticalContentSizeConstraintActive")]
		    get;
		    set;
	    }

	    [Export("safeAreaInsets")] public extern NSEdgeInsets SafeAreaInsets { get; }

	    [Export("additionalSafeAreaInsets", ArgumentSemantic.Assign)]
	    public extern NSEdgeInsets AdditionalSafeAreaInsets { get; set; }

	    [Export("safeAreaLayoutGuide", ArgumentSemantic.Strong)]
	     extern NSLayoutGuide SafeAreaLayoutGuide { get; }

	    [Export("safeAreaRect")] public extern CGRect SafeAreaRect { get; }

	    [Export("layoutMarginsGuide", ArgumentSemantic.Strong)]
	     extern NSLayoutGuide LayoutMarginsGuide { get; }

	    // category NSDisplayLink (NSView)
	    [Export("displayLinkWithTarget:selector:")]
	    public extern CADisplayLink GetDisplayLink(NSObject target, Selector selector);

#if !__MACCATALYST__
	    // category NSWritingToolsCoordinator (NSView)
	    [NoMacCatalyst]
	    [NullAllowed, Export ("writingToolsCoordinator", ArgumentSemantic.Assign)]
	    [Mac (15, 2)]
	    NSWritingToolsCoordinator WritingToolsCoordinator { get; set; }
#endif
    }
}