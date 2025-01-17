// Copyright 2011-2014 Xamarin Inc
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
using AppKit;
using ObjCRuntime;

#nullable enable

namespace Foundation {

	// Equals(Object) and GetHashCode are provided by NSObject
	// NSObject.GetHashCode calls GetNativeHash, which means it matches Equals (NSUrl)' behavior (which also calls the native implementation), so there's no need to override it.
	// NSObject.Equals calls the native isEqual: implementation, so that's fine as well, and no need to override.
#pragma warning disable 660 // `Foundation.NSUrl' defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable 661 // `Foundation.NSUrl' defines operator == or operator != but does not override Object.GetHashCode()
	public partial class NSUrl : IEquatable<NSUrl> {

		public NSUrl (string path, string relativeToUrl)
			: this (path, new NSUrl (relativeToUrl))
		{
		}
		
		public NSUrl (string path, NSUrl parentUrl)
		{
			_internalUri = new Uri(parentUrl.ToString() + path);
			var obj = new NSObject();
		}
		
		public NSUrl (string path, bool directBinding = false)
		{
			_internalUri = new Uri(path);
			_isDirectBinding = directBinding;
		}
		
		
		private Uri _internalUri;
		private bool _isDirectBinding = false;
		public bool IsDirectBinding => _isDirectBinding;
		
		
		// but NSUrl has it's own isEqual: selector, which we re-expose in a more .NET-ish way
		public bool Equals (NSUrl? url)
		{
			if (url is null)
				return false;
			// we can only ask `isEqual:` to test equality if both objects are direct bindings
			return IsDirectBinding && url.IsDirectBinding ? IsEqual (url) : Equals ((object) url);
		}

		// Converts from an NSURL to a System.Uri
		public static implicit operator Uri? (NSUrl? url)
		{
			if (url?.AbsoluteString is not string absoluteUrl) {
				return null;
			}

			if (Uri.TryCreate (absoluteUrl, UriKind.Absolute, out var uri))
				return uri;
			else
				return new Uri (absoluteUrl, UriKind.Relative);
		}

		public static implicit operator NSUrl? (Uri? uri)
		{
			if (uri is null) {
				return null;
			}
			if (uri.IsAbsoluteUri)
				return new NSUrl (uri.AbsoluteUri);
			else
				return new NSUrl (uri.OriginalString);
		}

		public static NSUrl FromFilename (string url)
		{
			return new NSUrl (url, false);
		}

		public NSUrl MakeRelative (string url)
		{
			//throw new NotImplementedException("NsURL MakeRelative");
			return _FromStringRelative (url, this);
		}

		public override string ToString ()
		{
			//return AbsoluteString ?? base.ToString ();
			
			return AbsoluteString ?? "" ;
				
		}

		public bool TryGetResource (NSString nsUrlResourceKey, out NSObject value, out NSError error)
		{
			return GetResourceValue (out value, nsUrlResourceKey, out error);
		}

		public bool TryGetResource (NSString nsUrlResourceKey, out NSObject value)
		{
			NSError error;
			return GetResourceValue (out value, nsUrlResourceKey, out error);
		}

		public bool SetResource (NSString nsUrlResourceKey, NSObject value, out NSError error)
		{
			return SetResourceValue (value, nsUrlResourceKey, out error);
		}

		public bool SetResource (NSString nsUrlResourceKey, NSObject value)
		{
			NSError error;
			return SetResourceValue (value, nsUrlResourceKey, out error);
		}

		public int Port {
			get {
				return (int) (this.PortNumber ?? -1);
			}
		}
		

		public static bool operator == (NSUrl? x, NSUrl? y)
		{
			if ((object?) x == (object?) y) // If both are null, or both are same instance, return true.
				return true;

			if (x is null || y is null) // If one is null, but not both, return false.
				return false;

			return x.Equals (y);
		}

		public static bool operator != (NSUrl? x, NSUrl? y)
		{
			return !(x == y);
		}
	}
	
