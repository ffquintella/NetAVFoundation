
using AVFoundation;
using Foundation;

public static class AVVideoApertureModeExtensions
{
    public static AVVideoApertureMode GetValue(NSString value)
    {
        if (value == "AVVideoApertureModeCleanAperture")
            return AVVideoApertureMode.CleanAperture;
        if (value == "AVVideoApertureModeProductionAperture")
            return AVVideoApertureMode.ProductionAperture;
        if (value == "AVVideoApertureModeEncodedPixels")
            return AVVideoApertureMode.EncodedPixels;
        return AVVideoApertureMode.EncodedPixels;
    }

    public static NSString GetConstant(this AVVideoApertureMode self)
    {
        switch (self)
        {
            case AVVideoApertureMode.CleanAperture:
                return new NSString("AVVideoApertureModeCleanAperture");
            case AVVideoApertureMode.ProductionAperture:
                return new NSString("AVVideoApertureModeProductionAperture");
            case AVVideoApertureMode.EncodedPixels:
                return new NSString("AVVideoApertureModeEncodedPixels");
            default:
                return new NSString("AVVideoApertureModeEncodedPixels");
        }
    }
}