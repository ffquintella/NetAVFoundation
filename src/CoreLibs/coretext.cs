//
// coretext.cs: Definitions for CoreText
//
// Authors: 
//  Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2014 Xamarin Inc.
//

using System;

using CoreGraphics;
using CoreLibs;
using Foundation;
using ObjCRuntime;

namespace CoreText {

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTFontFeatures" />.</summary>
	[Static]
	public static class CTFontFeatureKey {
		[Field ("kCTFontFeatureTypeIdentifierKey")]
		public static extern NSString Identifier { get; }

		[Field ("kCTFontFeatureTypeNameKey")]
		public static extern NSString Name { get; }

		[Field ("kCTFontFeatureTypeExclusiveKey")]
		public static extern NSString Exclusive { get; }

		[Field ("kCTFontFeatureTypeSelectorsKey")]
		public static extern NSString Selectors { get; }
	}

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTFontFeatureSelectors" />.</summary>
	[Static]
	public static class CTFontFeatureSelectorKey {
		[Field ("kCTFontFeatureSelectorIdentifierKey")]
		public static extern NSString Identifier { get; }

		[Field ("kCTFontFeatureSelectorNameKey")]
		public static extern NSString Name { get; }

		[Field ("kCTFontFeatureSelectorDefaultKey")]
		public static extern NSString Default { get; }

		[Field ("kCTFontFeatureSelectorSettingKey")]
		public static extern NSString Setting { get; }

