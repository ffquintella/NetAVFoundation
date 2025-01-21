//
// This file describes the API that the generator will produce
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2010, Novell, Inc.
// Copyright 2012, 2015, Xamarin Inc
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

using System;
using System.Collections;
using System.Collections.Generic;
using CoreLibs;
using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

	public partial class NSSet : IEnumerable<NSObject> {

		public NSSet(NSArray array)
		{
			
		}

		public NSSet()
		{
			
		}
		
		public NSSet(NativeHandle handle) : base(handle) {}
		
		public NSSet (params NSObject [] objs) : this (NSArray.FromNSObjects (objs))
		{
		}

		public NSSet (params INativeObject [] objs) : this (NSArray.FromObjects (objs))
		{
		}

		public NSSet (params string [] strings) : this (NSArray.FromStrings (strings))
		{
		}

		public T [] ToArray<T> () where T : class, INativeObject
		{
			IntPtr nsarr = _AllObjects ();
			return NSArray.ArrayFromHandle<T> (nsarr);
		}

		public static NSSet MakeNSObjectSet<T> (T [] values) where T : class, INativeObject
		{
			using (var a = NSArray.FromNSObjects (values))
				return Runtime.GetNSObject<NSSet> (_SetWithArray (a.Handle));
		}

		#region IEnumerable<T>
		/// <summary>Returns an enumerator that iterates through the set.</summary>
		/// <returns>An enumerator that can be used to iterate through the set.</returns>
		public IEnumerator<NSObject> GetEnumerator ()
		{
			var enumerator = _GetEnumerator ();
			NSObject obj;

			while ((obj = enumerator.NextObject ()) is not null)
				yield return obj as NSObject;
		}
		#endregion

		#region IEnumerable
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return ((IEnumerable<NSObject>) this).GetEnumerator ();
		}
		#endregion

		public static NSSet operator + (NSSet first, NSSet second)
		{
			if (first is null)
				return new NSSet (second);
			if (second is null)
				return new NSSet (first);
			return first.SetByAddingObjectsFromSet (second);
		}

		public static NSSet operator + (NSSet first, NSOrderedSet second)
		{
			if (first is null)
				return new NSSet (second.AsSet ());
			if (second is null)
				return new NSSet (first);
			var copy = new NSMutableSet (first);
			copy.UnionSet (second.AsSet ());
			return copy;
		}

		public static NSSet operator - (NSSet first, NSSet second)
		{
			if (first is null)
				return null;
			if (second is null)
				return new NSSet (first);
			var copy = new NSMutableSet (first);
			copy.MinusSet (second);
			return copy;
		}

		public static NSSet operator - (NSSet first, NSOrderedSet second)
		{
			if (first is null)
				return null;
			if (second is null)
				return new NSSet (first);
			var copy = new NSMutableSet (first);
			copy.MinusSet (second.AsSet ());
			return copy;
		}

		public bool Contains (object obj)
		{
			return Contains (NSObject.FromObject (obj));
		}
	}
	
	[BaseType (typeof (NSObject))]
	public partial class NSSet : NSMutableCopying {
		[Export ("set")]
		[Static]
		public static extern NSSet CreateSet ();

		[Export ("initWithSet:")]
		public extern NativeHandle Constructor (NSSet other);

		[Export ("initWithArray:")]
		public extern NativeHandle Constructor (NSArray other);

		[Export ("count")]
		public extern nuint Count { get; }

		[Internal]
		[Sealed]
		[Export ("member:")]
		public extern IntPtr _LookupMember (IntPtr probe);

		[Export ("member:")]
		public extern NSObject LookupMember (NSObject probe);

		[Internal]
		[Sealed]
		[Export ("anyObject")]
		internal extern IntPtr _AnyObject { get; }

		[Export ("anyObject")]
		public extern NSObject AnyObject { get; }

		[Internal]
		[Sealed]
		[Export ("containsObject:")]
		internal extern bool _Contains (NativeHandle id);

		[Export ("containsObject:")]
		public extern bool Contains (NSObject id);

		[Export ("allObjects")]
		[Internal]
		internal extern IntPtr _AllObjects ();

		[Export ("isEqualToSet:")]
		public extern bool IsEqualToSet (NSSet other);

		[Export ("objectEnumerator"), Internal]
		public extern NSEnumerator _GetEnumerator ();

		[Export ("isSubsetOfSet:")]
		public extern bool IsSubsetOf (NSSet other);

		[Export ("enumerateObjectsUsingBlock:")]
		public extern void Enumerate (NSSetEnumerator enumerator);

		[Internal]
		[Sealed]
		[Export ("setByAddingObjectsFromSet:")]
		internal extern NativeHandle _SetByAddingObjectsFromSet (NativeHandle other);

		[Export ("setByAddingObjectsFromSet:"), Internal]
		public extern NSSet SetByAddingObjectsFromSet (NSSet other);

		[Export ("intersectsSet:")]
		public extern bool IntersectsSet (NSSet other);

		[Internal]
		[Static]
		[Export ("setWithArray:")]
		public extern static NativeHandle _SetWithArray (NativeHandle array);
	}

	public partial class NSSet<TKey> : NSSet { }
}
