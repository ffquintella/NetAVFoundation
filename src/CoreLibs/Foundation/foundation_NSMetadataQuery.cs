#region INCLUDES 

#define DOUBLE_BLOCKS
using ObjCRuntime;

using CoreData;
using CoreFoundation;
using Foundation;
using CoreGraphics;
using UniformTypeIdentifiers;

#if HAS_APPCLIP
using AppClip;
#endif
#if IOS
using QuickLook;
#endif
#if !TVOS

#endif
#if !WATCH
using CoreAnimation;

#endif
using CoreMedia;

#if IOS || MONOMAC

#else
using INSFileProviderItem = Foundation.NSObject;
#endif

#if MONOMAC
using AppKit;

#else
using CoreLocation;
using UIKit;
#endif

using System;
using System.ComponentModel;

// In Apple headers, this is a typedef to a pointer to a private struct
using NSAppleEventManagerSuspensionID = System.IntPtr;
// These two are both four char codes i.e. defined on a uint with constant like 'xxxx'
using AEKeyword = System.UInt32;
using OSType = System.UInt32;
// typedef double NSTimeInterval;
using NSTimeInterval = System.Double;

#if MONOMAC
// dummy usings to make code compile without having the actual types available (for [NoMac] to work)
using NSDirectionalEdgeInsets = Foundation.NSObject;
using UIEdgeInsets = Foundation.NSObject;
using UIOffset = Foundation.NSObject;
using UIPreferredPresentationStyle = Foundation.NSObject;
#else
using NSPasteboard = Foundation.NSObject;
using NSWorkspaceAuthorization = Foundation.NSObject;

using NSStringAttributes = UIKit.UIStringAttributes;
#endif

#if IOS && !__MACCATALYST__
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if TVOS
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if WATCH
// dummy usings to make code compile without having the actual types available (for [NoWatch] to work)
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
using CSSearchableItemAttributeSet = Foundation.NSObject;
#endif

#if WATCH
using CIBarcodeDescriptor = Foundation.NSObject;
#else
using CoreImage;
#endif

#if !IOS
using APActivationPayload = Foundation.NSObject;
#endif

#if __MACCATALYST__
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if IOS || WATCH || TVOS
using NSAppearance = UIKit.UIAppearance;
using NSColor = UIKit.UIColor;
using NSNotificationSuspensionBehavior = Foundation.NSObject;
using NSNotificationFlags = Foundation.NSObject;
using NSTextBlock = Foundation.NSObject;
using NSTextTable = Foundation.NSString; // Different frmo NSTextBlock, because some methods overload on these two types.
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

#endregion

namespace Foundation
{

