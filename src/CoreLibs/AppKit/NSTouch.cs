using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

#nullable enable

namespace AppKit {
	public partial class NSTouch {
#if !NET
		[Obsolete ("This type is not meant to be user-created")]
		public NSTouch ()
		{
		}
#endif
	}
	
	[NoMacCatalyst]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	public partial class NSTouch : NSCopying {
		[Export ("identity", ArgumentSemantic.Retain)]
		public extern NSObject Identity { get; }

		[Export ("phase")]
		public extern NSTouchPhase Phase { get; }

		[Export ("normalizedPosition")]
		public extern CGPoint NormalizedPosition { get; }

		[Export ("isResting")]
		public extern bool IsResting { get; }

		[Export ("device", ArgumentSemantic.Retain)]
		public extern NSObject Device { get; }

		[Export ("deviceSize")]
		public extern CGSize DeviceSize { get; }
	}
}
