using CoreLibs;
using Foundation;
using ObjCRuntime;
using INSFileProviderItem = Foundation.NSObject;

namespace Foundation
{
	
	//[BaseType(typeof(NSObject))]
	public partial class NSError : NSCopying
	{
		[Static, Export("errorWithDomain:code:userInfo:")]
		public static extern NSError FromDomain(NSString domain, nint code, [NullAllowed] NSDictionary userInfo);

		[DesignatedInitializer]
		[Export("initWithDomain:code:userInfo:")]
		public extern NativeHandle Constructor(NSString domain, nint code, [NullAllowed] NSDictionary userInfo);

		[Export("domain")] public extern string Domain { get; }

		[Export("code")] public extern nint Code { get; }

		[Export("userInfo")] public extern NSDictionary UserInfo { get; }

		[Export("localizedDescription")] public extern string LocalizedDescription { get; }

		[Export("localizedFailureReason")] public extern string LocalizedFailureReason { get; }

		[Export("localizedRecoverySuggestion")]
		public extern string LocalizedRecoverySuggestion { get; }

		[Export("localizedRecoveryOptions")] public extern string[] LocalizedRecoveryOptions { get; }

		[Export("helpAnchor")] public extern string HelpAnchor { get; }

		[Watch(7, 4), TV(14, 5), iOS(14, 5)]
		[MacCatalyst(14, 5)]
		[Export("underlyingErrors", ArgumentSemantic.Copy)]
		public extern NSError[] UnderlyingErrors { get; }

		[Field("NSCocoaErrorDomain")] public static extern NSString CocoaErrorDomain { get; }

		[Field("NSPOSIXErrorDomain")] public static extern NSString PosixErrorDomain { get; }

		[Field("NSOSStatusErrorDomain")] public static extern NSString OsStatusErrorDomain { get; }

		[Field("NSMachErrorDomain")] public static extern NSString MachErrorDomain { get; }

		[Field("NSURLErrorDomain")] public static extern NSString NSUrlErrorDomain { get; }

#if NET
		[NoWatch]
		[MacCatalyst(13, 1)]
#else
	[Obsoleted (PlatformName.WatchOS, 7, 0)]
#endif
		[Field("NSNetServicesErrorDomain")]
		public extern NSString NSNetServicesErrorDomain { get; }

		[NoWatch]
		[Field("NSNetServicesErrorCode")]
		public extern NSString NSNetServicesErrorCode { get; }

		[Field("NSStreamSocketSSLErrorDomain")]
		public extern NSString NSStreamSocketSSLErrorDomain { get; }

		[Field("NSStreamSOCKSErrorDomain")] public extern NSString NSStreamSOCKSErrorDomain { get; }

		[Field("kCLErrorDomain", "CoreLocation")]
		public extern static NSString CoreLocationErrorDomain { get; }

#if !WATCH
		[Field("kCFErrorDomainCFNetwork", "CFNetwork")]
		public extern static NSString CFNetworkErrorDomain { get; }
#endif

		[NoMac, NoTV]
		[MacCatalyst(13, 1)]
		[Field("CMErrorDomain", "CoreMotion")]
		public static extern NSString CoreMotionErrorDomain { get; }

		[NoMac, NoTV, NoWatch]
		[iOS(12, 0)]
		[NoMacCatalyst] // We don't expose CarPlay on Mac Catalyst for the moment // [MacCatalyst (14, 0)]
		[Field("CarPlayErrorDomain", "CarPlay")]
		public static extern NSString CarPlayErrorDomain { get; }

		[Field("NSUnderlyingErrorKey")] public static extern NSString UnderlyingErrorKey { get; }

		[Watch(7, 4), TV(14, 5), iOS(14, 5)]
		[MacCatalyst(14, 5)]
		[Field("NSMultipleUnderlyingErrorsKey")]
		public static extern NSString MultipleUnderlyingErrorsKey { get; }

