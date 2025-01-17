//
// ImageIO.cs : Constants
//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2012-2014, Xamarin, Inc.
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

using ObjCRuntime;
using Foundation;
using CoreFoundation;
using CoreGraphics;
using System;

namespace ImageIO {

	/// <summary>Known properties of various metadata prefixes. Most often used with <see cref="M:ImageIO.CGImageMetadata.CopyTagMatchingImageProperty(Foundation.NSString,Foundation.NSString)" />.</summary>
	[Static]
	// Bad name should end with Keys
	public static class CGImageProperties {
		// Format-Specific Dictionaries
		[Field ("kCGImagePropertyTIFFDictionary")]
		public static extern NSString TIFFDictionary { get; }
		[Field ("kCGImagePropertyGIFDictionary")]
		public static extern NSString GIFDictionary { get; }
		[Field ("kCGImagePropertyJFIFDictionary")]
		public static extern NSString JFIFDictionary { get; }
		[Field ("kCGImagePropertyExifDictionary")]
		public static extern NSString ExifDictionary { get; }
		[Field ("kCGImagePropertyPNGDictionary")]
		public static extern NSString PNGDictionary { get; }
		[Field ("kCGImagePropertyIPTCDictionary")]
		public static extern NSString IPTCDictionary { get; }
		[Field ("kCGImagePropertyGPSDictionary")]
		public static extern NSString GPSDictionary { get; }
		[Field ("kCGImagePropertyRawDictionary")]
		public static extern NSString RawDictionary { get; }
		[Field ("kCGImagePropertyCIFFDictionary")]
		public static extern NSString CIFFDictionary { get; }
		[Field ("kCGImageProperty8BIMDictionary")]
		public static extern NSString EightBIMDictionary { get; }
		[Field ("kCGImagePropertyDNGDictionary")]
		public static extern NSString DNGDictionary { get; }
		[Field ("kCGImagePropertyExifAuxDictionary")]
		public static extern NSString ExifAuxDictionary { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSDictionary")]
		public static extern NSString HeicsDictionary { get; }

		//[iOS (14, 0), TV (14, 0), Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPDictionary")]
		public static extern NSString WebPDictionary { get; }

		//[iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImagePropertyTGADictionary")]
		public static extern NSString TgaDictionary { get; }

		//[Mac (14, 0), iOS (17, 0), TV (17, 0), Watch (10, 0), MacCatalyst (17, 0)]
		[Field ("kCGImagePropertyAVISDictionary")]
		public static extern NSString AvisDictionary { get; }

		// Camera-Maker Dictionaries
		[Field ("kCGImagePropertyMakerCanonDictionary")]
		public static extern NSString MakerCanonDictionary { get; }
		[Field ("kCGImagePropertyMakerNikonDictionary")]
		public static extern NSString MakerNikonDictionary { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerMinoltaDictionary")]
		public static extern NSString MakerMinoltaDictionary { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerFujiDictionary")]
		public static extern NSString MakerFujiDictionary { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerOlympusDictionary")]
		public static extern NSString MakerOlympusDictionary { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerPentaxDictionary")]
		public static extern NSString MakerPentaxDictionary { get; }

		// Image Source Container Properties
		[Field ("kCGImagePropertyFileSize")]
		public static extern NSString FileSize { get; }

		// Individual Image Properties
		[Field ("kCGImagePropertyDPIHeight")]
		public static extern NSString DPIHeight { get; }
		[Field ("kCGImagePropertyDPIWidth")]
		public static extern NSString DPIWidth { get; }
		[Field ("kCGImagePropertyPixelWidth")]
		public static extern NSString PixelWidth { get; }
		[Field ("kCGImagePropertyPixelHeight")]
		public static extern NSString PixelHeight { get; }
		[Field ("kCGImagePropertyDepth")]
		public static extern NSString Depth { get; }
		[Field ("kCGImagePropertyOrientation")]
		public static extern NSString Orientation { get; }
		[Field ("kCGImagePropertyIsFloat")]
		public static extern NSString IsFloat { get; }
		[Field ("kCGImagePropertyIsIndexed")]
		public static extern NSString IsIndexed { get; }
		[Field ("kCGImagePropertyHasAlpha")]
		public static extern NSString HasAlpha { get; }
		[Field ("kCGImagePropertyColorModel")]
		public static extern NSString ColorModel { get; }
		[Field ("kCGImagePropertyProfileName")]
		public static extern NSString ProfileName { get; }

		// Color Model Values

		[Field ("kCGImagePropertyColorModelRGB")]
		public static extern NSString ColorModelRGB { get; }
		[Field ("kCGImagePropertyColorModelGray")]
		public static extern NSString ColorModelGray { get; }
		[Field ("kCGImagePropertyColorModelCMYK")]
		public static extern NSString ColorModelCMYK { get; }
		[Field ("kCGImagePropertyColorModelLab")]
		public static extern NSString ColorModelLab { get; }

		// EXIF Dictionary Keys

		[Field ("kCGImagePropertyExifExposureTime")]
		public static extern NSString ExifExposureTime { get; }
		[Field ("kCGImagePropertyExifFNumber")]
		public static extern NSString ExifFNumber { get; }
		[Field ("kCGImagePropertyExifExposureProgram")]
		public static extern NSString ExifExposureProgram { get; }
		[Field ("kCGImagePropertyExifSpectralSensitivity")]
		public static extern NSString ExifSpectralSensitivity { get; }
		[Field ("kCGImagePropertyExifISOSpeedRatings")]
		public static extern NSString ExifISOSpeedRatings { get; }
		[Field ("kCGImagePropertyExifOECF")]
		public static extern NSString ExifOECF { get; }
		[Field ("kCGImagePropertyExifVersion")]
		public static extern NSString ExifVersion { get; }
		[Field ("kCGImagePropertyExifDateTimeOriginal")]
		public static extern NSString ExifDateTimeOriginal { get; }
		[Field ("kCGImagePropertyExifDateTimeDigitized")]
		public static extern NSString ExifDateTimeDigitized { get; }
		[Field ("kCGImagePropertyExifComponentsConfiguration")]
		public static extern NSString ExifComponentsConfiguration { get; }
		[Field ("kCGImagePropertyExifCompressedBitsPerPixel")]
		public static extern NSString ExifCompressedBitsPerPixel { get; }
		[Field ("kCGImagePropertyExifShutterSpeedValue")]
		public static extern NSString ExifShutterSpeedValue { get; }
		[Field ("kCGImagePropertyExifApertureValue")]
		public static extern NSString ExifApertureValue { get; }
		[Field ("kCGImagePropertyExifBrightnessValue")]
		public static extern NSString ExifBrightnessValue { get; }
		[Field ("kCGImagePropertyExifExposureBiasValue")]
		public static extern NSString ExifExposureBiasValue { get; }
		[Field ("kCGImagePropertyExifMaxApertureValue")]
		public static extern NSString ExifMaxApertureValue { get; }
		[Field ("kCGImagePropertyExifSubjectDistance")]
		public static extern NSString ExifSubjectDistance { get; }
		[Field ("kCGImagePropertyExifMeteringMode")]
		public static extern NSString ExifMeteringMode { get; }
		[Field ("kCGImagePropertyExifLightSource")]
		public static extern NSString ExifLightSource { get; }
		[Field ("kCGImagePropertyExifFlash")]
		public static extern NSString ExifFlash { get; }
		[Field ("kCGImagePropertyExifFocalLength")]
		public static extern NSString ExifFocalLength { get; }
		[Field ("kCGImagePropertyExifSubjectArea")]
		public static extern NSString ExifSubjectArea { get; }
		[Field ("kCGImagePropertyExifMakerNote")]
		public static extern NSString ExifMakerNote { get; }
		[Field ("kCGImagePropertyExifUserComment")]
		public static extern NSString ExifUserComment { get; }
		[Field ("kCGImagePropertyExifSubsecTime")]
		public static extern NSString ExifSubsecTime { get; }
		[Field ("kCGImagePropertyExifSubsecTimeOrginal")]
		public static extern NSString ExifSubsecTimeOrginal { get; }
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSubsecTimeOriginal")]
		public static extern NSString ExifSubsecTimeOriginal { get; }
		[Field ("kCGImagePropertyExifSubsecTimeDigitized")]
		public static extern NSString ExifSubsecTimeDigitized { get; }
		[Field ("kCGImagePropertyExifFlashPixVersion")]
		public static extern 	NSString ExifFlashPixVersion { get; }
		[Field ("kCGImagePropertyExifColorSpace")]
		public static extern NSString ExifColorSpace { get; }
		[Field ("kCGImagePropertyExifPixelXDimension")]
		public static extern NSString ExifPixelXDimension { get; }
		[Field ("kCGImagePropertyExifPixelYDimension")]
		public static extern NSString ExifPixelYDimension { get; }
		[Field ("kCGImagePropertyExifRelatedSoundFile")]
		public static extern NSString ExifRelatedSoundFile { get; }
		[Field ("kCGImagePropertyExifFlashEnergy")]
		public static extern NSString ExifFlashEnergy { get; }
		[Field ("kCGImagePropertyExifSpatialFrequencyResponse")]
		public static extern NSString ExifSpatialFrequencyResponse { get; }
		[Field ("kCGImagePropertyExifFocalPlaneXResolution")]
		public static extern NSString ExifFocalPlaneXResolution { get; }
		[Field ("kCGImagePropertyExifFocalPlaneYResolution")]
		public static extern NSString ExifFocalPlaneYResolution { get; }
		[Field ("kCGImagePropertyExifFocalPlaneResolutionUnit")]
		public static extern NSString ExifFocalPlaneResolutionUnit { get; }
		[Field ("kCGImagePropertyExifSubjectLocation")]
		public static extern NSString ExifSubjectLocation { get; }
		[Field ("kCGImagePropertyExifExposureIndex")]
		public static extern NSString ExifExposureIndex { get; }
		[Field ("kCGImagePropertyExifSensingMethod")]
		public static extern NSString ExifSensingMethod { get; }
		[Field ("kCGImagePropertyExifFileSource")]
		public static extern NSString ExifFileSource { get; }
		[Field ("kCGImagePropertyExifSceneType")]
		public static extern NSString ExifSceneType { get; }
		[Field ("kCGImagePropertyExifCFAPattern")]
		public static extern NSString ExifCFAPattern { get; }
		[Field ("kCGImagePropertyExifCustomRendered")]
		public static extern NSString ExifCustomRendered { get; }
		[Field ("kCGImagePropertyExifExposureMode")]
		public static extern NSString ExifExposureMode { get; }
		[Field ("kCGImagePropertyExifWhiteBalance")]
		public static extern NSString ExifWhiteBalance { get; }
		[Field ("kCGImagePropertyExifDigitalZoomRatio")]
		public static extern NSString ExifDigitalZoomRatio { get; }
		[Field ("kCGImagePropertyExifFocalLenIn35mmFilm")]
		public static extern NSString ExifFocalLenIn35mmFilm { get; }
		[Field ("kCGImagePropertyExifSceneCaptureType")]
		public static extern NSString ExifSceneCaptureType { get; }
		[Field ("kCGImagePropertyExifGainControl")]
		public static extern NSString ExifGainControl { get; }
		[Field ("kCGImagePropertyExifContrast")]
		public static extern 	NSString ExifContrast { get; }
		[Field ("kCGImagePropertyExifSaturation")]
		public static extern NSString ExifSaturation { get; }
		[Field ("kCGImagePropertyExifSharpness")]
		public static extern NSString ExifSharpness { get; }
		[Field ("kCGImagePropertyExifDeviceSettingDescription")]
		public static extern NSString ExifDeviceSettingDescription { get; }
		[Field ("kCGImagePropertyExifSubjectDistRange")]
		public static extern NSString ExifSubjectDistRange { get; }
		[Field ("kCGImagePropertyExifImageUniqueID")]
		public static extern NSString ExifImageUniqueID { get; }
		[Field ("kCGImagePropertyExifGamma")]
		public static extern NSString ExifGamma { get; }

		//[iOS (13, 1), TV (13, 1), Watch (6, 1)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifCompositeImage")]
		public static extern NSString ExifCompositeImage { get; }

		//[iOS (13, 1), TV (13, 1), Watch (6, 1)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSourceImageNumberOfCompositeImage")]
		public static extern NSString ExifSourceImageNumberOfCompositeImage { get; }

		//[iOS (13, 1), TV (13, 1), Watch (6, 1)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSourceExposureTimesOfCompositeImage")]
		public static extern NSString ExifSourceExposureTimesOfCompositeImage { get; }

		// misdocumented (first 4.3, then 5.0) but the constants were not present until 6.x

		[Field ("kCGImagePropertyExifCameraOwnerName")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifCameraOwnerName { get; }

		[Field ("kCGImagePropertyExifBodySerialNumber")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifBodySerialNumber { get; }

		[Field ("kCGImagePropertyExifLensSpecification")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifLensSpecification { get; }

		[Field ("kCGImagePropertyExifLensMake")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifLensMake { get; }

		[Field ("kCGImagePropertyExifLensModel")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifLensModel { get; }

		[Field ("kCGImagePropertyExifLensSerialNumber")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifLensSerialNumber { get; }

		// EXIF Auxiliary Dictionary Keys

		[Field ("kCGImagePropertyExifAuxLensInfo")]
		public static extern NSString ExifAuxLensInfo { get; }
		[Field ("kCGImagePropertyExifAuxLensModel")]
		public static extern NSString ExifAuxLensModel { get; }
		[Field ("kCGImagePropertyExifAuxSerialNumber")]
		public static extern NSString ExifAuxSerialNumber { get; }
		[Field ("kCGImagePropertyExifAuxLensID")]
		public static extern NSString ExifAuxLensID { get; }
		[Field ("kCGImagePropertyExifAuxLensSerialNumber")]
		public static extern NSString ExifAuxLensSerialNumber { get; }
		[Field ("kCGImagePropertyExifAuxImageNumber")]
		public static extern NSString ExifAuxImageNumber { get; }
		[Field ("kCGImagePropertyExifAuxFlashCompensation")]
		public static extern NSString ExifAuxFlashCompensation { get; }
		[Field ("kCGImagePropertyExifAuxOwnerName")]
		public static extern NSString ExifAuxOwnerName { get; }
		[Field ("kCGImagePropertyExifAuxFirmware")]
		public static extern NSString ExifAuxFirmware { get; }

		// GIF Dictionary Keys

		[Field ("kCGImagePropertyGIFLoopCount")]
		public static extern NSString GIFLoopCount { get; }
		[Field ("kCGImagePropertyGIFDelayTime")]
		public static extern NSString GIFDelayTime { get; }
		[Field ("kCGImagePropertyGIFImageColorMap")]
		public static extern NSString GIFImageColorMap { get; }
		[Field ("kCGImagePropertyGIFHasGlobalColorMap")]
		public static extern NSString GIFHasGlobalColorMap { get; }
		[Field ("kCGImagePropertyGIFUnclampedDelayTime")]
		public static extern NSString GIFUnclampedDelayTime { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGIFCanvasPixelWidth")]
		public static extern NSString GifCanvasPixelWidth { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGIFCanvasPixelHeight")]
		public static extern NSString GifCanvasPixelHeight { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGIFFrameInfoArray")]
		public static extern NSString GifFrameInfoArray { get; }

		// GPS Dictionary Keys

		[Field ("kCGImagePropertyGPSVersion")]
		public static extern NSString GPSVersion { get; }
		[Field ("kCGImagePropertyGPSLatitudeRef")]
		public static extern NSString GPSLatitudeRef { get; }
		[Field ("kCGImagePropertyGPSLatitude")]
		public static extern NSString GPSLatitude { get; }
		[Field ("kCGImagePropertyGPSLongitudeRef")]
		public static extern NSString GPSLongitudeRef { get; }
		[Field ("kCGImagePropertyGPSLongitude")]
		public static extern NSString GPSLongitude { get; }
		[Field ("kCGImagePropertyGPSAltitudeRef")]
		public static extern NSString GPSAltitudeRef { get; }
		[Field ("kCGImagePropertyGPSAltitude")]
		public static extern NSString GPSAltitude { get; }
		[Field ("kCGImagePropertyGPSTimeStamp")]
		public static extern NSString GPSTimeStamp { get; }
		[Field ("kCGImagePropertyGPSSatellites")]
		public static extern NSString GPSSatellites { get; }
		[Field ("kCGImagePropertyGPSStatus")]
		public static extern NSString GPSStatus { get; }
		[Field ("kCGImagePropertyGPSMeasureMode")]
		public static extern NSString GPSMeasureMode { get; }
		[Field ("kCGImagePropertyGPSDOP")]
		public static extern NSString GPSDOP { get; }
		[Field ("kCGImagePropertyGPSSpeedRef")]
		public static extern NSString GPSSpeedRef { get; }
		[Field ("kCGImagePropertyGPSSpeed")]
		public static extern NSString GPSSpeed { get; }
		[Field ("kCGImagePropertyGPSTrackRef")]
		public static extern NSString GPSTrackRef { get; }
		[Field ("kCGImagePropertyGPSTrack")]
		public static extern NSString GPSTrack { get; }
		[Field ("kCGImagePropertyGPSImgDirectionRef")]
		public static extern NSString GPSImgDirectionRef { get; }
		[Field ("kCGImagePropertyGPSImgDirection")]
		public static extern NSString GPSImgDirection { get; }
		[Field ("kCGImagePropertyGPSMapDatum")]
		public static extern NSString GPSMapDatum { get; }
		[Field ("kCGImagePropertyGPSDestLatitudeRef")]
		public static extern NSString GPSDestLatitudeRef { get; }
		[Field ("kCGImagePropertyGPSDestLatitude")]
		public static extern NSString GPSDestLatitude { get; }
		[Field ("kCGImagePropertyGPSDestLongitudeRef")]
		public static extern NSString GPSDestLongitudeRef { get; }
		[Field ("kCGImagePropertyGPSDestLongitude")]
		public static extern NSString GPSDestLongitude { get; }
		[Field ("kCGImagePropertyGPSDestBearingRef")]
		public static extern NSString GPSDestBearingRef { get; }
		[Field ("kCGImagePropertyGPSDestBearing")]
		public static extern NSString GPSDestBearing { get; }
		[Field ("kCGImagePropertyGPSDestDistanceRef")]
		public static extern NSString GPSDestDistanceRef { get; }
		[Field ("kCGImagePropertyGPSDestDistance")]
		public static extern NSString GPSDestDistance { get; }
		[Field ("kCGImagePropertyGPSAreaInformation")]
		public static extern NSString GPSAreaInformation { get; }
		[Field ("kCGImagePropertyGPSDateStamp")]
		public static extern NSString GPSDateStamp { get; }
		[Field ("kCGImagePropertyGPSDifferental")]
		public static extern NSString GPSDifferental { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGPSHPositioningError")]
		public static extern NSString GPSHPositioningError { get; }

		// IPTC Dictionary Keys

		[Field ("kCGImagePropertyIPTCObjectTypeReference")]
		public static extern NSString IPTCObjectTypeReference { get; }
		[Field ("kCGImagePropertyIPTCObjectAttributeReference")]
		public static extern NSString IPTCObjectAttributeReference { get; }
		[Field ("kCGImagePropertyIPTCObjectName")]
		public static extern NSString IPTCObjectName { get; }
		[Field ("kCGImagePropertyIPTCEditStatus")]
		public static extern NSString IPTCEditStatus { get; }
		[Field ("kCGImagePropertyIPTCEditorialUpdate")]
		public static extern NSString IPTCEditorialUpdate { get; }
		[Field ("kCGImagePropertyIPTCUrgency")]
		public static extern NSString IPTCUrgency { get; }
		[Field ("kCGImagePropertyIPTCSubjectReference")]
		public static extern NSString IPTCSubjectReference { get; }
		[Field ("kCGImagePropertyIPTCCategory")]
		public static extern NSString IPTCCategory { get; }
		[Field ("kCGImagePropertyIPTCSupplementalCategory")]
		public static extern NSString IPTCSupplementalCategory { get; }
		[Field ("kCGImagePropertyIPTCFixtureIdentifier")]
		public static extern NSString IPTCFixtureIdentifier { get; }
		[Field ("kCGImagePropertyIPTCKeywords")]
		public static extern NSString IPTCKeywords { get; }
		[Field ("kCGImagePropertyIPTCContentLocationCode")]
		public static extern NSString IPTCContentLocationCode { get; }
		[Field ("kCGImagePropertyIPTCContentLocationName")]
		public static extern NSString IPTCContentLocationName { get; }
		[Field ("kCGImagePropertyIPTCReleaseDate")]
		public static extern NSString IPTCReleaseDate { get; }
		[Field ("kCGImagePropertyIPTCReleaseTime")]
		public static extern NSString IPTCReleaseTime { get; }
		[Field ("kCGImagePropertyIPTCExpirationDate")]
		public static extern NSString IPTCExpirationDate { get; }
		[Field ("kCGImagePropertyIPTCExpirationTime")]
		public static extern NSString IPTCExpirationTime { get; }
		[Field ("kCGImagePropertyIPTCSpecialInstructions")]
		public static extern NSString IPTCSpecialInstructions { get; }
		[Field ("kCGImagePropertyIPTCActionAdvised")]
		public static extern NSString IPTCActionAdvised { get; }
		[Field ("kCGImagePropertyIPTCReferenceService")]
		public static extern NSString IPTCReferenceService { get; }
		[Field ("kCGImagePropertyIPTCReferenceDate")]
		public static extern NSString IPTCReferenceDate { get; }
		[Field ("kCGImagePropertyIPTCReferenceNumber")]
		public static extern NSString IPTCReferenceNumber { get; }
		[Field ("kCGImagePropertyIPTCDateCreated")]
		public static extern NSString IPTCDateCreated { get; }
		[Field ("kCGImagePropertyIPTCTimeCreated")]
		public static extern NSString IPTCTimeCreated { get; }
		[Field ("kCGImagePropertyIPTCDigitalCreationDate")]
		public static extern NSString IPTCDigitalCreationDate { get; }
		[Field ("kCGImagePropertyIPTCDigitalCreationTime")]
		public static extern NSString IPTCDigitalCreationTime { get; }
		[Field ("kCGImagePropertyIPTCOriginatingProgram")]
		public static extern NSString IPTCOriginatingProgram { get; }
		[Field ("kCGImagePropertyIPTCProgramVersion")]
		public static extern NSString IPTCProgramVersion { get; }
		[Field ("kCGImagePropertyIPTCObjectCycle")]
		public static extern NSString IPTCObjectCycle { get; }
		[Field ("kCGImagePropertyIPTCByline")]
		public static extern NSString IPTCByline { get; }
		[Field ("kCGImagePropertyIPTCBylineTitle")]
		public static extern NSString IPTCBylineTitle { get; }
		[Field ("kCGImagePropertyIPTCCity")]
		public static extern NSString IPTCCity { get; }
		[Field ("kCGImagePropertyIPTCSubLocation")]
		public static extern NSString IPTCSubLocation { get; }
		[Field ("kCGImagePropertyIPTCProvinceState")]
		public static extern NSString IPTCProvinceState { get; }
		[Field ("kCGImagePropertyIPTCCountryPrimaryLocationCode")]
		public static extern NSString IPTCCountryPrimaryLocationCode { get; }
		[Field ("kCGImagePropertyIPTCCountryPrimaryLocationName")]
		public static extern NSString IPTCCountryPrimaryLocationName { get; }
		[Field ("kCGImagePropertyIPTCOriginalTransmissionReference")]
		public static extern NSString IPTCOriginalTransmissionReference { get; }
		[Field ("kCGImagePropertyIPTCHeadline")]
		public static extern NSString IPTCHeadline { get; }
		[Field ("kCGImagePropertyIPTCCredit")]
		public static extern NSString IPTCCredit { get; }
		[Field ("kCGImagePropertyIPTCSource")]
		public static extern NSString IPTCSource { get; }
		[Field ("kCGImagePropertyIPTCCopyrightNotice")]
		public static extern NSString IPTCCopyrightNotice { get; }
		[Field ("kCGImagePropertyIPTCContact")]
		public static extern NSString IPTCContact { get; }
		[Field ("kCGImagePropertyIPTCCaptionAbstract")]
		public static extern NSString IPTCCaptionAbstract { get; }
		[Field ("kCGImagePropertyIPTCWriterEditor")]
		public static extern NSString IPTCWriterEditor { get; }
		[Field ("kCGImagePropertyIPTCImageType")]
		public static extern NSString IPTCImageType { get; }
		[Field ("kCGImagePropertyIPTCImageOrientation")]
		public static extern NSString IPTCImageOrientation { get; }
		[Field ("kCGImagePropertyIPTCLanguageIdentifier")]
		public static extern NSString IPTCLanguageIdentifier { get; }
		[Field ("kCGImagePropertyIPTCStarRating")]
		public static extern NSString IPTCStarRating { get; }
		[Field ("kCGImagePropertyIPTCCreatorContactInfo")]
		public static extern NSString IPTCCreatorContactInfo { get; }
		[Field ("kCGImagePropertyIPTCRightsUsageTerms")]
		public static extern NSString IPTCRightsUsageTerms { get; }
		[Field ("kCGImagePropertyIPTCScene")]
		public static extern NSString IPTCScene { get; }

		// IPTC Creator Contact Info Dictionary Keys

		[Field ("kCGImagePropertyIPTCContactInfoCity")]
		public static extern NSString IPTCContactInfoCity { get; }
		[Field ("kCGImagePropertyIPTCContactInfoCountry")]
		public static extern NSString IPTCContactInfoCountry { get; }
		[Field ("kCGImagePropertyIPTCContactInfoAddress")]
		public static extern NSString IPTCContactInfoAddress { get; }
		[Field ("kCGImagePropertyIPTCContactInfoPostalCode")]
		public static extern NSString IPTCContactInfoPostalCode { get; }
		[Field ("kCGImagePropertyIPTCContactInfoStateProvince")]
		public static extern NSString IPTCContactInfoStateProvince { get; }
		[Field ("kCGImagePropertyIPTCContactInfoEmails")]
		public static extern NSString IPTCContactInfoEmails { get; }
		[Field ("kCGImagePropertyIPTCContactInfoPhones")]
		public static extern NSString IPTCContactInfoPhones { get; }
		[Field ("kCGImagePropertyIPTCContactInfoWebURLs")]
		public static extern NSString IPTCContactInfoWebURLs { get; }

		// JFIF Dictionary Keys

		[Field ("kCGImagePropertyJFIFVersion")]
		public static extern NSString JFIFVersion { get; }
		[Field ("kCGImagePropertyJFIFXDensity")]
		public static extern NSString JFIFXDensity { get; }
		[Field ("kCGImagePropertyJFIFYDensity")]
		public static extern NSString JFIFYDensity { get; }
		[Field ("kCGImagePropertyJFIFDensityUnit")]
		public static extern NSString JFIFDensityUnit { get; }
		[Field ("kCGImagePropertyJFIFIsProgressive")]
		public static extern NSString JFIFIsProgressive { get; }

		// PNG Dictionary Keys

		[Field ("kCGImagePropertyPNGGamma")]
		public static extern NSString PNGGamma { get; }
		[Field ("kCGImagePropertyPNGInterlaceType")]
		public static extern NSString PNGInterlaceType { get; }
		[Field ("kCGImagePropertyPNGXPixelsPerMeter")]
		public static extern NSString PNGXPixelsPerMeter { get; }
		[Field ("kCGImagePropertyPNGYPixelsPerMeter")]
		public static extern NSString PNGYPixelsPerMeter { get; }
		[Field ("kCGImagePropertyPNGsRGBIntent")]
		public static extern NSString PNGsRGBIntent { get; }
		[Field ("kCGImagePropertyPNGChromaticities")]
		public static extern NSString PNGChromaticities { get; }
		[Field ("kCGImagePropertyPNGAuthor")]
		public static extern NSString PNGAuthor { get; }
		[Field ("kCGImagePropertyPNGCopyright")]
		public static extern NSString PNGCopyright { get; }
		[Field ("kCGImagePropertyPNGCreationTime")]
		public static extern NSString PNGCreationTime { get; }
		[Field ("kCGImagePropertyPNGDescription")]
		public static extern NSString PNGDescription { get; }
		[Field ("kCGImagePropertyPNGModificationTime")]
		public static extern NSString PNGModificationTime { get; }
		[Field ("kCGImagePropertyPNGSoftware")]
		public static extern NSString PNGSoftware { get; }
		[Field ("kCGImagePropertyPNGTitle")]
		public static extern NSString PNGTitle { get; }
		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyPNGPixelsAspectRatio")]
		public static extern NSString PNGPixelsAspectRatio { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGCompressionFilter")]
		public static extern NSString PNGCompressionFilter { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGLoopCount")]
		public static extern NSString PNGLoopCount { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGDelayTime")]
		public static extern NSString PNGDelayTime { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGUnclampedDelayTime")]
		public static extern NSString PNGUnclampedDelayTime { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGFrameInfoArray")]
		public static extern NSString ApngFrameInfoArray { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGCanvasPixelWidth")]
		public static extern NSString ApngCanvasPixelWidth { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGCanvasPixelHeight")]
		public static extern NSString ApngCanvasPixelHeight { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGComment")]
		public static extern NSString PNGComment { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGDisclaimer")]
		public static extern NSString PNGDisclaimer { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGSource")]
		public static extern 	NSString PNGSource { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGWarning")]
		public static extern NSString PNGWarning { get; }

		//[Watch (7, 4), TV (14, 5), iOS (14, 5)]
		[MacCatalyst (14, 5)]
		[Field ("kCGImagePropertyPNGTransparency")]
		public static extern NSString PNGTransparency { get; }

		// TIFF Dictionary Keys

		[Field ("kCGImagePropertyTIFFCompression")]
		public static extern NSString TIFFCompression { get; }
		[Field ("kCGImagePropertyTIFFPhotometricInterpretation")]
		public static extern NSString TIFFPhotometricInterpretation { get; }
		[Field ("kCGImagePropertyTIFFDocumentName")]
		public static extern NSString TIFFDocumentName { get; }
		[Field ("kCGImagePropertyTIFFImageDescription")]
		public static extern NSString TIFFImageDescription { get; }
		[Field ("kCGImagePropertyTIFFMake")]
		public static extern NSString TIFFMake { get; }
		[Field ("kCGImagePropertyTIFFModel")]
		public static extern NSString TIFFModel { get; }
		[Field ("kCGImagePropertyTIFFOrientation")]
		public static extern NSString TIFFOrientation { get; }
		[Field ("kCGImagePropertyTIFFXResolution")]
		public static extern NSString TIFFXResolution { get; }
		[Field ("kCGImagePropertyTIFFYResolution")]
		public static extern NSString TIFFYResolution { get; }
		//[Mac (14, 4), iOS (17, 4), MacCatalyst (17, 4), TV (17, 4), Watch (10, 4)]
		[Field ("kCGImagePropertyTIFFXPosition")]
		public static extern NSString TIFFXPosition { get; }
		//[Mac (14, 4), iOS (17, 4), MacCatalyst (17, 4), TV (17, 4), Watch (10, 4)]
		[Field ("kCGImagePropertyTIFFYPosition")]
		public static extern NSString TIFFYPosition { get; }
		[Field ("kCGImagePropertyTIFFResolutionUnit")]
		public static extern NSString TIFFResolutionUnit { get; }
		[Field ("kCGImagePropertyTIFFSoftware")]
		public static extern NSString TIFFSoftware { get; }
		[Field ("kCGImagePropertyTIFFTransferFunction")]
		public static extern NSString TIFFTransferFunction { get; }
		[Field ("kCGImagePropertyTIFFDateTime")]
		public static extern NSString TIFFDateTime { get; }
		[Field ("kCGImagePropertyTIFFArtist")]
		public static extern NSString TIFFArtist { get; }
		[Field ("kCGImagePropertyTIFFHostComputer")]
		public static extern NSString TIFFHostComputer { get; }
		[Field ("kCGImagePropertyTIFFWhitePoint")]
		public static extern 	NSString TIFFWhitePoint { get; }
		[Field ("kCGImagePropertyTIFFPrimaryChromaticities")]
		public static extern 	NSString TIFFPrimaryChromaticities { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyTIFFTileLength")]
		public static extern NSString TIFFTileLength { get; }
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyTIFFTileWidth")]
		public static extern NSString TIFFTileWidth { get; }

		// DNG Dictionary Keys

		[Field ("kCGImagePropertyDNGVersion")]
		public static extern 	NSString DNGVersion { get; }
		[Field ("kCGImagePropertyDNGBackwardVersion")]
		public static extern NSString DNGBackwardVersion { get; }
		[Field ("kCGImagePropertyDNGUniqueCameraModel")]
		public static extern NSString DNGUniqueCameraModel { get; }
		[Field ("kCGImagePropertyDNGLocalizedCameraModel")]
		public static extern NSString DNGLocalizedCameraModel { get; }
		[Field ("kCGImagePropertyDNGCameraSerialNumber")]
		public static extern 	NSString DNGCameraSerialNumber { get; }
		[Field ("kCGImagePropertyDNGLensInfo")]
		public static extern NSString DNGLensInfo { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevel")]
		public static extern NSString DNGBlackLevel { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGWhiteLevel")]
		public static extern NSString DNGWhiteLevel { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCalibrationIlluminant1")]
		public static extern NSString DNGCalibrationIlluminant1 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCalibrationIlluminant2")]
		public static extern NSString DNGCalibrationIlluminant2 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGColorMatrix1")]
		public static extern NSString DNGColorMatrix1 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGColorMatrix2")]
		public static extern 	NSString DNGColorMatrix2 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCameraCalibration1")]
		public static extern NSString DNGCameraCalibration1 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCameraCalibration2")]
		public static extern NSString DNGCameraCalibration2 { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotNeutral")]
		public static extern NSString DNGAsShotNeutral { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotWhiteXY")]
		public static extern NSString DNGAsShotWhiteXY { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineExposure")]
		public static extern NSString DNGBaselineExposure { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineNoise")]
		public static extern NSString DNGBaselineNoise { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineSharpness")]
		public static extern NSString DNGBaselineSharpness { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPrivateData")]
		public static extern NSString DNGPrivateData { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCameraCalibrationSignature")]
		public static extern NSString DNGCameraCalibrationSignature { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileCalibrationSignature")]
		public static extern NSString DNGProfileCalibrationSignature { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGNoiseProfile")]
		public static extern NSString DNGNoiseProfile { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGWarpRectilinear")]
		public static extern NSString DNGWarpRectilinear { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGWarpFisheye")]
		public static extern NSString DNGWarpFisheye { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGFixVignetteRadial")]
		public static extern NSString DNGFixVignetteRadial { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGActiveArea")]
		public static extern NSString DNGActiveArea { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAnalogBalance")]
		public static extern NSString DNGAnalogBalance { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAntiAliasStrength")]
		public static extern 	NSString DNGAntiAliasStrength { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotICCProfile")]
		public static extern NSString DNGAsShotICCProfile { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotPreProfileMatrix")]
		public static extern NSString DNGAsShotPreProfileMatrix { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotProfileName")]
		public static extern NSString DNGAsShotProfileName { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineExposureOffset")]
		public static extern NSString DNGBaselineExposureOffset { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBayerGreenSplit")]
		public static extern NSString DNGBayerGreenSplit { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBestQualityScale")]
		public static extern NSString DNGBestQualityScale { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevelDeltaH")]
		public static extern NSString DNGBlackLevelDeltaHorizontal { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevelDeltaV")]
		public static extern NSString DNGBlackLevelDeltaVertical { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevelRepeatDim")]
		public static extern NSString DNGBlackLevelRepeatDim { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCFALayout")]
		public static extern NSString DNGCfaLayout { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCFAPlaneColor")]
		public static extern NSString DNGCfaPlaneColor { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGChromaBlurRadius")]
		public static extern NSString DNGChromaBlurRadius { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGColorimetricReference")]
		public static extern NSString DNGColorimetricReference { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCurrentICCProfile")]
		public static extern NSString DNGCurrentICCProfile { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCurrentPreProfileMatrix")]
		public static extern NSString DNGCurrentPreProfileMatrix { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultBlackRender")]
		public static extern NSString DNGDefaultBlackRender { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultCropOrigin")]
		public static extern NSString DNGDefaultCropOrigin { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultCropSize")]
		public static extern NSString DNGDefaultCropSize { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultScale")]
		public static extern NSString DNGDefaultScale { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultUserCrop")]
		public static extern NSString DNGDefaultUserCrop { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGExtraCameraProfiles")]
		public static extern NSString DNGExtraCameraProfiles { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGForwardMatrix1")]
		public static extern NSString DNGForwardMatrix1 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGForwardMatrix2")]
		public static extern NSString DNGForwardMatrix2 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGLinearizationTable")]
		public static extern 	NSString DNGLinearizationTable { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGLinearResponseLimit")]
		public static extern NSString DNGLinearResponseLimit { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGMakerNoteSafety")]
		public static extern NSString DNGMakerNoteSafety { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGMaskedAreas")]
		public static extern NSString DNGMaskedAreas { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGNewRawImageDigest")]
		public static extern NSString DNGNewRawImageDigest { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGNoiseReductionApplied")]
		public static extern NSString DNGNoiseReductionApplied { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOpcodeList1")]
		public static extern NSString DNGOpcodeList1 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOpcodeList2")]
		public static extern NSString DNGOpcodeList2 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOpcodeList3")]
		public static extern NSString DNGOpcodeList3 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalBestQualityFinalSize")]
		public static extern NSString DNGOriginalBestQualityFinalSize { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalDefaultCropSize")]
		public static extern NSString DNGOriginalDefaultCropSize { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalDefaultFinalSize")]
		public static extern NSString DNGOriginalDefaultFinalSize { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalRawFileData")]
		public static extern NSString DNGOriginalRawFileData { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalRawFileDigest")]
		public static extern NSString DNGOriginalRawFileDigest { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalRawFileName")]
		public static extern NSString DNGOriginalRawFileName { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewApplicationName")]
		public static extern NSString DNGPreviewApplicationName { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewApplicationVersion")]
		public static extern NSString DNGPreviewApplicationVersion { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewColorSpace")]
		public static extern NSString DNGPreviewColorSpace { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewDateTime")]
		public static extern NSString DNGPreviewDateTime { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewSettingsDigest")]
		public static extern NSString DNGPreviewSettingsDigest { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewSettingsName")]
		public static extern NSString DNGPreviewSettingsName { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileCopyright")]
		public static extern NSString DNGProfileCopyright { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileEmbedPolicy")]
		public static extern NSString DNGProfileEmbedPolicy { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapData1")]
		public static extern NSString DNGProfileHueSatMapData1 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapData2")]
		public static extern NSString DNGProfileHueSatMapData2 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapDims")]
		public static extern NSString DNGProfileHueSatMapDims { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapEncoding")]
		public static extern NSString DNGProfileHueSatMapEncoding { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileLookTableData")]
		public static extern NSString DNGProfileLookTableData { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileLookTableDims")]
		public static extern NSString DNGProfileLookTableDims { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileLookTableEncoding")]
		public static extern NSString DNGProfileLookTableEncoding { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileName")]
		public static extern 	NSString DNGProfileName { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileToneCurve")]
		public static extern NSString DNGProfileToneCurve { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRawDataUniqueID")]
		public static extern NSString DNGRawDataUniqueId { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRawImageDigest")]
		public static extern NSString DNGRawImageDigest { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRawToPreviewGain")]
		public static extern NSString DNGRawToPreviewGain { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGReductionMatrix1")]
		public static extern NSString DNGReductionMatrix1 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGReductionMatrix2")]
		public static extern 	NSString DNGReductionMatrix2 { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRowInterleaveFactor")]
		public static extern NSString DNGRowInterleaveFactor { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGShadowScale")]
		public static extern NSString DNGShadowScale { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGSubTileBlockSize")]
		public static extern NSString DNGSubTileBlockSize { get; }

		// 8BIM Dictionary Keys

		[Field ("kCGImageProperty8BIMLayerNames")]
		public static extern NSString EightBIMLayerNames { get; }

		// CIFF Dictionary Keys

		[Field ("kCGImagePropertyCIFFDescription")]
		public static extern 	NSString CIFFDescription { get; }
		[Field ("kCGImagePropertyCIFFFirmware")]
		public static extern 	NSString CIFFFirmware { get; }
		[Field ("kCGImagePropertyCIFFOwnerName")]
		public static extern NSString CIFFOwnerName { get; }
		[Field ("kCGImagePropertyCIFFImageName")]
		public static extern NSString CIFFImageName { get; }
		[Field ("kCGImagePropertyCIFFImageFileName")]
		public static extern NSString CIFFImageFileName { get; }
		[Field ("kCGImagePropertyCIFFReleaseMethod")]
		public static extern NSString CIFFReleaseMethod { get; }
		[Field ("kCGImagePropertyCIFFReleaseTiming")]
		public static extern NSString CIFFReleaseTiming { get; }
		[Field ("kCGImagePropertyCIFFRecordID")]
		public static extern NSString CIFFRecordID { get; }
		[Field ("kCGImagePropertyCIFFSelfTimingTime")]
		public static extern NSString CIFFSelfTimingTime { get; }
		[Field ("kCGImagePropertyCIFFCameraSerialNumber")]
		public static extern NSString CIFFCameraSerialNumber { get; }
		[Field ("kCGImagePropertyCIFFImageSerialNumber")]
		public static extern NSString CIFFImageSerialNumber { get; }
		[Field ("kCGImagePropertyCIFFContinuousDrive")]
		public static extern NSString CIFFContinuousDrive { get; }
		[Field ("kCGImagePropertyCIFFFocusMode")]
		public static extern NSString CIFFFocusMode { get; }
		[Field ("kCGImagePropertyCIFFMeteringMode")]
		public static extern NSString CIFFMeteringMode { get; }
		[Field ("kCGImagePropertyCIFFShootingMode")]
		public static extern NSString CIFFShootingMode { get; }
		[Field ("kCGImagePropertyCIFFLensMaxMM")]
		public static extern NSString CIFFLensMaxMM { get; }
		[Field ("kCGImagePropertyCIFFLensMinMM")]
		public static extern 	NSString CIFFLensMinMM { get; }
		[Field ("kCGImagePropertyCIFFLensModel")]
	public static extern 	NSString CIFFLensModel { get; }
		[Field ("kCGImagePropertyCIFFWhiteBalanceIndex")]
		public static extern NSString CIFFWhiteBalanceIndex { get; }
		[Field ("kCGImagePropertyCIFFFlashExposureComp")]
	public static extern 	NSString CIFFFlashExposureComp { get; }
		[Field ("kCGImagePropertyCIFFMeasuredEV")]
	public static extern 	NSString CIFFMeasuredEV { get; }

		// HEICS

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSLoopCount")]
		public static extern NSString HeicsLoopCount { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSDelayTime")]
		public static extern NSString HeicsDelayTime { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSUnclampedDelayTime")]
		public static extern NSString HeicsSUnclampedDelayTime { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSCanvasPixelWidth")]
		public static extern NSString HeicsCanvasPixelWidth { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSCanvasPixelHeight")]
		public static extern NSString HeicsCanvasPixelHeight { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSFrameInfoArray")]
		public static extern NSString HeicsFrameInfoArray { get; }

		// Nikon Camera Dictionary Keys

		[Field ("kCGImagePropertyMakerNikonISOSetting")]
		public static extern NSString MakerNikonISOSetting { get; }
		[Field ("kCGImagePropertyMakerNikonColorMode")]
		public static extern NSString MakerNikonColorMode { get; }
		[Field ("kCGImagePropertyMakerNikonQuality")]
		public static extern NSString MakerNikonQuality { get; }
		[Field ("kCGImagePropertyMakerNikonWhiteBalanceMode")]
		public static extern NSString MakerNikonWhiteBalanceMode { get; }
		[Field ("kCGImagePropertyMakerNikonSharpenMode")]
		public static extern NSString MakerNikonSharpenMode { get; }
		[Field ("kCGImagePropertyMakerNikonFocusMode")]
		public static extern NSString MakerNikonFocusMode { get; }
		[Field ("kCGImagePropertyMakerNikonFlashSetting")]
		public static extern NSString MakerNikonFlashSetting { get; }
		[Field ("kCGImagePropertyMakerNikonISOSelection")]
		public static extern NSString MakerNikonISOSelection { get; }
		[Field ("kCGImagePropertyMakerNikonFlashExposureComp")]
		public static extern NSString MakerNikonFlashExposureComp { get; }
		[Field ("kCGImagePropertyMakerNikonImageAdjustment")]
		public static extern NSString MakerNikonImageAdjustment { get; }
		[Field ("kCGImagePropertyMakerNikonLensAdapter")]
		public static extern NSString MakerNikonLensAdapter { get; }
		[Field ("kCGImagePropertyMakerNikonLensType")]
		public static extern NSString MakerNikonLensType { get; }
		[Field ("kCGImagePropertyMakerNikonLensInfo")]
		public static extern NSString MakerNikonLensInfo { get; }
		[Field ("kCGImagePropertyMakerNikonFocusDistance")]
		public static extern NSString MakerNikonFocusDistance { get; }
		[Field ("kCGImagePropertyMakerNikonDigitalZoom")]
		public static extern NSString MakerNikonDigitalZoom { get; }
		[Field ("kCGImagePropertyMakerNikonShootingMode")]
		public static extern NSString MakerNikonShootingMode { get; }
		[Field ("kCGImagePropertyMakerNikonShutterCount")]
		public static extern NSString MakerNikonShutterCount { get; }
		[Field ("kCGImagePropertyMakerNikonCameraSerialNumber")]
		public static extern NSString MakerNikonCameraSerialNumber { get; }

		// Canon Camera Dictionary Keys

		[Field ("kCGImagePropertyMakerCanonOwnerName")]
		public static extern NSString MakerCanonOwnerName { get; }
		[Field ("kCGImagePropertyMakerCanonCameraSerialNumber")]
		public static extern 	NSString MakerCanonCameraSerialNumber { get; }
		[Field ("kCGImagePropertyMakerCanonImageSerialNumber")]
		public static extern 	NSString MakerCanonImageSerialNumber { get; }
		[Field ("kCGImagePropertyMakerCanonFlashExposureComp")]
		public static extern NSString MakerCanonFlashExposureComp { get; }
		[Field ("kCGImagePropertyMakerCanonContinuousDrive")]
		public static extern NSString MakerCanonContinuousDrive { get; }
		[Field ("kCGImagePropertyMakerCanonLensModel")]
		public static extern NSString MakerCanonLensModel { get; }
		[Field ("kCGImagePropertyMakerCanonFirmware")]
		public static extern NSString MakerCanonFirmware { get; }
		[Field ("kCGImagePropertyMakerCanonAspectRatioInfo")]
		public static extern NSString MakerCanonAspectRatioInfo { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifISOSpeed")]
		public static extern NSString ExifISOSpeed { get; }
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifISOSpeedLatitudeyyy")]
		public static extern NSString ExifISOSpeedLatitudeYyy { get; }
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifISOSpeedLatitudezzz")]
		public static extern NSString ExifISOSpeedLatitudeZzz { get; }
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifRecommendedExposureIndex")]
		public static extern NSString ExifRecommendedExposureIndex { get; }
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSensitivityType")]
		public static extern NSString ExifSensitivityType { get; }
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifStandardOutputSensitivity")]
		public static extern NSString ExifStandardOutputSensitivity { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifOffsetTime")]
		public static extern NSString ExifOffsetTime { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifOffsetTimeOriginal")]
		public static extern NSString ExifOffsetTimeOriginal { get; }

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifOffsetTimeDigitized")]
		public static extern NSString ExifOffsetTimeDigitized { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerAppleDictionary")]
		public static extern NSString MakerAppleDictionary { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyImageCount")]
		public static extern NSString ImageCount { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyImageIndex")]
		public static extern NSString ImageIndex { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyWidth")]
		public static extern NSString Width { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHeight")]
		public static extern NSString Height { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyBytesPerRow")]
		public static extern NSString BytesPerRow { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyNamedColorSpace")]
		public static extern NSString NamedColorSpace { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPixelFormat")]
		public static extern NSString PixelFormat { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyImages")]
		public static extern NSString Images { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyThumbnailImages")]
		public static extern NSString ThumbnailImages { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAuxiliaryData")]
		public static extern NSString AuxiliaryData { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAuxiliaryDataType")]
		public static extern NSString AuxiliaryDataType { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyFileContentsDictionary")]
		public static extern NSString FileContentsDictionary { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyOpenEXRDictionary")]
		public static extern NSString OpenExrDictionary { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTerm")]
		public static extern NSString IPTCExtAboutCvTerm { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermCvId")]
		public static extern NSString IPTCExtAboutCvTermCvId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermId")]
		public static extern NSString IPTCExtAboutCvTermId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermName")]
		public static extern NSString IPTCExtAboutCvTermName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermRefinedAbout")]
		public static extern NSString IPTCExtAboutCvTermRefinedAbout { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAddlModelInfo")]
		public static extern NSString IPTCExtAddlModelInfo { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkOrObject")]
		public static extern NSString IPTCExtArtworkOrObject { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCircaDateCreated")]
		public static extern NSString IPTCExtArtworkCircaDateCreated { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkContentDescription")]
		public static extern NSString IPTCExtArtworkContentDescription { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkContributionDescription")]
		public static extern NSString IPTCExtArtworkContributionDescription { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCopyrightNotice")]
		public static extern NSString IPTCExtArtworkCopyrightNotice { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCreator")]
		public static extern NSString IPTCExtArtworkCreator { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCreatorID")]
		public static extern NSString IPTCExtArtworkCreatorId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCopyrightOwnerID")]
		public static extern NSString IPTCExtArtworkCopyrightOwnerId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCopyrightOwnerName")]
		public static extern NSString IPTCExtArtworkCopyrightOwnerName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkLicensorID")]
		public static extern NSString IPTCExtArtworkLicensorId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkLicensorName")]
		public static extern NSString IPTCExtArtworkLicensorName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkDateCreated")]
		public static extern NSString IPTCExtArtworkDateCreated { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkPhysicalDescription")]
		public static extern NSString IPTCExtArtworkPhysicalDescription { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkSource")]
		public static extern NSString IPTCExtArtworkSource { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkSourceInventoryNo")]
		public static extern NSString IPTCExtArtworkSourceInventoryNo { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkSourceInvURL")]
		public static extern NSString IPTCExtArtworkSourceInvUrl { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkStylePeriod")]
		public static extern NSString IPTCExtArtworkStylePeriod { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkTitle")]
		public static extern NSString IPTCExtArtworkTitle { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAudioBitrate")]
		public static extern NSString IPTCExtAudioBitrate { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAudioBitrateMode")]
		public static extern NSString IPTCExtAudioBitrateMode { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAudioChannelCount")]
		public static extern NSString IPTCExtAudioChannelCount { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCircaDateCreated")]
		public static extern NSString IPTCExtCircaDateCreated { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContainerFormat")]
		public static extern NSString IPTCExtContainerFormat { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContainerFormatIdentifier")]
		public static extern NSString IPTCExtContainerFormatIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContainerFormatName")]
		public static extern NSString IPTCExtContainerFormatName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributor")]
		public static extern NSString IPTCExtContributor { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributorIdentifier")]
		public static extern NSString IPTCExtContributorIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributorName")]
		public static extern NSString IPTCExtContributorName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributorRole")]
		public static extern NSString IPTCExtContributorRole { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCopyrightYear")]
		public static extern NSString IPTCExtCopyrightYear { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreator")]
		public static extern NSString IPTCExtCreator { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreatorIdentifier")]
		public static extern NSString IPTCExtCreatorIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreatorName")]
		public static extern NSString IPTCExtCreatorName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreatorRole")]
		public static extern NSString IPTCExtCreatorRole { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtControlledVocabularyTerm")]
		public static extern NSString IPTCExtControlledVocabularyTerm { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreen")]
		public static extern NSString IPTCExtDataOnScreen { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegion")]
		public static extern NSString IPTCExtDataOnScreenRegion { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionD")]
		public static extern NSString IPTCExtDataOnScreenRegionD { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionH")]
		public static extern NSString IPTCExtDataOnScreenRegionH { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionText")]
		public static extern NSString IPTCExtDataOnScreenRegionText { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionUnit")]
		public static extern NSString IPTCExtDataOnScreenRegionUnit { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionW")]
		public static extern NSString IPTCExtDataOnScreenRegionW { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionX")]
		public static extern NSString IPTCExtDataOnScreenRegionX { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionY")]
		public static extern NSString IPTCExtDataOnScreenRegionY { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDigitalImageGUID")]
		public static extern NSString IPTCExtDigitalImageGuid { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDigitalSourceFileType")]
		public static extern NSString IPTCExtDigitalSourceFileType { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDigitalSourceType")]
		public static extern NSString IPTCExtDigitalSourceType { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheet")]
		public static extern NSString IPTCExtDopesheet { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheetLink")]
		public static extern NSString IPTCExtDopesheetLink { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheetLinkLink")]
		public static extern NSString IPTCExtDopesheetLinkLink { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheetLinkLinkQualifier")]
		public static extern NSString IPTCExtDopesheetLinkLinkQualifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbdEncRightsExpr")]
		public static extern NSString IPTCExtEmbdEncRightsExpr { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbeddedEncodedRightsExpr")]
		public static extern NSString IPTCExtEmbeddedEncodedRightsExpr { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbeddedEncodedRightsExprType")]
		public static extern NSString IPTCExtEmbeddedEncodedRightsExprType { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbeddedEncodedRightsExprLangID")]
		public static extern NSString IPTCExtEmbeddedEncodedRightsExprLangId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisode")]
		public static extern NSString IPTCExtEpisode { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisodeIdentifier")]
		public static extern NSString IPTCExtEpisodeIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisodeName")]
		public static extern NSString IPTCExtEpisodeName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisodeNumber")]
		public static extern NSString IPTCExtEpisodeNumber { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEvent")]
		public static extern NSString IPTCExtEvent { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtShownEvent")]
		public static extern NSString IPTCExtShownEvent { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtShownEventIdentifier")]
		public static extern NSString IPTCExtShownEventIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtShownEventName")]
		public static extern NSString IPTCExtShownEventName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtExternalMetadataLink")]
		public static extern NSString IPTCExtExternalMetadataLink { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtFeedIdentifier")]
		public static extern NSString IPTCExtFeedIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenre")]
		public static extern NSString IPTCExtGenre { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvId")]
		public static extern NSString IPTCExtGenreCvId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvTermId")]
		public static extern NSString IPTCExtGenreCvTermId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvTermName")]
		public static extern NSString IPTCExtGenreCvTermName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvTermRefinedAbout")]
		public static extern NSString IPTCExtGenreCvTermRefinedAbout { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtHeadline")]
		public static extern NSString IPTCExtHeadline { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtIPTCLastEdited")]
		public static extern NSString IPTCExtIPTCLastEdited { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncRightsExpr")]
		public static extern NSString IPTCExtLinkedEncRightsExpr { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncodedRightsExpr")]
		public static extern NSString IPTCExtLinkedEncodedRightsExpr { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncodedRightsExprType")]
		public static extern NSString IPTCExtLinkedEncodedRightsExprType { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncodedRightsExprLangID")]
		public static extern NSString IPTCExtLinkedEncodedRightsExprLangId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCreated")]
		public static extern NSString IPTCExtLocationCreated { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCity")]
		public static extern NSString IPTCExtLocationCity { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCountryCode")]
		public static extern NSString IPTCExtLocationCountryCode { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCountryName")]
		public static extern NSString IPTCExtLocationCountryName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationGPSAltitude")]
		public static extern NSString IPTCExtLocationGpsAltitude { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationGPSLatitude")]
		public static extern NSString IPTCExtLocationGpsLatitude { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationGPSLongitude")]
		public static extern NSString IPTCExtLocationGpsLongitude { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationIdentifier")]
		public static extern NSString IPTCExtLocationIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationLocationId")]
		public static extern NSString IPTCExtLocationLocationId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationLocationName")]
		public static extern NSString IPTCExtLocationLocationName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationProvinceState")]
		public static extern NSString IPTCExtLocationProvinceState { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationSublocation")]
		public static extern NSString IPTCExtLocationSublocation { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationWorldRegion")]
		public static extern NSString IPTCExtLocationWorldRegion { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationShown")]
		public static extern NSString IPTCExtLocationShown { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtMaxAvailHeight")]
		public static extern NSString IPTCExtMaxAvailHeight { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtMaxAvailWidth")]
		public static extern NSString IPTCExtMaxAvailWidth { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtModelAge")]
		public static extern NSString IPTCExtModelAge { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtOrganisationInImageCode")]
		public static extern NSString IPTCExtOrganisationInImageCode { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtOrganisationInImageName")]
		public static extern NSString IPTCExtOrganisationInImageName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonHeard")]
		public static extern NSString IPTCExtPersonHeard { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonHeardIdentifier")]
		public static extern NSString IPTCExtPersonHeardIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonHeardName")]
		public static extern NSString IPTCExtPersonHeardName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImage")]
		public static extern NSString IPTCExtPersonInImage { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageWDetails")]
		public static extern NSString IPTCExtPersonInImageWDetails { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCharacteristic")]
		public static extern NSString IPTCExtPersonInImageCharacteristic { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermCvId")]
		public static extern NSString IPTCExtPersonInImageCvTermCvId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermId")]
		public static extern NSString IPTCExtPersonInImageCvTermId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermName")]
		public static extern NSString IPTCExtPersonInImageCvTermName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermRefinedAbout")]
		public static extern NSString IPTCExtPersonInImageCvTermRefinedAbout { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageDescription")]
		public static extern NSString IPTCExtPersonInImageDescription { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageId")]
		public static extern NSString IPTCExtPersonInImageId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageName")]
		public static extern NSString IPTCExtPersonInImageName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImage")]
		public static extern NSString IPTCExtProductInImage { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImageDescription")]
		public static extern NSString IPTCExtProductInImageDescription { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImageGTIN")]
		public static extern NSString IPTCExtProductInImageGtin { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImageName")]
		public static extern NSString IPTCExtProductInImageName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEvent")]
		public static extern NSString IPTCExtPublicationEvent { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEventDate")]
		public static extern NSString IPTCExtPublicationEventDate { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEventIdentifier")]
		public static extern NSString IPTCExtPublicationEventIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEventName")]
		public static extern NSString IPTCExtPublicationEventName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRating")]
		public static extern NSString IPTCExtRating { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRatingRegion")]
		public static extern NSString IPTCExtRatingRatingRegion { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionCity")]
		public static extern NSString IPTCExtRatingRegionCity { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionCountryCode")]
		public static extern NSString IPTCExtRatingRegionCountryCode { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionCountryName")]
		public static extern NSString IPTCExtRatingRegionCountryName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionGPSAltitude")]
		public static extern NSString IPTCExtRatingRegionGpsAltitude { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionGPSLatitude")]
		public static extern NSString IPTCExtRatingRegionGpsLatitude { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionGPSLongitude")]
		public static extern NSString IPTCExtRatingRegionGpsLongitude { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionIdentifier")]
		public static extern NSString IPTCExtRatingRegionIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionLocationId")]
		public static extern NSString IPTCExtRatingRegionLocationId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionLocationName")]
		public static extern NSString IPTCExtRatingRegionLocationName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionProvinceState")]
		public static extern NSString IPTCExtRatingRegionProvinceState { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionSublocation")]
		public static extern NSString IPTCExtRatingRegionSublocation { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionWorldRegion")]
		public static extern NSString IPTCExtRatingRegionWorldRegion { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingScaleMaxValue")]
		public static extern NSString IPTCExtRatingScaleMaxValue { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingScaleMinValue")]
		public static extern NSString IPTCExtRatingScaleMinValue { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingSourceLink")]
		public static extern NSString IPTCExtRatingSourceLink { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingValue")]
		public static extern NSString IPTCExtRatingValue { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingValueLogoLink")]
		public static extern NSString IPTCExtRatingValueLogoLink { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryID")]
		public static extern NSString IPTCExtRegistryId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryEntryRole")]
		public static extern NSString IPTCExtRegistryEntryRole { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryItemID")]
		public static extern NSString IPTCExtRegistryItemId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryOrganisationID")]
		public static extern NSString IPTCExtRegistryOrganisationId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtReleaseReady")]
		public static extern NSString IPTCExtReleaseReady { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeason")]
		public static extern NSString IPTCExtSeason { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeasonIdentifier")]
		public static extern NSString IPTCExtSeasonIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeasonName")]
		public static extern NSString IPTCExtSeasonName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeasonNumber")]
		public static extern NSString IPTCExtSeasonNumber { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeries")]
		public static extern NSString IPTCExtSeries { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeriesIdentifier")]
		public static extern NSString IPTCExtSeriesIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeriesName")]
		public static extern NSString IPTCExtSeriesName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtStorylineIdentifier")]
		public static extern NSString IPTCExtStorylineIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtStreamReady")]
		public static extern NSString IPTCExtStreamReady { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtStylePeriod")]
		public static extern NSString IPTCExtStylePeriod { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSupplyChainSource")]
		public static extern NSString IPTCExtSupplyChainSource { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSupplyChainSourceIdentifier")]
		public static extern NSString IPTCExtSupplyChainSourceIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSupplyChainSourceName")]
		public static extern NSString IPTCExtSupplyChainSourceName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTemporalCoverage")]
		public static extern NSString IPTCExtTemporalCoverage { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTemporalCoverageFrom")]
		public static extern NSString IPTCExtTemporalCoverageFrom { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTemporalCoverageTo")]
		public static extern NSString IPTCExtTemporalCoverageTo { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscript")]
		public static extern NSString IPTCExtTranscript { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscriptLink")]
		public static extern NSString IPTCExtTranscriptLink { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscriptLinkLink")]
		public static extern NSString IPTCExtTranscriptLinkLink { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscriptLinkLinkQualifier")]
		public static extern NSString IPTCExtTranscriptLinkLinkQualifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoBitrate")]
		public static extern NSString IPTCExtVideoBitrate { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoBitrateMode")]
		public static extern NSString IPTCExtVideoBitrateMode { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoDisplayAspectRatio")]
		public static extern NSString IPTCExtVideoDisplayAspectRatio { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoEncodingProfile")]
		public static extern NSString IPTCExtVideoEncodingProfile { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoShotType")]
		public static extern NSString IPTCExtVideoShotType { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoShotTypeIdentifier")]
		public static extern NSString IPTCExtVideoShotTypeIdentifier { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoShotTypeName")]
		public static extern NSString IPTCExtVideoShotTypeName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoStreamsCount")]
		public static extern NSString IPTCExtVideoStreamsCount { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVisualColor")]
		public static extern NSString IPTCExtVisualColor { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTag")]
		public static extern NSString IPTCExtWorkflowTag { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvId")]
		public static extern NSString IPTCExtWorkflowTagCvId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvTermId")]
		public static extern NSString IPTCExtWorkflowTagCvTermId { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvTermName")]
		public static extern NSString IPTCExtWorkflowTagCvTermName { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvTermRefinedAbout")]
		public static extern NSString IPTCExtWorkflowTagCvTermRefinedAbout { get; }

		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyOpenEXRAspectRatio")]
		public static extern NSString OpenExrAspectRatio { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPrimaryImage")]
		public static extern NSString PrimaryImage { get; }

		// WebP Dictionary Keys

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPLoopCount")]
		public static extern NSString WebPLoopCount { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPDelayTime")]
		public static extern NSString WebPDelayTime { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPUnclampedDelayTime")]
		public static extern NSString WebPUnclampedDelayTime { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPFrameInfoArray")]
		public static extern NSString WebPFrameInfoArray { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPCanvasPixelWidth")]
		public static extern NSString WebPCanvasPixelWidth { get; }

		//[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPCanvasPixelHeight")]
		public static extern NSString WebPCanvasPixelHeight { get; }

		//[iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImagePropertyTGACompression")]
		public static extern NSString TgaCompression { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIndexLeft")]
		public static extern NSString GroupImageIndexLeft { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIndexRight")]
		public static extern NSString GroupImageIndexRight { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIsAlternateImage")]
		public static extern NSString GroupImageIsAlternateImage { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIsLeftImage")]
		public static extern NSString GroupImageIsLeftImage { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIsRightImage")]
		public static extern NSString GroupImageIsRightImage { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImagesAlternate")]
		public static extern NSString GroupImagesAlternate { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupIndex")]
		public static extern NSString GroupIndex { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroups")]
		public static extern NSString Groups { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupType")]
		public static extern NSString GroupType { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupTypeStereoPair")]
		public static extern NSString GroupTypeStereoPair { get; }

		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupTypeAlternate")]
		public static extern NSString GroupTypeAlternate { get; }

		//[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Field ("kCGImagePropertyGroupImageBaseline")]
		public static extern NSString GroupImageBaseline { get; }

		//[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Field ("kCGImagePropertyGroupImageDisparityAdjustment")]
		public static extern NSString GroupImageDisparityAdjustment { get; }

		//[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Field ("kCGImagePropertyHEIFDictionary")]
		public static extern NSString HeifDictionary { get; }

		//[iOS (16, 4), Mac (13, 3), Watch (9, 4), TV (16, 4), MacCatalyst (16, 4)]
		[Field ("kCGImagePropertyOpenEXRCompression")]
		public static extern NSString OpenExrCompression { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImagePropertyGroupImageIndexMonoscopic")]
		public static extern NSString GroupImageIndexMonoscopic { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImagePropertyGroupImageIsMonoscopicImage")]
		public static extern NSString GroupImageIsMonoscopicImage { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImagePropertyGroupImageStereoAggressors")]
		public static extern NSString GroupImageStereoAggressors { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImagePropertyGroupMonoscopicImageLocation")]
		public static extern NSString GroupMonoscopicImageLocation { get; }
	}

	/// <summary>Holds constants specifying standard metadata namespaces. Primarily used with <see cref="P:ImageIO.CGImageMetadataTag.Namespace" />.</summary>
	[Static]
	public static class CGImageMetadataTagNamespaces {
		[Field ("kCGImageMetadataNamespaceExif")]
		public static extern NSString Exif { get; }
		[Field ("kCGImageMetadataNamespaceExifAux")]
		public static extern NSString ExifAux { get; }
		[Field ("kCGImageMetadataNamespaceExifEX")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifEx { get; }
		[Field ("kCGImageMetadataNamespaceDublinCore")]
		public static extern NSString DublinCore { get; }
		[Field ("kCGImageMetadataNamespaceIPTCCore")]
		public static extern NSString IPTCCore { get; }
		[Field ("kCGImageMetadataNamespacePhotoshop")]
		public static extern NSString Photoshop { get; }
		[Field ("kCGImageMetadataNamespaceTIFF")]
		public static extern NSString TIFF { get; }
		[Field ("kCGImageMetadataNamespaceXMPBasic")]
		public static extern NSString XMPBasic { get; }
		[Field ("kCGImageMetadataNamespaceXMPRights")]
		public static extern NSString XMPRights { get; }
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageMetadataNamespaceIPTCExtension")]
		public static extern NSString IPTCExtension { get; }
	}

	/// <summary>Constants defining standard prefixes. Primarily used with <see cref="P:ImageIO.CGImageMetadataTag.Prefix" />.</summary>
	[Static]
	public static class CGImageMetadataTagPrefixes {
		[Field ("kCGImageMetadataPrefixExif")]
		public static extern NSString Exif { get; }
		[Field ("kCGImageMetadataPrefixExifAux")]
		public static extern NSString ExifAux { get; }
		[Field ("kCGImageMetadataPrefixExifEX")]
		[MacCatalyst (13, 1)]
		public static extern NSString ExifEx { get; }
		[Field ("kCGImageMetadataPrefixDublinCore")]
		public static extern NSString DublinCore { get; }
		[Field ("kCGImageMetadataPrefixIPTCCore")]
		public static extern NSString IPTCCore { get; }
		[Field ("kCGImageMetadataPrefixPhotoshop")]
		public static extern NSString Photoshop { get; }
		[Field ("kCGImageMetadataPrefixTIFF")]
		public static extern NSString TIFF { get; }
		[Field ("kCGImageMetadataPrefixXMPBasic")]
		public static extern NSString XMPBasic { get; }
		[Field ("kCGImageMetadataPrefixXMPRights")]
		public static extern NSString XMPRights { get; }
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageMetadataPrefixIPTCExtension")]
		public static extern NSString IPTCExtension { get; }
	}

	public static class CGImageMetadata {
		[Field ("kCFErrorDomainCGImageMetadata")]
		public static extern NSString ErrorDomain { get; }
	}

	/// <summary>Use an instance of this class to configure the CGImageSource.</summary>
	[Partial]
	interface CGImageOptions {
		[Internal]
		[Field ("kCGImageSourceTypeIdentifierHint")]
		IntPtr kTypeIdentifierHint { get; }

		[Internal]
		[Field ("kCGImageSourceShouldCache")]
		IntPtr kShouldCache { get; }

		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCGImageSourceShouldCacheImmediately")]
		IntPtr kShouldCacheImmediately { get; }

		[Internal]
		[Field ("kCGImageSourceShouldAllowFloat")]
		IntPtr kShouldAllowFloat { get; }
	}

	/// <summary>Configuration options used when loading thumbnails using CGImageSource.</summary>
	[Partial]
	interface CGImageThumbnailOptions {
		[Internal]
		[Field ("kCGImageSourceCreateThumbnailFromImageIfAbsent")]
		IntPtr kCreateThumbnailFromImageIfAbsent { get; }

		[Internal]
		[Field ("kCGImageSourceCreateThumbnailFromImageAlways")]
		IntPtr kCreateThumbnailFromImageAlways { get; }

		[Internal]
		[Field ("kCGImageSourceThumbnailMaxPixelSize")]
		IntPtr kThumbnailMaxPixelSize { get; }

		[Internal]
		[Field ("kCGImageSourceCreateThumbnailWithTransform")]
		IntPtr kCreateThumbnailWithTransform { get; }

		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCGImageSourceSubsampleFactor")]
		IntPtr kCGImageSourceSubsampleFactor { get; }
	}

	[Partial]
	//[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	public partial class CGImageDecodeOptions {
		[Internal]
		[Field ("kCGImageSourceDecodeRequest")]
		public extern IntPtr DecodeRequest { get; }

		[Internal]
		[Field ("kCGImageSourceDecodeToHDR")]
		public extern IntPtr DecodeToHDR { get; }

		[Internal]
		[Field ("kCGImageSourceDecodeToSDR")]
		public extern IntPtr DecodeToSDR { get; }

		//[iOS (18, 0), MacCatalyst (18, 0), TV (18, 0), Mac (15, 0), Watch (11, 0)]
		[Internal]
		[Field ("kCGImageSourceGenerateImageSpecificLumaScaling")]
		public extern IntPtr GenerateImageSpecificLumaScaling { get; }

		[Internal]
		[Field ("kCGImageSourceDecodeRequestOptions")]
		public extern IntPtr DecodeRequestOptions { get; }
	}

	/// <summary>Specifies whether the callback in <see cref="M:ImageIO.CGImageMetadata.EnumerateTags(Foundation.NSString,ImageIO.CGImageMetadataEnumerateOptions,ImageIO.CGImageMetadataTagBlock)" /> is recursive.</summary>
	[Partial]
	public partial class CGImageMetadataEnumerateOptions {
		[Internal]
		[Field ("kCGImageMetadataEnumerateRecursively")]
		public extern IntPtr kCGImageMetadataEnumerateRecursively { get; }
	}

	// Defined in CGImageProperties.cs in CoreGraphics
	public interface CGImagePropertiesTiff { }
	public interface CGImagePropertiesExif { }
	public interface CGImagePropertiesJfif { }
	public interface CGImagePropertiesPng { }
	public interface CGImagePropertiesGps { }
	public interface CGImagePropertiesIptc { }

	/// <summary>Use an instance of this class to configure how an image is added to a <see cref="T:ImageIO.CGImageDestination" />.</summary>
	///     <remarks>
	///       <para>Use this class to configure the parameters when you add an image to CGImageDestination.</para>
	///     </remarks>
	//[StrongDictionary ("CGImageDestinationOptionsKeys")]
	public partial class CGImageDestinationOptions: DictionaryContainer {

		[Export ("LossyCompressionQuality")]
		public extern float LossyCompressionQuality { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("ImageMaxPixelSize")]
		public extern int ImageMaxPixelSize { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("EmbedThumbnail")]
		public extern bool EmbedThumbnail { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("OptimizeColorForSharing")]
		public extern bool OptimizeColorForSharing { get; set; }

		[StrongDictionary]
		[Export ("TIFFDictionary")]
		public extern CGImagePropertiesTiff TiffDictionary { get; set; }

		[Export ("GIFDictionary")]
		public extern NSDictionary GifDictionary { get; set; }

		[StrongDictionary]
		[Export ("JFIFDictionary")]
		public extern CGImagePropertiesJfif JfifDictionary { get; set; }

		[StrongDictionary]
		[Export ("ExifDictionary")]
		public extern CGImagePropertiesExif ExifDictionary { get; set; }

		[StrongDictionary]
		[Export ("PNGDictionary")]
		public extern CGImagePropertiesPng PngDictionary { get; set; }

		[StrongDictionary]
		[Export ("IPTCDictionary")]
		public extern CGImagePropertiesIptc IptcDictionary { get; set; }

		[StrongDictionary]
		[Export ("GPSDictionary")]
		public extern CGImagePropertiesGps GpsDictionary { get; set; }

		[Export ("RawDictionary")]
		public extern NSDictionary RawDictionary { get; set; }

		[Export ("CIFFDictionary")]
		public extern NSDictionary CiffDictionary { get; set; }

		[Export ("EightBIMDictionary")]
		public extern NSDictionary EightBimDictionary { get; set; }

		[Export ("DNGDictionary")]
		public extern NSDictionary DngDictionary { get; set; }

		[Export ("ExifAuxDictionary")]
		public extern NSDictionary ExifAuxDictionary { get; set; }

		//[iOS (14, 0), TV (14, 0), Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Export ("WebPDictionary")]
		public extern NSDictionary WebPDictionary { get; set; }

		//[iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Export ("TgaDictionary")]
		public extern NSDictionary TgaDictionary { get; set; }

		//[Mac (14, 0), iOS (17, 0), TV (17, 0), Watch (10, 0), MacCatalyst (17, 0)]
		[Export ("AvisDictionary")]
		public extern NSDictionary AvisDictionary { get; set; }

		//[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[MacCatalyst (14, 1)]
		public extern bool PreserveGainMap { get; set; }
	}

	/// <summary>Contains keys that index image destination options.</summary>
	[Static]
	public static class CGImageDestinationOptionsKeys {

		[Field ("kCGImageDestinationLossyCompressionQuality")]
		public static extern NSString LossyCompressionQuality { get; }

		[Field ("kCGImageDestinationBackgroundColor")]
		public static extern NSString BackgroundColor { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImageDestinationImageMaxPixelSize")]
		public static extern NSString ImageMaxPixelSize { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImageDestinationEmbedThumbnail")]
		public static extern NSString EmbedThumbnail { get; }

		[MacCatalyst (13, 1)]
		[Field ("kCGImageDestinationOptimizeColorForSharing")]
		public static extern NSString OptimizeColorForSharing { get; }

		// [Field ("kCGImagePropertyTIFFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.TIFFDictionary")]
		public static extern NSString TIFFDictionary { get; }

		// [Field ("kCGImagePropertyGIFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.GIFDictionary")]
		public static extern NSString GIFDictionary { get; }

		// [Field ("kCGImagePropertyJFIFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.JFIFDictionary")]
		public static extern NSString JFIFDictionary { get; }

		// [Field ("kCGImagePropertyExifDictionary")]
		[Static]
		[Wrap ("CGImageProperties.ExifDictionary")]
		public static extern NSString ExifDictionary { get; }

		// [Field ("kCGImagePropertyPNGDictionary")]
		[Static]
		[Wrap ("CGImageProperties.PNGDictionary")]
		public static extern NSString PNGDictionary { get; }

		// [Field ("kCGImagePropertyIPTCDictionary")]
		[Static]
		[Wrap ("CGImageProperties.IPTCDictionary")]
		public static extern NSString IPTCDictionary { get; }

		// [Field ("kCGImagePropertyGPSDictionary")]
		[Static]
		[Wrap ("CGImageProperties.GPSDictionary")]
		public static extern NSString GPSDictionary { get; }

		// [Field ("kCGImagePropertyRawDictionary")]
		[Static]
		[Wrap ("CGImageProperties.RawDictionary")]
		public static extern NSString RawDictionary { get; }

		// [Field ("kCGImagePropertyCIFFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.CIFFDictionary")]
		public static extern NSString CIFFDictionary { get; }

		// [Field ("kCGImageProperty8BIMDictionary")]
		[Static]
		[Wrap ("CGImageProperties.EightBIMDictionary")]
		public static extern NSString EightBIMDictionary { get; }

		// [Field ("kCGImagePropertyDNGDictionary")]
		[Static]
		[Wrap ("CGImageProperties.DNGDictionary")]
		public static extern NSString DNGDictionary { get; }

		// [Field ("kCGImagePropertyExifAuxDictionary")]
		[Static]
		[Wrap ("CGImageProperties.ExifAuxDictionary")]
		public static extern NSString ExifAuxDictionary { get; }

		//[iOS (14, 0), TV (14, 0), Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Wrap ("CGImageProperties.WebPDictionary")]
		public static extern NSString WebPDictionary { get; }

		//[iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Static]
		[Wrap ("CGImageProperties.TgaDictionary")]
		public static extern NSString TgaDictionary { get; }

		//[Mac (14, 0), iOS (17, 0), TV (17, 0), Watch (10, 0)]
		[MacCatalyst (17, 0)]
		[Static]
		[Wrap ("CGImageProperties.AvisDictionary")]
		public static extern NSString AvisDictionary { get; }

		//[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImageDestinationPreserveGainMap")]
		public static extern NSString PreserveGainMapKey { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageDestinationEncodeRequest")]
		public static extern NSString EncodeRequest { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageDestinationEncodeToSDR")]
		public static extern NSString EncodeToSdr { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageDestinationEncodeToISOHDR")]
		public static extern NSString EncodeToIsoHdr { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageDestinationEncodeToISOGainmap")]
		public static extern NSString EncodeToIsoGainmap { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageDestinationEncodeRequestOptions")]
		public static extern NSString EncodeRequestOptions { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageDestinationEncodeBaseIsSDR")]
		public static extern NSString EncodeBaseIsSdr { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageDestinationEncodeTonemapMode")]
		public static extern NSString EncodeTonemapMode { get; }
	}

	/// <summary>Class that contains options for copying image sources.</summary>
	[Partial]
	interface CGCopyImageSourceOptions {

		[Internal]
		[Field ("kCGImageDestinationMetadata")]
		IntPtr kMetadata { get; }

		[Internal]
		[Field ("kCGImageDestinationMergeMetadata")]
		IntPtr kMergeMetadata { get; }

		[Internal]
		[Field ("kCGImageMetadataShouldExcludeXMP")]
		IntPtr kShouldExcludeXMP { get; }

		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCGImageMetadataShouldExcludeGPS")]
		IntPtr kShouldExcludeGPS { get; }

		[Internal]
		[Field ("kCGImageDestinationDateTime")]
		IntPtr kDateTime { get; }

		[Internal]
		[Field ("kCGImageDestinationOrientation")]
		IntPtr kOrientation { get; }
	}

	[MacCatalyst (13, 1)]
	public enum CGImageAuxiliaryDataType {
		[Field ("kCGImageAuxiliaryDataTypeDepth")]
		Depth,

		[Field ("kCGImageAuxiliaryDataTypeDisparity")]
		Disparity,

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypePortraitEffectsMatte")]
		PortraitEffectsMatte,

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationHairMatte")]
		SemanticSegmentationHairMatte,

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationSkinMatte")]
		SemanticSegmentationSkinMatte,

		//[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationTeethMatte")]
		SemanticSegmentationTeethMatte,

		//[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationGlassesMatte")]
		SemanticSegmentationGlassesMatte,

		//[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImageAuxiliaryDataTypeHDRGainMap")]
		TypeHdrGainMap,

		//[iOS (14, 3)]
		[TV (14, 3)]
		[Watch (7, 2)]
		[MacCatalyst (14, 3)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationSkyMatte")]
		SemanticSegmentationSkyMatte,

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageAuxiliaryDataTypeISOGainMap")]
		IsoGainMap,
	}

	[MacCatalyst (13, 1)]
	[Static]
	[Internal]
	public static class CGImageAuxiliaryDataInfoKeys {
		[Field ("kCGImageAuxiliaryDataInfoData")]
		public static extern NSString DataKey { get; }

		[Field ("kCGImageAuxiliaryDataInfoDataDescription")]
		public static extern NSString DataDescriptionKey { get; }

		[Field ("kCGImageAuxiliaryDataInfoMetadata")]
		public static extern NSString MetadataKey { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("kCGImageAuxiliaryDataInfoColorSpace")]
		public static extern NSString ColorSpaceKey { get; }
	}

	[MacCatalyst (13, 1)]
	//[StrongDictionary ("CGImageAuxiliaryDataInfoKeys")]
	public class  CGImageAuxiliaryDataInfo : DictionaryContainer {

		public NSData Data { get; set; }
		public NSDictionary DataDescription { get; set; }
		// Bound manually:
		// CGImageMetadata Metadata { get; set; }))
		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		public CGColorSpace ColorSpace { get; set; }
	}

	//[iOS (13, 0), TV (13, 0), Watch (6, 0)]
	[MacCatalyst (13, 1)]
	[Static]
	[Internal]
	public static class CGImageAnimationOptionsKeys {
		[Field ("kCGImageAnimationDelayTime")]
		public static extern NSString DelayTimeKey { get; }

		[Field ("kCGImageAnimationLoopCount")]
		public static extern NSString LoopCountKey { get; }

		[Field ("kCGImageAnimationStartIndex")]
		public static extern NSString StartIndexKey { get; }
	}

	//[iOS (13, 0), TV (13, 0), Watch (6, 0)]
	[MacCatalyst (13, 1)]
	//[StrongDictionary ("CGImageAnimationOptionsKeys")]
	public class CGImageAnimationOptions: DictionaryContainer {
		public double DelayTime { get; set; }

		public nuint LoopCount { get; set; }

		public nuint StartIndex { get; set; }
	}

	[Static]
	//[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	public static class IOCameraExtrinsics {
		[Field ("kIIOCameraExtrinsics_CoordinateSystemID")]
		public static extern NSString CoordinateSystemId { get; }

		[Field ("kIIOCameraExtrinsics_Position")]
		public static extern NSString Position { get; }

		[Field ("kIIOCameraExtrinsics_Rotation")]
		public static extern NSString Rotation { get; }
	}

	[Static]
	//[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	public static class IOCameraModel {
		[Field ("kIIOCameraModel_Intrinsics")]
		public static extern NSString Intrinsics { get; }

		//[Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		[Field ("kIIOCameraModel_ModelType")]
		public static extern NSString ModelType { get; }
	}

	[Static]
	//[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	public static class IOCameraModelType {
		[Field ("kIIOCameraModelType_SimplifiedPinhole")]
		public static extern NSString SimplifiedPinhole { get; }

		[Field ("kIIOCameraModelType_GenericPinhole")]
		public static extern NSString GenericPinhole { get; }
	}

	[Static]
	//[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	interface IOMetadata {
		[Field ("kIIOMetadata_CameraExtrinsicsKey")]
		public static extern NSString CameraExtrinsicsKey { get; }

		[Field ("kIIOMetadata_CameraModelKey")]
		public static extern NSString CameraModelKey { get; }
	}

	[Static]
	//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	public static class IOStereoAggressors {
		[Field ("kIIOStereoAggressors_Type")]
		public static extern NSString Type { get; }

		[Field ("kIIOStereoAggressors_SubTypeURI")]
		public static extern NSString SubTypeUri { get; }

		[Field ("kIIOStereoAggressors_Severity")]
		public static extern NSString Severity { get; }
	}

	[Static]
	//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	public static class IOMonoscopicImageLocation {
		[Field ("kIIOMonoscopicImageLocation_Unspecified")]
		public static extern NSString Unspecified { get; }

		[Field ("kIIOMonoscopicImageLocation_Left")]
		public static extern NSString Left { get; }

		[Field ("kIIOMonoscopicImageLocation_Right")]
		public static extern NSString Right { get; }

		[Field ("kIIOMonoscopicImageLocation_Center")]
		public static extern NSString Center { get; }
	}
}
