//
// corefoundation.cs: Definitions for CoreFoundation
//
// Copyright 2014-2015 Xamarin Inc. All rights reserved.
//

using System;
using Foundation;
using ObjCRuntime;

namespace CoreFoundation {

	/// <summary>A class that allows for explicit allocation and de-allocation of memory.</summary>
	//[Partial]
	public partial class CFAllocator {

		[Internal]
		[Field ("kCFAllocatorDefault")]
		public static IntPtr default_ptr { get; }

		[Internal]
		[Field ("kCFAllocatorSystemDefault")]
		public static IntPtr system_default_ptr { get; }

		[Internal]
		[Field ("kCFAllocatorMalloc")]
		public static IntPtr malloc_ptr { get; }

		[Internal]
		[Field ("kCFAllocatorMallocZone")]
		public static IntPtr malloc_zone_ptr { get; }

		[Internal]
		[Field ("kCFAllocatorNull")]
		public static IntPtr null_ptr { get; }
	}

	[Partial]
	public partial class CFArray {

		[Internal]
		[Field ("kCFNull")]
		static IntPtr /* CFNullRef */ _CFNullHandle { get; }
	}

	[Partial]
	[Internal]
	public partial class CFBoolean {
		[Internal]
		[Field ("kCFBooleanTrue", "CoreFoundation")]
		public static IntPtr TrueHandle { get; }

		[Internal]
		[Field ("kCFBooleanFalse", "CoreFoundation")]
		public static IntPtr FalseHandle { get; }
	}

	/// <summary>Main loop implementation for Cocoa and CocoaTouch applications.</summary>
	///     <remarks>Run loops can be executed recursively.</remarks>
	[Partial]
	public partial class CFRunLoop {

		[Field ("kCFRunLoopDefaultMode")]
		public static NSString ModeDefault { get; }

		[Field ("kCFRunLoopCommonModes")]
		public static NSString ModeCommon { get; }
	}

	[Partial]
	public partial class DispatchData {
		[Internal]
		[Field ("_dispatch_data_destructor_free", "/usr/lib/system/libdispatch.dylib")]
		static IntPtr free { get; }
	}

#if !WATCH
	/// <summary>Provides the necessary methods needed for accessing the system's global proxy configuration settings and resolving a list of proxies to use for connecting to a URL.</summary>
	[Partial]
	public partial class CFNetwork {

		[Field ("kCFErrorDomainCFNetwork", "CFNetwork")]
		static NSString ErrorDomain { get; }
	}
#endif

	public enum CFStringTransform {
		[Field ("kCFStringTransformStripCombiningMarks")]
		StripCombiningMarks,

		[Field ("kCFStringTransformToLatin")]
		ToLatin,

		[Field ("kCFStringTransformFullwidthHalfwidth")]
		FullwidthHalfwidth,

		[Field ("kCFStringTransformLatinKatakana")]
		LatinKatakana,

		[Field ("kCFStringTransformLatinHiragana")]
		LatinHiragana,

		[Field ("kCFStringTransformHiraganaKatakana")]
		HiraganaKatakana,

		[Field ("kCFStringTransformMandarinLatin")]
		MandarinLatin,

		[Field ("kCFStringTransformLatinHangul")]
		LatinHangul,

		[Field ("kCFStringTransformLatinArabic")]
		LatinArabic,

		[Field ("kCFStringTransformLatinHebrew")]
		LatinHebrew,

		[Field ("kCFStringTransformLatinThai")]
		LatinThai,

		[Field ("kCFStringTransformLatinCyrillic")]
		LatinCyrillic,

		[Field ("kCFStringTransformLatinGreek")]
		LatinGreek,

		[Field ("kCFStringTransformToXMLHex")]
		ToXmlHex,

		[Field ("kCFStringTransformToUnicodeName")]
		ToUnicodeName,

		[Field ("kCFStringTransformStripDiacritics")]
		StripDiacritics,
	}

	[Introduced (PlatformName.MacCatalyst, 13, 0)]
	public enum OSLogLevel : byte {
		// These values must match the os_log_type_t enum in <os/log.h>.
		Default = 0x00,
		Info = 0x01,
		Debug = 0x02,
		Error = 0x10,
		Fault = 0x11,
	}
}
