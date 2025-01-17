using System;
using System.Collections.ObjectModel;
using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

	public partial class NSTimeZone {

		static ReadOnlyCollection<string> known_time_zone_names;

		// avoid exposing an array - it's too easy to break
		public static ReadOnlyCollection<string> KnownTimeZoneNames {
			get {
				if (known_time_zone_names is null)
					known_time_zone_names = new ReadOnlyCollection<string> (_KnownTimeZoneNames);
				return known_time_zone_names;
			}
		}

		public override string ToString ()
		{
			return Name;
		}
	}
	
	[BaseType (typeof (NSObject))]
	// NSTimeZone is an abstract class that defines the behavior of time zone objects. -> http://developer.apple.com/library/ios/#documentation/Cocoa/Reference/Foundation/Classes/NSTimeZone_Class/Reference/Reference.html
	// calling 'init' returns a NIL pointer, i.e. an unusable instance
	[DisableDefaultCtor]
	public partial class NSTimeZone :  NSCopying {
		[Export ("initWithName:")]
		public extern NativeHandle Constructor (string name);

		[Export ("initWithName:data:")]
		public extern NativeHandle Constructor (string name, NSData data);

		[Export ("name")]
		public extern string Name { get; }

		[Export ("data")]
		public extern NSData Data { get; }

		[Export ("secondsFromGMTForDate:")]
		public extern nint SecondsFromGMT (NSDate date);

		[Static]
		[Export ("abbreviationDictionary")]
		public extern static NSDictionary Abbreviations { get; }

		[Export ("abbreviation")]
		public extern string Abbreviation ();

		[Export ("abbreviationForDate:")]
		public extern string Abbreviation (NSDate date);

		[Export ("isDaylightSavingTimeForDate:")]
		public extern bool IsDaylightSavingsTime (NSDate date);

		[Export ("daylightSavingTimeOffsetForDate:")]
		public extern double DaylightSavingTimeOffset (NSDate date);

		[Export ("nextDaylightSavingTimeTransitionAfterDate:")]
		public extern NSDate NextDaylightSavingTimeTransitionAfter (NSDate date);

		[Static, Export ("timeZoneWithName:")]
		public extern static NSTimeZone FromName (string tzName);

		[Static, Export ("timeZoneWithName:data:")]
		public extern static NSTimeZone FromName (string tzName, NSData data);

		[Static]
		[Export ("timeZoneForSecondsFromGMT:")]
		public extern static NSTimeZone FromGMT (nint seconds);

		[Static, Export ("localTimeZone", ArgumentSemantic.Copy)]
		public extern static NSTimeZone LocalTimeZone { get; }

		[Export ("secondsFromGMT")]
		public extern nint GetSecondsFromGMT { get; }

		[Export ("defaultTimeZone", ArgumentSemantic.Copy), Static]
		public extern NSTimeZone DefaultTimeZone { get; set; }

		[Export ("resetSystemTimeZone"), Static]
		public extern void ResetSystemTimeZone ();

		[Export ("systemTimeZone", ArgumentSemantic.Copy), Static]
		public extern NSTimeZone SystemTimeZone { get; }

		[Export ("timeZoneWithAbbreviation:"), Static]
		public extern NSTimeZone FromAbbreviation (string abbreviation);

		[Export ("knownTimeZoneNames"), Static, Internal]
		public static extern string [] _KnownTimeZoneNames { get; }

		[Export ("timeZoneDataVersion"), Static]
		public extern string DataVersion { get; }

		[Export ("localizedName:locale:")]
		public extern string GetLocalizedName (NSTimeZoneNameStyle style, [NullAllowed] NSLocale locale);

		[Notification]
		[Field ("NSSystemTimeZoneDidChangeNotification")]
		public extern NSString SystemTimeZoneDidChangeNotification { get; }
	}
}
