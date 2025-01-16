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
using CoreData;
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

#endregion

namespace UIKit
{
	public interface IUITraitEnvironment { }
	
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	[MacCatalyst (13, 1)]
	public partial class UITraitEnvironment : NSObject{
		[Abstract]
		[Export ("traitCollection")]
		public extern UITraitCollection TraitCollection { get; }

		[Deprecated (PlatformName.iOS, 17, 0, message: "Use the 'UITraitChangeObservable' protocol instead.")]
		[Deprecated (PlatformName.MacCatalyst, 17, 0, message: "Use the 'UITraitChangeObservable' protocol instead.")]
		[Deprecated (PlatformName.TvOS, 17, 0, message: "Use the 'UITraitChangeObservable' protocol instead.")]
		[Abstract]
		[Export ("traitCollectionDidChange:")]
		public extern void TraitCollectionDidChange ([NullAllowed] UITraitCollection previousTraitCollection);
	}
	
	public interface IUIMutableTraits { }

	public delegate void UITraitMutations (IUIMutableTraits mutableTraits);

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	[ThreadSafe] // Documentation doesn't say, but it this class doesn't seem to trigger Apple's Main Thread Checker.
	public partial class UITraitCollection : NSCopying {
		
		/* COMMENTED UNIT WE DISCOVER IF IT IS NEEDED
		[Export ("userInterfaceIdiom")]
		public extern UIUserInterfaceIdiom UserInterfaceIdiom { get; }

		[MacCatalyst (13, 1)]
		[Export ("userInterfaceStyle")]
		public extern UIUserInterfaceStyle UserInterfaceStyle { get; }

		[Export ("displayScale")]
		nfloat DisplayScale { get; }

		[Export ("horizontalSizeClass")]
		public extern UIUserInterfaceSizeClass HorizontalSizeClass { get; }

		[Export ("verticalSizeClass")]
		public extern UIUserInterfaceSizeClass VerticalSizeClass { get; }

		[Deprecated (PlatformName.iOS, 17, 0, message: "Compare the values for the specific items instead.")]
		[Deprecated (PlatformName.MacCatalyst, 17, 0, message: "Compare the values for the specific items instead.")]
		[Deprecated (PlatformName.TvOS, 17, 0, message: "Compare the values for the specific items instead.")]
		[Export ("containsTraitsInCollection:")]
		bool Contains (UITraitCollection trait);

		[Deprecated (PlatformName.iOS, 17, 0, message: "Use 'GetTraitCollectionWithTraits(UITraitMutations)' and 'GetTraitCollectionByModifyingTraits(UITraitMutations)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 17, 0, message: "Use 'GetTraitCollectionWithTraits(UITraitMutations)' and 'GetTraitCollectionByModifyingTraits(UITraitMutations)' instead.")]
		[Deprecated (PlatformName.TvOS, 17, 0, message: "Use 'GetTraitCollectionWithTraits(UITraitMutations)' and 'GetTraitCollectionByModifyingTraits(UITraitMutations)' instead.")]
		[Static, Export ("traitCollectionWithTraitsFromCollections:")]
		UITraitCollection FromTraitsFromCollections (UITraitCollection [] traitCollections);

		[Static, Export ("traitCollectionWithUserInterfaceIdiom:")]
		UITraitCollection FromUserInterfaceIdiom (UIUserInterfaceIdiom idiom);

		[Static, Export ("traitCollectionWithDisplayScale:")]
		UITraitCollection FromDisplayScale (nfloat scale);

		[Static, Export ("traitCollectionWithHorizontalSizeClass:")]
		UITraitCollection FromHorizontalSizeClass (UIUserInterfaceSizeClass horizontalSizeClass);

		[Static, Export ("traitCollectionWithVerticalSizeClass:")]
		UITraitCollection FromVerticalSizeClass (UIUserInterfaceSizeClass verticalSizeClass);

		[MacCatalyst (13, 1)]
		[Static, Export ("traitCollectionWithForceTouchCapability:")]
		UITraitCollection FromForceTouchCapability (UIForceTouchCapability capability);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("traitCollectionWithUserInterfaceStyle:")]
		UITraitCollection FromUserInterfaceStyle (UIUserInterfaceStyle userInterfaceStyle);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("traitCollectionWithDisplayGamut:")]
		UITraitCollection FromDisplayGamut (UIDisplayGamut displayGamut);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("traitCollectionWithLayoutDirection:")]
		UITraitCollection FromLayoutDirection (UITraitEnvironmentLayoutDirection layoutDirection);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("traitCollectionWithPreferredContentSizeCategory:")]
		[Internal]
		UITraitCollection FromPreferredContentSizeCategory (NSString preferredContentSizeCategory);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithSceneCaptureState:")]
		UITraitCollection FromSceneCaptureState (UISceneCaptureState sceneCaptureState);

		[MacCatalyst (13, 1)]
		[Export ("forceTouchCapability")]
		UIForceTouchCapability ForceTouchCapability { get; }

		[MacCatalyst (13, 1)]
		[Export ("displayGamut")]
		UIDisplayGamut DisplayGamut { get; }

		[MacCatalyst (13, 1)]
		[Export ("preferredContentSizeCategory")]
		string PreferredContentSizeCategory { get; }

		[MacCatalyst (13, 1)]
		[Export ("layoutDirection")]
		UITraitEnvironmentLayoutDirection LayoutDirection { get; }

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("sceneCaptureState")]
		UISceneCaptureState SceneCaptureState { get; }

		// This class has other members using From*
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("traitCollectionWithAccessibilityContrast:")]
		UITraitCollection FromAccessibilityContrast (UIAccessibilityContrast accessibilityContrast);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("accessibilityContrast")]
		UIAccessibilityContrast AccessibilityContrast { get; }

		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("traitCollectionWithUserInterfaceLevel:")]
		UITraitCollection FromUserInterfaceLevel (UIUserInterfaceLevel userInterfaceLevel);

		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("userInterfaceLevel")]
		UIUserInterfaceLevel UserInterfaceLevel { get; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("traitCollectionWithLegibilityWeight:")]
		UITraitCollection FromLegibilityWeight (UILegibilityWeight legibilityWeight);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("legibilityWeight")]
		UILegibilityWeight LegibilityWeight { get; }

		[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Export ("traitCollectionWithActiveAppearance:")]
		UITraitCollection FromActiveAppearance (UIUserInterfaceActiveAppearance userInterfaceActiveAppearance); // We have other From* methods

		[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("activeAppearance")]
		UIUserInterfaceActiveAppearance ActiveAppearance { get; }

		// From UITraitCollection (CurrentTraitCollection)

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("currentTraitCollection", ArgumentSemantic.Strong)]
		UITraitCollection CurrentTraitCollection { get; set; }

		[ThreadSafe]
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("performAsCurrentTraitCollection:")]
		void PerformAsCurrentTraitCollection (Action actions);

		// From UITraitCollection (CurrentTraitCollection)

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("hasDifferentColorAppearanceComparedToTraitCollection:")]
		bool HasDifferentColorAppearanceComparedTo ([NullAllowed] UITraitCollection traitCollection);

		// From UITraitCollection (ImageConfiguration)

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("imageConfiguration", ArgumentSemantic.Strong)]
		UIImageConfiguration ImageConfiguration { get; }

		[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Static]
		[Export ("traitCollectionWithToolbarItemPresentationSize:")]
		UITraitCollection GetTraitCollection (UINSToolbarItemPresentationSize toolbarItemPresentationSize);

		[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("toolbarItemPresentationSize")]
		UINSToolbarItemPresentationSize ToolbarItemPresentationSize { get; }

#if !XAMCORE_5_0
		[Obsolete ("Use the overload that takes a 'UITraitMutations' parameter instead.")]
		[EditorBrowsable (EditorBrowsableState.Never)]
		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithTraits:")]
		UITraitCollection GetTraitCollectionWithTraits (Func<IUIMutableTraits> mutations);
#endif

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithTraits:")]
		UITraitCollection GetTraitCollectionWithTraits (UITraitMutations mutations);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("traitCollectionByModifyingTraits:")]
		UITraitCollection GetTraitCollectionByModifyingTraits (UITraitMutations mutations);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithCGFloatValue:forTrait:")]
		UITraitCollection GetTraitCollectionWithValue (nfloat value, IUICGFloatTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("traitCollectionByReplacingCGFloatValue:forTrait:")]
		UITraitCollection GetTraitCollectionByReplacingValue (nfloat value, IUICGFloatTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("valueForCGFloatTrait:")]
		nfloat GetValueForTrait (IUICGFloatTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithNSIntegerValue:forTrait:")]
		UITraitCollection GetTraitCollectionWithValue (nint value, IUINSIntegerTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("traitCollectionByReplacingNSIntegerValue:forTrait:")]
		UITraitCollection TraitCollectionByReplacingValue (nint value, IUINSIntegerTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("valueForNSIntegerTrait:")]
		nint GetValueForTrait (IUINSIntegerTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithObject:forTrait:")]
		UITraitCollection GetTraitCollectionWithObject ([NullAllowed] NSObject @object, IUIObjectTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("traitCollectionByReplacingObject:forTrait:")]
		UITraitCollection GetTraitCollectionByReplacingObject ([NullAllowed] NSObject @object, IUIObjectTraitDefinition trait);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("objectForTrait:")]
		[return: NullAllowed]
		NSObject GetObject (IUIObjectTraitDefinition trait);

#if !XAMCORE_5_0
		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("changedTraitsFromTraitCollection:")]
		[Obsolete ("Use 'GetChangedTraits2' instead.")]
		NSSet<IUITraitDefinition> GetChangedTraits ([NullAllowed] UITraitCollection traitCollection);
#endif

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("changedTraitsFromTraitCollection:")]
#if XAMCORE_5_0
		NSSet<Class> GetChangedTraits ([NullAllowed] UITraitCollection traitCollection);
#else
		[Sealed]
		NSSet<Class> GetChangedTraits2 ([NullAllowed] UITraitCollection traitCollection);
#endif

#if !XAMCORE_5_0
		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("systemTraitsAffectingColorAppearance")]
		[Obsolete ("Use 'SystemTraitsAffectingColorAppearance2' instead.")]
		IUITraitDefinition [] SystemTraitsAffectingColorAppearance { get; }
#endif

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("systemTraitsAffectingColorAppearance")]
#if XAMCORE_5_0
		Class [] SystemTraitsAffectingColorAppearance { get; }
#else
		[Sealed]
		Class [] SystemTraitsAffectingColorAppearance2 { get; }
#endif

#if !XAMCORE_5_0
		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("systemTraitsAffectingImageLookup")]
		[Obsolete ("Use 'SystemTraitsAffectingImageLookup2' instead.")]
		IUITraitDefinition [] SystemTraitsAffectingImageLookup { get; }
#endif

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("systemTraitsAffectingImageLookup")]
#if XAMCORE_5_0
		Class [] SystemTraitsAffectingImageLookup { get; }
#else
		[Sealed]
		Class [] SystemTraitsAffectingImageLookup2 { get; }
#endif

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("typesettingLanguage")]
		string TypesettingLanguage { get; }

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithTypesettingLanguage:")]
		UITraitCollection GetTraitCollection (string language);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("traitCollectionWithImageDynamicRange:")]
		UITraitCollection GetTraitCollection (UIImageDynamicRange imageDynamicRange);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("imageDynamicRange")]
		UIImageDynamicRange ImageDynamicRange { get; }

		[Static]
		[TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("traitCollectionWithListEnvironment:")]
		UITraitCollection GetTraitCollection (UIListEnvironment listEnvironment);

		[TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("listEnvironment")]
		UIListEnvironment ListEnvironment { get; }
		
		*/
	}

	[MacCatalyst (13, 1)]
	[Static]
	public partial class UITransitionContext {
		[Field ("UITransitionContextFromViewControllerKey")]
		public extern NSString FromViewControllerKey { get; }

		[Field ("UITransitionContextToViewControllerKey")]
		public extern NSString ToViewControllerKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("UITransitionContextFromViewKey")]
		public extern NSString FromViewKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("UITransitionContextToViewKey")]
		public extern NSString ToViewKey { get; }
	}
}