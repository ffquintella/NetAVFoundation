//
// NSFileManager.cs:
// Author:
//   Miguel de Icaza
//
// Copyright 2011, Novell, Inc.
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
//
using CoreFoundation;
using ObjCRuntime;

using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using CoreLibs;

#nullable enable

namespace Foundation {

	// This is a convenience enum around a set of native strings.
	public enum NSFileType {
		Directory, Regular, SymbolicLink, Socket, CharacterSpecial, BlockSpecial, Unknown
	}

#if !MONOMAC
	public enum NSFileProtection {
		None,
		Complete,
		CompleteUnlessOpen,
		CompleteUntilFirstUserAuthentication,
	}
#endif

#if NET
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif
	public class NSFileAttributes: DictionaryContainer {
		public bool? AppendOnly { get; set; }
		public bool? Busy { get; set; }
		public bool? ExtensionHidden { get; set; }
		public NSDate? CreationDate { get; set; }
		public string? OwnerAccountName { get; set; }
		public string? GroupOwnerAccountName { get; set; }
		public nint? SystemNumber { get; set; } // NSInteger
		public nuint? DeviceIdentifier { get; set; } // unsigned long
		public nuint? GroupOwnerAccountID { get; set; } // unsigned long

		public bool? Immutable { get; set; }
		public NSDate? ModificationDate { get; set; }
		public nuint? OwnerAccountID { get; set; } // unsigned long
		public nuint? HfsCreatorCode { get; set; }
		public nuint? HfsTypeCode { get; set; } // unsigned long

		public short? PosixPermissions { get; set; }
		public nuint? ReferenceCount { get; set; } // unsigned long
		public nuint? SystemFileNumber { get; set; } // unsigned long
		public ulong? Size { get; set; } // unsigned long long
		public NSFileType? Type { get; set; }

#if !MONOMAC
		public NSFileProtection? ProtectionKey { get; set; }
#endif
		
