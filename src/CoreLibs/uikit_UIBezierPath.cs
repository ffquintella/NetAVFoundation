#region USING
//
// This file describes the API that the generator will produce
//
// Authors:
//   Geoff Norton
//   Miguel de Icaza
//   Alex Soto <alexsoto@microsoft.com>
//
// Copyright 2009-2011, Novell, Inc.
// Copyrigh 2011-2013, Xamarin Inc.
// Copyrigh 2019, Microsoft Corporation.
//
using ObjCRuntime;
using Foundation;
using CoreGraphics;
//using CoreLocation;
using UIKit;
//using CloudKit;
#if !TVOS
//using Contacts;
#else
using CNContact = System.Object;
#endif
//using MediaPlayer;
using CoreImage;
using CoreAnimation;
//using CoreData;
//using UserNotifications;
using UniformTypeIdentifiers;
//using Symbols;

#if IOS
using FileProvider;
using LinkPresentation;
#endif // IOS
#if TVOS
using LPLinkMetadata = Foundation.NSObject;
#endif // TVOS
//using Intents;

// Unfortunately this file is a mix of #if's andso we list
// some classes untilis used instead of #if's directives
// to avoid the usage of more #if's

#if !IOS
using UIPointerAccessoryPosition = Foundation.NSObject;
#endif // !IOS

#if __MACCATALYST__
using AppKit;
#else
using NSTouchBarProvider = Foundation.NSObject;
using NSTouchBar = Foundation.NSObject;
using NSToolbar = Foundation.NSObject;
using NSToolbarItem = Foundation.NSObject;
#endif

#if !NET
using NSWritingDirection = UIKit.UITextWritingDirection;
#endif

using System;
using System.ComponentModel;
using CoreLibs;

#if !NET
using NativeHandle = System.IntPtr;
#endif

#nullable enable

#endregion

namespace UIKit
{
	/*
	// NSUInteger -> UIPopoverController.h
	[Native]
	[Flags]
	public enum UIRectCorner : ulong {
		TopLeft = 1 << 0,
		TopRight = 1 << 1,
		BottomLeft = 1 << 2,
		BottomRight = 1 << 3,
		AllCorners = ~(ulong) 0
	}
	*/
	
	[BaseType (typeof (NSObject))]
	[ThreadSafe]
	[DisableDefaultCtor] // designated
	public class UIBezierPath : NSCopying {

		[DesignatedInitializer]
		[Export ("init")]
		public extern NativeHandle Constructor ();

		// initWithFrame: --> unrecognized selector

		[Export ("bezierPath"), Static]
		public extern UIBezierPath Create ();

		[Export ("bezierPathWithArcCenter:radius:startAngle:endAngle:clockwise:"), Static]
		public extern UIBezierPath FromArc (CGPoint center, nfloat radius, nfloat startAngle, nfloat endAngle, bool clockwise);

		[Export ("bezierPathWithCGPath:"), Static]
		public extern UIBezierPath FromPath (CGPath path);

		[Export ("bezierPathWithOvalInRect:"), Static]
		public extern UIBezierPath FromOval (CGRect inRect);

		[Export ("bezierPathWithRect:"), Static]
		public extern UIBezierPath FromRect (CGRect rect);

		[Export ("bezierPathWithRoundedRect:byRoundingCorners:cornerRadii:"), Static]
		public extern UIBezierPath FromRoundedRect (CGRect rect, UIRectCorner corners, CGSize radii);

		[Export ("bezierPathWithRoundedRect:cornerRadius:"), Static]
		public extern UIBezierPath FromRoundedRect (CGRect rect, nfloat cornerRadius);

		[Export ("CGPath")]
		[NullAllowed]
		public extern CGPath CGPath { get; set; }

		[Export ("moveToPoint:")]
		public extern void MoveTo (CGPoint point);

		[Export ("addLineToPoint:")]
		public extern void AddLineTo (CGPoint point);

		[Export ("addCurveToPoint:controlPoint1:controlPoint2:")]
		public extern void AddCurveToPoint (CGPoint endPoint, CGPoint controlPoint1, CGPoint controlPoint2);

		[Export ("addQuadCurveToPoint:controlPoint:")]
		public extern void AddQuadCurveToPoint (CGPoint endPoint, CGPoint controlPoint);

		[Export ("closePath")]
		public extern void ClosePath ();

		[Export ("removeAllPoints")]
		public extern void RemoveAllPoints ();

		[Export ("appendPath:")]
		public extern void AppendPath (UIBezierPath path);

		[Export ("applyTransform:")]
		public extern void ApplyTransform (CGAffineTransform transform);

		[Export ("empty")]
		public extern bool Empty { [Bind ("isEmpty")] get; }

		[Export ("bounds")]
		public extern CGRect Bounds { get; }

		[Export ("currentPoint")]
		public extern CGPoint CurrentPoint { get; }

		[Export ("containsPoint:")]
		public extern bool ContainsPoint (CGPoint point);


		[Export ("lineWidth")]
		public extern nfloat LineWidth { get; set; }

		[Export ("lineCapStyle")]
		public extern CGLineCap LineCapStyle { get; set; }

		[Export ("lineJoinStyle")]
		public extern CGLineJoin LineJoinStyle { get; set; }

		[Export ("miterLimit")]
		public extern nfloat MiterLimit { get; set; }

		[Export ("flatness")]
		public extern nfloat Flatness { get; set; }

		[Export ("usesEvenOddFillRule")]
		public extern bool UsesEvenOddFillRule { get; set; }

		[Export ("fill")]
		public extern void Fill ();

		[Export ("stroke")]
		public extern void Stroke ();

		[Export ("fillWithBlendMode:alpha:")]
		public extern void Fill (CGBlendMode blendMode, nfloat alpha);

		[Export ("strokeWithBlendMode:alpha:")]
		public extern void Stroke (CGBlendMode blendMode, nfloat alpha);

		[Export ("addClip")]
		public extern void AddClip ();

		[Internal]
		[Export ("getLineDash:count:phase:")]
		public extern void _GetLineDash (IntPtr pattern, out nint count, out nfloat phase);

		[Internal, Export ("setLineDash:count:phase:")]
		public extern void SetLineDash (IntPtr fvalues, nint count, nfloat phase);

		[Export ("addArcWithCenter:radius:startAngle:endAngle:clockwise:")]
		public extern void AddArc (CGPoint center, nfloat radius, nfloat startAngle, nfloat endAngle, bool clockWise);

		[Export ("bezierPathByReversingPath")]
		public extern UIBezierPath BezierPathByReversingPath ();
	}

}