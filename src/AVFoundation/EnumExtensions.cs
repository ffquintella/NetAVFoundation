using AVFoundation;
using Foundation;

namespace NetAVFoundation;

public static class EnumExtensions
{
    public static NSString GetConstant(this AVMediaTypes self)
    {
        switch (self)
        {
            case AVMediaTypes.Video:
                return new NSString("AVMediaTypeVideo");
            case AVMediaTypes.Audio:
                return new NSString("AVMediaTypeAudio");
            case AVMediaTypes.Text:
                return new NSString("AVMediaTypeText");
            case AVMediaTypes.ClosedCaption:
                return new NSString("AVMediaTypeClosedCaption");
            case AVMediaTypes.Subtitle:
                return new NSString("AVMediaTypeSubtitle");
            case AVMediaTypes.Timecode:
                return new NSString("AVMediaTypeTimecode");
            case AVMediaTypes.Muxed:
                return new NSString("AVMediaTypeMuxed");
            case AVMediaTypes.MetadataObject:
                return new NSString("AVMediaTypeMetadataObject");
            case AVMediaTypes.Metadata:
                return new NSString("AVMediaTypeMetadata");
            case AVMediaTypes.DepthData:
                return new NSString("AVMediaTypeDepthData");
            case AVMediaTypes.AuxiliaryPicture:
                return new NSString("AVMediaTypeAuxiliaryPicture");
            case AVMediaTypes.Haptic:
                return new NSString("AVMediaTypeHaptic");
   

            default:
                return new NSString("AVMediaTypeVideo");
        }
    }
}