		internal NSDictionary ToDictionary ()
		{
			NSFileType? type;
			NSString? v = null;
			var dict = new NSMutableDictionary ();
			if (AppendOnly.HasValue)
				dict.SetObject (NSNumber.FromBoolean (AppendOnly.Value), NSFileManager.AppendOnly);
			if (Busy.HasValue)
				dict.SetObject (NSNumber.FromBoolean (Busy.Value), NSFileManager.Busy);
			if (ExtensionHidden.HasValue)
				dict.SetObject (NSNumber.FromBoolean (ExtensionHidden.Value), NSFileManager.ExtensionHidden);
			if (CreationDate is not null)
				dict.SetObject (CreationDate, NSFileManager.CreationDate);
			if (OwnerAccountName is not null)
				dict.SetObject (new NSString (OwnerAccountName), NSFileManager.OwnerAccountName);
			if (GroupOwnerAccountName is not null)
				dict.SetObject (new NSString (GroupOwnerAccountName), NSFileManager.GroupOwnerAccountName);
			if (SystemNumber.HasValue)
				dict.SetObject (NSNumber.FromLong (SystemNumber.Value), NSFileManager.SystemNumber);
			if (DeviceIdentifier.HasValue)
				dict.SetObject (NSNumber.FromUnsignedLong (DeviceIdentifier.Value), NSFileManager.DeviceIdentifier);
			if (GroupOwnerAccountID.HasValue)
				dict.SetObject (NSNumber.FromUnsignedLong (GroupOwnerAccountID.Value), NSFileManager.GroupOwnerAccountID);
			if (Immutable.HasValue)
				dict.SetObject (NSNumber.FromBoolean (Immutable.Value), NSFileManager.Immutable);
			if (ModificationDate is not null)
				dict.SetObject (ModificationDate, NSFileManager.ModificationDate);
			if (OwnerAccountID.HasValue)
				dict.SetObject (NSNumber.FromUnsignedLong (OwnerAccountID.Value), NSFileManager.OwnerAccountID);
			if (HfsCreatorCode.HasValue)
				dict.SetObject (NSNumber.FromUnsignedLong (HfsCreatorCode.Value), NSFileManager.HfsCreatorCode);
			if (HfsTypeCode.HasValue)
				dict.SetObject (NSNumber.FromUnsignedLong (HfsTypeCode.Value), NSFileManager.HfsTypeCode);
			if (PosixPermissions.HasValue)
				dict.SetObject (NSNumber.FromInt16 ((short) PosixPermissions.Value), NSFileManager.PosixPermissions);
			if (ReferenceCount.HasValue)
				dict.SetObject (NSNumber.FromUnsignedLong (ReferenceCount.Value), NSFileManager.ReferenceCount);
			if (SystemFileNumber.HasValue)
				dict.SetObject (NSNumber.FromUnsignedLong (SystemFileNumber.Value), NSFileManager.SystemFileNumber);
			if (Size.HasValue)
				dict.SetObject (NSNumber.FromUInt64 (Size.Value), NSFileManager.Size);

			type = Type;

			if (type.HasValue) {
				v = null;
				switch (type.Value) {
				case NSFileType.Directory:
					v = NSFileManager.TypeDirectory; break;
				case NSFileType.Regular:
					v = NSFileManager.TypeRegular; break;
				case NSFileType.SymbolicLink:
					v = NSFileManager.TypeSymbolicLink; break;
				case NSFileType.Socket:
					v = NSFileManager.TypeSocket; break;
				case NSFileType.CharacterSpecial:
					v = NSFileManager.TypeCharacterSpecial; break;
				case NSFileType.BlockSpecial:
					v = NSFileManager.TypeBlockSpecial; break;
				default:
					v = NSFileManager.TypeUnknown; break;
				}
				dict.SetObject (v, NSFileManager.NSFileType);
			}

#if !MONOMAC
			if (ProtectionKey.HasValue) {
				v = null;
				switch (ProtectionKey.Value) {
				case NSFileProtection.None:
					v = NSFileManager.FileProtectionNone; break;
				case NSFileProtection.Complete:
					v = NSFileManager.FileProtectionComplete; break;
				case NSFileProtection.CompleteUnlessOpen:
					v = NSFileManager.FileProtectionCompleteUnlessOpen; break;
				case NSFileProtection.CompleteUntilFirstUserAuthentication:
					v = NSFileManager.FileProtectionCompleteUntilFirstUserAuthentication; break;
				}
				if (v is not null)
					dict.SetObject (v, NSFileManager.FileProtectionKey);
			}
#endif
			return dict;
		}

		#region fetch
		internal static bool? fetch_bool (NSDictionary dict, NSString key)
		{
			var k = dict.ObjectForKey (key) as NSNumber;
			if (k is null)
				return null;
			return k.BoolValue;
		}

		internal static uint? fetch_uint (NSDictionary dict, NSString key)
		{
			var k = dict.ObjectForKey (key) as NSNumber;
			if (k is null)
				return null;
			return k.UInt32Value;
		}

		internal static nuint? fetch_nuint (NSDictionary dict, NSString key)
		{
			var k = dict.ObjectForKey (key) as NSNumber;
			if (k is null)
				return null;
			return k.UnsignedLongValue;
		}

		internal static nint? fetch_nint (NSDictionary dict, NSString key)
		{
			var k = dict.ObjectForKey (key) as NSNumber;
			if (k is null)
				return null;
			return k.LongValue;
		}

		internal static ulong? fetch_ulong (NSDictionary dict, NSString key)
		{
			var k = dict.ObjectForKey (key) as NSNumber;
			if (k is null)
				return null;
			return k.UInt64Value;
		}

		internal static long? fetch_long (NSDictionary dict, NSString key)
		{
			var k = dict.ObjectForKey (key) as NSNumber;
			if (k is null)
				return null;
			return k.Int64Value;
		}

		internal static short? fetch_short (NSDictionary dict, NSString key)
		{
			var k = dict.ObjectForKey (key) as NSNumber;
			if (k is null)
				return null;
			return k.Int16Value;
		}
		#endregion

