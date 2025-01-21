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
using UIKit;
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
    public interface INSPreviewRepresentableActivityItem { }

    //[NoMacCatalyst, Mac (13, 0)]
    [Protocol]
    public partial class NSPreviewRepresentableActivityItem {
        [Abstract]
        [Export ("item", ArgumentSemantic.Strong)]
        public extern NSObject Item { get; }

        [NullAllowed, Export ("title")]
        public extern string? Title { get; }

        [NullAllowed, Export ("imageProvider", ArgumentSemantic.Strong)]
        extern NSItemProvider? ImageProvider { get; }

        [NullAllowed, Export ("iconProvider", ArgumentSemantic.Strong)]
        extern NSItemProvider? IconProvider { get; }
    }

    //[NoMacCatalyst, Mac (13, 0)]
    [BaseType (typeof (NSObject))]
    [DisableDefaultCtor]
    public partial class  NSPreviewRepresentingActivityItem : NSPreviewRepresentableActivityItem {
        [NoiOS]
        [Export ("initWithItem:title:image:icon:")]
        public extern NativeHandle Constructor (NSObject item, [NullAllowed] string title, [NullAllowed] NSImage image, [NullAllowed] NSImage icon);

        [NoiOS]
        [Export ("initWithItem:title:imageProvider:iconProvider:")]
        [DesignatedInitializer]
        extern NativeHandle Constructor (NSObject item, [NullAllowed] string title, [NullAllowed] NSItemProvider imageProvider, [NullAllowed] NSItemProvider iconProvider);
    }
}