//
// NSAttributedStringDocumentAttributes.cs
//
// Authors:
//   Rolf Bjarne Kvinge (rolf@xamarin.com)
//
// Copyright 2022 Microsoft Corp

#nullable enable

using System;
using System.ComponentModel;
using AppKit;

#if HAS_APPKIT
using AppKit;
#endif
using CoreGraphics;
using CoreLibs;
using Foundation;
#if HAS_UIKIT
using UIKit;
#endif
#if !COREBUILD && HAS_WEBKIT
using WebKit;
#endif
using ObjCRuntime;
using UIKit;
//using WebKit;

#if !COREBUILD
#if __MACOS__
using XColor = AppKit.NSColor;
#else
using XColor = UIKit.UIColor;
#endif
#endif

namespace Foundation {
	public partial class NSAttributedStringDocumentAttributes : DictionaryContainer {
#if !COREBUILD
		public NSString? WeakDocumentType {
			get {
				return GetNSStringValue (NSAttributedStringDocumentAttributeKey.DocumentTypeDocumentAttribute);
			}
			set {
				SetStringValue (NSAttributedStringDocumentAttributeKey.DocumentTypeDocumentAttribute, value);
			}
		}

#if !XAMCORE_5_0
		[EditorBrowsable (EditorBrowsableState.Never)]
		[Obsolete ("Use 'CharacterEncoding' instead.")]
		public NSStringEncoding? StringEncoding {
			get {
				return CharacterEncoding;
			}
			set
			{
				if (value is not null) CharacterEncoding = value.Value;
				else CharacterEncoding = new NSStringEncoding();
			}
		}
#endif // !XAMCORE_5_0

#if !XAMCORE_5_0
		public NSDocumentType DocumentType {
			get
			{
				throw new NotImplementedException();
				//return (NSDocumentType) NSAttributedStringDocumentTypeExtensions.GetValue (WeakDocumentType);
			}
			set
			{
				throw new NotImplementedException();
				//WeakDocumentType = ((NSAttributedStringDocumentType) value).GetConstant ();
			}
		}
#endif // !XAMCORE_5_0