		public static NSFileAttributes? FromDictionary (NSDictionary dict)
		{
			if (dict is null)
				return null;
			var ret = new NSFileAttributes ();

			ret.AppendOnly = fetch_bool (dict, NSFileManager.AppendOnly);
			ret.Busy = fetch_bool (dict, NSFileManager.Busy);
			ret.ExtensionHidden = fetch_bool (dict, NSFileManager.ExtensionHidden);
			ret.CreationDate = dict.ObjectForKey (NSFileManager.CreationDate) as NSDate;
			ret.OwnerAccountName = dict.ObjectForKey (NSFileManager.OwnerAccountName) as NSString;
			ret.GroupOwnerAccountName = dict.ObjectForKey (NSFileManager.GroupOwnerAccountName) as NSString;
			ret.SystemNumber = fetch_nint (dict, NSFileManager.SystemNumber);
			ret.DeviceIdentifier = fetch_nuint (dict, NSFileManager.DeviceIdentifier);
			ret.GroupOwnerAccountID = fetch_nuint (dict, NSFileManager.GroupOwnerAccountID);
			ret.Immutable = fetch_bool (dict, NSFileManager.Immutable);
			ret.ModificationDate = dict.ObjectForKey (NSFileManager.ModificationDate) as NSDate;
			ret.OwnerAccountID = fetch_nuint (dict, NSFileManager.OwnerAccountID);
			ret.HfsCreatorCode = fetch_nuint (dict, NSFileManager.HfsCreatorCode);
			ret.HfsTypeCode = fetch_nuint (dict, NSFileManager.HfsTypeCode);
			ret.PosixPermissions = fetch_short (dict, NSFileManager.PosixPermissions);
			ret.ReferenceCount = fetch_nuint (dict, NSFileManager.ReferenceCount);
			ret.SystemFileNumber = fetch_nuint (dict, NSFileManager.SystemFileNumber);
			ret.Size = fetch_ulong (dict, NSFileManager.Size);

			var name = dict.ObjectForKey (NSFileManager.NSFileType) as NSString;
			if (name is not null) {
				NSFileType? type = null;

				if (name == NSFileManager.TypeDirectory)
					type = NSFileType.Directory;
				else if (name == NSFileManager.TypeRegular)
					type = NSFileType.Regular;
				else if (name == NSFileManager.TypeSymbolicLink)
					type = NSFileType.SymbolicLink;
				else if (name == NSFileManager.TypeSocket)
					type = NSFileType.Socket;
				else if (name == NSFileManager.TypeCharacterSpecial)
					type = NSFileType.CharacterSpecial;
				else if (name == NSFileManager.TypeBlockSpecial)
					type = NSFileType.BlockSpecial;
				else if (name == NSFileManager.TypeUnknown)
					type = NSFileType.Unknown;

				ret.Type = type;
			}

#if !MONOMAC
			name = dict.ObjectForKey (NSFileManager.FileProtectionKey) as NSString;
			if (name is not null) {
				NSFileProtection? protection = null;

				if (name == NSFileManager.FileProtectionNone)
					protection = NSFileProtection.None;
				else if (name == NSFileManager.FileProtectionComplete)
					protection = NSFileProtection.Complete;
				else if (name == NSFileManager.FileProtectionCompleteUnlessOpen)
					protection = NSFileProtection.CompleteUnlessOpen;
				else if (name == NSFileManager.FileProtectionCompleteUntilFirstUserAuthentication)
					protection = NSFileProtection.CompleteUntilFirstUserAuthentication;

				ret.ProtectionKey = protection;
			}
#endif
			return ret;
		}
	}

#if NET
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif
	public class NSFileSystemAttributes {
		NSDictionary dict;

		internal NSFileSystemAttributes (NSDictionary dict)
		{
			this.dict = dict;
		}

		// The documentation only says these are NSNumbers, it doesn't say which type of number.
		public ulong Size { get; internal set; }
		public ulong FreeSize { get; internal set; }
		public long Nodes { get; internal set; }
		public long FreeNodes { get; internal set; }
		// "The value corresponds to the value of st_dev, as returned by stat(2)" => st_dev is defined to be int32_t in all architectures.
		public uint Number { get; internal set; }

