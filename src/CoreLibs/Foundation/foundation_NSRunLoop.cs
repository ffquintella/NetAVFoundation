#region INCLUDES 

#define DOUBLE_BLOCKS
using ObjCRuntime;

//using CoreData;
using CoreFoundation;
using Foundation;
using CoreGraphics;
using UniformTypeIdentifiers;

#if HAS_APPCLIP
using AppClip;
#endif
#if IOS
using QuickLook;
#endif
#if !TVOS

#endif
#if !WATCH
using CoreAnimation;

#endif
using CoreMedia;

#if IOS || MONOMAC

#else
using INSFileProviderItem = Foundation.NSObject;
#endif

#if MONOMAC
using AppKit;

#else
using CoreLocation;
using UIKit;
#endif

using System;
using System.ComponentModel;
using CoreLibs;

// In Apple headers, this is a typedef to a pointer to a private struct
using NSAppleEventManagerSuspensionID = System.IntPtr;
// These two are both four char codes i.e. defined on a uint with constant like 'xxxx'
using AEKeyword = System.UInt32;
using OSType = System.UInt32;
// typedef double NSTimeInterval;
using NSTimeInterval = System.Double;

#if MONOMAC
// dummy usings to make code compile without having the actual types available (for [NoMac] to work)
using NSDirectionalEdgeInsets = Foundation.NSObject;
using UIEdgeInsets = Foundation.NSObject;
using UIOffset = Foundation.NSObject;
using UIPreferredPresentationStyle = Foundation.NSObject;
#else
using NSPasteboard = Foundation.NSObject;
using NSWorkspaceAuthorization = Foundation.NSObject;

using NSStringAttributes = UIKit.UIStringAttributes;
#endif

#if IOS && !__MACCATALYST__
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if TVOS
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if WATCH
// dummy usings to make code compile without having the actual types available (for [NoWatch] to work)
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
using CSSearchableItemAttributeSet = Foundation.NSObject;
#endif

#if WATCH
using CIBarcodeDescriptor = Foundation.NSObject;
#else
using CoreImage;
#endif

#if !IOS
using APActivationPayload = Foundation.NSObject;
#endif

#if __MACCATALYST__
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if IOS || WATCH || TVOS
using NSAppearance = UIKit.UIAppearance;
using NSColor = UIKit.UIColor;
using NSNotificationSuspensionBehavior = Foundation.NSObject;
using NSNotificationFlags = Foundation.NSObject;
using NSTextBlock = Foundation.NSObject;
using NSTextTable = Foundation.NSString; // Different frmo NSTextBlock, because some methods overload on these two types.
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

#endregion

namespace Foundation
{
    [BaseType (typeof (NSObject))]
	public partial class NSRunLoop: NSObject {
		[Export ("currentRunLoop", ArgumentSemantic.Strong)]
		[Static]
		[IsThreadStatic]
		public extern static NSRunLoop Current { get; }

		[Export ("mainRunLoop", ArgumentSemantic.Strong)]
		[Static]
		public extern static NSRunLoop Main { get; }

		[Export ("currentMode")]
		public extern NSString CurrentMode { get; }

		[Wrap ("NSRunLoopModeExtensions.GetValue (CurrentMode)")]
		public extern NSRunLoopMode CurrentRunLoopMode { get; }

		[Export ("getCFRunLoop")]
		public extern CFRunLoop GetCFRunLoop ();

		[Export ("addTimer:forMode:")]
		public extern void AddTimer (NSTimer timer, NSString forMode);

		[Wrap ("AddTimer (timer, forMode.GetConstant ()!)")]
		public extern void AddTimer (NSTimer timer, NSRunLoopMode forMode);

		[Export ("limitDateForMode:")]
		public extern NSDate LimitDateForMode (NSString mode);

		[Wrap ("LimitDateForMode (mode.GetConstant ()!)")]
		public extern NSDate LimitDateForMode (NSRunLoopMode mode);

		[Export ("acceptInputForMode:beforeDate:")]
		public extern void AcceptInputForMode (NSString mode, NSDate limitDate);

		[Wrap ("AcceptInputForMode (mode.GetConstant ()!, limitDate)")]
		public extern void AcceptInputForMode (NSRunLoopMode mode, NSDate limitDate);

		[Export ("run")]
		public extern void Run ();

		[Export ("runUntilDate:")]
		public extern void RunUntil (NSDate date);

		[Export ("runMode:beforeDate:")]
		public extern bool RunUntil (NSString runLoopMode, NSDate limitdate);

		[Wrap ("RunUntil (runLoopMode.GetConstant ()!, limitDate)")]
		public extern bool RunUntil (NSRunLoopMode runLoopMode, NSDate limitDate);

		[MacCatalyst (13, 1)]
		[Export ("performBlock:")]
		public extern void Perform (Action block);

		[MacCatalyst (13, 1)]
		[Export ("performInModes:block:")]
		public extern void Perform (NSString [] modes, Action block);

		[MacCatalyst (13, 1)]
		[Wrap ("Perform (modes.GetConstants ()!, block)")]
		public extern void Perform (NSRunLoopMode [] modes, Action block);

#if !NET
		[Obsolete ("Use the 'NSRunLoopMode' enum instead.")]
		[Field ("NSDefaultRunLoopMode")]
		NSString NSDefaultRunLoopMode { get; }

		[Obsolete ("Use the 'NSRunLoopMode' enum instead.")]
		[Field ("NSRunLoopCommonModes")]
		NSString NSRunLoopCommonModes { get; }

		[Obsolete ("Use the 'NSRunLoopMode' enum instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSXpcConnection' instead.")]
		[NoiOS, NoWatch, NoTV, MacCatalyst (15, 0)]
		[Field ("NSConnectionReplyMode")]
		NSString NSRunLoopConnectionReplyMode { get; }

		[Obsolete ("Use the 'NSRunLoopMode' enum instead.")]
		[NoiOS, NoWatch, NoTV]
		[Field ("NSModalPanelRunLoopMode", "AppKit")]
		NSString NSRunLoopModalPanelMode { get; }

		[Obsolete ("Use the 'NSRunLoopMode' enum instead.")]
		[NoiOS, NoWatch, NoTV]
		[Field ("NSEventTrackingRunLoopMode", "AppKit")]
		NSString NSRunLoopEventTracking { get; }

		[Obsolete ("Use the 'NSRunLoopMode' enum instead.")]
		[NoMac]
		[NoWatch]
		[Field ("UITrackingRunLoopMode", "UIKit")]
		NSString UITrackingRunLoopMode { get; }
#endif
	}
}