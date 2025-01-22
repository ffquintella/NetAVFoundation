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
	
	[Flags]
	public enum UIAccessibilityTrait : long {
		None = 0,
		Button = 1,
		Link = 2,
		Image = 4,
		Selected = 8,
		PlaysSound = 16,
		KeyboardKey = 32,
		StaticText = 64,
		SummaryElement = 128,
		NotEnabled = 256,
		UpdatesFrequently = 512,
		SearchField = 1024,
		StartsMediaSession = 2048,
		Adjustable = 4096,
		AllowsDirectInteraction = 8192,
		CausesPageTurn = 16384,
		Header = 65536,
	}
	
	[MacCatalyst (13, 1)]
	[Native]
	public enum UIAccessibilityNavigationStyle : long {

		Automatic = 0,
		Separate = 1,
		Combined = 2
	}
	
	// This protocol is supposed to be an aggregate to existing classes,
	// at the moment there is no API that require a specific UIAccessibilityIdentification
	// implementation, so we don't provide a Model class (for now at least).
	[MacCatalyst (13, 1)]
	[Protocol]
	public class UIAccessibilityIdentification {
		[Abstract]
		[NullAllowed] // by default this property is null
		[Export ("accessibilityIdentifier", ArgumentSemantic.Copy)]
		public extern string? AccessibilityIdentifier { get; set; }
	}

	public interface IUIAccessibilityIdentification { }
	
	public class UIAccessibility {
		[Export ("isAccessibilityElement")]
		public extern bool IsAccessibilityElement { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("accessibilityLabel", ArgumentSemantic.Copy)]
		public extern string? AccessibilityLabel { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("accessibilityAttributedLabel", ArgumentSemantic.Copy)]
		public extern NSAttributedString? AccessibilityAttributedLabel { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("accessibilityHint", ArgumentSemantic.Copy)]
		public extern string? AccessibilityHint { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("accessibilityAttributedHint", ArgumentSemantic.Copy)]
		public extern NSAttributedString? AccessibilityAttributedHint { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("accessibilityValue", ArgumentSemantic.Copy)]
		public extern string? AccessibilityValue { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("accessibilityAttributedValue", ArgumentSemantic.Copy)]
		public extern NSAttributedString AccessibilityAttributedValue { get; set; }

		[Export ("accessibilityTraits")]
		public extern UIAccessibilityTrait AccessibilityTraits { get; set; }

		[Export ("accessibilityFrame")]
		public extern CGRect AccessibilityFrame { get; set; }

		[Export ("accessibilityActivationPoint")]
		public extern CGPoint AccessibilityActivationPoint { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("accessibilityLanguage", ArgumentSemantic.Retain)]
		public extern string AccessibilityLanguage { get; set; }

		[Export ("accessibilityElementsHidden")]
		public extern bool AccessibilityElementsHidden { get; set; }

		[Export ("accessibilityViewIsModal")]
		public extern bool AccessibilityViewIsModal { get; set; }

		[Export ("shouldGroupAccessibilityChildren")]
		public extern bool ShouldGroupAccessibilityChildren { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("accessibilityNavigationStyle")]
		public extern UIAccessibilityNavigationStyle AccessibilityNavigationStyle { get; set; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("accessibilityRespondsToUserInteraction")]
		public extern bool AccessibilityRespondsToUserInteraction { get; set; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("accessibilityUserInputLabels", ArgumentSemantic.Strong)]
		string [] AccessibilityUserInputLabels { get; set; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("accessibilityAttributedUserInputLabels", ArgumentSemantic.Copy)]
		public extern NSAttributedString [] AccessibilityAttributedUserInputLabels { get; set; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("accessibilityTextualContext", ArgumentSemantic.Strong)]
		public extern string AccessibilityTextualContext { get; set; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitNone")]
		public extern long TraitNone { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitButton")]
		public extern long TraitButton { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitLink")]
		public extern long TraitLink { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitHeader")]
		public extern long TraitHeader { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitSearchField")]
		public extern long TraitSearchField { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitImage")]
		public extern long TraitImage { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitSelected")]
		public extern long TraitSelected { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitPlaysSound")]
		public extern long TraitPlaysSound { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitKeyboardKey")]
		public extern long TraitKeyboardKey { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitStaticText")]
		public extern long TraitStaticText { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitSummaryElement")]
		public extern long TraitSummaryElement { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitNotEnabled")]
		public extern long TraitNotEnabled { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitUpdatesFrequently")]
		public extern long TraitUpdatesFrequently { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitStartsMediaSession")]
		public extern long TraitStartsMediaSession { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitAdjustable")]
		public extern long TraitAdjustable { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitAllowsDirectInteraction")]
		public extern long TraitAllowsDirectInteraction { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[Field ("UIAccessibilityTraitCausesPageTurn")]
		public extern long TraitCausesPageTurn { get; }

		[Obsolete ("Use 'UIAccessibilityTraits' enum instead.")]
		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilityTraitTabBar")]
		public extern long TraitTabBar { get; }

		[Field ("UIAccessibilityAnnouncementDidFinishNotification")]
		[Notification (typeof (UIAccessibilityAnnouncementFinishedEventArgs))]
		public extern NSString AnnouncementDidFinishNotification { get; }

		//[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'VoiceOverStatusDidChangeNotification' instead.")]
		//[Deprecated (PlatformName.TvOS, 11, 0, message: "Use 'VoiceOverStatusDidChangeNotification' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'VoiceOverStatusDidChangeNotification' instead.")]
		[Field ("UIAccessibilityVoiceOverStatusChanged")]
		public extern NSString VoiceOverStatusChanged { get; }

		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilityVoiceOverStatusDidChangeNotification")]
		[Notification]
		public extern NSString VoiceOverStatusDidChangeNotification { get; }

		[Field ("UIAccessibilityMonoAudioStatusDidChangeNotification")]
		[Notification]
		public extern NSString MonoAudioStatusDidChangeNotification { get; }

		[Field ("UIAccessibilityClosedCaptioningStatusDidChangeNotification")]
		[Notification]
		public extern NSString ClosedCaptioningStatusDidChangeNotification { get; }

		[Field ("UIAccessibilityInvertColorsStatusDidChangeNotification")]
		[Notification]
		public extern NSString InvertColorsStatusDidChangeNotification { get; }

		[Field ("UIAccessibilityGuidedAccessStatusDidChangeNotification")]
		[Notification]
		public extern NSString GuidedAccessStatusDidChangeNotification { get; }

		[Field ("UIAccessibilityScreenChangedNotification")]
		public extern int ScreenChangedNotification { get; } // This is int, not nint

		[Field ("UIAccessibilityLayoutChangedNotification")]
		public extern int LayoutChangedNotification { get; } // This is int, not nint

		[Field ("UIAccessibilityAnnouncementNotification")]
		public extern int AnnouncementNotification { get; } // This is int, not nint

		[Field ("UIAccessibilityPageScrolledNotification")]
		public extern int PageScrolledNotification { get; } // This is int, not nint

		[NullAllowed] // by default this property is null
		[Export ("accessibilityPath", ArgumentSemantic.Copy)]
		public extern UIBezierPath? AccessibilityPath { get; set; }

		[Export ("accessibilityActivate")]
		public extern bool AccessibilityActivate ();

		[Field ("UIAccessibilitySpeechAttributePunctuation")]
		public extern NSString SpeechAttributePunctuation { get; }

		[Field ("UIAccessibilitySpeechAttributeLanguage")]
		public extern NSString SpeechAttributeLanguage { get; }

		[Field ("UIAccessibilitySpeechAttributePitch")]
		public extern NSString SpeechAttributePitch { get; }

		//[iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Field ("UIAccessibilitySpeechAttributeAnnouncementPriority")]
		public extern NSString SpeechAttributeAnnouncementPriority { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityBoldTextStatusDidChangeNotification")]
		public extern NSString BoldTextStatusDidChangeNotification { get; }

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Notification]
		[Field ("UIAccessibilityButtonShapesEnabledStatusDidChangeNotification")]
		public extern NSString ButtonShapesEnabledStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityDarkerSystemColorsStatusDidChangeNotification")]
		public extern NSString DarkerSystemColorsStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityGrayscaleStatusDidChangeNotification")]
		public extern NSString GrayscaleStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityReduceMotionStatusDidChangeNotification")]
		public extern NSString ReduceMotionStatusDidChangeNotification { get; }

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Notification]
		[Field ("UIAccessibilityPrefersCrossFadeTransitionsStatusDidChangeNotification")]
		public extern NSString PrefersCrossFadeTransitionsStatusDidChangeNotification { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityVideoAutoplayStatusDidChangeNotification")]
		public extern NSString VideoAutoplayStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityReduceTransparencyStatusDidChangeNotification")]
		public extern NSString ReduceTransparencyStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilitySwitchControlStatusDidChangeNotification")]
		public extern NSString SwitchControlStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilityNotificationSwitchControlIdentifier")]
		public extern NSString NotificationSwitchControlIdentifier { get; }


		// Chose int because this should be UIAccessibilityNotifications type
		// just like UIAccessibilityAnnouncementNotification field
		[MacCatalyst (13, 1)]
		//[Notification] // int ScreenChangedNotification doesn't use this attr either
		[Field ("UIAccessibilityPauseAssistiveTechnologyNotification")]
		public extern int PauseAssistiveTechnologyNotification { get; } // UIAccessibilityNotifications => uint32_t

		// Chose int because this should be UIAccessibilityNotifications type
		// just like UIAccessibilityAnnouncementNotification field
		[MacCatalyst (13, 1)]
		//[Notification] // int ScreenChangedNotification doesn't use this attr either
		[Field ("UIAccessibilityResumeAssistiveTechnologyNotification")]
		public extern int ResumeAssistiveTechnologyNotification { get; } // UIAccessibilityNotifications => uint32_t

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilitySpeakScreenStatusDidChangeNotification")]
		public extern NSString SpeakScreenStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilitySpeakSelectionStatusDidChangeNotification")]
		public extern NSString SpeakSelectionStatusDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityShakeToUndoDidChangeNotification")]
		public extern NSString ShakeToUndoDidChangeNotification { get; }

		// FIXME: we only used this on a few types before, none of them available on tvOS
		// but a new member was added to the platform... 
		[NoiOS]
		[NoMacCatalyst]
		[NullAllowed, Export ("accessibilityHeaderElements", ArgumentSemantic.Copy)]
		public extern NSObject [] AccessibilityHeaderElements { get; set; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityElementFocusedNotification")]
		public extern NSString ElementFocusedNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityFocusedElementKey")]
		public extern NSString FocusedElementKey { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityUnfocusedElementKey")]
		public extern NSString UnfocusedElementKey { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityAssistiveTechnologyKey")]
		public extern NSString AssistiveTechnologyKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilityNotificationVoiceOverIdentifier")]
		public extern NSString NotificationVoiceOverIdentifier { get; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityHearingDevicePairedEarDidChangeNotification")]
		public extern NSString HearingDevicePairedEarDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityAssistiveTouchStatusDidChangeNotification")]
		public extern NSString AssistiveTouchStatusDidChangeNotification { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityShouldDifferentiateWithoutColorDidChangeNotification")]
		public extern NSString ShouldDifferentiateWithoutColorDidChangeNotification { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("UIAccessibilityOnOffSwitchLabelsDidChangeNotification")]
		public extern NSString OnOffSwitchLabelsDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilitySpeechAttributeQueueAnnouncement")]
		public extern NSString SpeechAttributeQueueAnnouncement { get; }

		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilitySpeechAttributeIPANotation")]
		public extern NSString SpeechAttributeIpaNotation { get; }

		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilityTextAttributeHeadingLevel")]
		public extern NSString TextAttributeHeadingLevel { get; }

		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilityTextAttributeCustom")]
		public extern NSString TextAttributeCustom { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilityTextAttributeContext")]
		public extern NSString TextAttributeContext { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("UIAccessibilitySpeechAttributeSpellOut")]
		public extern NSString SpeechAttributeSpellOut { get; }

		//[iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("accessibilityDirectTouchOptions", ArgumentSemantic.Assign)]
		public extern UIAccessibilityDirectTouchOptions AccessibilityDirectTouchOptions { get; set; }

		//[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("accessibilityExpandedStatus", ArgumentSemantic.Assign)]
		public extern UIAccessibilityExpandedStatus AccessibilityExpandedStatus { get; set; }
	}
	
	[Flags]
	[Native]
	public enum UIAccessibilityDirectTouchOptions : ulong {
		None = 0x0,
		SilentOnTouch = 1uL << 0,
		RequiresActivation = 1uL << 1,
	}
	
	public enum UIAccessibilityExpandedStatus : long {
		Unsupported = 0,
		Expanded,
		Collapsed,
	}

	public class  UIAccessibilityAnnouncementFinishedEventArgs {
		[Export ("UIAccessibilityAnnouncementKeyStringValue")]
		public extern string Announcement { get; }

		[Export ("UIAccessibilityAnnouncementKeyWasSuccessful")]
		public extern bool WasSuccessful { get; }
	}

	[MacCatalyst (13, 1)]
	[Protocol (IsInformal = true)]
	public class  UIAccessibilityContainer {
		[Export ("accessibilityElementCount")]
		public extern nint AccessibilityElementCount ();

		[Export ("accessibilityElementAtIndex:")]
		public extern NSObject GetAccessibilityElementAt (nint index);

		[Export ("indexOfAccessibilityElement:")]
		public extern nint GetIndexOfAccessibilityElement (NSObject element);

		[Export ("accessibilityElements")]
		[MacCatalyst (13, 1)]
		public extern NSObject GetAccessibilityElements ();

		[MacCatalyst (13, 1)]
		[Export ("setAccessibilityElements:")]
		public extern void SetAccessibilityElements ([NullAllowed] NSObject elements);

		[MacCatalyst (13, 1)]
		[Export ("accessibilityContainerType", ArgumentSemantic.Assign)]
		public extern UIAccessibilityContainerType AccessibilityContainerType { get; set; }
	}

	[MacCatalyst (13, 1)]
	[Native]
	public enum UIAccessibilityContainerType : long {
		None = 0,
		DataTable,
		List,
		Landmark,
		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		SemanticGroup,
	}
	
	public class IUIAccessibilityContainerDataTableCell { }

	[MacCatalyst (13, 1)]
	[Protocol]
	public class UIAccessibilityContainerDataTableCell {
		[Abstract]
		[Export ("accessibilityRowRange")]
		public extern NSRange GetAccessibilityRowRange ();

		[Abstract]
		[Export ("accessibilityColumnRange")]
		public extern NSRange GetAccessibilityColumnRange ();
	}

	[MacCatalyst (13, 1)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	public class UIAccessibilityContainerDataTable {
		[Abstract]
		[Export ("accessibilityDataTableCellElementForRow:column:")]
		[return: NullAllowed]
		public extern IUIAccessibilityContainerDataTableCell? GetAccessibilityDataTableCellElement (nuint row, nuint column);

		[Abstract]
		[Export ("accessibilityRowCount")]
		public extern nuint AccessibilityRowCount { get; }

		[Abstract]
		[Export ("accessibilityColumnCount")]
		public extern nuint AccessibilityColumnCount { get; }

		[Export ("accessibilityHeaderElementsForRow:")]
		[return: NullAllowed]
		public extern IUIAccessibilityContainerDataTableCell [] GetAccessibilityHeaderElementsForRow (nuint row);

		[Export ("accessibilityHeaderElementsForColumn:")]
		[return: NullAllowed]
		public extern IUIAccessibilityContainerDataTableCell [] GetAccessibilityHeaderElementsForColumn (nuint column);
	}

	//[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	public delegate bool UIAccessibilityCustomActionHandler (UIAccessibilityCustomAction customAction);

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // NSInvalidArgumentException Please use the designated initializer
	public partial class UIAccessibilityCustomAction {
		[Export ("initWithName:target:selector:")]
		public extern NativeHandle Constructor (string name, NSObject target, Selector selector);

		[MacCatalyst (13, 1)]
		[Export ("initWithAttributedName:target:selector:")]
		public extern NativeHandle Constructor (NSAttributedString attributedName, [NullAllowed] NSObject target, Selector selector);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("initWithName:actionHandler:")]
		public extern NativeHandle Constructor (string name, [NullAllowed] UIAccessibilityCustomActionHandler actionHandler);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("initWithAttributedName:actionHandler:")]
		public extern NativeHandle Constructor (NSAttributedString attributedName, [NullAllowed] UIAccessibilityCustomActionHandler actionHandler);

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("initWithName:image:target:selector:")]
		public extern NativeHandle Constructor (string name, [NullAllowed] UIImage image, [NullAllowed] NSObject target, Selector selector);

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("initWithAttributedName:image:target:selector:")]
		public extern NativeHandle Constructor (NSAttributedString attributedName, [NullAllowed] UIImage image, [NullAllowed] NSObject target, Selector selector);

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("initWithName:image:actionHandler:")]
		public extern NativeHandle Constructor (string name, [NullAllowed] UIImage image, UIAccessibilityCustomActionHandler actionHandler);

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("initWithAttributedName:image:actionHandler:")]
		public extern NativeHandle Constructor (NSAttributedString attributedName, [NullAllowed] UIImage image, UIAccessibilityCustomActionHandler actionHandler);

		[NullAllowed] // by default this property is null
		[Export ("name")]
		public extern string Name { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("attributedName", ArgumentSemantic.Copy)]
		public extern NSAttributedString AttributedName { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("target", ArgumentSemantic.Weak)]
		public extern NSObject Target { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("selector", ArgumentSemantic.UnsafeUnretained)]
		public extern Selector Selector { get; set; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("actionHandler", ArgumentSemantic.Copy)]
		public extern UIAccessibilityCustomActionHandler ActionHandler { get; set; }

		//[TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
		public extern UIImage Image { get; set; }

		//[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("category", ArgumentSemantic.Copy), NullAllowed]
		public extern string Category { get; set; }

		//[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("UIAccessibilityCustomActionCategoryEdit")]
		public extern NSString CategoryEdit { get; }
	}

	public delegate UIAccessibilityCustomRotorItemResult UIAccessibilityCustomRotorSearch (UIAccessibilityCustomRotorSearchPredicate predicate);

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class  UIAccessibilityCustomRotor {

		[Export ("initWithName:itemSearchBlock:")]
		public extern NativeHandle Constructor (string name, UIAccessibilityCustomRotorSearch itemSearchHandler);

		[MacCatalyst (13, 1)]
		[Export ("initWithAttributedName:itemSearchBlock:")]
		public extern NativeHandle Constructor (NSAttributedString attributedName, UIAccessibilityCustomRotorSearch itemSearchBlock);

		[MacCatalyst (13, 1)]
		[Export ("initWithSystemType:itemSearchBlock:")]
		public extern NativeHandle Constructor (UIAccessibilityCustomSystemRotorType type, UIAccessibilityCustomRotorSearch itemSearchBlock);

		[Export ("name")]
		public extern string Name { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("attributedName", ArgumentSemantic.Copy)]
		public extern NSAttributedString AttributedName { get; set; }

		[Export ("itemSearchBlock", ArgumentSemantic.Copy)]
		public extern UIAccessibilityCustomRotorSearch ItemSearchHandler { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("systemRotorType")]
		public extern UIAccessibilityCustomSystemRotorType SystemRotorType { get; }
	}
	
	[MacCatalyst (13, 1)]
	[Native]
	public enum UIAccessibilityCustomSystemRotorType : long {
		None = 0,
		Link,
		VisitedLink,
		Heading,
		HeadingLevel1,
		HeadingLevel2,
		HeadingLevel3,
		HeadingLevel4,
		HeadingLevel5,
		HeadingLevel6,
		BoldText,
		ItalicText,
		UnderlineText,
		MisspelledWord,
		Image,
		TextField,
		Table,
		List,
		Landmark
	}

	[MacCatalyst (13, 1)]
	//[Category]
	[BaseType (typeof (NSObject))]
	public class NSObject_UIAccessibilityCustomRotor : NSObject {

		[Export ("accessibilityCustomRotors")]
		[return: NullAllowed]
		public extern UIAccessibilityCustomRotor [] GetAccessibilityCustomRotors ();

		[Export ("setAccessibilityCustomRotors:")]
		public extern void SetAccessibilityCustomRotors ([NullAllowed] UIAccessibilityCustomRotor [] customRotors);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class  UIAccessibilityCustomRotorItemResult : NSObject {

		[Export ("initWithTargetElement:targetRange:")]
		public extern NativeHandle Constructor (NSObject targetElement, [NullAllowed] UITextRange targetRange);

		[NullAllowed, Export ("targetElement", ArgumentSemantic.Weak)]
		public extern NSObject TargetElement { get; set; }

		[NullAllowed, Export ("targetRange", ArgumentSemantic.Retain)]
		public extern UITextRange TargetRange { get; set; }
	}
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class UITextRange {
		[Export ("isEmpty")]
		public extern bool IsEmpty { get; }

		[Export ("start")]
		public extern UITextPosition Start { get; }

		[Export ("end")]
		public extern UITextPosition End { get; }
	}
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public interface UITextPosition {
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class  UIAccessibilityCustomRotorSearchPredicate : NSObject {

		[Export ("currentItem", ArgumentSemantic.Retain)]
		public extern UIAccessibilityCustomRotorItemResult CurrentItem { get; set; }

		[Export ("searchDirection", ArgumentSemantic.Assign)]
		public extern UIAccessibilityCustomRotorDirection SearchDirection { get; set; }
	}
	
	[MacCatalyst (13, 1)]
	[Native]
	public enum UIAccessibilityCustomRotorDirection : long {
		Previous,
		Next
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (UIResponder))]
	// only happens on the simulator (not devices) on iOS8 (still make sense)
	[DisableDefaultCtor] // NSInvalidArgumentException Reason: Use initWithAccessibilityContainer:
	public class  UIAccessibilityElement : UIAccessibilityIdentification {
		[Export ("initWithAccessibilityContainer:")]
		public extern NativeHandle Constructor (NSObject container);

		[NullAllowed] // by default this property is null
		[Export ("accessibilityContainer", ArgumentSemantic.UnsafeUnretained)]
		public extern NSObject? AccessibilityContainer { get; set; }

		[Export ("isAccessibilityElement", ArgumentSemantic.UnsafeUnretained)]
		public extern bool IsAccessibilityElement { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("accessibilityLabel", ArgumentSemantic.Retain)]
		public extern string? AccessibilityLabel { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("accessibilityHint", ArgumentSemantic.Retain)]
		public extern string? AccessibilityHint { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("accessibilityValue", ArgumentSemantic.Retain)]
		public extern string? AccessibilityValue { get; set; }

		[Export ("accessibilityFrame", ArgumentSemantic.UnsafeUnretained)]
		public extern CGRect AccessibilityFrame { get; set; }

		[Export ("accessibilityTraits", ArgumentSemantic.UnsafeUnretained)]
		public extern ulong AccessibilityTraits { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("accessibilityFrameInContainerSpace", ArgumentSemantic.Assign)]
		public extern CGRect AccessibilityFrameInContainerSpace { get; set; }
	}

	[MacCatalyst (13, 1)]
	public class UIAccessibilityFocus {
		[Export ("accessibilityElementDidBecomeFocused")]
		public extern void AccessibilityElementDidBecomeFocused ();

		[Export ("accessibilityElementDidLoseFocus")]
		public extern void AccessibilityElementDidLoseFocus ();

		[Export ("accessibilityElementIsFocused")]
		public extern bool AccessibilityElementIsFocused ();

		[MacCatalyst (13, 1)]
		[Export ("accessibilityAssistiveTechnologyFocusedIdentifiers")]
		public extern NSSet<NSString> AccessibilityAssistiveTechnologyFocusedIdentifiers { get; }
	}

	[MacCatalyst (13, 1)]
	public class UIAccessibilityAction {
		[Export ("accessibilityIncrement")]
		public extern void AccessibilityIncrement ();

		[Export ("accessibilityDecrement")]
		public extern void AccessibilityDecrement ();

		[Export ("accessibilityScroll:")]
		public extern bool AccessibilityScroll (UIAccessibilityScrollDirection direction);

		[Export ("accessibilityPerformEscape")]
		public extern bool AccessibilityPerformEscape ();

		[NoMacCatalyst]
		[Export ("accessibilityPerformMagicTap")]
		public extern bool AccessibilityPerformMagicTap ();

		[MacCatalyst (13, 1)]
		[Export ("accessibilityCustomActions"), NullAllowed]
		public extern UIAccessibilityCustomAction [] AccessibilityCustomActions { get; set; }
	}
	
	// NSInteger -> UIAccessibility.h
	[Native]
	[MacCatalyst (13, 1)]
	public enum UIAccessibilityScrollDirection : long {
		Right = 1,
		Left,
		Up,
		Down,
		Next,
		Previous
	}

	[NoTV]
	[MacCatalyst (13, 1)]
	// NSObject category inlined in UIResponder
	public class UIAccessibilityDragging {
		[NullAllowed, Export ("accessibilityDragSourceDescriptors", ArgumentSemantic.Copy)]
		public extern UIAccessibilityLocationDescriptor [] AccessibilityDragSourceDescriptors { get; set; }

		[NullAllowed, Export ("accessibilityDropPointDescriptors", ArgumentSemantic.Copy)]
		public extern UIAccessibilityLocationDescriptor [] AccessibilityDropPointDescriptors { get; set; }
	}

	/// <summary>An object that provides an accessible description of a location.</summary>
	[NoTV]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public class UIAccessibilityLocationDescriptor {
		[Export ("initWithName:view:")]
		public extern NativeHandle Constructor (string name, UIView view);

		[Export ("initWithName:point:inView:")]
		public extern NativeHandle Constructor (string name, CGPoint point, UIView view);

		[Export ("initWithAttributedName:point:inView:")]
		[DesignatedInitializer]
		public extern NativeHandle Constructor (NSAttributedString attributedName, CGPoint point, UIView view);

		[NullAllowed, Export ("view", ArgumentSemantic.Weak)]
		public extern UIView View { get; }

		[Export ("point")]
		public extern CGPoint Point { get; }

		[Export ("name", ArgumentSemantic.Strong)]
		public extern string Name { get; }

		[Export ("attributedName", ArgumentSemantic.Strong)]
		public extern NSAttributedString AttributedName { get; }
	}

	[NoMac]
	[MacCatalyst (13, 1)]
	[Protocol]
	public class UIAccessibilityContentSizeCategoryImageAdjusting {
		[Abstract]
		[Export ("adjustsImageSizeForAccessibilityContentSizeCategory")]
		public extern bool AdjustsImageSizeForAccessibilityContentSizeCategory { get; set; }
	}
}