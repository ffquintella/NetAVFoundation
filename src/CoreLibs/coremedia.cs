//
// coremedia.cs: Definitions for CoreMedia
//
// Copyright 2014 Xamarin Inc. All rights reserved.
//

using System;
using CoreLibs;
using Foundation;
using ObjCRuntime;

namespace CoreMedia {

	/// <summary>Class that manages the repetitive allocation and deallocation of large blocks of memory.</summary>
	///     
	///     <!-- TODO: No Apple documentation on this as of 2013-05-01 -->
	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	[Partial]
	partial class CMMemoryPool {

		[Internal]
		[Field ("kCMMemoryPoolOption_AgeOutPeriod")]
		public extern static IntPtr AgeOutPeriodSelector { get; }
	}

	[NoWatch, NoTV, Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	public enum CMFormatDescriptionProjectionKind {
		[Field ("kCMFormatDescriptionProjectionKind_Rectilinear")]
		Rectilinear,
	}

	[NoWatch, NoTV, Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	public enum CMFormatDescriptionViewPackingKind {
		[Field ("kCMFormatDescriptionViewPackingKind_SideBySide")]
		SideBySide,

		[Field ("kCMFormatDescriptionViewPackingKind_OverUnder")]
		OverUnder,
	}

	[Static]
	[Internal]
	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	internal static class CMTextMarkupAttributesKeys {
		[Internal]
		[Field ("kCMTextMarkupAttribute_ForegroundColorARGB")]
		internal static extern NSString ForegroundColorARGB { get; }

		[Internal]
		[Field ("kCMTextMarkupAttribute_BackgroundColorARGB")]
		internal static extern NSString BackgroundColorARGB { get; }

		[Internal]
		[Field ("kCMTextMarkupAttribute_BoldStyle")]
		internal static extern NSString BoldStyle { get; }

		[Internal]
		[Field ("kCMTextMarkupAttribute_ItalicStyle")]
		internal static extern NSString ItalicStyle { get; }

		[Internal]
		[Field ("kCMTextMarkupAttribute_UnderlineStyle")]
		internal static extern NSString UnderlineStyle { get; }

		[Internal]
		[Field ("kCMTextMarkupAttribute_FontFamilyName")]
		internal static extern NSString FontFamilyName { get; }

		[Internal]
		[Field ("kCMTextMarkupAttribute_RelativeFontSize")]
		internal static extern NSString RelativeFontSize { get; }

		[Internal]
		[Field ("kCMTextMarkupAttribute_BaseFontSizePercentageRelativeToVideoHeight")]
		internal static extern NSString BaseFontSizePercentageRelativeToVideoHeight { get; }
	}

	[Static]
	[Internal]
	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	internal static class CMSampleAttachmentKey {
		[Field ("kCMSampleAttachmentKey_NotSync")]
		public static extern NSString NotSync { get; }

		[Field ("kCMSampleAttachmentKey_PartialSync")]
		public static extern NSString PartialSync { get; }

		[Field ("kCMSampleAttachmentKey_HasRedundantCoding")]
		public static extern NSString HasRedundantCoding { get; }

		[Field ("kCMSampleAttachmentKey_IsDependedOnByOthers")]
		public static extern NSString IsDependedOnByOthers { get; }

		[Field ("kCMSampleAttachmentKey_DependsOnOthers")]
		public static extern NSString DependsOnOthers { get; }

		[Field ("kCMSampleAttachmentKey_EarlierDisplayTimesAllowed")]
		public static extern NSString EarlierDisplayTimesAllowed { get; }

		[Field ("kCMSampleAttachmentKey_DisplayImmediately")]
		public static extern NSString DisplayImmediately { get; }

		[Field ("kCMSampleAttachmentKey_DoNotDisplay")]
		public static extern NSString DoNotDisplay { get; }

		[Field ("kCMSampleBufferAttachmentKey_ResetDecoderBeforeDecoding")]
		public static extern NSString ResetDecoderBeforeDecoding { get; }

		[Field ("kCMSampleBufferAttachmentKey_DrainAfterDecoding")]
		public static extern NSString DrainAfterDecoding { get; }

		[Field ("kCMSampleBufferAttachmentKey_PostNotificationWhenConsumed")]
		public static extern NSString PostNotificationWhenConsumedKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_ResumeOutput")]
		public static extern NSString ResumeOutputKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_TransitionID")]
		public static extern NSString TransitionIdKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_TrimDurationAtStart")]
		public static extern NSString TrimDurationAtStartKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_TrimDurationAtEnd")]
		public static extern NSString TrimDurationAtEndKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_SpeedMultiplier")]
		public static extern NSString SpeedMultiplierKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_Reverse")]
		public static extern NSString Reverse { get; }

		[Field ("kCMSampleBufferAttachmentKey_FillDiscontinuitiesWithSilence")]
		public static extern NSString FillDiscontinuitiesWithSilence { get; }

		[Field ("kCMSampleBufferAttachmentKey_EmptyMedia")]
		public static extern NSString EmptyMedia { get; }

		[Field ("kCMSampleBufferAttachmentKey_PermanentEmptyMedia")]
		public static extern NSString PermanentEmptyMedia { get; }

		[Field ("kCMSampleBufferAttachmentKey_DisplayEmptyMediaImmediately")]
		public static extern NSString DisplayEmptyMediaImmediately { get; }

		[Field ("kCMSampleBufferAttachmentKey_EndsPreviousSampleDuration")]
		public static extern NSString EndsPreviousSampleDuration { get; }

		[Field ("kCMSampleBufferAttachmentKey_SampleReferenceURL")]
		public static extern NSString SampleReferenceUrlKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_SampleReferenceByteOffset")]
		public static extern NSString SampleReferenceByteOffsetKey { get; }

		[Field ("kCMSampleBufferAttachmentKey_GradualDecoderRefresh")]
		public static extern NSString GradualDecoderRefreshKey { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferAttachmentKey_DroppedFrameReason")]
		public static extern NSString DroppedFrameReason { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferAttachmentKey_StillImageLensStabilizationInfo")]
		public static extern NSString StillImageLensStabilizationInfo { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferLensStabilizationInfo_Active")]
		public static extern NSString BufferLensStabilizationInfo_Active { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferLensStabilizationInfo_OutOfRange")]
		public static extern NSString BufferLensStabilizationInfo_OutOfRange { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferLensStabilizationInfo_Unavailable")]
		public static extern NSString BufferLensStabilizationInfo_Unavailable { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferLensStabilizationInfo_Off")]
		public static extern NSString BufferLensStabilizationInfo_Off { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCMSampleAttachmentKey_HEVCTemporalLevelInfo")]
		public static extern NSString HevcTemporalLevelInfoKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCMSampleAttachmentKey_HEVCTemporalSubLayerAccess")]
		public static extern NSString HevcTemporalSubLayerAccessKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCMSampleAttachmentKey_HEVCStepwiseTemporalSubLayerAccess")]
		public static extern NSString HevcStepwiseTemporalSubLayerAccessKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCMSampleAttachmentKey_HEVCSyncSampleNALUnitType")]
		public static extern NSString HevcSyncSampleNalUnitTypeKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferAttachmentKey_CameraIntrinsicMatrix")]
		public static extern NSString CameraIntrinsicMatrixKey { get; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCMSampleAttachmentKey_AudioIndependentSampleDecoderRefreshCount")]
		public static extern NSString AudioIndependentSampleDecoderRefreshCountKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCMSampleBufferAttachmentKey_ForceKeyFrame")]
		public static extern NSString ForceKeyFrameKey { get; }

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		[Field ("kCMSampleAttachmentKey_HDR10PlusPerFrameData")]
		public static extern NSString Hdr10PlusPerFrameDataKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst, Mac (15, 0)]
		[Field ("kCMSampleAttachmentKey_PostDecodeProcessingMetadata")]
		public static extern NSString PostDecodeProcessingMetadataKey { get; }
	}

	/// <summary>The keys for <see cref="T:CoreMedia.CMSampleBuffer" /> attachments.</summary>
	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	//[StrongDictionary ("CMSampleAttachmentKey")]
	partial class CMSampleBufferAttachmentSettings: DictionaryContainer {

		NSDictionary PostNotificationWhenConsumed { get; set; }
		bool ResumeOutput { get; set; }
		int TransitionId { get; set; }
		NSDictionary TrimDurationAtStart { get; set; }
		NSDictionary TrimDurationAtEnd { get; set; }
		float SpeedMultiplier { get; set; }
		NSUrl SampleReferenceUrl { get; set; }
		int SampleReferenceByteOffset { get; set; }
		NSNumber GradualDecoderRefresh { get; set; }

		[MacCatalyst (13, 1)]
		[StrongDictionary]
		CMHevcTemporalLevelInfoSettings HevcTemporalLevelInfo { get; set; }

		[MacCatalyst (13, 1)]
		bool HevcTemporalSubLayerAccess { get; set; }

		[MacCatalyst (13, 1)]
		bool HevcStepwiseTemporalSubLayerAccess { get; set; }

		[MacCatalyst (13, 1)]
		int HevcSyncSampleNalUnitType { get; set; }

		[MacCatalyst (13, 1)]
		NSData CameraIntrinsicMatrix { get; set; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		nint AudioIndependentSampleDecoderRefreshCount { get; set; }

		[MacCatalyst (13, 1)]
		bool ForceKeyFrame { get; set; }

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		NSData Hdr10PlusPerFrameData { get; set; } // it is a CFData, but that is a toll-free bridged

		[NoWatch, NoTV, NoiOS, NoMacCatalyst, Mac (15, 0)]
		NSDictionary PostDecodeProcessingMetadata { get; set; } // it is a CFDictionary, but that is a toll-free bridged
	}

	[Internal]
	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	[Static]
	interface CMHevcTemporalLevelInfoKeys {

		[Field ("kCMHEVCTemporalLevelInfoKey_TemporalLevel")]
		NSString TemporalLevelKey { get; }

		[Field ("kCMHEVCTemporalLevelInfoKey_ProfileSpace")]
		NSString ProfileSpaceKey { get; }

		[Field ("kCMHEVCTemporalLevelInfoKey_TierFlag")]
		NSString TierFlagKey { get; }

		[Field ("kCMHEVCTemporalLevelInfoKey_ProfileIndex")]
		NSString ProfileIndexKey { get; }

		[Field ("kCMHEVCTemporalLevelInfoKey_ProfileCompatibilityFlags")]
		NSString ProfileCompatibilityFlagsKey { get; }

		[Field ("kCMHEVCTemporalLevelInfoKey_ConstraintIndicatorFlags")]
		NSString ConstraintIndicatorFlagsKey { get; }

		[Field ("kCMHEVCTemporalLevelInfoKey_LevelIndex")]
		NSString LevelIndexKey { get; }
	}

	[Watch (6, 0)]
	[MacCatalyst (13, 1)]
	[StrongDictionary ("CMHevcTemporalLevelInfoKeys")]
	interface CMHevcTemporalLevelInfoSettings {

		int TemporalLevel { get; set; }
		int ProfileSpace { get; set; }
		int TierFlag { get; set; }
		int ProfileIndex { get; set; }
		NSData ProfileCompatibilityFlags { get; set; }
		NSData ConstraintIndicatorFlags { get; set; }
		int LevelIndex { get; set; }
	}

#if false
	// right now the generator can't add fields in a partial struct
	[Watch (6,0)]
	[Partial]
	interface CMTime {
		[Field ("kCMTimeValueKey")]
		NSString ValueKey { get; }

		[Field ("kCMTimeScaleKey")]
		NSString ScaleKey { get; }

		[Field ("kCMTimeEpochKey")]
		NSString EpochKey { get; }

		[Field ("kCMTimeFlagsKey")]
		NSString FlagsKey { get; }
	}
#endif
}
