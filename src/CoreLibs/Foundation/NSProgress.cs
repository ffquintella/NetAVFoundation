#if !COREBUILD
using System;
using CoreLibs;
using Foundation;
using ObjCRuntime;

namespace Foundation {
	public partial class NSProgress {
		//Manual bindings until BindAs support is merged
		public nint? EstimatedTimeRemaining {
			get { return _EstimatedTimeRemaining?.NIntValue; }
			set { _EstimatedTimeRemaining = value is not null ? new NSNumber (value.Value) : null; }
		}

		public nint? Throughput {
			get { return _Throughput?.NIntValue; }
			set { _Throughput = value is not null ? new NSNumber (value.Value) : null; }
		}

		public nint? FileTotalCount {
			get { return _FileTotalCount?.NIntValue; }
			set { _FileTotalCount = value is not null ? new NSNumber (value.Value) : null; }
		}

		public nint? FileCompletedCount {
			get { return _FileCompletedCount?.NIntValue; }
			set { _FileCompletedCount = value is not null ? new NSNumber (value.Value) : null; }
		}
	}
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class NSProgress {

		[Static, Export ("currentProgress")]
		public static extern NSProgress CurrentProgress { get; }

		[Static, Export ("progressWithTotalUnitCount:")]
		public static extern NSProgress FromTotalUnitCount (long unitCount);

		[MacCatalyst (13, 1)]
		[Static, Export ("discreteProgressWithTotalUnitCount:")]
		public static extern NSProgress GetDiscreteProgress (long unitCount);

		[MacCatalyst (13, 1)]
		[Static, Export ("progressWithTotalUnitCount:parent:pendingUnitCount:")]
		public static extern NSProgress FromTotalUnitCount (long unitCount, NSProgress parent, long portionOfParentTotalUnitCount);

		[DesignatedInitializer]
		[Export ("initWithParent:userInfo:")]
		public static extern NativeHandle Constructor ([NullAllowed] NSProgress parentProgress, [NullAllowed] NSDictionary userInfo);

		[Export ("becomeCurrentWithPendingUnitCount:")]
		public static extern void BecomeCurrent (long pendingUnitCount);

		[Export ("resignCurrent")]
		public static extern void ResignCurrent ();

		[MacCatalyst (13, 1)]
		[Export ("addChild:withPendingUnitCount:")]
		public static extern void AddChild (NSProgress child, long pendingUnitCount);

		[Export ("totalUnitCount")]
		public static extern long TotalUnitCount { get; set; }

		[Export ("completedUnitCount")]
		public static extern long CompletedUnitCount { get; set; }

		[Export ("localizedDescription", ArgumentSemantic.Copy), NullAllowed]
		public static extern string LocalizedDescription { get; set; }

		[Export ("localizedAdditionalDescription", ArgumentSemantic.Copy), NullAllowed]
		public static extern string LocalizedAdditionalDescription { get; set; }

		[Export ("cancellable")]
		public static extern bool Cancellable { [Bind ("isCancellable")] get; set; }

		[Export ("pausable")]
		public static extern bool Pausable { [Bind ("isPausable")] get; set; }

		[Export ("cancelled")]
		public static extern bool Cancelled { [Bind ("isCancelled")] get; }

		[Export ("paused")]
		public static extern bool Paused { [Bind ("isPaused")] get; }

		[Export ("setCancellationHandler:")]
		public static extern void SetCancellationHandler (Action handler);

		[Export ("setPausingHandler:")]
		public static extern void SetPauseHandler (Action handler);

		[MacCatalyst (13, 1)]
		[Export ("setResumingHandler:")]
		public static extern void SetResumingHandler (Action handler);

		[Export ("setUserInfoObject:forKey:")]
		public static extern void SetUserInfo ([NullAllowed] NSObject obj, NSString key);

		[Export ("indeterminate")]
		public static extern bool Indeterminate { [Bind ("isIndeterminate")] get; }

		[Export ("fractionCompleted")]
		public static extern double FractionCompleted { get; }

		[Export ("cancel")]
		public static extern void Cancel ();

		[Export ("pause")]
		public static extern void Pause ();

		[MacCatalyst (13, 1)]
		[Export ("resume")]
		public static extern void Resume ();

		[Export ("userInfo")]
		public static extern NSDictionary UserInfo { get; }

		[NullAllowed] // by default this property is null
		[Export ("kind", ArgumentSemantic.Copy)]
		public static extern NSString Kind { get; set; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("publish")]
		public static extern void Publish ();

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("unpublish")]
		public static extern void Unpublish ();

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("setAcknowledgementHandler:forAppBundleIdentifier:")]
		public static extern void SetAcknowledgementHandler (Action<bool> acknowledgementHandler, string appBundleIdentifier);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Static, Export ("addSubscriberForFileURL:withPublishingHandler:")]
		public static extern NSObject AddSubscriberForFile (NSUrl url, Action<NSProgress> publishingHandler);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Static, Export ("removeSubscriber:")]
		public static extern void RemoveSubscriber (NSObject subscriber);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("acknowledgeWithSuccess:")]
		public static extern void AcknowledgeWithSuccess (bool success);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("old")]
		public static extern bool Old { [Bind ("isOld")] get; }

		[Field ("NSProgressKindFile")]
		public static extern NSString KindFile { get; }

		[Field ("NSProgressEstimatedTimeRemainingKey")]
		public static extern NSString EstimatedTimeRemainingKey { get; }

		[Field ("NSProgressThroughputKey")]
		public static extern NSString ThroughputKey { get; }

		[Field ("NSProgressFileOperationKindKey")]
		public static extern NSString FileOperationKindKey { get; }

		[Field ("NSProgressFileOperationKindDownloading")]
		public static extern NSString FileOperationKindDownloading { get; }

		[Field ("NSProgressFileOperationKindDecompressingAfterDownloading")]
		public static extern NSString FileOperationKindDecompressingAfterDownloading { get; }

		[Field ("NSProgressFileOperationKindReceiving")]
		public static extern NSString FileOperationKindReceiving { get; }

		[Field ("NSProgressFileOperationKindCopying")]
		public static extern NSString FileOperationKindCopying { get; }

		//[Watch (7, 4), TV (14, 5), iOS (14, 5)]
		[MacCatalyst (14, 5)]
		[Field ("NSProgressFileOperationKindUploading")]
		public static extern NSString FileOperationKindUploading { get; }

		[Field ("NSProgressFileURLKey")]
		public static extern NSString FileURLKey { get; }

		[Field ("NSProgressFileTotalCountKey")]
		public static extern NSString FileTotalCountKey { get; }

		[Field ("NSProgressFileCompletedCountKey")]
		public static extern NSString FileCompletedCountKey { get; }

		//[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Field ("NSProgressFileOperationKindDuplicating")]
		public static extern NSString FileOperationKindDuplicatingKey { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Field ("NSProgressFileAnimationImageKey")]
		public static extern NSString FileAnimationImageKey { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Field ("NSProgressFileAnimationImageOriginalRectKey")]
		public static extern NSString FileAnimationImageOriginalRectKey { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Field ("NSProgressFileIconKey")]
		public static extern NSString FileIconKey { get; }

		[MacCatalyst (13, 1)]
		[Async, Export ("performAsCurrentWithPendingUnitCount:usingBlock:")]
		public static extern void PerformAsCurrent (long unitCount, Action work);

		[Export ("finished")]
		public static extern bool Finished { [Bind ("isFinished")] get; }

		[Internal]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("estimatedTimeRemaining", ArgumentSemantic.Copy)]
		//[BindAs (typeof (nint?))]
		public static extern NSNumber _EstimatedTimeRemaining { get; set; }

		[Internal]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("throughput", ArgumentSemantic.Copy)]
		//[BindAs (typeof (nint?))]
		public static extern NSNumber _Throughput { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("fileOperationKind")]
		public static extern string FileOperationKind { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("fileURL", ArgumentSemantic.Copy)]
		public static extern NSUrl FileUrl { get; set; }

		[Internal]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("fileTotalCount", ArgumentSemantic.Copy)]
		//[BindAs (typeof (nint?))]
		public static extern NSNumber _FileTotalCount { get; set; }

		[Internal]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("fileCompletedCount", ArgumentSemantic.Copy)]
		//[BindAs (typeof (nint?))]
		public static extern NSNumber _FileCompletedCount { get; set; }
	}

	partial class INSProgressReporting { }
}
#endif
