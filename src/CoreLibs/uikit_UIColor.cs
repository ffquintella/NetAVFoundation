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

#if !NET
using NativeHandle = System.IntPtr;
#endif

#nullable enable
using CoreLibs;
using UIEdgeInsets=System.Object;
#endregion

namespace UIKit
{
	[Native]
	//[TV (18, 0), NoMac, iOS (18, 0), MacCatalyst (18, 0)]
	public enum UIColorProminence : long {
		Primary,
		Secondary,
		Tertiary,
		Quaternary,
	}

	
	[BaseType (typeof (NSObject))]
	[ThreadSafe]
	// returns NIL handle causing exceptions in further calls, e.g. ToString
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -CGColor not defined for the UIColor <UIPlaceholderColor: 0x114f5ad0>; need to first convert colorspace.
	[DisableDefaultCtor]
	public class UIColor : NSCopying
#if !TVOS
		//, NSItemProviderWriting, NSItemProviderReading
#endif
	{
		[Export ("colorWithWhite:alpha:")]
		[Static]
		public static extern UIColor FromWhiteAlpha (nfloat white, nfloat alpha);

		[Export ("colorWithHue:saturation:brightness:alpha:")]
		[Static]
		public static extern UIColor FromHSBA (nfloat hue, nfloat saturation, nfloat brightness, nfloat alpha);

		[Export ("colorWithRed:green:blue:alpha:")]
		[Static]
		public static extern UIColor FromRGBA (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Export ("colorWithCGColor:")]
		[Static]
		public static extern UIColor FromCGColor (CGColor color);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("colorNamed:")]
		[return: NullAllowed]
		public static extern UIColor? FromName (string name);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("colorNamed:inBundle:compatibleWithTraitCollection:")]
		[return: NullAllowed]
		public static extern UIColor? FromName (string name, [NullAllowed] NSBundle inBundle, [NullAllowed] UITraitCollection compatibleWithTraitCollection);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("colorWithDisplayP3Red:green:blue:alpha:")]
		public static extern UIColor FromDisplayP3 (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Export ("colorWithPatternImage:")]
		[Static]
		public static extern UIColor FromPatternImage (UIImage image);

		[Export ("initWithRed:green:blue:alpha:")]
		public extern NativeHandle Constructor (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Export ("initWithPatternImage:")]
		public extern NativeHandle Constructor (UIImage patternImage);

		[Export ("initWithWhite:alpha:")]
		public extern NativeHandle Constructor (nfloat white, nfloat alpha);

		// [Export ("initWithHue:saturation:brightness:alpha:")]
		// NativeHandle Constructor (nfloat red, nfloat green, nfloat blue, nfloat alpha);
		// 
		// This method is not bound as a constructor because the binding already has a constructor that
		// takes 4 doubles (RGBA constructor) meaning that we would need to use an enum to diff between them making the API
		// uglier when it is not needed. The developer can use colorWithHue:saturation:brightness:alpha:
		// instead.

		[Export ("initWithCGColor:")]
		public extern NativeHandle Constructor (CGColor color);

		[Static]
		[Export ("clearColor")]
		public static extern UIColor Clear { get; }

		[Static]
		[Export ("blackColor")]
		UIColor Black { get; }

		[Static]
		[Export ("darkGrayColor")]
		public static extern UIColor DarkGray { get; }

		[Static]
		[Export ("lightGrayColor")]
		public static extern UIColor LightGray { get; }

		[Static]
		[Export ("whiteColor")]
		public static extern UIColor White { get; }

		[Static]
		[Export ("grayColor")]
		public static extern UIColor Gray { get; }

		[Static]
		[Export ("redColor")]
		public static extern UIColor Red { get; }

		[Static]
		[Export ("greenColor")]
		public static extern UIColor Green { get; }

		[Static]
		[Export ("blueColor")]
		public static extern UIColor Blue { get; }

		[Static]
		[Export ("cyanColor")]
		public static extern UIColor Cyan { get; }

		[Static]
		[Export ("yellowColor")]
		public static extern UIColor Yellow { get; }

		[Static]
		[Export ("magentaColor")]
		public static extern UIColor Magenta { get; }

		[Static]
		[Export ("orangeColor")]
		public static extern UIColor Orange { get; }

		[Static]
		[Export ("purpleColor")]
		public static extern UIColor Purple { get; }

		[Static]
		[Export ("brownColor")]
		public static extern UIColor Brown { get; }

		[Export ("set")]
		public extern void SetColor ();

		[Export ("setFill")]
		public extern void SetFill ();

		[Export ("setStroke")]
		public extern void SetStroke ();

		[Export ("colorWithAlphaComponent:")]
		public extern UIColor ColorWithAlpha (nfloat alpha);

		[Export ("CGColor")]
		public extern CGColor CGColor { get; }

		[MacCatalyst (13, 1)]
		[Export ("CIColor")]
		public extern CIColor CIColor { get; }