	[BaseType (typeof (NSObject), Name = "NSURL")]
	// init returns NIL
	//[DisableDefaultCtor]
	public partial class NSUrl :  NSCopying
#if MONOMAC
	//, NSPasteboardReading, NSPasteboardWriting
#endif
	//, NSItemProviderWriting, NSItemProviderReading
#if IOS || MONOMAC
	//, QLPreviewItem
#endif
	{
		[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'NSUrlComponents' instead.")]
		[Deprecated (PlatformName.WatchOS, 2, 0, message: "Use 'NSUrlComponents' instead.")]
		[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'NSUrlComponents' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSUrlComponents' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSUrlComponents' instead.")]
		[Export ("initWithScheme:host:path:")]
		public extern NativeHandle Constructor (string scheme, string host, string path);

		[DesignatedInitializer]
		[Export ("initFileURLWithPath:isDirectory:")]
		public extern NativeHandle Constructor (string path, bool isDir);

		[Export ("initWithString:")]
		public extern NativeHandle Constructor (string urlString);

		[DesignatedInitializer]
		[Export ("initWithString:relativeToURL:")]
		public extern NativeHandle Constructor (string urlString, NSUrl relativeToUrl);

		[return: NullAllowed]
		[Export ("URLWithString:")]
		[Static]
		public extern NSUrl FromString ([NullAllowed] string s);

		[Export ("URLWithString:relativeToURL:")]
		[Internal]
		[Static]
		public extern NSUrl _FromStringRelative (string url, NSUrl relative);

		//[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Static]
		[Export ("URLWithString:encodingInvalidCharacters:")]
		[return: NullAllowed]
		public extern NSUrl FromString (string url, bool encodingInvalidCharacters);

		[Export ("absoluteString")]
		[NullAllowed]
		public  extern string? AbsoluteString { get; }

		[Export ("absoluteURL")]
		[NullAllowed]
		public  extern NSUrl? AbsoluteUrl { get; }

		[Export ("baseURL")]
		[NullAllowed]
		public  extern NSUrl? BaseUrl { get; }

		[Export ("fragment")]
		[NullAllowed]
		public  extern string? Fragment { get; }

		[Export ("host")]
		[NullAllowed]
		public  extern string? Host { get; }

		[Internal]
		[Export ("isEqual:")]
		internal  extern bool IsEqual ([NullAllowed] NSUrl other);

		[Export ("isFileURL")]
		public  extern bool IsFileUrl { get; }

		[Export ("isFileReferenceURL")]
		public  extern bool IsFileReferenceUrl { get; }

		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Always return 'null'. Use and parse 'Path' instead.")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Always return 'null'. Use and parse 'Path' instead.")]
		[Deprecated (PlatformName.WatchOS, 6, 0, message: "Always return 'null'. Use and parse 'Path' instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Always return 'null'. Use and parse 'Path' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Always return 'null'. Use and parse 'Path' instead.")]
		[Export ("parameterString")]
		[NullAllowed]
		public  extern string? ParameterString { get; }

		[Export ("password")]
		[NullAllowed]
		public static extern string Password { get; }

		[Export ("path")]
		[NullAllowed]
		public static extern string Path { get; }

		[Export ("query")]
		[NullAllowed]
		public static extern string Query { get; }

		[Export ("relativePath")]
		[NullAllowed]
		public static extern string RelativePath { get; }

		[Export ("pathComponents")]
		[NullAllowed]
		public static extern string [] PathComponents { get; }

		[Export ("lastPathComponent")]
		[NullAllowed]
		public static extern string LastPathComponent { get; }

		[Export ("pathExtension")]
		[NullAllowed]
		public static extern string PathExtension { get; }

		[Export ("relativeString")]
		public static extern string RelativeString { get; }

		[Export ("resourceSpecifier")]
		[NullAllowed]
		public static extern string ResourceSpecifier { get; }

		[Export ("scheme")]
		[NullAllowed]
		public static extern string Scheme { get; }

		[Export ("user")]
		[NullAllowed]
		public static extern string User { get; }

		[Export ("standardizedURL")]
		[NullAllowed]
		public static extern NSUrl StandardizedUrl { get; }

		[Export ("URLByAppendingPathComponent:isDirectory:")]
		public extern NSUrl Append (string pathComponent, bool isDirectory);

		[Export ("URLByAppendingPathExtension:")]
		public extern NSUrl AppendPathExtension (string extension);

		[Export ("URLByDeletingLastPathComponent")]
		public extern NSUrl RemoveLastPathComponent ();

		[Export ("URLByDeletingPathExtension")]
		public extern NSUrl RemovePathExtension ();

		[MacCatalyst (13, 1)]
		[Export ("getFileSystemRepresentation:maxLength:")]
		public extern bool GetFileSystemRepresentation (IntPtr buffer, nint maxBufferLength);

		[MacCatalyst (13, 1)]
		[Export ("fileSystemRepresentation")]
		public extern IntPtr GetFileSystemRepresentationAsUtf8Ptr { get; }

		[MacCatalyst (13, 1)]
		[Export ("removeCachedResourceValueForKey:")]
		public extern void RemoveCachedResourceValueForKey (NSString key);

		[MacCatalyst (13, 1)]
		[Export ("removeAllCachedResourceValues")]
		public extern void RemoveAllCachedResourceValues ();

		[MacCatalyst (13, 1)]
		[Export ("setTemporaryResourceValue:forKey:")]
		public extern void SetTemporaryResourceValue (NSObject value, NSString key);

		[DesignatedInitializer]
		[MacCatalyst (13, 1)]
		[Export ("initFileURLWithFileSystemRepresentation:isDirectory:relativeToURL:")]
		public extern NativeHandle Constructor (IntPtr ptrUtf8path, bool isDir, [NullAllowed] NSUrl baseURL);

		[Static, Export ("fileURLWithFileSystemRepresentation:isDirectory:relativeToURL:")]
		[MacCatalyst (13, 1)]
		public extern NSUrl FromUTF8Pointer (IntPtr ptrUtf8path, bool isDir, [NullAllowed] NSUrl baseURL);

		/* These methods come from NURL_AppKitAdditions */
		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("URLFromPasteboard:")]
		[Static]
		[return: NullAllowed]
		public extern NSUrl FromPasteboard (NSPasteboard pasteboard);

