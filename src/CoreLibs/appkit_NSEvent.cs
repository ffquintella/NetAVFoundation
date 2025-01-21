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
[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	public class NSEvent : NSCopying {
		[Export ("type")]
		public extern NSEventType Type { get; }

		[Export ("modifierFlags")]
		public extern NSEventModifierMask ModifierFlags { get; }

		[Export ("timestamp")]
		public extern double Timestamp { get; }

		[Export ("window")]
		public extern NSWindow Window { get; }

		[Export ("windowNumber")]
		public extern nint WindowNumber { get; }

		[Deprecated (PlatformName.MacOSX, 10, 12, message: "This method always returns null. If you need access to the current drawing context, use NSGraphicsContext.CurrentContext inside of a draw operation.")]
		[Export ("context")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)] extern NSGraphicsContext Context { get; }

		[Export ("clickCount")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint ClickCount { get; }

		[Export ("buttonNumber")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint ButtonNumber { get; }

		[Export ("eventNumber")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint EventNumber { get; }

		[Export ("pressure")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern float Pressure { get; } /* float, not CGFloat */

		[Export ("locationInWindow")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern CGPoint LocationInWindow { get; }

		[Export ("deltaX")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nfloat DeltaX { get; }

		[Export ("deltaY")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nfloat DeltaY { get; }

		[Export ("deltaZ")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		nfloat DeltaZ { get; }

		[Export ("characters")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern string Characters { get; }

		[Export ("charactersIgnoringModifiers")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern string CharactersIgnoringModifiers { get; }

		[Export ("isARepeat")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern bool IsARepeat { get; }

		[Export ("keyCode")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern ushort KeyCode { get; }

		[Export ("trackingNumber")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint TrackingNumber { get; }

		[Export ("userData")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern IntPtr UserData { get; }

		[Export ("trackingArea")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		extern NSTrackingArea TrackingArea { get; }

		[Export ("subtype")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern short Subtype { get; }

		[Export ("data1")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint Data1 { get; }

		[Export ("data2")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint Data2 { get; }

		[Export ("eventRef")]
		public extern IntPtr EventRef { get; }

		[Static]
		[Export ("eventWithEventRef:")]
		public extern NSEvent EventWithEventRef (IntPtr cgEventRef);

		[Export ("CGEvent")]
		public extern IntPtr CGEvent { get; }

		/// <summary>The CGEvent object corresponding to this event.</summary>
		/// <appledoc>https://developer.apple.com/documentation/appkit/nsevent/1530429-cgevent?language=objc</appledoc>
		[return: NullAllowed]
		[Wrap ("Runtime.GetINativeObject<CGEvent> (CGEvent, false)")]
		public extern CGEvent GetCGEventObject ();

		[Static]
		[Export ("eventWithCGEvent:")]
		[Obsolete ("Use 'Create (CGEvent)' instead.")]
#if XAMCORE_5_0
		[Internal]
#endif
		public extern NSEvent EventWithCGEvent (IntPtr cgEventPtr);

		[Export ("magnification")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nfloat Magnification { get; }

		[Export ("deviceID")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint DeviceID { get; }

		[Export ("rotation")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern float Rotation { get; } /* float, not CGFloat */

		[Export ("absoluteX")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint AbsoluteX { get; }

		[Export ("absoluteY")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint AbsoluteY { get; }

		[Export ("absoluteZ")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nint AbsoluteZ { get; }

		// TODO: What is the type?
		[Export ("buttonMask")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint ButtonMask { get; }

		[Export ("tilt")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern CGPoint Tilt { get; }

		[Export ("tangentialPressure")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern float TangentialPressure { get; } /* float, not CGFloat */

		[Export ("vendorDefined")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern NSObject VendorDefined { get; }

		[Export ("vendorID")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint VendorID { get; }

		[Export ("tabletID")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint TabletID { get; }

		[Export ("pointingDeviceID")]
		public extern nuint PointingDeviceID ();

		[Export ("systemTabletID")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint SystemTabletID { get; }

		[Export ("vendorPointingDeviceType")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint VendorPointingDeviceType { get; }

		[Export ("pointingDeviceSerialNumber")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint PointingDeviceSerialNumber { get; }

		[Export ("uniqueID")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern long UniqueID { get; }

		[Export ("capabilityMask")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nuint CapabilityMask { get; }

		[Export ("pointingDeviceType")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern NSPointingDeviceType PointingDeviceType { get; }

		[Export ("isEnteringProximity")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern bool IsEnteringProximity { get; }

		[Export ("touchesMatchingPhase:inView:")]
		public extern NSSet TouchesMatchingPhase (NSTouchPhase phase, NSView view);

		[Static]
		[Export ("startPeriodicEventsAfterDelay:withPeriod:")]
		public static extern void StartPeriodicEventsAfterDelay (double delay, double period);

		[Static]
		[Export ("stopPeriodicEvents")]
		public static extern void StopPeriodicEvents ();

		[Static]
		[Export ("mouseEventWithType:location:modifierFlags:timestamp:windowNumber:context:eventNumber:clickCount:pressure:")]
		static extern NSEvent MouseEvent (NSEventType type, CGPoint location, NSEventModifierMask flags, double time, nint wNum, [NullAllowed] NSGraphicsContext context, nint eNum, nint cNum, float /* float, not CGFloat */ pressure);

		[Static]
		[Export ("keyEventWithType:location:modifierFlags:timestamp:windowNumber:context:characters:charactersIgnoringModifiers:isARepeat:keyCode:")]
		static extern NSEvent KeyEvent (NSEventType type, CGPoint location, NSEventModifierMask flags, double time, nint wNum, [NullAllowed] NSGraphicsContext context, string keys, string ukeys, bool isARepeat, ushort code);

		[Static]
		[Export ("enterExitEventWithType:location:modifierFlags:timestamp:windowNumber:context:eventNumber:trackingNumber:userData:")]
		static extern NSEvent EnterExitEvent (NSEventType type, CGPoint location, NSEventModifierMask flags, double time, nint wNum, [NullAllowed] NSGraphicsContext context, nint eNum, nint tNum, IntPtr data);

		[Static]
		[Export ("otherEventWithType:location:modifierFlags:timestamp:windowNumber:context:subtype:data1:data2:")]
		static extern NSEvent OtherEvent (NSEventType type, CGPoint location, NSEventModifierMask flags, double time, nint wNum, [NullAllowed] NSGraphicsContext context, short subtype, nint d1, nint d2);

		[Static]
		[Export ("mouseLocation")]
		public static extern CGPoint CurrentMouseLocation { get; }

		[Static]
		[Export ("modifierFlags")]
		public static extern NSEventModifierMask CurrentModifierFlags { get; }

		[Static]
		[Export ("pressedMouseButtons")]
		public static extern nuint CurrentPressedMouseButtons { get; }

		[Static]
		[Export ("doubleClickInterval")]
		public static extern double DoubleClickInterval { get; }

		[Static]
		[Export ("keyRepeatDelay")]
		public static extern double KeyRepeatDelay { get; }

		[Static]
		[Export ("keyRepeatInterval")]
		public static extern double KeyRepeatInterval { get; }

		[Static]
		[Export ("addGlobalMonitorForEventsMatchingMask:handler:")]
		static extern NSObject AddGlobalMonitorForEventsMatchingMask (NSEventMask mask, GlobalEventHandler handler);

		[Static]
		[Export ("addLocalMonitorForEventsMatchingMask:handler:")]
		static extern NSObject AddLocalMonitorForEventsMatchingMask (NSEventMask mask, LocalEventHandler handler);

		[Static]
		[Export ("removeMonitor:")]
		public static extern void RemoveMonitor (NSObject eventMonitor);

		//Detected properties
		[Static]
		[Export ("mouseCoalescingEnabled")]
		public static extern bool MouseCoalescingEnabled { [Bind ("isMouseCoalescingEnabled")] get; set; }

		[Export ("hasPreciseScrollingDeltas")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern bool HasPreciseScrollingDeltas { get; }

		[Export ("scrollingDeltaX")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nfloat ScrollingDeltaX { get; }

		[Export ("scrollingDeltaY")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern nfloat ScrollingDeltaY { get; }

		[Export ("momentumPhase")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern NSEventPhase MomentumPhase { get; }

		[Export ("isDirectionInvertedFromDevice")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern bool IsDirectionInvertedFromDevice { get; }

		[Export ("phase")]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		public extern NSEventPhase Phase { get; }

		[Static]
		[Export ("isSwipeTrackingFromScrollEventsEnabled")]
		public static extern bool IsSwipeTrackingFromScrollEventsEnabled { get; }

		[Export ("trackSwipeEventWithOptions:dampenAmountThresholdMin:max:usingHandler:")]
		extern void TrackSwipeEvent (NSEventSwipeTrackingOptions options, nfloat minDampenThreshold, nfloat maxDampenThreshold, NSEventTrackHandler trackingHandler);

		[Export ("stage")]
		public extern nint Stage { get; }

		[Export ("stageTransition")]
		public extern nfloat StageTransition { get; }

		[Export ("associatedEventsMask")]
		public extern NSEventMask AssociatedEventsMask { get; }

		[Export ("allTouches")]
		public extern NSSet<NSTouch> AllTouches { get; }

		[Export ("touchesForView:")]
		public extern NSSet<NSTouch> GetTouches (NSView view);

		[Export ("coalescedTouchesForTouch:")]
		public extern NSTouch [] GetCoalescedTouches (NSTouch touch);

		[Export ("charactersByApplyingModifiers:")]
		[return: NullAllowed]
		public extern string GetCharacters (NSEventModifierFlags modifiers);
	}
}