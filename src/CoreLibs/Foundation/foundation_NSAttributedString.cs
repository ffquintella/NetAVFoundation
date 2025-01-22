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
	public partial class NSAttributedString :  NSMutableCopying //NSObject2,
#if MONOMAC
		//, NSPasteboardReading, NSPasteboardWriting
#endif
#if IOS
		//, NSItemProviderReading, NSItemProviderWriting
#endif
	{
#if !WATCH
		// Inlined from the NSAttributedStringAttachmentConveniences category
		[Static, Export ("attributedStringWithAttachment:")]
		public static extern NSAttributedString FromAttachment (NSTextAttachment attachment);
#endif

		// Inlined from the NSAttributedStringAttachmentConveniences category
		//[NoWatch, TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Static, Export ("attributedStringWithAttachment:attributes:")]
		public static extern NSAttributedString FromAttachment (NSTextAttachment attachment, NSDictionary<NSString, NSObject> attributes);

		[Export ("string")]
		public IntPtr LowLevelValue { get; }

		[Export ("attributesAtIndex:effectiveRange:")]
#if NET
		public extern IntPtr LowLevelGetAttributes (nint location, IntPtr effectiveRange);
#else
		public IntPtr LowLevelGetAttributes (nint location, out NSRange effectiveRange);
#endif

		[Export ("length")]
		public nint Length { get; }

		// TODO: figure out the type, this deserves to be strongly typed if possble
		[Export ("attribute:atIndex:effectiveRange:")]
		public extern  NSObject GetAttribute (string attribute, nint location, out NSRange effectiveRange);

		[Export ("attributedSubstringFromRange:"), Internal]
		public extern NSAttributedString Substring (NSRange range);

		[Export ("attributesAtIndex:longestEffectiveRange:inRange:")]
		public extern NSDictionary GetAttributes (nint location, out NSRange longestEffectiveRange, NSRange rangeLimit);

		[Export ("attribute:atIndex:longestEffectiveRange:inRange:")]
		public extern NSObject GetAttribute (string attribute, nint location, out NSRange longestEffectiveRange, NSRange rangeLimit);

		[Export ("isEqualToAttributedString:")]
		public extern bool IsEqual (NSAttributedString other);

		[Export ("initWithString:")]
		public extern NativeHandle Constructor (string str);

		[Export ("initWithString:attributes:")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public extern NativeHandle Constructor (string str, [NullAllowed] NSDictionary attributes);

		[Export ("initWithAttributedString:")]
		public extern NativeHandle Constructor (NSAttributedString other);

		[Export ("enumerateAttributesInRange:options:usingBlock:")]
		public extern void EnumerateAttributes (NSRange range, NSAttributedStringEnumeration options, NSAttributedRangeCallback callback);

		[Export ("enumerateAttribute:inRange:options:usingBlock:")]
		public extern void EnumerateAttribute (NSString attributeName, NSRange inRange, NSAttributedStringEnumeration options, NSAttributedStringCallback callback);

#if !XAMCORE_5_0
		[Obsolete ("Use the 'Create' method instead, because there's no way to return an error from a constructor.")]
		[Export ("initWithURL:options:documentAttributes:error:")]
#if !__MACOS__
		public NativeHandle Constructor (NSUrl url, NSDictionary options, out NSDictionary resultDocumentAttributes, ref NSError error);
#else
		public extern NativeHandle Constructor (NSUrl url, NSDictionary options, out NSDictionary resultDocumentAttributes, out NSError error);
#endif
#endif // !XAMCORE_5_0

		[Internal]
		[Sealed]
		[Export ("initWithURL:options:documentAttributes:error:")]
		internal extern  NativeHandle _InitWithUrl (NSUrl url, NSDictionary options, out NSDictionary resultDocumentAttributes, out NSError error);

#if !XAMCORE_5_0
		[Obsolete ("Use the 'Create' method instead, because there's no way to return an error from a constructor.")]
		[Export ("initWithData:options:documentAttributes:error:")]
#if __MACOS__
		public extern NativeHandle Constructor (NSData data, NSDictionary options, out NSDictionary docAttributes, out NSError error);
#else
		public NativeHandle Constructor (NSData data, NSDictionary options, out NSDictionary resultDocumentAttributes, ref NSError error);
#endif
#endif // !XAMCORE_5_0

		[Internal]
		[Sealed]
		[Export ("initWithData:options:documentAttributes:error:")]
		internal extern  NativeHandle _InitWithData (NSData data, NSDictionary options, out NSDictionary resultDocumentAttributes, out NSError error);

#if !XAMCORE_5_0
		[Obsolete ("Use the 'Create' method instead, because there's no way to return an error from a constructor.")]
#if __MACOS__
		[Wrap ("this (url, options.GetDictionary ()!, out resultDocumentAttributes, out error)")]
		public extern NativeHandle Constructor (NSUrl url, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, out NSError error);
#else
		[Wrap ("this (url, options.GetDictionary ()!, out resultDocumentAttributes, ref error)")]
		public NativeHandle Constructor (NSUrl url, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, ref NSError error);
#endif
#endif // !XAMCORE_5_0

		[Obsolete ("Use the 'Create' method instead, because there's no way to return an error from a constructor.")]
#if !XAMCORE_5_0
#if __MACOS__
		[Wrap ("this (data, options.GetDictionary ()!, out resultDocumentAttributes, out error)")]
		public extern NativeHandle Constructor (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, out NSError error);
#else
		[Wrap ("this (data, options.GetDictionary ()!, out resultDocumentAttributes, ref error)")]
		public NativeHandle Constructor (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, ref NSError error);
#endif
#endif // !XAMCORE_5_0

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("initWithDocFormat:documentAttributes:")]
		public extern NativeHandle Constructor (NSData wordDocFormat, out NSDictionary docAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("initWithHTML:baseURL:documentAttributes:")]
		public extern NativeHandle Constructor (NSData htmlData, NSUrl baseUrl, out NSDictionary docAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("drawWithRect:options:")]
		public extern void DrawString (CGRect rect, NSStringDrawingOptions options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSAttributedString (NSUrl, NSDictionary, out NSDictionary, ref NSError)' instead.")]
		[Export ("initWithPath:documentAttributes:")]
		public extern NativeHandle Constructor (string path, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSAttributedString (NSUrl, NSDictionary, out NSDictionary, ref NSError)' instead.")]
		[Export ("initWithURL:documentAttributes:")]
		public extern NativeHandle Constructor (NSUrl url, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Internal, Export ("initWithRTF:documentAttributes:")]
		public extern IntPtr InitWithRtf (NSData data, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Internal, Export ("initWithRTFD:documentAttributes:")]
		public extern IntPtr InitWithRtfd (NSData data, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Internal, Export ("initWithHTML:documentAttributes:")]
		public extern IntPtr InitWithHTML (NSData data, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("initWithHTML:options:documentAttributes:")]
		public extern NativeHandle Constructor (NSData data, [NullAllowed] NSDictionary options, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Wrap ("this (data, options.GetDictionary (), out resultDocumentAttributes)")]
		public extern NativeHandle Constructor (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("initWithRTFDFileWrapper:documentAttributes:")]
		public extern NativeHandle Constructor (NSFileWrapper wrapper, out NSDictionary resultDocumentAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("containsAttachments")]
		public bool ContainsAttachments { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("fontAttributesInRange:")]
		public extern NSDictionary GetFontAttributes (NSRange range);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("rulerAttributesInRange:")]
		public extern NSDictionary GetRulerAttributes (NSRange range);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("lineBreakBeforeIndex:withinRange:")]
		public extern nuint GetLineBreak (nuint beforeIndex, NSRange aRange);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("lineBreakByHyphenatingBeforeIndex:withinRange:")]
		public extern nuint GetLineBreakByHyphenating (nuint beforeIndex, NSRange aRange);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("doubleClickAtIndex:")]
		public extern NSRange DoubleClick (nuint index);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("nextWordFromIndex:forward:")]
		public extern nuint GetNextWord (nuint fromIndex, bool isForward);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSDataDetector' instead.")]
		[Export ("URLAtIndex:effectiveRange:")]
		public extern NSUrl GetUrl (nuint index, out NSRange effectiveRange);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("rangeOfTextBlock:atIndex:")]
		public extern NSRange GetRange (NSTextBlock textBlock, nuint index);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("rangeOfTextTable:atIndex:")]
		public extern NSRange GetRange (NSTextTable textTable, nuint index);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("rangeOfTextList:atIndex:")]
		public extern NSRange GetRange (NSTextList textList, nuint index);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("itemNumberInTextList:atIndex:")]
		public extern  nint GetItemNumber (NSTextList textList, nuint index);

