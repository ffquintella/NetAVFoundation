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
    [MacCatalyst (13, 1)]
    [BaseType (typeof (NSTouchBarItem))]
    [DisableDefaultCtor]
    public partial class NSColorPickerTouchBarItem {
        [Export ("initWithIdentifier:")]
        [DesignatedInitializer]
        public extern NativeHandle Constructor (string identifier);

        [Static]
        [Export ("colorPickerWithIdentifier:")]
        public extern static NSColorPickerTouchBarItem CreateColorPicker (string identifier);

        [Static]
        [Export ("textColorPickerWithIdentifier:")]
        public extern static NSColorPickerTouchBarItem CreateTextColorPicker (string identifier);

        [Static]
        [Export ("strokeColorPickerWithIdentifier:")]
        public extern static NSColorPickerTouchBarItem CreateStrokeColorPicker (string identifier);

        [Static]
        [Export ("colorPickerWithIdentifier:buttonImage:")]
        public extern static NSColorPickerTouchBarItem CreateColorPicker (string identifier, NSImage image);

        [Export ("color", ArgumentSemantic.Copy)]
        public extern Color Color { get; set; }

        [Export ("showsAlpha")]
        public extern bool ShowsAlpha { get; set; }

        [NoMacCatalyst]
        [Export ("colorList", ArgumentSemantic.Strong)]
        public extern NSColorList ColorList { get; set; }

        [NullAllowed]
        [Export ("customizationLabel")]
        public extern string CustomizationLabel { get; set; }

        [NullAllowed, Export ("target", ArgumentSemantic.Weak)]
        public extern NSObject? Target { get; set; }

        [NullAllowed, Export ("action", ArgumentSemantic.Assign)]
        public extern Selector? Action { get; set; }

        [Export ("enabled")]
        public extern bool Enabled { [Bind ("isEnabled")] get; set; }

        [NoMacCatalyst]
        [NullAllowed, Export ("allowedColorSpaces", ArgumentSemantic.Copy)]
        public extern NSColorSpace []? AllowedColorSpaces { get; set; }
    }
}