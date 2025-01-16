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
    [NoMacCatalyst]
    [BaseType (typeof (NSObject))]
    public partial class NSColorList : NSObject {
        [Static]
        [Export ("availableColorLists")]
        public static extern NSColorList [] AvailableColorLists { get; }

        [Static]
        [Export ("colorListNamed:")]
        public static extern NSColorList ColorListNamed (string name);

        [Export ("initWithName:")]
        public extern NativeHandle Constructor (string name);

        [Export ("initWithName:fromFile:")]
        public extern NativeHandle Constructor (string name, [NullAllowed] string path);

        [Export ("name")]
        public extern string Name { get; }

        [Export ("setColor:forKey:")]
        public extern void SetColorForKey (NSColor color, string key);

        [Export ("insertColor:key:atIndex:")]
        public extern void InsertColor (NSColor color, string key, nint indexPos);

        [Export ("removeColorWithKey:")]
        public extern void RemoveColor (string key);

        [Export ("colorWithKey:")]
        public extern NSColor ColorWithKey (string key);

        [Export ("allKeys")]
        public extern string [] AllKeys ();

        [Export ("isEditable")]
        public extern bool IsEditable { get; }

        [Export ("writeToFile:")]
        [Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'WriteToUrl' instead.")]
        public extern bool WriteToFile ([NullAllowed] string path);

        [Export ("removeFile")]
        public extern void RemoveFile ();

        [Export ("writeToURL:error:")]
        public extern bool WriteToUrl ([NullAllowed] NSUrl url, [NullAllowed] out NSError error);
    }
}