// 
// UIStringAttributes.cs: Implements strongly typed access to UIKit specific part of UIStringAttributeKey
//
// Authors:
//   Marek Safar (marek.safar@gmail.com)
//   Miguel de Icaza (miguel@xamarin.com)
//     
// Copyright 2012-2013, Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

using ObjCRuntime;
using Foundation;
using CoreFoundation;
using CoreGraphics;
using CoreLibs;
using CoreText;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace UIKit {
	
	[Static]
	public static class UIStringAttributeKey {
		[Field ("NSFontAttributeName")]
		public static NSString Font { get; }

		[Field ("NSForegroundColorAttributeName")]
		public static NSString ForegroundColor { get; }

		[Field ("NSBackgroundColorAttributeName")]
		public static NSString BackgroundColor { get; }

		[Field ("NSStrokeColorAttributeName")]
		public static NSString StrokeColor { get; }

		[Field ("NSStrikethroughStyleAttributeName")]
		public static NSString StrikethroughStyle { get; }

		[Field ("NSShadowAttributeName")]
		public static NSString Shadow { get; }

		[Field ("NSParagraphStyleAttributeName")]
		public static NSString ParagraphStyle { get; }

		[Field ("NSLigatureAttributeName")]
		public static NSString Ligature { get; }

		[Field ("NSKernAttributeName")]
		public static NSString KerningAdjustment { get; }

		[Field ("NSUnderlineStyleAttributeName")]
		public static NSString UnderlineStyle { get; }

		[Field ("NSStrokeWidthAttributeName")]
		public static NSString StrokeWidth { get; }

		[Field ("NSVerticalGlyphFormAttributeName")]
		public static NSString VerticalGlyphForm { get; }

		[Field ("NSTextEffectAttributeName")]
		public static NSString TextEffect { get; }

		[Field ("NSAttachmentAttributeName")]
		public static NSString Attachment { get; }

		[Field ("NSLinkAttributeName")]
		public static NSString Link { get; }

		[Field ("NSBaselineOffsetAttributeName")]
		public static NSString BaselineOffset { get; }

		[Field ("NSUnderlineColorAttributeName")]
		public static NSString UnderlineColor { get; }

		[Field ("NSStrikethroughColorAttributeName")]
		public static NSString StrikethroughColor { get; }

		[Field ("NSObliquenessAttributeName")]
		public static NSString Obliqueness { get; }

		[Field ("NSExpansionAttributeName")]
		public static NSString Expansion { get; }

		[Field ("NSWritingDirectionAttributeName")]
		public static NSString WritingDirection { get; }

		[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSTrackingAttributeName")]
		public static NSString Tracking { get; }

		[NoTV, iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("UITextItemTagAttributeName")]
		public static NSString Name { get; }

		//
		// These are internal, if we choose to expose these, we should
		// put them on a better named class
		//
		[Internal, Field ("NSTextEffectLetterpressStyle")]
		public static NSString NSTextEffectLetterpressStyle { get; }

		// we do not seem to expose other options like NSDefaultAttributesDocumentOption so keeping these as is for now
		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Internal, Field ("NSTargetTextScalingDocumentOption")]
		public static NSString TargetTextScalingDocumentOption { get; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Internal, Field ("NSSourceTextScalingDocumentOption")]
		static NSString SourceTextScalingDocumentOption { get; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSTextHighlightStyleAttributeName")]
		static NSString TextHighlightStyle { get; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSTextHighlightColorSchemeAttributeName")]
		static NSString TextHighlightColorScheme { get; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSAdaptiveImageGlyphAttributeName")]
		static NSString AdaptiveImageGlyph { get; }

		[NoTV, Mac (15, 2), iOS (18, 2), MacCatalyst (18, 2)]
		[Field ("NSWritingToolsExclusionAttributeName")]
		static NSString WritingToolsExclusion { get; }

	}

	public class UIStringAttributes : DictionaryContainer {
#if !COREBUILD
		public UIStringAttributes ()
			: base (new NSMutableDictionary ())
		{
		}

		public UIStringAttributes (NSDictionary dictionary)
			: base (dictionary)
		{
		}

		public UIColor ForegroundColor {
			get {
				return Dictionary [UIStringAttributeKey.ForegroundColor] as UIColor;
			}
			set {
				SetNativeValue (UIStringAttributeKey.ForegroundColor, value);
			}
		}

		public UIColor BackgroundColor {
			get {
				return Dictionary [UIStringAttributeKey.BackgroundColor] as UIColor;
			}
			set {
				SetNativeValue (UIStringAttributeKey.BackgroundColor, value);
			}
		}

		public UIFont Font {
			get {
				return Dictionary [UIStringAttributeKey.Font] as UIFont;
			}
			set {
				SetNativeValue (UIStringAttributeKey.Font, value);
			}
		}

		public float? KerningAdjustment {
			get {
				return GetFloatValue (UIStringAttributeKey.KerningAdjustment);
			}
			set {
				SetNumberValue (UIStringAttributeKey.KerningAdjustment, value);
			}
		}

		public NSLigatureType? Ligature {
			get {
				var value = GetInt32Value (UIStringAttributeKey.Ligature);
				return value is null ? null : (NSLigatureType?) value.Value;
			}
			set {
				SetNumberValue (UIStringAttributeKey.Ligature, (int?) value);
			}
		}

		public NSParagraphStyle ParagraphStyle {
			get {
				return Dictionary [UIStringAttributeKey.ParagraphStyle] as NSParagraphStyle;
			}
			set {
				SetNativeValue (UIStringAttributeKey.ParagraphStyle, value);
			}
		}

		public NSUnderlineStyle? StrikethroughStyle {
			get {
				var value = GetInt32Value (UIStringAttributeKey.StrikethroughStyle);
				return value is null ? null : (NSUnderlineStyle?) value.Value;
			}
			set {
				SetNumberValue (UIStringAttributeKey.StrikethroughStyle, (int?) value);
			}
		}

		public UIColor StrokeColor {
			get {
				return Dictionary [UIStringAttributeKey.StrokeColor] as UIColor;
			}
			set {
				SetNativeValue (UIStringAttributeKey.StrokeColor, value);
			}
		}

		public float? StrokeWidth {
			get {
				return GetFloatValue (UIStringAttributeKey.StrokeWidth);
			}
			set {
				SetNumberValue (UIStringAttributeKey.StrokeWidth, value);
			}
		}

		public NSShadow Shadow {
			get {
				return Dictionary [UIStringAttributeKey.Shadow] as NSShadow;
			}
			set {
				SetNativeValue (UIStringAttributeKey.Shadow, value);
			}
		}

		public NSUnderlineStyle? UnderlineStyle {
			get {
				var value = GetInt32Value (UIStringAttributeKey.UnderlineStyle);
				return value is null ? null : (NSUnderlineStyle?) value.Value;
			}
			set {
				SetNumberValue (UIStringAttributeKey.UnderlineStyle, (int?) value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public NSString WeakTextEffect {
			get {
				return Dictionary [UIStringAttributeKey.TextEffect] as NSString;
			}
			set {
				SetStringValue (UIStringAttributeKey.TextEffect, value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public NSTextEffect TextEffect {
			get {
				var s = WeakTextEffect;
				if (s is null)
					return NSTextEffect.None;

				if (s == UIStringAttributeKey.NSTextEffectLetterpressStyle)
					return NSTextEffect.LetterPressStyle;
				return NSTextEffect.UnknownUseWeakEffect;
			}
			set {
				if (value == NSTextEffect.LetterPressStyle)
					SetStringValue (UIStringAttributeKey.TextEffect, UIStringAttributeKey.NSTextEffectLetterpressStyle);
				else
					SetStringValue (UIStringAttributeKey.TextEffect, (NSString) null);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public NSTextAttachment TextAttachment {
			get {
				return Dictionary [UIStringAttributeKey.Attachment] as NSTextAttachment;
			}
			set {
				SetNativeValue (UIStringAttributeKey.Attachment, value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public NSUrl Link {
			get {
				return Dictionary [UIStringAttributeKey.Link] as NSUrl;
			}
			set {
				SetNativeValue (UIStringAttributeKey.Link, value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public float? BaselineOffset {
			get {
				return GetFloatValue (UIStringAttributeKey.BaselineOffset);
			}
			set {
				SetNumberValue (UIStringAttributeKey.BaselineOffset, value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public UIColor StrikethroughColor {
			get {
				return Dictionary [UIStringAttributeKey.StrikethroughColor] as UIColor;
			}
			set {
				SetNativeValue (UIStringAttributeKey.StrikethroughColor, value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public UIColor UnderlineColor {
			get {
				return Dictionary [UIStringAttributeKey.UnderlineColor] as UIColor;
			}
			set {
				SetNativeValue (UIStringAttributeKey.UnderlineColor, value);
			}
		}


#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public float? Obliqueness {
			get {
				return GetFloatValue (UIStringAttributeKey.Obliqueness);
			}
			set {
				SetNumberValue (UIStringAttributeKey.Obliqueness, value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public float? Expansion {
			get {
				return GetFloatValue (UIStringAttributeKey.Expansion);
			}
			set {
				SetNumberValue (UIStringAttributeKey.Expansion, value);
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
#endif
		public NSNumber [] WritingDirectionInt {
			get {
				return GetArray<NSNumber> (UIStringAttributeKey.WritingDirection);
			}
			set {
				SetArrayValue (UIStringAttributeKey.WritingDirection, value);
			}
		}
#endif
	}
}
