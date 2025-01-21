using CoreMedia;
using CoreVideo;
using Foundation;

namespace CoreLibs;


static public partial class EnumsExtension {


    public static NSString GetConstant(this CVImageBufferTransferFunction self)
    {
        switch (self)
        {
            case CVImageBufferTransferFunction.Unknown:
                return new NSString("");
            case CVImageBufferTransferFunction.ItuR709_2:
                return new NSString("kCVImageBufferTransferFunction_ITU_R_709_2");
            case CVImageBufferTransferFunction.Smpte240M1995:
                return new NSString("kCVImageBufferTransferFunction_SMPTE_240M_1995");
            case CVImageBufferTransferFunction.UseGamma:
                return new NSString("kCVImageBufferTransferFunction_UseGamma");
            case CVImageBufferTransferFunction.ItuR2020:
                return new NSString("kCVImageBufferTransferFunction_ITU_R_2020");
            case CVImageBufferTransferFunction.SmpteST428_1:
                return new NSString("kCVImageBufferTransferFunction_SMPTE_ST_428_1");
            case CVImageBufferTransferFunction.SRgb:
                return new NSString("kCVImageBufferTransferFunction_sRGB");
            case CVImageBufferTransferFunction.SmpteST2084PQ:
                return new NSString("kCVImageBufferTransferFunction_SMPTE_ST_2084_PQ");
            case CVImageBufferTransferFunction.ItuR2100Hlg:
                return new NSString("kCVImageBufferTransferFunction_ITU_R_2100_HLG");
            case CVImageBufferTransferFunction.Linear:
                return new NSString("kCVImageBufferTransferFunction_Linear");
            default:
                return new NSString("");
        }
    }

    public static NSString GetConstant(this CVImageBufferColorPrimaries self)
    {
        switch (self)
        {
            case CVImageBufferColorPrimaries.Unknown:
                return new NSString("");
            case CVImageBufferColorPrimaries.DciP3:
                return new NSString("kCVImageBufferColorPrimaries_DCI_P3");
            case CVImageBufferColorPrimaries.ItuR2020:
                return new NSString("kCVImageBufferColorPrimaries_ITU_R_2020");
            case CVImageBufferColorPrimaries.P3D65:
                return new NSString("kCVImageBufferColorPrimaries_P3_D65");
            case CVImageBufferColorPrimaries.ItuR709_2:
                return new NSString("kCVImageBufferColorPrimaries_ITU_R_709_2");
            case CVImageBufferColorPrimaries.Ebu3213:
                return new NSString("kCVImageBufferColorPrimaries_EBU_3213");
            case CVImageBufferColorPrimaries.SmpteC:
                return new NSString("kCVImageBufferColorPrimaries_SMPTE_C");
            case CVImageBufferColorPrimaries.P22:
                return new NSString("kCVImageBufferColorPrimaries_P22");
            default:
                return new NSString("");
        }
    }

    public static NSString GetConstant(this CVImageBufferYCbCrMatrix self)
    {
        switch (self)
        {
            case CVImageBufferYCbCrMatrix.ItuR709_2:
                return new NSString("kCVImageBufferYCbCrMatrix_ITU_R_709_2");
                break;
            case CVImageBufferYCbCrMatrix.Unknown:
                return new NSString("");
                break;
            case CVImageBufferYCbCrMatrix.ItuR601_4:
                return new NSString("kCVImageBufferYCbCrMatrix_ITU_R_601_4");
                break;
            case CVImageBufferYCbCrMatrix.Smpte240M1995:
                return new NSString("kCVImageBufferYCbCrMatrix_SMPTE_240M_1995");
                break;
            case CVImageBufferYCbCrMatrix.DciP3:
                return new NSString("kCVImageBufferYCbCrMatrix_DCI_P3");
                break;
            case CVImageBufferYCbCrMatrix.P3D65:
                return new NSString("kCVImageBufferYCbCrMatrix_P3_D65");
                break;
            case CVImageBufferYCbCrMatrix.ItuR2020:
                return new NSString("kCVImageBufferYCbCrMatrix_ITU_R_2020");
                break;
            default:
                return new NSString("");
                break;
        }
    }

