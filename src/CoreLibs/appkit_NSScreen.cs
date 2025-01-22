#region USING
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreFoundation;
using CoreImage;
using CoreAnimation;
//using CoreData;
using CoreLibs;
//using Intents;
//using SharedWithYouCore;
//using Symbols;
#if !__MACCATALYST__
using OpenGL;
#endif
using CoreVideo;
//using CloudKit;
using UniformTypeIdentifiers;

#if __MACCATALYST__
//using UIKit;
#else
using UIMenu = Foundation.NSObject;
using UIMenuElement = Foundation.NSObject;
#endif

using CGGlyph = System.UInt16;
#if __MACCATALYST__
using CAOpenGLLayer = Foundation.NSObject;
using CGLContext = Foundation.NSObject;
using CGLPixelFormat = Foundation.NSObject;
//using Color = UIKit.UIColor;
using NSColorList = Foundation.NSObject;
#else
using Color = AppKit.NSColor;
using IUIActivityItemsConfigurationReading = System.Object;
using UIBarButtonItem = Foundation.NSObject;
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

#endregion

namespace AppKit
{
	public partial class NSScreen {
		[Notification, Field ("NSScreenColorSpaceDidChangeNotification")]
		public extern NSString ColorSpaceDidChangeNotification { get; }
	}
	
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	public partial class NSScreen {

		[ThreadSafe]
		[Static]
		[Export ("screens", ArgumentSemantic.Copy)]
		public static extern NSScreen [] Screens { get; }

		[ThreadSafe]
		[Static]
		[Export ("mainScreen")]
		public static extern NSScreen MainScreen { get; }

		[ThreadSafe]
		[Static]
		[Export ("deepestScreen")]
		public static extern NSScreen DeepestScreen { get; }

		[ThreadSafe]
		[Export ("depth")]
		public extern NSWindowDepth Depth { get; }

		[ThreadSafe]
		[Export ("frame")]
		public extern CGRect Frame { get; }

		[ThreadSafe]
		[Export ("visibleFrame")]
		public extern CGRect VisibleFrame { get; }

		[ThreadSafe]
		[Export ("deviceDescription")]
		public extern NSDictionary DeviceDescription { get; }

		[ThreadSafe]
		[Export ("colorSpace")]
		public extern NSColorSpace ColorSpace { get; }

		[Export ("supportedWindowDepths"), Internal]
		public extern IntPtr GetSupportedWindowDepths ();

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("userSpaceScaleFactor")]
		public extern nfloat UserSpaceScaleFactor { get; }

		[Export ("convertRectToBacking:")]
		public extern CGRect ConvertRectToBacking (CGRect aRect);

		[Export ("convertRectFromBacking:")]
		public extern CGRect ConvertRectfromBacking (CGRect aRect);

		[Export ("backingAlignedRect:options:")]
		public extern CGRect GetBackingAlignedRect (CGRect globalScreenCoordRect, NSAlignmentOptions options);

		[ThreadSafe]
		[Export ("backingScaleFactor")]
		public extern nfloat BackingScaleFactor { get; }

		[ThreadSafe]
		[Static, Export ("screensHaveSeparateSpaces")]
		public extern bool ScreensHaveSeparateSpaces ();

		[Export ("canRepresentDisplayGamut:")]
		public extern bool CanRepresentDisplayGamut (NSDisplayGamut displayGamut);

		// Inlined from unnamed category.
		[ThreadSafe]
		[Export ("maximumExtendedDynamicRangeColorComponentValue")]
		public extern nfloat MaximumExtendedDynamicRangeColorComponentValue { get; }

		[ThreadSafe]
		[Export ("maximumPotentialExtendedDynamicRangeColorComponentValue")]
		public extern nfloat MaximumPotentialExtendedDynamicRangeColorComponentValue { get; }

		[ThreadSafe]
		[Export ("maximumReferenceExtendedDynamicRangeColorComponentValue")]
		public extern nfloat MaximumReferenceExtendedDynamicRangeColorComponentValue { get; }

		[ThreadSafe]
		[Export ("localizedName", ArgumentSemantic.Copy)]
		public extern string LocalizedName { get; }

		[ThreadSafe]
		[Export ("safeAreaInsets")]
		public extern NSEdgeInsets SafeAreaInsets { get; }

		[ThreadSafe]
		[Export ("auxiliaryTopLeftArea")]
		public extern CGRect AuxiliaryTopLeftArea { get; }

		[ThreadSafe]
		[Export ("auxiliaryTopRightArea")]
		public extern CGRect AuxiliaryTopRightArea { get; }

		[Export ("maximumFramesPerSecond")]
		public extern nint MaximumFramesPerSecond { get; }

		[Export ("minimumRefreshInterval")]
		public extern double MinimumRefreshInterval { get; }

		[Export ("maximumRefreshInterval")]
		public extern double MaximumRefreshInterval { get; }

		[Export ("displayUpdateGranularity")]
		public extern double DisplayUpdateGranularity { get; }

		[Export ("lastDisplayUpdateTimestamp")]
		public extern double LastDisplayUpdateTimestamp { get; }

		// from @interface NSDisplayLink (NSScreen)

		//[Mac (14, 0)]
		[Export ("displayLinkWithTarget:selector:")]
		public extern CADisplayLink GetDisplayLink (NSObject target, Selector selector);
	}
}