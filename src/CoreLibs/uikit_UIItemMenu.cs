
#region USING
//
// This file describes the API that the generator will produce
//
// Authors:
//   Geoff Norton
//   Miguel de Icaza
//   Alex Soto <alexsoto@microsoft.com>
//
// Copyright 2009-2011, Novell, Inc.
// Copyrigh 2011-2013, Xamarin Inc.
// Copyrigh 2019, Microsoft Corporation.
//
using ObjCRuntime;
using Foundation;
using CoreGraphics;
//using CoreLocation;
using UIKit;
//using CloudKit;
#if !TVOS
//using Contacts;
#else
using CNContact = System.Object;
#endif
//using MediaPlayer;
using CoreImage;
using CoreAnimation;
//using CoreData;
//using UserNotifications;
using UniformTypeIdentifiers;
//using Symbols;

#if IOS
using FileProvider;
using LinkPresentation;
#endif // IOS
#if TVOS
using LPLinkMetadata = Foundation.NSObject;
#endif // TVOS
//using Intents;

// Unfortunately this file is a mix of #if's andso we list
// some classes untilis used instead of #if's directives
// to avoid the usage of more #if's

#if !IOS
using UIPointerAccessoryPosition = Foundation.NSObject;
#endif // !IOS

#if __MACCATALYST__
using AppKit;
#else
using NSTouchBarProvider = Foundation.NSObject;
using NSTouchBar = Foundation.NSObject;
using NSToolbar = Foundation.NSObject;
using NSToolbarItem = Foundation.NSObject;
#endif

#if !NET
using NSWritingDirection = UIKit.UITextWritingDirection;
#endif

using System;
using System.ComponentModel;
using CoreLibs;

#if !NET
using NativeHandle = System.IntPtr;
#endif

#nullable enable

#endregion

namespace UIKit
{
    /*
   // [iOS (13, 0), TV (13, 0)]
	[MacCatalyst (13, 1)]
	public enum UIMenuIdentifier {
		//[DefaultEnumValue]
		[Field (null)]
		None,
		[Field ("UIMenuApplication")]
		Application,
		[Field ("UIMenuFile")]
		File,
		[Field ("UIMenuEdit")]
		Edit,
		[Field ("UIMenuView")]
		View,
		[Field ("UIMenuWindow")]
		Window,
		[Field ("UIMenuHelp")]
		Help,
		[Field ("UIMenuAbout")]
		About,
		[Field ("UIMenuPreferences")]
		Preferences,
		[Field ("UIMenuServices")]
		Services,
		[Field ("UIMenuHide")]
		Hide,
		[Field ("UIMenuQuit")]
		Quit,
		[Field ("UIMenuNewScene")]
		NewScene,
		[Field ("UIMenuClose")]
		Close,
		[Field ("UIMenuPrint")]
		Print,
		[Field ("UIMenuUndoRedo")]
		UndoRedo,
		[Field ("UIMenuStandardEdit")]
		StandardEdit,
		[Field ("UIMenuFind")]
		Find,
		[Field ("UIMenuReplace")]
		Replace,
		[Field ("UIMenuShare")]
		Share,
		[Field ("UIMenuTextStyle")]
		TextStyle,
		[Field ("UIMenuSpelling")]
		Spelling,
		[Field ("UIMenuSpellingPanel")]
		SpellingPanel,
		[Field ("UIMenuSpellingOptions")]
		SpellingOptions,
		[Field ("UIMenuSubstitutions")]
		Substitutions,
		[Field ("UIMenuSubstitutionsPanel")]
		SubstitutionsPanel,
		[Field ("UIMenuSubstitutionOptions")]
		SubstitutionOptions,
		[Field ("UIMenuTransformations")]
		Transformations,
		[Field ("UIMenuSpeech")]
		Speech,
		[Field ("UIMenuLookup")]
		Lookup,
		[Field ("UIMenuLearn")]
		Learn,
		[Field ("UIMenuFormat")]
		Format,
		[Field ("UIMenuFont")]
		Font,
		[Field ("UIMenuTextSize")]
		TextSize,
		[Field ("UIMenuTextColor")]
		TextColor,
		[Field ("UIMenuTextStylePasteboard")]
		TextStylePasteboard,
		[Field ("UIMenuText")]
		Text,
		[Field ("UIMenuWritingDirection")]
		WritingDirection,
		[Field ("UIMenuAlignment")]
		Alignment,
		[Field ("UIMenuToolbar")]
		Toolbar,
		//[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Field ("UIMenuSidebar")]
		Sidebar,
		[Field ("UIMenuFullscreen")]
		Fullscreen,
		[Field ("UIMenuMinimizeAndZoom")]
		MinimizeAndZoom,
		[Field ("UIMenuBringAllToFront")]
		BringAllToFront,
		[Field ("UIMenuRoot")]
		Root,

		//[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("UIMenuOpenRecent")]
		OpenRecent,

		//[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Field ("UIMenuDocument")]
		Document,

		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("UIMenuAutoFill")]
		AutoFill,
		//[TV (18, 1), iOS (18, 1), MacCatalyst (18, 1)]
		[Field ("UIMenuOpen")]
		Open,
	}
    */
    //[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
    [Native]
    public enum UIMenuElementSize : long {
        Small = 0,
        Medium,
        Large,
        //[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
        Automatic = -1,
    }
    