#if !(MONOMAC || XAMCORE_5_0)
		[Sealed]
#endif
		[return: NullAllowed]
		[Export ("dataFromRange:documentAttributes:error:")]
		public extern NSData GetData (NSRange range, NSDictionary options, out NSError error);

		[return: NullAllowed]
		[Wrap ("this.GetData (range, options.GetDictionary ()!, out error)")]
		public extern  NSData GetData (NSRange range, NSAttributedStringDocumentAttributes options, out NSError error);

#if !(MONOMAC || XAMCORE_5_0)
		[return: NullAllowed]
		[Obsolete ("Use 'GetData' instead.")]
		[Export ("dataFromRange:documentAttributes:error:")]
		public NSData GetDataFromRange (NSRange range, NSDictionary attributes, ref NSError error);
#endif

#if !(MONOMAC || XAMCORE_5_0)
		[return: NullAllowed]
		[Obsolete ("Use 'GetData' instead.")]
		[Wrap ("GetDataFromRange (range, documentAttributes.GetDictionary ()!, ref error)")]
		public NSData GetDataFromRange (NSRange range, NSAttributedStringDocumentAttributes documentAttributes, ref NSError error);
#endif

#if !(MONOMAC || XAMCORE_5_0)
		[Sealed]
#endif
		[return: NullAllowed]
		[Export ("fileWrapperFromRange:documentAttributes:error:")]
		public extern NSFileWrapper GetFileWrapper (NSRange range, NSDictionary options, out NSError error);