		internal static NSFileSystemAttributes? FromDictionary (NSDictionary dict)
		{
			if (dict is null)
				return null;
			var ret = new NSFileSystemAttributes (dict);
			ret.Size = NSFileAttributes.fetch_ulong (dict, NSFileManager.SystemSize) ?? 0;
			ret.FreeSize = NSFileAttributes.fetch_ulong (dict, NSFileManager.SystemFreeSize) ?? 0;
			ret.Nodes = NSFileAttributes.fetch_long (dict, NSFileManager.SystemNodes) ?? 0;
			ret.FreeNodes = NSFileAttributes.fetch_long (dict, NSFileManager.SystemFreeNodes) ?? 0;
			ret.Number = NSFileAttributes.fetch_uint (dict, NSFileManager.SystemFreeNodes) ?? 0;

			return ret;
		}

		// For source code compatibility with users that had done manual NSDictionary lookups before
		public static implicit operator NSDictionary (NSFileSystemAttributes attr)
		{
			return attr.dict;
		}

	}

	public partial class NSFileManager {

		[DllImport (Constants.FoundationLibrary)]
		static extern IntPtr NSUserName ();

		public static string? UserName {
			get {
				return CFString.FromHandle (NSUserName ());
			}
		}

		[DllImport (Constants.FoundationLibrary)]
		static extern IntPtr NSFullUserName ();

		public static string? FullUserName {
			get {
				return CFString.FromHandle (NSFullUserName ());
			}
		}

		[DllImport (Constants.FoundationLibrary)]
		static extern IntPtr NSHomeDirectory ();

		public static string? HomeDirectory {
			get {
				return CFString.FromHandle (NSHomeDirectory ());
			}
		}

		[DllImport (Constants.FoundationLibrary)]
		static extern IntPtr NSHomeDirectoryForUser (/* NSString */IntPtr userName);

		public static string? GetHomeDirectory (string userName)
		{
			if (userName is null)
				throw new ArgumentNullException (nameof (userName));

			var userNamePtr = CFString.CreateNative (userName);
			var rv = CFString.FromHandle (NSHomeDirectoryForUser (userNamePtr));
			CFString.ReleaseNative (userNamePtr);
			return rv;
		}

		[DllImport (Constants.FoundationLibrary)]
		static extern IntPtr NSTemporaryDirectory ();

		public static string? TemporaryDirectory {
			get {
				return CFString.FromHandle (NSTemporaryDirectory ());
			}
		}

		public bool SetAttributes (NSFileAttributes attributes, string path, out NSError error)
		{
			if (attributes is null)
				throw new ArgumentNullException (nameof (attributes));
			return SetAttributes (attributes.ToDictionary (), path, out error);
		}

		public bool SetAttributes (NSFileAttributes attributes, string path)
		{
			if (attributes is null)
				throw new ArgumentNullException (nameof (attributes));

			return SetAttributes (attributes.ToDictionary (), path, out _);
		}

		public bool CreateDirectory (string path, bool createIntermediates, NSFileAttributes? attributes, out NSError error)
		{
			return CreateDirectory (path, createIntermediates, attributes?.ToDictionary (), out error);
		}

		public bool CreateDirectory (string path, bool createIntermediates, NSFileAttributes? attributes)
		{
			return CreateDirectory (path, createIntermediates, attributes?.ToDictionary (), out var _);
		}

		public bool CreateFile (string path, NSData data, NSFileAttributes? attributes)
		{
			return CreateFile (path, data, attributes?.ToDictionary ());
		}

		public NSFileAttributes? GetAttributes (string path, out NSError error)
		{
			return NSFileAttributes.FromDictionary (_GetAttributes (path, out error));
		}

		public NSFileAttributes? GetAttributes (string path)
		{
			return NSFileAttributes.FromDictionary (_GetAttributes (path, out var _));
		}

		public NSFileSystemAttributes? GetFileSystemAttributes (string path)
		{
			return NSFileSystemAttributes.FromDictionary (_GetFileSystemAttributes (path, out var _));
		}

		public NSFileSystemAttributes? GetFileSystemAttributes (string path, out NSError error)
		{
			return NSFileSystemAttributes.FromDictionary (_GetFileSystemAttributes (path, out error));
		}

