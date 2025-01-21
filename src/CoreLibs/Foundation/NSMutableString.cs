// Copyright 2013 Xamarin Inc. All rights reserved.

using System;
using System.ComponentModel;
using CoreLibs;
using ObjCRuntime;

namespace Foundation {

	public partial class NSMutableString {

		// check helpers to avoid native exceptions

		void Check (NSRange range)
		{
			if (range.Location + range.Length > Length)
				throw new ArgumentOutOfRangeException ("range");
		}

		void Check (nint index)
		{
			if (index < 0 || index > Length)
				throw new ArgumentOutOfRangeException ("index");
		}
	}
	
	[BaseType (typeof (NSString))]
	// hack: it seems that generator.cs can't track NSCoding correctly ? maybe because the type is named NSString2 at that time
	public partial class NSMutableString : NSString {
		[Export ("initWithCapacity:")]
		public extern NativeHandle Constructor (nint capacity);

		[PreSnippet ("Check (index);", Optimizable = true)]
		[Export ("insertString:atIndex:")]
		public extern void Insert (NSString str, nint index);

		[PreSnippet ("Check (range);", Optimizable = true)]
		[Export ("deleteCharactersInRange:")]
		public extern void DeleteCharacters (NSRange range);

		[Export ("appendString:")]
		public extern void Append (NSString str);

		[Export ("setString:")]
		public extern void SetString (NSString str);

		[PreSnippet ("Check (range);", Optimizable = true)]
		[Export ("replaceOccurrencesOfString:withString:options:range:")]
		public extern nuint ReplaceOcurrences (NSString target, NSString replacement, NSStringCompareOptions options, NSRange range);

		[MacCatalyst (13, 1)]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		[Export ("applyTransform:reverse:range:updatedRange:")]
		public extern bool ApplyTransform (NSString transform, bool reverse, NSRange range, out NSRange resultingRange);

		[MacCatalyst (13, 1)]
		[Wrap ("ApplyTransform (transform.GetConstant ()!, reverse, range, out resultingRange)")]
		public extern bool ApplyTransform (NSStringTransform transform, bool reverse, NSRange range, out NSRange resultingRange);

		[Export ("replaceCharactersInRange:withString:")]
		public extern void ReplaceCharactersInRange (NSRange range, NSString aString);
	}
}
