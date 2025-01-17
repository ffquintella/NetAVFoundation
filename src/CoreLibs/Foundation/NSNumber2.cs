//
// Copyright 2010, Novell, Inc.
// Copyright 2014 Xamarin Inc. All rights reserved.
//

using System;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;

using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {
	public partial class NSNumber : NSValue
#if COREBUILD
	{
#else
	, IComparable, IComparable<NSNumber>, IEquatable<NSNumber> {

		public static implicit operator NSNumber (float value)
		{
			return FromFloat (value);
		}

		public static implicit operator NSNumber (double value)
		{
			return FromDouble (value);
		}

		public static implicit operator NSNumber (bool value)
		{
			return FromBoolean (value);
		}

		public static implicit operator NSNumber (sbyte value)
		{
			return FromSByte (value);
		}

		public static implicit operator NSNumber (byte value)
		{
			return FromByte (value);
		}

		public static implicit operator NSNumber (short value)
		{
			return FromInt16 (value);
		}

		public static implicit operator NSNumber (ushort value)
		{
			return FromUInt16 (value);
		}

		public static implicit operator NSNumber (int value)
		{
			return FromInt32 (value);
		}

		public static implicit operator NSNumber (uint value)
		{
			return FromUInt32 (value);
		}

		public static implicit operator NSNumber (long value)
		{
			return FromInt64 (value);
		}

		public static implicit operator NSNumber (ulong value)
		{
			return FromUInt64 (value);
		}

		public static explicit operator byte (NSNumber source)
		{
			return source.ByteValue;
		}

		public static explicit operator sbyte (NSNumber source)
		{
			return source.SByteValue;
		}

		public static explicit operator short (NSNumber source)
		{
			return source.Int16Value;
		}

		public static explicit operator ushort (NSNumber source)
		{
			return source.UInt16Value;
		}

		public static explicit operator int (NSNumber source)
		{
			return source.Int32Value;
		}

		public static explicit operator uint (NSNumber source)
		{
			return source.UInt32Value;
		}

		public static explicit operator long (NSNumber source)
		{
			return source.Int64Value;
		}

		public static explicit operator ulong (NSNumber source)
		{
			return source.UInt64Value;
		}

		public static explicit operator float (NSNumber source)
		{
			return source.FloatValue;
		}

		public static explicit operator double (NSNumber source)
		{
			return source.DoubleValue;
		}

		public static explicit operator bool (NSNumber source)
		{
			return source.BoolValue;
		}
		
		public NSNumber (nfloat value) 
		{
			Handle = FromNFloat (value).Handle;
		}
		
		public NSNumber (bool value) 
		{
			Handle = FromBoolean(value).Handle;
		}

		public NSNumber (float value) 
		{
			Handle = FromFloat(value).Handle;
		}
		
		public NSNumber (double value) 
		{
			Handle = FromDouble(value).Handle;
		}
		

		public nfloat NFloatValue {
			get {
				return (nfloat) DoubleValue;
			}
		}

		public static NSNumber FromNFloat (nfloat value)
		{
			return (FromDouble ((double) value));
		}

		public override string ToString ()
		{
			return StringValue;
		}

		public int CompareTo (object obj)
		{
			return CompareTo (obj as NSNumber);
		}

		public int CompareTo (NSNumber other)
		{
			// value must not be `nil` to call the `compare:` selector
			// that match well with the not same type of .NET check
			if (other is null)
				throw new ArgumentException ("other");
			return (int) Compare (other);
		}

		// should be present when implementing IComparable
		public override bool Equals (object other)
		{
			return Equals (other as NSNumber);
		}

		// IEquatable<NSNumber>
		public bool Equals (NSNumber other)
		{
			if (other is null)
				return false;
			return IsEqualTo (other.Handle);
		}

		public override int GetHashCode ()
		{
			// this is heavy weight :( but it's the only way to follow .NET rule where:
			// "If two objects compare as equal, the GetHashCode method for each object must return the same value."
			// otherwise NSNumber (1) needs to be != from NSNumber (1d), a breaking change from classic and 
			// something that's really not obvious
			return StringValue.GetHashCode ();
		}
#endif
	}
	
	[BaseType (typeof (NSValue))]
	public partial class NSNumber : NSValue //, CKRecordValue, NSFetchRequestResult {
	{
		[Export ("charValue")]
		public extern sbyte SByteValue { get; }

		[Export ("unsignedCharValue")]
		public extern byte ByteValue { get; }

		[Export ("shortValue")]
		public extern short Int16Value { get; }

		[Export ("unsignedShortValue")]
		public extern ushort UInt16Value { get; }

		[Export ("intValue")]
		public extern int Int32Value { get; }

		[Export ("unsignedIntValue")]
		public extern uint UInt32Value { get; }

		[Export ("longValue")]
		public extern nint LongValue { get; }

		[Export ("unsignedLongValue")]
		public extern nuint UnsignedLongValue { get; }

		[Export ("longLongValue")]
		public extern long Int64Value { get; }

		[Export ("unsignedLongLongValue")]
		public extern ulong UInt64Value { get; }

		[Export ("floatValue")]
		public extern float FloatValue { get; } /* float, not CGFloat */

		[Export ("doubleValue")]
		public extern double DoubleValue { get; }

		[Export ("decimalValue")]
		public extern NSDecimal NSDecimalValue { get; }

		[Export ("boolValue")]
		public extern bool BoolValue { get; }

		[Export ("integerValue")]
		public extern nint NIntValue { get; }

		[Export ("unsignedIntegerValue")]
		public extern nuint NUIntValue { get; }

		[Export ("stringValue")]
		public extern string StringValue { get; }

		[Export ("compare:")]
		public extern static nint Compare (NSNumber otherNumber);

		[Export ("isEqualToNumber:")]
		public extern static bool IsEqualTo (IntPtr number);

		[Wrap ("IsEqualTo (number.GetHandle ())")]
		public extern static bool IsEqualTo (NSNumber number);

		[Export ("descriptionWithLocale:")]
		public extern static string DescriptionWithLocale (NSLocale locale);

		[DesignatedInitializer]
		[Export ("initWithChar:")]
		public extern static NativeHandle Constructor (sbyte value);

		[DesignatedInitializer]
		[Export ("initWithUnsignedChar:")]
		public extern static NativeHandle Constructor (byte value);

		[DesignatedInitializer]
		[Export ("initWithShort:")]
		public extern static NativeHandle Constructor (short value);

		[DesignatedInitializer]
		[Export ("initWithUnsignedShort:")]
		public extern static NativeHandle Constructor (ushort value);

		[DesignatedInitializer]
		[Export ("initWithInt:")]
		public extern static NativeHandle Constructor (int /* int, not NSInteger */ value);

		[DesignatedInitializer]
		[Export ("initWithUnsignedInt:")]
		public extern static NativeHandle Constructor (uint /* unsigned int, not NSUInteger */value);

		//[Export ("initWithLong:")]
		//NativeHandle Constructor (long value);
		//
		//[Export ("initWithUnsignedLong:")]
		//NativeHandle Constructor (ulong value);

		[DesignatedInitializer]
		[Export ("initWithLongLong:")]
		public extern static NativeHandle Constructor (long value);

		[DesignatedInitializer]
		[Export ("initWithUnsignedLongLong:")]
		public extern static NativeHandle Constructor (ulong value);

		[DesignatedInitializer]
		[Export ("initWithFloat:")]
		public extern static NativeHandle Constructor (float /* float, not CGFloat */ value);

		[DesignatedInitializer]
		[Export ("initWithDouble:")]
		public extern static NativeHandle Constructor (double value);

		[DesignatedInitializer]
		[Export ("initWithBool:")]
		public extern static NativeHandle Constructor (bool value);

		[DesignatedInitializer]
		[Export ("initWithInteger:")]
		public extern static NativeHandle Constructor (nint value);

		[DesignatedInitializer]
		[Export ("initWithUnsignedInteger:")]
		public extern static NativeHandle Constructor (nuint value);

		[Export ("numberWithChar:")]
		[Static]
		public extern static NSNumber FromSByte (sbyte value);

		[Static]
		[Export ("numberWithUnsignedChar:")]
		public extern static NSNumber FromByte (byte value);

		[Static]
		[Export ("numberWithShort:")]
		public extern static NSNumber FromInt16 (short value);

		[Static]
		[Export ("numberWithUnsignedShort:")]
		public extern static NSNumber FromUInt16 (ushort value);

		[Static]
		[Export ("numberWithInt:")]
		public extern static NSNumber FromInt32 (int /* int, not NSInteger */ value);

		[Static]
		[Export ("numberWithUnsignedInt:")]
		public extern static NSNumber FromUInt32 (uint /* unsigned int, not NSUInteger */ value);

		[Static]
		[Export ("numberWithLong:")]
		public extern static NSNumber FromLong (nint value);
		//
		[Static]
		[Export ("numberWithUnsignedLong:")]
		public extern static NSNumber FromUnsignedLong (nuint value);

		[Static]
		[Export ("numberWithLongLong:")]
		public extern static NSNumber FromInt64 (long value);

		[Static]
		[Export ("numberWithUnsignedLongLong:")]
		public extern static NSNumber FromUInt64 (ulong value);

		[Static]
		[Export ("numberWithFloat:")]
		public extern static NSNumber FromFloat (float /* float, not CGFloat */ value);

		[Static]
		[Export ("numberWithDouble:")]
		public extern static NSNumber FromDouble (double value);

		[Static]
		[Export ("numberWithBool:")]
		public extern static NSNumber FromBoolean (bool value);

		[Static]
		[Export ("numberWithInteger:")]
		public extern static NSNumber FromNInt (nint value);

		[Static]
		[Export ("numberWithUnsignedInteger:")]
		public extern static NSNumber FromNUInt (nuint value);
	}
}
