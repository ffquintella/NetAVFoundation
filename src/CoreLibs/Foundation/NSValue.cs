//
// Copyright 2010, Novell, Inc.
// Copyright 2011, 2012, 2013 Xamarin Inc
// Copyright 2019 Microsoft Corporation
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
#if !NO_SYSTEM_DRAWING
using System.Drawing;
#endif
using System.Runtime.InteropServices;

using CoreGraphics;
using CoreLibs;
using CoreMedia;
using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {
	public partial class NSValue  {
#if !COREBUILD
		public string ObjCType {
			get {
				return Marshal.PtrToStringAnsi (ObjCTypePtr ());
			}
		}

#if !NO_SYSTEM_DRAWING
		public static NSValue FromRectangleF (RectangleF rect)
		{
			return FromCGRect (rect);
		}

		public static NSValue FromSizeF (SizeF size)
		{
			return FromCGSize (size);
		}

		public static NSValue FromPointF (PointF point)
		{
			return FromCGPoint (point);
		}

		public RectangleF RectangleFValue {
			get { return (RectangleF) CGRectValue; }
		}

		public SizeF SizeFValue {
			get { return (SizeF) CGSizeValue; }
		}

		public PointF PointFValue {
			get { return (PointF) CGPointValue; }
		}
#endif

#if MONOMAC
		// @encode(CGAffineTransform) -> "{CGAffineTransform=dddddd}" but...
		// using a C string crash on macOS (while it works fine on iOS)
		[DllImport ("__Internal")]
		extern static IntPtr xamarin_encode_CGAffineTransform ();

		/*
		// The `+valueWithCGAffineTransform:` selector comes from UIKit and is not available on macOS
		public unsafe static NSValue FromCGAffineTransform (CGAffineTransform tran)
		{
			return Create ((IntPtr) (void*) &tran, xamarin_encode_CGAffineTransform ());
		}
		*/

		/*
		// The `CGAffineTransformValue` selector comes from UIKit and is not available on macOS
		public unsafe virtual CGAffineTransform CGAffineTransformValue {
			get {
				var result = new CGAffineTransform ();
				// avoid potential buffer overflow since we use the older `getValue:` API to cover all platforms
				// and we can cheat here with the actual string comparison (since we are the one doing it)
				if (ObjCType == "{CGAffineTransform=dddddd}")
					StoreValueAtAddress ((IntPtr) (void*) &result);
				return result;
			}
		}
		*/
#endif
#endif
	}
	
	[BaseType (typeof (NSObject))]
	// init returns NIL
	[DisableDefaultCtor]
	public partial class NSValue : NSCopying
	{
		public NSValue()
		{
			Handle = IntPtr.Zero;
		}
		
		public NSValue(NativeHandle handle) : base(handle)
		{}

		public NSValue(NativeHandle handle, bool owns) : base(handle, owns)
		{
			
		}
		
		//[Deprecated (PlatformName.MacOSX, 10, 13, message: "Potential for buffer overruns. Use 'StoreValueAtAddress (IntPtr, nuint)' instead.")]
		//[Deprecated (PlatformName.iOS, 11, 0, message: "Potential for buffer overruns. Use 'StoreValueAtAddress (IntPtr, nuint)' instead.")]
	//	[Deprecated (PlatformName.TvOS, 11, 0, message: "Potential for buffer overruns. Use 'StoreValueAtAddress (IntPtr, nuint)' instead.")]
		//[Deprecated (PlatformName.WatchOS, 4, 0, message: "Potential for buffer overruns. Use 'StoreValueAtAddress (IntPtr, nuint)' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Potential for buffer overruns. Use 'StoreValueAtAddress (IntPtr, nuint)' instead.")]
		[Export ("getValue:")]
		public extern void StoreValueAtAddress (IntPtr value);

		[MacCatalyst (13, 1)]
		[Export ("getValue:size:")]
		public extern void StoreValueAtAddress (IntPtr value, nuint size);

		[Export ("objCType")]
		[Internal]
		public extern IntPtr ObjCTypePtr ();

		//[Export ("initWithBytes:objCType:")][Internal]
		//NSValue InitFromBytes (IntPtr byte_ptr, IntPtr char_ptr_type);

		[Static]
		[Internal]
		[Export ("valueWithBytes:objCType:")]
		public extern static NSValue Create (IntPtr bytes, IntPtr objCType);

		[Static]
		[Export ("valueWithNonretainedObject:")]
		public extern static NSValue ValueFromNonretainedObject (NSObject anObject);

		[Export ("nonretainedObjectValue")]
		public extern NSObject NonretainedObjectValue { get; }

		[Static]
		[Export ("valueWithPointer:")]
		public extern static NSValue ValueFromPointer (IntPtr pointer);

		[Export ("pointerValue")]
		public extern IntPtr PointerValue { get; }

		[Export ("isEqualToValue:")]
		public extern bool IsEqualTo (NSValue value);

		[Export ("valueWithRange:")]
		[Static]
		public static extern NSValue FromRange (NSRange range);

		[Export ("rangeValue")]
		public extern NSRange RangeValue { get; }

		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Static, Export ("valueWithCMTime:")]
		public static extern NSValue FromCMTime (CMTime time);

		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Export ("CMTimeValue")]
		public extern CMTime CMTimeValue { get; }

		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Static, Export ("valueWithCMTimeMapping:")]
		public static extern NSValue FromCMTimeMapping (CMTimeMapping timeMapping);

		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Export ("CMTimeMappingValue")]
		public extern CMTimeMapping CMTimeMappingValue { get; }

		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Static, Export ("valueWithCMTimeRange:")]
		public static extern NSValue FromCMTimeRange (CMTimeRange timeRange);

		[Watch (6, 0)]
		[MacCatalyst (13, 1)]
		[Export ("CMTimeRangeValue")]
		public extern CMTimeRange CMTimeRangeValue { get; }

