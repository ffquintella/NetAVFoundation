//
// NSUuid.cs: support code for the NSUUID binding
//
// Authors:
//    MIguel de Icaza (miguel@xamarin.com)
//
// Copyright 2012-2013 Xamarin Inc
//
using System;
using System.Runtime.InteropServices;
using CoreLibs;
using ObjCRuntime;

namespace Foundation {
	partial class NSUuid {

		public NSUuid (byte [] bytes) : base (NSObjectFlag.Empty)
		{
			if (bytes is null)
				throw new ArgumentNullException ("bytes");
			if (bytes.Length < 16)
				throw new ArgumentException ("length must be at least 16 bytes");

			unsafe {
				fixed (byte* p = bytes) {
					IntPtr ptr = (IntPtr) p;

					if (IsDirectBinding) {
						Handle = Messaging.IntPtr_objc_msgSend_IntPtr (this.Handle, Selector.GetHandle ("initWithUUIDBytes:"), ptr);
					} else {
						Handle = Messaging.IntPtr_objc_msgSendSuper_IntPtr (this.SuperHandle, Selector.GetHandle ("initWithUUIDBytes:"), ptr);
					}
				}
			}
		}

		public byte [] GetBytes ()
		{
			byte [] ret = new byte [16];

			unsafe {
				fixed (byte* buf = ret) {
					GetUuidBytes ((IntPtr) buf);
				}
			}

			return ret;
		}
	}
	
	[BaseType (typeof (NSObject), Name = "NSUUID")]
	//[DesignatedDefaultCtor]
	partial class NSUuid :  NSCopying {
		[Export ("initWithUUIDString:")]
		public extern NativeHandle Constructor (string str);

		// bound manually to keep the managed/native signatures identical
		//[Export ("initWithUUIDBytes:"), Internal]
		//NativeHandle Constructor (IntPtr bytes, bool unused);

		[Export ("getUUIDBytes:"), Internal]
		public extern void GetUuidBytes (IntPtr uuid);

		[Export ("UUIDString")]
		public extern string AsString ();

		//[Watch (8, 0), TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("compare:")]
		public extern NSComparisonResult Compare (NSUuid otherUuid);
	}
}