		public NSUrl [] GetMountedVolumes (NSString [] properties, NSVolumeEnumerationOptions options)
		{
			using var array = NSArray.FromNSObjects (properties);
			return GetMountedVolumes (array, options);
		}

		public string CurrentDirectory {
			get { return GetCurrentDirectory (); }
			// ignore boolean return value
			set { ChangeCurrentDirectory (value); }
		}

		public static NSError SetSkipBackupAttribute (string filename, bool skipBackup)
		{
			if (filename is null)
				throw new ArgumentNullException (nameof (filename));

			using (var url = NSUrl.FromFilename (filename)) {
				url.SetResource (NSUrl.IsExcludedFromBackupKey, (NSNumber) (skipBackup ? 1 : 0), out var error);
				return error;
			}
		}

		public static bool GetSkipBackupAttribute (string filename)
		{
			return GetSkipBackupAttribute (filename, out var _);
		}

		public static bool GetSkipBackupAttribute (string filename, out NSError error)
		{
			if (filename is null)
				throw new ArgumentNullException (nameof (filename));

			using (var url = NSUrl.FromFilename (filename)) {
				url.TryGetResource (NSUrl.IsExcludedFromBackupKey, out var value, out error);
				return (error is null) && ((long) ((NSNumber) value) == 1);
			}
		}
	}
	
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public interface NSWorkspaceAuthorization {
	}
	
	public partial class NSFileManager {

