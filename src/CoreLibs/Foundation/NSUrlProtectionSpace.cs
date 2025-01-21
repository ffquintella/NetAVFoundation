// Copyright 2013 Xamarin Inc.

using System;
using CoreLibs;
using ObjCRuntime;
using Security;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

	public partial class NSUrlProtectionSpace {

		public NSUrlProtectionSpace (string host, int port, string protocol, string realm, string authenticationMethod)
			: base (NSObjectFlag.Empty)
		{
			Handle = Init (host, port, protocol, realm, authenticationMethod);
		}

		public NSUrlProtectionSpace (string host, int port, string protocol, string realm, string authenticationMethod, bool useProxy)
			: base (NSObjectFlag.Empty)
		{
			if (useProxy)
				Handle = InitWithProxy (host, port, protocol, realm, authenticationMethod);
			else
				Handle = Init (host, port, protocol, realm, authenticationMethod);
		}

		public SecTrust ServerSecTrust {
			get
			{
				throw new NotImplementedException();
				//IntPtr handle = ServerTrust;
				//return (handle == IntPtr.Zero) ? null : new SecTrust (handle, false);
			}
		}
	}
	
	[BaseType (typeof (NSObject), Name = "NSURLProtectionSpace")]
	// 'init' returns NIL
	//[DisableDefaultCtor]
	partial class NSUrlProtectionSpace : NSCopying {

		[Internal]
		[Export ("initWithHost:port:protocol:realm:authenticationMethod:")]
		public extern IntPtr Init (string host, nint port, [NullAllowed] string protocol, [NullAllowed] string realm, [NullAllowed] string authenticationMethod);

		[Internal]
		[Export ("initWithProxyHost:port:type:realm:authenticationMethod:")]
		public extern IntPtr InitWithProxy (string host, nint port, [NullAllowed] string type, [NullAllowed] string realm, [NullAllowed] string authenticationMethod);

		[Export ("realm")]
		public extern string Realm { get; }

		[Export ("receivesCredentialSecurely")]
		public extern bool ReceivesCredentialSecurely { get; }

		[Export ("isProxy")]
		public extern bool IsProxy { get; }

		[Export ("host")]
		public extern string Host { get; }

		[Export ("port")]
		public extern nint Port { get; }

		[Export ("proxyType")]
		public extern string ProxyType { get; }

		[Export ("protocol")]
		public extern string Protocol { get; }

		[Export ("authenticationMethod")]
		public extern string AuthenticationMethod { get; }

		// NSURLProtectionSpace(NSClientCertificateSpace)

		[Export ("distinguishedNames")]
		public extern NSData [] DistinguishedNames { get; }

		// NSURLProtectionSpace(NSServerTrustValidationSpace)
		[Internal]
		[Export ("serverTrust")]
		public extern IntPtr ServerTrust { get; }

		[Field ("NSURLProtectionSpaceHTTP")]
		public extern NSString HTTP { get; }

		[Field ("NSURLProtectionSpaceHTTPS")]
		public extern NSString HTTPS { get; }

		[Field ("NSURLProtectionSpaceFTP")]
		public extern NSString FTP { get; }

		[Field ("NSURLProtectionSpaceHTTPProxy")]
		public extern NSString HTTPProxy { get; }

		[Field ("NSURLProtectionSpaceHTTPSProxy")]
		public extern NSString HTTPSProxy { get; }

		[Field ("NSURLProtectionSpaceFTPProxy")]
		public extern NSString FTPProxy { get; }

		[Field ("NSURLProtectionSpaceSOCKSProxy")]
		public extern NSString SOCKSProxy { get; }

		[Field ("NSURLAuthenticationMethodDefault")]
		public extern NSString AuthenticationMethodDefault { get; }

		[Field ("NSURLAuthenticationMethodHTTPBasic")]
		public extern NSString AuthenticationMethodHTTPBasic { get; }

		[Field ("NSURLAuthenticationMethodHTTPDigest")]
		public extern NSString AuthenticationMethodHTTPDigest { get; }

		[Field ("NSURLAuthenticationMethodHTMLForm")]
		public extern NSString AuthenticationMethodHTMLForm { get; }

		[Field ("NSURLAuthenticationMethodNTLM")]
		public extern NSString AuthenticationMethodNTLM { get; }

		[Field ("NSURLAuthenticationMethodNegotiate")]
		public extern NSString AuthenticationMethodNegotiate { get; }

		[Field ("NSURLAuthenticationMethodClientCertificate")]
		public extern NSString AuthenticationMethodClientCertificate { get; }

		[Field ("NSURLAuthenticationMethodServerTrust")]
		public extern NSString AuthenticationMethodServerTrust { get; }
	}
}
