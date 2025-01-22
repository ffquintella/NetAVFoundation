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
using UICollectionLayoutListConfiguration=System.Object;
using UIContentInsetsReference=System.Object;
using UIEdgeInsets=System.Object;
using UITraitCollection=System.Object;

#if !NET
using NativeHandle = System.IntPtr;
#endif

#nullable enable

#endregion

namespace UIKit
{

	[MacCatalyst (13, 1)]
	[Native]
	public enum UIImageSymbolWeight : long {
		Unspecified = 0,
		UltraLight = 1,
		Thin,
		Light,
		Regular,
		Medium,
		Semibold,
		Bold,
		Heavy,
		Black,
	}
	
	
	//[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum UIImageSymbolScale : long {
		Default = -1,
		Unspecified = 0,
		Small = 1,
		Medium,
		Large,
	}
	
	public enum UIImageResizingMode : long {
		Tile, Stretch
	}
	
	// NSInteger -> UIImage.h
	[Native]
	public enum UIImageOrientation : long {
		Up,
		Down,
		Left,
		Right,
		UpMirrored,
		DownMirrored,
		LeftMirrored,
		RightMirrored,
	}
	
	// NSInteger -> UIImage.h
	[Native]
	public enum UIImageRenderingMode : long {
		Automatic,
		AlwaysOriginal,
		AlwaysTemplate
	}
	
	[MacCatalyst (13, 1)]
	[Native]
	public enum UIGraphicsImageRendererFormatRange : long {
		Unspecified = -1,
		Automatic = 0,
		Extended,
		Standard,
	}
	
	public enum UIFontTextStyle {
		[Field ("UIFontTextStyleHeadline")]
		Headline,

		[Field ("UIFontTextStyleBody")]
		Body,

		[Field ("UIFontTextStyleSubheadline")]
		Subheadline,

		[Field ("UIFontTextStyleFootnote")]
		Footnote,

		[Field ("UIFontTextStyleCaption1")]
		Caption1,

		[Field ("UIFontTextStyleCaption2")]
		Caption2,

		[MacCatalyst (13, 1)]
		[Field ("UIFontTextStyleTitle1")]
		Title1,

		[MacCatalyst (13, 1)]
		[Field ("UIFontTextStyleTitle2")]
		Title2,

		[MacCatalyst (13, 1)]
		[Field ("UIFontTextStyleTitle3")]
		Title3,

		[MacCatalyst (13, 1)]
		[Field ("UIFontTextStyleCallout")]
		Callout,

		[NoTV]
		[MacCatalyst (13, 1)]
		[Field ("UIFontTextStyleLargeTitle")]
		LargeTitle,

		//[iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Field ("UIFontTextStyleExtraLargeTitle")]
		ExtraLargeTitle,

		//[iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Field ("UIFontTextStyleExtraLargeTitle2")]
		ExtraLargeTitle2,
	}
	
	public interface IUIDynamicAnimatorDelegate { }
	
	
	[BaseType (typeof (NSObject))]
	[ThreadSafe]
	[DisableDefaultCtor] // iOS7 -> Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: -[UIFont ctFontRef]: unrecognized selector sent to instance 0x15b283c0
						 // note: because of bug 25511 (managed Dispose / native semi-factory) we need to return a copy of the UIFont for every static method that returns an UIFont
	public class UIFont : NSCopying {
		[Static]
		[Export ("systemFontOfSize:")]
		[Internal] // bug 25511
		public static extern IntPtr _SystemFontOfSize (nfloat size);

		[MacCatalyst (13, 1)]
		[EditorBrowsable (EditorBrowsableState.Advanced)] // we prefer to show the one using the enum
		[Internal] // bug 25511
		[Static]
		[Export ("systemFontOfSize:weight:")]
		public static extern IntPtr _SystemFontOfSize (nfloat size, nfloat weight);

		[MacCatalyst (13, 1)]
		[EditorBrowsable (EditorBrowsableState.Advanced)] // we prefer to show the one using the enum
		[Internal] // bug 25511
		[Static]
		[Export ("monospacedDigitSystemFontOfSize:weight:")]
		public static extern IntPtr _MonospacedDigitSystemFontOfSize (nfloat fontSize, nfloat weight);

		[Static]
		[Export ("boldSystemFontOfSize:")]
		[Internal] // bug 25511
		public static extern IntPtr _BoldSystemFontOfSize (nfloat size);

		[Static]
		[Export ("italicSystemFontOfSize:")]
		[Internal] // bug 25511
		public static extern IntPtr _ItalicSystemFontOfSize (nfloat size);

		[Static]
		[Export ("fontWithName:size:")]
		[Internal] // bug 25511
		public static extern IntPtr _FromName (string name, nfloat size);

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Internal] // bug https://xamarin.github.io/bugzilla-archives/25/25511/bug.html
		[Export ("monospacedSystemFontOfSize:weight:")]
		public static extern IntPtr _MonospacedSystemFontOfSize (nfloat fontSize, nfloat weight);

		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("labelFontSize")]
		public static extern nfloat LabelFontSize { get; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("buttonFontSize")]
		public static extern nfloat ButtonFontSize { get; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("smallSystemFontSize")]
		public static extern nfloat SmallSystemFontSize { get; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemFontSize")]
		public static extern nfloat SystemFontSize { get; }

		[Export ("fontWithSize:")]
		[Internal] // bug 25511
		public extern IntPtr _WithSize (nfloat size);

		[Export ("familyName", ArgumentSemantic.Retain)]
		public extern string FamilyName { get; }

		[Export ("fontName", ArgumentSemantic.Retain)]
		public extern string Name { get; }

		[Export ("pointSize")]
		public extern nfloat PointSize { get; }

		[Export ("ascender")]
		public extern nfloat Ascender { get; }

		[Export ("descender")]
		public extern nfloat Descender { get; }

		[Export ("leading")]
		public extern nfloat Leading { get; }

		[Export ("capHeight")]
		public extern nfloat CapHeight { get; }

		[Export ("xHeight")]
		public extern nfloat XHeight { get; }

#if !XAMCORE_5_0
		[Obsolete ("Use the 'XHeight' property instead.")]
		[Wrap ("XHeight", IsVirtual = true)]
		public extern nfloat xHeight { get; }
#endif

		[Export ("lineHeight")]
		public extern nfloat LineHeight { get; }

		[Static]
		[Export ("familyNames")]
		public static extern string [] FamilyNames { get; }

		[Static]
		[Export ("fontNamesForFamilyName:")]
		public static extern string [] FontNamesForFamilyName (string familyName);

		[Export ("fontDescriptor")]
		public extern UIFontDescriptor FontDescriptor { get; }

		[Static, Export ("fontWithDescriptor:size:")]
		[Internal] // bug 25511
		public extern IntPtr _FromDescriptor (UIFontDescriptor descriptor, nfloat pointSize);

		[Static, Export ("preferredFontForTextStyle:")]
		[Internal] // bug 25511
		public extern IntPtr _GetPreferredFontForTextStyle (NSString uiFontTextStyle);

		// FIXME the API is present but UITraitCollection is not exposed / rdar 27785753
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("preferredFontForTextStyle:compatibleWithTraitCollection:")]
		[Internal]
		public extern IntPtr _GetPreferredFontForTextStyle (NSString uiFontTextStyle, [NullAllowed] UITraitCollection traitCollection);

		//[iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Static]
		[Internal]
		[Export ("systemFontOfSize:weight:width:")]
		public extern IntPtr _SystemFontOfSize (nfloat fontSize, nfloat weight, nfloat width);

	} 
	
	// uint32_t -> UIFontDescriptor.h
	[Flags]
	public enum UIFontDescriptorSymbolicTraits : uint {
		Italic = 1 << 0,
		Bold = 1 << 1,
		Expanded = 1 << 5,
		Condensed = 1 << 6,
		MonoSpace = 1 << 10,
		Vertical = 1 << 11,
		UIOptimized = 1 << 12,
		TightLeading = 1 << 15,
		LooseLeading = 1 << 16,

		ClassMask = 0xF0000000,

		ClassUnknown = 0,
		ClassOldStyleSerifs = 1 << 28,
		ClassTransitionalSerifs = 2 << 28,
		ClassModernSerifs = 3 << 28,
		ClassClarendonSerifs = 4 << 28,
		ClassSlabSerifs = 5 << 28,
		ClassFreeformSerifs = 7 << 28,
		ClassSansSerif = 8U << 28,
		ClassOrnamentals = 9U << 28,
		ClassScripts = 10U << 28,
		ClassSymbolic = 12U << 28
	}	
	
	//[iOS (13, 0), TV (13, 0)]
	[MacCatalyst (13, 1)]
	/* NS_TYPED_ENUM */
	public enum UIFontDescriptorSystemDesign {
		//[DefaultEnumValue]
		[Field ("UIFontDescriptorSystemDesignDefault")]
		Default,
		[Field ("UIFontDescriptorSystemDesignRounded")]
		Rounded,
		[MacCatalyst (13, 1)]
		[Field ("UIFontDescriptorSystemDesignSerif")]
		Serif,
		[MacCatalyst (13, 1)]
		[Field ("UIFontDescriptorSystemDesignMonospaced")]
		Monospaced,
	}
						 
	[BaseType (typeof (NSObject))]
	[ThreadSafe]
	public partial class UIFontDescriptor : NSCopying {

		[Export ("postscriptName")]
		public extern string PostscriptName { get; }

		[Export ("pointSize")]
		public extern nfloat PointSize { get; }

		[Export ("matrix")]
		public extern CGAffineTransform Matrix { get; }

		[Export ("symbolicTraits")]
		public extern UIFontDescriptorSymbolicTraits SymbolicTraits { get; }

		[Export ("objectForKey:")]
		public extern NSObject GetObject (NSString anAttribute);

		[Export ("fontAttributes")]
		public extern NSDictionary WeakFontAttributes { get; }

		[Wrap ("WeakFontAttributes")]
		public extern UIFontAttributes FontAttributes { get; }

		[Export ("matchingFontDescriptorsWithMandatoryKeys:")]
		public extern UIFontDescriptor [] GetMatchingFontDescriptors ([NullAllowed] NSSet mandatoryKeys);

		[Static, Export ("fontDescriptorWithFontAttributes:")]
		public static extern UIFontDescriptor FromAttributes (NSDictionary attributes);

		[Static, Wrap ("FromAttributes (attributes.GetDictionary ()!)")]
		public static extern UIFontDescriptor FromAttributes (UIFontAttributes attributes);

		[Static, Export ("fontDescriptorWithName:size:")]
		public static extern UIFontDescriptor FromName (string fontName, nfloat size);

		[Static, Export ("fontDescriptorWithName:matrix:")]
		public static extern UIFontDescriptor FromName (string fontName, CGAffineTransform matrix);

		[Static, Export ("preferredFontDescriptorWithTextStyle:")]
		public static extern UIFontDescriptor GetPreferredDescriptorForTextStyle (NSString uiFontTextStyle);

		[Static]
		[Wrap ("GetPreferredDescriptorForTextStyle (uiFontTextStyle.GetConstant ()!)")]
		public static extern UIFontDescriptor GetPreferredDescriptorForTextStyle (UIFontTextStyle uiFontTextStyle);

		// FIXME the API is present but UITraitCollection is not exposed / rdar #27785753
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("preferredFontDescriptorWithTextStyle:compatibleWithTraitCollection:")]
		public static extern UIFontDescriptor GetPreferredDescriptorForTextStyle (NSString uiFontTextStyle, [NullAllowed] UITraitCollection traitCollection);

		[MacCatalyst (13, 1)]
		[Static]
		[Wrap ("GetPreferredDescriptorForTextStyle (uiFontTextStyle.GetConstant ()!, traitCollection)")]
		public static extern UIFontDescriptor GetPreferredDescriptorForTextStyle (UIFontTextStyle uiFontTextStyle, [NullAllowed] UITraitCollection traitCollection);

		[DesignatedInitializer]
		[Export ("initWithFontAttributes:")]
		public extern NativeHandle Constructor (NSDictionary attributes);

		[DesignatedInitializer]
		[Wrap ("this (attributes.GetDictionary ()!)")]
		public extern NativeHandle Constructor (UIFontAttributes attributes);

		[Export ("fontDescriptorByAddingAttributes:")]
		public extern UIFontDescriptor CreateWithAttributes (NSDictionary attributes);

		[Wrap ("CreateWithAttributes (attributes.GetDictionary ()!)")]
		public extern UIFontDescriptor CreateWithAttributes (UIFontAttributes attributes);

		[Export ("fontDescriptorWithSymbolicTraits:")]
		public extern UIFontDescriptor CreateWithTraits (UIFontDescriptorSymbolicTraits symbolicTraits);

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("fontDescriptorWithDesign:")]
		[return: NullAllowed]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		public extern UIFontDescriptor CreateWithDesign (NSString design);

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[return: NullAllowed]
		[Wrap ("CreateWithDesign (design.GetConstant ()!)")]
		public extern UIFontDescriptor CreateWithDesign (UIFontDescriptorSystemDesign design);

		[Export ("fontDescriptorWithSize:")]
		public extern UIFontDescriptor CreateWithSize (nfloat newPointSize);

		[Export ("fontDescriptorWithMatrix:")]
		public extern UIFontDescriptor CreateWithMatrix (CGAffineTransform matrix);

		[Export ("fontDescriptorWithFace:")]
		public extern UIFontDescriptor CreateWithFace (string newFace);

		[Export ("fontDescriptorWithFamily:")]
		public extern UIFontDescriptor CreateWithFamily (string newFamily);


		//
		// Internal fields
		//
		[Internal, Field ("UIFontDescriptorFamilyAttribute")]
		internal static extern NSString FamilyAttribute { get; }

		[Internal, Field ("UIFontDescriptorNameAttribute")]
		internal static extern NSString NameAttribute { get; }

		[Internal, Field ("UIFontDescriptorFaceAttribute")]
		internal static extern NSString FaceAttribute { get; }

		[Internal, Field ("UIFontDescriptorSizeAttribute")]
		internal static extern NSString SizeAttribute { get; }

		[Internal, Field ("UIFontDescriptorVisibleNameAttribute")]
		internal static extern NSString VisibleNameAttribute { get; }

		[Internal, Field ("UIFontDescriptorMatrixAttribute")]
		internal static extern NSString MatrixAttribute { get; }

		[Internal, Field ("UIFontDescriptorCharacterSetAttribute")]
		internal static extern NSString CharacterSetAttribute { get; }

		[Internal, Field ("UIFontDescriptorCascadeListAttribute")]
		internal static extern NSString CascadeListAttribute { get; }

		[Internal, Field ("UIFontDescriptorTraitsAttribute")]
		internal static extern NSString TraitsAttribute { get; }

		[Internal, Field ("UIFontDescriptorFixedAdvanceAttribute")]
		internal static extern NSString FixedAdvanceAttribute { get; }

		[Internal, Field ("UIFontDescriptorFeatureSettingsAttribute")]
		internal static extern NSString FeatureSettingsAttribute { get; }

		[Internal, Field ("UIFontDescriptorTextStyleAttribute")]
		internal static extern NSString TextStyleAttribute { get; }

		[Internal, Field ("UIFontSymbolicTrait")]
		internal static extern NSString SymbolicTrait { get; }

		[Internal, Field ("UIFontWeightTrait")]
		internal static  extern NSString WeightTrait { get; }

		[Internal, Field ("UIFontWidthTrait")]
		internal static extern NSString WidthTrait { get; }

		[Internal, Field ("UIFontSlantTrait")]
		internal static extern NSString SlantTrait { get; }

		[Internal, Field ("UIFontFeatureSelectorIdentifierKey")]
		internal static extern NSString UIFontFeatureSelectorIdentifierKey { get; }

		[Internal, Field ("UIFontFeatureTypeIdentifierKey")]
		internal static extern NSString UIFontFeatureTypeIdentifierKey { get; }

	}
	

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[Protocol]
	[Model]
	public class UIDynamicAnimatorDelegate {
#if !NET
		[Abstract]
#endif
		[Export ("dynamicAnimatorWillResume:")]
		public extern void WillResume (UIDynamicAnimator animator);

#if !NET
		[Abstract]
#endif
		[Export ("dynamicAnimatorDidPause:")]
		public extern void DidPause (UIDynamicAnimator animator);
	}
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class UIDynamicAnimator: NSObject {
		[DesignatedInitializer]
		[Export ("initWithReferenceView:")]
		public extern NativeHandle Constructor (UIView referenceView);

		[Export ("referenceView")]
		public extern UIView ReferenceView { get; }

		[Export ("behaviors", ArgumentSemantic.Copy)]
		public extern UIDynamicBehavior [] Behaviors { get; }

		[Export ("running")]
		public extern bool Running { [Bind ("isRunning")] get; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		public extern IUIDynamicAnimatorDelegate Delegate { get; set; }

		[Export ("addBehavior:")]
		[PostGet ("Behaviors")]
		public extern void AddBehavior ([NullAllowed] UIDynamicBehavior behavior);

		[Export ("removeBehavior:")]
		[PostGet ("Behaviors")]
		public extern void RemoveBehavior ([NullAllowed] UIDynamicBehavior behavior);

		[Export ("removeAllBehaviors")]
		[PostGet ("Behaviors")]
		public extern void RemoveAllBehaviors ();

		[Export ("itemsInRect:")]
		public extern IUIDynamicItem [] GetDynamicItems (CGRect rect);

		[Export ("elapsedTime")]
		public extern double ElapsedTime { get; }

		[Export ("updateItemUsingCurrentState:")]
		public extern void UpdateItemUsingCurrentState (IUIDynamicItem uiDynamicItem);

		//
		// From UIDynamicAnimator (UICollectionViewAdditions)
		//
		[Export ("initWithCollectionViewLayout:")]
		public extern NativeHandle Constructor (UICollectionViewLayout layout);

		[Export ("layoutAttributesForCellAtIndexPath:")]
		public extern UICollectionViewLayoutAttributes GetLayoutAttributesForCell (NSIndexPath cellIndexPath);

		[Export ("layoutAttributesForSupplementaryViewOfKind:atIndexPath:")]
		public extern UICollectionViewLayoutAttributes GetLayoutAttributesForSupplementaryView (NSString viewKind, NSIndexPath viewIndexPath);

		[Export ("layoutAttributesForDecorationViewOfKind:atIndexPath:")]
		public extern UICollectionViewLayoutAttributes GetLayoutAttributesForDecorationView (NSString viewKind, NSIndexPath viewIndexPath);

	}
	
	public interface IUIDynamicItem { }

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class UIDynamicBehavior {
		[Export ("childBehaviors", ArgumentSemantic.Copy)]
		public extern UIDynamicBehavior [] ChildBehaviors { get; }

		[NullAllowed] // by default this property is null
		[Export ("action", ArgumentSemantic.Copy)]
		public extern Action Action { get; set; }

		[Export ("addChildBehavior:")]
		[PostGet ("ChildBehaviors")]
		public extern void AddChildBehavior (UIDynamicBehavior behavior);

		[Export ("removeChildBehavior:")]
		[PostGet ("ChildBehaviors")]
		public extern void RemoveChildBehavior (UIDynamicBehavior behavior);

		[Export ("dynamicAnimator")]
		public extern UIDynamicAnimator DynamicAnimator { get; }

		[Export ("willMoveToAnimator:")]
		public extern void WillMoveToAnimator ([NullAllowed] UIDynamicAnimator targetAnimator);
	}
	

	//[NoTV, iOS (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (UIViewController))]
	public class UIColorPickerViewController : UIViewController {
		[Export ("initWithNibName:bundle:")]
		public extern NativeHandle Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		public extern IUIColorPickerViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		public extern NSObject WeakDelegate { get; set; }

		[Export ("selectedColor", ArgumentSemantic.Strong)]
		public extern UIColor SelectedColor { get; set; }

		[Export ("supportsAlpha")]
		public extern bool SupportsAlpha { get; set; }
	}
	
	//[NoTV, iOS (14, 0)]
	[MacCatalyst (14, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	public class UIColorPickerViewControllerDelegate: NSObject {

		//[Deprecated (PlatformName.iOS, 15, 0, message: "Use the 'DidSelectColor (UIColorPickerViewController, UIColor, bool)' overload instead.")]
		[Deprecated (PlatformName.MacCatalyst, 15, 0, message: "Use the 'DidSelectColor (UIColorPickerViewController, UIColor, bool)' overload instead.")]
		[Export ("colorPickerViewControllerDidSelectColor:")]
		public extern void DidSelectColor (UIColorPickerViewController viewController);

		//[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("colorPickerViewController:didSelectColor:continuously:")]
		public extern void DidSelectColor (UIColorPickerViewController viewController, UIColor color, bool continuously);

		[Export ("colorPickerViewControllerDidFinish:")]
		public extern void DidFinish (UIColorPickerViewController viewController);
	}
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class UIGraphicsRendererFormat : NSCopying {
		[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'PreferredFormat' instead.")]
		[Static]
		[Export ("defaultFormat")]
		public static extern UIGraphicsRendererFormat DefaultFormat { get; }

		[Export ("bounds")]
		public extern CGRect Bounds { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("preferredFormat")]
		public static extern UIGraphicsRendererFormat PreferredFormat { get; }
	}
	
	// Not worth it, Action<UIGraphicsImageRendererContext> conveys more data
	//delegate void UIGraphicsImageDrawingActions (UIGraphicsImageRendererContext context);

	[MacCatalyst (13, 1)]
	[BaseType (typeof (UIGraphicsRendererFormat))]
	public class UIGraphicsImageRendererFormat {
		[Export ("scale")]
		public extern nfloat Scale { get; set; }

		[Export ("opaque")]
		public extern bool Opaque { get; set; }

		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use the 'PreferredRange' property instead.")]
		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use the 'PreferredRange' property instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use the 'PreferredRange' property instead.")]
		[Export ("prefersExtendedRange")]
		public extern bool PrefersExtendedRange { get; set; }

		[New] // kind of overloading a static member, make it return `instancetype`
		[Static]
		[Export ("defaultFormat")]
		public static extern UIGraphicsImageRendererFormat DefaultFormat { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("formatForTraitCollection:")]
		public static extern UIGraphicsImageRendererFormat GetFormat (UITraitCollection traitCollection);

		[MacCatalyst (13, 1)]
		[Export ("preferredRange", ArgumentSemantic.Assign)]
		public static extern UIGraphicsImageRendererFormatRange PreferredRange { get; set; }

		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("supportsHighDynamicRange")]
		public static extern bool SupportsHighDynamicRange { get; }
	}
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class UIImageAsset : NSCoding {

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageWithConfiguration:")]
		public extern UIImage FromConfiguration (UIImageConfiguration configuration);

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("registerImage:withConfiguration:")]
		public extern void RegisterImage (UIImage image, UIImageConfiguration configuration);

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("unregisterImageWithConfiguration:")]
		public extern void UnregisterImage (UIImageConfiguration configuration);

		[Export ("imageWithTraitCollection:")]
		public extern UIImage FromTraitCollection (UITraitCollection traitCollection);

		[Export ("registerImage:withTraitCollection:")]
		public extern void RegisterImage (UIImage image, UITraitCollection traitCollection);

		[Export ("unregisterImageWithTraitCollection:")]
		public extern void UnregisterImageWithTraitCollection (UITraitCollection traitCollection);
	}
	
	[NoTV]
	[MacCatalyst (13, 1)]
	[Protocol]
	public interface UIItemProviderPresentationSizeProviding {
		[Abstract]
		[Export ("preferredPresentationSizeForItemProvider")]
		public extern CGSize PreferredPresentationSizeForItemProvider { get; }
	}
	
	[BaseType (typeof (NSObject))]
	public class UIImage : UIAccessibility, IUIAccessibilityIdentification
#if !TVOS
		//, NSItemProviderWriting, NSItemProviderReading, UIItemProviderPresentationSizeProviding
#endif
	{
		[ThreadSafe]
		[Export ("initWithContentsOfFile:")]
		public extern NativeHandle Constructor (string filename);

		[ThreadSafe]
		[Export ("initWithData:")]
		public extern NativeHandle Constructor (NSData data);

		[ThreadSafe]
		[Export ("size")]
		[Autorelease]
		public extern CGSize Size { get; }

		// Thread-safe in iOS 9 or later according to docs.
#if IOS
		// tvOS started with 9.0 code base (and watchOS 2.0 came later)
		[Advice ("This API is thread-safe only on 9.0 and later.")]
#endif
		[ThreadSafe]
		[Static]
		[Export ("imageNamed:")]
		[Autorelease]
		[return: NullAllowed]
		public extern UIImage FromBundle (string name);

		// Thread-safe in iOS 9 or later according to docs.
#if IOS
		// tvOS started with 9.0 code base (and watchOS 2.0 came later)
		[Advice ("This API is thread-safe only on 9.0 and later.")]
#endif
		[ThreadSafe]
		[MacCatalyst (13, 1)]
		[Static, Export ("imageNamed:inBundle:compatibleWithTraitCollection:")]
		[return: NullAllowed]
		public extern UIImage? FromBundle (string name, [NullAllowed] NSBundle bundle, [NullAllowed] UITraitCollection traitCollection);

		[Static]
		[Export ("imageWithContentsOfFile:")]
		[Autorelease]
		[ThreadSafe]
		[return: NullAllowed]
		public static extern UIImage? FromFile (string filename);

		[Static]
		[Export ("imageWithData:")]
		[Autorelease]
		[ThreadSafe]
		[return: NullAllowed]
		public static extern UIImage? LoadFromData (NSData data);

		[Static]
		[Export ("imageWithCGImage:")]
		[Autorelease]
		[ThreadSafe]
		public static extern UIImage FromImage (CGImage image);

		[Static]
		[Export ("imageWithCGImage:scale:orientation:")]
		[Autorelease]
		[ThreadSafe]
		public static extern UIImage FromImage (CGImage image, nfloat scale, UIImageOrientation orientation);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("imageWithCIImage:")]
		[Autorelease]
		[ThreadSafe]
		public static extern UIImage FromImage (CIImage image);

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
		[Static]
		[Export ("objectWithItemProviderData:typeIdentifier:error:")]
		[NoTV]
		[MacCatalyst (13, 1)]
		[return: NullAllowed]
#if !TVOS
		new
#endif
			public static extern UIImage GetObject (NSData data, string typeIdentifier, [NullAllowed] out NSError outError);

		[Export ("renderingMode")]
		[ThreadSafe]
		public static extern UIImageRenderingMode RenderingMode { get; }

		[Export ("imageWithRenderingMode:")]
		[ThreadSafe]
		public static extern UIImage ImageWithRenderingMode (UIImageRenderingMode renderingMode);

		[Export ("CGImage")]
		[ThreadSafe]
		[NullAllowed]
		public static extern CGImage CGImage { get; }

		[Export ("imageOrientation")]
		[ThreadSafe]
		public static extern UIImageOrientation Orientation { get; }

		[Export ("drawAtPoint:")]
		[ThreadSafe]
		public static extern void Draw (CGPoint point);

		[Export ("drawAtPoint:blendMode:alpha:")]
		[ThreadSafe]
		public static extern void Draw (CGPoint point, CGBlendMode blendMode, nfloat alpha);

		[Export ("drawInRect:")]
		[ThreadSafe]
		public static extern void Draw (CGRect rect);

		[Export ("drawInRect:blendMode:alpha:")]
		[ThreadSafe]
		public static extern void Draw (CGRect rect, CGBlendMode blendMode, nfloat alpha);

		[Export ("drawAsPatternInRect:")]
		[ThreadSafe]
		public static extern void DrawAsPatternInRect (CGRect rect);

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("stretchableImageWithLeftCapWidth:topCapHeight:")]
		[Autorelease]
		[ThreadSafe]
		public  extern UIImage StretchableImage (nint leftCapWidth, nint topCapHeight);

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("leftCapWidth")]
		[ThreadSafe]
		public  extern nint LeftCapWidth { get; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("topCapHeight")]
		[ThreadSafe]
		public  extern nint TopCapHeight { get; }

		[Export ("scale")]
		[ThreadSafe]
		public  extern nfloat CurrentScale { get; }

		[Static, Export ("animatedImageNamed:duration:")]
		[Autorelease]
		[ThreadSafe]
		[return: NullAllowed]
		public  extern UIImage CreateAnimatedImage (string name, double duration);

		[Static, Export ("animatedImageWithImages:duration:")]
		[Autorelease]
		[ThreadSafe]
		[return: NullAllowed]
		public  extern UIImage CreateAnimatedImage (UIImage [] images, double duration);

		[Static, Export ("animatedResizableImageNamed:capInsets:duration:")]
		[Autorelease]
		[ThreadSafe]
		[return: NullAllowed]
		public  extern UIImage CreateAnimatedImage (string name, UIEdgeInsets capInsets, double duration);

		[Export ("initWithCGImage:")]
		[ThreadSafe]
		public  extern NativeHandle Constructor (CGImage cgImage);

		[MacCatalyst (13, 1)]
		[Export ("initWithCIImage:")]
		[ThreadSafe]
		public  extern NativeHandle Constructor (CIImage ciImage);

		[Export ("initWithCGImage:scale:orientation:")]
		[ThreadSafe]
		public  extern NativeHandle Constructor (CGImage cgImage, nfloat scale, UIImageOrientation orientation);

		[MacCatalyst (13, 1)]
		[Export ("CIImage")]
		[ThreadSafe]
		[NullAllowed]
		public  extern CIImage CIImage { get; }

		[Export ("images")]
		[ThreadSafe]
		[NullAllowed]
		public  extern UIImage [] Images { get; }

		[Export ("duration")]
		[ThreadSafe]
		public  extern double Duration { get; }

		[Export ("resizableImageWithCapInsets:")]
		[Autorelease]
		[ThreadSafe]
		public  extern UIImage CreateResizableImage (UIEdgeInsets capInsets);

		[Export ("capInsets")]
		[ThreadSafe]
		public  extern UIEdgeInsets CapInsets { get; }

		//
		// 6.0
		//
		[Export ("alignmentRectInsets")]
		[ThreadSafe]
		public  extern UIEdgeInsets AlignmentRectInsets { get; }

		[Static]
		[Export ("imageWithData:scale:")]
		[ThreadSafe, Autorelease]
		[return: NullAllowed]
		public static extern UIImage? LoadFromData (NSData data, nfloat scale);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("imageWithCIImage:scale:orientation:")]
		[ThreadSafe, Autorelease]
		public static extern UIImage? FromImage (CIImage ciImage, nfloat scale, UIImageOrientation orientation);

		[Export ("initWithData:scale:")]
		[ThreadSafe]
		public  extern NativeHandle Constructor (NSData data, nfloat scale);

		[MacCatalyst (13, 1)]
		[Export ("initWithCIImage:scale:orientation:")]
		[ThreadSafe]
		public  extern NativeHandle Constructor (CIImage ciImage, nfloat scale, UIImageOrientation orientation);

		[Export ("resizableImageWithCapInsets:resizingMode:")]
		[ThreadSafe]
		public  extern UIImage CreateResizableImage (UIEdgeInsets capInsets, UIImageResizingMode resizingMode);

		[Static]
		[Export ("animatedResizableImageNamed:capInsets:resizingMode:duration:")]
		[ThreadSafe]
		[return: NullAllowed]
		public  extern UIImage? CreateAnimatedImage (string name, UIEdgeInsets capInsets, UIImageResizingMode resizingMode, double duration);

		[Export ("imageWithAlignmentRectInsets:")]
		[ThreadSafe, Autorelease]
		public  extern UIImage ImageWithAlignmentRectInsets (UIEdgeInsets alignmentInsets);

		[Export ("resizingMode")]
		[ThreadSafe]
		public  extern UIImageResizingMode ResizingMode { get; }

		[MacCatalyst (13, 1)]
		[Export ("traitCollection")]
		[ThreadSafe]
		public  extern UITraitCollection TraitCollection { get; }

		[MacCatalyst (13, 1)]
		[Export ("imageAsset")]
		[ThreadSafe]
		[NullAllowed]
		public  extern UIImageAsset ImageAsset { get; }

		[MacCatalyst (13, 1)]
		[Export ("imageFlippedForRightToLeftLayoutDirection")]
		public  extern UIImage GetImageFlippedForRightToLeftLayoutDirection ();

		[MacCatalyst (13, 1)]
		[Export ("flipsForRightToLeftLayoutDirection")]
		public  extern bool FlipsForRightToLeftLayoutDirection { get; }

		[MacCatalyst (13, 1)]
		[Export ("imageRendererFormat")]
		public  extern UIGraphicsImageRendererFormat ImageRendererFormat { get; }

		[MacCatalyst (13, 1)]
		[Export ("imageWithHorizontallyFlippedOrientation")]
		public  extern UIImage GetImageWithHorizontallyFlippedOrientation ();

		// From the NSItemProviderWriting protocol, a static method.
		// NSItemProviderWriting doesn't seem to be implemented for tvOS/watchOS, even though the headers say otherwise.
		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("writableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
#if !TVOS
		new
#endif
			public  extern string [] WritableTypeIdentifiers { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemImageNamed:")]
		[return: NullAllowed]
		public  extern UIImage GetSystemImage (string name);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemImageNamed:withConfiguration:")]
		[return: NullAllowed]
		public  extern UIImage GetSystemImage (string name, [NullAllowed] UIImageConfiguration configuration);

		//[TV (13, 0), iOS (13, 0)] // UITraitCollection is not available on watch, it has been reported before.
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("systemImageNamed:compatibleWithTraitCollection:")]
		[return: NullAllowed]
		public  extern UIImage GetSystemImage (string name, [NullAllowed] UITraitCollection traitCollection);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[ThreadSafe]
		[Export ("imageNamed:inBundle:withConfiguration:")]
		[return: NullAllowed]
		public  extern UIImage FromBundle (string name, [NullAllowed] NSBundle bundle, [NullAllowed] UIImageConfiguration configuration);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("symbolImage")]
		public  extern bool SymbolImage { [Bind ("isSymbolImage")] get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("baselineOffsetFromBottom")]
		public  extern nfloat BaselineOffsetFromBottom { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("hasBaseline")]
		public  extern bool HasBaseline { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageWithBaselineOffsetFromBottom:")]
		public  extern UIImage GetImageFromBottom (nfloat baselineOffset);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageWithoutBaseline")]
		public  extern UIImage GetImageWithoutBaseline ();

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("configuration", ArgumentSemantic.Copy)]
		[NullAllowed]
		public  extern UIImageConfiguration? Configuration { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageWithConfiguration:")]
		public  extern UIImage ApplyConfiguration (UIImageConfiguration configuration);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("symbolConfiguration", ArgumentSemantic.Copy)]
		public  extern UIImageSymbolConfiguration SymbolConfiguration { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageByApplyingSymbolConfiguration:")]
		[return: NullAllowed]
		public  extern UIImage? ApplyConfiguration (UIImageSymbolConfiguration configuration);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageWithTintColor:")]
		public  extern UIImage ApplyTintColor (UIColor color);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageWithTintColor:renderingMode:")]
		public  extern UIImage ApplyTintColor (UIColor color, UIImageRenderingMode renderingMode);

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("imageByPreparingForDisplay")]
		[return: NullAllowed]
		public  extern UIImage? GetImageByPreparingForDisplay ();

		[Async]
		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("prepareForDisplayWithCompletionHandler:")]
		public extern void PrepareForDisplay (Action<UIImage> completionHandler);

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("imageByPreparingThumbnailOfSize:")]
		[return: NullAllowed]
		public  extern UIImage GetImageByPreparingThumbnail (CGSize ofSize);

		[Async]
		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("prepareThumbnailOfSize:completionHandler:")]
		public  extern void PrepareThumbnail (CGSize OfSize, Action<UIImage> completionHandler);

		// Inlined from UIImage (PreconfiguredSystemImages)

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("actionsImage", ArgumentSemantic.Strong)]
		public  extern UIImage ActionsImage { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("addImage", ArgumentSemantic.Strong)]
		public static extern UIImage AddImage { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("removeImage", ArgumentSemantic.Strong)]
		public static extern UIImage RemoveImage { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("checkmarkImage", ArgumentSemantic.Strong)]
		public static extern UIImage CheckmarkImage { get; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("strokedCheckmarkImage", ArgumentSemantic.Strong)]
		public static extern UIImage StrokedCheckmarkImage { get; }

		//[TV (16, 0), MacCatalyst (16, 0), iOS (16, 0)]
		[Static]
		[Export ("systemImageNamed:variableValue:withConfiguration:")]
		[return: NullAllowed]
		public static extern UIImage GetSystemImage (string name, double value, [NullAllowed] UIImageConfiguration configuration);

		//[TV (16, 0), MacCatalyst (16, 0), iOS (16, 0)]
		[Static]
		[Export ("imageNamed:inBundle:variableValue:withConfiguration:")]
		[return: NullAllowed]
		public static extern UIImage FromBundle (string name, [NullAllowed] NSBundle bundle, double value, [NullAllowed] UIImageConfiguration configuration);

		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("isHighDynamicRange")]
		public extern bool IsHighDynamicRange { get; }

		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("imageRestrictedToStandardDynamicRange")]
		public  extern UIImage ImageRestrictedToStandardDynamicRange { get; }
	}

	//[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public class UIImageConfiguration : NSCopying {
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("traitCollection")]
		public  extern UITraitCollection TraitCollection { get; }

		[MacCatalyst (13, 1)]
		[Export ("configurationWithTraitCollection:")]
		public  extern UIImageConfiguration GetConfiguration ([NullAllowed] UITraitCollection traitCollection);

		[Export ("configurationByApplyingConfiguration:")]
		public extern UIImageConfiguration GetConfiguration ([NullAllowed] UIImageConfiguration otherConfiguration);

		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[NullAllowed, Export ("locale")]
		public extern NSLocale Locale { get; }

		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("configurationWithLocale:")]
		public extern UIImageConfiguration GetConfiguration ([NullAllowed] NSLocale locale);

		[Static]
		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("configurationWithLocale:")]
		public extern UIImageConfiguration CreateConfiguration ([NullAllowed] NSLocale locale);

		//[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("configurationWithTraitCollection:")]
		public static extern UIImageConfiguration CreateConfiguration ([NullAllowed] UITraitCollection traitCollection);
	}

	//[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (UIImageConfiguration))]
	public class UIImageSymbolConfiguration {

		[Static]
		[Export ("unspecifiedConfiguration")]
		public static extern UIImageSymbolConfiguration UnspecifiedConfiguration { get; }

		[Static]
		[Export ("configurationWithScale:")]
		public static extern UIImageSymbolConfiguration Create (UIImageSymbolScale scale);

		[Static]
		[Export ("configurationWithPointSize:")]
		public static extern UIImageSymbolConfiguration Create (nfloat pointSize);

		[Static]
		[Export ("configurationWithWeight:")]
		public static extern UIImageSymbolConfiguration Create (UIImageSymbolWeight weight);

		[Static]
		[Export ("configurationWithPointSize:weight:")]
		public static extern UIImageSymbolConfiguration Create (nfloat pointSize, UIImageSymbolWeight weight);

		[Static]
		[Export ("configurationWithPointSize:weight:scale:")]
		public static extern UIImageSymbolConfiguration Create (nfloat pointSize, UIImageSymbolWeight weight, UIImageSymbolScale scale);

		[Static]
		[Export ("configurationWithTextStyle:")]
		public static extern UIImageSymbolConfiguration Create ([BindAs (typeof (UIFontTextStyle))] NSString textStyle);

		[Static]
		[Export ("configurationWithTextStyle:scale:")]
		public static extern UIImageSymbolConfiguration Create ([BindAs (typeof (UIFontTextStyle))] NSString textStyle, UIImageSymbolScale scale);

		[Static]
		[Export ("configurationWithFont:")]
		public static extern UIImageSymbolConfiguration Create (UIFont font);

		[Static]
		[Export ("configurationWithFont:scale:")]
		public static extern UIImageSymbolConfiguration Create (UIFont font, UIImageSymbolScale scale);

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("configurationWithHierarchicalColor:")]
		public static extern UIImageSymbolConfiguration Create (UIColor hierarchicalColor);

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("configurationWithPaletteColors:")]
		public static extern UIImageSymbolConfiguration Create (UIColor [] paletteColors);

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("configurationPreferringMulticolor")]
		public static extern UIImageSymbolConfiguration ConfigurationPreferringMulticolor { get; }

		[Export ("configurationWithoutTextStyle")]
		public static extern UIImageSymbolConfiguration ConfigurationWithoutTextStyle { get; }

		[Export ("configurationWithoutScale")]
		public static extern UIImageSymbolConfiguration ConfigurationWithoutScale { get; }

		[Export ("configurationWithoutWeight")]
		public static extern UIImageSymbolConfiguration ConfigurationWithoutWeight { get; }

		[Export ("configurationWithoutPointSizeAndWeight")]
		public static extern UIImageSymbolConfiguration ConfigurationWithoutPointSizeAndWeight { get; }

		[Export ("isEqualToConfiguration:")]
		public  extern bool IsEqualTo ([NullAllowed] UIImageSymbolConfiguration otherConfiguration);

		//[TV (16, 0), MacCatalyst (16, 0), iOS (16, 0)]
		[Static]
		[Export ("configurationPreferringMonochrome")]
		public static extern UIImageSymbolConfiguration GetConfigurationPreferringMonochrome ();
	}
}