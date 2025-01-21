//
// corevideo.cs: Definitions for CoreVideo
//
// Copyright 2014 Xamarin Inc. All rights reserved.
// Copyright 2020 Microsoft Corporation
//

using System;
using CoreFoundation;
using CoreGraphics;
using CoreLibs;
using Foundation;
using ObjCRuntime;
#if !WATCH
using Metal;
#endif

namespace CoreVideo {

	/// <summary>Manages pixel buffer pool allocation settings.</summary>
	[Partial]
	interface CVPixelBufferPoolAllocationSettings {

		[Internal]
		[Field ("kCVPixelBufferPoolAllocationThresholdKey")]
		NSString ThresholdKey { get; }
	}

	/// <summary>A Core Video data buffer, containing video, audio, or other type of data.</summary>
	[Partial]
	public partial class CVBuffer  {

		[Field ("kCVBufferMovieTimeKey")]
		public static extern NSString MovieTimeKey { get; }

		[Field ("kCVBufferTimeValueKey")]
		public static extern NSString TimeValueKey { get; }

		[Field ("kCVBufferTimeScaleKey")]
		public static extern NSString TimeScaleKey { get; }

		[Field ("kCVBufferPropagatedAttachmentsKey")]
		public static extern NSString PropagatedAttachmentsKey { get; }

		[Field ("kCVBufferNonPropagatedAttachmentsKey")]
		public static extern NSString NonPropagatedAttachmentsKey { get; }
	}

	/// <summary>A <see cref="T:CoreVideo.CVBuffer" /> that stores image data.</summary>
	[Partial]
	public partial class CVImageBuffer : CVBuffer {

		[Field ("kCVImageBufferCGColorSpaceKey")]
		public  extern NSString CGColorSpaceKey { get; }

		[Field ("kCVImageBufferGammaLevelKey")]
		public  extern NSString GammaLevelKey { get; }

		[Field ("kCVImageBufferCleanApertureKey")]
		public  extern NSString CleanApertureKey { get; }

		[Field ("kCVImageBufferPreferredCleanApertureKey")]
		public  extern NSString PreferredCleanApertureKey { get; }

		[Field ("kCVImageBufferCleanApertureWidthKey")]
		public  extern NSString CleanApertureWidthKey { get; }

		[Field ("kCVImageBufferCleanApertureHeightKey")]
		public  extern NSString CleanApertureHeightKey { get; }

		[Field ("kCVImageBufferCleanApertureHorizontalOffsetKey")]
		public  extern NSString CleanApertureHorizontalOffsetKey { get; }

		[Field ("kCVImageBufferCleanApertureVerticalOffsetKey")]
		public  extern NSString CleanApertureVerticalOffsetKey { get; }

		[Field ("kCVImageBufferFieldCountKey")]
		public  extern NSString FieldCountKey { get; }

		[Field ("kCVImageBufferFieldDetailKey")]
		public  extern NSString FieldDetailKey { get; }

		[Field ("kCVImageBufferFieldDetailTemporalTopFirst")]
		public  extern NSString FieldDetailTemporalTopFirst { get; }

		[Field ("kCVImageBufferFieldDetailTemporalBottomFirst")]
		public  extern NSString FieldDetailTemporalBottomFirst { get; }

		[Field ("kCVImageBufferFieldDetailSpatialFirstLineEarly")]
		public  extern NSString FieldDetailSpatialFirstLineEarly { get; }

		[Field ("kCVImageBufferFieldDetailSpatialFirstLineLate")]
		public  extern NSString FieldDetailSpatialFirstLineLate { get; }

		[Field ("kCVImageBufferPixelAspectRatioKey")]
		public  extern NSString PixelAspectRatioKey { get; }

		[Field ("kCVImageBufferPixelAspectRatioHorizontalSpacingKey")]
		public  extern NSString PixelAspectRatioHorizontalSpacingKey { get; }

		[Field ("kCVImageBufferPixelAspectRatioVerticalSpacingKey")]
		public  extern NSString PixelAspectRatioVerticalSpacingKey { get; }

		[Field ("kCVImageBufferDisplayDimensionsKey")]
		public  extern NSString DisplayDimensionsKey { get; }

		[Field ("kCVImageBufferDisplayWidthKey")]
		public  extern NSString DisplayWidthKey { get; }

