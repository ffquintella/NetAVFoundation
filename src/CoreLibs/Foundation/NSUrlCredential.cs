// Copyright 2013 Xamarin Inc.

using System;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;

using ObjCRuntime;
using Security;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

	public partial class NSUrlCredential {
		public NSUrlCredential (SecIdentity identity, SecCertificate [] certificates, NSUrlCredentialPersistence persistence)
			: this (identity.Handle, NSArray.FromNativeObjects (certificates).Handle, persistence)
		{
		}

		public NSUrlCredential(IntPtr identity, IntPtr certificates, NSUrlCredentialPersistence persistance)
		{
			Handle = Constructor(identity, certificates, persistance);
		}

		public static NSUrlCredential FromIdentityCertificatesPersistance (SecIdentity identity, SecCertificate [] certificates, NSUrlCredentialPersistence persistence)
		{
			if (identity is null)
				throw new ArgumentNullException ("identity");

			if (certificates is null)
				throw new ArgumentNullException ("certificates");

			using (var certs = NSArray.FromNativeObjects (certificates))
				return FromIdentityCertificatesPersistanceInternal (identity.Handle, certs.Handle, persistence);
		}

		public SecIdentity SecIdentity {
			get
			{
				throw new NotImplementedException();
				//IntPtr handle = Identity;
				//return (handle == IntPtr.Zero) ? null : new SecIdentity (handle, false);
			}
		}

		public static NSUrlCredential FromTrust (SecTrust trust)
		{
			if (trust is null)
				throw new ArgumentNullException ("trust");

			return FromTrust (trust.Handle);
		}
	}
	
	[BaseType (typeof (NSObject), Name = "NSURLCredential")]
	// crash when calling NSObjecg.get_Description (and likely other selectors)
	[DisableDefaultCtor]
	partial class NSUrlCredential : NSCopying {

		[Export ("initWithTrust:")]
		public extern NativeHandle Constructor (SecTrust trust);

		[Export ("persistence")]
		NSUrlCredentialPersistence Persistence { get; }

		[Export ("initWithUser:password:persistence:")]
		public extern NativeHandle Constructor (string user, string password, NSUrlCredentialPersistence persistence);

		[Static]
		[Export ("credentialWithUser:password:persistence:")]
		public extern NSUrlCredential FromUserPasswordPersistance (string user, string password, NSUrlCredentialPersistence persistence);

		[Export ("user")]
		public extern string User { get; }

		[Export ("password")]
		public extern string Password { get; }

		[Export ("hasPassword")]
		public extern bool HasPassword { get; }

		[Export ("initWithIdentity:certificates:persistence:")]
		[Internal]
		public extern NativeHandle Constructor (IntPtr identity, IntPtr certificates, NSUrlCredentialPersistence persistance);

		[Static]
		[Internal]
		[Export ("credentialWithIdentity:certificates:persistence:")]
		public static extern NSUrlCredential FromIdentityCertificatesPersistanceInternal (IntPtr identity, IntPtr certificates, NSUrlCredentialPersistence persistence);

		[Internal]
		[Export ("identity")]
		public extern IntPtr Identity { get; }

		[Export ("certificates")]
		public extern SecCertificate [] Certificates { get; }

		// bound manually to keep the managed/native signatures identical
		//[Export ("initWithTrust:")]
		//NativeHandle Constructor (IntPtr SecTrustRef_trust, bool ignored);

		[Internal]
		[Static]
		[Export ("credentialForTrust:")]
		public static extern NSUrlCredential FromTrust (IntPtr trust);
	}
}