		public NSDictionary? WeakDefaultAttributes {
			get {
				return GetNativeValue<NSDictionary> (NSAttributedStringDocumentAttributeKey.DefaultAttributesDocumentAttribute);
			}
			set {
				SetNativeValue (NSAttributedStringDocumentAttributeKey.DefaultAttributesDocumentAttribute, value);
			}
		}

#if XAMCORE_5_0 || __MACOS__
		public bool? ReadOnly {
			get {
				var value = GetInt32Value (NSAttributedStringDocumentAttributeKey.ReadOnlyDocumentAttribute);
				if (value is null)
					return null;
				return value.Value == 1;
			}
			set {
				SetNumberValue (NSAttributedStringDocumentAttributeKey.ReadOnlyDocumentAttribute, value is null ? null : (value.Value ? 1 : 0));
			}
		}
#else
		public bool ReadOnly {
			get {
				var value = GetInt32Value (NSAttributedStringDocumentAttributeKey.ReadOnlyDocumentAttribute);
				if (value is null || value.Value != 1)
					return false;
				return true;
			}
			set {
				SetNumberValue (NSAttributedStringDocumentAttributeKey.ReadOnlyDocumentAttribute, value ? 1 : 0);
			}
		}
#endif // XAMCORE_5_0 || __MACOS__

#if !TVOS && !WATCH
		// documentation is unclear if an NSString or an NSUrl should be used...
		// but providing an `NSString` throws a `NSInvalidArgumentException Reason: (null) is not a file URL`
#if NET
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("ios13.0")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
#else
		[iOS (13, 0)]
#endif
		public NSUrl? ReadAccessUrl {
			get {
				return GetNativeValue<NSUrl> (NSAttributedStringDocumentReadingOptionKey.ReadAccessUrlDocumentOption);
			}
			set {
				SetNativeValue (NSAttributedStringDocumentReadingOptionKey.ReadAccessUrlDocumentOption, value);
			}
		}
#endif // !TVOS && !WATCH
/*
#if __MACOS__
#if NET
		[UnsupportedOSPlatform ("ios")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
#endif // NET
		public WebPreferences? WebPreferences {
			get {
				return GetNativeValue<WebPreferences> (NSAttributedStringDocumentReadingOptionKey.WebPreferencesDocumentOption);
			}
			set {
				SetNativeValue (NSAttributedStringDocumentReadingOptionKey.WebPreferencesDocumentOption, value);
			}
		}
#endif // !__MACOS__
*/
#if __MACOS__
#if NET
		[UnsupportedOSPlatform ("ios")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
#endif // NET
		public NSObject? WebResourceLoadDelegate {
			get {
				return GetNativeValue<NSObject> (NSAttributedStringDocumentReadingOptionKey.WebResourceLoadDelegateDocumentOption);
			}
			set {
				SetNativeValue (NSAttributedStringDocumentReadingOptionKey.WebResourceLoadDelegateDocumentOption, value);
			}
		}
#endif // !__MACOS__

#if __MACOS__
#if NET
		[UnsupportedOSPlatform ("ios")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
#endif // NET
		public NSUrl? BaseUrl {
			get {
				return GetNativeValue<NSUrl> (NSAttributedStringDocumentReadingOptionKey.BaseUrlDocumentOption);
			}
			set {
				SetNativeValue (NSAttributedStringDocumentReadingOptionKey.BaseUrlDocumentOption, value);
			}
		}
#endif // !__MACOS__

#if __MACOS__
#if NET
		[UnsupportedOSPlatform ("ios")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
#endif // NET
		public float? TextSizeMultiplier {
			get {
				return GetFloatValue (NSAttributedStringDocumentReadingOptionKey.TextSizeMultiplierDocumentOption);
			}
			set {
				SetNumberValue (NSAttributedStringDocumentReadingOptionKey.TextSizeMultiplierDocumentOption, value);
			}
		}
#endif // !__MACOS__

#if __MACOS__
#if NET
		[UnsupportedOSPlatform ("ios")]
		[UnsupportedOSPlatform ("tvos")]
		[UnsupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
#endif // NET
		public float? Timeout {
			get {
				return GetFloatValue (NSAttributedStringDocumentReadingOptionKey.TimeoutDocumentOption);
			}
			set {
				SetNumberValue (NSAttributedStringDocumentReadingOptionKey.TimeoutDocumentOption, value);
			}
		}
#endif // !__MACOS__

#endif // !COREBUILD
	}
	
	//[StrongDictionary (nameof (NSAttributedStringDocumentAttributeKey), Suffix = "DocumentAttribute")]
	partial class NSAttributedStringDocumentAttributes {
		// Wait with this one until XAMCORE_5_0, using the strong dictionary logic would be an API break.
#if XAMCORE_5_0
		NSAttributedStringDocumentType DocumentType { get; set; }
#endif

		public NSStringEncoding CharacterEncoding { get; set; }

		NSAttributedStringDocumentAttributes DefaultAttributes { get; set; }

		CGSize PaperSize { get; set; }

		//[NoMac]
		//UIEdgeInsets PaperMargin { get; set; }

		CGSize ViewSize { get; set; }

		float ViewZoom { get; set; }

		NSDocumentViewMode ViewMode { get; set; }

		// The definition for this boolean is very specific in the header file:
		// "NSNumber containing integer; if missing, or 0 or negative, not readonly; 1 or more, readonly"
		// So keep the manual code, the generic strong dictionary logic is slightly different.
		// #if XAMCORE_5_0
		// bool? ReadOnly { get; set; }
		// #else
		// bool ReadOnly { get; set; }
		// #endif

		NSColor BackgroundColor { get; set; }

		float HyphenationFactor {
			get;
			[PreSnippet ("if (value < 0 || value > 1.0f) throw new ArgumentOutOfRangeException (nameof (value), value, \"Value must be between 0 and 1\");")]
			set;
		}

		float DefaultTabInterval {
			get;
			[PreSnippet ("if (value < 0 || value > 1.0f) throw new ArgumentOutOfRangeException (nameof (value), value, \"Value must be between 0 and 1\");")]
			set;
		}

		// This would need a custom binding, it's an array of another strong dictionary.
		// [Export ("TextLayoutSectionsAttribute")]
		// NSTextLayoutSection[] TextLayout { get; set; }

		//[iOS (13, 0)]
		NSTextScalingType TextScaling { get; set; }

		//[iOS (13, 0)]
		NSTextScalingType SourceTextScaling { get; set; }

		//[iOS (13, 0)]
		float CocoaVersion { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		int Converted { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string FileType { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Title { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Company { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Copyright { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Subject { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Author { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string [] Keywords { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Comment { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Editor { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		NSDate CreationTime { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		NSDate ModificationTime { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Manager { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string Category { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		NSAppearance Appearance { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		float LeftMargin { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		float RightMargin { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		float TopMargin { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		float BottomMargin { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string [] ExcludedElements { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		string TextEncodingName { get; set; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		int PrefixSpaces { get; set; }
	}
}