		[Field ("kCVImageBufferDisplayHeightKey")]
		public  extern NSString DisplayHeightKey { get; }

		[Field ("kCVImageBufferYCbCrMatrixKey")]
		public  extern NSString YCbCrMatrixKey { get; }

		[Static]
		[Wrap ("CVImageBufferYCbCrMatrix.ItuR709_2.GetConstant ()")]
		public static extern NSString YCbCrMatrix_ITU_R_709_2 { get; }

		[Static]
		[Wrap ("CVImageBufferYCbCrMatrix.ItuR601_4.GetConstant ()")]
		public static extern NSString YCbCrMatrix_ITU_R_601_4 { get; }

		[Static]
		[Wrap ("CVImageBufferYCbCrMatrix.Smpte240M1995.GetConstant ()")]
		public static extern NSString YCbCrMatrix_SMPTE_240M_1995 { get; }

		[Static]
		[Wrap ("CVImageBufferYCbCrMatrix.DciP3.GetConstant ()")]
		[MacCatalyst (13, 1)]
		public static extern NSString YCbCrMatrix_DCI_P3 { get; }

		[Static]
		[Wrap ("CVImageBufferYCbCrMatrix.P3D65.GetConstant ()")]
		[MacCatalyst (13, 1)]
		public static extern NSString YCbCrMatrix_P3_D65 { get; }

		[Static]
		[Wrap ("CVImageBufferYCbCrMatrix.ItuR2020.GetConstant ()")]
		[MacCatalyst (13, 1)]
		public static extern NSString YCbCrMatrix_ITU_R_2020 { get; }

		[Static]
		[Wrap ("CVImageBufferColorPrimaries.DciP3.GetConstant ()")]
		[MacCatalyst (13, 1)]
		public static extern NSString ColorPrimaries_DCI_P3 { get; }

		[Static]
		[Wrap ("CVImageBufferColorPrimaries.ItuR2020.GetConstant ()")]
		[MacCatalyst (13, 1)]
		public static extern NSString ColorPrimaries_ITU_R_2020 { get; }

		[Static]
		[Wrap ("CVImageBufferColorPrimaries.P3D65.GetConstant ()")]
		[MacCatalyst (13, 1)]
		public static extern NSString ColorPrimaries_P3_D65 { get; }

		[Field ("kCVImageBufferChromaSubsamplingKey")]
		public extern NSString ChromaSubsamplingKey { get; }

		[Field ("kCVImageBufferChromaSubsampling_420")]
		public extern NSString ChromaSubsampling_420 { get; }

		[Field ("kCVImageBufferChromaSubsampling_422")]
		public extern NSString ChromaSubsampling_422 { get; }

		[Field ("kCVImageBufferChromaSubsampling_411")]
		public extern NSString ChromaSubsampling_411 { get; }

		[Field ("kCVImageBufferTransferFunctionKey")]
		public extern NSString TransferFunctionKey { get; }

		[Static]
		[Wrap ("CVImageBufferTransferFunction.ItuR709_2.GetConstant ()")]
		public static extern NSString TransferFunction_ITU_R_709_2 { get; }

		[Static]
		[Wrap ("CVImageBufferTransferFunction.Smpte240M1995.GetConstant ()")]
		public static extern NSString TransferFunction_SMPTE_240M_1995 { get; }

		[Static]
		[Wrap ("CVImageBufferTransferFunction.UseGamma.GetConstant ()")]
		public static extern NSString TransferFunction_UseGamma { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("CVImageBufferTransferFunction.ItuR2020.GetConstant ()")]
		public static extern NSString TransferFunction_ITU_R_2020 { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("CVImageBufferTransferFunction.SmpteST428_1.GetConstant ()")]
		public static extern NSString TransferFunction_SMPTE_ST_428_1 { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("CVImageBufferTransferFunction.SRgb.GetConstant ()")]
		public static extern NSString TransferFunction_sRGB { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("CVImageBufferTransferFunction.SmpteST2084PQ.GetConstant ()")]
		public static extern NSString TransferFunction_SMPTE_ST_2084_PQ { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("CVImageBufferTransferFunction.ItuR2100Hlg.GetConstant ()")]
		public static extern NSString TransferFunction_ITU_R_2100_HLG { get; }

