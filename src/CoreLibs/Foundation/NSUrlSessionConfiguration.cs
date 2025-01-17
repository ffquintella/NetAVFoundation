//
// NSUrlSessionHandlerConfiguration.cs:
//
// Authors:
//     Manuel de la Pena <mandel@microsoft.com>
using System;
using ObjCRuntime;
//using Network;

using Foundation;

namespace Foundation {

	public abstract class NSUrlSessionConfiguration: NSObject
	{
	}

	/*
	// the following was added to make the use of the configuration easier for the NUrlSessionHandler.
	// Apple APIs do not give an easy way to know the type of configuration that was created, this is an
	// issue when we want to interact with the cookie containers, since depending on the configuration type
	// the cookie container can be shared or not. This code should be transparent to the user, and is only used internaly.
	public partial class NSUrlSessionConfiguration {
		public enum SessionConfigurationType {
			Default,
			Background,
			Ephemeral,
		}

		public SessionConfigurationType SessionType { get; private set; } = SessionConfigurationType.Default;

		public static NSUrlSessionConfiguration DefaultSessionConfiguration {
			get {
				var config = NSUrlSessionConfiguration._DefaultSessionConfiguration;
				config.SessionType = SessionConfigurationType.Default;
				return config;
			}
		}

		public static NSUrlSessionConfiguration EphemeralSessionConfiguration {
			get {
				var config = NSUrlSessionConfiguration._EphemeralSessionConfiguration;
				config.SessionType = SessionConfigurationType.Ephemeral;
				return config;
			}
		}

#if NET
		[SupportedOSPlatform ("ios")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("maccatalyst")]
		[SupportedOSPlatform ("tvos")]
		[ObsoletedOSPlatform ("macos10.10", "Use 'CreateBackgroundSessionConfiguration' instead.")]
		[ObsoletedOSPlatform ("ios8.0", "Use 'CreateBackgroundSessionConfiguration' instead.")]
#else
		[Deprecated (PlatformName.iOS, 8, 0, message: "Use 'CreateBackgroundSessionConfiguration' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'CreateBackgroundSessionConfiguration' instead.")]
#endif
		public static NSUrlSessionConfiguration BackgroundSessionConfiguration (string identifier)
		{
			var config = NSUrlSessionConfiguration._BackgroundSessionConfiguration (identifier);
			config.SessionType = SessionConfigurationType.Background;
			return config;
		}

		public static NSUrlSessionConfiguration CreateBackgroundSessionConfiguration (string identifier)
		{
			var config = NSUrlSessionConfiguration._CreateBackgroundSessionConfiguration (identifier);
			config.SessionType = SessionConfigurationType.Background;
			return config;
		}

#if NET
		[SupportedOSPlatform ("ios17.0")]
		[SupportedOSPlatform ("macos14.0")]
		[SupportedOSPlatform ("maccatalyst17.0")]
		[SupportedOSPlatform ("tvos17.0")]
#else
		[TV (17, 0), Watch (10, 0), iOS (17, 0), Mac (14, 0), MacCatalyst (17, 0)]
#endif
		public NWProxyConfig [] ProxyConfigurations {
			get => NSArray.ArrayFromHandleFunc (_ProxyConfigurations, handle => new NWProxyConfig (handle, owns: false));
			set {
				var arr = NSArray.FromNSObjects (value);
				_ProxyConfigurations = arr.Handle;
				GC.KeepAlive (arr);
			}
		}

	}
	
	[MacCatalyst (13, 1)]
	   [BaseType (typeof (NSObject), Name = "NSURLSessionConfiguration")]
	   [DisableDefaultCtorAttribute]
	   partial class NSUrlSessionConfiguration : NSCopying {

	   	[Internal]
	   	[Static, Export ("defaultSessionConfiguration", ArgumentSemantic.Strong)]
	   	NSUrlSessionConfiguration _DefaultSessionConfiguration { get; }

	   	[Internal]
	   	[Static, Export ("ephemeralSessionConfiguration", ArgumentSemantic.Strong)]
	   	NSUrlSessionConfiguration _EphemeralSessionConfiguration { get; }

	   	[Internal]
	   	[Static, Export ("backgroundSessionConfiguration:")]
	   	NSUrlSessionConfiguration _BackgroundSessionConfiguration (string identifier);

	   	[Export ("identifier", ArgumentSemantic.Copy), NullAllowed]
	   	string Identifier { get; }

	   	[Export ("requestCachePolicy")]
	   	NSUrlRequestCachePolicy RequestCachePolicy { get; set; }

	   	[Export ("timeoutIntervalForRequest")]
	   	double TimeoutIntervalForRequest { get; set; }

	   	[Export ("timeoutIntervalForResource")]
	   	double TimeoutIntervalForResource { get; set; }

	   	[Export ("networkServiceType")]
	   	NSUrlRequestNetworkServiceType NetworkServiceType { get; set; }

	   	[Export ("allowsCellularAccess")]
	   	bool AllowsCellularAccess { get; set; }

	   	[Export ("discretionary")]
	   	bool Discretionary { [Bind ("isDiscretionary")] get; set; }

	   	[MacCatalyst (13, 1)]
	   	[Export ("sessionSendsLaunchEvents")]
	   	bool SessionSendsLaunchEvents { get; set; }

	   	[NullAllowed]
	   	[Export ("connectionProxyDictionary", ArgumentSemantic.Copy)]
	   	NSDictionary ConnectionProxyDictionary { get; set; }

	   	[NoWatch]
	   	[MacCatalyst (13, 1)]
	   	ProxyConfigurationDictionary StrongConnectionProxyDictionary {
	   		[Wrap ("new ProxyConfigurationDictionary (ConnectionProxyDictionary!)")]
	   		get;
	   		[Wrap ("ConnectionProxyDictionary = value.GetDictionary ()")]
	   		set;
	   	}
	
	*/
}
