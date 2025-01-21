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
using CoreData;
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
    [NoMacCatalyst]
	[ThreadSafe]
	[BaseType (typeof (NSObject))]
	public partial class NSColorSpace : NSCoding {
		[Export ("initWithICCProfileData:")]
		public extern NativeHandle Constructor (NSData iccData);

		[Export ("ICCProfileData")]
		public extern NSData ICCProfileData { get; }

		// Conflicts with the built-in handle intptr
		//[Export ("initWithColorSyncProfile:")]
		//NativeHandle Constructor (IntPtr colorSyncProfile);

		[Export ("colorSyncProfile")]
		public extern IntPtr ColorSyncProfile { get; }

		[Export ("initWithCGColorSpace:")]
		public extern NativeHandle Constructor (CGColorSpace cgColorSpace);

		[Export ("CGColorSpace")]
		public extern CGColorSpace ColorSpace { get; }

		[Export ("numberOfColorComponents")]
		public extern nint ColorComponents { get; }

		[Export ("colorSpaceModel")]
		public extern NSColorSpaceModel ColorSpaceModel { get; }

		[Export ("localizedName")]
		public extern string LocalizedName { get; }

		[Static]
		[Export ("genericRGBColorSpace")]
		public extern NSColorSpace GenericRGBColorSpace { get; }

		[Static]
		[Export ("genericGrayColorSpace")]
		public static extern NSColorSpace GenericGrayColorSpace { get; }

		[Static]
		[Export ("genericCMYKColorSpace")]
		public static extern NSColorSpace GenericCMYKColorSpace { get; }

		[Static]
		[Export ("deviceRGBColorSpace")]
		public static extern NSColorSpace DeviceRGBColorSpace { get; }

		[Static]
		[Export ("deviceGrayColorSpace")]
		public static extern NSColorSpace DeviceGrayColorSpace { get; }

		[Static]
		[Export ("deviceCMYKColorSpace")]
		public static extern NSColorSpace DeviceCMYKColorSpace { get; }

		[Static]
		[Export ("sRGBColorSpace")]
		public static extern NSColorSpace SRGBColorSpace { get; }

		[Static]
		[Export ("genericGamma22GrayColorSpace")]
		public static extern NSColorSpace GenericGamma22GrayColorSpace { get; }

		[Static]
		[Export ("adobeRGB1998ColorSpace")]
		public static extern NSColorSpace AdobeRGB1998ColorSpace { get; }

		[Static]
		[Export ("availableColorSpacesWithModel:")]
		public static extern NSColorSpace [] AvailableColorSpacesWithModel (NSColorSpaceModel model);

		[Static]
		[Export ("extendedSRGBColorSpace")]
		public static extern NSColorSpace ExtendedSRgbColorSpace { get; }

		[Static]
		[Export ("extendedGenericGamma22GrayColorSpace")]
		public static extern NSColorSpace ExtendedGenericGamma22GrayColorSpace { get; }

		[Static]
		[Export ("displayP3ColorSpace")]
		public static extern NSColorSpace DisplayP3ColorSpace { get; }

		[Field ("NSCalibratedWhiteColorSpace")]
		public static extern NSString CalibratedWhite { get; }

		[Field ("NSCalibratedBlackColorSpace")]
		public static extern NSString CalibratedBlack { get; }

		[Field ("NSCalibratedRGBColorSpace")]
		public static extern NSString CalibratedRGB { get; }

		[Field ("NSDeviceWhiteColorSpace")]
		public static extern NSString DeviceWhite { get; }

		[Field ("NSDeviceBlackColorSpace")]
		public static extern NSString DeviceBlack { get; }

		[Field ("NSDeviceRGBColorSpace")]
		public static extern NSString DeviceRGB { get; }

		[Field ("NSDeviceCMYKColorSpace")]
		public static extern NSString DeviceCMYK { get; }

		[Field ("NSNamedColorSpace")]
		public static extern NSString Named { get; }

		[Field ("NSPatternColorSpace")]
		public static extern NSString Pattern { get; }

		[Field ("NSCustomColorSpace")]
		public static extern NSString Custom { get; }
	}
}