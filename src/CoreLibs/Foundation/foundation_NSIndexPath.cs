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
		[BaseType (typeof (NSObject))]
    	public partial class NSIndexPath : NSCoding {
    		[Export ("indexPathWithIndex:")]
    		[Static]
    		public extern static NSIndexPath FromIndex (nuint index);
    
    		[Export ("indexPathWithIndexes:length:")]
    		[Internal]
    		[Static]
		    public extern static NSIndexPath _FromIndex (IntPtr indexes, nint len);
    
    		[Export ("indexPathByAddingIndex:")]
		    public extern NSIndexPath IndexPathByAddingIndex (nuint index);
    
    		[Export ("indexPathByRemovingLastIndex")]
		    public extern NSIndexPath IndexPathByRemovingLastIndex ();
    
    		[Export ("indexAtPosition:")]
		    public extern nuint IndexAtPosition (nint position);
    
    		[Export ("length")]
		    public extern nint Length { get; }
    
    		[Export ("getIndexes:")]
    		[Internal]
    		internal extern void _GetIndexes (IntPtr target);
    
    		[MacCatalyst (13, 1)]
    		[Export ("getIndexes:range:")]
    		[Internal]
    		internal extern void _GetIndexes (IntPtr target, NSRange positionRange);
    
    		[Export ("compare:")]
		    public extern nint Compare (NSIndexPath other);
    
    		// NSIndexPath UIKit Additions Reference
    		// https://developer.apple.com/library/ios/#documentation/UIKit/Reference/NSIndexPath_UIKitAdditions/Reference/Reference.html
    
    		// see monotouch/src/UIKit/Addition.cs for int-returning Row/Section properties
    		[NoMac]
    		[NoWatch]
    		[MacCatalyst (13, 1)]
    		[Export ("row")]
		    public extern nint LongRow { get; }
    
    		[NoMac]
    		[NoWatch]
    		[MacCatalyst (13, 1)]
    		[Export ("section")]
		    public extern nint LongSection { get; }
    
    		[NoMac]
    		[NoWatch]
    		[MacCatalyst (13, 1)]
    		[Static]
    		[Export ("indexPathForRow:inSection:")]
		    public extern NSIndexPath FromRowSection (nint row, nint section);
    
    		/*[NoiOS]
    		[NoMacCatalyst]
    		[NoWatch]
    		[NoTV]
    		[Export ("section")]
		    public extern nint Section { get; }
		    */
    
    		[NoWatch]
    		[Static]
    		[MacCatalyst (13, 1)]
    		[Export ("indexPathForItem:inSection:")]
		    public extern NSIndexPath FromItemSection (nint item, nint section);
    
    		[NoWatch]
    		[Export ("item")]
    		[MacCatalyst (13, 1)]
		    public extern nint Item { get; }
    	}
}