#if !NET
		[Obsolete ("Use 'LightText' instead.")]
		[NoTV]
		[Export ("lightTextColor")]
		[Static]
		UIColor LightTextColor { get; }
#endif

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("lightTextColor")]
		[Static]
		public static extern UIColor LightText { get; }

#if !NET
		[Obsolete ("Use 'DarkText' instead.")]
		[NoTV]
		[Export ("darkTextColor")]
		[Static]
		public static extern UIColor DarkTextColor { get; }
#endif

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("darkTextColor")]
		[Static]
		public static extern UIColor DarkText { get; }

#if !NET
		[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'SystemGroupedBackground' instead.")]
		[NoTV]
		[Export ("groupTableViewBackgroundColor")]
		[Static]
		public static extern UIColor GroupTableViewBackgroundColor { get; }
#endif

		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'SystemGroupedBackground' instead.")]
		[NoTV]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'SystemGroupedBackground' instead.")]
		[Export ("groupTableViewBackgroundColor")]
		[Static]
		public static extern UIColor GroupTableViewBackground { get; }

#if !NET
		[Obsolete ("Use 'ViewFlipsideBackground' instead.")]
		[Deprecated (PlatformName.iOS, 7, 0)]
		[NoTV]
		[Export ("viewFlipsideBackgroundColor")]
		[Static]
		public static extern UIColor ViewFlipsideBackgroundColor { get; }
#endif

		//[Deprecated (PlatformName.iOS, 7, 0)]
		[NoTV]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("viewFlipsideBackgroundColor")]
		[Static]
		public static extern UIColor ViewFlipsideBackground { get; }

#if !NET
		[Obsolete ("Use 'ScrollViewTexturedBackground' instead.")]
		[Deprecated (PlatformName.iOS, 7, 0)]
		[NoTV]
		[Export ("scrollViewTexturedBackgroundColor")]
		[Static]
		public static extern UIColor ScrollViewTexturedBackgroundColor { get; }
#endif

		//[Deprecated (PlatformName.iOS, 7, 0)]
		[NoTV]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("scrollViewTexturedBackgroundColor")]
		[Static]
		public static extern UIColor ScrollViewTexturedBackground { get; }

#if !NET
		[Obsolete ("Use 'UnderPageBackground' instead.")]
		[Deprecated (PlatformName.iOS, 7, 0)]
		[NoTV]
		[Static, Export ("underPageBackgroundColor")]
		public static extern UIColor UnderPageBackgroundColor { get; }
#endif

		//[Deprecated (PlatformName.iOS, 7, 0)]
		[NoTV]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Static, Export ("underPageBackgroundColor")]
		public static extern UIColor UnderPageBackground { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("colorWithCIColor:")]
		public static extern UIColor FromCIColor (CIColor color);

		[MacCatalyst (13, 1)]
		[Export ("initWithCIColor:")]
		public extern NativeHandle Constructor (CIColor ciColor);

		[Export ("getWhite:alpha:")]
		public extern bool GetWhite (out nfloat white, out nfloat alpha);

#if false
		// for testing the managed implementations
		[Export ("getHue:saturation:brightness:alpha:")]
		public extern bool GetHSBA (out nfloat hue, out nfloat saturation, out nfloat brightness, out nfloat alpha);
		
		[Export ("getRed:green:blue:alpha:")]
		public extern bool GetRGBA2 (out nfloat red, out nfloat green, out nfloat blue, out nfloat alpha);
#endif

		// From the NSItemProviderReading protocol, a static method.
		[Static]
		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("readableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
#if !TVOS
		new
#endif
		public static extern string [] ReadableTypeIdentifiers { get; }

		// From the NSItemProviderReading protocol, a static method.
		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("objectWithItemProviderData:typeIdentifier:error:")]
		[return: NullAllowed]
#if !TVOS
		new
