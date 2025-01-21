//
// Copyright 2010, Novell, Inc.
// Copyright 2011, 2012 Xamarin Inc
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
// Simple class for passing NSErrors as EventArgs
//
using System;
using System.Diagnostics;
using ObjCRuntime;
using System.Runtime.Versioning;
using CoreData;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

#if NET
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif
	public class NSErrorEventArgs : EventArgs {
		public NSErrorEventArgs (NSError error)
		{
			Error = error;
		}

		public NSError Error { get; private set; }
	}

	public partial class NSError : NSCopying {
#if !COREBUILD
		[Advice ("Always specify a domain and error code when creating an NSError instance")]
		public NSError () : this (new NSString ("Invalid .ctor used"), 0, null)
		{
			Debug.WriteLine ("Warning: you created an NSError without specifying a domain");
		}

		public NSError(NSString domain, nint code, NSDictionary? userInfo) 
		{
			if (domain == null)
				throw new ArgumentNullException (nameof (domain));
			Handle = FromDomain(domain, code, userInfo).Handle;
		}

		public static NSError FromDomain (NSString domain, nint code)
		{
			return FromDomain (domain, code, null);
		}

		public NSError (NSString domain, nint code) : this (domain, code, null)
		{
		}
		
		public NSError (NativeHandle handle, bool owns) : base (handle, owns)
		{
		}
		
		public NSError (NativeHandle handle) : base (handle, false)
		{
		}
		public override string ToString ()
		{
			return Description;
			//return LocalizedDescription;
		}

#if __IOS__ && !NET
		[Obsolete (Constants.WatchKitRemoved)]
		public static NSString WatchKitErrorDomain {
			get {
				throw new PlatformNotSupportedException (Constants.WatchKitRemoved);
			}
		}
#endif // __IOS__
#endif
	}
}