		[Field ("kCVImageBufferChromaLocationTopFieldKey")]
		public extern NSString ChromaLocationTopFieldKey { get; }

		[Field ("kCVImageBufferChromaLocationBottomFieldKey")]
		public extern NSString ChromaLocationBottomFieldKey { get; }

		[Field ("kCVImageBufferChromaLocation_Left")]
		public extern NSString ChromaLocation_Left { get; }

		[Field ("kCVImageBufferChromaLocation_Center")]
		public extern NSString ChromaLocation_Center { get; }

		[Field ("kCVImageBufferChromaLocation_TopLeft")]
		public extern NSString ChromaLocation_TopLeft { get; }

		[Field ("kCVImageBufferChromaLocation_Top")]
		public extern NSString ChromaLocation_Top { get; }

		[Field ("kCVImageBufferChromaLocation_BottomLeft")]
		public extern NSString ChromaLocation_BottomLeft { get; }

		[Field ("kCVImageBufferChromaLocation_Bottom")]
		public extern NSString ChromaLocation_Bottom { get; }

		[Field ("kCVImageBufferChromaLocation_DV420")]
		public extern NSString ChromaLocation_DV420 { get; }

		[Field ("kCVImageBufferColorPrimariesKey")]
		public extern NSString ColorPrimariesKey { get; }

		[Static]
		[Wrap ("CVImageBufferColorPrimaries.ItuR709_2.GetConstant ()")]
		public static extern NSString ColorPrimaries_ITU_R_709_2 { get; }

		[Static]
		[Wrap ("CVImageBufferColorPrimaries.Ebu3213.GetConstant ()")]
		public static extern NSString ColorPrimaries_EBU_3213 { get; }

		[Static]
		[Wrap ("CVImageBufferColorPrimaries.SmpteC.GetConstant ()")]
		public static extern NSString ColorPrimaries_SMPTE_C { get; }

		[Static]
		[Wrap ("CVImageBufferColorPrimaries.P22.GetConstant ()")]
		public static extern NSString ColorPrimaries_P22 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferAlphaChannelIsOpaque")]
		public extern NSString AlphaChannelIsOpaque { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferMasteringDisplayColorVolumeKey")]
		public  extern NSString MasteringDisplayColorVolumeKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferContentLightLevelInfoKey")]
		public extern NSString ContentLightLevelInfoKey { get; }

		[TV (13, 0), NoWatch, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferAlphaChannelModeKey")]
		public extern NSString AlphaChannelModeKey { get; }

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Field ("kCVImageBufferRegionOfInterestKey")]
		public extern NSString RegionOfInterestKey { get; }

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Field ("kCVImageBufferAmbientViewingEnvironmentKey")]
		public extern NSString AmbientViewingEnvironmentKey { get; }

		[Watch (10, 2), TV (17, 2), Mac (14, 2), iOS (17, 2), MacCatalyst (17, 2)]
		[Field ("kCVImageBufferLogTransferFunctionKey")]
		public extern NSString LogTransferFunctionKey { get; }

		[Watch (10, 2), TV (17, 2), Mac (14, 2), iOS (17, 2), MacCatalyst (17, 2)]
		[Field ("kCVImageBufferLogTransferFunction_AppleLog")]
		public extern NSString LogTransferFunctionAppleLogKey { get; }

		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCVImageBufferSceneIlluminationKey")]
		public extern NSString SceneIlluminationKey { get; }

		[Mac (15, 0), NoiOS, NoTV, NoWatch, NoMacCatalyst]
		[Field ("kCVImageBufferPostDecodeProcessingSequenceMetadataKey")]
		public extern NSString PostDecodeProcessingSequenceMetadataKey { get; }

		[Mac (15, 0), NoiOS, NoTV, NoWatch, NoMacCatalyst]
		[Field ("kCVImageBufferPostDecodeProcessingFrameMetadataKey")]
		public extern NSString PostDecodeProcessingFrameMetadataKey { get; }
	}

	[MacCatalyst (13, 1)]
	public enum CVImageBufferTransferFunction {

		[Field (null)]
		Unknown = 2, // 2 (the code point for "unknown")

		[Field ("kCVImageBufferTransferFunction_ITU_R_709_2")]
		ItuR709_2,