#if !(MONOMAC || XAMCORE_5_0)
		[return: NullAllowed]
		[Obsolete ("Use 'GetFileWrapper' instead.")]
		[Export ("fileWrapperFromRange:documentAttributes:error:")]
		public NSFileWrapper GetFileWrapperFromRange (NSRange range, NSDictionary attributes, ref NSError error);
#endif

		[return: NullAllowed]
		[Wrap ("this.GetFileWrapper (range, options.GetDictionary ()!, out error)")]
		public extern NSFileWrapper GetFileWrapper (NSRange range, NSAttributedStringDocumentAttributes options, out NSError error);

#if !(MONOMAC || XAMCORE_5_0)
		[return: NullAllowed]
		[Obsolete ("Use 'GetFileWrapper' instead.")]
		[Wrap ("GetFileWrapperFromRange (range, documentAttributes.GetDictionary ()!, ref error)")]
		public NSFileWrapper GetFileWrapperFromRange (NSRange range, NSAttributedStringDocumentAttributes documentAttributes, ref NSError error);
#endif

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("RTFFromRange:documentAttributes:")]
		public extern NSData GetRtf (NSRange range, [NullAllowed] NSDictionary options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Wrap ("this.GetRtf (range, options.GetDictionary ())")]
		public  extern NSData GetRtf (NSRange range, NSAttributedStringDocumentAttributes options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("RTFDFromRange:documentAttributes:")]
		public  extern NSData GetRtfd (NSRange range, [NullAllowed] NSDictionary options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Wrap ("this.GetRtfd (range, options.GetDictionary ())")]
		public  extern NSData GetRtfd (NSRange range, NSAttributedStringDocumentAttributes options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("RTFDFileWrapperFromRange:documentAttributes:")]
		public  extern NSFileWrapper GetRtfdFileWrapper (NSRange range, [NullAllowed] NSDictionary options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Wrap ("this.GetRtfdFileWrapper (range, options.GetDictionary ())")]
		public  extern NSFileWrapper GetRtfdFileWrapper (NSRange range, NSAttributedStringDocumentAttributes options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("docFormatFromRange:documentAttributes:")]
		public extern  NSData GetDocFormat (NSRange range, [NullAllowed] NSDictionary options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Wrap ("this.GetDocFormat (range, options.GetDictionary ())")]
		public extern  NSData GetDocFormat (NSRange range, NSAttributedStringDocumentAttributes options);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("drawWithRect:options:context:")]
		public  extern void DrawString (CGRect rect, NSStringDrawingOptions options, [NullAllowed] NSStringDrawingContext context);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("boundingRectWithSize:options:context:")]
		public  extern CGRect GetBoundingRect (CGSize size, NSStringDrawingOptions options, [NullAllowed] NSStringDrawingContext context);

		[MacCatalyst (13, 1)]
		[Export ("size")]
		public  extern CGSize Size { get; }

		[Export ("drawAtPoint:")]
		public extern  void DrawString (CGPoint point);

		[Export ("drawInRect:")]
		public extern  void DrawString (CGRect rect);

		// Inlined from the NSAttributedStringKitAdditions category
		[MacCatalyst (13, 1)]
		[Export ("containsAttachmentsInRange:")]
		public  extern bool ContainsAttachmentsInRange (NSRange range);

		// Inlined from the NSAttributedStringKitAdditions category
		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("prefersRTFDInRange:")]
		public  extern bool PrefersRtfdInRange (NSRange range);

		// inlined from NSAttributedStringWebKitAdditions category (since they are all static members)

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("loadFromHTMLWithRequest:options:completionHandler:")]
		[PreSnippet ("GC.KeepAlive (WebKit.WKContentMode.Recommended); // no-op to ensure WebKit.framework is loaded into memory", Optimizable = true)]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public static  extern void LoadFromHtml (NSUrlRequest request, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[Wrap ("LoadFromHtml (request, options.GetDictionary ()!, completionHandler)")]
		public static extern  void LoadFromHtml (NSUrlRequest request, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("loadFromHTMLWithFileURL:options:completionHandler:")]
		[PreSnippet ("GC.KeepAlive (WebKit.WKContentMode.Recommended); // no-op to ensure WebKit.framework is loaded into memory", Optimizable = true)]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public static extern  void LoadFromHtml (NSUrl fileUrl, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[Wrap ("LoadFromHtml (fileUrl, options.GetDictionary ()!, completionHandler)")]
		public static extern  void LoadFromHtml (NSUrl fileUrl, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("loadFromHTMLWithString:options:completionHandler:")]
		[PreSnippet ("GC.KeepAlive (WebKit.WKContentMode.Recommended); // no-op to ensure WebKit.framework is loaded into memory", Optimizable = true)]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public static  extern void LoadFromHtml (string @string, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[Wrap ("LoadFromHtml (@string, options.GetDictionary ()!, completionHandler)")]
		public static extern  void LoadFromHtml (string @string, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("loadFromHTMLWithData:options:completionHandler:")]
		[PreSnippet ("GC.KeepAlive (WebKit.WKContentMode.Recommended); // no-op to ensure WebKit.framework is loaded into memory", Optimizable = true)]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public static  extern void LoadFromHtml (NSData data, NSDictionary options, NSAttributedStringCompletionHandler completionHandler);

		[NoWatch]
		[NoTV] // really inside WebKit
		[iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Async (ResultTypeName = "NSLoadFromHtmlResult")]
		[Wrap ("LoadFromHtml (data, options.GetDictionary ()!, completionHandler)")]
		public static extern  void LoadFromHtml (NSData data, NSAttributedStringDocumentAttributes options, NSAttributedStringCompletionHandler completionHandler);

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("initWithContentsOfMarkdownFileAtURL:options:baseURL:error:")]
		public  extern NativeHandle Constructor (NSUrl markdownFile, [NullAllowed] NSAttributedStringMarkdownParsingOptions options, [NullAllowed] NSUrl baseUrl, [NullAllowed] out NSError error);

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("initWithMarkdown:options:baseURL:error:")]
		public  extern NativeHandle Constructor (NSData markdown, [NullAllowed] NSAttributedStringMarkdownParsingOptions options, [NullAllowed] NSUrl baseUrl, [NullAllowed] out NSError error);

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("initWithMarkdownString:options:baseURL:error:")]
		public  extern NativeHandle Constructor (string markdownString, [NullAllowed] NSAttributedStringMarkdownParsingOptions options, [NullAllowed] NSUrl baseUrl, [NullAllowed] out NSError error);

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("attributedStringByInflectingString")]
		public  extern NSAttributedString AttributedStringByInflectingString { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("boundingRectWithSize:options:")]
		public  extern CGRect BoundingRectWithSize (CGSize size, NSStringDrawingOptions options);

