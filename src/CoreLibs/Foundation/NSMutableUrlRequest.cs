using ObjCRuntime;

namespace Foundation {

	public partial class NSUrlRequest {
		public string this [string key] {
			get {
				return Header (key);
			}
		}
	}

	public partial class NSMutableUrlRequest: NSUrlRequest {
		public new string this [string key] {
			get {
				return Header (key);
			}

			set {
				_SetValue (value, key);
			}
		}
	}
	
	[BaseType (typeof (NSObject), Name = "NSURLRequest")]
	public partial class NSUrlRequest :  NSMutableCopying {
		[Export ("initWithURL:")]
		public extern NativeHandle Constructor (NSUrl url);

		[DesignatedInitializer]
		[Export ("initWithURL:cachePolicy:timeoutInterval:")]
		public extern NativeHandle Constructor (NSUrl url, NSUrlRequestCachePolicy cachePolicy, double timeoutInterval);

		[Export ("requestWithURL:")]
		[Static]
		public extern NSUrlRequest FromUrl (NSUrl url);

		[Export ("URL")]
		public extern NSUrl Url { get; }

		[Export ("cachePolicy")]
		public static extern NSUrlRequestCachePolicy CachePolicy { get; }

		[Export ("timeoutInterval")]
		public static extern double TimeoutInterval { get; }

		[Export ("mainDocumentURL")]
		public static extern NSUrl MainDocumentURL { get; }

		[Export ("networkServiceType")]
		public static extern NSUrlRequestNetworkServiceType NetworkServiceType { get; }

		[Export ("allowsCellularAccess")]
		public static extern bool AllowsCellularAccess { get; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("allowsExpensiveNetworkAccess")]
		public static extern bool AllowsExpensiveNetworkAccess { get; [NotImplemented] set; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("allowsConstrainedNetworkAccess")]
		public static extern bool AllowsConstrainedNetworkAccess { get; [NotImplemented] set; }

		[Export ("HTTPMethod")]
		public static extern string HttpMethod { get; }

		[Export ("allHTTPHeaderFields")]
		public static extern NSDictionary Headers { get; }

		[Internal]
		[Export ("valueForHTTPHeaderField:")]
		public static extern string Header (string field);

		[Export ("HTTPBody")]
		public static extern NSData Body { get; }

		[Export ("HTTPBodyStream")]
		public static extern NSInputStream BodyStream { get; }

		[Export ("HTTPShouldHandleCookies")]
		public static extern bool ShouldHandleCookies { get; }

		//[Watch (7, 4), TV (14, 5), iOS (14, 5)]
		[MacCatalyst (14, 5)]
		[Export ("assumesHTTP3Capable")]
		public static extern bool AssumesHttp3Capable { get; [NotImplemented] set; }

		//[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("attribution")]
		public static extern NSURLRequestAttribution Attribution { get; }

		// macOS is documented out of sync with iOS here
		//[Watch (9, 1), TV (16, 1), Mac (13, 0), iOS (16, 1)]
		[MacCatalyst (16, 1)]
		[Export ("requiresDNSSECValidation")]
		public static extern bool RequiresDnsSecValidation { get; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("allowsPersistentDNS")]
		public static extern bool AllowsPersistentDns { get; }

		//[TV (18, 2), iOS (18, 2), MacCatalyst (18, 2), Mac (15, 2)]
		[Export ("cookiePartitionIdentifier", ArgumentSemantic.Copy), NullAllowed]
		public static extern string CookiePartitionIdentifier { get; }
	}
	
	[BaseType (typeof (NSUrlRequest), Name = "NSMutableURLRequest")]
	partial class NSMutableUrlRequest {
		[Export ("initWithURL:")]
		public extern NativeHandle Constructor (NSUrl url);

		[Export ("initWithURL:cachePolicy:timeoutInterval:")]
		public extern NativeHandle Constructor (NSUrl url, NSUrlRequestCachePolicy cachePolicy, double timeoutInterval);

		[NullAllowed] // by default this property is null
		[New]
		[Export ("URL")]
		public extern NSUrl? Url { get; set; }

		[New]
		[Export ("cachePolicy")]
		public extern NSUrlRequestCachePolicy CachePolicy { get; set; }

		[New]
		[Export ("timeoutInterval")]
		public extern double TimeoutInterval { set; get; }

		[NullAllowed] // by default this property is null
		[New]
		[Export ("mainDocumentURL")]
		public extern NSUrl MainDocumentURL { get; set; }

		[New]
		[Export ("HTTPMethod")]
		public extern string HttpMethod { get; set; }

		[NullAllowed] // by default this property is null
		[New]
		[Export ("allHTTPHeaderFields")]
		public extern NSDictionary Headers { get; set; }

		[Internal]
		[Export ("setValue:forHTTPHeaderField:")]
		public extern void _SetValue (string value, string field);

		[NullAllowed] // by default this property is null
		[New]
		[Export ("HTTPBody")]
		public extern NSData Body { get; set; }

		[NullAllowed] // by default this property is null
		[New]
		[Export ("HTTPBodyStream")]
		public extern NSInputStream BodyStream { get; set; }

		[New]
		[Export ("HTTPShouldHandleCookies")]
		public extern bool ShouldHandleCookies { get; set; }

		[Export ("networkServiceType")]
		public extern NSUrlRequestNetworkServiceType NetworkServiceType { set; get; }

		[New]
		[Export ("allowsCellularAccess")]
		public extern bool AllowsCellularAccess { get; set; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("allowsExpensiveNetworkAccess")]
		public extern bool AllowsExpensiveNetworkAccess { get; set; }

		//[Watch (6, 0), TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("allowsConstrainedNetworkAccess")]
		public extern bool AllowsConstrainedNetworkAccess { get; set; }

		//[Watch (7, 4), TV (14, 5), iOS (14, 5)]
		[MacCatalyst (14, 5)]
		[Export ("assumesHTTP3Capable")]
		public extern bool AssumesHttp3Capable { get; set; }

		//[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("attribution", ArgumentSemantic.Assign)]
		public extern NSURLRequestAttribution Attribution { get; set; }

		// Documented as 16.0 but did not work until 16.1 - https://github.com/xamarin/maccore/issues/2608 - https://feedbackassistant.apple.com/feedback/10897552
		//[Watch (9, 1), TV (16, 1), Mac (13, 0), iOS (16, 1)]
		[MacCatalyst (16, 1)]
		[Export ("requiresDNSSECValidation")]
		public extern bool RequiresDnsSecValidation { get; set; }

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("allowsPersistentDNS")]
		public extern bool AllowsPersistentDns { get; set; }

		//[TV (18, 2), iOS (18, 2), MacCatalyst (18, 2), Mac (15, 2)]
		[Export ("cookiePartitionIdentifier", ArgumentSemantic.Copy), NullAllowed]
		public extern string CookiePartitionIdentifier { get; set; }
	}
}
