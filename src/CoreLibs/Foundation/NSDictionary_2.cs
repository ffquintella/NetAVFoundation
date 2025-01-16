//
// Copyright 2015 Xamarin Inc
//
// This file contains a generic version of NSDictionary.
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
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using ObjCRuntime;

#if !NET
using NativeHandle = System.IntPtr;
#endif

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {
#if NET
	[SupportedOSPlatform ("ios")]
	[SupportedOSPlatform ("maccatalyst")]
	[SupportedOSPlatform ("macos")]
	[SupportedOSPlatform ("tvos")]
#endif
	//[Register ("NSDictionary", SkipRegistration = true)]
	public partial class NSDictionary<K, V> : NSDictionary, IDictionary<K, V>
		where K : class, INativeObject
		where V : class, INativeObject {
		public NSDictionary ()
		{
		}
		

		public NSDictionary (string filename)
		{
			Handle = this.Constructor(filename);
		}

		public NSDictionary (NSUrl url)
		{
			Handle = Constructor(url);
		}

		internal NSDictionary (NativeHandle handle)
		{
			Handle = handle;
		}

		public NSDictionary (NSDictionary<K, V> other)
		{
			Handle = Constructor(other);
		}

		internal static bool ValidateKeysAndValues (K [] keys, V [] values)
		{
			if (keys is null)
				throw new ArgumentNullException (nameof (keys));

			if (values is null)
				throw new ArgumentNullException (nameof (values));

			if (values.Length != keys.Length)
				throw new ArgumentException (nameof (values) + " and " + nameof (keys) + " arrays have different sizes");

			return true;
		}

		NSDictionary (K [] keys, V [] values, bool validation)
			: base (NSArray.FromNSObjects (values), NSArray.FromNSObjects (keys))
		{
		}

		public NSDictionary (K [] keys, V [] values)
			: this (keys, values, ValidateKeysAndValues (keys, values))
		{
		}

		public NSDictionary (K key, V value)
			: base (NSArray.FromNSObjects (value), NSArray.FromNSObjects (key))
		{
		}

		// Strongly typed methods from NSDictionary

		public V ObjectForKey (K key)
		{
			if (key is null)
				throw new ArgumentNullException (nameof (key));

			return Runtime.GetINativeObject<V> (_ObjectForKey (key.Handle), false);
		}

		public K [] Keys {
			get {
				using (var pool = new NSAutoreleasePool ())
					return NSArray.ArrayFromHandle<K> (_AllKeys ());
			}
		}

		public K [] KeysForObject (V obj)
		{
			if (obj is null)
				throw new ArgumentNullException (nameof (obj));

			using (var pool = new NSAutoreleasePool ())
				return NSArray.ArrayFromHandle<K> (_AllKeysForObject (obj.Handle));
		}

		public V [] Values {
			get {
				using (var pool = new NSAutoreleasePool ())
					return NSArray.ArrayFromHandle<V> (_AllValues ());
			}
		}

		public V [] ObjectsForKeys (K [] keys, V marker)
		{
			if (keys is null)
				throw new ArgumentNullException (nameof (keys));

			if (marker is null)
				throw new ArgumentNullException (nameof (marker));

			if (keys.Length == 0)
				return new V [] { };

			using (var pool = new NSAutoreleasePool ())
				return NSArray.ArrayFromHandle<V> (_ObjectsForKeys (NSArray.From<K> (keys).Handle, marker.Handle));
		}

		static NSDictionary<K, V> GenericFromObjectsAndKeysInternal (NSArray objects, NSArray keys)
		{
			return Runtime.GetNSObject<NSDictionary<K, V>> (_FromObjectsAndKeysInternal (objects.Handle, keys.Handle));
		}

		public static NSDictionary<K, V> FromObjectsAndKeys (V [] objects, K [] keys, nint count)
		{
			if (objects is null)
				throw new ArgumentNullException (nameof (objects));
			if (keys is null)
				throw new ArgumentNullException (nameof (keys));
			if (objects.Length != keys.Length)
				throw new ArgumentException (nameof (objects) + " and " + nameof (keys) + " arrays have different sizes");
			if (count < 1 || objects.Length < count)
				throw new ArgumentException (nameof (count));

			using (var no = NSArray.FromNativeObjects (objects, count))
			using (var nk = NSArray.FromNativeObjects (keys, count))
				return GenericFromObjectsAndKeysInternal (no, nk);
		}

#if NET
		public static NSDictionary<K, V> FromObjectsAndKeys (V [] objects, K [] keys)
#else
		[Obsolete ("'K' and 'V' are inversed and won't work unless both types are identical. Use the generic overload that takes a count parameter instead.")]
		public static NSDictionary<K, V> FromObjectsAndKeys (K [] objects, V [] keys)
#endif
		{
			if (objects is null)
				throw new ArgumentNullException (nameof (objects));
			if (keys is null)
				throw new ArgumentNullException (nameof (keys));
			if (objects.Length != keys.Length)
				throw new ArgumentException (nameof (objects) + " and " + nameof (keys) + " arrays have different sizes");

			using (var no = NSArray.FromNSObjects (objects))
			using (var nk = NSArray.FromNSObjects (keys))
				return GenericFromObjectsAndKeysInternal (no, nk);
		}

		public static NSDictionary<K, V> FromObjectsAndKeys (object [] objects, object [] keys)
		{
			if (objects is null)
				throw new ArgumentNullException (nameof (objects));
			if (keys is null)
				throw new ArgumentNullException (nameof (keys));
			if (objects.Length != keys.Length)
				throw new ArgumentException (nameof (objects) + " and " + nameof (keys) + " arrays have different sizes");

			using (var no = NSArray.FromObjects ((NSObject[])objects))
			using (var nk = NSArray.FromObjects ((NSObject[])keys))
				return GenericFromObjectsAndKeysInternal (no, nk);
		}

		public static NSDictionary<K, V> FromObjectsAndKeys (NSObject [] objects, NSObject [] keys, nint count)
		{
			if (objects is null)
				throw new ArgumentNullException (nameof (objects));
			if (keys is null)
				throw new ArgumentNullException (nameof (keys));
			if (objects.Length != keys.Length)
				throw new ArgumentException (nameof (objects) + " and " + nameof (keys) + " arrays have different sizes");
			if (count < 1 || objects.Length < count || keys.Length < count)
				throw new ArgumentException (nameof (count));

			using (var no = NSArray.FromNativeObjects (objects, count))
			using (var nk = NSArray.FromNativeObjects (keys, count))
				return GenericFromObjectsAndKeysInternal (no, nk);
		}

		public static NSDictionary<K, V> FromObjectsAndKeys (object [] objects, object [] keys, nint count)
		{
			if (objects is null)
				throw new ArgumentNullException (nameof (objects));
			if (keys is null)
				throw new ArgumentNullException (nameof (keys));
			if (objects.Length != keys.Length)
				throw new ArgumentException (nameof (objects) + " and " + nameof (keys) + " arrays have different sizes");
			if (count < 1 || objects.Length < count || keys.Length < count)
				throw new ArgumentException (nameof (count));

			using (var no = NSArray.FromObjects (count, (NSObject[]) objects))
			using (var nk = NSArray.FromObjects (count, (NSObject[]) keys))
				return GenericFromObjectsAndKeysInternal (no, nk);
		}

		// Other implementations

		public bool ContainsKey (K key)
		{
			if (key is null)
				throw new ArgumentNullException (nameof (key));

			return _ObjectForKey (key.Handle) != IntPtr.Zero;
		}

		public bool TryGeValue (K key, out V value)
		{
			// NSDictionary can not contain NULLs, if you want a NULL, it exists as an NSNull
			return (value = ObjectForKey (key)) is not null;
		}



		public V this [K key] {
			get {
				return ObjectForKey (key);
			}
		}

		#region IDictionary<K,V> implementation
		bool IDictionary<K, V>.ContainsKey (K key)
		{
			return ContainsKey (key);
		}

		void IDictionary<K, V>.Add (K key, V value)
		{
			throw new NotSupportedException ();
		}

		bool IDictionary<K, V>.Remove (K key)
		{
			throw new NotSupportedException ();
		}

		bool IDictionary<K, V>.TryGetValue (K key, out V value)
		{
			return TryGetValue (key, out value);
		}

		V IDictionary<K, V>.this [K key] {
			get {
				return this [key];
			}
			set {
				throw new NotSupportedException ();
			}
		}

		ICollection<K> IDictionary<K, V>.Keys {
			get {
				return Keys;
			}
		}

		ICollection<V> IDictionary<K, V>.Values {
			get {
				return Values;
			}
		}
		#endregion

		#region ICollection<K,V> implementation
		void ICollection<KeyValuePair<K, V>>.Add (KeyValuePair<K, V> item)
		{
			throw new NotSupportedException ();
		}

		void ICollection<KeyValuePair<K, V>>.Clear ()
		{
			throw new NotSupportedException ();
		}

		bool ICollection<KeyValuePair<K, V>>.Contains (KeyValuePair<K, V> item)
		{
			V value;
			if (!TryGetValue<V> (item.Key, out value))
				return false;

			return (object) value == (object) item.Value;
		}

		void ICollection<KeyValuePair<K, V>>.CopyTo (KeyValuePair<K, V> [] array, int arrayIndex)
		{
			if (array is null)
				throw new ArgumentNullException (nameof (array));
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException (nameof (arrayIndex));
			int c = array.Length;
			if ((c > 0) && (arrayIndex >= c))
				throw new ArgumentException (nameof (arrayIndex) + " is equal to or greater than " + nameof (array) + ".Length");
			if (arrayIndex + (int) Count > c)
				throw new ArgumentException ("Not enough room from " + nameof (arrayIndex) + " to end of " + nameof (array) + " for this dictionary");

			var idx = arrayIndex;
			foreach (var kvp in (IEnumerable<KeyValuePair<K, V>>) this)
				array [idx++] = kvp;
		}

		bool ICollection<KeyValuePair<K, V>>.Remove (KeyValuePair<K, V> item)
		{
			throw new NotSupportedException ();
		}

		int ICollection<KeyValuePair<K, V>>.Count {
			get {
				return (int) base.Count;
			}
		}

		bool ICollection<KeyValuePair<K, V>>.IsReadOnly {
			get {
				return true;
			}
		}
		#endregion

		#region IEnumerable<KVP> implementation
		IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator ()
		{
			foreach (var key in Keys) {
				yield return new KeyValuePair<K, V> (key, ObjectForKey (key));
			}
		}
		#endregion

		#region IEnumerable implementation
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
		#endregion
	}
}
