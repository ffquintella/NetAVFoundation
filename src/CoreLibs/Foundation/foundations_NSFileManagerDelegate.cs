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
    public partial class INSFileManagerDelegate { }
    
	public partial class NSFileManagerDelegate : NSObject {
		[Export ("fileManager:shouldCopyItemAtPath:toPath:")]
		public extern bool ShouldCopyItemAtPath (NSFileManager fm, NSString srcPath, NSString dstPath);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldCopyItemAtURL:toURL:")]
		public extern bool ShouldCopyItemAtUrl (NSFileManager fm, NSUrl srcUrl, NSUrl dstUrl);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldLinkItemAtURL:toURL:")]
		public extern bool ShouldLinkItemAtUrl (NSFileManager fileManager, NSUrl srcUrl, NSUrl dstUrl);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldMoveItemAtURL:toURL:")]
		public extern bool ShouldMoveItemAtUrl (NSFileManager fileManager, NSUrl srcUrl, NSUrl dstUrl);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldProceedAfterError:copyingItemAtURL:toURL:")]
		public extern bool ShouldProceedAfterErrorCopyingItem (NSFileManager fileManager, NSError error, NSUrl srcUrl, NSUrl dstUrl);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldProceedAfterError:linkingItemAtURL:toURL:")]
		public extern bool ShouldProceedAfterErrorLinkingItem (NSFileManager fileManager, NSError error, NSUrl srcUrl, NSUrl dstUrl);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldProceedAfterError:movingItemAtURL:toURL:")]
		public extern bool ShouldProceedAfterErrorMovingItem (NSFileManager fileManager, NSError error, NSUrl srcUrl, NSUrl dstUrl);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldRemoveItemAtURL:")]
		public extern bool ShouldRemoveItemAtUrl (NSFileManager fileManager, NSUrl url);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("fileManager:shouldProceedAfterError:removingItemAtURL:")]
		public extern bool ShouldProceedAfterErrorRemovingItem (NSFileManager fileManager, NSError error, NSUrl url);

		[Export ("fileManager:shouldProceedAfterError:copyingItemAtPath:toPath:")]
		public extern bool ShouldProceedAfterErrorCopyingItem (NSFileManager fileManager, NSError error, string srcPath, string dstPath);

		[Export ("fileManager:shouldMoveItemAtPath:toPath:")]
		public extern bool ShouldMoveItemAtPath (NSFileManager fileManager, string srcPath, string dstPath);

		[Export ("fileManager:shouldProceedAfterError:movingItemAtPath:toPath:")]
		public extern bool ShouldProceedAfterErrorMovingItem (NSFileManager fileManager, NSError error, string srcPath, string dstPath);

		[Export ("fileManager:shouldLinkItemAtPath:toPath:")]
		public extern bool ShouldLinkItemAtPath (NSFileManager fileManager, string srcPath, string dstPath);

		[Export ("fileManager:shouldProceedAfterError:linkingItemAtPath:toPath:")]
		public extern bool ShouldProceedAfterErrorLinkingItem (NSFileManager fileManager, NSError error, string srcPath, string dstPath);

		[Export ("fileManager:shouldRemoveItemAtPath:")]
		public extern bool ShouldRemoveItemAtPath (NSFileManager fileManager, string path);

		[Export ("fileManager:shouldProceedAfterError:removingItemAtPath:")]
		public extern bool ShouldProceedAfterErrorRemovingItem (NSFileManager fileManager, NSError error, string path);
	}
}