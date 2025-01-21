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

    public partial class NSHost: NSObject {

        [Static, Internal, Export ("currentHost")]
        public static extern NSHost _Current { get;}

        [Static, Internal, Export ("hostWithName:")]
        public static extern NSHost _FromName ([NullAllowed] string name);

        [Static, Internal, Export ("hostWithAddress:")]
        public static extern NSHost _FromAddress (string address);

        [Export ("isEqualToHost:")]
        public extern bool Equals (NSHost host);

        [NullAllowed]
        [Export ("name")]
        public extern string? Name { get; }

        [NullAllowed]
        [Export ("localizedName")]
        public extern string? LocalizedName { get; }

        [Export ("names")]
        public extern string [] Names { get; }

        [NullAllowed]
        [Internal, Export ("address")]
        public extern string? _Address { get; }

        [Internal, Export ("addresses")]
        internal extern string [] _Addresses  { get; }

        [Export ("hash"), Internal]
        public extern nuint _Hash { get; }

        /* Deprecated, here for completeness:

        [Availability (Introduced = Platform.Mac_10_0, Deprecated = Platform.Mac_10_7)]
        [Static, Export ("setHostCacheEnabled:")]
        void SetHostCacheEnabled (bool flag);

        [Availability (Introduced = Platform.Mac_10_0, Deprecated = Platform.Mac_10_7)]
        [Static, Export ("isHostCacheEnabled")]
        bool IsHostCacheEnabled ();

        [Availability (Introduced = Platform.Mac_10_0, Deprecated = Platform.Mac_10_7)]
        [Static, Export ("flushHostCache")]
        void FlushHostCache ();
        */
    }
}