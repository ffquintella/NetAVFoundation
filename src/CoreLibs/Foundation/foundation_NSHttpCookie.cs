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

	public partial class NSHttpCookie : NSObject {
		[Export ("initWithProperties:")]
		public extern NativeHandle Constructor (NSDictionary properties);

		[Export ("cookieWithProperties:"), Static]
		public extern NSHttpCookie CookieFromProperties (NSDictionary properties);

		[Export ("requestHeaderFieldsWithCookies:"), Static]
		public extern NSDictionary RequestHeaderFieldsWithCookies (NSHttpCookie [] cookies);

		[Export ("cookiesWithResponseHeaderFields:forURL:"), Static]
		public extern NSHttpCookie [] CookiesWithResponseHeaderFields (NSDictionary headerFields, NSUrl url);

		[Export ("properties")]
		public extern  NSDictionary Properties { get; }

		[Export ("version")]
		public extern  nuint Version { get; }

		[Export ("value")]
		public extern  string Value { get; }

		[Export ("expiresDate")]
		public extern  NSDate ExpiresDate { get; }

		[Export ("isSessionOnly")]
		public extern  bool IsSessionOnly { get; }

		[Export ("domain")]
		public extern  string Domain { get; }

		[Export ("name")]
		public extern  string Name { get; }

		[Export ("path")]
		public extern  string Path { get; }

		[Export ("isSecure")]
		public extern  bool IsSecure { get; }

		[Export ("isHTTPOnly")]
		public extern  bool IsHttpOnly { get; }

		[Export ("comment")]
		public extern  string Comment { get; }

		[Export ("commentURL")]
		public extern  NSUrl CommentUrl { get; }

		[Export ("portList")]
		public extern  NSNumber [] PortList { get; }

		[Field ("NSHTTPCookieName")]
		public static extern  NSString KeyName { get; }

		[Field ("NSHTTPCookieValue")]
		public static extern  NSString KeyValue { get; }

		[Field ("NSHTTPCookieOriginURL")]
		public extern  NSString KeyOriginUrl { get; }

		[Field ("NSHTTPCookieVersion")]
		public static extern  NSString KeyVersion { get; }

		[Field ("NSHTTPCookieDomain")]
		public extern static NSString KeyDomain { get; }

		[Field ("NSHTTPCookiePath")]
		public extern static NSString KeyPath { get; }

		[Field ("NSHTTPCookieSecure")]
		public extern static NSString KeySecure { get; }

		[Field ("NSHTTPCookieExpires")]
		public extern static NSString KeyExpires { get; }

		[Field ("NSHTTPCookieComment")]
		public extern static NSString KeyComment { get; }

		[Field ("NSHTTPCookieCommentURL")]
		public extern static NSString KeyCommentUrl { get; }

		[Field ("NSHTTPCookieDiscard")]
		public extern static NSString KeyDiscard { get; }

		[Field ("NSHTTPCookieMaximumAge")]
		public extern static NSString KeyMaximumAge { get; }

		[Field ("NSHTTPCookiePort")]
		public extern static NSString KeyPort { get; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		//[MacCatalyst (13, 1)]
		[Field ("NSHTTPCookieSameSitePolicy")]
		public extern static NSString KeySameSitePolicy { get; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		//[MacCatalyst (13, 1)]
		[Field ("NSHTTPCookieSameSiteLax")]
		public extern static NSString KeySameSiteLax { get; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		//[MacCatalyst (13, 1)]
		[Field ("NSHTTPCookieSameSiteStrict")]
		public extern static NSString KeySameSiteStrict { get; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		//[MacCatalyst (13, 1)]
		[NullAllowed, Export ("sameSitePolicy")]
		public extern static NSString SameSitePolicy { get; }

		//[TV (18, 2), iOS (18, 2), MacCatalyst (18, 2), Mac (15, 2)]
		//[Field ("NSHTTPCookieSetByJavaScript")]
		public extern static NSString KeySetByJavaScript { get; }
	}
    
}