#endif
			public static extern UIColor GetObject (NSData data, string typeIdentifier, [NullAllowed] out NSError outError);

		// From the NSItemProviderWriting protocol, a static method.
		// NSItemProviderWriting doesn't seem to be implemented for tvOS/watchOS, even though the headers say otherwise.
		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("writableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
#if !TVOS
		new
#endif
			public static extern string [] WritableTypeIdentifiers { get; }

		// From UIColor (DynamicColors)

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("colorWithDynamicProvider:")]
		public static extern UIColor FromDynamicProvider (Func<UITraitCollection, UIColor> dynamicProvider);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("initWithDynamicProvider:")]
		public extern NativeHandle Constructor (Func<UITraitCollection, UIColor> dynamicProvider);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("resolvedColorWithTraitCollection:")]
		public extern UIColor GetResolvedColor (UITraitCollection traitCollection);

		// From: UIColor (UIColorSystemColors)
		// this probably needs bindings to be moved into from appkit.cs to xkit.cs
		// and adjust accordingly since a lot of those are static properties
		// that cannot be exposed from a [Category]

#if !NET
		[Obsolete ("Use 'SystemRed' instead.")]
		[Static]
		[Export ("systemRedColor")]
		public static extern UIColor SystemRedColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemRedColor")]
		public static extern UIColor SystemRed { get; }

#if !NET
		[Obsolete ("Use 'SystemGreen' instead.")]
		[Static]
		[Export ("systemGreenColor")]
		public static extern UIColor SystemGreenColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGreenColor")]
		public static extern UIColor SystemGreen { get; }

#if !NET
		[Obsolete ("Use 'SystemBlue' instead.")]
		[Static]
		[Export ("systemBlueColor")]
		public static extern UIColor SystemBlueColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemBlueColor")]
		public static extern UIColor SystemBlue { get; }

#if !NET
		[Obsolete ("Use 'SystemOrange' instead.")]
		[Static]
		[Export ("systemOrangeColor")]
		public static extern UIColor SystemOrangeColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemOrangeColor")]
		public static extern UIColor SystemOrange { get; }

#if !NET
		[Obsolete ("Use 'SystemYellow' instead.")]
		[Static]
		[Export ("systemYellowColor")]
		UIColor SystemYellowColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemYellowColor")]
		public static extern UIColor SystemYellow { get; }

#if !NET
		[Obsolete ("Use 'SystemPink' instead.")]
		[Static]
		[Export ("systemPinkColor")]
		public static extern UIColor SystemPinkColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemPinkColor")]
		public static extern UIColor SystemPink { get; }

#if !NET
		[Obsolete ("Use 'SystemPurple' instead.")]
		[Static]
		[Export ("systemPurpleColor")]
		public static extern UIColor SystemPurpleColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemPurpleColor")]
		public static extern UIColor SystemPurple { get; }

#if !NET
		[Obsolete ("Use 'SystemTeal' instead.")]
		[Static]
		[Export ("systemTealColor")]
		public static extern UIColor SystemTealColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemTealColor")]
		public static extern UIColor SystemTeal { get; }

#if !NET
		[Obsolete ("Use 'SystemIndigo' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("systemIndigoColor")]
		public static extern UIColor SystemIndigoColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemIndigoColor")]
		public static extern UIColor SystemIndigo { get; }

#if !NET
		[Obsolete ("Use 'SystemBrown' instead.")]
		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("systemBrownColor")]
		public static extern UIColor SystemBrownColor { get; }
#endif

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("systemBrownColor")]
		public static extern UIColor SystemBrown { get; }

#if !NET
		[Obsolete ("Use 'SystemMint' instead.")]
		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("systemMintColor")]
		public static extern UIColor SystemMintColor { get; }
#endif

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("systemMintColor")]
		public static extern UIColor SystemMint { get; }

#if !NET
		[Obsolete ("Use 'SystemCyan' instead.")]
		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("systemCyanColor")]
		public static extern UIColor SystemCyanColor { get; }
#endif

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("systemCyanColor")]
		public static extern UIColor SystemCyan { get; }

#if !NET
		[Obsolete ("Use 'SystemGray' instead.")]
		[Static]
		[Export ("systemGrayColor")]
		public static extern UIColor SystemGrayColor { get; }
#endif

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGrayColor")]
		public static extern UIColor SystemGray { get; }

