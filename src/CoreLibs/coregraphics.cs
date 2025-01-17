//
// coregraphics.cs: Definitions for CoreGraphics
//
// Copyright 2014 Xamarin Inc. All rights reserved.
//

using System;
using Foundation;
using ObjCRuntime;

namespace CoreGraphics {

	//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	public enum CGToneMapping : uint {
		Default = 0,
		ImageSpecificLumaScaling,
		ReferenceWhiteBased,
		IturRecommended,
		ExrGamma,
		None,
	}

	/// <summary>Specifies various boxes for the <see cref="M:CoreGraphics.CGContextPDF.BeginPage(CoreGraphics.CGPDFPageInfo)" /> method.</summary>
	[Partial]
	public partial class CGPDFPageInfo {

		[Internal]
		[Field ("kCGPDFContextMediaBox")]
		public extern IntPtr kCGPDFContextMediaBox { get; }

		[Internal]
		[Field ("kCGPDFContextCropBox")]
		public extern IntPtr kCGPDFContextCropBox { get; }

		[Internal]
		[Field ("kCGPDFContextBleedBox")]
		public extern IntPtr kCGPDFContextBleedBox { get; }

		[Internal]
		[Field ("kCGPDFContextTrimBox")]
		public extern IntPtr kCGPDFContextTrimBox { get; }

		[Internal]
		[Field ("kCGPDFContextArtBox")]
		public extern IntPtr kCGPDFContextArtBox { get; }
	}

	/// <summary>Auxiliary parameters for constructing a <see cref="T:CoreGraphics.CGContextPDF" />.</summary>
	[Partial]
	public partial class CGPDFInfo {

		[Internal]
		[Field ("kCGPDFContextTitle")]
		public extern IntPtr kCGPDFContextTitle { get; }

		[Internal]
		[Field ("kCGPDFContextAuthor")]
		public extern IntPtr kCGPDFContextAuthor { get; }

		[Internal]
		[Field ("kCGPDFContextSubject")]
		public extern IntPtr kCGPDFContextSubject { get; }

		[Internal]
		[Field ("kCGPDFContextKeywords")]
		public extern IntPtr kCGPDFContextKeywords { get; }

		[Internal]
		[Field ("kCGPDFContextCreator")]
		public extern IntPtr kCGPDFContextCreator { get; }

		[Internal]
		[Field ("kCGPDFContextOwnerPassword")]
		public extern IntPtr kCGPDFContextOwnerPassword { get; }

		[Internal]
		[Field ("kCGPDFContextUserPassword")]
		public extern IntPtr kCGPDFContextUserPassword { get; }

		[Internal]
		[Field ("kCGPDFContextEncryptionKeyLength")]
		public extern IntPtr kCGPDFContextEncryptionKeyLength { get; }

		[Internal]
		[Field ("kCGPDFContextAllowsPrinting")]
		public extern IntPtr kCGPDFContextAllowsPrinting { get; }

		[Internal]
		[Field ("kCGPDFContextAllowsCopying")]
		public extern IntPtr kCGPDFContextAllowsCopying { get; }

#if false
		kCGPDFContextOutputIntent;
		kCGPDFXOutputIntentSubtype;
		kCGPDFXOutputConditionIdentifier;
		kCGPDFXOutputCondition;
		kCGPDFXRegistryName;
		kCGPDFXInfo;
		kCGPDFXDestinationOutputProfile;
		kCGPDFContextOutputIntents;
#endif

		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCGPDFContextAccessPermissions")]
		public extern IntPtr kCGPDFContextAccessPermissions { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Internal]
		[Field ("kCGPDFContextCreateLinearizedPDF")]
		public extern IntPtr kCGPDFContextCreateLinearizedPDF { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Internal]
		[Field ("kCGPDFContextCreatePDFA")]
		public extern IntPtr kCGPDFContextCreatePDFA { get; }
	}

	/// <summary>Provides string constants whose values are known color spaces.</summary>
	[Static]
	[MacCatalyst (13, 1)]
	public static class CGColorSpaceNames {
		[Field ("kCGColorSpaceGenericGray")]
		public static extern NSString GenericGray { get; }

		[Field ("kCGColorSpaceGenericRGB")]
		public static extern NSString GenericRgb { get; }

		[Field ("kCGColorSpaceGenericCMYK")]
		public static extern NSString GenericCmyk { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceDisplayP3")]
		public static extern NSString DisplayP3 { get; }

		[Field ("kCGColorSpaceGenericRGBLinear")]
		public static extern NSString GenericRgbLinear { get; }

		[Field ("kCGColorSpaceAdobeRGB1998")]
		public static extern NSString AdobeRgb1998 { get; }

		[Field ("kCGColorSpaceSRGB")]
		public static extern NSString Srgb { get; }

		[Field ("kCGColorSpaceGenericGrayGamma2_2")]
		public static extern NSString GenericGrayGamma2_2 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceGenericXYZ")]
		public static extern NSString GenericXyz { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceACESCGLinear")]
		public static extern NSString AcesCGLinear { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceITUR_709")]
		public static extern NSString ItuR_709 { get; }

		//[Mac (12, 1), iOS (15, 2), TV (15, 2), Watch (8, 3)]
		[MacCatalyst (15, 2)]
		[Field ("kCGColorSpaceITUR_709_PQ")]
		public static extern NSString ItuR_709_PQ { get; }

		//[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0), Watch (9, 0)]
		[Field ("kCGColorSpaceITUR_709_HLG")]
		public static extern NSString ItuR_709_Hlg { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceITUR_2020")]
		public static extern NSString ItuR_2020 { get; }

		//[Mac (12, 1), iOS (15, 2), TV (15, 2), Watch (8, 3)]
		[MacCatalyst (15, 2)]
		[Field ("kCGColorSpaceITUR_2020_sRGBGamma")]
		public static extern NSString ItuR_2020_sRgbGamma { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceROMMRGB")]
		public static extern NSString RommRgb { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceDCIP3")]
		public static extern NSString Dcip3 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceExtendedSRGB")]
		public static extern NSString ExtendedSrgb { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceLinearSRGB")]
		public static extern NSString LinearSrgb { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceExtendedLinearSRGB")]
		public static extern NSString ExtendedLinearSrgb { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceExtendedGray")]
		public static extern NSString ExtendedGray { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceLinearGray")]
		public static extern NSString LinearGray { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceExtendedLinearGray")]
		public static extern NSString ExtendedLinearGray { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Now accessible as GenericCmyk.")]
		[Field ("kCGColorSpaceGenericCMYK")]
		public static extern NSString GenericCMYK { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Now accessible as AdobeRgb1998.")]
		[Field ("kCGColorSpaceAdobeRGB1998")]
		public static extern NSString AdobeRGB1998 { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Now accessible as Srgb.")]
		[Field ("kCGColorSpaceSRGB")]
		public static extern NSString SRGB { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Now accessible as GenericRgb.")]
		[Field ("kCGColorSpaceGenericRGB")]
		public static extern NSString GenericRGB { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Now accessible as GenericRgb.")]
		[Field ("kCGColorSpaceGenericRGBLinear")]
		public static extern NSString GenericRGBLinear { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceGenericLab")]
		public static extern NSString GenericLab { get; }

		//[iOS (12, 3)]
		[TV (12, 3)]
		[Watch (5, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceExtendedLinearITUR_2020")]
		public static extern NSString ExtendedLinearItur_2020 { get; }

		//[iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGColorSpaceExtendedITUR_2020")]
		public static extern NSString ExtendedItur_2020 { get; }

		//[iOS (12, 3)]
		[TV (12, 3)]
		[Watch (5, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceExtendedLinearDisplayP3")]
		public static extern NSString ExtendedLinearDisplayP3 { get; }

		//[iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGColorSpaceExtendedDisplayP3")]
		public static extern NSString ExtendedDisplayP3 { get; }

		[Watch (5, 0)]
		[Deprecated (PlatformName.MacOSX, 10, 15, 4, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.iOS, 13, 4, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.TvOS, 13, 4, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.WatchOS, 6, 2, message: "Use 'Itur_2100_PQ' instead.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Itur_2100_PQ' instead.")]
		[Field ("kCGColorSpaceITUR_2020_PQ_EOTF")]
		public static extern NSString Itur_2020_PQ_Eotf { get; }

		//[iOS (13, 4), TV (13, 4), Watch (6, 2)]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.iOS, 14, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.TvOS, 14, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.WatchOS, 7, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 14, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Field ("kCGColorSpaceITUR_2020_PQ")]
		public static extern NSString Itur_2020_PQ { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Deprecated (PlatformName.MacOSX, 10, 15, 4)]
		[Deprecated (PlatformName.iOS, 13, 4)]
		[Deprecated (PlatformName.TvOS, 13, 4)]
		[Deprecated (PlatformName.WatchOS, 6, 2)]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Field ("kCGColorSpaceDisplayP3_PQ_EOTF")]
		public static extern NSString DisplayP3_PQ_Eotf { get; }

		//[iOS (13, 4), TV (13, 4), Watch (6, 2)]
		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceDisplayP3_PQ")]
		public static extern NSString DisplayP3_PQ { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGColorSpaceDisplayP3_HLG")]
		public static extern NSString DisplayP3_Hlg { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.iOS, 14, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.TvOS, 14, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Deprecated (PlatformName.WatchOS, 7, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 14, 0, message: "Use 'Itur_2100_PQ' instead.")]
		[Field ("kCGColorSpaceITUR_2020_HLG")]
		public static extern NSString Itur_2020_Hlg { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGColorSpaceITUR_2100_HLG")]
		public static extern NSString Itur_2100_Hlg { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGColorSpaceITUR_2100_PQ")]
		public static extern NSString Itur_2100_PQ { get; }

		//[iOS (15, 0), TV (15, 0), Watch (8, 0), MacCatalyst (15, 0)]
		[Field ("kCGColorSpaceExtendedRange")]
		public static extern NSString ExtendedRange { get; }

		//[iOS (15, 0), TV (15, 0), Watch (8, 0), MacCatalyst (15, 0)]
		[Field ("kCGColorSpaceLinearDisplayP3")]
		public static extern NSString LinearDisplayP3 { get; }

		//[iOS (15, 0), TV (15, 0), Watch (8, 0), MacCatalyst (15, 0)]
		[Field ("kCGColorSpaceLinearITUR_2020")]
		public static extern NSString LinearItur_2020 { get; }

		//[Mac (15, 0), iOS (18, 0), TV (18, 0), Watch (11, 0), MacCatalyst (18, 0)]
		[Field ("kCGColorSpaceCoreMedia709")]
		public static extern NSString CoreMedia709 { get; }
	}

	[Partial]
	partial class CGColorConversionInfo {

		[Internal]
		[Field ("kCGColorConversionBlackPointCompensation")]
		public extern NSString BlackPointCompensationKey { get; }

		[Internal]
		[Field ("kCGColorConversionTRCSize")]
		[MacCatalyst (13, 1)]
		extern NSString TrcSizeKey { get; }
	}

	[MacCatalyst (13, 1)]
	//[StrongDictionary ("CGColorConversionInfo")]
	public class CGColorConversionOptions: DictionaryContainer {
		bool BlackPointCompensation { get; set; }
		CGSize TrcSize { get; set; }
	}

	[MacCatalyst (13, 1)]
	[Static]
	[Internal]
	public interface CGPDFOutlineKeys {
		[Internal]
		[Field ("kCGPDFOutlineTitle")]
		NSString OutlineTitleKey { get; }

		[Internal]
		[Field ("kCGPDFOutlineChildren")]
		NSString OutlineChildrenKey { get; }

		[Internal]
		[Field ("kCGPDFOutlineDestination")]
		NSString OutlineDestinationKey { get; }

		[Internal]
		[Field ("kCGPDFOutlineDestinationRect")]
		NSString DestinationRectKey { get; }

		[Internal]
		[Field ("kCGPDFContextAccessPermissions")]
		NSString AccessPermissionsKey { get; }
	}

	[MacCatalyst (13, 1)]
	//[StrongDictionary ("CGPDFOutlineKeys")]
	public class CGPDFOutlineOptions: DictionaryContainer {
		
		public CGPDFOutlineOptions(IntPtr handle): base(handle) { }
		
		public CGPDFOutlineOptions(NSObject obj): base(obj.Handle) { }
		
		public string OutlineTitle { get; set; }
		public NSDictionary [] OutlineChildren { get; set; }
		public NSObject OutlineDestination { get; set; }
		public CGRect DestinationRect { get; set; }
	}

	//[iOS (13, 0)]
	[TV (13, 0)]
	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	[Static]
	[Internal]
	interface CGPdfTagPropertyKeys {
		[Field ("kCGPDFTagPropertyActualText")]
		NSString ActualTextKey { get; }

		[Field ("kCGPDFTagPropertyAlternativeText")]
		NSString AlternativeTextKey { get; }

		[Field ("kCGPDFTagPropertyTitleText")]
		NSString TitleTextKey { get; }

		[Field ("kCGPDFTagPropertyLanguageText")]
		NSString LanguageTextKey { get; }
	}

	//[iOS (13, 0)]
	[TV (13, 0)]
	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	//[StrongDictionary ("CGPdfTagPropertyKeys")]
	public class CGPdfTagProperties : DictionaryContainer {
		// <quote>The following CGPDFTagProperty keys are to be paired with CFStringRef values</quote>
		public string ActualText { get; set; }
		public string AlternativeText { get; set; }
		public string TitleText { get; set; }
		public string LanguageText { get; set; }
	}

	// macOS 10.5
	//[iOS (14, 0)]
	[TV (14, 0)]
	[Watch (7, 0)]
	[MacCatalyst (14, 0)]
	public enum CGConstantColor {
		[Field ("kCGColorWhite")]
		White,
		[Field ("kCGColorBlack")]
		Black,
		[Field ("kCGColorClear")]
		Clear,
	}

	// Adding suffix *Keys to avoid possible name clash
	[NoiOS, NoTV, NoWatch, MacCatalyst (13, 1)]
	[Static]
	[Deprecated (PlatformName.MacOSX, 15, 0, message: "Use ScreenCaptureKit instead.")]
	[Deprecated (PlatformName.MacCatalyst, 18, 0, message: "Use ScreenCaptureKit instead.")]
	interface CGDisplayStreamKeys {

		[Field ("kCGDisplayStreamColorSpace")]
		NSString ColorSpace { get; }

		[Field ("kCGDisplayStreamDestinationRect")]
		NSString DestinationRect { get; }

		[Field ("kCGDisplayStreamMinimumFrameTime")]
		NSString MinimumFrameTime { get; }

		[Field ("kCGDisplayStreamPreserveAspectRatio")]
		NSString PreserveAspectRatio { get; }

		[Field ("kCGDisplayStreamQueueDepth")]
		NSString QueueDepth { get; }

		[Field ("kCGDisplayStreamShowCursor")]
		NSString ShowCursor { get; }

		[Field ("kCGDisplayStreamSourceRect")]
		NSString SourceRect { get; }

		[Field ("kCGDisplayStreamYCbCrMatrix")]
		NSString YCbCrMatrix { get; }
	}

	[NoiOS, NoTV, NoWatch, MacCatalyst (13, 1)]
	[Static]
	interface CGDisplayStreamYCbCrMatrixOptionKeys {

		[Field ("kCGDisplayStreamYCbCrMatrix_ITU_R_601_4")]
		NSString Itu_R_601_4 { get; }

		[Field ("kCGDisplayStreamYCbCrMatrix_ITU_R_709_2")]
		NSString Itu_R_709_2 { get; }

		[Field ("kCGDisplayStreamYCbCrMatrix_SMPTE_240M_1995")]
		NSString Smpte_240M_1995 { get; }
	}

#if NET
	[NoiOS, NoTV, NoWatch, MacCatalyst (13, 1)]
	//[StrongDictionary ("CGSessionKeys")]
	public class  CGSessionProperties: DictionaryContainer
	{

		public CGSessionProperties(NSObject obj) : base(obj.Handle ){}
		
		uint UserId { get; }
		string UserName { get; }
		uint ConsoleSet { get; }
		bool OnConsole { get; }
		bool LoginDone { get; }
	}
#endif

	//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[Partial]
	partial interface CGToneMappingOptionKeys {
		[Internal]
		[Field ("kCGUse100nitsHLGOOTF")]
		NSString Use100nitsHlgOotfKey { get; }

		[Internal]
		[Field ("kCGUseBT1886ForCoreVideoGamma")]
		NSString UseBT1886ForCoreVideoGammaKey { get; }

		[Internal]
		[Field ("kCGSkipBoostToHDR")]
		NSString SkipBoostToHdrKey { get; }

		[Internal]
		[Field ("kCGEXRToneMappingGammaDefog")]
		NSString ExrToneMappingGammaDefogKey { get; }

		[Internal]
		[Field ("kCGEXRToneMappingGammaExposure")]
		NSString ExrToneMappingGammaExposureKey { get; }

		[Internal]
		[Field ("kCGEXRToneMappingGammaKneeLow")]
		NSString ExrToneMappingGammaKneeLowKey { get; }

		[Internal]
		[Field ("kCGEXRToneMappingGammaKneeHigh")]
		NSString ExrToneMappingGammaKneeHighKey { get; }
	}

	//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	//[StrongDictionary ("CGToneMappingOptionKeys")]
	public class CGToneMappingOptions : DictionaryContainer {
		public bool Use100nitsHlgOotf { get; set; }
		public bool UseBT1886ForCoreVideoGamma { get; set; }
		public bool SkipBoostToHdr { get; set; }
		public float ExrToneMappingGammaDefog { get; set; }
		public float ExrToneMappingGammaExposure { get; set; }
		public float ExrToneMappingGammaKneeLow { get; set; }
		public float ExrToneMappingGammaKneeHigh { get; set; }
	}

	//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[Partial]
	[Internal]
	public class CoreGraphicsFields {
		[Field ("kCGDefaultHDRImageContentHeadroom")]
		public extern static float DefaultHdrImageContentHeadroom { get; }
	}
}
