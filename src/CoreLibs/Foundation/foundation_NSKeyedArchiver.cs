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
    [BaseType (typeof (NSCoder), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSKeyedArchiverDelegate) })]
	public partial class NSKeyedArchiver: NSCoder {

		[MacCatalyst (13, 1)]
		[Export ("initRequiringSecureCoding:")]
		public extern NativeHandle Constructor (bool requiresSecureCoding);

		// hack so we can decorate the default .ctor with availability attributes
		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		[Export ("init")]
		public extern NativeHandle Constructor ();

		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSKeyedArchiver (bool)' instead.")]
		[Export ("initForWritingWithMutableData:")]
		public extern NativeHandle Constructor (NSMutableData data);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("archivedDataWithRootObject:requiringSecureCoding:error:")]
		[return: NullAllowed]
#if NET
		public extern NSData? GetArchivedData (NSObject @object, bool requiresSecureCoding, [NullAllowed] out NSError error);
#else
		public extern NSData? ArchivedDataWithRootObject (NSObject @object, bool requiresSecureCoding, [NullAllowed] out NSError error);
#endif

		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
	//	[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		[Export ("archivedDataWithRootObject:")]
		[Static]
#if NET
		public extern static NSData GetArchivedData (NSObject root);
#else
		public extern static NSData ArchivedDataWithRootObject (NSObject root);
#endif

		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ArchivedDataWithRootObject (NSObject, bool, out NSError)' instead.")]
		[Export ("archiveRootObject:toFile:")]
		[Static]
		public extern static bool ArchiveRootObjectToFile (NSObject root, string file);

		[Export ("finishEncoding")]
		public extern void FinishEncoding ();

		[Export ("outputFormat")]
		public extern NSPropertyListFormat PropertyListFormat { get; set; }

		[Wrap ("WeakDelegate")]
		public extern INSKeyedArchiverDelegate Delegate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		public extern NSObject? WeakDelegate { get; set; }

		[Export ("setClassName:forClass:")]
		public extern void SetClassName (string name, Class kls);

		[Export ("classNameForClass:")]
		public extern string GetClassName (Class kls);

		[MacCatalyst (13, 1)]
		[Field ("NSKeyedArchiveRootObjectKey")]
		public extern NSString RootObjectKey { get; }

#if NET
		[Export ("requiresSecureCoding")]
		public extern bool RequiresSecureCoding { get; set; }
#else
		[Export ("setRequiresSecureCoding:")]
		public extern void SetRequiresSecureCoding (bool requireSecureEncoding);

		[Export ("requiresSecureCoding")]
		public extern bool GetRequiresSecureCoding ();
#endif

		[MacCatalyst (13, 1)]
		[Export ("encodedData", ArgumentSemantic.Strong)]
		public extern NSData EncodedData { get; }
	}
	
	public partial class INSKeyedArchiverDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	public partial class NSKeyedArchiverDelegate {
		[Export ("archiver:didEncodeObject:"), EventArgs ("NSObject")]
		public extern void EncodedObject (NSKeyedArchiver archiver, NSObject obj);

		[Export ("archiverDidFinish:")]
		public extern void Finished (NSKeyedArchiver archiver);

		[Export ("archiver:willEncodeObject:"), DelegateName ("NSEncodeHook"), DefaultValue (null)]
		public extern NSObject WillEncode (NSKeyedArchiver archiver, NSObject obj);

		[Export ("archiverWillFinish:")]
		public extern void Finishing (NSKeyedArchiver archiver);

		[Export ("archiver:willReplaceObject:withObject:"), EventArgs ("NSArchiveReplace")]
		public extern void ReplacingObject (NSKeyedArchiver archiver, NSObject oldObject, NSObject newObject);
	}
	
}