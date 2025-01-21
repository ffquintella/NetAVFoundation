//
// Copyright 2012, 2015 Xamarin Inc
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

#if !WATCH // __WATCHOS_PROHIBITED

using System;
using CoreLibs;
using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

	public unsafe partial class NSNetService {

		public virtual NSData TxtRecordData {
			get { return GetTxtRecordData (); }
			// ignore boolean return value
			set { SetTxtRecordData (value); }
		}
	}
	
	//[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use the Network.framework instead.")]
	//[Deprecated (PlatformName.iOS, 15, 0, message: "Use the Network.framework instead.")]
	//[Deprecated (PlatformName.TvOS, 15, 0, message: "Use the Network.framework instead.")]
	[NoWatch]
	[MacCatalyst (13, 1)]
	[Deprecated (PlatformName.MacCatalyst, 15, 0, message: "Use the Network.framework instead.")]
	[DisableDefaultCtor] // the instance just crash when trying to call selectors
	[BaseType (typeof (NSObject), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSNetServiceDelegate) })]
	partial class NSNetService {
		[DesignatedInitializer]
		[Export ("initWithDomain:type:name:port:")]
		public extern NativeHandle Constructor (string domain, string type, string name, int /* int, not NSInteger */ port);

		[Export ("initWithDomain:type:name:")]
		public extern NativeHandle Constructor (string domain, string type, string name);

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		extern INSNetServiceDelegate Delegate { get; set; }

#if NET
		[Export ("scheduleInRunLoop:forMode:")]
		public extern void Schedule (NSRunLoop aRunLoop, NSString forMode);

		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
		[Export ("removeFromRunLoop:forMode:")]
		public extern void Unschedule (NSRunLoop aRunLoop, NSString forMode);
#else
		[Export ("scheduleInRunLoop:forMode:")]
		void Schedule (NSRunLoop aRunLoop, string forMode);

		// For consistency with other APIs (NSUrlConnection) we call this Unschedule
		[Export ("removeFromRunLoop:forMode:")]
		void Unschedule (NSRunLoop aRunLoop, string forMode);
#endif
		[Wrap ("Schedule (aRunLoop, forMode.GetConstant ()!)")]
		public extern void Schedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);

		[Wrap ("Unschedule (aRunLoop, forMode.GetConstant ()!)")]
		public extern void Unschedule (NSRunLoop aRunLoop, NSRunLoopMode forMode);

		[Export ("domain", ArgumentSemantic.Copy)]
		public extern string Domain { get; }

		[Export ("type", ArgumentSemantic.Copy)]
		public extern string Type { get; }

		[Export ("name", ArgumentSemantic.Copy)]
		public extern string Name { get; }

		[NullAllowed]
		[Export ("addresses", ArgumentSemantic.Copy)]
		public extern NSData [] Addresses { get; }

		[Export ("port")]
		public extern nint Port { get; }

		[Export ("publish")]
		public extern void Publish ();

		[Export ("publishWithOptions:")]
		public extern void Publish (NSNetServiceOptions options);

		[Export ("resolve")]
		//[Deprecated (PlatformName.iOS, 2, 0, message: "Use 'Resolve (double)' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 4, message: "Use 'Resolve (double)' instead.")]
		[NoWatch]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'Resolve (double)' instead.")]
		public extern void Resolve ();

		[Export ("resolveWithTimeout:")]
		public extern void Resolve (double timeOut);

		[Export ("stop")]
		public extern void Stop ();

		[Static, Export ("dictionaryFromTXTRecordData:")]
		public extern NSDictionary DictionaryFromTxtRecord (NSData data);

		[Static, Export ("dataFromTXTRecordDictionary:")]
		public extern NSData DataFromTxtRecord (NSDictionary dictionary);

		[NullAllowed]
		[Export ("hostName", ArgumentSemantic.Copy)]
		public extern string HostName { get; }

		[Export ("getInputStream:outputStream:")]
		public extern bool GetStreams (out NSInputStream inputStream, out NSOutputStream outputStream);

		[return: NullAllowed]
		[Export ("TXTRecordData")]
		public extern NSData GetTxtRecordData ();

		[Export ("setTXTRecordData:")]
		public extern bool SetTxtRecordData ([NullAllowed] NSData data);

		//NSData TxtRecordData { get; set; }

		[Export ("startMonitoring")]
		public extern void StartMonitoring ();

		[Export ("stopMonitoring")]
		public extern void StopMonitoring ();

		[MacCatalyst (13, 1)]
		[Export ("includesPeerToPeer")]
		public extern bool IncludesPeerToPeer { get; set; }
	}

	partial class INSNetServiceDelegate { }

	[NoWatch]
	[MacCatalyst (13, 1)]
	[Model, BaseType (typeof (NSObject))]
	[Protocol]
	partial class NSNetServiceDelegate {
		[Export ("netServiceWillPublish:")]
		public extern void WillPublish (NSNetService sender);

		[Export ("netServiceDidPublish:")]
		public extern void Published (NSNetService sender);

		[Export ("netService:didNotPublish:"), EventArgs ("NSNetServiceError")]
		public extern void PublishFailure (NSNetService sender, NSDictionary errors);

		[Export ("netServiceWillResolve:")]
		public extern void WillResolve (NSNetService sender);

		[Export ("netServiceDidResolveAddress:")]
		public extern void AddressResolved (NSNetService sender);

		[Export ("netService:didNotResolve:"), EventArgs ("NSNetServiceError")]
		public extern void ResolveFailure (NSNetService sender, NSDictionary errors);

		[Export ("netServiceDidStop:")]
		public extern void Stopped (NSNetService sender);

		[Export ("netService:didUpdateTXTRecordData:"), EventArgs ("NSNetServiceData")]
		public extern void UpdatedTxtRecordData (NSNetService sender, NSData data);

		[Export ("netService:didAcceptConnectionWithInputStream:outputStream:"), EventArgs ("NSNetServiceConnection")]
		public extern void DidAcceptConnection (NSNetService sender, NSInputStream inputStream, NSOutputStream outputStream);
	}
}

#endif // !WATCH
