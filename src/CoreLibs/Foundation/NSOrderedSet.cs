//
// NSOrderedSet.cs:
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2013, Xamarin Inc
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
using System.Reflection.Metadata;
using System.Runtime.Versioning;
using CoreFoundation;
using CoreLibs;
using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

	public partial class NSOrderedSet : IEnumerable<NSObject> {
		internal const string selSetWithArray = "orderedSetWithArray:";

		
		public NSOrderedSet () 
		{
		}

		public NSOrderedSet (params NSObject [] objs) : this (NSArray.FromNSObjects (objs))
		{
		}

		public NSOrderedSet (params INativeObject [] objs) : this (NSArray.FromObjects (objs))
		{
		}

		public NSOrderedSet (params string [] strings) : this (NSArray.FromStrings (strings))
		{
		}
		
		public NSOrderedSet (NSArray array) : this (array.Handle)
		{
		}
		
		public NSOrderedSet (NativeHandle handle) : base(handle)
		{
		}
		
		public NSOrderedSet (NSObject obj) 
		{
			if (obj == null)
				throw new ArgumentNullException ("obj");
			Handle = Constructor (obj);
		}

		public NSObject this [nint idx] {
			get {
				return GetObject (idx);
			}
		}

		public T [] ToArray<T> () where T : class, INativeObject
		{
			IntPtr nsarr = _ToArray ();
			return NSArray.ArrayFromHandle<T> (nsarr);
		}

		public static NSOrderedSet MakeNSOrderedSet<T> (T [] values) where T : NSObject
		{
			NSArray a = NSArray.FromNSObjects (values);
			return (NSOrderedSet) Runtime.GetNSObject (ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr (class_ptr, Selector.GetHandle (selSetWithArray), a.Handle));
		}

		/// <summary>Returns an enumerator that iterates through the set.</summary>
		/// <returns>An enumerator that can be used to iterate through the set.</returns>
		public IEnumerator<NSObject> GetEnumerator ()
		{
			var enumerator = _GetEnumerator ();
			NSObject obj;

			while ((obj = enumerator.NextObject ()) is not null)
				yield return obj as NSObject;
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			var enumerator = _GetEnumerator ();
			NSObject obj;

			while ((obj = enumerator.NextObject ()) is not null)
				yield return obj;
		}

		public static NSOrderedSet operator + (NSOrderedSet first, NSOrderedSet second)
		{
			if (first is null)
				return new NSOrderedSet (second);
			if (second is null)
				return new NSOrderedSet (first);
			var copy = new NSMutableOrderedSet (first);
			copy.UnionSet (second);
			return copy;
		}

		public static NSOrderedSet operator + (NSOrderedSet first, NSSet second)
		{
			if (first is null)
				return new NSOrderedSet (second);
			if (second is null)
				return new NSOrderedSet (first);
			var copy = new NSMutableOrderedSet (first);
			copy.UnionSet (second);
			return copy;
		}

		public static NSOrderedSet operator - (NSOrderedSet first, NSOrderedSet second)
		{
			if (first is null)
				return null;
			if (second is null)
				return new NSOrderedSet (first);
			var copy = new NSMutableOrderedSet (first);
			copy.MinusSet (second);
			return copy;
		}

		public static NSOrderedSet operator - (NSOrderedSet first, NSSet second)
		{
			if (first is null)
				return null;
			if (second is null)
				return new NSOrderedSet (first);
			var copy = new NSMutableOrderedSet (first);
			copy.MinusSet (second);
			return copy;
		}

		public static bool operator == (NSOrderedSet first, NSOrderedSet second)
		{
			// IsEqualToOrderedSet does not allow null
			if (object.ReferenceEquals (null, first))
				return object.ReferenceEquals (null, second);
			if (object.ReferenceEquals (null, second))
				return false;

			return first.IsEqualToOrderedSet (second);
		}

		public static bool operator != (NSOrderedSet first, NSOrderedSet second)
		{
			// IsEqualToOrderedSet does not allow null
			if (object.ReferenceEquals (null, first))
				return !object.ReferenceEquals (null, second);
			if (object.ReferenceEquals (null, second))
				return true;

			return !first.IsEqualToOrderedSet (second);
		}

		public override bool Equals (object other)
		{
			NSOrderedSet o = other as NSOrderedSet;
			if (o is null)
				return false;
			return IsEqualToOrderedSet (o);
		}

		public override int GetHashCode ()
		{
			return (int) GetNativeHash ();
		}

		public bool Contains (object obj)
		{
			return Contains (NSObject.FromObject (obj));
		}
	}

	public partial class NSMutableOrderedSet<TKey> : NSMutableOrderedSet { }

	[BaseType (typeof (NSOrderedSet))]
	public partial class NSMutableOrderedSet {
		[Export ("initWithObject:")]
		public extern NativeHandle Constructor (NSObject start);

		[Export ("initWithSet:")]
		public extern NativeHandle Constructor (NSSet source);

		[Export ("initWithOrderedSet:")]
		public extern NativeHandle Constructor (NSOrderedSet source);

		[DesignatedInitializer]
		[Export ("initWithCapacity:")]
		public extern NativeHandle Constructor (nint capacity);

		[Export ("initWithArray:"), Internal]
		public extern NativeHandle Constructor (NSArray array);

		[Export ("unionSet:"), Internal]
		public extern void UnionSet (NSSet other);

		[Export ("minusSet:"), Internal]
		public extern void MinusSet (NSSet other);

		[Export ("unionOrderedSet:"), Internal]
		public extern void UnionSet (NSOrderedSet other);

		[Export ("minusOrderedSet:"), Internal]
		public extern void MinusSet (NSOrderedSet other);

		[Internal]
		[Sealed]
		[Export ("insertObject:atIndex:")]
		public extern void _Insert (IntPtr obj, nint atIndex);

		[Export ("insertObject:atIndex:")]
		public extern void Insert (NSObject obj, nint atIndex);

		[Export ("removeObjectAtIndex:")]
		public extern void Remove (nint index);

		[Internal]
		[Sealed]
		[Export ("replaceObjectAtIndex:withObject:")]
		public extern void _Replace (nint objectAtIndex, IntPtr newObject);

		[Export ("replaceObjectAtIndex:withObject:")]
		public extern void Replace (nint objectAtIndex, NSObject newObject);

		[Internal]
		[Sealed]
		[Export ("addObject:")]
		public extern void _Add (IntPtr obj);

		[Export ("addObject:")]
		public extern void Add (NSObject obj);

		[Internal]
		[Sealed]
		[Export ("addObjectsFromArray:")]
		public extern void _AddObjects (NSArray source);

		[Export ("addObjectsFromArray:")]
		public extern void AddObjects (NSObject [] source);

		[Internal]
		[Sealed]
		[Export ("insertObjects:atIndexes:")]
		public extern void _InsertObjects (NSArray objects, NSIndexSet atIndexes);

		[Export ("insertObjects:atIndexes:")]
		public extern void InsertObjects (NSObject [] objects, NSIndexSet atIndexes);

		[Export ("removeObjectsAtIndexes:")]
		public extern void RemoveObjects (NSIndexSet indexSet);

		[Export ("exchangeObjectAtIndex:withObjectAtIndex:")]
		public extern void ExchangeObject (nint first, nint second);

		[Export ("moveObjectsAtIndexes:toIndex:")]
		public extern void MoveObjects (NSIndexSet indexSet, nint destination);

		[Internal]
		[Sealed]
		[Export ("setObject:atIndex:")]
		public extern void _SetObject (IntPtr obj, nint index);

		[Export ("setObject:atIndex:")]
		public extern void SetObject (NSObject obj, nint index);
		
		[Export ("getObject:atIndex:")]
		public extern NativeHandle _GetObject ( nint index);
		
		[Export ("getObject:atIndex:")]
		public extern NSObject GetObject ( nint index);

		[Internal]
		[Sealed]
		[Export ("replaceObjectsAtIndexes:withObjects:")]
		public extern void _ReplaceObjects (NSIndexSet indexSet, NSArray replacementObjects);

		[Export ("replaceObjectsAtIndexes:withObjects:")]
		public extern void ReplaceObjects (NSIndexSet indexSet, NSObject [] replacementObjects);

		[Export ("removeObjectsInRange:")]
		public extern void RemoveObjects (NSRange range);

		[Export ("removeAllObjects")]
		public extern void RemoveAllObjects ();

		[Internal]
		[Sealed]
		[Export ("removeObject:")]
		public extern void _RemoveObject (IntPtr obj);

		[Export ("removeObject:")]
		public extern void RemoveObject (NSObject obj);

		[Internal]
		[Sealed]
		[Export ("removeObjectsInArray:")]
		public extern void _RemoveObjects (NSArray objects);

		[Export ("removeObjectsInArray:")]
		public extern void RemoveObjects (NSObject [] objects);

		[Export ("intersectOrderedSet:")]
		public extern void Intersect (NSOrderedSet intersectWith);

		[Export ("intersectSet:")]
		public extern void Intersect (NSSet intersectWith);

		[Export ("sortUsingComparator:")]
		public extern void Sort (NSComparator comparator);

		[Export ("sortWithOptions:usingComparator:")]
		public extern void Sort (NSSortOptions sortOptions, NSComparator comparator);

		[Export ("sortRange:options:usingComparator:")]
		public extern void SortRange (NSRange range, NSSortOptions sortOptions, NSComparator comparator);

#if false // https://github.com/xamarin/xamarin-macios/issues/15577
		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("applyDifference:")]
		void _ApplyDifference (IntPtr difference);

		[Sealed]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("applyDifference:")]
		void ApplyDifference (NSOrderedCollectionDifference<NSObject> difference);