#if MONOMAC
		[Export ("valueWithRect:")]
#else
		[Export ("valueWithCGRect:")]
#endif
		[Static]
		public static extern NSValue FromCGRect (CGRect rect);

#if MONOMAC
		[Export ("valueWithSize:")]
#else
		[Export ("valueWithCGSize:")]
#endif
		[Static]
		public static extern NSValue FromCGSize (CGSize size);

#if MONOMAC
		[Export ("valueWithPoint:")]
#else
		[Export ("valueWithCGPoint:")]
#endif
		[Static]
		public static extern NSValue FromCGPoint (CGPoint point);

		[MacCatalyst (15, 0)]
#if MONOMAC
		[Export ("rectValue")]
#else
		[Export ("CGRectValue")]
#endif
		public extern CGRect CGRectValue { get; }

		[MacCatalyst (15, 0)]
#if MONOMAC
		[Export ("sizeValue")]
#else
		[Export ("CGSizeValue")]
#endif
		public extern CGSize CGSizeValue { get; }

		[MacCatalyst (15, 0)]
#if MONOMAC
		[Export ("pointValue")]
#else
		[Export ("CGPointValue")]
#endif
		public extern CGPoint CGPointValue { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("CGAffineTransformValue")]
		public CoreGraphics.CGAffineTransform CGAffineTransformValue { get; }

		/*
		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("UIEdgeInsetsValue")]
		public extern UIEdgeInsets UIEdgeInsetsValue { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("directionalEdgeInsetsValue")]
		public extern NSDirectionalEdgeInsets DirectionalEdgeInsetsValue { get; }
		*/
		
		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("valueWithCGAffineTransform:")]
		[Static]
		public extern static NSValue FromCGAffineTransform (CoreGraphics.CGAffineTransform tran);

		/*
		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("valueWithUIEdgeInsets:")]
		[Static]
		public extern NSValue FromUIEdgeInsets (UIEdgeInsets insets);

		[NoMac]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("valueWithDirectionalEdgeInsets:")]
		public extern NSValue FromDirectionalEdgeInsets (NSDirectionalEdgeInsets insets);

		[Export ("valueWithUIOffset:")]
		[Static]
		[NoMac]
		[MacCatalyst (13, 1)]
		public extern NSValue FromUIOffset (UIOffset insets);
		

		[Export ("UIOffsetValue")]
		[NoMac]
		[MacCatalyst (13, 1)]
		public extern UIOffset UIOffsetValue { get; }
		// from UIGeometry.h - those are in iOS8 only (even if the header is silent about them)
		// and not in OSX 10.10
		*/

		[Export ("CGVectorValue")]
		[NoMac]
		[MacCatalyst (13, 1)]
		public extern CGVector CGVectorValue { get; }

		[Static, Export ("valueWithCGVector:")]
		[NoMac]
		[MacCatalyst (13, 1)]
		public extern static NSValue FromCGVector (CGVector vector);

		// Maybe we should include this inside mapkit.cs instead (it's a partial interface, so that's trivial)?
		//[MacCatalyst (13, 1)]
		//[Static, Export ("valueWithMKCoordinate:")]
		//public extern static NSValue FromMKCoordinate (CoreLocation.CLLocationCoordinate2D coordinate);

		[MacCatalyst (13, 1)]
		[Static, Export ("valueWithMKCoordinateSpan:")]
		public extern static NSValue FromMKCoordinateSpan (MapKit.MKCoordinateSpan coordinateSpan);

		//[MacCatalyst (13, 1)]
		//[Export ("MKCoordinateValue")]
		//public extern CoreLocation.CLLocationCoordinate2D CoordinateValue { get; }

		[MacCatalyst (13, 1)]
		[Export ("MKCoordinateSpanValue")]
		public extern MapKit.MKCoordinateSpan CoordinateSpanValue { get; }

		/* SEE IF WE NEED
#if !WATCH
		[Export ("valueWithCATransform3D:")]
		[Static]
		public extern NSValue FromCATransform3D (CoreAnimation.CATransform3D transform);

		[Export ("CATransform3DValue")]
		public extern CoreAnimation.CATransform3D CATransform3DValue { get; }
#endif
*/

		//[iOS (16, 0)]
		//[Mac (13, 0)]
		[MacCatalyst (16, 0)]
		[TV (16, 0)]
		[Watch (9, 0)]
		[Export ("CMVideoDimensionsValue")]
		public CMVideoDimensions CMVideoDimensionsValue { get; }

		//[iOS (16, 0)]
		//[Mac (13, 0)]
		[MacCatalyst (16, 0)]
		[TV (16, 0)]
		[Watch (9, 0)]
		[Export ("valueWithCMVideoDimensions:")]
		[Static]
		public static extern  NSValue FromCMVideoDimensions (CMVideoDimensions value);

		/*
		#region SceneKit Additions

		[MacCatalyst (13, 1)]
		[Static, Export ("valueWithSCNVector3:")]
		public static extern NSValue FromVector (SCNVector3 vector);

		[MacCatalyst (13, 1)]
		[Export ("SCNVector3Value")]
		public static extern  SCNVector3 Vector3Value { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("valueWithSCNVector4:")]
		public NSValue extern FromVector (SCNVector4 vector);

		[MacCatalyst (13, 1)]
		[Export ("SCNVector4Value")]
		public extern SCNVector4 Vector4Value { get; }

		[MacCatalyst (13, 1)]
		[Static, Export ("valueWithSCNMatrix4:")]
		public static extern NSValue FromSCNMatrix4 (SCNMatrix4 matrix);

		[MacCatalyst (13, 1)]
		[Export ("SCNMatrix4Value")]
		public extern SCNMatrix4 SCNMatrix4Value { get; }

		#endregion
		*/
	}

	[BaseType (typeof (NSObject))]
	//[Abstract] // Apple docs: NSValueTransformer is an abstract class...
	public abstract partial class NSValueTransformer: NSObject {
		[Static]
		[Export ("setValueTransformer:forName:")]
		public static extern void SetValueTransformer ([NullAllowed] NSValueTransformer transformer, string name);

		[Static]
		[Export ("valueTransformerForName:")]
		[return: NullAllowed]
		public static extern NSValueTransformer GetValueTransformer (string name);

		[Static]
		[Export ("valueTransformerNames")]
		public static extern string [] ValueTransformerNames { get; }

		[Static]
		[Export ("transformedValueClass")]
		public static extern Class TransformedValueClass { get; }

		[Static]
		[Export ("allowsReverseTransformation")]
		public static extern bool AllowsReverseTransformation { get; }

		[Export ("transformedValue:")]
		[return: NullAllowed]
		public extern NSObject TransformedValue ([NullAllowed] NSObject value);

		[Export ("reverseTransformedValue:")]
		[return: NullAllowed]
		public extern NSObject ReverseTransformedValue ([NullAllowed] NSObject value);

#if IOS && !NET
		[Notification]
		[Obsolete ("Use 'NSUserDefaults.SizeLimitExceededNotification' instead.")]
		[Field ("NSUserDefaultsSizeLimitExceededNotification")]
		NSString SizeLimitExceededNotification { get; }

		[Notification]
		[Obsolete ("Use 'NSUserDefaults.DidChangeAccountsNotification' instead.")]
		[Field ("NSUbiquitousUserDefaultsDidChangeAccountsNotification")]
		NSString DidChangeAccountsNotification { get; }

		[Notification]
		[Obsolete ("Use 'NSUserDefaults.CompletedInitialSyncNotification' instead.")]
		[Field ("NSUbiquitousUserDefaultsCompletedInitialSyncNotification")]
		NSString CompletedInitialSyncNotification { get; }

		[Notification]
		[Obsolete ("Use 'NSUserDefaults.DidChangeNotification' instead.")]
		[Field ("NSUserDefaultsDidChangeNotification")]
		NSString UserDefaultsDidChangeNotification { get; }
#endif

		[Field ("NSNegateBooleanTransformerName")]
		public extern NSString BooleanTransformerName { get; }

		[Field ("NSIsNilTransformerName")]
		public extern NSString IsNilTransformerName { get; }

		[Field ("NSIsNotNilTransformerName")]
		public extern NSString IsNotNilTransformerName { get; }

		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		[Field ("NSUnarchiveFromDataTransformerName")]
		public extern NSString UnarchiveFromDataTransformerName { get; }

		//[Deprecated (PlatformName.TvOS, 12, 0, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		//[Deprecated (PlatformName.WatchOS, 5, 0, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		//[Deprecated (PlatformName.iOS, 12, 0, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		//[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'SecureUnarchiveFromDataTransformerName' instead.")]
		[Field ("NSKeyedUnarchiveFromDataTransformerName")]
		public extern NSString KeyedUnarchiveFromDataTransformerName { get; }

		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		[Field ("NSSecureUnarchiveFromDataTransformerName")]
		public extern NSString SecureUnarchiveFromDataTransformerName { get; }
	}
}