		[NoiOS]
		[NoMacCatalyst]
		[NoWatch]
		[NoTV]
		[Export ("writeToPasteboard:")]
		public extern void WriteToPasteboard (NSPasteboard pasteboard);

		[Export ("bookmarkDataWithContentsOfURL:error:")]
		[Static]
		public extern NSData GetBookmarkData (NSUrl bookmarkFileUrl, out NSError error);

		[Export ("URLByResolvingBookmarkData:options:relativeToURL:bookmarkDataIsStale:error:")]
		[Static]
		public extern NSUrl FromBookmarkData (NSData data, NSUrlBookmarkResolutionOptions options, [NullAllowed] NSUrl relativeToUrl, out bool isStale, out NSError error);

		[Export ("writeBookmarkData:toURL:options:error:")]
		[Static]
		public extern bool WriteBookmarkData (NSData data, NSUrl bookmarkFileUrl, NSUrlBookmarkCreationOptions options, out NSError error);

		[Export ("filePathURL")]
		[NullAllowed]
		public extern NSUrl FilePathUrl { get; }

		[Export ("fileReferenceURL")]
		[NullAllowed]
		public extern NSUrl FileReferenceUrl { get; }

		[Export ("getResourceValue:forKey:error:"), Internal]
		public extern bool GetResourceValue (out NSObject value, NSString key, out NSError error);

		[Export ("resourceValuesForKeys:error:")]
		public extern NSDictionary GetResourceValues (NSString [] keys, out NSError error);

		[Export ("setResourceValue:forKey:error:"), Internal]
		public extern bool SetResourceValue (NSObject value, NSString key, out NSError error);

		[Export ("port"), Internal]
		[NullAllowed]
		public extern NSNumber PortNumber { get; }

		[Field ("NSURLNameKey")]
		public  extern NSString NameKey { get; }

		[Field ("NSURLLocalizedNameKey")]
		public  extern NSString LocalizedNameKey { get; }

		[Field ("NSURLIsRegularFileKey")]
		public  extern NSString IsRegularFileKey { get; }

		[Field ("NSURLIsDirectoryKey")]
		public  extern NSString IsDirectoryKey { get; }

		[Field ("NSURLIsSymbolicLinkKey")]
		public  extern NSString IsSymbolicLinkKey { get; }

		[Field ("NSURLIsVolumeKey")]
		public  extern NSString IsVolumeKey { get; }

		[Field ("NSURLIsPackageKey")]
		public  extern NSString IsPackageKey { get; }

		[Field ("NSURLIsSystemImmutableKey")]
		public  extern NSString IsSystemImmutableKey { get; }

		[Field ("NSURLIsUserImmutableKey")]
		public  extern NSString IsUserImmutableKey { get; }

		[Field ("NSURLIsHiddenKey")]
		public  extern NSString IsHiddenKey { get; }

		[Field ("NSURLHasHiddenExtensionKey")]
		public  extern NSString HasHiddenExtensionKey { get; }

		[Field ("NSURLCreationDateKey")]
		public  extern NSString CreationDateKey { get; }

