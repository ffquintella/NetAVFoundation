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
    public partial class INSKeyedUnarchiverDelegate { }

	[BaseType (typeof (NSObject))]
	public partial class NSKeyedUnarchiverDelegate: NSObject {
		[Export ("unarchiver:didDecodeObject:"), DelegateName ("NSDecoderCallback"), DefaultValue (null)]
		public extern NSObject DecodedObject (NSKeyedUnarchiver unarchiver, NSObject obj);

		[Export ("unarchiverDidFinish:")]
		public extern void Finished (NSKeyedUnarchiver unarchiver);

		[Export ("unarchiver:cannotDecodeObjectOfClassName:originalClasses:"), DelegateName ("NSDecoderHandler"), DefaultValue (null)]
		public extern Class CannotDecodeClass (NSKeyedUnarchiver unarchiver, string klass, string [] classes);

		[Export ("unarchiverWillFinish:")]
		public extern void Finishing (NSKeyedUnarchiver unarchiver);

		[Export ("unarchiver:willReplaceObject:withObject:"), EventArgs ("NSArchiveReplace")]
		public extern void ReplacingObject (NSKeyedUnarchiver unarchiver, NSObject oldObject, NSObject newObject);
	}

	

	[BaseType (typeof (NSCoder), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSKeyedUnarchiverDelegate) })]
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -[NSKeyedUnarchiver init]: cannot use -init for initialization
	[DisableDefaultCtor]
	partial class NSKeyedUnarchiver: NSCoder {
		[MacCatalyst (13, 1)]
		[Export ("initForReadingFromData:error:")]
		public extern NativeHandle Constructor (NSData data, [NullAllowed] out NSError error);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("unarchivedObjectOfClass:fromData:error:")]
		[return: NullAllowed]
		public extern NSObject? GetUnarchivedObject (Class cls, NSData data, [NullAllowed] out NSError error);

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("GetUnarchivedObject (new Class (type), data, out error)")]
		[return: NullAllowed]
		public extern NSObject? GetUnarchivedObject (Type type, NSData data, [NullAllowed] out NSError error);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("unarchivedObjectOfClasses:fromData:error:")]
		[return: NullAllowed]
		public extern NSObject? GetUnarchivedObject (NSSet<Class> classes, NSData data, [NullAllowed] out NSError error);

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("GetUnarchivedObject (new NSSet<Class> (Array.ConvertAll (types, t => new Class (t))), data, out error)")]
		[return: NullAllowed]
		public extern NSObject? GetUnarchivedObject (Type [] types, NSData data, [NullAllowed] out NSError error);

		[Export ("initForReadingWithData:")]
		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'NSKeyedUnarchiver (NSData, out NSError)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'NSKeyedUnarchiver (NSData, out NSError)' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'NSKeyedUnarchiver (NSData, out NSError)' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSKeyedUnarchiver (NSData, out NSError)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSKeyedUnarchiver (NSData, out NSError)' instead.")]
		[MarshalNativeExceptions]
		public extern NativeHandle Constructor (NSData data);

		[Static, Export ("unarchiveObjectWithData:")]
		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'GetUnarchivedObject ()' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'GetUnarchivedObject ()' instead.")]
		[MarshalNativeExceptions]
		public extern static NSObject UnarchiveObject (NSData data);

		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'GetUnarchivedObject ()' instead.")]
		[Static, Export ("unarchiveTopLevelObjectWithData:error:")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'GetUnarchivedObject ()' instead.")]
		// FIXME: [MarshalNativeExceptions]
		public extern static NSObject UnarchiveTopLevelObject (NSData data, out NSError error);

		[Static, Export ("unarchiveObjectWithFile:")]
		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'GetUnarchivedObject ()' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'GetUnarchivedObject ()' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'GetUnarchivedObject ()' instead.")]
		[MarshalNativeExceptions]
		public extern static NSObject UnarchiveFile (string file);

		[Export ("finishDecoding")]
		public extern void FinishDecoding ();

		[Wrap ("WeakDelegate")]
		public extern INSKeyedUnarchiverDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		public extern NSObject? WeakDelegate { get; set; }

		[Export ("setClass:forClassName:")]
		public extern void SetClass (Class kls, string codedName);

		[Export ("classForClassName:")]
		[return: NullAllowed]
		public extern Class GetClass (string codedName);

#if NET
		[Export ("requiresSecureCoding")]
		public extern bool RequiresSecureCoding { get; set; }
#else
		[Export ("setRequiresSecureCoding:")]
		public extern void SetRequiresSecureCoding (bool requireSecureEncoding);

		[Export ("requiresSecureCoding")]
		public extern bool GetRequiresSecureCoding ();
#endif

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Export ("unarchivedArrayOfObjectsOfClass:fromData:error:")]
		[return: NullAllowed]
		public extern static NSObject []? GetUnarchivedArray (Class @class, NSData data, [NullAllowed] out NSError error);

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Export ("unarchivedArrayOfObjectsOfClasses:fromData:error:")]
		[return: NullAllowed]
		public extern static NSObject []? GetUnarchivedArray (NSSet<Class> classes, NSData data, [NullAllowed] out NSError error);

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Export ("unarchivedDictionaryWithKeysOfClass:objectsOfClass:fromData:error:")]
		[return: NullAllowed]
		public extern static NSDictionary? GetUnarchivedDictionary (Class keyClass, Class valueClass, NSData data, [NullAllowed] out NSError error);

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Export ("unarchivedDictionaryWithKeysOfClasses:objectsOfClasses:fromData:error:")]
		[return: NullAllowed]
		public extern static NSDictionary? GetUnarchivedDictionary (NSSet<Class> keyClasses, NSSet<Class> valueClasses, NSData data, [NullAllowed] out NSError error);
	}
}