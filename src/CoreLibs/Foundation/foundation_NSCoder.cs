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
	public partial class NSCoder: NSObject {

		//
		// Encoding and decoding
		//
		[Export ("encodeObject:")]
		public extern void Encode ([NullAllowed] NSObject obj);

		[Export ("encodeRootObject:")]
		public extern void EncodeRoot ([NullAllowed] NSObject obj);

		[Export ("decodeObject")]
		public extern NSObject DecodeObject ();

		//
		// Encoding and decoding with keys
		// 
		[Export ("encodeConditionalObject:forKey:")]
		public extern void EncodeConditionalObject ([NullAllowed] NSObject val, string key);

		[Export ("encodeObject:forKey:")]
		public extern void Encode ([NullAllowed] NSObject val, string key);

		[Export ("encodeBool:forKey:")]
		public extern void Encode (bool val, string key);

		[Export ("encodeDouble:forKey:")]
		public extern void Encode (double val, string key);

		[Export ("encodeFloat:forKey:")]
		public extern void Encode (float /* float, not CGFloat */ val, string key);

		[Export ("encodeInt32:forKey:")]
		public extern void Encode (int /* int32 */ val, string key);

		[Export ("encodeInt64:forKey:")]
		public extern void Encode (long val, string key);

		[Export ("encodeInteger:forKey:")]
		public extern void Encode (nint val, string key);

		[Export ("encodeBytes:length:forKey:")]
		public extern void EncodeBlock (IntPtr bytes, nint length, string key);

		[Export ("containsValueForKey:")]
		public extern bool ContainsKey (string key);

		[Export ("decodeBoolForKey:")]
		public extern bool DecodeBool (string key);

		[Export ("decodeDoubleForKey:")]
		public extern double DecodeDouble (string key);

		[Export ("decodeFloatForKey:")]
		public extern float DecodeFloat (string key); /* float, not CGFloat */

		[Export ("decodeInt32ForKey:")]
		public extern int DecodeInt (string key); /* int, not NSInteger */

		[Export ("decodeInt64ForKey:")]
		public extern long DecodeLong (string key);

		[Export ("decodeIntegerForKey:")]
		public extern nint DecodeNInt (string key);

		[Export ("decodeObjectForKey:")]
		public extern NSObject DecodeObject (string key);

		[Export ("decodeBytesForKey:returnedLength:")]
		public extern IntPtr DecodeBytes (string key, out nuint length);

		[Export ("decodeBytesWithReturnedLength:")]
		public extern IntPtr DecodeBytes (out nuint length);

		[Export ("allowedClasses")]
		public extern NSSet AllowedClasses { get; }

		[Export ("requiresSecureCoding")]
		public extern bool RequiresSecureCoding ();

		[MacCatalyst (13, 1)]
		[Export ("decodeTopLevelObjectAndReturnError:")]
		public extern NSObject DecodeTopLevelObject (out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("decodeTopLevelObjectForKey:error:")]
		public extern NSObject DecodeTopLevelObject (string key, out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("decodeTopLevelObjectOfClass:forKey:error:")]
		public extern NSObject DecodeTopLevelObject (Class klass, string key, out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("decodeTopLevelObjectOfClasses:forKey:error:")]
		public extern NSObject DecodeTopLevelObject ([NullAllowed] NSSet<Class> setOfClasses, string key, out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("failWithError:")]
		public extern void Fail (NSError error);

		[Export ("systemVersion")]
		public extern uint SystemVersion { get; }

		[MacCatalyst (13, 1)]
		[Export ("decodingFailurePolicy")]
		public extern NSDecodingFailurePolicy DecodingFailurePolicy { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("error", ArgumentSemantic.Copy)]
		public extern NSError? Error { get; }

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("decodeArrayOfObjectsOfClass:forKey:")]
		[return: NullAllowed]
		public extern NSObject? [] DecodeArrayOfObjects (Class @class, string key);

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("decodeArrayOfObjectsOfClasses:forKey:")]
		[return: NullAllowed]
		public extern NSObject? [] DecodeArrayOfObjects (NSSet<Class> classes, string key);

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("decodeDictionaryWithKeysOfClass:objectsOfClass:forKey:")]
		[return: NullAllowed]
		public extern NSDictionary? DecodeDictionary (Class keyClass, Class objectClass, string key);

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("decodeDictionaryWithKeysOfClasses:objectsOfClasses:forKey:")]
		[return: NullAllowed]
		public extern NSDictionary? DecodeDictionary (NSSet<Class> keyClasses, NSSet<Class> objectClasses, string key);
	}
}