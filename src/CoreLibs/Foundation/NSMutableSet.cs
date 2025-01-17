//
// This file describes the API that the generator will produce
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2012, Xamarin Inc.
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

using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

	public partial class NSMutableSet : IEnumerable<NSObject> {
		public NSMutableSet (params NSObject [] objs)
			: this (NSArray.FromNSObjects (objs))
		{
		}

		public NSMutableSet (params string [] strings)
			: this (NSArray.FromStrings (strings))
		{
		}

		internal NSMutableSet (params INativeObject [] objs)
			: this (NSArray.FromNSObjects (objs))
		{
		}
		
		public NSMutableSet (NativeHandle handle ) : base (handle)
		{
		}
		
		public NSMutableSet (NSArray array) : base (array)
		{
		}

		public NSMutableSet()
		{
			
		}

		public static NSMutableSet operator + (NSMutableSet first, NSMutableSet second)
		{
			if (first is null || first.Count == 0)
				return new NSMutableSet (second);
			if (second is null || second.Count == 0)
				return new NSMutableSet (first);

			var copy = new NSMutableSet (first);
			copy.UnionSet (second);
			return copy;
		}

		public static NSMutableSet operator - (NSMutableSet first, NSMutableSet second)
		{
			if (first is null || first.Count == 0)
				return null;
			if (second is null || second.Count == 0)
				return new NSMutableSet (first);

			var copy = new NSMutableSet (first);
			copy.MinusSet (second);
			return copy;
		}
	}
	
	[BaseType (typeof (NSSet))]
	public partial class NSMutableSet: NSSet {
		[Export ("initWithArray:")]
		public extern NativeHandle Constructor (NSArray other);

		[Export ("initWithSet:")]
		public extern NativeHandle Constructor (NSSet other);

		[DesignatedInitializer]
		[Export ("initWithCapacity:")]
		public extern NativeHandle Constructor (nint capacity);

		[Internal]
		[Sealed]
		[Export ("addObject:")]
		public extern void _Add (IntPtr obj);

		[Export ("addObject:")]
		public extern void Add (NSObject nso);

		[Internal]
		[Sealed]
		[Export ("removeObject:")]
		public extern void _Remove (IntPtr nso);

		[Export ("removeObject:")]
		public extern void Remove (NSObject nso);

		[Export ("removeAllObjects")]
		public extern void RemoveAll ();

		[Internal]
		[Sealed]
		[Export ("addObjectsFromArray:")]
		public extern void _AddObjects (IntPtr objects);

		[Export ("addObjectsFromArray:")]
		public extern void AddObjects (NSObject [] objects);

		[Internal, Export ("minusSet:")]
		public extern void MinusSet (NSSet other);

		[Internal, Export ("unionSet:")]
		public extern void UnionSet (NSSet other);
	}
}