		[Field("NSLocalizedDescriptionKey")] public static extern NSString LocalizedDescriptionKey { get; }

		[Field("NSLocalizedFailureReasonErrorKey")]
		public static extern NSString LocalizedFailureReasonErrorKey { get; }

		[Field("NSLocalizedRecoverySuggestionErrorKey")]
		public static extern NSString LocalizedRecoverySuggestionErrorKey { get; }

		[Field("NSLocalizedRecoveryOptionsErrorKey")]
		public static extern NSString LocalizedRecoveryOptionsErrorKey { get; }

		[Field("NSRecoveryAttempterErrorKey")] public static extern NSString RecoveryAttempterErrorKey { get; }

		[Field("NSHelpAnchorErrorKey")] public static extern NSString HelpAnchorErrorKey { get; }

		[Field("NSStringEncodingErrorKey")] public static extern NSString StringEncodingErrorKey { get; }

		[Field("NSURLErrorKey")] public static extern NSString UrlErrorKey { get; }

		[Field("NSFilePathErrorKey")] public static extern NSString FilePathErrorKey { get; }

		[MacCatalyst(13, 1)]
		[Field("NSDebugDescriptionErrorKey")]
		public static extern NSString DebugDescriptionErrorKey { get; }

		[MacCatalyst(13, 1)]
		[Field("NSLocalizedFailureErrorKey")]
		public static extern NSString LocalizedFailureErrorKey { get; }

		[MacCatalyst(13, 1)]
		[Static]
		[Export("setUserInfoValueProviderForDomain:provider:")]
		public static extern void SetUserInfoValueProvider(string errorDomain,
			[NullAllowed] NSErrorUserInfoValueProvider provider);

		[MacCatalyst(13, 1)]
		[Static]
		[Export("userInfoValueProviderForDomain:")]
		[return: NullAllowed]
		public static extern NSErrorUserInfoValueProvider? GetUserInfoValueProvider(string errorDomain);

		// From NSError (NSFileProviderError) Category to avoid static category uglyness

		[NoMacCatalyst]
		[NoTV]
		[NoWatch]
		[Static]
		[Export("fileProviderErrorForCollisionWithItem:")]
		public static extern NSError GetFileProviderError(INSFileProviderItem existingItem);

		[NoMacCatalyst]
		[NoTV]
		[NoWatch]
		[Static]
		[Export("fileProviderErrorForNonExistentItemWithIdentifier:")]
		public static extern NSError GetFileProviderError(string nonExistentItemIdentifier);

		[iOS(16, 0)]
		[NoMacCatalyst]
		[NoTV]
		[NoWatch]
		[Static]
		[Export("fileProviderErrorForRejectedDeletionOfItem:")]
		public static extern NSError GetFileProviderErrorForRejectedDeletion(INSFileProviderItem updatedVersion);

#if false
	// FIXME that value is present in the header (7.0 DP 6) files but returns NULL (i.e. unusable)
	// we're also missing other NSURLError* fields (which we should add)
	[Field ("NSURLErrorBackgroundTaskCancelledReasonKey")]
	public NSString NSUrlErrorBackgroundTaskCancelledReasonKey { get; }
#endif

#if IOS && !MACCATALYST
	[iOS (18, 2), NoMacCatalyst, NoTV, NoMac]
	[Field ("UIApplicationCategoryDefaultRetryAvailabilityDateErrorKey", "UIKit")]
	public NSString UIApplicationCategoryDefaultRetryAvailabilityDateErrorKey { get; }

	[iOS (18, 2), NoMacCatalyst, NoTV, NoMac]
	[Field ("UIApplicationCategoryDefaultStatusLastProvidedDateErrorKey", "UIKit")]
	public NSString UIApplicationCategoryDefaultStatusLastProvidedDateErrorKey { get; }
#endif
	}

	public delegate NSObject NSErrorUserInfoValueProvider(NSError error, NSString userInfoKey);
	
}