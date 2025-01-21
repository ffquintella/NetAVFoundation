#region INCLUDES 

#define DOUBLE_BLOCKS
using ObjCRuntime;

using CoreData;
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
	// Objective-C exception thrown.  Name: NSGenericException Reason: *** -[NSConcreteNotification init]: should never be used
	[DisableDefaultCtor] // added in iOS7 but header files says "do not invoke; not a valid initializer for this class"
	public partial class NSNotification :  NSCopying {
		[Export ("name")]
		// Null not allowed
		public extern string Name { get; }

		[Export ("object")]
		[NullAllowed]
		public extern NSObject? Object { get; }

		[Export ("userInfo")]
		[NullAllowed]
		public extern NSDictionary? UserInfo { get; }

		[Export ("notificationWithName:object:")]
		[Static]
		public static extern NSNotification FromName (string name, [NullAllowed] NSObject obj);

		[Export ("notificationWithName:object:userInfo:")]
		[Static]
		public static extern NSNotification FromName (string name, [NullAllowed] NSObject obj, [NullAllowed] NSDictionary userInfo);

	}

	[BaseType (typeof (NSObject))]
	public partial class NSNotificationCenter: NSObject {
		[Static]
		[Export ("defaultCenter", ArgumentSemantic.Strong)]
		public static extern NSNotificationCenter DefaultCenter { get; }

		[Export ("addObserver:selector:name:object:")]
		[PostSnippet ("AddObserverToList (observer, aName, anObject);", Optimizable = true)]
		public extern void AddObserver (NSObject observer, Selector aSelector, [NullAllowed] NSString aName, [NullAllowed] NSObject anObject);

		[Export ("postNotification:")]
		public extern void PostNotification (NSNotification notification);

		[Export ("postNotificationName:object:")]
		public extern void PostNotificationName (string aName, [NullAllowed] NSObject anObject);

		[Export ("postNotificationName:object:userInfo:")]
		public extern void PostNotificationName (string aName, [NullAllowed] NSObject anObject, [NullAllowed] NSDictionary aUserInfo);

		[Export ("removeObserver:")]
		[PostSnippet ("RemoveObserversFromList (observer, null, null);", Optimizable = true)]
		public extern void RemoveObserver (NSObject observer);

		[Export ("removeObserver:name:object:")]
		[PostSnippet ("RemoveObserversFromList (observer, aName, anObject);", Optimizable = true)]
		public extern void RemoveObserver (NSObject observer, [NullAllowed] string aName, [NullAllowed] NSObject anObject);

		[Export ("addObserverForName:object:queue:usingBlock:")]
		public extern NSObject AddObserver ([NullAllowed] string name, [NullAllowed] NSObject obj, [NullAllowed] NSOperationQueue queue, Action<NSNotification> handler);
	}
	
	[MacCatalyst (13, 1)]
	[Protocol]
	public partial class NSProgressReporting {
#if NET
		[Abstract]
#endif
		[Export ("progress")]
		public extern NSProgress Progress { get; }
	}

	[BaseType (typeof (NSMutableData))]
	public partial class NSPurgeableData :  NSDiscardableContent {
	}

	[Protocol]
	public partial class NSDiscardableContent : NSMutableCopying {
		[Abstract]
		[Export ("beginContentAccess")]
		public extern bool BeginContentAccess ();

		[Abstract]
		[Export ("endContentAccess")]
		public extern void EndContentAccess ();

		[Abstract]
		[Export ("discardContentIfPossible")]
		public extern void DiscardContentIfPossible ();

		[Abstract]
		[Export ("isContentDiscarded")]
		public extern bool IsContentDiscarded { get; }
	}
	
	[BaseType (typeof (NSObject))]
	public partial class NSOperationQueue : NSProgressReporting {
		[Export ("addOperation:")]
		[PostGet ("Operations")]
		public extern void AddOperation ([NullAllowed] NSOperation op);

		[Export ("addOperations:waitUntilFinished:")]
		[PostGet ("Operations")]
		public extern void AddOperations ([NullAllowed] NSOperation [] operations, bool waitUntilFinished);

		[Export ("addOperationWithBlock:")]
		[PostGet ("Operations")]
		public extern void AddOperation (/* non null */ Action operation);

		//[Deprecated (PlatformName.MacOSX, 10, 15, 0, message: "This API should not be used as it is subject to race conditions. If synchronization is needed use 'AddBarrier' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "This API should not be used as it is subject to race conditions. If synchronization is needed use 'AddBarrier' instead.")]
		//[Deprecated (PlatformName.WatchOS, 6, 0, message: "This API should not be used as it is subject to race conditions. If synchronization is needed use 'AddBarrier' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "This API should not be used as it is subject to race conditions. If synchronization is needed use 'AddBarrier' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "This API should not be used as it is subject to race conditions. If synchronization is needed use 'AddBarrier' instead.")]
		[Export ("operations")]
		public extern NSOperation [] Operations { get; }

		//[Deprecated (PlatformName.MacOSX, 10, 15)]
		//[Deprecated (PlatformName.iOS, 13, 0)]
		//[Deprecated (PlatformName.WatchOS, 6, 0)]
		//[Deprecated (PlatformName.TvOS, 13, 0)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("operationCount")]
		public extern nint OperationCount { get; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("addBarrierBlock:")]
		public extern void AddBarrier (Action barrier);

		[Export ("name")]
		public extern string Name { get; set; }

		[Export ("cancelAllOperations")]
		[PostGet ("Operations")]
		public extern void CancelAllOperations ();

		[Export ("waitUntilAllOperationsAreFinished")]
		public extern void WaitUntilAllOperationsAreFinished ();

		[Static]
		[Export ("currentQueue", ArgumentSemantic.Strong)]
		public static extern NSOperationQueue CurrentQueue { get; }

		[Static]
		[Export ("mainQueue", ArgumentSemantic.Strong)]
		public static extern NSOperationQueue MainQueue { get; }

		//Detected properties
		[Export ("maxConcurrentOperationCount")]
		public extern nint MaxConcurrentOperationCount { get; set; }

		[Export ("suspended")]
		public extern bool Suspended { [Bind ("isSuspended")] get; set; }

		[MacCatalyst (13, 1)]
		[Export ("qualityOfService")]
		public extern NSQualityOfService QualityOfService { get; set; }

		[NullAllowed]
		[MacCatalyst (13, 1)]
		[Export ("underlyingQueue", ArgumentSemantic.UnsafeUnretained)]
		public extern DispatchQueue? UnderlyingQueue { get; set; }

	}
}