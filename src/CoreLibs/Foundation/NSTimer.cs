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
// Copyright 2011-2014 Xamarin Inc.
//
using System;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;
using CoreLibs;
using ObjCRuntime;

namespace Foundation {

	public partial class NSTimer {

		// The right selector signature is:
		//		- (void)timerFireMethod:(NSTimer *)timer
		// which does not match the (old) API we were provided
		public static NSTimer CreateRepeatingScheduledTimer (TimeSpan when, Action<NSTimer> action)
		{
			return CreateScheduledTimer (when.TotalSeconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, true);
		}

		public static NSTimer CreateRepeatingScheduledTimer (double seconds, Action<NSTimer> action)
		{
			return CreateScheduledTimer (seconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, true);
		}

		public static NSTimer CreateScheduledTimer (TimeSpan when, Action<NSTimer> action)
		{
			return CreateScheduledTimer (when.TotalSeconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, false);
		}

		public static NSTimer CreateScheduledTimer (double seconds, Action<NSTimer> action)
		{
			return CreateScheduledTimer (seconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, false);
		}

		public static NSTimer CreateRepeatingTimer (TimeSpan when, Action<NSTimer> action)
		{
			return CreateTimer (when.TotalSeconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, true);
		}

		public static NSTimer CreateRepeatingTimer (double seconds, Action<NSTimer> action)
		{
			return CreateTimer (seconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, true);
		}

		public static NSTimer CreateTimer (TimeSpan when, Action<NSTimer> action)
		{
			return CreateTimer (when.TotalSeconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, false);
		}

		public static NSTimer CreateTimer (double seconds, Action<NSTimer> action)
		{
			return CreateTimer (seconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, false);
		}

		public NSTimer (NSDate date, TimeSpan when, Action<NSTimer> action, System.Boolean repeats)
			: this (date, when.TotalSeconds, new NSTimerActionDispatcher (action), NSTimerActionDispatcher.Selector, null, repeats)
		{
		}

		public NSTimer(NSDate date, double seconds, NSObject target, Selector selector, [NullAllowed] NSObject userInfo,
			bool repeats)
		{
			Handle = Constructor(date, seconds, target, selector, userInfo, repeats);
		}

	}
	
	[BaseType (typeof (NSObject))]
	//[Dispose ("if (disposing) { Invalidate (); } ", Optimizable = true)]
	// init returns NIL
	[DisableDefaultCtor]
	partial class NSTimer: NSObject {

		[Static, Export ("scheduledTimerWithTimeInterval:target:selector:userInfo:repeats:")]
		public static extern NSTimer CreateScheduledTimer (double seconds, NSObject target, Selector selector, [NullAllowed] NSObject userInfo, bool repeats);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("scheduledTimerWithTimeInterval:repeats:block:")]
		public static extern NSTimer CreateScheduledTimer (double interval, bool repeats, Action<NSTimer> block);

		[Static, Export ("timerWithTimeInterval:target:selector:userInfo:repeats:")]
		public static extern NSTimer CreateTimer (double seconds, NSObject target, Selector selector, [NullAllowed] NSObject userInfo, bool repeats);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("timerWithTimeInterval:repeats:block:")]
		public static extern NSTimer CreateTimer (double interval, bool repeats, Action<NSTimer> block);

		[DesignatedInitializer]
		[Export ("initWithFireDate:interval:target:selector:userInfo:repeats:")]
		public static extern NativeHandle Constructor (NSDate date, double seconds, NSObject target, Selector selector, [NullAllowed] NSObject userInfo, bool repeats);

		[MacCatalyst (13, 1)]
		[Export ("initWithFireDate:interval:repeats:block:")]
		public static extern NativeHandle Constructor (NSDate date, double seconds, bool repeats, Action<NSTimer> block);

		[Export ("fire")]
		public extern void Fire ();

		[NullAllowed] // by default this property is null
		[Export ("fireDate", ArgumentSemantic.Copy)]
		public extern NSDate FireDate { get; set; }

		// Note: preserving this member allows us to re-enable the `Optimizable` binding flag
		[Preserve (Conditional = true)]
		[Export ("invalidate")]
		public extern void Invalidate ();

		[Export ("isValid")]
		public extern bool IsValid { get; }

		[Export ("timeInterval")]
		public extern double TimeInterval { get; }

		[Export ("userInfo")]
		public extern NSObject UserInfo { get; }

		[MacCatalyst (13, 1)]
		[Export ("tolerance")]
		public extern double Tolerance { get; set; }
	}
	
}
