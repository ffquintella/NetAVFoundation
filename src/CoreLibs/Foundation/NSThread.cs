//
// Copyright 2012 Xamarin Inc
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
using System.Runtime.InteropServices;
using CoreLibs;
using ObjCRuntime;

namespace Foundation {

	public partial class NSThread {

		public NSThread() : base(IntPtr.Zero)
		{
		}

		public static double Priority {
			get { return _GetPriority (); }
			// ignore the boolean return value
			set { _SetPriority (value); }
		}

		[DllImport ("__Internal")]
		static extern IntPtr xamarin_init_nsthread (IntPtr handle, byte is_direct_binding, IntPtr target, IntPtr selector, IntPtr argument);

		IntPtr InitNSThread (NSObject target, Selector selector, NSObject argument)
		{
			if (target is null)
				throw new ArgumentNullException ("target");
			if (selector is null)
				throw new ArgumentNullException ("selector");

			return xamarin_init_nsthread (IsDirectBinding ? this.Handle : this.SuperHandle, IsDirectBinding.AsByte (), target.Handle, selector.Handle, argument is null ? IntPtr.Zero : argument.Handle);
		}

		[Export ("initWithTarget:selector:object:")]
		public NSThread (NSObject target, Selector selector, NSObject argument)
			: base ()
		{
			Handle = InitNSThread (target, selector, argument);
		}
	}
	
	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	public partial class NSThread : NSObject {
		[Static, Export ("currentThread", ArgumentSemantic.Strong)]
		public static extern NSThread Current { get; }

		[Static, Export ("callStackSymbols", ArgumentSemantic.Copy)]
		public static extern string [] NativeCallStack { get; }

		//+ (void)detachNewThreadSelector:(SEL)selector toTarget:(id)target withObject:(id)argument;

		[Static, Export ("isMultiThreaded")]
		public static extern bool IsMultiThreaded { get; }

		//- (NSMutableDictionary *)threadDictionary;

		[Static, Export ("sleepUntilDate:")]
		public static extern void SleepUntil (NSDate date);

		[Static, Export ("sleepForTimeInterval:")]
		public static extern void SleepFor (double timeInterval);

		[Static, Export ("exit")]
		public static extern void Exit ();

		[Static, Export ("threadPriority"), Internal]
		public static extern double _GetPriority ();

		[Static, Export ("setThreadPriority:"), Internal]
		public static extern bool _SetPriority (double priority);

		//+ (NSArray *)callStackReturnAddresses;

		[NullAllowed] // by default this property is null
		[Export ("name")]
		public extern string? Name { get; set; }

		[Export ("stackSize")]
		public extern nuint StackSize { get; set; }

		[Export ("isMainThread")]
		public extern bool IsMainThread { get; }

		// MainThread is already used for the instance selector and we can't reuse the same name
		[Static]
		[Export ("isMainThread")]
		public static extern bool IsMain { get; }

		[Static]
		[Export ("mainThread", ArgumentSemantic.Strong)]
		public static extern NSThread MainThread { get; }

		[Export ("isExecuting")]
		public extern bool IsExecuting { get; }

		[Export ("isFinished")]
		public extern bool IsFinished { get; }

		[Export ("isCancelled")]
		public extern bool IsCancelled { get; }

		[Export ("cancel")]
		public extern void Cancel ();

		[Export ("start")]
		public extern void Start ();

		[Export ("main")]
		public extern void Main ();

		[MacCatalyst (13, 1)]
		[Export ("qualityOfService")]
		public extern NSQualityOfService QualityOfService { get; set; }

		[Notification]
		[Field ("NSThreadWillExitNotification")]
		public extern NSString ThreadWillExitNotification { get; }

		[Notification]
		[Field ("NSWillBecomeMultiThreadedNotification")]
		public extern NSString WillBecomeMultiThreadedNotification { get; }
	}
}