		[Field ("kCVImageBufferTransferFunction_SMPTE_240M_1995")]
		Smpte240M1995,

		[Field ("kCVImageBufferTransferFunction_UseGamma")]
		UseGamma,

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferTransferFunction_ITU_R_2020")]
		ItuR2020,

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferTransferFunction_SMPTE_ST_428_1")]
		SmpteST428_1,

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferTransferFunction_sRGB")]
		SRgb,

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferTransferFunction_SMPTE_ST_2084_PQ")]
		SmpteST2084PQ,

		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferTransferFunction_ITU_R_2100_HLG")]
		ItuR2100Hlg,

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCVImageBufferTransferFunction_Linear")]
		Linear,
	}

	[MacCatalyst (13, 1)]
	public enum CVImageBufferColorPrimaries {

		[Field (null)]
		Unknown = 2, // 2 (the code point for "unknown")

		[Field ("kCVImageBufferColorPrimaries_DCI_P3")]
		[MacCatalyst (13, 1)]
		DciP3,

		[Field ("kCVImageBufferColorPrimaries_ITU_R_2020")]
		[MacCatalyst (13, 1)]
		ItuR2020,

		[Field ("kCVImageBufferColorPrimaries_P3_D65")]
		[MacCatalyst (13, 1)]
		P3D65,

		[Field ("kCVImageBufferColorPrimaries_ITU_R_709_2")]
		ItuR709_2,

		[Field ("kCVImageBufferColorPrimaries_EBU_3213")]
		Ebu3213,

		[Field ("kCVImageBufferColorPrimaries_SMPTE_C")]
		SmpteC,

		[Field ("kCVImageBufferColorPrimaries_P22")]
		P22,
	}

	[MacCatalyst (13, 1)]
	public enum CVImageBufferYCbCrMatrix {

		[Field (null)]
		Unknown = 2, // 2 (the code point for "unknown")

		[Field ("kCVImageBufferYCbCrMatrix_ITU_R_709_2")]
		ItuR709_2,

		[Field ("kCVImageBufferYCbCrMatrix_ITU_R_601_4")]
		ItuR601_4,

		[Field ("kCVImageBufferYCbCrMatrix_SMPTE_240M_1995")]
		Smpte240M1995,

		//[Deprecated (PlatformName.iOS, 14, 0, message: "This API is no longer supported.")]
		//[Deprecated (PlatformName.TvOS, 14, 0, message: "This API is no longer supported.")]
		//[Deprecated (PlatformName.MacOSX, 11, 0, message: "This API is no longer supported.")]
		[Field ("kCVImageBufferYCbCrMatrix_DCI_P3")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 14, 0, message: "This API is no longer supported.")]
		DciP3,