		[iOS (13, 0), TV (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCTFontFeatureSampleTextKey")]
		public static extern NSString SampleText { get; }

		[iOS (13, 0), TV (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCTFontFeatureTooltipTextKey")]
		public static extern NSString TooltipText { get; }
	}

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTFontVariationAxes" />.</summary>
	[Static]
	public static class CTFontVariationAxisKey {

		[Field ("kCTFontVariationAxisIdentifierKey")]
		public static extern NSString Identifier { get; }

		[Field ("kCTFontVariationAxisMinimumValueKey")]
		public static extern NSString MinimumValue { get; }

		[Field ("kCTFontVariationAxisMaximumValueKey")]
		public static extern NSString MaximumValue { get; }

		[Field ("kCTFontVariationAxisDefaultValueKey")]
		public static extern NSString DefaultValue { get; }

		[Field ("kCTFontVariationAxisNameKey")]
		public static extern NSString Name { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCTFontVariationAxisHiddenKey")]
		public static extern NSString Hidden { get; }
	}

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTTypesetterOptions" />.</summary>
	[Static]
	public static class CTTypesetterOptionKey {

		//[Deprecated (PlatformName.iOS, 6, 0)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Field ("kCTTypesetterOptionDisableBidiProcessing")]
#if !NET
		[Internal]
		NSString _DisableBidiProcessing { get; }
#else
		public static extern NSString DisableBidiProcessing { get; }
#endif

		[Field ("kCTTypesetterOptionForcedEmbeddingLevel")]
#if !NET
		[Internal]
		NSString _ForceEmbeddingLevel { get; }
#else
		public static extern NSString ForceEmbeddingLevel { get; }
#endif

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCTTypesetterOptionAllowUnboundedLayout")]
		public static extern NSString AllowUnboundedLayout { get; }
	}

	[Static]
	interface CTFontManagerErrorKeys {
		[Field ("kCTFontManagerErrorFontURLsKey")]
		NSString FontUrlsKey { get; }

		[NoWatch, NoTV, NoMac, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCTFontManagerErrorFontDescriptorsKey")]
		NSString FontDescriptorsKey { get; }

		[NoWatch, NoTV, NoMac, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCTFontManagerErrorFontAssetNameKey")]
		NSString FontAssetNameKey { get; }
	}

#if NET
	[Internal]
	[Static][Partial]
	internal static partial class CTBaselineClassID {
		[Field ("kCTBaselineClassRoman")]
		public static extern NSString Roman { get; }

		[Field ("kCTBaselineClassIdeographicCentered")]
		public static extern NSString IdeographicCentered { get; }

		[Field ("kCTBaselineClassIdeographicLow")]
		public static extern NSString IdeographicLow { get; }

		[Field ("kCTBaselineClassIdeographicHigh")]
		public static extern NSString IdeographicHigh { get; }

		[Field ("kCTBaselineClassHanging")]
		public static extern NSString Hanging { get; }

		[Field ("kCTBaselineClassMath")]
		public static extern NSString Math { get; }
	}

	[Internal]
	[Static][Partial]
	internal static partial class CTBaselineFontID {
		[Field ("kCTBaselineReferenceFont")]
		public static extern NSString Reference { get; }

		[Field ("kCTBaselineOriginalFont")]
		public static extern NSString Original { get; }
	}

	/// <summary>A valid key for use with <see cref="T:CoreText.CTFontDescriptor" /> attribute properties.</summary>
	[Static]
	public static class CTFontDescriptorAttributeKey {
		[Field ("kCTFontURLAttribute")]
		public static extern NSString Url { get; }

		[Field ("kCTFontNameAttribute")]
		public static extern NSString Name { get; }

		[Field ("kCTFontDisplayNameAttribute")]
		public static extern NSString DisplayName { get; }

		[Field ("kCTFontFamilyNameAttribute")]
		public static extern NSString FamilyName { get; }

		[Field ("kCTFontStyleNameAttribute")]
		public static extern NSString StyleName { get; }

		[Field ("kCTFontTraitsAttribute")]
		public static extern NSString Traits { get; }

		[Field ("kCTFontVariationAttribute")]
		public static extern NSString Variation { get; }

		[Field ("kCTFontSizeAttribute")]
		public static extern NSString Size { get; }

		[Field ("kCTFontMatrixAttribute")]
		public static extern NSString Matrix { get; }

		[Field ("kCTFontCascadeListAttribute")]
		public static extern NSString CascadeList { get; }

		[Field ("kCTFontCharacterSetAttribute")]
		public static extern NSString CharacterSet { get; }

		[Field ("kCTFontLanguagesAttribute")]
		public static extern NSString Languages { get; }

		[Field ("kCTFontBaselineAdjustAttribute")]
		public static extern NSString BaselineAdjust { get; }

		[Field ("kCTFontMacintoshEncodingsAttribute")]
		public static extern NSString MacintoshEncodings { get; }

		[Field ("kCTFontFeaturesAttribute")]
		public static extern NSString Features { get; }

		[Field ("kCTFontFeatureSettingsAttribute")]
		public static extern NSString FeatureSettings { get; }

		[Field ("kCTFontFixedAdvanceAttribute")]
		public static extern NSString FixedAdvance { get; }

		[Field ("kCTFontOrientationAttribute")]
		public static extern NSString FontOrientation { get; }

		[Field ("kCTFontFormatAttribute")]
		public static extern NSString FontFormat { get; }

		[Field ("kCTFontRegistrationScopeAttribute")]
		public static extern NSString RegistrationScope { get; }

		[Field ("kCTFontPriorityAttribute")]
		public static extern NSString Priority { get; }

		[Field ("kCTFontEnabledAttribute")]
		public static extern NSString Enabled { get; }

		[iOS (13, 0), NoTV, NoWatch, MacCatalyst (13, 1), NoMac]
		[Field ("kCTFontRegistrationUserInfoAttribute")]
		public static extern NSString RegistrationUserInfo { get; }
	}

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTTextTabOptions" />.</summary>
	[Static]
	public static class CTTextTabOptionKey {
		[Field ("kCTTabColumnTerminatorsAttributeName")]
		public static extern NSString ColumnTerminators { get; }
	}

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTFrameAttributes" />.</summary>
	[Static]
	public static class CTFrameAttributeKey {
		[Field ("kCTFrameProgressionAttributeName")]
		public static extern NSString Progression { get; }

		[Field ("kCTFramePathFillRuleAttributeName")]
		public static extern NSString PathFillRule { get; }

		[Field ("kCTFramePathWidthAttributeName")]
		public static extern NSString PathWidth { get; }

		[Field ("kCTFrameClippingPathsAttributeName")]
		public static extern NSString ClippingPaths { get; }

		[Field ("kCTFramePathClippingPathAttributeName")]
		public static extern NSString PathClippingPath { get; }
	}

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTFontTraits" />.</summary>
	[Static]
	public static class  CTFontTraitKey {
		[Field ("kCTFontSymbolicTrait")]
		public static extern NSString Symbolic { get; }

		[Field ("kCTFontWeightTrait")]
		public static extern NSString Weight { get; }

		[Field ("kCTFontWidthTrait")]
		public static extern NSString Width { get; }

		[Field ("kCTFontSlantTrait")]
		public static extern NSString Slant { get; }
	}

	[Internal]
	[Static][Partial]
	internal static partial class CTFontNameKeyId {
		[Field ("kCTFontCopyrightNameKey")]
		internal static extern NSString Copyright { get; }

		[Field ("kCTFontFamilyNameKey")]
		internal static extern NSString Family { get; }

		[Field ("kCTFontSubFamilyNameKey")]
		internal static extern NSString SubFamily { get; }

		[Field ("kCTFontStyleNameKey")]
		internal static extern NSString Style { get; }

		[Field ("kCTFontUniqueNameKey")]
		internal static extern NSString Unique { get; }

		[Field ("kCTFontFullNameKey")]
		internal static extern NSString Full { get; }

		[Field ("kCTFontVersionNameKey")]
		internal static extern NSString Version { get; }

		[Field ("kCTFontPostScriptNameKey")]
		internal static extern NSString PostScript { get; }

		[Field ("kCTFontTrademarkNameKey")]
		internal static extern NSString Trademark { get; }

		[Field ("kCTFontManufacturerNameKey")]
		internal static extern NSString Manufacturer { get; }

		[Field ("kCTFontDesignerNameKey")]
		internal static extern NSString Designer { get; }

		[Field ("kCTFontDescriptionNameKey")]
		internal static extern NSString Description { get; }

		[Field ("kCTFontVendorURLNameKey")]
		internal static extern NSString VendorUrl { get; }

		[Field ("kCTFontDesignerURLNameKey")]
		internal static extern NSString DesignerUrl { get; }

		[Field ("kCTFontLicenseNameKey")]
		internal static extern NSString License { get; }

		[Field ("kCTFontLicenseURLNameKey")]
		internal static extern NSString LicenseUrl { get; }

		[Field ("kCTFontSampleTextNameKey")]
		internal static extern NSString SampleText { get; }

		[Field ("kCTFontPostScriptCIDNameKey")]
		internal static extern NSString PostscriptCid { get; }
	}

	/// <summary>A class whose static property can be used as a key for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTFontCollectionOptions" />.</summary>
	[Static]
	public static class CTFontCollectionOptionKey {
		[Field ("kCTFontCollectionRemoveDuplicatesOption")]
		public static extern NSString RemoveDuplicates { get; }
	}
#endif

	[Internal]
	[Static]
	interface CTFontDescriptorMatchingKeys {
		[Field ("kCTFontDescriptorMatchingSourceDescriptor")]
		NSString SourceDescriptorKey { get; }

		[Field ("kCTFontDescriptorMatchingDescriptors")]
		NSString DescriptorsKey { get; }

		[Field ("kCTFontDescriptorMatchingResult")]
		NSString ResultKey { get; }

		[Field ("kCTFontDescriptorMatchingPercentage")]
		NSString PercentageKey { get; }

		[Field ("kCTFontDescriptorMatchingCurrentAssetSize")]
		NSString CurrentAssetSizeKey { get; }

		[Field ("kCTFontDescriptorMatchingTotalDownloadedSize")]
		NSString TotalDownloadedSizeKey { get; }

		[Field ("kCTFontDescriptorMatchingTotalAssetSize")]
		NSString TotalAssetSizeKey { get; }

		[Field ("kCTFontDescriptorMatchingError")]
		NSString ErrorKey { get; }
	}

	//[StrongDictionary ("CTFontDescriptorMatchingKeys")]
	public class  CTFontDescriptorMatchingProgress: DictionaryContainer {
		
		public CTFontDescriptorMatchingProgress(): base(){}
		public CTFontDescriptorMatchingProgress (NSDictionary dictionary) : base (dictionary) {}
		
		public CTFontDescriptor SourceDescriptor { get; }
		public CTFontDescriptor [] Descriptors { get; }
		public CTFontDescriptor [] Result { get; }
		public double Percentage { get; }
		public long CurrentAssetSize { get; }
		public long TotalDownloadedSize { get; }
		public long TotalAssetSize { get; }
		public NSError Error { get; }
	}

	/// <summary>A class whose static properties can be used as keys for the <see cref="T:Foundation.NSDictionary" /> used by <see cref="T:CoreText.CTStringAttributes" />.</summary>
	[Static]
	[Partial]
	public static partial class  CTStringAttributeKey {
#if NET
		[Field ("kCTFontAttributeName")]
		public static extern NSString Font { get; }

		[Field ("kCTForegroundColorFromContextAttributeName")]
		public static extern NSString ForegroundColorFromContext { get; }

		[Field ("kCTKernAttributeName")]
		public static extern NSString KerningAdjustment { get; }

		[Field ("kCTLigatureAttributeName")]
		public static extern NSString LigatureFormation { get; }

		[Field ("kCTForegroundColorAttributeName")]
		public static extern NSString ForegroundColor { get; }

		[Field ("kCTBackgroundColorAttributeName")]
		public static extern NSString BackgroundColor { get; }

		[Field ("kCTParagraphStyleAttributeName")]
		public static extern NSString ParagraphStyle { get; }

		[Field ("kCTStrokeWidthAttributeName")]
		public static extern NSString StrokeWidth { get; }

		[Field ("kCTStrokeColorAttributeName")]
		public static extern NSString StrokeColor { get; }

		[Field ("kCTUnderlineStyleAttributeName")]
		public static extern NSString UnderlineStyle { get; }

		[Field ("kCTSuperscriptAttributeName")]
		public static extern NSString Superscript { get; }

		[Field ("kCTUnderlineColorAttributeName")]
		public static extern NSString UnderlineColor { get; }

		[Field ("kCTVerticalFormsAttributeName")]
		public static extern NSString VerticalForms { get; }

		[Field ("kCTHorizontalInVerticalFormsAttributeName")]
		public static extern NSString HorizontalInVerticalForms { get; }

		[Field ("kCTGlyphInfoAttributeName")]
		public static extern NSString GlyphInfo { get; }

		[Field ("kCTCharacterShapeAttributeName")]
		public static extern NSString CharacterShape { get; }

		[Field ("kCTRunDelegateAttributeName")]
		public static extern NSString RunDelegate { get; }

		[Field ("kCTBaselineOffsetAttributeName")]
		public static extern NSString BaselineOffset { get; }

		[Field ("kCTBaselineClassAttributeName")]
		public static extern NSString BaselineClass { get; }

		[Field ("kCTBaselineInfoAttributeName")]
		public static extern NSString BaselineInfo { get; }

		[Field ("kCTBaselineReferenceInfoAttributeName")]
		public static extern NSString BaselineReferenceInfo { get; }

		[Field ("kCTWritingDirectionAttributeName")]
		public static extern NSString WritingDirection { get; }

		[Field ("kCTRubyAnnotationAttributeName")]
		public static extern NSString RubyAnnotation { get; }

		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCTAdaptiveImageProviderAttributeName")]
		public static extern NSString AdaptiveImageProvider { get; }
#endif

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCTTrackingAttributeName")]
		public static extern NSString TrackingAttributeName { get; }
	}

	[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[Protocol (BackwardsCompatibleCodeGeneration = false)]
	interface CTAdaptiveImageProviding {
		[Abstract]
		[Export ("imageForProposedSize:scaleFactor:imageOffset:imageSize:")]
		[return: NullAllowed]
		CGImage GetImage (CGSize proposedSize, nfloat scaleFactor, out CGPoint imageOffset, out CGSize imageSize);
	}
}
