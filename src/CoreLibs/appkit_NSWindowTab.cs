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
    [BaseType (typeof (NSObject))]
    public class NSWindowTab {
        [Export ("title")]
        public extern string Title { get; set; }

        [NullAllowed, Export ("attributedTitle", ArgumentSemantic.Copy)]
        public extern NSAttributedString AttributedTitle { get; set; }

        [Export ("toolTip"), NullAllowed]
        public extern string ToolTip { get; set; }

        [NullAllowed, Export ("accessoryView", ArgumentSemantic.Strong)]
        public extern  NSView AccessoryView { get; set; }
    }
    
    [NoMacCatalyst]
    [BaseType (typeof (NSObject))]
    [DisableDefaultCtor]
    public partial class NSWindowTabGroup {
        [Export ("identifier")]
        public extern string Identifier { get; }

        [Export ("windows", ArgumentSemantic.Copy)]
        public extern NSWindow [] Windows { get; }

        [Export ("overviewVisible")]
        public extern bool OverviewVisible { [Bind ("isOverviewVisible")] get; set; }

        [Export ("tabBarVisible")]
        public extern bool TabBarVisible { [Bind ("isTabBarVisible")] get; }

        [NullAllowed, Export ("selectedWindow", ArgumentSemantic.Weak)]
        public extern NSWindow SelectedWindow { get; set; }

        [Export ("addWindow:")]
        public extern void Add (NSWindow window);

        [Export ("insertWindow:atIndex:")]
        public extern void Insert (NSWindow window, nint index);

        [Export ("removeWindow:")]
        public extern void Remove (NSWindow window);
    }
}