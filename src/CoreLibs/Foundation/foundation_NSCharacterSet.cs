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
	public class NSCharacterSet : NSMutableCopying {
		[Static, Export ("alphanumericCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Alphanumerics { get; }

		[Static, Export ("capitalizedLetterCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Capitalized { get; }

		// TODO/FIXME: constructor?
		[Static, Export ("characterSetWithBitmapRepresentation:")]
		public static extern NSCharacterSet FromBitmap (NSData data);

		// TODO/FIXME: constructor?
		[Static, Export ("characterSetWithCharactersInString:")]
		public static extern NSCharacterSet FromString (string aString);

		[return: NullAllowed]
		[Static, Export ("characterSetWithContentsOfFile:")]
		public static extern NSCharacterSet FromFile (string path);

		[Static, Export ("characterSetWithRange:")]
		public static extern NSCharacterSet FromRange (NSRange aRange);

		[Static, Export ("controlCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Controls { get; }

		[Static, Export ("decimalDigitCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet DecimalDigits { get; }

		[Static, Export ("decomposableCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Decomposables { get; }

		[Static, Export ("illegalCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Illegals { get; }

		[Static, Export ("letterCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Letters { get; }

		[Static, Export ("lowercaseLetterCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet LowercaseLetters { get; }

		[Static, Export ("newlineCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Newlines { get; }

		[Static, Export ("nonBaseCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Marks { get; }

		[Static, Export ("punctuationCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Punctuation { get; }

		[Static, Export ("symbolCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Symbols { get; }

		[Static, Export ("uppercaseLetterCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet UppercaseLetters { get; }

		[Static, Export ("whitespaceAndNewlineCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet WhitespaceAndNewlines { get; }

		[Static, Export ("whitespaceCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet Whitespaces { get; }

		[Export ("bitmapRepresentation")]
		public extern NSData GetBitmapRepresentation ();

		[Export ("characterIsMember:")]
		public extern bool Contains (char aCharacter);

		[Export ("hasMemberInPlane:")]
		public extern bool HasMemberInPlane (byte thePlane);

		[Export ("invertedSet")]
		public extern NSCharacterSet InvertedSet { get; }

		[Export ("isSupersetOfSet:")]
		public extern bool IsSupersetOf (NSCharacterSet theOtherSet);

		[Export ("longCharacterIsMember:")]
		public extern bool Contains (uint /* UTF32Char = UInt32 */ theLongChar);

		[Static]
		[Export ("URLFragmentAllowedCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet UrlFragmentAllowed { get; }

		[Static]
		[Export ("URLHostAllowedCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet UrlHostAllowed { get; }

		[Static]
		[Export ("URLPasswordAllowedCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet UrlPasswordAllowed { get; }

		[Static]
		[Export ("URLPathAllowedCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet UrlPathAllowed { get; }

		[Static]
		[Export ("URLQueryAllowedCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet UrlQueryAllowed { get; }

		[Static]
		[Export ("URLUserAllowedCharacterSet", ArgumentSemantic.Copy)]
		public static extern NSCharacterSet UrlUserAllowed { get; }
	}
}