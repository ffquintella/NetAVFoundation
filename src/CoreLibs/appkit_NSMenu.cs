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
    [MacCatalyst (13, 1)]
    [BaseType (typeof (NSToolbarItem))]
#if XAMCORE_5_0
	[DisableDefaultCtor]
#endif
    public class NSMenuToolbarItem: NSToolbarItem {
        [DesignatedInitializer]
        [Export ("initWithItemIdentifier:")]
        public extern NativeHandle Constructor (string itemIdentifier);

        [NoMacCatalyst]
        [Export ("menu", ArgumentSemantic.Strong)]
        public extern NSMenu Menu { get; set; }

        [Export ("showsIndicator")]
        public extern bool ShowsIndicator { get; set; }

        [MacCatalyst (13, 1)]
        [NoMac]
        [Export ("itemMenu", ArgumentSemantic.Copy)]
        public extern UIMenu ItemMenu { get; set; }
    }
    
    public partial class NSMenuItemIndexEventArgs {
        [Export ("NSMenuItemIndex")]
        public extern nint MenuItemIndex { get; }
    }

    public partial class NSMenuItemEventArgs {
        [Export ("MenuItem")]
        public extern NSMenu MenuItem { get; }
    }

    public partial class NSMenu {
        [Notification (typeof (NSMenuItemEventArgs))]
        [Field ("NSMenuWillSendActionNotification")]
        public extern NSString WillSendActionNotification { get; }

        [Notification (typeof (NSMenuItemEventArgs))]
        [Field ("NSMenuDidSendActionNotification")]
        public extern  NSString DidSendActionNotification { get; }

        [Notification (typeof (NSMenuItemIndexEventArgs))]
        [Field ("NSMenuDidAddItemNotification")]
        public extern NSString DidAddItemNotification { get; }

        [Notification (typeof (NSMenuItemIndexEventArgs))]
        [Field ("NSMenuDidRemoveItemNotification")]
        public extern NSString DidRemoveItemNotification { get; }

        [Notification (typeof (NSMenuItemIndexEventArgs))]
        [Field ("NSMenuDidChangeItemNotification")]
        public extern NSString DidChangeItemNotification { get; }

        [Notification, Field ("NSMenuDidBeginTrackingNotification")]
        public extern NSString DidBeginTrackingNotification { get; }

        [Notification, Field ("NSMenuDidEndTrackingNotification")]
        public extern  NSString DidEndTrackingNotification { get; }
    }
}