#if MONOMAC
		[Field ("NSTextLayoutSectionOrientation", "AppKit")]
#else
		[Field ("NSTextLayoutSectionOrientation", "UIKit")]
#endif
		public  extern NSString TextLayoutSectionOrientation { get; }

#if MONOMAC
		[Field ("NSTextLayoutSectionRange", "AppKit")]
#else
		[Field ("NSTextLayoutSectionRange", "UIKit")]
#endif
		public  extern NSString TextLayoutSectionRange { get; }

#if !XAMCORE_5_0
#if MONOMAC
		[Field ("NSTextLayoutSectionsAttribute", "AppKit")]
#else
		[Field ("NSTextLayoutSectionsAttribute", "UIKit")]
#endif
		public  extern NSString TextLayoutSectionsAttribute { get; }
#endif // !XAMCORE_5_0

		[NoiOS, NoWatch, NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[NoMacCatalyst]
		[Field ("NSUnderlineByWordMask", "AppKit")]
		public static nint UnderlineByWordMaskAttributeName { get; }

#if !XAMCORE_5_0
#if MONOMAC
		[Field ("NSTextScalingDocumentAttribute", "AppKit")]
#else
		[Field ("NSTextScalingDocumentAttribute", "UIKit")]
#endif
		[iOS (13, 0), TV (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		public  extern NSString TextScalingDocumentAttribute { get; }
#endif // !XAMCORE_5_0

#if !XAMCORE_5_0
#if MONOMAC
		[Field ("NSSourceTextScalingDocumentAttribute", "AppKit")]
#else
		[Field ("NSSourceTextScalingDocumentAttribute", "UIKit")]
#endif
		[iOS (13, 0), TV (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		public  extern NSString SourceTextScalingDocumentAttribute { get; }
#endif // !XAMCORE_5_0

#if !XAMCORE_5_0
#if MONOMAC
		[Field ("NSCocoaVersionDocumentAttribute", "AppKit")]
#else
		[Field ("NSCocoaVersionDocumentAttribute", "UIKit")]
#endif
		[iOS (13, 0), TV (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		public  extern NSString CocoaVersionDocumentAttribute { get; }
#endif // !XAMCORE_5_0

		// Inlined from the NSAttributedStringAdaptiveImageGlyphConveniences category
		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("attributedStringWithAdaptiveImageGlyph:attributes:")]
		public  extern NSAttributedString Create (NSAdaptiveImageGlyph adaptiveImageGlyph, NSDictionary<NSString, NSObject> attributes);
	}
}