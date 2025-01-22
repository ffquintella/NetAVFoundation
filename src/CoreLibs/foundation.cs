//
// This file describes the API that the generator will produce
//
// Authors:
//   Geoff Norton
//   Miguel de Icaza
//   Aaron Bockover
//
// Copyright 2009, Novell, Inc.
// Copyright 2010, Novell, Inc.
// Copyright 2011-2013 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
#define DOUBLE_BLOCKS
using ObjCRuntime;
//using CloudKit;
//using CoreData;
using CoreFoundation;
using Foundation;
using CoreGraphics;
using UniformTypeIdentifiers;
//using Network;
#if HAS_APPCLIP
using AppClip;
#endif
#if IOS
using QuickLook;
#endif
#if !TVOS
//using Contacts;
#endif
#if !WATCH
using CoreAnimation;
///using CoreSpotlight;
#endif
using CoreMedia;
//using SceneKit;
using Security;
#if IOS || MONOMAC
//using FileProvider;
#else
using INSFileProviderItem = Foundation.NSObject;
#endif

#if MONOMAC
using AppKit;
//using QuickLookUI;
#else
using CoreLocation;
using UIKit;
#endif

using System;
using System.ComponentModel;
using System.Net.Security;
using CoreLibs;

// In Apple headers, this is a typedef to a pointer to a private struct
using NSAppleEventManagerSuspensionID = System.IntPtr;
// These two are both four char codes i.e. defined on a uint with constant like 'xxxx'
using AEKeyword = System.UInt32;
using OSType = System.UInt32;
// typedef double NSTimeInterval;
using NSTimeInterval = System.Double;

#if MONOMAC
// dummy usings to make code compile without having the actual types available (for [NoMac] to work)
using NSDirectionalEdgeInsets = Foundation.NSObject;
using UIEdgeInsets = Foundation.NSObject;
using UIOffset = Foundation.NSObject;
using UIPreferredPresentationStyle = Foundation.NSObject;
#else
using NSPasteboard = Foundation.NSObject;
using NSWorkspaceAuthorization = Foundation.NSObject;

using NSStringAttributes = UIKit.UIStringAttributes;
#endif

#if IOS && !__MACCATALYST__
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if TVOS
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if WATCH
// dummy usings to make code compile without having the actual types available (for [NoWatch] to work)
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
using CSSearchableItemAttributeSet = Foundation.NSObject;
#endif

#if WATCH
using CIBarcodeDescriptor = Foundation.NSObject;
#else
using CoreImage;
#endif

#if !IOS
using APActivationPayload = Foundation.NSObject;
#endif

#if __MACCATALYST__
using NSAppleEventSendOptions = Foundation.NSObject;
using NSBezierPath = Foundation.NSObject;
using NSImage = Foundation.NSObject;
#endif

#if IOS || WATCH || TVOS
using NSAppearance = UIKit.UIAppearance;
using NSColor = UIKit.UIColor;
using NSNotificationSuspensionBehavior = Foundation.NSObject;
using NSNotificationFlags = Foundation.NSObject;
using NSTextBlock = Foundation.NSObject;
using NSTextTable = Foundation.NSString; // Different frmo NSTextBlock, because some methods overload on these two types.
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Foundation {
	delegate void NSFilePresenterReacquirer ([BlockCallback] Action reacquirer);
}

namespace Foundation {
	


#if NET
	[BaseType (typeof (NSObject))]
	public class NSAutoreleasePool: NSObject {
		[Export ("init")]
		public extern NSAutoreleasePool ();
	}
#endif



	

	// we follow the API found in swift
	[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	public enum NSAttributedStringNameKey {

		[Field ("NSAlternateDescriptionAttributeName")]
		AlternateDescription,

		[Field ("NSImageURLAttributeName")]
		ImageUrl,

		[Field ("NSInflectionRuleAttributeName")]
		InflectionRule,

		[Field ("NSInflectionAlternativeAttributeName")]
		InflectionAlternative,

		[Field ("NSInlinePresentationIntentAttributeName")]
		InlinePresentationIntent,

		[Field ("NSLanguageIdentifierAttributeName")]
		LanguageIdentifier,

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		[Field ("NSMarkdownSourcePositionAttributeName")]
		MarkdownSourcePosition,

		[Field ("NSMorphologyAttributeName")]
		Morphology,

		[Field ("NSPresentationIntentAttributeName")]
		PresentationIntentAttributeName,

		[Field ("NSReplacementIndexAttributeName")]
		ReplacementIndex,

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("NSInflectionAgreementArgumentAttributeName")]
		InflectionAgreementArgument,

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("NSInflectionAgreementConceptAttributeName")]
		InflectionAgreementConcept,

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("NSInflectionReferentConceptAttributeName")]
		InflectionReferentConcept,

		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSLocalizedNumberFormatAttributeName")]
		LocalizedNumberFormat,
	}

	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	[Native]
	public enum NSGrammaticalCase : long {
		NotSet = 0,
		Nominative,
		Accusative,
		Dative,
		Genitive,
		Prepositional,
		Ablative,
		Adessive,
		Allative,
		Elative,
		Illative,
		Essive,
		Inessive,
		Locative,
		Translative,
	}

	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	[Native]
	public enum NSGrammaticalPronounType : long {
		NotSet = 0,
		Personal,
		Reflexive,
		Possessive,
	}

	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	[Native]
	public enum NSGrammaticalDefiniteness : long {
		NotSet = 0,
		Indefinite,
		Definite,
	}

	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	[Native]
	public enum NSGrammaticalDetermination : long {
		NotSet = 0,
		Independent,
		Dependent,
	}

	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	[Native]
	public enum NSGrammaticalPerson : long {
		NotSet = 0,
		First,
		Second,
		Third,
	}

	[NoWatch]
	[NoTV] // really inside WebKit
	[iOS (13, 0)]
	[MacCatalyst (13, 1)]
	public delegate void NSAttributedStringCompletionHandler ([NullAllowed] NSAttributedString attributedString, [NullAllowed] NSDictionary<NSString, NSObject> attributes, [NullAllowed] NSError error);

	[BaseType (typeof (NSObject),
		   Delegates = new string [] { "WeakDelegate" },
		   Events = new Type [] { typeof (NSCacheDelegate) })]
	interface NSCache {
		[Export ("objectForKey:")]
		NSObject ObjectForKey (NSObject key);

		[Export ("setObject:forKey:")]
		void SetObjectforKey (NSObject obj, NSObject key);

		[Export ("setObject:forKey:cost:")]
		void SetCost (NSObject obj, NSObject key, nuint cost);

		[Export ("removeObjectForKey:")]
		void RemoveObjectForKey (NSObject key);

		[Export ("removeAllObjects")]
		void RemoveAllObjects ();

		//Detected properties
		[Export ("name")]
		string Name { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSCacheDelegate Delegate { get; set; }

		[Export ("totalCostLimit")]
		nuint TotalCostLimit { get; set; }

		[Export ("countLimit")]
		nuint CountLimit { get; set; }

		[Export ("evictsObjectsWithDiscardedContent")]
		bool EvictsObjectsWithDiscardedContent { get; set; }
	}

	interface INSCacheDelegate { }

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSCacheDelegate {
		[Export ("cache:willEvictObject:"), EventArgs ("NSObject")]
		void WillEvictObject (NSCache cache, NSObject obj);
	}

	[BaseType (typeof (NSObject), Name = "NSCachedURLResponse")]
	// instance created with 'init' will crash when Dispose is called
	[DisableDefaultCtor]
	public partial class NSCachedUrlResponse : NSCopying {
		[Export ("initWithResponse:data:userInfo:storagePolicy:")]
		extern NativeHandle Constructor (NSUrlResponse response, NSData data, [NullAllowed] NSDictionary userInfo, NSUrlCacheStoragePolicy storagePolicy);

		[Export ("initWithResponse:data:")]
		extern NativeHandle Constructor (NSUrlResponse response, NSData data);

		[Export ("response")]
		NSUrlResponse Response { get; }

		[Export ("data")]
		NSData Data { get; }

		[Export ("userInfo")]
		NSDictionary UserInfo { get; }

		[Export ("storagePolicy")]
		NSUrlCacheStoragePolicy StoragePolicy { get; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public partial class NSCalendar :  NSCopying {
		[DesignatedInitializer]
		[Export ("initWithCalendarIdentifier:")]
		public extern NativeHandle Constructor (NSString identifier);

		[Export ("calendarIdentifier")]
		public extern string Identifier { get; }

		[Export ("currentCalendar")]
		[Static]
		public static extern NSCalendar CurrentCalendar { get; }

		[Export ("locale", ArgumentSemantic.Copy)]
		public extern NSLocale Locale { get; set; }

		[Export ("timeZone", ArgumentSemantic.Copy)]
		public extern NSTimeZone TimeZone { get; set; }

		[Export ("firstWeekday")]
		public extern nuint FirstWeekDay { get; set; }

		[Export ("minimumDaysInFirstWeek")]
		public extern nuint MinimumDaysInFirstWeek { get; set; }

		[Export ("components:fromDate:")]
		public extern NSDateComponents Components (NSCalendarUnit unitFlags, NSDate fromDate);

		[Export ("components:fromDate:toDate:options:")]
		public extern NSDateComponents Components (NSCalendarUnit unitFlags, NSDate fromDate, NSDate toDate, NSCalendarOptions opts);

#if !NET
		[Obsolete ("Use the overload with a 'NSCalendarOptions' parameter.")]
		[Wrap ("Components (unitFlags, fromDate, toDate, (NSCalendarOptions) opts)")]
		public extern NSDateComponents Components (NSCalendarUnit unitFlags, NSDate fromDate, NSDate toDate, NSDateComponentsWrappingBehavior opts);
#endif

		[Export ("dateByAddingComponents:toDate:options:")]
		public extern NSDate DateByAddingComponents (NSDateComponents comps, NSDate date, NSCalendarOptions opts);

#if !NET
		[Obsolete ("Use the overload with a 'NSCalendarOptions' parameter.")]
		[Wrap ("DateByAddingComponents (comps, date, (NSCalendarOptions) opts)")]
		public extern NSDate DateByAddingComponents (NSDateComponents comps, NSDate date, NSDateComponentsWrappingBehavior opts);
#endif

		[Export ("dateFromComponents:")]
		public extern NSDate DateFromComponents (NSDateComponents comps);

		[Field ("NSCalendarIdentifierGregorian"), Internal]
		public static extern NSString NSGregorianCalendar { get; }

		[Field ("NSCalendarIdentifierBuddhist"), Internal]
		public static extern NSString NSBuddhistCalendar { get; }

		[Field ("NSCalendarIdentifierChinese"), Internal]
		public static extern NSString NSChineseCalendar { get; }

		[Field ("NSCalendarIdentifierHebrew"), Internal]
		public static extern NSString NSHebrewCalendar { get; }

		[Field ("NSIslamicCalendar"), Internal]
		public static extern NSString NSIslamicCalendar { get; }

		[Field ("NSCalendarIdentifierIslamicCivil"), Internal]
		public static extern NSString NSIslamicCivilCalendar { get; }

		[Field ("NSCalendarIdentifierJapanese"), Internal]
		public static extern NSString NSJapaneseCalendar { get; }

		[Field ("NSCalendarIdentifierRepublicOfChina"), Internal]
		public static extern NSString NSRepublicOfChinaCalendar { get; }

		[Field ("NSCalendarIdentifierPersian"), Internal]
		public static extern NSString NSPersianCalendar { get; }

		[Field ("NSCalendarIdentifierIndian"), Internal]
		public static extern NSString NSIndianCalendar { get; }

		[Field ("NSCalendarIdentifierISO8601"), Internal]
		public static extern NSString NSISO8601Calendar { get; }

		[Field ("NSCalendarIdentifierCoptic"), Internal]
		public static extern NSString CopticCalendar { get; }

		[Field ("NSCalendarIdentifierEthiopicAmeteAlem"), Internal]
		public static extern NSString EthiopicAmeteAlemCalendar { get; }

		[Field ("NSCalendarIdentifierEthiopicAmeteMihret"), Internal]
		public static extern NSString EthiopicAmeteMihretCalendar { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSCalendarIdentifierIslamicTabular"), Internal]
		public static extern NSString IslamicTabularCalendar { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSCalendarIdentifierIslamicUmmAlQura"), Internal]
		public static extern NSString IslamicUmmAlQuraCalendar { get; }

		[Export ("eraSymbols")]
		public static extern string [] EraSymbols { get; }

		[Export ("longEraSymbols")]
		public static extern string [] LongEraSymbols { get; }

		[Export ("monthSymbols")]
		public static extern string [] MonthSymbols { get; }

		[Export ("shortMonthSymbols")]
		public static extern string [] ShortMonthSymbols { get; }

		[Export ("veryShortMonthSymbols")]
		public static extern string [] VeryShortMonthSymbols { get; }

		[Export ("standaloneMonthSymbols")]
		public static extern string [] StandaloneMonthSymbols { get; }

		[Export ("shortStandaloneMonthSymbols")]
		public static extern string [] ShortStandaloneMonthSymbols { get; }

		[Export ("veryShortStandaloneMonthSymbols")]
		public static extern string [] VeryShortStandaloneMonthSymbols { get; }

		[Export ("weekdaySymbols")]
		public static extern string [] WeekdaySymbols { get; }

		[Export ("shortWeekdaySymbols")]
		public static extern string [] ShortWeekdaySymbols { get; }

		[Export ("veryShortWeekdaySymbols")]
		public static extern string [] VeryShortWeekdaySymbols { get; }

		[Export ("standaloneWeekdaySymbols")]
		public static extern string [] StandaloneWeekdaySymbols { get; }

		[Export ("shortStandaloneWeekdaySymbols")]
		public static extern string [] ShortStandaloneWeekdaySymbols { get; }

		[Export ("veryShortStandaloneWeekdaySymbols")]
		public static extern string [] VeryShortStandaloneWeekdaySymbols { get; }

		[Export ("quarterSymbols")]
		public static extern string [] QuarterSymbols { get; }

		[Export ("shortQuarterSymbols")]
		public static extern string [] ShortQuarterSymbols { get; }

		[Export ("standaloneQuarterSymbols")]
		public static extern string [] StandaloneQuarterSymbols { get; }

		[Export ("shortStandaloneQuarterSymbols")]
		public static extern string [] ShortStandaloneQuarterSymbols { get; }

		[Export ("AMSymbol")]
		public static extern string AMSymbol { get; }

		[Export ("PMSymbol")]
		public static extern string PMSymbol { get; }

		[Export ("compareDate:toDate:toUnitGranularity:")]
		[MacCatalyst (13, 1)]
		public static extern NSComparisonResult CompareDate (NSDate date1, NSDate date2, NSCalendarUnit granularity);

		[Export ("component:fromDate:")]
		[MacCatalyst (13, 1)]
		public static extern nint GetComponentFromDate (NSCalendarUnit unit, NSDate date);

		[Export ("components:fromDateComponents:toDateComponents:options:")]
		[MacCatalyst (13, 1)]
		public static extern NSDateComponents ComponentsFromDateToDate (NSCalendarUnit unitFlags, NSDateComponents startingDate, NSDateComponents resultDate, NSCalendarOptions options);

		[Export ("componentsInTimeZone:fromDate:")]
		[MacCatalyst (13, 1)]
		public static extern NSDateComponents ComponentsInTimeZone (NSTimeZone timezone, NSDate date);

		[Export ("date:matchesComponents:")]
		[MacCatalyst (13, 1)]
		public extern bool Matches (NSDate date, NSDateComponents components);

		[Export ("dateByAddingUnit:value:toDate:options:")]
		[MacCatalyst (13, 1)]
		public extern NSDate DateByAddingUnit (NSCalendarUnit unit, nint value, NSDate date, NSCalendarOptions options);

		[Export ("dateBySettingHour:minute:second:ofDate:options:")]
		[MacCatalyst (13, 1)]
		public extern NSDate DateBySettingsHour (nint hour, nint minute, nint second, NSDate date, NSCalendarOptions options);

		[Export ("dateBySettingUnit:value:ofDate:options:")]
		[MacCatalyst (13, 1)]
		public extern NSDate DateBySettingUnit (NSCalendarUnit unit, nint value, NSDate date, NSCalendarOptions options);

		[Export ("dateWithEra:year:month:day:hour:minute:second:nanosecond:")]
		[MacCatalyst (13, 1)]
		public extern NSDate Date (nint era, nint year, nint month, nint date, nint hour, nint minute, nint second, nint nanosecond);

		[Export ("dateWithEra:yearForWeekOfYear:weekOfYear:weekday:hour:minute:second:nanosecond:")]
		[MacCatalyst (13, 1)]
		public extern NSDate DateForWeekOfYear (nint era, nint year, nint week, nint weekday, nint hour, nint minute, nint second, nint nanosecond);

		[Export ("enumerateDatesStartingAfterDate:matchingComponents:options:usingBlock:")]
		[MacCatalyst (13, 1)]
		public extern void EnumerateDatesStartingAfterDate (NSDate start, NSDateComponents matchingComponents, NSCalendarOptions options, [BlockCallback] EnumerateDatesCallback callback);

		[Export ("getEra:year:month:day:fromDate:")]
		[MacCatalyst (13, 1)]
		public extern void GetComponentsFromDate (out nint era, out nint year, out nint month, out nint day, NSDate date);

		[Export ("getEra:yearForWeekOfYear:weekOfYear:weekday:fromDate:")]
		[MacCatalyst (13, 1)]
		public extern void GetComponentsFromDateForWeekOfYear (out nint era, out nint year, out nint weekOfYear, out nint weekday, NSDate date);

		[Export ("getHour:minute:second:nanosecond:fromDate:")]
		[MacCatalyst (13, 1)]
		public extern void GetHourComponentsFromDate (out nint hour, out nint minute, out nint second, out nint nanosecond, NSDate date);

		[Export ("isDate:equalToDate:toUnitGranularity:")]
		[MacCatalyst (13, 1)]
		public extern bool IsEqualToUnitGranularity (NSDate date1, NSDate date2, NSCalendarUnit unit);

		[Export ("isDate:inSameDayAsDate:")]
		[MacCatalyst (13, 1)]
		public extern bool IsInSameDay (NSDate date1, NSDate date2);

		[Export ("isDateInToday:")]
		[MacCatalyst (13, 1)]
		public extern bool IsDateInToday (NSDate date);

		[Export ("isDateInTomorrow:")]
		[MacCatalyst (13, 1)]
		public extern bool IsDateInTomorrow (NSDate date);

		[Export ("isDateInWeekend:")]
		[MacCatalyst (13, 1)]
		public extern bool IsDateInWeekend (NSDate date);

		[Export ("isDateInYesterday:")]
		[MacCatalyst (13, 1)]
		public extern bool IsDateInYesterday (NSDate date);

		[Export ("nextDateAfterDate:matchingComponents:options:")]
		[MacCatalyst (13, 1)]
		[MarshalNativeExceptions]
		[return: NullAllowed]
		public extern NSDate FindNextDateAfterDateMatching (NSDate date, NSDateComponents components, NSCalendarOptions options);

		[Export ("nextDateAfterDate:matchingHour:minute:second:options:")]
		[MacCatalyst (13, 1)]
		[MarshalNativeExceptions]
		[return: NullAllowed]
		public extern NSDate FindNextDateAfterDateMatching (NSDate date, nint hour, nint minute, nint second, NSCalendarOptions options);

		[Export ("nextDateAfterDate:matchingUnit:value:options:")]
		[MacCatalyst (13, 1)]
		[MarshalNativeExceptions]
		[return: NullAllowed]
		public extern NSDate FindNextDateAfterDateMatching (NSDate date, NSCalendarUnit unit, nint value, NSCalendarOptions options);

		[Export ("nextWeekendStartDate:interval:options:afterDate:")]
		[MacCatalyst (13, 1)]
		public extern bool FindNextWeekend (out NSDate date, out double /* NSTimeInterval */ interval, NSCalendarOptions options, NSDate afterDate);

		[Export ("rangeOfWeekendStartDate:interval:containingDate:")]
		[MacCatalyst (13, 1)]
		public extern bool RangeOfWeekendContainingDate (out NSDate weekendStartDate, out double /* NSTimeInterval */ interval, NSDate date);

		// although the ideal would be to use GetRange, we already have the method
		// RangeOfWeekendContainingDate and for the sake of consistency we are 
		// going to use the same name pattern.
		[Export ("minimumRangeOfUnit:")]
		public extern NSRange MinimumRange (NSCalendarUnit unit);

		[Export ("maximumRangeOfUnit:")]
		public extern NSRange MaximumRange (NSCalendarUnit unit);

		[Export ("rangeOfUnit:inUnit:forDate:")]
		public extern NSRange Range (NSCalendarUnit smaller, NSCalendarUnit larger, NSDate date);

		[Export ("ordinalityOfUnit:inUnit:forDate:")]
		public extern nuint Ordinality (NSCalendarUnit smaller, NSCalendarUnit larger, NSDate date);

		[Export ("rangeOfUnit:startDate:interval:forDate:")]
		public extern bool Range (NSCalendarUnit unit, [NullAllowed] out NSDate datep, out double /* NSTimeInterval */ interval, NSDate date);

		[Export ("startOfDayForDate:")]
		[MacCatalyst (13, 1)]
		public extern NSDate StartOfDayForDate (NSDate date);

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSCalendarDayChangedNotification")]
		public extern NSString DayChangedNotification { get; }
	}

	// Obsolete, but the only API surfaced by WebKit.WebHistory.
	[Deprecated (PlatformName.MacOSX, 10, 1, message: "Use NSCalendar and NSDateComponents.")]
	[NoiOS]
	[NoMacCatalyst]
	[NoWatch]
	[NoTV]
	[BaseType (typeof (NSDate))]
	partial class NSCalendarDate : NSDate {
		[Export ("initWithString:calendarFormat:locale:")]
		[Deprecated (PlatformName.MacOSX, 10, 0)]
		extern NativeHandle Constructor (string description, string calendarFormat, [NullAllowed] NSObject locale);

		[Export ("initWithString:calendarFormat:")]
		[Deprecated (PlatformName.MacOSX, 10, 0)]
		extern NativeHandle Constructor (string description, string calendarFormat);

		[Export ("initWithString:")]
		[Deprecated (PlatformName.MacOSX, 10, 0)]
		extern NativeHandle Constructor (string description);

		[Export ("initWithYear:month:day:hour:minute:second:timeZone:")]
		[Deprecated (PlatformName.MacOSX, 10, 0)]
		extern NativeHandle Constructor (nint year, nuint month, nuint day, nuint hour, nuint minute, nuint second, [NullAllowed] NSTimeZone aTimeZone);

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("dateByAddingYears:months:days:hours:minutes:seconds:")]
		extern NSCalendarDate DateByAddingYears (nint year, nint month, nint day, nint hour, nint minute, nint second);

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("dayOfCommonEra")]
		nint DayOfCommonEra { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("dayOfMonth")]
		nint DayOfMonth { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("dayOfWeek")]
		nint DayOfWeek { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("dayOfYear")]
		nint DayOfYear { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("hourOfDay")]
		nint HourOfDay { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("minuteOfHour")]
		nint MinuteOfHour { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("monthOfYear")]
		nint MonthOfYear { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("secondOfMinute")]
		nint SecondOfMinute { get; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("yearOfCommonEra")]
		nint YearOfCommonEra { get; }

		[NullAllowed]
		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("calendarFormat")]
		string CalendarFormat { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("descriptionWithCalendarFormat:locale:")]
		extern string GetDescription (string calendarFormat, [NullAllowed] NSObject locale);

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("descriptionWithCalendarFormat:")]
		extern string GetDescription (string calendarFormat);

		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("descriptionWithLocale:")]
		extern string GetDescription ([NullAllowed] NSLocale locale);

		[NullAllowed]
		[Deprecated (PlatformName.MacOSX, 10, 0)]
		[Export ("timeZone")]
		NSTimeZone TimeZone { get; set; }
	}

	

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	interface NSMassFormatter {
		[Export ("numberFormatter", ArgumentSemantic.Copy)]
		NSNumberFormatter NumberFormatter { get; set; }

		[Export ("unitStyle")]
		NSFormattingUnitStyle UnitStyle { get; set; }

		[Export ("forPersonMassUse")]
		bool ForPersonMassUse { [Bind ("isForPersonMassUse")] get; set; }

		[Export ("stringFromValue:unit:")]
		string StringFromValue (double value, NSMassFormatterUnit unit);

		[Export ("stringFromKilograms:")]
		string StringFromKilograms (double numberInKilograms);

		[Export ("unitStringFromValue:unit:")]
		string UnitStringFromValue (double value, NSMassFormatterUnit unit);

		[Export ("unitStringFromKilograms:usedUnit:")]
		string UnitStringFromKilograms (double numberInKilograms, ref NSMassFormatterUnit unitp);

		[Export ("getObjectValue:forString:errorDescription:")]
		bool GetObjectValue (out NSObject obj, string str, out string error);
	}

	[BaseType (typeof (NSCharacterSet))]
	interface NSMutableCharacterSet {
		[Export ("addCharactersInRange:")]
		void AddCharacters (NSRange aRange);

		[Export ("removeCharactersInRange:")]
		void RemoveCharacters (NSRange aRange);

		[Export ("addCharactersInString:")]
#if MONOMAC && !NET
		void AddCharacters (string str);
#else
		void AddCharacters (NSString str);
#endif

		[Export ("removeCharactersInString:")]
#if MONOMAC && !NET
		void RemoveCharacters (string str);
#else
		void RemoveCharacters (NSString str);
#endif

		[Export ("formUnionWithCharacterSet:")]
		void UnionWith (NSCharacterSet otherSet);

		[Export ("formIntersectionWithCharacterSet:")]
		void IntersectWith (NSCharacterSet otherSet);

		[Export ("invert")]
		void Invert ();

		[MacCatalyst (13, 1)]
		[Static, Export ("alphanumericCharacterSet")]
		NSCharacterSet Alphanumerics { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("capitalizedLetterCharacterSet")]
		NSCharacterSet Capitalized { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("characterSetWithBitmapRepresentation:")]
		NSCharacterSet FromBitmapRepresentation (NSData data);

		[MacCatalyst (13, 1)]
		[Static, Export ("characterSetWithCharactersInString:")]
		NSCharacterSet FromString (string aString);

		[return: NullAllowed]
		[MacCatalyst (13, 1)]
		[Static, Export ("characterSetWithContentsOfFile:")]
		NSCharacterSet FromFile (string path);

		[MacCatalyst (13, 1)]
		[Static, Export ("characterSetWithRange:")]
		NSCharacterSet FromRange (NSRange aRange);

		[MacCatalyst (13, 1)]
		[Static, Export ("controlCharacterSet")]
		NSCharacterSet Controls { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("decimalDigitCharacterSet")]
		NSCharacterSet DecimalDigits { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("decomposableCharacterSet")]
		NSCharacterSet Decomposables { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("illegalCharacterSet")]
		NSCharacterSet Illegals { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("letterCharacterSet")]
		NSCharacterSet Letters { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("lowercaseLetterCharacterSet")]
		NSCharacterSet LowercaseLetters { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("newlineCharacterSet")]
		NSCharacterSet Newlines { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("nonBaseCharacterSet")]
		NSCharacterSet Marks { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("punctuationCharacterSet")]
		NSCharacterSet Punctuation { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("symbolCharacterSet")]
		NSCharacterSet Symbols { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("uppercaseLetterCharacterSet")]
		NSCharacterSet UppercaseLetters { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("whitespaceAndNewlineCharacterSet")]
		NSCharacterSet WhitespaceAndNewlines { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("whitespaceCharacterSet")]
		NSCharacterSet Whitespaces { get; }
	}

	

	[BaseType (typeof (NSPredicate))]
	partial class NSComparisonPredicate : NSPredicate {
		[Static, Export ("predicateWithLeftExpression:rightExpression:modifier:type:options:")]
		static extern NSComparisonPredicate Create (NSExpression leftExpression, NSExpression rightExpression, NSComparisonPredicateModifier comparisonModifier, NSPredicateOperatorType operatorType, NSComparisonPredicateOptions comparisonOptions);

		[Static, Export ("predicateWithLeftExpression:rightExpression:customSelector:")]
		static extern NSComparisonPredicate FromSelector (NSExpression leftExpression, NSExpression rightExpression, Selector selector);

		[DesignatedInitializer]
		[Export ("initWithLeftExpression:rightExpression:modifier:type:options:")]
		extern NativeHandle Constructor (NSExpression leftExpression, NSExpression rightExpression, NSComparisonPredicateModifier comparisonModifier, NSPredicateOperatorType operatorType, NSComparisonPredicateOptions comparisonOptions);

		[DesignatedInitializer]
		[Export ("initWithLeftExpression:rightExpression:customSelector:")]
		extern NativeHandle Constructor (NSExpression leftExpression, NSExpression rightExpression, Selector selector);

		[Export ("predicateOperatorType")]
		NSPredicateOperatorType PredicateOperatorType { get; }

		[Export ("comparisonPredicateModifier")]
		NSComparisonPredicateModifier ComparisonPredicateModifier { get; }

		[Export ("leftExpression")]
		NSExpression LeftExpression { get; }

		[Export ("rightExpression")]
		NSExpression RightExpression { get; }

		[NullAllowed]
		[Export ("customSelector")]
		Selector CustomSelector { get; }

		[Export ("options")]
		NSComparisonPredicateOptions Options { get; }
	}

	[BaseType (typeof (NSPredicate))]
	[DisableDefaultCtor] // An uncaught exception was raised: Can't have a NOT predicate with no subpredicate.
	partial class NSCompoundPredicate : NSPredicate {
		[DesignatedInitializer]
		[Export ("initWithType:subpredicates:")]
		extern NativeHandle Constructor (NSCompoundPredicateType type, NSPredicate [] subpredicates);

		[Export ("compoundPredicateType")]
		NSCompoundPredicateType Type { get; }

		[Export ("subpredicates")]
		NSPredicate [] Subpredicates { get; }

		[Static]
		[Export ("andPredicateWithSubpredicates:")]
		static extern NSCompoundPredicate CreateAndPredicate (NSPredicate [] subpredicates);

		[Static]
		[Export ("orPredicateWithSubpredicates:")]
		static extern NSCompoundPredicate CreateOrPredicate (NSPredicate [] subpredicates);

		[Static]
		[Export ("notPredicateWithSubpredicate:")]
		static extern NSCompoundPredicate CreateNotPredicate (NSPredicate predicate);

	}

	public delegate void NSDataByteRangeEnumerator (IntPtr bytes, NSRange range, ref bool stop);

	[BaseType (typeof (NSObject))]
	public partial class NSData :  NSMutableCopying {
		[Export ("dataWithContentsOfURL:")]
		[Static]
		public static extern NSData FromUrl (NSUrl url);

		[Export ("dataWithContentsOfURL:options:error:")]
		[Static]
		public static extern NSData FromUrl (NSUrl url, NSDataReadingOptions mask, out NSError error);

		[Export ("dataWithContentsOfFile:")]
		[Static]
		public static extern NSData FromFile (string path);

		[Export ("dataWithContentsOfFile:options:error:")]
		[Static]
		public static extern NSData FromFile (string path, NSDataReadingOptions mask, out NSError error);

		[Export ("dataWithData:")]
		[Static]
		public static extern NSData FromData (NSData source);

		[Export ("dataWithBytes:length:"), Static]
		public static extern NSData FromBytes (IntPtr bytes, nuint size);

		[Export ("dataWithBytesNoCopy:length:"), Static]
		public static extern NSData FromBytesNoCopy (IntPtr bytes, nuint size);

		[Export ("dataWithBytesNoCopy:length:freeWhenDone:"), Static]
		public static extern NSData FromBytesNoCopy (IntPtr bytes, nuint size, bool freeWhenDone);

		[Export ("bytes")]
		public extern IntPtr Bytes { get; }

		[Export ("length")]
		public extern nuint Length { get; [NotImplemented ("Not available on NSData, only available on NSMutableData")] set; }

		[Export ("writeToFile:options:error:")]
		[Internal]
		internal extern bool _Save (string file, nint options, IntPtr addr);

		[Export ("writeToURL:options:error:")]
		[Internal]
		internal extern bool  _Save (NSUrl url, nint options, IntPtr addr);

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use 'Save (NSUrl,bool)' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'Save (NSUrl,bool)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'Save (NSUrl,bool)' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "Use 'Save (NSUrl,bool)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Save (NSUrl,bool)' instead.")]
		[Export ("writeToFile:atomically:")]
		public extern bool Save (string path, bool atomically);

		[Export ("writeToURL:atomically:")]
		public extern bool Save (NSUrl url, bool atomically);

		[Export ("subdataWithRange:")]
		public extern NSData Subdata (NSRange range);

		[Export ("getBytes:length:")]
		public extern void GetBytes (IntPtr buffer, nuint length);

		[Export ("getBytes:range:")]
		public extern void GetBytes (IntPtr buffer, NSRange range);

		[Export ("rangeOfData:options:range:")]
		public extern NSRange Find (NSData dataToFind, NSDataSearchOptions searchOptions, NSRange searchRange);

		[MacCatalyst (13, 1)]
		[Export ("initWithBase64EncodedString:options:")]
		public extern NativeHandle Constructor (string base64String, NSDataBase64DecodingOptions options);

		[MacCatalyst (13, 1)]
		[Export ("initWithBase64EncodedData:options:")]
		public extern NativeHandle Constructor (NSData base64Data, NSDataBase64DecodingOptions options);

		[MacCatalyst (13, 1)]
		[Export ("base64EncodedDataWithOptions:")]
		public extern NSData GetBase64EncodedData (NSDataBase64EncodingOptions options);

		[MacCatalyst (13, 1)]
		[Export ("base64EncodedStringWithOptions:")]
		public extern string GetBase64EncodedString (NSDataBase64EncodingOptions options);

		[MacCatalyst (13, 1)]
		[Export ("enumerateByteRangesUsingBlock:")]
		public extern void EnumerateByteRange (NSDataByteRangeEnumerator enumerator);

		[MacCatalyst (13, 1)]
		[Export ("initWithBytesNoCopy:length:deallocator:")]
		public extern NativeHandle Constructor (IntPtr bytes, nuint length, [NullAllowed] Action<IntPtr, nuint> deallocator);

		// NSDataCompression (NSData)

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("decompressedDataUsingAlgorithm:error:")]
		[return: NullAllowed]
		public extern NSData Decompress (NSDataCompressionAlgorithm algorithm, [NullAllowed] out NSError error);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("compressedDataUsingAlgorithm:error:")]
		[return: NullAllowed]
		public extern NSData Compress (NSDataCompressionAlgorithm algorithm, [NullAllowed] out NSError error);
	}

	[BaseType (typeof (NSRegularExpression))]
	partial class NSDataDetector : NSCopying {
		[DesignatedInitializer]
		[Export ("initWithTypes:error:")]
		extern NativeHandle Constructor (NSTextCheckingTypes options, out NSError error);

		[Wrap ("this ((NSTextCheckingTypes) options, out error)")]
		extern NativeHandle Constructor (NSTextCheckingType options, out NSError error);

		[Export ("dataDetectorWithTypes:error:"), Static]
		extern NSDataDetector Create (NSTextCheckingTypes checkingTypes, out NSError error);

		[Static]
		[Wrap ("Create ((NSTextCheckingTypes) checkingTypes, out error)")]
		extern NSDataDetector Create (NSTextCheckingType checkingTypes, out NSError error);

		[Export ("checkingTypes")]
		NSTextCheckingTypes CheckingTypes { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial class NSDateComponents :  NSCopying, INSSecureCoding, INativeObject {
		[NullAllowed] // by default this property is null
		[Export ("timeZone", ArgumentSemantic.Copy)]
		public extern NSTimeZone TimeZone { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("calendar", ArgumentSemantic.Copy)]
		public extern NSCalendar Calendar { get; set; }

		[Export ("quarter")]
		public extern nint Quarter { get; set; }

		[Export ("date")]
		public extern NSDate Date { get; }

		//Detected properties
		[Export ("era")]
		public extern nint Era { get; set; }

		[Export ("year")]
		public extern nint Year { get; set; }

		[Export ("month")]
		public extern nint Month { get; set; }

		[Export ("day")]
		public extern nint Day { get; set; }

		[Export ("hour")]
		public extern nint Hour { get; set; }

		[Export ("minute")]
		public extern nint Minute { get; set; }

		[Export ("second")]
		public extern nint Second { get; set; }

		[Export ("nanosecond")]
		public extern nint Nanosecond { get; set; }

		[Export ("week")]
		//[Deprecated (PlatformName.MacOSX, 10, 9, message: "Use 'WeekOfMonth' or 'WeekOfYear' instead.")]
		//[Deprecated (PlatformName.iOS, 7, 0, message: "Use 'WeekOfMonth' or 'WeekOfYear' instead.")]
		//[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'WeekOfMonth' or 'WeekOfYear' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'WeekOfMonth' or 'WeekOfYear' instead.")]
		public extern nint Week { get; set; }

		[Export ("weekday")]
		public extern nint Weekday { get; set; }

		[Export ("weekdayOrdinal")]
		public extern nint WeekdayOrdinal { get; set; }

		[Export ("weekOfMonth")]
		public extern nint WeekOfMonth { get; set; }

		[Export ("weekOfYear")]
		public extern nint WeekOfYear { get; set; }

		[Export ("yearForWeekOfYear")]
		public extern nint YearForWeekOfYear { get; set; }

		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("dayOfYear")]
		public extern nint DayOfYear { get; set; }

		[Export ("leapMonth")]
		public extern bool IsLeapMonth { [Bind ("isLeapMonth")] get; set; }

		[Export ("isValidDate")]
		[MacCatalyst (13, 1)]
		public extern bool IsValidDate { get; }

		[Export ("isValidDateInCalendar:")]
		[MacCatalyst (13, 1)]
		public extern bool IsValidDateInCalendar (NSCalendar calendar);

		[Export ("setValue:forComponent:")]
		[MacCatalyst (13, 1)]
		public extern void SetValueForComponent (nint value, NSCalendarUnit unit);

		[Export ("valueForComponent:")]
		[MacCatalyst (13, 1)]
		public extern nint GetValueForComponent (NSCalendarUnit unit);
	}

	[BaseType (typeof (NSFormatter))]
	partial class NSByteCountFormatter: NSFormatter {
		[Export ("allowsNonnumericFormatting")]
		bool AllowsNonnumericFormatting { get; set; }

		[Export ("includesUnit")]
		bool IncludesUnit { get; set; }

		[Export ("includesCount")]
		bool IncludesCount { get; set; }

		[Export ("includesActualByteCount")]
		bool IncludesActualByteCount { get; set; }

		[Export ("adaptive")]
		bool Adaptive { [Bind ("isAdaptive")] get; set; }

		[Export ("zeroPadsFractionDigits")]
		bool ZeroPadsFractionDigits { get; set; }

		[Static]
		[Export ("stringFromByteCount:countStyle:")]
		static extern string Format (long byteCount, NSByteCountFormatterCountStyle countStyle);

		[Export ("stringFromByteCount:")]
		extern string Format (long byteCount);

		[Export ("allowedUnits")]
		NSByteCountFormatterUnits AllowedUnits { get; set; }

		[Export ("countStyle")]
		NSByteCountFormatterCountStyle CountStyle { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("formattingContext")]
		NSFormattingContext FormattingContext { get; set; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("stringForObjectValue:")]
		[return: NullAllowed]
		extern string GetString ([NullAllowed] NSObject obj);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("stringFromMeasurement:countStyle:")]
		extern string Create (NSUnitInformationStorage measurement, NSByteCountFormatterCountStyle countStyle);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("stringFromMeasurement:")]
		extern string Create (NSUnitInformationStorage measurement);
	}

	[BaseType (typeof (NSFormatter))]
	partial class NSDateFormatter: NSFormatter {
		[Export ("stringFromDate:")]
		extern string ToString (NSDate date);

		[Export ("dateFromString:")]
		extern NSDate Parse (string date);

		[Export ("dateFormat")]
		string DateFormat { get; set; }

		[Export ("dateStyle")]
		NSDateFormatterStyle DateStyle { get; set; }

		[Export ("timeStyle")]
		NSDateFormatterStyle TimeStyle { get; set; }

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[Export ("generatesCalendarDates")]
		bool GeneratesCalendarDates { get; set; }

		[Export ("formatterBehavior")]
		NSDateFormatterBehavior Behavior { get; set; }

		[Export ("defaultFormatterBehavior"), Static]
		NSDateFormatterBehavior DefaultBehavior { get; set; }

		[Export ("timeZone", ArgumentSemantic.Copy)]
		NSTimeZone TimeZone { get; set; }

		[Export ("calendar", ArgumentSemantic.Copy)]
		NSCalendar Calendar { get; set; }

		// not exposed as a property in documentation
		[Export ("isLenient")]
		bool IsLenient { get; [Bind ("setLenient:")] set; }

		[Export ("twoDigitStartDate", ArgumentSemantic.Copy)]
		NSDate TwoDigitStartDate { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("defaultDate", ArgumentSemantic.Copy)]
		NSDate DefaultDate { get; set; }

		[Export ("eraSymbols")]
		string [] EraSymbols { get; set; }

		[Export ("monthSymbols")]
		string [] MonthSymbols { get; set; }

		[Export ("shortMonthSymbols")]
		string [] ShortMonthSymbols { get; set; }

		[Export ("weekdaySymbols")]
		string [] WeekdaySymbols { get; set; }

		[Export ("shortWeekdaySymbols")]
		string [] ShortWeekdaySymbols { get; set; }

		[Export ("AMSymbol")]
		string AMSymbol { get; set; }

		[Export ("PMSymbol")]
		string PMSymbol { get; set; }

		[Export ("longEraSymbols")]
		string [] LongEraSymbols { get; set; }

		[Export ("veryShortMonthSymbols")]
		string [] VeryShortMonthSymbols { get; set; }

		[Export ("standaloneMonthSymbols")]
		string [] StandaloneMonthSymbols { get; set; }

		[Export ("shortStandaloneMonthSymbols")]
		string [] ShortStandaloneMonthSymbols { get; set; }

		[Export ("veryShortStandaloneMonthSymbols")]
		string [] VeryShortStandaloneMonthSymbols { get; set; }

		[Export ("veryShortWeekdaySymbols")]
		string [] VeryShortWeekdaySymbols { get; set; }

		[Export ("standaloneWeekdaySymbols")]
		string [] StandaloneWeekdaySymbols { get; set; }

		[Export ("shortStandaloneWeekdaySymbols")]
		string [] ShortStandaloneWeekdaySymbols { get; set; }

		[Export ("veryShortStandaloneWeekdaySymbols")]
		string [] VeryShortStandaloneWeekdaySymbols { get; set; }

		[Export ("quarterSymbols")]
		string [] QuarterSymbols { get; set; }

		[Export ("shortQuarterSymbols")]
		string [] ShortQuarterSymbols { get; set; }

		[Export ("standaloneQuarterSymbols")]
		string [] StandaloneQuarterSymbols { get; set; }

		[Export ("shortStandaloneQuarterSymbols")]
		string [] ShortStandaloneQuarterSymbols { get; set; }

		[Export ("gregorianStartDate", ArgumentSemantic.Copy)]
		NSDate GregorianStartDate { get; set; }

		[Export ("localizedStringFromDate:dateStyle:timeStyle:")]
		[Static]
		static extern string ToLocalizedString (NSDate date, NSDateFormatterStyle dateStyle, NSDateFormatterStyle timeStyle);

		[Export ("dateFormatFromTemplate:options:locale:")]
		[Static]
		static extern string GetDateFormatFromTemplate (string template, nuint options, [NullAllowed] NSLocale locale);

		[Export ("doesRelativeDateFormatting")]
		bool DoesRelativeDateFormatting { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("setLocalizedDateFormatFromTemplate:")]
		extern void SetLocalizedDateFormatFromTemplate (string dateFormatTemplate);

		[MacCatalyst (13, 1)]
		[Export ("formattingContext", ArgumentSemantic.Assign)]
		NSFormattingContext FormattingContext { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSDateComponentsFormatter: NSFormatter {
		[Export ("unitsStyle")]
		NSDateComponentsFormatterUnitsStyle UnitsStyle { get; set; }

		[Export ("allowedUnits")]
		NSCalendarUnit AllowedUnits { get; set; }

		[Export ("zeroFormattingBehavior")]
		NSDateComponentsFormatterZeroFormattingBehavior ZeroFormattingBehavior { get; set; }

		[Export ("calendar", ArgumentSemantic.Copy)]
		NSCalendar Calendar { get; set; }

		[Export ("allowsFractionalUnits")]
		bool AllowsFractionalUnits { get; set; }

		[Export ("maximumUnitCount")]
		nint MaximumUnitCount { get; set; }

		[Export ("collapsesLargestUnit")]
		bool CollapsesLargestUnit { get; set; }

		[Export ("includesApproximationPhrase")]
		bool IncludesApproximationPhrase { get; set; }

		[Export ("includesTimeRemainingPhrase")]
		bool IncludesTimeRemainingPhrase { get; set; }

		[Export ("formattingContext")]
		NSFormattingContext FormattingContext { get; set; }

		[Export ("stringForObjectValue:")]
		extern string StringForObjectValue ([NullAllowed] NSObject obj);

		[Export ("stringFromDateComponents:")]
		extern string StringFromDateComponents (NSDateComponents components);

		[Export ("stringFromDate:toDate:")]
		extern string StringFromDate (NSDate startDate, NSDate endDate);

		[Export ("stringFromTimeInterval:")]
		extern string StringFromTimeInterval (double ti);

		[Static, Export ("localizedStringFromDateComponents:unitsStyle:")]
		extern string LocalizedStringFromDateComponents (NSDateComponents components, NSDateComponentsFormatterUnitsStyle unitsStyle);

		[Export ("getObjectValue:forString:errorDescription:")]
		extern bool GetObjectValue (out NSObject obj, string str, out string error);

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("referenceDate", ArgumentSemantic.Copy)]
		NSDate ReferenceDate { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSDateIntervalFormatter {

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[Export ("calendar", ArgumentSemantic.Copy)]
		NSCalendar Calendar { get; set; }

		[Export ("timeZone", ArgumentSemantic.Copy)]
		NSTimeZone TimeZone { get; set; }

		[Export ("dateTemplate")]
		string DateTemplate { get; set; }

		[Export ("dateStyle")]
		NSDateIntervalFormatterStyle DateStyle { get; set; }

		[Export ("timeStyle")]
		NSDateIntervalFormatterStyle TimeStyle { get; set; }

		[Export ("stringFromDate:toDate:")]
		extern string StringFromDate (NSDate fromDate, NSDate toDate);

		[MacCatalyst (13, 1)]
		[Export ("stringFromDateInterval:")]
		[return: NullAllowed]
		extern string ToString (NSDateInterval dateInterval);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSEnergyFormatter {
		[Export ("numberFormatter", ArgumentSemantic.Copy)]
		NSNumberFormatter NumberFormatter { get; set; }

		[Export ("unitStyle")]
		NSFormattingUnitStyle UnitStyle { get; set; }

		[Export ("forFoodEnergyUse")]
		bool ForFoodEnergyUse { [Bind ("isForFoodEnergyUse")] get; set; }

		[Export ("stringFromValue:unit:")]
		extern string StringFromValue (double value, NSEnergyFormatterUnit unit);

		[Export ("stringFromJoules:")]
		extern string StringFromJoules (double numberInJoules);

		[Export ("unitStringFromValue:unit:")]
		extern string UnitStringFromValue (double value, NSEnergyFormatterUnit unit);

		[Export ("unitStringFromJoules:usedUnit:")]
		extern string UnitStringFromJoules (double numberInJoules, out NSEnergyFormatterUnit unitp);

		[Export ("getObjectValue:forString:errorDescription:")]
		extern bool GetObjectValue (out NSObject obj, string str, out string error);
	}

	partial class NSFileHandleReadEventArgs {
		[Export ("NSFileHandleNotificationDataItem")]
		NSData AvailableData { get; }

		[Export ("NSFileHandleError", ArgumentSemantic.Assign)]
		nint UnixErrorCode { get; }
	}

	partial class NSFileHandleConnectionAcceptedEventArgs {
		[Export ("NSFileHandleNotificationFileHandleItem")]
		NSFileHandle NearSocketConnection { get; }

		[Export ("NSFileHandleError", ArgumentSemantic.Assign)]
		nint UnixErrorCode { get; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // return invalid handle
	partial class NSFileHandle : NSSecureCoding {
		[Export ("availableData")]
		extern NSData AvailableData ();

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use 'ReadToEnd (out NSError)' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'ReadToEnd (out NSError)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'ReadToEnd (out NSError)' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "Use 'ReadToEnd (out NSError)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ReadToEnd (out NSError)' instead.")]
		[Export ("readDataToEndOfFile")]
		extern NSData ReadDataToEndOfFile ();

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("readDataToEndOfFileAndReturnError:")]
		[return: NullAllowed]
		extern NSData ReadToEnd ([NullAllowed] out NSError error);

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use 'Read (nuint, out NSError)' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'Read (nuint, out NSError)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'Read (nuint, out NSError)' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "Use 'Read (nuint, out NSError)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Read (nuint, out NSError)' instead.")]
		[Export ("readDataOfLength:")]
		extern NSData ReadDataOfLength (nuint length);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("readDataUpToLength:error:")]
		[return: NullAllowed]
		extern NSData? Read (nuint length, [NullAllowed] out NSError error);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Write (out NSError)' instead.")]
		[Export ("writeData:")]
		extern void WriteData (NSData data);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("writeData:error:")]
		extern bool Write (NSData data, [NullAllowed] out NSError error);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'GetOffset (out ulong, out NSError)' instead.")]
		[Export ("offsetInFile")]
		extern ulong OffsetInFile ();

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("getOffset:error:")]
		extern bool GetOffset (out ulong offsetInFile, [NullAllowed] out NSError error);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'SeekToEnd (out ulong, out NSError)' instead.")]
		[Export ("seekToEndOfFile")]
		extern ulong SeekToEndOfFile ();

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("seekToEndReturningOffset:error:")]
		extern bool SeekToEnd ([NullAllowed] out ulong offsetInFile, [NullAllowed] out NSError error);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Seek (ulong, out NSError)' instead.")]
		[Export ("seekToFileOffset:")]
		extern void SeekToFileOffset (ulong offset);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("seekToOffset:error:")]
		extern bool Seek (ulong offset, [NullAllowed] out NSError error);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Truncate (ulong, out NSError)' instead.")]
		[Export ("truncateFileAtOffset:")]
		extern void TruncateFileAtOffset (ulong offset);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("truncateAtOffset:error:")]
		extern bool Truncate (ulong offset, [NullAllowed] out NSError error);

	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Synchronize (out NSError)' instead.")]
		[Export ("synchronizeFile")]
		extern void SynchronizeFile ();

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("synchronizeAndReturnError:")]
		extern bool Synchronize ([NullAllowed] out NSError error);

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use 'Close (out NSError)' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'Close (out NSError)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'Close (out NSError)' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "Use 'Close (out NSError)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Close (out NSError)' instead.")]
		[Export ("closeFile")]
		extern void CloseFile ();

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("closeAndReturnError:")]
		extern bool Close ([NullAllowed] out NSError error);

		[Static]
		[Export ("fileHandleWithStandardInput")]
		static extern NSFileHandle FromStandardInput ();

		[Static]
		[Export ("fileHandleWithStandardOutput")]
		static extern NSFileHandle FromStandardOutput ();

		[Static]
		[Export ("fileHandleWithStandardError")]
		static extern NSFileHandle FromStandardError ();

		[Static]
		[Export ("fileHandleWithNullDevice")]
		static extern NSFileHandle FromNullDevice ();

		[Static]
		[Export ("fileHandleForReadingAtPath:")]
		static extern NSFileHandle OpenRead (string path);

		[Static]
		[Export ("fileHandleForWritingAtPath:")]
		static extern NSFileHandle OpenWrite (string path);

		[Static]
		[Export ("fileHandleForUpdatingAtPath:")]
		static extern NSFileHandle OpenUpdate (string path);

		[Static]
		[Export ("fileHandleForReadingFromURL:error:")]
		static extern NSFileHandle OpenReadUrl (NSUrl url, out NSError error);

		[Static]
		[Export ("fileHandleForWritingToURL:error:")]
		static extern NSFileHandle OpenWriteUrl (NSUrl url, out NSError error);

		[Static]
		[Export ("fileHandleForUpdatingURL:error:")]
		static extern NSFileHandle OpenUpdateUrl (NSUrl url, out NSError error);

		[Export ("readInBackgroundAndNotifyForModes:")]
		extern void ReadInBackground (NSString [] notifyRunLoopModes);

		[Wrap ("ReadInBackground (notifyRunLoopModes.GetConstants ())")] 
		extern void ReadInBackground (NSRunLoopMode [] notifyRunLoopModes);

		[Export ("readInBackgroundAndNotify")]
		extern void ReadInBackground ();

		[Export ("readToEndOfFileInBackgroundAndNotifyForModes:")]
		extern void ReadToEndOfFileInBackground (NSString [] notifyRunLoopModes);

		[Wrap ("ReadToEndOfFileInBackground (notifyRunLoopModes.GetConstants ())")]
		extern void ReadToEndOfFileInBackground (NSRunLoopMode [] notifyRunLoopModes);

		[Export ("readToEndOfFileInBackgroundAndNotify")]
		extern void ReadToEndOfFileInBackground ();

		[Export ("acceptConnectionInBackgroundAndNotifyForModes:")]
		extern void AcceptConnectionInBackground (NSString [] notifyRunLoopModes);

		[Wrap ("AcceptConnectionInBackground (notifyRunLoopModes.GetConstants ())")]
		extern void AcceptConnectionInBackground (NSRunLoopMode [] notifyRunLoopModes);

		[Export ("acceptConnectionInBackgroundAndNotify")]
		extern void AcceptConnectionInBackground ();

		[Export ("waitForDataInBackgroundAndNotifyForModes:")]
		extern void WaitForDataInBackground (NSString [] notifyRunLoopModes);

		[Wrap ("WaitForDataInBackground (notifyRunLoopModes.GetConstants ())")]
		extern void WaitForDataInBackground (NSRunLoopMode [] notifyRunLoopModes);

		[Export ("waitForDataInBackgroundAndNotify")]
		extern void WaitForDataInBackground ();

		[DesignatedInitializer]
		[Export ("initWithFileDescriptor:closeOnDealloc:")]
		extern NativeHandle Constructor (int /* int, not NSInteger */ fd, bool closeOnDealloc);

		[Export ("initWithFileDescriptor:")]
		extern NativeHandle Constructor (int /* int, not NSInteger */ fd);

		[Export ("fileDescriptor")]
		extern int FileDescriptor { get; } /* int, not NSInteger */

		[Export ("setReadabilityHandler:")]
		extern void SetReadabilityHandler ([NullAllowed] Action<NSFileHandle> readCallback);

		[Export ("setWriteabilityHandler:")]
		extern void SetWriteabilityHandle ([NullAllowed] Action<NSFileHandle> writeCallback);

		[Field ("NSFileHandleOperationException")]
		extern NSString OperationException { get; }

		[Field ("NSFileHandleReadCompletionNotification")]
		[Notification (typeof (NSFileHandleReadEventArgs))]
		extern NSString ReadCompletionNotification { get; }

		[Field ("NSFileHandleReadToEndOfFileCompletionNotification")]
		[Notification (typeof (NSFileHandleReadEventArgs))]
		extern NSString ReadToEndOfFileCompletionNotification { get; }

		[Field ("NSFileHandleConnectionAcceptedNotification")]
		[Notification (typeof (NSFileHandleConnectionAcceptedEventArgs))]
		extern NSString ConnectionAcceptedNotification { get; }

		[Field ("NSFileHandleDataAvailableNotification")]
		[Notification]
		extern NSString DataAvailableNotification { get; }
	}

	[MacCatalyst (13, 1)]
	[Static]
	 static partial class NSPersonNameComponent {
		[Field ("NSPersonNameComponentKey")]
		static NSString ComponentKey { get; }

		[Field ("NSPersonNameComponentGivenName")]
		static NSString GivenName { get; }

		[Field ("NSPersonNameComponentFamilyName")]
		static NSString FamilyName { get; }

		[Field ("NSPersonNameComponentMiddleName")]
		static NSString MiddleName { get; }

		[Field ("NSPersonNameComponentPrefix")]
		static NSString Prefix { get; }

		[Field ("NSPersonNameComponentSuffix")]
		static NSString Suffix { get; }

		[Field ("NSPersonNameComponentNickname")]
		static NSString Nickname { get; }

		[Field ("NSPersonNameComponentDelimiter")]
		static NSString Delimiter { get; }
	}


	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class NSPersonNameComponents : NSCopying {

		[NullAllowed, Export ("namePrefix")]
		string NamePrefix { get; set; }

		[NullAllowed, Export ("givenName")]
		string GivenName { get; set; }

		[NullAllowed, Export ("middleName")]
		string MiddleName { get; set; }

		[NullAllowed, Export ("familyName")]
		string FamilyName { get; set; }

		[NullAllowed, Export ("nameSuffix")]
		string NameSuffix { get; set; }

		[NullAllowed, Export ("nickname")]
		string Nickname { get; set; }

		[NullAllowed, Export ("phoneticRepresentation", ArgumentSemantic.Copy)]
		NSPersonNameComponents PhoneticRepresentation { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSPersonNameComponentsFormatter {
		[Export ("style", ArgumentSemantic.Assign)]
		NSPersonNameComponentsFormatterStyle Style { get; set; }

		[Export ("phonetic")]
		bool Phonetic { [Bind ("isPhonetic")] get; set; }

		[Static]
		[Export ("localizedStringFromPersonNameComponents:style:options:")]
		static extern string GetLocalizedString (NSPersonNameComponents components, NSPersonNameComponentsFormatterStyle nameFormatStyle, NSPersonNameComponentsFormatterOptions nameOptions);

		[Export ("stringFromPersonNameComponents:")]
		static extern string GetString (NSPersonNameComponents components);

		[Export ("annotatedStringFromPersonNameComponents:")]
		static extern NSAttributedString GetAnnotatedString (NSPersonNameComponents components);

		[Export ("getObjectValue:forString:errorDescription:")]
		static extern bool GetObjectValue (out NSObject result, string str, out string errorDescription);

		[MacCatalyst (13, 1)]
		[Export ("personNameComponentsFromString:")]
		[return: NullAllowed]
		static extern NSPersonNameComponents GetComponents (string @string);

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }
	}


	[BaseType (typeof (NSObject))]
	partial class NSPipe {

		[Export ("fileHandleForReading")]
		NSFileHandle ReadHandle { get; }

		[Export ("fileHandleForWriting")]
		NSFileHandle WriteHandle { get; }

		[Static]
		[Export ("pipe")]
		static extern NSPipe Create ();
	}
	

	[BaseType (typeof (NSObject))]
#if NET
	[DisableDefaultCtor] // points to nothing so access properties crash the apps
#endif
	partial class NSMetadataItem {

		[NoiOS]
		[NoTV]
		[NoWatch]
		[NoMacCatalyst]
		[DesignatedInitializer]
		[Export ("initWithURL:")]
		extern NativeHandle Constructor (NSUrl url);

		[Export ("valueForAttribute:")]
		 extern NSObject ValueForAttribute (string key);

		[Sealed]
		[Internal]
		[Export ("valueForAttribute:")]
		extern IntPtr GetHandle (NSString key);
		[Export ("valuesForAttributes:")]
		extern NSDictionary ValuesForAttributes (NSArray keys);

		[Export ("attributes")]
		NSObject [] Attributes { get; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSMetadataQueryAttributeValueTuple {
		[Export ("attribute")]
		string Attribute { get; }

		[Export ("value")]
		NSObject Value { get; }

		[Export ("count")]
		nint Count { get; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSMetadataQueryResultGroup {
		[Export ("attribute")]
		string Attribute { get; }

		[Export ("value")]
		NSObject Value { get; }

		[Export ("subgroups")]
		NSObject [] Subgroups { get; }

		[Export ("resultCount")]
		nint ResultCount { get; }

		[Export ("resultAtIndex:")]
		extern NSObject ResultAtIndex (nuint idx);

		[Export ("results")]
		NSObject [] Results { get; }

	}

	// Sadly, while this API is a poor API and we should in general not use it
	// Apple has now surfaced it on a few methods.   So we need to take the Obsolete
	// out, and we will have to fully support it.
	[BaseType (typeof (NSArray))]
	//[DesignatedDefaultCtor]
	public partial class NSMutableArray: NSArray {

		public NSMutableArray()
		{
			Handle = this.Constructor(0);
		}
		
		public NSMutableArray (nuint capacity)
		{
			Handle = this.Constructor(capacity);
		}
		
		[DesignatedInitializer]
		[Export ("initWithCapacity:")]
		extern public NativeHandle Constructor (nuint capacity);

		[Internal]
		[Sealed]
		[Export ("addObject:")]
		extern public void _Add (IntPtr obj);

		[Export ("addObject:")]
		extern public void Add (NSObject obj);

		[Internal]
		[Sealed]
		[Export ("insertObject:atIndex:")]
		extern public void _Insert (IntPtr obj, nint index);

		[Export ("insertObject:atIndex:")]
		extern public void Insert (NSObject obj, nint index);

		[Export ("removeLastObject")]
		extern public void RemoveLastObject ();

		[Export ("removeObjectAtIndex:")]
		extern public void RemoveObject (nint index);

		[Internal]
		[Sealed]
		[Export ("replaceObjectAtIndex:withObject:")]
		extern public void _ReplaceObject (nint index, IntPtr withObject);

		[Export ("replaceObjectAtIndex:withObject:")]
		extern public void ReplaceObject (nint index, NSObject withObject);

		[Export ("removeAllObjects")]
		extern public void RemoveAllObjects ();

		[Export ("addObjectsFromArray:")]
		extern public void AddObjects (NSObject [] source);

		[Internal]
		[Sealed]
		[Export ("insertObjects:atIndexes:")]
		extern public void _InsertObjects (IntPtr objects, NSIndexSet atIndexes);

		[Export ("insertObjects:atIndexes:")]
		extern public void InsertObjects (NSObject [] objects, NSIndexSet atIndexes);

		[Export ("removeObjectsAtIndexes:")]
		extern public void RemoveObjectsAtIndexes (NSIndexSet indexSet);

		[MacCatalyst (13, 1)]
		[Static, Export ("arrayWithContentsOfFile:")]
		extern public NSMutableArray FromFile (string path);

		[MacCatalyst (13, 1)]
		[Static, Export ("arrayWithContentsOfURL:")]
		extern public NSMutableArray FromUrl (NSUrl url);

#if false // https://github.com/xamarin/xamarin-macios/issues/15577
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("applyDifference:")]
		void ApplyDifference (NSOrderedCollectionDifference difference);
#endif
	}
	

	[BaseType (typeof (NSAttributedString))]
	partial class NSMutableAttributedString {
		[Export ("initWithString:")]
		extern public NativeHandle Constructor (string str);

		[Export ("initWithString:attributes:")]
		extern public NativeHandle Constructor (string str, [NullAllowed] NSDictionary attributes);

		[Export ("initWithAttributedString:")]
		extern public NativeHandle Constructor (NSAttributedString other);

		[Export ("replaceCharactersInRange:withString:")]
		extern public void Replace (NSRange range, string newValue);

		[Export ("setAttributes:range:")]
		extern public void LowLevelSetAttributes (IntPtr dictionaryAttrsHandle, NSRange range);

		[Export ("mutableString", ArgumentSemantic.Retain)]
		extern public NSMutableString MutableString { get; }

		[Export ("addAttribute:value:range:")]
		extern public void AddAttribute (NSString attributeName, NSObject value, NSRange range);

		[Export ("addAttributes:range:")]
		extern public void AddAttributes (NSDictionary attrs, NSRange range);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Wrap ("AddAttributes (attributes.GetDictionary ()!, range)")]
		extern public void AddAttributes (NSStringAttributes attributes, NSRange range);

		[Export ("removeAttribute:range:")]
		extern public void RemoveAttribute (string name, NSRange range);

		[Export ("replaceCharactersInRange:withAttributedString:")]
		extern public void Replace (NSRange range, NSAttributedString value);

		[Export ("insertAttributedString:atIndex:")]
		extern public void Insert (NSAttributedString attrString, nint location);

		[Export ("appendAttributedString:")]
		extern public void Append (NSAttributedString attrString);

		[Export ("deleteCharactersInRange:")]
		extern public void DeleteRange (NSRange range);

		[Export ("setAttributedString:")]
		extern public void SetString (NSAttributedString attrString);

		[Export ("beginEditing")]
		extern public void BeginEditing ();

		[Export ("endEditing")]
		extern public void EndEditing ();

		[NoMac]
		[NoTV]
		//[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'ReadFromUrl' instead.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ReadFromUrl' instead.")]
		[Export ("readFromFileURL:options:documentAttributes:error:")]
		extern public bool ReadFromFile (NSUrl url, NSDictionary options, ref NSDictionary returnOptions, ref NSError error);

		[NoMac]
		[NoTV]
		//[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'ReadFromUrl' instead.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'ReadFromUrl' instead.")]
		[Wrap ("ReadFromFile (url, options.GetDictionary ()!, ref returnOptions, ref error)")]
		extern public bool ReadFromFile (NSUrl url, NSAttributedStringDocumentAttributes options, ref NSDictionary returnOptions, ref NSError error);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("readFromData:options:documentAttributes:error:")]
		extern public bool ReadFromData (NSData data, NSDictionary options, ref NSDictionary returnOptions, ref NSError error);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Wrap ("ReadFromData (data, options.GetDictionary ()!, ref returnOptions, ref error)")]
		extern public bool ReadFromData (NSData data, NSAttributedStringDocumentAttributes options, ref NSDictionary returnOptions, ref NSError error);

		[Internal]
		[Sealed]
		[MacCatalyst (13, 1)]
		[Export ("readFromURL:options:documentAttributes:error:")]
		extern public bool ReadFromUrl (NSUrl url, NSDictionary options, ref NSDictionary<NSString, NSObject> returnOptions, ref NSError error);

		[MacCatalyst (13, 1)]
		[Export ("readFromURL:options:documentAttributes:error:")]
		extern public bool ReadFromUrl (NSUrl url, NSDictionary<NSString, NSObject> options, ref NSDictionary<NSString, NSObject> returnOptions, ref NSError error);

		[MacCatalyst (13, 1)]
		[Wrap ("ReadFromUrl (url, options.GetDictionary ()!, ref returnOptions, ref error)")]
		extern public bool ReadFromUrl (NSUrl url, NSAttributedStringDocumentAttributes options, ref NSDictionary<NSString, NSObject> returnOptions, ref NSError error);
	}

	[BaseType (typeof (NSData))]
	public partial class NSMutableData: NSData {
		[Static, Export ("dataWithCapacity:")]
		[Autorelease]
		[PreSnippet ("if (capacity < 0 || capacity > nint.MaxValue) throw new ArgumentOutOfRangeException ();", Optimizable = true)]
		public static extern NSMutableData FromCapacity (nint capacity);

		[Static, Export ("dataWithLength:")]
		[Autorelease]
		[PreSnippet ("if (length < 0 || length > nint.MaxValue) throw new ArgumentOutOfRangeException ();", Optimizable = true)]
		public static extern NSMutableData FromLength (nint length);

		[Static, Export ("data")]
		[Autorelease]
		public static extern NSMutableData Create ();

		[Export ("mutableBytes")]
		public extern IntPtr MutableBytes { get; }

		[Export ("initWithCapacity:")]
		[PreSnippet ("if (capacity > (ulong) nint.MaxValue) throw new ArgumentOutOfRangeException ();", Optimizable = true)]
		public extern NativeHandle Constructor (nuint capacity);

		[Export ("appendData:")]
		public extern void AppendData (NSData other);

		[Export ("appendBytes:length:")]
		public extern void AppendBytes (IntPtr bytes, nuint len);

		[Export ("setData:")]
		public extern void SetData (NSData data);

		[Export ("length")]
		[Override]
		public extern nuint Length { get; set; }

		[Export ("replaceBytesInRange:withBytes:")]
		public extern void ReplaceBytes (NSRange range, IntPtr buffer);

		[Export ("resetBytesInRange:")]
		public extern void ResetBytes (NSRange range);

		[Export ("replaceBytesInRange:withBytes:length:")]
		public extern void ReplaceBytes (NSRange range, IntPtr buffer, nuint length);

		// NSMutableDataCompression (NSMutableData)

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("decompressUsingAlgorithm:error:")]
		public extern bool Decompress (NSDataCompressionAlgorithm algorithm, [NullAllowed] out NSError error);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("compressUsingAlgorithm:error:")]
		public extern bool Compress (NSDataCompressionAlgorithm algorithm, [NullAllowed] out NSError error);
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum NSDataCompressionAlgorithm : long {
		Lzfse = 0,
		Lz4,
		Lzma,
		Zlib,
	}

	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	partial class NSDate :  NSCopying {
		[Export ("timeIntervalSinceReferenceDate")]
		double SecondsSinceReferenceDate { get; }

		[Export ("timeIntervalSinceDate:")]
		extern double GetSecondsSince (NSDate anotherDate);

		[Export ("timeIntervalSinceNow")]
		double SecondsSinceNow { get; }

		[Export ("timeIntervalSince1970")]
		double SecondsSince1970 { get; }

		[Export ("dateWithTimeIntervalSinceReferenceDate:")]
		[Static]
		static extern NSDate FromTimeIntervalSinceReferenceDate (double secs);

		[Static, Export ("dateWithTimeIntervalSince1970:")]
		static extern NSDate FromTimeIntervalSince1970 (double secs);

		[Export ("date")]
		[Static]
		static NSDate Now { get; }

		[Export ("distantPast")]
		[Static]
		static NSDate DistantPast { get; }

		[Export ("distantFuture")]
		[Static]
		static NSDate DistantFuture { get; }

		[Export ("dateByAddingTimeInterval:")]
		extern NSDate AddSeconds (double seconds);

		[Export ("dateWithTimeIntervalSinceNow:")]
		[Static]
		static extern NSDate FromTimeIntervalSinceNow (double secs);

		[Export ("descriptionWithLocale:")]
		extern string DescriptionWithLocale (NSLocale locale);

		[Export ("earlierDate:")]
		extern NSDate EarlierDate (NSDate anotherDate);

		[Export ("laterDate:")]
		extern NSDate LaterDate (NSDate anotherDate);

		[Export ("compare:")]
		extern NSComparisonResult Compare (NSDate other);

		[Export ("isEqualToDate:")]
		extern bool IsEqualToDate (NSDate other);

		// NSDate_SensorKit

		[NoWatch, NoTV, NoMac]
		[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Export ("dateWithSRAbsoluteTime:")]
		static extern NSDate CreateFromSRAbsoluteTime (double time);

		[NoWatch, NoTV, NoMac]
		[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("initWithSRAbsoluteTime:")]
		extern NativeHandle Constructor (double srAbsoluteTime);

		[NoWatch, NoTV, NoMac]
		[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("srAbsoluteTime")]
		extern double SrAbsoluteTime { get; }

		[Field ("NSSystemClockDidChangeNotification")]
		[Notification]
		extern NSString SystemClockDidChangeNotification { get; }
	}

	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	public partial class NSDictionary :  INSFastEnumeration {
		
		public NSDictionary ()
		{
			Handle = IntPtr.Zero;
		}
		
		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSMutableDictionary.FromFile' instead.")]
		[Export ("dictionaryWithContentsOfFile:")]
		[Static]
		public static extern NSDictionary FromFile (string path);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSMutableDictionary.FromUrl' instead.")]
		[Export ("dictionaryWithContentsOfURL:")]
		[Static]
		public static  extern NSDictionary FromUrl (NSUrl url);

		[Export ("dictionaryWithObject:forKey:")]
		[Static]
		public static  extern NSDictionary FromObjectAndKey (NSObject obj, NSObject key);

		[Export ("dictionaryWithDictionary:")]
		[Static]
		public static  extern NSDictionary FromDictionary (NSDictionary source);

		[Export ("dictionaryWithObjects:forKeys:count:")]
		[Static, Internal]
		internal static  extern IntPtr _FromObjectsAndKeysInternal (IntPtr objects, IntPtr keys, nint count);

		[Export ("dictionaryWithObjects:forKeys:count:")]
		[Static, Internal]
		internal static  extern NSDictionary FromObjectsAndKeysInternal ([NullAllowed] NSArray objects, [NullAllowed] NSArray keys, nint count);

		[Export ("dictionaryWithObjects:forKeys:")]
		[Static, Internal]
		internal static  extern IntPtr _FromObjectsAndKeysInternal (IntPtr objects, IntPtr keys);

		[Export ("dictionaryWithObjects:forKeys:")]
		[Static, Internal]
		internal static  extern NSDictionary FromObjectsAndKeysInternal ([NullAllowed] NSArray objects, [NullAllowed] NSArray keys);

		[Export ("initWithDictionary:")]
		public  extern NativeHandle Constructor (NSDictionary other);

		[Export ("initWithDictionary:copyItems:")]
		public extern  NativeHandle Constructor (NSDictionary other, bool copyItems);

	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSMutableDictionary(string)' constructor instead.")]
		[Export ("initWithContentsOfFile:")]
		public  extern NativeHandle Constructor (string fileName);

		[Export ("initWithObjects:forKeys:"), Internal]
		internal  extern NativeHandle Constructor (NSArray objects, NSArray keys);

	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSMutableDictionary(NSUrl)' constructor instead.")]
		[Export ("initWithContentsOfURL:")]
		public extern  NativeHandle Constructor (NSUrl url);

		[MacCatalyst (13, 1)]
		[Export ("initWithContentsOfURL:error:")]
		public  extern NativeHandle Constructor (NSUrl url, out NSError error);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("dictionaryWithContentsOfURL:error:")]
		[return: NullAllowed]
		public  extern NSDictionary<NSString, NSObject> FromUrl (NSUrl url, out NSError error);

		[Export ("count")]
		public nuint Count { get; }

		[Internal]
		[Sealed]
		[Export ("objectForKey:")]
		internal extern   IntPtr _ObjectForKey (IntPtr key);

		[Export ("objectForKey:")]
		public  extern NSObject ObjectForKey (NSObject key);

		[Internal]
		[Sealed]
		[Export ("allKeys")]
		internal  extern  IntPtr _AllKeys ();

		[Export ("allKeys")]
		[Autorelease]
		public NSObject [] Keys { get; }

		[Internal]
		[Sealed]
		[Export ("allKeysForObject:")]
		internal extern   IntPtr _AllKeysForObject (IntPtr obj);

		[Export ("allKeysForObject:")]
		[Autorelease]
		public  extern NSObject [] KeysForObject (NSObject obj);

		[Internal]
		[Sealed]
		[Export ("allValues")]
		internal  extern  IntPtr _AllValues ();

		[Export ("allValues")]
		[Autorelease]
		public NSObject [] Values { get; }

		[Export ("descriptionInStringsFileFormat")]
		public string DescriptionInStringsFileFormat { get; }

		[Export ("isEqualToDictionary:")]
		public  extern bool IsEqualToDictionary (NSDictionary other);

		[Export ("objectEnumerator")]
		public NSEnumerator ObjectEnumerator { get; }

		[Internal]
		[Sealed]
		[Export ("objectsForKeys:notFoundMarker:")]
		internal extern   IntPtr _ObjectsForKeys (IntPtr keys, IntPtr marker);

		[Export ("objectsForKeys:notFoundMarker:")]
		[Autorelease]
		public  extern NSObject [] ObjectsForKeys (NSArray keys, NSObject marker);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("writeToFile:atomically:")]
		public  extern bool WriteToFile (string path, bool useAuxiliaryFile);

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("writeToURL:atomically:")]
		public  extern  bool WriteToUrl (NSUrl url, bool atomically);

		[Static]
		[Export ("sharedKeySetForKeys:")]
		public extern  NSObject GetSharedKeySetForKeys (NSObject [] keys);

	}

	public partial class NSDictionary<K, V> : NSDictionary { }

	[BaseType (typeof (NSObject))]
	public partial class NSEnumerator : NSObject {
		[Export ("nextObject")]
		public extern NSObject NextObject ();

		public NSEnumerator() : base()
		{
		}
		
		public NSEnumerator(NativeHandle handle) : base(handle)
		{
		}
	}

	public partial class NSEnumerator<TKey> : NSEnumerator {
		
		/*[Export ("nextObject")]
		public new TKey NextTObject ()
		{
			return (TKey) base.NextObject ();
		}
		
		public T IEnumerator<TKey>.Current {
			get {
				return current as NSString;
			}
		}

		public NSEnumerator() : base()
		{
		}*/
	}

	



#if !NET && !WATCH
	[Obsolete ("NSExpressionHandler is deprecated, please use FromFormat (string, NSObject[]) instead.")]
	public delegate void NSExpressionHandler (NSObject evaluatedObject, NSExpression [] expressions, NSMutableDictionary context);
#endif
	public delegate NSObject NSExpressionCallbackHandler (NSObject evaluatedObject, NSExpression [] expressions, NSMutableDictionary context);
	[BaseType (typeof (NSObject))]
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -predicateFormat cannot be sent to an abstract object of class NSExpression: Create a concrete instance!
	[DisableDefaultCtor]
	public partial class NSExpression :  NSCopying {
		[Static, Export ("expressionForConstantValue:")]
		public static extern NSExpression FromConstant ([NullAllowed] NSObject obj);

		[Static, Export ("expressionForEvaluatedObject")]
		public static extern NSExpression ExpressionForEvaluatedObject { get; }

		[Static, Export ("expressionForVariable:")]
		public static extern NSExpression FromVariable (string string1);

		[Static, Export ("expressionForKeyPath:")]
		public static extern NSExpression FromKeyPath (string keyPath);

		[Static, Export ("expressionForFunction:arguments:")]
		public static extern NSExpression FromFunction (string name, NSExpression [] parameters);

		[Static, Export ("expressionWithFormat:")]
		public static extern NSExpression FromFormat (string expressionFormat);

#if !NET && !WATCH
		[Obsolete ("Use 'FromFormat (string, NSObject[])' instead.")]
		[Static, Export ("expressionWithFormat:argumentArray:")]
		public static extern NSExpression FromFormat (string format, NSExpression [] parameters);
#endif

		[Static, Export ("expressionWithFormat:argumentArray:")]
		public static extern NSExpression FromFormat (string format, NSObject [] parameters);

		//+ (NSExpression *)expressionForAggregate:(NSArray *)subexpressions; 
		[Static, Export ("expressionForAggregate:")]
		public static extern NSExpression FromAggregate (NSExpression [] subexpressions);

		[Static, Export ("expressionForUnionSet:with:")]
		public static extern NSExpression FromUnionSet (NSExpression left, NSExpression right);

		[Static, Export ("expressionForIntersectSet:with:")]
		public static extern NSExpression FromIntersectSet (NSExpression left, NSExpression right);

		[Static, Export ("expressionForMinusSet:with:")]
		public static extern NSExpression FromMinusSet (NSExpression left, NSExpression right);

		//+ (NSExpression *)expressionForSubquery:(NSExpression *)expression usingIteratorVariable:(NSString *)variable predicate:(id)predicate; 
		[Static, Export ("expressionForSubquery:usingIteratorVariable:predicate:")]
		public static extern NSExpression FromSubquery (NSExpression expression, string variable, NSObject predicate);

		[Static, Export ("expressionForFunction:selectorName:arguments:")]
		public static extern NSExpression FromFunction (NSExpression target, string name, NSExpression [] parameters);

#if !NET && !WATCH
		[Obsolete ("Use 'FromFunction (NSExpressionCallbackHandler, NSExpression[])' instead.")]
		[Static, Export ("expressionForBlock:arguments:")]
		public static extern NSExpression FromFunction (NSExpressionHandler target, [NullAllowed] NSExpression [] parameters);
#endif

		[Static, Export ("expressionForBlock:arguments:")]
		public static extern NSExpression FromFunction (NSExpressionCallbackHandler target, NSExpression [] parameters);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("expressionForAnyKey")]
		public static extern NSExpression FromAnyKey ();

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("expressionForConditional:trueExpression:falseExpression:")]
		public static extern NSExpression FromConditional (NSPredicate predicate, NSExpression trueExpression, NSExpression falseExpression);

		[MacCatalyst (13, 1)]
		[Export ("allowEvaluation")]
		public extern void AllowEvaluation ();

		[DesignatedInitializer]
		[Export ("initWithExpressionType:")]
		public extern NativeHandle Constructor (NSExpressionType type);

		[Export ("expressionType")]
		public extern NSExpressionType ExpressionType { get; }

		[Sealed, Internal, Export ("expressionBlock")]
		 extern NSExpressionCallbackHandler _Block { get; }

		[Sealed, Internal, Export ("constantValue")]
		 extern NSObject _ConstantValue { get; }

		[Sealed, Internal, Export ("keyPath")]
		 extern string _KeyPath { get; }

		[Sealed, Internal, Export ("function")]
		 extern string _Function { get; }

		[Sealed, Internal, Export ("variable")]
		 extern string _Variable { get; }

		[Sealed, Internal, Export ("operand")]
		 extern NSExpression _Operand { get; }

		[Sealed, Internal, Export ("arguments")]
		 extern NSExpression [] _Arguments { get; }

		[Sealed, Internal, Export ("collection")]
		 extern NSObject _Collection { get; }

		[Sealed, Internal, Export ("predicate")]
		 extern NSPredicate _Predicate { get; }

		[Sealed, Internal, Export ("leftExpression")]
		 extern NSExpression _LeftExpression { get; }

		[Sealed, Internal, Export ("rightExpression")]
		 extern NSExpression _RightExpression { get; }

		[MacCatalyst (13, 1)]
		[Sealed, Internal, Export ("trueExpression")]
		 extern NSExpression _TrueExpression { get; }

		[MacCatalyst (13, 1)]
		[Sealed, Internal, Export ("falseExpression")]
		 extern NSExpression _FalseExpression { get; }

		[Export ("expressionValueWithObject:context:")]
		[return: NullAllowed]
		public extern NSObject EvaluateWith ([NullAllowed] NSObject obj, [NullAllowed] NSMutableDictionary context);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class NSExtensionContext {

		[Export ("inputItems", ArgumentSemantic.Copy)]
		NSExtensionItem [] InputItems { get; }

		[Async]
		[Export ("completeRequestReturningItems:completionHandler:")]
		extern void CompleteRequest (NSExtensionItem [] returningItems, [NullAllowed] Action<bool> completionHandler);

		[Export ("cancelRequestWithError:")]
		extern void CancelRequest (NSError error);

		[Export ("openURL:completionHandler:")]
		[Async]
		extern void OpenUrl (NSUrl url, [NullAllowed] Action<bool> completionHandler);

		[Field ("NSExtensionItemsAndErrorsKey")]
		NSString ItemsAndErrorsKey { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSExtensionHostWillEnterForegroundNotification")]
		NSString HostWillEnterForegroundNotification { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSExtensionHostDidEnterBackgroundNotification")]
		NSString HostDidEnterBackgroundNotification { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSExtensionHostWillResignActiveNotification")]
		NSString HostWillResignActiveNotification { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSExtensionHostDidBecomeActiveNotification")]
		NSString HostDidBecomeActiveNotification { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class NSExtensionItem : NSCopying {

		[NullAllowed] // by default this property is null
		[Export ("attributedTitle", ArgumentSemantic.Copy)]
		NSAttributedString AttributedTitle { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("attributedContentText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedContentText { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("attachments", ArgumentSemantic.Copy)]
		NSItemProvider [] Attachments { get; set; }

		[Export ("userInfo", ArgumentSemantic.Copy)]
		NSDictionary UserInfo { get; set; }

		[Field ("NSExtensionItemAttributedTitleKey")]
		extern NSString AttributedTitleKey { get; }

		[Field ("NSExtensionItemAttributedContentTextKey")]
		extern NSString AttributedContentTextKey { get; }

		[Field ("NSExtensionItemAttachmentsKey")]
		extern NSString AttachmentsKey { get; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSNull : NSCopying
	{
		[Export ("null"), Static]
		[Internal]
		static NSNull _Null { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSLengthFormatter {
		[Export ("numberFormatter", ArgumentSemantic.Copy)]
		NSNumberFormatter NumberFormatter { get; set; }

		[Export ("unitStyle")]
		NSFormattingUnitStyle UnitStyle { get; set; }

		[Export ("stringFromValue:unit:")]
		extern string StringFromValue (double value, NSLengthFormatterUnit unit);

		[Export ("stringFromMeters:")]
		extern string StringFromMeters (double numberInMeters);

		[Export ("unitStringFromValue:unit:")]
		extern string UnitStringFromValue (double value, NSLengthFormatterUnit unit);

		[Export ("unitStringFromMeters:usedUnit:")]
		extern string UnitStringFromMeters (double numberInMeters, ref NSLengthFormatterUnit unitp);

		[Export ("getObjectValue:forString:errorDescription:")]
		extern bool GetObjectValue (out NSObject obj, string str, out string error);

		[Export ("forPersonHeightUse")]
		bool ForPersonHeightUse { [Bind ("isForPersonHeightUse")] get; set; }
	}

	delegate void NSLingusticEnumerator (NSString tag, NSRange tokenRange, NSRange sentenceRange, ref bool stop);


	[Deprecated (PlatformName.MacCatalyst, 14, 0, message: "Use 'NaturalLanguage.*' API instead.")]
	[BaseType (typeof (NSObject))]
	partial class NSLinguisticTagger {
		[DesignatedInitializer]
		[Export ("initWithTagSchemes:options:")]
		extern NativeHandle Constructor (NSString [] tagSchemes, NSLinguisticTaggerOptions opts);

		[Export ("tagSchemes")]
		NSString [] TagSchemes { get; }

		[Static]
		[Export ("availableTagSchemesForLanguage:")]
		extern NSString [] GetAvailableTagSchemesForLanguage (string language);

		[Export ("setOrthography:range:")]
		extern void SetOrthographyrange (NSOrthography orthography, NSRange range);

		[Export ("orthographyAtIndex:effectiveRange:")]
		extern NSOrthography GetOrthography (nint charIndex, ref NSRange effectiveRange);

		[Export ("stringEditedInRange:changeInLength:")]
		extern void StringEditedInRange (NSRange newRange, nint delta);

		[Export ("enumerateTagsInRange:scheme:options:usingBlock:")]
		extern void EnumerateTagsInRange (NSRange range, NSString tagScheme, NSLinguisticTaggerOptions opts, NSLingusticEnumerator enumerator);

		[Export ("sentenceRangeForRange:")]
		extern NSRange GetSentenceRangeForRange (NSRange range);

		[Export ("tagAtIndex:scheme:tokenRange:sentenceRange:")]
		extern 	string GetTag (nint charIndex, NSString tagScheme, ref NSRange tokenRange, ref NSRange sentenceRange);

		[Export ("tagsInRange:scheme:options:tokenRanges:"), Internal]
		extern 	NSString [] GetTagsInRange (NSRange range, NSString tagScheme, NSLinguisticTaggerOptions opts, ref NSArray tokenRanges);

		[Export ("possibleTagsAtIndex:scheme:tokenRange:sentenceRange:scores:"), Internal]
		extern 	NSString [] GetPossibleTags (nint charIndex, NSString tagScheme, ref NSRange tokenRange, ref NSRange sentenceRange, ref NSArray scores);

		//Detected properties
		[NullAllowed] // by default this property is null
		[Export ("string", ArgumentSemantic.Retain)]
		string AnalysisString { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tagsInRange:unit:scheme:options:tokenRanges:")]
		extern 	string [] GetTags (NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options, [NullAllowed] out NSValue [] tokenRanges);

		[MacCatalyst (13, 1)]
		[Export ("enumerateTagsInRange:unit:scheme:options:usingBlock:")]
		extern 	void EnumerateTags (NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options, LinguisticTagEnumerator enumerator);

		[MacCatalyst (13, 1)]
		[Export ("tagAtIndex:unit:scheme:tokenRange:")]
		[return: NullAllowed]
		extern string GetTag (nuint charIndex, NSLinguisticTaggerUnit unit, string scheme, [NullAllowed] ref NSRange tokenRange);

		[MacCatalyst (13, 1)]
		[Export ("tokenRangeAtIndex:unit:")]
		extern NSRange GetTokenRange (nuint charIndex, NSLinguisticTaggerUnit unit);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("availableTagSchemesForUnit:language:")]
		extern 	string [] GetAvailableTagSchemes (NSLinguisticTaggerUnit unit, string language);

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("dominantLanguage")]
		string DominantLanguage { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("dominantLanguageForString:")]
		[return: NullAllowed]
		 extern string GetDominantLanguage (string str);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("tagForString:atIndex:unit:scheme:orthography:tokenRange:")]
		[return: NullAllowed]
		static extern string GetTag (string str, nuint charIndex, NSLinguisticTaggerUnit unit, string scheme, [NullAllowed] NSOrthography orthography, [NullAllowed] ref NSRange tokenRange);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("tagsForString:range:unit:scheme:options:orthography:tokenRanges:")]
		static extern string [] GetTags (string str, NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options, [NullAllowed] NSOrthography orthography, [NullAllowed] out NSValue [] tokenRanges);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("enumerateTagsForString:range:unit:scheme:options:orthography:usingBlock:")]
		static extern void EnumerateTags (string str, NSRange range, NSLinguisticTaggerUnit unit, string scheme, NSLinguisticTaggerOptions options, [NullAllowed] NSOrthography orthography, LinguisticTagEnumerator enumerator);
	}

	delegate void LinguisticTagEnumerator (string tag, NSRange tokenRange, bool stop);

#if !NET
	[Obsolete ("Use 'NSLinguisticTagUnit' enum instead.")]
	[Static]
	partial class NSLinguisticTag {
		[Field ("NSLinguisticTagSchemeTokenType")]
		NSString SchemeTokenType { get; }

		[Field ("NSLinguisticTagSchemeLexicalClass")]
		NSString SchemeLexicalClass { get; }

		[Field ("NSLinguisticTagSchemeNameType")]
		NSString SchemeNameType { get; }

		[Field ("NSLinguisticTagSchemeNameTypeOrLexicalClass")]
		NSString SchemeNameTypeOrLexicalClass { get; }

		[Field ("NSLinguisticTagSchemeLemma")]
		NSString SchemeLemma { get; }

		[Field ("NSLinguisticTagSchemeLanguage")]
		NSString SchemeLanguage { get; }

		[Field ("NSLinguisticTagSchemeScript")]
		NSString SchemeScript { get; }

		[Field ("NSLinguisticTagWord")]
		NSString Word { get; }

		[Field ("NSLinguisticTagPunctuation")]
		NSString Punctuation { get; }

		[Field ("NSLinguisticTagWhitespace")]
		NSString Whitespace { get; }

		[Field ("NSLinguisticTagOther")]
		NSString Other { get; }

		[Field ("NSLinguisticTagNoun")]
		NSString Noun { get; }

		[Field ("NSLinguisticTagVerb")]
		NSString Verb { get; }

		[Field ("NSLinguisticTagAdjective")]
		NSString Adjective { get; }

		[Field ("NSLinguisticTagAdverb")]
		NSString Adverb { get; }

		[Field ("NSLinguisticTagPronoun")]
		NSString Pronoun { get; }

		[Field ("NSLinguisticTagDeterminer")]
		NSString Determiner { get; }

		[Field ("NSLinguisticTagParticle")]
		NSString Particle { get; }

		[Field ("NSLinguisticTagPreposition")]
		NSString Preposition { get; }

		[Field ("NSLinguisticTagNumber")]
		NSString Number { get; }

		[Field ("NSLinguisticTagConjunction")]
		NSString Conjunction { get; }

		[Field ("NSLinguisticTagInterjection")]
		NSString Interjection { get; }

		[Field ("NSLinguisticTagClassifier")]
		NSString Classifier { get; }

		[Field ("NSLinguisticTagIdiom")]
		NSString Idiom { get; }

		[Field ("NSLinguisticTagOtherWord")]
		NSString OtherWord { get; }

		[Field ("NSLinguisticTagSentenceTerminator")]
		NSString SentenceTerminator { get; }

		[Field ("NSLinguisticTagOpenQuote")]
		NSString OpenQuote { get; }

		[Field ("NSLinguisticTagCloseQuote")]
		NSString CloseQuote { get; }

		[Field ("NSLinguisticTagOpenParenthesis")]
		NSString OpenParenthesis { get; }

		[Field ("NSLinguisticTagCloseParenthesis")]
		NSString CloseParenthesis { get; }

		[Field ("NSLinguisticTagWordJoiner")]
		NSString WordJoiner { get; }

		[Field ("NSLinguisticTagDash")]
		NSString Dash { get; }

		[Field ("NSLinguisticTagOtherPunctuation")]
		NSString OtherPunctuation { get; }

		[Field ("NSLinguisticTagParagraphBreak")]
		NSString ParagraphBreak { get; }

		[Field ("NSLinguisticTagOtherWhitespace")]
		NSString OtherWhitespace { get; }

		[Field ("NSLinguisticTagPersonalName")]
		NSString PersonalName { get; }

		[Field ("NSLinguisticTagPlaceName")]
		NSString PlaceName { get; }

		[Field ("NSLinguisticTagOrganizationName")]
		NSString OrganizationName { get; }
	}
#endif

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public partial class NSLocale :  NSCopying {
		[Static]
		[Export ("systemLocale", ArgumentSemantic.Copy)]
		public extern static NSLocale SystemLocale { get; }

		[Static]
		[Export ("currentLocale", ArgumentSemantic.Copy)]
		public extern static NSLocale CurrentLocale { get; }

		[Static]
		[Export ("autoupdatingCurrentLocale", ArgumentSemantic.Strong)]
		public extern static NSLocale AutoUpdatingCurrentLocale { get; }

		[DesignatedInitializer]
		[Export ("initWithLocaleIdentifier:")]
		public extern NativeHandle Constructor (string identifier);

		[Export ("localeIdentifier")]
		public extern string LocaleIdentifier { get; }

		[Export ("availableLocaleIdentifiers", ArgumentSemantic.Copy)]
		[Static]
		public extern static string [] AvailableLocaleIdentifiers { get; }

		[Export ("ISOLanguageCodes", ArgumentSemantic.Copy)]
		[Static]
		public extern static string [] ISOLanguageCodes { get; }

		[Export ("ISOCurrencyCodes", ArgumentSemantic.Copy)]
		[Static]
		public extern static string [] ISOCurrencyCodes { get; }

		[Export ("ISOCountryCodes", ArgumentSemantic.Copy)]
		[Static]
		public extern static string [] ISOCountryCodes { get; }

		[Export ("commonISOCurrencyCodes", ArgumentSemantic.Copy)]
		[Static]
		public extern static string [] CommonISOCurrencyCodes { get; }

		[Export ("preferredLanguages", ArgumentSemantic.Copy)]
		[Static]
		public extern static string [] PreferredLanguages { get; }

		[Export ("componentsFromLocaleIdentifier:")]
		[Static]
		public extern static NSDictionary ComponentsFromLocaleIdentifier (string identifier);

		[Export ("localeIdentifierFromComponents:")]
		[Static]
		public extern static string LocaleIdentifierFromComponents (NSDictionary dict);

		[Export ("canonicalLanguageIdentifierFromString:")]
		[Static]
		public extern static string CanonicalLanguageIdentifierFromString (string str);

		[Export ("canonicalLocaleIdentifierFromString:")]
		[Static]
		public extern static string CanonicalLocaleIdentifierFromString (string str);

		[Export ("characterDirectionForLanguage:")]
		[Static]
		public extern static NSLocaleLanguageDirection GetCharacterDirection (string isoLanguageCode);

		[Export ("lineDirectionForLanguage:")]
		[Static]
		public extern static NSLocaleLanguageDirection GetLineDirection (string isoLanguageCode);

		[Static]
		[Export ("localeWithLocaleIdentifier:")]
		public extern static NSLocale FromLocaleIdentifier (string ident);

		[Field ("NSCurrentLocaleDidChangeNotification")]
		[Notification]
		public extern NSString CurrentLocaleDidChangeNotification { get; }

		[Export ("objectForKey:"), Internal]
		public extern NSObject ObjectForKey (NSString key);

		[Export ("displayNameForKey:value:"), Internal]
		public extern NSString DisplayNameForKey (NSString key, string value);

		[Internal, Field ("NSLocaleIdentifier")]
		internal extern NSString _Identifier { get; }

		[Internal, Field ("NSLocaleLanguageCode")]
		internal extern NSString _LanguageCode { get; }

		[Internal, Field ("NSLocaleCountryCode")]
		internal extern NSString _CountryCode { get; }

		[Internal, Field ("NSLocaleScriptCode")]
		internal extern NSString _ScriptCode { get; }

		[Internal, Field ("NSLocaleVariantCode")]
		internal extern NSString _VariantCode { get; }

		[Internal, Field ("NSLocaleExemplarCharacterSet")]
		internal extern NSString _ExemplarCharacterSet { get; }

		[Internal, Field ("NSLocaleCalendar")]
		internal extern NSString _Calendar { get; }

		[Internal, Field ("NSLocaleCollationIdentifier")]
		internal extern NSString _CollationIdentifier { get; }

		[Internal, Field ("NSLocaleUsesMetricSystem")]
		internal extern NSString _UsesMetricSystem { get; }

		[Internal, Field ("NSLocaleMeasurementSystem")]
		internal extern NSString _MeasurementSystem { get; }

		[Internal, Field ("NSLocaleDecimalSeparator")]
		internal extern NSString _DecimalSeparator { get; }

		[Internal, Field ("NSLocaleGroupingSeparator")]
		internal extern NSString _GroupingSeparator { get; }

		[Internal, Field ("NSLocaleCurrencySymbol")]
		internal extern NSString _CurrencySymbol { get; }

		[Internal, Field ("NSLocaleCurrencyCode")]
		internal extern NSString _CurrencyCode { get; }

		[Internal, Field ("NSLocaleCollatorIdentifier")]
		internal extern NSString _CollatorIdentifier { get; }

		[Internal, Field ("NSLocaleQuotationBeginDelimiterKey")]
		internal extern NSString _QuotationBeginDelimiterKey { get; }

		[Internal, Field ("NSLocaleQuotationEndDelimiterKey")]
		internal extern NSString _QuotationEndDelimiterKey { get; }

		[Internal, Field ("NSLocaleAlternateQuotationBeginDelimiterKey")]
		internal extern NSString _AlternateQuotationBeginDelimiterKey { get; }

		[Internal, Field ("NSLocaleAlternateQuotationEndDelimiterKey")]
		internal extern NSString _AlternateQuotationEndDelimiterKey { get; }

		// follow the pattern of NSLocale.cs which included managed helpers that did the same

		[MacCatalyst (13, 1)]
		[Export ("calendarIdentifier")]
		public extern string CalendarIdentifier { get; }

		[MacCatalyst (13, 1)]
		[Export ("localizedStringForCalendarIdentifier:")]
		[return: NullAllowed]
		public extern string GetLocalizedCalendarIdentifier (string calendarIdentifier);

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("languageIdentifier")]
		public extern string LanguageIdentifier { get; }

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[NullAllowed, Export ("regionCode")]
		public extern string RegionCode { get; }
	}

	delegate void NSMatchEnumerator (NSTextCheckingResult result, NSMatchingFlags flags, ref bool stop);

	// This API surfaces NSString instead of strings, because we already have the .NET version that uses
	// strings, so it makes sense to use NSString here (and also, the replacing functionality operates on
	// NSMutableStrings)
	[BaseType (typeof (NSObject))]
	partial class NSRegularExpression : NSCopying {
		[DesignatedInitializer]
		[Export ("initWithPattern:options:error:")]
		static extern NativeHandle Constructor (NSString pattern, NSRegularExpressionOptions options, out NSError error);

		[Static]
		[Export ("regularExpressionWithPattern:options:error:")]
		static extern NSRegularExpression Create (NSString pattern, NSRegularExpressionOptions options, out NSError error);

		[Export ("pattern")]
		NSString Pattern { get; }

		[Export ("options")]
		NSRegularExpressionOptions Options { get; }

		[Export ("numberOfCaptureGroups")]
		nuint NumberOfCaptureGroups { get; }

		[Export ("escapedPatternForString:")]
		[Static]
		static extern NSString GetEscapedPattern (NSString str);

		/* From the NSMatching category */

		[Export ("enumerateMatchesInString:options:range:usingBlock:")]
		extern void EnumerateMatches (NSString str, NSMatchingOptions options, NSRange range, NSMatchEnumerator enumerator);

#if !NET
		[Obsolete ("Use 'GetMatches2' instead, this method has the wrong return type.")]
		[Export ("matchesInString:options:range:")]
		NSString [] GetMatches (NSString str, NSMatchingOptions options, NSRange range);
#endif

		[Export ("matchesInString:options:range:")]
#if NET
		extern NSTextCheckingResult [] GetMatches (NSString str, NSMatchingOptions options, NSRange range);
#else
		[Sealed]
		NSTextCheckingResult [] GetMatches2 (NSString str, NSMatchingOptions options, NSRange range);
#endif

		[Export ("numberOfMatchesInString:options:range:")]
		extern nuint GetNumberOfMatches (NSString str, NSMatchingOptions options, NSRange range);

		[Export ("firstMatchInString:options:range:")]
		[return: NullAllowed]
		extern NSTextCheckingResult FindFirstMatch (string str, NSMatchingOptions options, NSRange range);

		[Export ("rangeOfFirstMatchInString:options:range:")]
		extern NSRange GetRangeOfFirstMatch (string str, NSMatchingOptions options, NSRange range);

		/* From the NSReplacement category */

		[Export ("stringByReplacingMatchesInString:options:range:withTemplate:")]
		extern string ReplaceMatches (string sourceString, NSMatchingOptions options, NSRange range, string template);

		[Export ("replaceMatchesInString:options:range:withTemplate:")]
		extern nuint ReplaceMatches (NSMutableString mutableString, NSMatchingOptions options, NSRange range, NSString template);

		[Export ("replacementStringForResult:inString:offset:template:")]
		extern NSString GetReplacementString (NSTextCheckingResult result, NSString str, nint offset, NSString template);

		[Static, Export ("escapedTemplateForString:")]
		extern NSString GetEscapedTemplate (NSString str);

	}
	

	//[Category, BaseType (typeof (NSOrderedSet))]
	partial class NSKeyValueSorting_NSOrderedSet {
		[Export ("sortedArrayUsingDescriptors:")]
		extern NSObject [] GetSortedArray (NSSortDescriptor [] sortDescriptors);
	}

#pragma warning disable 618
	//[Category, BaseType (typeof (NSMutableArray))]
#pragma warning restore 618
	partial class NSSortDescriptorSorting_NSMutableArray {
		[Export ("sortUsingDescriptors:")]
		extern void SortUsingDescriptors (NSSortDescriptor [] sortDescriptors);
	}

	//[Category, BaseType (typeof (NSMutableOrderedSet))]
	partial class NSKeyValueSorting_NSMutableOrderedSet {
		[Export ("sortUsingDescriptors:")]
		extern void SortUsingDescriptors (NSSortDescriptor [] sortDescriptors);
	}

	

	

	partial class NSUbiquitousKeyValueStoreChangeEventArgs {
		[Export ("NSUbiquitousKeyValueStoreChangedKeysKey")]
		string [] ChangedKeys { get; }

		[Export ("NSUbiquitousKeyValueStoreChangeReasonKey")]
		NSUbiquitousKeyValueStoreChangeReason ChangeReason { get; }
	}

	[BaseType (typeof (NSObject))]
#if WATCH
	[Advice (Constants.UnavailableOnWatchOS)]
	[DisableDefaultCtor] // "NSUbiquitousKeyValueStore is unavailable" is printed to the log.
#endif
	partial class NSUbiquitousKeyValueStore {
		[Static]
		[Export ("defaultStore")]
		NSUbiquitousKeyValueStore DefaultStore { get; }

		[return: NullAllowed]
		[Export ("objectForKey:"), Internal]
		extern NSObject ObjectForKey (string aKey);

		[Export ("setObject:forKey:"), Internal]
		extern void SetObjectForKey ([NullAllowed] NSObject anObject, string aKey);

		[Export ("removeObjectForKey:")]
		extern void Remove (string aKey);

		[return: NullAllowed]
		[Export ("stringForKey:")]
		extern string GetString (string aKey);

		[return: NullAllowed]
		[Export ("arrayForKey:")]
		extern NSObject [] GetArray (string aKey);

		[return: NullAllowed]
		[Export ("dictionaryForKey:")]
		extern NSDictionary GetDictionary (string aKey);

		[return: NullAllowed]
		[Export ("dataForKey:")]
		extern NSData GetData (string aKey);

		[Export ("longLongForKey:")]
		extern long GetLong (string aKey);

		[Export ("doubleForKey:")]
		extern double GetDouble (string aKey);

		[Export ("boolForKey:")]
		extern bool GetBool (string aKey);

		[Export ("setString:forKey:"), Internal]
		extern void _SetString ([NullAllowed] string aString, string aKey);

		[Export ("setData:forKey:"), Internal]
		extern void _SetData ([NullAllowed] NSData data, string key);

		[Export ("setArray:forKey:"), Internal]
		extern void _SetArray ([NullAllowed] NSObject [] array, string key);

		[Export ("setDictionary:forKey:"), Internal]
		extern void _SetDictionary ([NullAllowed] NSDictionary aDictionary, string aKey);

		[Export ("setLongLong:forKey:"), Internal]
		extern void _SetLong (long value, string aKey);

		[Export ("setDouble:forKey:"), Internal]
		extern void _SetDouble (double value, string aKey);

		[Export ("setBool:forKey:"), Internal]
		extern void _SetBool (bool value, string aKey);

		[Export ("dictionaryRepresentation")]
		extern NSDictionary ToDictionary ();

		[Export ("synchronize")]
		extern bool Synchronize ();

		[Field ("NSUbiquitousKeyValueStoreDidChangeExternallyNotification")]
		[Notification (typeof (NSUbiquitousKeyValueStoreChangeEventArgs))]
		 NSString DidChangeExternallyNotification { get; }

		[Field ("NSUbiquitousKeyValueStoreChangeReasonKey")]
		NSString ChangeReasonKey { get; }

		[Field ("NSUbiquitousKeyValueStoreChangedKeysKey")]
		NSString ChangedKeysKey { get; }
	}



	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // xcode 8 beta 4 marks it as API_DEPRECATED
	public partial class NSUserActivity
#if IOS // iOS only.
	: NSItemProviderReading, NSItemProviderWriting
#endif
	{
		[DesignatedInitializer]
		[Export ("initWithActivityType:")]
		extern NativeHandle Constructor (string activityType);

		[Export ("activityType")]
		string ActivityType { get; }

		[NullAllowed] // by default this property is null
		[Export ("title")]
		string Title { get; set; }

		[Export ("userInfo", ArgumentSemantic.Copy), NullAllowed]
		NSDictionary UserInfo { get; set; }

		[Export ("needsSave")]
		bool NeedsSave { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("webpageURL", ArgumentSemantic.Copy)]
		NSUrl WebPageUrl { get; set; }

		[Export ("supportsContinuationStreams")]
		bool SupportsContinuationStreams { get; set; }

		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSUserActivityDelegate Delegate { get; set; }

		[Export ("addUserInfoEntriesFromDictionary:")]
		extern void AddUserInfoEntries (NSDictionary otherDictionary);

		[Export ("becomeCurrent")]
		extern void BecomeCurrent ();

		[Export ("invalidate")]
		extern void Invalidate ();

		[Export ("getContinuationStreamsWithCompletionHandler:")]
		[Async (ResultTypeName = "NSUserActivityContinuation")]
		extern void GetContinuationStreams (Action<NSInputStream, NSOutputStream, NSError> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("requiredUserInfoKeys", ArgumentSemantic.Copy)]
		NSSet<NSString> RequiredUserInfoKeys { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("keywords", ArgumentSemantic.Copy)]
		NSSet<NSString> Keywords { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("resignCurrent")]
		extern void ResignCurrent ();

		[MacCatalyst (13, 1)]
		[Export ("eligibleForHandoff")]
		bool EligibleForHandoff { [Bind ("isEligibleForHandoff")] get; set; }

		[MacCatalyst (13, 1)]
		[Export ("eligibleForSearch")]
		bool EligibleForSearch { [Bind ("isEligibleForSearch")] get; set; }

		[MacCatalyst (13, 1)]
		[Export ("eligibleForPublicIndexing")]
		bool EligibleForPublicIndexing { [Bind ("isEligibleForPublicIndexing")] get; set; }

		/*
		[NoWatch]
		[NoTV]
		[MacCatalyst (13, 1)]
		[NullAllowed]
		[Export ("contentAttributeSet", ArgumentSemantic.Copy)] // From CSSearchableItemAttributeSet.h
		//CSSearchableItemAttributeSet ContentAttributeSet { get; set; }
		*/

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("referrerURL", ArgumentSemantic.Copy)]
		NSUrl ReferrerUrl { get; set; }

		// From NSUserActivity (CIBarcodeDescriptor)

		[NoWatch]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("detectedBarcodeDescriptor", ArgumentSemantic.Copy)]
		CIBarcodeDescriptor DetectedBarcodeDescriptor { get; }

		// From NSUserActivity (CLSDeepLinks)

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[NoWatch, NoTV]
		[Export ("isClassKitDeepLink")]
		bool IsClassKitDeepLink { get; }

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[NoWatch, NoTV]
		[NullAllowed, Export ("contextIdentifierPath", ArgumentSemantic.Strong)]
		string [] ContextIdentifierPath { get; }

		// From NSUserActivity (IntentsAdditions)

		[Watch (5, 0), NoTV]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("suggestedInvocationPhrase")]
		string SuggestedInvocationPhrase {
			// This _simply_ ensure that the Intents namespace (via the enum) will be present which,
			// in turns, means that the Intents.framework is loaded into memory and this makes the
			// selectors (getter and setter) work at runtime. Other selectors do not need it.
			// reference: https://github.com/xamarin/xamarin-macios/issues/4894
			[PreSnippet ("GC.KeepAlive (Intents.INCallCapabilityOptions.AudioCall); // no-op to ensure Intents.framework is loaded into memory", Optimizable = true)]
			get;
			[PreSnippet ("GC.KeepAlive (Intents.INCallCapabilityOptions.AudioCall); // no-op to ensure Intents.framework is loaded into memory", Optimizable = true)]
			set;
		}

		[Watch (5, 0), NoTV, NoMac]
		[MacCatalyst (13, 1)]
		[Export ("eligibleForPrediction")]
		bool EligibleForPrediction { [Bind ("isEligibleForPrediction")] get; set; }

		[Watch (5, 0), NoTV]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("persistentIdentifier")]
		string PersistentIdentifier { get; set; }

		[Watch (5, 0), NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Async]
		[Export ("deleteSavedUserActivitiesWithPersistentIdentifiers:completionHandler:")]
		extern void DeleteSavedUserActivities (string [] persistentIdentifiers, Action handler);

		[Watch (5, 0), NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Async]
		[Export ("deleteAllSavedUserActivitiesWithCompletionHandler:")]
		extern void DeleteAllSavedUserActivities (Action handler);

		// Inlined from NSUserActivity (UISceneActivationConditions)

		[iOS (13, 0), TV (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("targetContentIdentifier")]
		string TargetContentIdentifier { get; set; }

#if HAS_APPCLIP
		// Inlined from NSUserActivity (AppClip)
		[iOS (14,0)][NoTV][NoMac][NoWatch]
		[MacCatalyst (14, 0)]
		[Export ("appClipActivationPayload", ArgumentSemantic.Strong)]
		[NullAllowed]
		APActivationPayload AppClipActivationPayload { get; }
#endif
	}

	[MacCatalyst (13, 1)]
	[Static]
	public partial class NSUserActivityType {
		[Field ("NSUserActivityTypeBrowsingWeb")]
		NSString BrowsingWeb { get; }
	}

	partial class INSUserActivityDelegate { }

	[MacCatalyst (13, 1)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))] 
	partial class NSUserActivityDelegate {
		[Export ("userActivityWillSave:")]
		extern void UserActivityWillSave (NSUserActivity userActivity);

		[Export ("userActivityWasContinued:")]
		extern void UserActivityWasContinued (NSUserActivity userActivity);

		[Export ("userActivity:didReceiveInputStream:outputStream:")]
		extern void UserActivityReceivedData (NSUserActivity userActivity, NSInputStream inputStream, NSOutputStream outputStream);
	}


	//
	// Just a category so we can document the three methods together
	//
	//[Category, BaseType (typeof (NSUrl))]
	partial class NSUrl_PromisedItems {
		[MacCatalyst (13, 1)]
		[Export ("checkPromisedItemIsReachableAndReturnError:")]
		extern bool CheckPromisedItemIsReachable (out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("getPromisedItemResourceValue:forKey:error:")]
		extern bool GetPromisedItemResourceValue (out NSObject value, NSString key, out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("promisedItemResourceValuesForKeys:error:")]
		[return: NullAllowed]
		extern NSDictionary GetPromisedItemResourceValues (NSString [] keys, out NSError error);

	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Name = "NSURLQueryItem")]
	partial class NSUrlQueryItem :  NSCopying {
		[DesignatedInitializer]
		[Export ("initWithName:value:")]
		extern NativeHandle Constructor (string name, string value);

		[Export ("name")]
		string Name { get; }

		[Export ("value")]
		string Value { get; }
	}

	//[Category, BaseType (typeof (NSCharacterSet))]
	partial class NSUrlUtilities_NSCharacterSet {
		[Static, Export ("URLUserAllowedCharacterSet", ArgumentSemantic.Copy)]
		static extern NSCharacterSet UrlUserAllowedCharacterSet { get; }

		[Static, Export ("URLPasswordAllowedCharacterSet", ArgumentSemantic.Copy)]
		static extern NSCharacterSet UrlPasswordAllowedCharacterSet { get; }

		[Static, Export ("URLHostAllowedCharacterSet", ArgumentSemantic.Copy)]
		static extern NSCharacterSet UrlHostAllowedCharacterSet { get; }

		[Static, Export ("URLPathAllowedCharacterSet", ArgumentSemantic.Copy)]
		static extern NSCharacterSet UrlPathAllowedCharacterSet { get; }

		[Static, Export ("URLQueryAllowedCharacterSet", ArgumentSemantic.Copy)]
		static extern NSCharacterSet UrlQueryAllowedCharacterSet { get; }

		[Static, Export ("URLFragmentAllowedCharacterSet", ArgumentSemantic.Copy)]
		static extern NSCharacterSet UrlFragmentAllowedCharacterSet { get; }
	}

	[BaseType (typeof (NSObject), Name = "NSURLCache")]
	partial class NSUrlCache {
		[Export ("sharedURLCache", ArgumentSemantic.Strong), Static]
		NSUrlCache SharedCache { get; set; }

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use the overload that accepts an 'NSUrl' parameter instead.")]
		[Export ("initWithMemoryCapacity:diskCapacity:diskPath:")]
		extern NativeHandle Constructor (nuint memoryCapacity, nuint diskCapacity, [NullAllowed] string diskPath);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("initWithMemoryCapacity:diskCapacity:directoryURL:")]
		extern NativeHandle Constructor (nuint memoryCapacity, nuint diskCapacity, [NullAllowed] NSUrl directoryUrl);

		[Export ("cachedResponseForRequest:")]
		extern NSCachedUrlResponse CachedResponseForRequest (NSUrlRequest request);

		[Export ("storeCachedResponse:forRequest:")]
		extern void StoreCachedResponse (NSCachedUrlResponse cachedResponse, NSUrlRequest forRequest);

		[Export ("removeCachedResponseForRequest:")]
		extern void RemoveCachedResponse (NSUrlRequest request);

		[Export ("removeAllCachedResponses")]
		extern void RemoveAllCachedResponses ();

		[Export ("memoryCapacity")]
		nuint MemoryCapacity { get; set; }

		[Export ("diskCapacity")]
		nuint DiskCapacity { get; set; }

		[Export ("currentMemoryUsage")]
		nuint CurrentMemoryUsage { get; }

		[Export ("currentDiskUsage")]
		nuint CurrentDiskUsage { get; }

		[MacCatalyst (13, 1)]
		[Export ("removeCachedResponsesSinceDate:")]
		extern void RemoveCachedResponsesSinceDate (NSDate date);

		[MacCatalyst (13, 1)]
		[Export ("storeCachedResponse:forDataTask:")]
		extern void StoreCachedResponse (NSCachedUrlResponse cachedResponse, NSUrlSessionDataTask dataTask);

		[MacCatalyst (13, 1)]
		[Export ("getCachedResponseForDataTask:completionHandler:")]
		[Async]
		extern void GetCachedResponse (NSUrlSessionDataTask dataTask, Action<NSCachedUrlResponse> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("removeCachedResponseForDataTask:")]
		extern void RemoveCachedResponse (NSUrlSessionDataTask dataTask);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Name = "NSURLComponents")]
	partial class NSUrlComponents : NSCopying {
		[Export ("initWithURL:resolvingAgainstBaseURL:")]
		extern NativeHandle Constructor (NSUrl url, bool resolveAgainstBaseUrl);

		[Static, Export ("componentsWithURL:resolvingAgainstBaseURL:")]
		extern NSUrlComponents FromUrl (NSUrl url, bool resolvingAgainstBaseUrl);

		[Export ("initWithString:")]
		extern NativeHandle Constructor (string urlString);

		[Static, Export ("componentsWithString:")]
		extern NSUrlComponents FromString (string urlString);

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("componentsWithString:encodingInvalidCharacters:")]
		[return: NullAllowed]
		static extern NSUrlComponents FromString (string url, bool encodingInvalidCharacters);

		[Export ("URL")]
		NSUrl Url { get; }

		[Export ("URLRelativeToURL:")]
		extern NSUrl GetRelativeUrl (NSUrl baseUrl);

		[NullAllowed] // by default this property is null
		[Export ("scheme", ArgumentSemantic.Copy)]
		string Scheme { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("user", ArgumentSemantic.Copy)]
		string User { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("password", ArgumentSemantic.Copy)]
		string Password { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("host", ArgumentSemantic.Copy)]
		string Host { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("port", ArgumentSemantic.Copy)]
		NSNumber Port { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("path", ArgumentSemantic.Copy)]
		string Path { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("query", ArgumentSemantic.Copy)]
		string Query { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("fragment", ArgumentSemantic.Copy)]
		string Fragment { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("percentEncodedUser", ArgumentSemantic.Copy)]
		string PercentEncodedUser { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("percentEncodedPassword", ArgumentSemantic.Copy)]
		string PercentEncodedPassword { get; set; }

		[NullAllowed] // by default this property is null
		[Advice ("Use 'EncodedHost' instead.")]
		[Export ("percentEncodedHost", ArgumentSemantic.Copy)]
		string PercentEncodedHost { get; set; }

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		[NullAllowed, Export ("encodedHost")]
		string EncodedHost { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("percentEncodedPath", ArgumentSemantic.Copy)]
		string PercentEncodedPath { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("percentEncodedQuery", ArgumentSemantic.Copy)]
		string PercentEncodedQuery { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("percentEncodedFragment", ArgumentSemantic.Copy)]
		string PercentEncodedFragment { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed] // by default this property is null
		[Export ("queryItems")]
		NSUrlQueryItem [] QueryItems { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("string")]
		extern string AsString ();

		[MacCatalyst (13, 1)]
		[Export ("rangeOfScheme")]
		NSRange RangeOfScheme { get; }

		[MacCatalyst (13, 1)]
		[Export ("rangeOfUser")]
		NSRange RangeOfUser { get; }

		[MacCatalyst (13, 1)]
		[Export ("rangeOfPassword")]
		NSRange RangeOfPassword { get; }

		[MacCatalyst (13, 1)]
		[Export ("rangeOfHost")]
		NSRange RangeOfHost { get; }

		[MacCatalyst (13, 1)]
		[Export ("rangeOfPort")]
		NSRange RangeOfPort { get; }

		[MacCatalyst (13, 1)]
		[Export ("rangeOfPath")]
		NSRange RangeOfPath { get; }

		[MacCatalyst (13, 1)]
		[Export ("rangeOfQuery")]
		NSRange RangeOfQuery { get; }

		[MacCatalyst (13, 1)]
		[Export ("rangeOfFragment")]
		NSRange RangeOfFragment { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("percentEncodedQueryItems", ArgumentSemantic.Copy)]
		NSUrlQueryItem [] PercentEncodedQueryItems { get; set; }
	}

	[BaseType (typeof (NSObject), Name = "NSURLAuthenticationChallenge")]
	// 'init' returns NIL
	[DisableDefaultCtor]
	partial class NSUrlAuthenticationChallenge : NSSecureCoding {
		[Export ("initWithProtectionSpace:proposedCredential:previousFailureCount:failureResponse:error:sender:")]
		extern NativeHandle Constructor (NSUrlProtectionSpace space, NSUrlCredential credential, nint previousFailureCount, [NullAllowed] NSUrlResponse response, [NullAllowed] NSError error, NSUrlConnection sender);

		[Export ("initWithAuthenticationChallenge:sender:")]
		extern NativeHandle Constructor (NSUrlAuthenticationChallenge challenge, NSUrlConnection sender);

		[Export ("protectionSpace")]
		NSUrlProtectionSpace ProtectionSpace { get; }

		[Export ("proposedCredential")]
		NSUrlCredential ProposedCredential { get; }

		[Export ("previousFailureCount")]
		nint PreviousFailureCount { get; }

		[Export ("failureResponse")]
		NSUrlResponse FailureResponse { get; }

		[Export ("error")]
		NSError Error { get; }

		[Export ("sender")]
		NSUrlConnection Sender { get; }
	}

	[Protocol (Name = "NSURLAuthenticationChallengeSender")]
#if NET
	partial class NSUrlAuthenticationChallengeSender {
#else
	[Model]
	[BaseType (typeof (NSObject))]
	partial class NSURLAuthenticationChallengeSender {
#endif
		[Abstract]
		[Export ("useCredential:forAuthenticationChallenge:")]
		extern void UseCredential (NSUrlCredential credential, NSUrlAuthenticationChallenge challenge);

		[Abstract]
		[Export ("continueWithoutCredentialForAuthenticationChallenge:")]
		extern void ContinueWithoutCredential (NSUrlAuthenticationChallenge challenge);

		[Abstract]
		[Export ("cancelAuthenticationChallenge:")]
		extern void CancelAuthenticationChallenge (NSUrlAuthenticationChallenge challenge);

		[Export ("performDefaultHandlingForAuthenticationChallenge:")]
		extern void PerformDefaultHandling (NSUrlAuthenticationChallenge challenge);

		[Export ("rejectProtectionSpaceAndContinueWithChallenge:")]
		extern void RejectProtectionSpaceAndContinue (NSUrlAuthenticationChallenge challenge);
	}


	delegate void NSUrlConnectionDataResponse (NSUrlResponse response, NSData data, NSError error);

	[BaseType (typeof (NSObject), Name = "NSURLConnection")]
	partial class NSUrlConnection :
#if NET
		NSUrlAuthenticationChallengeSender
#else
		NSURLAuthenticationChallengeSender
#endif
	{
		[Export ("canHandleRequest:")]
		[Static]
		static extern bool CanHandleRequest (NSUrlRequest request);

		[return: NullAllowed]
		[NoWatch]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSUrlSession' instead.")]
		[Export ("connectionWithRequest:delegate:")]
		[Static]
		extern NSUrlConnection FromRequest (NSUrlRequest request, [NullAllowed] INSUrlConnectionDelegate connectionDelegate);

	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSUrlSession' instead.")]
		[Export ("initWithRequest:delegate:")]
		extern NativeHandle Constructor (NSUrlRequest request, [NullAllowed] INSUrlConnectionDelegate connectionDelegate);

		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSUrlSession' instead.")]
		[Export ("initWithRequest:delegate:startImmediately:")]
		extern NativeHandle Constructor (NSUrlRequest request, [NullAllowed] INSUrlConnectionDelegate connectionDelegate, bool startImmediately);

		[Export ("start")]
		extern void Start ();

		[Export ("cancel")]
		extern void Cancel ();

		[Export ("scheduleInRunLoop:forMode:")]
		extern void Schedule (NSRunLoop aRunLoop, NSString forMode);

		[Wrap ("Schedule (aRunLoop, forMode.GetConstant ()!)")]
		extern void Schedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);

		[Export ("unscheduleFromRunLoop:forMode:")]
		extern void Unschedule (NSRunLoop aRunLoop, NSString forMode);

		[Wrap ("Unschedule (aRunLoop, forMode.GetConstant ()!)")]
		extern void Unschedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("originalRequest")]
		NSUrlRequest OriginalRequest { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("currentRequest")]
		NSUrlRequest CurrentRequest { get; }

		[Export ("setDelegateQueue:")]
		extern void SetDelegateQueue (NSOperationQueue queue);

	
		[NoWatch]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSUrlSession' instead.")]
		[Static]
		[Export ("sendSynchronousRequest:returningResponse:error:")]
		[return: NullAllowed]
		static extern NSData SendSynchronousRequest (NSUrlRequest request, out NSUrlResponse response, out NSError error);
		
		[NoWatch]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSUrlSession.CreateDataTask' instead.")]
		[Static]
		[Export ("sendAsynchronousRequest:queue:completionHandler:")]
		[Async (ResultTypeName = "NSUrlAsyncResult", MethodName = "SendRequestAsync")]
		extern void SendAsynchronousRequest (NSUrlRequest request, NSOperationQueue queue, NSUrlConnectionDataResponse completionHandler);
	}

	partial class INSUrlConnectionDelegate { }

	[BaseType (typeof (NSObject), Name = "NSURLConnectionDelegate")]
	[Model]
	[Protocol]
	partial class NSUrlConnectionDelegate {
		[Export ("connection:canAuthenticateAgainstProtectionSpace:")]

		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'WillSendRequestForAuthenticationChallenge' instead.")]
		extern bool CanAuthenticateAgainstProtectionSpace (NSUrlConnection connection, NSUrlProtectionSpace protectionSpace);

		[Export ("connection:didReceiveAuthenticationChallenge:")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'WillSendRequestForAuthenticationChallenge' instead.")]
		extern void ReceivedAuthenticationChallenge (NSUrlConnection connection, NSUrlAuthenticationChallenge challenge);

		[Export ("connection:didCancelAuthenticationChallenge:")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'WillSendRequestForAuthenticationChallenge' instead.")]
		extern void CanceledAuthenticationChallenge (NSUrlConnection connection, NSUrlAuthenticationChallenge challenge);

		[Export ("connectionShouldUseCredentialStorage:")]
		extern bool ConnectionShouldUseCredentialStorage (NSUrlConnection connection);

		[Export ("connection:didFailWithError:")]
		extern void FailedWithError (NSUrlConnection connection, NSError error);

		[Export ("connection:willSendRequestForAuthenticationChallenge:")]
		extern void WillSendRequestForAuthenticationChallenge (NSUrlConnection connection, NSUrlAuthenticationChallenge challenge);
	}

	[BaseType (typeof (NSUrlConnectionDelegate), Name = "NSURLConnectionDataDelegate")]
	[Protocol, Model]
	partial class NSUrlConnectionDataDelegate {

		[Export ("connection:willSendRequest:redirectResponse:")]
		extern NSUrlRequest WillSendRequest (NSUrlConnection connection, NSUrlRequest request, NSUrlResponse response);

		[Export ("connection:didReceiveResponse:")]
		extern void ReceivedResponse (NSUrlConnection connection, NSUrlResponse response);

		[Export ("connection:didReceiveData:")]
		extern void ReceivedData (NSUrlConnection connection, NSData data);

		[Export ("connection:needNewBodyStream:")]
		extern NSInputStream NeedNewBodyStream (NSUrlConnection connection, NSUrlRequest request);

		[Export ("connection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
		extern void SentBodyData (NSUrlConnection connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);

		[Export ("connection:willCacheResponse:")]
		extern NSCachedUrlResponse WillCacheResponse (NSUrlConnection connection, NSCachedUrlResponse cachedResponse);

		[Export ("connectionDidFinishLoading:")]
		extern void FinishedLoading (NSUrlConnection connection);
	}

	[BaseType (typeof (NSUrlConnectionDelegate), Name = "NSURLConnectionDownloadDelegate")]
	[Model]
	[Protocol]
	partial class NSUrlConnectionDownloadDelegate {
		[Export ("connection:didWriteData:totalBytesWritten:expectedTotalBytes:")]
		extern void WroteData (NSUrlConnection connection, long bytesWritten, long totalBytesWritten, long expectedTotalBytes);

		[Export ("connectionDidResumeDownloading:totalBytesWritten:expectedTotalBytes:")]
		extern void ResumedDownloading (NSUrlConnection connection, long totalBytesWritten, long expectedTotalBytes);

		[Abstract]
		[Export ("connectionDidFinishDownloading:destinationURL:")]
		extern void FinishedDownloading (NSUrlConnection connection, NSUrl destinationUrl);
	}

	

	[BaseType (typeof (NSObject), Name = "NSURLCredentialStorage")]
	// init returns NIL -> SharedCredentialStorage
	[DisableDefaultCtor]
	partial class NSUrlCredentialStorage {
		[Static]
		[Export ("sharedCredentialStorage", ArgumentSemantic.Strong)]
		static extern NSUrlCredentialStorage SharedCredentialStorage { get; }

		[Export ("credentialsForProtectionSpace:")]
		extern NSDictionary GetCredentials (NSUrlProtectionSpace forProtectionSpace);

		[Export ("allCredentials")]
		extern NSDictionary AllCredentials { get; }

		[Export ("setCredential:forProtectionSpace:")]
		extern void SetCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace);

		[Export ("removeCredential:forProtectionSpace:")]
		extern void RemoveCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace);

		[Export ("defaultCredentialForProtectionSpace:")]
		extern NSUrlCredential GetDefaultCredential (NSUrlProtectionSpace forProtectionSpace);

		[Export ("setDefaultCredential:forProtectionSpace:")]
		extern void SetDefaultCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace);

		[MacCatalyst (13, 1)]
		[Export ("removeCredential:forProtectionSpace:options:")]
		extern void RemoveCredential (NSUrlCredential credential, NSUrlProtectionSpace forProtectionSpace, NSDictionary options);

		[MacCatalyst (13, 1)]
		[Field ("NSURLCredentialStorageRemoveSynchronizableCredentials")]
		NSString RemoveSynchronizableCredentials { get; }

		[Field ("NSURLCredentialStorageChangedNotification")]
		[Notification]
		NSString ChangedNotification { get; }

		[MacCatalyst (13, 1)]
		[Async]
		[Export ("getCredentialsForProtectionSpace:task:completionHandler:")]
		extern void GetCredentials (NSUrlProtectionSpace protectionSpace, NSUrlSessionTask task, [NullAllowed] Action<NSDictionary> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("setCredential:forProtectionSpace:task:")]
		extern void SetCredential (NSUrlCredential credential, NSUrlProtectionSpace protectionSpace, NSUrlSessionTask task);

		[MacCatalyst (13, 1)]
		[Export ("removeCredential:forProtectionSpace:options:task:")]
		extern void RemoveCredential (NSUrlCredential credential, NSUrlProtectionSpace protectionSpace, NSDictionary options, NSUrlSessionTask task);

		[MacCatalyst (13, 1)]
		[Async]
		[Export ("getDefaultCredentialForProtectionSpace:task:completionHandler:")]
		extern void GetDefaultCredential (NSUrlProtectionSpace space, NSUrlSessionTask task, [NullAllowed] Action<NSUrlCredential> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("setDefaultCredential:forProtectionSpace:task:")]
		extern void SetDefaultCredential (NSUrlCredential credential, NSUrlProtectionSpace protectionSpace, NSUrlSessionTask task);

	}

	public delegate void NSUrlSessionPendingTasks (NSUrlSessionTask [] dataTasks, NSUrlSessionTask [] uploadTasks, NSUrlSessionTask [] downloadTasks);
	public delegate void NSUrlSessionAllPendingTasks (NSUrlSessionTask [] tasks);
	public delegate void NSUrlSessionResponse (NSData data, NSUrlResponse response, NSError error);
	public delegate void NSUrlSessionDownloadResponse (NSUrl data, NSUrlResponse response, NSError error);

	public delegate void NSUrlDownloadSessionResponse (NSUrl location, NSUrlResponse response, NSError error);

	public partial class INSUrlSessionDelegate { }

	//
	// Some of the XxxTaskWith methods that take a completion were flagged as allowing a null in
	// 083d9cba1eb997eac5c5ded77db32180c3eef566 with comment:
	//
	// "Add missing [NullAllowed] on NSUrlSession since the
	// delegate is optional and the handler can be null when one
	// is provided (but requiring a delegate along with handlers
	// only duplicates code)"
	//
	// but Apple has flagged these as not allowing null.
	//
	// Leaving the null allowed for now.
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Name = "NSURLSession")]
	[DisableDefaultCtorAttribute]
	public partial class NSUrlSession {

		[Static, Export ("sharedSession", ArgumentSemantic.Strong)]
		public static NSUrlSession SharedSession { get; }

		[Static, Export ("sessionWithConfiguration:")]
		public static extern NSUrlSession FromConfiguration (NSUrlSessionConfiguration configuration);

		[Static, Export ("sessionWithConfiguration:delegate:delegateQueue:")]
		public static extern NSUrlSession FromWeakConfiguration (NSUrlSessionConfiguration configuration, [NullAllowed] NSObject weakDelegate, [NullAllowed] NSOperationQueue delegateQueue);

#if !NET
		[Obsolete ("Use the overload with a 'INSUrlSessionDelegate' parameter.")]
		[Static, Wrap ("FromWeakConfiguration (configuration, sessionDelegate, delegateQueue);")]
		NSUrlSession FromConfiguration (NSUrlSessionConfiguration configuration, NSUrlSessionDelegate sessionDelegate, [NullAllowed] NSOperationQueue delegateQueue);
#endif
		[Static, Wrap ("FromWeakConfiguration (configuration, (NSObject) sessionDelegate, delegateQueue);")]
		public static extern NSUrlSession FromConfiguration (NSUrlSessionConfiguration configuration, INSUrlSessionDelegate sessionDelegate, [NullAllowed] NSOperationQueue delegateQueue);

		[Export ("delegateQueue", ArgumentSemantic.Retain)]
		public NSOperationQueue DelegateQueue { get; }

		[Export ("delegate", ArgumentSemantic.Retain), NullAllowed]
		public NSObject WeakDelegate { get; }

		[Wrap ("WeakDelegate")]
		public INSUrlSessionDelegate Delegate { get; }

		[Export ("configuration", ArgumentSemantic.Copy)]
		public NSUrlSessionConfiguration Configuration { get; }

		[NullAllowed]
		[Export ("sessionDescription", ArgumentSemantic.Copy)]
		public string? SessionDescription { get; set; }

		[Export ("finishTasksAndInvalidate")]
		public extern void FinishTasksAndInvalidate ();

		[Export ("invalidateAndCancel")]
		public extern void InvalidateAndCancel ();

		[Export ("resetWithCompletionHandler:")]
		[Async]
		public extern void Reset (Action completionHandler);

		[Export ("flushWithCompletionHandler:")]
		[Async]
		public extern void Flush (Action completionHandler);

		// Fixed version (breaking change) only for NET
		[Export ("getTasksWithCompletionHandler:")]
		[Async (ResultTypeName = "NSUrlSessionActiveTasks")]
		public extern void GetTasks (NSUrlSessionPendingTasks completionHandler);

#if !NET
		// Workaround, not needed for NET+
		[Sealed]
		[Export ("getTasksWithCompletionHandler:")]
		[Async (ResultTypeName = "NSUrlSessionActiveTasks2")]
		void GetTasks2 (NSUrlSessionPendingTasks2 completionHandler);
#endif

		[Export ("dataTaskWithRequest:")]
		//[return: ForcedType]
		public extern NSUrlSessionDataTask CreateDataTask (NSUrlRequest request);

		[Export ("dataTaskWithURL:")]
		//[return: ForcedType]
		public extern NSUrlSessionDataTask CreateDataTask (NSUrl url);

		[Export ("uploadTaskWithRequest:fromFile:")]
		//[return: ForcedType]
		public extern NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSUrl fileURL);

		[Export ("uploadTaskWithRequest:fromData:")]
		//[return: ForcedType]
		public extern NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSData bodyData);

		[Export ("uploadTaskWithStreamedRequest:")]
		//[return: ForcedType]
		public extern NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request);

		[Export ("downloadTaskWithRequest:")]
		//[return: ForcedType]
		public extern 	NSUrlSessionDownloadTask CreateDownloadTask (NSUrlRequest request);

		[Export ("downloadTaskWithURL:")]
		//[return: ForcedType]
		public extern NSUrlSessionDownloadTask CreateDownloadTask (NSUrl url);

		[Export ("downloadTaskWithResumeData:")]
		//[return: ForcedType]
		public extern NSUrlSessionDownloadTask CreateDownloadTask (NSData resumeData);

		[Export ("dataTaskWithRequest:completionHandler:")]
		//[return: ForcedType]
		[Async (ResultTypeName = "NSUrlSessionDataTaskRequest", PostNonResultSnippet = "result.Resume ();")]
		public extern NSUrlSessionDataTask CreateDataTask (NSUrlRequest request, [NullAllowed] NSUrlSessionResponse completionHandler);

		[Export ("dataTaskWithURL:completionHandler:")]
		//[return: ForcedType]
		[Async (ResultTypeName = "NSUrlSessionDataTaskRequest", PostNonResultSnippet = "result.Resume ();")]
		public extern NSUrlSessionDataTask CreateDataTask (NSUrl url, [NullAllowed] NSUrlSessionResponse completionHandler);

		[Export ("uploadTaskWithRequest:fromFile:completionHandler:")]
		//[return: ForcedType]
		[Async (ResultTypeName = "NSUrlSessionDataTaskRequest", PostNonResultSnippet = "result.Resume ();")]
		public extern NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSUrl fileURL, NSUrlSessionResponse completionHandler);

		[Export ("uploadTaskWithRequest:fromData:completionHandler:")]
		//[return: ForcedType]
		[Async (ResultTypeName = "NSUrlSessionDataTaskRequest", PostNonResultSnippet = "result.Resume ();")]
		public extern 	NSUrlSessionUploadTask CreateUploadTask (NSUrlRequest request, NSData bodyData, NSUrlSessionResponse completionHandler);

		[Export ("downloadTaskWithRequest:completionHandler:")]
		//[return: ForcedType]
		[Async (ResultTypeName = "NSUrlSessionDownloadTaskRequest", PostNonResultSnippet = "result.Resume ();")]
		public extern NSUrlSessionDownloadTask CreateDownloadTask (NSUrlRequest request, [NullAllowed] NSUrlDownloadSessionResponse completionHandler);

		[Export ("downloadTaskWithURL:completionHandler:")]
		//[return: ForcedType]
		[Async (ResultTypeName = "NSUrlSessionDownloadTaskRequest", PostNonResultSnippet = "result.Resume ();")]
		public extern NSUrlSessionDownloadTask CreateDownloadTask (NSUrl url, [NullAllowed] NSUrlDownloadSessionResponse completionHandler);

		[Export ("downloadTaskWithResumeData:completionHandler:")]
		//[return: ForcedType]
		[Async (ResultTypeName = "NSUrlSessionDownloadTaskRequest", PostNonResultSnippet = "result.Resume ();")]
		public extern NSUrlSessionDownloadTask CreateDownloadTaskFromResumeData (NSData resumeData, [NullAllowed] NSUrlDownloadSessionResponse completionHandler);


		[MacCatalyst (13, 1)]
		[Export ("getAllTasksWithCompletionHandler:")]
		[Async (ResultTypeName = "NSUrlSessionCombinedTasks")]
		public extern void GetAllTasks (NSUrlSessionAllPendingTasks completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("streamTaskWithHostName:port:")]
		public extern NSUrlSessionStreamTask CreateBidirectionalStream (string hostname, nint port);

		
		[NoWatch]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 15, 0, message: "Use the Network.framework instead.")]
		[Export ("streamTaskWithNetService:")]
		public extern NSUrlSessionStreamTask CreateBidirectionalStream (NSNetService service);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("webSocketTaskWithURL:")]
		public extern NSUrlSessionWebSocketTask CreateWebSocketTask (NSUrl url);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("webSocketTaskWithURL:protocols:")]
		public extern NSUrlSessionWebSocketTask CreateWebSocketTask (NSUrl url, string [] protocols);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("webSocketTaskWithRequest:")]
		public extern NSUrlSessionWebSocketTask CreateWebSocketTask (NSUrlRequest request);

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("uploadTaskWithResumeData:")]
		//[return: ForcedType]
		public extern NSUrlSessionUploadTask CreateUploadTask (NSData resumeData);

		[Async (ResultTypeName = "NSUrlSessionUploadTaskResumeRequest")]
		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("uploadTaskWithResumeData:completionHandler:")]
		//[return: ForcedType]
		public extern NSUrlSessionUploadTask CreateUploadTask (NSData resumeData, Action<NSData, NSUrlResponse, NSError> completionHandler);
	}

	[MacCatalyst (13, 1)]
	[Protocol, Model]
	[BaseType (typeof (NSUrlSessionTaskDelegate), Name = "NSURLSessionStreamDelegate")]
	partial class NSUrlSessionStreamDelegate {
		[Export ("URLSession:readClosedForStreamTask:")]
		extern void ReadClosed (NSUrlSession session, NSUrlSessionStreamTask streamTask);

		[Export ("URLSession:writeClosedForStreamTask:")]
		extern void WriteClosed (NSUrlSession session, NSUrlSessionStreamTask streamTask);

		[Export ("URLSession:betterRouteDiscoveredForStreamTask:")]
		extern void BetterRouteDiscovered (NSUrlSession session, NSUrlSessionStreamTask streamTask);

		//
		// Note: the names of this methods do not exactly match the Objective-C name
		// because it was a bad name, and does not describe what this does, so the name
		// was picked from the documentation and what it does.
		//
		[Export ("URLSession:streamTask:didBecomeInputStream:outputStream:")]
		extern void CompletedTaskCaptureStreams (NSUrlSession session, NSUrlSessionStreamTask streamTask, NSInputStream inputStream, NSOutputStream outputStream);
	}

	public delegate void NSUrlSessionDataRead (NSData data, bool atEof, NSError error);
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSUrlSessionTask), Name = "NSURLSessionStreamTask")]
	[DisableDefaultCtor] // now (xcode11) marked as deprecated
	public partial class NSUrlSessionStreamTask {
		[Export ("readDataOfMinLength:maxLength:timeout:completionHandler:")]
		[Async (ResultTypeName = "NSUrlSessionStreamDataRead")]
		public extern void ReadData (nuint minBytes, nuint maxBytes, double timeout, NSUrlSessionDataRead completionHandler);

		[Export ("writeData:timeout:completionHandler:")]
		[Async]
		public extern void WriteData (NSData data, double timeout, Action<NSError> completionHandler);

		[Export ("captureStreams")]
		public extern void CaptureStreams ();

		[Export ("closeWrite")]
		public extern void CloseWrite ();

		[Export ("closeRead")]
		public extern void CloseRead ();

		[Export ("startSecureConnection")]
		public extern void StartSecureConnection ();

	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "A secure (TLS) connection cannot become drop back to insecure (non-TLS).")]
		[Export ("stopSecureConnection")]
		public extern void StopSecureConnection ();
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Name = "NSURLSessionTask")]
	//[DisableDefaultCtor]
	public partial class NSUrlSessionTask :  NSProgressReporting {
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "This type is not meant to be user created.")]
		[Export ("init")]
		public extern NativeHandle Constructor ();

		[Export ("taskIdentifier")]
		public nuint TaskIdentifier { get; }

		[Export ("originalRequest", ArgumentSemantic.Copy), NullAllowed]
		public extern NSUrlRequest OriginalRequest { get; }

		[Export ("currentRequest", ArgumentSemantic.Copy), NullAllowed]
		public extern  NSUrlRequest CurrentRequest { get; }

		[Export ("response", ArgumentSemantic.Copy), NullAllowed]
		public extern  NSUrlResponse? Response { get; }

		[Export ("countOfBytesReceived")]
		public long BytesReceived { get; }

		[Export ("countOfBytesSent")]
		public long BytesSent { get; }

		[Export ("countOfBytesExpectedToSend")]
		public long BytesExpectedToSend { get; }

		[Export ("countOfBytesExpectedToReceive")]
		public long BytesExpectedToReceive { get; }

		[NullAllowed] // by default this property is null
		[Export ("taskDescription", ArgumentSemantic.Copy)]
		public string TaskDescription { get; set; }

		[Export ("cancel")]
		public extern void Cancel ();

		[Export ("state")]
		public NSUrlSessionTaskState State { get; }

		[Export ("error", ArgumentSemantic.Copy), NullAllowed]
		public NSError Error { get; }

		[Export ("suspend")]
		public extern void Suspend ();

		[Export ("resume")]
		public extern void Resume ();

		[Field ("NSURLSessionTransferSizeUnknown")]
		public long TransferSizeUnknown { get; }

		[MacCatalyst (13, 1)]
		[Export ("priority")]
		public float Priority { get; set; } /* float, not CGFloat */

		[Watch (7, 4), TV (14, 5), iOS (14, 5)]
		[MacCatalyst (14, 5)]
		[Export ("prefersIncrementalDelivery")]
		public bool PrefersIncrementalDelivery { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("earliestBeginDate", ArgumentSemantic.Copy)]
		public NSDate EarliestBeginDate { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("countOfBytesClientExpectsToSend")]
		public long CountOfBytesClientExpectsToSend { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("countOfBytesClientExpectsToReceive")]
		public long CountOfBytesClientExpectsToReceive { get; set; }

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Retain)]
		public NSObject WeakDelegate { get; set; }

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		public INSUrlSessionTaskDelegate Delegate { get; set; }
	}

	[Static]
	[MacCatalyst (13, 1)]
	static partial class NSUrlSessionTaskPriority {
		[Field ("NSURLSessionTaskPriorityDefault")]
		static float Default { get; } /* float, not CGFloat */

		[Field ("NSURLSessionTaskPriorityLow")]
		static float Low { get; } /* float, not CGFloat */

		[Field ("NSURLSessionTaskPriorityHigh")]
		static float High { get; } /* float, not CGFloat */
	}

	// All of the NSUrlSession APIs are either 10.10, or 10.9 and 64-bit only
	// "NSURLSession is not available for i386 targets before Mac OS X 10.10."

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSUrlSessionTask), Name = "NSURLSessionDataTask")]
	[DisableDefaultCtor]
	public partial class NSUrlSessionDataTask {
	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSURLSession.CreateDataTask' instead.")]
		[Export ("init")]
		extern NativeHandle Constructor ();
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSUrlSessionDataTask), Name = "NSURLSessionUploadTask")]
	[DisableDefaultCtor]
	public partial class NSUrlSessionUploadTask {
	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSURLSession.CreateUploadTask' instead.")]
		[Export ("init")]
		extern NativeHandle Constructor ();

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("NSURLSessionUploadTaskResumeData")]
		NSString ResumeDataKey { get; }

		[Async]
		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("cancelByProducingResumeData:")]
		extern void CancelByProducingResumeData (Action<NSData> completionHandler);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSUrlSessionTask), Name = "NSURLSessionDownloadTask")]
	[DisableDefaultCtor]
	public partial class NSUrlSessionDownloadTask {
	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSURLSession.CreateDownloadTask' instead.")]
		[Export ("init")]
		extern NativeHandle Constructor ();

		[Export ("cancelByProducingResumeData:")]
		extern void Cancel (Action<NSData> resumeCallback);
	}

	[Internal]
	[Static]
	[NoWatch]
	[MacCatalyst (13, 1)]
	static partial class ProxyConfigurationDictionaryKeys {
		[Field ("kCFNetworkProxiesHTTPEnable")]
		static NSString HttpEnableKey { get; }

		[Field ("kCFStreamPropertyHTTPProxyHost")]
		static NSString HttpProxyHostKey { get; }

		[Field ("kCFStreamPropertyHTTPProxyPort")]
		static NSString HttpProxyPortKey { get; }

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Field ("kCFNetworkProxiesHTTPSEnable")]
		static NSString HttpsEnableKey { get; }

		[Field ("kCFStreamPropertyHTTPSProxyHost")]
		static NSString HttpsProxyHostKey { get; }

		[Field ("kCFStreamPropertyHTTPSProxyPort")]
		static NSString HttpsProxyPortKey { get; }
	}

	[NoWatch]
	[MacCatalyst (13, 1)]
	//[StrongDictionary ("ProxyConfigurationDictionaryKeys")]
	partial class ProxyConfigurationDictionary: DictionaryContainer {
		bool HttpEnable { get; set; }
		string HttpProxyHost { get; set; }
		int HttpProxyPort { get; set; }
		[NoiOS, NoTV]
		[NoMacCatalyst]
		bool HttpsEnable { get; set; }
		string HttpsProxyHost { get; set; }
		int HttpsProxyPort { get; set; }
	}

	

	[MacCatalyst (13, 1)]
	[Model, BaseType (typeof (NSObject), Name = "NSURLSessionDelegate")]
	[Protocol]
	public partial class NSUrlSessionDelegate {
		[Export ("URLSession:didBecomeInvalidWithError:")]
		extern void DidBecomeInvalid (NSUrlSession session, NSError error);

		[Export ("URLSession:didReceiveChallenge:completionHandler:")]
		extern void DidReceiveChallenge (NSUrlSession session, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("URLSessionDidFinishEventsForBackgroundURLSession:")]
		extern void DidFinishEventsForBackgroundSession (NSUrlSession session);
	}

	public partial class INSUrlSessionTaskDelegate { }

	[MacCatalyst (13, 1)]
	[Model]
	[BaseType (typeof (NSUrlSessionDelegate), Name = "NSURLSessionTaskDelegate")]
	[Protocol]
	partial class NSUrlSessionTaskDelegate {

		[Export ("URLSession:task:willPerformHTTPRedirection:newRequest:completionHandler:")]
		extern void WillPerformHttpRedirection (NSUrlSession session, NSUrlSessionTask task, NSHttpUrlResponse response, NSUrlRequest newRequest, Action<NSUrlRequest> completionHandler);

		[Export ("URLSession:task:didReceiveChallenge:completionHandler:")]
		extern void DidReceiveChallenge (NSUrlSession session, NSUrlSessionTask task, NSUrlAuthenticationChallenge challenge, Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential> completionHandler);

		[Export ("URLSession:task:needNewBodyStream:")]
		extern void NeedNewBodyStream (NSUrlSession session, NSUrlSessionTask task, Action<NSInputStream> completionHandler);

		[Export ("URLSession:task:didSendBodyData:totalBytesSent:totalBytesExpectedToSend:")]
		extern void DidSendBodyData (NSUrlSession session, NSUrlSessionTask task, long bytesSent, long totalBytesSent, long totalBytesExpectedToSend);

		[Export ("URLSession:task:didCompleteWithError:")]
		extern void DidCompleteWithError (NSUrlSession session, NSUrlSessionTask task, [NullAllowed] NSError error);

		[MacCatalyst (13, 1)]
		[Export ("URLSession:task:didFinishCollectingMetrics:")]
		extern void DidFinishCollectingMetrics (NSUrlSession session, NSUrlSessionTask task, NSUrlSessionTaskMetrics metrics);

		[MacCatalyst (13, 1)]
		[Export ("URLSession:task:willBeginDelayedRequest:completionHandler:")]
		extern void WillBeginDelayedRequest (NSUrlSession session, NSUrlSessionTask task, NSUrlRequest request, Action<NSUrlSessionDelayedRequestDisposition, NSUrlRequest> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("URLSession:taskIsWaitingForConnectivity:")]
		extern void TaskIsWaitingForConnectivity (NSUrlSession session, NSUrlSessionTask task);

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		[Export ("URLSession:didCreateTask:")]
		extern void DidCreateTask (NSUrlSession session, NSUrlSessionTask task);

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("URLSession:task:didReceiveInformationalResponse:")]
		extern void DidReceiveInformationalResponse (NSUrlSession session, NSUrlSessionTask task, NSHttpUrlResponse response);

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("URLSession:task:needNewBodyStreamFromOffset:completionHandler:")]
		extern void NeedNewBodyStream (NSUrlSession session, NSUrlSessionTask task, long offset, Action<NSInputStream> completionHandler);
	}

	[MacCatalyst (13, 1)]
	[Model]
	[BaseType (typeof (NSUrlSessionTaskDelegate), Name = "NSURLSessionDataDelegate")]
	[Protocol]
	public partial class NSUrlSessionDataDelegate {
		[Export ("URLSession:dataTask:didReceiveResponse:completionHandler:")]
		extern void DidReceiveResponse (NSUrlSession session, NSUrlSessionDataTask dataTask, NSUrlResponse response, Action<NSUrlSessionResponseDisposition> completionHandler);

		[Export ("URLSession:dataTask:didBecomeDownloadTask:")]
		extern void DidBecomeDownloadTask (NSUrlSession session, NSUrlSessionDataTask dataTask, NSUrlSessionDownloadTask downloadTask);

		[Export ("URLSession:dataTask:didReceiveData:")]
		extern void DidReceiveData (NSUrlSession session, NSUrlSessionDataTask dataTask, NSData data);

		[Export ("URLSession:dataTask:willCacheResponse:completionHandler:")]
		extern void WillCacheResponse (NSUrlSession session, NSUrlSessionDataTask dataTask, NSCachedUrlResponse proposedResponse, Action<NSCachedUrlResponse> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("URLSession:dataTask:didBecomeStreamTask:")]
		extern void DidBecomeStreamTask (NSUrlSession session, NSUrlSessionDataTask dataTask, NSUrlSessionStreamTask streamTask);
	}

	[MacCatalyst (13, 1)]
	[Model]
	[BaseType (typeof (NSUrlSessionTaskDelegate), Name = "NSURLSessionDownloadDelegate")]
	[Protocol]
	partial class NSUrlSessionDownloadDelegate {

		[Abstract]
		[Export ("URLSession:downloadTask:didFinishDownloadingToURL:")]
		extern void DidFinishDownloading (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, NSUrl location);

		[Export ("URLSession:downloadTask:didWriteData:totalBytesWritten:totalBytesExpectedToWrite:")]
		extern void DidWriteData (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, long bytesWritten, long totalBytesWritten, long totalBytesExpectedToWrite);

		[Export ("URLSession:downloadTask:didResumeAtOffset:expectedTotalBytes:")]
		extern void DidResume (NSUrlSession session, NSUrlSessionDownloadTask downloadTask, long resumeFileOffset, long expectedTotalBytes);

		[Field ("NSURLSessionDownloadTaskResumeData")]
		NSString TaskResumeDataKey { get; }
	}

	partial class NSUndoManagerCloseUndoGroupEventArgs {
		// Bug in docs, see header file
		[Export ("NSUndoManagerGroupIsDiscardableKey")]
		[NullAllowed]
		bool Discardable { get; }
	}

	

	

	

	

	//partial class NSMutableDictionary<K, V> : NSDictionary { }

	

	

	[BaseType (typeof (NSObject), Name = "NSURLResponse")]
	public partial class NSUrlResponse :  NSCopying {
		[DesignatedInitializer]
		[Export ("initWithURL:MIMEType:expectedContentLength:textEncodingName:")]
		extern NativeHandle Constructor (NSUrl url, string mimetype, nint expectedContentLength, [NullAllowed] string textEncodingName);

		[Export ("URL")]
		NSUrl Url { get; }

		[Export ("MIMEType")]
		string MimeType { get; }

		[Export ("expectedContentLength")]
		long ExpectedContentLength { get; }

		[Export ("textEncodingName")]
		string TextEncodingName { get; }

		[Export ("suggestedFilename")]
		string SuggestedFilename { get; }
	}



	

	

	//[Category, BaseType (typeof (NSString))]
	partial class NSUrlUtilities_NSString {
		[Export ("stringByAddingPercentEncodingWithAllowedCharacters:")]
		extern NSString CreateStringByAddingPercentEncoding (NSCharacterSet allowedCharacters);

		[Export ("stringByRemovingPercentEncoding")]
		extern NSString CreateStringByRemovingPercentEncoding ();

		[Export ("stringByAddingPercentEscapesUsingEncoding:")]
		extern NSString CreateStringByAddingPercentEscapes (NSStringEncoding enc);

		[Export ("stringByReplacingPercentEscapesUsingEncoding:")]
		extern NSString CreateStringByReplacingPercentEscapes (NSStringEncoding enc);
	}

	// This comes from UIKit.framework/Headers/NSStringDrawing.h
	[NoMac]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class NSStringDrawingContext {
		[Export ("minimumScaleFactor")]
		nfloat MinimumScaleFactor { get; set; }

		[NoTV]
		//[Deprecated (PlatformName.iOS, 7, 0)]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("minimumTrackingAdjustment")]
		nfloat MinimumTrackingAdjustment { get; set; }

		[Export ("actualScaleFactor")]
		nfloat ActualScaleFactor { get; }

		[NoTV]
		//[Deprecated (PlatformName.iOS, 7, 0)]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("actualTrackingAdjustment")]
		nfloat ActualTrackingAdjustment { get; }

		[Export ("totalBounds")]
		CGRect TotalBounds { get; }
	}



	delegate bool NSEnumerateLinguisticTagsEnumerator (NSString tag, NSRange tokenRange, NSRange sentenceRange, ref bool stop);

	//[Category]
	[BaseType (typeof (NSString))]
	partial class NSLinguisticAnalysis {
#if NET
		[return: BindAs (typeof (NSLinguisticTag []))]
#else
		[return: BindAs (typeof (NSLinguisticTagUnit []))]
#endif
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("linguisticTagsInRange:scheme:options:orthography:tokenRanges:")]
		extern NSString [] GetLinguisticTags (NSRange range, NSString scheme, NSLinguisticTaggerOptions options, [NullAllowed] NSOrthography orthography, [NullAllowed] out NSValue [] tokenRanges);

		[Wrap ("GetLinguisticTags (This, range, scheme.GetConstant ()!, options, orthography, out tokenRanges)")]
#if NET
		extern NSLinguisticTag[] GetLinguisticTags (NSRange range, NSLinguisticTagScheme scheme, NSLinguisticTaggerOptions options, [NullAllowed] NSOrthography orthography, [NullAllowed] out NSValue[] tokenRanges);
#else
		NSLinguisticTagUnit [] GetLinguisticTags (NSRange range, NSLinguisticTagScheme scheme, NSLinguisticTaggerOptions options, [NullAllowed] NSOrthography orthography, [NullAllowed] out NSValue [] tokenRanges);
#endif

		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("enumerateLinguisticTagsInRange:scheme:options:orthography:usingBlock:")]
		extern void EnumerateLinguisticTags (NSRange range, NSString scheme, NSLinguisticTaggerOptions options, [NullAllowed] NSOrthography orthography, NSEnumerateLinguisticTagsEnumerator handler);

		[Wrap ("EnumerateLinguisticTags (This, range, scheme.GetConstant ()!, options, orthography, handler)")]
		extern void EnumerateLinguisticTags (NSRange range, NSLinguisticTagScheme scheme, NSLinguisticTaggerOptions options, [NullAllowed] NSOrthography orthography, NSEnumerateLinguisticTagsEnumerator handler);
	}

	//
	// We expose NSString versions of these methods because it could
	// avoid an extra lookup in cases where there is a large volume of
	// calls being made and the keys are mostly tokens
	//
	[BaseType (typeof (NSObject)), Bind ("NSObject")]
	public partial class NSObject2 : NSObject {

		// those are to please the compiler while creating the definition .dll
		// but, for the final binary, we'll be using manually bounds alternatives
		// not the generated code
#pragma warning disable 108
		//[Manual]
		[Export ("conformsToProtocol:")]
		extern public bool ConformsToProtocol (NativeHandle /* Protocol */ aProtocol);

	//	[Manual]
		[Export ("retain")]
		extern public NSObject DangerousRetain ();

		//[Manual]
		[Export ("release")]
		extern 	public void DangerousRelease ();

		//[Manual]
		[Export ("autorelease")]
		extern public NSObject DangerousAutorelease ();
#pragma warning restore 108

		[Export ("doesNotRecognizeSelector:")]
		extern public void DoesNotRecognizeSelector (Selector sel);

		[Export ("observeValueForKeyPath:ofObject:change:context:")]
		extern public void ObserveValue (NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context);

		[Export ("addObserver:forKeyPath:options:context:")]
		extern public void AddObserver (NSObject observer, NSString keyPath, NSKeyValueObservingOptions options, IntPtr context);

		[Wrap ("AddObserver (observer, (NSString) keyPath, options, context)")]
		extern public void AddObserver (NSObject observer, string keyPath, NSKeyValueObservingOptions options, IntPtr context);

		[Export ("removeObserver:forKeyPath:context:")]
		extern public void RemoveObserver (NSObject observer, NSString keyPath, IntPtr context);

		[Wrap ("RemoveObserver (observer, (NSString) keyPath, context)")]
		extern public void RemoveObserver (NSObject observer, string keyPath, IntPtr context);

		[Export ("removeObserver:forKeyPath:")]
		extern public void RemoveObserver (NSObject observer, NSString keyPath);

		[Wrap ("RemoveObserver (observer, (NSString) keyPath)")] 
		extern public void RemoveObserver (NSObject observer, string keyPath);

		[Export ("willChangeValueForKey:")]
		extern public void WillChangeValue (string forKey);

		[Export ("didChangeValueForKey:")]
		extern public void DidChangeValue (string forKey);

		[Export ("willChange:valuesAtIndexes:forKey:")]
		extern public void WillChange (NSKeyValueChange changeKind, NSIndexSet indexes, NSString forKey);

		[Export ("didChange:valuesAtIndexes:forKey:")]
		extern public void DidChange (NSKeyValueChange changeKind, NSIndexSet indexes, NSString forKey);

		[Export ("willChangeValueForKey:withSetMutation:usingObjects:")]
		extern public void WillChange (NSString forKey, NSKeyValueSetMutationKind mutationKind, NSSet objects);

		[Export ("didChangeValueForKey:withSetMutation:usingObjects:")]
		extern public void DidChange (NSString forKey, NSKeyValueSetMutationKind mutationKind, NSSet objects);

		[Static, Export ("keyPathsForValuesAffectingValueForKey:")]
		extern public NSSet GetKeyPathsForValuesAffecting (NSString key);

		[Static, Export ("automaticallyNotifiesObserversForKey:")]
		extern public bool AutomaticallyNotifiesObserversForKey (string key);

		[Export ("valueForKey:")]
		[MarshalNativeExceptions]
		extern public NSObject ValueForKey (NSString key);

		[Export ("setValue:forKey:")]
		extern public void SetValueForKey (NSObject value, NSString key);

		[Export ("valueForKeyPath:")]
		extern public NSObject ValueForKeyPath (NSString keyPath);

		[Export ("setValue:forKeyPath:")]
		extern public void SetValueForKeyPath (NSObject value, NSString keyPath);

		[Export ("valueForUndefinedKey:")]
		extern public NSObject ValueForUndefinedKey (NSString key);

		[Export ("setValue:forUndefinedKey:")]
		extern public void SetValueForUndefinedKey (NSObject value, NSString undefinedKey);

		[Export ("setNilValueForKey:")]
		extern public void SetNilValueForKey (NSString key);

		[Export ("dictionaryWithValuesForKeys:")]
		extern public NSDictionary GetDictionaryOfValuesFromKeys (NSString [] keys);

		[Export ("setValuesForKeysWithDictionary:")]
		extern public void SetValuesForKeysWithDictionary (NSDictionary keyedValues);

		[Field ("NSKeyValueChangeKindKey")]
		public static NSString ChangeKindKey { get; }

		[Field ("NSKeyValueChangeNewKey")]
		public static NSString ChangeNewKey { get; }

		[Field ("NSKeyValueChangeOldKey")]
		public static NSString ChangeOldKey { get; }

		[Field ("NSKeyValueChangeIndexesKey")]
		public static NSString ChangeIndexesKey { get; }

		[Field ("NSKeyValueChangeNotificationIsPriorKey")]
		public static NSString ChangeNotificationIsPriorKey { get; }

		// Cocoa Bindings added by Kenneth J. Pouncey 2010/11/17
#if !NET
		[Sealed]
#endif
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("valueClassForBinding:")]
		extern Class GetBindingValueClass (NSString binding);

#if !NET
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Use 'Bind (NSString binding, NSObject observable, string keyPath, [NullAllowed] NSDictionary options)' instead.")]
		[Export ("bind:toObject:withKeyPath:options:")]
		void Bind (string binding, NSObject observable, string keyPath, [NullAllowed] NSDictionary options);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Use 'Unbind (NSString binding)' instead.")]
		[Export ("unbind:")]
		void Unbind (string binding);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Use 'GetBindingValueClass (NSString binding)' instead.")]
		[Export ("valueClassForBinding:")]
		Class BindingValueClass (string binding);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Use 'GetBindingInfo (NSString binding)' instead.")]
		[Export ("infoForBinding:")]
		NSDictionary BindingInfo (string binding);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Use 'GetBindingOptionDescriptions (NSString aBinding)' instead.")]
		[Export ("optionDescriptionsForBinding:")]
		NSObject [] BindingOptionDescriptions (string aBinding);

		[Static]
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Wrap ("GetDefaultPlaceholder (marker, (NSString) binding)")]
		NSObject GetDefaultPlaceholder (NSObject marker, string binding);

		[Static]
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Obsolete ("Use 'SetDefaultPlaceholder (NSObject placeholder, NSObject marker, NSString binding)' instead.")]
		[Wrap ("SetDefaultPlaceholder (placeholder, marker, (NSString) binding)")]
		void SetDefaultPlaceholder (NSObject placeholder, NSObject marker, string binding);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("exposedBindings")]
		NSString [] ExposedBindings ();
#else
		[NoiOS][NoMacCatalyst][NoWatch][NoTV]
		[Export ("exposedBindings")]
		extern NSString[] ExposedBindings { get; }
#endif

#if !NET
		[Sealed]
#endif
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("bind:toObject:withKeyPath:options:")]
		extern void Bind (NSString binding, NSObject observable, string keyPath, [NullAllowed] NSDictionary options);

#if !NET
		[Sealed]
#endif
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("unbind:")]
		extern void Unbind (NSString binding);

#if !NET
		[Sealed]
#endif
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("infoForBinding:")]
		extern NSDictionary GetBindingInfo (NSString binding);

#if !NET
		[Sealed]
#endif
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("optionDescriptionsForBinding:")]
		extern NSObject [] GetBindingOptionDescriptions (NSString aBinding);

		// NSPlaceholders (informal) protocol
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		[Static]
		[Export ("defaultPlaceholderForMarker:withBinding:")]
		static extern NSObject GetDefaultPlaceholder (NSObject marker, NSString binding);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		[Static]
		[Export ("setDefaultPlaceholder:forMarker:withBinding:")]
		static extern void SetDefaultPlaceholder (NSObject placeholder, NSObject marker, NSString binding);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, message: "Now on 'NSEditor' protocol.")]
		[Export ("objectDidEndEditing:")]
		extern void ObjectDidEndEditing (NSObject editor);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, message: "Now on 'NSEditor' protocol.")]
		[Export ("commitEditing")]
		extern bool CommitEditing ();

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, message: "Now on 'NSEditor' protocol.")]
		[Export ("commitEditingWithDelegate:didCommitSelector:contextInfo:")]
		extern void CommitEditing (NSObject objDelegate, Selector didCommitSelector, IntPtr contextInfo);

		[Export ("methodForSelector:")]
		extern IntPtr GetMethodForSelector (Selector sel);

		[PreSnippet ("if (!(this is INSCopying)) throw new InvalidOperationException (\"Type does not conform to NSCopying\");", Optimizable = true)]
		[Export ("copy")]
		[return: Release ()]
		extern NSObject Copy ();

		[PreSnippet ("if (!(this is INSMutableCopying)) throw new InvalidOperationException (\"Type does not conform to NSMutableCopying\");", Optimizable = true)]
		[Export ("mutableCopy")]
		[return: Release ()]
		extern NSObject MutableCopy ();

		//
		// Extra Perform methods, with selectors
		//
		[Export ("performSelector:withObject:afterDelay:inModes:")]
		extern void PerformSelector (Selector selector, [NullAllowed] NSObject withObject, double afterDelay, NSString [] nsRunLoopModes);

		[Export ("performSelector:withObject:afterDelay:")]
		extern void PerformSelector (Selector selector, [NullAllowed] NSObject withObject, double delay);

		[Export ("performSelector:onThread:withObject:waitUntilDone:")]
		extern void PerformSelector (Selector selector, NSThread onThread, [NullAllowed] NSObject withObject, bool waitUntilDone);

		[Export ("performSelector:onThread:withObject:waitUntilDone:modes:")]
		extern void PerformSelector (Selector selector, NSThread onThread, [NullAllowed] NSObject withObject, bool waitUntilDone, [NullAllowed] NSString [] nsRunLoopModes);

		[Static, Export ("cancelPreviousPerformRequestsWithTarget:")]
		extern void CancelPreviousPerformRequest (NSObject aTarget);

		[Static, Export ("cancelPreviousPerformRequestsWithTarget:selector:object:")]
		extern void CancelPreviousPerformRequest (NSObject aTarget, Selector selector, [NullAllowed] NSObject argument);

		[NoWatch]
		[MacCatalyst (13, 1)]
		[Export ("prepareForInterfaceBuilder")]
		extern void PrepareForInterfaceBuilder ();

		[NoWatch]
		[MacCatalyst (13, 1)]
#if MONOMAC
		// comes from NSNibAwaking category and does not requires calling super
#else
		[RequiresSuper] // comes from UINibLoadingAdditions category - which is decorated
#endif
		[Export ("awakeFromNib")]
		extern void AwakeFromNib ();

		[NoWatch, TV (13, 0), iOS (13, 0), NoMac]
		[MacCatalyst (13, 1)]
		[Export ("accessibilityRespondsToUserInteraction")]
		bool AccessibilityRespondsToUserInteraction { get; set; }

		[NoWatch, TV (13, 0), iOS (13, 0), NoMac]
		[MacCatalyst (13, 1)]
		[Export ("accessibilityUserInputLabels", ArgumentSemantic.Strong)]
		string [] AccessibilityUserInputLabels { get; set; }

		[NoWatch, TV (13, 0), iOS (13, 0), NoMac]
		[MacCatalyst (13, 1)]
		[Export ("accessibilityAttributedUserInputLabels", ArgumentSemantic.Copy)]
		NSAttributedString [] AccessibilityAttributedUserInputLabels { get; set; }

		[NoWatch, TV (13, 0), iOS (13, 0), NoMac]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("accessibilityTextualContext", ArgumentSemantic.Strong)]
		string AccessibilityTextualContext { get; set; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	[NoWatch]
	[NoTV]
	[NoiOS]
	[NoMacCatalyst]
	partial class NSBindingSelectionMarker : NSCopying {
		[Static]
		[Export ("multipleValuesSelectionMarker", ArgumentSemantic.Strong)]
		NSBindingSelectionMarker MultipleValuesSelectionMarker { get; }

		[Static]
		[Export ("noSelectionMarker", ArgumentSemantic.Strong)]
		NSBindingSelectionMarker NoSelectionMarker { get; }

		[Static]
		[Export ("notApplicableSelectionMarker", ArgumentSemantic.Strong)]
		NSBindingSelectionMarker NotApplicableSelectionMarker { get; }

		[NoMacCatalyst]
		[Static]
		[Export ("setDefaultPlaceholder:forMarker:onClass:withBinding:")]
		extern void SetDefaultPlaceholder ([NullAllowed] NSObject placeholder, [NullAllowed] NSBindingSelectionMarker marker, Class objectClass, string binding);

		[NoMacCatalyst]
		[Static]
		[Export ("defaultPlaceholderForMarker:onClass:withBinding:")]
		[return: NullAllowed]
		extern NSObject GetDefaultPlaceholder ([NullAllowed] NSBindingSelectionMarker marker, Class objectClass, string binding);
	}

	

	[BaseType (typeof (NSObject))]
	public partial class NSOperation : NSObject {
		[Export ("start")]
		extern public void Start ();

		[Export ("main")]
		extern public void Main ();

		[Export ("isCancelled")]
		public bool IsCancelled { get; }

		[Export ("cancel")]
		extern public void Cancel ();

		[Export ("isExecuting")]
		public bool IsExecuting { get; }

		[Export ("isFinished")]
		public bool IsFinished { get; }

		[Export ("isConcurrent")]
		public bool IsConcurrent { get; }

		[Export ("isReady")]
		public bool IsReady { get; }

		[Export ("addDependency:")]
		[PostGet ("Dependencies")]
		extern public void AddDependency (NSOperation op);

		[Export ("removeDependency:")]
		[PostGet ("Dependencies")]
		extern public void RemoveDependency (NSOperation op);

		[Export ("dependencies")]
		public NSOperation [] Dependencies { get; }

		[NullAllowed]
		[Export ("completionBlock", ArgumentSemantic.Copy)]
		public Action CompletionBlock { get; set; }

		[Export ("waitUntilFinished")]
		extern public void WaitUntilFinished ();

		[Export ("threadPriority")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		public double ThreadPriority { get; set; }

		//Detected properties
		[Export ("queuePriority")]
		public NSOperationQueuePriority QueuePriority { get; set; }

		[Export ("asynchronous")]
		public bool Asynchronous { [Bind ("isAsynchronous")] get; }

		[MacCatalyst (13, 1)]
		[Export ("qualityOfService")]
		public NSQualityOfService QualityOfService { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed] // by default this property is null
		[Export ("name")]
		public string Name { get; set; }
	}

	[BaseType (typeof (NSOperation))]
	partial class NSBlockOperation {
		[Static]
		[Export ("blockOperationWithBlock:")]
		extern NSBlockOperation Create (/* non null */ Action method);

		[Export ("addExecutionBlock:")]
		extern void AddExecutionBlock (/* non null */ Action method);

		[Export ("executionBlocks")]
		NSObject [] ExecutionBlocks { get; }
	}

	

	

	

	/*
	[BaseType (typeof (NSObject))]
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -[__NSArrayM insertObject:atIndex:]: object cannot be nil
	[DisableDefaultCtor]
	partial class NSOrthography : NSSecureCoding, NSCopying {
		[Export ("dominantScript")]
		string DominantScript { get; }

		[Export ("languageMap")]
		NSDictionary LanguageMap { get; }

		[Export ("dominantLanguage")]
		string DominantLanguage { get; }

		[Export ("allScripts")]
		string [] AllScripts { get; }

		[Export ("allLanguages")]
		string [] AllLanguages { get; }

		[Export ("languagesForScript:")]
		string [] LanguagesForScript (string script);

		[Export ("dominantLanguageForScript:")]
		string DominantLanguageForScript (string script);

		[DesignatedInitializer]
		[Export ("initWithDominantScript:languageMap:")]
		NativeHandle Constructor (string dominantScript, [NullAllowed] NSDictionary languageMap);
	}*/

	[BaseType (typeof (NSStream))]
	[DisableDefaultCtor] // crash when used
	partial class NSOutputStream {
		[DesignatedInitializer]
		[Export ("initToMemory")]
		extern NativeHandle Constructor ();

		[Export ("hasSpaceAvailable")]
		extern bool HasSpaceAvailable ();

		//[Export ("initToBuffer:capacity:")]
		//NativeHandle Constructor (uint8_t  buffer, NSUInteger capacity);

		[Export ("initToFileAtPath:append:")]
		extern NativeHandle Constructor (string path, bool shouldAppend);

		[Static]
		[Export ("outputStreamToMemory")]
		extern NSObject OutputStreamToMemory ();

		//[Static]
		//[Export ("outputStreamToBuffer:capacity:")]
		//NSObject OutputStreamToBuffer (uint8_t  buffer, NSUInteger capacity);

		[Static]
		[Export ("outputStreamToFileAtPath:append:")]
		extern static NSOutputStream CreateFile (string path, bool shouldAppend);

#if NET
		[return: NullAllowed]
		[Protected]
		[Export ("propertyForKey:"), Override]
		extern NSObject GetProperty (NSString key);

		[Protected]
		[Export ("setProperty:forKey:"), Override]
		extern bool SetProperty ([NullAllowed] NSObject property, NSString key);

#endif
	}



	[BaseType (typeof (NSObject), Name = "NSHTTPCookieStorage")]
	// NSHTTPCookieStorage implements a singleton object -> use SharedStorage since 'init' returns NIL
	[DisableDefaultCtor]
	partial class NSHttpCookieStorage {
		[Export ("sharedHTTPCookieStorage", ArgumentSemantic.Strong), Static]
		NSHttpCookieStorage SharedStorage { get; }

		[Export ("cookies")]
		NSHttpCookie [] Cookies { get; }

		[Export ("setCookie:")]
		extern void SetCookie (NSHttpCookie cookie);

		[Export ("deleteCookie:")]
		extern void DeleteCookie (NSHttpCookie cookie);

		[Export ("cookiesForURL:")]
		extern NSHttpCookie [] CookiesForUrl (NSUrl url);

		[Export ("setCookies:forURL:mainDocumentURL:")]
		extern void SetCookies (NSHttpCookie [] cookies, NSUrl forUrl, NSUrl mainDocumentUrl);

		[Export ("cookieAcceptPolicy")]
		NSHttpCookieAcceptPolicy AcceptPolicy { get; set; }

		[Export ("sortedCookiesUsingDescriptors:")]
		extern NSHttpCookie [] GetSortedCookies (NSSortDescriptor [] sortDescriptors);

		// @required - (void)removeCookiesSinceDate:(NSDate *)date;
		[MacCatalyst (13, 1)]
		[Export ("removeCookiesSinceDate:")]
		extern void RemoveCookiesSinceDate (NSDate date);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("sharedCookieStorageForGroupContainerIdentifier:")]
		extern NSHttpCookieStorage GetSharedCookieStorage (string groupContainerIdentifier);

		[MacCatalyst (13, 1)]
		[Async]
		[Export ("getCookiesForTask:completionHandler:")]
		extern void GetCookiesForTask (NSUrlSessionTask task, Action<NSHttpCookie []> completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("storeCookies:forTask:")]
		extern void StoreCookies (NSHttpCookie [] cookies, NSUrlSessionTask task);

		[Notification]
		[Field ("NSHTTPCookieManagerAcceptPolicyChangedNotification")]
		NSString CookiesChangedNotification { get; }

		[Notification]
		[Field ("NSHTTPCookieManagerCookiesChangedNotification")]
		NSString AcceptPolicyChangedNotification { get; }
	}

	[BaseType (typeof (NSUrlResponse), Name = "NSHTTPURLResponse")]
	partial class NSHttpUrlResponse {
		[Export ("initWithURL:MIMEType:expectedContentLength:textEncodingName:")]
		extern NativeHandle Constructor (NSUrl url, string mimetype, nint expectedContentLength, [NullAllowed] string textEncodingName);

		[Export ("initWithURL:statusCode:HTTPVersion:headerFields:")]
		extern NativeHandle Constructor (NSUrl url, nint statusCode, [NullAllowed] string httpVersion, [NullAllowed] NSDictionary headerFields);

		[Export ("statusCode")]
		nint StatusCode { get; }

		[Export ("allHeaderFields")]
		NSDictionary AllHeaderFields { get; }

		[Export ("localizedStringForStatusCode:")]
		[Static]
		extern static string LocalizedStringForStatusCode (nint statusCode);

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("valueForHTTPHeaderField:")]
		[return: NullAllowed]
		extern string GetHttpHeaderValue (string headerField);
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSBundle: NSObject {
		[Export ("mainBundle")]
		[Static]
		public static extern NSBundle MainBundle { get; }

		[Export ("bundleWithPath:")]
		[Static]
		public static extern NSBundle FromPath (string path);

		[DesignatedInitializer]
		[Export ("initWithPath:")]
		public static extern NativeHandle Constructor (string path);

		[Export ("bundleForClass:")]
		[Static]
		public static extern NSBundle FromClass (Class c);

		[Export ("bundleWithIdentifier:")]
		[Static]
		public static extern NSBundle FromIdentifier (string str);

#if !XAMCORE_5_0
		[Internal]
		[Export ("allBundles")]
		[Static]
		public static extern NSArray _InternalAllBundles { get; }

		[Obsolete ("Use the 'AllBundles' property instead.")]
		[Wrap ("_InternalAllBundles")]
		[Static]
		public static extern NSBundle [] _AllBundles { get; }

		[Wrap ("_InternalAllBundles")]
		[Static]
		public static extern NSBundle [] AllBundles { get; }
#else
		[Export ("allBundles")][Static]
		public static extern NSBundle [] AllBundles { get; }
#endif

		[Export ("allFrameworks")]
		[Static]
		public static extern NSBundle [] AllFrameworks { get; }

		[Export ("load")]
		public  extern bool Load ();

		[Export ("isLoaded")]
		public  extern bool IsLoaded { get; }

		[Export ("unload")]
		public  extern bool Unload ();

		[Export ("bundlePath")]
		public  extern string BundlePath { get; }

		[Export ("resourcePath")]
		public  extern string ResourcePath { get; }

		[Export ("executablePath")]
		public  extern string ExecutablePath { get; }

		[Export ("pathForAuxiliaryExecutable:")]
		public  extern string PathForAuxiliaryExecutable (string s);


		[Export ("privateFrameworksPath")]
		public  extern string PrivateFrameworksPath { get; }

		[Export ("sharedFrameworksPath")]
		public  extern string SharedFrameworksPath { get; }

		[Export ("sharedSupportPath")]
		public  extern string SharedSupportPath { get; }

		[Export ("builtInPlugInsPath")]
		public  extern string BuiltinPluginsPath { get; }

		[Export ("bundleIdentifier")]
		public  extern string BundleIdentifier { get; }

		[Export ("classNamed:")]
		public  extern Class ClassNamed (string className);

		[Export ("principalClass")]
		public  extern Class PrincipalClass { get; }

		[Export ("pathForResource:ofType:inDirectory:")]
		[Static]
		public static extern string PathForResourceAbsolute (string name, [NullAllowed] string ofType, string bundleDirectory);

		[Export ("pathForResource:ofType:")]
		public  extern string PathForResource (string name, [NullAllowed] string ofType);

		[Export ("pathForResource:ofType:inDirectory:")]
		public  extern string PathForResource (string name, [NullAllowed] string ofType, [NullAllowed] string subpath);

		[Export ("pathForResource:ofType:inDirectory:forLocalization:")]
		public  extern string PathForResource (string name, [NullAllowed] string ofType, string subpath, string localizationName);

		[Export ("localizedStringForKey:value:table:")]
		public  extern NSString GetLocalizedString ([NullAllowed] NSString key, [NullAllowed] NSString value, [NullAllowed] NSString table);

		[Export ("objectForInfoDictionaryKey:")]
		public  extern NSObject ObjectForInfoDictionary (string key);

		[Export ("developmentLocalization")]
		public  extern string DevelopmentLocalization { get; }

		[Export ("infoDictionary")]
		public  extern NSDictionary InfoDictionary { get; }

		// Additions from AppKit
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("loadNibNamed:owner:topLevelObjects:")]
		public  extern bool LoadNibNamed (string nibName, [NullAllowed] NSObject owner, out NSArray topLevelObjects);

		// https://developer.apple.com/library/mac/#documentation/Cocoa/Reference/ApplicationKit/Classes/NSBundle_AppKitAdditions/Reference/Reference.html
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Static]
		[Deprecated (PlatformName.MacOSX, 10, 8)]
		[Export ("loadNibNamed:owner:")]
		public  extern bool LoadNib (string nibName, NSObject owner);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("pathForImageResource:")]
		public  extern string PathForImageResource (string resource);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("pathForSoundResource:")]
		public  extern string PathForSoundResource (string resource);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("URLForImageResource:")]
		public  extern NSUrl GetUrlForImageResource (string resource);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("contextHelpForKey:")]
		public  extern NSAttributedString GetContextHelp (string key);

		// http://developer.apple.com/library/ios/#documentation/uikit/reference/NSBundle_UIKitAdditions/Introduction/Introduction.html
		[NoMac]
		[NoWatch]
		[MacCatalyst (13, 1)]
		[Export ("loadNibNamed:owner:options:")]
		public  extern NSArray LoadNib (string nibName, [NullAllowed] NSObject owner, [NullAllowed] NSDictionary options);

		[Export ("bundleURL")]
		public  extern NSUrl BundleUrl { get; }

		[Export ("resourceURL")]
		public  extern NSUrl ResourceUrl { get; }

		[Export ("executableURL")]
		public  extern NSUrl ExecutableUrl { get; }

		[Export ("URLForAuxiliaryExecutable:")]
		public  extern NSUrl UrlForAuxiliaryExecutable (string executable);

		[Export ("privateFrameworksURL")]
		public  extern 	NSUrl PrivateFrameworksUrl { get; }

		[Export ("sharedFrameworksURL")]
		public  extern NSUrl SharedFrameworksUrl { get; }

		[Export ("sharedSupportURL")]
		public  extern NSUrl SharedSupportUrl { get; }

		[Export ("builtInPlugInsURL")]
		public  extern NSUrl BuiltInPluginsUrl { get; }

		[Export ("initWithURL:")]
		public  extern NativeHandle Constructor (NSUrl url);

		[Static, Export ("bundleWithURL:")]
		public  extern 	NSBundle FromUrl (NSUrl url);

		[Export ("preferredLocalizations")]
		public  extern string [] PreferredLocalizations { get; }

		[Export ("localizations")]
		public  extern string [] Localizations { get; }

		[Export ("appStoreReceiptURL")]
		public  extern NSUrl AppStoreReceiptUrl { get; }

		[Export ("pathsForResourcesOfType:inDirectory:")]
		public  extern string [] PathsForResources (string fileExtension, [NullAllowed] string subDirectory);

		[Export ("pathsForResourcesOfType:inDirectory:forLocalization:")]
		public  extern string [] PathsForResources (string fileExtension, [NullAllowed] string subDirectory, [NullAllowed] string localizationName);

		[Static, Export ("pathsForResourcesOfType:inDirectory:")]
		public  extern string [] GetPathsForResources (string fileExtension, string bundlePath);

		[Static, Export ("URLForResource:withExtension:subdirectory:inBundleWithURL:")]
		public  extern NSUrl GetUrlForResource (string name, string fileExtension, [NullAllowed] string subdirectory, NSUrl bundleURL);

		[Static, Export ("URLsForResourcesWithExtension:subdirectory:inBundleWithURL:")]
		public  extern NSUrl [] GetUrlsForResourcesWithExtension (string fileExtension, [NullAllowed] string subdirectory, NSUrl bundleURL);

		[Export ("URLForResource:withExtension:")]
		public  extern NSUrl GetUrlForResource (string name, string fileExtension);

		[Export ("URLForResource:withExtension:subdirectory:")]
		public  extern NSUrl GetUrlForResource (string name, string fileExtension, [NullAllowed] string subdirectory);

		[Export ("URLForResource:withExtension:subdirectory:localization:")]
		public  extern NSUrl GetUrlForResource (string name, string fileExtension, [NullAllowed] string subdirectory, [NullAllowed] string localizationName);

		[Export ("URLsForResourcesWithExtension:subdirectory:")]
		public  extern NSUrl [] GetUrlsForResourcesWithExtension (string fileExtension, [NullAllowed] string subdirectory);

		[Export ("URLsForResourcesWithExtension:subdirectory:localization:")]
		public  extern NSUrl [] GetUrlsForResourcesWithExtension (string fileExtension, [NullAllowed] string subdirectory, [NullAllowed] string localizationName);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("preservationPriorityForTag:")]
		public  extern double GetPreservationPriority (NSString tag);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("setPreservationPriority:forTags:")]
		public  extern void SetPreservationPriority (double priority, NSSet<NSString> tags);

		[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("localizedAttributedStringForKey:value:table:")]
		public  extern NSAttributedString GetLocalizedAttributedString (string key, [NullAllowed] string value, [NullAllowed] string tableName);

		[Notification]
		[Field ("NSBundleDidLoadNotification")]
		public  extern NSString BundleDidLoadNotification { get; }
	}

	[NoMac]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSBundleResourceRequest : NSProgressReporting {
		[Export ("initWithTags:")]
		extern NativeHandle Constructor (NSSet<NSString> tags);

		[Export ("initWithTags:bundle:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (NSSet<NSString> tags, NSBundle bundle);

		[Export ("loadingPriority")]
		double LoadingPriority { get; set; }

		[Export ("tags", ArgumentSemantic.Copy)]
		NSSet<NSString> Tags { get; }

		[Export ("bundle", ArgumentSemantic.Strong)]
		NSBundle Bundle { get; }

		[Export ("beginAccessingResourcesWithCompletionHandler:")]
		[Async]
		extern void BeginAccessingResources (Action<NSError> completionHandler);

		[Export ("conditionallyBeginAccessingResourcesWithCompletionHandler:")]
		[Async]
		extern void ConditionallyBeginAccessingResources (Action<bool> completionHandler);

		[Export ("endAccessingResources")]
		extern void EndAccessingResources ();

		[Field ("NSBundleResourceRequestLowDiskSpaceNotification")]
		[Notification]
		NSString LowDiskSpaceNotification { get; }

		[Field ("NSBundleResourceRequestLoadingPriorityUrgent")]
		double LoadingPriorityUrgent { get; }
	}

	



	

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // from the docs: " you should not create these objects using alloc and init."
	partial class NSInvocation {

		[Export ("selector")]
		Selector Selector { get; set; }

		[Export ("target", ArgumentSemantic.Assign), NullAllowed]
		NSObject Target { get; set; }

		// FIXME: We need some special marshaling support to handle these buffers...
		[Internal, Export ("setArgument:atIndex:")]
		extern void _SetArgument (IntPtr buffer, nint index);

		[Internal, Export ("getArgument:atIndex:")]
		extern void _GetArgument (IntPtr buffer, nint index);

		[Internal, Export ("setReturnValue:")]
		extern void _SetReturnValue (IntPtr buffer);

		[Internal, Export ("getReturnValue:")]
		extern 	void _GetReturnValue (IntPtr buffer);

		[Export ("invoke")]
		extern void Invoke ();

		[Export ("invokeWithTarget:")]
		extern void Invoke (NSObject target);

		[Export ("methodSignature")]
		NSMethodSignature MethodSignature { get; }
	}


	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	partial class NSItemProvider : NSCopying {
		[DesignatedInitializer]
		[Export ("initWithItem:typeIdentifier:")]
		extern NativeHandle Constructor ([NullAllowed] NSObject item, string typeIdentifier);

		[Export ("initWithContentsOfURL:")]
		extern NativeHandle Constructor (NSUrl fileUrl);

		[Export ("registeredTypeIdentifiers", ArgumentSemantic.Copy)]
		string [] RegisteredTypeIdentifiers { get; }

		[Export ("registerItemForTypeIdentifier:loadHandler:")]
		extern void RegisterItemForTypeIdentifier (string typeIdentifier, NSItemProviderLoadHandler loadHandler);

		[Export ("hasItemConformingToTypeIdentifier:")]
		extern bool HasItemConformingTo (string typeIdentifier);

		[Async]
		[Export ("loadItemForTypeIdentifier:options:completionHandler:")]
		extern void LoadItem (string typeIdentifier, [NullAllowed] NSDictionary options, [NullAllowed] Action<NSObject, NSError> completionHandler);

		[Field ("NSItemProviderPreferredImageSizeKey")]
		NSString PreferredImageSizeKey { get; }

		[Export ("setPreviewImageHandler:")]
		extern void SetPreviewImageHandler (NSItemProviderLoadHandler handler);

		[Async]
		[Export ("loadPreviewImageWithOptions:completionHandler:")]
		extern void LoadPreviewImage (NSDictionary options, Action<NSObject, NSError> completionHandler);

		[Field ("NSItemProviderErrorDomain")]
		NSString ErrorDomain { get; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		[Export ("sourceFrame")]
		CGRect SourceFrame { get; }

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		[Export ("containerFrame")]
		CGRect ContainerFrame { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Export ("preferredPresentationSize")]
		CGSize PreferredPresentationSize {
			get;
			[NoMac]
			[MacCatalyst (13, 1)]
			set;
		}
/*
		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		[Export ("registerCloudKitShareWithPreparationHandler:")]
		void RegisterCloudKitShare (CloudKitRegistrationPreparationAction preparationHandler);

		[NoiOS, NoTV, NoWatch, NoMacCatalyst]
		[Export ("registerCloudKitShare:container:")]
		void RegisterCloudKitShare (CKShare share, CKContainer container);
*/
		[MacCatalyst (13, 1)]
		[Export ("registerDataRepresentationForTypeIdentifier:visibility:loadHandler:")]
		extern void RegisterDataRepresentation (string typeIdentifier, NSItemProviderRepresentationVisibility visibility, RegisterDataRepresentationLoadHandler loadHandler);

		[MacCatalyst (13, 1)]
		[Export ("registerFileRepresentationForTypeIdentifier:fileOptions:visibility:loadHandler:")]
		extern void RegisterFileRepresentation (string typeIdentifier, NSItemProviderFileOptions fileOptions, NSItemProviderRepresentationVisibility visibility, RegisterFileRepresentationLoadHandler loadHandler);

		[MacCatalyst (13, 1)]
		[Export ("registeredTypeIdentifiersWithFileOptions:")]
		extern string [] GetRegisteredTypeIdentifiers (NSItemProviderFileOptions fileOptions);

		[MacCatalyst (13, 1)]
		[Export ("hasRepresentationConformingToTypeIdentifier:fileOptions:")]
		extern bool HasConformingRepresentation (string typeIdentifier, NSItemProviderFileOptions fileOptions);

		[MacCatalyst (13, 1)]
		[Async, Export ("loadDataRepresentationForTypeIdentifier:completionHandler:")]
		extern NSProgress LoadDataRepresentation (string typeIdentifier, Action<NSData, NSError> completionHandler);

		[MacCatalyst (13, 1)]
		[Async, Export ("loadFileRepresentationForTypeIdentifier:completionHandler:")]
		extern 	NSProgress LoadFileRepresentation (string typeIdentifier, Action<NSUrl, NSError> completionHandler);

		[MacCatalyst (13, 1)]
		[Async (ResultTypeName = "LoadInPlaceResult"), Export ("loadInPlaceFileRepresentationForTypeIdentifier:completionHandler:")]
		extern NSProgress LoadInPlaceFileRepresentation (string typeIdentifier, LoadInPlaceFileRepresentationHandler completionHandler);

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("suggestedName")]
		string SuggestedName { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("initWithObject:")]
		extern NativeHandle Constructor (INSItemProviderWriting @object);

		[MacCatalyst (13, 1)]
		[Export ("registerObject:visibility:")]
		extern void RegisterObject (INSItemProviderWriting @object, NSItemProviderRepresentationVisibility visibility);

		[MacCatalyst (13, 1)]
		[Export ("registerObjectOfClass:visibility:loadHandler:")]
		extern void RegisterObject (Class aClass, NSItemProviderRepresentationVisibility visibility, RegisterObjectRepresentationLoadHandler loadHandler);

		[MacCatalyst (13, 1)]
		[Wrap ("RegisterObject (new Class (type), visibility, loadHandler)")]
		extern void RegisterObject (Type type, NSItemProviderRepresentationVisibility visibility, RegisterObjectRepresentationLoadHandler loadHandler);

		[MacCatalyst (13, 1)]
		[Export ("canLoadObjectOfClass:")]
		extern bool CanLoadObject (Class aClass);

		[MacCatalyst (13, 1)]
		[Wrap ("CanLoadObject (new Class (type))")]
		extern bool CanLoadObject (Type type);

		[MacCatalyst (13, 1)]
		[Async, Export ("loadObjectOfClass:completionHandler:")]
		extern NSProgress LoadObject (Class aClass, Action<INSItemProviderReading, NSError> completionHandler);

		// NSItemProvider_UIKitAdditions category

		[NoWatch, NoTV]
		[NoMac]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("teamData", ArgumentSemantic.Copy)]
		NSData TeamData { get; set; }

		[NoWatch, NoTV]
		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("preferredPresentationStyle", ArgumentSemantic.Assign)]
		UIPreferredPresentationStyle PreferredPresentationStyle { get; set; }

		// extension methods from CloudKit
/*
		[NoWatch, NoTV, Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("registerCKShareWithContainer:allowedSharingOptions:preparationHandler:")]
		void RegisterCKShare (CKContainer container, CKAllowedSharingOptions allowedOptions, Action preparationHandler);

		[NoWatch, NoTV, Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("registerCKShare:container:allowedSharingOptions:")]
		void RegisterCKShare (CKShare share, CKContainer container, CKAllowedSharingOptions allowedOptions);
*/
		// from partial class UTType (NSItemProvider)

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("initWithContentsOfURL:contentType:openInPlace:coordinated:visibility:")]
		extern NativeHandle Constructor (NSUrl fileUrl, [NullAllowed] UTType contentType, bool openInPlace, bool coordinated, NSItemProviderRepresentationVisibility visibility);

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("registerDataRepresentationForContentType:visibility:loadHandler:")]
		extern void RegisterDataRepresentation (UTType contentType, NSItemProviderRepresentationVisibility visibility, NSItemProviderUTTypeLoadDelegate loadHandler);

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("registerFileRepresentationForContentType:visibility:openInPlace:loadHandler:")]
		extern void RegisterFileRepresentation (UTType contentType, NSItemProviderRepresentationVisibility visibility, bool openInPlace, NSItemProviderUTTypeLoadDelegate loadHandler);

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("registeredContentTypes", ArgumentSemantic.Copy)]
		UTType [] RegisteredContentTypes { get; }

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("registeredContentTypesForOpenInPlace", ArgumentSemantic.Copy)]
		UTType [] RegisteredContentTypesForOpenInPlace { get; }

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("registeredContentTypesConformingToContentType:")]
		extern UTType [] RegisteredContentTypesConforming (UTType contentType);

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("loadDataRepresentationForContentType:completionHandler:")]
		extern NSProgress LoadDataRepresentation (UTType contentType, ItemProviderDataCompletionHandler completionHandler);

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("loadFileRepresentationForContentType:openInPlace:completionHandler:")]
		extern NSProgress LoadFileRepresentation (UTType contentType, bool openInPlace, LoadFileRepresentationHandler completionHandler);
	}

	[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
	delegate NSProgress NSItemProviderUTTypeLoadDelegate ([BlockCallback] ItemProviderDataCompletionHandler completionHandler);
	[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
	delegate void LoadFileRepresentationHandler (NSUrl fileUrl, bool openInPlace, NSError error);
	delegate NSProgress RegisterFileRepresentationLoadHandler ([BlockCallback] RegisterFileRepresentationCompletionHandler completionHandler);
	delegate void RegisterFileRepresentationCompletionHandler (NSUrl fileUrl, bool coordinated, NSError error);
	delegate void ItemProviderDataCompletionHandler (NSData data, NSError error);
	delegate NSProgress RegisterDataRepresentationLoadHandler ([BlockCallback] ItemProviderDataCompletionHandler completionHandler);
	delegate void LoadInPlaceFileRepresentationHandler (NSUrl fileUrl, bool isInPlace, NSError error);
	delegate NSProgress RegisterObjectRepresentationLoadHandler ([BlockCallback] RegisterObjectRepresentationCompletionHandler completionHandler);
	delegate void RegisterObjectRepresentationCompletionHandler (INSItemProviderWriting @object, NSError error);

	partial class INSItemProviderReading { }

	[MacCatalyst (13, 1)]
	[Protocol]
	partial class NSItemProviderReading {
		// This static method has to be implemented on each class that implements
		// this, this is not a capability that exists in C#.
		// We are inlining these on each class that implements NSItemProviderReading
		// for the sake of the method being callable from C#, for user code, the
		// user needs to manually [Export] the selector on a static method, like
		// they do for the "layer" property on CALayer subclasses.
		//
		[Static, Abstract]
		[Export ("readableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
		string [] ReadableTypeIdentifiers { get; }

		[Static, Abstract]
		[Export ("objectWithItemProviderData:typeIdentifier:error:")]
		[return: NullAllowed]
		extern INSItemProviderReading GetObject (NSData data, string typeIdentifier, [NullAllowed] out NSError outError);
	}

	partial class INSItemProviderWriting { }

	[MacCatalyst (13, 1)]
	[Protocol]
	public partial class NSItemProviderWriting {
		//
		// This static method has to be implemented on each class that implements
		// this, this is not a capability that exists in C#.
		// We are inlining these on each class that implements NSItemProviderWriting
		// for the sake of the method being callable from C#, for user code, the
		// user needs to manually [Export] the selector on a static method, like
		// they do for the "layer" property on CALayer subclasses.
		//
		[Static, Abstract]
		[Export ("writableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
		string [] WritableTypeIdentifiers { get; }

		// This is an optional method, which means the generator will inline it in any classes
		// that implements this interface. Unfortunately none of the native classes that implements
		// the protocol actually implements this method, which means that inlining the method will cause
		// introspection to complain (rightly). So comment out this method to avoid generator a lot of unusable API.
		// See also https://bugzilla.xamarin.com/show_bug.cgi?id=59308.
		//
		// [Static]
		// [Export ("itemProviderVisibilityForRepresentationWithTypeIdentifier:")]
		// NSItemProviderRepresentationVisibility GetItemProviderVisibility (string typeIdentifier);

		[Export ("writableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
		// 'WritableTypeIdentifiers' is a nicer name, but there's a static property with that name.
		string [] WritableTypeIdentifiersForItemProvider { get; }

		[Export ("itemProviderVisibilityForRepresentationWithTypeIdentifier:")]
		// 'GetItemProviderVisibility' is a nicer name, but there's a static method with that name.
		extern NSItemProviderRepresentationVisibility GetItemProviderVisibilityForTypeIdentifier (string typeIdentifier);

		[Abstract]
		[Async, Export ("loadDataWithTypeIdentifier:forItemProviderCompletionHandler:")]
		[return: NullAllowed]
		extern NSProgress LoadData (string typeIdentifier, Action<NSData, NSError> completionHandler);
	}

	[Static]
	[MacCatalyst (13, 1)]
	partial class NSJavaScriptExtension {
		[Field ("NSExtensionJavaScriptPreprocessingResultsKey")]
		extern NSString PreprocessingResultsKey { get; }

		[Field ("NSExtensionJavaScriptFinalizeArgumentKey")]
		extern NSString FinalizeArgumentKey { get; }
	}

	[MacCatalyst (13, 1)]
	partial class NSTypeIdentifier {
		[Field ("NSTypeIdentifierDateText")]
		extern NSString DateText { get; }

		[Field ("NSTypeIdentifierAddressText")]
		extern NSString AddressText { get; }

		[Field ("NSTypeIdentifierPhoneNumberText")]
		extern NSString PhoneNumberText { get; }

		[Field ("NSTypeIdentifierTransitInformationText")]
		extern NSString TransitInformationText { get; }
	}

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // `init` returns a null handle
	partial class NSMethodSignature: NSObject {
		[Static]
		[Export ("signatureWithObjCTypes:")]
		extern NSMethodSignature FromObjcTypes (IntPtr utf8objctypes);

		[Export ("numberOfArguments")]
		nuint NumberOfArguments { get; }

		[Export ("frameLength")]
		nuint FrameLength { get; }

		[Export ("methodReturnLength")]
		nuint MethodReturnLength { get; }

		[Export ("isOneway")]
		bool IsOneway { get; }

		[Export ("getArgumentTypeAtIndex:")]
		extern IntPtr GetArgumentType (nuint index);

		[Export ("methodReturnType")]
		IntPtr MethodReturnType { get; }
	}

	[BaseType (typeof (NSObject), Name = "NSJSONSerialization")]
	// Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** +[NSJSONSerialization allocWithZone:]: Do not create instances of NSJSONSerialization in this release
	[DisableDefaultCtor]
	partial class NSJsonSerialization {
		[Static]
		[Export ("isValidJSONObject:")]
		static extern bool IsValidJSONObject (NSObject obj);

		[Static]
		[Export ("dataWithJSONObject:options:error:")]
		static extern NSData Serialize (NSObject obj, NSJsonWritingOptions opt, out NSError error);

		[Static]
		[Export ("JSONObjectWithData:options:error:")]
		extern static NSObject Deserialize (NSData data, NSJsonReadingOptions opt, out NSError error);

		[Static]
		[Export ("writeJSONObject:toStream:options:error:")]
		extern static nint Serialize (NSObject obj, NSOutputStream stream, NSJsonWritingOptions opt, out NSError error);

		[Static]
		[Export ("JSONObjectWithStream:options:error:")]
		extern static NSObject Deserialize (NSInputStream stream, NSJsonReadingOptions opt, out NSError error);

	}

	[BaseType (typeof (NSIndexSet))]
	public partial class NSMutableIndexSet : NSIndexSet {
		[Export ("initWithIndex:")]
		extern public NativeHandle Constructor (nuint index);

		[Export ("initWithIndexSet:")]
		extern public NativeHandle Constructor (NSIndexSet other);

		[Export ("addIndexes:")]
		extern public void Add (NSIndexSet other);

		[Export ("removeIndexes:")]
		extern public void Remove (NSIndexSet other);

		[Export ("removeAllIndexes")]
		extern public void Clear ();

		[Export ("addIndex:")]
		extern public void Add (nuint index);

		[Export ("removeIndex:")]
		extern public void Remove (nuint index);

		[Export ("shiftIndexesStartingAtIndex:by:")]
		extern public void ShiftIndexes (nuint startIndex, nint delta);

		[Export ("addIndexesInRange:")]
		extern public void AddIndexesInRange (NSRange range);

		[Export ("removeIndexesInRange:")]
		extern public void RemoveIndexesInRange (NSRange range);
	}

	
	[NoWatch]
	[MacCatalyst (13, 1)]
	[Deprecated (PlatformName.MacCatalyst, 15, 0, message: "Use the Network.framework instead.")]
	[BaseType (typeof (NSObject),
		   Delegates = new string [] { "WeakDelegate" },
		   Events = new Type [] { typeof (NSNetServiceBrowserDelegate) })]
	partial class NSNetServiceBrowser {
		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSNetServiceBrowserDelegate Delegate { get; set; }

#if NET
		[Export ("scheduleInRunLoop:forMode:")]
		extern void Schedule (NSRunLoop aRunLoop, NSString forMode);

		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
		[Export ("removeFromRunLoop:forMode:")]
		extern void Unschedule (NSRunLoop aRunLoop, NSString forMode);
#else
		[Export ("scheduleInRunLoop:forMode:")]
		void Schedule (NSRunLoop aRunLoop, string forMode);

		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
		[Export ("removeFromRunLoop:forMode:")]
		void Unschedule (NSRunLoop aRunLoop, string forMode);
#endif

		[Wrap ("Schedule (aRunLoop, forMode.GetConstant ()!)")]
		extern void Schedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);

		[Wrap ("Unschedule (aRunLoop, forMode.GetConstant ()!)")]
		extern void Unschedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);

		[Export ("searchForBrowsableDomains")]
		extern void SearchForBrowsableDomains ();

		[Export ("searchForRegistrationDomains")]
		extern void SearchForRegistrationDomains ();

		[Export ("searchForServicesOfType:inDomain:")]
		extern void SearchForServices (string type, string domain);

		[Export ("stop")]
		extern void Stop ();

		[MacCatalyst (13, 1)]
		[Export ("includesPeerToPeer")]
		bool IncludesPeerToPeer { get; set; }
	}

	partial class INSNetServiceBrowserDelegate { }

	[NoWatch]
	[MacCatalyst (13, 1)]
	[Model, BaseType (typeof (NSObject))]
	[Protocol]
	partial class NSNetServiceBrowserDelegate {
		[Export ("netServiceBrowserWillSearch:")]
		extern void SearchStarted (NSNetServiceBrowser sender);

		[Export ("netServiceBrowserDidStopSearch:")]
		extern 	void SearchStopped (NSNetServiceBrowser sender);

		[Export ("netServiceBrowser:didNotSearch:"), EventArgs ("NSNetServiceError")]
		extern void NotSearched (NSNetServiceBrowser sender, NSDictionary errors);

		[Export ("netServiceBrowser:didFindDomain:moreComing:"), EventArgs ("NSNetDomain")]
		extern void FoundDomain (NSNetServiceBrowser sender, string domain, bool moreComing);

		[Export ("netServiceBrowser:didFindService:moreComing:"), EventArgs ("NSNetService")]
		extern void FoundService (NSNetServiceBrowser sender, NSNetService service, bool moreComing);

		[Export ("netServiceBrowser:didRemoveDomain:moreComing:"), EventArgs ("NSNetDomain")]
		extern void DomainRemoved (NSNetServiceBrowser sender, string domain, bool moreComing);

		[Export ("netServiceBrowser:didRemoveService:moreComing:"), EventArgs ("NSNetService")]
		extern void ServiceRemoved (NSNetServiceBrowser sender, NSNetService service, bool moreComing);
	}

	

	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSDistributedLock {
		[Static]
		[Export ("lockWithPath:")]
		[return: NullAllowed]
		extern NSDistributedLock FromPath (string path);

		[Export ("initWithPath:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string path);

		[Export ("tryLock")]
		extern bool TryLock ();

		[Export ("unlock")]
		extern void Unlock ();

		[Export ("breakLock")]
		extern void BreakLock ();

		[Export ("lockDate", ArgumentSemantic.Copy)]
		NSDate LockDate { get; }
	}

	/// <summary>Allows notifications to be sent to objects in other tasks.</summary>
	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (15, 0)]
	[BaseType (typeof (NSNotificationCenter))]
	partial class NSDistributedNotificationCenter {
		[Static]
		[Export ("defaultCenter")]
#if NET
		NSDistributedNotificationCenter DefaultCenter { get; }
#else
		NSDistributedNotificationCenter GetDefaultCenter ();

		[Static]
		[Advice ("Use 'GetDefaultCenter ()' for a strongly typed version.")]
		[Wrap ("GetDefaultCenter ()")]
		NSObject DefaultCenter { get; }
#endif

		[Export ("addObserver:selector:name:object:suspensionBehavior:")]
		extern void AddObserver (NSObject observer, Selector selector, [NullAllowed] string notificationName, [NullAllowed] string notificationSenderc, NSNotificationSuspensionBehavior suspensionBehavior);

		[Export ("postNotificationName:object:userInfo:deliverImmediately:")]
		extern void PostNotificationName (string name, [NullAllowed] string anObject, [NullAllowed] NSDictionary userInfo, bool deliverImmediately);

		[Export ("postNotificationName:object:userInfo:options:")]
		extern void PostNotificationName (string name, [NullAllowed] string anObjecb, [NullAllowed] NSDictionary userInfo, NSNotificationFlags options);

		[Export ("addObserver:selector:name:object:")]
		extern void AddObserver (NSObject observer, Selector aSelector, [NullAllowed] string aName, [NullAllowed] NSObject anObject);

		[Export ("postNotificationName:object:")]
		extern void PostNotificationName (string aName, [NullAllowed] string anObject);

		[Export ("postNotificationName:object:userInfo:")]
		extern void PostNotificationName (string aName, [NullAllowed] string anObject, [NullAllowed] NSDictionary aUserInfo);

		[Export ("removeObserver:name:object:")]
		extern void RemoveObserver (NSObject observer, [NullAllowed] string aName, [NullAllowed] NSObject anObject);

		//Detected properties
		[Export ("suspended")]
		bool Suspended { get; set; }

		[Field ("NSLocalNotificationCenterType")]
		NSString NSLocalNotificationCenterType { get; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSNotificationQueue {
		[Static]
		[IsThreadStatic]
		[Export ("defaultQueue", ArgumentSemantic.Strong)]
		NSNotificationQueue DefaultQueue { get; }

		[DesignatedInitializer]
		[Export ("initWithNotificationCenter:")]
		extern NativeHandle Constructor (NSNotificationCenter notificationCenter);

		[Export ("enqueueNotification:postingStyle:")]
		extern void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle);

		[Export ("enqueueNotification:postingStyle:coalesceMask:forModes:")]
#if !NET
		void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle, NSNotificationCoalescing coalesceMask, [NullAllowed] string [] modes);
#else
		extern void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle, NSNotificationCoalescing coalesceMask, [NullAllowed] NSString [] modes);

		[Wrap ("EnqueueNotification (notification, postingStyle, coalesceMask, modes?.GetConstants ())")]
		extern void EnqueueNotification (NSNotification notification, NSPostingStyle postingStyle, NSNotificationCoalescing coalesceMask, [NullAllowed] NSRunLoopMode [] modes);
#endif

		[Export ("dequeueNotificationsMatching:coalesceMask:")]
		extern void DequeueNotificationsMatchingcoalesceMask (NSNotification notification, NSNotificationCoalescing coalesceMask);
	}

	

	[Watch (5, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSValueTransformer))]
	partial class NSSecureUnarchiveFromDataTransformer {
		[Static]
		[Export ("allowedTopLevelClasses", ArgumentSemantic.Copy)]
		Class [] AllowedTopLevelClasses { get; }

		[Static]
		[Wrap ("Array.ConvertAll (AllowedTopLevelClasses, c => Class.Lookup (c))")]
		Type [] AllowedTopLevelTypes { get; }
	}

	


	[BaseType (typeof (NSFormatter))]
	partial class NSNumberFormatter {
		[Export ("stringFromNumber:")]
		extern string StringFromNumber (NSNumber number);

		[Export ("numberFromString:")]
		extern NSNumber NumberFromString (string text);

		[Static]
		[Export ("localizedStringFromNumber:numberStyle:")]
		extern string LocalizedStringFromNumbernumberStyle (NSNumber num, NSNumberFormatterStyle nstyle);

		//Detected properties
		[Export ("numberStyle")]
		NSNumberFormatterStyle NumberStyle { get; set; }

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[Export ("generatesDecimalNumbers")]
		bool GeneratesDecimalNumbers { get; set; }

		[Export ("formatterBehavior")]
		NSNumberFormatterBehavior FormatterBehavior { get; set; }

		[Static]
		[Export ("defaultFormatterBehavior")]
		NSNumberFormatterBehavior DefaultFormatterBehavior { get; set; }

		[Export ("negativeFormat")]
		string NegativeFormat { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("textAttributesForNegativeValues", ArgumentSemantic.Copy)]
		NSDictionary TextAttributesForNegativeValues { get; set; }

		[Export ("positiveFormat")]
		string PositiveFormat { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("textAttributesForPositiveValues", ArgumentSemantic.Copy)]
		NSDictionary TextAttributesForPositiveValues { get; set; }

		[Export ("allowsFloats")]
		bool AllowsFloats { get; set; }

		[Export ("decimalSeparator")]
		string DecimalSeparator { get; set; }

		[Export ("alwaysShowsDecimalSeparator")]
		bool AlwaysShowsDecimalSeparator { get; set; }

		[Export ("currencyDecimalSeparator")]
		string CurrencyDecimalSeparator { get; set; }

		[Export ("usesGroupingSeparator")]
		bool UsesGroupingSeparator { get; set; }

		[Export ("groupingSeparator")]
		string GroupingSeparator { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("zeroSymbol")]
		string ZeroSymbol { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("textAttributesForZero", ArgumentSemantic.Copy)]
		NSDictionary TextAttributesForZero { get; set; }

		[Export ("nilSymbol")]
		string NilSymbol { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("textAttributesForNil", ArgumentSemantic.Copy)]
		NSDictionary TextAttributesForNil { get; set; }

		[Export ("notANumberSymbol")]
		string NotANumberSymbol { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("textAttributesForNotANumber", ArgumentSemantic.Copy)]
		NSDictionary TextAttributesForNotANumber { get; set; }

		[Export ("positiveInfinitySymbol")]
		string PositiveInfinitySymbol { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("textAttributesForPositiveInfinity", ArgumentSemantic.Copy)]
		NSDictionary TextAttributesForPositiveInfinity { get; set; }

		[Export ("negativeInfinitySymbol")]
		string NegativeInfinitySymbol { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("textAttributesForNegativeInfinity", ArgumentSemantic.Copy)]
		NSDictionary TextAttributesForNegativeInfinity { get; set; }

		[Export ("positivePrefix")]
		string PositivePrefix { get; set; }

		[Export ("positiveSuffix")]
		string PositiveSuffix { get; set; }

		[Export ("negativePrefix")]
		string NegativePrefix { get; set; }

		[Export ("negativeSuffix")]
		string NegativeSuffix { get; set; }

		[Export ("currencyCode")]
		string CurrencyCode { get; set; }

		[Export ("currencySymbol")]
		string CurrencySymbol { get; set; }

		[Export ("internationalCurrencySymbol")]
		string InternationalCurrencySymbol { get; set; }

		[Export ("percentSymbol")]
		string PercentSymbol { get; set; }

		[Export ("perMillSymbol")]
		string PerMillSymbol { get; set; }

		[Export ("minusSign")]
		string MinusSign { get; set; }

		[Export ("plusSign")]
		string PlusSign { get; set; }

		[Export ("exponentSymbol")]
		string ExponentSymbol { get; set; }

		[Export ("groupingSize")]
		nuint GroupingSize { get; set; }

		[Export ("secondaryGroupingSize")]
		nuint SecondaryGroupingSize { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("multiplier", ArgumentSemantic.Copy)]
		NSNumber Multiplier { get; set; }

		[Export ("formatWidth")]
		nuint FormatWidth { get; set; }

		[Export ("paddingCharacter")]
		string PaddingCharacter { get; set; }

		[Export ("paddingPosition")]
		NSNumberFormatterPadPosition PaddingPosition { get; set; }

		[Export ("roundingMode")]
		NSNumberFormatterRoundingMode RoundingMode { get; set; }

		[Export ("roundingIncrement", ArgumentSemantic.Copy)]
		NSNumber RoundingIncrement { get; set; }

		[Export ("minimumIntegerDigits")]
		nint MinimumIntegerDigits { get; set; }

		[Export ("maximumIntegerDigits")]
		nint MaximumIntegerDigits { get; set; }

		[Export ("minimumFractionDigits")]
		nint MinimumFractionDigits { get; set; }

		[Export ("maximumFractionDigits")]
		nint MaximumFractionDigits { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("minimum", ArgumentSemantic.Copy)]
		NSNumber Minimum { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("maximum", ArgumentSemantic.Copy)]
		NSNumber Maximum { get; set; }

		[Export ("currencyGroupingSeparator")]
		string CurrencyGroupingSeparator { get; set; }

		[Export ("lenient")]
		bool Lenient { [Bind ("isLenient")] get; set; }

		[Export ("usesSignificantDigits")]
		bool UsesSignificantDigits { get; set; }

		[Export ("minimumSignificantDigits")]
		nuint MinimumSignificantDigits { get; set; }

		[Export ("maximumSignificantDigits")]
		nuint MaximumSignificantDigits { get; set; }

		[Export ("partialStringValidationEnabled")]
		bool PartialStringValidationEnabled { [Bind ("isPartialStringValidationEnabled")] get; set; }

		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("minimumGroupingDigits")]
		nint MinimumGroupingDigits { get; set; }
	}

	[BaseType (typeof (NSNumber))]
	public partial class NSDecimalNumber : NSNumber {
		[Export ("initWithMantissa:exponent:isNegative:")]
		public extern NativeHandle Constructor (long mantissa, short exponent, bool isNegative);

		[DesignatedInitializer]
		[Export ("initWithDecimal:")]
		public extern NativeHandle Constructor (NSDecimal dec);
		
		public NSDecimalNumber (NSDecimal dec) 
		{
			Handle = Constructor (dec);
		}

		public NSDecimalNumber(string str) : base(  double.Parse(str, System.Globalization.CultureInfo.InvariantCulture)  ){}

		[Export ("initWithString:")]
		public extern NativeHandle Constructor (string numberValue);

		[Export ("initWithString:locale:")]
		public extern NativeHandle Constructor (string numberValue, NSObject locale);

		[Export ("descriptionWithLocale:")]
		[Override]
		public extern string DescriptionWithLocale (NSLocale locale);

		[Export ("decimalValue")]
		public extern NSDecimal NSDecimalValue { get; }

		[Export ("zero", ArgumentSemantic.Copy)]
		[Static]
		public extern static NSDecimalNumber Zero { get; }

		[Export ("one", ArgumentSemantic.Copy)]
		[Static]
		public extern static NSDecimalNumber One { get; }

		[Export ("minimumDecimalNumber", ArgumentSemantic.Copy)]
		[Static]
		public extern static NSDecimalNumber MinValue { get; }

		[Export ("maximumDecimalNumber", ArgumentSemantic.Copy)]
		[Static]
		public extern static NSDecimalNumber MaxValue { get; }

		[Export ("notANumber", ArgumentSemantic.Copy)]
		[Static]
		public extern static NSDecimalNumber NaN { get; }

		//
		// All the behavior ones require:
		// id <NSDecimalNumberBehaviors>)behavior;

		[Export ("decimalNumberByAdding:")]
		public extern NSDecimalNumber Add (NSDecimalNumber d);

		[Export ("decimalNumberByAdding:withBehavior:")]
		public extern NSDecimalNumber Add (NSDecimalNumber d, NSObject Behavior);

		[Export ("decimalNumberBySubtracting:")]
		public extern NSDecimalNumber Subtract (NSDecimalNumber d);

		[Export ("decimalNumberBySubtracting:withBehavior:")]
		public extern NSDecimalNumber Subtract (NSDecimalNumber d, NSObject Behavior);

		[Export ("decimalNumberByMultiplyingBy:")]
		public extern NSDecimalNumber Multiply (NSDecimalNumber d);

		[Export ("decimalNumberByMultiplyingBy:withBehavior:")]
		public extern NSDecimalNumber Multiply (NSDecimalNumber d, NSObject Behavior);

		[Export ("decimalNumberByDividingBy:")]
		public extern NSDecimalNumber Divide (NSDecimalNumber d);

		[Export ("decimalNumberByDividingBy:withBehavior:")]
		public extern NSDecimalNumber Divide (NSDecimalNumber d, NSObject Behavior);

		[Export ("decimalNumberByRaisingToPower:")]
		public extern NSDecimalNumber RaiseTo (nuint power);

		[Export ("decimalNumberByRaisingToPower:withBehavior:")]
		public extern NSDecimalNumber RaiseTo (nuint power, [NullAllowed] NSObject Behavior);

		[Export ("decimalNumberByMultiplyingByPowerOf10:")]
		public extern NSDecimalNumber MultiplyPowerOf10 (short power);

		[Export ("decimalNumberByMultiplyingByPowerOf10:withBehavior:")]
		public extern NSDecimalNumber MultiplyPowerOf10 (short power, [NullAllowed] NSObject Behavior);

		[Export ("decimalNumberByRoundingAccordingToBehavior:")]
		public extern NSDecimalNumber Rounding (NSObject behavior);

		[Export ("compare:")]
		[Override]
		public extern  nint Compare (NSNumber other);

		[Export ("defaultBehavior", ArgumentSemantic.Strong)]
		[Static]
		public extern static NSObject DefaultBehavior { get; set; }

		[Export ("doubleValue")]
		[Override]
		public extern  double DoubleValue { get; }
	}

	

	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public partial class NSPort :  NSCopying {
		[Static, Export ("port")]
		extern NSPort Create ();

		[Export ("invalidate")]
		extern void Invalidate ();

		[Export ("isValid")]
		bool IsValid { get; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate"), NullAllowed]
		INSPortDelegate Delegate { get; set; }

		[Export ("scheduleInRunLoop:forMode:")]
		extern void ScheduleInRunLoop (NSRunLoop runLoop, NSString runLoopMode);

		[Wrap ("ScheduleInRunLoop (runLoop, runLoopMode.GetConstant ()!)")]
		extern void ScheduleInRunLoop (NSRunLoop runLoop, NSRunLoopMode runLoopMode);

		[Export ("removeFromRunLoop:forMode:")]
		extern void RemoveFromRunLoop (NSRunLoop runLoop, NSString runLoopMode);

		[Wrap ("RemoveFromRunLoop (runLoop, runLoopMode.GetConstant ()!)")]
		extern void RemoveFromRunLoop (NSRunLoop runLoop, NSRunLoopMode runLoopMode);

		// Disable warning for NSMutableArray
#pragma warning disable 618
		[Export ("sendBeforeDate:components:from:reserved:")]
		extern bool SendBeforeDate (NSDate limitDate, [NullAllowed] NSMutableArray components, [NullAllowed] NSPort receivePort, nuint headerSpaceReserved);

		[Export ("sendBeforeDate:msgid:components:from:reserved:")]
		extern bool SendBeforeDate (NSDate limitDate, nuint msgID, [NullAllowed] NSMutableArray components, [NullAllowed] NSPort receivePort, nuint headerSpaceReserved);
#pragma warning restore 618

		[Notification]
		[Field ("NSPortDidBecomeInvalidNotification")]
		NSString PortDidBecomeInvalidNotification { get; }
	}

	partial class INSPortDelegate { }

	[Model, BaseType (typeof (NSObject))]
	[Protocol]
	partial class NSPortDelegate {
		[NoMacCatalyst]
		[Export ("handlePortMessage:")]
		extern void MessageReceived (NSPortMessage message);
	}

	[BaseType (typeof (NSObject))]
	[MacCatalyst (15, 0)]
	partial class NSPortMessage : NSObject {
		[NoiOS]
		[NoWatch]
		[NoTV]
		[MacCatalyst (15, 0)]
		[DesignatedInitializer]
		[Export ("initWithSendPort:receivePort:components:")]
		extern NativeHandle Constructor ([NullAllowed] NSPort sendPort, [NullAllowed] NSPort recvPort, [NullAllowed] NSArray components);

		[NullAllowed]
		[NoiOS]
		[NoWatch]
		[NoTV]
		[MacCatalyst (15, 0)]
		[Export ("components")]
		NSArray Components { get; }

		// Apple started refusing applications that use those selectors (desk #63237)
		// The situation is a bit confusing since NSPortMessage.h is not part of iOS SDK - 
		// but the type is used (from NSPort[Delegate]) but not _itself_ documented
		// The selectors Apple *currently* dislike are removed from the iOS build
		[NoiOS]
		[NoWatch]
		[NoTV]
		[MacCatalyst (15, 0)]
		[Export ("sendBeforeDate:")]
		extern bool SendBefore (NSDate date);

		[NullAllowed]
		[NoiOS]
		[NoWatch]
		[NoTV]
		[MacCatalyst (15, 0)]
		[Export ("receivePort")]
		NSPort ReceivePort { get; }

		[NullAllowed]
		[NoiOS]
		[NoWatch]
		[NoTV]
		[MacCatalyst (15, 0)]
		[Export ("sendPort")]
		NSPort SendPort { get; }

		[NoiOS]
		[NoWatch]
		[NoTV]
		[MacCatalyst (15, 0)]
		[Export ("msgid")]
		uint MsgId { get; set; } /* uint32_t */
	}

	[BaseType (typeof (NSPort))]
	partial class NSMachPort: NSPort {
		[DesignatedInitializer]
		[Export ("initWithMachPort:")]
		extern NativeHandle Constructor (uint /* uint32_t */ machPort);

		[DesignatedInitializer]
		[Export ("initWithMachPort:options:")]
		extern NativeHandle Constructor (uint /* uint32_t */ machPort, NSMachPortRights options);

		[Static, Export ("portWithMachPort:")]
		static extern NSPort FromMachPort (uint /* uint32_t */ port);

		[Static, Export ("portWithMachPort:options:")]
		static extern NSPort FromMachPort (uint /* uint32_t */ port, NSMachPortRights options);

		[Export ("machPort")]
		uint MachPort { get; } /* uint32_t */

		[Export ("removeFromRunLoop:forMode:")]
		[Override]
		extern void RemoveFromRunLoop (NSRunLoop runLoop, NSString mode);

		// note: wrap'ed version using NSRunLoopMode will call the override

		[Export ("scheduleInRunLoop:forMode:")]
		[Override]
		extern void ScheduleInRunLoop (NSRunLoop runLoop, NSString mode);

		// note: wrap'ed version using NSRunLoopMode will call the override

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		[Override]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate"), NullAllowed]
		INSMachPortDelegate Delegate { get; set; }
	}

	partial class INSMachPortDelegate { }

	[Model, BaseType (typeof (NSPortDelegate))]
	[Protocol]
	partial class NSMachPortDelegate {
		[Export ("handleMachMessage:")]
		extern void MachMessageReceived (IntPtr msgHeader);
	}

	[BaseType (typeof (NSObject))]
	public partial class NSProcessInfo {
		[Export ("processInfo", ArgumentSemantic.Strong)]
		[Static]
		public static extern NSProcessInfo ProcessInfo { get; }

		[Export ("arguments")]
		public  extern string [] Arguments { get; }

		[Export ("environment")]
		public  extern NSDictionary Environment { get; }

		[Export ("processIdentifier")]
		public  extern int ProcessIdentifier { get; } /* int, not NSInteger */

		[Export ("globallyUniqueString")]
		public  extern string GloballyUniqueString { get; }

		[Export ("processName")]
		public  extern string ProcessName { get; set; }

		[Export ("hostName")]
		public  extern string HostName { get; }


		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'OperatingSystemVersion' or 'IsOperatingSystemAtLeastVersion' instead.")]
		[Export ("operatingSystem")]
		nint OperatingSystem { get; }


		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'OperatingSystemVersionString' instead.")]
		[Export ("operatingSystemName")]
		public  extern string OperatingSystemName { get; }

		[Export ("operatingSystemVersionString")]
		public  extern string OperatingSystemVersionString { get; }

		[Export ("physicalMemory")]
		public  extern ulong PhysicalMemory { get; }

		[Export ("processorCount")]
		public  extern nint ProcessorCount { get; }

		[Export ("activeProcessorCount")]
		public  extern nint ActiveProcessorCount { get; }

		[Export ("systemUptime")]
		public  extern double SystemUptime { get; }

		[MacCatalyst (13, 1)]
		[Export ("beginActivityWithOptions:reason:")]
		public  extern NSObject BeginActivity (NSActivityOptions options, string reason);

		[MacCatalyst (13, 1)]
		[Export ("endActivity:")]
		public  extern void EndActivity (NSObject activity);

		[MacCatalyst (13, 1)]
		[Export ("performActivityWithOptions:reason:usingBlock:")]
		public  extern void PerformActivity (NSActivityOptions options, string reason, Action runCode);

		[MacCatalyst (13, 1)]
		[Export ("isOperatingSystemAtLeastVersion:")]
		public  extern bool IsOperatingSystemAtLeastVersion (NSOperatingSystemVersion version);

		[MacCatalyst (13, 1)]
		[Export ("operatingSystemVersion")]
		public  extern NSOperatingSystemVersion OperatingSystemVersion { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("enableSuddenTermination")]
		public  extern void EnableSuddenTermination ();

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("disableSuddenTermination")]
		public  extern void DisableSuddenTermination ();

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("enableAutomaticTermination:")]
		public  extern void EnableAutomaticTermination (string reason);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("disableAutomaticTermination:")]
		public  extern void DisableAutomaticTermination (string reason);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("automaticTerminationSupportEnabled")]
		public  extern bool AutomaticTerminationSupportEnabled { get; set; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("performExpiringActivityWithReason:usingBlock:")]
		public  extern void PerformExpiringActivity (string reason, Action<bool> block);

		[TV (15, 0)]
		[MacCatalyst (13, 1)]
		[Export ("lowPowerModeEnabled")]
		public  extern bool LowPowerModeEnabled { [Bind ("isLowPowerModeEnabled")] get; }

		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSProcessInfoPowerStateDidChangeNotification")]
		public  extern NSString PowerStateDidChangeNotification { get; }

		[MacCatalyst (13, 1)]
		[Export ("thermalState")]
		public  extern NSProcessInfoThermalState ThermalState { get; }

		[Field ("NSProcessInfoThermalStateDidChangeNotification")]
		[MacCatalyst (13, 1)]
		[Notification]
		public  extern NSString ThermalStateDidChangeNotification { get; }

		#region NSProcessInfoPlatform (NSProcessInfo)
		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("macCatalystApp")]
		public  extern bool IsMacCatalystApplication { [Bind ("isMacCatalystApp")] get; }

		[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("iOSAppOnMac")]
		public  extern bool IsiOSApplicationOnMac { [Bind ("isiOSAppOnMac")] get; }
		#endregion

		[Field ("NSProcessInfoPerformanceProfileDidChangeNotification", "Metal")]
		[Notification]
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), NoWatch]
		public  extern NSString PerformanceProfileDidChangeNotification { get; }
	}

	[NoWatch]
	[NoTV]
	[NoiOS]
	[NoMacCatalyst]
	//[Category]
	[BaseType (typeof (NSProcessInfo))]
	partial class NSProcessInfo_NSUserInformation : NSProcessInfo {
		[Export ("userName")]
		extern string GetUserName ();

		[Export ("fullUserName")]
		extern string GetFullUserName ();
	}



	

	delegate void NSFileCoordinatorWorkerRW (NSUrl newReadingUrl, NSUrl newWritingUrl);

	partial class INSFilePresenter { }

	[BaseType (typeof (NSObject))]
	partial class NSFileCoordinator {
		[Static, Export ("addFilePresenter:")]
		[PostGet ("FilePresenters")]
		extern static void AddFilePresenter (INSFilePresenter filePresenter);

		[Static]
		[Export ("removeFilePresenter:")]
		[PostGet ("FilePresenters")]
		extern static void RemoveFilePresenter (INSFilePresenter filePresenter);

		[Static]
		[Export ("filePresenters", ArgumentSemantic.Copy)]
		INSFilePresenter [] FilePresenters { get; }

		[DesignatedInitializer]
		[Export ("initWithFilePresenter:")]
		extern NativeHandle Constructor ([NullAllowed] INSFilePresenter filePresenterOrNil);

#if !NET
		[Obsolete ("Use '.ctor(INSFilePresenter)' instead.")]
		[Wrap ("this (filePresenterOrNil as INSFilePresenter)")]
		NativeHandle Constructor ([NullAllowed] NSFilePresenter filePresenterOrNil);
#endif

		[Export ("coordinateReadingItemAtURL:options:error:byAccessor:")]
		extern void CoordinateRead (NSUrl itemUrl, NSFileCoordinatorReadingOptions options, out NSError error, /* non null */ Action<NSUrl> worker);

		[Export ("coordinateWritingItemAtURL:options:error:byAccessor:")]
		extern void CoordinateWrite (NSUrl url, NSFileCoordinatorWritingOptions options, out NSError error, /* non null */ Action<NSUrl> worker);

		[Export ("coordinateReadingItemAtURL:options:writingItemAtURL:options:error:byAccessor:")]
		extern void CoordinateReadWrite (NSUrl readingURL, NSFileCoordinatorReadingOptions readingOptions, NSUrl writingURL, NSFileCoordinatorWritingOptions writingOptions, out NSError error, /* non null */ NSFileCoordinatorWorkerRW readWriteWorker);

		[Export ("coordinateWritingItemAtURL:options:writingItemAtURL:options:error:byAccessor:")]
		extern void CoordinateWriteWrite (NSUrl writingURL, NSFileCoordinatorWritingOptions writingOptions, NSUrl writingURL2, NSFileCoordinatorWritingOptions writingOptions2, out NSError error, /* non null */ NSFileCoordinatorWorkerRW writeWriteWorker);

#if !NET
		[Obsolete ("Use 'CoordinateBatch' instead.")]
		[Wrap ("CoordinateBatch (readingURLs, readingOptions, writingURLs, writingOptions, out error, batchHandler)", IsVirtual = true)]
		void CoordinateBatc (NSUrl [] readingURLs, NSFileCoordinatorReadingOptions readingOptions, NSUrl [] writingURLs, NSFileCoordinatorWritingOptions writingOptions, out NSError error, /* non null */ Action batchHandler);
#endif

		[Export ("prepareForReadingItemsAtURLs:options:writingItemsAtURLs:options:error:byAccessor:")]
		extern void CoordinateBatch (NSUrl [] readingURLs, NSFileCoordinatorReadingOptions readingOptions, NSUrl [] writingURLs, NSFileCoordinatorWritingOptions writingOptions, out NSError error, /* non null */ Action batchHandler);

		[MacCatalyst (13, 1)]
		[Export ("coordinateAccessWithIntents:queue:byAccessor:")]
		extern void CoordinateAccess (NSFileAccessIntent [] intents, NSOperationQueue executionQueue, Action<NSError> accessor);

		[Export ("itemAtURL:didMoveToURL:")]
		extern void ItemMoved (NSUrl fromUrl, NSUrl toUrl);

		[Export ("cancel")]
		extern void Cancel ();

		[Export ("itemAtURL:willMoveToURL:")]
		extern void WillMove (NSUrl oldUrl, NSUrl newUrl);

		[Export ("purposeIdentifier")]
		string PurposeIdentifier { get; set; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Export ("itemAtURL:didChangeUbiquityAttributes:")]
		extern void ItemUbiquityAttributesChanged (NSUrl url, NSSet<NSString> attributes);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSFileAccessIntent {
		[Export ("URL", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		[Static, Export ("readingIntentWithURL:options:")]
		extern static NSFileAccessIntent CreateReadingIntent (NSUrl url, NSFileCoordinatorReadingOptions options);

		[Static, Export ("writingIntentWithURL:options:")]
		extern static NSFileAccessIntent CreateWritingIntent (NSUrl url, NSFileCoordinatorWritingOptions options);
	}

	

	

	//[Category]
	[BaseType (typeof (NSFileManager))]
	partial class NSFileManager_NSUserInformation: NSFileManager {

		[NoWatch]
		[NoTV]
		[NoiOS]
		[NoMacCatalyst]
		[Export ("homeDirectoryForCurrentUser")]
		extern NSUrl GetHomeDirectoryForCurrentUser ();

		[MacCatalyst (13, 1)]
		[Export ("temporaryDirectory")]
		extern NSUrl GetTemporaryDirectory ();

		[NoWatch]
		[NoTV]
		[NoiOS]
		[NoMacCatalyst]
		[Export ("homeDirectoryForUser:")]
		[return: NullAllowed]
		extern NSUrl GetHomeDirectory (string userName);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial class NSFilePresenter: NSObject {
		[Abstract]
		[Export ("presentedItemURL", ArgumentSemantic.Retain)]
		[NullAllowed]
#if NET
		NSUrl PresentedItemUrl { get; }
#else
		NSUrl PresentedItemURL { get; }
#endif

		[Abstract]
		[Export ("presentedItemOperationQueue", ArgumentSemantic.Retain)]
#if NET
		NSOperationQueue PresentedItemOperationQueue { get; }
#else
		NSOperationQueue PesentedItemOperationQueue { get; }
#endif

#if DOUBLE_BLOCKS
		[Export ("relinquishPresentedItemToReader:")]
		extern void RelinquishPresentedItemToReader (NSFilePresenterReacquirer readerAction);

		[Export ("relinquishPresentedItemToWriter:")]
		extern void RelinquishPresentedItemToWriter (NSFilePresenterReacquirer writerAction);
#endif

		[Export ("savePresentedItemChangesWithCompletionHandler:")]
		extern void SavePresentedItemChanges (Action<NSError> completionHandler);

		[Export ("accommodatePresentedItemDeletionWithCompletionHandler:")]
		extern void AccommodatePresentedItemDeletion (Action<NSError> completionHandler);

		[NoWatch, NoTV, Mac (14, 4), iOS (17, 4), MacCatalyst (17, 4)]
		[Export ("accommodatePresentedItemEvictionWithCompletionHandler:")]
		extern void AccommodatePresentedItemEviction (Action<NSError> completionHandler);

		[Export ("presentedItemDidMoveToURL:")]
		extern void PresentedItemMoved (NSUrl newURL);

		[Export ("presentedItemDidChange")]
		extern void PresentedItemChanged ();

		[Export ("presentedItemDidGainVersion:")]
		extern void PresentedItemGainedVersion (NSFileVersion version);

		[Export ("presentedItemDidLoseVersion:")]
		extern void PresentedItemLostVersion (NSFileVersion version);

		[Export ("presentedItemDidResolveConflictVersion:")]
		extern void PresentedItemResolveConflictVersion (NSFileVersion version);

		[Export ("accommodatePresentedSubitemDeletionAtURL:completionHandler:")]
		extern void AccommodatePresentedSubitemDeletion (NSUrl url, Action<NSError> completionHandler);

		[Export ("presentedSubitemDidAppearAtURL:")]
		extern void PresentedSubitemAppeared (NSUrl atUrl);

		[Export ("presentedSubitemAtURL:didMoveToURL:")]
		extern void PresentedSubitemMoved (NSUrl oldURL, NSUrl newURL);

		[Export ("presentedSubitemDidChangeAtURL:")]
		extern void PresentedSubitemChanged (NSUrl url);

		[Export ("presentedSubitemAtURL:didGainVersion:")]
		extern void PresentedSubitemGainedVersion (NSUrl url, NSFileVersion version);

		[Export ("presentedSubitemAtURL:didLoseVersion:")]
		extern void PresentedSubitemLostVersion (NSUrl url, NSFileVersion version);

		[Export ("presentedSubitemAtURL:didResolveConflictVersion:")]
		extern void PresentedSubitemResolvedConflictVersion (NSUrl url, NSFileVersion version);

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Export ("presentedItemDidChangeUbiquityAttributes:")]
		extern void PresentedItemChangedUbiquityAttributes (NSSet<NSString> attributes);

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Export ("observedPresentedItemUbiquityAttributes", ArgumentSemantic.Strong)]
		NSSet<NSString> PresentedItemObservedUbiquityAttributes { get; }
	}

	delegate void NSFileVersionNonlocalVersionsCompletionHandler ([NullAllowed] NSFileVersion [] nonlocalFileVersions, [NullAllowed] NSError error);

	[BaseType (typeof (NSObject))]
	// Objective-C exception thrown.  Name: NSGenericException Reason: -[NSFileVersion init]: You have to use one of the factory methods to instantiate NSFileVersion.
	[DisableDefaultCtor]
	partial class NSFileVersion {
		[Export ("URL", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		[Export ("localizedName", ArgumentSemantic.Copy)]
		string LocalizedName { get; }

		[Export ("localizedNameOfSavingComputer", ArgumentSemantic.Copy)]
		string LocalizedNameOfSavingComputer { get; }

		[Export ("modificationDate", ArgumentSemantic.Copy)]
		NSDate ModificationDate { get; }

		[Export ("persistentIdentifier", ArgumentSemantic.Retain)]
		NSObject PersistentIdentifier { get; }

		[Export ("conflict")]
		bool IsConflict { [Bind ("isConflict")] get; }

		[Export ("resolved")]
		bool Resolved { [Bind ("isResolved")] get; set; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("discardable")]
		bool Discardable { [Bind ("isDiscardable")] get; set; }

		[MacCatalyst (13, 1)]
		[Export ("hasLocalContents")]
		bool HasLocalContents { get; }

		[MacCatalyst (13, 1)]
		[Export ("hasThumbnail")]
		bool HasThumbnail { get; }

		[Static]
		[Export ("currentVersionOfItemAtURL:")]
		static extern NSFileVersion GetCurrentVersion (NSUrl url);

		[MacCatalyst (13, 1)]
		[Static]
		[Async]
		[Export ("getNonlocalVersionsOfItemAtURL:completionHandler:")]
		static extern void GetNonlocalVersions (NSUrl url, NSFileVersionNonlocalVersionsCompletionHandler completionHandler);

		[Static]
		[Export ("otherVersionsOfItemAtURL:")]
		static extern NSFileVersion [] GetOtherVersions (NSUrl url);

		[Static]
		[Export ("unresolvedConflictVersionsOfItemAtURL:")]
		static extern NSFileVersion [] GetUnresolvedConflictVersions (NSUrl url);

		[Static]
		[Export ("versionOfItemAtURL:forPersistentIdentifier:")]
		static extern NSFileVersion GetSpecificVersion (NSUrl url, NSObject persistentIdentifier);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[return: NullAllowed]
		[Static]
		[Export ("addVersionOfItemAtURL:withContentsOfURL:options:error:")]
		static extern NSFileVersion AddVersion (NSUrl url, NSUrl contentsURL, NSFileVersionAddingOptions options, out NSError outError);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Static]
		[Export ("temporaryDirectoryURLForNewVersionOfItemAtURL:")]
		extern static NSUrl TemporaryDirectoryForItem (NSUrl url);

		[Export ("replaceItemAtURL:options:error:")]
		extern NSUrl ReplaceItem (NSUrl url, NSFileVersionReplacingOptions options, out NSError error);

		[Export ("removeAndReturnError:")]
		extern bool Remove (out NSError outError);

		[Static]
		[Export ("removeOtherVersionsOfItemAtURL:error:")]
		static extern bool RemoveOtherVersions (NSUrl url, out NSError outError);

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("originatorNameComponents", ArgumentSemantic.Copy)]
		NSPersonNameComponents OriginatorNameComponents { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial class NSFileWrapper : NSSecureCoding {
		[DesignatedInitializer]
		[Export ("initWithURL:options:error:")]
		extern public NativeHandle Constructor (NSUrl url, NSFileWrapperReadingOptions options, out NSError outError);

		[DesignatedInitializer]
		[Export ("initDirectoryWithFileWrappers:")]
		extern public NativeHandle Constructor (NSDictionary childrenByPreferredName);

		[DesignatedInitializer]
		[Export ("initRegularFileWithContents:")]
		extern public NativeHandle Constructor (NSData contents);

		[DesignatedInitializer]
		[Export ("initSymbolicLinkWithDestinationURL:")]
		extern public NativeHandle Constructor (NSUrl urlToSymbolicLink);

		// Constructor clash
		//[Export ("initWithSerializedRepresentation:")]
		//NativeHandle Constructor (NSData serializeRepresentation);

		[Export ("isDirectory")]
		public bool IsDirectory { get; }

		[Export ("isRegularFile")]
		public bool IsRegularFile { get; }

		[Export ("isSymbolicLink")]
		public bool IsSymbolicLink { get; }

		[Export ("matchesContentsOfURL:")]
		extern public bool MatchesContentsOfURL (NSUrl url);

		[Export ("readFromURL:options:error:")]
		extern public bool Read (NSUrl url, NSFileWrapperReadingOptions options, out NSError outError);

		[Export ("writeToURL:options:originalContentsURL:error:")]
		extern public bool Write (NSUrl url, NSFileWrapperWritingOptions options, [NullAllowed] NSUrl originalContentsURL, out NSError outError);

		[Export ("serializedRepresentation")]
		extern public NSData GetSerializedRepresentation ();

		[Export ("addFileWrapper:")]
		extern public string AddFileWrapper (NSFileWrapper child);

		[Export ("addRegularFileWithContents:preferredFilename:")]
		extern public string AddRegularFile (NSData dataContents, string preferredFilename);

		[Export ("removeFileWrapper:")]
		extern public void RemoveFileWrapper (NSFileWrapper child);

		[Export ("fileWrappers")]
		public NSDictionary FileWrappers { get; }

		[Export ("keyForFileWrapper:")]
		extern public string KeyForFileWrapper (NSFileWrapper child);

		[Export ("regularFileContents")]
		extern public NSData GetRegularFileContents ();

		[Export ("symbolicLinkDestinationURL")]
		public NSUrl SymbolicLinkDestinationURL { get; }

		//Detected properties
		// [NullAllowed] can't be used. It's null by default but, on device, it throws-n-crash
		// NSInvalidArgumentException -[NSFileWrapper setPreferredFilename:] *** preferredFilename cannot be empty.
		[Export ("preferredFilename")]
		public string PreferredFilename { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("filename")]
		public string Filename { get; set; }

		[Export ("fileAttributes", ArgumentSemantic.Copy)]
		public NSDictionary FileAttributes { get; set; }

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("icon", ArgumentSemantic.Retain)]
		public NSImage Icon { get; set; }
	}

	[BaseType (typeof (NSEnumerator))]
	partial class NSDirectoryEnumerator {
		[Export ("fileAttributes")]
		NSDictionary FileAttributes { get; }

		[Export ("directoryAttributes")]
		NSDictionary DirectoryAttributes { get; }

		[Export ("skipDescendents")]
		extern void SkipDescendents ();

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("level")]
		nint Level { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("isEnumeratingDirectoryPostOrder")]
		bool IsEnumeratingDirectoryPostOrder { get; }
	}



	

#pragma warning disable 618
	//[Category, BaseType (typeof (NSMutableArray))]
#pragma warning restore 618
	partial class NSPredicateSupport_NSMutableArray {
		[Export ("filterUsingPredicate:")]
		extern void FilterUsingPredicate (NSPredicate predicate);
	}

	//[Category, BaseType (typeof (NSSet))]
	partial class NSPredicateSupport_NSSet {
		[Export ("filteredSetUsingPredicate:")]
		extern NSSet FilterUsingPredicate (NSPredicate predicate);
	}

	//[Category, BaseType (typeof (NSMutableSet))]
	partial class NSPredicateSupport_NSMutableSet {
		[Export ("filterUsingPredicate:")]
		extern void FilterUsingPredicate (NSPredicate predicate);
	}

	[NoiOS]
	[NoMacCatalyst]
	[NoWatch]
	[NoTV]
	[BaseType (typeof (NSObject), Name = "NSURLDownload")]
	partial class NSUrlDownload {
		[Static, Export ("canResumeDownloadDecodedWithEncodingMIMEType:")]
		static extern bool CanResumeDownloadDecodedWithEncodingMimeType (string mimeType);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSURLSession' instead.")]
		[Export ("initWithRequest:delegate:")]
		extern NativeHandle Constructor (NSUrlRequest request, [NullAllowed] NSObject delegate1);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSURLSession' instead.")]
		[Export ("initWithResumeData:delegate:path:")]
		extern NativeHandle Constructor (NSData resumeData, [NullAllowed] NSObject delegate1, string path);

		[Export ("cancel")]
		extern void Cancel ();

		[Export ("setDestination:allowOverwrite:")]
		extern void SetDestination (string path, bool allowOverwrite);

		[Export ("request")]
		NSUrlRequest Request { get; }

		[NullAllowed]
		[Export ("resumeData")]
		NSData ResumeData { get; }

		[Export ("deletesFileUponFailure")]
		bool DeletesFileUponFailure { get; set; }
	}

	[NoiOS]
	[NoMacCatalyst]
	[NoWatch]
	[NoTV]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol (Name = "NSURLDownloadDelegate")]
	partial class NSUrlDownloadDelegate {
		[Export ("downloadDidBegin:")]
		extern void DownloadBegan (NSUrlDownload download);

		[Export ("download:willSendRequest:redirectResponse:")]
		extern NSUrlRequest WillSendRequest (NSUrlDownload download, NSUrlRequest request, NSUrlResponse redirectResponse);

		[Export ("download:didReceiveAuthenticationChallenge:")]
		extern void ReceivedAuthenticationChallenge (NSUrlDownload download, NSUrlAuthenticationChallenge challenge);

		[Export ("download:didCancelAuthenticationChallenge:")]
		extern void CanceledAuthenticationChallenge (NSUrlDownload download, NSUrlAuthenticationChallenge challenge);

		[Export ("download:didReceiveResponse:")]
		extern void ReceivedResponse (NSUrlDownload download, NSUrlResponse response);

		//- (void)download:(NSUrlDownload *)download willResumeWithResponse:(NSUrlResponse *)response fromByte:(long long)startingByte;
		[Export ("download:willResumeWithResponse:fromByte:")]
		extern void Resume (NSUrlDownload download, NSUrlResponse response, long startingByte);

		//- (void)download:(NSUrlDownload *)download didReceiveDataOfLength:(NSUInteger)length;
		[Export ("download:didReceiveDataOfLength:")]
		extern void ReceivedData (NSUrlDownload download, nuint length);

		[Export ("download:shouldDecodeSourceDataOfMIMEType:")]
		extern bool DecodeSourceData (NSUrlDownload download, string encodingType);

		[Export ("download:decideDestinationWithSuggestedFilename:")]
		extern void DecideDestination (NSUrlDownload download, string suggestedFilename);

		[Export ("download:didCreateDestination:")]
		extern void CreatedDestination (NSUrlDownload download, string path);

		[Export ("downloadDidFinish:")]
		extern void Finished (NSUrlDownload download);

		[Export ("download:didFailWithError:")]
		extern void FailedWithError (NSUrlDownload download, NSError error);
	}

	// Users are not supposed to implement the NSUrlProtocolClient protocol, they're 
	// only supposed to consume it. This is why there's no model for this protocol.
	[Protocol (Name = "NSURLProtocolClient")]
	partial class NSUrlProtocolClient {
		[Abstract]
		[Export ("URLProtocol:wasRedirectedToRequest:redirectResponse:")]
		extern void Redirected (NSUrlProtocol protocol, NSUrlRequest redirectedToEequest, NSUrlResponse redirectResponse);

		[Abstract]
		[Export ("URLProtocol:cachedResponseIsValid:")]
		extern void CachedResponseIsValid (NSUrlProtocol protocol, NSCachedUrlResponse cachedResponse);

		[Abstract]
		[Export ("URLProtocol:didReceiveResponse:cacheStoragePolicy:")]
		extern void ReceivedResponse (NSUrlProtocol protocol, NSUrlResponse response, NSUrlCacheStoragePolicy policy);

		[Abstract]
		[Export ("URLProtocol:didLoadData:")]
		extern void DataLoaded (NSUrlProtocol protocol, NSData data);

		[Abstract]
		[Export ("URLProtocolDidFinishLoading:")]
		extern void FinishedLoading (NSUrlProtocol protocol);

		[Abstract]
		[Export ("URLProtocol:didFailWithError:")]
		extern void FailedWithError (NSUrlProtocol protocol, NSError error);

		[Abstract]
		[Export ("URLProtocol:didReceiveAuthenticationChallenge:")]
		extern void ReceivedAuthenticationChallenge (NSUrlProtocol protocol, NSUrlAuthenticationChallenge challenge);

		[Abstract]
		[Export ("URLProtocol:didCancelAuthenticationChallenge:")]
		extern void CancelledAuthenticationChallenge (NSUrlProtocol protocol, NSUrlAuthenticationChallenge challenge);
	}

	partial class INSUrlProtocolClient { }

	[BaseType (typeof (NSObject),
		   Name = "NSURLProtocol",
		   Delegates = new string [] { "WeakClient" })]
	partial class NSUrlProtocol {
		[DesignatedInitializer]
		[Export ("initWithRequest:cachedResponse:client:")]
		extern NativeHandle Constructor (NSUrlRequest request, [NullAllowed] NSCachedUrlResponse cachedResponse, INSUrlProtocolClient client);

		[Export ("client")]
		INSUrlProtocolClient Client { get; }

		[Export ("request")]
		NSUrlRequest Request { get; }

		[Export ("cachedResponse")]
		NSCachedUrlResponse CachedResponse { get; }

		[Static]
		[Export ("canInitWithRequest:")]
		extern static bool CanInitWithRequest (NSUrlRequest request);

		[Static]
		[Export ("canonicalRequestForRequest:")]
		extern static NSUrlRequest GetCanonicalRequest (NSUrlRequest forRequest);

		[Static]
		[Export ("requestIsCacheEquivalent:toRequest:")]
		extern static bool IsRequestCacheEquivalent (NSUrlRequest first, NSUrlRequest second);

		[Export ("startLoading")]
		extern void StartLoading ();

		[Export ("stopLoading")]
		extern void StopLoading ();

		[Static]
		[Export ("propertyForKey:inRequest:")]
		extern static NSObject GetProperty (string key, NSUrlRequest inRequest);

		[Static]
		[Export ("setProperty:forKey:inRequest:")]
		extern static void SetProperty ([NullAllowed] NSObject value, string key, NSMutableUrlRequest inRequest);

		[Static]
		[Export ("removePropertyForKey:inRequest:")]
		extern static void RemoveProperty (string propertyKey, NSMutableUrlRequest request);

		[Static]
		[Export ("registerClass:")]
		extern static bool RegisterClass (Class protocolClass);

		[Static]
		[Export ("unregisterClass:")]
		extern static void UnregisterClass (Class protocolClass);

		// Commented API are broken and we'll need to provide a workaround for them
		// https://trello.com/c/RthKXnyu/381-disabled-nsurlprotocol-api-reminder

		// * "task" does not answer and is not usable - maybe it only works if created from the new API ?!?
		//
		// * "canInitWithTask" can't be called as a .NET static method. The ObjC code uses the current type
		//    internally (which will always be NSURLProtocol in .NET never a subclass) and complains about it
		//    being abstract (which is true)
		//    -canInitWithRequest: cannot be sent to an abstract object of class NSURLProtocol: Create a concrete instance!

		//		
		//		[Export ("initWithTask:cachedResponse:client:")]
		//		NativeHandle Constructor (NSUrlSessionTask task, [NullAllowed] NSCachedUrlResponse cachedResponse, INSUrlProtocolClient client);
		//
		//		
		//		[Export ("task", ArgumentSemantic.Copy)]
		//		NSUrlSessionTask Task { get; }
		//
		//		
		//		[Static, Export ("canInitWithTask:")]
		//		bool CanInitWithTask (NSUrlSessionTask task);
	}



	partial class INSExtensionRequestHandling { }

	[MacCatalyst (13, 1)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	partial class NSExtensionRequestHandling {
		[Abstract]
		// @required - (void)beginRequestWithExtensionContext:(NSExtensionContext *)context;
		[Export ("beginRequestWithExtensionContext:")]
		extern void BeginRequestWithExtensionContext (NSExtensionContext context);
	}

	[Protocol]
	partial class NSLocking {

		[Abstract]
		[Export ("lock")]
		extern void Lock ();

		[Abstract]
		[Export ("unlock")]
		extern void Unlock ();
	}

	/*
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // An uncaught exception was raised: *** -range cannot be sent to an abstract object of class NSTextCheckingResult: Create a concrete instance!
	partial class NSTextCheckingResult : NSSecureCoding, NSCopying {
		[Export ("resultType")]
		NSTextCheckingType ResultType { get; }

		[Export ("range")]
		NSRange Range { get; }

		// From the NSTextCheckingResultOptional category on NSTextCheckingResult
		[Export ("orthography")]
		NSOrthography Orthography { get; }

		[Export ("grammarDetails")]
		string [] GrammarDetails { get; }

		[Export ("date")]
		NSDate Date { get; }

		[Export ("timeZone")]
		NSTimeZone TimeZone { get; }

		[Export ("duration")]
		double TimeInterval { get; }

		[Export ("components")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSDictionary WeakComponents { get; }

		[Wrap ("WeakComponents")]
		NSTextCheckingTransitComponents Components { get; }

		[Export ("URL")]
		NSUrl Url { get; }

		[Export ("replacementString")]
		string ReplacementString { get; }

		[Export ("alternativeStrings")]
		[MacCatalyst (13, 1)]
		string [] AlternativeStrings { get; }

		//		NSRegularExpression isn't bound
		//		[Export ("regularExpression")]
		//		NSRegularExpression RegularExpression { get; }

		[Export ("phoneNumber")]
		string PhoneNumber { get; }

		[Export ("addressComponents")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSDictionary WeakAddressComponents { get; }

		[Wrap ("WeakAddressComponents")]
		NSTextCheckingAddressComponents AddressComponents { get; }

		[Export ("numberOfRanges")]
		nuint NumberOfRanges { get; }

		[Export ("rangeAtIndex:")]
		NSRange RangeAtIndex (nuint idx);

		[Export ("resultByAdjustingRangesWithOffset:")]
		NSTextCheckingResult ResultByAdjustingRanges (nint offset);

		// From the NSTextCheckingResultCreation category on NSTextCheckingResult

		[Static]
		[Export ("orthographyCheckingResultWithRange:orthography:")]
		NSTextCheckingResult OrthographyCheckingResult (NSRange range, NSOrthography ortography);

		[Static]
		[Export ("spellCheckingResultWithRange:")]
		NSTextCheckingResult SpellCheckingResult (NSRange range);

		[Static]
		[Export ("grammarCheckingResultWithRange:details:")]
		NSTextCheckingResult GrammarCheckingResult (NSRange range, string [] details);

		[Static]
		[Export ("dateCheckingResultWithRange:date:")]
		NSTextCheckingResult DateCheckingResult (NSRange range, NSDate date);

		[Static]
		[Export ("dateCheckingResultWithRange:date:timeZone:duration:")]
		NSTextCheckingResult DateCheckingResult (NSRange range, NSDate date, NSTimeZone timezone, double duration);

		[Static]
		[Export ("addressCheckingResultWithRange:components:")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSTextCheckingResult AddressCheckingResult (NSRange range, NSDictionary components);

		[Static]
		[Wrap ("AddressCheckingResult (range, components.GetDictionary ()!)")]
		NSTextCheckingResult AddressCheckingResult (NSRange range, NSTextCheckingAddressComponents components);

		[Static]
		[Export ("linkCheckingResultWithRange:URL:")]
		NSTextCheckingResult LinkCheckingResult (NSRange range, NSUrl url);

		[Static]
		[Export ("quoteCheckingResultWithRange:replacementString:")]
		NSTextCheckingResult QuoteCheckingResult (NSRange range, NSString replacementString);

		[Static]
		[Export ("dashCheckingResultWithRange:replacementString:")]
		NSTextCheckingResult DashCheckingResult (NSRange range, string replacementString);

		[Static]
		[Export ("replacementCheckingResultWithRange:replacementString:")]
		NSTextCheckingResult ReplacementCheckingResult (NSRange range, string replacementString);

		[Static]
		[Export ("correctionCheckingResultWithRange:replacementString:")]
		NSTextCheckingResult CorrectionCheckingResult (NSRange range, string replacementString);

		[Static]
		[Export ("correctionCheckingResultWithRange:replacementString:alternativeStrings:")]
		[MacCatalyst (13, 1)]
		NSTextCheckingResult CorrectionCheckingResult (NSRange range, string replacementString, string [] alternativeStrings);

		//		NSRegularExpression isn't bound
		//		[Export ("regularExpressionCheckingResultWithRanges:count:regularExpression:")]
		//		[Internal] // FIXME
		//		NSTextCheckingResult RegularExpressionCheckingResult (ref NSRange ranges, nuint count, NSRegularExpression regularExpression);

		[Static]
		[Export ("phoneNumberCheckingResultWithRange:phoneNumber:")]
		NSTextCheckingResult PhoneNumberCheckingResult (NSRange range, string phoneNumber);

		[Static]
		[Export ("transitInformationCheckingResultWithRange:components:")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		NSTextCheckingResult TransitInformationCheckingResult (NSRange range, NSDictionary components);

		[Static]
		[Wrap ("TransitInformationCheckingResult (range, components.GetDictionary ()!)")]
		NSTextCheckingResult TransitInformationCheckingResult (NSRange range, NSTextCheckingTransitComponents components);

		[MacCatalyst (13, 1)]
		[Export ("rangeWithName:")]
		NSRange GetRange (string name);

	}*/

	//[StrongDictionary ("NSTextChecking")]
	partial class NSTextCheckingTransitComponents: DictionaryContainer {
		string Airline { get; }

		string Flight { get; }
	}

	//[StrongDictionary ("NSTextChecking")]
	partial class NSTextCheckingAddressComponents: DictionaryContainer {
		string Name { get; }

		string JobTitle { get; }

		string Organization { get; }

		string Street { get; }

		string City { get; }

		string State { get; }

		[Export ("ZipKey")]
		string ZIP { get; }

		string Country { get; }

		string Phone { get; }
	}

	[Static]
	static partial class NSTextChecking {
		[Field ("NSTextCheckingNameKey")]
		static NSString NameKey { get; }

		[Field ("NSTextCheckingJobTitleKey")]
		static NSString JobTitleKey { get; }

		[Field ("NSTextCheckingOrganizationKey")]
		static NSString OrganizationKey { get; }

		[Field ("NSTextCheckingStreetKey")]
		static NSString StreetKey { get; }

		[Field ("NSTextCheckingCityKey")]
		static NSString CityKey { get; }

		[Field ("NSTextCheckingStateKey")]
		static NSString StateKey { get; }

		[Field ("NSTextCheckingZIPKey")]
		static NSString ZipKey { get; }

		[Field ("NSTextCheckingCountryKey")]
		static NSString CountryKey { get; }

		[Field ("NSTextCheckingPhoneKey")]
		static NSString PhoneKey { get; }

		[Field ("NSTextCheckingAirlineKey")]
		static NSString AirlineKey { get; }

		[Field ("NSTextCheckingFlightKey")]
		static NSString FlightKey { get; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSLock : NSLocking {
		[Export ("tryLock")]
		extern bool TryLock ();

		[Export ("lockBeforeDate:")]
		extern bool LockBeforeDate (NSDate limit);

		[Export ("name")]
		[NullAllowed]
		string Name { get; set; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSConditionLock : NSLocking {

		[DesignatedInitializer]
		[Export ("initWithCondition:")]
		extern NativeHandle Constructor (nint condition);

		[Export ("condition")]
		nint Condition { get; }

		[Export ("lockWhenCondition:")]
		extern void LockWhenCondition (nint condition);

		[Export ("tryLock")]
		extern bool TryLock ();

		[Export ("tryLockWhenCondition:")]
		extern bool TryLockWhenCondition (nint condition);

		[Export ("unlockWithCondition:")]
		extern void UnlockWithCondition (nint condition);

		[Export ("lockBeforeDate:")]
		extern bool LockBeforeDate (NSDate limit);

		[Export ("lockWhenCondition:beforeDate:")]
		extern bool LockWhenCondition (nint condition, NSDate limit);

		[Export ("name")]
		[NullAllowed]
		string Name { get; set; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSRecursiveLock : NSLocking {
		[Export ("tryLock")]
		extern bool TryLock ();

		[Export ("lockBeforeDate:")]
		extern bool LockBeforeDate (NSDate limit);

		[Export ("name")]
		[NullAllowed]
		string Name { get; set; }
	}

	[BaseType (typeof (NSObject))]
	partial class NSCondition : NSLocking {
		[Export ("wait")]
		extern void Wait ();

		[Export ("waitUntilDate:")]
		extern bool WaitUntilDate (NSDate limit);

		[Export ("signal")]
		extern void Signal ();

		[Export ("broadcast")]
		extern void Broadcast ();

		[Export ("name")]
		[NullAllowed]
		string Name { get; set; }
	}

	// Not yet, the IntPtr[] argument isn't handled correctly by the generator (it tries to convert to NSArray, while the native method expects a C array).
	//	[Protocol]
	//	interface NSFastEnumeration {
	//		[Abstract]
	//		[Export ("countByEnumeratingWithState:objects:count:")]
	//		nuint Enumerate (ref NSFastEnumerationState state, IntPtr[] objects, nuint count);
	//	}

	// Placeholer, just so we can start flagging things
	partial interface INSFastEnumeration { }

	public partial class NSBundle {
		// - (NSImage *)imageForResource:(NSString *)name NS_AVAILABLE_MAC(10_7);
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("imageForResource:")]
		extern NSImage ImageForResource (string name);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class NSDateInterval : NSCopying {
		[Export ("startDate", ArgumentSemantic.Copy)]
		NSDate StartDate { get; }

		[Export ("endDate", ArgumentSemantic.Copy)]
		NSDate EndDate { get; }

		[Export ("duration")]
		double Duration { get; }

		[Export ("initWithStartDate:duration:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (NSDate startDate, double duration);

		[Export ("initWithStartDate:endDate:")]
		extern NativeHandle Constructor (NSDate startDate, NSDate endDate);

		[Export ("compare:")]
		extern NSComparisonResult Compare (NSDateInterval dateInterval);

		[Export ("isEqualToDateInterval:")]
		extern bool IsEqualTo (NSDateInterval dateInterval);

		[Export ("intersectsDateInterval:")]
		extern bool Intersects (NSDateInterval dateInterval);

		[Export ("intersectionWithDateInterval:")]
		[return: NullAllowed]
		extern NSDateInterval GetIntersection (NSDateInterval dateInterval);

		[Export ("containsDate:")]
		extern bool ContainsDate (NSDate date);
	}

	[DisableDefaultCtor]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class NSUnit : NSCopying {
		[Export ("symbol")]
		string Symbol { get; }

		[Export ("initWithSymbol:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class NSUnitConverter {
		[Export ("baseUnitValueFromValue:")]
		extern double GetBaseUnitValue (double value);

		[Export ("valueFromBaseUnitValue:")]
		extern double GetValue (double baseUnitValue);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSUnitConverter))]
	partial class NSUnitConverterLinear : NSSecureCoding {

		[Export ("coefficient")]
		double Coefficient { get; }

		[Export ("constant")]
		double Constant { get; }

		[Export ("initWithCoefficient:")]
		extern NativeHandle Constructor (double coefficient);

		[Export ("initWithCoefficient:constant:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (double coefficient, double constant);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSUnit))]
	//[Abstract] // abstract subclass of NSUnit
	[DisableDefaultCtor] // there's a designated initializer
	partial class NSDimension : NSSecureCoding {
		// Inlined from base type
		[Export ("initWithSymbol:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol);

		[Export ("converter", ArgumentSemantic.Copy)]
		NSUnitConverter Converter { get; }

		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		// needs to be overriden in suubclasses
		//	NSInvalidArgumentException Reason: *** You must override baseUnit in your class NSDimension to define its base unit.
		// we provide a basic, managed, implementation that throws with a similar message
		//[Static]
		//[Export ("baseUnit")]
		//NSDimension BaseUnit { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	[DisableDefaultCtor] // base type has a designated initializer
	partial class NSUnitTemperature : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("kelvin", ArgumentSemantic.Copy)]
		NSUnitTemperature Kelvin { get; }

		[Static]
		[Export ("celsius", ArgumentSemantic.Copy)]
		NSUnitTemperature Celsius { get; }

		[Static]
		[Export ("fahrenheit", ArgumentSemantic.Copy)]
		NSUnitTemperature Fahrenheit { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}


	[NoiOS, NoTV, NoWatch]
	[BaseType (typeof (NSObject))]
	[MacCatalyst (13, 1)]
	public partial class NSAffineTransform : NSCopying {
		[Export ("initWithTransform:")]
		extern NativeHandle Constructor (NSAffineTransform transform);

		[Export ("translateXBy:yBy:")]
		extern void Translate (nfloat deltaX, nfloat deltaY);

		[Export ("rotateByDegrees:")]
		extern void RotateByDegrees (nfloat angle);

		[Export ("rotateByRadians:")]
		extern void RotateByRadians (nfloat angle);

		[Export ("scaleBy:")]
		extern void Scale (nfloat scale);

		[Export ("scaleXBy:yBy:")]
		extern void Scale (nfloat scaleX, nfloat scaleY);

		[Export ("invert")]
		extern void Invert ();

		[Export ("appendTransform:")]
		extern void AppendTransform (NSAffineTransform transform);

		[Export ("prependTransform:")]
		extern void PrependTransform (NSAffineTransform transform);

		[Export ("transformPoint:")]
		extern CGPoint TransformPoint (CGPoint aPoint);

		[Export ("transformSize:")]
		extern CGSize TransformSize (CGSize aSize);

		[NoMacCatalyst]
		[Export ("transformBezierPath:")]
		extern NSBezierPath TransformBezierPath (NSBezierPath path);

		[Export ("set")]
		extern void Set ();

		[Export ("concat")]
		extern void Concat ();

		[Export ("transformStruct")]
		CGAffineTransform TransformStruct { get; set; }
	}

	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSXpcConnection' instead.")]
	[NoMacCatalyst]
	[NoiOS, NoTV, NoWatch]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSConnection {
		[return: NullAllowed]
		[Static, Export ("connectionWithReceivePort:sendPort:")]
		extern NSConnection Create ([NullAllowed] NSPort receivePort, [NullAllowed] NSPort sendPort);

		[Export ("runInNewThread")]
		extern void RunInNewThread ();

		// enableMultipleThreads, multipleThreadsEnabled - no-op in 10.5+ (always enabled)

		[Export ("addRunLoop:")]
		extern void AddRunLoop (NSRunLoop runLoop);

		[Export ("removeRunLoop:")]
		extern void RemoveRunLoop (NSRunLoop runLoop);

		[return: NullAllowed]
		[Static, Export ("serviceConnectionWithName:rootObject:usingNameServer:")]
		extern static NSConnection CreateService (string name, NSObject root, NSPortNameServer server);

		[return: NullAllowed]
		[Static, Export ("serviceConnectionWithName:rootObject:")]
		extern static NSConnection CreateService (string name, NSObject root);

		[Export ("registerName:")]
		extern bool RegisterName ([NullAllowed] string name);

		[Export ("registerName:withNameServer:")]
		extern bool RegisterName ([NullAllowed] string name, NSPortNameServer server);

		[NullAllowed]
		[Export ("rootObject", ArgumentSemantic.Retain)]
		NSObject RootObject { get; set; }

		[return: NullAllowed]
		[Static, Export ("connectionWithRegisteredName:host:")]
		extern static NSConnection LookupService (string name, [NullAllowed] string hostName);

		[return: NullAllowed]
		[Static, Export ("connectionWithRegisteredName:host:usingNameServer:")]
		extern static NSConnection LookupService (string name, [NullAllowed] string hostName, NSPortNameServer server);

		[Internal, Export ("rootProxy")]
		extern IntPtr _GetRootProxy ();

		[Internal, Static, Export ("rootProxyForConnectionWithRegisteredName:host:")]
		extern IntPtr _GetRootProxy (string name, [NullAllowed] string hostName);

		[Internal, Static, Export ("rootProxyForConnectionWithRegisteredName:host:usingNameServer:")]
		extern IntPtr _GetRootProxy (string name, [NullAllowed] string hostName, NSPortNameServer server);

		[Export ("remoteObjects")]
		NSObject [] RemoteObjects { get; }

		[Export ("localObjects")]
		NSObject [] LocalObjects { get; }

		[NullAllowed]
		[Static, Export ("currentConversation")]
		NSObject CurrentConversation { get; }

		[Static, Export ("allConnections")]
		NSConnection [] AllConnections { get; }

		[Export ("requestTimeout")]
		NSTimeInterval RequestTimeout { get; set; }

		[Export ("replyTimeout")]
		NSTimeInterval ReplyTimeout { get; set; }

		[Export ("independentConversationQueueing")]
		bool IndependentConversationQueueing { get; set; }

		[Export ("addRequestMode:")]
		extern void AddRequestMode (NSString runLoopMode);

		[Export ("removeRequestMode:")]
		extern void RemoveRequestMode (NSString runLoopMode);

		[Export ("requestModes")]
		NSString [] RequestModes { get; }

		[Export ("invalidate")]
		extern void Invalidate ();

		[Export ("isValid")]
		bool IsValid { get; }

		[Export ("receivePort")]
		NSPort ReceivePort { get; }

		[Export ("sendPort")]
		NSPort SendPort { get; }

		[Export ("dispatchWithComponents:")]
		extern void Dispatch (NSArray components);

		[Export ("statistics")]
		NSDictionary Statistics { get; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSConnectionDelegate Delegate { get; set; }
	}

	partial class INSConnectionDelegate { }

	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSXpcConnection' instead.")]
	[NoMacCatalyst]
	[NoiOS, NoTV, NoWatch]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial class NSConnectionDelegate {
		[Export ("authenticateComponents:withData:")]
		extern bool AuthenticateComponents (NSArray components, NSData authenticationData);

		[Export ("authenticationDataForComponents:")]
		extern NSData GetAuthenticationData (NSArray components);

		[Export ("connection:shouldMakeNewConnection:")]
		extern bool ShouldMakeNewConnection (NSConnection parentConnection, NSConnection newConnection);

		[Export ("connection:handleRequest:")]
		extern bool HandleRequest (NSConnection connection, NSDistantObjectRequest request);

		[Export ("createConversationForConnection:")]
		extern NSObject CreateConversation (NSConnection connection);

		[Export ("makeNewConnection:sender:")]
		extern bool AllowNewConnection (NSConnection newConnection, NSConnection parentConnection);
	}

	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSXpcConnection' instead.")]
	[NoMacCatalyst]
	[NoiOS, NoTV, NoWatch]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSDistantObjectRequest {
		[Export ("connection")]
		NSConnection Connection { get; }

		[Export ("conversation")]
		NSObject Conversation { get; }

		[Export ("invocation")]
		NSInvocation Invocation { get; }

		[Export ("replyWithException:")]
		extern void Reply ([NullAllowed] NSException exception);
	}

	[NoMacCatalyst]
	[NoiOS, NoTV, NoWatch]
	[Deprecated (PlatformName.MacOSX, 10, 13)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public partial class NSPortNameServer {
		[Static, Export ("systemDefaultPortNameServer")]
		public static extern NSPortNameServer SystemDefault { get; }

		[return: NullAllowed]
		[Export ("portForName:")]
		public extern NSPort GetPort (string portName);

		[return: NullAllowed]
		[Export ("portForName:host:")]
		public extern NSPort GetPort (string portName, [NullAllowed] string hostName);

		[Export ("registerPort:name:")]
		public extern bool RegisterPort (NSPort port, string portName);

		[Export ("removePortForName:")]
		public extern bool RemovePort (string portName);
	}



	[NoiOS, NoTV, NoWatch]
	[MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	partial class NSAppleEventManager {
		[Static]
		[Export ("sharedAppleEventManager")]
		NSAppleEventManager SharedAppleEventManager { get; }

		[Export ("setEventHandler:andSelector:forEventClass:andEventID:")]
		extern void SetEventHandler (NSObject handler, Selector handleEventSelector, AEEventClass eventClass, AEEventID eventID);

		[Export ("removeEventHandlerForEventClass:andEventID:")]
		extern void RemoveEventHandler (AEEventClass eventClass, AEEventID eventID);

		[NullAllowed]
		[Export ("currentAppleEvent")]
		NSAppleEventDescriptor CurrentAppleEvent { get; }

		[NullAllowed]
		[Export ("currentReplyAppleEvent")]
		NSAppleEventDescriptor CurrentReplyAppleEvent { get; }

		[Export ("suspendCurrentAppleEvent")]
		extern NSAppleEventManagerSuspensionID SuspendCurrentAppleEvent ();

		[Export ("appleEventForSuspensionID:")]
		extern NSAppleEventDescriptor AppleEventForSuspensionID (NSAppleEventManagerSuspensionID suspensionID);

		[Export ("replyAppleEventForSuspensionID:")]
		extern NSAppleEventDescriptor ReplyAppleEventForSuspensionID (NSAppleEventManagerSuspensionID suspensionID);

		[Export ("setCurrentAppleEventAndReplyEventWithSuspensionID:")]
		extern void SetCurrentAppleEventAndReplyEventWithSuspensionID (NSAppleEventManagerSuspensionID suspensionID);

		[Export ("resumeWithSuspensionID:")]
		extern void ResumeWithSuspensionID (NSAppleEventManagerSuspensionID suspensionID);

		[Notification]
		[Field ("NSAppleEventManagerWillProcessFirstEventNotification")]
		NSString WillProcessFirstEventNotification { get; }
	}

	[NoiOS, NoTV, NoWatch]
	[MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	partial class NSTask {
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		[Export ("launch")]
		extern void Launch ();

		[NoMacCatalyst]
		[Export ("launchAndReturnError:")]
		extern bool Launch ([NullAllowed] out NSError error);

		[Export ("interrupt")]
		extern void Interrupt ();

		[Export ("terminate")]
		extern void Terminate ();

		[Export ("suspend")]
	extern 	bool Suspend ();

		[Export ("resume")]
		extern bool Resume ();

		[Export ("waitUntilExit")]
		extern void WaitUntilExit ();

		[Static]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
#if XAMCORE_5_0
		[NoMacCatalyst]
#else
#if MACCATALYST
		[Obsolete ("Do not use; this method is not available on Mac Catalyst.")]
		[EditorBrowsable (EditorBrowsableState.Never)]
#endif // MACCATALYST
#endif // XAMCORE_5_0
		[Export ("launchedTaskWithLaunchPath:arguments:")]
		extern NSTask LaunchFromPath (string path, string [] arguments);

		[Static]
		[NoMacCatalyst]
		[Export ("launchedTaskWithExecutableURL:arguments:error:terminationHandler:")]
		[return: NullAllowed]
		extern static NSTask LaunchFromUrl (NSUrl url, string [] arguments, [NullAllowed] out NSError error, [NullAllowed] Action<NSTask> terminationHandler);

		//Detected properties
		[NullAllowed]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		[NoMacCatalyst]
		[Export ("launchPath")]
		string LaunchPath { get; set; }

		[NullAllowed]
		[NoMacCatalyst]
		[Export ("executableURL")]
		NSUrl ExecutableUrl { get; set; }

		[NullAllowed]
		[Export ("arguments")]
		string [] Arguments { get; set; }

		[NullAllowed]
		[Export ("environment", ArgumentSemantic.Copy)]
		NSDictionary Environment { get; set; }

		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		[Export ("currentDirectoryPath")]
		string CurrentDirectoryPath { get; set; }

		[NullAllowed]
		[NoMacCatalyst]
		[Export ("currentDirectoryURL")]
		NSUrl CurrentDirectoryUrl { get; set; }

		[NullAllowed]
		[Mac (14, 4), MacCatalyst (17, 4)]
		[Export ("launchRequirementData", ArgumentSemantic.Copy)]
		NSData LaunchRequirementData { get; set; }

		[NullAllowed]
		[Export ("standardInput", ArgumentSemantic.Retain)]
		NSObject StandardInput { get; set; }

		[NullAllowed]
		[Export ("standardOutput", ArgumentSemantic.Retain)]
		NSObject StandardOutput { get; set; }

		[NullAllowed]
		[Export ("standardError", ArgumentSemantic.Retain)]
		NSObject StandardError { get; set; }

		[Export ("qualityOfService")]
		NSQualityOfService QualityOfService { get; set; }

		[Export ("isRunning")]
		bool IsRunning { get; }

		[Export ("processIdentifier")]
		int ProcessIdentifier { get; } /* pid_t = int */

		[Export ("terminationStatus")]
		int TerminationStatus { get; } /* int, not NSInteger */

		[NullAllowed]
		[NoMacCatalyst]
		[Export ("terminationHandler")]
		Action<NSTask> TerminationHandler { get; set; }

		[NoMacCatalyst]
		[Export ("terminationReason")]
		NSTaskTerminationReason TerminationReason { get; }

#if !NET && MONOMAC
		[Field ("NSTaskDidTerminateNotification")]
		NSString NSTaskDidTerminateNotification { get; }
#endif

		[Field ("NSTaskDidTerminateNotification")]
		[Notification]
		NSString DidTerminateNotification { get; }
	}

	[NoiOS, NoTV, NoWatch, NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	[Advice ("'NSUserNotification' usages should be replaced with 'UserNotifications' framework.")]
	partial class NSUserNotification :  NSCopying {
		[NullAllowed]
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[NullAllowed]
		[Export ("subtitle", ArgumentSemantic.Copy)]
		string Subtitle { get; set; }

		[NullAllowed]
		[Export ("informativeText", ArgumentSemantic.Copy)]
		string InformativeText { get; set; }

		[Export ("actionButtonTitle", ArgumentSemantic.Copy)]
		string ActionButtonTitle { get; set; }

		[NullAllowed]
		[Export ("userInfo", ArgumentSemantic.Copy)]
		NSDictionary UserInfo { get; set; }

		[NullAllowed]
		[Export ("deliveryDate", ArgumentSemantic.Copy)]
		NSDate DeliveryDate { get; set; }

		[NullAllowed]
		[Export ("deliveryTimeZone", ArgumentSemantic.Copy)]
		NSTimeZone DeliveryTimeZone { get; set; }

		[NullAllowed]
		[Export ("deliveryRepeatInterval", ArgumentSemantic.Copy)]
		NSDateComponents DeliveryRepeatInterval { get; set; }

		[NullAllowed]
		[Export ("actualDeliveryDate")]
		NSDate ActualDeliveryDate { get; }

		[Export ("presented")]
		bool Presented { [Bind ("isPresented")] get; }

		[Export ("remote")]
		bool Remote { [Bind ("isRemote")] get; }

		[NullAllowed]
		[Export ("soundName", ArgumentSemantic.Copy)]
		string SoundName { get; set; }

		[Export ("hasActionButton")]
		bool HasActionButton { get; set; }

		[Export ("activationType")]
		NSUserNotificationActivationType ActivationType { get; }

		[Export ("otherButtonTitle", ArgumentSemantic.Copy)]
		string OtherButtonTitle { get; set; }

		[Field ("NSUserNotificationDefaultSoundName")]
		NSString NSUserNotificationDefaultSoundName { get; }

		[NullAllowed, Export ("identifier")]
		string Identifier { get; set; }

		[NullAllowed, Export ("contentImage", ArgumentSemantic.Copy)]
		NSImage ContentImage { get; set; }

		[Export ("hasReplyButton")]
		bool HasReplyButton { get; set; }

		[NullAllowed, Export ("responsePlaceholder")]
		string ResponsePlaceholder { get; set; }

		[NullAllowed, Export ("response", ArgumentSemantic.Copy)]
		NSAttributedString Response { get; }

		[NullAllowed, Export ("additionalActions", ArgumentSemantic.Copy)]
		NSUserNotificationAction [] AdditionalActions { get; set; }

		[NullAllowed, Export ("additionalActivationAction", ArgumentSemantic.Copy)]
		NSUserNotificationAction AdditionalActivationAction { get; }
	}

	[NoiOS, NoTV, NoWatch, NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Advice ("'NSUserNotification' usages should be replaced with 'UserNotifications' framework.")]
	partial class NSUserNotificationAction : NSCopying {
		[Static]
		[Export ("actionWithIdentifier:title:")]
		extern static NSUserNotificationAction GetAction ([NullAllowed] string identifier, [NullAllowed] string title);

		[NullAllowed, Export ("identifier")]
		string Identifier { get; }

		[NullAllowed, Export ("title")]
		string Title { get; }
	}

	[NoiOS, NoTV, NoWatch, NoMacCatalyst]
	[BaseType (typeof (NSObject),
			   Delegates = new string [] { "WeakDelegate" },
	Events = new Type [] { typeof (NSUserNotificationCenterDelegate) })]
	[DisableDefaultCtor] // crash with: NSUserNotificationCenter designitated initializer is _centerForBundleIdentifier
	[Advice ("'NSUserNotification' usages should be replaced with 'UserNotifications' framework.")]
	partial class NSUserNotificationCenter {
		[Export ("defaultUserNotificationCenter")]
		[Static]
		NSUserNotificationCenter DefaultUserNotificationCenter { get; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSUserNotificationCenterDelegate Delegate { get; set; }

		[Export ("scheduledNotifications", ArgumentSemantic.Copy)]
		NSUserNotification [] ScheduledNotifications { get; set; }

		[Export ("scheduleNotification:")]
		[PostGet ("ScheduledNotifications")]
		extern void ScheduleNotification (NSUserNotification notification);

		[Export ("removeScheduledNotification:")]
		[PostGet ("ScheduledNotifications")]
		extern void RemoveScheduledNotification (NSUserNotification notification);

		[Export ("deliveredNotifications")]
		NSUserNotification [] DeliveredNotifications { get; }

		[Export ("deliverNotification:")]
		[PostGet ("DeliveredNotifications")]
		extern void DeliverNotification (NSUserNotification notification);

		[Export ("removeDeliveredNotification:")]
		[PostGet ("DeliveredNotifications")]
		extern void RemoveDeliveredNotification (NSUserNotification notification);

		[Export ("removeAllDeliveredNotifications")]
		[PostGet ("DeliveredNotifications")]
		extern void RemoveAllDeliveredNotifications ();
	}

	partial class INSUserNotificationCenterDelegate { }

	[NoiOS, NoTV, NoWatch, NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'UserNotifications.*' API instead.")]
	partial class NSUserNotificationCenterDelegate {
		[Export ("userNotificationCenter:didDeliverNotification:"), EventArgs ("UNCDidDeliverNotification")]
		extern void DidDeliverNotification (NSUserNotificationCenter center, NSUserNotification notification);

		[Export ("userNotificationCenter:didActivateNotification:"), EventArgs ("UNCDidActivateNotification")]
		extern void DidActivateNotification (NSUserNotificationCenter center, NSUserNotification notification);

		[Export ("userNotificationCenter:shouldPresentNotification:"), DelegateName ("UNCShouldPresentNotification"), DefaultValue (false)]
		extern bool ShouldPresentNotification (NSUserNotificationCenter center, NSUserNotification notification);
	}

	[NoiOS, NoTV, NoWatch]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSAppleScript : NSCopying {

		// @required - (instancetype)initWithContentsOfURL:(NSURL *)url error:(NSDictionary **)errorInfo;
		[DesignatedInitializer]
		[Export ("initWithContentsOfURL:error:")]
		extern NativeHandle Constructor (NSUrl url, out NSDictionary errorInfo);

		// @required - (instancetype)initWithSource:(NSString *)source;
		[DesignatedInitializer]
		[Export ("initWithSource:")]
		extern NativeHandle Constructor (string source);

		// @property (readonly, copy) NSString * source;
		[NullAllowed]
		[Export ("source")]
		string Source { get; }

		// @property (readonly, getter = isCompiled) BOOL compiled;
		[Export ("compiled")]
		bool Compiled { [Bind ("isCompiled")] get; }

		// @required - (BOOL)compileAndReturnError:(NSDictionary **)errorInfo;
		[Export ("compileAndReturnError:")]
		extern bool CompileAndReturnError (out NSDictionary errorInfo);

		// @required - (NSAppleEventDescriptor *)executeAndReturnError:(NSDictionary **)errorInfo;
		[Export ("executeAndReturnError:")]
		extern NSAppleEventDescriptor ExecuteAndReturnError (out NSDictionary errorInfo);

		// @required - (NSAppleEventDescriptor *)executeAppleEvent:(NSAppleEventDescriptor *)event error:(NSDictionary **)errorInfo;
		[Export ("executeAppleEvent:error:")]
		extern NSAppleEventDescriptor ExecuteAppleEvent (NSAppleEventDescriptor eventDescriptor, out NSDictionary errorInfo);

		[NullAllowed]
		[Export ("richTextSource", ArgumentSemantic.Retain)]
		NSAttributedString RichTextSource { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter), Name = "NSISO8601DateFormatter")]
	//[DesignatedDefaultCtor]
	partial class NSIso8601DateFormatter : NSSecureCoding {

		[Export ("timeZone", ArgumentSemantic.Copy)]
		NSTimeZone TimeZone { get; set; }

		[Export ("formatOptions", ArgumentSemantic.Assign)]
		NSIso8601DateFormatOptions FormatOptions { get; set; }

		[Export ("stringFromDate:")]
		extern string ToString (NSDate date);

		[Export ("dateFromString:")]
		[return: NullAllowed]
		extern NSDate ToDate (string @string);

		[Static]
		[Export ("stringFromDate:timeZone:formatOptions:")]
		extern static string Format (NSDate date, NSTimeZone timeZone, NSIso8601DateFormatOptions formatOptions);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Name = "NSURLSessionTaskTransactionMetrics")]
	[DisableDefaultCtor]
	partial class NSUrlSessionTaskTransactionMetrics {
		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "This type is not meant to be user created.")]
		[Export ("init")]
		extern NativeHandle Constructor ();

		[Export ("request", ArgumentSemantic.Copy)]
		NSUrlRequest Request { get; }

		[NullAllowed, Export ("response", ArgumentSemantic.Copy)]
		NSUrlResponse Response { get; }

		[NullAllowed, Export ("fetchStartDate", ArgumentSemantic.Copy)]
		NSDate FetchStartDate { get; }

		[NullAllowed, Export ("domainLookupStartDate", ArgumentSemantic.Copy)]
		NSDate DomainLookupStartDate { get; }

		[NullAllowed, Export ("domainLookupEndDate", ArgumentSemantic.Copy)]
		NSDate DomainLookupEndDate { get; }

		[NullAllowed, Export ("connectStartDate", ArgumentSemantic.Copy)]
		NSDate ConnectStartDate { get; }

		[NullAllowed, Export ("secureConnectionStartDate", ArgumentSemantic.Copy)]
		NSDate SecureConnectionStartDate { get; }

		[NullAllowed, Export ("secureConnectionEndDate", ArgumentSemantic.Copy)]
		NSDate SecureConnectionEndDate { get; }

		[NullAllowed, Export ("connectEndDate", ArgumentSemantic.Copy)]
		NSDate ConnectEndDate { get; }

		[NullAllowed, Export ("requestStartDate", ArgumentSemantic.Copy)]
		NSDate RequestStartDate { get; }

		[NullAllowed, Export ("requestEndDate", ArgumentSemantic.Copy)]
		NSDate RequestEndDate { get; }

		[NullAllowed, Export ("responseStartDate", ArgumentSemantic.Copy)]
		NSDate ResponseStartDate { get; }

		[NullAllowed, Export ("responseEndDate", ArgumentSemantic.Copy)]
		NSDate ResponseEndDate { get; }

		[NullAllowed, Export ("networkProtocolName")]
		string NetworkProtocolName { get; }

		[Export ("proxyConnection")]
		bool ProxyConnection { [Bind ("isProxyConnection")] get; }

		[Export ("reusedConnection")]
		bool ReusedConnection { [Bind ("isReusedConnection")] get; }

		[Export ("resourceFetchType", ArgumentSemantic.Assign)]
		NSUrlSessionTaskMetricsResourceFetchType ResourceFetchType { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("countOfRequestHeaderBytesSent")]
		long CountOfRequestHeaderBytesSent { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("countOfRequestBodyBytesSent")]
		long CountOfRequestBodyBytesSent { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("countOfRequestBodyBytesBeforeEncoding")]
		long CountOfRequestBodyBytesBeforeEncoding { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("countOfResponseHeaderBytesReceived")]
		long CountOfResponseHeaderBytesReceived { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("countOfResponseBodyBytesReceived")]
		long CountOfResponseBodyBytesReceived { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("countOfResponseBodyBytesAfterDecoding")]
		long CountOfResponseBodyBytesAfterDecoding { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("localAddress")]
		string LocalAddress { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("localPort", ArgumentSemantic.Copy)]
		// 0-1023
		[BindAs (typeof (ushort?))]
		NSNumber LocalPort { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("remoteAddress")]
		string RemoteAddress { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("remotePort", ArgumentSemantic.Copy)]
		// 0-1023
		[BindAs (typeof (ushort?))]
		NSNumber RemotePort { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("negotiatedTLSProtocolVersion", ArgumentSemantic.Copy)]
		// <quote>It is a 2-byte sequence in host byte order.</quote> but it refers to (nicer) `tls_protocol_version_t`
		//[BindAs (typeof (SslProtocol?))]
		NSNumber NegotiatedTlsProtocolVersion { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("negotiatedTLSCipherSuite", ArgumentSemantic.Copy)]
		// <quote>It is a 2-byte sequence in host byte order.</quote> but it refers to (nicer) `tls_ciphersuite_t`
#if NET
		[BindAs (typeof (TlsCipherSuite?))]
#else
		[BindAs (typeof (SslCipherSuite?))]
#endif
		NSNumber NegotiatedTlsCipherSuite { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("cellular")]
		bool Cellular { [Bind ("isCellular")] get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("expensive")]
		bool Expensive { [Bind ("isExpensive")] get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("constrained")]
		bool Constrained { [Bind ("isConstrained")] get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("multipath")]
		bool Multipath { [Bind ("isMultipath")] get; }

		[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("domainResolutionProtocol")]
		NSUrlSessionTaskMetricsDomainResolutionProtocol DomainResolutionProtocol { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Name = "NSURLSessionTaskMetrics")]
	[DisableDefaultCtor]
	partial class NSUrlSessionTaskMetrics {

	
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "This type is not meant to be user created.")]
		[Export ("init")]
		extern NativeHandle Constructor ();

		[Export ("transactionMetrics", ArgumentSemantic.Copy)]
		NSUrlSessionTaskTransactionMetrics [] TransactionMetrics { get; }

		[Export ("taskInterval", ArgumentSemantic.Copy)]
		NSDateInterval TaskInterval { get; }

		[Export ("redirectCount")]
		nuint RedirectCount { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitAcceleration : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("metersPerSecondSquared", ArgumentSemantic.Copy)]
		NSUnitAcceleration MetersPerSecondSquared { get; }

		[Static]
		[Export ("gravity", ArgumentSemantic.Copy)]
		NSUnitAcceleration Gravity { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitAngle : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("degrees", ArgumentSemantic.Copy)]
		NSUnitAngle Degrees { get; }

		[Static]
		[Export ("arcMinutes", ArgumentSemantic.Copy)]
		NSUnitAngle ArcMinutes { get; }

		[Static]
		[Export ("arcSeconds", ArgumentSemantic.Copy)]
		NSUnitAngle ArcSeconds { get; }

		[Static]
		[Export ("radians", ArgumentSemantic.Copy)]
		NSUnitAngle Radians { get; }

		[Static]
		[Export ("gradians", ArgumentSemantic.Copy)]
		NSUnitAngle Gradians { get; }

		[Static]
		[Export ("revolutions", ArgumentSemantic.Copy)]
		NSUnitAngle Revolutions { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitArea : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("squareMegameters", ArgumentSemantic.Copy)]
		NSUnitArea SquareMegameters { get; }

		[Static]
		[Export ("squareKilometers", ArgumentSemantic.Copy)]
		NSUnitArea SquareKilometers { get; }

		[Static]
		[Export ("squareMeters", ArgumentSemantic.Copy)]
		NSUnitArea SquareMeters { get; }

		[Static]
		[Export ("squareCentimeters", ArgumentSemantic.Copy)]
		NSUnitArea SquareCentimeters { get; }

		[Static]
		[Export ("squareMillimeters", ArgumentSemantic.Copy)]
		NSUnitArea SquareMillimeters { get; }

		[Static]
		[Export ("squareMicrometers", ArgumentSemantic.Copy)]
		NSUnitArea SquareMicrometers { get; }

		[Static]
		[Export ("squareNanometers", ArgumentSemantic.Copy)]
		NSUnitArea SquareNanometers { get; }

		[Static]
		[Export ("squareInches", ArgumentSemantic.Copy)]
		NSUnitArea SquareInches { get; }

		[Static]
		[Export ("squareFeet", ArgumentSemantic.Copy)]
		NSUnitArea SquareFeet { get; }

		[Static]
		[Export ("squareYards", ArgumentSemantic.Copy)]
		NSUnitArea SquareYards { get; }

		[Static]
		[Export ("squareMiles", ArgumentSemantic.Copy)]
		NSUnitArea SquareMiles { get; }

		[Static]
		[Export ("acres", ArgumentSemantic.Copy)]
		NSUnitArea Acres { get; }

		[Static]
		[Export ("ares", ArgumentSemantic.Copy)]
		NSUnitArea Ares { get; }

		[Static]
		[Export ("hectares", ArgumentSemantic.Copy)]
		NSUnitArea Hectares { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitConcentrationMass : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("gramsPerLiter", ArgumentSemantic.Copy)]
		NSUnitConcentrationMass GramsPerLiter { get; }

		[Static]
		[Export ("milligramsPerDeciliter", ArgumentSemantic.Copy)]
		NSUnitConcentrationMass MilligramsPerDeciliter { get; }

		[Static]
		[Export ("millimolesPerLiterWithGramsPerMole:")]
		extern static NSUnitConcentrationMass GetMillimolesPerLiter (double gramsPerMole);

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitDispersion : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("partsPerMillion", ArgumentSemantic.Copy)]
		NSUnitDispersion PartsPerMillion { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitDuration : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("seconds", ArgumentSemantic.Copy)]
		NSUnitDuration Seconds { get; }

		[Static]
		[Export ("minutes", ArgumentSemantic.Copy)]
		NSUnitDuration Minutes { get; }

		[Static]
		[Export ("hours", ArgumentSemantic.Copy)]
		NSUnitDuration Hours { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("milliseconds", ArgumentSemantic.Copy)]
		NSUnitDuration Milliseconds { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("microseconds", ArgumentSemantic.Copy)]
		NSUnitDuration Microseconds { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("nanoseconds", ArgumentSemantic.Copy)]
		NSUnitDuration Nanoseconds { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("picoseconds", ArgumentSemantic.Copy)]
		NSUnitDuration Picoseconds { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitElectricCharge : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("coulombs", ArgumentSemantic.Copy)]
		NSUnitElectricCharge Coulombs { get; }

		[Static]
		[Export ("megaampereHours", ArgumentSemantic.Copy)]
		NSUnitElectricCharge MegaampereHours { get; }

		[Static]
		[Export ("kiloampereHours", ArgumentSemantic.Copy)]
		NSUnitElectricCharge KiloampereHours { get; }

		[Static]
		[Export ("ampereHours", ArgumentSemantic.Copy)]
		NSUnitElectricCharge AmpereHours { get; }

		[Static]
		[Export ("milliampereHours", ArgumentSemantic.Copy)]
		NSUnitElectricCharge MilliampereHours { get; }

		[Static]
		[Export ("microampereHours", ArgumentSemantic.Copy)]
		NSUnitElectricCharge MicroampereHours { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitElectricCurrent : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("megaamperes", ArgumentSemantic.Copy)]
		NSUnitElectricCurrent Megaamperes { get; }

		[Static]
		[Export ("kiloamperes", ArgumentSemantic.Copy)]
		NSUnitElectricCurrent Kiloamperes { get; }

		[Static]
		[Export ("amperes", ArgumentSemantic.Copy)]
		NSUnitElectricCurrent Amperes { get; }

		[Static]
		[Export ("milliamperes", ArgumentSemantic.Copy)]
		NSUnitElectricCurrent Milliamperes { get; }

		[Static]
		[Export ("microamperes", ArgumentSemantic.Copy)]
		NSUnitElectricCurrent Microamperes { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitElectricPotentialDifference : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("megavolts", ArgumentSemantic.Copy)]
		NSUnitElectricPotentialDifference Megavolts { get; }

		[Static]
		[Export ("kilovolts", ArgumentSemantic.Copy)]
		NSUnitElectricPotentialDifference Kilovolts { get; }

		[Static]
		[Export ("volts", ArgumentSemantic.Copy)]
		NSUnitElectricPotentialDifference Volts { get; }

		[Static]
		[Export ("millivolts", ArgumentSemantic.Copy)]
		NSUnitElectricPotentialDifference Millivolts { get; }

		[Static]
		[Export ("microvolts", ArgumentSemantic.Copy)]
		NSUnitElectricPotentialDifference Microvolts { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitElectricResistance : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("megaohms", ArgumentSemantic.Copy)]
		NSUnitElectricResistance Megaohms { get; }

		[Static]
		[Export ("kiloohms", ArgumentSemantic.Copy)]
		NSUnitElectricResistance Kiloohms { get; }

		[Static]
		[Export ("ohms", ArgumentSemantic.Copy)]
		NSUnitElectricResistance Ohms { get; }

		[Static]
		[Export ("milliohms", ArgumentSemantic.Copy)]
		NSUnitElectricResistance Milliohms { get; }

		[Static]
		[Export ("microohms", ArgumentSemantic.Copy)]
		NSUnitElectricResistance Microohms { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitEnergy : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("kilojoules", ArgumentSemantic.Copy)]
		NSUnitEnergy Kilojoules { get; }

		[Static]
		[Export ("joules", ArgumentSemantic.Copy)]
		NSUnitEnergy Joules { get; }

		[Static]
		[Export ("kilocalories", ArgumentSemantic.Copy)]
		NSUnitEnergy Kilocalories { get; }

		[Static]
		[Export ("calories", ArgumentSemantic.Copy)]
		NSUnitEnergy Calories { get; }

		[Static]
		[Export ("kilowattHours", ArgumentSemantic.Copy)]
		NSUnitEnergy KilowattHours { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitFrequency : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("terahertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Terahertz { get; }

		[Static]
		[Export ("gigahertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Gigahertz { get; }

		[Static]
		[Export ("megahertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Megahertz { get; }

		[Static]
		[Export ("kilohertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Kilohertz { get; }

		[Static]
		[Export ("hertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Hertz { get; }

		[Static]
		[Export ("millihertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Millihertz { get; }

		[Static]
		[Export ("microhertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Microhertz { get; }

		[Static]
		[Export ("nanohertz", ArgumentSemantic.Copy)]
		NSUnitFrequency Nanohertz { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }

		[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("framesPerSecond", ArgumentSemantic.Copy)]
		NSUnitFrequency FramesPerSecond { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitFuelEfficiency : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("litersPer100Kilometers", ArgumentSemantic.Copy)]
		NSUnitFuelEfficiency LitersPer100Kilometers { get; }

		[Static]
		[Export ("milesPerImperialGallon", ArgumentSemantic.Copy)]
		NSUnitFuelEfficiency MilesPerImperialGallon { get; }

		[Static]
		[Export ("milesPerGallon", ArgumentSemantic.Copy)]
		NSUnitFuelEfficiency MilesPerGallon { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitLength : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("megameters", ArgumentSemantic.Copy)]
		NSUnitLength Megameters { get; }

		[Static]
		[Export ("kilometers", ArgumentSemantic.Copy)]
		NSUnitLength Kilometers { get; }

		[Static]
		[Export ("hectometers", ArgumentSemantic.Copy)]
		NSUnitLength Hectometers { get; }

		[Static]
		[Export ("decameters", ArgumentSemantic.Copy)]
		NSUnitLength Decameters { get; }

		[Static]
		[Export ("meters", ArgumentSemantic.Copy)]
		NSUnitLength Meters { get; }

		[Static]
		[Export ("decimeters", ArgumentSemantic.Copy)]
		NSUnitLength Decimeters { get; }

		[Static]
		[Export ("centimeters", ArgumentSemantic.Copy)]
		NSUnitLength Centimeters { get; }

		[Static]
		[Export ("millimeters", ArgumentSemantic.Copy)]
		NSUnitLength Millimeters { get; }

		[Static]
		[Export ("micrometers", ArgumentSemantic.Copy)]
		NSUnitLength Micrometers { get; }

		[Static]
		[Export ("nanometers", ArgumentSemantic.Copy)]
		NSUnitLength Nanometers { get; }

		[Static]
		[Export ("picometers", ArgumentSemantic.Copy)]
		NSUnitLength Picometers { get; }

		[Static]
		[Export ("inches", ArgumentSemantic.Copy)]
		NSUnitLength Inches { get; }

		[Static]
		[Export ("feet", ArgumentSemantic.Copy)]
		NSUnitLength Feet { get; }

		[Static]
		[Export ("yards", ArgumentSemantic.Copy)]
		NSUnitLength Yards { get; }

		[Static]
		[Export ("miles", ArgumentSemantic.Copy)]
		NSUnitLength Miles { get; }

		[Static]
		[Export ("scandinavianMiles", ArgumentSemantic.Copy)]
		NSUnitLength ScandinavianMiles { get; }

		[Static]
		[Export ("lightyears", ArgumentSemantic.Copy)]
		NSUnitLength Lightyears { get; }

		[Static]
		[Export ("nauticalMiles", ArgumentSemantic.Copy)]
		NSUnitLength NauticalMiles { get; }

		[Static]
		[Export ("fathoms", ArgumentSemantic.Copy)]
		NSUnitLength Fathoms { get; }

		[Static]
		[Export ("furlongs", ArgumentSemantic.Copy)]
		NSUnitLength Furlongs { get; }

		[Static]
		[Export ("astronomicalUnits", ArgumentSemantic.Copy)]
		NSUnitLength AstronomicalUnits { get; }

		[Static]
		[Export ("parsecs", ArgumentSemantic.Copy)]
		NSUnitLength Parsecs { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitIlluminance : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("lux", ArgumentSemantic.Copy)]
		NSUnitIlluminance Lux { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitMass : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("kilograms", ArgumentSemantic.Copy)]
		NSUnitMass Kilograms { get; }

		[Static]
		[Export ("grams", ArgumentSemantic.Copy)]
		NSUnitMass Grams { get; }

		[Static]
		[Export ("decigrams", ArgumentSemantic.Copy)]
		NSUnitMass Decigrams { get; }

		[Static]
		[Export ("centigrams", ArgumentSemantic.Copy)]
		NSUnitMass Centigrams { get; }

		[Static]
		[Export ("milligrams", ArgumentSemantic.Copy)]
		NSUnitMass Milligrams { get; }

		[Static]
		[Export ("micrograms", ArgumentSemantic.Copy)]
		NSUnitMass Micrograms { get; }

		[Static]
		[Export ("nanograms", ArgumentSemantic.Copy)]
		NSUnitMass Nanograms { get; }

		[Static]
		[Export ("picograms", ArgumentSemantic.Copy)]
		NSUnitMass Picograms { get; }

		[Static]
		[Export ("ounces", ArgumentSemantic.Copy)]
		NSUnitMass Ounces { get; }

		[Static]
		[Export ("poundsMass", ArgumentSemantic.Copy)]
		NSUnitMass Pounds { get; }

		[Static]
		[Export ("stones", ArgumentSemantic.Copy)]
		NSUnitMass Stones { get; }

		[Static]
		[Export ("metricTons", ArgumentSemantic.Copy)]
		NSUnitMass MetricTons { get; }

		[Static]
		[Export ("shortTons", ArgumentSemantic.Copy)]
		NSUnitMass ShortTons { get; }

		[Static]
		[Export ("carats", ArgumentSemantic.Copy)]
		NSUnitMass Carats { get; }

		[Static]
		[Export ("ouncesTroy", ArgumentSemantic.Copy)]
		NSUnitMass OuncesTroy { get; }

		[Static]
		[Export ("slugs", ArgumentSemantic.Copy)]
		NSUnitMass Slugs { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitPower : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("terawatts", ArgumentSemantic.Copy)]
		NSUnitPower Terawatts { get; }

		[Static]
		[Export ("gigawatts", ArgumentSemantic.Copy)]
		NSUnitPower Gigawatts { get; }

		[Static]
		[Export ("megawatts", ArgumentSemantic.Copy)]
		NSUnitPower Megawatts { get; }

		[Static]
		[Export ("kilowatts", ArgumentSemantic.Copy)]
		NSUnitPower Kilowatts { get; }

		[Static]
		[Export ("watts", ArgumentSemantic.Copy)]
		NSUnitPower Watts { get; }

		[Static]
		[Export ("milliwatts", ArgumentSemantic.Copy)]
		NSUnitPower Milliwatts { get; }

		[Static]
		[Export ("microwatts", ArgumentSemantic.Copy)]
		NSUnitPower Microwatts { get; }

		[Static]
		[Export ("nanowatts", ArgumentSemantic.Copy)]
		NSUnitPower Nanowatts { get; }

		[Static]
		[Export ("picowatts", ArgumentSemantic.Copy)]
		NSUnitPower Picowatts { get; }

		[Static]
		[Export ("femtowatts", ArgumentSemantic.Copy)]
		NSUnitPower Femtowatts { get; }

		[Static]
		[Export ("horsepower", ArgumentSemantic.Copy)]
		NSUnitPower Horsepower { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitPressure : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("newtonsPerMetersSquared", ArgumentSemantic.Copy)]
		NSUnitPressure NewtonsPerMetersSquared { get; }

		[Static]
		[Export ("gigapascals", ArgumentSemantic.Copy)]
		NSUnitPressure Gigapascals { get; }

		[Static]
		[Export ("megapascals", ArgumentSemantic.Copy)]
		NSUnitPressure Megapascals { get; }

		[Static]
		[Export ("kilopascals", ArgumentSemantic.Copy)]
		NSUnitPressure Kilopascals { get; }

		[Static]
		[Export ("hectopascals", ArgumentSemantic.Copy)]
		NSUnitPressure Hectopascals { get; }

		[Static]
		[Export ("inchesOfMercury", ArgumentSemantic.Copy)]
		NSUnitPressure InchesOfMercury { get; }

		[Static]
		[Export ("bars", ArgumentSemantic.Copy)]
		NSUnitPressure Bars { get; }

		[Static]
		[Export ("millibars", ArgumentSemantic.Copy)]
		NSUnitPressure Millibars { get; }

		[Static]
		[Export ("millimetersOfMercury", ArgumentSemantic.Copy)]
		NSUnitPressure MillimetersOfMercury { get; }

		[Static]
		[Export ("poundsForcePerSquareInch", ArgumentSemantic.Copy)]
		NSUnitPressure PoundsForcePerSquareInch { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitSpeed : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("metersPerSecond", ArgumentSemantic.Copy)]
		NSUnitSpeed MetersPerSecond { get; }

		[Static]
		[Export ("kilometersPerHour", ArgumentSemantic.Copy)]
		NSUnitSpeed KilometersPerHour { get; }

		[Static]
		[Export ("milesPerHour", ArgumentSemantic.Copy)]
		NSUnitSpeed MilesPerHour { get; }

		[Static]
		[Export ("knots", ArgumentSemantic.Copy)]
		NSUnitSpeed Knots { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[DisableDefaultCtor] // -init should never be called on NSUnit!
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	partial class NSUnitVolume : NSSecureCoding {
		// inline from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("megaliters", ArgumentSemantic.Copy)]
		NSUnitVolume Megaliters { get; }

		[Static]
		[Export ("kiloliters", ArgumentSemantic.Copy)]
		NSUnitVolume Kiloliters { get; }

		[Static]
		[Export ("liters", ArgumentSemantic.Copy)]
		NSUnitVolume Liters { get; }

		[Static]
		[Export ("deciliters", ArgumentSemantic.Copy)]
		NSUnitVolume Deciliters { get; }

		[Static]
		[Export ("centiliters", ArgumentSemantic.Copy)]
		NSUnitVolume Centiliters { get; }

		[Static]
		[Export ("milliliters", ArgumentSemantic.Copy)]
		NSUnitVolume Milliliters { get; }

		[Static]
		[Export ("cubicKilometers", ArgumentSemantic.Copy)]
		NSUnitVolume CubicKilometers { get; }

		[Static]
		[Export ("cubicMeters", ArgumentSemantic.Copy)]
		NSUnitVolume CubicMeters { get; }

		[Static]
		[Export ("cubicDecimeters", ArgumentSemantic.Copy)]
		NSUnitVolume CubicDecimeters { get; }

		[Static]
		[Export ("cubicCentimeters", ArgumentSemantic.Copy)]
		NSUnitVolume CubicCentimeters { get; }

		[Static]
		[Export ("cubicMillimeters", ArgumentSemantic.Copy)]
		NSUnitVolume CubicMillimeters { get; }

		[Static]
		[Export ("cubicInches", ArgumentSemantic.Copy)]
		NSUnitVolume CubicInches { get; }

		[Static]
		[Export ("cubicFeet", ArgumentSemantic.Copy)]
		NSUnitVolume CubicFeet { get; }

		[Static]
		[Export ("cubicYards", ArgumentSemantic.Copy)]
		NSUnitVolume CubicYards { get; }

		[Static]
		[Export ("cubicMiles", ArgumentSemantic.Copy)]
		NSUnitVolume CubicMiles { get; }

		[Static]
		[Export ("acreFeet", ArgumentSemantic.Copy)]
		NSUnitVolume AcreFeet { get; }

		[Static]
		[Export ("bushels", ArgumentSemantic.Copy)]
		NSUnitVolume Bushels { get; }

		[Static]
		[Export ("teaspoons", ArgumentSemantic.Copy)]
		NSUnitVolume Teaspoons { get; }

		[Static]
		[Export ("tablespoons", ArgumentSemantic.Copy)]
		NSUnitVolume Tablespoons { get; }

		[Static]
		[Export ("fluidOunces", ArgumentSemantic.Copy)]
		NSUnitVolume FluidOunces { get; }

		[Static]
		[Export ("cups", ArgumentSemantic.Copy)]
		NSUnitVolume Cups { get; }

		[Static]
		[Export ("pints", ArgumentSemantic.Copy)]
		NSUnitVolume Pints { get; }

		[Static]
		[Export ("quarts", ArgumentSemantic.Copy)]
		NSUnitVolume Quarts { get; }

		[Static]
		[Export ("gallons", ArgumentSemantic.Copy)]
		NSUnitVolume Gallons { get; }

		[Static]
		[Export ("imperialTeaspoons", ArgumentSemantic.Copy)]
		NSUnitVolume ImperialTeaspoons { get; }

		[Static]
		[Export ("imperialTablespoons", ArgumentSemantic.Copy)]
		NSUnitVolume ImperialTablespoons { get; }

		[Static]
		[Export ("imperialFluidOunces", ArgumentSemantic.Copy)]
		NSUnitVolume ImperialFluidOunces { get; }

		[Static]
		[Export ("imperialPints", ArgumentSemantic.Copy)]
		NSUnitVolume ImperialPints { get; }

		[Static]
		[Export ("imperialQuarts", ArgumentSemantic.Copy)]
		NSUnitVolume ImperialQuarts { get; }

		[Static]
		[Export ("imperialGallons", ArgumentSemantic.Copy)]
		NSUnitVolume ImperialGallons { get; }

		[Static]
		[Export ("metricCups", ArgumentSemantic.Copy)]
		NSUnitVolume MetricCups { get; }

		[New] // kind of overloading a static member
		[Static]
		[Export ("baseUnit")]
		NSDimension BaseUnit { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public partial class NSMeasurement<UnitType> : NSCopying
		where UnitType : NSUnit {
		[Export ("unit", ArgumentSemantic.Copy)]
		NSUnit Unit { get; }

		[Export ("doubleValue")]
		double DoubleValue { get; }

		[Export ("initWithDoubleValue:unit:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (double doubleValue, NSUnit unit);

		[Export ("canBeConvertedToUnit:")]
		extern bool CanBeConvertedTo (NSUnit unit);

		[Export ("measurementByConvertingToUnit:")]
		extern NSMeasurement<UnitType> GetMeasurementByConverting (NSUnit unit);

		[Export ("measurementByAddingMeasurement:")]
		extern NSMeasurement<UnitType> GetMeasurementByAdding (NSMeasurement<UnitType> measurement);

		[Export ("measurementBySubtractingMeasurement:")]
		extern NSMeasurement<UnitType> GetMeasurementBySubtracting (NSMeasurement<UnitType> measurement);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSMeasurementFormatter : NSSecureCoding {

		[Export ("unitOptions", ArgumentSemantic.Assign)]
		NSMeasurementFormatterUnitOptions UnitOptions { get; set; }

		[Export ("unitStyle", ArgumentSemantic.Assign)]
		NSFormattingUnitStyle UnitStyle { get; set; }

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[Export ("numberFormatter", ArgumentSemantic.Copy)]
		NSNumberFormatter NumberFormatter { get; set; }

		[Export ("stringFromMeasurement:")]
		extern string ToString (NSMeasurement<NSUnit> measurement);

		[Export ("stringFromUnit:")]
		extern string ToString (NSUnit unit);
	}

	

	partial class INSXpcListenerDelegate { }

	[BaseType (typeof (NSObject), Name = "NSXPCListener", Delegates = new string [] { "WeakDelegate" })]
	[DisableDefaultCtor]
	partial class NSXpcListener {
		[Export ("serviceListener")]
		[Static]
		NSXpcListener ServiceListener { get; }

		[Export ("anonymousListener")]
		[Static]
		NSXpcListener AnonymousListener { get; }

		[Export ("initWithMachServiceName:")]
		[DesignatedInitializer]
		[NoiOS]
		[NoTV]
		[NoWatch]
		[NoMacCatalyst]
		extern NativeHandle Constructor (string machServiceName);

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSXpcListenerDelegate Delegate { get; set; }

		[Export ("endpoint")]
		NSXpcListenerEndpoint Endpoint { get; }

		[Advice ("Prefer using 'Activate' for initial activation of a listener.")]
		[Export ("resume")]
		extern void Resume ();

		[Export ("suspend")]
		extern void Suspend ();

		[Export ("invalidate")]
		extern void Invalidate ();

		[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("activate")]
		extern void Activate ();

		[NoWatch, NoTV, NoiOS, Mac (13, 0)]
		[NoMacCatalyst]
		[Export ("setConnectionCodeSigningRequirement:")]
		extern void SetConnectionCodeSigningRequirement (string requirement);
	}

	[BaseType (typeof (NSObject), Name = "NSXPCListenerDelegate")]
#if NET
	[Protocol, Model]
#else
	[Model (AutoGeneratedName = true), Protocol]
#endif
	partial class NSXpcListenerDelegate {
		[Export ("listener:shouldAcceptNewConnection:")]
		extern bool ShouldAcceptConnection (NSXpcListener listener, NSXpcConnection newConnection);
	}

	

	[BaseType (typeof (NSObject), Name = "NSXPCListenerEndpoint")]
	[DisableDefaultCtor]
	partial class NSXpcListenerEndpoint : NSSecureCoding {
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSListFormatter {

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[NullAllowed, Export ("itemFormatter", ArgumentSemantic.Copy)]
		NSFormatter ItemFormatter { get; set; }

		[Static]
		[Export ("localizedStringByJoiningStrings:")]
		// using `NSString[]` since they might be one (or many) `NSString` subclass(es) that handle localization
		extern static string GetLocalizedString (NSString [] joinedStrings);

		[Export ("stringFromItems:")]
		[return: NullAllowed]
		extern string? GetString (NSObject [] items);

		[Export ("stringForObjectValue:")]
		[return: NullAllowed]
		extern string? GetString ([NullAllowed] NSObject obj);
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	enum NSRelativeDateTimeFormatterStyle : long {
		Numeric = 0,
		Named,
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	enum NSRelativeDateTimeFormatterUnitsStyle : long {
		Full = 0,
		SpellOut,
		Short,
		Abbreviated,
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSFormatter))]
	partial class NSRelativeDateTimeFormatter {

		[Export ("dateTimeStyle", ArgumentSemantic.Assign)]
		NSRelativeDateTimeFormatterStyle DateTimeStyle { get; set; }

		[Export ("unitsStyle", ArgumentSemantic.Assign)]
		NSRelativeDateTimeFormatterUnitsStyle UnitsStyle { get; set; }

		[Export ("formattingContext", ArgumentSemantic.Assign)]
		NSFormattingContext FormattingContext { get; set; }

		[Export ("calendar", ArgumentSemantic.Copy)]
		NSCalendar Calendar { get; set; }

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[Export ("localizedStringFromDateComponents:")]
		extern string GetLocalizedString (NSDateComponents dateComponents);

		[Export ("localizedStringFromTimeInterval:")]
		extern string GetLocalizedString (double timeInterval);

		[Export ("localizedStringForDate:relativeToDate:")]
		extern string GetLocalizedString (NSDate date, NSDate referenceDate);

		[Export ("stringForObjectValue:")]
		[return: NullAllowed]
		extern string GetString ([NullAllowed] NSObject obj);
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	enum NSCollectionChangeType : long {
		Insert,
		Remove,
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	enum NSOrderedCollectionDifferenceCalculationOptions : ulong {
		OmitInsertedObjects = (1uL << 0),
		OmitRemovedObjects = (1uL << 1),
		InferMoves = (1uL << 2),
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSDimension))]
	[DisableDefaultCtor] // NSGenericException Reason: -init should never be called on NSUnit!
	partial class NSUnitInformationStorage : NSSecureCoding {

		// Inlined from base type
		[Export ("initWithSymbol:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol);

		// Inlined from base type
		[Export ("initWithSymbol:converter:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string symbol, NSUnitConverter converter);

		[Static]
		[Export ("bytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Bytes { get; }

		[Static]
		[Export ("bits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Bits { get; }

		[Static]
		[Export ("nibbles", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Nibbles { get; }

		[Static]
		[Export ("yottabytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Yottabytes { get; }

		[Static]
		[Export ("zettabytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Zettabytes { get; }

		[Static]
		[Export ("exabytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Exabytes { get; }

		[Static]
		[Export ("petabytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Petabytes { get; }

		[Static]
		[Export ("terabytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Terabytes { get; }

		[Static]
		[Export ("gigabytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Gigabytes { get; }

		[Static]
		[Export ("megabytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Megabytes { get; }

		[Static]
		[Export ("kilobytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Kilobytes { get; }

		[Static]
		[Export ("yottabits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Yottabits { get; }

		[Static]
		[Export ("zettabits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Zettabits { get; }

		[Static]
		[Export ("exabits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Exabits { get; }

		[Static]
		[Export ("petabits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Petabits { get; }

		[Static]
		[Export ("terabits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Terabits { get; }

		[Static]
		[Export ("gigabits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Gigabits { get; }

		[Static]
		[Export ("megabits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Megabits { get; }

		[Static]
		[Export ("kilobits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Kilobits { get; }

		[Static]
		[Export ("yobibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Yobibytes { get; }

		[Static]
		[Export ("zebibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Zebibytes { get; }

		[Static]
		[Export ("exbibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Exbibytes { get; }

		[Static]
		[Export ("pebibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Pebibytes { get; }

		[Static]
		[Export ("tebibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Tebibytes { get; }

		[Static]
		[Export ("gibibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Gibibytes { get; }

		[Static]
		[Export ("mebibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Mebibytes { get; }

		[Static]
		[Export ("kibibytes", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Kibibytes { get; }

		[Static]
		[Export ("yobibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Yobibits { get; }

		[Static]
		[Export ("zebibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Zebibits { get; }

		[Static]
		[Export ("exbibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Exbibits { get; }

		[Static]
		[Export ("pebibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Pebibits { get; }

		[Static]
		[Export ("tebibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Tebibits { get; }

		[Static]
		[Export ("gibibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Gibibits { get; }

		[Static]
		[Export ("mebibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Mebibits { get; }

		[Static]
		[Export ("kibibits", ArgumentSemantic.Copy)]
		NSUnitInformationStorage Kibibits { get; }
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	enum NSUrlSessionWebSocketMessageType : long {
		Data = 0,
		String = 1,
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Name = "NSURLSessionWebSocketMessage")]
	[DisableDefaultCtor]
	public partial class NSUrlSessionWebSocketMessage {

		[Export ("initWithData:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (NSData data);

		[Export ("initWithString:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string @string);

		[Export ("type")]
		NSUrlSessionWebSocketMessageType Type { get; }

		[NullAllowed, Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		[NullAllowed, Export ("string")]
		string String { get; }
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum NSUrlSessionWebSocketCloseCode : long {
		Invalid = 0,
		NormalClosure = 1000,
		GoingAway = 1001,
		ProtocolError = 1002,
		UnsupportedData = 1003,
		NoStatusReceived = 1005,
		AbnormalClosure = 1006,
		InvalidFramePayloadData = 1007,
		PolicyViolation = 1008,
		MessageTooBig = 1009,
		MandatoryExtensionMissing = 1010,
		InternalServerError = 1011,
		TlsHandshakeFailure = 1015,
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSUrlSessionTask), Name = "NSURLSessionWebSocketTask")]
	[DisableDefaultCtor]
	public partial class NSUrlSessionWebSocketTask {

		[Export ("sendMessage:completionHandler:")]
		[Async]
		public extern void SendMessage (NSUrlSessionWebSocketMessage message, Action<NSError> completionHandler);

		[Export ("receiveMessageWithCompletionHandler:")]
		[Async]
		public extern void ReceiveMessage (Action<NSUrlSessionWebSocketMessage, NSError> completionHandler);

		[Export ("sendPingWithPongReceiveHandler:")]
		[Async]
		public extern void SendPing (Action<NSError> pongReceiveHandler);

		[Export ("cancelWithCloseCode:reason:")]
		public extern void Cancel (NSUrlSessionWebSocketCloseCode closeCode, [NullAllowed] NSData reason);

		[Export ("maximumMessageSize")]
		public nint MaximumMessageSize { get; set; }

		[Export ("closeCode")]
		public NSUrlSessionWebSocketCloseCode CloseCode { get; }

		[NullAllowed, Export ("closeReason", ArgumentSemantic.Copy)]
		public NSData CloseReason { get; }
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
#if NET
	[Protocol][Model]
#else
	[Protocol]
	[Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSUrlSessionTaskDelegate), Name = "NSURLSessionWebSocketDelegate")]
	partial class NSUrlSessionWebSocketDelegate {

		[Export ("URLSession:webSocketTask:didOpenWithProtocol:")]
		extern void DidOpen (NSUrlSession session, NSUrlSessionWebSocketTask webSocketTask, [NullAllowed] string protocol);

		[Export ("URLSession:webSocketTask:didCloseWithCode:reason:")]
		extern 	void DidClose (NSUrlSession session, NSUrlSessionWebSocketTask webSocketTask, NSUrlSessionWebSocketCloseCode closeCode, [NullAllowed] NSData reason);
	}

	[Watch (6, 0), TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	enum NSUrlErrorNetworkUnavailableReason : long {
		Cellular = 0,
		Expensive = 1,
		Constrained = 2,
	}

	[NoWatch, NoTV, NoiOS]
	[NoMacCatalyst]
	[Native]
	public enum NSBackgroundActivityResult : long {
		Finished = 1,
		Deferred = 2,
	}

	delegate void NSBackgroundActivityCompletionHandler (NSBackgroundActivityResult result);

	delegate void NSBackgroundActivityCompletionAction ([BlockCallback] NSBackgroundActivityCompletionHandler handler);

	[NoWatch, NoTV, NoiOS]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSBackgroundActivityScheduler {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string identifier);

		[Export ("identifier")]
		string Identifier { get; }

		[Export ("qualityOfService", ArgumentSemantic.Assign)]
		NSQualityOfService QualityOfService { get; set; }

		[Export ("repeats")]
		bool Repeats { get; set; }

		[Export ("interval")]
		double Interval { get; set; }

		[Export ("tolerance")]
		double Tolerance { get; set; }

		[Export ("scheduleWithBlock:")]
		extern void Schedule (NSBackgroundActivityCompletionAction action);

		[Export ("invalidate")]
		extern void Invalidate ();

		[Export ("shouldDefer")]
		bool ShouldDefer { get; }
	}

	[Watch (7, 0), TV (14, 0), iOS (14, 0)]
	[MacCatalyst (14, 0)]
	[Native]
	public enum NSUrlSessionTaskMetricsDomainResolutionProtocol : long {
		Unknown,
		Udp,
		Tcp,
		Tls,
		Https,
	}

	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (15, 0)]
	[Native]
	public enum NSNotificationSuspensionBehavior : ulong {
		Drop = 1,
		Coalesce = 2,
		Hold = 3,
		DeliverImmediately = 4,
	}

	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (15, 0)]
	[Flags]
	[Native]
	public enum NSNotificationFlags : ulong {
		DeliverImmediately = (1 << 0),
		PostToAllSessions = (1 << 1),
	}

	[NoWatch]
	[NoTV]
	[NoiOS]
	[NoMacCatalyst]
	[Native]
	[Flags]
	public enum NSFileManagerUnmountOptions : ulong {
		AllPartitionsAndEjectDisk = 1 << 0,
		WithoutUI = 1 << 1,
	}

	[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSPresentationIntent : NSCopying{
		[Export ("intentKind")]
		NSPresentationIntentKind IntentKind { get; }

		[NullAllowed, Export ("parentIntent", ArgumentSemantic.Strong)]
		NSPresentationIntent ParentIntent { get; }

		[Static]
		[Export ("paragraphIntentWithIdentity:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateParagraphIntent (nint identity, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("headerIntentWithIdentity:level:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateHeaderIntent (nint identity, nint level, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("codeBlockIntentWithIdentity:languageHint:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateCodeBlockIntent (nint identity, [NullAllowed] string languageHint, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("thematicBreakIntentWithIdentity:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateThematicBreakIntent (nint identity, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("orderedListIntentWithIdentity:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateOrderedListIntent (nint identity, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("unorderedListIntentWithIdentity:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateUnorderedListIntent (nint identity, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("listItemIntentWithIdentity:ordinal:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateListItemIntent (nint identity, nint ordinal, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("blockQuoteIntentWithIdentity:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateBlockQuoteIntent (nint identity, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("tableIntentWithIdentity:columnCount:alignments:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateTableIntent (nint identity, nint columnCount, NSNumber [] alignments, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("tableHeaderRowIntentWithIdentity:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateTableHeaderRowIntent (nint identity, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("tableRowIntentWithIdentity:row:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateTableRowIntent (nint identity, nint row, [NullAllowed] NSPresentationIntent parent);

		[Static]
		[Export ("tableCellIntentWithIdentity:column:nestedInsideIntent:")]
		extern static NSPresentationIntent CreateTableCellIntent (nint identity, nint column, [NullAllowed] NSPresentationIntent parent);

		[Export ("identity")]
		nint Identity { get; }

		[Export ("ordinal")]
		nint Ordinal { get; }

		[NullAllowed, Export ("columnAlignments")]
		NSNumber [] ColumnAlignments { get; }

		[Export ("columnCount")]
		nint ColumnCount { get; }

		[Export ("headerLevel")]
		nint HeaderLevel { get; }

		[NullAllowed, Export ("languageHint")]
		string LanguageHint { get; }

		[Export ("column")]
		nint Column { get; }

		[Export ("row")]
		nint Row { get; }

		[Export ("indentationLevel")]
		nint IndentationLevel { get; }

		[Export ("isEquivalentToPresentationIntent:")]
		extern bool IsEquivalent (NSPresentationIntent other);
	}

	[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	public partial class NSAttributedStringMarkdownParsingOptions : NSCopying {
		[Export ("allowsExtendedAttributes")]
		bool AllowsExtendedAttributes { get; set; }

		[Export ("interpretedSyntax", ArgumentSemantic.Assign)]
		NSAttributedStringMarkdownInterpretedSyntax InterpretedSyntax { get; set; }

		[Export ("failurePolicy", ArgumentSemantic.Assign)]
		NSAttributedStringMarkdownParsingFailurePolicy FailurePolicy { get; set; }

		[NullAllowed, Export ("languageCode")]
		string LanguageCode { get; set; }

		[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		[Export ("appliesSourcePositionAttributes")]
		bool AppliesSourcePositionAttributes { get; set; }
	}

	[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSInflectionRule : NSCopying {
		[Static]
		[Export ("automaticRule")]
		static NSInflectionRule AutomaticRule { get; }

		[Watch (8, 0), TV (15, 0), iOS (15, 0)]
		[MacCatalyst (15, 0)]
		[Static]
		[Export ("canInflectLanguage:")]
		extern static bool CanInflectLanguage (string language);

		[Watch (8, 0), TV (15, 0), iOS (15, 0)]
		[MacCatalyst (15, 0)]
		[Static]
		[Export ("canInflectPreferredLocalization")]
		static bool CanInflectPreferredLocalization { get; }
	}

	[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSInflectionRule))]
	partial class NSInflectionRuleExplicit {
		[Export ("initWithMorphology:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (NSMorphology morphology);

		[Export ("morphology", ArgumentSemantic.Copy)]
		NSMorphology Morphology { get; }
	}

	[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	partial class NSMorphology : NSCopying {
		[Export ("grammaticalGender", ArgumentSemantic.Assign)]
		NSGrammaticalGender GrammaticalGender { get; set; }

		[Export ("partOfSpeech", ArgumentSemantic.Assign)]
		NSGrammaticalPartOfSpeech PartOfSpeech { get; set; }

		[Export ("number", ArgumentSemantic.Assign)]
		NSGrammaticalNumber Number { get; set; }

	
		[Obsoleted (PlatformName.WatchOS, 10, 0, message: "Use 'NSTermOfAddress' instead.")]
		[Export ("customPronounForLanguage:")]
		[return: NullAllowed]
		extern NSMorphologyCustomPronoun GetCustomPronoun (string language);

		
		[Obsoleted (PlatformName.WatchOS, 10, 0, message: "Use 'NSTermOfAddress' instead.")]
		[Export ("setCustomPronoun:forLanguage:error:")]
		extern bool SetCustomPronoun ([NullAllowed] NSMorphologyCustomPronoun features, string language, [NullAllowed] out NSError error);

		[Export ("unspecified")]
		bool Unspecified { [Bind ("isUnspecified")] get; }

		[Static]
		[Export ("userMorphology")]
		NSMorphology UserMorphology { get; }

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("grammaticalCase", ArgumentSemantic.Assign)]
		NSGrammaticalCase GrammaticalCase { get; set; }

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("determination", ArgumentSemantic.Assign)]
		NSGrammaticalDetermination Determination { get; set; }

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("grammaticalPerson", ArgumentSemantic.Assign)]
		NSGrammaticalPerson GrammaticalPerson { get; set; }

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("pronounType", ArgumentSemantic.Assign)]
		NSGrammaticalPronounType PronounType { get; set; }

		[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("definiteness", ArgumentSemantic.Assign)]
		NSGrammaticalDefiniteness Definiteness { get; set; }
	}

	
	[Obsoleted (PlatformName.WatchOS, 10, 0, message: "Use 'NSTermOfAddress' instead.")]
	[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	partial class NSMorphologyCustomPronoun : NSCopying {
		[Static]
		[Export ("isSupportedForLanguage:")]
		static extern bool IsSupported (string language);

		[Static]
		[Export ("requiredKeysForLanguage:")]
		static extern string [] GetRequiredKeysForLanguage (string language);

		[NullAllowed, Export ("subjectForm")]
		string SubjectForm { get; set; }

		[NullAllowed, Export ("objectForm")]
		string ObjectForm { get; set; }

		[NullAllowed, Export ("possessiveForm")]
		string PossessiveForm { get; set; }

		[NullAllowed, Export ("possessiveAdjectiveForm")]
		string PossessiveAdjectiveForm { get; set; }

		[NullAllowed, Export ("reflexiveForm")]
		string ReflexiveForm { get; set; }
	}

#if false // https://github.com/xamarin/xamarin-macios/issues/15577
	partial class NSOrderedCollectionChange <TKey> : NSOrderedCollectionChange {}
	
	[Watch (6,0), TV (13,0), iOS (13,0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSOrderedCollectionChange
	{
		[Internal]
		[Static]
		[Export ("changeWithObject:type:index:")]
		NativeHandle _ChangeWithObject ([NullAllowed] IntPtr anObject, NSCollectionChangeType type, nuint index);

		[Internal]
		[Static]
		[Export ("changeWithObject:type:index:associatedIndex:")]
		NativeHandle _ChangeWithObject ([NullAllowed] IntPtr anObject, NSCollectionChangeType type, nuint index, nuint associatedIndex);

		[Internal]
		[NullAllowed, Export ("object", ArgumentSemantic.Strong)]
		NativeHandle _Object { get; }

		[Export ("changeType")]
		NSCollectionChangeType ChangeType { get; }

		[Export ("index")]
		nuint Index { get; }

		[Export ("associatedIndex")]
		nuint AssociatedIndex { get; }

		[Internal]
		[Export ("initWithObject:type:index:")]
		NativeHandle Constructor (IntPtr anObject, NSCollectionChangeType type, nuint index);
		
		[Wrap ("this (anObject!.Handle, type, index)")]
		NativeHandle Constructor ([NullAllowed] NSObject anObject, NSCollectionChangeType type, nuint index);

		[Internal]
		[DesignatedInitializer]
		[Export ("initWithObject:type:index:associatedIndex:")]
		NativeHandle Constructor (IntPtr anObject, NSCollectionChangeType type, nuint index, nuint associatedIndex);
		
		[Wrap ("this (anObject!.Handle, type, index, associatedIndex)")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSObject anObject, NSCollectionChangeType type, nuint index, nuint associatedIndex);
	}

	partial class NSOrderedCollectionDifference <TKey> : NSOrderedCollectionDifference {}
	
	[Watch (6,0), TV (13,0), iOS (13,0)]
	[BaseType (typeof (NSObject))]
	partial class NSOrderedCollectionDifference : INSFastEnumeration
	{
		[Export ("initWithChanges:")]
		NativeHandle Constructor (NSOrderedCollectionChange[] changes);
		
		[Internal]
		[DesignatedInitializer]
		[Export ("initWithInsertIndexes:insertedObjects:removeIndexes:removedObjects:additionalChanges:")]
		NativeHandle Constructor (NSIndexSet inserts, [NullAllowed] NSArray insertedObjects, NSIndexSet removes, [NullAllowed] NSArray removedObjects, NSOrderedCollectionChange[] changes);

		[Wrap ("this (inserts, NSArray.FromNSObjects (insertedObjects), removes, NSArray.FromNSObjects (removedObjects), changes)")]
		NativeHandle Constructor (NSIndexSet inserts, [NullAllowed] NSObject[] insertedObjects, NSIndexSet removes, [NullAllowed] NSObject[] removedObjects, NSOrderedCollectionChange[] changes);

		[Internal]
		[Export ("initWithInsertIndexes:insertedObjects:removeIndexes:removedObjects:")]
		NativeHandle Constructor (NSIndexSet inserts, [NullAllowed] NSArray insertedObjects, NSIndexSet removes, [NullAllowed] NSArray removedObjects);
		
		[Wrap ("this (inserts, NSArray.FromNSObjects (insertedObjects), removes, NSArray.FromNSObjects (removedObjects))")]
		NativeHandle Constructor (NSIndexSet inserts, [NullAllowed] NSObject[] insertedObjects, NSIndexSet removes, [NullAllowed] NSObject[] removedObjects);

		[Internal]
		[Export ("insertions", ArgumentSemantic.Strong)]
		NativeHandle _Insertions { get; }

		[Internal]
		[Export ("removals", ArgumentSemantic.Strong)]
		NativeHandle _Removals { get; }

		[Export ("hasChanges")]
		bool HasChanges { get; }

		[Internal]
		[Export ("differenceByTransformingChangesWithBlock:")]
		NativeHandle _GetDifference (/* Func<NSOrderedCollectionChange<NSObject>, NSOrderedCollectionChange<NSObject>>*/ ref BlockLiteral block); 

		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("inverseDifference")]
		NativeHandle _InverseDifference ();
	}
#endif

	[Watch (9, 0), TV (16, 0), Mac (13, 0), iOS (16, 0)]
	[MacCatalyst (16, 0)]
	[BaseType (typeof (NSObject))]
	partial class NSAttributedStringMarkdownSourcePosition : NSCopying {
		[Export ("startLine")]
		nint StartLine { get; }

		[Export ("startColumn")]
		nint StartColumn { get; }

		[Export ("endLine")]
		nint EndLine { get; }

		[Export ("endColumn")]
		nint EndColumn { get; }

		[Export ("initWithStartLine:startColumn:endLine:endColumn:")]
		extern NativeHandle Constructor (nint startLine, nint startColumn, nint endLine, nint endColumn);

		[Export ("rangeInString:")]
		extern NSRange RangeInString (string @string);
	}

	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSTermOfAddress : NSCopying {
		[Static]
		[Export ("neutral")]
		NSTermOfAddress Neutral { get; }

		[Static]
		[Export ("feminine")]
		NSTermOfAddress Feminine { get; }

		[Static]
		[Export ("masculine")]
		NSTermOfAddress Masculine { get; }

		[Static]
		[Export ("localizedForLanguageIdentifier:withPronouns:")]
		extern static NSTermOfAddress GetLocalized (string language, NSMorphologyPronoun [] pronouns);

		[NullAllowed, Export ("languageIdentifier")]
		string LanguageIdentifier { get; }

		[NullAllowed, Export ("pronouns", ArgumentSemantic.Copy)]
		NSMorphologyPronoun [] Pronouns { get; }

		[Static]
		[Export ("currentUser")]
		[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		NSTermOfAddress CurrentUser { get; }
	}

	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSMorphologyPronoun : NSCopying {
		[Export ("initWithPronoun:morphology:dependentMorphology:")]
		extern NativeHandle Constructor (string pronoun, NSMorphology morphology, [NullAllowed] NSMorphology dependentMorphology);

		[Export ("pronoun")]
		string Pronoun { get; }

		[Export ("morphology", ArgumentSemantic.Copy)]
		NSMorphology Morphology { get; }

		[NullAllowed, Export ("dependentMorphology", ArgumentSemantic.Copy)]
		NSMorphology DependentMorphology { get; }
	}



	[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSKeyValueSharedObserversSnapshot {
	}

	[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSKeyValueSharedObservers {
		[Export ("initWithObservableClass:")]
		extern NativeHandle Constructor (Class observableClass);

		[Wrap ("this (new Class (observableType))")]
		extern NativeHandle Constructor (Type observableType);

		[Export ("addSharedObserver:forKey:options:context:")]
		extern void AddSharedObserver (NSObject observer, string forKey, NSKeyValueObservingOptions options, IntPtr context);

		[Export ("snapshot")]
		extern NSKeyValueSharedObserversSnapshot GetSnapshot ();
	}

	//[Category, BaseType (typeof (NSObject))]
	[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	partial class NSKeyValueSharedObserverRegistration_NSObject {
		[Export ("setSharedObservers:")]
		extern void SetSharedObservers ([NullAllowed] NSKeyValueSharedObserversSnapshot sharedObservers);
	}

	[BaseType (typeof (NSObject))]
	[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[DisableDefaultCtor]
	partial class NSLocalizedNumberFormatRule : NSCopying {
		[Static]
		[Export ("automatic")]
		NSLocalizedNumberFormatRule Automatic { get; }
	}
}
