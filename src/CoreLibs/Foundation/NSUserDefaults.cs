using System;
using ObjCRuntime;

#nullable enable

namespace Foundation {

	public enum NSUserDefaultsType {
		UserName,
		SuiteName
	}

	public partial class NSUserDefaults  {
#if NET
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
		[ObsoletedOSPlatform ("macos10.10")]
		[ObsoletedOSPlatform ("ios7.0")]
#else
		[Deprecated (PlatformName.iOS, 7, 0)]
		[Deprecated (PlatformName.MacOSX, 10, 10)]
#endif
		public NSUserDefaults (string name) : this (name, NSUserDefaultsType.UserName)
		{
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("tvos")]
#endif
		public NSUserDefaults (string? name, NSUserDefaultsType type)
		{
			// two different `init*` would share the same C# signature
			switch (type) {
			case NSUserDefaultsType.UserName:
				if (name is null)
					throw new ArgumentNullException (nameof (name));
				Handle = InitWithUserName (name);
				break;
			case NSUserDefaultsType.SuiteName:
				Handle = InitWithSuiteName (name);
				break;
			default:
				throw new ArgumentException (nameof (type));
			}
		}

		public void SetString (string? value, string defaultName)
		{
			using var str = (NSString?) value;
			SetObjectForKey (str, defaultName);
		}

		public NSObject? this [string key] {
			get {
				return ObjectForKey (key);
			}

			set {
				SetObjectForKey (value, key);
			}
		}
	}
	
	[BaseType (typeof (NSObject))]
	partial class NSUserDefaults: NSObject {
		[Export ("URLForKey:")]
		[return: NullAllowed]
		public extern NSUrl? URLForKey (string defaultName);

		[Export ("setURL:forKey:")]
		public extern void SetURL ([NullAllowed] NSUrl url, string defaultName);

		[Static]
		[Export ("standardUserDefaults", ArgumentSemantic.Strong)]
		public extern NSUserDefaults StandardUserDefaults { get; }

		[Static]
		[Export ("resetStandardUserDefaults")]
		public extern void ResetStandardUserDefaults ();

		[Internal]
		[Export ("initWithUser:")]
		public extern IntPtr InitWithUserName (string username);

		[Internal]
		[MacCatalyst (13, 1)]
		[Export ("initWithSuiteName:")]
		public extern IntPtr InitWithSuiteName ([NullAllowed] string suiteName);

		[Export ("objectForKey:")]
		[Internal]
		[return: NullAllowed]
		public extern NSObject ObjectForKey (string defaultName);

		[Export ("setObject:forKey:")]
		[Internal]
		public extern void SetObjectForKey ([NullAllowed] NSObject value, string defaultName);

		[Export ("removeObjectForKey:")]
		public extern void RemoveObject (string defaultName);

		[return: NullAllowed]
		[Export ("stringForKey:")]
		public extern string StringForKey (string defaultName);

		[return: NullAllowed]
		[Export ("arrayForKey:")]
		public extern NSObject [] ArrayForKey (string defaultName);

		[return: NullAllowed]
		[Export ("dictionaryForKey:")]
		public extern NSDictionary DictionaryForKey (string defaultName);

		[return: NullAllowed]
		[Export ("dataForKey:")]
		public extern NSData DataForKey (string defaultName);

		[return: NullAllowed]
		[Export ("stringArrayForKey:")]
		public extern string [] StringArrayForKey (string defaultName);

		[Export ("integerForKey:")]
		public extern nint IntForKey (string defaultName);

		[Export ("floatForKey:")]
		public extern float FloatForKey (string defaultName); // this is defined as float, not CGFloat.

		[Export ("doubleForKey:")]
		public extern double DoubleForKey (string defaultName);

		[Export ("boolForKey:")]
		public extern bool BoolForKey (string defaultName);

		[Export ("setInteger:forKey:")]
		public extern void SetInt (nint value, string defaultName);

		[Export ("setFloat:forKey:")]
		public extern void SetFloat (float value /* this is defined as float, not CGFloat */, string defaultName);

		[Export ("setDouble:forKey:")]
		public extern void SetDouble (double value, string defaultName);

		[Export ("setBool:forKey:")]
		public extern void SetBool (bool value, string defaultName);

		[Export ("registerDefaults:")]
		public extern void RegisterDefaults (NSDictionary registrationDictionary);

		[Export ("addSuiteNamed:")]
		public extern void AddSuite (string suiteName);

		[Export ("removeSuiteNamed:")]
		public extern void RemoveSuite (string suiteName);

		[Export ("dictionaryRepresentation")]
		public extern NSDictionary ToDictionary ();

		[Export ("volatileDomainNames")]
#if XAMCORE_5_0
		public extern string [] VolatileDomainNames { get; }
#else
		public extern string [] VolatileDomainNames ();
#endif

		[Export ("volatileDomainForName:")]
		public extern NSDictionary GetVolatileDomain (string domainName);

		[Export ("setVolatileDomain:forName:")]
		public extern void SetVolatileDomain (NSDictionary domain, string domainName);

		[Export ("removeVolatileDomainForName:")]
		public extern void RemoveVolatileDomain (string domainName);

		[Deprecated (PlatformName.iOS, 7, 0)]
		[Deprecated (PlatformName.TvOS, 9, 0)]
		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Export ("persistentDomainNames")]
		public extern string [] PersistentDomainNames ();

		[return: NullAllowed]
		[Export ("persistentDomainForName:")]
		public extern NSDictionary PersistentDomainForName (string domainName);

		[Export ("setPersistentDomain:forName:")]
		public extern void SetPersistentDomain (NSDictionary domain, string domainName);

		[Export ("removePersistentDomainForName:")]
		public extern void RemovePersistentDomain (string domainName);

		[Export ("synchronize")]
		public extern bool Synchronize ();

		[Export ("objectIsForcedForKey:")]
		public extern bool ObjectIsForced (string key);

		[Export ("objectIsForcedForKey:inDomain:")]
		public extern bool ObjectIsForced (string key, string domain);

		[Field ("NSGlobalDomain")]
		public extern NSString GlobalDomain { get; }

		[Field ("NSArgumentDomain")]
		public extern NSString ArgumentDomain { get; }

		[Field ("NSRegistrationDomain")]
		public extern NSString RegistrationDomain { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSUserDefaultsSizeLimitExceededNotification")]
		public extern NSString SizeLimitExceededNotification { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSUbiquitousUserDefaultsNoCloudAccountNotification")]
		public extern NSString NoCloudAccountNotification { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSUbiquitousUserDefaultsDidChangeAccountsNotification")]
		public extern NSString DidChangeAccountsNotification { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Notification]
		[Field ("NSUbiquitousUserDefaultsCompletedInitialSyncNotification")]
		public extern NSString CompletedInitialSyncNotification { get; }

		[Notification]
		[Field ("NSUserDefaultsDidChangeNotification")]
		public extern NSString DidChangeNotification { get; }
	}
}
