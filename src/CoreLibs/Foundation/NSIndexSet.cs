//
// Authors:
//      James Clancey james.clancey@gmail.com>
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

#if MONOMAC

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CoreLibs;
using ObjCRuntime;

namespace Foundation {
	
	public partial class NSIndexSet : IEnumerable<nuint> {

		public NSIndexSet()
		{
			Handle = new IntPtr (0);
		}
		
		IEnumerator IEnumerable.GetEnumerator ()
		{
			if (this.Count == 0)
				yield break;

			for (nuint i = this.FirstIndex; i <= this.LastIndex;) {
				yield return i;
				i = this.IndexGreaterThan (i);
			}
		}

		/// <summary>Returns an enumerator that iterates through the set.</summary>
		/// <returns>An enumerator that can be used to iterate through the set.</returns>
		public IEnumerator<nuint> GetEnumerator ()
		{
			if (this.Count == 0)
				yield break;

			for (nuint i = this.FirstIndex; i <= this.LastIndex;) {
				yield return i;
				i = this.IndexGreaterThan (i);
			}
		}
		
		public nuint[] ToArray ()
		{
			nuint [] indexes = new nuint [Count];

			if (this.Count == 0)
				return indexes;

			int j = 0;
			for (nuint i = this.FirstIndex; i <= this.LastIndex;) {
				indexes [j++] = i;
				i = this.IndexGreaterThan (i);
			}
			return indexes;
		}

		public static NSIndexSet FromArray (nuint[] items)
		{
			if (items is null)
				return new NSIndexSet ();
			
			var indexSet = new NSMutableIndexSet();
			foreach (var index in items) 
				indexSet.Add (index);	
			return indexSet;
		}

		public static NSIndexSet FromArray (uint[] items)
		{
			if (items is null)
				return new NSIndexSet ();

			var indexSet = new NSMutableIndexSet();
			foreach (var index in items)
				indexSet.Add ((nuint)index);
			return indexSet;
		}

		public static NSIndexSet FromArray (int[] items)
		{
			if (items is null)
				return new NSIndexSet ();
			
			var indexSet = new NSMutableIndexSet();
			foreach (var index in items){
				if (index < 0)
					throw new ArgumentException ("One of the items values is negative");
				indexSet.Add ((nuint)(uint) index);
			}
			return indexSet;
		}

		public NSIndexSet (uint value) 
		{
			Handle = this.Constructor((nuint)value);
		}

		public NSIndexSet (nint value) 
		{
			if (value < 0)
				throw new ArgumentException ("value must be positive");
			// init done by the base ctor
			
			Handle = this.Constructor((nuint)value);
		}

		public NSIndexSet (int value) 
		{
			if (value < 0)
				throw new ArgumentException ("value must be positive");
			// init done by the base ctor
			
			Handle = this.Constructor((nuint)(uint)value);
		}
	}
	
	[BaseType (typeof (NSObject))]
	public partial class NSIndexSet : NSMutableCopying {
		[Static, Export ("indexSetWithIndex:")]
		public extern NSIndexSet FromIndex (nint idx);

		[Static, Export ("indexSetWithIndexesInRange:")]
		public extern NSIndexSet FromNSRange (NSRange indexRange);

		[Export ("initWithIndex:")]
		public extern NativeHandle Constructor (nuint index);

		[DesignatedInitializer]
		[Export ("initWithIndexSet:")]
		public extern NativeHandle Constructor (NSIndexSet other);

		[Export ("count")]
		public extern nint Count { get; }

		[Export ("isEqualToIndexSet:")]
		public extern bool IsEqual (NSIndexSet other);

		[Export ("firstIndex")]
		public extern nuint FirstIndex { get; }

		[Export ("lastIndex")]
		public extern nuint LastIndex { get; }

		[Export ("indexGreaterThanIndex:")]
		public extern nuint IndexGreaterThan (nuint index);

		[Export ("indexLessThanIndex:")]
		public extern nuint IndexLessThan (nuint index);

		[Export ("indexGreaterThanOrEqualToIndex:")]
		public extern nuint IndexGreaterThanOrEqual (nuint index);

		[Export ("indexLessThanOrEqualToIndex:")]
		public extern nuint IndexLessThanOrEqual (nuint index);

		[Export ("containsIndex:")]
		public extern bool Contains (nuint index);

		[Export ("containsIndexes:")]
		public extern bool Contains (NSIndexSet indexes);

		[Export ("enumerateRangesUsingBlock:")]
		extern void EnumerateRanges (NSRangeIterator iterator);

		[Export ("enumerateRangesWithOptions:usingBlock:")]
		extern void EnumerateRanges (NSEnumerationOptions opts, NSRangeIterator iterator);

		[Export ("enumerateRangesInRange:options:usingBlock:")]
		extern void EnumerateRanges (NSRange range, NSEnumerationOptions opts, NSRangeIterator iterator);

		[Export ("enumerateIndexesUsingBlock:")]
		public extern void EnumerateIndexes (EnumerateIndexSetCallback enumeratorCallback);

		[Export ("enumerateIndexesWithOptions:usingBlock:")]
		public extern void EnumerateIndexes (NSEnumerationOptions opts, EnumerateIndexSetCallback enumeratorCallback);

		[Export ("enumerateIndexesInRange:options:usingBlock:")]
		public extern void EnumerateIndexes (NSRange range, NSEnumerationOptions opts, EnumerateIndexSetCallback enumeratorCallback);
	}
	
	delegate void NSRangeIterator (NSRange range, ref bool stop);
	
}

#endif