#if !NET
		[Obsolete ("Use 'SystemGray2' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemGray2Color")]
		public static extern UIColor SystemGray2Color { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGray2Color")]
		public static extern UIColor SystemGray2 { get; }

#if !NET
		[Obsolete ("Use 'SystemGray3' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemGray3Color")]
		public static extern UIColor SystemGray3Color { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGray3Color")]
		public static extern UIColor SystemGray3 { get; }

#if !NET
		[Obsolete ("Use 'SystemGray4' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemGray4Color")]
		public static extern UIColor SystemGray4Color { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGray4Color")]
		public static extern UIColor SystemGray4 { get; }

#if !NET
		[Obsolete ("Use 'SystemGray5' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemGray5Color")]
		public static extern UIColor SystemGray5Color { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGray5Color")]
		public static extern UIColor SystemGray5 { get; }

#if !NET
		[Obsolete ("Use 'SystemGray6' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemGray6Color")]
		public static extern UIColor SystemGray6Color { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGray6Color")]
		public static extern UIColor SystemGray6 { get; }

#if !NET
		[Obsolete ("Use 'Tint' instead.")]
		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("tintColor")]
		public static extern UIColor TintColor { get; }
#endif

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("tintColor")]
		public static extern UIColor Tint { get; }

#if !NET
		[Obsolete ("Use 'Label' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("labelColor")]
		public static extern UIColor LabelColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("labelColor")]
		public static extern UIColor Label { get; }

#if !NET
		[Obsolete ("Use 'SecondaryLabel' instead.")]
		//[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("secondaryLabelColor")]
		public static extern UIColor SecondaryLabelColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("secondaryLabelColor")]
		public static extern UIColor SecondaryLabel { get; }

#if !NET
		[Obsolete ("Use 'TertiaryLabel' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("tertiaryLabelColor")]
		public static extern UIColor TertiaryLabelColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("tertiaryLabelColor")]
		public static extern UIColor TertiaryLabel { get; }

#if !NET
		[Obsolete ("Use 'QuaternaryLabel' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("quaternaryLabelColor")]
		public static extern UIColor QuaternaryLabelColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("quaternaryLabelColor")]
		public static extern UIColor QuaternaryLabel { get; }

#if !NET
		[Obsolete ("Use 'Link' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("linkColor")]
		public static extern UIColor LinkColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("linkColor")]
		public static extern UIColor Link { get; }

#if !NET
		[Obsolete ("Use 'PlaceholderText' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("placeholderTextColor")]
		public static extern UIColor PlaceholderTextColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("placeholderTextColor")]
		public static extern UIColor PlaceholderText { get; }

#if !NET
		[Obsolete ("Use 'Separator' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("separatorColor")]
		UIColor SeparatorColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("separatorColor")]
		public static extern UIColor Separator { get; }

#if !NET
		[Obsolete ("Use 'OpaqueSeparator' instead.")]
		[TV (13, 0), iOS (13, 0)]
		[Static]
		[Export ("opaqueSeparatorColor")]
		public static extern UIColor OpaqueSeparatorColor { get; }
#endif

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("opaqueSeparatorColor")]
		public static extern UIColor OpaqueSeparator { get; }

#if !NET
		[Obsolete ("Use 'SystemBackground' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemBackgroundColor")]
		public static extern UIColor SystemBackgroundColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemBackgroundColor")]
		public static extern UIColor SystemBackground { get; }

#if !NET
		[Obsolete ("Use 'SecondarySystemBackground' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("secondarySystemBackgroundColor")]
		public static extern UIColor SecondarySystemBackgroundColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("secondarySystemBackgroundColor")]
		public static extern UIColor SecondarySystemBackground { get; }

#if !NET
		[Obsolete ("Use 'TertiarySystemBackground' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("tertiarySystemBackgroundColor")]
		public static extern UIColor TertiarySystemBackgroundColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("tertiarySystemBackgroundColor")]
		public static extern UIColor TertiarySystemBackground { get; }

#if !NET
		//[Obsolete ("Use 'SystemGroupedBackground' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemGroupedBackgroundColor")]
		public static extern UIColor SystemGroupedBackgroundColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemGroupedBackgroundColor")]
		public static extern UIColor SystemGroupedBackground { get; }

#if !NET
		[Obsolete ("Use 'SecondarySystemGroupedBackground' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("secondarySystemGroupedBackgroundColor")]
		public static extern UIColor SecondarySystemGroupedBackgroundColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("secondarySystemGroupedBackgroundColor")]
		public static extern UIColor SecondarySystemGroupedBackground { get; }

#if !NET
		[Obsolete ("Use 'TertiarySystemGroupedBackground' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("tertiarySystemGroupedBackgroundColor")]
		public static extern UIColor TertiarySystemGroupedBackgroundColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("tertiarySystemGroupedBackgroundColor")]
		public static extern UIColor TertiarySystemGroupedBackground { get; }

#if !NET
		[Obsolete ("Use 'SystemFill' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("systemFillColor")]
		public static extern UIColor SystemFillColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemFillColor")]
		public static extern UIColor SystemFill { get; }

#if !NET
		[Obsolete ("Use 'SecondarySystemFill' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("secondarySystemFillColor")]
		public static extern UIColor SecondarySystemFillColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("secondarySystemFillColor")]
		public static extern UIColor SecondarySystemFill { get; }

#if !NET
		[Obsolete ("Use 'TertiarySystemFill' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("tertiarySystemFillColor")]
		public static extern UIColor TertiarySystemFillColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("tertiarySystemFillColor")]
		public static extern UIColor TertiarySystemFill { get; }

#if !NET
		[Obsolete ("Use 'QuaternarySystemFill' instead.")]
		[NoTV, iOS (13, 0)]
		[Static]
		[Export ("quaternarySystemFillColor")]
		public static extern UIColor QuaternarySystemFillColor { get; }
#endif

		//[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("quaternarySystemFillColor")]
		public static extern UIColor QuaternarySystemFill { get; }

		// UIColor (UIAccessibility) Category

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("accessibilityName")]
		public static extern string AccessibilityName { get; }

		// Inlined from the ProminenceSupport category
		//[TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("colorWithProminence:")]
		public static extern UIColor ApplyProminence (UIColorProminence prominence);

		// Inlined from the ProminenceSupport category
		//[TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("prominence")]
		public static extern UIColorProminence Prominence { get; }
	}
	
	public interface IUIColorPickerViewControllerDelegate { }

	[MacCatalyst (13, 1)]
	[BaseType (typeof (UIDynamicBehavior),
		   Delegates = new string [] { "CollisionDelegate" },
		   Events = new Type [] { typeof (UICollisionBehaviorDelegate) })]
	public class UICollisionBehavior {
		[DesignatedInitializer]
		[Export ("initWithItems:")]
		public  extern NativeHandle Constructor ([Params] IUIDynamicItem [] items);

		[Export ("items", ArgumentSemantic.Copy)]
		public  extern IUIDynamicItem [] Items { get; }

		[Export ("collisionMode")]
		public  extern UICollisionBehaviorMode CollisionMode { get; set; }

		[Export ("translatesReferenceBoundsIntoBoundary")]
		public  extern bool TranslatesReferenceBoundsIntoBoundary { get; set; }

		[Export ("boundaryIdentifiers", ArgumentSemantic.Copy)]
		public  extern NSObject [] BoundaryIdentifiers { get; }

		[Export ("collisionDelegate", ArgumentSemantic.Assign), NullAllowed]
		public  extern NSObject WeakCollisionDelegate { get; set; }

		[Wrap ("WeakCollisionDelegate")]
		public  extern IUICollisionBehaviorDelegate CollisionDelegate { get; set; }

		[Export ("addItem:")]
		public  extern void AddItem (IUIDynamicItem dynamicItem);

		[Export ("removeItem:")]
		public  extern void RemoveItem (IUIDynamicItem dynamicItem);

		[Export ("setTranslatesReferenceBoundsIntoBoundaryWithInsets:")]
		public  extern void SetTranslatesReferenceBoundsIntoBoundaryWithInsets (UIEdgeInsets insets);

		[Export ("addBoundaryWithIdentifier:forPath:")]
		[PostGet ("BoundaryIdentifiers")]
		public  extern void AddBoundary (NSObject boundaryIdentifier, UIBezierPath bezierPath);

		[Export ("addBoundaryWithIdentifier:fromPoint:toPoint:")]
		[PostGet ("BoundaryIdentifiers")]
		public  extern void AddBoundary (NSObject boundaryIdentifier, CGPoint fromPoint, CGPoint toPoint);

		[Export ("boundaryWithIdentifier:")]
		public  extern UIBezierPath GetBoundary (NSObject boundaryIdentifier);

		[Export ("removeBoundaryWithIdentifier:")]
		public  extern void RemoveBoundary (NSObject boundaryIdentifier);

		[Export ("removeAllBoundaries")]
		public  extern void RemoveAllBoundaries ();
	}
}