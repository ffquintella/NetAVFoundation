
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

//using NSStringAttributes = UIKit.UIStringAttributes;
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
	public  partial class NSArray { }
	
	public partial class NSArray: NSMutableCopying, INSFastEnumeration {
		
		public NSArray(){}
		
		[Export ("count")]
		public extern nuint Count { get; }

		[Export ("objectAtIndex:")]
		public extern NativeHandle ValueAt (nuint idx);

		[Static]
		[Internal]
		[Export ("arrayWithObjects:count:")]
		public extern static IntPtr FromObjects (IntPtr array, nint count);

		[Export ("valueForKey:")]
		[MarshalNativeExceptions]
		public extern NSObject ValueForKey (NSString key);

		[Export ("setValue:forKey:")]
		public extern void SetValueForKey (NSObject value, NSString key);

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use 'Write (NSUrl, out NSError)' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'Write (NSUrl, out NSError)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'Write (NSUrl, out NSError)' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "Use 'Write (NSUrl, out NSError)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Write (NSUrl, out NSError)' instead.")]
		[Export ("writeToFile:atomically:")]
		public extern bool WriteToFile (string path, bool useAuxiliaryFile);

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use 'NSMutableArray.FromFile' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'NSMutableArray.FromFile' instead.")]
		//[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'NSMutableArray.FromFile' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "Use 'NSMutableArray.FromFile' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSMutableArray.FromFile' instead.")]
		[Export ("arrayWithContentsOfFile:")]
		[Static]
		public extern NSArray FromFile (string path);

		[Export ("sortedArrayUsingComparator:")]
		public extern NSArray Sort (NSComparator cmptr);

		[Export ("filteredArrayUsingPredicate:")]
		public extern NSArray Filter (NSPredicate predicate);

		[Internal]
		[Sealed]
		[Export ("containsObject:")]
		public extern bool _Contains (NativeHandle anObject);

		[Export ("containsObject:")]
		public extern bool Contains (NSObject anObject);

		[Internal]
		[Sealed]
		[Export ("indexOfObject:")]
		public extern nuint _IndexOf (NativeHandle anObject);

		[Export ("indexOfObject:")]
		public extern nuint IndexOf (NSObject anObject);

		[Export ("addObserver:toObjectsAtIndexes:forKeyPath:options:context:")]
		public extern void AddObserver (NSObject observer, NSIndexSet indexes, string keyPath, NSKeyValueObservingOptions options, IntPtr context);

		[Export ("removeObserver:fromObjectsAtIndexes:forKeyPath:context:")]
		public extern void RemoveObserver (NSObject observer, NSIndexSet indexes, string keyPath, IntPtr context);

		[Export ("removeObserver:fromObjectsAtIndexes:forKeyPath:")]
		public extern void RemoveObserver (NSObject observer, NSIndexSet indexes, string keyPath);

		[MacCatalyst (13, 1)]
		[Export ("writeToURL:error:")]
		public extern bool Write (NSUrl url, out NSError error);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("arrayWithContentsOfURL:error:")]

		public extern static NSArray? FromUrl (NSUrl url, out NSError error);

#if false // https://github.com/xamarin/xamarin-macios/issues/15577
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Internal]
		[Export ("differenceFromArray:withOptions:")]
		NativeHandle _GetDifference (NSArray other, NSOrderedCollectionDifferenceCalculationOptions options);

		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Wrap ("Runtime.GetNSObject <NSOrderedCollectionDifference> (_GetDifference (NSArray.FromNSObjects (other), options))")]
		[return: NullAllowed]
		NSOrderedCollectionDifference GetDifference (NSObject[] other, NSOrderedCollectionDifferenceCalculationOptions options);

		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("differenceFromArray:")]
		NativeHandle _GetDifference (NSArray other);

		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Wrap ("Runtime.GetNSObject <NSOrderedCollectionDifference> (_GetDifference(NSArray.FromNSObjects (other)))")]
		[return: NullAllowed]
		NSOrderedCollectionDifference GetDifference (NSObject[] other);

		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("arrayByApplyingDifference:")]
		[return: NullAllowed]
		NativeHandle _GetArrayByApplyingDifference (NSOrderedCollectionDifference difference);

		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Wrap ("NSArray.ArrayFromHandle<NSObject> (_GetArrayByApplyingDifference (difference))")]
		[return: NullAllowed]
		NSObject[] GetArrayByApplyingDifference (NSOrderedCollectionDifference difference);

		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("differenceFromArray:withOptions:usingEquivalenceTest:")]
		NativeHandle _GetDifferenceFromArray (NSArray other, NSOrderedCollectionDifferenceCalculationOptions options, /* Func<NSObject, NSObject, bool> block */ ref BlockLiteral block);
#endif
	}

}