	[BaseType (typeof (NSObject), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSMetadataQueryDelegate) })]
	public partial class NSMetadataQuery: NSObject {
		[Export ("startQuery")]
		public extern bool StartQuery ();

		[Export ("stopQuery")]
		public extern void StopQuery ();

		[Export ("isStarted")]
		public extern bool IsStarted { get; }

		[Export ("isGathering")]
		public extern bool IsGathering { get; }

		[Export ("isStopped")]
		public extern bool IsStopped { get; }

		[Export ("disableUpdates")]
		public extern void DisableUpdates ();

		[Export ("enableUpdates")]
		public extern void EnableUpdates ();

		[Export ("resultCount")]
		public extern nint ResultCount { get; }

		[Export ("resultAtIndex:")]
		public extern NSObject ResultAtIndex (nint idx);

		[Export ("results")]
		public extern NSMetadataItem [] Results { get; }

		[Export ("indexOfResult:")]
		public extern nint IndexOfResult (NSObject result);

		[Export ("valueLists")]
		public extern NSDictionary ValueLists { get; }

		[Export ("groupedResults")]
		public extern NSObject [] GroupedResults { get; }

		[Export ("valueOfAttribute:forResultAtIndex:")]
		public extern NSObject ValueOfAttribute (string attribyteName, nint atIndex);

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		public extern INSMetadataQueryDelegate Delegate { get; set; }

		[Export ("predicate", ArgumentSemantic.Copy)]
		[NullAllowed] // by default this property is null
		public extern NSPredicate Predicate { get; set; }

		[Export ("sortDescriptors", ArgumentSemantic.Copy)]
		public extern NSSortDescriptor [] SortDescriptors { get; set; }

		[Export ("valueListAttributes", ArgumentSemantic.Copy)]
		public extern NSObject [] ValueListAttributes { get; set; }

		[Export ("groupingAttributes", ArgumentSemantic.Copy)]
		public extern NSArray GroupingAttributes { get; set; }

		[Export ("notificationBatchingInterval")]
		public extern double NotificationBatchingInterval { get; set; }

		[Export ("searchScopes", ArgumentSemantic.Copy)]
		public extern NSObject [] SearchScopes { get; set; }

		// There is no info associated with these notifications
		[Field ("NSMetadataQueryDidStartGatheringNotification")]
		[Notification]
		public extern NSString DidStartGatheringNotification { get; }

		[Field ("NSMetadataQueryGatheringProgressNotification")]
		[Notification]
		public extern NSString GatheringProgressNotification { get; }

		[Field ("NSMetadataQueryDidFinishGatheringNotification")]
		[Notification]
		public extern NSString DidFinishGatheringNotification { get; }

		[Field ("NSMetadataQueryDidUpdateNotification")]
		[Notification]
		public extern NSString DidUpdateNotification { get; }

		[Field ("NSMetadataQueryResultContentRelevanceAttribute")]
		public extern NSString ResultContentRelevanceAttribute { get; }

		// Scope constants for defined search locations
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Field ("NSMetadataQueryUserHomeScope")]
		public extern NSString UserHomeScope { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Field ("NSMetadataQueryLocalComputerScope")]
		public extern NSString LocalComputerScope { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Field ("NSMetadataQueryLocalDocumentsScope")]
		public extern NSString LocalDocumentsScope { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Field ("NSMetadataQueryNetworkScope")]
		public extern NSString NetworkScope { get; }

		[Field ("NSMetadataQueryUbiquitousDocumentsScope")]
		public extern NSString UbiquitousDocumentsScope { get; }

		[Field ("NSMetadataQueryUbiquitousDataScope")]
		public extern NSString UbiquitousDataScope { get; }


		[MacCatalyst (13, 1)]
		[Field ("NSMetadataQueryAccessibleUbiquitousExternalDocumentsScope")]
		public static extern NSString AccessibleUbiquitousExternalDocumentsScope { get; }

		[Field ("NSMetadataItemFSNameKey")]
		public static extern NSString ItemFSNameKey { get; }

		[Field ("NSMetadataItemDisplayNameKey")]
		public static extern NSString ItemDisplayNameKey { get; }

		[Field ("NSMetadataItemURLKey")]
		public static extern NSString ItemURLKey { get; }

		[Field ("NSMetadataItemPathKey")]
		public static extern NSString ItemPathKey { get; }

		[Field ("NSMetadataItemFSSizeKey")]
		public static extern NSString ItemFSSizeKey { get; }

		[Field ("NSMetadataItemFSCreationDateKey")]
		public static extern NSString ItemFSCreationDateKey { get; }

		[Field ("NSMetadataItemFSContentChangeDateKey")]
		public static extern NSString ItemFSContentChangeDateKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataItemContentTypeKey")]
		public static extern NSString ContentTypeKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataItemContentTypeTreeKey")]
		public static extern NSString ContentTypeTreeKey { get; }


		[Field ("NSMetadataItemIsUbiquitousKey")]
		public static extern NSString ItemIsUbiquitousKey { get; }

		[Field ("NSMetadataUbiquitousItemHasUnresolvedConflictsKey")]
		public static extern NSString UbiquitousItemHasUnresolvedConflictsKey { get; }

		[Deprecated (PlatformName.iOS, 7, 0, message: "Use 'UbiquitousItemDownloadingStatusKey' instead.")]
		[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'UbiquitousItemDownloadingStatusKey' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 9, message: "Use 'UbiquitousItemDownloadingStatusKey' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'UbiquitousItemDownloadingStatusKey' instead.")]
		[Field ("NSMetadataUbiquitousItemIsDownloadedKey")]
		public static extern NSString UbiquitousItemIsDownloadedKey { get; }

		[Field ("NSMetadataUbiquitousItemIsDownloadingKey")]
		public static extern NSString UbiquitousItemIsDownloadingKey { get; }

		[Field ("NSMetadataUbiquitousItemIsUploadedKey")]
		public static extern NSString UbiquitousItemIsUploadedKey { get; }

		[Field ("NSMetadataUbiquitousItemIsUploadingKey")]
		public static extern NSString UbiquitousItemIsUploadingKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemDownloadingStatusKey")]
		public static extern NSString UbiquitousItemDownloadingStatusKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemDownloadingErrorKey")]
		public static extern NSString UbiquitousItemDownloadingErrorKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemUploadingErrorKey")]
		public static extern NSString UbiquitousItemUploadingErrorKey { get; }

		[Field ("NSMetadataUbiquitousItemPercentDownloadedKey")]
		public static extern NSString UbiquitousItemPercentDownloadedKey { get; }

		[Field ("NSMetadataUbiquitousItemPercentUploadedKey")]
		public static extern NSString UbiquitousItemPercentUploadedKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemDownloadRequestedKey")]
		public static extern NSString UbiquitousItemDownloadRequestedKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemIsExternalDocumentKey")]
		public static extern NSString UbiquitousItemIsExternalDocumentKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemContainerDisplayNameKey")]
		public static extern NSString UbiquitousItemContainerDisplayNameKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemURLInLocalContainerKey")]
		public static extern NSString UbiquitousItemURLInLocalContainerKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemKeywordsKey")]
		public static extern NSString KeywordsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemTitleKey")]
		public static extern NSString TitleKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAuthorsKey")]
		public static extern NSString AuthorsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemEditorsKey")]
		public static extern NSString EditorsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemParticipantsKey")]
		public static extern NSString ParticipantsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemProjectsKey")]
		public static extern NSString ProjectsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemDownloadedDateKey")]
		public static extern NSString DownloadedDateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemWhereFromsKey")]
		public static extern NSString WhereFromsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCommentKey")]
		public static extern NSString CommentKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCopyrightKey")]
		public static extern NSString CopyrightKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemLastUsedDateKey")]
		public static extern NSString LastUsedDateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemContentCreationDateKey")]
		public static extern NSString ContentCreationDateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemContentModificationDateKey")]
		public static extern NSString ContentModificationDateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemDateAddedKey")]
		public static extern NSString DateAddedKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemDurationSecondsKey")]
		public static extern NSString DurationSecondsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemContactKeywordsKey")]
		public static extern NSString ContactKeywordsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemVersionKey")]
		public static extern NSString VersionKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPixelHeightKey")]
		public static extern NSString PixelHeightKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPixelWidthKey")]
		public static extern NSString PixelWidthKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPixelCountKey")]
		public static extern NSString PixelCountKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemColorSpaceKey")]
		public static extern NSString ColorSpaceKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemBitsPerSampleKey")]
		public static extern NSString BitsPerSampleKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemFlashOnOffKey")]
		public static extern NSString FlashOnOffKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemFocalLengthKey")]
		public static extern NSString FocalLengthKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAcquisitionMakeKey")]
		public static extern NSString AcquisitionMakeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAcquisitionModelKey")]
		public static extern NSString AcquisitionModelKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemISOSpeedKey")]
		public static extern NSString IsoSpeedKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemOrientationKey")]
		public static extern NSString OrientationKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemLayerNamesKey")]
		public static extern NSString LayerNamesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemWhiteBalanceKey")]
		public static extern NSString WhiteBalanceKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemApertureKey")]
		public static extern NSString ApertureKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemProfileNameKey")]
		public static extern NSString ProfileNameKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemResolutionWidthDPIKey")]
		public static extern NSString ResolutionWidthDpiKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemResolutionHeightDPIKey")]
		public static extern NSString ResolutionHeightDpiKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemExposureModeKey")]
		public static extern NSString ExposureModeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemExposureTimeSecondsKey")]
		public static extern NSString ExposureTimeSecondsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemEXIFVersionKey")]
		public static extern NSString ExifVersionKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCameraOwnerKey")]
		public static extern NSString CameraOwnerKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemFocalLength35mmKey")]
		public static extern NSString FocalLength35mmKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemLensModelKey")]
		public static extern NSString LensModelKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemEXIFGPSVersionKey")]
		public static extern NSString ExifGpsVersionKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAltitudeKey")]
		public static extern NSString AltitudeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemLatitudeKey")]
		public static extern NSString LatitudeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemLongitudeKey")]
		public static extern NSString LongitudeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemSpeedKey")]
		public static extern NSString SpeedKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemTimestampKey")]
		public static extern NSString TimestampKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSTrackKey")]
		public static extern NSString GpsTrackKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemImageDirectionKey")]
		public static extern NSString ImageDirectionKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemNamedLocationKey")]
		public static extern NSString NamedLocationKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSStatusKey")]
		public static extern NSString GpsStatusKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSMeasureModeKey")]
		public static extern NSString GpsMeasureModeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSDOPKey")]
		public static extern NSString GpsDopKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSMapDatumKey")]
		public static extern NSString GpsMapDatumKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSDestLatitudeKey")]
		public static extern NSString GpsDestLatitudeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSDestLongitudeKey")]
		public static extern 	NSString GpsDestLongitudeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSDestBearingKey")]
		public static extern NSString GpsDestBearingKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSDestDistanceKey")]
		public static extern NSString GpsDestDistanceKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSProcessingMethodKey")]
		public static extern NSString GpsProcessingMethodKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSAreaInformationKey")]
		public static extern NSString GpsAreaInformationKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSDateStampKey")]
		public static extern NSString GpsDateStampKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGPSDifferentalKey")]
		public static extern NSString GpsDifferentalKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCodecsKey")]
		public static extern NSString CodecsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemMediaTypesKey")]
		public static extern NSString MediaTypesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemStreamableKey")]
		public static extern NSString StreamableKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemTotalBitRateKey")]
		public static extern NSString TotalBitRateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemVideoBitRateKey")]
		public static extern NSString VideoBitRateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAudioBitRateKey")]
		public static extern NSString AudioBitRateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemDeliveryTypeKey")]
		public static extern NSString DeliveryTypeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAlbumKey")]
		public static extern NSString AlbumKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemHasAlphaChannelKey")]
		public static extern NSString HasAlphaChannelKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemRedEyeOnOffKey")]
		public static extern NSString RedEyeOnOffKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemMeteringModeKey")]
		public static extern NSString MeteringModeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemMaxApertureKey")]
		public static extern NSString MaxApertureKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemFNumberKey")]
		public static extern NSString FNumberKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemExposureProgramKey")]
		public static extern NSString ExposureProgramKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemExposureTimeStringKey")]
		public static extern NSString ExposureTimeStringKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemHeadlineKey")]
		public static extern NSString HeadlineKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemInstructionsKey")]
		public static extern NSString InstructionsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCityKey")]
		public static extern NSString CityKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemStateOrProvinceKey")]
		public static extern NSString StateOrProvinceKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCountryKey")]
		public static extern NSString CountryKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemTextContentKey")]
		public static extern NSString TextContentKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAudioSampleRateKey")]
		public static extern NSString AudioSampleRateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAudioChannelCountKey")]
		public static extern NSString AudioChannelCountKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemTempoKey")]
		public static extern NSString TempoKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemKeySignatureKey")]
		public static extern NSString KeySignatureKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemTimeSignatureKey")]
		public static extern NSString TimeSignatureKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAudioEncodingApplicationKey")]
		public static extern NSString AudioEncodingApplicationKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemComposerKey")]
		public static extern NSString ComposerKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemLyricistKey")]
		public static extern NSString LyricistKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAudioTrackNumberKey")]
		public static extern NSString AudioTrackNumberKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemRecordingDateKey")]
		public static extern NSString RecordingDateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemMusicalGenreKey")]
		public static extern NSString MusicalGenreKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemIsGeneralMIDISequenceKey")]
		public static extern NSString IsGeneralMidiSequenceKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemRecordingYearKey")]
		public static extern NSString RecordingYearKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemOrganizationsKey")]
		public static extern NSString OrganizationsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemLanguagesKey")]
		public static extern NSString LanguagesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemRightsKey")]
		public static extern NSString RightsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPublishersKey")]
		public static extern NSString PublishersKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemContributorsKey")]
		public static extern NSString ContributorsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCoverageKey")]
		public static extern NSString CoverageKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemSubjectKey")]
		public static extern NSString SubjectKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemThemeKey")]
		public static extern NSString ThemeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemDescriptionKey")]
		public static extern NSString DescriptionKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemIdentifierKey")]
		public static extern NSString IdentifierKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAudiencesKey")]
		public static extern NSString AudiencesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemNumberOfPagesKey")]
		public static extern NSString NumberOfPagesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPageWidthKey")]
		public static extern NSString PageWidthKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPageHeightKey")]
		public static extern NSString PageHeightKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemSecurityMethodKey")]
		public static extern NSString SecurityMethodKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCreatorKey")]
		public static extern NSString CreatorKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemEncodingApplicationsKey")]
		public static extern NSString EncodingApplicationsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemDueDateKey")]
		public static extern NSString DueDateKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemStarRatingKey")]
		public static extern NSString StarRatingKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPhoneNumbersKey")]
		public static extern NSString PhoneNumbersKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemEmailAddressesKey")]
		public static extern NSString EmailAddressesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemInstantMessageAddressesKey")]
		public static extern NSString InstantMessageAddressesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemKindKey")]
		public static extern NSString KindKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemRecipientsKey")]
		public static extern NSString RecipientsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemFinderCommentKey")]
		public static extern NSString FinderCommentKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemFontsKey")]
		public static extern NSString FontsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAppleLoopsRootKeyKey")]
		public static extern NSString AppleLoopsRootKeyKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAppleLoopsKeyFilterTypeKey")]
		public static extern NSString AppleLoopsKeyFilterTypeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAppleLoopsLoopModeKey")]
		public static extern NSString AppleLoopsLoopModeKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAppleLoopDescriptorsKey")]
		public static extern NSString AppleLoopDescriptorsKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemMusicalInstrumentCategoryKey")]
		public static extern NSString MusicalInstrumentCategoryKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemMusicalInstrumentNameKey")]
		public static extern NSString MusicalInstrumentNameKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemCFBundleIdentifierKey")]
		public static extern NSString CFBundleIdentifierKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemInformationKey")]
		public static extern NSString InformationKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemDirectorKey")]
		public static extern NSString DirectorKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemProducerKey")]
		public static extern NSString ProducerKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemGenreKey")]
		public static extern NSString GenreKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemPerformersKey")]
		public static extern NSString PerformersKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemOriginalFormatKey")]
		public static extern NSString OriginalFormatKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemOriginalSourceKey")]
		public static extern NSString OriginalSourceKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAuthorEmailAddressesKey")]
		public static extern NSString AuthorEmailAddressesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemRecipientEmailAddressesKey")]
		public static extern NSString RecipientEmailAddressesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemAuthorAddressesKey")]
		public static extern NSString AuthorAddressesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemRecipientAddressesKey")]
		public static extern NSString RecipientAddressesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemIsLikelyJunkKey")]
		public static extern NSString IsLikelyJunkKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemExecutableArchitecturesKey")]
		public static extern NSString ExecutableArchitecturesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemExecutablePlatformKey")]
		public static extern NSString ExecutablePlatformKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemApplicationCategoriesKey")]
		public static extern NSString ApplicationCategoriesKey { get; }

		[NoWatch, NoTV, NoiOS, NoMacCatalyst]
		[Field ("NSMetadataItemIsApplicationManagedKey")]
		public static extern NSString IsApplicationManagedKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousItemIsSharedKey")]
		public static extern NSString UbiquitousItemIsSharedKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemCurrentUserRoleKey")]
		public static extern NSString UbiquitousSharedItemCurrentUserRoleKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemCurrentUserPermissionsKey")]
		public static extern NSString UbiquitousSharedItemCurrentUserPermissionsKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemOwnerNameComponentsKey")]
		public static extern NSString UbiquitousSharedItemOwnerNameComponentsKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemMostRecentEditorNameComponentsKey")]
		public static extern NSString UbiquitousSharedItemMostRecentEditorNameComponentsKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemRoleOwner")]
		public static extern NSString UbiquitousSharedItemRoleOwner { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemRoleParticipant")]
		public static extern NSString UbiquitousSharedItemRoleParticipant { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemPermissionsReadOnly")]
		public static extern NSString UbiquitousSharedItemPermissionsReadOnly { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataUbiquitousSharedItemPermissionsReadWrite")]
		public static extern NSString UbiquitousSharedItemPermissionsReadWrite { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed] // by default this property is null
		[Export ("searchItems", ArgumentSemantic.Copy)]
		// DOC: object is a mixture of NSString, NSMetadataItem, NSUrl
		public static extern NSObject [] SearchItems { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed] // by default this property is null
		[Export ("operationQueue", ArgumentSemantic.Retain)]
		public static extern NSOperationQueue OperationQueue { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("enumerateResultsUsingBlock:")]
		public static extern void EnumerateResultsUsingBlock (NSMetadataQueryEnumerationCallback callback);

		[Export ("enumerateResultsWithOptions:usingBlock:")]
		[MacCatalyst (13, 1)]
		public static extern void EnumerateResultsWithOptions (NSEnumerationOptions opts, NSMetadataQueryEnumerationCallback block);

		//
		// These are for NSMetadataQueryDidUpdateNotification 
		//
		[MacCatalyst (13, 1)]
		[Field ("NSMetadataQueryUpdateAddedItemsKey")]
		public static extern NSString QueryUpdateAddedItemsKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataQueryUpdateChangedItemsKey")]
		public static extern NSString QueryUpdateChangedItemsKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSMetadataQueryUpdateRemovedItemsKey")]
		public static extern NSString QueryUpdateRemovedItemsKey { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial class NSSortDescriptor : NSCopying {
		[Export ("initWithKey:ascending:")]
		public extern NativeHandle Constructor (string key, bool ascending);

		[Export ("initWithKey:ascending:selector:")]
		public extern NativeHandle Constructor (string key, bool ascending, [NullAllowed] Selector selector);

		[Export ("initWithKey:ascending:comparator:")]
		public extern NativeHandle Constructor (string key, bool ascending, NSComparator comparator);

		[Export ("key")]
		public extern string Key { get; }

		[Export ("ascending")]
		public extern bool Ascending { get; }

		[NullAllowed]
		[Export ("selector")]
		public extern Selector? Selector { get; }

		[Export ("compareObject:toObject:")]
		public extern NSComparisonResult Compare (NSObject object1, NSObject object2);

		[Export ("reversedSortDescriptor")]
		public extern NSObject ReversedSortDescriptor { get; }

		[MacCatalyst (13, 1)]
		[Export ("allowEvaluation")]
		public extern void AllowEvaluation ();
	}
	
	public partial class INSMetadataQueryDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	public partial class NSMetadataQueryDelegate {
		[Export ("metadataQuery:replacementObjectForResultObject:"), DelegateName ("NSMetadataQueryObject"), DefaultValue (null)]
		public static extern NSObject ReplacementObjectForResultObject (NSMetadataQuery query, NSMetadataItem result);

		[Export ("metadataQuery:replacementValueForAttribute:value:"), DelegateName ("NSMetadataQueryValue"), DefaultValue (null)]
		public static extern NSObject ReplacementValueForAttributevalue (NSMetadataQuery query, string attributeName, NSObject value);
	}
	
	public partial interface INSSecureCoding {}
	
	public delegate void NSAttributedRangeCallback (NSDictionary attrs, NSRange range, ref bool stop);
	public delegate void NSAttributedStringCallback (NSObject value, NSRange range, ref bool stop);

	public delegate bool NSEnumerateErrorHandler (NSUrl url, NSError error);
	public delegate void NSMetadataQueryEnumerationCallback (NSObject result, nuint idx, ref bool stop);
#if NET
	public delegate void NSItemProviderCompletionHandler (INSSecureCoding itemBeingLoaded, NSError error);
#else
	public delegate void NSItemProviderCompletionHandler (NSObject itemBeingLoaded, NSError error);
#endif
	public delegate void NSItemProviderLoadHandler ([BlockCallback] NSItemProviderCompletionHandler completionHandler, Class expectedValueClass, NSDictionary options);
	public delegate void EnumerateDatesCallback (NSDate date, bool exactMatch, ref bool stop);
	public delegate void EnumerateIndexSetCallback (nuint idx, ref bool stop);
	//public delegate void CloudKitRegistrationPreparationAction ([BlockCallback] CloudKitRegistrationPreparationHandler handler);
	//public delegate void CloudKitRegistrationPreparationHandler (CKShare share, CKContainer container, NSError error);
	
}