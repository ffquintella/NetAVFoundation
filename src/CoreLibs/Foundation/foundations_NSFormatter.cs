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
    public partial class NSFormatter : NSCopying {
        [Export ("stringForObjectValue:")]
        public extern string StringFor ([NullAllowed] NSObject value);

        // - (NSAttributedString *)attributedStringForObjectValue:(id)obj withDefaultAttributes:(NSDictionary *)attrs;

        [Export ("editingStringForObjectValue:")]
        public extern string EditingStringFor (NSObject value);

        [Internal]
        [Sealed]
        [Export ("attributedStringForObjectValue:withDefaultAttributes:")]
        public extern NSAttributedString GetAttributedString (NSObject obj, NSDictionary defaultAttributes);

        // -(NSAttributedString *)attributedStringForObjectValue:(id)obj withDefaultAttributes:(NSDictionary *)attrs;
        [Export ("attributedStringForObjectValue:withDefaultAttributes:")]
        public extern NSAttributedString GetAttributedString (NSObject obj, NSDictionary<NSString, NSObject> defaultAttributes);

        [Wrap ("GetAttributedString (obj, defaultAttributes.GetDictionary ()!)")]
#if MONOMAC
        public extern NSAttributedString GetAttributedString (NSObject obj, NSStringAttributes defaultAttributes);
#else
		public extern NSAttributedString GetAttributedString (NSObject obj, UIStringAttributes defaultAttributes);
#endif

        [Export ("getObjectValue:forString:errorDescription:")]
        public extern bool GetObjectValue (out NSObject obj, string str, out NSString error);

        [Export ("isPartialStringValid:newEditingString:errorDescription:")]
        public extern bool IsPartialStringValid (string partialString, [NullAllowed] out string newString, [NullAllowed] out NSString error);

        [Export ("isPartialStringValid:proposedSelectedRange:originalString:originalSelectedRange:errorDescription:")]
        public extern bool IsPartialStringValid (ref string partialString, out NSRange proposedSelRange, string origString, NSRange origSelRange, [NullAllowed] out string error);
    }
}