    //[TV (17, 4), iOS (17, 4), MacCatalyst (17, 4)]
    [BaseType (typeof (NSObject))]
    public class UIMenuDisplayPreferences : NSCopying {

        [Export ("maximumNumberOfTitleLines")]
        public extern nint MaximumNumberOfTitleLines { get; set; }
    }
    /*
    [Flags]
    //[iOS (13, 0), TV (13, 0)]
    [MacCatalyst (13, 1)]
    [Native]
    public enum UIMenuOptions : ulong {
        DisplayInline = 1uL << 0,
        Destructive = 1uL << 1,
        //[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
        SingleSelection = 1uL << 5,
        //[iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
        DisplayAsPalette = 1uL << 7,
    }
    */
    //[iOS (13, 0), TV (13, 0)]
    [MacCatalyst (13, 1)]
    [BaseType (typeof (UIMenuElement))]
    [DisableDefaultCtor]
    public class UIMenu {

        //[BindAs (typeof (UIMenuIdentifier))]
        [Export ("identifier")]
        NSString Identifier { get; }

        [Export ("options")]
        public extern UIMenuOptions Options { get; }

       // [iOS (15, 0), MacCatalyst (15, 0), TV (15, 0)]
        [Export ("selectedElements")]
#if XAMCORE_5_0
		public extern UIMenuElement [] SelectedElements { get; }
#else
        [Internal]
        internal extern UIMenuElement [] _SelectedElements { get; }
#endif

        //[iOS (17, 4), MacCatalyst (17, 4), TV (17, 4)]
        [NullAllowed]
        [Export ("displayPreferences", ArgumentSemantic.Copy)]
        public extern UIMenuDisplayPreferences DisplayPreferences { get; set; }

        [Export ("children")]
        internal extern UIMenuElement [] Children { get; }

        //[TV (14, 0), iOS (14, 0)]
        [MacCatalyst (14, 0)]
        [Static]
        [Export ("menuWithChildren:")]
        public static extern UIMenu Create (UIMenuElement [] children);

        [Static]
        [Export ("menuWithTitle:children:")]
        public static extern UIMenu Create (string title, UIMenuElement [] children);

        [Static]
        [Export ("menuWithTitle:image:identifier:options:children:")]
        public static extern UIMenu Create (string title, [NullAllowed] UIImage image, [NullAllowed][BindAs (typeof (UIMenuIdentifier))] NSString identifier, UIMenuOptions options, UIMenuElement [] children);

        [Export ("menuByReplacingChildren:")]
        public extern UIMenu GetMenuByReplacingChildren (UIMenuElement [] newChildren);

        //[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
        [Export ("preferredElementSize", ArgumentSemantic.Assign)]
        public extern UIMenuElementSize PreferredElementSize { get; set; }
    }

    //[iOS (13, 0), TV (13, 0)]
    [MacCatalyst (13, 1)]
    [BaseType (typeof (NSObject))]
    [DisableDefaultCtor]
    public class UIMenuElement : NSCopying, IUIAccessibilityIdentification {

        [Export ("title")]
        public extern string Title { get; }

        //[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
        [NullAllowed, Export ("subtitle")]
        public extern string Subtitle { get; set; }

        [NullAllowed, Export ("image")]
        public extern UIImage Image { get; }
    }
    
}