#endif
	}
	
	public partial class NSMutableOrderedSet: NSOrderedSet {
		
		public NSMutableOrderedSet () : base()
		{
		}
		public NSMutableOrderedSet (params NSObject [] objs) : this (NSArray.FromNSObjects (objs))
		{
		}
		
		public NSMutableOrderedSet (NativeHandle handle) : base(handle){
			
		}
		
		public NSMutableOrderedSet (NSObject obj) : base(obj){
			
		}

		public NSMutableOrderedSet (params INativeObject [] objs) : base (NSArray.FromObjects (objs))
		{
		}

		public NSMutableOrderedSet (params string [] strings) : this (NSArray.FromStrings (strings))
		{
		}

		public new NSObject this [nint idx] {
			get {
				return GetObject (idx);
			}

			set {
				SetObject (value, idx);
			}
		}

#if false // https://github.com/xamarin/xamarin-macios/issues/15577
		delegate bool NSOrderedCollectionDifferenceEquivalenceTestProxy (IntPtr blockLiteral, /* NSObject */ IntPtr first, /* NSObject */ IntPtr second);
		static readonly NSOrderedCollectionDifferenceEquivalenceTestProxy static_DiffEquality = DiffEqualityHandler;

		[MonoPInvokeCallback (typeof (NSOrderedCollectionDifferenceEquivalenceTestProxy))]
		static bool DiffEqualityHandler (IntPtr block, IntPtr first, IntPtr second)
		{
			var callback = BlockLiteral.GetTarget<NSOrderedCollectionDifferenceEquivalenceTest> (block);
			if (callback is not null) {
				var nsFirst = Runtime.GetNSObject<NSObject> (first, false);
				var nsSecond = Runtime.GetNSObject<NSObject> (second, false);
				return callback (nsFirst, nsSecond);
			}
			return false;
		}

#if !NET
		[Watch (6,0), TV (13,0), iOS (13,0)]
#else
		[SupportedOSPlatform ("ios13.0"), SupportedOSPlatform ("tvos13.0"), SupportedOSPlatform ("macos")]
#endif
		public NSOrderedCollectionDifference GetDifference (NSOrderedSet other, NSOrderedCollectionDifferenceCalculationOptions options, NSOrderedCollectionDifferenceEquivalenceTest equivalenceTest)
		{
			if (equivalenceTest is null)
				throw new ArgumentNullException (nameof (equivalenceTest));

			var block = new BlockLiteral ();
			block.SetupBlock (static_DiffEquality, equivalenceTest);
			try {
				return Runtime.GetNSObject<NSOrderedCollectionDifference> (_GetDifference (other, options, ref block));
			} finally {
				block.CleanupBlock ();
			}
		}
#endif
	}
	
	public partial class NSOrderedSet<TKey> : NSOrderedSet { }

	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	public partial class NSOrderedSet : NSMutableCopying {
		[Export ("initWithObject:")]
		public extern NativeHandle Constructor (NSObject start);

		[Export ("initWithArray:"), Internal]
		public extern NativeHandle Constructor (NSArray array);

		[Export ("initWithSet:")]
		public extern NativeHandle Constructor (NSSet source);

		[Export ("initWithOrderedSet:")]
		public extern NativeHandle Constructor (NSOrderedSet source);

		[Export ("count")]
		public extern nint Count { get; }

		[Internal]
		[Sealed]
		[Export ("objectAtIndex:")]
		public extern IntPtr _GetObject (nint idx);

		[Export ("objectAtIndex:"), Internal]
		public extern NSObject GetObject (nint idx);

		[Export ("array"), Internal]
		public extern IntPtr _ToArray ();

		[Internal]
		[Sealed]
		[Export ("indexOfObject:")]
		public extern nint _IndexOf (IntPtr obj);

		[Export ("indexOfObject:")]
		public extern nint IndexOf (NSObject obj);

		[Export ("objectEnumerator"), Internal]
		public extern NSEnumerator _GetEnumerator ();

		[Internal]
		[Sealed]
		[Export ("set")]
		public extern IntPtr _AsSet ();

		[Export ("set")]
		public extern NSSet AsSet ();

		[Internal]
		[Sealed]
		[Export ("containsObject:")]
		public extern bool _Contains (IntPtr obj);

		[Export ("containsObject:")]
		public extern bool Contains (NSObject obj);

		[Internal]
		[Sealed]
		[Export ("firstObject")]
		public extern IntPtr _FirstObject ();

		[Export ("firstObject")]
		[return: NullAllowed]
		public extern NSObject FirstObject ();

		[Internal]
		[Sealed]
		[Export ("lastObject")]
		public extern IntPtr _LastObject ();

		[Export ("lastObject")]
		[return: NullAllowed]
		public extern NSObject LastObject ();

		[Export ("isEqualToOrderedSet:")]
		public extern bool IsEqualToOrderedSet (NSOrderedSet other);

		[Export ("intersectsOrderedSet:")]
		public extern bool Intersects (NSOrderedSet other);

		[Export ("intersectsSet:")]
		public extern bool Intersects (NSSet other);

		[Export ("isSubsetOfOrderedSet:")]
		public extern bool IsSubset (NSOrderedSet other);

		[Export ("isSubsetOfSet:")]
		public extern bool IsSubset (NSSet other);

		[Export ("reversedOrderedSet")]
		public extern NSOrderedSet GetReverseOrderedSet ();

#if false // https://github.com/xamarin/xamarin-macios/issues/15577
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Wrap ("Runtime.GetNSObject <NSOrderedCollectionDifference> (_GetDifference (other, options))")]
		[return: NullAllowed]
		NSOrderedCollectionDifference GetDifference (NSOrderedSet other, NSOrderedCollectionDifferenceCalculationOptions options);
		
		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("differenceFromOrderedSet:withOptions:")]
		IntPtr _GetDifference (NSOrderedSet other, NSOrderedCollectionDifferenceCalculationOptions options);

		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Wrap ("Runtime.GetNSObject <NSOrderedCollectionDifference> (_GetDifference (other))")]
		[return: NullAllowed]
		NSOrderedCollectionDifference GetDifference (NSOrderedSet other);
		
		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("differenceFromOrderedSet:")]
		IntPtr _GetDifference (NSOrderedSet other);

		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Wrap ("Runtime.GetNSObject <NSOrderedSet> (_GetOrderedSet (difference))")]
		[return: NullAllowed]
		NSOrderedSet GetOrderedSet (NSOrderedCollectionDifference difference);
		
		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("orderedSetByApplyingDifference:")]
		[return: NullAllowed]
		IntPtr _GetOrderedSet (NSOrderedCollectionDifference difference);

		[Internal]
		[Watch (6,0), TV (13,0), iOS (13,0)]
		[Export ("differenceFromOrderedSet:withOptions:usingEquivalenceTest:")]
		/* NSOrderedCollectionDifference<NSObject>*/ IntPtr _GetDifference (NSOrderedSet other, NSOrderedCollectionDifferenceCalculationOptions options, /* Func<NSObject, NSObject, bool> */ ref BlockLiteral block);
#endif
	}
}