		[NoTV, NoWatch]
		[MacCatalyst (13, 1)]
		[Export ("trashItemAtURL:resultingItemURL:error:")]
		public extern bool TrashItem (NSUrl url, out NSUrl resultingItemUrl, out NSError error);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Static]
		[Export ("fileManagerWithAuthorization:")]
		public extern static NSFileManager FromAuthorization (NSWorkspaceAuthorization authorization);
	}
	
	[BaseType (typeof (NSObject))]
	public partial class NSFileManager: NSObject {
		[Field ("NSFileType")]
		public static extern NSString NSFileType { get; }

		[Field ("NSFileTypeDirectory")]
		public static extern NSString TypeDirectory { get; }

		[Field ("NSFileTypeRegular")]
		public static extern  NSString TypeRegular { get; }

		[Field ("NSFileTypeSymbolicLink")]
		public static extern NSString TypeSymbolicLink { get; }

		[Field ("NSFileTypeSocket")]
		public static extern NSString TypeSocket { get; }

		[Field ("NSFileTypeCharacterSpecial")]
		public static extern NSString TypeCharacterSpecial { get; }

		[Field ("NSFileTypeBlockSpecial")]
		public static extern NSString TypeBlockSpecial { get; }

		[Field ("NSFileTypeUnknown")]
		public static extern NSString TypeUnknown { get; }

		[Field ("NSFileSize")]
		public static extern NSString Size { get; }

		[Field ("NSFileModificationDate")]
		public static extern NSString ModificationDate { get; }

		[Field ("NSFileReferenceCount")]
		public static extern NSString ReferenceCount { get; }

		[Field ("NSFileDeviceIdentifier")]
		public static extern NSString DeviceIdentifier { get; }

		[Field ("NSFileOwnerAccountName")]
		public static extern NSString OwnerAccountName { get; }

		[Field ("NSFileGroupOwnerAccountName")]
		public static extern NSString GroupOwnerAccountName { get; }

		[Field ("NSFilePosixPermissions")]
		public static extern NSString PosixPermissions { get; }

		[Field ("NSFileSystemNumber")]
		public static extern NSString SystemNumber { get; }

		[Field ("NSFileSystemFileNumber")]
		public static extern NSString SystemFileNumber { get; }

		[Field ("NSFileExtensionHidden")]
		public static extern NSString ExtensionHidden { get; }

		[Field ("NSFileHFSCreatorCode")]
		public static extern NSString HfsCreatorCode { get; }

		[Field ("NSFileHFSTypeCode")]
		public static extern NSString HfsTypeCode { get; }

		[Field ("NSFileImmutable")]
		public static extern NSString Immutable { get; }

		[Field ("NSFileAppendOnly")]
		public static extern NSString AppendOnly { get; }

		[Field ("NSFileCreationDate")]
		public static extern NSString CreationDate { get; }

		[Field ("NSFileOwnerAccountID")]
		public static extern NSString OwnerAccountID { get; }

		[Field ("NSFileGroupOwnerAccountID")]
		public static extern NSString GroupOwnerAccountID { get; }

		[Field ("NSFileBusy")]
		public static extern NSString Busy { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSFileProtectionKey")]
		public static extern NSString FileProtectionKey { get; }

		[Obsolete ("Use the 'NSFileProtectionType' instead.")]
		[MacCatalyst (13, 1)]
		[Field ("NSFileProtectionNone")]
		public static extern NSString FileProtectionNone { get; }

		[Obsolete ("Use the 'NSFileProtectionType' instead.")]
		[MacCatalyst (13, 1)]
		[Field ("NSFileProtectionComplete")]
		public static extern NSString FileProtectionComplete { get; }

		[Obsolete ("Use the 'NSFileProtectionType' instead.")]
		[MacCatalyst (13, 1)]
		[Field ("NSFileProtectionCompleteUnlessOpen")]
		public static extern NSString FileProtectionCompleteUnlessOpen { get; }

		[Obsolete ("Use the 'NSFileProtectionType' instead.")]
		[MacCatalyst (13, 1)]
		[Field ("NSFileProtectionCompleteUntilFirstUserAuthentication")]
		public static extern NSString FileProtectionCompleteUntilFirstUserAuthentication { get; }

		[Field ("NSFileSystemSize")]
		public static extern NSString SystemSize { get; }

		[Field ("NSFileSystemFreeSize")]
		public static extern NSString SystemFreeSize { get; }

		[Field ("NSFileSystemNodes")]
		public static extern NSString SystemNodes { get; }

		[Field ("NSFileSystemFreeNodes")]
		public static extern NSString SystemFreeNodes { get; }

		[Static, Export ("defaultManager", ArgumentSemantic.Strong)]
		public static extern NSFileManager DefaultManager { get; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		public static extern NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		public static extern INSFileManagerDelegate Delegate { get; set; }

		[Export ("setAttributes:ofItemAtPath:error:")]
		public static extern bool SetAttributes (NSDictionary attributes, string path, out NSError error);

		[Export ("createDirectoryAtPath:withIntermediateDirectories:attributes:error:")]
		public static extern bool CreateDirectory (string path, bool createIntermediates, [NullAllowed] NSDictionary attributes, out NSError error);

		[Export ("contentsOfDirectoryAtPath:error:")]
		public extern string [] GetDirectoryContent (string path, out NSError error);

		[Export ("subpathsOfDirectoryAtPath:error:")]
		public extern string [] GetDirectoryContentRecursive (string path, out NSError error);

		[Export ("attributesOfItemAtPath:error:")]
		[Internal]
		internal extern NSDictionary _GetAttributes (string path, out NSError error);

		[Export ("attributesOfFileSystemForPath:error:")]
		[Internal]
		internal extern NSDictionary _GetFileSystemAttributes (String path, out NSError error);

		[Export ("createSymbolicLinkAtPath:withDestinationPath:error:")]
		public extern bool CreateSymbolicLink (string path, string destPath, out NSError error);

		[Export ("destinationOfSymbolicLinkAtPath:error:")]
		public extern string GetSymbolicLinkDestination (string path, out NSError error);

		[Export ("copyItemAtPath:toPath:error:")]
		public extern bool Copy (string srcPath, string dstPath, out NSError error);

		[Export ("moveItemAtPath:toPath:error:")]
		public extern bool Move (string srcPath, string dstPath, out NSError error);

		[Export ("linkItemAtPath:toPath:error:")]
		public extern bool Link (string srcPath, string dstPath, out NSError error);

		[Export ("removeItemAtPath:error:")]
		public extern bool Remove ([NullAllowed] string path, out NSError error);

#if DEPRECATED
		// These are not available on iOS, and deprecated on OSX.
		[Export ("linkPath:toPath:handler:")]
		public extern bool LinkPath (string src, string dest, IntPtr handler);

		[Export ("copyPath:toPath:handler:")]
		public extern bool CopyPath (string src, string dest, IntPtr handler);

		[Export ("movePath:toPath:handler:")]
		public extern bool MovePath (string src, string dest, IntPtr handler);

		[Export ("removeFileAtPath:handler:")]
		public extern bool RemoveFileAtPath (string path, IntPtr handler);
#endif
		[Export ("currentDirectoryPath")]
		public extern string GetCurrentDirectory ();

		[Export ("changeCurrentDirectoryPath:")]
		public extern bool ChangeCurrentDirectory (string path);

		[Export ("fileExistsAtPath:")]
		public extern bool FileExists (string path);

		[Export ("fileExistsAtPath:isDirectory:")]
		public extern bool FileExists (string path, ref bool isDirectory);

		[Export ("isReadableFileAtPath:")]
		public extern bool IsReadableFile (string path);

		[Export ("isWritableFileAtPath:")]
		public extern bool IsWritableFile (string path);

		[Export ("isExecutableFileAtPath:")]
		public extern bool IsExecutableFile (string path);

		[Export ("isDeletableFileAtPath:")]
		public extern bool IsDeletableFile (string path);

		[Export ("contentsEqualAtPath:andPath:")]
		public extern bool ContentsEqual (string path1, string path2);

		[Export ("displayNameAtPath:")]
		public extern string DisplayName (string path);

		[Export ("componentsToDisplayForPath:")]
		public extern string [] ComponentsToDisplay (string path);

		[Export ("enumeratorAtPath:")]
		public extern NSDirectoryEnumerator GetEnumerator (string path);

		[Export ("subpathsAtPath:")]
		public extern string [] Subpaths (string path);

		[Export ("contentsAtPath:")]
		public extern NSData Contents (string path);

		[Export ("createFileAtPath:contents:attributes:")]
		public extern bool CreateFile (string path, NSData data, [NullAllowed] NSDictionary attr);

		[Export ("contentsOfDirectoryAtURL:includingPropertiesForKeys:options:error:")]
		public extern NSUrl [] GetDirectoryContent (NSUrl url, [NullAllowed] NSArray properties, NSDirectoryEnumerationOptions options, out NSError error);

		[Export ("copyItemAtURL:toURL:error:")]
		public extern bool Copy (NSUrl srcUrl, NSUrl dstUrl, out NSError error);

		[Export ("moveItemAtURL:toURL:error:")]
		public extern bool Move (NSUrl srcUrl, NSUrl dstUrl, out NSError error);

		[Export ("linkItemAtURL:toURL:error:")]
		public extern bool Link (NSUrl srcUrl, NSUrl dstUrl, out NSError error);

		[Export ("removeItemAtURL:error:")]
		public extern bool Remove ([NullAllowed] NSUrl url, out NSError error);

		[Export ("enumeratorAtURL:includingPropertiesForKeys:options:errorHandler:")]
		public extern NSDirectoryEnumerator GetEnumerator (NSUrl url, [NullAllowed] NSString [] keys, NSDirectoryEnumerationOptions options, [NullAllowed] NSEnumerateErrorHandler handler);

		[Export ("URLForDirectory:inDomain:appropriateForURL:create:error:")]
		public extern NSUrl GetUrl (NSSearchPathDirectory directory, NSSearchPathDomain domain, [NullAllowed] NSUrl url, bool shouldCreate, out NSError error);

		[Export ("URLsForDirectory:inDomains:")]
		public extern NSUrl [] GetUrls (NSSearchPathDirectory directory, NSSearchPathDomain domains);

		[Export ("replaceItemAtURL:withItemAtURL:backupItemName:options:resultingItemURL:error:")]
		public extern bool Replace (NSUrl originalItem, NSUrl newItem, [NullAllowed] string backupItemName, NSFileManagerItemReplacementOptions options, out NSUrl resultingURL, out NSError error);

		[Export ("mountedVolumeURLsIncludingResourceValuesForKeys:options:")]
		public extern NSUrl [] GetMountedVolumes ([NullAllowed] NSArray properties, NSVolumeEnumerationOptions options);

		// Methods to convert paths to/from C strings for passing to system calls - Not implemented
		////- (const char *)fileSystemRepresentationWithPath:(NSString *)path;
		//[Export ("fileSystemRepresentationWithPath:")]
		//const char FileSystemRepresentationWithPath (string path);

		////- (NSString *)stringWithFileSystemRepresentation:(const char *)str length:(NSUInteger)len;
		//[Export ("stringWithFileSystemRepresentation:length:")]
		//string StringWithFileSystemRepresentation (const char str, uint len);

		[Export ("createDirectoryAtURL:withIntermediateDirectories:attributes:error:")]
		public extern bool CreateDirectory (NSUrl url, bool createIntermediates, [NullAllowed] NSDictionary attributes, out NSError error);

		[Export ("createSymbolicLinkAtURL:withDestinationURL:error:")]
		public extern bool CreateSymbolicLink (NSUrl url, NSUrl destURL, out NSError error);

		[Export ("setUbiquitous:itemAtURL:destinationURL:error:")]
		public extern bool SetUbiquitous (bool flag, NSUrl url, NSUrl destinationUrl, out NSError error);

		[Export ("isUbiquitousItemAtURL:")]
		public extern bool IsUbiquitous (NSUrl url);

		[Export ("startDownloadingUbiquitousItemAtURL:error:")]
		public extern bool StartDownloadingUbiquitous (NSUrl url, out NSError error);

		[Export ("evictUbiquitousItemAtURL:error:")]
		public extern bool EvictUbiquitous (NSUrl url, out NSError error);

		[Export ("URLForUbiquityContainerIdentifier:")]
		public extern NSUrl GetUrlForUbiquityContainer ([NullAllowed] string containerIdentifier);

		[Export ("URLForPublishingUbiquitousItemAtURL:expirationDate:error:")]
		public extern NSUrl GetUrlForPublishingUbiquitousItem (NSUrl url, out NSDate expirationDate, out NSError error);

		[Export ("ubiquityIdentityToken")]
		public extern NSObject UbiquityIdentityToken { get; }

		[Field ("NSUbiquityIdentityDidChangeNotification")]
		[Notification]
		public extern NSString UbiquityIdentityDidChangeNotification { get; }

		[Export ("containerURLForSecurityApplicationGroupIdentifier:")]
		public extern NSUrl GetContainerUrl (string securityApplicationGroupIdentifier);

		[MacCatalyst (13, 1)]
		[Export ("getRelationship:ofDirectory:inDomain:toItemAtURL:error:")]
		public extern bool GetRelationship (out NSUrlRelationship outRelationship, NSSearchPathDirectory directory, NSSearchPathDomain domain, NSUrl toItemAtUrl, out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("getRelationship:ofDirectoryAtURL:toItemAtURL:error:")]
		public extern bool GetRelationship (out NSUrlRelationship outRelationship, NSUrl directoryURL, NSUrl otherURL, out NSError error);

		[NoWatch]
		[NoTV]
		[NoiOS]
		[NoMacCatalyst]
		[Async]
		[Export ("unmountVolumeAtURL:options:completionHandler:")]
		public extern void UnmountVolume (NSUrl url, NSFileManagerUnmountOptions mask, Action<NSError> completionHandler);

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Async, Export ("getFileProviderServicesForItemAtURL:completionHandler:")]
		public extern void GetFileProviderServices (NSUrl url, Action<NSDictionary<NSString, NSFileProviderService>, NSError> completionHandler);
	}
	[NoWatch, NoTV]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public partial class NSFileProviderService : INativeObject
	{
		[Export ("name")]
		public extern string Name { get; }

		[Async]
		[Export ("getFileProviderConnectionWithCompletionHandler:")]
		public extern void GetFileProviderConnection (Action<NSXpcConnection, NSError> completionHandler);

		public NativeHandle Handle { get; }
	}

#if MONOMAC
	public partial class NSFilePresenter {
		[NoiOS][NoMacCatalyst][NoWatch][NoTV]
		[NullAllowed]
		[Export ("primaryPresentedItemURL")]
		public extern NSUrl PrimaryPresentedItemUrl { get; }
	}

	
#endif
}