		//[Deprecated (PlatformName.iOS, 14, 0, message: "This API is no longer supported.")]
		//[Deprecated (PlatformName.TvOS, 14, 0, message: "This API is no longer supported.")]
		//[Deprecated (PlatformName.MacOSX, 11, 0, message: "This API is no longer supported.")]
		[Field ("kCVImageBufferYCbCrMatrix_P3_D65")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 14, 0, message: "This API is no longer supported.")]
		P3D65,

		[Field ("kCVImageBufferYCbCrMatrix_ITU_R_2020")]
		[MacCatalyst (13, 1)]
		ItuR2020,
	}

	/// <summary>A <see cref="T:CoreVideo.CVImageBuffer" /> that holds pixels.</summary>
	[Partial]
	public partial class CVPixelBuffer: CVImageBuffer {

		[Field ("kCVPixelBufferPixelFormatTypeKey")]
		public static extern NSString PixelFormatTypeKey { get; }

		[Field ("kCVPixelBufferMemoryAllocatorKey")]
		public static extern NSString MemoryAllocatorKey { get; }

		[Field ("kCVPixelBufferWidthKey")]
		public static extern NSString WidthKey { get; }

		[Field ("kCVPixelBufferHeightKey")]
		public static extern NSString HeightKey { get; }

		[Field ("kCVPixelBufferExtendedPixelsLeftKey")]
		public static extern NSString ExtendedPixelsLeftKey { get; }

		[Field ("kCVPixelBufferExtendedPixelsTopKey")]
		public static extern NSString ExtendedPixelsTopKey { get; }

		[Field ("kCVPixelBufferExtendedPixelsRightKey")]
		public static extern NSString ExtendedPixelsRightKey { get; }

		[Field ("kCVPixelBufferExtendedPixelsBottomKey")]
		public static extern NSString ExtendedPixelsBottomKey { get; }

		[Field ("kCVPixelBufferBytesPerRowAlignmentKey")]
		public static extern NSString BytesPerRowAlignmentKey { get; }

		[Field ("kCVPixelBufferCGBitmapContextCompatibilityKey")]
		public static extern NSString CGBitmapContextCompatibilityKey { get; }

		[Field ("kCVPixelBufferCGImageCompatibilityKey")]
		public static extern NSString CGImageCompatibilityKey { get; }

		[Field ("kCVPixelBufferOpenGLCompatibilityKey")]
		public static extern NSString OpenGLCompatibilityKey { get; }

		[Field ("kCVPixelBufferIOSurfacePropertiesKey")]
		public static extern NSString IOSurfacePropertiesKey { get; }

		[Field ("kCVPixelBufferPlaneAlignmentKey")]
		public static extern NSString PlaneAlignmentKey { get; }

		[NoMac]
		[NoWatch]
		[NoMacCatalyst]
		[Field ("kCVPixelBufferOpenGLESCompatibilityKey")]
		public static extern NSString OpenGLESCompatibilityKey { get; }

		[NoMac]
		[NoWatch]
		[NoMacCatalyst]
		[Field ("kCVPixelBufferOpenGLESTextureCacheCompatibilityKey")]
		public static extern NSString OpenGLESTextureCacheCompatibilityKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCVPixelBufferMetalCompatibilityKey")]
		public static extern NSString MetalCompatibilityKey { get; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		[Field ("kCVPixelBufferOpenGLTextureCacheCompatibilityKey")]
		public static extern NSString OpenGLTextureCacheCompatibilityKey { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_BlackLevel")]
		public static extern NSString ProResRawKey_BlackLevel { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_ColorMatrix")]
		public static extern NSString ProResRawKey_ColorMatrix { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_GainFactor")]
		public static extern NSString ProResRawKey_GainFactor { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_RecommendedCrop")]
		public static extern NSString ProResRawKey_RecommendedCrop { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_SenselSitingOffsets")]
		public static extern NSString ProResRawKey_SenselSitingOffsets { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_WhiteBalanceBlueFactor")]
		public static extern NSString ProResRawKey_WhiteBalanceBlueFactor { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_WhiteBalanceCCT")]
		public static extern NSString ProResRawKey_WhiteBalanceCct { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_WhiteBalanceRedFactor")]
		public static extern NSString ProResRawKey_WhiteBalanceRedFactor { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_WhiteLevel")]
		public static extern NSString ProResRawKey_WhiteLevel { get; }

		[NoWatch, NoTV, iOS (14, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferVersatileBayerKey_BayerPattern")]
		public static extern NSString VersatileBayerKey_BayerPattern { get; }

		[NoWatch, NoTV, iOS (15, 0), MacCatalyst (15, 0)]
		[Field ("kCVPixelBufferProResRAWKey_MetadataExtension")]
		public static extern NSString MetadataExtension { get; }
	}

	/// <summary>A reusable set of <see cref="T:CoreVideo.CVPixelBuffer" />s.</summary>
	[Partial]
	interface CVPixelBufferPool {
		[Field ("kCVPixelBufferPoolMinimumBufferCountKey")]
		NSString MinimumBufferCountKey { get; }

		[Field ("kCVPixelBufferPoolMaximumBufferAgeKey")]
		NSString MaximumBufferAgeKey { get; }
	}

	/// <summary>Cache to manage CVMetalTexture objects.</summary>
	[NoWatch]
	[MacCatalyst (13, 1)]
	[Partial]
	interface CVMetalTextureCache {
		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCVMetalTextureCacheMaximumTextureAgeKey")]
		IntPtr MaxTextureAge { get; }

		[TV (13, 0), NoWatch, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCVMetalTextureStorageMode")]
		NSString StorageMode { get; }
	}

	// CVOpenGLESTextureCache is bound (manually) in OpenTK[-1.0].dll.
	// [Partial]
	// interface CVOpenGLESTextureCache {
	// 	[Internal]
	// 	[Field ("kCVOpenGLESTextureCacheMaximumTextureAgeKey")]
	// 	IntPtr MaxTextureAge { get; }
	// }

	[NoWatch]
	[MacCatalyst (13, 1)]
	[Static, Internal]
	interface CVMetalTextureAttributesKeys {

		[Field ("kCVMetalTextureUsage")]
		NSString UsageKey { get; }
	}

	[NoWatch]
	[MacCatalyst (13, 1)]
	[StrongDictionary ("CVMetalTextureAttributesKeys")]
	interface CVMetalTextureAttributes {
		// Create stub DictionaryContainer class
	}

	[NoWatch, NoTV, NoMac, iOS (14, 0)]
	[MacCatalyst (14, 0)]
	public enum CVVersatileBayerPattern : uint {
		Rggb = 0,
		Grbg = 1,
		Gbrg = 2,
		Bggr = 3,
	}

	[NoWatch, TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[Static, Internal]
	interface CVMetalBufferCacheAttributeKeys {
		[Field ("kCVMetalBufferCacheMaximumBufferAgeKey")]
		NSString MaximumBufferAgeKey { get; }
	}

	[NoWatch]
	[StrongDictionary ("CVMetalBufferCacheAttributeKeys")]
	interface CVMetalBufferCacheAttributes {
		double MaximumBufferAge { get; }
	}

	[Partial]
	interface CVPixelFormatKeys {
		[Field ("kCVPixelFormatName")]
		NSString Name { get; }

		[Field ("kCVPixelFormatConstant")]
		NSString Constant { get; }

		[Field ("kCVPixelFormatCodecType")]
		NSString CodecType { get; }

		[Field ("kCVPixelFormatFourCC")]
		NSString FourCC { get; }

		[Field ("kCVPixelFormatContainsAlpha")]
		NSString ContainsAlpha { get; }

		[Field ("kCVPixelFormatContainsYCbCr")]
		NSString ContainsYCbCr { get; }

		[Field ("kCVPixelFormatContainsRGB")]
		NSString ContainsRgb { get; }

		[Field ("kCVPixelFormatContainsGrayscale")]
		NSString ContainsGrayscale { get; }

		[iOS (16, 0), Mac (13, 0), MacCatalyst (16, 0), TV (16, 0), Watch (9, 0)]
		[Field ("kCVPixelFormatContainsSenselArray")]
		NSString ContainsSenselArray { get; }

		[Field ("kCVPixelFormatComponentRange")]
		NSString ComponentRange { get; }

		[Field ("kCVPixelFormatPlanes")]
		NSString Planes { get; }

		[Field ("kCVPixelFormatBlockWidth")]
		NSString BlockWidth { get; }

		[Field ("kCVPixelFormatBlockHeight")]
		NSString BlockHeight { get; }

		[Field ("kCVPixelFormatBitsPerBlock")]
		NSString BitsPerBlock { get; }

		[Field ("kCVPixelFormatBlockHorizontalAlignment")]
		NSString BlockHorizontalAlignment { get; }

		[Field ("kCVPixelFormatBlockVerticalAlignment")]
		NSString BlockVerticalAlignment { get; }

		[Field ("kCVPixelFormatBlackBlock")]
		NSString BlackBlock { get; }

		[Field ("kCVPixelFormatHorizontalSubsampling")]
		NSString HorizontalSubsampling { get; }

		[Field ("kCVPixelFormatVerticalSubsampling")]
		NSString VerticalSubsampling { get; }

		[Field ("kCVPixelFormatOpenGLFormat")]
		NSString OpenGLFormat { get; }

		[Field ("kCVPixelFormatOpenGLType")]
		NSString OpenGLType { get; }

		[Field ("kCVPixelFormatOpenGLInternalFormat")]
		NSString OpenGLInternalFormat { get; }

		[Field ("kCVPixelFormatCGBitmapInfo")]
		NSString CGBitmapInfo { get; }

		[Field ("kCVPixelFormatQDCompatibility")]
		NSString QDCompatibility { get; }

		[Field ("kCVPixelFormatCGBitmapContextCompatibility")]
		NSString CGBitmapContextCompatibility { get; }

		[Field ("kCVPixelFormatCGImageCompatibility")]
		NSString CGImageCompatibility { get; }

		[Field ("kCVPixelFormatOpenGLCompatibility")]
		NSString OpenGLCompatibility { get; }

		[NoWatch, NoMacCatalyst, NoMac]
		[Field ("kCVPixelFormatOpenGLESCompatibility")]
		NSString OpenGlesCompatibility { get; }

		[Field ("kCVPixelFormatFillExtendedPixelsCallback")]
		NSString FillExtendedPixelsCallback { get; }

		[iOS (18, 0), Mac (15, 0), MacCatalyst (18, 0), TV (18, 0), Watch (11, 0)]
		[Field ("kCVPixelFormatBitsPerComponent")]
		NSString BitsPerComponent { get; }
	}

	[Partial]
	interface CVPixelFormatComponentRangeKeys {
		[Field ("kCVPixelFormatComponentRange_VideoRange")]
		NSString VideoRange { get; }

		[Field ("kCVPixelFormatComponentRange_FullRange")]
		NSString FullRange { get; }

		[Field ("kCVPixelFormatComponentRange_WideRange")]
		NSString WideRange { get; }
	}


	[StrongDictionary ("CVPixelFormatComponentRangeKeys", Suffix = "")]
	interface CVPixelFormatComponentRange {
		// there's no documentation about the type, so binding as NSObject
		NSObject VideoRange { get; set; }

		// there's no documentation about the type, so binding as NSObject
		NSObject FullRange { get; set; }

		// there's no documentation about the type, so binding as NSObject
		NSObject WideRange { get; set; }
	}

	[StrongDictionary ("CVPixelFormatKeys", Suffix = "")]
	interface CVPixelFormatDescription {
		string Name { get; set; }

		CVPixelFormatType Constant { get; set; }

		// Documentation says 'CFString', but it also says 'CFString' about another property which clearly isn't, so I don't trust the documentation.
		// Headers don't say, and tests don't show anything useful, there are no hits on Google for the underlying field, so leaving this typed as 'NSObject'.
		NSObject CodecType { get; set; }

		int FourCC { get; set; }

		bool ContainsAlpha { get; set; }

#if XAMCORE_5_0
		bool ContainsYCbCr { get; set; }
#else
		[Export ("ContainsYCbCr")]
		bool FormatContainsYCbCr { get; set; }
#endif

#if XAMCORE_5_0
		bool ContainsRgb { get; set; }
#else
		[Export ("ContainsRgb")]
		bool FormatContainsRgb { get; set; }
#endif

		bool ContainsGrayscale { get; set; }

		[iOS (16, 0), Mac (13, 0), MacCatalyst (16, 0), TV (16, 0), Watch (9, 0)]
#if XAMCORE_5_0
		bool ContainsSenselArray { get; set; }
#else
		[Export ("ContainsSenselArray")]
		bool FormatContainsSenselArray { get; set; }
#endif

		CVPixelFormatComponentRange ComponentRange { get; set; }

		// This can be an array of dictionaries, or a single dictionary when there's only one plane, so we have to type as 'NSObject'.
		NSObject Planes { get; set; }

		int BlockWidth { get; set; }

		int BlockHeight { get; set; }

		int BitsPerBlock { get; set; }

		int BlockHorizontalAlignment { get; set; }

		int BlockVerticalAlignment { get; set; }

		NSData BlackBlock { get; set; }

		int HorizontalSubsampling { get; set; }

		int VerticalSubsampling { get; set; }

		int OpenGLFormat { get; set; }

		int OpenGLType { get; set; }

		int OpenGLInternalFormat { get; set; }

		CGBitmapFlags CGBitmapInfo { get; set; }

		bool QDCompatibility { get; set; }

		bool CGBitmapContextCompatibility { get; set; }

		bool CGImageCompatibility { get; set; }

		bool OpenGLCompatibility { get; set; }

		[NoWatch, NoMacCatalyst, NoMac]
		bool OpenGlesCompatibility { get; set; }

		NSData FillExtendedPixelsCallback { get; set; }

		[iOS (18, 0), Mac (15, 0), MacCatalyst (18, 0), TV (18, 0), Watch (11, 0)]
		int BitsPerComponent { get; set; }
	}
}
