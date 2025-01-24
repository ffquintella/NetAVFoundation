//
// Copyright 2010, Novell, Inc.
// Copyright 2011 - 2014 Xamarin Inc
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
using System;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using CoreLibs;

#if !COREBUILD
using System.Text;
using CoreFoundation;
using CoreGraphics;
#endif
using ObjCRuntime;

#if !NET
using NativeHandle = System.IntPtr;
#endif

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

#if COREBUILD
	[Protocol]
	public partial class INSCopying {}
	[Protocol]
	public partial class INSCoding {}
	[Protocol]
	public partial class INSSecureCoding {}
#endif

	public partial class NSString : NSValue, IComparable<NSString>
#if COREBUILD
		, INSCopying, INSSecureCoding
#endif
	 {
#if !COREBUILD
		const string selUTF8String = "UTF8String";
		const string selInitWithCharactersLength = "initWithCharacters:length:";

#if MONOMAC
		//static IntPtr selUTF8StringHandle = Selector.GetHandle (selUTF8String);
		//static IntPtr selInitWithCharactersLengthHandle = Selector.GetHandle (selInitWithCharactersLength);
#endif

		public static readonly NSString Empty = new NSString (String.Empty);

		public NSString (NativeHandle handle) : base (handle, false)
		{
		}
		
		internal NSString (NativeHandle handle, bool owns) : base (handle, owns)
		{
		}

		static NativeHandle CreateWithCharacters (NativeHandle classHandle, string str, int offset, int length, bool autorelease = false)
		{
			var chandle = Class.GetHandle(nameof(NSString));
			
			unsafe {
				fixed (char* ptrFirstChar = str) {
					var ptrStart = (IntPtr) (ptrFirstChar + offset);
#if MONOMAC
					var resHandle = Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr (chandle, Selector.GetHandle (selInitWithCharactersLength), ptrStart, (IntPtr) length);
					
					//Messaging.void_objc_msgSend_IntPtr_IntPtr (handle, selInitWithCharactersLengthHandle, ptrStart, (IntPtr) length);
#else
					var resHandle = Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr (classHandle, Selector.GetHandle (selInitWithCharactersLength), ptrStart, (IntPtr) length);
#endif

					if (autorelease)
						NSObject.DangerousAutorelease (resHandle);

					return resHandle;
				}
			}
		}

		[Obsolete ("Use of 'CFString.CreateNative' offers better performance.")]
		[EditorBrowsable (EditorBrowsableState.Never)]
		public static NativeHandle CreateNative (string str)
		{
			return CreateNative (str, false);
		}

		public static NativeHandle CreateNative (string str, bool autorelease)
		{
			if (str is null)
				return NativeHandle.Zero;

			return CreateNative (str, 0, str.Length, autorelease);
		}

		public static NativeHandle CreateNative (string value, int start, int length)
		{
			return CreateNative (value, start, length, false);
		}

		public static NativeHandle CreateNative (string value, int start, int length, bool autorelease)
		{
			if (value is null)
				return NativeHandle.Zero;

			if (start < 0 || start > value.Length)
				throw new ArgumentOutOfRangeException (nameof (start));

			if (length < 0 || start > value.Length - length)
				throw new ArgumentOutOfRangeException (nameof (length));

#if MONOMAC
			var handle = Messaging.IntPtr_objc_msgSend (class_ptr, Selector.AllocHandle);
#else
			var handle = Messaging.IntPtr_objc_msgSend (class_ptr, Selector.GetHandle (Selector.Alloc));
#endif

			return CreateWithCharacters (handle, value, start, length, autorelease);
		}

		public static void ReleaseNative (NativeHandle handle)
		{
			NSObject.DangerousRelease (handle);
		}

		
		public NSString (NSData data, NSStringEncoding encoding) 
		{
			if (data is null)
				throw new ArgumentNullException (nameof (data));

			string str = "";
			switch (encoding.GetHashCode())
			{
				case (int)NSStringEncoding.UTF8 :
					str = System.Text.UTF8Encoding.UTF8.GetString (data.ToArray ());
					break;
				case (int)NSStringEncoding.ASCIIStringEncoding :
					str = System.Text.ASCIIEncoding.ASCII.GetString (data.ToArray ());
					break;
			}
			
			Handle = CreateWithCharacters (ClassHandle, str, 0, str.Length);
		}
		public NSString (string str) : base()
		{
			if (str is null)
				throw new ArgumentNullException ("str");

			Handle = CreateWithCharacters (ClassHandle, str, 0, str.Length);
			
		}
		
		public NSString ()
		{
			//class_ptr = Class.GetHandle (nameof(NSString));
			var str = "";

			Handle = CreateWithCharacters (ClassHandle, str, 0, str.Length);
		}

		public NSString (string value, int start, int length)
		{
			if (value is null)
				throw new ArgumentNullException (nameof (value));

			if (start < 0 || start > value.Length)
				throw new ArgumentOutOfRangeException (nameof (start));

			if (length < 0 || start > value.Length - length)
				throw new ArgumentOutOfRangeException (nameof (length));

			Handle = CreateWithCharacters (Handle, value, start, length);
		}

		public override string ToString ()
		{
			return FromHandle (Handle);
		}

		public static implicit operator string (NSString str)
		{
			if (((object) str) is null)
				return null;
			return str.ToString ();
		}

		public static explicit operator NSString (string str)
		{
			if (str is null)
				return null;
			return new NSString (str);
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		[Obsolete ("Use of 'CFString.FromHandle' offers better performance.")]
		public static string FromHandle (NativeHandle usrhandle)
		{
			return FromHandle (usrhandle, false);
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		[Obsolete ("Use of 'CFString.FromHandle' offers better performance.")]
		public static string FromHandle (NativeHandle handle, bool owns)
		{
			if (handle == NativeHandle.Zero)
				return null;

			try {
#if MONOMAC
				return Marshal.PtrToStringAuto (Messaging.IntPtr_objc_msgSend (handle, selUTF8StringHandle));
#else
				return Marshal.PtrToStringAuto (Messaging.IntPtr_objc_msgSend (handle, Selector.GetHandle (selUTF8String)));
#endif
			} finally {
				if (owns)
					DangerousRelease (handle);
			}
		}

		public static bool Equals (NSString a, NSString b)
		{
			if ((a as object) == (b as object))
				return true;

			if (((object) a) is null || ((object) b) is null)
				return false;

			if (a.Handle == b.Handle)
				return true;
			return a.IsEqualTo (b);
		}

		public static bool operator == (NSString a, NSString b)
		{
			return Equals (a, b);
		}

		public static bool operator != (NSString a, NSString b)
		{
			return !Equals (a, b);
		}

		public override bool Equals (Object obj)
		{
			return Equals (this, obj as NSString);
		}

		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format (IntPtr fmt);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_1 (IntPtr fmt, IntPtr arg1);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_2 (IntPtr fmt, IntPtr arg1, IntPtr arg2);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_3 (IntPtr fmt, IntPtr arg1, IntPtr arg2, IntPtr arg3);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_4 (IntPtr fmt, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_5 (IntPtr fmt, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_6 (IntPtr fmt, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_7 (IntPtr fmt, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_8 (IntPtr fmt, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8);
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_localized_string_format_9 (IntPtr fmt, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9);

		public static NSString LocalizedFormat (string format, params object [] args)
		{
			using (var ns = new NSString (format))
				return LocalizedFormat (ns, args);
		}

		public static NSString LocalizedFormat (NSString format, params object [] args)
		{
			int argc = args.Length;
			var nso = new NSObject [argc];
			for (int i = 0; i < argc; i++)
				nso [i] = NSObject.FromObject (args [i]);

			return LocalizedFormat (format, nso);
		}

		public static NSString LocalizedFormat (NSString format, NSObject [] args)
		{
			switch (args.Length) {
			case 0:
				return new NSString (xamarin_localized_string_format (format.Handle));
			case 1:
				return new NSString (xamarin_localized_string_format_1 (format.Handle, args [0].Handle));
			case 2:
				return new NSString (xamarin_localized_string_format_2 (format.Handle, args [0].Handle, args [1].Handle));
			case 3:
				return new NSString (xamarin_localized_string_format_3 (format.Handle, args [0].Handle, args [1].Handle, args [2].Handle));
			case 4:
				return new NSString (xamarin_localized_string_format_4 (format.Handle, args [0].Handle, args [1].Handle, args [2].Handle, args [3].Handle));
			case 5:
				return new NSString (xamarin_localized_string_format_5 (format.Handle, args [0].Handle, args [1].Handle, args [2].Handle, args [3].Handle, args [4].Handle));
			case 6:
				return new NSString (xamarin_localized_string_format_6 (format.Handle, args [0].Handle, args [1].Handle, args [2].Handle, args [3].Handle, args [4].Handle, args [5].Handle));
			case 7:
				return new NSString (xamarin_localized_string_format_7 (format.Handle, args [0].Handle, args [1].Handle, args [2].Handle, args [3].Handle, args [4].Handle, args [5].Handle, args [6].Handle));
			case 8:
				return new NSString (xamarin_localized_string_format_8 (format.Handle, args [0].Handle, args [1].Handle, args [2].Handle, args [3].Handle, args [4].Handle, args [5].Handle, args [6].Handle, args [7].Handle));
			case 9:
				return new NSString (xamarin_localized_string_format_9 (format.Handle, args [0].Handle, args [1].Handle, args [2].Handle, args [3].Handle, args [4].Handle, args [5].Handle, args [6].Handle, args [7].Handle, args [8].Handle));
			default:
				throw new Exception ("Unsupported number of arguments, maximum number is 9");
			}
		}

		public NSString TransliterateString (NSStringTransform transform, bool reverse)
		{
			return TransliterateString (transform, reverse);
		}

		public override int GetHashCode ()
		{
			return Handle.GetHashCode();
			//return HashCode.Combine(this.ToString());
			//return base.GetHashCode ();
		}
#endif // !COREBUILD
	}
	
	[BaseType (typeof (NSObject)), Bind ("NSString")]
	//[DesignatedDefaultCtor]
	public partial class NSString : NSValue //, NSMutableCopying, CKRecordValue
#if MONOMAC
		//, NSPasteboardReading, NSPasteboardWriting // Documented that it implements NSPasteboard protocols even if header doesn't show it
#endif
		//, NSItemProviderReading, NSItemProviderWriting
		{
		[Export ("initWithData:encoding:")]
		public extern NativeHandle Constructor (NSData data, NSStringEncoding encoding);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Bind ("sizeWithAttributes:")]
		public extern CGSize StringSize ([NullAllowed] NSDictionary attributedStringAttributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Bind ("boundingRectWithSize:options:attributes:")]
		public extern CGRect BoundingRectWithSize (CGSize size, NSStringDrawingOptions options, NSDictionary attributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Bind ("drawAtPoint:withAttributes:")]
		public extern void DrawString (CGPoint point, NSDictionary attributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Bind ("drawInRect:withAttributes:")]
		public extern void DrawString (CGRect rect, NSDictionary attributes);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Bind ("drawWithRect:options:attributes:")]
		public extern void DrawString (CGRect rect, NSStringDrawingOptions options, NSDictionary attributes);

		[Internal]
		[Export ("characterAtIndex:")]
		public extern char _characterAtIndex (nint index);

		[Export ("length")]
		public extern nint Length { get; }

		[Sealed]
		[Export ("isEqualToString:")]
		extern bool IsEqualTo (IntPtr handle);

		[Export ("compare:")]
		public extern NSComparisonResult Compare (NSString aString);

		[Export ("compare:options:")]
		public extern NSComparisonResult Compare (NSString aString, NSStringCompareOptions mask);

		[Export ("compare:options:range:")]
		public extern NSComparisonResult Compare (NSString aString, NSStringCompareOptions mask, NSRange range);

		[Export ("compare:options:range:locale:")]
		public extern NSComparisonResult Compare (NSString aString, NSStringCompareOptions mask, NSRange range, [NullAllowed] NSLocale locale);

		[Export ("stringByReplacingCharactersInRange:withString:")]
		public extern NSString Replace (NSRange range, NSString replacement);

		[Export ("commonPrefixWithString:options:")]
		public extern NSString CommonPrefix (NSString aString, NSStringCompareOptions options);

		// start methods from NSStringPathExtensions category

		[Static]
		[Export ("pathWithComponents:")]
		public static extern string [] PathWithComponents (string [] components);

		[Export ("pathComponents")]
		public extern string [] PathComponents { get; }

		[Export ("isAbsolutePath")]
		public extern bool IsAbsolutePath { get; }

		[Export ("lastPathComponent")]
		public extern NSString LastPathComponent { get; }

		[Export ("stringByDeletingLastPathComponent")]
		public extern NSString DeleteLastPathComponent ();

		[Export ("stringByAppendingPathComponent:")]
		public extern NSString AppendPathComponent (NSString str);

		[Export ("pathExtension")]
		public extern NSString PathExtension { get; }

		[Export ("stringByDeletingPathExtension")]
		public extern NSString DeletePathExtension ();

		[Export ("stringByAppendingPathExtension:")]
		public extern NSString AppendPathExtension (NSString str);

		[Export ("stringByAbbreviatingWithTildeInPath")]
		public extern NSString AbbreviateTildeInPath ();

		[Export ("stringByExpandingTildeInPath")]
		public extern NSString ExpandTildeInPath ();

		[Export ("stringByStandardizingPath")]
		public extern NSString StandarizePath ();

		[Export ("stringByResolvingSymlinksInPath")]
		public extern NSString ResolveSymlinksInPath ();

		[Export ("stringsByAppendingPaths:")]
		public extern string [] AppendPaths (string [] paths);

		// end methods from NSStringPathExtensions category

		[Export ("capitalizedStringWithLocale:")]
		public extern string Capitalize ([NullAllowed] NSLocale locale);

		[Export ("lowercaseStringWithLocale:")]
		public extern string ToLower (NSLocale locale);

		[Export ("uppercaseStringWithLocale:")]
		public extern string ToUpper (NSLocale locale);

		[MacCatalyst (13, 1)]
		[Export ("containsString:")]
		public extern bool Contains (NSString str);

		[MacCatalyst (13, 1)]
		[Export ("localizedCaseInsensitiveContainsString:")]
		public extern bool LocalizedCaseInsensitiveContains (NSString str);

		[MacCatalyst (13, 1)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Static, Export ("stringEncodingForData:encodingOptions:convertedString:usedLossyConversion:")]
		public extern nuint DetectStringEncoding (NSData rawData, NSDictionary options, out string convertedString, out bool usedLossyConversion);

		[MacCatalyst (13, 1)]
		[Static, Wrap ("DetectStringEncoding(rawData,options.GetDictionary ()!, out convertedString, out usedLossyConversion)")]
		public extern nuint DetectStringEncoding (NSData rawData, EncodingDetectionOptions options, out string convertedString, out bool usedLossyConversion);

		[MacCatalyst (13, 1)]
		[Internal, Field ("NSStringEncodingDetectionSuggestedEncodingsKey")]
		public extern NSString EncodingDetectionSuggestedEncodingsKey { get; }

		[MacCatalyst (13, 1)]
		[Internal, Field ("NSStringEncodingDetectionDisallowedEncodingsKey")]
		public extern NSString EncodingDetectionDisallowedEncodingsKey { get; }

		[MacCatalyst (13, 1)]
		[Internal, Field ("NSStringEncodingDetectionUseOnlySuggestedEncodingsKey")]
		public extern NSString EncodingDetectionUseOnlySuggestedEncodingsKey { get; }

		[MacCatalyst (13, 1)]
		[Internal, Field ("NSStringEncodingDetectionAllowLossyKey")]
		public extern NSString EncodingDetectionAllowLossyKey { get; }

		[MacCatalyst (13, 1)]
		[Internal, Field ("NSStringEncodingDetectionFromWindowsKey")]
		public extern NSString EncodingDetectionFromWindowsKey { get; }

		[MacCatalyst (13, 1)]
		[Internal, Field ("NSStringEncodingDetectionLossySubstitutionKey")]
		public extern NSString EncodingDetectionLossySubstitutionKey { get; }

		[MacCatalyst (13, 1)]
		[Internal, Field ("NSStringEncodingDetectionLikelyLanguageKey")]
		public extern NSString EncodingDetectionLikelyLanguageKey { get; }

		[Export ("lineRangeForRange:")]
		public extern NSRange LineRangeForRange (NSRange range);

		[Export ("getLineStart:end:contentsEnd:forRange:")]
		public extern void GetLineStart (out nuint startPtr, out nuint lineEndPtr, out nuint contentsEndPtr, NSRange range);

		[MacCatalyst (13, 1)]
		[Export ("variantFittingPresentationWidth:")]
		public extern NSString GetVariantFittingPresentationWidth (nint width);

		[MacCatalyst (13, 1)]
		[Export ("localizedStandardContainsString:")]
		public extern bool LocalizedStandardContainsString (NSString str);

		[MacCatalyst (13, 1)]
		[Export ("localizedStandardRangeOfString:")]
		public extern NSRange LocalizedStandardRangeOfString (NSString str);

		[MacCatalyst (13, 1)]
		[Export ("localizedUppercaseString")]
		public extern NSString LocalizedUppercaseString { get; }

		[MacCatalyst (13, 1)]
		[Export ("localizedLowercaseString")]
		public extern NSString LocalizedLowercaseString { get; }

		[MacCatalyst (13, 1)]
		[Export ("localizedCapitalizedString")]
		public extern NSString LocalizedCapitalizedString { get; }

		[MacCatalyst (13, 1)]
		[Export ("stringByApplyingTransform:reverse:")]
		[return: NullAllowed]
		public extern NSString TransliterateString (NSString transform, bool reverse);

		[Export ("hasPrefix:")]
		public extern bool HasPrefix (NSString prefix);

		[Export ("hasSuffix:")]
		public extern bool HasSuffix (NSString suffix);

		// UNUserNotificationCenterSupport category
		[NoTV]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("localizedUserNotificationStringForKey:arguments:")]
		public static extern NSString GetLocalizedUserNotificationString (NSString key, [Params][NullAllowed] NSObject [] arguments);

		[Export ("getParagraphStart:end:contentsEnd:forRange:")]
		public extern void GetParagraphPositions (out nuint paragraphStartPosition, out nuint paragraphEndPosition, out nuint contentsEndPosition, NSRange range);

		[Export ("paragraphRangeForRange:")]
		public extern NSRange GetParagraphRange (NSRange range);

		[Export ("componentsSeparatedByString:")]
		public extern NSString [] SeparateComponents (NSString separator);

		[Export ("componentsSeparatedByCharactersInSet:")]
		public extern NSString [] SeparateComponents (NSCharacterSet separator);

		// From the NSItemProviderReading protocol

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("readableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
		public static extern new string [] ReadableTypeIdentifiers { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("objectWithItemProviderData:typeIdentifier:error:")]
		[return: NullAllowed]
		public static extern new NSString GetObject (NSData data, string typeIdentifier, [NullAllowed] out NSError outError);

		// From the NSItemProviderWriting protocol
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("writableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
		public static extern new string [] WritableTypeIdentifiers { get; }
	}
	
	[StrongDictionary ("NSString")]
	public partial interface EncodingDetectionOptions {
		NSStringEncoding [] EncodingDetectionSuggestedEncodings { get; set; }
		NSStringEncoding [] EncodingDetectionDisallowedEncodings { get; set; }
		bool EncodingDetectionUseOnlySuggestedEncodings { get; set; }
		bool EncodingDetectionAllowLossy { get; set; }
		bool EncodingDetectionFromWindows { get; set; }
		NSString EncodingDetectionLossySubstitution { get; set; }
		NSString EncodingDetectionLikelyLanguage { get; set; }
	}
	
}