    public static NSString  GetConstant (this CMSampleBufferAttachmentKey  self)
    {
        switch (self)
        {
            case CMSampleBufferAttachmentKey.NotSync:
                return new NSString("kCMSampleAttachmentKey_NotSync");
                break;
            case CMSampleBufferAttachmentKey.PartialSync:
                return new NSString("kCMSampleAttachmentKey_PartialSync");
                break;
            case CMSampleBufferAttachmentKey.HasRedundantCoding:
                return new NSString("kCMSampleAttachmentKey_HasRedundantCoding");
                break;
            case CMSampleBufferAttachmentKey.IsDependedOnByOthers:
                return new NSString("kCMSampleAttachmentKey_IsDependedOnByOthers");
                break;
            case CMSampleBufferAttachmentKey.DependsOnOthers:
                return new NSString("kCMSampleAttachmentKey_DependsOnOthers");
                break;
            case CMSampleBufferAttachmentKey.EarlierDisplayTimesAllowed:
                return new NSString("kCMSampleAttachmentKey_EarlierDisplayTimesAllowed");
                break;
            case CMSampleBufferAttachmentKey.DisplayImmediately:
                return new NSString("kCMSampleAttachmentKey_DisplayImmediately");
                break;
            case CMSampleBufferAttachmentKey.DoNotDisplay:
                return new NSString("kCMSampleAttachmentKey_DoNotDisplay");
                break;
            case CMSampleBufferAttachmentKey.HevcTemporalLevelInfo:
                return new NSString("kCMSampleAttachmentKey_HEVCTemporalLevelInfo");
                break;
            case CMSampleBufferAttachmentKey.HevcTemporalSubLayerAccess:
                return new NSString("kCMSampleAttachmentKey_HEVCTemporalSubLayerAccess");
                break;
            case CMSampleBufferAttachmentKey.HevcStepwiseTemporalSubLayerAccess:
                return new NSString("kCMSampleAttachmentKey_HEVCStepwiseTemporalSubLayerAccess");
                break;
            case CMSampleBufferAttachmentKey.HevcSyncSampleNalUnitType:
                return new NSString("kCMSampleAttachmentKey_HEVCSyncSampleNALUnitType");
                break;
            case CMSampleBufferAttachmentKey.ResetDecoderBeforeDecoding:
                return new NSString("kCMSampleBufferAttachmentKey_ResetDecoderBeforeDecoding");
                break;
            case CMSampleBufferAttachmentKey.DrainAfterDecoding:
                return new NSString("kCMSampleBufferAttachmentKey_DrainAfterDecoding");
                break;
            case CMSampleBufferAttachmentKey.PostNotificationWhenConsumed:
                return new NSString("kCMSampleBufferAttachmentKey_PostNotificationWhenConsumed");
                break;
            case CMSampleBufferAttachmentKey.ResumeOutput:
                return new NSString("kCMSampleBufferAttachmentKey_ResumeOutput");
                break;
            case CMSampleBufferAttachmentKey.TransitionId:
                return new NSString("kCMSampleBufferAttachmentKey_TransitionID");
                break;
            case CMSampleBufferAttachmentKey.TrimDurationAtStart:
                return new NSString("kCMSampleBufferAttachmentKey_TrimDurationAtStart");
                break;
            case CMSampleBufferAttachmentKey.TrimDurationAtEnd:
                return new NSString("kCMSampleBufferAttachmentKey_TrimDurationAtEnd");
                break;
            case CMSampleBufferAttachmentKey.SpeedMultiplier:
                return new NSString("kCMSampleBufferAttachmentKey_SpeedMultiplier");
                break;
            case CMSampleBufferAttachmentKey.Reverse:
                return new NSString("kCMSampleBufferAttachmentKey_Reverse");
                break;
            case CMSampleBufferAttachmentKey.FillDiscontinuitiesWithSilence:
                return new NSString("kCMSampleBufferAttachmentKey_FillDiscontinuitiesWithSilence");
                break;
            case CMSampleBufferAttachmentKey.EmptyMedia:
                return new NSString("kCMSampleBufferAttachmentKey_EmptyMedia");
                break;
            case CMSampleBufferAttachmentKey.PermanentEmptyMedia:
                return new NSString("kCMSampleBufferAttachmentKey_PermanentEmptyMedia");
                break;
            case CMSampleBufferAttachmentKey.DisplayEmptyMediaImmediately:
                return new NSString("kCMSampleBufferAttachmentKey_DisplayEmptyMediaImmediately");
                break;
            case CMSampleBufferAttachmentKey.EndsPreviousSampleDuration:
                return new NSString("kCMSampleBufferAttachmentKey_EndsPreviousSampleDuration");
                break;
            case CMSampleBufferAttachmentKey.SampleReferenceUrl:
                return new NSString("kCMSampleBufferAttachmentKey_SampleReferenceURL");
                break;
            case CMSampleBufferAttachmentKey.SampleReferenceByteOffset:
                return new NSString("kCMSampleBufferAttachmentKey_SampleReferenceByteOffset");
                break;
            case CMSampleBufferAttachmentKey.GradualDecoderRefresh:
                return new NSString("kCMSampleBufferAttachmentKey_GradualDecoderRefresh");
                break;
            case CMSampleBufferAttachmentKey.DroppedFrameReason:
                return new NSString("kCMSampleBufferAttachmentKey_DroppedFrameReason");
                break;
            case CMSampleBufferAttachmentKey.StillImageLensStabilizationInfo:
                return new NSString("kCMSampleBufferAttachmentKey_StillImageLensStabilizationInfo");
                break;
            case CMSampleBufferAttachmentKey.CameraIntrinsicMatrix:
                return new NSString("kCMSampleBufferAttachmentKey_CameraIntrinsicMatrix");
                break;
            case CMSampleBufferAttachmentKey.DroppedFrameReasonInfo:
                return new NSString("kCMSampleBufferAttachmentKey_DroppedFrameReasonInfo");
                break;
            case CMSampleBufferAttachmentKey.ForceKeyFrame:
                return new NSString("kCMSampleBufferAttachmentKey_ForceKeyFrame");
                break;
            case CMSampleBufferAttachmentKey.Hdr10PlusPerFrameData:
                return new NSString("kCMSampleAttachmentKey_HDR10PlusPerFrameData");
                break;
            default:
                return new NSString("kCMSampleAttachmentKey_NotSyn");
                break;
        }
    }
}