		[Field ("NSURLContentAccessDateKey")]
		public  extern NSString ContentAccessDateKey { get; }

		[Field ("NSURLContentModificationDateKey")]
		public  extern NSString ContentModificationDateKey { get; }

		[Field ("NSURLAttributeModificationDateKey")]
		public  extern NSString AttributeModificationDateKey { get; }

		[Field ("NSURLLinkCountKey")]
		public  extern NSString LinkCountKey { get; }

		[Field ("NSURLParentDirectoryURLKey")]
		public  extern NSString ParentDirectoryURLKey { get; }

		[Field ("NSURLVolumeURLKey")]
		public  extern NSString VolumeURLKey { get; }

		[Deprecated (PlatformName.iOS, 14, 0, message: "Use 'ContentTypeKey' instead.")]
		[Deprecated (PlatformName.TvOS, 14, 0, message: "Use 'ContentTypeKey' instead.")]
		[Deprecated (PlatformName.WatchOS, 7, 0, message: "Use 'ContentTypeKey' instead.")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'ContentTypeKey' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 14, 0, message: "Use 'ContentTypeKey' instead.")]
		[Field ("NSURLTypeIdentifierKey")]
		public  extern NSString TypeIdentifierKey { get; }

		[Field ("NSURLLocalizedTypeDescriptionKey")]
		public  extern NSString LocalizedTypeDescriptionKey { get; }

		[Field ("NSURLLabelNumberKey")]
		public  extern NSString LabelNumberKey { get; }

		[Field ("NSURLLabelColorKey")]
		public  extern NSString LabelColorKey { get; }

		[Field ("NSURLLocalizedLabelKey")]
		public  extern NSString LocalizedLabelKey { get; }

		[Field ("NSURLEffectiveIconKey")]
		public  extern NSString EffectiveIconKey { get; }

		[Field ("NSURLCustomIconKey")]
		public  extern NSString CustomIconKey { get; }

		[Field ("NSURLFileSizeKey")]
		public  extern NSString FileSizeKey { get; }

		[Field ("NSURLFileAllocatedSizeKey")]
		public  extern NSString FileAllocatedSizeKey { get; }

		[Field ("NSURLIsAliasFileKey")]
		public  extern NSString IsAliasFileKey { get; }

		[Field ("NSURLVolumeLocalizedFormatDescriptionKey")]
		public  extern NSString VolumeLocalizedFormatDescriptionKey { get; }

		[Field ("NSURLVolumeTotalCapacityKey")]
		public  extern NSString VolumeTotalCapacityKey { get; }

		[Field ("NSURLVolumeAvailableCapacityKey")]
		public  extern NSString VolumeAvailableCapacityKey { get; }

		[Field ("NSURLVolumeResourceCountKey")]
		public  extern NSString VolumeResourceCountKey { get; }

		[Field ("NSURLVolumeSupportsPersistentIDsKey")]
		public  extern NSString VolumeSupportsPersistentIDsKey { get; }

		[Field ("NSURLVolumeSupportsSymbolicLinksKey")]
		public  extern NSString VolumeSupportsSymbolicLinksKey { get; }

		[Field ("NSURLVolumeSupportsHardLinksKey")]
		public  extern NSString VolumeSupportsHardLinksKey { get; }

		[Field ("NSURLVolumeSupportsJournalingKey")]
		public static extern NSString VolumeSupportsJournalingKey { get; }

		[Field ("NSURLVolumeIsJournalingKey")]
		public  extern NSString VolumeIsJournalingKey { get; }

		[Field ("NSURLVolumeSupportsSparseFilesKey")]
		public  extern NSString VolumeSupportsSparseFilesKey { get; }

		[Field ("NSURLVolumeSupportsZeroRunsKey")]
		public  extern NSString VolumeSupportsZeroRunsKey { get; }

		[Field ("NSURLVolumeSupportsCaseSensitiveNamesKey")]
		public  extern NSString VolumeSupportsCaseSensitiveNamesKey { get; }

		[Field ("NSURLVolumeSupportsCasePreservedNamesKey")]
		public  extern NSString VolumeSupportsCasePreservedNamesKey { get; }

		// 5.0 Additions
		[Field ("NSURLKeysOfUnsetValuesKey")]
		public  extern NSString KeysOfUnsetValuesKey { get; }

		[Field ("NSURLFileResourceIdentifierKey")]
		public  extern NSString FileResourceIdentifierKey { get; }

		[Field ("NSURLVolumeIdentifierKey")]
		public  extern NSString VolumeIdentifierKey { get; }

		[Field ("NSURLPreferredIOBlockSizeKey")]
		public  extern NSString PreferredIOBlockSizeKey { get; }

		[Field ("NSURLIsReadableKey")]
		public  extern NSString IsReadableKey { get; }

		[Field ("NSURLIsWritableKey")]
		public  extern NSString IsWritableKey { get; }

		[Field ("NSURLIsExecutableKey")]
		public  extern NSString IsExecutableKey { get; }

		[Field ("NSURLIsMountTriggerKey")]
		public  extern NSString IsMountTriggerKey { get; }

		[Field ("NSURLFileSecurityKey")]
		public  extern NSString FileSecurityKey { get; }

		[Field ("NSURLFileResourceTypeKey")]
		public  extern NSString FileResourceTypeKey { get; }

		//[Watch (9, 4), TV (16, 4), Mac (13, 3), iOS (16, 4)]
		[MacCatalyst (16, 4)]
		[Field ("NSURLFileIdentifierKey")]
		public  extern NSString FileIdentifierKey { get; }

		[Field ("NSURLFileResourceTypeNamedPipe")]
		public  extern NSString FileResourceTypeNamedPipe { get; }

		[Field ("NSURLFileResourceTypeCharacterSpecial")]
		public  extern NSString FileResourceTypeCharacterSpecial { get; }

		[Field ("NSURLFileResourceTypeDirectory")]
		public  extern NSString FileResourceTypeDirectory { get; }

		[Field ("NSURLFileResourceTypeBlockSpecial")]
		public  extern NSString FileResourceTypeBlockSpecial { get; }

		[Field ("NSURLFileResourceTypeRegular")]
		public  extern NSString FileResourceTypeRegular { get; }

		[Field ("NSURLFileResourceTypeSymbolicLink")]
		public  extern NSString FileResourceTypeSymbolicLink { get; }

		[Field ("NSURLFileResourceTypeSocket")]
		public  extern NSString FileResourceTypeSocket { get; }

		[Field ("NSURLFileResourceTypeUnknown")]
		public  extern NSString FileResourceTypeUnknown { get; }

		[Field ("NSURLTotalFileSizeKey")]
		public  extern NSString TotalFileSizeKey { get; }

		[Field ("NSURLTotalFileAllocatedSizeKey")]
		public  extern NSString TotalFileAllocatedSizeKey { get; }

		[Field ("NSURLVolumeSupportsRootDirectoryDatesKey")]
		public  extern NSString VolumeSupportsRootDirectoryDatesKey { get; }

		[Field ("NSURLVolumeSupportsVolumeSizesKey")]
		public  extern NSString VolumeSupportsVolumeSizesKey { get; }

		[Field ("NSURLVolumeSupportsRenamingKey")]
		public  extern NSString VolumeSupportsRenamingKey { get; }

		[Field ("NSURLVolumeSupportsAdvisoryFileLockingKey")]
		public  extern NSString VolumeSupportsAdvisoryFileLockingKey { get; }

		[Field ("NSURLVolumeSupportsExtendedSecurityKey")]
		public  extern NSString VolumeSupportsExtendedSecurityKey { get; }

		[Field ("NSURLVolumeIsBrowsableKey")]
		public  extern NSString VolumeIsBrowsableKey { get; }

		[Field ("NSURLVolumeMaximumFileSizeKey")]
		public  extern NSString VolumeMaximumFileSizeKey { get; }

		[Field ("NSURLVolumeIsEjectableKey")]
		public  extern NSString VolumeIsEjectableKey { get; }

		[Field ("NSURLVolumeIsRemovableKey")]
		public  extern NSString VolumeIsRemovableKey { get; }

		[Field ("NSURLVolumeIsInternalKey")]
		public  extern NSString VolumeIsInternalKey { get; }

		[Field ("NSURLVolumeIsAutomountedKey")]
		public  extern NSString VolumeIsAutomountedKey { get; }

		[Field ("NSURLVolumeIsLocalKey")]
		public  extern NSString VolumeIsLocalKey { get; }

		[Field ("NSURLVolumeIsReadOnlyKey")]
		public  extern NSString VolumeIsReadOnlyKey { get; }

		[Field ("NSURLVolumeCreationDateKey")]
		public  extern NSString VolumeCreationDateKey { get; }

		[Field ("NSURLVolumeURLForRemountingKey")]
		public  extern NSString VolumeURLForRemountingKey { get; }

		[Field ("NSURLVolumeUUIDStringKey")]
		public  extern NSString VolumeUUIDStringKey { get; }

		[Field ("NSURLVolumeNameKey")]
		public  extern NSString VolumeNameKey { get; }

		[Field ("NSURLVolumeLocalizedNameKey")]
		public  extern NSString VolumeLocalizedNameKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeIsEncryptedKey")]
		public  extern NSString VolumeIsEncryptedKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeIsRootFileSystemKey")]
		public  extern NSString VolumeIsRootFileSystemKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeSupportsCompressionKey")]
		public  extern NSString VolumeSupportsCompressionKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeSupportsFileCloningKey")]
		public  extern NSString VolumeSupportsFileCloningKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeSupportsSwapRenamingKey")]
		public  extern NSString VolumeSupportsSwapRenamingKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeSupportsExclusiveRenamingKey")]
		public  extern NSString VolumeSupportsExclusiveRenamingKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeSupportsImmutableFilesKey")]
		public  extern NSString VolumeSupportsImmutableFilesKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeSupportsAccessPermissionsKey")]
		public  extern NSString VolumeSupportsAccessPermissionsKey { get; }

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSURLVolumeSupportsFileProtectionKey")]
		public  extern NSString VolumeSupportsFileProtectionKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeAvailableCapacityForImportantUsageKey")]
		public  extern NSString VolumeAvailableCapacityForImportantUsageKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLVolumeAvailableCapacityForOpportunisticUsageKey")]
		public  extern NSString VolumeAvailableCapacityForOpportunisticUsageKey { get; }

		//[Watch (9, 4), TV (16, 4), Mac (13, 3), iOS (16, 4)]
		[MacCatalyst (16, 4)]
		[Field ("NSURLVolumeTypeNameKey")]
		public  extern NSString VolumeTypeNameKey { get; }

		//[Watch (9, 4), TV (16, 4), Mac (13, 3), iOS (16, 4)]
		[MacCatalyst (16, 4)]
		[Field ("NSURLVolumeSubtypeKey")]
		public  extern NSString VolumeSubtypeKey { get; }

		//[Watch (9, 4), TV (16, 4), Mac (13, 3), iOS (16, 4)]
		[MacCatalyst (16, 4)]
		[Field ("NSURLVolumeMountFromLocationKey")]
		public  extern NSString VolumeMountFromLocationKey { get; }

		[Field ("NSURLIsUbiquitousItemKey")]
		public  extern NSString IsUbiquitousItemKey { get; }

		[Field ("NSURLUbiquitousItemHasUnresolvedConflictsKey")]
		public  extern NSString UbiquitousItemHasUnresolvedConflictsKey { get; }

		[Field ("NSURLUbiquitousItemIsDownloadedKey")]
		public  extern NSString UbiquitousItemIsDownloadedKey { get; }

		[Field ("NSURLUbiquitousItemIsDownloadingKey")]
		[Deprecated (PlatformName.iOS, 7, 0)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		public  extern NSString UbiquitousItemIsDownloadingKey { get; }

		[Field ("NSURLUbiquitousItemIsUploadedKey")]
		public  extern NSString UbiquitousItemIsUploadedKey { get; }

		[Field ("NSURLUbiquitousItemIsUploadingKey")]
		public  extern NSString UbiquitousItemIsUploadingKey { get; }

		[Field ("NSURLUbiquitousItemPercentDownloadedKey")]
		[Deprecated (PlatformName.iOS, 6, 0, message: "Use 'NSMetadataQuery.UbiquitousItemPercentDownloadedKey' on 'NSMetadataItem' instead.")]
		[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'NSMetadataQuery.UbiquitousItemPercentDownloadedKey' on 'NSMetadataItem' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 8, message: "Use 'NSMetadataQuery.UbiquitousItemPercentDownloadedKey' on 'NSMetadataItem' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSMetadataQuery.UbiquitousItemPercentDownloadedKey' on 'NSMetadataItem' instead.")]
		public  extern NSString UbiquitousItemPercentDownloadedKey { get; }

		[Deprecated (PlatformName.iOS, 6, 0, message: "Use 'NSMetadataQuery.UbiquitousItemPercentUploadedKey' on 'NSMetadataItem' instead.")]
		[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'NSMetadataQuery.UbiquitousItemPercentUploadedKey' on 'NSMetadataItem' instead.")]
		[Deprecated (PlatformName.MacOSX, 10, 8, message: "Use 'NSMetadataQuery.UbiquitousItemPercentUploadedKey' on 'NSMetadataItem' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'NSMetadataQuery.UbiquitousItemPercentUploadedKey' on 'NSMetadataItem' instead.")]
		[Field ("NSURLUbiquitousItemPercentUploadedKey")]
		public  extern NSString UbiquitousItemPercentUploadedKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemIsSharedKey")]
		public  extern NSString UbiquitousItemIsSharedKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemCurrentUserRoleKey")]
		public  extern NSString UbiquitousSharedItemCurrentUserRoleKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemCurrentUserPermissionsKey")]
		public  extern NSString UbiquitousSharedItemCurrentUserPermissionsKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemOwnerNameComponentsKey")]
		public  extern NSString UbiquitousSharedItemOwnerNameComponentsKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemMostRecentEditorNameComponentsKey")]
		public  extern NSString UbiquitousSharedItemMostRecentEditorNameComponentsKey { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemRoleOwner")]
		public  extern NSString UbiquitousSharedItemRoleOwner { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemRoleParticipant")]
		public  extern NSString UbiquitousSharedItemRoleParticipant { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemPermissionsReadOnly")]
		public  extern NSString UbiquitousSharedItemPermissionsReadOnly { get; }

		[NoWatch, NoTV]
		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousSharedItemPermissionsReadWrite")]
		public  extern NSString UbiquitousSharedItemPermissionsReadWrite { get; }

		[Field ("NSURLIsExcludedFromBackupKey")]
		public static extern NSString IsExcludedFromBackupKey { get; }

		[Export ("bookmarkDataWithOptions:includingResourceValuesForKeys:relativeToURL:error:")]
		public  extern NSData CreateBookmarkData (NSUrlBookmarkCreationOptions options, [NullAllowed] string [] resourceValues, [NullAllowed] NSUrl relativeUrl, out NSError error);

		[Export ("initByResolvingBookmarkData:options:relativeToURL:bookmarkDataIsStale:error:")]
		public  extern NativeHandle Constructor (NSData bookmarkData, NSUrlBookmarkResolutionOptions resolutionOptions, [NullAllowed] NSUrl relativeUrl, out bool bookmarkIsStale, out NSError error);

		[Field ("NSURLPathKey")]
		public  extern NSString PathKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemDownloadingStatusKey")]
		public  extern NSString UbiquitousItemDownloadingStatusKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemDownloadingErrorKey")]
		public  extern NSString UbiquitousItemDownloadingErrorKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemUploadingErrorKey")]
		public  extern NSString UbiquitousItemUploadingErrorKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemDownloadingStatusNotDownloaded")]
		public  extern NSString UbiquitousItemDownloadingStatusNotDownloaded { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemDownloadingStatusDownloaded")]
		public  extern NSString UbiquitousItemDownloadingStatusDownloaded { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemDownloadingStatusCurrent")]
		public  extern NSString UbiquitousItemDownloadingStatusCurrent { get; }

		[MacCatalyst (13, 1)]
		[Export ("startAccessingSecurityScopedResource")]
		public  extern bool StartAccessingSecurityScopedResource ();

		[MacCatalyst (13, 1)]
		[Export ("stopAccessingSecurityScopedResource")]
		public  extern void StopAccessingSecurityScopedResource ();

		[MacCatalyst (13, 1)]
		[Static, Export ("URLByResolvingAliasFileAtURL:options:error:")]
		public  extern NSUrl ResolveAlias (NSUrl aliasFileUrl, NSUrlBookmarkResolutionOptions options, out NSError error);

		[Static, Export ("fileURLWithPathComponents:")]
		public  extern NSUrl CreateFileUrl (string [] pathComponents);

		[MacCatalyst (13, 1)]
		[Field ("NSURLAddedToDirectoryDateKey")]
		public  extern NSString AddedToDirectoryDateKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLDocumentIdentifierKey")]
		public  extern NSString DocumentIdentifierKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLGenerationIdentifierKey")]
		public  extern NSString GenerationIdentifierKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLThumbnailDictionaryKey")]
		public static extern NSString ThumbnailDictionaryKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemContainerDisplayNameKey")]
		public static extern NSString UbiquitousItemContainerDisplayNameKey { get; }

		//[Watch (7, 4), TV (14, 5), iOS (14, 5)]
		[MacCatalyst (14, 5)]
		[Field ("NSURLUbiquitousItemIsExcludedFromSyncKey")]
		public  extern NSString UbiquitousItemIsExcludedFromSyncKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLUbiquitousItemDownloadRequestedKey")]
		public  extern NSString UbiquitousItemDownloadRequestedKey { get; }

		//
		// iOS 9.0/osx 10.11 additions
		//
		[DesignatedInitializer]
		[MacCatalyst (13, 1)]
		[Export ("initFileURLWithPath:isDirectory:relativeToURL:")]
		public  extern NativeHandle Constructor (string path, bool isDir, [NullAllowed] NSUrl relativeToUrl);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("fileURLWithPath:isDirectory:relativeToURL:")]
		public static extern NSUrl CreateFileUrl (string path, bool isDir, [NullAllowed] NSUrl relativeToUrl);

		[Static]
		[Export ("fileURLWithPath:isDirectory:")]
		public static extern NSUrl CreateFileUrl (string path, bool isDir);

		[Static]
		[Export ("fileURLWithPath:relativeToURL:")]
		public static extern NSUrl CreateFileUrl (string path, [NullAllowed] NSUrl relativeToUrl);

		[Static]
		[Export ("fileURLWithPath:")]
		public static extern NSUrl CreateFileUrl (string path);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("URLWithDataRepresentation:relativeToURL:")]
		public static extern NSUrl CreateWithDataRepresentation (NSData data, [NullAllowed] NSUrl relativeToUrl);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("absoluteURLWithDataRepresentation:relativeToURL:")]
		public static extern NSUrl CreateAbsoluteUrlWithDataRepresentation (NSData data, [NullAllowed] NSUrl relativeToUrl);

		[MacCatalyst (13, 1)]
		[Export ("dataRepresentation", ArgumentSemantic.Copy)]
		public static extern NSData DataRepresentation { get; }

		[MacCatalyst (13, 1)]
		[Export ("hasDirectoryPath")]
		public static extern bool HasDirectoryPath { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLIsApplicationKey")]
		public static extern NSString IsApplicationKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLFileProtectionKey")]
		public static extern NSString FileProtectionKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLFileProtectionNone")]
		public static extern NSString FileProtectionNone { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLFileProtectionComplete")]
		public static extern NSString FileProtectionComplete { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLFileProtectionCompleteUnlessOpen")]
		public static extern NSString FileProtectionCompleteUnlessOpen { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSURLFileProtectionCompleteUntilFirstUserAuthentication")]
		public static extern NSString FileProtectionCompleteUntilFirstUserAuthentication { get; }

	//	[Watch (10, 0), TV (17, 0), NoMac, iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("NSURLFileProtectionCompleteWhenUserInactive")]
		public static extern NSString FileProtectionCompleteWhenUserInactive { get; }

	//	[Watch (10, 0), TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Field ("NSURLDirectoryEntryCountKey")]
		public static extern NSString DirectoryEntryCountKey { get; }

		[Watch (7, 0)]
		[TV (14, 0)]
		//[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSURLContentTypeKey")]
		public static extern NSString ContentTypeKey { get; }

		[Watch (7, 0)]
		[TV (14, 0)]
		//[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSURLFileContentIdentifierKey")]
		public static extern NSString FileContentIdentifierKey { get; }

		[Watch (7, 0)]
		[TV (14, 0)]
		//[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSURLIsPurgeableKey")]
		public static extern NSString IsPurgeableKey { get; }

		[Watch (7, 0)]
		[TV (14, 0)]
		//[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSURLIsSparseKey")]
		public static extern NSString IsSparseKey { get; }

		[Watch (7, 0)]
		[TV (14, 0)]
	//	[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSURLMayHaveExtendedAttributesKey")]
		public static extern NSString MayHaveExtendedAttributesKey { get; }

		[Watch (7, 0)]
		[TV (14, 0)]
	//	[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("NSURLMayShareFileContentKey")]
		public static extern NSString MayShareFileContentKey { get; }

		// From the NSItemProviderReading protocol
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("readableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
		public static extern new string [] ReadableTypeIdentifiers { get; }

		// From the NSItemProviderReading protocol
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("objectWithItemProviderData:typeIdentifier:error:")]
		[return: NullAllowed]
		public static extern new NSUrl GetObject (NSData data, string typeIdentifier, [NullAllowed] out NSError outError);

		// From the NSItemProviderWriting protocol
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("writableTypeIdentifiersForItemProvider", ArgumentSemantic.Copy)]
		public static extern new string [] WritableTypeIdentifiers { get; }
	}
}
