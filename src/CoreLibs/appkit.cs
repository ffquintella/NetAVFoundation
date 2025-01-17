// Copyright 2011-2012 Xamarin, Inc.
// Copyright 2010, 2011, Novell, Inc.
// Copyright 2010, Kenneth Pouncey
// Coprightt 2010, James Clancey
// Copyright 2011, Curtis Wensley
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
// appkit.cs: Definitions for AppKit
//

// TODO: turn NSAnimatablePropertyCOntainer into a system similar to UIAppearance

using System;
using System.Diagnostics;
using System.ComponentModel;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreFoundation;
using CoreImage;
using CoreAnimation;
using CoreData;
using Intents;
using SharedWithYouCore;
using Symbols;
#if !__MACCATALYST__
using OpenGL;
#endif
using CoreVideo;
using CloudKit;
using UniformTypeIdentifiers;

#if __MACCATALYST__
using UIKit;
#else
using UIMenu = Foundation.NSObject;
using UIMenuElement = Foundation.NSObject;
#endif

using CGGlyph = System.UInt16;
#if __MACCATALYST__
using CAOpenGLLayer = Foundation.NSObject;
using CGLContext = Foundation.NSObject;
using CGLPixelFormat = Foundation.NSObject;
using Color = UIKit.UIColor;
using NSColorList = Foundation.NSObject;
#else
using Color = AppKit.NSColor;
using IUIActivityItemsConfigurationReading = System.Object;
using UIBarButtonItem = Foundation.NSObject;
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace AppKit {
	//[BaseType (typeof (NSObject))]
	//interface CIImage {
	//	[Export ("drawInRect:fromRect:operation:fraction:")]
	//	void Draw (CGRect inRect, CGRect fromRect, NSCompositingOperation operation, float fractionDelta);
	//
	//	[Export ("drawAtPoint:fromRect:operation:fraction:")]
	//	void DrawAtPoint (CGPoint atPoint, CGRect fromRect, NSCompositingOperation operation, float fractionDelta);
	//}

	[Native]
	[Mac (15, 0), MacCatalyst (18, 0)]
	enum NSCursorFrameResizePosition : ulong {
		Top = (1 << 0),
		Left = (1 << 1),
		Bottom = (1 << 2),
		Right = (1 << 3),
		TopLeft = (Top | Left),
		TopRight = (Top | Right),
		BottomLeft = (Bottom | Left),
		BottomRight = (Bottom | Right),
	}

	[Native]
	[Mac (15, 0), MacCatalyst (18, 0)]
	enum NSCursorFrameResizeDirections : ulong {
		Inward = (1 << 0),
		Outward = (1 << 1),
		All = (Inward | Outward),
	}

	[Native]
	[Mac (15, 0), MacCatalyst (18, 0)]
	enum NSHorizontalDirections : ulong {
		Left = (1 << 0),
		Right = (1 << 1),
		All = (Left | Right),
	}

	[Native]
	[Mac (15, 0), MacCatalyst (18, 0)]
	enum NSVerticalDirections : ulong {
		Up = (1 << 0),
		Down = (1 << 1),
		All = (Up | Down),
	}

	[Native]
	[Mac (15, 0), NoMacCatalyst]
	enum NSSharingCollaborationMode : long {
		SendCopy,
		Collaborate,
	}





	[NoMacCatalyst]
	[BaseType (typeof (NSCell))]
	interface NSActionCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("target", ArgumentSemantic.Weak), NullAllowed]
		NSObject Target { get; set; }

		[Export ("action"), NullAllowed]
		Selector Action { get; set; }

		[Export ("tag")]
		nint Tag { get; set; }

	}

	[MacCatalyst (13, 1)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSAlignmentFeedbackToken {
	}

	interface INSAlignmentFeedbackToken { }

	// @interface NSAlignmentFeedbackFilter : NSObject
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSAlignmentFeedbackFilter {
		[Static]
		[Export ("inputEventMask")]
		NSEventMask InputEventMask { get; }

		[Export ("updateWithEvent:")]
		void Update (NSEvent theEvent);

		[Export ("updateWithPanRecognizer:")]
		void Update (NSPanGestureRecognizer panRecognizer);

		[Export ("alignmentFeedbackTokenForMovementInView:previousPoint:alignedPoint:defaultPoint:")]
		[return: NullAllowed]
		INSAlignmentFeedbackToken GetTokenForMovement ([NullAllowed] NSView view, CGPoint previousPoint, CGPoint alignedPoint, CGPoint defaultPoint);

		[Export ("alignmentFeedbackTokenForHorizontalMovementInView:previousX:alignedX:defaultX:")]
		[return: NullAllowed]
		INSAlignmentFeedbackToken GetTokenForHorizontalMovement ([NullAllowed] NSView view, nfloat previousX, nfloat alignedX, nfloat defaultX);

		[Export ("alignmentFeedbackTokenForVerticalMovementInView:previousY:alignedY:defaultY:")]
		[return: NullAllowed]
		INSAlignmentFeedbackToken GetTokenForVerticalMovement ([NullAllowed] NSView view, nfloat previousY, nfloat alignedY, nfloat defaultY);

		[Export ("performFeedback:performanceTime:")]
		void PerformFeedback (INSAlignmentFeedbackToken [] tokens, NSHapticFeedbackPerformanceTime performanceTime);
	}

	//
	// Inlined, not really an object implementation
	//
	interface NSAnimatablePropertyContainer {
		[Export ("animator")]
		NSObject Animator { [return: Proxy] get; }

		[Export ("animations")]
		NSDictionary Animations { get; set; }

		[Export ("animationForKey:")]
		NSObject AnimationFor (NSString key);

		[Static, Export ("defaultAnimationForKey:")]
		NSObject DefaultAnimationFor (NSString key);
	}

	interface NSAnimationProgressMarkEventArgs {
		[Export ("NSAnimationProgressMark")]
		float Progress { get; } /* float, not CGFloat */
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSAnimationDelegate) })]
	interface NSAnimation : NSCoding, NSCopying {
#if NET
		[DesignatedInitializer]
#endif
		[Export ("initWithDuration:animationCurve:")]
#if !NET
		[Sealed] // Just to avoid the duplicate selector error
#endif
		NativeHandle Constructor (double duration, NSAnimationCurve animationCurve);

#if !NET
		[Obsolete ("Use the constructor instead.")]
		[Export ("initWithDuration:animationCurve:")]
		IntPtr Constant (double duration, NSAnimationCurve animationCurve);
#endif

		[Export ("startAnimation")]
		void StartAnimation ();

		[Export ("stopAnimation")]
		void StopAnimation ();

		[Export ("isAnimating")]
		bool IsAnimating ();

		[Export ("currentProgress")]
		float CurrentProgress { get; set; } /* NSAnimationProgress = float */

		[Export ("duration")]
		double Duration { get; set; }

		[Export ("animationBlockingMode")]
		NSAnimationBlockingMode AnimationBlockingMode { get; set; }

		[Export ("frameRate")]
		float FrameRate { get; set; } /* float, not CGFloat */

		[Export ("animationCurve")]
		NSAnimationCurve AnimationCurve { get; set; }

		[Export ("currentValue")]
		float CurrentValue { get; } /* float, not CGFloat */

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSAnimationDelegate Delegate { get; set; }

		[Export ("progressMarks", ArgumentSemantic.Copy)]
		NSNumber [] ProgressMarks { get; set; }

		[Export ("addProgressMark:")]
		void AddProgressMark (float /* NSAnimationProgress = float */ progressMark);

		[Export ("removeProgressMark:")]
		void RemoveProgressMark (float /* NSAnimationProgress = float */ progressMark);

		[Export ("startWhenAnimation:reachesProgress:")]
		void StartWhenAnimationReaches (NSAnimation animation, float /* NSAnimationProgress = float */ startProgress);

		[Export ("stopWhenAnimation:reachesProgress:")]
		void StopWhenAnimationReaches (NSAnimation animation, float /* NSAnimationProgress = float */ stopProgress);

		[Export ("clearStartAnimation")]
		void ClearStartAnimation ();

		[Export ("clearStopAnimation")]
		void ClearStopAnimation ();

		[Export ("runLoopModesForAnimating")]
		NSString [] RunLoopModesForAnimating { get; }

		[Notification (typeof (NSAnimationProgressMarkEventArgs)), Field ("NSAnimationProgressMarkNotification")]
		NSString ProgressMarkNotification { get; }

		[Field ("NSAnimationProgressMark")]
		NSString ProgressMark { get; }

		[Field ("NSAnimationTriggerOrderIn")]
		NSString TriggerOrderIn { get; }

		[Field ("NSAnimationTriggerOrderOut")]
		NSString TriggerOrderOut { get; }
	}

	interface INSAnimationDelegate { }

	[NoiOS]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSAnimationDelegate {
		[Export ("animationShouldStart:"), DelegateName ("NSAnimationPredicate"), DefaultValue (true)]
		bool AnimationShouldStart (NSAnimation animation);

		[Export ("animationDidStop:"), EventArgs ("NSAnimation")]
		void AnimationDidStop (NSAnimation animation);

		[Export ("animationDidEnd:"), EventArgs ("NSAnimation")]
		void AnimationDidEnd (NSAnimation animation);

		[Export ("animation:valueForProgress:"), DelegateName ("NSAnimationProgress"), DefaultValueFromArgumentAttribute ("progress")]
		float /* float, not CGFloat */ ComputeAnimationCurve (NSAnimation animation, float /* NSAnimationProgress = float */ progress);

		[Export ("animation:didReachProgressMark:"), EventArgs ("NSAnimation")]
		void AnimationDidReachProgressMark (NSAnimation animation, float /* NSAnimationProgress = float */ progress);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface NSAnimationContext {
		[Static]
		[Export ("beginGrouping")]
		void BeginGrouping ();

		[Static]
		[Export ("endGrouping")]
		void EndGrouping ();

		[Static]
		[Export ("currentContext")]
		NSAnimationContext CurrentContext { get; }

		//Detected properties
		[Export ("duration")]
		double Duration { get; set; }

		[Export ("completionHandler", ArgumentSemantic.Copy)]
		Action CompletionHandler { get; set; }

		[Static]
		[Export ("runAnimationGroup:completionHandler:")]
		void RunAnimation (Action<NSAnimationContext> changes, [NullAllowed] Action completionHandler);

		[Static]
		[Export ("runAnimationGroup:")]
		void RunAnimation (Action<NSAnimationContext> changes);

		[Export ("timingFunction", ArgumentSemantic.Strong)]
		CAMediaTimingFunction TimingFunction { get; set; }

		[Export ("allowsImplicitAnimation")]
		bool AllowsImplicitAnimation { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSAlertDelegate) })]
	interface NSAlert {
		[Static, Export ("alertWithError:")]
		NSAlert WithError (NSError error);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use constructor instead.")]
		[Static, Export ("alertWithMessageText:defaultButton:alternateButton:otherButton:informativeTextWithFormat:")]
		NSAlert WithMessage ([NullAllowed] string message, [NullAllowed] string defaultButton, [NullAllowed] string alternateButton, [NullAllowed] string otherButton, string full);

		[Export ("messageText")]
		string MessageText { get; set; }

		[Export ("informativeText")]
		string InformativeText { get; set; }

		[Export ("icon", ArgumentSemantic.Retain)]
		NSImage Icon { get; set; }

		[Export ("addButtonWithTitle:")]
		NSButton AddButton (string title);

		[Export ("buttons")]
		NSButton [] Buttons { get; }

		[Export ("showsHelp")]
		bool ShowsHelp { get; set; }

		[Export ("helpAnchor")]
		string HelpAnchor { get; set; }

		[Export ("alertStyle")]
		NSAlertStyle AlertStyle { get; set; }

		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSAlertDelegate Delegate { get; set; }

		[Export ("showsSuppressionButton")]
		bool ShowsSuppressionButton { get; set; }

		[Export ("suppressionButton")]
		NSButton SuppressionButton { get; }

		[Export ("accessoryView", ArgumentSemantic.Retain), NullAllowed]
		NSView AccessoryView { get; set; }

		[Export ("layout")]
		void Layout ();

		[Export ("runModal")]
		nint RunModal ();

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use BeginSheetModalForWindow (NSWindow sheetWindow, Action<nint> handler) instead.")]
		[Export ("beginSheetModalForWindow:modalDelegate:didEndSelector:contextInfo:")]
		void BeginSheet ([NullAllowed] NSWindow window, [NullAllowed] NSObject modalDelegate, [NullAllowed] Selector didEndSelector, IntPtr contextInfo);

		[Export ("beginSheetModalForWindow:completionHandler:")]
		[Async]
		void BeginSheet ([NullAllowed] NSWindow Window, [NullAllowed] Action<NSModalResponse> handler);

		[Export ("window")]
		NSPanel Window { get; }
	}

	interface INSAlertDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSAlertDelegate {
		[Export ("alertShowHelp:"), DelegateName ("NSAlertPredicate"), DefaultValue (false)]
		bool ShowHelp (NSAlert alert);
	}

	[NoMacCatalyst]
	interface NSApplicationDidFinishLaunchingEventArgs {
		[Export ("NSApplicationLaunchIsDefaultLaunchKey")]
		bool IsLaunchDefault { get; }

		[ProbePresence, Export ("NSApplicationLaunchUserNotificationKey")]
		bool IsLaunchFromUserNotification { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSAppearance : NSSecureCoding {
		[DesignatedInitializer]
		[Export ("initWithAppearanceNamed:bundle:")]
		NativeHandle Constructor (string name, [NullAllowed] NSBundle bundle);

		[Export ("name")]
		string Name { get; }

		[Export ("allowsVibrancy")]
		bool AllowsVibrancy { get; }

		[Static, Export ("currentAppearance")]
		[Deprecated (PlatformName.MacOSX, 10, 9, message: "Use 'CurrentDrawingAppearance' instead.")]
		NSAppearance CurrentAppearance { get; [Bind ("setCurrentAppearance:")] set; }

		[Static]
		[Export ("currentDrawingAppearance", ArgumentSemantic.Strong)]
		NSAppearance CurrentDrawingAppearance { get; }

		[Export ("performAsCurrentDrawingAppearance:")]
		void PerformAsCurrentDrawingAppearance (Action receiver);


		[Static, Export ("appearanceNamed:")]
		NSAppearance GetAppearance (NSString name);

		[Field ("NSAppearanceNameAqua")]
		NSString NameAqua { get; }

		[Field ("NSAppearanceNameDarkAqua")]
		NSString NameDarkAqua { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Field ("NSAppearanceNameLightContent")]
		NSString NameLightContent { get; }

		[Field ("NSAppearanceNameVibrantDark")]
		NSString NameVibrantDark { get; }

		[Field ("NSAppearanceNameVibrantLight")]
		NSString NameVibrantLight { get; }

		[Field ("NSAppearanceNameAccessibilityHighContrastAqua")]
		NSString NameAccessibilityHighContrastAqua { get; }

		[Field ("NSAppearanceNameAccessibilityHighContrastDarkAqua")]
		NSString NameAccessibilityHighContrastDarkAqua { get; }

		[Field ("NSAppearanceNameAccessibilityHighContrastVibrantLight")]
		NSString NameAccessibilityHighContrastVibrantLight { get; }

		[Field ("NSAppearanceNameAccessibilityHighContrastVibrantDark")]
		NSString NameAccessibilityHighContrastVibrantDark { get; }

		[Export ("bestMatchFromAppearancesWithNames:")]
		[return: NullAllowed]
		string FindBestMatch (string [] appearances);
	}

	interface INSAppearanceCustomization { }

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSAppearanceCustomization {
#if NET
		[Abstract]
#endif
		[NullAllowed]
		[Export ("appearance", ArgumentSemantic.Strong)]
		NSAppearance Appearance { get; set; }

#if NET
		[Abstract]
#endif
		[Export ("effectiveAppearance", ArgumentSemantic.Strong)]
		NSAppearance EffectiveAppearance { get; }
	}


	[NoMacCatalyst]
	[BaseType (typeof (NSResponder), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSApplicationDelegate) })]
	[DisableDefaultCtor] // An uncaught exception was raised: Creating more than one Application
	interface NSApplication : NSAccessibilityElementProtocol, NSUserInterfaceValidations, NSMenuItemValidation, NSAccessibility, NSAppearanceCustomization {
		[Export ("sharedApplication"), Static, ThreadSafe]
		NSApplication SharedApplication { get; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSApplicationDelegate Delegate { get; set; }

		[Export ("context")]
		[Deprecated (PlatformName.MacOSX, 10, 12, message: "This method always returns null. If you need access to the current drawing context, use NSGraphicsContext.CurrentContext inside of a draw operation.")]
		NSGraphicsContext Context { get; }

		[Export ("hide:")]
		void Hide (NSObject sender);

		[Export ("unhide:")]
		void Unhide (NSObject sender);

		[Export ("unhideWithoutActivation")]
		void UnhideWithoutActivation ();

		[Export ("windowWithWindowNumber:")]
		NSWindow WindowWithWindowNumber (nint windowNum);

		[Export ("mainWindow")]
		NSWindow MainWindow { get; }

		[Export ("keyWindow")]
		NSWindow KeyWindow { get; }

		[Export ("isActive")]
		bool Active { get; }

		[Export ("isHidden")]
		bool Hidden { get; }

		[Export ("isRunning")]
		bool Running { get; }

		[Export ("deactivate")]
		void Deactivate ();

		[Deprecated (PlatformName.MacOSX, 14, 0)]
		[Export ("activateIgnoringOtherApps:")]
		void ActivateIgnoringOtherApps (bool flag);

		[Export ("hideOtherApplications:")]
		void HideOtherApplications (NSObject sender);

		[Export ("unhideAllApplications:")]
		void UnhideAllApplications (NSObject sender);

		[Export ("finishLaunching")]
		void FinishLaunching ();

		[Export ("run")]
		void Run ();

		[Export ("runModalForWindow:")]
		nint RunModalForWindow (NSWindow theWindow);

		[Export ("stop:")]
		void Stop (NSObject sender);

		[Export ("stopModal")]
		void StopModal ();

		[Export ("stopModalWithCode:")]
		void StopModalWithCode (nint returnCode);

		[Export ("abortModal"), ThreadSafe]
		void AbortModal ();

		[Export ("modalWindow")]
		NSWindow ModalWindow { get; }

		[Export ("beginModalSessionForWindow:")]
		IntPtr BeginModalSession (NSWindow theWindow);

		[Export ("runModalSession:")]
		nint RunModalSession (IntPtr session);

		[Export ("endModalSession:")]
		void EndModalSession (IntPtr session);

		[Export ("terminate:")]
		void Terminate ([NullAllowed] NSObject sender);

		[Export ("requestUserAttention:")]
		nint RequestUserAttention (NSRequestUserAttentionType requestType);

		[Export ("cancelUserAttentionRequest:")]
		void CancelUserAttentionRequest (nint request);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use NSWindow.BeginSheet instead.")]
		[Export ("beginSheet:modalForWindow:modalDelegate:didEndSelector:contextInfo:")]
		void BeginSheet (NSWindow sheet, NSWindow docWindow, [NullAllowed] NSObject modalDelegate, [NullAllowed] Selector didEndSelector, IntPtr contextInfo);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use NSWindow.EndSheet instead.")]
		[Export ("endSheet:")]
		void EndSheet (NSWindow sheet);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("endSheet:returnCode:")]
		void EndSheet (NSWindow sheet, nint returnCode);

		[Export ("nextEventMatchingMask:untilDate:inMode:dequeue:"), Protected]
		NSEvent NextEvent (NSEventMask mask, [NullAllowed] NSDate expiration, NSString runLoopMode, bool deqFlag);

#if !NET
		[Obsolete ("Use the 'NextEvent (NSEventMask, NSDate, [NSRunLoopMode|NSString], bool)' overloads instead.")]
		[Wrap ("NextEvent ((NSEventMask) (ulong) mask, expiration, (NSString) mode, deqFlag)", IsVirtual = true), Protected]
		NSEvent NextEvent (nuint mask, NSDate expiration, string mode, bool deqFlag);

		// NSEventMask must be casted to nuint to preserve the NSEventMask.Any special value on 64 bit systems. NSEventMask is not [Native].
		[Obsolete ("Use the 'NextEvent (NSEventMask, NSDate, [NSRunLoopMode|NSString], bool)' overloads instead.")]
		[Wrap ("NextEvent (mask, expiration, (NSString) mode, deqFlag)")]
		NSEvent NextEvent (NSEventMask mask, NSDate expiration, string mode, bool deqFlag);
#endif

		// NSEventMask must be casted to nuint to preserve the NSEventMask.Any special value on 64 bit systems. NSEventMask is not [Native].
		[Wrap ("NextEvent (mask, expiration, runLoopMode.GetConstant ()!, deqFlag)")]
		NSEvent NextEvent (NSEventMask mask, NSDate expiration, NSRunLoopMode runLoopMode, bool deqFlag);

		[Export ("discardEventsMatchingMask:beforeEvent:"), Protected]
		void DiscardEvents (nuint mask, NSEvent lastEvent);

		[ThreadSafe]
		[Export ("postEvent:atStart:")]
		void PostEvent (NSEvent theEvent, bool atStart);

		[Export ("currentEvent")]
		NSEvent CurrentEvent { get; }

		[Export ("sendEvent:")]
		void SendEvent (NSEvent theEvent);

		[Export ("preventWindowOrdering")]
		void PreventWindowOrdering ();

		[Export ("makeWindowsPerform:inOrder:")]
		[Deprecated (PlatformName.MacOSX, 10, 12, message: "Use EnumerateWindows instead.")]
		NSWindow MakeWindowsPerform (Selector aSelector, bool inOrder);

#if !NET
		[Obsolete ("Remove usage or use 'DangerousWindows' instead.")]
		[EditorBrowsable (EditorBrowsableState.Never)]
		[Wrap ("DangerousWindows", IsVirtual = true)]
		NSWindow [] Windows { get; }
#endif

		[Advice ("Use of DangerousWindows can prevent windows from leaving memory.")]
		[Export ("windows")]
		NSArray<NSWindow> DangerousWindows { get; }

		[Export ("setWindowsNeedUpdate:")]
		void SetWindowsNeedUpdate (bool needUpdate);

		[Export ("updateWindows")]
		void UpdateWindows ();

		[Export ("mainMenu", ArgumentSemantic.Retain)]
		NSMenu MainMenu { get; set; }

		[Export ("helpMenu", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSMenu HelpMenu { get; set; }

		[Export ("applicationIconImage", ArgumentSemantic.Retain)]
		NSImage ApplicationIconImage { get; set; }

		[Export ("activationPolicy"), Protected]
		NSApplicationActivationPolicy GetActivationPolicy ();

		[Export ("setActivationPolicy:"), Protected]
		bool SetActivationPolicy (NSApplicationActivationPolicy activationPolicy);

		[Export ("dockTile")]
		NSDockTile DockTile { get; }

		[Export ("sendAction:to:from:")]
		bool SendAction (Selector theAction, [NullAllowed] NSObject theTarget, [NullAllowed] NSObject sender);

		[Export ("targetForAction:")]
		NSObject TargetForAction (Selector theAction);

		[Export ("targetForAction:to:from:")]
		NSObject TargetForAction (Selector theAction, [NullAllowed] NSObject theTarget, [NullAllowed] NSObject sender);

		[Export ("tryToPerform:with:")]
		bool TryToPerform (Selector anAction, [NullAllowed] NSObject target);

		[Export ("validRequestorForSendType:returnType:")]
		[return: NullAllowed]
		NSObject ValidRequestor (string sendType, string returnType);

		[Export ("reportException:")]
		void ReportException (NSException theException);

		[Static]
		[Export ("detachDrawingThread:toTarget:withObject:")]
		void DetachDrawingThread (Selector selector, NSObject target, NSObject argument);

		[Export ("replyToApplicationShouldTerminate:")]
		void ReplyToApplicationShouldTerminate (bool shouldTerminate);

		[Export ("replyToOpenOrPrint:")]
		void ReplyToOpenOrPrint (NSApplicationDelegateReply reply);

		[Export ("orderFrontCharacterPalette:")]
		void OrderFrontCharacterPalette (NSObject sender);

		[Export ("presentationOptions")]
		NSApplicationPresentationOptions PresentationOptions { get; set; }

		[Export ("currentSystemPresentationOptions")]
		NSApplicationPresentationOptions CurrentSystemPresentationOptions { get; }

		[Export ("windowsMenu")]
		NSMenu WindowsMenu { get; set; }

		[Export ("arrangeInFront:")]
		void ArrangeInFront (NSObject sender);

		[Export ("removeWindowsItem:")]
		void RemoveWindowsItem (NSWindow win);

		[Export ("addWindowsItem:title:filename:")]
		void AddWindowsItem (NSWindow win, string title, bool isFilename);

		[Export ("changeWindowsItem:title:filename:")]
		void ChangeWindowsItem (NSWindow win, string title, bool isFilename);

		[Export ("updateWindowsItem:")]
		void UpdateWindowsItem (NSWindow win);

		[Export ("miniaturizeAll:")]
		void MiniaturizeAll (NSObject sender);

		[Export ("isFullKeyboardAccessEnabled")]
		bool FullKeyboardAccessEnabled { get; }

		[Export ("servicesProvider")]
		NSObject ServicesProvider { get; set; }

		[Export ("userInterfaceLayoutDirection")]
#if !NET
		NSApplicationLayoutDirection UserInterfaceLayoutDirection { get; }
#else
		NSUserInterfaceLayoutDirection UserInterfaceLayoutDirection { get; }
#endif

		[Export ("servicesMenu")]
		NSMenu ServicesMenu { get; set; }

		// From NSColorPanel
		[Export ("orderFrontColorPanel:")]
		void OrderFrontColorPanel (NSObject sender);

		[Export ("disableRelaunchOnLogin"), ThreadSafe]
		void DisableRelaunchOnLogin ();

		[Export ("enableRelaunchOnLogin"), ThreadSafe]
		void EnableRelaunchOnLogin ();

		[Export ("enabledRemoteNotificationTypes")]
		NSRemoteNotificationType EnabledRemoteNotificationTypes ();

		[Export ("registerForRemoteNotificationTypes:")]
		void RegisterForRemoteNotificationTypes (NSRemoteNotificationType types);

		[Export ("unregisterForRemoteNotifications")]
		void UnregisterForRemoteNotifications ();

		[Export ("registerForRemoteNotifications")]
		void RegisterForRemoteNotifications ();

		[Export ("registeredForRemoteNotifications")]
		bool IsRegisteredForRemoteNotifications { [Bind ("isRegisteredForRemoteNotifications")] get; }

		[Notification, Field ("NSApplicationDidBecomeActiveNotification")]
		NSString DidBecomeActiveNotification { get; }

		[Notification, Field ("NSApplicationDidHideNotification")]
		NSString DidHideNotification { get; }

		[Notification (typeof (NSApplicationDidFinishLaunchingEventArgs)), Field ("NSApplicationDidFinishLaunchingNotification")]
		NSString DidFinishLaunchingNotification { get; }

		[Notification, Field ("NSApplicationDidResignActiveNotification")]
		NSString DidResignActiveNotification { get; }

		[Notification, Field ("NSApplicationDidUnhideNotification")]
		NSString DidUnhideNotification { get; }

		[Notification, Field ("NSApplicationDidUpdateNotification")]
		NSString DidUpdateNotification { get; }

		[Notification, Field ("NSApplicationWillBecomeActiveNotification")]
		NSString WillBecomeActiveNotification { get; }

		[Notification, Field ("NSApplicationWillHideNotification")]
		NSString WillHideNotification { get; }

		[Notification, Field ("NSApplicationWillFinishLaunchingNotification")]
		NSString WillFinishLaunchingNotification { get; }

		[Notification, Field ("NSApplicationWillResignActiveNotification")]
		NSString WillResignActiveNotification { get; }

		[Notification, Field ("NSApplicationWillUnhideNotification")]
		NSString WillUnhideNotification { get; }

		[Notification, Field ("NSApplicationWillUpdateNotification")]
		NSString WillUpdateNotification { get; }

		[Notification, Field ("NSApplicationWillTerminateNotification")]
		NSString WillTerminateNotification { get; }

		[Notification, Field ("NSApplicationDidChangeScreenParametersNotification")]
		NSString DidChangeScreenParametersNotification { get; }

		[Notification, Mac (12, 1)]
		[Field ("NSApplicationProtectedDataWillBecomeUnavailableNotification")]
		NSString ProtectedDataWillBecomeUnavailableNotification { get; }

		[Notification, Mac (12, 1)]
		[Field ("NSApplicationProtectedDataDidBecomeAvailableNotification")]
		NSString ProtectedDataDidBecomeAvailableNotification { get; }

		[Field ("NSApplicationLaunchIsDefaultLaunchKey")]
		NSString LaunchIsDefaultLaunchKey { get; }

		[Field ("NSApplicationLaunchRemoteNotificationKey")]
		NSString LaunchRemoteNotificationKey { get; }

		[Field ("NSApplicationLaunchUserNotificationKey")]
		NSString LaunchUserNotificationKey { get; }

		[Notification, Field ("NSApplicationDidFinishRestoringWindowsNotification")]
		NSString DidFinishRestoringWindowsNotification { get; }

		[Export ("occlusionState")]
		NSApplicationOcclusionState OcclusionState { get; }

		// This comes from the NSWindowRestoration category (defined on NSApplication: '@interface NSApplication (NSWindowRestoration)')
		// Also can't call it 'RestoreWindow', because that's already in use.
		[Export ("restoreWindowWithIdentifier:state:completionHandler:")]
		bool RestoreWindowWithIdentifier (string identifier, NSCoder state, NSWindowCompletionHandler onCompletion);

		// This one comes from the NSRestorableStateExtension category ('@interface NSApplication (NSRestorableStateExtension)')
		[Export ("extendStateRestoration")]
		void ExtendStateRestoration ();

		// This one comes from the NSRestorableStateExtension category ('@interface NSApplication (NSRestorableStateExtension)')
		[Export ("completeStateRestoration")]
		void CompleteStateRestoration ();

#if !NET
		[Export ("registerServicesMenuSendTypes:returnTypes:"), EventArgs ("NSApplicationRegister")]
		void RegisterServicesMenu2 (string [] sendTypes, string [] returnTypes);

		[Export ("orderFrontStandardAboutPanel:"), EventArgs ("NSObject")]
		void OrderFrontStandardAboutPanel2 (NSObject sender);

		[Export ("orderFrontStandardAboutPanelWithOptions:"), EventArgs ("NSDictionary")]
		void OrderFrontStandardAboutPanelWithOptions2 (NSDictionary optionsDictionary);
#endif

		[Export ("enumerateWindowsWithOptions:usingBlock:")]
		void EnumerateWindows (NSWindowListOptions options, NSApplicationEnumerateWindowsHandler block);

		[Export ("protectedDataAvailable")]
		bool ProtectedDataAvailable { [Bind ("isProtectedDataAvailable")] get; }

		[Mac (14, 0)]
		[Export ("activate")]
		void Activate ();

		[Mac (14, 0)]
		[Export ("yieldActivationToApplication:")]
		void YieldActivation (NSRunningApplication toApplication);

		[Mac (14, 0)]
		[Export ("yieldActivationToApplicationWithBundleIdentifier:")]
		void YieldActivation (string toApplicationWithBundleIdentifier);

		// From the NSUserInterfaceItemSearching category
		[Export ("registerUserInterfaceItemSearchHandler:")]
		void RegisterUserInterfaceItemSearchHandler (INSUserInterfaceItemSearching handler);

		[Export ("unregisterUserInterfaceItemSearchHandler:")]
		void UnregisterUserInterfaceItemSearchHandler (INSUserInterfaceItemSearching handler);

		[Export ("searchString:inUserInterfaceItemString:searchRange:foundRange:")]
		bool SearchStringInUserInterface (string searchString, string stringToSearch, NSRange searchRange, out NSRange foundRange);

		// From the NSApplicationHelpExtension category
		[Export ("activateContextHelpMode:")]
		void ActivateContextHelpMode ([NullAllowed] NSObject sender);

		[Export ("showHelp:")]
		void ShowHelp ([NullAllowed] NSObject sender);
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSApplication))]
	interface NSApplication_NSServicesMenu {
		[Export ("registerServicesMenuSendTypes:returnTypes:")]
		void RegisterServicesMenu (string [] sendTypes, string [] returnTypes);
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSApplication))]
	interface NSApplication_NSStandardAboutPanel {
		[Export ("orderFrontStandardAboutPanel:")]
		void OrderFrontStandardAboutPanel ([NullAllowed] NSObject sender);

		[Export ("orderFrontStandardAboutPanelWithOptions:")]
#if XAMCORE_5_0
		void OrderFrontStandardAboutPanelWithOptions (NSDictionary<NSAboutPanelOption, NSObject> optionsDictionary);
#else
		void OrderFrontStandardAboutPanelWithOptions (NSDictionary optionsDictionary);
#endif
	}

	[NoMacCatalyst]
	[Static]
	interface NSAboutPanelOption {
		[Field ("NSAboutPanelOptionCredits")]
		NSString Credits { get; }

		[Field ("NSAboutPanelOptionApplicationName")]
		NSString ApplicationName { get; }

		[Field ("NSAboutPanelOptionApplicationIcon")]
		NSString ApplicationIcon { get; }

		[Field ("NSAboutPanelOptionVersion")]
		NSString Version { get; }

		[Field ("NSAboutPanelOptionApplicationVersion")]
		NSString ApplicationVersion { get; }
	}

	delegate void NSApplicationEnumerateWindowsHandler (NSWindow window, ref bool stop);
#if NET
	[NoMacCatalyst]
	delegate void ContinueUserActivityRestorationHandler (INSUserActivityRestoring [] restorableObjects);
#else
	delegate void ContinueUserActivityRestorationHandler (NSObject [] restorableObjects);
#endif

	interface INSApplicationDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSApplicationDelegate {
		[Export ("applicationShouldTerminate:"), DelegateName ("NSApplicationTermination"), DefaultValue (NSApplicationTerminateReply.Now)]
		NSApplicationTerminateReply ApplicationShouldTerminate (NSApplication sender);

		[Export ("application:openFile:"), DelegateName ("NSApplicationFile"), DefaultValue (false)]
		bool OpenFile (NSApplication sender, string filename);

		[Export ("application:openFiles:"), EventArgs ("NSApplicationFiles")]
		void OpenFiles (NSApplication sender, string [] filenames);

		[Export ("application:openTempFile:"), DelegateName ("NSApplicationFile"), DefaultValue (false)]
		bool OpenTempFile (NSApplication sender, string filename);

		[Export ("applicationShouldOpenUntitledFile:"), DelegateName ("NSApplicationPredicate"), DefaultValue (false)]
		bool ApplicationShouldOpenUntitledFile (NSApplication sender);

		[Export ("applicationOpenUntitledFile:"), DelegateName ("NSApplicationPredicate"), DefaultValue (false)]
		bool ApplicationOpenUntitledFile (NSApplication sender);

		[Export ("application:openFileWithoutUI:"), DelegateName ("NSApplicationFileCommand"), DefaultValue (false)]
		bool OpenFileWithoutUI (NSObject sender, string filename);

		[Export ("application:printFile:"), DelegateName ("NSApplicationFile"), DefaultValue (false)]
		bool PrintFile (NSApplication sender, string filename);

		[Export ("application:printFiles:withSettings:showPrintPanels:"), DelegateName ("NSApplicationPrint"), DefaultValue (NSApplicationPrintReply.Failure)]
		NSApplicationPrintReply PrintFiles (NSApplication application, string [] fileNames, NSDictionary printSettings, bool showPrintPanels);

		[Export ("applicationShouldTerminateAfterLastWindowClosed:"), DelegateName ("NSApplicationPredicate"), DefaultValue (false)]
		bool ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender);

		[Export ("applicationShouldHandleReopen:hasVisibleWindows:"), DelegateName ("NSApplicationReopen"), DefaultValue (false)]
		bool ApplicationShouldHandleReopen (NSApplication sender, bool hasVisibleWindows);

		[Export ("applicationDockMenu:"), DelegateName ("NSApplicationMenu"), DefaultValue (null)]
		NSMenu ApplicationDockMenu (NSApplication sender);

		[Export ("application:willPresentError:"), DelegateName ("NSApplicationError"), DefaultValue (null)]
		NSError WillPresentError (NSApplication application, NSError error);

		[Export ("applicationWillFinishLaunching:"), EventArgs ("NSNotification")]
		void WillFinishLaunching (NSNotification notification);

		[Export ("applicationDidFinishLaunching:"), EventArgs ("NSNotification")]
		void DidFinishLaunching (NSNotification notification);

		[Export ("applicationWillHide:"), EventArgs ("NSNotification")]
		void WillHide (NSNotification notification);

		[Export ("applicationDidHide:"), EventArgs ("NSNotification")]
		void DidHide (NSNotification notification);

		[Export ("applicationWillUnhide:"), EventArgs ("NSNotification")]
		void WillUnhide (NSNotification notification);

		[Export ("applicationDidUnhide:"), EventArgs ("NSNotification")]
		void DidUnhide (NSNotification notification);

		[Export ("applicationWillBecomeActive:"), EventArgs ("NSNotification")]
		void WillBecomeActive (NSNotification notification);

		[Export ("applicationDidBecomeActive:"), EventArgs ("NSNotification")]
		void DidBecomeActive (NSNotification notification);

		[Export ("applicationWillResignActive:"), EventArgs ("NSNotification")]
		void WillResignActive (NSNotification notification);

		[Export ("applicationDidResignActive:"), EventArgs ("NSNotification")]
		void DidResignActive (NSNotification notification);

		[Export ("applicationWillUpdate:"), EventArgs ("NSNotification")]
		void WillUpdate (NSNotification notification);

		[Export ("applicationDidUpdate:"), EventArgs ("NSNotification")]
		void DidUpdate (NSNotification notification);

		[Export ("applicationWillTerminate:"), EventArgs ("NSNotification")]
		void WillTerminate (NSNotification notification);

		[Export ("applicationDidChangeScreenParameters:"), EventArgs ("NSNotification")]
		void ScreenParametersChanged (NSNotification notification);

#if !NET // Needs to move from delegate in next API break
		[Obsolete ("Use the 'RegisterServicesMenu2' on NSApplication.")]
		[Export ("registerServicesMenuSendTypes:returnTypes:"), EventArgs ("NSApplicationRegister")]
		void RegisterServicesMenu (string [] sendTypes, string [] returnTypes);

		[Obsolete ("Use the 'INSServicesMenuRequestor' protocol.")]
		[Export ("writeSelectionToPasteboard:types:"), DelegateName ("NSApplicationSelection"), DefaultValue (false)]
		bool WriteSelectionToPasteboard (NSPasteboard board, string [] types);

		[Obsolete ("Use the 'INSServicesMenuRequestor' protocol.")]
		[Export ("readSelectionFromPasteboard:"), DelegateName ("NSPasteboardPredicate"), DefaultValue (false)]
		bool ReadSelectionFromPasteboard (NSPasteboard pboard);

		[Obsolete ("Use the 'OrderFrontStandardAboutPanel2' on NSApplication.")]
		[Export ("orderFrontStandardAboutPanel:"), EventArgs ("NSObject")]
		void OrderFrontStandardAboutPanel (NSObject sender);

		[Obsolete ("Use the 'OrderFrontStandardAboutPanelWithOptions2' on NSApplication.")]
		[Export ("orderFrontStandardAboutPanelWithOptions:"), EventArgs ("NSDictionary")]
		void OrderFrontStandardAboutPanelWithOptions (NSDictionary optionsDictionary);
#endif

		[Export ("application:didRegisterForRemoteNotificationsWithDeviceToken:"), EventArgs ("NSData")]
		void RegisteredForRemoteNotifications (NSApplication application, NSData deviceToken);

		[Export ("application:didFailToRegisterForRemoteNotificationsWithError:"), EventArgs ("NSError", true)]
		void FailedToRegisterForRemoteNotifications (NSApplication application, NSError error);

		[Export ("application:didReceiveRemoteNotification:"), EventArgs ("NSDictionary")]
		void ReceivedRemoteNotification (NSApplication application, NSDictionary userInfo);

		[Export ("application:willEncodeRestorableState:"), EventArgs ("NSCoder")]
		void WillEncodeRestorableState (NSApplication app, NSCoder encoder);

		[Export ("application:didDecodeRestorableState:"), EventArgs ("NSCoder")]
		void DecodedRestorableState (NSApplication app, NSCoder state);

		[Export ("application:willContinueUserActivityWithType:"), DelegateName ("NSApplicationUserActivityType"), DefaultValue (false)]
		bool WillContinueUserActivity (NSApplication application, string userActivityType);

		[Export ("application:continueUserActivity:restorationHandler:"), DelegateName ("NSApplicationContinueUserActivity"), DefaultValue (false)]
		bool ContinueUserActivity (NSApplication application, NSUserActivity userActivity, ContinueUserActivityRestorationHandler restorationHandler);

		[Export ("application:didFailToContinueUserActivityWithType:error:"), EventArgs ("NSApplicationFailed"), DefaultValue (false)]
		void FailedToContinueUserActivity (NSApplication application, string userActivityType, NSError error);

		[Export ("application:didUpdateUserActivity:"), EventArgs ("NSApplicationUpdatedUserActivity"), DefaultValue (false)]
		void UpdatedUserActivity (NSApplication application, NSUserActivity userActivity);

		[Export ("application:userDidAcceptCloudKitShareWithMetadata:"), EventArgs ("NSApplicationUserAcceptedCloudKitShare")]
		void UserDidAcceptCloudKitShare (NSApplication application, CKShareMetadata metadata);

		[EventArgs ("NSApplicationOpenUrls")]
		[Export ("application:openURLs:")]
		void OpenUrls (NSApplication application, NSUrl [] urls);

		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Now optional on NSApplicationDelegate.")]
		[Export ("application:delegateHandlesKey:"), DelegateName ("NSApplicationHandlesKey"), NoDefaultValue]
		bool HandlesKey (NSApplication sender, string key);

		[IgnoredInDelegate]
		[Export ("applicationSupportsSecureRestorableState:")]
		bool SupportsSecureRestorableState (NSApplication application);

		[IgnoredInDelegate]
		[Export ("application:handlerForIntent:")]
		[return: NullAllowed]
		NSObject GetHandler (NSApplication application, INIntent intent);

		[IgnoredInDelegate]
		[Export ("applicationShouldAutomaticallyLocalizeKeyEquivalents:")]
		bool ShouldAutomaticallyLocalizeKeyEquivalents (NSApplication application);

		[Export ("applicationProtectedDataWillBecomeUnavailable:")]
		void ProtectedDataWillBecomeUnavailable (NSNotification notification);

		[Export ("applicationProtectedDataDidBecomeAvailable:")]
		void ProtectedDataDidBecomeAvailable (NSNotification notification);
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSServicesMenuRequestor {
		[Export ("writeSelectionToPasteboard:types:")]
		bool WriteSelectionToPasteboard (NSPasteboard pboard, string [] types);

		[Export ("readSelectionFromPasteboard:")]
		bool ReadSelectionFromPasteboard (NSPasteboard pboard);
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSApplication))]
	interface NSApplication_NSTouchBarCustomization {
		[Export ("isAutomaticCustomizeTouchBarMenuItemEnabled")]
		bool GetAutomaticCustomizeTouchBarMenuItemEnabled ();

		[Export ("setAutomaticCustomizeTouchBarMenuItemEnabled:")]
		void SetAutomaticCustomizeTouchBarMenuItemEnabled (bool enabled);

		[Export ("toggleTouchBarCustomizationPalette:")]
		void ToggleTouchBarCustomizationPalette ([NullAllowed] NSObject sender);
	}


	[NoMacCatalyst]
	[BaseType (typeof (NSObjectController))]
	interface NSArrayController {
		[Export ("rearrangeObjects")]
		void RearrangeObjects ();

		[Export ("automaticRearrangementKeyPaths")]
		NSObject [] AutomaticRearrangementKeyPaths ();

		[Export ("didChangeArrangementCriteria")]
		void DidChangeArrangementCriteria ();

		[Export ("arrangeObjects:")]
		NSObject [] ArrangeObjects (NSObject [] objects);

		[Export ("arrangedObjects")]
		NSObject [] ArrangedObjects ();

		[Export ("addSelectionIndexes:")]
		bool AddSelectionIndexes (NSIndexSet indexes);

		[Export ("removeSelectionIndexes:")]
		bool RemoveSelectionIndexes (NSIndexSet indexes);

		[Export ("addSelectedObjects:")]
		bool AddSelectedObjects (NSObject [] objects);

		[Export ("removeSelectedObjects:")]
		bool RemoveSelectedObjects (NSObject [] objects);

		[Export ("add:")]
		void Add (NSObject sender);

		[Export ("remove:")]
		void RemoveOp (NSObject sender);

		[Export ("insert:")]
		void Insert (NSObject sender);

		[Export ("canInsert")]
		bool CanInsert ();

		[Export ("selectNext:")]
		void SelectNext (NSObject sender);

		[Export ("selectPrevious:")]
		void SelectPrevious (NSObject sender);

		[Export ("canSelectNext")]
		bool CanSelectNext ();

		[Export ("canSelectPrevious")]
		bool CanSelectPrevious ();

		[Export ("addObject:")]
		void AddObject (NSObject aObject);

		[Export ("addObjects:")]
		void AddObjects (NSArray objects);

		[Export ("insertObject:atArrangedObjectIndex:")]
		void Insert (NSObject aObject, nint index);

		[Export ("insertObjects:atArrangedObjectIndexes:")]
		void Insert (NSObject [] objects, NSIndexSet indexes);

		[Export ("removeObjectAtArrangedObjectIndex:")]
		void RemoveAt (nint index);

		[Export ("removeObjectsAtArrangedObjectIndexes:")]
		void Remove (NSIndexSet indexes);

		[Export ("removeObject:")]
		void Remove (NSObject aObject);

		[Export ("removeObjects:")]
		void Remove (NSObject [] objects);

		//Detected properties
		[Export ("automaticallyRearrangesObjects")]
		bool AutomaticallyRearrangesObjects { get; set; }

		[Export ("sortDescriptors", ArgumentSemantic.Copy)]
		NSObject [] SortDescriptors { get; set; }

		[Export ("filterPredicate", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSPredicate FilterPredicate { get; set; }

		[Export ("clearsFilterPredicateOnInsertion")]
		bool ClearsFilterPredicateOnInsertion { get; set; }

		[Export ("avoidsEmptySelection")]
		bool AvoidsEmptySelection { get; set; }

		[Export ("preservesSelection")]
		bool PreservesSelection { get; set; }

		[Export ("selectsInsertedObjects")]
		bool SelectsInsertedObjects { get; set; }

		[Export ("alwaysUsesMultipleValuesMarker")]
		bool AlwaysUsesMultipleValuesMarker { get; set; }

		[Export ("selectionIndexes"), Protected]
		NSIndexSet GetSelectionIndexes ();

		[Export ("setSelectionIndexes:"), Protected]
		bool SetSelectionIndexes (NSIndexSet indexes);

		[Export ("selectionIndex"), Protected]
		nuint GetSelectionIndex ();

		[Export ("setSelectionIndex:"), Protected]
		bool SetSelectionIndex (nuint index);

		[Export ("selectedObjects"), Protected]
		NSObject [] GetSelectedObjects ();

		[Export ("setSelectedObjects:"), Protected]
		bool SetSelectedObjects (NSObject [] objects);
	}

	[NoMacCatalyst]
	[ThreadSafe]
	[BaseType (typeof (NSObject))]
	interface NSBezierPath : NSSecureCoding, NSCopying {

		[Static]
		[Export ("bezierPathWithRect:")]
		NSBezierPath FromRect (CGRect rect);

		[Static]
		[Export ("bezierPathWithOvalInRect:")]
		NSBezierPath FromOvalInRect (CGRect rect);

		[Static]
		[Export ("bezierPathWithRoundedRect:xRadius:yRadius:")]
		NSBezierPath FromRoundedRect (CGRect rect, nfloat xRadius, nfloat yRadius);

		[Static]
		[Export ("fillRect:")]
		void FillRect (CGRect rect);

		[Static]
		[Export ("strokeRect:")]
		void StrokeRect (CGRect rect);

		[Static]
		[Export ("clipRect:")]
		void ClipRect (CGRect rect);

		[Static]
		[Export ("strokeLineFromPoint:toPoint:")]
		void StrokeLine (CGPoint point1, CGPoint point2);

		//IntPtr is exposed because the packedGlyphs should be treated as a "black box"
		[Static]
		[Export ("drawPackedGlyphs:atPoint:")]
		void DrawPackedGlyphsAtPoint (IntPtr packedGlyphs, CGPoint point);

		[Export ("moveToPoint:")]
		void MoveTo (CGPoint point);

		[Export ("lineToPoint:")]
		void LineTo (CGPoint point);

		[Export ("curveToPoint:controlPoint1:controlPoint2:")]
		void CurveTo (CGPoint endPoint, CGPoint controlPoint1, CGPoint controlPoint2);

		[Export ("closePath")]
		void ClosePath ();

		[Export ("removeAllPoints")]
		void RemoveAllPoints ();

		[Export ("relativeMoveToPoint:")]
		void RelativeMoveTo (CGPoint point);

		[Export ("relativeLineToPoint:")]
		void RelativeLineTo (CGPoint point);

		[Export ("relativeCurveToPoint:controlPoint1:controlPoint2:")]
		void RelativeCurveTo (CGPoint endPoint, CGPoint controlPoint1, CGPoint controlPoint2);

		[Export ("getLineDash:count:phase:"), Internal]
		void _GetLineDash (IntPtr pattern, out nint count, out nfloat phase);

		[Export ("setLineDash:count:phase:"), Internal]
		void _SetLineDash (IntPtr pattern, nint count, nfloat phase);

		[Export ("stroke")]
		void Stroke ();

		[Export ("fill")]
		void Fill ();

		[Export ("addClip")]
		void AddClip ();

		[Export ("setClip")]
		void SetClip ();

		[Export ("bezierPathByFlatteningPath")]
		NSBezierPath BezierPathByFlatteningPath ();

		[Export ("bezierPathByReversingPath")]
		NSBezierPath BezierPathByReversingPath ();

		[Export ("transformUsingAffineTransform:")]
		void TransformUsingAffineTransform (NSAffineTransform transform);

		[Export ("isEmpty")]
		bool IsEmpty { get; }

		[Export ("currentPoint")]
		CGPoint CurrentPoint { get; }

		[Export ("controlPointBounds")]
		CGRect ControlPointBounds { get; }

		[Export ("bounds")]
		CGRect Bounds { get; }

		[Export ("elementCount")]
		nint ElementCount { get; }

		[Export ("elementAtIndex:associatedPoints:"), Internal]
		NSBezierPathElement _ElementAt (nint index, IntPtr points);

		[Export ("elementAtIndex:")]
		NSBezierPathElement ElementAt (nint index);

		[Export ("setAssociatedPoints:atIndex:"), Internal]
		void _SetAssociatedPointsAtIndex (IntPtr points, nint index);

		[Export ("appendBezierPath:")]
		void AppendPath (NSBezierPath path);

		[Export ("appendBezierPathWithRect:")]
		void AppendPathWithRect (CGRect rect);

		[Export ("appendBezierPathWithPoints:count:"), Internal]
		void _AppendPathWithPoints (IntPtr points, nint count);

		[Export ("appendBezierPathWithOvalInRect:")]
		void AppendPathWithOvalInRect (CGRect rect);

		[Export ("appendBezierPathWithArcWithCenter:radius:startAngle:endAngle:clockwise:")]
		void AppendPathWithArc (CGPoint center, nfloat radius, nfloat startAngle, nfloat endAngle, bool clockwise);

		[Export ("appendBezierPathWithArcWithCenter:radius:startAngle:endAngle:")]
		void AppendPathWithArc (CGPoint center, nfloat radius, nfloat startAngle, nfloat endAngle);

		[Export ("appendBezierPathWithArcFromPoint:toPoint:radius:")]
		void AppendPathWithArc (CGPoint point1, CGPoint point2, nfloat radius);

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'AppendPathWithCGGlyph (CGGlyph, NSFont)' instead.")]
		[Export ("appendBezierPathWithGlyph:inFont:")]
		void AppendPathWithGlyph (uint /* NSGlyph = unsigned int */ glyph, NSFont font);

		[Export ("appendBezierPathWithGlyphs:count:inFont:"), Internal]
		void _AppendPathWithGlyphs (IntPtr glyphs, nint count, NSFont font);

		//IntPtr is exposed because the packedGlyphs should be treated as a "black box"
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'Append (uint[], NSFont)' instead.")]
		[Export ("appendBezierPathWithPackedGlyphs:")]
		void AppendPathWithPackedGlyphs (IntPtr packedGlyphs);

		[Export ("appendBezierPathWithRoundedRect:xRadius:yRadius:")]
		void AppendPathWithRoundedRect (CGRect rect, nfloat xRadius, nfloat yRadius);

		[Export ("containsPoint:")]
		bool Contains (CGPoint point);

		//Detected properties
		[Static]
		[Export ("defaultMiterLimit")]
		nfloat DefaultMiterLimit { get; set; }

		[Static]
		[Export ("defaultFlatness")]
		nfloat DefaultFlatness { get; set; }

		[Static]
		[Export ("defaultWindingRule")]
		NSWindingRule DefaultWindingRule { get; set; }

		[Static]
		[Export ("defaultLineCapStyle")]
		NSLineCapStyle DefaultLineCapStyle { get; set; }

		[Static]
		[Export ("defaultLineJoinStyle")]
		NSLineJoinStyle DefaultLineJoinStyle { get; set; }

		[Static]
		[Export ("defaultLineWidth")]
		nfloat DefaultLineWidth { get; set; }

		[Export ("lineWidth")]
		nfloat LineWidth { get; set; }

		[Export ("lineCapStyle")]
		NSLineCapStyle LineCapStyle { get; set; }

		[Export ("lineJoinStyle")]
		NSLineJoinStyle LineJoinStyle { get; set; }

		[Export ("windingRule")]
		NSWindingRule WindingRule { get; set; }

		[Export ("miterLimit")]
		nfloat MiterLimit { get; set; }

		[Export ("flatness")]
		nfloat Flatness { get; set; }

		[Export ("appendBezierPathWithCGGlyph:inFont:")]
		void AppendPathWithCGGlyph (CGGlyph glyph, NSFont font);

		[Export ("appendBezierPathWithCGGlyphs:count:inFont:")]
		[Internal]
		void _AppendBezierPathWithCGGlyphs (IntPtr glyphs, nint count, NSFont font);

		[Wrap ("AppendPath (path)")]
		void Append (NSBezierPath path);

		[Mac (14, 0)]
		[Export ("CGPath", ArgumentSemantic.Assign)]
		CGPath CGPath { get; set; }

		[Mac (14, 0)]
		[Export ("curveToPoint:controlPoint:")]
		void CurveTo (CGPoint endPoint, CGPoint controlPoint);

		[Mac (14, 0)]
		[Export ("relativeCurveToPoint:controlPoint:")]
		void RelativeCurveTo (CGPoint endPoint, CGPoint controlPoint);

		[Mac (14, 0)]
		[Static]
		[Export ("bezierPathWithCGPath:")]
		NSBezierPath FromCGPath (CGPath cgPath);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSImageRep))]
	[DisableDefaultCtor] // An uncaught exception was raised: -[NSBitmapImageRep init]: unrecognized selector sent to instance 0x686880
	partial interface NSBitmapImageRep : NSSecureCoding {
		[Export ("initWithFocusedViewRect:")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSView.CacheDisplay()' instead.")]
		NativeHandle Constructor (CGRect rect);

		[Export ("initWithBitmapDataPlanes:pixelsWide:pixelsHigh:bitsPerSample:samplesPerPixel:hasAlpha:isPlanar:colorSpaceName:bytesPerRow:bitsPerPixel:")]
		NativeHandle Constructor (IntPtr planes, nint width, nint height, nint bps, nint spp, bool alpha, bool isPlanar,
					string colorSpaceName, nint rBytes, nint pBits);

		[Export ("initWithBitmapDataPlanes:pixelsWide:pixelsHigh:bitsPerSample:samplesPerPixel:hasAlpha:isPlanar:colorSpaceName:bitmapFormat:bytesPerRow:bitsPerPixel:")]
		NativeHandle Constructor (IntPtr planes, nint width, nint height, nint bps, nint spp, bool alpha, bool isPlanar, string colorSpaceName,
					NSBitmapFormat bitmapFormat, nint rBytes, nint pBits);

		[Export ("initWithCGImage:")]
		NativeHandle Constructor (CGImage cgImage);

		[Export ("initWithCIImage:")]
		NativeHandle Constructor (CIImage ciImage);

		[Static]
		[Export ("imageRepsWithData:")]
		NSImageRep [] ImageRepsWithData (NSData data);

		[Static]
		[Export ("imageRepWithData:")]
		NSImageRep ImageRepFromData (NSData data);

		[Export ("initWithData:")]
		NativeHandle Constructor (NSData data);

		[Export ("bitmapData")]
		IntPtr BitmapData { get; }

		[Export ("getBitmapDataPlanes:")]
		void GetBitmapDataPlanes (IntPtr data);

		[Export ("isPlanar")]
		bool IsPlanar { get; }

		[Export ("samplesPerPixel")]
		nint SamplesPerPixel { get; }

		[Export ("bitsPerPixel")]
		nint BitsPerPixel { get; }

		[Export ("bytesPerRow")]
		nint BytesPerRow { get; }

		[Export ("bytesPerPlane")]
		nint BytesPerPlane { get; }

		[Export ("numberOfPlanes")]
		nint Planes { get; }

		[Export ("bitmapFormat")]
		NSBitmapFormat BitmapFormat { get; }

		[Export ("getCompression:factor:")]
		void GetCompressionFactor (out NSTiffCompression compression, out float /* float, not CGFloat */ factor);

		[Export ("setCompression:factor:")]
		void SetCompressionFactor (NSTiffCompression compression, float /* float, not CGFloat */ factor);

		[Export ("TIFFRepresentation")]
		NSData TiffRepresentation { get; }

		[Export ("TIFFRepresentationUsingCompression:factor:")]
		NSData TiffRepresentationUsingCompressionFactor (NSTiffCompression comp, float /* float, not CGFloat */ factor);

		[Static]
		[Export ("TIFFRepresentationOfImageRepsInArray:")]
		NSData ImagesAsTiff (NSImageRep [] imageReps);

		[Static]
		[Export ("TIFFRepresentationOfImageRepsInArray:usingCompression:factor:")]
		NSData ImagesAsTiff (NSImageRep [] imageReps, NSTiffCompression comp, float /* float, not CGFloat */ factor);

		// FIXME: binding
		//[Static]
		//[Export ("getTIFFCompressionTypes:count:")]
		//void GetTiffCompressionTypes (const NSTIFFCompression list, int numTypes);

		[Static]
		[Export ("localizedNameForTIFFCompressionType:")]
		string LocalizedNameForTiffCompressionType (NSTiffCompression compression);

		[Export ("canBeCompressedUsing:")]
		bool CanBeCompressedUsing (NSTiffCompression compression);

		[Export ("colorizeByMappingGray:toColor:blackMapping:whiteMapping:")]
		void Colorize (nfloat midPoint, NSColor midPointColor, NSColor shadowColor, NSColor lightColor);

		[Export ("incrementalLoadFromData:complete:")]
		nint IncrementalLoad (NSData data, bool complete);

		[Export ("setColor:atX:y:")]
		void SetColorAt (NSColor color, nint x, nint y);

		[Export ("colorAtX:y:")]
		NSColor ColorAt (nint x, nint y);

		// FIXME: BINDING
		//[Export ("getPixel:atX:y:")]
		//void GetPixel (int[] p, int x, int y);
		//[Export ("setPixel:atX:y:")]
		//void SetPixel (int[] p, int x, int y);

		[Export ("CGImage")]
		CGImage CGImage { get; }

		[Export ("colorSpace")]
		NSColorSpace ColorSpace { get; }

		[Export ("bitmapImageRepByConvertingToColorSpace:renderingIntent:")]
		NSBitmapImageRep ConvertingToColorSpace (NSColorSpace targetSpace, NSColorRenderingIntent renderingIntent);

		[Export ("bitmapImageRepByRetaggingWithColorSpace:")]
		NSBitmapImageRep RetaggedWithColorSpace (NSColorSpace newSpace);

		[Export ("representationUsingType:properties:")]
		NSData RepresentationUsingTypeProperties (NSBitmapImageFileType storageType, [NullAllowed] NSDictionary properties);

		[Field ("NSImageCompressionMethod")]
		NSString CompressionMethod { get; }

		[Field ("NSImageCompressionFactor")]
		NSString CompressionFactor { get; }

		[Field ("NSImageDitherTransparency")]
		NSString DitherTransparency { get; }

		[Field ("NSImageRGBColorTable")]
		NSString RGBColorTable { get; }

		[Field ("NSImageInterlaced")]
		NSString Interlaced { get; }

		[Field ("NSImageColorSyncProfileData")]
		NSString ColorSyncProfileData { get; }

		[Field ("NSImageFrameCount")]
		NSString FrameCount { get; }

		[Field ("NSImageCurrentFrame")]
		NSString CurrentFrame { get; }

		[Field ("NSImageCurrentFrameDuration")]
		NSString CurrentFrameDuration { get; }

		[Field ("NSImageLoopCount")]
		NSString LoopCount { get; }

		[Field ("NSImageGamma")]
		NSString Gamma { get; }

		[Field ("NSImageProgressive")]
		NSString Progressive { get; }

		[Field ("NSImageEXIFData")]
		NSString EXIFData { get; }

		[Field ("NSImageIPTCData")]
		NSString IptcData { get; }

		[Field ("NSImageFallbackBackgroundColor")]
		NSString FallbackBackgroundColor { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSBox {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("borderType")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use 'Transparent' property for NSNoBorder instead.")]
		NSBorderType BorderType { get; set; }

		[Export ("titlePosition")]
		NSTitlePosition TitlePosition { get; set; }

		[Export ("boxType")]
		NSBoxType BoxType { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("titleFont", ArgumentSemantic.Retain)]
		NSFont TitleFont { get; set; }

		[Export ("borderRect")]
		CGRect BorderRect { get; }

		[Export ("titleRect")]
		CGRect TitleRect { get; }

		[Export ("titleCell")]
		NSObject TitleCell { get; }

		[Export ("sizeToFit")]
		void SizeToFit ();

		[Export ("contentViewMargins")]
		CGSize ContentViewMargins { get; set; }

		[Export ("setFrameFromContentFrame:")]
		void SetFrameFromContentFrame (CGRect contentFrame);

		[Export ("contentView")]
		NSObject ContentView { get; set; }

		[Export ("transparent")]
		bool Transparent { [Bind ("isTransparent")] get; set; }

		[Export ("setTitleWithMnemonic:")]
		[Deprecated (PlatformName.MacOSX, 10, 8, message: "For compatability, this method still sets the Title with the ampersand stripped from it.")]
		void SetTitleWithMnemonic (string stringWithMnemonic);

		[Export ("borderWidth")]
		nfloat BorderWidth { get; set; }

		[Export ("cornerRadius")]
		nfloat CornerRadius { get; set; }

		[ThreadSafe] // Bug 22909 - This can be called from a non-ui thread <= OS X 10.9
		[Export ("borderColor", ArgumentSemantic.Copy)]
		NSColor BorderColor { get; set; }

		[ThreadSafe] // Bug 22909 - This can be called from a non-ui thread <= OS X 10.9
		[Export ("fillColor", ArgumentSemantic.Copy)]
		NSColor FillColor { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	// , Delegates=new string [] { "Delegate" }, Events=new Type [] { typeof (NSBrowserDelegate)})]
	partial interface NSBrowser {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("loadColumnZero")]
		void LoadColumnZero ();

		[Export ("isLoaded")]
		bool Loaded { get; }

		[Export ("autohidesScroller")]
		bool AutohidesScroller { get; set; }

		[Export ("itemAtIndexPath:")]
		NSObject ItemAtIndexPath (NSIndexPath indexPath);

		[Export ("itemAtRow:inColumn:")]
		NSObject GetItem (nint row, nint column);

		[Export ("indexPathForColumn:")]
		NSIndexPath IndexPathForColumn (nint column);

		[Export ("isLeafItem:")]
		bool IsLeafItem (NSObject item);

		[Export ("reloadDataForRowIndexes:inColumn:")]
		void ReloadData (NSIndexSet rowIndexes, nint column);

		[Export ("parentForItemsInColumn:")]
		NSObject ParentForItems (nint column);

		[Export ("scrollRowToVisible:inColumn:")]
		void ScrollRowToVisible (nint row, nint column);

		[Export ("setTitle:ofColumn:")]
		void SetTitle (string aString, nint column);

		[Export ("titleOfColumn:")]
		string ColumnTitle (nint column);

		[Export ("pathToColumn:")]
		string ColumnPath (nint column);

		[Export ("clickedColumn")]
		nint ClickedColumn ();

		[Export ("clickedRow")]
		nint ClickedRow ();

		[Export ("selectedColumn")]
		nint SelectedColumn ();

		[Export ("selectedCell")]
		NSObject SelectedCell ();

		[Export ("selectedCellInColumn:")]
		NSObject SelectedCellInColumn (nint column);

		[Export ("selectedCells")]
		NSCell [] SelectedCells ();

		[Export ("selectRow:inColumn:")]
		void Select (nint row, nint column);

		[Export ("selectedRowInColumn:")]
		nint SelectedRow (nint column);

		[Export ("selectionIndexPath", ArgumentSemantic.Copy)]
		[NullAllowed]
		NSIndexPath SelectionIndexPath { get; set; }

		[Export ("selectionIndexPaths", ArgumentSemantic.Copy)]
		NSIndexPath [] SelectionIndexPaths { get; set; }

		[Export ("selectRowIndexes:inColumn:")]
		void SelectRowIndexes (NSIndexSet indexes, nint column);

		[Export ("selectedRowIndexesInColumn:")]
		NSIndexSet SelectedRowIndexes (nint column);

		[Export ("reloadColumn:")]
		void ReloadColumn (nint column);

		[Export ("validateVisibleColumns")]
		void ValidateVisibleColumns ();

		[Export ("scrollColumnsRightBy:")]
		void ScrollColumnsRightBy (nint shiftAmount);

		[Export ("scrollColumnsLeftBy:")]
		void ScrollColumnsLeftBy (nint shiftAmount);

		[Export ("scrollColumnToVisible:")]
		void ScrollColumnToVisible (nint column);

		[Export ("addColumn")]
		void AddColumn ();

		[Export ("numberOfVisibleColumns")]
		nint VisibleColumns { get; }

		[Export ("firstVisibleColumn")]
		nint FirstVisibleColumn { get; }

		[Export ("lastVisibleColumn")]
		nint LastVisibleColumn { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the item based NSBrowser instead.")]
		[Export ("columnOfMatrix:")]
		nint ColumnOfMatrix (NSMatrix matrix);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the item based NSBrowser instead.")]
		[Export ("matrixInColumn:")]
		NSMatrix MatrixInColumn (nint column);

		[Export ("loadedCellAtRow:column:")]
		NSCell LoadedCell (nint row, nint col);

		[Export ("selectAll:")]
		void SelectAll (NSObject sender);

		[Export ("tile")]
		void Tile ();

		[Export ("doClick:")]
		void DoClick (NSObject sender);

		[Export ("doDoubleClick:")]
		void DoDoubleClick (NSObject sender);

		[Export ("sendAction")]
		bool SendAction ();

		[Export ("titleFrameOfColumn:")]
		CGRect TitleFrameOfColumn (nint column);

		[Export ("drawTitleOfColumn:inRect:")]
		void DrawTitle (nint column, CGRect aRect);

		[Export ("titleHeight")]
		nfloat TitleHeight { get; }

		[Export ("frameOfColumn:")]
		CGRect ColumnFrame (nint column);

		[Export ("frameOfInsideOfColumn:")]
		CGRect ColumnInsideFrame (nint column);

		[Export ("frameOfRow:inColumn:")]
		CGRect RowFrame (nint row, nint column);

		[Export ("getRow:column:forPoint:")]
		bool GetRowColumnForPoint (out nint row, out nint column, CGPoint point);

		[Export ("columnWidthForColumnContentWidth:")]
		nfloat ColumnWidthForColumnContentWidth (nfloat columnContentWidth);

		[Export ("columnContentWidthForColumnWidth:")]
		nfloat ColumnContentWidthForColumnWidth (nfloat columnWidth);

		[Export ("columnResizingType")]
		NSBrowserColumnResizingType ColumnResizingType { get; set; }

		[Export ("prefersAllColumnUserResizing")]
		bool PrefersAllColumnUserResizing { get; set; }

		[Export ("setWidth:ofColumn:")]
		void SetColumnWidth (nfloat columnWidth, nint columnIndex);

		[Export ("widthOfColumn:")]
		nfloat GetColumnWidth (nint column);

		[Export ("rowHeight")]
		nfloat RowHeight { get; set; }

		[Export ("noteHeightOfRowsWithIndexesChanged:inColumn:")]
		void NoteHeightOfRows (NSIndexSet indexSet, nint columnIndex);

		[Export ("defaultColumnWidth")]
		nfloat DefaultColumnWidth { get; set; }

		[Export ("columnsAutosaveName")]
		string ColumnsAutosaveName { get; set; }

		[Static]
		[Export ("removeSavedColumnsWithAutosaveName:")]
		void RemoveSavedColumnsWithAutosaveName (string name);

		[Export ("canDragRowsWithIndexes:inColumn:withEvent:")]
		bool CanDragRowsWithIndexes (NSIndexSet rowIndexes, nint column, NSEvent theEvent);

		// FIXME: binding, NSPointPointer
		//[Export ("draggingImageForRowsWithIndexes:inColumn:withEvent:offset:")]
		//NSImage DraggingImageForRowsWithIndexes (NSIndexSet rowIndexes, int column, NSEvent theEvent, NSPointPointer dragImageOffset);

		[Export ("setDraggingSourceOperationMask:forLocal:")]
		void SetDraggingSourceOperationMask (NSDragOperation mask, bool isLocal);

		[Export ("allowsTypeSelect")]
		bool AllowsTypeSelect { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Retain)]
		NSColor BackgroundColor { get; set; }

		[Export ("editItemAtIndexPath:withEvent:select:")]
		void EditItemAtIndexPath (NSIndexPath indexPath, NSEvent theEvent, bool select);

		//Detected properties
		[NullAllowed]
		[Export ("doubleAction")]
		Selector DoubleAction { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the item based NSBrowser instead.")]
		[Export ("matrixClass")]
		Class MatrixClass { get; [Bind ("setMatrixClass:")] set; }

		[Static]
		[Export ("cellClass")]
		Class CellClass { get; }

		[Export ("setCellClass:")]
		void SetCellClass (Class factoryId);

		[Export ("cellPrototype", ArgumentSemantic.Retain)]
		NSObject CellPrototype { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSBrowserDelegate Delegate { get; set; }

		[Export ("reusesColumns")]
		bool ReusesColumns { get; set; }

		[Export ("hasHorizontalScroller")]
		bool HasHorizontalScroller { get; set; }

		[Export ("separatesColumns")]
		bool SeparatesColumns { get; set; }

		[Export ("titled")]
		bool Titled { [Bind ("isTitled")] get; set; }

		[Export ("minColumnWidth")]
		nfloat MinColumnWidth { get; set; }

		[Export ("maxVisibleColumns")]
		nint MaxVisibleColumns { get; set; }

		[Export ("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; set; }

		[Export ("allowsBranchSelection")]
		bool AllowsBranchSelection { get; set; }

		[Export ("allowsEmptySelection")]
		bool AllowsEmptySelection { get; set; }

		[Export ("takesTitleFromPreviousColumn")]
		bool TakesTitleFromPreviousColumn { get; set; }

		[Export ("sendsActionOnArrowKeys")]
		bool SendsActionOnArrowKeys { get; set; }

		[Export ("pathSeparator")]
		string PathSeparator { get; set; }

		[Export ("path"), Protected]
		string GetPath ();

		[Export ("setPath:"), Protected]
		bool SetPath (string path);

		[Export ("lastColumn")]
		nint LastColumn { get; set; }
	}

	interface INSBrowserDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSBrowserDelegate {
		[Export ("browser:numberOfRowsInColumn:"), EventArgs ("NSBrowserColumn")]
		nint RowsInColumn (NSBrowser sender, nint column);

		[Export ("browser:createRowsForColumn:inMatrix:")]
		void CreateRowsForColumn (NSBrowser sender, nint column, NSMatrix matrix);

		[Export ("browser:numberOfChildrenOfItem:")]
		nint CountChildren (NSBrowser browser, NSObject item);

		[Export ("browser:child:ofItem:")]
		NSObject GetChild (NSBrowser browser, nint index, NSObject item);

		[Export ("browser:isLeafItem:")]
		bool IsLeafItem (NSBrowser browser, NSObject item);

		[Export ("browser:objectValueForItem:")]
		NSObject ObjectValueForItem (NSBrowser browser, NSObject item);

		[Export ("browser:heightOfRow:inColumn:")]
		nfloat RowHeight (NSBrowser browser, nint row, nint columnIndex);

		[Export ("rootItemForBrowser:")]
		NSObject RootItemForBrowser (NSBrowser browser);

		[Export ("browser:setObjectValue:forItem:")]
		void SetObjectValue (NSBrowser browser, NSObject obj, NSObject item);

		[Export ("browser:shouldEditItem:")]
		bool ShouldEditItem (NSBrowser browser, NSObject item);

		[Export ("browser:willDisplayCell:atRow:column:")]
		void WillDisplayCell (NSBrowser sender, NSObject cell, nint row, nint column);

		[Export ("browser:titleOfColumn:")]
		string ColumnTitle (NSBrowser sender, nint column);

		[Export ("browser:selectCellWithString:inColumn:")]
		bool SelectCellWithString (NSBrowser sender, string title, nint column);

		[Export ("browser:selectRow:inColumn:")]
		bool SelectRowInColumn (NSBrowser sender, nint row, nint column);

		[Export ("browser:isColumnValid:")]
		bool IsColumnValid (NSBrowser sender, nint column);

		[Export ("browserWillScroll:")]
		void WillScroll (NSBrowser sender);

		[Export ("browserDidScroll:")]
		void DidScroll (NSBrowser sender);

		[Export ("browser:shouldSizeColumn:forUserResize:toWidth:")]
		nfloat ShouldSizeColumn (NSBrowser browser, nint columnIndex, bool userResize, nfloat suggestedWidth);

		[Export ("browser:sizeToFitWidthOfColumn:")]
		nfloat SizeToFitWidth (NSBrowser browser, nint columnIndex);

		[Export ("browserColumnConfigurationDidChange:")]
		void ColumnConfigurationDidChange (NSNotification notification);

		[Export ("browser:shouldShowCellExpansionForRow:column:")]
		bool ShouldShowCellExpansion (NSBrowser browser, nint row, nint column);

		[Export ("browser:writeRowsWithIndexes:inColumn:toPasteboard:")]
		bool WriteRowsWithIndexesToPasteboard (NSBrowser browser, NSIndexSet rowIndexes, nint column, NSPasteboard pasteboard);

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSFilePromiseReceiver' objects instead.")]
		[Export ("browser:namesOfPromisedFilesDroppedAtDestination:forDraggedRowsWithIndexes:inColumn:")]
		string [] PromisedFilesDroppedAtDestination (NSBrowser browser, NSUrl dropDestination, NSIndexSet rowIndexes, nint column);

		[Export ("browser:canDragRowsWithIndexes:inColumn:withEvent:")]
		bool CanDragRowsWithIndexes (NSBrowser browser, NSIndexSet rowIndexes, nint column, NSEvent theEvent);

		// FIXME: NSPOintPointer is a pointer to a CGPoint, so we need to support refs
		//[Export ("browser:draggingImageForRowsWithIndexes:inColumn:withEvent:offset:")]
		//NSImage DraggingImageForRowsWithIndexes (NSBrowser browser, NSIndexSet rowIndexes, int column, NSEvent theEvent, NSPointPointer dragImageOffset);

		[Export ("browser:validateDrop:proposedRow:column:dropOperation:")]
#if NET
		NSDragOperation ValidateDrop (NSBrowser browser, INSDraggingInfo info, ref nint row, ref nint column, ref NSBrowserDropOperation dropOperation);
#else
		NSDragOperation ValidateDrop (NSBrowser browser, NSDraggingInfo info, ref nint row, ref nint column, ref NSBrowserDropOperation dropOperation);
#endif

		[Export ("browser:acceptDrop:atRow:column:dropOperation:")]
#if NET
		bool AcceptDrop (NSBrowser browser, INSDraggingInfo info, nint row, nint column, NSBrowserDropOperation dropOperation);
#else
		bool AcceptDrop (NSBrowser browser, NSDraggingInfo info, nint row, nint column, NSBrowserDropOperation dropOperation);
#endif

		[return: NullAllowed]
		[Export ("browser:typeSelectStringForRow:inColumn:")]
		string TypeSelectString (NSBrowser browser, nint row, nint column);

		[Export ("browser:shouldTypeSelectForEvent:withCurrentSearchString:")]
		bool ShouldTypeSelectForEvent (NSBrowser browser, NSEvent theEvent, string currentSearchString);

		[Export ("browser:nextTypeSelectMatchFromRow:toRow:inColumn:forString:")]
		nint NextTypeSelectMatch (NSBrowser browser, nint startRow, nint endRow, nint column, string searchString);

		[Export ("browser:previewViewControllerForLeafItem:")]
		NSViewController PreviewViewControllerForLeafItem (NSBrowser browser, NSObject item);

		[Export ("browser:headerViewControllerForItem:")]
		NSViewController HeaderViewControllerForItem (NSBrowser browser, NSObject item);

		[Export ("browser:didChangeLastColumn:toColumn:")]
		void DidChangeLastColumn (NSBrowser browser, nint oldLastColumn, nint toColumn);

		[Export ("browser:selectionIndexesForProposedSelection:inColumn:")]
		NSIndexSet SelectionIndexesForProposedSelection (NSBrowser browser, NSIndexSet proposedSelectionIndexes, nint inColumn);

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSCell))]
	interface NSBrowserCell {
		[Export ("initTextCell:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string str);

		[Export ("initImageCell:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSImage image);

		[Static]
		[Export ("branchImage")]
		NSImage BranchImage { get; }

		[Static]
		[Export ("highlightedBranchImage")]
		NSImage HighlightedBranchImage { get; }

		[Export ("highlightColorInView:")]
		NSColor HighlightColorInView (NSView controlView);

		[Export ("reset")]
		void Reset ();

		[Export ("set")]
		void Set ();

		//Detected properties
		[Export ("leaf")]
		bool Leaf { [Bind ("isLeaf")] get; set; }

		[Export ("loaded")]
		bool Loaded { [Bind ("isLoaded")] get; set; }

		[Export ("image", ArgumentSemantic.Retain)]
		NSImage Image { get; set; }

		[Export ("alternateImage", ArgumentSemantic.Retain)]
		NSImage AlternateImage { get; set; }

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell))]
	interface NSButtonCell {
		[DesignatedInitializer]
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[DesignatedInitializer]
		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("title")]
		string Title { get; set; }

		[Export ("alternateTitle")]
		string AlternateTitle { get; set; }

		[Export ("alternateImage", ArgumentSemantic.Retain)]
		NSImage AlternateImage { get; set; }

		[Export ("imagePosition")]
		NSCellImagePosition ImagePosition { get; set; }

		[Export ("imageScaling")]
		NSImageScale ImageScale { get; set; }

		[Export ("highlightsBy")]
		nint HighlightsBy { get; set; }

		[Export ("showsStateBy")]
		nint ShowsStateBy { get; set; }

		[Export ("setButtonType:")]
		void SetButtonType (NSButtonType aType);

		[Export ("isOpaque")]
		bool IsOpaque { get; }

		[Export ("setFont:")]
		void SetFont (NSFont fontObj);

		[Export ("transparent")]
		bool Transparent { [Bind ("isTransparent")] get; set; }

		[Export ("setPeriodicDelay:interval:")]
		void SetPeriodicDelay (float /* float, not CGFloat */ delay, float /* float, not CGFloat */ interval);

		[Export ("getPeriodicDelay:interval:")]
		void GetPeriodicDelay (out float /* float, not CGFloat */ delay, out float /* float, not CGFloat */ interval);

		[Export ("keyEquivalent")]
		string KeyEquivalent { get; set; }

		[Export ("keyEquivalentModifierMask")]
		NSEventModifierMask KeyEquivalentModifierMask { get; set; }

		[NullAllowed, Export ("keyEquivalentFont", ArgumentSemantic.Strong)]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "It always returns the NSButtonCell's font.")]
		NSFont KeyEquivalentFont { get; set; }

		[Export ("setKeyEquivalentFont:size:")]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		void SetKeyEquivalentFont (string fontName, nfloat fontSize);

		[Export ("performClick:")]
		void PerformClick (NSObject sender);

		[Export ("drawImage:withFrame:inView:")]
		void DrawImage (NSImage image, CGRect frame, NSView controlView);

		[Export ("drawTitle:withFrame:inView:")]
		CGRect DrawTitle (NSAttributedString title, CGRect frame, NSView controlView);

		[Export ("drawBezelWithFrame:inView:")]
		void DrawBezelWithFrame (CGRect frame, NSView controlView);

		[Deprecated (PlatformName.MacOSX, 10, 8, message: "This method no longer does anything and should not be called.")]
		[Export ("alternateMnemonicLocation")]
		nint AlternateMnemonicLocation { get; set; }

		[Export ("alternateMnemonic")]
		[Deprecated (PlatformName.MacOSX, 10, 8, message: "This method still will set Title with the ampersand stripped from the value, but does nothing else. Set the Title directly.")]
		string AlternateMnemonic { get; [Bind ("setAlternateTitleWithMnemonic:")] set; }

		[Export ("setGradientType:")]
		[Deprecated (PlatformName.MacOSX, 10, 12, message: "The GradientType property is unused, and setting it has no effect.")]
		void SetGradientType (NSGradientType type);

		[Export ("imageDimsWhenDisabled")]
		bool ImageDimsWhenDisabled { get; set; }

		[Export ("showsBorderOnlyWhileMouseInside")]
		bool ShowsBorderOnlyWhileMouseInside { get; set; }

		[Export ("mouseEntered:")]
		void MouseEntered (NSEvent theEvent);

		[Export ("mouseExited:")]
		void MouseExited (NSEvent theEvent);

		[Export ("backgroundColor")]
		NSColor BackgroundColor { get; set; }

		[Export ("attributedTitle")]
		NSAttributedString AttributedTitle { get; set; }

		[Export ("attributedAlternateTitle")]
		NSAttributedString AttributedAlternateTitle { get; set; }

		[Export ("bezelStyle")]
		NSBezelStyle BezelStyle { get; set; }

		[Export ("sound")]
		NSSound Sound { get; set; }

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	[Dispose ("dispatcher = null;", Optimizable = true)]
	interface NSButton : NSAccessibilityButton, NSUserInterfaceCompression, NSUserInterfaceValidations {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Static]
		[Internal]
		[Export ("buttonWithTitle:image:target:action:")]
		NSButton _CreateButton (string title, NSImage image, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Internal]
		[Export ("buttonWithTitle:target:action:")]
		NSButton _CreateButton (string title, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Internal]
		[Export ("buttonWithImage:target:action:")]
		NSButton _CreateButton (NSImage image, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Internal]
		[Export ("checkboxWithTitle:target:action:")]
		NSButton _CreateCheckbox (string title, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Internal]
		[Export ("radioButtonWithTitle:target:action:")]
		NSButton _CreateRadioButton (string title, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Export ("title")]
		string Title { get; set; }

		[Export ("alternateTitle")]
		string AlternateTitle { get; set; }

		[Export ("image", ArgumentSemantic.Retain), NullAllowed]
		NSImage Image { get; set; }

		[Export ("alternateImage", ArgumentSemantic.Retain), NullAllowed]
		NSImage AlternateImage { get; set; }

		[Export ("imagePosition")]
		NSCellImagePosition ImagePosition { get; set; }

		[Export ("setButtonType:")]
		void SetButtonType (NSButtonType aType);

		[Export ("state")]
		NSCellStateValue State { get; set; }

		[Export ("bordered")]
		bool Bordered { [Bind ("isBordered")] get; set; }

		[Export ("transparent")]
		bool Transparent { [Bind ("isTransparent")] get; set; }

		[Export ("setPeriodicDelay:interval:")]
		void SetPeriodicDelay (float /* float, not CGFloat */ delay, /* float, not CGFloat */ float interval);

		[Export ("getPeriodicDelay:interval:")]
		void GetPeriodicDelay (ref float /* float, not CGFloat */ delay, ref float /* float, not CGFloat */ interval);

		[Export ("keyEquivalent")]
		string KeyEquivalent { get; set; }

		[Export ("keyEquivalentModifierMask")]
		NSEventModifierMask KeyEquivalentModifierMask { get; set; }

		[Export ("highlight:")]
		void Highlight (bool flag);

		[Export ("performKeyEquivalent:")]
		bool PerformKeyEquivalent (NSEvent key);

		[Deprecated (PlatformName.MacOSX, 10, 8, message: "On 10.8, this method still will set the Title with the ampersand stripped from stringWithAmpersand, but does nothing else. Set the Title directly.")]
		[Export ("setTitleWithMnemonic:")]
		void SetTitleWithMnemonic (string mnemonic);

		[Export ("attributedTitle")]
		NSAttributedString AttributedTitle { get; set; }

		[Export ("attributedAlternateTitle")]
		NSAttributedString AttributedAlternateTitle { get; set; }

		[Export ("bezelStyle")]
		NSBezelStyle BezelStyle { get; set; }

		[Export ("allowsMixedState")]
		bool AllowsMixedState { get; set; }

		[Export ("setNextState")]
		void SetNextState ();

		[Export ("showsBorderOnlyWhileMouseInside")]
		bool ShowsBorderOnlyWhileMouseInside { get; set; }

		[Export ("sound")]
		NSSound Sound { get; set; }

		[Export ("springLoaded")]
		bool IsSpringLoaded { [Bind ("isSpringLoaded")] get; set; }

		[Export ("maxAcceleratorLevel")]
		nint MaxAcceleratorLevel { get; set; }

		[Export ("imageHugsTitle")]
		bool ImageHugsTitle { get; set; }

		[NullAllowed]
		[Export ("symbolConfiguration", ArgumentSemantic.Copy)]
		NSImageSymbolConfiguration SymbolConfiguration { get; set; }

		[Export ("imageScaling")]
		NSImageScale ImageScaling { get; set; }

		[NullAllowed, Export ("bezelColor", ArgumentSemantic.Copy)]
		NSColor BezelColor { get; set; }

		[NullAllowed, Export ("contentTintColor", ArgumentSemantic.Copy)]
		NSColor ContentTintColor { get; set; }

		[Export ("hasDestructiveAction")]
		bool HasDestructiveAction { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSImageRep))]
	[DisableDefaultCtor] // An uncaught exception was raised: -[NSCachedImageRep init]: unrecognized selector sent to instance 0x14890e0
	[Deprecated (PlatformName.MacOSX, 10, 6)]
	interface NSCachedImageRep {
		[Deprecated (PlatformName.MacOSX, 10, 6)]
		[Export ("initWithWindow:rect:")]
		NativeHandle Constructor (NSWindow win, CGRect rect);

		[Deprecated (PlatformName.MacOSX, 10, 6)]
		[Export ("initWithSize:depth:separate:alpha:")]
		NativeHandle Constructor (CGSize size, NSWindowDepth depth, bool separate, bool alpha);

		[Deprecated (PlatformName.MacOSX, 10, 6)]
		[Export ("window")]
		NSWindow Window { get; }

		[Deprecated (PlatformName.MacOSX, 10, 6)]
		[Export ("rect")]
		CGRect Rectangle { get; }
	}



	[NoMacCatalyst]
	[BaseType (typeof (NSImageRep))]
	[DisableDefaultCtor] // An uncaught exception was raised: -[NSCIImageRep init]: unrecognized selector sent to instance 0x1b682a0
	interface NSCIImageRep {
		[Static]
		[Export ("imageRepWithCIImage:")]
		NSCIImageRep FromCIImage (CIImage image);

		[Export ("initWithCIImage:")]
		NativeHandle Constructor (CIImage image);

		[Export ("CIImage")]
		CIImage CIImage { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSGestureRecognizer))]
	interface NSClickGestureRecognizer : NSCoding {
		[Export ("initWithTarget:action:")]
		NativeHandle Constructor (NSObject target, Selector action);

		[Export ("buttonMask")]
		nuint ButtonMask { get; set; }

		[Export ("numberOfClicksRequired")]
		nint NumberOfClicksRequired { get; set; }

		[Export ("numberOfTouchesRequired")]
		nint NumberOfTouchesRequired { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSClipView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[Export ("documentView")]
		NSView DocumentView { get; set; }

		[Export ("documentRect")]
		CGRect DocumentRect { get; }

		[Export ("documentCursor", ArgumentSemantic.Retain)]
		NSCursor DocumentCursor { get; set; }

		[Export ("documentVisibleRect")]
		CGRect DocumentVisibleRect ();

		[Export ("viewFrameChanged:")]
		void ViewFrameChanged (NSNotification notification);

		[Export ("viewBoundsChanged:")]
		void ViewBoundsChanged (NSNotification notification);

		[Export ("copiesOnScroll")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "'NSClipView' minimizes area of the document view that is invalidated. Use the 'SetNeedsDisplayInRect' method to force invalidation.")]
		bool CopiesOnScroll { get; set; }

		[Export ("autoscroll:")]
		bool Autoscroll (NSEvent theEvent);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use ConstrainBoundsRect instead.")]
		[Export ("constrainScrollPoint:")]
		CGPoint ConstrainScrollPoint (CGPoint newOrigin);

		[Export ("constrainBoundsRect:")]
		CGRect ConstrainBoundsRect (CGRect proposedBounds);

		[Export ("scrollToPoint:")]
		void ScrollToPoint (CGPoint newOrigin);

		[Export ("scrollClipView:toPoint:")]
		void ScrollClipView (NSClipView aClipView, CGPoint aPoint);

		[Export ("contentInsets")]
		NSEdgeInsets ContentInsets { get; set; }

		[Export ("automaticallyAdjustsContentInsets")]
		bool AutomaticallyAdjustsContentInsets { get; set; }
	}

	[NoMacCatalyst]
	[Category, BaseType (typeof (NSCoder))]
	partial interface NSCoderAppKitAddons {
		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("decodeNXColor")]
		NSColor DecodeNXColor ();
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSViewController))]
	interface NSCollectionViewItem : NSCopying {
		[Export ("initWithNibName:bundle:")]
		NativeHandle Constructor ([NullAllowed] string nibNameOrNull, [NullAllowed] NSBundle nibBundleOrNull);

		[Export ("collectionView")]
		[NullAllowed]
		NSCollectionView CollectionView { get; }

		[Export ("selected")]
		bool Selected { [Bind ("isSelected")] get; set; }

		[Export ("imageView", ArgumentSemantic.Assign)]
		NSImageView ImageView { get; set; }

		[Export ("textField", ArgumentSemantic.Assign)]
		NSTextField TextField { get; set; }

		[Export ("draggingImageComponents")]
		NSDraggingImageComponent [] DraggingImageComponents { get; }

		[Export ("highlightState", ArgumentSemantic.Assign)]
		NSCollectionViewItemHighlightState HighlightState { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSCollectionView : NSDraggingSource, NSDraggingDestination {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("isFirstResponder")]
		bool IsFirstResponder { get; }

		[Export ("newItemForRepresentedObject:")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSCollectionViewDataSource.GetItem()' instead.")]
		[return: Release ()]
		NSCollectionViewItem NewItemForRepresentedObject (NSObject obj);

		[return: NullAllowed]
		[Export ("itemAtIndex:")]
#if NET
		NSCollectionViewItem GetItem (nint index);
#else
		NSCollectionViewItem ItemAtIndex (nint index);
#endif

		[Export ("frameForItemAtIndex:")]
#if NET
		CGRect GetFrameForItem (nint index);
#else
		CGRect FrameForItemAtIndex (nint index);
#endif

		[Export ("setDraggingSourceOperationMask:forLocal:")]
		void SetDraggingSource (NSDragOperation dragOperationMask, bool localDestination);

		//[Export ("draggingImageForItemsAtIndexes:withEvent:offset:")]
		//NSImage DraggingImage (NSIndexSet itemIndexes, NSEvent evt, NSPointPointer dragImageOffset);

		//Detected properties
		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSCollectionViewDelegate Delegate { get; set; }

		[Export ("content", ArgumentSemantic.Copy)]
		NSObject [] Content { get; set; }

		[Export ("selectable")]
		bool Selectable { [Bind ("isSelectable")] get; set; }

		[Export ("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; set; }

		[Export ("selectionIndexes", ArgumentSemantic.Copy)]
		NSIndexSet SelectionIndexes { get; set; }

		[Export ("itemPrototype", ArgumentSemantic.Retain)]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'RegisterNib' or 'RegisterClassForItem' instead.")]
		NSCollectionViewItem ItemPrototype { get; set; }

		[Export ("maxNumberOfRows")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Set a NSCollectionViewGridLayout on CollectionViewLayout and set its 'MaximumNumberOfRows' instead.")]
		nint MaxNumberOfRows { get; set; }

		[Export ("maxNumberOfColumns")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Set a NSCollectionViewGridLayout on CollectionViewLayout and set its 'MaximumNumberOfColumns' instead.")]
		nint MaxNumberOfColumns { get; set; }

		[Export ("minItemSize")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Set a NSCollectionViewGridLayout on CollectionViewLayout and set its 'MinimumItemSize' instead.")]
		CGSize MinItemSize { get; set; }

		[Export ("maxItemSize")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Set a NSCollectionViewGridLayout on CollectionViewLayout and set its 'MaximumItemSize' instead.")]
		CGSize MaxItemSize { get; set; }

		[Export ("backgroundColors", ArgumentSemantic.Copy), NullAllowed]
		NSColor [] BackgroundColors { get; set; }

		[Export ("frameForItemAtIndex:withNumberOfItems:")]
#if NET
		CGRect GetFrameForItem (nint index, nint numberOfItems);
#else
		CGRect FrameForItemAtIndex (nint index, nint numberOfItems);
#endif

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		INSCollectionViewDataSource DataSource { get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		[NullAllowed, Export ("backgroundView", ArgumentSemantic.Strong)]
		NSView BackgroundView { get; set; }

		[NullAllowed, Export ("collectionViewLayout", ArgumentSemantic.Strong)]
		NSCollectionViewLayout CollectionViewLayout { get; set; }

		[Export ("layoutAttributesForItemAtIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetLayoutAttributes (NSIndexPath indexPath);

		[Export ("layoutAttributesForSupplementaryElementOfKind:atIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetLayoutAttributes (string kind, NSIndexPath indexPath);

		// -(NSInteger)numberOfSections __attribute__((availability(macosx, introduced=10.11)));
		[Export ("numberOfSections")]
		// [Verify (MethodToProperty)]
		nint NumberOfSections { get; }

		[Export ("numberOfItemsInSection:")]
		nint GetNumberOfItems (nint section);

		[Export ("allowsEmptySelection")]
		bool AllowsEmptySelection { get; set; }

		[Export ("selectionIndexPaths", ArgumentSemantic.Copy)]
		NSSet SelectionIndexPaths { get; set; }

		[Export ("selectItemsAtIndexPaths:scrollPosition:")]
		void SelectItems (NSSet indexPaths, NSCollectionViewScrollPosition scrollPosition);

		[Export ("deselectItemsAtIndexPaths:")]
		void DeselectItems (NSSet indexPaths);

		[Export ("registerClass:forItemWithIdentifier:"), Internal]
		void _RegisterClassForItem ([NullAllowed] IntPtr itemClass, string identifier);

		[Export ("registerNib:forItemWithIdentifier:")]
		void RegisterNib ([NullAllowed] NSNib nib, string identifier);

		[Export ("registerClass:forSupplementaryViewOfKind:withIdentifier:"), Internal]
		void _RegisterClassForSupplementaryView ([NullAllowed] IntPtr viewClass, NSString kind, string identifier);

		[Export ("registerNib:forSupplementaryViewOfKind:withIdentifier:")]
		void RegisterNib ([NullAllowed] NSNib nib, NSString kind, string identifier);

		[Export ("makeItemWithIdentifier:forIndexPath:")]
		NSCollectionViewItem MakeItem (string identifier, NSIndexPath indexPath);

		[Export ("makeSupplementaryViewOfKind:withIdentifier:forIndexPath:")]
		NSView MakeSupplementaryView (NSString elementKind, string identifier, NSIndexPath indexPath);

		[Export ("itemAtIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewItem GetItem (NSIndexPath indexPath);

		[Export ("visibleItems")]
		// [Verify (MethodToProperty)]
		NSCollectionViewItem [] VisibleItems { get; }

		[Export ("indexPathsForVisibleItems")]
		// [Verify (MethodToProperty)]
		NSSet<NSIndexPath> IndexPathsForVisibleItems { get; }

		[Export ("indexPathForItem:")]
		[return: NullAllowed]
		NSIndexPath GetIndexPath (NSCollectionViewItem item);

		[Export ("indexPathForItemAtPoint:")]
		[return: NullAllowed]
		NSIndexPath GetIndexPath (CGPoint point);

		// -(NSView<NSCollectionViewElement> * __nullable)supplementaryViewForElementKind:(NSString * __nonnull)elementKind atIndexPath:(NSIndexPath * __nonnull)indexPath __attribute__((availability(macosx, introduced=10.11)));
		[Export ("supplementaryViewForElementKind:atIndexPath:")]
		[return: NullAllowed]
		INSCollectionViewElement GetSupplementaryView (NSString elementKind, NSIndexPath indexPath);

		// -(NSArray<NSView<NSCollectionViewElement> * __nonnull> * __nonnull)visibleSupplementaryViewsOfKind:(NSString * __nonnull)elementKind __attribute__((availability(macosx, introduced=10.11)));
		[Export ("visibleSupplementaryViewsOfKind:")]
		INSCollectionViewElement [] GetVisibleSupplementaryViews (NSString elementKind);

		[Export ("indexPathsForVisibleSupplementaryElementsOfKind:")]
		NSSet GetIndexPaths (string elementKind);

		[Export ("insertSections:")]
		void InsertSections (NSIndexSet sections);

		[Export ("deleteSections:")]
		void DeleteSections (NSIndexSet sections);

		[Export ("reloadSections:")]
		void ReloadSections (NSIndexSet sections);

		[Export ("moveSection:toSection:")]
		void MoveSection (nint section, nint newSection);

		[Export ("insertItemsAtIndexPaths:")]
		void InsertItems (NSSet<NSIndexPath> indexPaths);

		[Export ("deleteItemsAtIndexPaths:")]
		void DeleteItems (NSSet<NSIndexPath> indexPaths);

		[Export ("reloadItemsAtIndexPaths:")]
		void ReloadItems (NSSet<NSIndexPath> indexPaths);

		[Export ("moveItemAtIndexPath:toIndexPath:")]
		void MoveItem (NSIndexPath indexPath, NSIndexPath newIndexPath);

		[Export ("performBatchUpdates:completionHandler:")]
		void PerformBatchUpdates (Action updates, Action<bool> completionHandler);

		[Export ("scrollToItemsAtIndexPaths:scrollPosition:")]
		void ScrollToItems (NSSet<NSIndexPath> indexPaths, NSCollectionViewScrollPosition scrollPosition);

		[Export ("draggingImageForItemsAtIndexPaths:withEvent:offset:")]
		NSImage GetDraggingImage (NSSet<NSIndexPath> indexPaths, NSEvent theEvent, ref CGPoint dragImageOffset);

		[Export ("selectAll:")]
		void SelectAll ([NullAllowed] NSObject sender);

		[Export ("deselectAll:")]
		void DeselectAll ([NullAllowed] NSObject sender);

		[Export ("backgroundViewScrollsWithContent")]
		bool BackgroundViewScrollsWithContent { get; set; }

		[Export ("toggleSectionCollapse:")]
		void ToggleSectionCollapse (NSObject sender);

		[NullAllowed, Export ("prefetchDataSource", ArgumentSemantic.Weak)]
		INSCollectionViewPrefetching PrefetchDataSource { get; set; }
	}

	interface INSCollectionViewDataSource { }

	// @protocol NSCollectionViewDataSource <NSObject>
	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSCollectionViewDataSource {
		[Abstract]
		[Export ("collectionView:numberOfItemsInSection:")]
		nint GetNumberofItems (NSCollectionView collectionView, nint section);

		[Abstract]
		[Export ("collectionView:itemForRepresentedObjectAtIndexPath:")]
		NSCollectionViewItem GetItem (NSCollectionView collectionView, NSIndexPath indexPath);

		[Export ("numberOfSectionsInCollectionView:")]
		nint GetNumberOfSections (NSCollectionView collectionView);

		[Export ("collectionView:viewForSupplementaryElementOfKind:atIndexPath:")]
		NSView GetView (NSCollectionView collectionView, NSString kind, NSIndexPath indexPath);
	}

	interface INSCollectionViewDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface NSCollectionViewDelegate {
		[Export ("collectionView:canDragItemsAtIndexes:withEvent:")]
		bool CanDragItems (NSCollectionView collectionView, NSIndexSet indexes, NSEvent evt);

		[Export ("collectionView:writeItemsAtIndexes:toPasteboard:")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use the 'GetPasteboardWriter' method instead.")]
		bool WriteItems (NSCollectionView collectionView, NSIndexSet indexes, NSPasteboard toPasteboard);

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSFilePromiseReceiver' objects instead.")]
		[Export ("collectionView:namesOfPromisedFilesDroppedAtDestination:forDraggedItemsAtIndexes:")]
		string [] NamesOfPromisedFilesDroppedAtDestination (NSCollectionView collectionView, NSUrl dropUrl, NSIndexSet indexes);

		//[Export ("collectionView:draggingImageForItemsAtIndexes:withEvent:offset:")]
		//NSImage DraggingImageForItems (NSCollectionView collectionView, NSIndexSet indexes, NSEvent evg, NSPointPointer dragImageOffset);

		[Export ("collectionView:validateDrop:proposedIndex:dropOperation:")]
#if NET
		NSDragOperation ValidateDrop (NSCollectionView collectionView, INSDraggingInfo draggingInfo, ref nint dropIndex, ref NSCollectionViewDropOperation dropOperation);
#else
		NSDragOperation ValidateDrop (NSCollectionView collectionView, NSDraggingInfo draggingInfo, ref nint dropIndex, ref NSCollectionViewDropOperation dropOperation);
#endif

		[Export ("collectionView:acceptDrop:index:dropOperation:")]
#if NET
		bool AcceptDrop (NSCollectionView collectionView, INSDraggingInfo draggingInfo, nint index, NSCollectionViewDropOperation dropOperation);
#else
		bool AcceptDrop (NSCollectionView collectionView, NSDraggingInfo draggingInfo, nint index, NSCollectionViewDropOperation dropOperation);
#endif

		[Export ("collectionView:canDragItemsAtIndexPaths:withEvent:")]
		bool CanDragItems (NSCollectionView collectionView, NSSet indexPaths, NSEvent theEvent);

		[Export ("collectionView:writeItemsAtIndexPaths:toPasteboard:")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use the 'GetPasteboardWriter' method instead.")]
		bool WriteItems (NSCollectionView collectionView, NSSet indexPaths, NSPasteboard pasteboard);

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSFilePromiseReceiver' objects instead.")]
		[Export ("collectionView:namesOfPromisedFilesDroppedAtDestination:forDraggedItemsAtIndexPaths:")]
		string [] GetNamesOfPromisedFiles (NSCollectionView collectionView, NSUrl dropURL, NSSet indexPaths);

		[Export ("collectionView:draggingImageForItemsAtIndexPaths:withEvent:offset:")]
		NSImage GetDraggingImage (NSCollectionView collectionView, NSSet indexPaths, NSEvent theEvent, ref CGPoint dragImageOffset);

#if !NET
		[Export ("collectionView:validateDrop:proposedIndexPath:dropOperation:")]
		NSDragOperation ValidateDropOperation (NSCollectionView collectionView, NSDraggingInfo draggingInfo, ref NSIndexPath proposedDropIndexPath, ref NSCollectionViewDropOperation proposedDropOperation);
#else
		[Export ("collectionView:validateDrop:proposedIndexPath:dropOperation:")]
		NSDragOperation ValidateDrop (NSCollectionView collectionView, INSDraggingInfo draggingInfo, ref NSIndexPath proposedDropIndexPath, ref NSCollectionViewDropOperation proposedDropOperation);
#endif

		[Export ("collectionView:acceptDrop:indexPath:dropOperation:")]
#if NET
		bool AcceptDrop (NSCollectionView collectionView, INSDraggingInfo draggingInfo, NSIndexPath indexPath, NSCollectionViewDropOperation dropOperation);
#else
		bool AcceptDrop (NSCollectionView collectionView, NSDraggingInfo draggingInfo, NSIndexPath indexPath, NSCollectionViewDropOperation dropOperation);
#endif

		[Export ("collectionView:pasteboardWriterForItemAtIndexPath:")]
		[return: NullAllowed]
		INSPasteboardWriting GetPasteboardWriter (NSCollectionView collectionView, NSIndexPath indexPath);

		[Export ("collectionView:draggingSession:willBeginAtPoint:forItemsAtIndexPaths:")]
		void DraggingSessionWillBegin (NSCollectionView collectionView, NSDraggingSession session, CGPoint screenPoint, NSSet indexPaths);

		[Export ("collectionView:shouldChangeItemsAtIndexPaths:toHighlightState:")]
		NSSet ShouldChangeItems (NSCollectionView collectionView, NSSet indexPaths, NSCollectionViewItemHighlightState highlightState);

		[Export ("collectionView:didChangeItemsAtIndexPaths:toHighlightState:")]
		void ItemsChanged (NSCollectionView collectionView, NSSet indexPaths, NSCollectionViewItemHighlightState highlightState);

		[Export ("collectionView:shouldSelectItemsAtIndexPaths:")]
		NSSet ShouldSelectItems (NSCollectionView collectionView, NSSet indexPaths);

		[Export ("collectionView:shouldDeselectItemsAtIndexPaths:")]
		NSSet ShouldDeselectItems (NSCollectionView collectionView, NSSet indexPaths);

		[Export ("collectionView:didSelectItemsAtIndexPaths:")]
		void ItemsSelected (NSCollectionView collectionView, NSSet indexPaths);

		[Export ("collectionView:didDeselectItemsAtIndexPaths:")]
		void ItemsDeselected (NSCollectionView collectionView, NSSet indexPaths);

		[Export ("collectionView:willDisplayItem:forRepresentedObjectAtIndexPath:")]
		void WillDisplayItem (NSCollectionView collectionView, NSCollectionViewItem item, NSIndexPath indexPath);

		[Export ("collectionView:willDisplaySupplementaryView:forElementKind:atIndexPath:")]
		void WillDisplaySupplementaryView (NSCollectionView collectionView, NSView view, NSString elementKind, NSIndexPath indexPath);

		[Export ("collectionView:didEndDisplayingItem:forRepresentedObjectAtIndexPath:")]
		void DisplayingItemEnded (NSCollectionView collectionView, NSCollectionViewItem item, NSIndexPath indexPath);

		[Export ("collectionView:didEndDisplayingSupplementaryView:forElementOfKind:atIndexPath:")]
		void DisplayingSupplementaryViewEnded (NSCollectionView collectionView, NSView view, string elementKind, NSIndexPath indexPath);

		[Export ("collectionView:transitionLayoutForOldLayout:newLayout:")]
		NSCollectionViewTransitionLayout TransitionLayout (NSCollectionView collectionView, NSCollectionViewLayout fromLayout, NSCollectionViewLayout toLayout);
	}

	interface INSCollectionViewElement { }

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSCollectionViewElement : NSUserInterfaceItemIdentification {
		[Export ("prepareForReuse")]
		void PrepareForReuse ();

		[Export ("applyLayoutAttributes:")]
		void ApplyLayoutAttributes (NSCollectionViewLayoutAttributes layoutAttributes);

		[Export ("willTransitionFromLayout:toLayout:")]
		void WillTransition (NSCollectionViewLayout oldLayout, NSCollectionViewLayout newLayout);

		[Export ("didTransitionFromLayout:toLayout:")]
		void DidTransition (NSCollectionViewLayout oldLayout, NSCollectionViewLayout newLayout);

		[Export ("preferredLayoutAttributesFittingAttributes:")]
		NSCollectionViewLayoutAttributes GetPreferredLayoutAttributes (NSCollectionViewLayoutAttributes layoutAttributes);
	}

	[Static]
	[NoMacCatalyst]
	interface NSCollectionElementKind {
		[Field ("NSCollectionElementKindInterItemGapIndicator")]
		NSString InterItemGapIndicator { get; }

		[Field ("NSCollectionElementKindSectionHeader")]
		NSString SectionHeader { get; }

		[Field ("NSCollectionElementKindSectionFooter")]
		NSString SectionFooter { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSCollectionViewLayoutAttributes : NSCopying {
		[Export ("frame", ArgumentSemantic.Assign)]
		CGRect Frame { get; set; }

		[Export ("size", ArgumentSemantic.Assign)]
		CGSize Size { get; set; }

		[Export ("alpha", ArgumentSemantic.Assign)]
		nfloat Alpha { get; set; }

		[Export ("zIndex", ArgumentSemantic.Assign)]
		nint ZIndex { get; set; }

		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

		[NullAllowed, Export ("indexPath", ArgumentSemantic.Strong)]
		NSIndexPath IndexPath { get; set; }

		[Export ("representedElementCategory")]
		NSCollectionElementCategory RepresentedElementCategory { get; }

		[NullAllowed, Export ("representedElementKind")]
		string RepresentedElementKind { get; }

		[Static]
		[Export ("layoutAttributesForItemWithIndexPath:")]
		NSCollectionViewLayoutAttributes CreateForItem (NSIndexPath indexPath);

		[Static]
		[Export ("layoutAttributesForInterItemGapBeforeIndexPath:")]
		NSCollectionViewLayoutAttributes CreateForInterItemGap (NSIndexPath indexPath);

		[Static]
		[Export ("layoutAttributesForSupplementaryViewOfKind:withIndexPath:")]
		NSCollectionViewLayoutAttributes CreateForSupplementaryView (NSString elementKind, NSIndexPath indexPath);

		[Static]
		[Export ("layoutAttributesForDecorationViewOfKind:withIndexPath:")]
		NSCollectionViewLayoutAttributes CreateForDecorationView (NSString decorationViewKind, NSIndexPath indexPath);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSCollectionViewUpdateItem {
		[NullAllowed, Export ("indexPathBeforeUpdate")]
		NSIndexPath IndexPathBeforeUpdate { get; }

		[NullAllowed, Export ("indexPathAfterUpdate")]
		NSIndexPath IndexPathAfterUpdate { get; }

		[Export ("updateAction")]
		NSCollectionUpdateAction UpdateAction { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSCollectionViewLayoutInvalidationContext {
		[Export ("invalidateEverything")]
		bool InvalidateEverything { get; }

		[Export ("invalidateDataSourceCounts")]
		bool InvalidateDataSourceCounts { get; }

		[Export ("invalidateItemsAtIndexPaths:")]
		void InvalidateItems (NSSet indexPaths);

		[Export ("invalidateSupplementaryElementsOfKind:atIndexPaths:")]
		void InvalidateSupplementaryElements (NSString elementKind, NSSet indexPaths);

		[Export ("invalidateDecorationElementsOfKind:atIndexPaths:")]
		void InvalidateDecorationElements (NSString elementKind, NSSet indexPaths);

		[Export ("invalidatedItemIndexPaths")]
		NSSet InvalidatedItemIndexPaths { get; }

		[Export ("invalidatedSupplementaryIndexPaths")]
		NSDictionary InvalidatedSupplementaryIndexPaths { get; }

		[Export ("invalidatedDecorationIndexPaths")]
		NSDictionary InvalidatedDecorationIndexPaths { get; }

		[Export ("contentOffsetAdjustment", ArgumentSemantic.Assign)]
		CGPoint ContentOffsetAdjustment { get; set; }

		[Export ("contentSizeAdjustment", ArgumentSemantic.Assign)]
		CGSize ContentSizeAdjustment { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSCollectionViewLayout : NSCoding {
		[NullAllowed, Export ("collectionView", ArgumentSemantic.Weak)]
		NSCollectionView CollectionView { get; }

		[Export ("invalidateLayout")]
		void InvalidateLayout ();

		[Export ("invalidateLayoutWithContext:")]
		void InvalidateLayout (NSCollectionViewLayoutInvalidationContext context);

		[Export ("registerClass:forDecorationViewOfKind:"), Internal]
		void _RegisterClassForDecorationView ([NullAllowed] IntPtr viewClass, NSString elementKind);

		[Export ("registerNib:forDecorationViewOfKind:")]
		void RegisterNib ([NullAllowed] NSNib nib, NSString elementKind);

		//
		// NSSubclassingHooks
		//

		// +(__nonnull Class)layoutAttributesClass;
		[Static]
		[Export ("layoutAttributesClass")]
		// [Verify (MethodToProperty)]
		Class LayoutAttributesClass { get; }

		// +(__nonnull Class)invalidationContextClass;
		[Static]
		[Export ("invalidationContextClass")]
		// [Verify (MethodToProperty)]
		Class InvalidationContextClass { get; }

		[Export ("prepareLayout")]
		void PrepareLayout ();

		// -(__nonnull NSArray *)layoutAttributesForElementsInRect:(NSRect)rect;
		[Export ("layoutAttributesForElementsInRect:")]
		// [Verify (StronglyTypedNSArray)]
		NSCollectionViewLayoutAttributes [] GetLayoutAttributesForElements (CGRect rect);

		[Export ("layoutAttributesForItemAtIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetLayoutAttributesForItem (NSIndexPath indexPath);

		[Export ("layoutAttributesForSupplementaryViewOfKind:atIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetLayoutAttributesForSupplementaryView (NSString elementKind, NSIndexPath indexPath);

		[Export ("layoutAttributesForDecorationViewOfKind:atIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetLayoutAttributesForDecorationView (NSString elementKind, NSIndexPath indexPath);

		[Export ("layoutAttributesForDropTargetAtPoint:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetLayoutAttributesForDropTarget (CGPoint pointInCollectionView);

		[Export ("layoutAttributesForInterItemGapBeforeIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetLayoutAttributesForInterItemGap (NSIndexPath indexPath);

		[Export ("shouldInvalidateLayoutForBoundsChange:")]
		bool ShouldInvalidateLayout (CGRect newBounds);

		[Export ("invalidationContextForBoundsChange:")]
		NSCollectionViewLayoutInvalidationContext GetInvalidationContext (CGRect newBounds);

		[Export ("shouldInvalidateLayoutForPreferredLayoutAttributes:withOriginalAttributes:")]
		bool ShouldInvalidateLayout (NSCollectionViewLayoutAttributes preferredAttributes, NSCollectionViewLayoutAttributes originalAttributes);

		[Export ("invalidationContextForPreferredLayoutAttributes:withOriginalAttributes:")]
		NSCollectionViewLayoutInvalidationContext GetInvalidationContext (NSCollectionViewLayoutAttributes preferredAttributes, NSCollectionViewLayoutAttributes originalAttributes);

		[Export ("targetContentOffsetForProposedContentOffset:withScrollingVelocity:")]
		CGPoint GetTargetContentOffset (CGPoint proposedContentOffset, CGPoint velocity);

		[Export ("targetContentOffsetForProposedContentOffset:")]
		CGPoint GetTargetContentOffset (CGPoint proposedContentOffset);

		[Export ("collectionViewContentSize")]
		// [Verify (MethodToProperty)]
		CGSize CollectionViewContentSize { get; }

		//
		// NSUpdateSupportHooks
		//

		[Export ("prepareForCollectionViewUpdates:")]
		void PrepareForCollectionViewUpdates (NSCollectionViewUpdateItem [] updateItems);

		[Export ("finalizeCollectionViewUpdates")]
		void FinalizeCollectionViewUpdates ();

		[Export ("prepareForAnimatedBoundsChange:")]
		void PrepareForAnimatedBoundsChange (CGRect oldBounds);

		[Export ("finalizeAnimatedBoundsChange")]
		void FinalizeAnimatedBoundsChange ();

		[Export ("prepareForTransitionToLayout:")]
		void PrepareForTransitionToLayout (NSCollectionViewLayout newLayout);

		[Export ("prepareForTransitionFromLayout:")]
		void PrepareForTransitionFromLayout (NSCollectionViewLayout oldLayout);

		[Export ("finalizeLayoutTransition")]
		void FinalizeLayoutTransition ();

		[Export ("initialLayoutAttributesForAppearingItemAtIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetInitialLayoutAttributesForAppearingItem (NSIndexPath itemIndexPath);

		[Export ("finalLayoutAttributesForDisappearingItemAtIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetFinalLayoutAttributesForDisappearingItem (NSIndexPath itemIndexPath);

		[Export ("initialLayoutAttributesForAppearingSupplementaryElementOfKind:atIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetInitialLayoutAttributesForAppearingSupplementaryElement (NSString elementKind, NSIndexPath elementIndexPath);

		[Export ("finalLayoutAttributesForDisappearingSupplementaryElementOfKind:atIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetFinalLayoutAttributesForDisappearingSupplementaryElement (NSString elementKind, NSIndexPath elementIndexPath);

		[Export ("initialLayoutAttributesForAppearingDecorationElementOfKind:atIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetInitialLayoutAttributesForAppearingDecorationElement (NSString elementKind, NSIndexPath decorationIndexPath);

		[Export ("finalLayoutAttributesForDisappearingDecorationElementOfKind:atIndexPath:")]
		[return: NullAllowed]
		NSCollectionViewLayoutAttributes GetFinalLayoutAttributesForDisappearingDecorationElement (NSString elementKind, NSIndexPath decorationIndexPath);

		[Export ("indexPathsToDeleteForSupplementaryViewOfKind:")]
		NSSet GetIndexPathsToDeleteForSupplementaryView (NSString elementKind);

		[Export ("indexPathsToDeleteForDecorationViewOfKind:")]
		NSSet GetIndexPathsToDeleteForDecorationView (NSString elementKind);

		[Export ("indexPathsToInsertForSupplementaryViewOfKind:")]
		NSSet GetIndexPathsToInsertForSupplementaryView (NSString elementKind);

		[Export ("indexPathsToInsertForDecorationViewOfKind:")]
		NSSet GetIndexPathsToInsertForDecorationView (NSString elementKind);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSCollectionViewLayoutInvalidationContext))]
	interface NSCollectionViewFlowLayoutInvalidationContext {
		[Export ("invalidateFlowLayoutDelegateMetrics")]
		bool InvalidateFlowLayoutDelegateMetrics { get; set; }

		[Export ("invalidateFlowLayoutAttributes")]
		bool InvalidateFlowLayoutAttributes { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Protocol, Model]
	interface NSCollectionViewDelegateFlowLayout : NSCollectionViewDelegate {
		[Export ("collectionView:layout:sizeForItemAtIndexPath:")]
		CGSize SizeForItem (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, NSIndexPath indexPath);

		[Export ("collectionView:layout:insetForSectionAtIndex:")]
		NSEdgeInsets InsetForSection (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section);

		[Export ("collectionView:layout:minimumLineSpacingForSectionAtIndex:")]
		nfloat MinimumLineSpacing (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section);

		[Export ("collectionView:layout:minimumInteritemSpacingForSectionAtIndex:")]
		nfloat MinimumInteritemSpacingForSection (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section);

		[Export ("collectionView:layout:referenceSizeForHeaderInSection:")]
		CGSize ReferenceSizeForHeader (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section);

		[Export ("collectionView:layout:referenceSizeForFooterInSection:")]
		CGSize ReferenceSizeForFooter (NSCollectionView collectionView, NSCollectionViewLayout collectionViewLayout, nint section);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSCollectionViewLayout))]
	interface NSCollectionViewFlowLayout {
		[Export ("minimumLineSpacing", ArgumentSemantic.Assign)]
		nfloat MinimumLineSpacing { get; set; }

		[Export ("minimumInteritemSpacing", ArgumentSemantic.Assign)]
		nfloat MinimumInteritemSpacing { get; set; }

		[Export ("itemSize", ArgumentSemantic.Assign)]
		CGSize ItemSize { get; set; }

		[Export ("estimatedItemSize", ArgumentSemantic.Assign)]
		CGSize EstimatedItemSize { get; set; }

		[Export ("scrollDirection", ArgumentSemantic.Assign)]
		NSCollectionViewScrollDirection ScrollDirection { get; set; }

		[Export ("headerReferenceSize", ArgumentSemantic.Assign)]
		CGSize HeaderReferenceSize { get; set; }

		[Export ("footerReferenceSize", ArgumentSemantic.Assign)]
		CGSize FooterReferenceSize { get; set; }

		[Export ("sectionInset", ArgumentSemantic.Assign)]
		NSEdgeInsets SectionInset { get; set; }

		[Export ("sectionHeadersPinToVisibleBounds")]
		bool SectionHeadersPinToVisibleBounds { get; set; }

		[Export ("sectionFootersPinToVisibleBounds")]
		bool SectionFootersPinToVisibleBounds { get; set; }

		[Export ("sectionAtIndexIsCollapsed:")]
		bool SectionAtIndexIsCollapsed (nuint sectionIndex);

		[Export ("collapseSectionAtIndex:")]
		void CollapseSectionAtIndex (nuint sectionIndex);

		[Export ("expandSectionAtIndex:")]
		void ExpandSectionAtIndex (nuint sectionIndex);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSCollectionViewLayout))]
	interface NSCollectionViewGridLayout {
		[Export ("margins", ArgumentSemantic.Assign)]
		NSEdgeInsets Margins { get; set; }

		[Export ("minimumInteritemSpacing", ArgumentSemantic.Assign)]
		nfloat MinimumInteritemSpacing { get; set; }

		[Export ("minimumLineSpacing", ArgumentSemantic.Assign)]
		nfloat MinimumLineSpacing { get; set; }

		[Export ("maximumNumberOfRows", ArgumentSemantic.Assign)]
		nuint MaximumNumberOfRows { get; set; }

		[Export ("maximumNumberOfColumns", ArgumentSemantic.Assign)]
		nuint MaximumNumberOfColumns { get; set; }

		[Export ("minimumItemSize", ArgumentSemantic.Assign)]
		CGSize MinimumItemSize { get; set; }

		[Export ("maximumItemSize", ArgumentSemantic.Assign)]
		CGSize MaximumItemSize { get; set; }

		[Export ("backgroundColors", ArgumentSemantic.Copy)]
		NSColor [] BackgroundColors { get; set; }
	}

	[NoMacCatalyst]
	[DisableDefaultCtor]
	[BaseType (typeof (NSCollectionViewLayout))]
	interface NSCollectionViewTransitionLayout {
#if !NET
		[Obsolete ("Use the constructor that allows you to set currentLayout and newLayout.")]
		[Export ("init")]
		NativeHandle Constructor ();
#endif

		[Export ("transitionProgress", ArgumentSemantic.Assign)]
		nfloat TransitionProgress { get; set; }

		[Export ("currentLayout")]
		NSCollectionViewLayout CurrentLayout { get; }

		[Export ("nextLayout")]
		NSCollectionViewLayout NextLayout { get; }

		[Export ("initWithCurrentLayout:nextLayout:")]
		NativeHandle Constructor (NSCollectionViewLayout currentLayout, NSCollectionViewLayout newLayout);

		[Export ("updateValue:forAnimatedKey:")]
		void UpdateValue (nfloat value, string key);

		[Export ("valueForAnimatedKey:")]
		nfloat GetValue (string key);
	}

	[NoMacCatalyst]
	[ThreadSafe]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // -colorSpaceName not valid for the NSColor <NSColor: 0x1b94780>; need to first convert colorspace.
	public partial class NSColor : NSObject, NSCopying, NSPasteboardReading, NSPasteboardWriting, NSAccessibilityColor
	{

		public NSColor(IntPtr handle) : base(handle);
		
		[Static]
		[Export ("colorWithCalibratedWhite:alpha:")]
		public static NSColor FromCalibratedWhite (nfloat white, nfloat alpha);

		[Static]
		[Export ("colorWithCalibratedHue:saturation:brightness:alpha:")]
		public static NSColor FromCalibratedHsba (nfloat hue, nfloat saturation, nfloat brightness, nfloat alpha);

		[Static]
		[Export ("colorWithCalibratedRed:green:blue:alpha:")]
		public static NSColor FromCalibratedRgba (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Static]
		[Export ("colorWithDeviceWhite:alpha:")]
		public static NSColor FromDeviceWhite (nfloat white, nfloat alpha);

		[Static]
		[Export ("colorWithDeviceHue:saturation:brightness:alpha:")]
		public static NSColor FromDeviceHsba (nfloat hue, nfloat saturation, nfloat brightness, nfloat alpha);

		[Static]
		[Export ("colorWithDeviceRed:green:blue:alpha:")]
		public static NSColor FromDeviceRgba (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Static]
		[Export ("colorWithDeviceCyan:magenta:yellow:black:alpha:")]
		public static NSColor FromDeviceCymka (nfloat cyan, nfloat magenta, nfloat yellow, nfloat black, nfloat alpha);

		[Static]
		[Export ("colorWithCatalogName:colorName:")]
		public static NSColor FromCatalogName (string listName, string colorName);

		[Static]
		[Export ("colorWithColorSpace:components:count:"), Internal]
		public static NSColor _FromColorSpace (NSColorSpace space, IntPtr components, nint numberOfComponents);

		[Static, Export ("colorWithWhite:alpha:")]
		public static NSColor FromWhite (nfloat white, nfloat alpha);

		[Static, Export ("colorWithRed:green:blue:alpha:")]
		public static NSColor FromRgba (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Static, Export ("colorWithHue:saturation:brightness:alpha:")]
		public static NSColor FromHsba (nfloat hue, nfloat saturation, nfloat brightness, nfloat alpha);

		[Static]
		[Export ("blackColor")]
		public static NSColor Black { get; }

		[Static]
		[Export ("darkGrayColor")]
		public static NSColor DarkGray { get; }

		[Static]
		[Export ("lightGrayColor")]
		public static NSColor LightGray { get; }

		[Static]
		[Export ("whiteColor")]
		public static NSColor White { get; }

		[Static]
		[Export ("grayColor")]
		public static NSColor Gray { get; }

		[Static]
		[Export ("redColor")]
		public static NSColor Red { get; }

		[Static]
		[Export ("greenColor")]
		public static NSColor Green { get; }

		[Static]
		[Export ("blueColor")]
		public static NSColor Blue { get; }

		[Static]
		[Export ("cyanColor")]
		public static NSColor Cyan { get; }

		[Static]
		[Export ("yellowColor")]
		public static NSColor Yellow { get; }

		[Static]
		[Export ("magentaColor")]
		public static NSColor Magenta { get; }

		[Static]
		[Export ("orangeColor")]
		public static NSColor Orange { get; }

		[Static]
		[Export ("purpleColor")]
		public static NSColor Purple { get; }

		[Static]
		[Export ("brownColor")]
		public static NSColor Brown { get; }

		[Static]
		[Export ("clearColor")]
		public static NSColor Clear { get; }

		[Static]
		[Export ("controlShadowColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use a context specific color such as 'SeparatorColor'.")]
		public static NSColor ControlShadow { get; }

		[Static]
		[Export ("controlDarkShadowColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use a context specific color such as 'SeparatorColor'.")]
		public static NSColor ControlDarkShadow { get; }

		[Static]
		[Export ("controlColor")]
		public static NSColor Control { get; }

		[Static]
		[Export ("controlHighlightColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use a context specific color such as 'SeparatorColor'.")]
		public static NSColor ControlHighlight { get; }

		[Static]
		[Export ("controlLightHighlightColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use a context specific color such as 'SeparatorColor'.")]
		public static NSColor ControlLightHighlight { get; }

		[Static]
		[Export ("controlTextColor")]
		public static NSColor ControlText { get; }

		[Static]
		[Export ("controlBackgroundColor")]
		public static NSColor ControlBackground { get; }

		[Static]
		[Export ("selectedControlColor")]
		public static NSColor SelectedControl { get; }

		[Static]
		[Deprecated (PlatformName.MacOSX, message: "Use 'SelectedContentBackgroundColor' instead.")]
		[Export ("secondarySelectedControlColor")]
		public static NSColor SecondarySelectedControl { get; }

		[Static]
		[Export ("selectedControlTextColor")]
		public static NSColor SelectedControlText { get; }

		[Static]
		[Export ("disabledControlTextColor")]
		public static NSColor DisabledControlText { get; }

		[Static]
		[Export ("textColor")]
		public static NSColor Text { get; }

		[Static]
		[Export ("textBackgroundColor")]
		public static NSColor TextBackground { get; }

		[Static]
		[Export ("selectedTextColor")]
		public static NSColor SelectedText { get; }

		[Static]
		[Export ("selectedTextBackgroundColor")]
		public static NSColor SelectedTextBackground { get; }

		[Static]
		[Export ("gridColor")]
		public static NSColor Grid { get; }

		[Static]
		[Export ("keyboardFocusIndicatorColor")]
		public static NSColor KeyboardFocusIndicator { get; }

		[Static]
		[Export ("windowBackgroundColor")]
		public static NSColor WindowBackground { get; }

		[Static]
		[Export ("scrollBarColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSScroller' instead.")]
		public static NSColor ScrollBar { get; }

		[Static]
		[Export ("knobColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSScroller' instead.")]
		public static NSColor Knob { get; }

		[Static]
		[Export ("selectedKnobColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSScroller' instead.")]
		public static NSColor SelectedKnob { get; }

		[Static]
		[Export ("windowFrameColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSVisualEffectMaterial.Title' instead.")]
		public static NSColor WindowFrame { get; }

		[Static]
		[Export ("windowFrameTextColor")]
		public static NSColor WindowFrameText { get; }

		[Static]
		[Export ("selectedMenuItemColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSVisualEffectMaterial.Title' instead.")]
		public static NSColor SelectedMenuItem { get; }

		[Static]
		[Export ("selectedMenuItemTextColor")]
		public static NSColor SelectedMenuItemText { get; }

		[Static]
		[Export ("highlightColor")]
		public static NSColor Highlight { get; }

		[Static]
		[Export ("shadowColor")]
		public static NSColor Shadow { get; }

		[Static]
		[Export ("headerColor")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSVisualEffectMaterial.Title' instead.")]
		public static NSColor Header { get; }

		[Static]
		[Export ("headerTextColor")]
		public static NSColor HeaderText { get; }

		[Static]
		[Deprecated (PlatformName.MacOSX, message: "Use 'SelectedContentBackgroundColor' instead.")]
		[Export ("alternateSelectedControlColor")]
		public static NSColor AlternateSelectedControl { get; }

		[Static]
		[Export ("alternateSelectedControlTextColor")]
		public static NSColor AlternateSelectedControlText { get; }

		[Static]
		[Advice ("Use 'AlternatingContentBackgroundColors' instead.")]
		[Export ("controlAlternatingRowBackgroundColors")]
		public static NSColor [] ControlAlternatingRowBackgroundColors ();

		[Export ("highlightWithLevel:")]
		public static NSColor HighlightWithLevel (nfloat highlightLevel);

		[Export ("shadowWithLevel:")]
		public static NSColor ShadowWithLevel (nfloat shadowLevel);

		[Static]
		[Export ("colorForControlTint:")]
		[Advice ("Use 'NSColor.ControlAccentColor' instead.")]
		public static NSColor FromControlTint (NSControlTint controlTint);

		[Static]
		[Export ("currentControlTint")]
		public static NSControlTint CurrentControlTint { get; }

		[Export ("set")]
		public void Set ();

		[Export ("setFill")]
		public void SetFill ();

		[Export ("setStroke")]
		public void SetStroke ();

		[Export ("colorSpaceName")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'Type' and 'NSColorType' instead.")]
		public string ColorSpaceName { get; }

		[Export ("colorUsingColorSpaceName:")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'GetColor' or 'UsingColorSpace' instead.")]
		public NSColor UsingColorSpace ([NullAllowed] string colorSpaceName);

		[Export ("colorUsingColorSpaceName:device:")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'GetColor' or 'UsingColorSpace' instead.")]
		public NSColor UsingColorSpace ([NullAllowed] string colorSpaceName, [NullAllowed] NSDictionary deviceDescription);

		[Export ("colorUsingColorSpace:")]
		public NSColor UsingColorSpace (NSColorSpace colorSpace);

		[Export ("blendedColorWithFraction:ofColor:")]
		public NSColor BlendedColor (nfloat fraction, NSColor color);

		[Export ("colorWithAlphaComponent:")]
		public NSColor ColorWithAlphaComponent (nfloat alpha);

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("catalogNameComponent")]
		public string CatalogNameComponent { get; }

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("colorNameComponent")]
		public string ColorNameComponent { get; }

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("localizedCatalogNameComponent")]
		public string LocalizedCatalogNameComponent { get; }

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("localizedColorNameComponent")]
		public string LocalizedColorNameComponent { get; }

		[Export ("redComponent")]
		public nfloat RedComponent { [MarshalNativeExceptions] get; }

		[Export ("greenComponent")]
		public nfloat GreenComponent { [MarshalNativeExceptions] get; }

		[Export ("blueComponent")]
		public nfloat BlueComponent { [MarshalNativeExceptions] get; }

		[Export ("getRed:green:blue:alpha:")]
		public void GetRgba (out nfloat red, out nfloat green, out nfloat blue, out nfloat alpha);

		[Export ("hueComponent")]
		public nfloat HueComponent { [MarshalNativeExceptions] get; }

		[Export ("saturationComponent")]
		public nfloat SaturationComponent { [MarshalNativeExceptions] get; }

		[Export ("brightnessComponent")]
		public nfloat BrightnessComponent { [MarshalNativeExceptions] get; }

		[Export ("getHue:saturation:brightness:alpha:")]
		public void GetHsba (out nfloat hue, out nfloat saturation, out nfloat brightness, out nfloat alpha);

		[Export ("whiteComponent")]
		public nfloat WhiteComponent { [MarshalNativeExceptions] get; }

		[Export ("getWhite:alpha:")]
		public void GetWhiteAlpha (out nfloat white, out nfloat alpha);

		[Export ("cyanComponent")]
		public nfloat CyanComponent { [MarshalNativeExceptions] get; }

		[Export ("magentaComponent")]
		public nfloat MagentaComponent { [MarshalNativeExceptions] get; }

		[Export ("yellowComponent")]
		public nfloat YellowComponent { [MarshalNativeExceptions] get; }

		[Export ("blackComponent")]
		public nfloat BlackComponent { [MarshalNativeExceptions] get; }

		[Export ("getCyan:magenta:yellow:black:alpha:")]
		public void GetCmyka (out nfloat cyan, out nfloat magenta, out nfloat yellow, out nfloat black, out nfloat alpha);

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("colorSpace")]
		public NSColorSpace ColorSpace { get; }

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("numberOfComponents")]
		public nint ComponentCount { get; }

		[Export ("getComponents:"), Internal]
		public void _GetComponents (IntPtr components);

		[Export ("alphaComponent")]
		public nfloat AlphaComponent { [MarshalNativeExceptions] get; }

		[Static]
		[Export ("colorFromPasteboard:")]
		public NSColor FromPasteboard (NSPasteboard pasteBoard);

		[Export ("writeToPasteboard:")]
		public void WriteToPasteboard (NSPasteboard pasteBoard);

		[Static]
		[Export ("colorWithPatternImage:")]
		public NSColor FromPatternImage (NSImage image);

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("patternImage")]
		public NSImage PatternImage { get; }

		[Export ("CGColor")]
		public CGColor CGColor { get; }

		[Export ("drawSwatchInRect:")]
		public void DrawSwatchInRect (CGRect rect);

		[Static]
		[Export ("ignoresAlpha")]
		public bool IgnoresAlpha { get; set; }

		[Static]
		[Export ("colorWithCIColor:")]
		public NSColor FromCIColor (CIColor color);

#if !NET
		[Obsolete ("Use 'Label' instead.")]
		[Static, Export ("labelColor")]
		public static NSColor LabelColor { get; }
#endif

		[Static, Export ("labelColor")]
		public static  NSColor Label { get; }

#if !NET
		[Obsolete ("Use 'SecondaryLabel' instead.")]
		[Static, Export ("secondaryLabelColor")]
		public static  NSColor SecondaryLabelColor { get; }
#endif

		[Static, Export ("secondaryLabelColor")]
		public static NSColor SecondaryLabel { get; }

#if !NET
		[Obsolete ("Use 'TertiaryLabel' instead.")]
		[Static, Export ("tertiaryLabelColor")]
		public static NSColor TertiaryLabelColor { get; }
#endif

		[Static, Export ("tertiaryLabelColor")]
		public static NSColor TertiaryLabel { get; }

#if !NET
		[Obsolete ("Use 'QuaternaryLabel' instead.")]
		[Static, Export ("quaternaryLabelColor")]
		public static NSColor QuaternaryLabelColor { get; }
#endif

		[Static, Export ("quaternaryLabelColor")]
		public static NSColor QuaternaryLabel { get; }

#if !NET
		[Obsolete ("Use 'Link' instead.")]
		[Static, Export ("linkColor", ArgumentSemantic.Strong)]
		public static NSColor LinkColor { get; }
#endif

		[Static, Export ("linkColor", ArgumentSemantic.Strong)]
		public static NSColor Link { get; }

		[Static]
		[Export ("colorWithDisplayP3Red:green:blue:alpha:")]
		public static NSColor FromDisplayP3 (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Static]
		[Export ("colorWithColorSpace:hue:saturation:brightness:alpha:")]
		public static NSColor FromColor (NSColorSpace space, nfloat hue, nfloat saturation, nfloat brightness, nfloat alpha);

#if !NET
		[Obsolete ("Use 'ScrubberTexturedBackground' instead.")]
		[Static]
		[Export ("scrubberTexturedBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor ScrubberTexturedBackgroundColor { get; }
#endif

		[Static]
		[Export ("scrubberTexturedBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor ScrubberTexturedBackground { get; }

		[Static]
		[Export ("colorNamed:bundle:")]
		[return: NullAllowed]
		public static NSColor FromName (string name, [NullAllowed] NSBundle bundle);

		[Static]
		[Export ("colorNamed:")]
		[return: NullAllowed]
		public static NSColor FromName (string name);

		[Export ("type")]
		public NSColorType Type { get; }

		[Export ("colorUsingType:")]
		[return: NullAllowed]
		public NSColor GetColor (NSColorType type);

#if !NET
		[Obsolete ("Use 'SystemRed' instead.")]
		[Static]
		[Export ("systemRedColor", ArgumentSemantic.Strong)]
		public static NSColor SystemRedColor { get; }
#endif

		[Static]
		[Export ("systemRedColor", ArgumentSemantic.Strong)]
		public static NSColor SystemRed { get; }

#if !NET
		[Obsolete ("Use 'SystemGreen' instead.")]
		[Static]
		[Export ("systemGreenColor", ArgumentSemantic.Strong)]
		public static NSColor SystemGreenColor { get; }
#endif

		[Static]
		[Export ("systemGreenColor", ArgumentSemantic.Strong)]
		public static NSColor SystemGreen { get; }

#if !NET
		[Obsolete ("Use 'SystemBlue' instead.")]
		[Static]
		[Export ("systemBlueColor", ArgumentSemantic.Strong)]
		public static NSColor SystemBlueColor { get; }
#endif

		[Static]
		[Export ("systemBlueColor", ArgumentSemantic.Strong)]
		public static NSColor SystemBlue { get; }

#if !NET
		[Obsolete ("Use 'SystemOrange' instead.")]
		[Static]
		[Export ("systemOrangeColor", ArgumentSemantic.Strong)]
		public static NSColor SystemOrangeColor { get; }
#endif

		[Static]
		[Export ("systemOrangeColor", ArgumentSemantic.Strong)]
		public static NSColor SystemOrange { get; }

#if !NET
		[Obsolete ("Use 'SystemYellow' instead.")]
		[Static]
		[Export ("systemYellowColor", ArgumentSemantic.Strong)]
		public static NSColor SystemYellowColor { get; }
#endif

		[Static]
		[Export ("systemYellowColor", ArgumentSemantic.Strong)]
		public static NSColor SystemYellow { get; }

#if !NET
		[Obsolete ("Use 'SystemBrown' instead.")]
		[Static]
		[Export ("systemBrownColor", ArgumentSemantic.Strong)]
		public static NSColor SystemBrownColor { get; }
#endif

		[Static]
		[Export ("systemBrownColor", ArgumentSemantic.Strong)]
		public static NSColor SystemBrown { get; }

#if !NET
		[Obsolete ("Use 'SystemPink' instead.")]
		[Static]
		[Export ("systemPinkColor", ArgumentSemantic.Strong)]
		public static NSColor SystemPinkColor { get; }
#endif

		[Static]
		[Export ("systemPinkColor", ArgumentSemantic.Strong)]
		public static NSColor SystemPink { get; }

#if !NET
		[Obsolete ("Use 'SystemPurple' instead.")]
		[Static]
		[Export ("systemPurpleColor", ArgumentSemantic.Strong)]
		public static NSColor SystemPurpleColor { get; }
#endif

		[Static]
		[Export ("systemPurpleColor", ArgumentSemantic.Strong)]
		public static NSColor SystemPurple { get; }

#if !NET
		[Obsolete ("Use 'SystemGray' instead.")]
		[Static]
		[Export ("systemGrayColor", ArgumentSemantic.Strong)]
		public static NSColor SystemGrayColor { get; }
#endif

		[Static]
		[Export ("systemGrayColor", ArgumentSemantic.Strong)]
		public static NSColor SystemGray { get; }

#if !NET
		[Obsolete ("Use 'SystemIndigo' instead.")]
		[Static]
		[Export ("systemIndigoColor", ArgumentSemantic.Strong)]
		public static NSColor SystemIndigoColor { get; }
#endif

		[Static]
		[Export ("systemIndigoColor", ArgumentSemantic.Strong)]
		public static NSColor SystemIndigo { get; }

#if !NET
		[Obsolete ("Use 'SystemMint' instead.")]
		[Static]
		[Export ("systemMintColor", ArgumentSemantic.Strong)]
		public static NSColor SystemMintColor { get; }
#endif

		[Static]
		[Export ("systemMintColor", ArgumentSemantic.Strong)]
		public static NSColor SystemMint { get; }

#if !NET
		[Obsolete ("Use 'SystemCyan' instead.")]
		[Static]
		[Export ("systemCyanColor", ArgumentSemantic.Strong)]
		public static NSColor SystemCyanColor { get; }
#endif

		[Static]
		[Export ("systemCyanColor", ArgumentSemantic.Strong)]
		public static NSColor SystemCyan { get; }

#if !NET
		[Obsolete ("Use 'SystemTeal' instead.")]
		[Static]
		[Export ("systemTealColor", ArgumentSemantic.Strong)]
		public static NSColor SystemTealColor { get; }
#endif

		[Static]
		[Export ("systemTealColor", ArgumentSemantic.Strong)]
		public static NSColor SystemTeal { get; }

#if !NET
		[Obsolete ("Use 'Separator' instead.")]
		[Static]
		[Export ("separatorColor", ArgumentSemantic.Strong)]
		public static NSColor SeparatorColor { get; }
#endif

		[Static]
		[Export ("separatorColor", ArgumentSemantic.Strong)]
		public static NSColor Separator { get; }

#if !NET
		[Obsolete ("Use 'SelectedContentBackground' instead.")]
		[Static]
		[Export ("selectedContentBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor SelectedContentBackgroundColor { get; }
#endif

		[Static]
		[Export ("selectedContentBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor SelectedContentBackground { get; }

#if !NET
		[Obsolete ("Use 'UnemphasizedSelectedContentBackground' instead.")]
		[Static]
		[Export ("unemphasizedSelectedContentBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor UnemphasizedSelectedContentBackgroundColor { get; }
#endif

		[Static]
		[Export ("unemphasizedSelectedContentBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor UnemphasizedSelectedContentBackground { get; }

		[Static]
		[Export ("alternatingContentBackgroundColors", ArgumentSemantic.Strong)]
		public static NSColor [] AlternatingContentBackgroundColors { get; }

#if !NET
		[Obsolete ("Use 'UnemphasizedSelectedTextBackground' instead.")]
		[Static]
		[Export ("unemphasizedSelectedTextBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor UnemphasizedSelectedTextBackgroundColor { get; }
#endif

		[Static]
		[Export ("unemphasizedSelectedTextBackgroundColor", ArgumentSemantic.Strong)]
		public static NSColor UnemphasizedSelectedTextBackground { get; }

#if !NET
		[Obsolete ("Use 'UnemphasizedSelectedText' instead.")]
		[Static]
		[Export ("unemphasizedSelectedTextColor", ArgumentSemantic.Strong)]
		public static NSColor UnemphasizedSelectedTextColor { get; }
#endif

		[Static]
		[Export ("unemphasizedSelectedTextColor", ArgumentSemantic.Strong)]
		public static NSColor UnemphasizedSelectedText { get; }

#if !NET
		[Obsolete ("Use 'ControlAccent' instead.")]
		[Static]
		[Export ("controlAccentColor", ArgumentSemantic.Strong)]
		public static NSColor ControlAccentColor { get; }
#endif

		[Static]
		[Export ("controlAccentColor", ArgumentSemantic.Strong)]
		public static NSColor ControlAccent { get; }

		[Export ("colorWithSystemEffect:")]
		public NSColor FromSystemEffect (NSColorSystemEffect systemEffect);

#if !NET
		[Obsolete ("Use 'FindHighlight' instead.")]
		[Static]
		[Export ("findHighlightColor", ArgumentSemantic.Strong)]
		public static NSColor FindHighlightColor { get; }
#endif

		[Static]
		[Export ("findHighlightColor", ArgumentSemantic.Strong)]
		public static NSColor FindHighlight { get; }

#if !NET
		[Obsolete ("Use 'PlaceholderText' instead.")]
		[Static]
		[Export ("placeholderTextColor", ArgumentSemantic.Strong)]
		public static NSColor PlaceholderTextColor { get; }
#endif

		[Static]
		[Export ("placeholderTextColor", ArgumentSemantic.Strong)]
		public static NSColor PlaceholderText { get; }

		[Static]
		[Export ("colorWithName:dynamicProvider:")]
		public static NSColor GetColor ([NullAllowed] string colorName, Func<NSAppearance, NSColor> dynamicProvider);

		[Mac (14, 0)]
		[Static]
		[Export ("systemFillColor", ArgumentSemantic.Strong)]
		public static NSColor SystemFill { get; }

		[Mac (14, 0)]
		[Static]
		[Export ("secondarySystemFillColor", ArgumentSemantic.Strong)]
		public static NSColor SecondarySystemFill { get; }

		[Mac (14, 0)]
		[Static]
		[Export ("tertiarySystemFillColor", ArgumentSemantic.Strong)]
		public static NSColor TertiarySystemFill { get; }

		[Mac (14, 0)]
		[Static]
		[Export ("quaternarySystemFillColor", ArgumentSemantic.Strong)]
		public static NSColor QuaternarySystemFill { get; }

		[Mac (14, 0)]
		[Static]
		[Export ("quinarySystemFillColor", ArgumentSemantic.Strong)]
		public static NSColor QuinarySystemFill { get; }

		[Mac (14, 0)]
		[Static]
		[Export ("quinaryLabelColor", ArgumentSemantic.Strong)]
		public static NSColor QuinaryLabel { get; }

		[Mac (14, 0)]
		[Static]
		[Export ("textInsertionPointColor", ArgumentSemantic.Strong)]
		public static NSColor TextInsertionPoint { get; }
	}

	

	[NoMacCatalyst]
	[Protocol]
	interface NSColorChanging {
		[Abstract]
		[Export ("changeColor:")]
		void ChangeColor ([NullAllowed] NSColorPanel sender);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSPanel))]
	partial interface NSColorPanel {
		[Static, Export ("sharedColorPanel")]
		NSColorPanel SharedColorPanel { get; }

		[Static]
		[Export ("sharedColorPanelExists")]
		bool SharedColorPanelExists { get; }

		[Static]
		[Export ("dragColor:withEvent:fromView:")]
		bool DragColor (NSColor color, NSEvent theEvent, NSView sourceView);

		[Static]
		[Export ("setPickerMask:")]
		void SetPickerStyle (NSColorPanelFlags mask);

		[Static]
		[Export ("setPickerMode:")]
		void SetPickerMode (NSColorPanelMode mode);

		[Export ("alpha")]
		nfloat Alpha { get; }

		[Export ("setAction:")]
		void SetAction ([NullAllowed] Selector aSelector);

		[Export ("setTarget:")]
		void SetTarget ([NullAllowed] NSObject anObject);

		[Export ("attachColorList:")]
		void AttachColorList (NSColorList colorList);

		[Export ("detachColorList:")]
		void DetachColorList (NSColorList colorList);

		//Detected properties
		[Export ("accessoryView", ArgumentSemantic.Retain), NullAllowed]
		NSView AccessoryView { get; set; }

		[Export ("continuous")]
		bool Continuous { [Bind ("isContinuous")] get; set; }

		[Export ("showsAlpha")]
		bool ShowsAlpha { get; set; }

		[Export ("mode")]
		NSColorPanelMode Mode { get; set; }

		[Export ("color", ArgumentSemantic.Copy)]
		NSColor Color { get; set; }

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSColorPicker {
		[Export ("initWithPickerMask:colorPanel:")]
		NativeHandle Constructor (NSColorPanelFlags mask, NSColorPanel owningColorPanel);

		[Export ("colorPanel")]
		NSColorPanel ColorPanel { get; }

		[Export ("provideNewButtonImage")]
		NSImage ProvideNewButtonImage ();

		[Export ("insertNewButtonImage:in:")]
		void InsertNewButtonImage (NSImage newButtonImage, NSButtonCell buttonCell);

		[Export ("viewSizeChanged:")]
		void ViewSizeChanged (NSObject sender);

		[Export ("attachColorList:")]
		void AttachColorList (NSColorList colorList);

		[Export ("detachColorList:")]
		void DetachColorList (NSColorList colorList);

		[Export ("setMode:")]
		void SetMode (NSColorPanelMode mode);

		[Export ("buttonToolTip")]
		string ButtonToolTip { get; }

		[Export ("minContentSize")]
		CGSize MinContentSize { get; }
	}

	

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSColorWell {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("deactivate")]
		void Deactivate ();

		[Export ("activate:")]
		void Activate (bool exclusive);

		[Export ("isActive")]
		bool IsActive { get; }

		[Export ("drawWellInside:")]
		void DrawWellInside (CGRect insideRect);

		[Export ("takeColorFrom:")]
		void TakeColorFrom (NSObject sender);

		//Detected properties
		[Deprecated (PlatformName.MacOSX, 14, 0)]
		[Export ("bordered")]
		bool Bordered { [Bind ("isBordered")] get; set; }

		[Export ("color", ArgumentSemantic.Copy)]
		NSColor Color { get; set; }

		[Mac (13, 0)]
		[Export ("colorWellStyle", ArgumentSemantic.Assign)]
		NSColorWellStyle ColorWellStyle { get; set; }

		[Mac (13, 0)]
		[Export ("image", ArgumentSemantic.Strong)]
		[NullAllowed]
		NSImage Image { get; set; }

		[Mac (13, 0)]
		[Export ("pulldownTarget", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject PulldownTarget { get; set; }

		[Mac (13, 0)]
		[Export ("pulldownAction", ArgumentSemantic.Assign)]
		[NullAllowed]
		Selector PulldownAction { get; set; }

		[Mac (14, 0)]
		[Export ("supportsAlpha")]
		bool SupportsAlpha { get; set; }

		[Mac (14, 0)]
		[Static]
		[Export ("colorWellWithStyle:")]
		NSColorWell Create (NSColorWellStyle style);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextField),
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (NSComboBoxDelegate) }
	)]
	partial interface NSComboBox {

		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Wrap ("WeakDelegate")]
		INSComboBoxDelegate Delegate { get; set; }

		[Export ("hasVerticalScroller")]
		bool HasVerticalScroller { get; set; }

		[Export ("intercellSpacing")]
		CGSize IntercellSpacing { get; set; }

		[Export ("itemHeight")]
		nfloat ItemHeight { get; set; }

		[Export ("numberOfVisibleItems")]
		nint VisibleItems { get; set; }

		[Export ("buttonBordered")]
		bool ButtonBordered { [Bind ("isButtonBordered")] get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("noteNumberOfItemsChanged")]
		void NoteNumberOfItemsChanged ();

		[Export ("usesDataSource")]
		bool UsesDataSource { get; set; }

		[Export ("scrollItemAtIndexToTop:")]
		void ScrollItemAtIndexToTop (nint scrollItemIndex);

		[Export ("scrollItemAtIndexToVisible:")]
		void ScrollItemAtIndexToVisible (nint scrollItemIndex);

		[Export ("selectItemAtIndex:")]
		void SelectItem (nint itemIndex);

		[Export ("deselectItemAtIndex:")]
		void DeselectItem (nint itemIndex);

		[Export ("indexOfSelectedItem")]
		nint SelectedIndex { get; }

		[Export ("numberOfItems")]
		nint Count { get; }

		[Export ("completes")]
		bool Completes { get; set; }

		[Export ("dataSource", ArgumentSemantic.Assign)]
		[NullAllowed]
		INSComboBoxDataSource DataSource { get; set; }

		[Export ("addItemWithObjectValue:")]
		void Add (NSObject object1);

		[Export ("addItemsWithObjectValues:")]
		void Add (NSObject [] items);

		[Export ("insertItemWithObjectValue:atIndex:")]
		void Insert (NSObject object1, nint index);

		[Export ("removeItemWithObjectValue:")]
		void Remove (NSObject object1);

		[Export ("removeItemAtIndex:")]
		void RemoveAt (nint index);

		[Export ("removeAllItems")]
		void RemoveAll ();

		[Export ("selectItemWithObjectValue:")]
		void Select (NSObject object1);

		[Export ("itemObjectValueAtIndex:")]
		NSObject GetItemObject (nint index);

		[Export ("objectValueOfSelectedItem")]
		NSObject SelectedValue { get; }

		[Export ("indexOfItemWithObjectValue:")]
		nint IndexOf (NSObject object1);

		[Export ("objectValues")]
		NSObject [] Values { get; }

		[Notification, Field ("NSComboBoxSelectionDidChangeNotification")]
		NSString SelectionDidChangeNotification { get; }

		[Notification, Field ("NSComboBoxSelectionIsChangingNotification")]
		NSString SelectionIsChangingNotification { get; }

		[Notification, Field ("NSComboBoxWillDismissNotification")]
		NSString WillDismissNotification { get; }

		[Notification, Field ("NSComboBoxWillPopUpNotification")]
		NSString WillPopUpNotification { get; }
	}

	interface INSComboBoxDataSource { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSComboBoxDataSource {
		[Export ("comboBox:objectValueForItemAtIndex:")]
		NSObject ObjectValueForItem (NSComboBox comboBox, nint index);

		[Export ("numberOfItemsInComboBox:")]
		nint ItemCount (NSComboBox comboBox);

		[Export ("comboBox:completedString:")]
		string CompletedString (NSComboBox comboBox, string uncompletedString);

		[Export ("comboBox:indexOfItemWithStringValue:")]
		nint IndexOfItem (NSComboBox comboBox, string value);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextFieldCell))]
	partial interface NSComboBoxCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("hasVerticalScroller")]
		bool HasVerticalScroller { get; set; }

		[Export ("intercellSpacing")]
		CGSize IntercellSpacing { get; set; }

		[Export ("itemHeight")]
		nfloat ItemHeight { get; set; }

		[Export ("numberOfVisibleItems")]
		nint VisibleItems { get; set; }

		[Export ("buttonBordered")]
		bool ButtonBordered { [Bind ("isButtonBordered")] get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("noteNumberOfItemsChanged")]
		void NoteNumberOfItemsChanged ();

		[Export ("usesDataSource")]
		bool UsesDataSource { get; set; }

		[Export ("scrollItemAtIndexToTop:")]
		void ScrollItemAtIndexToTop (nint scrollItemIndex);

		[Export ("scrollItemAtIndexToVisible:")]
		void ScrollItemAtIndexToVisible (nint scrollItemIndex);

		[Export ("selectItemAtIndex:")]
		void SelectItem (nint itemIndex);

		[Export ("deselectItemAtIndex:")]
		void DeselectItem (nint itemIndex);

		[Export ("indexOfSelectedItem")]
		nint SelectedIndex { get; }

		[Export ("numberOfItems")]
		nint Count { get; }

		[Export ("completes")]
		bool Completes { get; set; }

		[Export ("dataSource", ArgumentSemantic.Assign)]
		[NullAllowed]
		INSComboBoxCellDataSource DataSource { get; set; }

		[Export ("addItemWithObjectValue:")]
		void Add (NSObject object1);

		[Export ("addItemsWithObjectValues:")]
		void Add (NSObject [] items);

		[Export ("insertItemWithObjectValue:atIndex:")]
		void Insert (NSObject object1, nint index);

		[Export ("removeItemWithObjectValue:")]
		void Remove (NSObject object1);

		[Export ("removeItemAtIndex:")]
		void RemoveAt (nint index);

		[Export ("removeAllItems")]
		void RemoveAll ();

		[Export ("selectItemWithObjectValue:")]
		void Select (NSObject object1);

		[Export ("itemObjectValueAtIndex:")]
		NSComboBox GetItem (nint index);

		[Export ("objectValueOfSelectedItem")]
		NSObject SelectedValue { get; }

		[Export ("indexOfItemWithObjectValue:")]
		nint IndexOf (NSObject object1);

		[Export ("objectValues")]
		NSObject [] Values { get; }

		[Export ("completedString:")]
		string CompletedString (string substring);

	}

	interface INSComboBoxCellDataSource { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface NSComboBoxCellDataSource {
		[Export ("comboBoxCell:objectValueForItemAtIndex:")]
		NSObject ObjectValueForItem (NSComboBoxCell comboBox, nint index);

		[Export ("numberOfItemsInComboBoxCell:")]
		nint ItemCount (NSComboBoxCell comboBox);

		[Export ("comboBoxCell:completedString:")]
		string CompletedString (NSComboBoxCell comboBox, string uncompletedString);

		[Export ("comboBoxCell:indexOfItemWithStringValue:")]
		nuint IndexOfItem (NSComboBoxCell comboBox, string value);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	partial interface NSControl {
		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("sizeToFit")]
		void SizeToFit ();

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Override 'Layout' instead.")]
		[Export ("calcSize")]
		void CalcSize ();

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("selectedCell")]
		NSCell SelectedCell { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("selectedTag")]
		nint SelectedTag { get; }

		[Export ("sendActionOn:")]
		nint SendActionOn (NSEventType mask);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("setNeedsDisplay")]
		void SetNeedsDisplay ();

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("updateCell:")]
		void UpdateCell (NSCell aCell);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("updateCellInside:")]
		void UpdateCellInside (NSCell aCell);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("drawCellInside:")]
		void DrawCellInside (NSCell aCell);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("drawCell:")]
		void DrawCell (NSCell aCell);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("selectCell:")]
		void SelectCell (NSCell aCell);

		[Export ("sendAction:to:")]
		bool SendAction (Selector theAction, NSObject theTarget);

		[Export ("takeIntValueFrom:")]
		void TakeIntValueFrom (NSObject sender);

		[Export ("takeFloatValueFrom:")]
		void TakeFloatValueFrom (NSObject sender);

		[Export ("takeDoubleValueFrom:")]
		void TakeDoubleValueFrom (NSObject sender);

		[Export ("takeStringValueFrom:")]
		void TakeStringValueFrom (NSObject sender);

		[Export ("takeObjectValueFrom:")]
		void TakeObjectValueFrom (NSObject sender);

		[Export ("currentEditor")]
		NSText CurrentEditor { get; }

		[Export ("abortEditing")]
		bool AbortEditing ();

		[Export ("validateEditing")]
		void ValidateEditing ();

		[Export ("mouseDown:")]
		void MouseDown (NSEvent theEvent);

		[Export ("takeIntegerValueFrom:")]
		void TakeIntegerValueFrom (NSObject sender);

		[Export ("invalidateIntrinsicContentSizeForCell:")]
		void InvalidateIntrinsicContentSizeForCell (NSCell cell);

		//Detected properties
		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("cellClass")]
		Class CellClass { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("cell")]
		NSCell Cell { get; set; }

		[Export ("target", ArgumentSemantic.Weak), NullAllowed]
		NSObject Target { get; set; }

		[Export ("action"), NullAllowed]
		Selector Action { get; set; }

		[Export ("tag")]
		nint Tag { get; set; }

		[Export ("ignoresMultiClick")]
		bool IgnoresMultiClick { get; set; }

		[Export ("continuous")]
		bool Continuous { [Bind ("isContinuous")] get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("alignment")]
		NSTextAlignment Alignment { get; set; }

		[Export ("font")]
		NSFont Font { get; set; }

		[Export ("formatter", ArgumentSemantic.Retain), NullAllowed]
#if NET
		NSFormatter Formatter { get; set; }
#else
		NSObject Formatter { get; set; }
#endif

		[Export ("objectValue", ArgumentSemantic.Copy)]
		NSObject ObjectValue { get; set; }

		[Export ("stringValue")]
		string StringValue { get; set; }

		[Export ("attributedStringValue", ArgumentSemantic.Copy)]
		NSAttributedString AttributedStringValue { get; set; }

		[Export ("intValue")]
		int IntValue { get; set; } /* int, not NSInteger */

		[Export ("floatValue")]
		float FloatValue { get; set; } /* float, not CGFloat */

		[Export ("doubleValue")]
		double DoubleValue { get; set; }

		[Export ("baseWritingDirection")]
		NSWritingDirection BaseWritingDirection { get; set; }

		[Export ("integerValue")]
		nint NIntValue { get; set; }

		[Export ("performClick:")]
		void PerformClick (NSObject sender);

		[Export ("refusesFirstResponder")]
		bool RefusesFirstResponder { get; set; }

		[Export ("highlighted")]
		bool Highlighted { [Bind ("isHighlighted")] get; [Bind ("setHighlighted:")] set; }

		[Export ("controlSize")]
		NSControlSize ControlSize { get; set; }

		[Export ("sizeThatFits:")]
		CGSize SizeThatFits (CGSize size);

		[Export ("lineBreakMode")]
		NSLineBreakMode LineBreakMode { get; set; }

		[Export ("usesSingleLineMode")]
		bool UsesSingleLineMode { get; set; }

		[Export ("drawWithExpansionFrame:inView:")]
		void DrawWithExpansionFrame (CGRect cellFrame, NSView view);

		[Export ("editWithFrame:editor:delegate:event:")]
		void EditWithFrame (CGRect aRect, [NullAllowed] NSText textObj, [NullAllowed] NSObject anObject, NSEvent theEvent);

		[Export ("selectWithFrame:editor:delegate:start:length:")]
		void SelectWithFrame (CGRect aRect, [NullAllowed] NSText textObj, [NullAllowed] NSObject anObject, nint selStart, nint selLength);

		[Export ("endEditing:")]
		void EndEditing ([NullAllowed] NSText textObj);
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSEditorRegistration {
		[Export ("objectDidBeginEditing:")]
		void ObjectDidBeginEditing (INSEditor editor);

		[Export ("objectDidEndEditing:")]
		void ObjectDidEndEditing (INSEditor editor);
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSObject))]
	interface NSObject_NSEditorRegistration {
		[Export ("objectDidBeginEditing:")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSEditorRegistration' instead.")]
		void ObjectDidBeginEditing (INSEditor editor);

		[Export ("objectDidEndEditing:")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSEditorRegistration' instead.")]
		void ObjectDidEndEditing (INSEditor editor);
	}

	interface INSEditor { }

	[NoMacCatalyst]
	[Protocol]
	interface NSEditor {
		[Abstract]
		[Export ("discardEditing")]
		void DiscardEditing ();

		[Abstract]
		[Export ("commitEditing")]
		bool CommitEditing ();

		[Abstract]
		[Export ("commitEditingWithDelegate:didCommitSelector:contextInfo:")]
		void CommitEditing ([NullAllowed] NSObject delegateObject, [NullAllowed] Selector didCommitSelector, IntPtr contextInfo);

		[Abstract]
		[Export ("commitEditingAndReturnError:")]
		bool CommitEditing ([NullAllowed] out NSError error);
	}

	[NoMacCatalyst]
	[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	interface NSController : NSCoding, NSEditorRegistration
#if NET
	, NSEditor // Conflict over if CommitEditing is a property or a method. NSViewController has it right so can't "fix" NSEditor to match existing API
#endif
	{
#pragma warning disable 0108 // warning CS0108: 'NSController.DiscardEditing()' hides inherited member 'NSEditor.DiscardEditing()'. Use the new keyword if hiding was intended.
		[Export ("discardEditing")]
		void DiscardEditing ();
#pragma warning restore

		[Export ("commitEditingWithDelegate:didCommitSelector:contextInfo:")]
#if NET
#pragma warning disable 0108 // warning CS0108: 'NSController.CommitEditing(NSObject, Selector, nint)' hides inherited member 'NSEditor.CommitEditing(NSObject, Selector, nint)'. Use the new keyword if hiding was intended.
		void CommitEditing ([NullAllowed] NSObject delegate1, [NullAllowed] Selector didCommitSelector, IntPtr contextInfo);
#pragma warning restore
#else
		void CommitEditingWithDelegate ([NullAllowed] NSObject delegate1, [NullAllowed] Selector didCommitSelector, IntPtr contextInfo);
#endif

#if NET
#pragma warning disable 0108 // warning CS0108: 'NSController.ObjectDidBeginEditing(INSEditor)' hides inherited member 'NSEditorRegistration.ObjectDidBeginEditing(INSEditor)'. Use the new keyword if hiding was intended.
		[Export ("objectDidBeginEditing:")]
		void ObjectDidBeginEditing (INSEditor editor);
#pragma warning restore

#pragma warning disable 0108 // warning CS0108: 'NSController.ObjectDidEndEditing(INSEditor)' hides inherited member 'NSEditorRegistration.ObjectDidEndEditing(INSEditor)'. Use the new keyword if hiding was intended.
		[Export ("objectDidEndEditing:")]
		void ObjectDidEndEditing (INSEditor editor);
#pragma warning restore
#else
		[Export ("objectDidBeginEditing:")]
		void ObjectDidBeginEditing (NSObject editor);

		[Export ("objectDidEndEditing:")]
		void ObjectDidEndEditing (NSObject editor);
#endif

		[Export ("commitEditing")]
#if NET
#pragma warning disable 0108 // warning CS0108: 'NSController.CommitEditing()' hides inherited member 'NSEditor.CommitEditing()'. Use the new keyword if hiding was intended.
		bool CommitEditing ();
#pragma warning restore
#else
		bool CommitEditing { get; }
#endif

		[Export ("isEditing")]
		bool IsEditing { get; }
	}

	//[MacCatalyst (13, 1)]
	//[BaseType (typeof (NSObject))]
	public partial class NSCursor : NSCoding {
		
		public NSCursor(IntPtr handle): base(handle) {}
		
		[Static]
		[Export ("currentCursor")]
		public static NSCursor CurrentCursor { get; }

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "If using ScreenCaptureKit to capture the screen, use the 'SCStreamConfiguration.ShowsCursor' to control whether or not to include the cursor in the capture. Use 'NSCursor.CurrentCursor' to get the current cursor for this application.")]
		[Deprecated (PlatformName.MacCatalyst, 18, 0, message: "If using ScreenCaptureKit to capture the screen, use the 'SCStreamConfiguration.ShowsCursor' to control whether or not to include the cursor in the capture. Use 'NSCursor.CurrentCursor' to get the current cursor for this application.")]
		[Static]
		[Export ("currentSystemCursor")]
		[NullAllowed]
		public static NSCursor CurrentSystemCursor { get; }

		[Static]
		[Export ("arrowCursor")]
		public static NSCursor ArrowCursor { get; }

		[Static]
		[Export ("IBeamCursor")]
		public static NSCursor IBeamCursor { get; }

		[Static]
		[Export ("pointingHandCursor")]
		public static NSCursor PointingHandCursor { get; }

		[Static]
		[Export ("closedHandCursor")]
		public static NSCursor ClosedHandCursor { get; }

		[Static]
		[Export ("openHandCursor")]
		public static NSCursor OpenHandCursor { get; }

		[Static]
		[Export ("resizeLeftCursor")]
		public static NSCursor ResizeLeftCursor { get; }

		[Static]
		[Export ("resizeRightCursor")]
		public static NSCursor ResizeRightCursor { get; }

		[Static]
		[Export ("resizeLeftRightCursor")]
		public static NSCursor ResizeLeftRightCursor { get; }

		[Static]
		[Export ("resizeUpCursor")]
		public static NSCursor ResizeUpCursor { get; }

		[Static]
		[Export ("resizeDownCursor")]
		public static NSCursor ResizeDownCursor { get; }

		[Static]
		[Export ("resizeUpDownCursor")]
		public static NSCursor ResizeUpDownCursor { get; }

		[Static]
		[Export ("crosshairCursor")]
		public static NSCursor CrosshairCursor { get; }

		[Static]
		[Export ("disappearingItemCursor")]
		public static NSCursor DisappearingItemCursor { get; }

		[Static]
		[Export ("operationNotAllowedCursor")]
		public static NSCursor OperationNotAllowedCursor { get; }

		[Static]
		[Export ("dragLinkCursor")]
		public static NSCursor DragLinkCursor { get; }

		[Static]
		[Export ("dragCopyCursor")]
		public static NSCursor DragCopyCursor { get; }

		[Static]
		[Export ("contextualMenuCursor")]
		public static NSCursor ContextualMenuCursor { get; }

		[Static]
		[Export ("IBeamCursorForVerticalLayout")]
		public static NSCursor IBeamCursorForVerticalLayout { get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("zoomInCursor", ArgumentSemantic.Strong)]
		public static NSCursor ZoomInCursor { get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("zoomOutCursor", ArgumentSemantic.Strong)]
		public static NSCursor ZoomOutCursor { get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("columnResizeCursor", ArgumentSemantic.Strong)]
		public static NSCursor ColumnResizeCursor { get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("columnResizeCursorInDirections:")]
		public static NSCursor GetColumnResizeCursor (NSHorizontalDirections directions);

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("rowResizeCursor", ArgumentSemantic.Strong)]
		public static NSCursor RowResizeCursor { get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("rowResizeCursorInDirections:")]
		public static NSCursor GetRowResizeCursor (NSVerticalDirections directions);

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Static]
		[Export ("frameResizeCursorFromPosition:inDirections:")]
		public static NSCursor GetFrameResizeCursor (NSCursorFrameResizePosition position, NSCursorFrameResizeDirections directions);

		[DesignatedInitializer]
		[Export ("initWithImage:hotSpot:")]
		public static NativeHandle Constructor (NSImage newImage, CGPoint aPoint);

		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 12, message: "Color hints are ignored. Use NSCursor (NSImage newImage, CGPoint aPoint) instead.")]
		[Export ("initWithImage:foregroundColorHint:backgroundColorHint:hotSpot:")]
		public static NativeHandle Constructor (NSImage newImage, NSColor fg, NSColor bg, CGPoint hotSpot);

		[Static]
		[Export ("hide")]
		public static void Hide ();

		[Static]
		[Export ("unhide")]
		public static void Unhide ();

		[Static]
		[Export ("setHiddenUntilMouseMoves:")]
		public static void SetHiddenUntilMouseMoves (bool flag);

		//[Static]
		//[Export ("pop")]
		//void Pop ();

		[Export ("image")]
		public NSImage Image { get; }

		[Export ("hotSpot")]
		public CGPoint HotSpot { get; }

		[Export ("push")]
		public 	void Push ();

		[Export ("pop")]
		public void Pop ();

		[Export ("set")]
		public void Set ();

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[Export ("setOnMouseExited:")]
		public 	void SetOnMouseExited (bool flag);

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Export ("setOnMouseEntered:")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		public 	void SetOnMouseEntered (bool flag);

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Export ("isSetOnMouseExited")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		public 	bool IsSetOnMouseExited ();

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[Export ("isSetOnMouseEntered")]
		public 	bool IsSetOnMouseEntered ();

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Export ("mouseEntered:")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[NoMacCatalyst]
		public 	void MouseEntered (NSEvent theEvent);

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Export ("mouseExited:")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[NoMacCatalyst]
		public 	void MouseExited (NSEvent theEvent);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSImageRep))]
	[DisableDefaultCtor] // An uncaught exception was raised: -[NSCustomImageRep init]: unrecognized selector sent to instance 0x54a870
	partial interface NSCustomImageRep {
		[Export ("initWithDrawSelector:delegate:")]
		NativeHandle Constructor (Selector drawSelectorMethod, NSObject delegateObject);

		[NullAllowed]
		[Export ("drawSelector")]
		Selector DrawSelector { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Assign)]
		NSObject Delegate { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSDatePickerCellDelegate) })]
	interface NSDatePicker {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		//Detected properties
		[Export ("datePickerStyle")]
		NSDatePickerStyle DatePickerStyle { get; set; }

		[Export ("bezeled")]
		bool Bezeled { [Bind ("isBezeled")] get; set; }

		[Export ("bordered")]
		bool Bordered { [Bind ("isBordered")] get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("cell")]
		NSDatePickerCell Cell { get; set; }

		[Export ("textColor", ArgumentSemantic.Copy)]
		NSColor TextColor { get; set; }

		[Export ("datePickerMode")]
		NSDatePickerMode DatePickerMode { get; set; }

		[Export ("datePickerElements")]
		NSDatePickerElementFlags DatePickerElements { get; set; }

		[Export ("calendar", ArgumentSemantic.Copy)]
		NSCalendar Calendar { get; set; }

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[Export ("timeZone", ArgumentSemantic.Copy)]
		NSTimeZone TimeZone { get; set; }

		[Export ("dateValue", ArgumentSemantic.Copy)]
		NSDate DateValue { get; set; }

		[Export ("timeInterval")]
		double TimeInterval { get; set; }

		[Export ("minDate", ArgumentSemantic.Copy)]
		NSDate MinDate { get; set; }

		[Export ("maxDate", ArgumentSemantic.Copy)]
		NSDate MaxDate { get; set; }

		[Export ("presentsCalendarOverlay")]
		bool PresentsCalendarOverlay { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSDatePickerCellDelegate Delegate { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSDatePickerCellDelegate) })]
	interface NSDatePickerCell {
		[DesignatedInitializer]
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		//Detected properties
		[Export ("datePickerStyle")]
		NSDatePickerStyle DatePickerStyle { get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("textColor", ArgumentSemantic.Copy)]
		NSColor TextColor { get; set; }

		[Export ("datePickerMode")]
		NSDatePickerMode DatePickerMode { get; set; }

		[Export ("datePickerElements")]
		NSDatePickerElementFlags DatePickerElements { get; set; }

		[Export ("calendar", ArgumentSemantic.Copy)]
		NSCalendar Calendar { get; set; }

		[Export ("locale", ArgumentSemantic.Copy)]
		NSLocale Locale { get; set; }

		[Export ("timeZone", ArgumentSemantic.Copy)]
		NSTimeZone TimeZone { get; set; }

		[Export ("dateValue", ArgumentSemantic.Copy)]
		NSDate DateValue { get; set; }

		[Export ("timeInterval")]
		double TimeInterval { get; set; }

		[Export ("minDate", ArgumentSemantic.Copy)]
		NSDate MinDate { get; set; }

		[Export ("maxDate", ArgumentSemantic.Copy)]
		NSDate MaxDate { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSDatePickerCellDelegate Delegate { get; set; }

	}

	interface INSDatePickerCellDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSDatePickerCellDelegate {
		[Export ("datePickerCell:validateProposedDateValue:timeInterval:"), EventArgs ("NSDatePickerValidator")]
		void ValidateProposedDateValue (NSDatePickerCell aDatePickerCell, ref NSDate proposedDateValue, double proposedTimeInterval);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSDictionaryControllerKeyValuePair {
		[NullAllowed, Export ("key")]
		string Key { get; set; }

		[NullAllowed, Export ("value", ArgumentSemantic.Strong)]
		NSObject Value { get; set; }

		[NullAllowed, Export ("localizedKey")]
		string LocalizedKey { get; set; }

		[Export ("explicitlyIncluded")]
		bool ExplicitlyIncluded { [Bind ("isExplicitlyIncluded")] get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSArrayController))]
	interface NSDictionaryController {
		// -(NSDictionaryControllerKeyValuePair * __nonnull)newObject;
		[Export ("newObject")]
		// [Verify (MethodToProperty)]
		NSDictionaryControllerKeyValuePair NewObject { get; }

		[Export ("initialKey")]
		string InitialKey { get; set; }

		[Export ("initialValue", ArgumentSemantic.Strong)]
		NSObject InitialValue { get; set; }

		[Export ("includedKeys", ArgumentSemantic.Copy)]
		string [] IncludedKeys { get; set; }

		[Export ("excludedKeys", ArgumentSemantic.Copy)]
		string [] ExcludedKeys { get; set; }

		[Export ("localizedKeyDictionary", ArgumentSemantic.Copy)]
		NSDictionary LocalizedKeyDictionary { get; set; }

		[NullAllowed, Export ("localizedKeyTable")]
		string LocalizedKeyTable { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSDockTile {
		[Export ("size")]
		CGSize Size { get; }

		[Export ("display")]
		void Display ();

		[Export ("owner")]
		NSObject Owner { get; }

		//Detected properties
		[Export ("contentView", ArgumentSemantic.Retain)]
		NSView ContentView { get; set; }

		[Export ("showsApplicationBadge")]
		bool ShowsApplicationBadge { get; set; }

		[Export ("badgeLabel"), NullAllowed]
		string BadgeLabel { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSDockTilePlugIn {
		[Abstract]
		[Export ("setDockTile:")]
		void SetDockTile (NSDockTile dockTile);

#if !NET
		[Abstract]
#endif
		[Export ("dockMenu")]
		NSMenu DockMenu ();
	}

	delegate void NSDocumentCompletionHandler (IntPtr nsErrorPointerOrZero);

	[NoMacCatalyst]
	[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	partial interface NSDocument : NSUserActivityRestoring {
		[Export ("initWithType:error:")]
		NativeHandle Constructor (string typeName, [NullAllowed] out NSError outError);

		[Static]
		[Export ("canConcurrentlyReadDocumentsOfType:")]
		bool CanConcurrentlyReadDocumentsOfType (string typeName);

		[Export ("initWithContentsOfURL:ofType:error:")]
		NativeHandle Constructor (NSUrl url, string typeName, [NullAllowed] out NSError outError);

		[Export ("initForURL:withContentsOfURL:ofType:error:")]
		NativeHandle Constructor ([NullAllowed] NSUrl documentUrl, NSUrl documentContentsUrl, string typeName, [NullAllowed] out NSError outError);

		[Export ("revertDocumentToSaved:")]
		void RevertDocumentToSaved ([NullAllowed] NSObject sender);

		[Export ("revertToContentsOfURL:ofType:error:")]
		bool RevertToContentsOfUrl (NSUrl url, string typeName, [NullAllowed] out NSError outError);

		[Export ("readFromURL:ofType:error:")]
		bool ReadFromUrl (NSUrl url, string typeName, [NullAllowed] out NSError outError);

		[Export ("readFromFileWrapper:ofType:error:")]
		bool ReadFromFileWrapper (NSFileWrapper fileWrapper, string typeName, out NSError outError);

		[Export ("readFromData:ofType:error:")]
		bool ReadFromData (NSData data, string typeName, [NullAllowed] out NSError outError);

		[Export ("writeToURL:ofType:error:")]
		bool WriteToUrl (NSUrl url, string typeName, [NullAllowed] out NSError outError);

		[Export ("fileWrapperOfType:error:")]
		NSFileWrapper GetAsFileWrapper (string typeName, [NullAllowed] out NSError outError);

		[Export ("dataOfType:error:")]
		NSData GetAsData (string typeName, [NullAllowed] out NSError outError);

		[Export ("writeSafelyToURL:ofType:forSaveOperation:error:")]
		bool WriteSafelyToUrl (NSUrl url, string typeName, NSSaveOperationType saveOperation, [NullAllowed] out NSError outError);

		[Export ("writeToURL:ofType:forSaveOperation:originalContentsURL:error:")]
		bool WriteToUrl (NSUrl url, string typeName, NSSaveOperationType saveOperation, [NullAllowed] NSUrl absoluteOriginalContentsUrl, [NullAllowed] out NSError outError);

		[Export ("fileAttributesToWriteToURL:ofType:forSaveOperation:originalContentsURL:error:")]
		NSDictionary FileAttributesToWrite (NSUrl toUrl, string typeName, NSSaveOperationType saveOperation, [NullAllowed] NSUrl absoluteOriginalContentsUrl, [NullAllowed] out NSError outError);

		[Export ("keepBackupFile")]
		bool KeepBackupFile ();

		[Export ("saveDocument:")]
		void SaveDocument ([NullAllowed] NSObject sender);

		[Export ("saveDocumentAs:")]
		void SaveDocumentAs ([NullAllowed] NSObject sender);

		[Export ("saveDocumentTo:")]
		void SaveDocumentTo ([NullAllowed] NSObject sender);

		[Export ("saveDocumentWithDelegate:didSaveSelector:contextInfo:")]
		void SaveDocument ([NullAllowed] NSObject delegateObject, [NullAllowed] Selector didSaveSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("saveDocumentToPDF:")]
		void SaveDocumentAsPdf ([NullAllowed] NSObject sender);

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("PDFPrintOperation", ArgumentSemantic.Retain)]
		NSPrintOperation PDFPrintOperation { get; }

		[Export ("runModalSavePanelForSaveOperation:delegate:didSaveSelector:contextInfo:")]
		void RunModalSavePanelForSaveOperation (NSSaveOperationType saveOperation, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector didSaveSelector, [NullAllowed] IntPtr contextInfo);

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "Use 'SavePanelShowsFileFormatsControl' instead.")]
		[Export ("shouldRunSavePanelWithAccessoryView")]
		bool ShouldRunSavePanelWithAccessoryView { get; }

		[Mac (15, 0)]
		[Export ("savePanelShowsFileFormatsControl")]
		bool SavePanelShowsFileFormatsControl { get; }

		[Export ("prepareSavePanel:")]
		bool PrepareSavePanel (NSSavePanel savePanel);

		[Export ("fileNameExtensionWasHiddenInLastRunSavePanel")]
		bool FileNameExtensionWasHiddenInLastRunSavePanel { get; }

		[Export ("fileTypeFromLastRunSavePanel")]
		string FileTypeFromLastRunSavePanel { get; }

		[Export ("saveToURL:ofType:forSaveOperation:delegate:didSaveSelector:contextInfo:")]
		void SaveToUrl (NSUrl url, string typeName, NSSaveOperationType saveOperation, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector didSaveSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("saveToURL:ofType:forSaveOperation:error:")]
		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use a 'SaveToUrl' overload accepting a completion handler instead.")]
		bool SaveToUrl (NSUrl url, string typeName, NSSaveOperationType saveOperation, [NullAllowed] out NSError outError);

		[Export ("hasUnautosavedChanges")]
		bool HasUnautosavedChanges { get; }

		[Export ("autosaveDocumentWithDelegate:didAutosaveSelector:contextInfo:")]
		void AutosaveDocument ([NullAllowed] NSObject delegateObject, [NullAllowed] Selector didAutosaveSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("autosavingFileType")]
		string AutosavingFileType { get; }

		[Export ("canCloseDocumentWithDelegate:shouldCloseSelector:contextInfo:")]
		void CanCloseDocument (NSObject delegateObject, [NullAllowed] Selector shouldCloseSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("close")]
		void Close ();

		[Export ("runPageLayout:")]
		void RunPageLayout ([NullAllowed] NSObject sender);

		[Export ("runModalPageLayoutWithPrintInfo:delegate:didRunSelector:contextInfo:")]
		void RunModalPageLayout (NSPrintInfo printInfo, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector didRunSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("preparePageLayout:")]
		bool PreparePageLayout (NSPageLayout pageLayout);

		[Export ("shouldChangePrintInfo:")]
		bool ShouldChangePrintInfo (NSPrintInfo newPrintInfo);

		[Export ("printDocument:")]
		void PrintDocument ([NullAllowed] NSObject sender);

		[Export ("printDocumentWithSettings:showPrintPanel:delegate:didPrintSelector:contextInfo:")]
		void PrintDocument (NSDictionary printSettings, bool showPrintPanel, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector didPrintSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("printOperationWithSettings:error:")]
		NSPrintOperation PrintOperation (NSDictionary printSettings, [NullAllowed] out NSError outError);

		[Export ("runModalPrintOperation:delegate:didRunSelector:contextInfo:")]
		void RunModalPrintOperation (NSPrintOperation printOperation, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector didRunSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("isDocumentEdited")]
		bool IsDocumentEdited { get; }

		[Export ("updateChangeCount:")]
		void UpdateChangeCount (NSDocumentChangeType change);

		[Export ("presentError:modalForWindow:delegate:didPresentSelector:contextInfo:")]
		void PresentError (NSError error, NSWindow window, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector didPresentSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("presentError:")]
		bool PresentError (NSError error);

		[Export ("willPresentError:")]
		NSError WillPresentError (NSError error);

		[Export ("makeWindowControllers")]
		void MakeWindowControllers ();

		[Export ("windowNibName")]
		string WindowNibName { get; }

		[Export ("windowControllerWillLoadNib:")]
		void WindowControllerWillLoadNib (NSWindowController windowController);

		[Export ("windowControllerDidLoadNib:")]
		void WindowControllerDidLoadNib (NSWindowController windowController);

		[Export ("setWindow:")]
		void SetWindow ([NullAllowed] NSWindow window);

		[Export ("addWindowController:")]
		void AddWindowController (NSWindowController windowController);

		[Export ("removeWindowController:")]
		void RemoveWindowController (NSWindowController windowController);

		[Export ("showWindows")]
		void ShowWindows ();

		[Export ("windowControllers")]
		NSWindowController [] WindowControllers { get; }

		[Export ("shouldCloseWindowController:delegate:shouldCloseSelector:contextInfo:")]
		void ShouldCloseWindowController (NSWindowController windowController, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector shouldCloseSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("displayName")]
		[NullAllowed]
		string DisplayName { get; set; }

		[Export ("windowForSheet")]
		NSWindow WindowForSheet { get; }

		[Static, Export ("readableTypes", ArgumentSemantic.Copy)]
		string [] ReadableTypes { get; }

		[Static]
		[Export ("writableTypes", ArgumentSemantic.Copy)]
		string [] WritableTypes ();

		[Static]
		[Export ("isNativeType:")]
		bool IsNativeType (string type);

		[Export ("writableTypesForSaveOperation:")]
		string [] WritableTypesForSaveOperation (NSSaveOperationType saveOperation);

		[Export ("fileNameExtensionForType:saveOperation:")]
		string FileNameExtensionForSaveOperation (string typeName, NSSaveOperationType saveOperation);

		// Found in NSUserInterfaceValidations protocol with INSValidatedUserInterfaceItem param but bound originally with NSObject
		// Adding protocol gave warning 0108 which is unfixable without API break 
#if NET
#pragma warning disable 0108 // warning CS0108: 'NSDocument.ValidateUserInterfaceItem(INSValidatedUserInterfaceItem)' hides inherited member 'NSUserInterfaceValidations.ValidateUserInterfaceItem(INSValidatedUserInterfaceItem)'. Use the new keyword if hiding was intended.
		[Export ("validateUserInterfaceItem:")]
		bool ValidateUserInterfaceItem (INSValidatedUserInterfaceItem anItem);
#pragma warning restore
#else
		[Export ("validateUserInterfaceItem:")]
		bool ValidateUserInterfaceItem (NSObject /* must implement NSValidatedUserInterfaceItem */ anItem);

#pragma warning disable 0108
		[Wrap ("ValidateUserInterfaceItem ((NSObject)anItem)")]
		bool ValidateUserInterfaceItem (INSValidatedUserInterfaceItem anItem);
#pragma warning restore 0108
#endif

		//Detected properties
		[Export ("fileType")]
		string FileType { get; set; }

		[Export ("fileURL", ArgumentSemantic.Copy), NullAllowed]
		NSUrl FileUrl { get; set; }

		[Export ("fileModificationDate", ArgumentSemantic.Copy)]
		NSDate FileModificationDate { get; set; }

		[Export ("autosavedContentsFileURL", ArgumentSemantic.Copy)]
		NSUrl AutosavedContentsFileUrl { get; set; }

		[Export ("printInfo", ArgumentSemantic.Copy)]
		NSPrintInfo PrintInfo { get; set; }

		[Export ("undoManager", ArgumentSemantic.Retain)]
		NSUndoManager UndoManager { get; set; }

		[Export ("hasUndoManager")]
		bool HasUndoManager { get; set; }

		[Export ("performActivityWithSynchronousWaiting:usingBlock:")]
		void PerformActivity (bool waitSynchronously, Action activityCompletionHandler);

		[Export ("continueActivityUsingBlock:")]
		void ContinueActivity (Action resume);

		[Export ("continueAsynchronousWorkOnMainThreadUsingBlock:")]
		void ContinueAsynchronousWorkOnMainThread (Action work);

		[Export ("performSynchronousFileAccessUsingBlock:")]
		void PerformSynchronousFileAccess (Action fileAccessCallback);

		[Export ("performAsynchronousFileAccessUsingBlock:")]
		void PerformAsynchronousFileAccess (Action ioCode);

		[Export ("isEntireFileLoaded")]
		bool IsEntireFileLoaded { get; }

		[Export ("unblockUserInteraction")]
		void UnblockUserInteraction ();

		[Export ("autosavingIsImplicitlyCancellable")]
		bool AutosavingIsImplicitlyCancellable { get; }

		[Export ("saveToURL:ofType:forSaveOperation:completionHandler:")]
		void SaveTo (NSUrl url, string typeName, NSSaveOperationType saveOperation, NSDocumentCompletionHandler completionHandler);

		[Export ("canAsynchronouslyWriteToURL:ofType:forSaveOperation:")]
		bool CanWriteAsynchronously (NSUrl toUrl, string typeName, NSSaveOperationType saveOperation);

		[Export ("checkAutosavingSafetyAndReturnError:")]
		bool CheckAutosavingSafety ([NullAllowed] out NSError outError);

		[Export ("scheduleAutosaving")]
		void ScheduleAutosaving ();

		[Export ("autosaveWithImplicitCancellability:completionHandler:")]
		void Autosave (bool autosavingIsImplicitlyCancellable, NSDocumentCompletionHandler completionHandler);

		[Static]
		[Export ("autosavesInPlace")]
		bool AutosavesInPlace ();

		[Static]
		[Export ("preservesVersions")]
		bool PreservesVersions ();

		[Export ("duplicateDocument:")]
		void DuplicateDocument ([NullAllowed] NSObject sender);

		[Export ("duplicateDocumentWithDelegate:didDuplicateSelector:contextInfo:"), Internal]
		void _DuplicateDocument ([NullAllowed] NSObject cbackobject, [NullAllowed] Selector didDuplicateSelector, [NullAllowed] IntPtr contextInfo);

		[Export ("duplicateAndReturnError:")]
		NSDocument Duplicate ([NullAllowed] out NSError outError);

		[Export ("isInViewingMode")]
		bool IsInViewingMode { get; }

		[Export ("changeCountTokenForSaveOperation:")]
		NSObject ChangeCountToken (NSSaveOperationType saveOperation);

		[Export ("updateChangeCountWithToken:forSaveOperation:")]
		void UpdateChangeCount (NSObject changeCountToken, NSSaveOperationType saveOperation);

		[Export ("willNotPresentError:")]
		void WillNotPresentError (NSError error);

		[Export ("restoreDocumentWindowWithIdentifier:state:completionHandler:")]
		void RestoreDocumentWindow (string identifier, NSCoder state, NSWindowCompletionHandler completionHandler);

		// This one comes from the NSRestorableState category ('@interface NSResponder (NSRestorableState)')
		[Export ("encodeRestorableStateWithCoder:")]
		void EncodeRestorableState (NSCoder coder);

		// This one comes from the NSRestorableState category ('@interface NSResponder (NSRestorableState)')
		[Export ("restoreStateWithCoder:")]
		void RestoreState (NSCoder coder);

		// This one comes from the NSRestorableState category ('@interface NSResponder (NSRestorableState)')
		[Export ("invalidateRestorableState")]
		void InvalidateRestorableState ();

		// This one comes from the NSRestorableState category ('@interface NSResponder (NSRestorableState)')
		[Static]
		[Export ("restorableStateKeyPaths", ArgumentSemantic.Copy)]
		string [] RestorableStateKeyPaths ();

		[Static]
		[Export ("allowedClassesForRestorableStateKeyPath:")]
		Class [] GetAllowedClasses (string keyPath);

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("userActivity", ArgumentSemantic.Strong)]
		NSUserActivity UserActivity { get; set; }

		[Export ("updateUserActivityState:")]
		void UpdateUserActivityState (NSUserActivity userActivity);

#if !NET
		// Should be removed but radar://42781537 - Classes fail to conformsToProtocol despite header declaration
		[Export ("restoreUserActivityState:")]
		new void RestoreUserActivityState (NSUserActivity userActivity);
#endif

		[Export ("isBrowsingVersions")]
		bool IsBrowsingVersions { get; }


		[Export ("stopBrowsingVersionsWithCompletionHandler:")]
		[Async]
		void StopBrowsingVersions ([NullAllowed] Action completionHandler);

		[Export ("allowsDocumentSharing")]
		bool AllowsDocumentSharing { get; }

		[Export ("shareDocumentWithSharingService:completionHandler:")]
		[Async]
		void ShareDocument (NSSharingService sharingService, [NullAllowed] Action<bool> completionHandler);

		[Export ("prepareSharingServicePicker:")]
		void Prepare (NSSharingServicePicker sharingServicePicker);

		[Mac (13, 2)]
		[NullAllowed]
		[Export ("previewRepresentableActivityItems", ArgumentSemantic.Copy)]
		INSPreviewRepresentableActivityItem [] PreviewRepresentableActivityItems { get; set; }
	}

	delegate void OpenDocumentCompletionHandler (NSDocument document, bool documentWasAlreadyOpen, NSError error);

	[NoMacCatalyst]
	[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	partial interface NSDocumentController : NSWindowRestoration, NSCoding {
		[Static, Export ("sharedDocumentController")]
		NSDocumentController SharedDocumentController { get; }

		[Export ("documents")]
		NSDocument [] Documents { get; }

		[Export ("currentDocument")]
		NSDocument CurrentDocument { get; }

		[Export ("currentDirectory")]
		string CurrentDirectory { get; }

		[Export ("documentForURL:")]
		NSDocument DocumentForUrl (NSUrl url);

		[Export ("documentForWindow:")]
		NSDocument DocumentForWindow (NSWindow window);

		[Export ("addDocument:")]
		void AddDocument (NSDocument document);

		[Export ("removeDocument:")]
		void RemoveDocument (NSDocument document);

		[Export ("newDocument:")]
		void NewDocument ([NullAllowed] NSObject sender);

		[Export ("openUntitledDocumentAndDisplay:error:")]
		NSObject OpenUntitledDocument (bool displayDocument, out NSError outError);

		[Export ("makeUntitledDocumentOfType:error:")]
		NSObject MakeUntitledDocument (string typeName, out NSError error);

		[Export ("openDocument:")]
		void OpenDocument ([NullAllowed] NSObject sender);

		[Export ("URLsFromRunningOpenPanel")]
		NSUrl [] UrlsFromRunningOpenPanel ();

		[Export ("runModalOpenPanel:forTypes:")]
		nint RunModalOpenPanel (NSOpenPanel openPanel, string [] types);

		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use 'OpenDocument (NSUrl, bool, OpenDocumentCompletionHandler)' instead.")]
		[Export ("openDocumentWithContentsOfURL:display:error:")]
		NSObject OpenDocument (NSUrl url, bool displayDocument, out NSError outError);

		[Export ("openDocumentWithContentsOfURL:display:completionHandler:")]
		void OpenDocument (NSUrl url, bool display, OpenDocumentCompletionHandler completionHandler);

		[Export ("makeDocumentWithContentsOfURL:ofType:error:")]
		NSObject MakeDocument (NSUrl url, string typeName, out NSError outError);

		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use 'NSDocumentController.ReopenDocumentForUrl (NSUrl, NSUrl, bool, OpenDocumentCompletionHandler)' instead.")]
		[Export ("reopenDocumentForURL:withContentsOfURL:error:")]
		bool ReopenDocument (NSUrl url, NSUrl contentsUrl, out NSError outError);

		[Export ("makeDocumentForURL:withContentsOfURL:ofType:error:")]
		NSObject MakeDocument ([NullAllowed] NSUrl urlOrNil, NSUrl contentsUrl, string typeName, out NSError outError);

		[Export ("saveAllDocuments:")]
		void SaveAllDocuments ([NullAllowed] NSObject sender);

		[Export ("hasEditedDocuments")]
		bool HasEditedDocuments { get; }

		[Export ("reviewUnsavedDocumentsWithAlertTitle:cancellable:delegate:didReviewAllSelector:contextInfo:")]
		void ReviewUnsavedDocuments (string title, bool cancellable, NSObject delegateObject, Selector didReviewAllSelector, IntPtr contextInfo);

		[Export ("closeAllDocumentsWithDelegate:didCloseAllSelector:contextInfo:")]
		void CloseAllDocuments (NSObject delegateObject, Selector didCloseAllSelector, IntPtr contextInfo);

		[Export ("presentError:modalForWindow:delegate:didPresentSelector:contextInfo:")]
		void PresentError (NSError error, NSWindow window, [NullAllowed] NSObject delegateObject, [NullAllowed] Selector didPresentSelector, IntPtr contextInfo);

		[Export ("presentError:")]
		bool PresentError (NSError error);

		[Export ("willPresentError:")]
		NSError WillPresentError (NSError error);

		[Export ("maximumRecentDocumentCount"), ThreadSafe]
		nint MaximumRecentDocumentCount { get; }

		[Export ("clearRecentDocuments:")]
		void ClearRecentDocuments ([NullAllowed] NSObject sender);

		[Export ("noteNewRecentDocument:")]
		void NoteNewRecentDocument (NSDocument document);

		[Export ("noteNewRecentDocumentURL:")]
		void NoteNewRecentDocumentURL (NSUrl url);

		[Export ("recentDocumentURLs")]
		NSUrl [] RecentDocumentUrls { get; }

		[Export ("defaultType")]
		string DefaultType { get; }

		[Export ("typeForContentsOfURL:error:")]
		string TypeForUrl (NSUrl url, out NSError outError);

		[Export ("documentClassNames")]
		string [] DocumentClassNames { get; }

		[Export ("documentClassForType:")]
		Class DocumentClassForType (string typeName);

		[Export ("displayNameForType:")]
		string DisplayNameForType (string typeName);

		// Found in NSUserInterfaceValidations protocol with INSValidatedUserInterfaceItem param but bound originally with NSObject
		// Adding protocol gave warning 0108 which is unfixable without API break 
#if NET
#pragma warning disable 0108 // warning CS0108: 'NSDocumentController.ValidateUserInterfaceItem(INSValidatedUserInterfaceItem)' hides inherited member 'NSUserInterfaceValidations.ValidateUserInterfaceItem(INSValidatedUserInterfaceItem)'. Use the new keyword if hiding was intended.
		[Export ("validateUserInterfaceItem:")]
		bool ValidateUserInterfaceItem (INSValidatedUserInterfaceItem anItem);
#pragma warning restore
#else
		[Export ("validateUserInterfaceItem:")]
		bool ValidateUserInterfaceItem (NSObject /* must implement NSValidatedUserInterfaceItem */ anItem);

#pragma warning disable 0108
		[Wrap ("ValidateUserInterfaceItem ((NSObject)anItem)")]
		bool ValidateUserInterfaceItem (INSValidatedUserInterfaceItem anItem);
#pragma warning restore 0108
#endif

		//Detected properties
		[Export ("autosavingDelay")]
		double AutosavingDelay { get; set; }
	}

	/*
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSDraggingImageComponent {
		[Export ("key", ArgumentSemantic.Copy)]
		string Key { get; set; }

		[Export ("contents", ArgumentSemantic.Strong)]
		NSObject Contents { get; set; }

		[Export ("frame")]
		CGRect Frame { get; set; }

		[Static]
		[Export ("draggingImageComponentWithKey:")]
		NSDraggingImageComponent FromKey (string key);

		[Export ("initWithKey:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string key);

		[Field ("NSDraggingImageComponentIconKey")]
		NSString IconKey { get; }

		[Field ("NSDraggingImageComponentLabelKey")]
		NSString LabelKey { get; }
	}
	*/

	[NoMacCatalyst]
	delegate NSDraggingImageComponent [] NSDraggingItemImagesContentProvider ();

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSDraggingItem {
		[Export ("item", ArgumentSemantic.Strong)]
		NSObject Item { get; }

		[Export ("draggingFrame")]
		CGRect DraggingFrame { get; set; }

		[Export ("imageComponents", ArgumentSemantic.Copy)]
		NSDraggingImageComponent [] ImageComponents { get; }

		[Export ("initWithPasteboardWriter:")]
		[DesignatedInitializer]
		NativeHandle Constructor (INSPasteboardWriting pasteboardWriter);

		[Export ("setImageComponentsProvider:")]
		void SetImagesContentProvider ([NullAllowed] NSDraggingItemImagesContentProvider provider);

		[Export ("setDraggingFrame:contents:")]
		void SetDraggingFrame (CGRect frame, NSObject contents);

	}

	[NoMacCatalyst]
#if !NET
	[BaseType (typeof (NSObject))]
#endif
	[Protocol] // Apple docs say: "you never need to create a class that implements the NSDraggingInfo protocol.", so don't add [Model]
	interface NSDraggingInfo {
#if NET
		[Abstract]
#endif
		[Export ("draggingDestinationWindow")]
		NSWindow DraggingDestinationWindow { get; }

#if NET
		[Abstract]
#endif
		[Export ("draggingSourceOperationMask")]
		NSDragOperation DraggingSourceOperationMask { get; }

#if NET
		[Abstract]
#endif
		[Export ("draggingLocation")]
		CGPoint DraggingLocation { get; }

#if NET
		[Abstract]
#endif
		[Export ("draggedImageLocation")]
		CGPoint DraggedImageLocation { get; }

#if NET
		[Abstract]
#endif
		[Export ("draggedImage")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use 'NSDraggingItem' objects instead.")]
		NSImage DraggedImage { get; }

#if NET
		[Abstract]
#endif
		[Export ("draggingPasteboard")]
		NSPasteboard DraggingPasteboard { get; }

#if NET
		[Abstract]
#endif
		[Export ("draggingSource")]
		NSObject DraggingSource { get; }

#if NET
		[Abstract]
#endif
		[Export ("draggingSequenceNumber")]
		nint DraggingSequenceNumber { get; }

#if NET
		[Abstract]
#endif
		[Export ("slideDraggedImageTo:")]
		void SlideDraggedImageTo (CGPoint screenPoint);

#if NET
		[Abstract]
#endif
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use NSFilePromiseProvider objects instead.")]
		[Export ("namesOfPromisedFilesDroppedAtDestination:")]
		string [] PromisedFilesDroppedAtDestination (NSUrl dropDestination);

#if NET
		[Abstract]
#endif
		[Export ("animatesToDestination")]
		bool AnimatesToDestination { get; set; }

#if NET
		[Abstract]
#endif
		[Export ("numberOfValidItemsForDrop")]
		nint NumberOfValidItemsForDrop { get; set; }

#if NET
		[Abstract]
#endif
		[Export ("draggingFormation")]
		NSDraggingFormation DraggingFormation { get; set; }

#if NET
		[Abstract]
#endif
		[Export ("enumerateDraggingItemsWithOptions:forView:classes:searchOptions:usingBlock:")]
		void EnumerateDraggingItems (NSDraggingItemEnumerationOptions enumOpts, NSView view, IntPtr classArray,
						 NSDictionary searchOptions, NSDraggingEnumerator enumerator);

#if NET
		[Abstract]
#endif
		[Export ("springLoadingHighlight")]
		NSSpringLoadingHighlight SpringLoadingHighlight { get; }

#if NET
		[Abstract]
#endif
		[Export ("resetSpringLoading")]
		void ResetSpringLoading ();
	}



	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSDraggingDestination {
		[Export ("draggingEntered:"), DefaultValue (NSDragOperation.None)]
#if NET
		NSDragOperation DraggingEntered (INSDraggingInfo sender);
#else
		NSDragOperation DraggingEntered (NSDraggingInfo sender);
#endif

		[Export ("draggingUpdated:"), DefaultValue (NSDragOperation.None)]
#if NET
		NSDragOperation DraggingUpdated (INSDraggingInfo sender);
#else
		NSDragOperation DraggingUpdated (NSDraggingInfo sender);
#endif

		[Export ("draggingExited:")]
#if NET
		void DraggingExited ([NullAllowed] INSDraggingInfo sender);
#else
		void DraggingExited (NSDraggingInfo sender);
#endif

		[Export ("prepareForDragOperation:"), DefaultValue (false)]
#if NET
		bool PrepareForDragOperation (INSDraggingInfo sender);
#else
		bool PrepareForDragOperation (NSDraggingInfo sender);
#endif

		[Export ("performDragOperation:"), DefaultValue (false)]
#if NET
		bool PerformDragOperation (INSDraggingInfo sender);
#else
		bool PerformDragOperation (NSDraggingInfo sender);
#endif

		[Export ("concludeDragOperation:")]
#if NET
		void ConcludeDragOperation ([NullAllowed] INSDraggingInfo sender);
#else
		void ConcludeDragOperation (NSDraggingInfo sender);
#endif

		[Export ("draggingEnded:")]
#if NET
		void DraggingEnded (INSDraggingInfo sender);
#else
		void DraggingEnded (NSDraggingInfo sender);
#endif

		[DebuggerBrowsableAttribute (DebuggerBrowsableState.Never)]
		[Export ("wantsPeriodicDraggingUpdates"), DefaultValue (true)]
		bool WantsPeriodicDraggingUpdates { get; }
	}

	[NoMacCatalyst]
	delegate void NSDraggingEnumerator (NSDraggingItem draggingItem, nint idx, ref bool stop);

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // warning on dispose - created using NSView.BeginDraggingSession
	interface NSDraggingSession {
		[Export ("draggingFormation")]
		NSDraggingFormation DraggingFormation { get; set; }

		[Export ("animatesToStartingPositionsOnCancelOrFail")]
		bool AnimatesToStartingPositionsOnCancelOrFail { get; set; }

		[Export ("draggingLeaderIndex")]
		nint DraggingLeaderIndex { get; set; }

		[Export ("draggingPasteboard")]
		NSPasteboard DraggingPasteboard { get; }

		[Export ("draggingSequenceNumber")]
		nint DraggingSequenceNumber { get; }

		[Export ("draggingLocation")]
		CGPoint DraggingLocation { get; }

		[Internal]
		[Export ("enumerateDraggingItemsWithOptions:forView:classes:searchOptions:usingBlock:")]
		void EnumerateDraggingItems (NSDraggingItemEnumerationOptions enumOpts, NSView view, IntPtr classArray, [NullAllowed] NSDictionary searchOptions, NSDraggingEnumerator enumerator);
	}

	interface INSDraggingSource { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSDraggingSource {
		[Export ("draggingSourceOperationMaskForLocal:"), DefaultValue (NSDragOperation.None)]
		NSDragOperation DraggingSourceOperationMaskForLocal (bool flag);

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use NSFilePromiseProvider objects instead.")]
		[Export ("namesOfPromisedFilesDroppedAtDestination:"), DefaultValue (new string [0])]
		string [] NamesOfPromisedFilesDroppedAtDestination (NSUrl dropDestination);

		[Export ("draggedImage:beganAt:")]
		void DraggedImageBeganAt (NSImage image, CGPoint screenPoint);

		[Export ("draggedImage:endedAt:operation:")]
		void DraggedImageEndedAtOperation (NSImage image, CGPoint screenPoint, NSDragOperation operation);

		[Export ("draggedImage:movedTo:")]
		void DraggedImageMovedTo (NSImage image, CGPoint screenPoint);

		[Export ("ignoreModifierKeysWhileDragging"), DefaultValue (false)]
		bool IgnoreModifierKeysWhileDragging { get; }

		[Deprecated (PlatformName.MacOSX, 10, 1, message: "Use DraggedImageEndedAtOperation instead.")]
		[Export ("draggedImage:endedAt:deposited:")]
		void DraggedImageEndedAtDeposited (NSImage image, CGPoint screenPoint, bool deposited);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSResponder), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSDrawerDelegate) })]
	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSSplitViewController' instead.")]
	partial interface NSDrawer : NSAccessibilityElementProtocol, NSAccessibility {
		[Export ("initWithContentSize:preferredEdge:")]
		NativeHandle Constructor (CGSize contentSize, NSRectEdge edge);

		[Export ("parentWindow")]
		NSWindow ParentWindow { get; set; }

		[Export ("contentView", ArgumentSemantic.Retain)]
		NSView ContentView { get; set; }

		[Export ("preferredEdge")]
		NSRectEdge PreferredEdge { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSDrawerDelegate Delegate { get; set; }

		[Export ("open")]
		void Open ();

		[Export ("openOnEdge:")]
		void OpenOnEdge (NSRectEdge edge);

		[Export ("close")]
		void Close ();

		[Export ("open:")]
		void Open (NSObject sender);

		[Export ("close:")]
		void Close (NSObject sender);

		[Export ("toggle:")]
		void Toggle (NSObject sender);

		[Export ("state")]
		NSDrawerState State { get; }

		[Export ("edge")]
		NSRectEdge Edge { get; }

		[Export ("contentSize")]
		CGSize ContentSize { get; set; }

		[Export ("minContentSize")]
		CGSize MinContentSize { get; set; }

		[Export ("maxContentSize")]
		CGSize MaxContentSize { get; set; }

		[Export ("leadingOffset")]
		nfloat LeadingOffset { get; set; }

		[Export ("trailingOffset")]
		nfloat TrailingOffset { get; set; }
	}

	interface INSDrawerDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSSplitViewController' instead.")]
	interface NSDrawerDelegate {
		[Export ("drawerDidClose:"), EventArgs ("NSNotification")]
		void DrawerDidClose (NSNotification notification);

		[Export ("drawerDidOpen:"), EventArgs ("NSNotification")]
		void DrawerDidOpen (NSNotification notification);

		[Export ("drawerShouldClose:"), DelegateName ("DrawerShouldCloseDelegate"), DefaultValue (true)]
		bool DrawerShouldClose (NSDrawer sender);

		[Export ("drawerShouldOpen:"), DelegateName ("DrawerShouldOpenDelegate"), DefaultValue (true)]
		bool DrawerShouldOpen (NSDrawer sender);

		[Export ("drawerWillClose:"), EventArgs ("NSNotification")]
		void DrawerWillClose (NSNotification notification);

		[Export ("drawerWillOpen:"), EventArgs ("NSNotification")]
		void DrawerWillOpen (NSNotification notification);

		[Export ("drawerWillResizeContents:toSize:"), DelegateName ("DrawerWillResizeContentsDelegate"), DefaultValue (null)]
		CGSize DrawerWillResizeContents (NSDrawer sender, CGSize toSize);

	}

	[NoMacCatalyst]
	[Protocol]
	interface NSFontChanging {
		[Export ("changeFont:")]
		void ChangeFont ([NullAllowed] NSFontManager sender);

		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Now optional method.")]
		[Export ("validModesForFontPanel:")]
		NSFontPanelModeMask GetValidModes (NSFontPanel fontPanel);
	}
	
	public partial class NSFont : NSObject, NSCopying {

		public NSFont(IntPtr handle) : base(handle) {}
		
		[Export ("fontWithName:size:")]
		internal static IntPtr _FromFontName (string fontName, nfloat fontSize);

		//[Static]
		//[Export ("fontWithName:matrix:")]
		//NSFont FromFontName (string fontName, float [] fontMatrix);

		[Static]
		[Internal]
		[Export ("fontWithDescriptor:size:")]
		internal static IntPtr _FromDescription (NSFontDescriptor fontDescriptor, nfloat fontSize);

		[Static]
		[Internal]
		[Export ("fontWithDescriptor:textTransform:")]
		internal static IntPtr _FromDescription (NSFontDescriptor fontDescriptor, [NullAllowed] NSAffineTransform textTransform);

		[Static]
		[Internal]
		[Export ("userFontOfSize:")]
		internal static IntPtr _UserFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("userFixedPitchFontOfSize:")]
		internal static IntPtr _UserFixedPitchFontOfSize (nfloat fontSize);

		[Static]
		[Export ("setUserFont:")]
		public static void SetUserFont ([NullAllowed] NSFont aFont);

		[Static]
		[Export ("setUserFixedPitchFont:")]
		public static void SetUserFixedPitchFont ([NullAllowed] NSFont aFont);

		[Static]
		[Internal]
		[Export ("systemFontOfSize:")]
		internal static IntPtr _SystemFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("boldSystemFontOfSize:")]
		internal static IntPtr _BoldSystemFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("labelFontOfSize:")]
		internal static IntPtr _LabelFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("titleBarFontOfSize:")]
		internal static IntPtr _TitleBarFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("menuFontOfSize:")]
		internal static IntPtr _MenuFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("menuBarFontOfSize:")]
		internal static IntPtr _MenuBarFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("messageFontOfSize:")]
		internal static IntPtr _MessageFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("paletteFontOfSize:")]
		internal static IntPtr _PaletteFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("toolTipsFontOfSize:")]
		internal static IntPtr _ToolTipsFontOfSize (nfloat fontSize);

		[Static]
		[Internal]
		[Export ("controlContentFontOfSize:")]
		internal static IntPtr _ControlContentFontOfSize (nfloat fontSize);

		[Static]
		[Export ("systemFontSize")]
		public static nfloat SystemFontSize { get; }

		[Static]
		[Export ("smallSystemFontSize")]
		public static nfloat SmallSystemFontSize { get; }

		[Static]
		[Export ("labelFontSize")]
		public static nfloat LabelFontSize { get; }

		[Static]
		[Export ("systemFontSizeForControlSize:")]
		public static nfloat SystemFontSizeForControlSize (NSControlSize controlSize);

		[Export ("fontName")]
		public string FontName { get; }

		[Export ("pointSize")]
		public nfloat PointSize { get; }

		//[Export ("matrix")]
		//  FIXME
		//IntPtr *float Matrix { get; }

		[Export ("familyName")]
		public string FamilyName { get; }

		[Export ("displayName")]
		public string DisplayName { get; }

		[Export ("fontDescriptor")]
		public NSFontDescriptor FontDescriptor { get; }

		[Export ("textTransform")]
		public NSAffineTransform TextTransform { get; }

		[Export ("numberOfGlyphs")]
		public nint GlyphCount { get; }

		[Export ("mostCompatibleStringEncoding")]
		public NSStringEncoding MostCompatibleStringEncoding { get; }

		[Export ("glyphWithName:")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use the 'CGGlyph' APIs instead.")]
		public uint GlyphWithName (string aName); /* NSGlyph = unsigned int */

		[Export ("coveredCharacterSet")]
		public NSCharacterSet CoveredCharacterSet { get; }

		[Export ("boundingRectForFont")]
		public CGRect BoundingRectForFont { get; }

		[Export ("maximumAdvancement")]
		public CGSize MaximumAdvancement { get; }

		[Export ("ascender")]
		public nfloat Ascender { get; }

		[Export ("descender")]
		public nfloat Descender { get; }

		[Export ("leading")]
		public nfloat Leading { get; }

		[Export ("underlinePosition")]
		public nfloat UnderlinePosition { get; }

		[Export ("underlineThickness")]
		public nfloat UnderlineThickness { get; }

		[Export ("italicAngle")]
		public nfloat ItalicAngle { get; }

		[Export ("capHeight")]
		public nfloat CapHeight { get; }

		[Export ("xHeight")]
		public nfloat XHeight { get; }

		[Export ("isFixedPitch")]
		public bool IsFixedPitch { get; }

		[Export ("boundingRectForGlyph:")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use the 'CGGlyph' APIs instead.")]
		public CGRect BoundingRectForGlyph (uint /* NSGlyph = unsigned int */ aGlyph);

		[Export ("advancementForGlyph:")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use the 'CGGlyph' APIs instead.")]
		public CGSize AdvancementForGlyph (uint /* NSGlyph = unsigned int */ aGlyph);

		[Export ("set")]
		public void Set ();

		[Export ("setInContext:")]
		public void SetInContext (NSGraphicsContext graphicsContext);

		[Export ("printerFont")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[Internal]
		public IntPtr _PrinterFont { get; }

		[Export ("screenFont")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[Internal]
		public IntPtr _ScreenFont { get; }

		[Export ("screenFontWithRenderingMode:")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[Internal]
		public IntPtr _ScreenFontWithRenderingMode (NSFontRenderingMode renderingMode);

		[Export ("renderingMode")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		public NSFontRenderingMode RenderingMode { get; }

		[Export ("isVertical")]
		public bool IsVertical { get; }

		//
		// Not a property because this causes the creation of a new font on request in the specified configuration.
		//
		[Export ("verticalFont")]
		[Internal]
		public IntPtr _GetVerticalFont ();

		[Field ("NSFontFamilyAttribute")]
		public NSString FamilyAttribute { get; }

		[Field ("NSFontNameAttribute")]
		public NSString NameAttribute { get; }

		[Field ("NSFontFaceAttribute")]
		public NSString FaceAttribute { get; }

		[Field ("NSFontSizeAttribute")]
		public NSString SizeAttribute { get; }

		[Field ("NSFontVisibleNameAttribute")]
		public NSString VisibleNameAttribute { get; }

		[Field ("NSFontMatrixAttribute")]
		public NSString MatrixAttribute { get; }

		[Field ("NSFontVariationAttribute")]
		public NSString VariationAttribute { get; }

		[Field ("NSFontCharacterSetAttribute")]
		public NSString CharacterSetAttribute { get; }

		[Field ("NSFontCascadeListAttribute")]
		public NSString CascadeListAttribute { get; }

		[Field ("NSFontTraitsAttribute")]
		public NSString TraitsAttribute { get; }

		[Field ("NSFontFixedAdvanceAttribute")]
		public NSString FixedAdvanceAttribute { get; }

		[Field ("NSFontFeatureSettingsAttribute")]
		public NSString FeatureSettingsAttribute { get; }

		[Field ("NSFontSymbolicTrait")]
		public NSString SymbolicTrait { get; }

		[Field ("NSFontWeightTrait")]
		public NSString WeightTrait { get; }

		[Field ("NSFontWidthTrait")]
		public NSString WidthTrait { get; }

		[Field ("NSFontSlantTrait")]
		public NSString SlantTrait { get; }

		[Field ("NSFontVariationAxisIdentifierKey")]
		public NSString VariationAxisIdentifierKey { get; }

		[Field ("NSFontVariationAxisMinimumValueKey")]
		public NSString VariationAxisMinimumValueKey { get; }

		[Field ("NSFontVariationAxisMaximumValueKey")]
		public NSString VariationAxisMaximumValueKey { get; }

		[Field ("NSFontVariationAxisDefaultValueKey")]
		public NSString VariationAxisDefaultValueKey { get; }

		[Field ("NSFontVariationAxisNameKey")]
		public NSString VariationAxisNameKey { get; }

		[Field ("NSFontFeatureTypeIdentifierKey")]
		public NSString FeatureTypeIdentifierKey { get; }

		[Field ("NSFontFeatureSelectorIdentifierKey")]
		public NSString FeatureSelectorIdentifierKey { get; }

		[Static]
		[Export ("systemFontOfSize:weight:")]
		[Internal]
		public static IntPtr _SystemFontOfSize (nfloat fontSize, nfloat weight);

		[Mac (13, 0)]
		[Static]
		[Export ("systemFontOfSize:weight:width:")]
		[Internal]
		public static IntPtr _SystemFontOfSize (nfloat fontSize, nfloat weight, nfloat width);

		[Static]
		[Export ("monospacedDigitSystemFontOfSize:weight:")]
		[Internal]
		public static IntPtr _MonospacedDigitSystemFontOfSize (nfloat fontSize, nfloat weight);

		[Export ("boundingRectForCGGlyph:")]
		public CGRect GetBoundingRect (CGGlyph glyph);

		[Export ("advancementForCGGlyph:")]
		public CGSize GetAdvancement (CGGlyph glyph);

		[Internal]
		[Export ("getBoundingRects:forCGGlyphs:count:")]
		public void _GetBoundingRects (IntPtr bounds, IntPtr glyphs, nuint glyphCount);

		[Internal]
		[Export ("getAdvancements:forCGGlyphs:count:")]
		public void _GetAdvancements (IntPtr advancements, IntPtr glyphs, nuint glyphCount);

		[Static]
		[Export ("monospacedSystemFontOfSize:weight:")]
		[Internal]
		public IntPtr _MonospacedSystemFont (nfloat fontSize, nfloat weight);

		[Static]
		[Export ("preferredFontForTextStyle:options:")]
		public NSFont GetPreferredFont (string textStyle, NSDictionary options);

		[Export ("fontWithSize:")]
		public NSFont GetFont (nfloat fontSize);
	}

	[NoMacCatalyst]
	interface NSFontCollectionChangedEventArgs {
		[Internal, Export ("NSFontCollectionActionKey")]
		NSString _Action { get; }

		[Export ("NSFontCollectionNameKey")]
		string Name { get; }

		[Export ("NSFontCollectionOldNameKey")]
		string OldName { get; }

		[Internal, Export ("NSFontCollectionVisibilityKey")]
		NSNumber _Visibility { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSFontCollection : NSSecureCoding, NSMutableCopying {
		[Static]
		[Export ("fontCollectionWithDescriptors:")]
		NSFontCollection FromDescriptors (NSFontDescriptor [] queryDescriptors);

		[Static]
		[Export ("fontCollectionWithAllAvailableDescriptors", ArgumentSemantic.Copy)]
		NSFontCollection GetAllAvailableFonts ();

		[Static]
		[Export ("fontCollectionWithLocale:")]
		NSFontCollection FromLocale (NSLocale locale);

		[Static]
		[Export ("showFontCollection:withName:visibility:error:")]
		bool ShowFontCollection (NSFontCollection fontCollection, string name, NSFontCollectionVisibility visibility, out NSError error);

		[Static]
		[Export ("hideFontCollectionWithName:visibility:error:")]
		bool HideFontCollection (string name, NSFontCollectionVisibility visibility, out NSError error);

		[Static]
		[Export ("renameFontCollectionWithName:visibility:toName:error:")]
		bool RenameFontCollection (string fromName, NSFontCollectionVisibility visibility, string toName, out NSError error);

		[Static]
		[Export ("allFontCollectionNames", ArgumentSemantic.Copy)]
		string [] AllFontCollectionNames { get; }

		[Static]
		[Export ("fontCollectionWithName:")]
		NSFontCollection FromName (string name);

		[Static]
		[Export ("fontCollectionWithName:visibility:")]
		NSFontCollection FromName (string name, NSFontCollectionVisibility visibility);

		[Export ("queryDescriptors")]
		NSFontDescriptor [] GetQueryDescriptors ();

		[Export ("exclusionDescriptors")]
		NSFontDescriptor [] GetExclusionDescriptors ();

		[Export ("matchingDescriptors")]
		NSFontDescriptor [] GetMatchingDescriptors ();

		[Export ("matchingDescriptorsWithOptions:")]
		NSFontDescriptor [] GetMatchingDescriptors (NSDictionary options);

		[Export ("matchingDescriptorsForFamily:")]
		NSFontDescriptor [] GetMatchingDescriptors (string family);

		[Export ("matchingDescriptorsForFamily:options:")]
		NSFontDescriptor [] GetMatchingDescriptors (string family, NSDictionary options);

		[Field ("NSFontCollectionIncludeDisabledFontsOption")]
		NSString IncludeDisabledFontsOption { get; }

		[Field ("NSFontCollectionRemoveDuplicatesOption")]
		NSString RemoveDuplicatesOption { get; }

		[Field ("NSFontCollectionDisallowAutoActivationOption")]
		NSString DisallowAutoActivationOption { get; }

		[Notification (typeof (NSFontCollectionChangedEventArgs)), Field ("NSFontCollectionDidChangeNotification")]
		NSString ChangedNotification { get; }

		[Field ("NSFontCollectionActionKey")]
		NSString ActionKey { get; }

		[Field ("NSFontCollectionNameKey")]
		NSString NameKey { get; }

		[Field ("NSFontCollectionOldNameKey")]
		NSString OldNameKey { get; }

		[Field ("NSFontCollectionVisibilityKey")]
		NSString VisibilityKey { get; }

		[Field ("NSFontCollectionWasShown")]
		NSString ActionWasShown { get; }

		[Field ("NSFontCollectionWasHidden")]
		NSString ActionWasHidden { get; }

		[Field ("NSFontCollectionWasRenamed")]
		NSString ActionWasRenamed { get; }

		[Field ("NSFontCollectionAllFonts")]
		NSString NameAllFonts { get; }

		[Field ("NSFontCollectionUser")]
		NSString NameUser { get; }

		[Field ("NSFontCollectionFavorites")]
		NSString NameFavorites { get; }

		[Field ("NSFontCollectionRecentlyUsed")]
		NSString NameRecentlyUsed { get; }

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSFontCollection))]
	[DisableDefaultCtor]
	interface NSMutableFontCollection {
		[Export ("setQueryDescriptors:")]
		void SetQueryDescriptors (NSFontDescriptor [] descriptors);

		[Export ("setExclusionDescriptors:")]
		void SetExclusionDescriptors (NSFontDescriptor [] descriptors);

		[Export ("addQueryForDescriptors:")]
		void AddQueryForDescriptors (NSFontDescriptor [] descriptors);

		[Export ("removeQueryForDescriptors:")]
		void RemoveQueryForDescriptors (NSFontDescriptor [] descriptors);

		[Static]
		[Export ("fontCollectionWithDescriptors:")]
		NSMutableFontCollection FromDescriptors (NSFontDescriptor [] queryDescriptors);

		[Static]
		[Export ("fontCollectionWithAllAvailableDescriptors", ArgumentSemantic.Copy)]
		NSMutableFontCollection GetAllAvailableFonts ();

		[Static]
		[Export ("fontCollectionWithLocale:")]
		NSMutableFontCollection FromLocale (NSLocale locale);

		[Static]
		[Export ("fontCollectionWithName:")]
		NSMutableFontCollection FromName (string name);

		[Static]
		[Export ("fontCollectionWithName:visibility:")]
		NSMutableFontCollection FromName (string name, NSFontCollectionVisibility visibility);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSFontDescriptor : NSSecureCoding, NSCopying {
		[Export ("postscriptName")]
		string PostscriptName { get; }

		[Export ("pointSize")]
		nfloat PointSize { get; }

		[Export ("matrix")]
		NSAffineTransform Matrix { get; }

		[Export ("symbolicTraits")]
		NSFontSymbolicTraits SymbolicTraits { get; }

		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		[Export ("fontAttributes")]
		NSDictionary FontAttributes { get; }

		[Static]
		[Export ("fontDescriptorWithFontAttributes:")]
		NSFontDescriptor FromAttributes (NSDictionary attributes);

		[Static]
		[Export ("fontDescriptorWithName:size:")]
		NSFontDescriptor FromNameSize (string fontName, nfloat size);

		[Static]
		[Export ("fontDescriptorWithName:matrix:")]
		NSFontDescriptor FromNameMatrix (string fontName, NSAffineTransform matrix);

		[Export ("initWithFontAttributes:")]
		NativeHandle Constructor ([NullAllowed] NSDictionary attributes);

		[Export ("matchingFontDescriptorsWithMandatoryKeys:")]
		NSFontDescriptor [] MatchingFontDescriptors (NSSet mandatoryKeys);

		[Export ("matchingFontDescriptorWithMandatoryKeys:")]
		NSFontDescriptor MatchingFontDescriptorWithMandatoryKeys (NSSet mandatoryKeys);

		[Export ("fontDescriptorByAddingAttributes:")]
		NSFontDescriptor FontDescriptorByAddingAttributes (NSDictionary attributes);

		[Export ("fontDescriptorWithSymbolicTraits:")]
		NSFontDescriptor FontDescriptorWithSymbolicTraits (NSFontSymbolicTraits symbolicTraits);

		[Export ("fontDescriptorWithSize:")]
		NSFontDescriptor FontDescriptorWithSize (nfloat newPointSize);

		[Export ("fontDescriptorWithMatrix:")]
		NSFontDescriptor FontDescriptorWithMatrix (NSAffineTransform matrix);

		[Export ("fontDescriptorWithFace:")]
		NSFontDescriptor FontDescriptorWithFace (string newFace);

		[Export ("fontDescriptorWithFamily:")]
		NSFontDescriptor FontDescriptorWithFamily (string newFamily);

		[Export ("requiresFontAssetRequest")]
		bool RequiresFontAssetRequest { get; }

#if XAMCORE_5_0
		[Wrap ("Create (design.GetConstant ()!)")]
#else
		[Wrap ("Create (design.GetConstant ()!)", IsVirtual = true)]
#endif
		[return: NullAllowed]
		NSFontDescriptor Create (NSFontDescriptorSystemDesign design);

		[Export ("fontDescriptorWithDesign:")]
		[return: NullAllowed]
		NSFontDescriptor Create (NSString design);

		[Static]
		[Export ("preferredFontDescriptorForTextStyle:options:")]
		NSFontDescriptor GetPreferredFont (string textStyle, NSDictionary options);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSFontManager : NSMenuItemValidation {
		[Static, Export ("setFontPanelFactory:")]
		void SetFontPanelFactory (Class factoryId);

		[Static, Export ("setFontManagerFactory:")]
		void SetFontManagerFactory (Class factoryId);

		[Static, Export ("sharedFontManager")]
		NSFontManager SharedFontManager { get; }

		[Export ("isMultiple")]
		bool IsMultiple { get; }

		[Export ("selectedFont")]
		NSFont SelectedFont { get; }

		[Export ("setSelectedFont:isMultiple:")]
		void SetSelectedFont (NSFont fontObj, bool isMultiple);

		[Export ("setFontMenu:")]
		void SetFontMenu (NSMenu newMenu);

		[Export ("fontMenu:")]
		NSMenu FontMenu (bool create);

		[Export ("fontPanel:")]
		NSFontPanel FontPanel (bool create);

		[Export ("fontWithFamily:traits:weight:size:")]
		NSFont FontWithFamily (string family, NSFontTraitMask traits, nint weight, nfloat size);

		[Export ("traitsOfFont:")]
		NSFontTraitMask TraitsOfFont (NSFont fontObj);

		[Export ("weightOfFont:")]
		nint WeightOfFont (NSFont fontObj);

		[Export ("availableFonts")]
		string [] AvailableFonts { get; }

		[Export ("availableFontFamilies")]
		string [] AvailableFontFamilies { get; }

		[Export ("availableMembersOfFontFamily:")]
		NSArray [] AvailableMembersOfFontFamily (string fam);

		[Export ("convertFont:")]
		NSFont ConvertFont (NSFont fontObj);

		[Export ("convertFont:toSize:")]
		NSFont ConvertFont (NSFont fontObj, nfloat size);

		[Export ("convertFont:toFace:")]
		NSFont ConvertFont (NSFont fontObj, string typeface);

		[Export ("convertFont:toFamily:")]
		NSFont ConvertFontToFamily (NSFont fontObj, string family);

		[Export ("convertFont:toHaveTrait:")]
		NSFont ConvertFont (NSFont fontObj, NSFontTraitMask trait);

		[Export ("convertFont:toNotHaveTrait:")]
		NSFont ConvertFontToNotHaveTrait (NSFont fontObj, NSFontTraitMask trait);

		[Export ("convertWeight:ofFont:")]
		NSFont ConvertWeight (bool increaseWeight, NSFont fontObj);

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("action"), NullAllowed]
		Selector Action { get; set; }

		[Export ("sendAction")]
		bool SendAction { get; }

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Export ("localizedNameForFamily:face:")]
		string LocalizedNameForFamily (string family, string faceKey);

		[Export ("setSelectedAttributes:isMultiple:")]
		void SetSelectedAttributes (NSDictionary attributes, bool isMultiple);

		[Export ("convertAttributes:")]
		NSDictionary ConvertAttributes (NSDictionary attributes);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSFontDescriptor.MatchingFontDescriptors' instead.")]
		[Export ("availableFontNamesMatchingFontDescriptor:")]
		string [] AvailableFontNamesMatchingFontDescriptor (NSFontDescriptor descriptor);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSFontCollection.AllFontCollectionNames' instead.")]
		[Export ("collectionNames")]
		string [] CollectionNames { get; }

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSFontCollection.GetMatchingDescriptors ()' instead.")]
		[Export ("fontDescriptorsInCollection:")]
		NSArray FontDescriptorsInCollection (string collectionNames);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSFontCollection.ShowFontCollection (NSFontCollection, string, NSFontCollectionVisibility, out NSError)' instead.")]
		[Export ("addCollection:options:")]
		bool AddCollection (string collectionName, NSFontCollectionOptions collectionOptions);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'HideFontCollection (string, NSFontCollectionVisibility, out NSError)' instead.")]
		[Export ("removeCollection:")]
		bool RemoveCollection (string collectionName);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSMutableFontCollection.AddQueryForDescriptors' instead.")]
		[Export ("addFontDescriptors:toCollection:")]
		void AddFontDescriptors (NSFontDescriptor [] descriptors, string collectionName);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSMutableFontCollection.RemoveQueryForDescriptors' instead.")]
		[Export ("removeFontDescriptor:fromCollection:")]
		void RemoveFontDescriptor (NSFontDescriptor descriptor, string collection);

		[Export ("currentFontAction")]
		nint CurrentFontAction { get; }

		[Export ("convertFontTraits:")]
		NSFontTraitMask ConvertFontTraits (NSFontTraitMask traits);

		[Export ("target", ArgumentSemantic.Weak), NullAllowed]
		NSObject Target { get; set; }

		[Export ("fontNamed:hasTraits:")]
		bool FontNamedHasTraits (string fName, NSFontTraitMask someTraits);

		[Export ("availableFontNamesWithTraits:")]
		string [] AvailableFontNamesWithTraits (NSFontTraitMask someTraits);

		[Export ("addFontTrait:")]
		void AddFontTrait (NSObject sender);

		[Export ("removeFontTrait:")]
		void RemoveFontTrait (NSObject sender);

		[Export ("modifyFontViaPanel:")]
		void ModifyFontViaPanel (NSObject sender);

		[Export ("modifyFont:")]
		void ModifyFont (NSObject sender);

		[Export ("orderFrontFontPanel:")]
		void OrderFrontFontPanel (NSObject sender);

		[Export ("orderFrontStylesPanel:")]
		void OrderFrontStylesPanel (NSObject sender);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSPanel))]
	interface NSFontPanel {
		[Static]
		[Export ("sharedFontPanel")]
		NSFontPanel SharedFontPanel { get; }

		[Static]
		[Export ("sharedFontPanelExists")]
		bool SharedFontPanelExists { get; }

		[Export ("setPanelFont:isMultiple:")]
		void SetPanelFont (NSFont fontObj, bool isMultiple);

		[Export ("panelConvertFont:")]
		NSFont PanelConvertFont (NSFont fontObj);

		[Export ("worksWhenModal")]
		bool WorksWhenModal { get; }

		[Export ("reloadDefaultFontFamilies")]
		void ReloadDefaultFontFamilies ();

		//Detected properties
		[Export ("accessoryView", ArgumentSemantic.Retain), NullAllowed]
		NSView AccessoryView { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }
	}

	[NoMacCatalyst]
	[Static]
	interface NSFontWeight {
		[Field ("NSFontWeightUltraLight")]
		nfloat UltraLight { get; }

		[Field ("NSFontWeightThin")]
		nfloat Thin { get; }

		[Field ("NSFontWeightLight")]
		nfloat Light { get; }

		[Field ("NSFontWeightRegular")]
		nfloat Regular { get; }

		[Field ("NSFontWeightMedium")]
		nfloat Medium { get; }

		[Field ("NSFontWeightSemibold")]
		nfloat Semibold { get; }

		[Field ("NSFontWeightBold")]
		nfloat Bold { get; }

		[Field ("NSFontWeightHeavy")]
		nfloat Heavy { get; }

		[Field ("NSFontWeightBlack")]
		nfloat Black { get; }
	}

	[NoMacCatalyst]
	[Static]
	interface NSFontWidth {
		[Mac (13, 0)]
		[Field ("NSFontWidthCompressed")]
		double Compressed { get; }

		[Field ("NSFontWidthCondensed")]
		double Condensed { get; }

		[Field ("NSFontWidthStandard")]
		double Standard { get; }

		[Field ("NSFontWidthExpanded")]
		double Expanded { get; }
	}

	[Deprecated (PlatformName.MacOSX, 10, 10)]
	[NoMacCatalyst]
	[BaseType (typeof (NSMatrix))]
	partial interface NSForm {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("initWithFrame:mode:prototype:numberOfRows:numberOfColumns:")]
		NativeHandle Constructor (CGRect frameRect, NSMatrixMode aMode, NSCell aCell, nint rowsHigh, nint colsWide);

		[Export ("initWithFrame:mode:cellClass:numberOfRows:numberOfColumns:")]
		NativeHandle Constructor (CGRect frameRect, NSMatrixMode aMode, Class factoryId, nint rowsHigh, nint colsWide);

		[Export ("indexOfSelectedItem")]
		nint SelectedItemIndex { get; }

		[Export ("setEntryWidth:")]
		void SetEntryWidth (nfloat width);

		[Export ("setInterlineSpacing:")]
		void SetInterlineSpacing (nfloat spacing);

		[Export ("setBordered:")]
		void SetBordered (bool bordered);

		[Export ("setBezeled:")]
		void SetBezeled (bool bezeled);

		[Export ("setTitleAlignment:")]
		void SetTitleAlignment (NSTextAlignment mode);

		[Export ("setTextAlignment:")]
		void SetTextAlignment (NSTextAlignment mode);

		[Export ("setTitleFont:")]
		void SetTitleFont (NSFont fontObj);

		[Export ("setTextFont:")]
		void SetTextFont (NSFont fontObj);

		[Export ("cellAtIndex:")]
		NSObject CellAtIndex (nint index);

		[Export ("drawCellAtIndex:")]
		void DrawCellAtIndex (nint index);

		[Export ("addEntry:")]
		NSFormCell AddEntry (string title);

		[Export ("insertEntry:atIndex:")]
		NSFormCell InsertEntryatIndex (string title, nint index);

		[Export ("removeEntryAtIndex:")]
		void RemoveEntryAtIndex (nint index);

		[Export ("indexOfCellWithTag:")]
		nint IndexOfCellWithTag (nint aTag);

		[Export ("selectTextAtIndex:")]
		void SelectTextAtIndex (nint index);

		[Export ("setFrameSize:")]
		void SetFrameSize (CGSize newSize);

		[Export ("setTitleBaseWritingDirection:")]
		void SetTitleBaseWritingDirection (NSWritingDirection writingDirection);

		[Export ("setTextBaseWritingDirection:")]
		void SetTextBaseWritingDirection (NSWritingDirection writingDirection);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell))]
	partial interface NSFormCell {
		[DesignatedInitializer]
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("isOpaque")]
		bool IsOpaque { get; }

		//Detected properties
		[Export ("titleWidth")]
		nfloat TitleWidth { get; set; }

		[Export ("titleWidth:")]
		nfloat TitleWidthConstraintedToSize (CGSize aSize);

		[Export ("title")]
		string Title { get; set; }

		[Export ("titleFont", ArgumentSemantic.Retain)]
		NSFont TitleFont { get; set; }

		[Export ("titleAlignment")]
		NSTextAlignment TitleAlignment { get; set; }

		[Export ("placeholderString")]
		string PlaceholderString { get; set; }

		[Export ("placeholderAttributedString", ArgumentSemantic.Copy)]
		NSAttributedString PlaceholderAttributedString { get; set; }

		[Export ("titleBaseWritingDirection")]
		NSWritingDirection TitleBaseWritingDirection { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 8, message: "Set Title instead.")]
		[Export ("setTitleWithMnemonic:")]
		void SetTitleWithMnemonic (string stringWithAmpersand);

		[Export ("attributedTitle")]
		NSAttributedString AttributedTitle { get; set; }
	}



	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSGradient : NSSecureCoding, NSCopying {
		[Export ("initWithStartingColor:endingColor:")]
		NativeHandle Constructor (NSColor startingColor, NSColor endingColor);

		[Export ("initWithColors:")]
		NativeHandle Constructor (NSColor [] colorArray);

		// See AppKit/NSGradiant.cs
		//[Export ("initWithColorsAndLocations:")]
		//[Export ("initWithColors:atLocations:colorSpace:")]

		[Export ("drawFromPoint:toPoint:options:")]
		void DrawFromPoint (CGPoint startingPoint, CGPoint endingPoint, NSGradientDrawingOptions options);

		[Export ("drawInRect:angle:")]
		void DrawInRect (CGRect rect, nfloat angle);

		[Export ("drawInBezierPath:angle:")]
		void DrawInBezierPath (NSBezierPath path, nfloat angle);

		[Export ("drawFromCenter:radius:toCenter:radius:options:")]
		void DrawFromCenterRadius (CGPoint startCenter, nfloat startRadius, CGPoint endCenter, nfloat endRadius, NSGradientDrawingOptions options);

		[Export ("drawInRect:relativeCenterPosition:")]
		void DrawInRect (CGRect rect, CGPoint relativeCenterPosition);

		[Export ("drawInBezierPath:relativeCenterPosition:")]
		void DrawInBezierPath (NSBezierPath path, CGPoint relativeCenterPosition);

		[Export ("colorSpace")]
		NSColorSpace ColorSpace { get; }

		[Export ("numberOfColorStops")]
		nint ColorStopsCount { get; }

		[Export ("getColor:location:atIndex:")]
		void GetColor (out NSColor color, out nfloat location, nint index);

		[Export ("interpolatedColorAtLocation:")]
		NSColor GetInterpolatedColor (nfloat location);
	}

	[NoMacCatalyst]
	[ThreadSafe] // CurrentContext returns a context that can be used from the current thread
	[BaseType (typeof (NSObject))]
	interface NSGraphicsContext {
		[Static, Export ("graphicsContextWithAttributes:")]
		NSGraphicsContext FromAttributes (NSDictionary attributes);

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "Add NSView instances to display content in a window.")]
		[Static, Export ("graphicsContextWithWindow:")]
		NSGraphicsContext FromWindow (NSWindow window);

		[Static, Export ("graphicsContextWithBitmapImageRep:")]
		NSGraphicsContext FromBitmap (NSBitmapImageRep bitmapRep);

		[Static, Export ("graphicsContextWithGraphicsPort:flipped:")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'FromCGContext' instead.")]
		NSGraphicsContext FromGraphicsPort (IntPtr graphicsPort, bool initialFlippedState);

		[Static, Export ("currentContext"), NullAllowed]
		NSGraphicsContext CurrentContext { get; set; }

		[Static, Export ("currentContextDrawingToScreen")]
		bool IsCurrentContextDrawingToScreen { get; }

		[Static, Export ("saveGraphicsState")]
		void GlobalSaveGraphicsState ();

		[Static, Export ("restoreGraphicsState")]
		void GlobalRestoreGraphicsState ();

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "This method has no effect.")]
		[Static, Export ("setGraphicsState:")]
		void SetGraphicsState (nint gState);

		[Export ("attributes")]
		NSDictionary Attributes { get; }

		[Export ("isDrawingToScreen")]
		bool IsDrawingToScreen { get; }

		[Export ("saveGraphicsState")]
		void SaveGraphicsState ();

		[Export ("restoreGraphicsState")]
		void RestoreGraphicsState ();

		[Export ("flushGraphics")]
		void FlushGraphics ();

		// keep signature in sync with 'graphicsContextWithGraphicsPort:flipped:'
		[Export ("graphicsPort")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'CGContext' instead.")]
		IntPtr GraphicsPortHandle { get; }

		[Export ("isFlipped")]
		bool IsFlipped { get; }

		[Export ("shouldAntialias")]
		bool ShouldAntialias { get; set; }

		[Export ("imageInterpolation")]
		NSImageInterpolation ImageInterpolation { get; set; }

		[Export ("patternPhase")]
		CGPoint PatternPhase { get; set; }

		[Export ("compositingOperation")]
		NSComposite CompositingOperation { get; set; }

		[Export ("colorRenderingIntent")]
		NSColorRenderingIntent ColorRenderingIntent { get; set; }

		[Export ("CIContext")]
		CoreImage.CIContext CIContext { get; }

		[Export ("CGContext")]
		CGContext CGContext { get; }

		[Static, Export ("graphicsContextWithCGContext:flipped:")]
		NSGraphicsContext FromCGContext (CGContext graphicsPort, bool initialFlippedState);

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSGridView {
		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CGRect frameRect);

		[Static]
		[Export ("gridViewWithNumberOfColumns:rows:")]
		NSGridView Create (nint columnCount, nint rowCount);

#if !NET
		[Static]
		[EditorBrowsable (EditorBrowsableState.Never)]
		[Obsolete ("You should use either 'NSGridView.Create(NSView [][] rowsAndColumns)' or 'NSGridView.Create(NSView [,] rowsAndColumns)'.")]
		[Export ("gridViewWithViews:")]
		NSGridView Create (NSView [] rows);
#endif

		[Static]
		[Export ("gridViewWithViews:")]
		NSGridView Create (NSView [] [] rowsAndColumns);

		[Static]
		[Export ("gridViewWithViews:")]
		NSGridView Create (NSView [,] rowsAndColumns);

		[Export ("numberOfRows")]
		nint RowCount { get; }

		[Export ("numberOfColumns")]
		nint ColumnCount { get; }

		[Export ("rowAtIndex:")]
		NSGridRow GetRow (nint index);

		[Export ("indexOfRow:")]
		nint GetIndex (NSGridRow row);

		[Export ("columnAtIndex:")]
		NSGridColumn GetColumn (nint index);

		[Export ("indexOfColumn:")]
		nint GetIndex (NSGridColumn column);

		[Export ("cellAtColumnIndex:rowIndex:")]
		NSGridCell GetCell (nint columnIndex, nint rowIndex);

		[Export ("cellForView:")]
		[return: NullAllowed]
		NSGridCell GetCell (NSView view);

		[Export ("addRowWithViews:")]
		NSGridRow AddRow (NSView [] views);

		[Export ("insertRowAtIndex:withViews:")]
		NSGridRow InsertRow (nint index, NSView [] views);

		[Export ("moveRowAtIndex:toIndex:")]
		void MoveRow (nint fromIndex, nint toIndex);

		[Export ("removeRowAtIndex:")]
		void RemoveRow (nint index);

		[Export ("addColumnWithViews:")]
		NSGridColumn AddColumn (NSView [] views);

		[Export ("insertColumnAtIndex:withViews:")]
		NSGridColumn InsertColumn (nint index, NSView [] views);

		[Export ("moveColumnAtIndex:toIndex:")]
		void MoveColumn (nint fromIndex, nint toIndex);

		[Export ("removeColumnAtIndex:")]
		void RemoveColumn (nint index);

		[Export ("xPlacement", ArgumentSemantic.Assign)]
		NSGridCellPlacement X { get; set; }

		[Export ("yPlacement", ArgumentSemantic.Assign)]
		NSGridCellPlacement Y { get; set; }

		[Export ("rowAlignment", ArgumentSemantic.Assign)]
		NSGridRowAlignment RowAlignment { get; set; }

		[Export ("rowSpacing")]
		nfloat RowSpacing { get; set; }

		[Export ("columnSpacing")]
		nfloat ColumnSpacing { get; set; }

		[Export ("mergeCellsInHorizontalRange:verticalRange:")]
		void MergeCells (NSRange hRange, NSRange vRange);

		[Field ("NSGridViewSizeForContent")]
		nfloat SizeForContent { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSGridRow : NSCoding {
		[NullAllowed, Export ("gridView", ArgumentSemantic.Weak)]
		NSGridView GridView { get; }

		[Export ("numberOfCells")]
		nint CellCount { get; }

		[Export ("cellAtIndex:")]
		NSGridCell GetCell (nint index);

		[Export ("yPlacement", ArgumentSemantic.Assign)]
		NSGridCellPlacement Y { get; set; }

		[Export ("rowAlignment", ArgumentSemantic.Assign)]
		NSGridRowAlignment RowAlignment { get; set; }

		[Export ("height")]
		nfloat Height { get; set; }

		[Export ("topPadding")]
		nfloat TopPadding { get; set; }

		[Export ("bottomPadding")]
		nfloat BottomPadding { get; set; }

		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

		[Export ("mergeCellsInRange:")]
		void MergeCells (NSRange range);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSGridColumn : NSCoding {
		[NullAllowed, Export ("gridView", ArgumentSemantic.Weak)]
		NSGridView GridView { get; }

		[Export ("numberOfCells")]
		nint CellCount { get; }

		[Export ("cellAtIndex:")]
		NSGridCell GetCell (nint index);

		[Export ("xPlacement", ArgumentSemantic.Assign)]
		NSGridCellPlacement X { get; set; }

		[Export ("width")]
		nfloat Width { get; set; }

		[Export ("leadingPadding")]
		nfloat LeadingPadding { get; set; }

		[Export ("trailingPadding")]
		nfloat TrailingPadding { get; set; }

		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

		[Export ("mergeCellsInRange:")]
		void MergeCells (NSRange range);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSGridCell : NSCoding {
		[Export ("contentView", ArgumentSemantic.Strong), NullAllowed]
		NSView ContentView { get; set; }

		[Export ("emptyContentView", ArgumentSemantic.Strong)]
		[Static]
		NSView EmptyContentView { get; }

		[NullAllowed, Export ("row", ArgumentSemantic.Weak)]
		NSGridRow Row { get; }

		[NullAllowed, Export ("column", ArgumentSemantic.Weak)]
		NSGridColumn Column { get; }

		[Export ("xPlacement", ArgumentSemantic.Assign)]
		NSGridCellPlacement X { get; set; }

		[Export ("yPlacement", ArgumentSemantic.Assign)]
		NSGridCellPlacement Y { get; set; }

		[Export ("rowAlignment", ArgumentSemantic.Assign)]
		NSGridRowAlignment RowAlignment { get; set; }

		[Export ("customPlacementConstraints", ArgumentSemantic.Copy)]
		NSLayoutConstraint [] CustomPlacementConstraints { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSGraphicsContext))]
	[DisableDefaultCtor]
	interface NSPrintPreviewGraphicsContext {
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSImageRep))]
	[DisableDefaultCtor] // An uncaught exception was raised: -[NSEPSImageRep init]: unrecognized selector sent to instance 0x1db2d90
	[Deprecated (PlatformName.MacOSX, 14, 0)]
	interface NSEPSImageRep {
		[Static]
		[Export ("imageRepWithData:")]
		NSObject FromData (NSData epsData);

		[Export ("initWithData:")]
		NativeHandle Constructor (NSData epsData);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("prepareGState")]
		void PrepareGState ();

		[Export ("EPSRepresentation")]
		NSData EPSRepresentation { get; }

		[Export ("boundingBox")]
		CGRect BoundingBox { get; }
	}

	[NoMacCatalyst]
	delegate void GlobalEventHandler (NSEvent theEvent);
	[NoMacCatalyst]
	delegate NSEvent LocalEventHandler (NSEvent theEvent);
	[NoMacCatalyst]
	delegate void NSEventTrackHandler (nfloat gestureAmount, NSEventPhase eventPhase, bool isComplete, ref bool stop);

	

	[Flags]
	[Native]
	[NoMacCatalyst]
	public enum NSEventModifierFlags : ulong {
		CapsLock = 1uL << 16,
		Shift = 1uL << 17,
		Control = 1uL << 18,
		Option = 1uL << 19,
		Command = 1uL << 20,
		NumericPad = 1uL << 21,
		Help = 1uL << 22,
		Function = 1uL << 23,
		DeviceIndependentFlagsMask = 0xffff0000L,
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSGestureRecognizerDelegate) })]
	interface NSGestureRecognizer : NSCoding {
		[DesignatedInitializer]
		[Export ("initWithTarget:action:")]
		NativeHandle Constructor ([NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Export ("target", ArgumentSemantic.Weak), NullAllowed]
		NSObject Target { get; set; }

		[NullAllowed]
		[Export ("action")]
		Selector Action { get; set; }

		[Export ("state")]
		NSGestureRecognizerState State { get; [Advice ("Only subclasses of 'NSGestureRecognizer' can set this property.")] set; }

		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSGestureRecognizerDelegate Delegate { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("view")]
		NSView View { get; }

		[Export ("delaysPrimaryMouseButtonEvents")]
		bool DelaysPrimaryMouseButtonEvents { get; set; }

		[Export ("delaysSecondaryMouseButtonEvents")]
		bool DelaysSecondaryMouseButtonEvents { get; set; }

		[Export ("delaysOtherMouseButtonEvents")]
		bool DelaysOtherMouseButtonEvents { get; set; }

		[Export ("delaysKeyEvents")]
		bool DelaysKeyEvents { get; set; }

		[Export ("delaysMagnificationEvents")]
		bool DelaysMagnificationEvents { get; set; }

		[Export ("delaysRotationEvents")]
		bool DelaysRotationEvents { get; set; }

		[Export ("locationInView:")]
		CGPoint LocationInView ([NullAllowed] NSView view);

		[Export ("reset")]
		void Reset ();

		[Export ("canPreventGestureRecognizer:")]
		bool CanPrevent (NSGestureRecognizer preventedGestureRecognizer);

		[Export ("canBePreventedByGestureRecognizer:")]
		bool CanBePrevented (NSGestureRecognizer preventingGestureRecognizer);

		[Export ("shouldRequireFailureOfGestureRecognizer:")]
		bool ShouldRequireFailureOfGestureRecognizer (NSGestureRecognizer otherGestureRecognizer);

		[Export ("shouldBeRequiredToFailByGestureRecognizer:")]
		bool ShouldBeRequiredToFailByGestureRecognizer (NSGestureRecognizer otherGestureRecognizer);

		[Export ("mouseDown:")]
		void MouseDown (NSEvent mouseEvent);

		[Export ("rightMouseDown:")]
		void RightMouseDown (NSEvent mouseEvent);

		[Export ("otherMouseDown:")]
		void OtherMouseDown (NSEvent mouseEvent);

		[Export ("mouseUp:")]
		void MouseUp (NSEvent mouseEvent);

		[Export ("rightMouseUp:")]
		void RightMouseUp (NSEvent mouseEvent);

		[Export ("otherMouseUp:")]
		void OtherMouseUp (NSEvent mouseEvent);

		[Export ("mouseDragged:")]
		void MouseDragged (NSEvent mouseEvent);

		[Export ("rightMouseDragged:")]
		void RightMouseDragged (NSEvent mouseEvent);

		[Export ("otherMouseDragged:")]
		void OtherMouseDragged (NSEvent mouseEvent);

		[Export ("keyDown:")]
		void KeyDown (NSEvent keyEvent);

		[Export ("keyUp:")]
		void KeyUp (NSEvent keyEvent);

		[Export ("flagsChanged:")]
		void FlagsChanged (NSEvent flagEvent);

		[Export ("tabletPoint:")]
		void TabletPoint (NSEvent tabletEvent);

		[Export ("magnifyWithEvent:")]
		void Magnify (NSEvent magnifyEvent);

		[Export ("rotateWithEvent:")]
		void Rotate (NSEvent rotateEvent);

		[Export ("pressureChangeWithEvent:")]
		void PressureChange (NSEvent pressureChangeEvent);

		[Export ("pressureConfiguration", ArgumentSemantic.Strong)]
		NSPressureConfiguration PressureConfiguration { get; set; }

		[Export ("touchesBeganWithEvent:")]
		void TouchesBegan (NSEvent touchEvent);

		[Export ("touchesMovedWithEvent:")]
		void TouchesMoved (NSEvent touchEvent);

		[Export ("touchesEndedWithEvent:")]
		void TouchesEnded (NSEvent touchEvent);

		[Export ("touchesCancelledWithEvent:")]
		void TouchesCancelled (NSEvent touchEvent);
	}

	interface INSGestureRecognizerDelegate { }

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSGestureRecognizerDelegate {
		[Export ("gestureRecognizerShouldBegin:"), DelegateName ("NSGestureProbe"), DefaultValue (true)]
		bool ShouldBegin (NSGestureRecognizer gestureRecognizer);

		[Export ("gestureRecognizer:shouldRecognizeSimultaneouslyWithGestureRecognizer:"), DelegateName ("NSGesturesProbe"), DefaultValue (false)]
		bool ShouldRecognizeSimultaneously (NSGestureRecognizer gestureRecognizer, NSGestureRecognizer otherGestureRecognizer);

		[Export ("gestureRecognizer:shouldRequireFailureOfGestureRecognizer:"), DelegateName ("NSGesturesProbe"), DefaultValue (false)]
		bool ShouldRequireFailure (NSGestureRecognizer gestureRecognizer, NSGestureRecognizer otherGestureRecognizer);

		[Export ("gestureRecognizer:shouldBeRequiredToFailByGestureRecognizer:"), DelegateName ("NSGesturesProbe"), DefaultValue (false)]
		bool ShouldBeRequiredToFail (NSGestureRecognizer gestureRecognizer, NSGestureRecognizer otherGestureRecognizer);

#if !NET
		[Export ("xamarinselector:removed:"), DelegateName ("NSGestureEvent"), DefaultValue (true)]
		[Obsolete ("It will never be called.")]
		bool ShouldReceiveEvent (NSGestureRecognizer gestureRecognizer, NSEvent gestureEvent);
#endif

		[Export ("gestureRecognizer:shouldAttemptToRecognizeWithEvent:"), DelegateName ("NSGestureEvent"), DefaultValue (true)]
		bool ShouldAttemptToRecognize (NSGestureRecognizer gestureRecognizer, NSEvent theEvent);

		[Export ("gestureRecognizer:shouldReceiveTouch:"), DelegateName ("NSTouchEvent"), DefaultValue (true)]
		bool ShouldReceiveTouch (NSGestureRecognizer gestureRecognizer, NSTouch touch);
	}

	/*[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[ThreadSafe] // Not documented anywhere, but their Finder extension sample uses it on non-ui thread
	partial interface NSMenu : NSCoding, NSCopying, NSAccessibility, NSAccessibilityElement, NSAppearanceCustomization, NSUserInterfaceItemIdentification {
		[DesignatedInitializer]
		[Export ("initWithTitle:")]
		NativeHandle Constructor (string title);

		[Static]
		[Export ("popUpContextMenu:withEvent:forView:")]
		void PopUpContextMenu (NSMenu menu, NSEvent theEvent, NSView view);

		[Static]
		[Export ("popUpContextMenu:withEvent:forView:withFont:")]
		void PopUpContextMenu (NSMenu menu, NSEvent theEvent, NSView view, [NullAllowed] NSFont font);

		[Export ("popUpMenuPositioningItem:atLocation:inView:")]
		bool PopUpMenu ([NullAllowed] NSMenuItem item, CGPoint location, [NullAllowed] NSView view);

		[Export ("insertItem:atIndex:")]
		void InsertItem (NSMenuItem newItem, nint index);

		[Export ("addItem:")]
		void AddItem (NSMenuItem newItem);

		[Export ("insertItemWithTitle:action:keyEquivalent:atIndex:")]
		NSMenuItem InsertItem (string title, [NullAllowed] Selector action, string charCode, nint index);

		[Wrap ("this.InsertItem (title, null, charCode, index)")]
		NSMenuItem InsertItem (string title, string charCode, nint index);

		[Export ("addItemWithTitle:action:keyEquivalent:")]
		NSMenuItem AddItem (string title, [NullAllowed] Selector action, string charCode);

		[Export ("removeItemAtIndex:")]
		void RemoveItemAt (nint index);

		[Export ("removeItem:")]
		void RemoveItem (NSMenuItem item);

		[Export ("setSubmenu:forItem:")]
		void SetSubmenu ([NullAllowed] NSMenu aMenu, NSMenuItem anItem);

		[Export ("removeAllItems")]
		void RemoveAllItems ();

		[Export ("itemArray", ArgumentSemantic.Copy)]
		NSMenuItem [] Items { get; set; }

#if !NET
		[Obsolete ("Use 'Items' instead.")]
		[Wrap ("Items", IsVirtual = true)]
		NSMenuItem [] ItemArray ();
#endif

		[Export ("numberOfItems")]
		nint Count { get; }

		[Export ("itemAtIndex:")]
		[return: NullAllowed]
		NSMenuItem ItemAt (nint index);

		[Export ("indexOfItem:")]
		nint IndexOf (NSMenuItem index);

		[Export ("indexOfItemWithTitle:")]
		nint IndexOf (string aTitle);

		[Export ("indexOfItemWithTag:")]
		nint IndexOf (nint itemTag);

		[Export ("indexOfItemWithRepresentedObject:")]
		nint IndexOfItem ([NullAllowed] NSObject obj);

		[Export ("indexOfItemWithSubmenu:")]
		nint IndexOfItem ([NullAllowed] NSMenu submenu);

		[Export ("indexOfItemWithTarget:andAction:")]
		nint IndexOfItem ([NullAllowed] NSObject target, [NullAllowed] Selector actionSelector);

		[Export ("itemWithTitle:")]
		[return: NullAllowed]
		NSMenuItem ItemWithTitle (string title);

		[Export ("itemWithTag:")]
		[return: NullAllowed]
		NSMenuItem ItemWithTag (nint tag);

		[Export ("update")]
		void Update ();

		[Export ("performKeyEquivalent:")]
		bool PerformKeyEquivalent (NSEvent theEvent);

		[Export ("itemChanged:")]
		void ItemChanged (NSMenuItem item);

		[Export ("performActionForItemAtIndex:")]
		void PerformActionForItem (nint index);

		[Export ("menuBarHeight")]
		nfloat MenuBarHeight { get; }

		[Export ("cancelTracking")]
		void CancelTracking ();

		[Export ("cancelTrackingWithoutAnimation")]
		void CancelTrackingWithoutAnimation ();

		[Export ("highlightedItem")]
		[NullAllowed]
		NSMenuItem HighlightedItem { get; }

		[Export ("size")]
		CGSize Size { get; }

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Static]
		[Export ("menuZone")]
		NSZone MenuZone { get; }

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("helpRequested:")]
		void HelpRequested (NSEvent eventPtr);

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("isTornOff")]
		bool IsTornOff { get; }

		//Detected properties
		[Export ("title")]
		string Title { get; set; }

		[Static]
		[Export ("menuBarVisible")]
		bool MenuBarVisible { get; set; }

		[NullAllowed, Export ("supermenu", ArgumentSemantic.Assign)]
		NSMenu Supermenu { get; set; }

		[Export ("autoenablesItems")]
		bool AutoEnablesItems { get; set; }

		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSMenuDelegate Delegate { get; set; }

		[Export ("minimumWidth")]
		nfloat MinimumWidth { get; set; }

		[Export ("font", ArgumentSemantic.Retain)]
		NSFont Font { get; set; }

		[Export ("allowsContextMenuPlugIns")]
		bool AllowsContextMenuPlugIns { get; set; }

		[Export ("showsStateColumn")]
		bool ShowsStateColumn { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("menuChangedMessagesEnabled")]
		bool MenuChangedMessagesEnabled { get; set; }

		[Export ("propertiesToUpdate")]
		NSMenuProperty PropertiesToUpdate ();

		[Export ("userInterfaceLayoutDirection", ArgumentSemantic.Assign)]
		NSUserInterfaceLayoutDirection UserInterfaceLayoutDirection { get; set; }

		// from @interface NSPaletteMenus (NSMenu)
		[Mac (14, 0)]
		[Static]
		[Export ("paletteMenuWithColors:titles:selectionHandler:")]
		NSMenu CreatePaletteMenu (NSColor [] colors, string [] itemTitles, [NullAllowed] Action<NSMenu> onSelectionChange);

		[Mac (14, 0)]
		[Static]
		[Export ("paletteMenuWithColors:titles:templateImage:selectionHandler:")]
		NSMenu CreatePaletteMenu (NSColor [] colors, string [] itemTitles, NSImage image, [NullAllowed] Action<NSMenu> onSelectionChange);

		[Mac (14, 0)]
		[Export ("presentationStyle", ArgumentSemantic.Assign)]
		NSMenuPresentationStyle PresentationStyle { get; set; }

		[Mac (14, 0)]
		[Export ("selectionMode", ArgumentSemantic.Assign)]
		NSMenuSelectionMode SelectionMode { get; set; }

		[Mac (14, 0)]
		[Export ("selectedItems", ArgumentSemantic.Copy)]
		NSMenuItem [] SelectedItems { get; set; }

		[Mac (15, 2)]
		[Export ("automaticallyInsertsWritingToolsItems")]
		bool AutomaticallyInsertsWritingToolsItems { get; set; }
	}
		*/
	interface INSMenuDelegate { }

	[NoiOS]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSMenuDelegate {
		[Export ("menuNeedsUpdate:")]
		void NeedsUpdate (NSMenu menu);

		[Export ("numberOfItemsInMenu:")]
		nint MenuItemCount (NSMenu menu);

		[Export ("menu:updateItem:atIndex:shouldCancel:")]
		bool UpdateItem (NSMenu menu, NSMenuItem item, nint atIndex, bool shouldCancel);

		[Export ("menuHasKeyEquivalent:forEvent:target:action:")]
		bool HasKeyEquivalentForEvent (NSMenu menu, NSEvent theEvent, NSObject target, Selector action);

		[Export ("menuWillOpen:")]
		void MenuWillOpen (NSMenu menu);

		[Export ("menuDidClose:")]
		void MenuDidClose (NSMenu menu);

#if !NET
		[Abstract]
#endif
		[Export ("menu:willHighlightItem:")]
		void MenuWillHighlightItem (NSMenu menu, NSMenuItem item);

		[Export ("confinementRectForMenu:onScreen:")]
		CGRect ConfinementRectForMenu (NSMenu menu, NSScreen screen);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[ThreadSafe] // Not documented anywhere, but their Finder extension sample uses it on non-ui thread
	interface NSMenuItem : NSCoding, NSCopying, NSAccessibility, NSAccessibilityElement, NSUserInterfaceItemIdentification, NSValidatedUserInterfaceItem {
		[Static]
		[Export ("separatorItem")]
		NSMenuItem SeparatorItem { get; }

		[DesignatedInitializer]
		[Export ("initWithTitle:action:keyEquivalent:")]
		NativeHandle Constructor (string title, [NullAllowed] Selector selectorAction, string charCode);

		[Export ("hasSubmenu")]
		bool HasSubmenu { get; }

		[Export ("parentItem")]
		NSMenuItem ParentItem { get; }

		[Export ("isSeparatorItem")]
		bool IsSeparatorItem { get; }

		[Export ("userKeyEquivalent")]
		string UserKeyEquivalent { get; }

		[Export ("setTitleWithMnemonic:")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'Title' instead.")]
		void SetTitleWithMnemonic (string stringWithAmpersand);

		[Export ("isHighlighted")]
		bool Highlighted { get; }

		[Export ("isHiddenOrHasHiddenAncestor")]
		bool IsHiddenOrHasHiddenAncestor { get; }

		//Detected properties
		[Static]
		[Export ("usesUserKeyEquivalents")]
		bool UsesUserKeyEquivalents { get; set; }

		[Export ("menu")]
		[NullAllowed]
		NSMenu Menu { get; set; }

		[Export ("submenu", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSMenu Submenu { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("attributedTitle", ArgumentSemantic.Copy)]
		NSAttributedString AttributedTitle { get; set; }

		[Export ("keyEquivalent")]
		string KeyEquivalent { get; set; }

		[Export ("keyEquivalentModifierMask")]
		NSEventModifierMask KeyEquivalentModifierMask { get; set; }

		[Export ("image", ArgumentSemantic.Retain), NullAllowed]
		NSImage Image { get; set; }

		[Export ("state")]
		NSCellStateValue State { get; set; }

		[Export ("onStateImage", ArgumentSemantic.Retain)]
		NSImage OnStateImage { get; set; }

		[Export ("offStateImage", ArgumentSemantic.Retain)]
		NSImage OffStateImage { get; set; }

		[Export ("mixedStateImage", ArgumentSemantic.Retain)]
		NSImage MixedStateImage { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("alternate")]
		bool Alternate { [Bind ("isAlternate")] get; set; }

		[Export ("indentationLevel")]
		nint IndentationLevel { get; set; }

#pragma warning disable 0108 // Protocol is read only but must be get/set
		[Export ("action"), NullAllowed]
		Selector Action { get; set; }

		[Export ("tag")]
		nint Tag { get; set; }
#pragma warning restore 0108

		[Export ("target", ArgumentSemantic.Weak), NullAllowed]
		NSObject Target { get; set; }

		[Export ("representedObject", ArgumentSemantic.Retain)]
		NSObject RepresentedObject { get; set; }

		[Export ("view", ArgumentSemantic.Retain)]
		NSView View { get; set; }

		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

		[Export ("toolTip"), NullAllowed]
		string ToolTip { get; set; }

		[Export ("allowsKeyEquivalentWhenHidden")]
		bool AllowsKeyEquivalentWhenHidden { get; set; }

		[Export ("allowsAutomaticKeyEquivalentLocalization")]
		bool AllowsAutomaticKeyEquivalentLocalization { get; set; }

		[Export ("allowsAutomaticKeyEquivalentMirroring")]
		bool AllowsAutomaticKeyEquivalentMirroring { get; set; }

		[Mac (14, 0)]
		[NullAllowed]
		[Export ("badge", ArgumentSemantic.Copy)]
		NSMenuItemBadge Badge { get; set; }

		[Mac (14, 0)]
		[Export ("sectionHeader")]
		bool IsSectionHeader { [Bind ("isSectionHeader")] get; }

		[Mac (14, 0)]
		[Static]
		[Export ("sectionHeaderWithTitle:")]
		NSMenuItem CreateSectionHeader (string title);

		[Mac (14, 4)]
		[Export ("subtitle", ArgumentSemantic.Copy), NullAllowed]
		string Subtitle { get; set; }

		[Static]
		[Mac (15, 2)]
		[Export ("writingToolsItems", ArgumentSemantic.Copy)]
		NSMenuItem [] WritingToolsItems { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSButtonCell))]
	interface NSMenuItemCell {
		[DesignatedInitializer]
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("calcSize")]
		void CalcSize ();

		[Export ("stateImageWidth")]
#if NET
		nfloat StateImageWidth { get; }
#else
		nfloat StateImageWidth ();
#endif

		[Export ("imageWidth")]
		nfloat ImageWidth { get; }

		[Export ("titleWidth")]
		nfloat TitleWidth { get; }

		[Export ("keyEquivalentWidth")]
		nfloat KeyEquivalentWidth { get; }

		[Export ("stateImageRectForBounds:")]
		CGRect StateImageRectForBounds (CGRect cellFrame);

		[Export ("titleRectForBounds:")]
		CGRect TitleRectForBounds (CGRect cellFrame);

		[Export ("keyEquivalentRectForBounds:")]
		CGRect KeyEquivalentRectForBounds (CGRect cellFrame);

		[Export ("drawSeparatorItemWithFrame:inView:")]
		void DrawSeparatorItem (CGRect cellFrame, NSView controlView);

		[Export ("drawStateImageWithFrame:inView:")]
		void DrawStateImage (CGRect cellFrame, NSView controlView);

		[Export ("drawImageWithFrame:inView:")]
		void DrawImage (CGRect cellFrame, NSView controlView);

		[Export ("drawTitleWithFrame:inView:")]
		void DrawTitle (CGRect cellFrame, NSView controlView);

		[Export ("drawKeyEquivalentWithFrame:inView:")]
		void DrawKeyEquivalent (CGRect cellFrame, NSView controlView);

		[Export ("drawBorderAndBackgroundWithFrame:inView:")]
		void DrawBorderAndBackground (CGRect cellFrame, NSView controlView);

		[Export ("tag")]
		nint Tag { get; }

		//Detected properties
		[Export ("menuItem", ArgumentSemantic.Retain)]
		NSMenuItem MenuItem { get; set; }

#if !NET
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "API only available on 32bits platforms.")]
		[Export ("menuView")]
		[NullAllowed]
		NSMenuView MenuView { get; set; }
#endif

		[Export ("needsSizing")]
		bool NeedsSizing { get; set; }

		[Export ("needsDisplay")]
		bool NeedsDisplay { get; set; }

	}

#if !NET
	[Mac (10, 0, 0, PlatformArchitecture.Arch32)] // kept for the arch limitation
	[NoMacCatalyst]
	[Deprecated (PlatformName.MacOSX, 10, 15, message: "API only available on 32bits platforms.")]
	[BaseType (typeof (NSView))]
	interface NSMenuView {
		[Static]
		[Export ("menuBarHeight")]
		nfloat MenuBarHeight { get; }

		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frame);

		// <quote>Deprecated. Tear-off menus are not supported in OS X.</quote>
		//[Export ("initAsTearOff")]
		//NativeHandle Constructor (int tokenInitAsTearOff);

		[Export ("itemChanged:")]
		void ItemChanged (NSNotification notification);

		[Export ("itemAdded:")]
		void ItemAdded (NSNotification notification);

		[Export ("itemRemoved:")]
		void ItemRemoved (NSNotification notification);

		[Export ("update")]
		void Update ();

		[Export ("innerRect")]
		CGRect InnerRect { get; }

		[Export ("rectOfItemAtIndex:")]
		CGRect RectOfItemAtIndex (nint index);

		[Export ("indexOfItemAtPoint:")]
		nint IndexOfItemAtPoint (CGPoint point);

		[Export ("setNeedsDisplayForItemAtIndex:")]
		void SetNeedsDisplay (nint itemAtIndex);

		[Export ("stateImageOffset")]
		nfloat StateImageOffset { get; }

		[Export ("stateImageWidth")]
		nfloat StateImageWidth { get; }

		[Export ("imageAndTitleOffset")]
		nfloat ImageAndTitleOffset { get; }

		[Export ("imageAndTitleWidth")]
		nfloat ImageAndTitleWidth { get; }

		[Export ("keyEquivalentOffset")]
		nfloat KeyEquivalentOffset { get; }

		[Export ("keyEquivalentWidth")]
		nfloat KeyEquivalentWidth { get; }

		[Export ("setMenuItemCell:forItemAtIndex:")]
		void SetMenuItemCell (NSMenuItemCell cell, nint itemAtIndex);

		[Export ("menuItemCellForItemAtIndex:")]
		NSMenuItemCell GetMenuItemCell (nint itemAtIndex);

		[Export ("attachedMenuView")]
		NSMenuView AttachedMenuView { get; }

		[Export ("sizeToFit")]
		void SizeToFit ();

		[Export ("attachedMenu")]
		NSMenu AttachedMenu { get; }

		[Export ("isAttached")]
		bool IsAttached { get; }

		[Export ("isTornOff")]
		bool IsTornOff { get; }

		[Export ("locationForSubmenu:")]
		CGPoint LocationForSubmenu (NSMenu aSubmenu);

		[Export ("setWindowFrameForAttachingToRect:onScreen:preferredEdge:popUpSelectedItem:")]
		void SetWindowFrameForAttachingToRect (CGRect screenRect, NSScreen onScreen, NSRectEdge preferredEdge, nint popupSelectedItem);

		[Export ("detachSubmenu")]
		void DetachSubmenu ();

		[Export ("attachSubmenuForItemAtIndex:")]
		void AttachSubmenuForItemAtIndex (nint index);

		[Export ("performActionWithHighlightingForItemAtIndex:")]
		void PerformActionWithHighlighting (nint forItemAtIndex);

		[Export ("trackWithEvent:")]
		bool TrackWithEvent (NSEvent theEvent);

		//Detected properties
		[Export ("menu")]
		[NullAllowed]
		NSMenu Menu { get; set; }

		[Export ("horizontal")]
		bool Horizontal { [Bind ("isHorizontal")] get; set; }

		[Export ("font")]
		NSFont Font { get; set; }

		[Export ("highlightedItemIndex")]
		nint HighlightedItemIndex { get; set; }

		[Export ("needsSizing")]
		bool NeedsSizing { get; set; }

		[Export ("horizontalEdgePadding")]
		nfloat HorizontalEdgePadding { get; set; }
	}
#endif // !NET

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface NSNib : NSCoding {
		[Export ("initWithContentsOfURL:")]
		[Deprecated (PlatformName.MacOSX, 10, 8)]
		NativeHandle Constructor (NSUrl nibFileUrl);

		[Export ("initWithNibNamed:bundle:")]
		NativeHandle Constructor (string nibName, [NullAllowed] NSBundle bundle);

		[Export ("initWithNibData:bundle:")]
		NativeHandle Constructor (NSData nibData, NSBundle bundle);

		[Deprecated (PlatformName.MacOSX, 10, 8)]
		[Export ("instantiateNibWithExternalNameTable:")]
		bool InstantiateNib (NSDictionary externalNameTable);

		[Export ("instantiateWithOwner:topLevelObjects:")]
		bool InstantiateNibWithOwner ([NullAllowed] NSObject owner, out NSArray topLevelObjects);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSController))]
	interface NSObjectController {
		[DesignatedInitializer]
		[Export ("initWithContent:")]
		NativeHandle Constructor (NSObject content);

		[Export ("content", ArgumentSemantic.Retain)]
		NSObject Content { get; set; }

		[Export ("selection")]
		NSObjectController Selection { get; }

		[Export ("selectedObjects")]
		NSObject [] SelectedObjects { get; [NotImplemented] set; }

		[Export ("automaticallyPreparesContent")]
		bool AutomaticallyPreparesContent { get; set; }

		[Export ("prepareContent")]
		void PrepareContent ();

		[Export ("objectClass")]
		Class ObjectClass { get; set; }

		[Export ("newObject")]
		NSObject NewObject { get; }

		[Export ("addObject:")]
		void AddObject (NSObject object1);

		[Export ("removeObject:")]
		void RemoveObject (NSObject object1);

		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("add:")]
		void Add (NSObject sender);

		[Export ("canAdd")]
		bool CanAdd { get; }

		[Export ("remove:")]
		void Remove (NSObject sender);

		[Export ("canRemove")]
		bool CanRemove { get; }

		[Export ("validateUserInterfaceItem:")]
		bool ValidateUserInterfaceItem (NSObject item);

		//[Export ("managedObjectContext")]
		//NSManagedObjectContext ManagedObjectContext { get; set; }

		[Export ("entityName")]
		string EntityName { get; set; }

		[Export ("fetchPredicate")]
		NSPredicate FetchPredicate { get; set; }

		//[Export ("fetchWithRequest:merge:error:")]
		//bool FetchWithRequestMerge (NSFetchRequest fetchRequest, bool merge, NSError error);

		[Export ("fetch:")]
		void Fetch (NSObject sender);

		[Export ("usesLazyFetching")]
		bool UsesLazyFetching { get; set; }

		//[Export ("defaultFetchRequest")]
		//NSFetchRequest DefaultFetchRequest { get; }
	}

	[ThreadSafe]
	[BaseType (typeof (NSObject))]
	[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'Metal' Framework instead.")]
	[NoMacCatalyst]
	interface NSOpenGLPixelFormat : NSCoding {
		[Export ("initWithData:")]
		NativeHandle Constructor (NSData attribs);

		[Export ("getValues:forAttribute:forVirtualScreen:")]
		void GetValue (ref int /* GLint = int32_t */ vals, NSOpenGLPixelFormatAttribute attrib, int /* GLint = int32_t */ screen);

		[Export ("numberOfVirtualScreens")]
		int NumberOfVirtualScreens { get; } /* GLint = int32_t */

		[Export ("CGLPixelFormatObj")]
		CGLPixelFormat CGLPixelFormat { get; }
	}

	[ThreadSafe]
	[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use 'Metal' Framework instead.")]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSOpenGLPixelBuffer {
		[Export ("initWithTextureTarget:textureInternalFormat:textureMaxMipMapLevel:pixelsWide:pixelsHigh:")]
		NativeHandle Constructor (NSGLTextureTarget targetGlEnum, NSGLFormat format, int /* GLint = int32_t */ maxLevel, int /* GLsizei = int32_t */ pixelsWide, int /* GLsizei = int32_t */ pixelsHigh);

		// FIXME: This conflicts with our internal ctor
		// [Export ("initWithCGLPBufferObj:")]
		// NativeHandle Constructor (IntPtr pbuffer);

		[Export ("CGLPBufferObj")]
		IntPtr CGLPBuffer { get; }

		[Export ("pixelsWide")]
		int PixelsWide { get; } /* GLsizei = int32_t */

		[Export ("pixelsHigh")]
		int PixelsHigh { get; } /* GLsizei = int32_t */

		[Export ("textureTarget")]
		NSGLTextureTarget TextureTarget { get; }

		[Export ("textureInternalFormat")]
		NSGLFormat TextureInternalFormat { get; }

		[Export ("textureMaxMipMapLevel")]
		int TextureMaxMipMapLevel { get; } /* GLint = int32_t */
	}

	[ThreadSafe] // single thread - but not restricted to the main thread
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // warns with "invalid context" at runtime
	[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'Metal' Framework instead.")]
	[NoMacCatalyst]
	interface NSOpenGLContext {
		[Export ("initWithFormat:shareContext:")]
		NativeHandle Constructor (NSOpenGLPixelFormat format, [NullAllowed] NSOpenGLContext shareContext);

		// FIXME: This conflicts with our internal ctor
		// [Export ("initWithCGLContextObj:")]
		// NativeHandle Constructor (IntPtr cglContext);

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("setFullScreen")]
		void SetFullScreen ();

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("setOffScreen:width:height:rowbytes:")]
		void SetOffScreen (IntPtr baseaddr, int /* GLsizei = int32_t */ width, int /* GLsizei = int32_t */ height, int /* GLint = int32_t */ rowbytes);

		[Export ("clearDrawable")]
		void ClearDrawable ();

		[Export ("update")]
		void Update ();

		[Export ("flushBuffer")]
		void FlushBuffer ();

		[ThreadSafe]
		[Export ("makeCurrentContext")]
		void MakeCurrentContext ();

		[Static]
		[Export ("clearCurrentContext")]
		void ClearCurrentContext ();

		[Static]
		[Export ("currentContext")]
		NSOpenGLContext CurrentContext { get; }

		[Deprecated (PlatformName.MacOSX, 10, 8)]
		[Export ("copyAttributesFromContext:withMask:")]
		void CopyAttributes (NSOpenGLContext context, uint /* GLbitfield = uint32_t */ mask);

		[Export ("setValues:forParameter:")]
		void SetValues (IntPtr vals, NSOpenGLContextParameter param);

		[Export ("getValues:forParameter:")]
		void GetValues (IntPtr vals, NSOpenGLContextParameter param);

		[Deprecated (PlatformName.MacOSX, 10, 8)]
		[Export ("createTexture:fromView:internalFormat:")]
		void CreateTexture (int /* GLenum = uint32_t */ targetIdentifier, NSView view, int /* GLenum = uint32_t */ format);

		[Export ("CGLContextObj")]
		CGLContext CGLContext { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("setPixelBuffer:cubeMapFace:mipMapLevel:currentVirtualScreen:")]
		void SetPixelBuffer (NSOpenGLPixelBuffer pixelBuffer, NSGLTextureCubeMap face, int /* GLint = int32_t */ level, int /* GLint = int32_t */ screen);

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("pixelBuffer")]
		NSOpenGLPixelBuffer PixelBuffer { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("pixelBufferCubeMapFace")]
		int PixelBufferCubeMapFace { get; } /* GLenum = uint32_t */

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("pixelBufferMipMapLevel")]
		int PixelBufferMipMapLevel { get; } /* GLint = int32_t */

		// TODO: fixme enumerations
		// GL_FRONT, GL_BACK, GL_AUX0
		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Export ("setTextureImageToPixelBuffer:colorBuffer:")]
		void SetTextureImage (NSOpenGLPixelBuffer pixelBuffer, NSGLColorBuffer source);

		//Detected properties
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'Metal' instead.")]
		[Export ("view")]
		NSView View { get; set; }

		[Export ("currentVirtualScreen")]
		int CurrentVirtualScreen { get; set; } /* GLint = int32_t */

		[Export ("pixelFormat", ArgumentSemantic.Retain)]
		NSOpenGLPixelFormat PixelFormat { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'Metal' Framework instead.")]
	partial interface NSOpenGLView {
		[Static]
		[Export ("defaultPixelFormat")]
		NSOpenGLPixelFormat DefaultPixelFormat { get; }

		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("initWithFrame:pixelFormat:")]
		NativeHandle Constructor (CGRect frameRect, NSOpenGLPixelFormat format);

		[Export ("clearGLContext")]
		void ClearGLContext ();

		[RequiresSuper]
		[Export ("update")]
		void Update ();

		[RequiresSuper]
		[Export ("reshape")]
		void Reshape ();

		[RequiresSuper]
		[Export ("prepareOpenGL")]
		void PrepareOpenGL ();

		//Detected properties
		[Export ("openGLContext", ArgumentSemantic.Retain)]
		NSOpenGLContext OpenGLContext { get; set; }

		[Export ("pixelFormat", ArgumentSemantic.Retain)]
		NSOpenGLPixelFormat PixelFormat { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSSavePanel))]
	[DisableDefaultCtor]
	interface NSOpenPanel {
		[Static]
		[Export ("openPanel")]
		[ForcedType] // different type used inside a sandbox
		NSOpenPanel OpenPanel { get; }

#if !XAMCORE_5_0
		[EditorBrowsable (EditorBrowsableState.Never)]
		[Advice ("You must use 'OpenPanel' method if the application is sandboxed.")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "All open panels now run out-of-process, use 'OpenPanel' method instead")]
		[Export ("init")]
		NativeHandle Constructor ();
#endif

		[Export ("URLs")]
		NSUrl [] Urls { get; }

		//Detected properties
		[Export ("resolvesAliases")]
		bool ResolvesAliases { get; set; }

		[Export ("canChooseDirectories")]
		bool CanChooseDirectories { get; set; }

		[Export ("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; set; }

		[Export ("canChooseFiles")]
		bool CanChooseFiles { get; set; }

		// Deprecated methods, but needed to run on pre 10.6 systems
		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use Urls instead.")]
		[Export ("filenames")]
		string [] Filenames { get; }

		//runModalForWindows:Completeion
		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use NSApplication.RunModal instead.")]
		[Export ("beginSheetForDirectory:file:types:modalForWindow:modalDelegate:didEndSelector:contextInfo:")]
		void BeginSheet ([NullAllowed] string directory, [NullAllowed] string fileName, [NullAllowed] string [] fileTypes, [NullAllowed] NSWindow modalForWindow, [NullAllowed] NSObject modalDelegate, [NullAllowed] Selector didEndSelector, IntPtr contextInfo);

		[Deprecated (PlatformName.MacOSX, 10, 6)]
		[Export ("beginForDirectory:file:types:modelessDelegate:didEndSelector:contextInfo:")]
		void Begin ([NullAllowed] string directory, [NullAllowed] string fileName, [NullAllowed] string [] fileTypes, [NullAllowed] NSObject modelessDelegate, [NullAllowed] Selector didEndSelector, IntPtr contextInfo);

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use NSApplication.RunModal instead.")]
		[Export ("runModalForDirectory:file:types:")]
		nint RunModal ([NullAllowed] string directory, [NullAllowed] string fileName, [NullAllowed] string [] types);

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use NSApplication.RunModal instead.")]
		[Export ("runModalForTypes:")]
		nint RunModal (string [] types);
	}

#if !NET && !__MACCATALYST__
	// This class doesn't show up in any documentation
	[BaseType (typeof (NSOpenPanel))]
	[DisableDefaultCtor] // should not be created by (only returned to) user code
	interface NSRemoteOpenPanel { }
#endif

	interface INSOpenSavePanelDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSOpenSavePanelDelegate {
		[Export ("panel:shouldEnableURL:"), DelegateName ("NSOpenSavePanelUrl"), DefaultValue (true)]
		bool ShouldEnableUrl (NSSavePanel panel, NSUrl url);

		[Export ("panel:validateURL:error:"), DelegateName ("NSOpenSavePanelValidate"), DefaultValue (true)]
		bool ValidateUrl (NSSavePanel panel, NSUrl url, [NullAllowed] out NSError outError);

		[Export ("panel:didChangeToDirectoryURL:"), EventArgs ("NSOpenSavePanelUrl")]
		void DidChangeToDirectory (NSSavePanel panel, NSUrl newDirectoryUrl);

		[Export ("panel:userEnteredFilename:confirmed:"), DelegateName ("NSOpenSaveFilenameConfirmation"), DefaultValueFromArgument ("filename")]
		string UserEnteredFilename (NSSavePanel panel, string filename, bool confirmed);

		[Export ("panel:willExpand:"), EventArgs ("NSOpenSaveExpanding")]
		void WillExpand (NSSavePanel panel, bool expanding);

		[Export ("panelSelectionDidChange:"), EventArgs ("NSOpenSaveSelectionChanged")]
		void SelectionDidChange (NSSavePanel panel);

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use ValidateUrl instead.")]
		[Export ("panel:isValidFilename:"), DelegateName ("NSOpenSaveFilename"), DefaultValue (true)]
		bool IsValidFilename (NSSavePanel panel, string fileName);

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use DidChangeToDirectory instead.")]
		[Export ("panel:directoryDidChange:"), EventArgs ("NSOpenSaveFilename")]
		void DirectoryDidChange (NSSavePanel panel, string path);

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "This method does not control sorting order.")]
		[Export ("panel:compareFilename:with:caseSensitive:"), DelegateName ("NSOpenSaveCompare"), DefaultValue (NSComparisonResult.Same)]
		NSComparisonResult CompareFilenames (NSSavePanel panel, string name1, string name2, bool caseSensitive);

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use ShouldEnableUrl instead.")]
		[Export ("panel:shouldShowFilename:"), DelegateName ("NSOpenSaveFilename"), DefaultValue (true)]
		bool ShouldShowFilename (NSSavePanel panel, string filename);

		[Mac (15, 0)]
		[Export ("panel:displayNameForType:"), DelegateName ("NSopenSavePanelDisplayName"), DefaultValue (null)]
		[return: NullAllowed]
		string GetDisplayName (NSSavePanel panel, UTType type);

		[Mac (15, 0)]
		[Export ("panel:didSelectType:"), EventArgs ("NSopenSavePanelUTType")]
		void DidSelectType (NSSavePanel panel, [NullAllowed] UTType type);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTableView))]
	partial interface NSOutlineView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("outlineTableColumn"), NullAllowed]
		NSTableColumn OutlineTableColumn { get; set; }

		[Export ("isExpandable:")]
		bool IsExpandable ([NullAllowed] NSObject item);

		[Export ("expandItem:expandChildren:")]
		void ExpandItem ([NullAllowed] NSObject item, bool expandChildren);

		[Export ("expandItem:")]
		void ExpandItem ([NullAllowed] NSObject item);

		[Export ("collapseItem:collapseChildren:")]
		void CollapseItem ([NullAllowed] NSObject item, bool collapseChildren);

		[Export ("collapseItem:")]
		void CollapseItem ([NullAllowed] NSObject item);

		[Export ("reloadItem:reloadChildren:")]
		void ReloadItem ([NullAllowed] NSObject item, bool reloadChildren);

		[Export ("reloadItem:")]
		void ReloadItem ([NullAllowed] NSObject item);

		[Export ("parentForItem:")]
		NSObject GetParent ([NullAllowed] NSObject item);

		[Export ("itemAtRow:")]
		NSObject ItemAtRow (nint row);

		[Export ("rowForItem:")]
		nint RowForItem ([NullAllowed] NSObject item);

		[Export ("levelForItem:")]
		nint LevelForItem ([NullAllowed] NSObject item);

		[Export ("levelForRow:")]
		nint LevelForRow (nint row);

		[Export ("isItemExpanded:")]
		bool IsItemExpanded (NSObject item);

		[Export ("indentationPerLevel")]
		nfloat IndentationPerLevel { get; set; }

		[Export ("indentationMarkerFollowsCell")]
		bool IndentationMarkerFollowsCell { get; set; }

		[Export ("autoresizesOutlineColumn")]
		bool AutoresizesOutlineColumn { get; set; }

		[Export ("frameOfOutlineCellAtRow:")]
		CGRect FrameOfOutlineCellAtRow (nint row);

		[Export ("setDropItem:dropChildIndex:")]
		void SetDropItem ([NullAllowed] NSObject item, nint index);

		[Export ("shouldCollapseAutoExpandedItemsForDeposited:")]
		bool ShouldCollapseAutoExpandedItems (bool forDeposited);

		[Export ("autosaveExpandedItems")]
		bool AutosaveExpandedItems { get; set; }

		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSOutlineViewDelegate Delegate { get; set; }

		[Export ("dataSource", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDataSource { get; set; }

		[Wrap ("WeakDataSource")]
		[NullAllowed]
		INSOutlineViewDataSource DataSource { get; set; }

		[Export ("numberOfChildrenOfItem:")]
		nint NumberOfChildren ([NullAllowed] NSObject item);

		[Export ("child:ofItem:")]
		NSObject GetChild (nint index, [NullAllowed] NSObject parentItem);

		[Export ("userInterfaceLayoutDirection")]
		NSUserInterfaceLayoutDirection UserInterfaceLayoutDirection { get; set; }

		[Export ("childIndexForItem:")]
		nint GetChildIndex (NSObject item);

		[Export ("stronglyReferencesItems")]
		bool StronglyReferencesItems { get; set; }
	}

	interface INSOutlineViewDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface NSOutlineViewDelegate {
		[Export ("outlineView:willDisplayCell:forTableColumn:item:")]
		void WillDisplayCell (NSOutlineView outlineView, NSObject cell, [NullAllowed] NSTableColumn tableColumn, NSObject item);

		[Export ("outlineView:shouldEditTableColumn:item:")]
		[DefaultValue (false)]
		bool ShouldEditTableColumn (NSOutlineView outlineView, [NullAllowed] NSTableColumn tableColumn, NSObject item);

		[Export ("selectionShouldChangeInOutlineView:")]
		[DefaultValue (false)]
		bool SelectionShouldChange (NSOutlineView outlineView);

		[Export ("outlineView:shouldSelectItem:")]
		[DefaultValue (true)]
		bool ShouldSelectItem (NSOutlineView outlineView, NSObject item);

		[Export ("outlineView:selectionIndexesForProposedSelection:")]
		NSIndexSet GetSelectionIndexes (NSOutlineView outlineView, NSIndexSet proposedSelectionIndexes);

		[Export ("outlineView:shouldSelectTableColumn:")]
		bool ShouldSelectTableColumn (NSOutlineView outlineView, [NullAllowed] NSTableColumn tableColumn);

		[Export ("outlineView:mouseDownInHeaderOfTableColumn:")]
		void MouseDown (NSOutlineView outlineView, NSTableColumn tableColumn);

		[Export ("outlineView:didClickTableColumn:")]
		void DidClickTableColumn (NSOutlineView outlineView, NSTableColumn tableColumn);

		[Export ("outlineView:didDragTableColumn:")]
		void DidDragTableColumn (NSOutlineView outlineView, NSTableColumn tableColumn);

		[Export ("outlineView:toolTipForCell:rect:tableColumn:item:mouseLocation:")]
		string ToolTipForCell (NSOutlineView outlineView, NSCell cell, ref CGRect rect, [NullAllowed] NSTableColumn tableColumn, NSObject item, CGPoint mouseLocation);

		[Export ("outlineView:heightOfRowByItem:"), NoDefaultValue]
		nfloat GetRowHeight (NSOutlineView outlineView, NSObject item);

		[Export ("outlineView:typeSelectStringForTableColumn:item:")]
		string GetSelectString (NSOutlineView outlineView, [NullAllowed] NSTableColumn tableColumn, NSObject item);

		[Export ("outlineView:nextTypeSelectMatchFromItem:toItem:forString:")]
		NSObject GetNextTypeSelectMatch (NSOutlineView outlineView, NSObject startItem, NSObject endItem, string searchString);

		[Export ("outlineView:shouldTypeSelectForEvent:withCurrentSearchString:")]
		bool ShouldTypeSelect (NSOutlineView outlineView, NSEvent theEvent, [NullAllowed] string searchString);

		[Export ("outlineView:shouldShowCellExpansionForTableColumn:item:")]
		bool ShouldShowCellExpansion (NSOutlineView outlineView, [NullAllowed] NSTableColumn tableColumn, NSObject item);

		[Export ("outlineView:shouldTrackCell:forTableColumn:item:")]
		bool ShouldTrackCell (NSOutlineView outlineView, NSCell cell, [NullAllowed] NSTableColumn tableColumn, NSObject item);

		[Export ("outlineView:dataCellForTableColumn:item:"), NoDefaultValue]
		NSCell GetCell (NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item);

		[Export ("outlineView:viewForTableColumn:item:"), NoDefaultValue]
		NSView GetView (NSOutlineView outlineView, [NullAllowed] NSTableColumn tableColumn, NSObject item);

		[Export ("outlineView:isGroupItem:")]
		bool IsGroupItem (NSOutlineView outlineView, NSObject item);

		[Export ("outlineView:shouldExpandItem:")]
		bool ShouldExpandItem (NSOutlineView outlineView, NSObject item);

		[Export ("outlineView:shouldCollapseItem:")]
		bool ShouldCollapseItem (NSOutlineView outlineView, NSObject item);

		[Export ("outlineView:willDisplayOutlineCell:forTableColumn:item:")]
		void WillDisplayOutlineCell (NSOutlineView outlineView, NSObject cell, [NullAllowed] NSTableColumn tableColumn, NSObject item);

		[Export ("outlineView:sizeToFitWidthOfColumn:"), NoDefaultValue]
		nfloat GetSizeToFitColumnWidth (NSOutlineView outlineView, nint column);

		[Export ("outlineView:shouldReorderColumn:toColumn:")]
		bool ShouldReorder (NSOutlineView outlineView, nint columnIndex, nint newColumnIndex);

		[Export ("outlineView:shouldShowOutlineCellForItem:")]
		bool ShouldShowOutlineCell (NSOutlineView outlineView, NSObject item);

		[Export ("outlineViewColumnDidMove:")]
		void ColumnDidMove (NSNotification notification);

		[Export ("outlineViewColumnDidResize:")]
		void ColumnDidResize (NSNotification notification);

		[Export ("outlineViewSelectionIsChanging:")]
		void SelectionIsChanging (NSNotification notification);

		[Export ("outlineViewItemWillExpand:")]
		void ItemWillExpand (NSNotification notification);

		[Export ("outlineViewItemDidExpand:")]
		void ItemDidExpand (NSNotification notification);

		[Export ("outlineViewItemWillCollapse:")]
		void ItemWillCollapse (NSNotification notification);

		[Export ("outlineViewItemDidCollapse:")]
		void ItemDidCollapse (NSNotification notification);

		[Export ("outlineViewSelectionDidChange:")]
		void SelectionDidChange (NSNotification notification);

		[Export ("outlineView:rowViewForItem:")]
		NSTableRowView RowViewForItem (NSOutlineView outlineView, NSObject item);

		[Export ("outlineView:didAddRowView:forRow:")]
		void DidAddRowView (NSOutlineView outlineView, NSTableRowView rowView, nint row);

		[Export ("outlineView:didRemoveRowView:forRow:")]
		void DidRemoveRowView (NSOutlineView outlineView, NSTableRowView rowView, nint row);

		[Export ("outlineView:tintConfigurationForItem:")]
		[return: NullAllowed]
		NSTintConfiguration GetTintConfiguration (NSOutlineView outlineView, NSObject item);

		[Mac (14, 0)]
		[Export ("outlineView:userCanChangeVisibilityOfTableColumn:"), DelegateName ("NSOutlineViewUserCanChangeColumnVisibility"), DefaultValue (false)]
		bool UserCanChangeVisibility (NSOutlineView outlineView, NSTableColumn column);

		[Mac (14, 0)]
		[Export ("outlineView:userDidChangeVisibilityOfTableColumns:"), EventArgs ("NSOutlineViewUserCanChangeColumnsVisibility")]
		void UserDidChangeVisibility (NSOutlineView outlineView, NSTableColumn [] columns);
	}

	interface INSOutlineViewDataSource { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface NSOutlineViewDataSource {
		[Export ("outlineView:child:ofItem:")]
		NSObject GetChild (NSOutlineView outlineView, nint childIndex, [NullAllowed] NSObject item);

		[Export ("outlineView:isItemExpandable:")]
		bool ItemExpandable (NSOutlineView outlineView, NSObject item);

		[Export ("outlineView:numberOfChildrenOfItem:")]
		nint GetChildrenCount (NSOutlineView outlineView, [NullAllowed] NSObject item);

		[Export ("outlineView:objectValueForTableColumn:byItem:")]
		NSObject GetObjectValue (NSOutlineView outlineView, [NullAllowed] NSTableColumn tableColumn, [NullAllowed] NSObject item);

		[Export ("outlineView:setObjectValue:forTableColumn:byItem:")]
		void SetObjectValue (NSOutlineView outlineView, [NullAllowed] NSObject theObject, [NullAllowed] NSTableColumn tableColumn, [NullAllowed] NSObject item);

		[Export ("outlineView:itemForPersistentObject:")]
		NSObject ItemForPersistentObject (NSOutlineView outlineView, NSObject theObject);

		[Export ("outlineView:persistentObjectForItem:")]
		NSObject PersistentObjectForItem (NSOutlineView outlineView, [NullAllowed] NSObject item);

		[Export ("outlineView:sortDescriptorsDidChange:")]
		void SortDescriptorsChanged (NSOutlineView outlineView, NSSortDescriptor [] oldDescriptors);

		[Export ("outlineView:writeItems:toPasteboard:")]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		bool OutlineViewwriteItemstoPasteboard (NSOutlineView outlineView, NSArray items, NSPasteboard pboard);

		[Export ("outlineView:validateDrop:proposedItem:proposedChildIndex:")]
#if NET
		NSDragOperation ValidateDrop (NSOutlineView outlineView, INSDraggingInfo info, [NullAllowed] NSObject item, nint index);
#else
		NSDragOperation ValidateDrop (NSOutlineView outlineView, NSDraggingInfo info, [NullAllowed] NSObject item, nint index);
#endif

		[Export ("outlineView:acceptDrop:item:childIndex:")]
#if NET
		bool AcceptDrop (NSOutlineView outlineView, INSDraggingInfo info, [NullAllowed] NSObject item, nint index);
#else
		bool AcceptDrop (NSOutlineView outlineView, NSDraggingInfo info, [NullAllowed] NSObject item, nint index);
#endif

		[Export ("outlineView:namesOfPromisedFilesDroppedAtDestination:forDraggedItems:")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSFilePromiseReceiver' objects instead.")]
		string [] FilesDropped (NSOutlineView outlineView, NSUrl dropDestination, NSArray items);
	}

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSHapticFeedbackPerformer {
		[Abstract]
		[Export ("performFeedbackPattern:performanceTime:")]
		void PerformFeedback (NSHapticFeedbackPattern pattern, NSHapticFeedbackPerformanceTime performanceTime);
	}

	interface INSHapticFeedbackPerformer { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSHapticFeedbackManager {
		[Static]
		[Export ("defaultPerformer")]
		INSHapticFeedbackPerformer DefaultPerformer { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface NSHelpManager {
		[Static]
		[Export ("sharedHelpManager")]
		NSHelpManager SharedHelpManager ();

		[Export ("setContextHelp:forObject:")]
		void SetContext (NSAttributedString attrString, NSObject theObject);

		[Export ("removeContextHelpForObject:")]
		void RemoveContext (NSObject theObject);

		[Export ("contextHelpForObject:")]
		NSAttributedString Context (NSObject theObject);

		[Export ("showContextHelpForObject:locationHint:")]
		bool ShowContext (NSObject theObject, CGPoint pt);

		[Export ("openHelpAnchor:inBook:")]
		void OpenHelpAnchor (string anchor, string book);

		[Export ("findString:inBook:")]
		void FindString (string query, string book);

		[Export ("registerBooksInBundle:")]
		bool RegisterBooks (NSBundle bundle);

		//Detected properties
		[Static]
		[Export ("contextHelpModeActive")]
		bool ContextHelpModeActive { [Bind ("isContextHelpModeActive")] get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Delegates = new string [] { "WeakDelegate" }
#if !__MACCATALYST__
		, Events = new Type [] { typeof (NSImageDelegate) }
#endif
	)]
	[ThreadSafe]
	public partial class NSImage : NSCopying, NSPasteboardReading, NSPasteboardWriting {
		[return: NullAllowed]
		[Static]
		[Export ("imageNamed:")]
		public extern NSImage ImageNamed (string name);

		[DesignatedInitializer]
		[Export ("initWithSize:")]
		public extern  NativeHandle Constructor (CGSize aSize);

		[Export ("initWithData:")]
		public extern  NativeHandle Constructor (NSData data);

		[Export ("initWithContentsOfFile:")]
		public extern  NativeHandle Constructor (string fileName);

		[Export ("initWithContentsOfURL:")]
		public extern  NativeHandle Constructor (NSUrl url);

		//[Export ("initByReferencingURL:")]
		//NativeHandle Constructor (NSUrl url);

		[Sealed, Export ("initWithContentsOfFile:"), Internal]
		sealed extern IntPtr InitWithContentsOfFile (string fileName);

		[Export ("initByReferencingFile:"), Internal]
		public extern IntPtr InitByReferencingFile (string name);

		[NoMacCatalyst]
		[Export ("initWithPasteboard:")]
		public extern NativeHandle Constructor (NSPasteboard pasteboard);

		[Export ("initWithData:"), Internal]
		[Sealed]
		public extern IntPtr InitWithData (NSData data);

		[Export ("initWithDataIgnoringOrientation:"), Internal]
		public extern IntPtr InitWithDataIgnoringOrientation (NSData data);

		[NoMacCatalyst]
		[Export ("drawAtPoint:fromRect:operation:fraction:")]
		public extern void Draw (CGPoint point, CGRect fromRect, NSCompositingOperation op, nfloat delta);

		[NoMacCatalyst]
		[Export ("drawInRect:fromRect:operation:fraction:")]
		public extern void Draw (CGRect rect, CGRect fromRect, NSCompositingOperation op, nfloat delta);

		[NoMacCatalyst]
		[Export ("drawInRect:fromRect:operation:fraction:respectFlipped:hints:")]
		public extern void Draw (CGRect dstSpacePortionRect, CGRect srcSpacePortionRect, NSCompositingOperation op, nfloat requestedAlpha, bool respectContextIsFlipped, [NullAllowed] NSDictionary hints);

		[MacCatalyst (13, 1)]
		[Export ("drawInRect:")]
		public extern void Draw (CGRect rect);

		[NoMacCatalyst]
		[Export ("drawRepresentation:inRect:")]
		public extern bool Draw (NSImageRep imageRep, CGRect rect);

		[Export ("recache")]
		public extern void Recache ();

		[return: NullAllowed]
		[Export ("TIFFRepresentation")]
		public extern NSData AsTiff ();

		[NoMacCatalyst]
		[Export ("TIFFRepresentationUsingCompression:factor:")]
		public extern NSData AsTiff (NSTiffCompression comp, float /* float, not CGFloat */ aFloat);

		[NoMacCatalyst]
		[Export ("representations")]
		public extern NSImageRep [] Representations ();

		[NoMacCatalyst]
		[Export ("addRepresentations:")]
		public extern void AddRepresentations (NSImageRep [] imageReps);

		[NoMacCatalyst]
		[Export ("addRepresentation:")]
		public extern void AddRepresentation (NSImageRep imageRep);

		[NoMacCatalyst]
		[Export ("removeRepresentation:")]
		public extern void RemoveRepresentation (NSImageRep imageRep);

		[Export ("isValid")]
		public extern bool IsValid { get; }

		[Obsoleted (PlatformName.MacOSX, 14, 0, message: "'ImageWithSize' should be used instead.")]
		[Obsoleted (PlatformName.MacCatalyst, 17, 0, message: "'ImageWithSize' should be used instead.")]
		[Export ("lockFocus")]
		public extern void LockFocus ();

		[Obsoleted (PlatformName.MacOSX, 14, 0, message: "'ImageWithSize' should be used instead.")]
		[Obsoleted (PlatformName.MacCatalyst, 17, 0, message: "'ImageWithSize' should be used instead.")]
		[Export ("lockFocusFlipped:")]
		public extern void LockFocusFlipped (bool flipped);

		[Obsoleted (PlatformName.MacOSX, 14, 0, message: "'ImageWithSize' should be used instead.")]
		[Obsoleted (PlatformName.MacCatalyst, 17, 0, message: "'ImageWithSize' should be used instead.")]
		[Export ("unlockFocus")]
		public extern void UnlockFocus ();

		[NoMacCatalyst]
		[Export ("bestRepresentationForDevice:")]
		public extern NSImageRep BestRepresentationForDevice ([NullAllowed] NSDictionary deviceDescription);

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageUnfilteredFileTypes")]
		public extern NSObject [] ImageUnfilteredFileTypes ();

		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageUnfilteredPasteboardTypes")]
		public extern string [] ImageUnfilteredPasteboardTypes ();

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageFileTypes")]
		public static extern string [] ImageFileTypes { get; }

		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imagePasteboardTypes")]
		public static extern string [] ImagePasteboardTypes { get; }

		[Static]
		[Export ("imageTypes", ArgumentSemantic.Copy)]
		public static extern string [] ImageTypes { get; }

		[Static]
		[Export ("imageUnfilteredTypes", ArgumentSemantic.Copy)]
		public static extern string [] ImageUnfilteredTypes { get; }

		[NoMacCatalyst]
		[Static]
		[Export ("canInitWithPasteboard:")]
		public static extern bool CanInitWithPasteboard (NSPasteboard pasteboard);

		[Export ("cancelIncrementalLoad")]
		public extern void CancelIncrementalLoad ();

		[NullAllowed]
		[Export ("accessibilityDescription")]
		public extern string AccessibilityDescription { get; set; }

		[Export ("initWithCGImage:size:")]
		public extern NativeHandle Constructor (CGImage cgImage, CGSize size);

		[NoMacCatalyst]
		[Export ("CGImageForProposedRect:context:hints:")]
		public extern CGImage AsCGImage (ref CGRect proposedDestRect, [NullAllowed] NSGraphicsContext referenceContext, [NullAllowed] NSDictionary hints);

		[NoMacCatalyst]
		[Export ("bestRepresentationForRect:context:hints:")]
		public extern NSImageRep BestRepresentation (CGRect rect, [NullAllowed] NSGraphicsContext referenceContext, [NullAllowed] NSDictionary hints);

		[NoMacCatalyst]
		[Export ("hitTestRect:withImageDestinationRect:context:hints:flipped:")]
		public extern bool HitTestRect (CGRect testRectDestSpace, CGRect imageRectDestSpace, NSGraphicsContext context, NSDictionary hints, bool flipped);

		//Detected properties
		[Export ("size")]
		public extern CGSize Size { get; set; }

		[return: NullAllowed]
		[Export ("name"), Internal]
		public extern string GetName ();

		[Export ("setName:"), Internal]
		public extern bool SetName ([NullAllowed] string aString);

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		public extern Color BackgroundColor { get; set; }

		[Export ("usesEPSOnResolutionMismatch")]
		public extern bool UsesEpsOnResolutionMismatch { get; set; }

		[Export ("prefersColorMatch")]
		public extern bool PrefersColorMatch { get; set; }

		[Export ("matchesOnMultipleResolution")]
		public extern bool MatchesOnMultipleResolution { get; set; }

		[Export ("matchesOnlyOnBestFittingAxis")]
		public extern bool MatchesOnlyOnBestFittingAxis { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		[NoMacCatalyst]
		[Wrap ("WeakDelegate")]
		public extern INSImageDelegate Delegate { get; set; }

		[NoMacCatalyst]
		[Export ("cacheMode")]
		public extern NSImageCacheMode CacheMode { get; set; }

		[Export ("alignmentRect")]
		public extern CGRect AlignmentRect { get; set; }

		[Export ("template")]
		public extern bool Template { [Bind ("isTemplate")] get; set; }

#if !NET
		[Obsolete ("Use 'Draw' instead.")]
		[NoMacCatalyst]
		[Export ("drawInRect:fromRect:operation:fraction:")]
		[Sealed]
		public extern void DrawInRect (CGRect dstRect, CGRect srcRect, NSCompositingOperation operation, nfloat delta);
#endif

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use DrawInRect with respectContextIsFlipped instead.")]
		[Export ("flipped")]
		public extern bool Flipped { [Bind ("isFlipped")] get; set; }

		[MacCatalyst (13, 1)]
		[Export ("capInsets")]
		public extern NSEdgeInsets CapInsets { get; set; }

		[NoMacCatalyst]
		[Export ("resizingMode")]
		public extern NSImageResizingMode ResizingMode { get; set; }

		[Export ("recommendedLayerContentsScale:")]
		public extern nfloat GetRecommendedLayerContentsScale (nfloat preferredContentsScale);

		[Export ("layerContentsForContentsScale:")]
		public extern NSObject GetLayerContentsForContentsScale (nfloat layerContentsScale);

		[NoMacCatalyst]
		[Static]
		[Export ("imageWithSystemSymbolName:accessibilityDescription:")]
		[return: NullAllowed]
		public static extern NSImage GetSystemSymbol (string symbolName, [NullAllowed] string accessibilityDescription);

		[NoMacCatalyst]
		[Export ("imageWithSymbolConfiguration:")]
		[return: NullAllowed]
		public extern NSImage GetImage (NSImageSymbolConfiguration configuration);

		[NoMacCatalyst]
		[Export ("symbolConfiguration", ArgumentSemantic.Copy)]
		public extern NSImageSymbolConfiguration SymbolConfiguration { get; }

		[NoMacCatalyst, Mac (13, 0)]
		[Static]
		[Export ("imageWithSymbolName:variableValue:")]
		[return: NullAllowed]
		public static extern NSImage GetImage (string symbolName, double variableValue);

		[NoMacCatalyst, Mac (13, 0)]
		[Static]
		[Export ("imageWithSystemSymbolName:variableValue:accessibilityDescription:")]
		[return: NullAllowed]
		public static extern NSImage GetImage (string systemSymbolName, double variableValue, [NullAllowed] string accessibilityDescription);

		[Mac (14, 0), NoMacCatalyst]
		[Export ("imageWithLocale:")]
		public extern NSImage GetImage ([NullAllowed] NSLocale locale);

		[NullAllowed]
		[Mac (14, 0), NoMacCatalyst]
		[Export ("locale", ArgumentSemantic.Copy)]
		public extern NSLocale Locale { get; }

		[Mac (14, 0), NoMacCatalyst]
		[Static]
		[Export ("imageWithSymbolName:bundle:variableValue:")]
		[return: NullAllowed]
		public static extern NSImage GetImage (string symbolName, [NullAllowed] NSBundle bundle, double variableValue);
	}

	[MacCatalyst (13, 1)]
	public enum NSImageName {
		[Field ("NSImageNameQuickLookTemplate")]
		QuickLookTemplate,

		[Field ("NSImageNameBluetoothTemplate")]
		BluetoothTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameIChatTheaterTemplate")]
		IChatTheaterTemplate,

		[Field ("NSImageNameSlideshowTemplate")]
		SlideshowTemplate,

		[Field ("NSImageNameActionTemplate")]
		ActionTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameSmartBadgeTemplate")]
		SmartBadgeTemplate,

		[Field ("NSImageNamePathTemplate")]
		PathTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameInvalidDataFreestandingTemplate")]
		InvalidDataFreestandingTemplate,

		[Field ("NSImageNameLockLockedTemplate")]
		LockLockedTemplate,

		[Field ("NSImageNameLockUnlockedTemplate")]
		LockUnlockedTemplate,

		[Field ("NSImageNameGoRightTemplate")]
		GoRightTemplate,

		[Field ("NSImageNameGoLeftTemplate")]
		GoLeftTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameRightFacingTriangleTemplate")]
		RightFacingTriangleTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameLeftFacingTriangleTemplate")]
		LeftFacingTriangleTemplate,

		[Field ("NSImageNameAddTemplate")]
		AddTemplate,

		[Field ("NSImageNameRemoveTemplate")]
		RemoveTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameRevealFreestandingTemplate")]
		RevealFreestandingTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameFollowLinkFreestandingTemplate")]
		FollowLinkFreestandingTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameEnterFullScreenTemplate")]
		EnterFullScreenTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameExitFullScreenTemplate")]
		ExitFullScreenTemplate,

		[Field ("NSImageNameStopProgressTemplate")]
		StopProgressTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameStopProgressFreestandingTemplate")]
		StopProgressFreestandingTemplate,

		[Field ("NSImageNameRefreshTemplate")]
		RefreshTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameRefreshFreestandingTemplate")]
		RefreshFreestandingTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameFolder")]
		Folder,

		[NoMacCatalyst]
		[Field ("NSImageNameTrashEmpty")]
		TrashEmpty,

		[NoMacCatalyst]
		[Field ("NSImageNameTrashFull")]
		TrashFull,

		[Field ("NSImageNameHomeTemplate")]
		HomeTemplate,

		[Field ("NSImageNameBookmarksTemplate")]
		BookmarksTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameCaution")]
		Caution,

		[NoMacCatalyst]
		[Field ("NSImageNameStatusAvailable")]
		StatusAvailable,

		[NoMacCatalyst]
		[Field ("NSImageNameStatusPartiallyAvailable")]
		StatusPartiallyAvailable,

		[NoMacCatalyst]
		[Field ("NSImageNameStatusUnavailable")]
		StatusUnavailable,

		[NoMacCatalyst]
		[Field ("NSImageNameStatusNone")]
		StatusNone,

		[NoMacCatalyst]
		[Field ("NSImageNameApplicationIcon")]
		ApplicationIcon,

		[NoMacCatalyst]
		[Field ("NSImageNameMenuOnStateTemplate")]
		MenuOnStateTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameMenuMixedStateTemplate")]
		MenuMixedStateTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameUserGuest")]
		UserGuest,

		[NoMacCatalyst]
		[Field ("NSImageNameMobileMe")]
		MobileMe,

		[Field ("NSImageNameShareTemplate")]
		ShareTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAddDetailTemplate")]
		TouchBarAddDetailTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAddTemplate")]
		TouchBarAddTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAlarmTemplate")]
		TouchBarAlarmTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAudioInputMuteTemplate")]
		TouchBarAudioInputMuteTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAudioInputTemplate")]
		TouchBarAudioInputTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAudioOutputMuteTemplate")]
		TouchBarAudioOutputMuteTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAudioOutputVolumeHighTemplate")]
		TouchBarAudioOutputVolumeHighTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAudioOutputVolumeLowTemplate")]
		TouchBarAudioOutputVolumeLowTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAudioOutputVolumeMediumTemplate")]
		TouchBarAudioOutputVolumeMediumTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarAudioOutputVolumeOffTemplate")]
		TouchBarAudioOutputVolumeOffTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarBookmarksTemplate")]
		TouchBarBookmarksTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarColorPickerFill")]
		TouchBarColorPickerFill,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarColorPickerFont")]
		TouchBarColorPickerFont,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarColorPickerStroke")]
		TouchBarColorPickerStroke,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarCommunicationAudioTemplate")]
		TouchBarCommunicationAudioTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarCommunicationVideoTemplate")]
		TouchBarCommunicationVideoTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarComposeTemplate")]
		TouchBarComposeTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarDeleteTemplate")]
		TouchBarDeleteTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarDownloadTemplate")]
		TouchBarDownloadTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarEnterFullScreenTemplate")]
		TouchBarEnterFullScreenTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarExitFullScreenTemplate")]
		TouchBarExitFullScreenTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarFastForwardTemplate")]
		TouchBarFastForwardTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarFolderCopyToTemplate")]
		TouchBarFolderCopyToTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarFolderMoveToTemplate")]
		TouchBarFolderMoveToTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarFolderTemplate")]
		TouchBarFolderTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarGetInfoTemplate")]
		TouchBarGetInfoTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarGoBackTemplate")]
		TouchBarGoBackTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarGoDownTemplate")]
		TouchBarGoDownTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarGoForwardTemplate")]
		TouchBarGoForwardTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarGoUpTemplate")]
		TouchBarGoUpTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarHistoryTemplate")]
		TouchBarHistoryTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarIconViewTemplate")]
		TouchBarIconViewTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarListViewTemplate")]
		TouchBarListViewTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarMailTemplate")]
		TouchBarMailTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarNewFolderTemplate")]
		TouchBarNewFolderTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarNewMessageTemplate")]
		TouchBarNewMessageTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarOpenInBrowserTemplate")]
		TouchBarOpenInBrowserTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarPauseTemplate")]
		TouchBarPauseTemplate,

		[NoMacCatalyst]
		[Field ("NSImageNameTouchBarPlayheadTemplate")]
		TouchBarPlayheadTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarPlayPauseTemplate")]
		TouchBarPlayPauseTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarPlayTemplate")]
		TouchBarPlayTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarQuickLookTemplate")]
		TouchBarQuickLookTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarRecordStartTemplate")]
		TouchBarRecordStartTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarRecordStopTemplate")]
		TouchBarRecordStopTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarRefreshTemplate")]
		TouchBarRefreshTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarRewindTemplate")]
		TouchBarRewindTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarRotateLeftTemplate")]
		TouchBarRotateLeftTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarRotateRightTemplate")]
		TouchBarRotateRightTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSearchTemplate")]
		TouchBarSearchTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarShareTemplate")]
		TouchBarShareTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSidebarTemplate")]
		TouchBarSidebarTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipAhead15SecondsTemplate")]
		TouchBarSkipAhead15SecondsTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipAhead30SecondsTemplate")]
		TouchBarSkipAhead30SecondsTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipAheadTemplate")]
		TouchBarSkipAheadTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipBack15SecondsTemplate")]
		TouchBarSkipBack15SecondsTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipBack30SecondsTemplate")]
		TouchBarSkipBack30SecondsTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipBackTemplate")]
		TouchBarSkipBackTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipToEndTemplate")]
		TouchBarSkipToEndTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSkipToStartTemplate")]
		TouchBarSkipToStartTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarSlideshowTemplate")]
		TouchBarSlideshowTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTagIconTemplate")]
		TouchBarTagIconTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextBoldTemplate")]
		TouchBarTextBoldTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextBoxTemplate")]
		TouchBarTextBoxTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextCenterAlignTemplate")]
		TouchBarTextCenterAlignTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextItalicTemplate")]
		TouchBarTextItalicTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextJustifiedAlignTemplate")]
		TouchBarTextJustifiedAlignTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextLeftAlignTemplate")]
		TouchBarTextLeftAlignTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextListTemplate")]
		TouchBarTextListTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextRightAlignTemplate")]
		TouchBarTextRightAlignTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextStrikethroughTemplate")]
		TouchBarTextStrikethroughTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarTextUnderlineTemplate")]
		TouchBarTextUnderlineTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarUserAddTemplate")]
		TouchBarUserAddTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarUserGroupTemplate")]
		TouchBarUserGroupTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarUserTemplate")]
		TouchBarUserTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarVolumeDownTemplate")]
		TouchBarVolumeDownTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarVolumeUpTemplate")]
		TouchBarVolumeUpTemplate,

		[MacCatalyst (13, 1)]
		[Field ("NSImageNameTouchBarRemoveTemplate")]
		TouchBarRemoveTemplate,
	}

	public partial class NSStringAttributes {

	}

	[NoMacCatalyst] // Also defined in foundation.cs, use that declaration instead
	[ThreadSafe]
	[BaseType (typeof (NSObject))]
	interface NSStringDrawingContext {
		[Export ("minimumScaleFactor", ArgumentSemantic.Assign)]
		nfloat MinimumScaleFactor { get; set; }

		[Export ("actualScaleFactor")]
		nfloat ActualScaleFactor { get; }

		[Export ("totalBounds")]
		CGRect TotalBounds { get; }
	}

	[NoMacCatalyst] // Also defined in uikit.cs, use that declaration instead
	[ThreadSafe]
	[Category, BaseType (typeof (NSString))]
	interface NSStringDrawing_NSString {
		[Export ("sizeWithAttributes:")]
		CGSize StringSize ([NullAllowed] NSDictionary attributes);

		[Wrap ("This.StringSize (attributes.GetDictionary ()!)")]
		CGSize StringSize ([NullAllowed] AppKit.NSStringAttributes attributes);

		[Export ("drawAtPoint:withAttributes:")]
		void DrawAtPoint (CGPoint point, [NullAllowed] NSDictionary attributes);

		[Wrap ("This.DrawAtPoint (point, attributes.GetDictionary ()!)")]
		void DrawAtPoint (CGPoint point, [NullAllowed] AppKit.NSStringAttributes attributes);

		[Export ("drawInRect:withAttributes:")]
		void DrawInRect (CGRect rect, [NullAllowed] NSDictionary attributes);

		[Wrap ("This.DrawInRect (rect, attributes.GetDictionary ()!)")]
		void DrawInRect (CGRect rect, [NullAllowed] AppKit.NSStringAttributes attributes);
	}

	[ThreadSafe]
	[Category, BaseType (typeof (NSAttributedString))]
	interface NSStringDrawing_NSAttributedString {
		[Export ("size")]
		CGSize GetSize ();

		[Export ("drawAtPoint:")]
		void DrawAtPoint (CGPoint point);

		[Export ("drawInRect:")]
		void DrawInRect (CGRect rect);
	}

	// @interface NSExtendedStringDrawing (NSAttributedString)
	[NoMacCatalyst]
	[ThreadSafe]
	[Category]
	[BaseType (typeof (NSAttributedString))]
	interface NSAttributedString_NSExtendedStringDrawing {
		[Export ("drawWithRect:options:context:")]
		void DrawWithRect (CGRect rect, NSStringDrawingOptions options, [NullAllowed] NSStringDrawingContext context);

		[Export ("boundingRectWithSize:options:context:")]
		CGRect BoundingRectWithSize (CGSize size, NSStringDrawingOptions options, [NullAllowed] NSStringDrawingContext context);
	}

	// Pending: @interface NSAttributedString (NSExtendedStringDrawing)

	[NoMacCatalyst]
	[Category, BaseType (typeof (NSMutableAttributedString))]
	interface NSMutableAttributedStringAppKitAddons {
		[Export ("readFromURL:options:documentAttributes:error:")]
		bool ReadFromURL (NSUrl url, NSDictionary options, out NSDictionary returnOptions, out NSError error);

		[Wrap ("This.ReadFromURL (url, options.GetDictionary ()!, out returnOptions, out error)")]
		bool ReadFromURL (NSUrl url, NSAttributedStringDocumentAttributes options, out NSDictionary returnOptions, out NSError error);

		[Export ("readFromURL:options:documentAttributes:")]
		bool ReadFromURL (NSUrl url, NSDictionary options, out NSDictionary returnOptions);

		[Wrap ("This.ReadFromURL (url, options.GetDictionary ()!, out returnOptions)")]
		bool ReadFromURL (NSUrl url, NSAttributedStringDocumentAttributes options, out NSDictionary returnOptions);

		[Export ("readFromData:options:documentAttributes:error:")]
		bool ReadFromData (NSData data, NSDictionary options, out NSDictionary returnOptions, out NSError error);

		[Wrap ("This.ReadFromData (data, options.GetDictionary ()!, out returnOptions, out error)")]
		bool ReadFromData (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary returnOptions, out NSError error);

		[Export ("readFromData:options:documentAttributes:")]
		bool ReadFromData (NSData data, NSDictionary options, out NSDictionary dict);

		[Wrap ("This.ReadFromData (data, options.GetDictionary ()!, out returnOptions)")]
		bool ReadFromData (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary returnOptions);

		[Export ("superscriptRange:")]
		void SuperscriptRange (NSRange range);

		[Export ("subscriptRange:")]
		void SubscriptRange (NSRange range);

		[Export ("unscriptRange:")]
		void UnscriptRange (NSRange range);

		[Export ("applyFontTraits:range:")]
		void ApplyFontTraits (NSFontTraitMask traitMask, NSRange range);

		[Export ("setAlignment:range:")]
		void SetAlignment (NSTextAlignment alignment, NSRange range);

		[Export ("setBaseWritingDirection:range:")]
		void SetBaseWritingDirection (NSWritingDirection writingDirection, NSRange range);

		[Export ("fixFontAttributeInRange:")]
		void FixFontAttributeInRange (NSRange range);

		[Export ("fixParagraphStyleAttributeInRange:")]
		void FixParagraphStyleAttributeInRange (NSRange range);

		[Export ("fixAttachmentAttributeInRange:")]
		void FixAttachmentAttributeInRange (NSRange range);

		[Export ("updateAttachmentsFromPath:")]
		void UpdateAttachmentsFromPath (string path);
	}

	interface INSImageDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSImageDelegate {
		[Export ("imageDidNotDraw:inRect:"), DelegateName ("NSImageRect"), DefaultValue (null)]
		NSImage ImageDidNotDraw (NSObject sender, CGRect aRect);

		[Export ("image:willLoadRepresentation:"), EventArgs ("NSImageLoad")]
		void WillLoadRepresentation (NSImage image, NSImageRep rep);

		[Export ("image:didLoadRepresentationHeader:"), EventArgs ("NSImageLoad")]
		void DidLoadRepresentationHeader (NSImage image, NSImageRep rep);

		[Export ("image:didLoadPartOfRepresentation:withValidRows:"), EventArgs ("NSImagePartial")]
		void DidLoadPartOfRepresentation (NSImage image, NSImageRep rep, nint rows);

		[Export ("image:didLoadRepresentation:withStatus:"), EventArgs ("NSImageLoadRepresentation")]
		void DidLoadRepresentation (NSImage image, NSImageRep rep, NSImageLoadStatus status);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSCell))]
	interface NSImageCell {
		//Detected properties
		[Export ("imageAlignment")]
		NSImageAlignment ImageAlignment { get; set; }

		[Export ("imageScaling")]
		NSImageScale ImageScaling { get; set; }

		[Export ("imageFrameStyle")]
		NSImageFrameStyle ImageFrameStyle { get; set; }

		// Inlined from parent
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);
	}

	[NoMacCatalyst]
	[Static]
	partial interface NSImageHint {
		[Field ("NSImageHintCTM")]
		NSString Ctm { get; }

		[Field ("NSImageHintInterpolation")]
		NSString Interpolation { get; }

		[Field ("NSImageHintUserInterfaceLayoutDirection")]
		NSString UserInterfaceLayoutDirection { get; }
	}

	[NoMacCatalyst]
	[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	partial interface NSImageRep : NSCoding, NSCopying {
		[Export ("draw")]
		bool Draw ();

		[Export ("drawAtPoint:")]
		bool DrawAtPoint (CGPoint point);

		[Export ("drawInRect:")]
		bool DrawInRect (CGRect rect);

		[Export ("drawInRect:fromRect:operation:fraction:respectFlipped:hints:")]
		bool DrawInRect (CGRect dstSpacePortionRect, CGRect srcSpacePortionRect, NSCompositingOperation op, nfloat requestedAlpha, bool respectContextIsFlipped, [NullAllowed] NSDictionary hints);

		[Export ("setAlpha:")]
		void SetAlpha (bool alpha);

		[Export ("hasAlpha")]
		bool HasAlpha { get; }

		[Static]
		[Export ("registerImageRepClass:")]
		void RegisterImageRepClass (Class imageRepClass);

		[Static]
		[Export ("unregisterImageRepClass:")]
		void UnregisterImageRepClass (Class imageRepClass);

		[Static]
		[Export ("registeredImageRepClasses")]
		Class [] GetRegisteredImageRepClasses ();

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageRepClassForFileType:")]
		Class ImageRepClassForFileType (string type);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageRepClassForPasteboardType:")]
		Class ImageRepClassForPasteboardType (string type);

		[Static]
		[Export ("imageRepClassForType:")]
		Class ImageRepClassForType (string type);

		[Static]
		[Export ("imageRepClassForData:")]
		Class ImageRepClassForData (NSData data);

		[Static]
		[Export ("canInitWithData:")]
		bool CanInitWithData (NSData data);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageUnfilteredFileTypes")]
		string [] ImageUnfilteredFileTypes { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageUnfilteredPasteboardTypes")]
		string [] ImageUnfilteredPasteboardTypes { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imageFileTypes")]
		string [] ImageFileTypes { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Static]
		[Export ("imagePasteboardTypes")]
		string [] ImagePasteboardTypes { get; }

		[Static]
		[Export ("imageUnfilteredTypes", ArgumentSemantic.Copy)]
		string [] ImageUnfilteredTypes { get; }

		[Static]
		[Export ("imageTypes", ArgumentSemantic.Copy)]
		string [] ImageTypes { get; }

		[Static]
		[Export ("canInitWithPasteboard:")]
		bool CanInitWithPasteboard (NSPasteboard pasteboard);

		[Static]
		[Export ("imageRepsWithContentsOfFile:")]
		NSImageRep [] ImageRepsFromFile (string filename);

		[Static]
		[Export ("imageRepWithContentsOfFile:")]
		NSImageRep ImageRepFromFile (string filename);

		[Static]
		[Export ("imageRepsWithContentsOfURL:")]
		NSImageRep [] ImageRepsFromUrl (NSUrl url);

		[Static]
		[Export ("imageRepWithContentsOfURL:")]
		NSImageRep ImageRepFromUrl (NSUrl url);

		[Static]
		[Export ("imageRepsWithPasteboard:")]
		NSImageRep [] ImageRepsFromPasteboard (NSPasteboard pasteboard);

		[Static]
		[Export ("imageRepWithPasteboard:")]
		NSImageRep ImageRepFromPasteboard (NSPasteboard pasteboard);

		[Export ("CGImageForProposedRect:context:hints:")]
		CGImage AsCGImage (ref CGRect proposedDestRect, [NullAllowed] NSGraphicsContext context, [NullAllowed] NSDictionary hints);

		//Detected properties
		[Export ("size")]
		CGSize Size { get; set; }

		[Export ("opaque")]
		bool Opaque { [Bind ("isOpaque")] get; set; }

		[Export ("colorSpaceName")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'Type' and 'NSColorType' instead.")]
		string ColorSpaceName { get; set; }

		[Export ("bitsPerSample")]
		nint BitsPerSample { get; set; }

		[Export ("pixelsWide")]
		nint PixelsWide { get; set; }

		[Export ("pixelsHigh")]
		nint PixelsHigh { get; set; }

		[Export ("layoutDirection", ArgumentSemantic.Assign)]
		NSImageLayoutDirection LayoutDirection { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSImageView : NSAccessibilityImage, NSMenuItemValidation {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		//Detected properties
		[Export ("image", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSImage Image { get; set; }

		[Export ("imageAlignment")]
		NSImageAlignment ImageAlignment { get; set; }

		[Export ("imageScaling")]
		NSImageScale ImageScaling { get; set; }

		[Export ("imageFrameStyle")]
		NSImageFrameStyle ImageFrameStyle { get; set; }

		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("animates")]
		bool Animates { get; set; }

		[Export ("allowsCutCopyPaste")]
		bool AllowsCutCopyPaste { get; set; }

		[Static]
		[Export ("imageViewWithImage:")]
		NSImageView FromImage (NSImage image);

		[NullAllowed, Export ("contentTintColor", ArgumentSemantic.Copy)]
		NSColor ContentTintColor { get; set; }

		[NullAllowed]
		[Export ("symbolConfiguration", ArgumentSemantic.Copy)]
		NSImageSymbolConfiguration SymbolConfiguration { get; set; }

		// from the category NSSymbolEffect (NSImageView)

		[Mac (14, 0)]
		[Export ("addSymbolEffect:")]
		void AddSymbolEffect (NSSymbolEffect symbolEffect);

		[Mac (14, 0)]
		[Export ("addSymbolEffect:options:")]
		void AddSymbolEffect (NSSymbolEffect symbolEffect, NSSymbolEffectOptions options);

		[Mac (14, 0)]
		[Export ("addSymbolEffect:options:animated:")]
		void AddSymbolEffect (NSSymbolEffect symbolEffect, NSSymbolEffectOptions options, bool animated);

		[Mac (14, 0)]
		[Export ("removeSymbolEffectOfType:")]
		void RemoveSymbolEffect (NSSymbolEffect symbolEffect);

		[Mac (14, 0)]
		[Export ("removeSymbolEffectOfType:options:")]
		void RemoveSymbolEffect (NSSymbolEffect symbolEffect, NSSymbolEffectOptions options);

		[Mac (14, 0)]
		[Export ("removeSymbolEffectOfType:options:animated:")]
		void RemoveSymbolEffect (NSSymbolEffect symbolEffect, NSSymbolEffectOptions options, bool animated);

		[Mac (14, 0)]
		[Export ("removeAllSymbolEffects")]
		void RemoveAllSymbolEffects ();

		[Mac (14, 0)]
		[Export ("removeAllSymbolEffectsWithOptions:")]
		void RemoveAllSymbolEffects (NSSymbolEffectOptions options);

		[Mac (14, 0)]
		[Export ("removeAllSymbolEffectsWithOptions:animated:")]
		void RemoveAllSymbolEffects (NSSymbolEffectOptions options, bool animated);

		[Mac (14, 0)]
		[Export ("setSymbolImage:withContentTransition:")]
		void SetSymbolImage (NSImage symbolImage, NSSymbolContentTransition contentTransition);

		[Mac (14, 0)]
		[Export ("setSymbolImage:withContentTransition:options:")]
		void SetSymbolImage (NSImage symbolImage, NSSymbolContentTransition contentTransition, NSSymbolEffectOptions options);

		[Mac (14, 0)]
		[Static]
		[Export ("defaultPreferredImageDynamicRange", ArgumentSemantic.Assign)]
		NSImageDynamicRange DefaultPreferredImageDynamicRange { get; set; }

		[Mac (14, 0)]
		[Export ("preferredImageDynamicRange", ArgumentSemantic.Assign)]
		NSImageDynamicRange PreferredImageDynamicRange { get; set; }

		[Mac (14, 0)]
		[Export ("imageDynamicRange")]
		NSImageDynamicRange ImageDynamicRange { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSMatrixDelegate) })]
	partial interface NSMatrix {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("initWithFrame:mode:prototype:numberOfRows:numberOfColumns:")]
		NativeHandle Constructor (CGRect frameRect, NSMatrixMode aMode, NSCell aCell, nint rowsHigh, nint colsWide);

		[Export ("initWithFrame:mode:cellClass:numberOfRows:numberOfColumns:")]
		NativeHandle Constructor (CGRect frameRect, NSMatrixMode aMode, Class factoryId, nint rowsHigh, nint colsWide);

		[Export ("makeCellAtRow:column:")]
		NSCell MakeCell (nint row, nint col);

		[Export ("sendAction:to:forAllCells:")]
		void SendAction (Selector aSelector, NSObject anObject, bool forAllCells);

		[Export ("cells")]
		NSCell [] Cells { get; }

		[Export ("sortUsingSelector:")]
		void Sort (Selector comparator);

		//[Export ("sortUsingFunction:context:")][Internal]
		// We need to define NSCompareFunc as:
		// (NSInteger (*)(id, id, void *))
		//void Sort (NSCompareFunc func, IntPtr context);

		[Export ("selectedCell")]
		NSCell SelectedCell { get; }

		[Export ("selectedCells")]
		NSCell [] SelectedCells { get; }

		[Export ("selectedRow")]
		nint SelectedRow { get; }

		[Export ("selectedColumn")]
		nint SelectedColumn { get; }

		[Export ("setSelectionFrom:to:anchor:highlight:")]
		void SetSelection (nint startPos, nint endPos, nint anchorPos, bool highlight);

		[Export ("deselectSelectedCell")]
		void DeselectSelectedCell ();

		[Export ("deselectAllCells")]
		void DeselectAllCells ();

		[Export ("selectCellAtRow:column:")]
		void SelectCell (nint row, nint column);

		[Export ("selectAll:")]
		void SelectAll (NSObject sender);

		[Export ("selectCellWithTag:")]
		bool SelectCellWithTag (nint tag);

		[Export ("setScrollable:")]
		void SetScrollable (bool flag);

		[Export ("setState:atRow:column:")]
		void SetState (nint state, nint row, nint column);

		[Export ("getNumberOfRows:columns:")]
		void GetRowsAndColumnsCount (out nint rowCount, out nint colCount);

		[Export ("numberOfRows")]
		nint Rows { get; }

		[Export ("numberOfColumns")]
		nint Columns { get; }

		[Export ("cellAtRow:column:")]
		[Internal]
		NSCell CellAtRowColumn (nint row, nint column);

		[Export ("cellFrameAtRow:column:")]
		CGRect CellFrameAtRowColumn (nint row, nint column);

		[Export ("getRow:column:ofCell:")]
		bool GetRowColumn (out nint row, out nint column, NSCell aCell);

		[Export ("getRow:column:forPoint:")]
		bool GetRowColumnForPoint (out nint row, out nint column, CGPoint aPoint);

		[Export ("renewRows:columns:")]
		void RenewRowsColumns (nint newRows, nint newCols);

		[Export ("putCell:atRow:column:")]
		void PutCell (NSCell newCell, nint row, nint column);

		[Export ("addRow")]
		void AddRow ();

		[Export ("addRowWithCells:")]
		void AddRowWithCells (NSCell [] newCells);

		[Export ("insertRow:")]
		void InsertRow (nint row);

		[Export ("insertRow:withCells:")]
		void InsertRow (nint row, NSCell [] newCells);

		[Export ("removeRow:")]
		void RemoveRow (nint row);

		[Export ("addColumn")]
		void AddColumn ();

		[Export ("addColumnWithCells:")]
		void AddColumnWithCells (NSCell [] newCells);

		[Export ("insertColumn:")]
		void InsertColumn (nint column);

		[Export ("insertColumn:withCells:")]
		void InsertColumn (nint column, NSCell [] newCells);

		[Export ("removeColumn:")]
		void RemoveColumn (nint col);

		[Export ("cellWithTag:")]
		NSCell CellWithTag (nint anInt);

		[Export ("sizeToCells")]
		void SizeToCells ();

		[Export ("setValidateSize:")]
		void SetValidateSize (bool flag);

		[Export ("drawCellAtRow:column:")]
		void DrawCellAtRowColumn (nint row, nint column);

		[Export ("highlightCell:atRow:column:")]
		void HighlightCell (bool highlight, nint row, nint column);

		[Export ("scrollCellToVisibleAtRow:column:")]
		void ScrollCellToVisible (nint row, nint column);

		[Export ("mouseDownFlags")]
		nint MouseDownFlags ();

		[Export ("mouseDown:")]
		void MouseDown (NSEvent theEvent);

		[Export ("performKeyEquivalent:")]
		bool PerformKeyEquivalent (NSEvent theEvent);

		[Export ("sendAction")]
		bool SendAction ();

		[Export ("sendDoubleAction")]
		void SendDoubleAction ();

		[Export ("textShouldBeginEditing:")]
		bool ShouldBeginEditing (NSText textObject);

		[Export ("textShouldEndEditing:")]
		bool ShouldEndEditing (NSText textObject);

		[Export ("textDidBeginEditing:")]
		void DidBeginEditing (NSNotification notification);

		[Export ("textDidEndEditing:")]
		void DidEndEditing (NSNotification notification);

		[Export ("textDidChange:")]
		void Changed (NSNotification notification);

		[Export ("selectText:")]
		void SelectText (NSObject sender);

		[Export ("selectTextAtRow:column:")]
		NSObject SelectTextAtRowColumn (nint row, nint column);

		[Export ("acceptsFirstMouse:")]
		bool AcceptsFirstMouse (NSEvent theEvent);

		[Export ("resetCursorRects")]
		void ResetCursorRects ();

		[Export ("setToolTip:forCell:")]
		void SetToolTipForCell ([NullAllowed] string toolTipString, NSCell cell);

		[Export ("toolTipForCell:")]
		[return: NullAllowed]
		string ToolTipForCell (NSCell cell);

		//Detected properties
		[Export ("cellClass")]
		Class CellClass { get; set; }

		[Export ("prototype", ArgumentSemantic.Copy)]
		NSCell Prototype { get; set; }

		[Export ("mode")]
		NSMatrixMode Mode { get; set; }

		[Export ("allowsEmptySelection")]
		bool AllowsEmptySelection { get; set; }

		[Export ("selectionByRect")]
		bool SelectionByRect { [Bind ("isSelectionByRect")] get; set; }

		[Export ("cellSize")]
		CGSize CellSize { get; set; }

		[Export ("intercellSpacing")]
		CGSize IntercellSpacing { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("cellBackgroundColor", ArgumentSemantic.Copy)]
		NSColor CellBackgroundColor { get; set; }

		[Export ("drawsCellBackground")]
		bool DrawsCellBackground { get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[NullAllowed]
		[Export ("doubleAction")]
		Selector DoubleAction { get; set; }

		[Export ("autosizesCells")]
		bool AutosizesCells { get; set; }

		[Export ("autoscroll")]
		bool Autoscroll { [Bind ("isAutoscroll")] get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSMatrixDelegate Delegate { get; set; }

		//Detected properties
		[Export ("tabKeyTraversesCells")]
		bool TabKeyTraversesCells { get; set; }

		[Export ("keyCell")]
		NSObject KeyCell { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSLevelIndicator {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("warningValue")]
		double WarningValue { get; set; }

		[Export ("criticalValue")]
		double CriticalValue { get; set; }

		[Export ("tickMarkPosition")]
		NSTickMarkPosition TickMarkPosition { get; set; }

		[Export ("numberOfTickMarks")]
		nint TickMarkCount { get; set; }

		[Export ("numberOfMajorTickMarks")]
		nint MajorTickMarkCount { get; set; }

		[Export ("tickMarkValueAtIndex:")]
		double TickMarkValueAt (nint index);

		[Export ("rectOfTickMarkAtIndex:")]
		CGRect RectOfTickMark (nint index);

		[Export ("levelIndicatorStyle")]
		NSLevelIndicatorStyle LevelIndicatorStyle { get; set; }

		[Export ("fillColor", ArgumentSemantic.Copy)]
		NSColor FillColor { get; set; }

		[Export ("warningFillColor", ArgumentSemantic.Copy)]
		NSColor WarningFillColor { get; set; }

		[Export ("criticalFillColor", ArgumentSemantic.Copy)]
		NSColor CriticalFillColor { get; set; }

		[Export ("drawsTieredCapacityLevels")]
		bool DrawsTieredCapacityLevels { get; set; }

		[Export ("placeholderVisibility", ArgumentSemantic.Assign)]
		NSLevelIndicatorPlaceholderVisibility PlaceholderVisibility { get; set; }

		[NullAllowed, Export ("ratingImage", ArgumentSemantic.Strong)]
		NSImage RatingImage { get; set; }

		[NullAllowed, Export ("ratingPlaceholderImage", ArgumentSemantic.Strong)]
		NSImage RatingPlaceholderImage { get; set; }

		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell))]
	interface NSLevelIndicatorCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("initWithLevelIndicatorStyle:")]
		NativeHandle Constructor (NSLevelIndicatorStyle levelIndicatorStyle);

		[Export ("levelIndicatorStyle")]
		NSLevelIndicatorStyle LevelIndicatorStyle { get; set; }

		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("warningValue")]
		double WarningValue { get; set; }

		[Export ("criticalValue")]
		double CriticalValue { get; set; }

		[Export ("tickMarkPosition")]
		NSTickMarkPosition TickMarkPosition { get; set; }

		[Export ("numberOfTickMarks")]
		nint TickMarkCount { get; set; }

		[Export ("numberOfMajorTickMarks")]
		nint MajorTickMarkCount { get; set; }

		[Export ("rectOfTickMarkAtIndex:")]
		CGRect RectOfTickMarkAt (nint index);

		[Export ("tickMarkValueAtIndex:")]
		double TickMarkValueAt (nint index);

		[Export ("setImage:")]
		void SetImage (NSImage image);
	}

	[NoMacCatalyst]
	[Protocol (IsInformal = true)]
	interface NSLayerDelegateContentsScaleUpdating {
		[Export ("layer:shouldInheritContentsScale:fromWindow:")]
		bool ShouldInheritContentsScale (CALayer layer, nfloat newScale, NSWindow fromWindow);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSLayoutGuide : NSCoding, NSUserInterfaceItemIdentification {
		[Export ("frame")]
		CGRect Frame { get; }

		[NullAllowed, Export ("owningView", ArgumentSemantic.Weak)]
		NSView OwningView { get; set; }

		[Export ("leadingAnchor", ArgumentSemantic.Strong)]
		NSLayoutXAxisAnchor LeadingAnchor { get; }

		[Export ("trailingAnchor", ArgumentSemantic.Strong)]
		NSLayoutXAxisAnchor TrailingAnchor { get; }

		[Export ("leftAnchor", ArgumentSemantic.Strong)]
		NSLayoutXAxisAnchor LeftAnchor { get; }

		[Export ("rightAnchor", ArgumentSemantic.Strong)]
		NSLayoutXAxisAnchor RightAnchor { get; }

		[Export ("topAnchor", ArgumentSemantic.Strong)]
		NSLayoutYAxisAnchor TopAnchor { get; }

		[Export ("bottomAnchor", ArgumentSemantic.Strong)]
		NSLayoutYAxisAnchor BottomAnchor { get; }

		[Export ("widthAnchor", ArgumentSemantic.Strong)]
		NSLayoutDimension WidthAnchor { get; }

		[Export ("heightAnchor", ArgumentSemantic.Strong)]
		NSLayoutDimension HeightAnchor { get; }

		[Export ("centerXAnchor", ArgumentSemantic.Strong)]
		NSLayoutXAxisAnchor CenterXAnchor { get; }

		[Export ("centerYAnchor", ArgumentSemantic.Strong)]
		NSLayoutYAxisAnchor CenterYAnchor { get; }

		[Export ("hasAmbiguousLayout")]
		bool HasAmbiguousLayout { get; }

		[Export ("constraintsAffectingLayoutForOrientation:")]
		NSLayoutConstraint [] GetConstraintsAffectingLayout (NSLayoutConstraintOrientation orientation);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSGestureRecognizer))]
	interface NSMagnificationGestureRecognizer {
		[Export ("initWithTarget:action:")]
		NativeHandle Constructor (NSObject target, Selector action);

		[Export ("magnification")]
		nfloat Magnification { get; set; }
	}

	interface INSMatrixDelegate { }

	[NoMacCatalyst]
	[Model]
	[BaseType (typeof (NSObject))]
	[Protocol]
	interface NSMatrixDelegate : NSControlTextEditingDelegate {
	}

	[NoMacCatalyst]
	[Model]
	[BaseType (typeof (NSObject))]
	[Protocol]
	interface NSControlTextEditingDelegate {
		[Export ("control:textShouldBeginEditing:"), DelegateName ("NSControlText"), DefaultValue (true)]
		bool TextShouldBeginEditing (NSControl control, NSText fieldEditor);

		[Export ("control:textShouldEndEditing:"), DelegateName ("NSControlText"), DefaultValue (true)]
		bool TextShouldEndEditing (NSControl control, NSText fieldEditor);

		[Export ("control:didFailToFormatString:errorDescription:"), DelegateName ("NSControlTextError"), DefaultValue (true)]
		bool DidFailToFormatString (NSControl control, string str, string error);

		[Export ("control:didFailToValidatePartialString:errorDescription:"), EventArgs ("NSControlTextError")]
		void DidFailToValidatePartialString (NSControl control, string str, string error);

		[Export ("control:isValidObject:"), DelegateName ("NSControlTextValidation"), DefaultValue (true)]
		bool IsValidObject (NSControl control, NSObject objectToValidate);

		[Export ("control:textView:doCommandBySelector:"), DelegateName ("NSControlCommand"), DefaultValue (false)]
		bool DoCommandBySelector (NSControl control, NSTextView textView, Selector commandSelector);

		[Export ("control:textView:completions:forPartialWordRange:indexOfSelectedItem:"), DelegateName ("NSControlTextCompletion"), DefaultValue (null)]
		string [] GetCompletions (NSControl control, NSTextView textView, string [] words, NSRange charRange, ref nint index);

		[Export ("controlTextDidBeginEditing:")]
		void ControlTextDidBeginEditing (NSNotification obj);

		[Export ("controlTextDidEndEditing:")]
		void ControlTextDidEndEditing (NSNotification obj);

		[Export ("controlTextDidChange:")]
		void ControlTextDidChange (NSNotification obj);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPageLayout {
		[Static]
		[Export ("pageLayout")]
		NSPageLayout PageLayout { get; }

		[Export ("addAccessoryController:")]
		void AddAccessoryController (NSViewController accessoryController);

		[Export ("removeAccessoryController:")]
		void RemoveAccessoryController (NSViewController accessoryController);

		[Export ("accessoryControllers")]
		NSViewController [] AccessoryControllers ();

		[Deprecated (PlatformName.MacOSX, 14, 0)]
		[Export ("beginSheetWithPrintInfo:modalForWindow:delegate:didEndSelector:contextInfo:")]
		void BeginSheet (NSPrintInfo printInfo, NSWindow docWindow, [NullAllowed] NSObject del, [NullAllowed] Selector didEndSelector, IntPtr contextInfo);

		[Export ("runModalWithPrintInfo:")]
		nint RunModalWithPrintInfo (NSPrintInfo printInfo);

		[Export ("runModal")]
		nint RunModal ();

		[Export ("printInfo")]
		NSPrintInfo PrintInfo { get; }

		[Async]
		[Mac (14, 0)]
		[Export ("beginSheetUsingPrintInfo:onWindow:completionHandler:")]
		void BeginSheet (NSPrintInfo printInfo, NSWindow parentWindow, [NullAllowed] Action<NSPageLayoutResult> handler);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSWindow))]
	interface NSPanel {
		//Detected properties
		[Export ("floatingPanel")]
		bool FloatingPanel { [Bind ("isFloatingPanel")] get; set; }

		[Export ("becomesKeyOnlyIfNeeded")]
		bool BecomesKeyOnlyIfNeeded { get; set; }

		[Export ("worksWhenModal")]
		bool WorksWhenModal { get; set; }

		[Export ("initWithContentRect:styleMask:backing:defer:")]
		NativeHandle Constructor (CGRect contentRect, NSWindowStyle aStyle, NSBackingStore bufferingType, bool deferCreation);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSGestureRecognizer))]
	interface NSPanGestureRecognizer : NSCoding {
		[Export ("initWithTarget:action:")]
		NativeHandle Constructor (NSObject target, Selector action);

		[Export ("buttonMask")]
		nuint ButtonMask { get; set; }

		[Export ("translationInView:")]
		CGPoint TranslationInView (NSView view);

		[Export ("setTranslation:inView:")]
		void SetTranslation (CGPoint translation, NSView view);

		[Export ("velocityInView:")]
		CGPoint VelocityInView (NSView view);

		[Export ("numberOfTouchesRequired")]
		nint NumberOfTouchesRequired { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSGestureRecognizer))]
	interface NSPressGestureRecognizer {
		[Export ("initWithTarget:action:")]
		NativeHandle Constructor (NSObject target, Selector action);

		[Export ("buttonMask")]
		nuint ButtonMask { get; set; }

		[Export ("minimumPressDuration")]
		double MinimumPressDuration { get; set; }

		[Export ("allowableMovement")]
		nfloat AllowableMovement { get; set; }

		[Export ("numberOfTouchesRequired")]
		nint NumberOfTouchesRequired { get; set; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSPasteboardTypeOwner {
		[Abstract]
		[Export ("pasteboard:provideDataForType:")]
		void ProvideData (NSPasteboard sender, string type);

		[Export ("pasteboardChangedOwner:")]
		void PasteboardChangedOwner (NSPasteboard sender);
	}

	/*
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // An uncaught exception was raised: +[NSPasteboard alloc]: unrecognized selector sent to class 0xac3dcbf0
	partial interface NSPasteboard // NSPasteboard does _not_ implement NSPasteboardReading/NSPasteboardWriting
	{
		[Static]
		[Export ("generalPasteboard")]
		NSPasteboard GeneralPasteboard { get; }

		[Static]
		[Export ("pasteboardWithName:")]
		NSPasteboard FromName (string name);

		[Static]
		[Export ("pasteboardWithUniqueName")]
		NSPasteboard CreateWithUniqueName ();

		[Export ("name")]
		string Name { get; }

		[Export ("changeCount")]
		nint ChangeCount { get; }

		[Export ("releaseGlobally")]
		void ReleaseGlobally ();

		[Export ("clearContents")]
		nint ClearContents ();

		// We have to support the backwards WriteObjects (NSPasteboardReading [] objects) so we just pass the handle.
		[Export ("writeObjects:")]
		[Internal]
		bool WriteObjects (IntPtr objects);

		[Export ("readObjectsForClasses:options:")]
		NSObject [] ReadObjectsForClasses (Class [] classArray, [NullAllowed] NSDictionary options);

		[Export ("pasteboardItems")]
		NSPasteboardItem [] PasteboardItems { get; }

		[Export ("indexOfPasteboardItem:")]
		nint IndexOf (NSPasteboardItem pasteboardItem);

		[Export ("canReadItemWithDataConformingToTypes:")]
		bool CanReadItemWithDataConformingToTypes (string [] utiTypes);

		[Export ("canReadObjectForClasses:options:")]
		bool CanReadObjectForClasses (Class [] classArray, [NullAllowed] NSDictionary options);

		[Export ("declareTypes:owner:")]
		nint DeclareTypes (string [] newTypes, [NullAllowed] NSObject newOwner);

		[Export ("addTypes:owner:")]
		nint AddTypes (string [] newTypes, [NullAllowed] NSObject newOwner);

		[Export ("types")]
		string [] Types { get; }

		[Export ("availableTypeFromArray:")]
		string GetAvailableTypeFromArray (string [] types);

		[Export ("setData:forType:")]
		bool SetDataForType (NSData data, string dataType);

		[Export ("setPropertyList:forType:")]
		bool SetPropertyListForType (NSObject plist, string dataType);

		[Export ("setString:forType:")]
		bool SetStringForType (string str, string dataType);

		[Export ("dataForType:")]
		NSData GetDataForType (string dataType);

		[Export ("propertyListForType:")]
		NSObject GetPropertyListForType (string dataType);

		[Export ("stringForType:")]
		string GetStringForType (string dataType);

#if !XAMCORE_5_0
		// Pasteboard data types

		[Field ("NSStringPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeString' instead.")]
		NSString NSStringType { get; }

		[Field ("NSFilenamesPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Create multiple items with 'NSPasteboardTypeFileUrl' or 'MobileCoreServices.UTType.FileURL' instead.")]
		NSString NSFilenamesType { get; }

		[Field ("NSPostScriptPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'com.adobe.encapsulated-postscript' instead.")]
		NSString NSPostScriptType { get; }

		[Field ("NSTIFFPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeTIFF' instead.")]
		NSString NSTiffType { get; }

		[Field ("NSRTFPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeRTF' instead.")]
		NSString NSRtfType { get; }

		[Field ("NSTabularTextPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeTabularText' instead.")]
		NSString NSTabularTextType { get; }

		[Field ("NSFontPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeFont' instead.")]
		NSString NSFontType { get; }

		[Field ("NSRulerPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeRuler' instead.")]
		NSString NSRulerType { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSFileContentsPboardType")]
		NSString NSFileContentsType { get; }

		[Field ("NSColorPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeColor' instead.")]
		NSString NSColorType { get; }

		[Field ("NSRTFDPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeRTFD' instead.")]
		NSString NSRtfdType { get; }

		[Field ("NSHTMLPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeHTML' instead.")]
		NSString NSHtmlType { get; }

		[Field ("NSPICTPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 6 , message: "Do not use, the PICT format was discontinued a long time ago.")]
		NSString NSPictType { get; }

		[Field ("NSURLPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeUrl' instead.")]
		NSString NSUrlType { get; }

		[Field ("NSPDFPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypePDF' instead.")]
		NSString NSPdfType { get; }

		[Field ("NSVCardPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'MobileCoreServices.UTType.VCard' instead.")]
		NSString NSVCardType { get; }

		[Field ("NSFilesPromisePboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'com.apple.pasteboard.promised-file-url' instead.")]
		NSString NSFilesPromiseType { get; }

		[Field ("NSMultipleTextSelectionPboardType")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeMultipleTextSelection' instead.")]
		NSString NSMultipleTextSelectionType { get; }

		// Pasteboard names: for NSPasteboard.FromName()

		[Field ("NSGeneralPboard")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSPasteboardNameGeneral' instead.")]
		NSString NSGeneralPasteboardName { get; }

		[Field ("NSFontPboard")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSPasteboardNameFont' instead.")]
		NSString NSFontPasteboardName { get; }

		[Field ("NSRulerPboard")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSPasteboardNameRuler' instead.")]
		NSString NSRulerPasteboardName { get; }

		[Field ("NSFindPboard")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSPasteboardNameFind' instead.")]
		NSString NSFindPasteboardName { get; }

		[Field ("NSDragPboard")]
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSPasteboardNameDrag' instead.")]
		NSString NSDragPasteboardName { get; }

		[Obsolete ("Use the 'NSPasteboardName' enum instead.")]
		[Field ("NSPasteboardNameGeneral")]
		NSString NSPasteboardNameGeneral { get; }

		[Obsolete ("Use the 'NSPasteboardName' enum instead.")]
		[Field ("NSPasteboardNameFont")]
		NSString NSPasteboardNameFont { get; }

		[Obsolete ("Use the 'NSPasteboardName' enum instead.")]
		[Field ("NSPasteboardNameRuler")]
		NSString NSPasteboardNameRuler { get; }

		[Obsolete ("Use the 'NSPasteboardName' enum instead.")]
		[Field ("NSPasteboardNameFind")]
		NSString NSPasteboardNameFind { get; }

		[Obsolete ("Use the 'NSPasteboardName' enum instead.")]
		[Field ("NSPasteboardNameDrag")]
		NSString NSPasteboardNameDrag { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeString")]
		NSString NSPasteboardTypeString { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypePDF")]
		NSString NSPasteboardTypePDF { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeTIFF")]
		NSString NSPasteboardTypeTIFF { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypePNG")]
		NSString NSPasteboardTypePNG { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeRTF")]
		NSString NSPasteboardTypeRTF { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeRTFD")]
		NSString NSPasteboardTypeRTFD { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeHTML")]
		NSString NSPasteboardTypeHTML { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeTabularText")]
		NSString NSPasteboardTypeTabularText { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeFont")]
		NSString NSPasteboardTypeFont { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeRuler")]
		NSString NSPasteboardTypeRuler { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeColor")]
		NSString NSPasteboardTypeColor { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeSound")]
		NSString NSPasteboardTypeSound { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeMultipleTextSelection")]
		NSString NSPasteboardTypeMultipleTextSelection { get; }

		[Field ("NSPasteboardTypeFindPanelSearchOptions")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'NSPasteboardTypeTextFinderOptions' instead.")]
		NSString NSPasteboardTypeFindPanelSearchOptions { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeTextFinderOptions")]
		NSString PasteboardTypeTextFinderOptions { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeURL")]
		NSString NSPasteboardTypeUrl { get; }

		[Obsolete ("Use the 'NSPasteboardType' enum instead.")]
		[Field ("NSPasteboardTypeFileURL")]
		NSString NSPasteboardTypeFileUrl { get; }
#endif // !XAMCORE_5_0

		[Export ("prepareForNewContentsWithOptions:")]
		nint PrepareForNewContents (NSPasteboardContentsOptions options);
	}
	*/

	[NoMacCatalyst]
	enum NSPasteboardName {
		[Field ("NSPasteboardNameGeneral")]
		General,

		[Field ("NSPasteboardNameFont")]
		Font,

		[Field ("NSPasteboardNameRuler")]
		Ruler,

		[Field ("NSPasteboardNameFind")]
		Find,

		[Field ("NSPasteboardNameDrag")]
		Drag,
	}

	[NoMacCatalyst]
	enum NSPasteboardType {
		[Field ("NSFileContentsPboardType")]
		FileContents,

		[Field ("NSPasteboardTypeString")]
		String,

		[Field ("NSPasteboardTypePDF")]
		Pdf,

		[Field ("NSPasteboardTypeTIFF")]
		Tiff,

		[Field ("NSPasteboardTypePNG")]
		Png,

		[Field ("NSPasteboardTypeRTF")]
		Rtf,

		[Field ("NSPasteboardTypeRTFD")]
		Rtfd,

		[Field ("NSPasteboardTypeHTML")]
		Html,

		[Field ("NSPasteboardTypeTabularText")]
		TabularText,

		[Field ("NSPasteboardTypeFont")]
		Font,

		[Field ("NSPasteboardTypeRuler")]
		Ruler,

		[Field ("NSPasteboardTypeColor")]
		Color,

		[Field ("NSPasteboardTypeSound")]
		Sound,

		[Field ("NSPasteboardTypeMultipleTextSelection")]
		MultipleTextSelection,

		[Field ("NSPasteboardTypeTextFinderOptions")]
		TextFinderOptions,

		[Field ("NSPasteboardTypeURL")]
		Url,

		[Field ("NSPasteboardTypeFileURL")]
		FileUrl,

		[Mac (13, 0)]
		[Field ("NSPasteboardTypeCollaborationMetadata", "SharedWithYou")]
		CollaborationMetadata,

		[Field ("NSFindPanelSearchOptionsPboardType")]
		FindPanelSearchOptions,

		// Deprecated with replacement in all macOS versions we support, so we're not binding them:
		// NSFilenamesPboardType
		// NSFontPboardType
		// NSColorPboardType
		// NSHTMLPboardType
		// NSMultipleTextSelectionPboardType
		// NSPDFPboardType
		// NSPICTPboardType (no replacement, just don't use)
		// NSRTFDPboardType
		// NSRTFDPboardType
		// NSRulerPboardType
		// NSStringPboardType
		// NSTIFFPboardType
		// NSTabularTextPboardType
		// NSURLPboardType
		// NSPasteboardTypeFindPanelSearchOptions
		// NSFilesPromisePboardType
		// NSInkTextPboardType
		// NSPostScriptPboardType
		// NSVCardPboardType
		// NSGetFileType
		// NSRTFPboardType
	}

	[NoMacCatalyst]
	enum NSPasteboardTypeTextFinderOptionKey {
		[Field ("NSTextFinderCaseInsensitiveKey")]
		CaseInsensitiveKey,

		[Field ("NSTextFinderMatchingTypeKey")]
		MatchingTypeKey,
	}

	[NoMacCatalyst]
	enum NSPasteboardTypeFindPanelSearchOptionKey {
		[Field ("NSFindPanelCaseInsensitiveSearch")]
		CaseInsensitiveSearch,

		[Field ("NSFindPanelSubstringMatch")]
		SubstringMatch,
	}

	[NoiOS]
	[NoTV]
	[NoMacCatalyst]
#if !NET
	// A class that implements only NSPasteboardWriting does not make sense, it's
	// used to add pasteboard support to existing classes.
	[BaseType (typeof (NSObject))]
	[Model]
#endif
	[Protocol]
	interface NSPasteboardWriting {
#if NET
		[Abstract]
#endif
		[Export ("writableTypesForPasteboard:")]
		string [] GetWritableTypesForPasteboard (NSPasteboard pasteboard);

		[Export ("writingOptionsForType:pasteboard:")]
		NSPasteboardWritingOptions GetWritingOptionsForType (string type, NSPasteboard pasteboard);

#if NET
		[Abstract]
#endif
		[Export ("pasteboardPropertyListForType:")]
		NSObject GetPasteboardPropertyListForType (string type);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPasteboardItem : NSPasteboardWriting, NSPasteboardReading {
		[Export ("types")]
		string [] Types { get; }

		[Export ("availableTypeFromArray:")]
		string GetAvailableTypeFromArray (string [] types);

		[Export ("setDataProvider:forTypes:")]
		bool SetDataProviderForTypes (INSPasteboardItemDataProvider dataProvider, string [] types);

		[Export ("setData:forType:")]
		bool SetDataForType (NSData data, string type);

		[Export ("setString:forType:")]
		bool SetStringForType (string str, string type);

		[Export ("setPropertyList:forType:")]
		bool SetPropertyListForType (NSObject propertyList, string type);

		[Export ("dataForType:")]
		NSData GetDataForType (string type);

		[Export ("stringForType:")]
		string GetStringForType (string type);

		[Export ("propertyListForType:")]
		NSObject GetPropertyListForType (string type);

		// @interface SWCollaborationMetadata (NSPasteboardItem)

		[Mac (13, 0)]
		[NullAllowed, Export ("collaborationMetadata", ArgumentSemantic.Copy)]
		SWCollaborationMetadata CollaborationMetadata { get; set; }

	}

	interface INSPasteboardItemDataProvider { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSPasteboardItemDataProvider {
		[Abstract]
		[Export ("pasteboard:item:provideDataForType:")]
		void ProvideDataForType (NSPasteboard pasteboard, NSPasteboardItem item, string type);

#if !NET
		[Abstract]
#endif
		[Export ("pasteboardFinishedWithDataProvider:")]
		void FinishedWithDataProvider (NSPasteboard pasteboard);
	}

	interface INSPasteboardReading { }
	interface INSPasteboardWriting { }

	[NoMacCatalyst]
	[NoTV]
	[NoiOS]
#if !NET
	[BaseType (typeof (NSObject))]
	// A class that implements only NSPasteboardReading does not make sense, it's
	// used to add pasteboard support to existing classes.
	[Model]
#endif
	[Protocol]
	interface NSPasteboardReading {
		// This method is required, but we don't generate the correct code for required static methods
		// [Abstract]
		[Static]
		[Export ("readableTypesForPasteboard:")]
		string [] GetReadableTypesForPasteboard (NSPasteboard pasteboard);

		[Static]
		[Export ("readingOptionsForType:pasteboard:")]
		NSPasteboardReadingOptions GetReadingOptionsForType (string type, NSPasteboard pasteboard);

		[Abstract]
#if NET
		[Export ("initWithPasteboardPropertyList:ofType:")]
		NativeHandle Constructor (NSObject propertyList, NSString type);

#else
		// This binding is just broken, it's an ObjC ctor (init*) bound as a normal method.
		[Export ("xamarinselector:removed:")]
		[Obsolete ("It will never be called.")]
		NSObject InitWithPasteboardPropertyList (NSObject propertyList, string type);
#endif
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell), Events = new Type [] { typeof (NSPathCellDelegate) }, Delegates = new string [] { "WeakDelegate" })]
	interface NSPathCell : NSMenuItemValidation {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("pathStyle")]
		NSPathStyle PathStyle { get; set; }

		[Export ("URL", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }

		[Export ("setObjectValue:")]
		void SetObjectValue (NSObject obj);

		[Export ("allowedTypes")]
		string [] AllowedTypes { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSPathCellDelegate Delegate { get; set; }

		[Static, Export ("pathComponentCellClass")]
		Class PathComponentCellClass { get; }

		[Export ("pathComponentCells", ArgumentSemantic.Copy)]
		NSPathComponentCell [] PathComponentCells { get; set; }

		[Export ("rectOfPathComponentCell:withFrame:inView:")]
		CGRect GetRect (NSPathComponentCell componentCell, CGRect withFrame, NSView inView);

		[Export ("pathComponentCellAtPoint:withFrame:inView:")]
		NSPathComponentCell GetPathComponent (CGPoint point, CGRect frame, NSView view);

		[Export ("clickedPathComponentCell")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'ClickedPathItem' instead.")]
		NSPathComponentCell ClickedPathComponentCell { get; }

		[Export ("mouseEntered:withFrame:inView:")]
		void MouseEntered (NSEvent evt, CGRect frame, NSView view);

		[Export ("mouseExited:withFrame:inView:")]
		void MouseExited (NSEvent evt, CGRect frame, NSView view);

		[NullAllowed]
		[Export ("doubleAction")]
		Selector DoubleAction { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("placeholderString")]
		string PlaceholderString { get; set; }

		[Export ("placeholderAttributedString", ArgumentSemantic.Copy)]
		NSAttributedString PlaceholderAttributedString { get; set; }

		[Export ("setControlSize:")]
		void SetControlSize (NSControlSize size);
	}

	interface INSPathCellDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSPathCellDelegate {
		[Export ("pathCell:willDisplayOpenPanel:"), EventArgs ("NSPathCellDisplayPanel")]
		void WillDisplayOpenPanel (NSPathCell pathCell, NSOpenPanel openPanel);

		[Export ("pathCell:willPopUpMenu:"), EventArgs ("NSPathCellMenu")]
		void WillPopupMenu (NSPathCell pathCell, NSMenu menu);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextFieldCell))]
	interface NSPathComponentCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("image", ArgumentSemantic.Copy)]
		NSImage Image { get; set; }

		[Export ("URL", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSPathControl {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("URL", ArgumentSemantic.Copy)]
		NSUrl Url { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Please use ClickedPathItem instead.")]
		[Export ("clickedPathComponentCell")]
		NSPathComponentCell ClickedPathComponentCell { get; }

		[Export ("setDraggingSourceOperationMask:forLocal:")]
		void SetDraggingSource (NSDragOperation operationMask, bool isLocal);

		[NullAllowed]
		[Export ("doubleAction")]
		Selector DoubleAction { get; set; }

		[Export ("pathStyle")]
		NSPathStyle PathStyle { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Please use PathItems instead.")]
		[Export ("pathComponentCells")]
		NSPathComponentCell [] PathComponentCells { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy), NullAllowed]
		NSColor BackgroundColor { get; set; }

		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSPathControlDelegate Delegate { get; set; }

		[Export ("menu", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSMenu Menu { get; set; }

		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("allowedTypes", ArgumentSemantic.Copy)]
		NSString [] AllowedTypes { get; set; }

		[Export ("placeholderString")]
		string PlaceholderString { get; set; }

		[Export ("placeholderAttributedString", ArgumentSemantic.Copy)]
		NSAttributedString PlaceholderAttributedString { get; set; }

		[Export ("clickedPathItem")]
		NSPathControlItem ClickedPathItem { get; }

		[Export ("pathItems", ArgumentSemantic.Copy)]
		NSPathControlItem [] PathItems { get; set; }

	}

	interface INSPathControlDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSPathControlDelegate {
		[Export ("pathControl:shouldDragPathComponentCell:withPasteboard:")]
		bool ShouldDragPathComponentCell (NSPathControl pathControl, NSPathComponentCell pathComponentCell, NSPasteboard pasteboard);

		[Export ("pathControl:validateDrop:")]
#if NET
		NSDragOperation ValidateDrop (NSPathControl pathControl, INSDraggingInfo info);
#else
		NSDragOperation ValidateDrop (NSPathControl pathControl, NSDraggingInfo info);
#endif

		[Export ("pathControl:acceptDrop:")]
#if NET
		bool AcceptDrop (NSPathControl pathControl, INSDraggingInfo info);
#else
		bool AcceptDrop (NSPathControl pathControl, NSDraggingInfo info);
#endif

		[Export ("pathControl:willDisplayOpenPanel:")]
		void WillDisplayOpenPanel (NSPathControl pathControl, NSOpenPanel openPanel);

		[Export ("pathControl:willPopUpMenu:")]
		void WillPopUpMenu (NSPathControl pathControl, NSMenu menu);

		[Export ("pathControl:shouldDragItem:withPasteboard:")]
		bool ShouldDragItem (NSPathControl pathControl, NSPathControlItem pathItem, NSPasteboard pasteboard);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPathControlItem {
		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("attributedTitle", ArgumentSemantic.Copy)]
		NSAttributedString AttributedTitle { get; set; }

		[Export ("image", ArgumentSemantic.Strong)]
		NSImage Image { get; set; }

		[Export ("URL")]
		NSUrl Url { get; }
	}

	[NoMacCatalyst]
	[DesignatedDefaultCtor]
	[BaseType (typeof (NSResponder))]
	interface NSPopover : NSAppearanceCustomization, NSAccessibilityElementProtocol, NSAccessibility {
#if !NET
		[Obsolete ("Use 'GetAppearance' and 'SetAppearance' methods instead.")]
		[Export ("appearance", ArgumentSemantic.Retain)]
		new NSPopoverAppearance Appearance { get; set; }
#endif

		[Export ("behavior")]
		NSPopoverBehavior Behavior { get; set; }

		[Export ("animates")]
		bool Animates { get; set; }

		[Export ("contentViewController", ArgumentSemantic.Retain)]
		NSViewController ContentViewController { get; set; }

		[Export ("contentSize")]
		CGSize ContentSize { get; set; }

		[Export ("shown")]
		bool Shown { [Bind ("isShown")] get; }

		[Export ("positioningRect")]
		CGRect PositioningRect { get; set; }

		[Export ("delegate", ArgumentSemantic.Weak), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSPopoverDelegate Delegate { set; get; }

		[Export ("showRelativeToRect:ofView:preferredEdge:")]
		void Show (CGRect relativePositioningRect, NSView positioningView, NSRectEdge preferredEdge);

		[Export ("performClose:")]
		void PerformClose (NSObject sender);

		[Export ("close")]
		void Close ();

		[Field ("NSPopoverCloseReasonKey")]
		NSString CloseReasonKey { get; }

		[Field ("NSPopoverCloseReasonStandard")]
		NSString CloseReasonStandard { get; }

		[Field ("NSPopoverCloseReasonDetachToWindow")]
		NSString CloseReasonDetachToWindow { get; }

		[Notification, Field ("NSPopoverWillShowNotification")]
		NSString WillShowNotification { get; }

		[Notification, Field ("NSPopoverDidShowNotification")]
		NSString DidShowNotification { get; }

		[Notification (typeof (NSPopoverCloseEventArgs)), Field ("NSPopoverWillCloseNotification")]
		NSString WillCloseNotification { get; }

		[Notification (typeof (NSPopoverCloseEventArgs)), Field ("NSPopoverDidCloseNotification")]
		NSString DidCloseNotification { get; }

		[Export ("detached")]
		bool Detached { [Bind ("isDetached")] get; }

		[Mac (14, 0)]
		[Export ("showRelativeToToolbarItem:")]
		void ShowRelative (NSToolbarItem toToolbarItem);

		[Mac (14, 0)]
		[Export ("hasFullSizeContent")]
		bool HasFullSizeContent { get; set; }
	}

	partial interface NSPopoverCloseEventArgs {
		[Internal, Export ("NSPopoverCloseReasonKey")]
		NSString _Reason { get; }
	}

	interface INSPopoverDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSPopoverDelegate {
		[Export ("popoverShouldClose:")]
		bool ShouldClose (NSPopover popover);

		[Export ("detachableWindowForPopover:")]
		NSWindow GetDetachableWindowForPopover (NSPopover popover);

		[Export ("popoverWillShow:")]
		void WillShow (NSNotification notification);

		[Export ("popoverDidShow:")]
		void DidShow (NSNotification notification);

		[Export ("popoverWillClose:")]
		void WillClose (NSNotification notification);

		[Export ("popoverDidClose:")]
		void DidClose (NSNotification notification);

		[Export ("popoverDidDetach:")]
		void DidDetach (NSPopover popover);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSButton))]
	partial interface NSPopUpButton {
		[Export ("initWithFrame:pullsDown:")]
		NativeHandle Constructor (CGRect buttonFrame, bool pullsDown);

		[Export ("addItemWithTitle:")]
		void AddItem (string title);

		[Export ("addItemsWithTitles:")]
		void AddItems (string [] itemTitles);

		[Export ("insertItemWithTitle:atIndex:")]
		void InsertItem (string title, nint index);

		[Export ("removeItemWithTitle:")]
		void RemoveItem (string title);

		[Export ("removeItemAtIndex:")]
		void RemoveItem (nint index);

		[Export ("removeAllItems")]
		void RemoveAllItems ();

		[Export ("itemArray")]
		NSMenuItem [] Items ();

		[Export ("numberOfItems")]
		nint ItemCount { get; }

		[Export ("indexOfItem:")]
		nint IndexOfItem (NSMenuItem item);

		[Export ("indexOfItemWithTitle:")]
		nint IndexOfItem (string title);

		[Export ("indexOfItemWithTag:")]
		nint IndexOfItem (nint tag);

		[Export ("indexOfItemWithRepresentedObject:")]
		nint IndexOfItem (NSObject obj);

		[Export ("indexOfItemWithTarget:andAction:")]
		nint IndexOfItem (NSObject target, Selector actionSelector);

		[Export ("itemAtIndex:")]
		NSMenuItem ItemAtIndex (nint index);

		[Export ("itemWithTitle:")]
		NSMenuItem ItemWithTitle (string title);

		[Export ("lastItem")]
		NSMenuItem LastItem { get; }

		[Export ("selectItem:")]
		void SelectItem ([NullAllowed] NSMenuItem item);

		[Export ("selectItemAtIndex:")]
		void SelectItem (nint index);

		[Export ("selectItemWithTitle:")]
		void SelectItem (string title);

		[Export ("selectItemWithTag:")]
		bool SelectItemWithTag (nint tag);

		[Export ("setTitle:")]
		void SetTitle (string aString);

		[Export ("selectedItem")]
		NSMenuItem SelectedItem { get; }

		[Export ("indexOfSelectedItem")]
		nint IndexOfSelectedItem { get; }

		[Export ("synchronizeTitleAndSelectedItem")]
		void SynchronizeTitleAndSelectedItem ();

		[Export ("itemTitleAtIndex:")]
		string ItemTitle (nint index);

		[Export ("itemTitles")]
		string [] ItemTitles ();

		[Export ("titleOfSelectedItem")]
		string TitleOfSelectedItem { get; }

		//Detected properties
		[Export ("menu", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSMenu Menu { get; set; }

		[Export ("pullsDown")]
		bool PullsDown { get; set; }

		[Export ("autoenablesItems")]
		bool AutoEnablesItems { get; set; }

		[Export ("preferredEdge")]
		NSRectEdge PreferredEdge { get; set; }

		[Export ("selectedTag")]
		nint SelectedTag { get; }

		[Mac (15, 0)]
		[Static]
		[Export ("popUpButtonWithMenu:target:action:")]
		NSPopUpButton CreatePopUpButton (NSMenu menu, [NullAllowed] NSObject target, [NullAllowed] Selector selector);

		[Mac (15, 0)]
		[Static]
		[Export ("pullDownButtonWithTitle:menu:")]
		NSPopUpButton CreatePullDownButton (string title, NSMenu menu);

		[Mac (15, 0)]
		[Static]
		[Export ("pullDownButtonWithImage:menu:")]
		NSPopUpButton CreatePullDownButton (NSImage image, NSMenu menu);

		[Mac (15, 0)]
		[Static]
		[Export ("pullDownButtonWithTitle:image:menu:")]
		NSPopUpButton CreatePullDownButton (string title, NSImage image, NSMenu menu);

		[Mac (15, 0)]
		[Export ("usesItemFromMenu")]
		bool UsesItemFromMenu { get; set; }

		[Mac (15, 0)]
		[Export ("altersStateOfSelectedItem")]
		bool AltersStateOfSelectedItem { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSMenuItemCell))]
	partial interface NSPopUpButtonCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[DesignatedInitializer]
		[Export ("initTextCell:pullsDown:")]
		NativeHandle Constructor (string stringValue, bool pullDown);

		[Export ("addItemWithTitle:")]
		void AddItem (string title);

		[Export ("addItemsWithTitles:")]
		void AddItems (string [] itemTitles);

		[Export ("insertItemWithTitle:atIndex:")]
		void InsertItem (string title, nint index);

		[Export ("removeItemWithTitle:")]
		void RemoveItem (string title);

		[Export ("removeItemAtIndex:")]
		void RemoveItemAt (nint index);

		[Export ("removeAllItems")]
		void RemoveAllItems ();

		[Export ("itemArray")]
		NSMenuItem [] Items { get; }

		[Export ("numberOfItems")]
		nint Count { get; }

		[Export ("indexOfItem:")]
		nint IndexOf (NSMenuItem item);

		[Export ("indexOfItemWithTitle:")]
		nint IndexOfItemWithTitle (string title);

		[Export ("indexOfItemWithTag:")]
		nint IndexOfItemWithTag (nint tag);

		[Export ("indexOfItemWithRepresentedObject:")]
		nint IndexOfItemWithRepresentedObject (NSObject obj);

		[Export ("indexOfItemWithTarget:andAction:")]
		nint IndexOfItemWithTargetandAction (NSObject target, Selector actionSelector);

		[Export ("itemAtIndex:")]
		NSMenuItem ItemAt (nint index);

		[Export ("itemWithTitle:")]
		NSMenuItem ItemWithTitle (string title);

		[Export ("lastItem")]
		NSMenuItem LastItem { get; }

		[Export ("selectItem:")]
		void SelectItem (NSMenuItem item);

		[Export ("selectItemAtIndex:")]
		void SelectItemAt (nint index);

		[Export ("selectItemWithTitle:")]
		void SelectItemWithTitle (string title);

		[Export ("selectItemWithTag:")]
		bool SelectItemWithTag (nint tag);

		[Export ("setTitle:")]
		void SetTitle (string aString);

		[Export ("selectedItem")]
		NSMenuItem SelectedItem { get; }

		[Export ("indexOfSelectedItem")]
		nint SelectedItemIndex { get; }

		[Export ("synchronizeTitleAndSelectedItem")]
		void SynchronizeTitleAndSelectedItem ();

		[Export ("itemTitleAtIndex:")]
		string GetItemTitle (nint index);

		[Export ("itemTitles")]
		string [] ItemTitles { get; }

		[Export ("titleOfSelectedItem")]
		string TitleOfSelectedItem { get; }

		[Export ("attachPopUpWithFrame:inView:")]
		void AttachPopUp (CGRect cellFrame, NSView inView);

		[Export ("dismissPopUp")]
		void DismissPopUp ();

		[Export ("performClickWithFrame:inView:")]
		void PerformClick (CGRect withFrame, NSView controlView);

		//Detected properties
		[Export ("menu", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSMenu Menu { get; set; }

		[Export ("pullsDown")]
		bool PullsDown { get; set; }

		[Export ("autoenablesItems")]
		bool AutoenablesItems { get; set; }

		[Export ("preferredEdge")]
		NSRectEdge PreferredEdge { get; set; }

		[Export ("usesItemFromMenu")]
		bool UsesItemFromMenu { get; set; }

		[Export ("altersStateOfSelectedItem")]
		bool AltersStateOfSelectedItem { get; set; }

		[Export ("arrowPosition")]
		NSPopUpArrowPosition ArrowPosition { get; set; }

		[Export ("objectValue")]
		NSObject ObjectValue { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPrinter : NSCoding, NSCopying {
		[Static]
		[Export ("printerNames", ArgumentSemantic.Copy)]
		string [] PrinterNames { get; }

		[Static]
		[Export ("printerTypes", ArgumentSemantic.Copy)]
		string [] PrinterTypes { get; }

		[Static]
		[Export ("printerWithName:")]
		NSPrinter PrinterWithName (string name);

		[Static]
		[Export ("printerWithType:")]
		NSPrinter PrinterWithType (string type);

		[Export ("name")]
		string Name { get; }

		[Export ("type")]
		string Type { get; }

		[Export ("languageLevel")]
		nint LanguageLevel { get; }

		[Export ("pageSizeForPaper:")]
		CGSize PageSizeForPaper (string paperName);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("statusForTable:")]
		NSPrinterTableStatus StatusForTable (string tableName);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("isKey:inTable:")]
		bool IsKeyInTable (string key, string table);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("booleanForKey:inTable:")]
		bool BooleanForKey (string key, string table);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("floatForKey:inTable:")]
		float /* float, not CGFloat */ FloatForKey (string key, string table);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("intForKey:inTable:")]
		int /* int, not NSInteger */ IntForKey (string key, string table);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("rectForKey:inTable:")]
		CGRect RectForKey (string key, string table);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("sizeForKey:inTable:")]
		CGSize SizeForKey (string key, string table);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("stringForKey:inTable:")]
		string StringForKey (string key, string table);

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("stringListForKey:inTable:")]
		string [] StringListForKey (string key, string table);

		[Export ("deviceDescription")]
		NSDictionary DeviceDescription { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPrintInfo : NSCoding, NSCopying {
		[DesignatedInitializer]
		[Export ("initWithDictionary:")]
		NativeHandle Constructor (NSDictionary attributes);

		[Export ("dictionary")]
		NSMutableDictionary Dictionary { get; }

		[Export ("setUpPrintOperationDefaultValues")]
		void SetUpPrintOperationDefaultValues ();

		[Export ("imageablePageBounds")]
		CGRect ImageablePageBounds { get; }

		[Export ("localizedPaperName")]
		string LocalizedPaperName { get; }

		[Static]
		[Export ("defaultPrinter")]
		NSPrinter DefaultPrinter { get; }

		[Export ("printSettings")]
		NSMutableDictionary PrintSettings { get; }

#if NET
		[Internal]
#endif
		[Export ("PMPrintSession")]
		IntPtr GetPMPrintSession ();

#if NET
		[Internal]
#endif
		[Export ("PMPageFormat")]
		IntPtr GetPMPageFormat ();

#if NET
		[Internal]
#endif
		[Export ("PMPrintSettings")]
		IntPtr GetPMPrintSettings ();

		[Export ("updateFromPMPageFormat")]
		void UpdateFromPMPageFormat ();

		[Export ("updateFromPMPrintSettings")]
		void UpdateFromPMPrintSettings ();

		//Detected properties
		[Static]
		[Export ("sharedPrintInfo")]
		NSPrintInfo SharedPrintInfo { get; set; }

		[Export ("paperName")]
		string PaperName { get; set; }

		[Export ("paperSize")]
		CGSize PaperSize { get; set; }

		[Export ("orientation")]
		NSPrintingOrientation Orientation { get; set; }

		[Export ("scalingFactor")]
		nfloat ScalingFactor { get; set; }

		[Export ("leftMargin")]
		nfloat LeftMargin { get; set; }

		[Export ("rightMargin")]
		nfloat RightMargin { get; set; }

		[Export ("topMargin")]
		nfloat TopMargin { get; set; }

		[Export ("bottomMargin")]
		nfloat BottomMargin { get; set; }

		[Export ("horizontallyCentered")]
		bool HorizontallyCentered { [Bind ("isHorizontallyCentered")] get; set; }

		[Export ("verticallyCentered")]
		bool VerticallyCentered { [Bind ("isVerticallyCentered")] get; set; }

		[Export ("horizontalPagination")]
		NSPrintingPaginationMode HorizontalPagination { get; set; }

		[Export ("verticalPagination")]
		NSPrintingPaginationMode VerticalPagination { get; set; }

		[Export ("jobDisposition")]
		string JobDisposition { get; set; }

		[Export ("printer", ArgumentSemantic.Copy)]
		NSPrinter Printer { get; set; }

		[Export ("selectionOnly")]
		bool SelectionOnly { [Bind ("isSelectionOnly")] get; set; }

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface NSPrintOperation {
		[Static]
		[Export ("printOperationWithView:printInfo:")]
		NSPrintOperation FromView (NSView view, NSPrintInfo printInfo);

		[Static]
		[Export ("PDFOperationWithView:insideRect:toData:printInfo:")]
		NSPrintOperation PdfFromView (NSView view, CGRect rect, NSMutableData data, NSPrintInfo printInfo);

		[Static]
		[Export ("PDFOperationWithView:insideRect:toPath:printInfo:")]
		NSPrintOperation PdfFromView (NSView view, CGRect rect, string path, NSPrintInfo printInfo);

		[Static]
		[Export ("EPSOperationWithView:insideRect:toData:printInfo:")]
		NSPrintOperation EpsFromView (NSView view, CGRect rect, NSMutableData data, NSPrintInfo printInfo);

		[Static]
		[Export ("EPSOperationWithView:insideRect:toPath:printInfo:")]
		NSPrintOperation EpsFromView (NSView view, CGRect rect, string path, NSPrintInfo printInfo);

		[Static]
		[Export ("printOperationWithView:")]
		NSPrintOperation FromView (NSView view);

		[Static]
		[Export ("PDFOperationWithView:insideRect:toData:")]
		NSPrintOperation PdfFromView (NSView view, CGRect rect, NSMutableData data);

		[Static]
		[Export ("EPSOperationWithView:insideRect:toData:")]
		NSPrintOperation EpsFromView (NSView view, CGRect rect, NSMutableData data);

		[Export ("isCopyingOperation")]
		bool IsCopyingOperation { get; }

		[Export ("runOperationModalForWindow:delegate:didRunSelector:contextInfo:")]
		void RunOperationModal (NSWindow docWindow, NSObject del, Selector didRunSelector, IntPtr contextInfo);

		[Export ("runOperation")]
		bool RunOperation ();

		[Export ("view")]
		NSView View { get; }

		[Export ("context")]
		NSGraphicsContext Context { get; }

		[Export ("pageRange")]
		NSRange PageRange { get; }

		[Export ("currentPage")]
		nint CurrentPage { get; }

		[Export ("createContext")]
		NSGraphicsContext CreateContext ();

		[Export ("destroyContext")]
		void DestroyContext ();

		[Export ("deliverResult")]
		bool DeliverResult ();

		[Export ("cleanUpOperation")]
		void CleanUpOperation ();

		//Detected properties
		[Static]
		[Export ("currentOperation")]
		NSPrintOperation CurrentOperation { get; set; }

		[Export ("jobTitle")]
		string JobTitle { get; set; }

		[Export ("showsPrintPanel")]
		bool ShowsPrintPanel { get; set; }

		[Export ("showsProgressPanel")]
		bool ShowsProgressPanel { get; set; }

		[Export ("printPanel", ArgumentSemantic.Retain)]
		NSPrintPanel PrintPanel { get; set; }

		[Export ("canSpawnSeparateThread")]
		bool CanSpawnSeparateThread { get; set; }

		[Export ("pageOrder")]
		NSPrintingPageOrder PageOrder { get; set; }

		[Export ("printInfo", ArgumentSemantic.Copy)]
		NSPrintInfo PrintInfo { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSPrintPanelAccessorizing {
		[Abstract]
		[Export ("localizedSummaryItems")]
		NSDictionary [] LocalizedSummaryItems ();

#if !NET
		[Abstract]
#endif
		[Export ("keyPathsForValuesAffectingPreview")]
		NSSet KeyPathsForValuesAffectingPreview ();
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPrintPanel {
		[Static]
		[Export ("printPanel")]
		NSPrintPanel PrintPanel { get; }

		[Export ("addAccessoryController:")]
		void AddAccessoryController (NSViewController accessoryController);

		[Export ("removeAccessoryController:")]
		void RemoveAccessoryController (NSViewController accessoryController);

		[Export ("accessoryControllers")]
		NSViewController [] AccessoryControllers ();

		[Deprecated (PlatformName.MacOSX, 14, 0)]
		[Export ("beginSheetWithPrintInfo:modalForWindow:delegate:didEndSelector:contextInfo:")]
		void BeginSheet (NSPrintInfo printInfo, NSWindow docWindow, [NullAllowed] NSObject del, [NullAllowed] Selector didEndSelector, IntPtr contextInfo);

		[Export ("runModalWithPrintInfo:")]
		nint RunModalWithPrintInfo (NSPrintInfo printInfo);

		[Export ("runModal")]
		nint RunModal ();

		[Export ("printInfo")]
		NSPrintInfo PrintInfo { get; }

		//Detected properties
		[Export ("options")]
		NSPrintPanelOptions Options { get; set; }

		[Export ("defaultButtonTitle")]
		string DefaultButtonTitle { get; set; }

		[Export ("helpAnchor")]
		string HelpAnchor { get; set; }

		[Export ("jobStyleHint")]
		string JobStyleHint { get; set; }

		[Async]
		[Mac (14, 0)]
		[Export ("beginSheetUsingPrintInfo:onWindow:completionHandler:")]
		void BeginSheet (NSPrintInfo printInfo, NSWindow parentWindow, [NullAllowed] Action<NSPrintPanelResult> handler);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSProgressIndicator : NSAccessibilityProgressIndicator {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("incrementBy:")]
		void IncrementBy (double delta);

		[Export ("startAnimation:")]
		void StartAnimation ([NullAllowed] NSObject sender);

		[Export ("stopAnimation:")]
		void StopAnimation ([NullAllowed] NSObject sender);

		[Export ("style")]
		NSProgressIndicatorStyle Style { get; set; }

		[Export ("sizeToFit")]
		void SizeToFit ();

		[Export ("displayedWhenStopped")]
		bool IsDisplayedWhenStopped { [Bind ("isDisplayedWhenStopped")] get; set; }

		//Detected properties
		[Export ("indeterminate")]
		bool Indeterminate { [Bind ("isIndeterminate")] get; set; }

		[Deprecated (PlatformName.MacOSX, 14, 0, message: "This property is not respected anymore.")]
		[Export ("bezeled")]
		bool Bezeled { [Bind ("isBezeled")] get; set; }

		[Deprecated (PlatformName.MacOSX, 14, 0, message: "This property is not respected anymore.")]
		[Export ("controlTint")]
		NSControlTint ControlTint { get; set; }

		[Export ("controlSize")]
		NSControlSize ControlSize { get; set; }

		[Export ("doubleValue")]
		double DoubleValue { get; set; }

		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("usesThreadedAnimation")]
		bool UsesThreadedAnimation { get; set; }

		[Mac (14, 0)]
		[NullAllowed]
		[Export ("observedProgress", ArgumentSemantic.Strong)]
		NSProgress ObservedProgress { get; set; }
	}

	// Technically on NSResponder but responder subclasses can implement any that make sense
	// So bound for user classes but not added to NSResponder binding
	[NoMacCatalyst]
	[Protocol]
	interface NSStandardKeyBindingResponding {
		[Export ("insertText:")]
		void InsertText (NSObject insertString);

		[Export ("doCommandBySelector:")]
		void DoCommandBySelector (Selector selector);

		[Export ("moveForward:")]
		void MoveForward ([NullAllowed] NSObject sender);

		[Export ("moveRight:")]
		void MoveRight ([NullAllowed] NSObject sender);

		[Export ("moveBackward:")]
		void MoveBackward ([NullAllowed] NSObject sender);

		[Export ("moveLeft:")]
		void MoveLeft ([NullAllowed] NSObject sender);

		[Export ("moveUp:")]
		void MoveUp ([NullAllowed] NSObject sender);

		[Export ("moveDown:")]
		void MoveDown ([NullAllowed] NSObject sender);

		[Export ("moveWordForward:")]
		void MoveWordForward ([NullAllowed] NSObject sender);

		[Export ("moveWordBackward:")]
		void MoveWordBackward ([NullAllowed] NSObject sender);

		[Export ("moveToBeginningOfLine:")]
		void MoveToBeginningOfLine ([NullAllowed] NSObject sender);

		[Export ("moveToEndOfLine:")]
		void MoveToEndOfLine ([NullAllowed] NSObject sender);

		[Export ("moveToBeginningOfParagraph:")]
		void MoveToBeginningOfParagraph ([NullAllowed] NSObject sender);

		[Export ("moveToEndOfParagraph:")]
		void MoveToEndOfParagraph ([NullAllowed] NSObject sender);

		[Export ("moveToEndOfDocument:")]
		void MoveToEndOfDocument ([NullAllowed] NSObject sender);

		[Export ("moveToBeginningOfDocument:")]
		void MoveToBeginningOfDocument ([NullAllowed] NSObject sender);

		[Export ("pageDown:")]
		void PageDown ([NullAllowed] NSObject sender);

		[Export ("pageUp:")]
		void PageUp ([NullAllowed] NSObject sender);

		[Export ("centerSelectionInVisibleArea:")]
		void CenterSelectionInVisibleArea ([NullAllowed] NSObject sender);

		[Export ("moveBackwardAndModifySelection:")]
		void MoveBackwardAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveForwardAndModifySelection:")]
		void MoveForwardAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveWordForwardAndModifySelection:")]
		void MoveWordForwardAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveWordBackwardAndModifySelection:")]
		void MoveWordBackwardAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveUpAndModifySelection:")]
		void MoveUpAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveDownAndModifySelection:")]
		void MoveDownAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToBeginningOfLineAndModifySelection:")]
		void MoveToBeginningOfLineAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToEndOfLineAndModifySelection:")]
		void MoveToEndOfLineAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToBeginningOfParagraphAndModifySelection:")]
		void MoveToBeginningOfParagraphAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToEndOfParagraphAndModifySelection:")]
		void MoveToEndOfParagraphAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToEndOfDocumentAndModifySelection:")]
		void MoveToEndOfDocumentAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToBeginningOfDocumentAndModifySelection:")]
		void MoveToBeginningOfDocumentAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("pageDownAndModifySelection:")]
		void PageDownAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("pageUpAndModifySelection:")]
		void PageUpAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveParagraphForwardAndModifySelection:")]
		void MoveParagraphForwardAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveParagraphBackwardAndModifySelection:")]
		void MoveParagraphBackwardAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveWordRight:")]
		void MoveWordRight ([NullAllowed] NSObject sender);

		[Export ("moveWordLeft:")]
		void MoveWordLeft ([NullAllowed] NSObject sender);

		[Export ("moveRightAndModifySelection:")]
		void MoveRightAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveLeftAndModifySelection:")]
		void MoveLeftAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveWordRightAndModifySelection:")]
		void MoveWordRightAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveWordLeftAndModifySelection:")]
		void MoveWordLeftAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToLeftEndOfLine:")]
		void MoveToLeftEndOfLine ([NullAllowed] NSObject sender);

		[Export ("moveToRightEndOfLine:")]
		void MoveToRightEndOfLine ([NullAllowed] NSObject sender);

		[Export ("moveToLeftEndOfLineAndModifySelection:")]
		void MoveToLeftEndOfLineAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("moveToRightEndOfLineAndModifySelection:")]
		void MoveToRightEndOfLineAndModifySelection ([NullAllowed] NSObject sender);

		[Export ("scrollPageUp:")]
		void ScrollPageUp ([NullAllowed] NSObject sender);

		[Export ("scrollPageDown:")]
		void ScrollPageDown ([NullAllowed] NSObject sender);

		[Export ("scrollLineUp:")]
		void ScrollLineUp ([NullAllowed] NSObject sender);

		[Export ("scrollLineDown:")]
		void ScrollLineDown ([NullAllowed] NSObject sender);

		[Export ("scrollToBeginningOfDocument:")]
		void ScrollToBeginningOfDocument ([NullAllowed] NSObject sender);

		[Export ("scrollToEndOfDocument:")]
		void ScrollToEndOfDocument ([NullAllowed] NSObject sender);

		[Export ("transpose:")]
		void Transpose ([NullAllowed] NSObject sender);

		[Export ("transposeWords:")]
		void TransposeWords ([NullAllowed] NSObject sender);

		[Export ("selectAll:")]
		void SelectAll ([NullAllowed] NSObject sender);

		[Export ("selectParagraph:")]
		void SelectParagraph ([NullAllowed] NSObject sender);

		[Export ("selectLine:")]
		void SelectLine ([NullAllowed] NSObject sender);

		[Export ("selectWord:")]
		void SelectWord ([NullAllowed] NSObject sender);

		[Export ("indent:")]
		void Indent ([NullAllowed] NSObject sender);

		[Export ("insertTab:")]
		void InsertTab ([NullAllowed] NSObject sender);

		[Export ("insertBacktab:")]
		void InsertBacktab ([NullAllowed] NSObject sender);

		[Export ("insertNewline:")]
		void InsertNewline ([NullAllowed] NSObject sender);

		[Export ("insertParagraphSeparator:")]
		void InsertParagraphSeparator ([NullAllowed] NSObject sender);

		[Export ("insertNewlineIgnoringFieldEditor:")]
		void InsertNewlineIgnoringFieldEditor ([NullAllowed] NSObject sender);

		[Export ("insertTabIgnoringFieldEditor:")]
		void InsertTabIgnoringFieldEditor ([NullAllowed] NSObject sender);

		[Export ("insertLineBreak:")]
		void InsertLineBreak ([NullAllowed] NSObject sender);

		[Export ("insertContainerBreak:")]
		void InsertContainerBreak ([NullAllowed] NSObject sender);

		[Export ("insertSingleQuoteIgnoringSubstitution:")]
		void InsertSingleQuoteIgnoringSubstitution ([NullAllowed] NSObject sender);

		[Export ("insertDoubleQuoteIgnoringSubstitution:")]
		void InsertDoubleQuoteIgnoringSubstitution ([NullAllowed] NSObject sender);

		[Export ("changeCaseOfLetter:")]
		void ChangeCaseOfLetter ([NullAllowed] NSObject sender);

		[Export ("uppercaseWord:")]
		void UppercaseWord ([NullAllowed] NSObject sender);

		[Export ("lowercaseWord:")]
		void LowercaseWord ([NullAllowed] NSObject sender);

		[Export ("capitalizeWord:")]
		void CapitalizeWord ([NullAllowed] NSObject sender);

		[Export ("deleteForward:")]
		void DeleteForward ([NullAllowed] NSObject sender);

		[Export ("deleteBackward:")]
		void DeleteBackward ([NullAllowed] NSObject sender);

		[Export ("deleteBackwardByDecomposingPreviousCharacter:")]
		void DeleteBackwardByDecomposingPreviousCharacter ([NullAllowed] NSObject sender);

		[Export ("deleteWordForward:")]
		void DeleteWordForward ([NullAllowed] NSObject sender);

		[Export ("deleteWordBackward:")]
		void DeleteWordBackward ([NullAllowed] NSObject sender);

		[Export ("deleteToBeginningOfLine:")]
		void DeleteToBeginningOfLine ([NullAllowed] NSObject sender);

		[Export ("deleteToEndOfLine:")]
		void DeleteToEndOfLine ([NullAllowed] NSObject sender);

		[Export ("deleteToBeginningOfParagraph:")]
		void DeleteToBeginningOfParagraph ([NullAllowed] NSObject sender);

		[Export ("deleteToEndOfParagraph:")]
		void DeleteToEndOfParagraph ([NullAllowed] NSObject sender);

		[Export ("yank:")]
		void Yank ([NullAllowed] NSObject sender);

		[Export ("complete:")]
		void Complete ([NullAllowed] NSObject sender);

		[Export ("setMark:")]
		void SetMark ([NullAllowed] NSObject sender);

		[Export ("deleteToMark:")]
		void DeleteToMark ([NullAllowed] NSObject sender);

		[Export ("selectToMark:")]
		void SelectToMark ([NullAllowed] NSObject sender);

		[Export ("swapWithMark:")]
		void SwapWithMark ([NullAllowed] NSObject sender);

		[Export ("cancelOperation:")]
		void CancelOperation ([NullAllowed] NSObject sender);

		[Export ("makeBaseWritingDirectionNatural:")]
		void MakeBaseWritingDirectionNatural ([NullAllowed] NSObject sender);

		[Export ("makeBaseWritingDirectionLeftToRight:")]
		void MakeBaseWritingDirectionLeftToRight ([NullAllowed] NSObject sender);

		[Export ("makeBaseWritingDirectionRightToLeft:")]
		void MakeBaseWritingDirectionRightToLeft ([NullAllowed] NSObject sender);

		[Export ("makeTextWritingDirectionNatural:")]
		void MakeTextWritingDirectionNatural ([NullAllowed] NSObject sender);

		[Export ("makeTextWritingDirectionLeftToRight:")]
		void MakeTextWritingDirectionLeftToRight ([NullAllowed] NSObject sender);

		[Export ("makeTextWritingDirectionRightToLeft:")]
		void MakeTextWritingDirectionRightToLeft ([NullAllowed] NSObject sender);

		[Export ("quickLookPreviewItems:")]
		void QuickLookPreviewItems ([NullAllowed] NSObject sender);

		[Mac (15, 0)]
		[Export ("showContextMenuForSelection:")]
		void ShowContextMenuForSelection ([NullAllowed] NSObject sender);
	}

	[NoMacCatalyst]
	[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	partial interface NSResponder : NSCoding, NSTouchBarProvider, NSUserActivityRestoring {
		[Export ("tryToPerform:with:")]
		bool TryToPerformwith (Selector anAction, [NullAllowed] NSObject anObject);

		[Export ("performKeyEquivalent:")]
		bool PerformKeyEquivalent (NSEvent theEvent);

		[Export ("validRequestorForSendType:returnType:")]
		NSObject ValidRequestorForSendType ([NullAllowed] string sendType, [NullAllowed] string returnType);

		[Export ("mouseDown:")]
		void MouseDown (NSEvent theEvent);

		[Export ("rightMouseDown:")]
		void RightMouseDown (NSEvent theEvent);

		[Export ("otherMouseDown:")]
		void OtherMouseDown (NSEvent theEvent);

		[Export ("mouseUp:")]
		void MouseUp (NSEvent theEvent);

		[Export ("rightMouseUp:")]
		void RightMouseUp (NSEvent theEvent);

		[Export ("otherMouseUp:")]
		void OtherMouseUp (NSEvent theEvent);

		[Export ("mouseMoved:")]
		void MouseMoved (NSEvent theEvent);

		[Export ("mouseDragged:")]
		void MouseDragged (NSEvent theEvent);

		[Export ("scrollWheel:")]
		void ScrollWheel (NSEvent theEvent);

		[Export ("rightMouseDragged:")]
		void RightMouseDragged (NSEvent theEvent);

		[Export ("otherMouseDragged:")]
		void OtherMouseDragged (NSEvent theEvent);

		[Export ("mouseEntered:")]
		void MouseEntered (NSEvent theEvent);

		[Export ("mouseExited:")]
		void MouseExited (NSEvent theEvent);

		[Export ("keyDown:")]
		void KeyDown (NSEvent theEvent);

		[Export ("keyUp:")]
		void KeyUp (NSEvent theEvent);

		[Export ("flagsChanged:")]
		void FlagsChanged (NSEvent theEvent);

		[Export ("tabletPoint:")]
		void TabletPoint (NSEvent theEvent);

		[Export ("tabletProximity:")]
		void TabletProximity (NSEvent theEvent);

		[Export ("cursorUpdate:")]
		void CursorUpdate (NSEvent theEvent);

		[Export ("magnifyWithEvent:")]
		void MagnifyWithEvent (NSEvent theEvent);

		[Export ("rotateWithEvent:")]
		void RotateWithEvent (NSEvent theEvent);

		[Export ("swipeWithEvent:")]
		void SwipeWithEvent (NSEvent theEvent);

		[Export ("beginGestureWithEvent:")]
		void BeginGestureWithEvent (NSEvent theEvent);

		[Export ("endGestureWithEvent:")]
		void EndGestureWithEvent (NSEvent theEvent);

		[Export ("touchesBeganWithEvent:")]
		void TouchesBeganWithEvent (NSEvent theEvent);

		[Export ("touchesMovedWithEvent:")]
		void TouchesMovedWithEvent (NSEvent theEvent);

		[Export ("touchesEndedWithEvent:")]
		void TouchesEndedWithEvent (NSEvent theEvent);

		[Export ("touchesCancelledWithEvent:")]
		void TouchesCancelledWithEvent (NSEvent theEvent);

		[Export ("noResponderFor:")]
		void NoResponderFor (Selector eventSelector);

		[Export ("acceptsFirstResponder")]
		bool AcceptsFirstResponder ();

		[Export ("becomeFirstResponder")]
		bool BecomeFirstResponder ();

		[Export ("resignFirstResponder")]
		bool ResignFirstResponder ();

		[Export ("interpretKeyEvents:")]
		void InterpretKeyEvents (NSEvent [] eventArray);

		[Export ("flushBufferedKeyEvents")]
		void FlushBufferedKeyEvents ();

		[Export ("showContextHelp:")]
		void ShowContextHelp (NSObject sender);

		[Export ("helpRequested:")]
		void HelpRequested (NSEvent theEventPtr);

		[Export ("shouldBeTreatedAsInkEvent:")]
		bool ShouldBeTreatedAsInkEvent (NSEvent theEvent);

		//Detected properties
		[Export ("nextResponder")]
		[NullAllowed]
		NSResponder NextResponder { get; set; }

		[Export ("menu", ArgumentSemantic.Retain)]
		[NullAllowed]
		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		NSMenu Menu { get; set; }

		[Export ("encodeRestorableStateWithCoder:")]
		void EncodeRestorableState (NSCoder coder);

		[Export ("restoreStateWithCoder:")]
		void RestoreState (NSCoder coder);

		[Export ("invalidateRestorableState")]
		void InvalidateRestorableState ();

		[Static]
		[Export ("restorableStateKeyPaths", ArgumentSemantic.Copy)]
		string [] RestorableStateKeyPaths ();

		[Static]
		[Export ("allowedClassesForRestorableStateKeyPath:")]
		Class [] GetAllowedClassesForRestorableStateKeyPath (string keyPath);

		[Export ("wantsForwardedScrollEventsForAxis:")]
		bool WantsForwardedScrollEventsForAxis (NSEventGestureAxis axis);

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("userActivity", ArgumentSemantic.Strong)]
		NSUserActivity UserActivity { get; set; }

		[Export ("updateUserActivityState:")]
		void UpdateUserActivityState (NSUserActivity userActivity);

#if !NET
		// Should be removed but radar://42781537 - Classes fail to conformsToProtocol despite header declaration
		[Export ("restoreUserActivityState:")]
		new void RestoreUserActivityState (NSUserActivity userActivity);
#endif

		[Export ("pressureChangeWithEvent:")]
		void PressureChange (NSEvent pressureChangeEvent);

		[Export ("newWindowForTab:")]
		void GetNewWindowForTab ([NullAllowed] NSObject sender);

		[Export ("presentError:")]
		bool PresentError (NSError error);

		[Export ("willPresentError:")]
		NSError WillPresentError (NSError error);

		[Sealed]
		[Export ("presentError:modalForWindow:delegate:didPresentSelector:contextInfo:")]
		void PresentError (NSError error, NSWindow window, [NullAllowed] NSObject @delegate, [NullAllowed] Selector didPresentSelector, IntPtr contextInfo);

		[Export ("encodeRestorableStateWithCoder:backgroundQueue:")]
		void EncodeRestorableState (NSCoder coder, NSOperationQueue queue);

		[Mac (15, 0)]
		[Export ("contextMenuKeyDown:")]
		void ContextMenuKeyDown (NSEvent @event);
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSUserActivityRestoring {
		[Abstract]
		[Export ("restoreUserActivityState:")]
		void RestoreUserActivityState (NSUserActivity userActivity);
	}

	interface INSUserActivityRestoring { }

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSResponder))]
	interface NSResponder_NSTouchBarProvider : INSTouchBarProvider {
		[Export ("touchBar")]
		[return: NullAllowed]
		NSTouchBar GetTouchBar ();

		[Export ("setTouchBar:")]
		void SetTouchBar ([NullAllowed] NSTouchBar bar);

		[Export ("makeTouchBar")]
		NSTouchBar MakeTouchBar ();
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSGestureRecognizer))]
	interface NSRotationGestureRecognizer {
		[Export ("initWithTarget:action:")]
		NativeHandle Constructor (NSObject target, Selector action);

		[Export ("rotation")]
		nfloat Rotation { get; set; }

		[Export ("rotationInDegrees")]
		nfloat RotationInDegrees { get; set; }
	}

	/*
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSRulerMarker : NSCoding, NSCopying {
		[DesignatedInitializer]
		[Export ("initWithRulerView:markerLocation:image:imageOrigin:")]
		NativeHandle Constructor (NSRulerView ruler, nfloat location, NSImage image, CGPoint imageOrigin);

		[Export ("ruler")]
		NSRulerView Ruler { get; }

		[Export ("isDragging")]
		bool IsDragging { get; }

		[Export ("imageRectInRuler")]
		CGRect ImageRectInRuler { get; }

		[Export ("thicknessRequiredInRuler")]
		nfloat ThicknessRequiredInRuler { get; }

		[Export ("drawRect:")]
		void DrawRect (CGRect rect);

		[Export ("trackMouse:adding:")]
		bool TrackMouse (NSEvent mouseDownEvent, bool isAdding);

		//Detected properties
		[Export ("markerLocation")]
		nfloat MarkerLocation { get; set; }

		[Export ("image", ArgumentSemantic.Retain)]
		NSImage Image { get; set; }

		[Export ("imageOrigin")]
		CGPoint ImageOrigin { get; set; }

		[Export ("movable")]
		bool Movable { [Bind ("isMovable")] get; set; }

		[Export ("removable")]
		bool Removable { [Bind ("isRemovable")] get; set; }

		[Export ("representedObject", ArgumentSemantic.Retain)]
		NSObject RepresentedObject { get; set; }
	}
	*/
 /*
	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	partial interface NSRulerView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Static]
		[Export ("registerUnitWithName:abbreviation:unitToPointsConversionFactor:stepUpCycle:stepDownCycle:")]
		void RegisterUnit (string unitName, string abbreviation, nfloat conversionFactor, NSNumber [] stepUpCycle, NSNumber [] stepDownCycle);

		[DesignatedInitializer]
		[Export ("initWithScrollView:orientation:")]
		NativeHandle Constructor (NSScrollView scrollView, NSRulerOrientation orientation);

		[Export ("baselineLocation")]
		nfloat BaselineLocation { get; }

		[Export ("requiredThickness")]
		nfloat RequiredThickness { get; }

		[Export ("addMarker:")]
		void AddMarker (NSRulerMarker marker);

		[Export ("removeMarker:")]
		void RemoveMarker (NSRulerMarker marker);

		[Export ("trackMarker:withMouseEvent:")]
		bool TrackMarker (NSRulerMarker marker, NSEvent theEvent);

		[Export ("moveRulerlineFromLocation:toLocation:")]
		void MoveRulerline (nfloat oldLocation, nfloat newLocation);

		[Export ("invalidateHashMarks")]
		void InvalidateHashMarks ();

		[Export ("drawHashMarksAndLabelsInRect:")]
		void DrawHashMarksAndLabels (CGRect rect);

		[Export ("drawMarkersInRect:")]
		void DrawMarkers (CGRect rect);

		[Export ("isFlipped")]
		bool IsFlipped { get; }

		//Detected properties
		[Export ("scrollView", ArgumentSemantic.Weak)]
		NSScrollView ScrollView { get; set; }

		[Export ("orientation")]
		NSRulerOrientation Orientation { get; set; }

		[Export ("ruleThickness")]
		nfloat RuleThickness { get; set; }

		[Export ("reservedThicknessForMarkers")]
		nfloat ReservedThicknessForMarkers { get; set; }

		[Export ("reservedThicknessForAccessoryView")]
		nfloat ReservedThicknessForAccessoryView { get; set; }

		[Export ("measurementUnits")]
#if NET
		[BindAs (typeof (NSRulerViewUnits))]
		NSString MeasurementUnits { get; set; }
#else
		string MeasurementUnits { get; set; }
#endif

		[Sealed]
		[Export ("measurementUnits")]
		NSString WeakMeasurementUnits { get; set; }

		[Export ("originOffset")]
		nfloat OriginOffset { get; set; }

		[Export ("clientView", ArgumentSemantic.Weak)]
		NSView ClientView { get; set; }

		[Export ("markers", ArgumentSemantic.Copy), NullAllowed]
		NSRulerMarker [] Markers { get; set; }

		[Export ("accessoryView", ArgumentSemantic.Retain), NullAllowed]
		NSView AccessoryView { get; set; }
	}
	*/

	[NoMacCatalyst]
	enum NSRulerViewUnits {
		[Field ("NSRulerViewUnitInches")]
		Inches,

		[Field ("NSRulerViewUnitCentimeters")]
		Centimeters,

		[Field ("NSRulerViewUnitPoints")]
		Points,

		[Field ("NSRulerViewUnitPicas")]
		Picas,
	}

	delegate void NSSavePanelComplete (nint result);

	[NoMacCatalyst]
	[BaseType (typeof (NSPanel), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSOpenSavePanelDelegate) })]
	[DisableDefaultCtor]
	interface NSSavePanel {
		[Static]
		[Export ("savePanel")]
		[ForcedType] // different type used inside a sandbox
		NSSavePanel SavePanel { get; }

#if !XAMCORE_5_0
		[Advice ("You must use 'SavePanel' method if the application is sandboxed.")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "All save panels now run out-of-process, use 'SavePanel' method instead")]
		[EditorBrowsable (EditorBrowsableState.Never)]
		[Export ("init")]
		NativeHandle Constructor ();
#endif

		[Export ("URL")]
		NSUrl Url { get; }

		[Export ("isExpanded")]
		bool IsExpanded { get; }

		[Export ("validateVisibleColumns")]
		void ValidateVisibleColumns ();

		[Export ("ok:")]
		void Ok (NSObject sender);

		[Export ("cancel:")]
		void Cancel (NSObject sender);

		[Export ("beginSheetModalForWindow:completionHandler:")]
		void BeginSheet (NSWindow window, NSSavePanelComplete onComplete);

		[Export ("beginWithCompletionHandler:")]
		void Begin (NSSavePanelComplete onComplete);

		[Export ("runModal")]
		nint RunModal ();

		//Detected properties
		[Export ("directoryURL", ArgumentSemantic.Copy)]
		NSUrl DirectoryUrl { get; set; }

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'AllowedContentTypes' instead.")]
		[Export ("allowedFileTypes")]
		[NullAllowed]
		string [] AllowedFileTypes { get; set; }

		[Export ("allowedContentTypes", ArgumentSemantic.Copy)]
		UTType [] AllowedContentTypes { get; set; }

		[Export ("allowsOtherFileTypes")]
		bool AllowsOtherFileTypes { get; set; }

		[Export ("accessoryView", ArgumentSemantic.Retain), NullAllowed]
		NSView AccessoryView { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSOpenSavePanelDelegate Delegate { get; set; }

		[Export ("canCreateDirectories")]
		bool CanCreateDirectories { get; set; }

		[Export ("canSelectHiddenExtension")]
		bool CanSelectHiddenExtension { get; set; }

		[Export ("extensionHidden")]
		bool ExtensionHidden { [Bind ("isExtensionHidden")] get; set; }

		[Export ("treatsFilePackagesAsDirectories")]
		bool TreatsFilePackagesAsDirectories { get; set; }

		[Export ("prompt")]
		string Prompt { get; set; }

		[Export ("title")]
		string Title { get; set; }

		[Export ("nameFieldLabel")]
		string NameFieldLabel { get; set; }

		[Export ("nameFieldStringValue")]
		string NameFieldStringValue { get; set; }

		[Export ("message")]
		string Message { get; set; }

		[Export ("showsHiddenFiles")]
		bool ShowsHiddenFiles { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use Url instead.")]
		[Export ("filename")]
		string Filename { get; }

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use DirectoryUrl instead.")]
		[Export ("directory")]
		string Directory { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use AllowedFileTypes instead.")]
		[Export ("requiredFileType")]
		string RequiredFileType { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use Begin with the callback instead.")]
		[Export ("beginSheetForDirectory:file:modalForWindow:modalDelegate:didEndSelector:contextInfo:")]
		void Begin ([NullAllowed] string directory, string filename, NSWindow docWindow, NSObject modalDelegate, Selector selector, IntPtr context);

		[Deprecated (PlatformName.MacOSX, 10, 6, message: "Use RunModal without parameters instead.")]
		[Export ("runModalForDirectory:file:")]
		nint RunModal ([NullAllowed] string directory, [NullAllowed] string filename);

		[Export ("showsTagField")]
		bool ShowsTagField { get; set; }

		[Export ("tagNames", ArgumentSemantic.Copy)]
		string [] TagNames { get; set; }

		[Mac (14, 0)]
		[NullAllowed, Export ("identifier")]
		string Identifier { get; set; }

		[Mac (15, 0)]
		[NullAllowed, Export ("currentContentType", ArgumentSemantic.Copy)]
		UTType CurrentContentType { get; set; }

		[Mac (15, 0)]
		[Export ("showsContentTypes")]
		bool ShowsContentTypes { get; set; }
	}

#if !NET && !__MACCATALYST__
	// This class doesn't show up in any documentation.
	[BaseType (typeof (NSSavePanel))]
	[DisableDefaultCtor] // should not be created by (only returned to) user code
	interface NSRemoteSavePanel { }
#endif



	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSScroller {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use GetScrollerWidth instead.")]
		[Static]
		[Export ("scrollerWidth")]
		nfloat ScrollerWidth { get; }

		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use GetScrollerWidth instead.")]
		[Static]
		[Export ("scrollerWidthForControlSize:")]
		nfloat ScrollerWidthForControlSize (NSControlSize controlSize);

		[Export ("drawParts")]
		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Not used.")]
		void DrawParts ();

		[Export ("rectForPart:")]
		CGRect RectForPart (NSScrollerPart partCode);

		[Export ("checkSpaceForParts")]
		void CheckSpaceForParts ();

		[Export ("usableParts")]
		NSUsableScrollerParts UsableParts { get; }

		[Export ("drawArrow:highlight:")]
		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Scrollers don't have arrows anymore.")]
		void DrawArrow (NSScrollerArrow whichArrow, bool highlight);

		[Export ("drawKnob")]
		void DrawKnob ();

		[Export ("drawKnobSlotInRect:highlight:")]
		void DrawKnobSlot (CGRect slotRect, bool highlight);

		[Export ("highlight:")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "No effect since 10.7.")]
		void Highlight (bool flag);

		[Export ("testPart:")]
		NSScrollerPart TestPart (CGPoint thePoint);

		[Export ("trackKnob:")]
		void TrackKnob (NSEvent theEvent);

		[Export ("trackScrollButtons:")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "No effect since 10.7.")]
		void TrackScrollButtons (NSEvent theEvent);

		[Export ("hitPart")]
		NSScrollerPart HitPart { get; }

		//Detected properties
		[Export ("arrowsPosition")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "No effect since 10.7.")]
		NSScrollArrowPosition ArrowsPosition { get; set; }

		[Export ("controlTint")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "No effect since 10.7.")]
		NSControlTint ControlTint { get; set; }

		[Export ("controlSize")]
		NSControlSize ControlSize { get; set; }

		[Export ("knobProportion")]
		nfloat KnobProportion { get; set; }

		[Static]
		[Export ("isCompatibleWithOverlayScrollers")]
		bool CompatibleWithOverlayScrollers { get; }

		[Export ("knobStyle")]
		NSScrollerKnobStyle KnobStyle { get; set; }

		[Static]
		[Export ("preferredScrollerStyle")]
		NSScrollerStyle PreferredScrollerStyle { get; }

		[Export ("scrollerStyle")]
		NSScrollerStyle ScrollerStyle { get; set; }

		[Static]
		[Export ("scrollerWidthForControlSize:scrollerStyle:")]
		nfloat GetScrollerWidth (NSControlSize forControlSize, NSScrollerStyle scrollerStyle);

		[Notification, Field ("NSPreferredScrollerStyleDidChangeNotification")]
		NSString PreferredStyleChangedNotification { get; }

	}

	/*
	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	partial interface NSScrollView : NSTextFinderBarContainer {
		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Static]
		[Export ("frameSizeForContentSize:hasHorizontalScroller:hasVerticalScroller:borderType:")]
		CGSize FrameSizeForContentSize (CGSize cSize, bool hFlag, bool vFlag, NSBorderType aType);

		[Deprecated (PlatformName.MacOSX, 10, 7)]
		[Static]
		[Export ("contentSizeForFrameSize:hasHorizontalScroller:hasVerticalScroller:borderType:")]
		CGSize ContentSizeForFrame (CGSize fSize, bool hFlag, bool vFlag, NSBorderType aType);

		[Export ("documentVisibleRect")]
		CGRect DocumentVisibleRect { get; }

		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("contentSize")]
		CGSize ContentSize { get; }

		[Export ("tile")]
		void Tile ();

		[Export ("reflectScrolledClipView:")]
		void ReflectScrolledClipView (NSClipView cView);

		[Export ("scrollWheel:")]
		void ScrollWheel (NSEvent theEvent);

		//Detected properties
		[Export ("documentView", ArgumentSemantic.Retain), NullAllowed]
#if NET
		NSView DocumentView { get; set; }
#else
		NSObject DocumentView { get; set; }
#endif

		[Export ("contentView", ArgumentSemantic.Retain)]
		new NSClipView ContentView { get; set; }

		[Export ("documentCursor", ArgumentSemantic.Retain)]
		NSCursor DocumentCursor { get; set; }

		[Export ("borderType")]
		NSBorderType BorderType { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[Export ("hasVerticalScroller")]
		bool HasVerticalScroller { get; set; }

		[Export ("hasHorizontalScroller")]
		bool HasHorizontalScroller { get; set; }

		[Export ("verticalScroller", ArgumentSemantic.Retain)]
		NSScroller VerticalScroller { get; set; }

		[Export ("horizontalScroller", ArgumentSemantic.Retain)]
		NSScroller HorizontalScroller { get; set; }

		[Export ("autohidesScrollers")]
		bool AutohidesScrollers { get; set; }

		[Export ("horizontalLineScroll")]
		nfloat HorizontalLineScroll { get; set; }

		[Export ("verticalLineScroll")]
		nfloat VerticalLineScroll { get; set; }

		[Export ("lineScroll")]
		nfloat LineScroll { get; set; }

		[Export ("horizontalPageScroll")]
		nfloat HorizontalPageScroll { get; set; }

		[Export ("verticalPageScroll")]
		nfloat VerticalPageScroll { get; set; }

		[Export ("pageScroll")]
		nfloat PageScroll { get; set; }

		[Export ("scrollsDynamically")]
		bool ScrollsDynamically { get; set; }

		[Export ("hasVerticalRuler")]
		bool HasVerticalRuler { get; set; }

		[Export ("hasHorizontalRuler")]
		bool HasHorizontalRuler { get; set; }

		[Export ("rulersVisible")]
		bool RulersVisible { get; set; }

		[Export ("horizontalRulerView")]
		NSRulerView HorizontalRulerView { get; set; }

		[Export ("verticalRulerView")]
		NSRulerView VerticalRulerView { get; set; }

		[Static]
		[Export ("contentSizeForFrameSize:horizontalScrollerClass:verticalScrollerClass:borderType:controlSize:scrollerStyle:")]
		CGSize GetContentSizeForFrame (CGSize forFrameSize, [NullAllowed] Class horizontalScrollerClass, [NullAllowed] Class verticalScrollerClass, NSBorderType borderType, NSControlSize controlSize, NSScrollerStyle scrollerStyle);

		[Export ("findBarPosition")]
		NSScrollViewFindBarPosition FindBarPosition { get; set; }

		[Export ("flashScrollers")]
		void FlashScrollers ();

		[Static]
		[Export ("frameSizeForContentSize:horizontalScrollerClass:verticalScrollerClass:borderType:controlSize:scrollerStyle:")]
		CGSize GetFrameSizeForContent (CGSize contentSize, [NullAllowed] Class horizontalScrollerClass, [NullAllowed] Class verticalScrollerClass, NSBorderType borderType, NSControlSize controlSize, NSScrollerStyle scrollerStyle);

		[Export ("horizontalScrollElasticity")]
		NSScrollElasticity HorizontalScrollElasticity { get; set; }

		[Export ("scrollerKnobStyle")]
		NSScrollerKnobStyle ScrollerKnobStyle { get; set; }

		[Export ("scrollerStyle")]
		NSScrollerStyle ScrollerStyle { get; set; }

		[Export ("usesPredominantAxisScrolling")]
		bool UsesPredominantAxisScrolling { get; set; }

		[Export ("verticalScrollElasticity")]
		NSScrollElasticity VerticalScrollElasticity { get; set; }

		[Export ("allowsMagnification")]
		bool AllowsMagnification { get; set; }

		[Export ("magnification")]
		nfloat Magnification { get; set; }

		[Export ("maxMagnification")]
		nfloat MaxMagnification { get; set; }

		[Export ("minMagnification")]
		nfloat MinMagnification { get; set; }

		[Export ("magnifyToFitRect:")]
		void MagnifyToFitRect (CGRect rect);

		[Export ("setMagnification:centeredAtPoint:")]
		void SetMagnification (nfloat magnification, CGPoint centeredAtPoint);

		[Notification, Field ("NSScrollViewWillStartLiveMagnifyNotification")]
		NSString WillStartLiveMagnifyNotification { get; }

		[Notification, Field ("NSScrollViewDidEndLiveMagnifyNotification")]
		NSString DidEndLiveMagnifyNotification { get; }

		[Notification, Field ("NSScrollViewWillStartLiveScrollNotification")]
		NSString WillStartLiveScrollNotification { get; }

		[Notification, Field ("NSScrollViewDidLiveScrollNotification")]
		NSString DidLiveScrollNotification { get; }

		[Notification, Field ("NSScrollViewDidEndLiveScrollNotification")]
		NSString DidEndLiveScrollNotification { get; }

		[Export ("automaticallyAdjustsContentInsets")]
		bool AutomaticallyAdjustsContentInsets { get; set; }

		// @property NSEdgeInsets contentInsets __attribute__((availability(macosx, introduced=10_10)));
		[Export ("contentInsets", ArgumentSemantic.Assign)]
		NSEdgeInsets ContentInsets { get; set; }

		// @property NSEdgeInsets scrollerInsets __attribute__((availability(macosx, introduced=10_10)));
		[Export ("scrollerInsets", ArgumentSemantic.Assign)]
		NSEdgeInsets ScrollerInsets { get; set; }

		[Export ("addFloatingSubview:forAxis:")]
		void AddFloatingSubview (NSView view, NSEventGestureAxis axis);
	}
*/
	[NoMacCatalyst]
	[BaseType (typeof (NSTextField), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSSearchFieldDelegate) })]
	interface NSSearchField {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("recentSearches")]
		string [] RecentSearches { get; set; }

		[Export ("recentsAutosaveName")]
		string RecentsAutosaveName { get; set; }

		[New, Export ("cell")]
		NSSearchFieldCell Cell { get; set; }

		[Export ("searchMenuTemplate", ArgumentSemantic.Retain)]
		NSMenu SearchMenuTemplate { get; set; }

		[Export ("sendsWholeSearchString")]
		bool SendsWholeSearchString { get; set; }

		[Export ("maximumRecents")]
		nint MaximumRecents { get; set; }

		[Export ("sendsSearchStringImmediately")]
		bool SendsSearchStringImmediately { get; set; }

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'SearchTextBounds' instead.")]
		[Export ("rectForSearchTextWhenCentered:")]
		CGRect GetRectForSearchText (bool isCentered);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'SearchButtonBounds' instead.")]
		[Export ("rectForSearchButtonWhenCentered:")]
		CGRect GetRectForSearchButton (bool isCentered);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'CancelButtonBounds' instead.")]
		[Export ("rectForCancelButtonWhenCentered:")]
		CGRect GetRectForCancelButton (bool isCentered);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSSearchFieldDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "No longer availabile, now a no-op.")]
		[Export ("centersPlaceholder")]
		bool CentersPlaceholder { get; set; }

		[Export ("searchTextBounds")]
		CGRect SearchTextBounds { get; }

		[Export ("searchButtonBounds")]
		CGRect SearchButtonBounds { get; }

		[Export ("cancelButtonBounds")]
		CGRect CancelButtonBounds { get; }
	}

	interface INSSearchFieldDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Protocol, Model]
	interface NSSearchFieldDelegate : NSTextFieldDelegate {
		[Export ("searchFieldDidStartSearching:")]
		void SearchingStarted (NSSearchField sender);

		[Export ("searchFieldDidEndSearching:")]
		void SearchingEnded (NSSearchField sender);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextFieldCell))]
	interface NSSearchFieldCell {
		[DesignatedInitializer]
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("searchButtonCell", ArgumentSemantic.Retain)]
		NSButtonCell SearchButtonCell { get; set; }

		[Export ("cancelButtonCell", ArgumentSemantic.Retain)]
		NSButtonCell CancelButtonCell { get; set; }

		[Export ("resetSearchButtonCell")]
		void ResetSearchButtonCell ();

		[Export ("resetCancelButtonCell")]
		void ResetCancelButtonCell ();

		[Export ("searchTextRectForBounds:")]
		CGRect SearchTextRectForBounds (CGRect rect);

		[Export ("searchButtonRectForBounds:")]
		CGRect SearchButtonRectForBounds (CGRect rect);

		[Export ("cancelButtonRectForBounds:")]
		CGRect CancelButtonRectForBounds (CGRect rect);

		[Export ("searchMenuTemplate", ArgumentSemantic.Retain)]
		NSMenu SearchMenuTemplate { get; set; }

		[Export ("sendsWholeSearchString")]
		bool SendsWholeSearchString { get; set; }

		[Export ("maximumRecents")]
		nint MaximumRecents { get; set; }

		[Export ("recentSearches")]
		string [] RecentSearches { get; set; }

		[Export ("recentsAutosaveName")]
		string RecentsAutosaveName { get; set; }

		[Export ("sendsSearchStringImmediately")]
		bool SendsSearchStringImmediately { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSSegmentedControl : NSUserInterfaceCompression {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("selectSegmentWithTag:")]
		bool SelectSegment (nint tag);

		[Export ("setWidth:forSegment:")]
		void SetWidth (nfloat width, nint segment);

		[Export ("widthForSegment:")]
		nfloat GetWidth (nint segment);

		[Export ("setImage:forSegment:")]
		void SetImage ([NullAllowed] NSImage image, nint segment);

		[Export ("imageForSegment:")]
		NSImage GetImage (nint segment);

		[Export ("setImageScaling:forSegment:")]
		void SetImageScaling (NSImageScaling scaling, nint segment);

		[Export ("imageScalingForSegment:")]
		NSImageScaling GetImageScaling (nint segment);

		[Export ("setLabel:forSegment:")]
		void SetLabel ([NullAllowed] string label, nint segment);

		[Export ("labelForSegment:")]
		string GetLabel (nint segment);

		[Export ("setMenu:forSegment:")]
		void SetMenu ([NullAllowed] NSMenu menu, nint segment);

		[Export ("menuForSegment:")]
		NSMenu GetMenu (nint segment);

		[Export ("setSelected:forSegment:")]
		void SetSelected (bool selected, nint segment);

		[Export ("isSelectedForSegment:")]
		bool IsSelectedForSegment (nint segment);

		[Export ("setEnabled:forSegment:")]
		void SetEnabled (bool enabled, nint segment);

		[Export ("isEnabledForSegment:")]
		bool IsEnabled (nint segment);

		//Detected properties
		[Export ("segmentCount")]
		nint SegmentCount { get; set; }

		[Export ("selectedSegment")]
		nint SelectedSegment { get; set; }

		[Export ("segmentStyle")]
		NSSegmentStyle SegmentStyle { get; set; }

		[Export ("springLoaded")]
		bool IsSpringLoaded { [Bind ("isSpringLoaded")] get; set; }

		[Export ("trackingMode")]
		NSSegmentSwitchTracking TrackingMode { get; set; }

		[Export ("doubleValueForSelectedSegment")]
		double GetValueForSelectedSegment (); // actually returns double

		[Static]
		[Internal]
		[Export ("segmentedControlWithLabels:trackingMode:target:action:")]
		NSSegmentedControl _FromLabels (string [] labels, NSSegmentSwitchTracking trackingMode, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Internal]
		[Export ("segmentedControlWithImages:trackingMode:target:action:")]
		NSSegmentedControl _FromImages (NSImage [] images, NSSegmentSwitchTracking trackingMode, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[NullAllowed, Export ("selectedSegmentBezelColor", ArgumentSemantic.Copy)]
		NSColor SelectedSegmentBezelColor { get; set; }

		[Export ("setToolTip:forSegment:")]
		void SetToolTip ([NullAllowed] string toolTip, nint segment);

		[Export ("toolTipForSegment:")]
		[return: NullAllowed]
		string GetToolTip (nint forSegment);

		[Export ("setTag:forSegment:")]
		void SetTag (nint tag, nint segment);

		[Export ("tagForSegment:")]
		nint GetTag (nint segment);

		[Export ("setShowsMenuIndicator:forSegment:")]
		void SetShowsMenuIndicator (bool showsMenuIndicator, nint segment);

		[Export ("showsMenuIndicatorForSegment:")]
		bool ShowsMenuIndicator (nint segment);

		[Export ("setAlignment:forSegment:")]
		void SetAlignment (NSTextAlignment alignment, nint segment);

		[Export ("alignmentForSegment:")]
		NSTextAlignment GetAlignment (nint segment);

		[Export ("segmentDistribution", ArgumentSemantic.Assign)]
		NSSegmentDistribution SegmentDistribution { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell))]
	interface NSSegmentedCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("selectSegmentWithTag:")]
		bool SelectSegment (nint tag);

		[Export ("makeNextSegmentKey")]
		void InsertSegmentAfterSelection ();

		[Export ("makePreviousSegmentKey")]
		void InsertSegmentBeforeSelection ();

		[Export ("setWidth:forSegment:")]
		void SetWidth (nfloat width, nint forSegment);

		[Export ("widthForSegment:")]
		nfloat GetWidth (nint forSegment);

		[Export ("setImage:forSegment:")]
		void SetImage (NSImage image, nint forSegment);

		[Export ("imageForSegment:")]
		NSImage GetImageForSegment (nint forSegment);

		[Export ("setImageScaling:forSegment:")]
		void SetImageScaling (NSImageScaling scaling, nint forSegment);

		[Export ("imageScalingForSegment:")]
		NSImageScaling GetImageScaling (nint forSegment);

		[Export ("setLabel:forSegment:")]
		void SetLabel (string label, nint forSegment);

		[Export ("labelForSegment:")]
		string GetLabel (nint forSegment);

		[Export ("setSelected:forSegment:")]
		void SetSelected (bool selected, nint forSegment);

		[Export ("isSelectedForSegment:")]
		bool IsSelected (nint forSegment);

		[Export ("setEnabled:forSegment:")]
		void SetEnabled (bool enabled, nint forSegment);

		[Export ("isEnabledForSegment:")]
		bool IsEnabled (nint forSegment);

		[Export ("setMenu:forSegment:")]
		void SetMenu (NSMenu menu, nint forSegment);

		[Export ("menuForSegment:")]
		NSMenu GetMenu (nint forSegment);

		[Export ("setToolTip:forSegment:")]
		void SetToolTip ([NullAllowed] string toolTip, nint forSegment);

		[Export ("toolTipForSegment:")]
		[return: NullAllowed]
		string GetToolTip (nint forSegment);

		[Export ("setTag:forSegment:")]
		void SetTag (nint tag, nint forSegment);

		[Export ("tagForSegment:")]
		nint GetTag (nint forSegment);

		[Export ("drawSegment:inFrame:withView:")]
		void DrawSegment (nint segment, CGRect frame, NSView controlView);

		//Detected properties
		[Export ("segmentCount")]
		nint SegmentCount { get; set; }

		[Export ("selectedSegment")]
		nint SelectedSegment { get; set; }

		[Export ("trackingMode")]
		NSSegmentSwitchTracking TrackingMode { get; set; }

		[Export ("segmentStyle")]
		NSSegmentStyle SegmentStyle { get; set; }

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSSlider : NSAccessibilitySlider {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("vertical")]
		// Radar 27222357
#if NET
		bool IsVertical { [Bind ("isVertical")] get; set; }
#else
		nint IsVertical { [Bind ("isVertical")] get; set; }
#endif

		[Export ("acceptsFirstMouse:")]
		bool AcceptsFirstMouse (NSEvent theEvent);

		//Detected properties
		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("altIncrementValue")]
		double AltIncrementValue { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("titleCell")]
		NSObject TitleCell { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("titleColor")]
		NSColor TitleColor { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("titleFont")]
		NSFont TitleFont { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("title")]
		string Title { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("knobThickness")]
		nfloat KnobThickness { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("image")]
		NSImage Image { get; set; }

		[Export ("tickMarkValueAtIndex:")]
		double TickMarkValue (nint index);

		[Export ("rectOfTickMarkAtIndex:")]
		CGRect RectOfTick (nint index);

		[Export ("indexOfTickMarkAtPoint:")]
		nint IndexOfTickMark (CGPoint point);

		[Export ("closestTickMarkValueToValue:")]
		double ClosestTickMarkValue (double value);

		//Detected properties
		[Export ("numberOfTickMarks")]
		nint TickMarksCount { get; set; }

		[Export ("tickMarkPosition")]
		NSTickMarkPosition TickMarkPosition { get; set; }

		[Export ("allowsTickMarkValuesOnly")]
		bool AllowsTickMarkValuesOnly { get; set; }

		[Export ("sliderType")]
		NSSliderType SliderType { get; set; }

		[Static]
		[Internal]
		[Export ("sliderWithTarget:action:")]
		NSSlider _FromTarget ([NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Internal]
		[Export ("sliderWithValue:minValue:maxValue:target:action:")]
		NSSlider _FromValue (double value, double minValue, double maxValue, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[NullAllowed, Export ("trackFillColor", ArgumentSemantic.Copy)]
		NSColor TrackFillColor { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell))]
	interface NSSliderCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Static]
		[Export ("prefersTrackingUntilMouseUp")]
		bool PrefersTrackingUntilMouseUp ();

		[Export ("vertical")]
		// Radar 27222357
#if NET
		bool IsVertical { [Bind ("isVertical")] get; set; }
#else
		nint IsVertical { [Bind ("isVertical")] get; set; }
#endif

		[Export ("knobRectFlipped:")]
		CGRect KnobRectFlipped (bool flipped);

		[Export ("drawKnob:")]
		void DrawKnob (CGRect knobRect);

		[Export ("drawKnob")]
		void DrawKnob ();

		[Export ("drawBarInside:flipped:")]
		void DrawBar (CGRect aRect, bool flipped);

		[Export ("trackRect")]
		CGRect TrackRect { get; }

		//Detected properties
		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("altIncrementValue")]
		double AltIncrementValue { get; set; }

		[Export ("titleColor")]
		[Deprecated (PlatformName.MacOSX, 10, 9)]
		NSColor TitleColor { get; set; }

		[Export ("titleFont")]
		[Deprecated (PlatformName.MacOSX, 10, 9)]
		NSFont TitleFont { get; set; }

		[Export ("title")]
		[Deprecated (PlatformName.MacOSX, 10, 9)]
		string Title { get; set; }

		[Export ("titleCell")]
		[Deprecated (PlatformName.MacOSX, 10, 9)]
		NSObject TitleCell { get; set; }

		[Export ("knobThickness")]
		[Deprecated (PlatformName.MacOSX, 10, 9)]
		nfloat KnobThickness { get; set; }

		[Export ("sliderType")]
		NSSliderType SliderType { get; set; }

		[Export ("tickMarkValueAtIndex:")]
		double TickMarkValue (nint index);

		[Export ("rectOfTickMarkAtIndex:")]
		CGRect RectOfTickMark (nint index);

		[Export ("indexOfTickMarkAtPoint:")]
		nint IndexOfTickMark (CGPoint point);

		[Export ("closestTickMarkValueToValue:")]
		double ClosestTickMarkValue (double value);

		//Detected properties
		[Export ("numberOfTickMarks")]
		nint TickMarks { get; set; }

		[Export ("tickMarkPosition")]
		NSTickMarkPosition TickMarkPosition { get; set; }

		[Export ("allowsTickMarkValuesOnly")]
		bool AllowsTickMarkValuesOnly { get; set; }

		[Export ("barRectFlipped:")]
		CGRect BarRectFlipped (bool flipped);
	}

	

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSSpeechRecognizer {
		[Export ("startListening")]
		void StartListening ();

		[Export ("stopListening")]
		void StopListening ();

		//Detected properties
		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSSpeechRecognizerDelegate Delegate { get; set; }

		[Export ("commands")]
		string [] Commands { get; set; }

		[Export ("displayedCommandsTitle")]
		string DisplayedCommandsTitle { get; set; }

		[Export ("listensInForegroundOnly")]
		bool ListensInForegroundOnly { get; set; }

		[Export ("blocksOtherRecognizers")]
		bool BlocksOtherRecognizers { get; set; }
	}

	interface INSSpeechRecognizerDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSSpeechRecognizerDelegate {
		[Export ("speechRecognizer:didRecognizeCommand:")]
		void DidRecognizeCommand (NSSpeechRecognizer sender, string command);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Deprecated (PlatformName.MacOSX, 14, 0, message: "Use 'AVSpeechSynthesizer' in AVFoundation instead.")]
	interface NSSpeechSynthesizer {
		[Export ("initWithVoice:")]
		NativeHandle Constructor (string voice);

		[Export ("startSpeakingString:")]
		bool StartSpeakingString (string theString);

		[Export ("startSpeakingString:toURL:")]
		bool StartSpeakingStringtoURL (string theString, NSUrl url);

		[Export ("isSpeaking")]
		bool IsSpeaking { get; }

		[Export ("stopSpeaking")]
		void StopSpeaking ();

		[Export ("stopSpeakingAtBoundary:")]
		void StopSpeaking (NSSpeechBoundary boundary);

		[Export ("pauseSpeakingAtBoundary:")]
		void PauseSpeaking (NSSpeechBoundary boundary);

		[Export ("continueSpeaking")]
		void ContinueSpeaking ();

		[Export ("addSpeechDictionary:")]
		void AddSpeechDictionary (NSDictionary speechDictionary);

		[Export ("phonemesFromText:")]
		string PhonemesFromText (string text);

		[Export ("objectForProperty:error:")]
		NSObject ObjectForProperty (string property, out NSError outError);

		[Export ("setObject:forProperty:error:")]
		bool SetObjectforProperty (NSObject theObject, string property, out NSError outError);

		[Static]
		[Export ("isAnyApplicationSpeaking")]
		bool IsAnyApplicationSpeaking { get; }

		[Static]
		[Export ("defaultVoice")]
		string DefaultVoice { get; }

		[Static]
		[Export ("availableVoices")]
		string [] AvailableVoices { get; }

		[Static]
		[Export ("attributesForVoice:")]
		NSDictionary AttributesForVoice (string voice);

		//Detected properties
		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSSpeechSynthesizerDelegate Delegate { get; set; }

		[Export ("voice"), Protected]
		string GetVoice ();

		[Export ("setVoice:"), Protected]
		bool SetVoice (string voice);

		[Export ("rate")]
		float Rate { get; set; } /* float, not CGFloat */

		[Export ("volume")]
		float Volume { get; set; } /* float, not CGFloat */

		[Export ("usesFeedbackWindow")]
		bool UsesFeedbackWindow { get; set; }
	}

	interface INSSpeechSynthesizerDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	[Deprecated (PlatformName.MacOSX, 14, 0, message: "Use 'AVSpeechSynthesizer' in AVFoundation instead.")]
	interface NSSpeechSynthesizerDelegate {
		[Export ("speechSynthesizer:didFinishSpeaking:")]
		void DidFinishSpeaking (NSSpeechSynthesizer sender, bool finishedSpeaking);

		[Export ("speechSynthesizer:willSpeakWord:ofString:")]
		void WillSpeakWord (NSSpeechSynthesizer sender, NSRange wordCharacterRange, string ofString);

		[Export ("speechSynthesizer:willSpeakPhoneme:")]
		void WillSpeakPhoneme (NSSpeechSynthesizer sender, short phonemeOpcode);

		[Export ("speechSynthesizer:didEncounterErrorAtIndex:ofString:message:")]
		void DidEncounterError (NSSpeechSynthesizer sender, nuint characterIndex, string theString, string message);

		[Export ("speechSynthesizer:didEncounterSyncMessage:")]
		void DidEncounterSyncMessage (NSSpeechSynthesizer sender, string message);
	}

	[NoMacCatalyst]
	[StrongDictionary ("NSTextCheckingKey")]
	interface NSTextCheckingOptions {
		NSOrthography Orthography { get; set; }
		string [] Quotes { get; set; }
		NSDictionary Replacements { get; set; }
		NSDate ReferenceDate { get; set; }
		NSTimeZone ReferenceTimeZone { get; set; }
		NSUrl DocumentUrl { get; set; }
		string DocumentTitle { get; set; }
		string DocumentAuthor { get; set; }
	}

	[NoMacCatalyst]
	[Internal, Static]
	interface NSTextCheckingKey {
		[Field ("NSTextCheckingOrthographyKey")]
		NSString OrthographyKey { get; }
		[Field ("NSTextCheckingQuotesKey")]
		NSString QuotesKey { get; }
		[Field ("NSTextCheckingReplacementsKey")]
		NSString ReplacementsKey { get; }
		[Field ("NSTextCheckingReferenceDateKey")]
		NSString ReferenceDateKey { get; }
		[Field ("NSTextCheckingReferenceTimeZoneKey")]
		NSString ReferenceTimeZoneKey { get; }
		[Field ("NSTextCheckingDocumentURLKey")]
		NSString DocumentUrlKey { get; }
		[Field ("NSTextCheckingDocumentTitleKey")]
		NSString DocumentTitleKey { get; }
		[Field ("NSTextCheckingDocumentAuthorKey")]
		NSString DocumentAuthorKey { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface NSSpellChecker {
		[Static]
		[Export ("sharedSpellChecker")]
		NSSpellChecker SharedSpellChecker { get; }

		[Static]
		[Export ("sharedSpellCheckerExists")]
		bool SharedSpellCheckerExists { get; }

		[Static]
		[Export ("uniqueSpellDocumentTag")]
		nint UniqueSpellDocumentTag { get; }

		[Export ("checkSpellingOfString:startingAt:language:wrap:inSpellDocumentWithTag:wordCount:")]
		NSRange CheckSpelling (string stringToCheck, nint startingOffset, string language, bool wrapFlag, nint documentTag, out nint wordCount);

		[Export ("checkSpellingOfString:startingAt:")]
		NSRange CheckSpelling (string stringToCheck, nint startingOffset);

		[Export ("countWordsInString:language:")]
		nint CountWords (string stringToCount, string language);

		[Export ("checkGrammarOfString:startingAt:language:wrap:inSpellDocumentWithTag:details:")]
		NSRange CheckGrammar (string stringToCheck, nint startingOffset, string language, bool wrapFlag, nint documentTag, NSDictionary [] details);

		[Export ("checkString:range:types:options:inSpellDocumentWithTag:orthography:wordCount:")]
		NSTextCheckingResult [] CheckString (string stringToCheck, NSRange range, NSTextCheckingTypes checkingTypes, [NullAllowed] NSDictionary options, nint tag, out NSOrthography orthography, out nint wordCount);

		[Wrap ("CheckString (stringToCheck, range, checkingTypes, options.GetDictionary (), tag, out orthography, out wordCount)")]
		NSTextCheckingResult [] CheckString (string stringToCheck, NSRange range, NSTextCheckingTypes checkingTypes, NSTextCheckingOptions options, nint tag, out NSOrthography orthography, out nint wordCount);

		[Export ("requestCheckingOfString:range:types:options:inSpellDocumentWithTag:completionHandler:")]
		nint RequestChecking (string stringToCheck, NSRange range, NSTextCheckingTypes checkingTypes, [NullAllowed] NSDictionary options, nint tag, Action<nint, NSTextCheckingResult [], NSOrthography, nint> completionHandler);

		[Wrap ("RequestChecking (stringToCheck, range, checkingTypes, options.GetDictionary (), tag, completionHandler)")]
		nint RequestChecking (string stringToCheck, NSRange range, NSTextCheckingTypes checkingTypes, NSTextCheckingOptions options, nint tag, Action<nint, NSTextCheckingResult [], NSOrthography, nint> completionHandler);

		[Export ("menuForResult:string:options:atLocation:inView:")]
		NSMenu MenuForResults (NSTextCheckingResult result, string checkedString, NSDictionary options, CGPoint location, NSView view);

		[Wrap ("MenuForResults (result, checkedString, options.GetDictionary ()!, location, view)")]
		NSMenu MenuForResults (NSTextCheckingResult result, string checkedString, NSTextCheckingOptions options, CGPoint location, NSView view);

		[Export ("userQuotesArrayForLanguage:")]
		string [] UserQuotesArrayForLanguage (string language);

		[Export ("userReplacementsDictionary")]
		NSDictionary UserReplacementsDictionary { get; }

		[Export ("updateSpellingPanelWithMisspelledWord:")]
		void UpdateSpellingPanelWithMisspelledWord (string word);

		[Export ("updateSpellingPanelWithGrammarString:detail:")]
		void UpdateSpellingPanelWithGrammarl (string theString, NSDictionary detail);

		[Export ("spellingPanel")]
		NSPanel SpellingPanel { get; }

		[Export ("substitutionsPanel")]
		NSPanel SubstitutionsPanel { get; }

		[Export ("updatePanels")]
		void UpdatePanels ();

		[Export ("ignoreWord:inSpellDocumentWithTag:")]
		void IgnoreWord (string wordToIgnore, nint documentTag);

		[Export ("ignoredWordsInSpellDocumentWithTag:")]
		string [] IgnoredWords (nint documentTag);

		[Export ("setIgnoredWords:inSpellDocumentWithTag:")]
		void SetIgnoredWords (string [] words, nint documentTag);

		[Export ("guessesForWordRange:inString:language:inSpellDocumentWithTag:")]
		string [] GuessesForWordRange (NSRange range, string theString, string language, nint documentTag);

		[Export ("completionsForPartialWordRange:inString:language:inSpellDocumentWithTag:")]
		string [] CompletionsForPartialWordRange (NSRange range, string theString, string language, nint documentTag);

		[Export ("closeSpellDocumentWithTag:")]
		void CloseSpellDocument (nint documentTag);

		[Export ("availableLanguages")]
		string [] AvailableLanguages { get; }

		[Export ("userPreferredLanguages")]
		string [] UserPreferredLanguages { get; }

		[Export ("setWordFieldStringValue:")]
		void SetWordFieldStringValue (string aString);

		[Export ("learnWord:")]
		void LearnWord (string word);

		[Export ("hasLearnedWord:")]
		bool HasLearnedWord (string word);

		[Export ("unlearnWord:")]
		void UnlearnWord (string word);

		//Detected properties
		[Export ("accessoryView", ArgumentSemantic.Retain), NullAllowed]
		NSView AccessoryView { get; set; }

		[Export ("substitutionsPanelAccessoryViewController", ArgumentSemantic.Retain)]
		NSViewController SubstitutionsPanelAccessoryViewController { get; set; }

		[Export ("automaticallyIdentifiesLanguages")]
		bool AutomaticallyIdentifiesLanguages { get; set; }

		[Export ("language"), Protected]
		string GetLanguage ();

		[Export ("setLanguage:"), Protected]
		bool SetLanguage (string language);

		[Static, Export ("isAutomaticQuoteSubstitutionEnabled")]
		bool IsAutomaticQuoteSubstitutionEnabled ();

		[Static, Export ("isAutomaticDashSubstitutionEnabled")]
		bool IsAutomaticDashSubstitutionEnabled ();

		[Static]
		[Export ("isAutomaticCapitalizationEnabled")]
		bool IsAutomaticCapitalizationEnabled { get; }

		[Static]
		[Export ("isAutomaticPeriodSubstitutionEnabled")]
		bool IsAutomaticPeriodSubstitutionEnabled { get; }

		[Export ("preventsAutocorrectionBeforeString:language:")]
		bool PreventsAutocorrectionBefore (string aString, [NullAllowed] string language);

		[Static]
		[Export ("isAutomaticTextCompletionEnabled")]
		bool IsAutomaticTextCompletionEnabled { get; }

#if NET
		[Async (ResultTypeName="NSSpellCheckerCandidates")]
#else
		[Async (ResultTypeName = "NSSpellCheckerCanidates")]
#endif
		[Export ("requestCandidatesForSelectedRange:inString:types:options:inSpellDocumentWithTag:completionHandler:")]
		nint RequestCandidates (NSRange selectedRange, string stringToCheck, ulong checkingTypes, [NullAllowed] NSDictionary<NSString, NSObject> options, nint tag, [NullAllowed] Action<nint, NSTextCheckingResult []> completionHandler);

		[Export ("deletesAutospaceBetweenString:andString:language:")]
		bool DeletesAutospace (string precedingString, string followingString, [NullAllowed] string language);

		[Notification]
		[NoMacCatalyst, Mac (14, 0)]
		[Field ("NSSpellCheckerDidChangeAutomaticInlinePredictionNotification")]
		NSString DidChangeAutomaticInlinePredictionNotification { get; }

		[NoMacCatalyst, Mac (14, 0)]
		[Export ("showInlinePredictionForCandidates:client:")]
		void ShowInlinePrediction (NSTextCheckingResult [] candidates, INSTextInputClient client);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject), Delegates = new string [] { "WeakDelegate" }, Events = new Type [] { typeof (NSSoundDelegate) })]
	[DisableDefaultCtor] // no valid handle is returned
	partial interface NSSound : NSSecureCoding, NSCopying, NSPasteboardReading, NSPasteboardWriting {
		[Static]
		[Export ("soundNamed:")]
		NSSound FromName (string name);

		[Export ("initWithContentsOfURL:byReference:")]
		NativeHandle Constructor (NSUrl url, bool byRef);

		[Export ("initWithContentsOfFile:byReference:")]
		NativeHandle Constructor (string path, bool byRef);

		[Export ("initWithData:")]
		NativeHandle Constructor (NSData data);

		[Static]
		[Export ("canInitWithPasteboard:")]
		bool CanCreateFromPasteboard (NSPasteboard pasteboard);

		[Static]
		[Export ("soundUnfilteredTypes", ArgumentSemantic.Copy)]
		string [] SoundUnfilteredTypes ();

		[Export ("initWithPasteboard:")]
		NativeHandle Constructor (NSPasteboard pasteboard);

		[Export ("writeToPasteboard:")]
		void WriteToPasteboard (NSPasteboard pasteboard);

		[Export ("play")]
		bool Play ();

		[Export ("pause")]
		bool Pause ();

		[Export ("resume")]
		bool Resume ();

		[Export ("stop")]
		bool Stop ();

		[Export ("isPlaying")]
		bool IsPlaying ();

		[Export ("duration")]
		double Duration ();

		//Detected properties
		[Export ("name"), Protected]
		string GetName ();

		[Export ("setName:"), Protected]
		bool SetName (string name);

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSSoundDelegate Delegate { get; set; }

		[Export ("volume")]
		float Volume { get; set; } /* float, not CGFloat */

		[Export ("currentTime")]
		double CurrentTime { get; set; }

		[Export ("loops")]
		bool Loops { get; set; }

		[Export ("playbackDeviceIdentifier")]
		string PlaybackDeviceID { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 9)]
		[Export ("channelMapping")]
		NSObject ChannelMapping { get; set; }
	}

	interface INSSoundDelegate { }

	[NoMacCatalyst]
	[Model, BaseType (typeof (NSObject))]
	[Protocol]
	interface NSSoundDelegate {
		[Export ("sound:didFinishPlaying:"), EventArgs ("NSSoundFinished")]
		void DidFinishPlaying (NSSound sound, bool finished);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	partial interface NSSplitView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("drawDividerInRect:")]
		void DrawDivider (CGRect rect);

		[Export ("dividerColor")]
		NSColor DividerColor { get; }

		[Export ("dividerThickness")]
		nfloat DividerThickness { get; }

		[Export ("adjustSubviews")]
		void AdjustSubviews ();

		[Export ("isSubviewCollapsed:")]
		bool IsSubviewCollapsed (NSView subview);

		[Export ("minPossiblePositionOfDividerAtIndex:")]
		nfloat MinPositionOfDivider (nint dividerIndex);

		[Export ("maxPossiblePositionOfDividerAtIndex:")]
		nfloat MaxPositionOfDivider (nint dividerIndex);

		[Export ("setPosition:ofDividerAtIndex:")]
		void SetPositionOfDivider (nfloat position, nint dividerIndex);

		//Detected properties
		[Export ("vertical")]
		bool IsVertical { [Bind ("isVertical")] get; set; }

		[Export ("dividerStyle")]
		NSSplitViewDividerStyle DividerStyle { get; set; }

		[Export ("autosaveName")]
		string AutosaveName { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSSplitViewDelegate Delegate { get; set; }

		[Export ("arrangesAllSubviews")]
		bool ArrangesAllSubviews { get; set; }

		[Export ("arrangedSubviews", ArgumentSemantic.Copy)]
		NSView [] ArrangedSubviews { get; }

		[Export ("addArrangedSubview:")]
		void AddArrangedSubview (NSView view);

		[Export ("insertArrangedSubview:atIndex:")]
		void InsertArrangedSubview (NSView view, nint index);

		[Export ("removeArrangedSubview:")]
		void RemoveArrangedSubview (NSView view);

		[Export ("holdingPriorityForSubviewAtIndex:")]
		float /*NSLayoutPriority*/ HoldingPriorityForSubview (nint subviewIndex);

		[Export ("setHoldingPriority:forSubviewAtIndex:")]
		void SetHoldingPriority (float /*NSLayoutPriority*/ priority, nint subviewIndex);

		[Notification (typeof (NSSplitViewDividerIndexEventArgs))]
		[Field ("NSSplitViewWillResizeSubviewsNotification")]
		NSString NSSplitViewWillResizeSubviewsNotification { get; }

		[Notification (typeof (NSSplitViewDividerIndexEventArgs))]
		[Field ("NSSplitViewDidResizeSubviewsNotification")]
		NSString NSSplitViewDidResizeSubviewsNotification { get; }
	}

	interface INSSplitViewDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSViewController))]
	interface NSSplitViewController : NSSplitViewDelegate, NSUserInterfaceValidations {
		[Export ("initWithNibName:bundle:")]
		NativeHandle Constructor ([NullAllowed] string nibNameOrNull, [NullAllowed] NSBundle nibBundleOrNull);

		[Export ("splitView", ArgumentSemantic.Strong)]
		NSSplitView SplitView { get; set; }

		[Export ("splitViewItems", ArgumentSemantic.Copy)]
		NSSplitViewItem [] SplitViewItems { get; set; }

		[Export ("addSplitViewItem:")]
		void AddSplitViewItem (NSSplitViewItem splitViewItem);

		[Export ("insertSplitViewItem:atIndex:")]
		void InsertSplitViewItem (NSSplitViewItem splitViewItem, nint index);

		[Export ("removeSplitViewItem:")]
		void RemoveSplitViewItem (NSSplitViewItem splitViewItem);

		[Export ("splitViewItemForViewController:")]
		NSSplitViewItem GetSplitViewItem (NSViewController viewController);

		[Export ("minimumThicknessForInlineSidebars", ArgumentSemantic.Assign)]
		nfloat MinimumThicknessForInlineSidebars { get; set; }

		[Export ("toggleSidebar:")]
		void ToggleSidebar ([NullAllowed] NSObject sender);

		[Field ("NSSplitViewControllerAutomaticDimension")]
		nfloat AutomaticDimension { get; }

		// 'new' since it's inlined from NSSplitViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("splitView:additionalEffectiveRectOfDividerAtIndex:")]
		new CGRect GetAdditionalEffectiveRect (NSSplitView splitView, nint dividerIndex);

		// 'new' since it's inlined from NSSplitViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("splitView:canCollapseSubview:")]
		new bool CanCollapse (NSSplitView splitView, NSView subview);

		// 'new' since it's inlined from NSSplitViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("splitView:effectiveRect:forDrawnRect:ofDividerAtIndex:")]
		new CGRect GetEffectiveRect (NSSplitView splitView, CGRect proposedEffectiveRect, CGRect drawnRect, nint dividerIndex);

		// 'new' since it's inlined from NSSplitViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("splitView:shouldHideDividerAtIndex:")]
		new bool ShouldHideDivider (NSSplitView splitView, nint dividerIndex);

		// 'new' since it's inlined from NSSplitViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("splitView:shouldCollapseSubview:forDoubleClickOnDividerAtIndex:")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "This delegate method is never called, and NSSplitViewController's implementation always returns false.")]
		new bool ShouldCollapseForDoubleClick (NSSplitView splitView, NSView subview, nint doubleClickAtDividerIndex);

		[Mac (14, 0)]
		[Export ("toggleInspector:")]
		void ToggleInspector ([NullAllowed] NSObject sender);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSSplitViewItem : NSAnimatablePropertyContainer, NSCoding {
		[Export ("viewController", ArgumentSemantic.Strong)]
		NSViewController ViewController { get; set; }

		[Export ("collapsed")]
		bool Collapsed { [Bind ("isCollapsed")] get; set; }

		[Export ("canCollapse")]
		bool CanCollapse { get; set; }

		[Export ("holdingPriority")]
		float HoldingPriority { get; set; } /* NSLayoutPriority = float */

		[Static, Export ("splitViewItemWithViewController:")]
		NSSplitViewItem FromViewController (NSViewController viewController);

		[Static]
		[Export ("sidebarWithViewController:")]
		NSSplitViewItem CreateSidebar (NSViewController viewController);

		[Static]
		[Export ("contentListWithViewController:")]
		NSSplitViewItem CreateContentList (NSViewController viewController);

		[Export ("behavior")]
		NSSplitViewItemBehavior Behavior { get; }

		[Export ("minimumThickness", ArgumentSemantic.Assign)]
		nfloat MinimumThickness { get; set; }

		[Export ("maximumThickness", ArgumentSemantic.Assign)]
		nfloat MaximumThickness { get; set; }

		[Export ("preferredThicknessFraction", ArgumentSemantic.Assign)]
		nfloat PreferredThicknessFraction { get; set; }

		[Export ("automaticMaximumThickness", ArgumentSemantic.Assign)]
		nfloat AutomaticMaximumThickness { get; set; }

		[Export ("springLoaded")]
		bool SpringLoaded { [Bind ("isSpringLoaded")] get; set; }

		[Field ("NSSplitViewItemUnspecifiedDimension")]
		nfloat UnspecifiedDimension { get; }

		[Export ("allowsFullHeightLayout")]
		bool AllowsFullHeightLayout { get; set; }

		[Export ("titlebarSeparatorStyle", ArgumentSemantic.Assign)]
		NSTitlebarSeparatorStyle TitlebarSeparatorStyle { get; set; }

		[Mac (10, 14)]
		[Export ("canCollapseFromWindowResize")]
		bool CanCollapseFromWindowResize { get; set; }

		[Static]
		[Export ("inspectorWithViewController:")]
		NSSplitViewItem CreateInspector (NSViewController viewController);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model, Protocol]
	interface NSSplitViewDelegate {
		[Export ("splitView:canCollapseSubview:")]
		[DefaultValue (true)]
		bool CanCollapse (NSSplitView splitView, NSView subview);

		[Export ("splitView:shouldCollapseSubview:forDoubleClickOnDividerAtIndex:")]
		[DefaultValue (true)]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "This delegate method is never called.")]
		bool ShouldCollapseForDoubleClick (NSSplitView splitView, NSView subview, nint doubleClickAtDividerIndex);

		[Export ("splitView:constrainMinCoordinate:ofSubviewAt:")]
		nfloat SetMinCoordinateOfSubview (NSSplitView splitView, nfloat proposedMinimumPosition, nint subviewDividerIndex);

		[Export ("splitView:constrainMaxCoordinate:ofSubviewAt:")]
		nfloat SetMaxCoordinateOfSubview (NSSplitView splitView, nfloat proposedMaximumPosition, nint subviewDividerIndex);

		[Export ("splitView:constrainSplitPosition:ofSubviewAt:")]
		nfloat ConstrainSplitPosition (NSSplitView splitView, nfloat proposedPosition, nint subviewDividerIndex);

		[Export ("splitView:resizeSubviewsWithOldSize:")]
		void Resize (NSSplitView splitView, CGSize oldSize);

		[Export ("splitView:shouldAdjustSizeOfSubview:")]
		[DefaultValue (true)]
		bool ShouldAdjustSize (NSSplitView splitView, NSView view);

		[Export ("splitView:shouldHideDividerAtIndex:")]
		[DefaultValue (false)]
		bool ShouldHideDivider (NSSplitView splitView, nint dividerIndex);

		[Export ("splitView:effectiveRect:forDrawnRect:ofDividerAtIndex:")]
		CGRect GetEffectiveRect (NSSplitView splitView, CGRect proposedEffectiveRect, CGRect drawnRect, nint dividerIndex);

		[Export ("splitView:additionalEffectiveRectOfDividerAtIndex:")]
		CGRect GetAdditionalEffectiveRect (NSSplitView splitView, nint dividerIndex);

		[Export ("splitViewWillResizeSubviews:")]
		void SplitViewWillResizeSubviews (NSNotification notification);

		[Export ("splitViewDidResizeSubviews:")]
		void DidResizeSubviews (NSNotification notification);
	}

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSSpringLoadingDestination {
		[Abstract]
		[Export ("springLoadingActivated:draggingInfo:")]
#if NET
		void Activated (bool activated, INSDraggingInfo draggingInfo);
#else
		void Activated (bool activated, NSDraggingInfo draggingInfo);
#endif

		[Abstract]
		[Export ("springLoadingHighlightChanged:")]
#if NET
		void HighlightChanged (INSDraggingInfo draggingInfo);
#else
		void HighlightChanged (NSDraggingInfo draggingInfo);
#endif

		[Export ("springLoadingEntered:")]
#if NET
		NSSpringLoadingOptions Entered (INSDraggingInfo draggingInfo);
#else
		NSSpringLoadingOptions Entered (NSDraggingInfo draggingInfo);
#endif

		[Export ("springLoadingUpdated:")]
#if NET
		NSSpringLoadingOptions Updated (INSDraggingInfo draggingInfo);
#else
		NSSpringLoadingOptions Updated (NSDraggingInfo draggingInfo);
#endif

		[Export ("springLoadingExited:")]
#if NET
		void Exited (INSDraggingInfo draggingInfo);
#else
		void Exited (NSDraggingInfo draggingInfo);
#endif

		[Export ("draggingEnded:")]
#if NET
		void DraggingEnded (INSDraggingInfo draggingInfo);
#else
		void DraggingEnded (NSDraggingInfo draggingInfo);
#endif
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSStackView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("delegate", ArgumentSemantic.Weak)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSStackViewDelegate Delegate { get; set; }

		[Export ("orientation")]
		NSUserInterfaceLayoutOrientation Orientation { get; set; }

		[Export ("alignment")]
		NSLayoutAttribute Alignment { get; set; }

		[Export ("edgeInsets")]
		NSEdgeInsets EdgeInsets { get; set; }

		[Export ("views", ArgumentSemantic.Copy)]
		NSView [] Views { get; }

		[Export ("detachedViews", ArgumentSemantic.Copy)]
		NSView [] DetachedViews { get; }

		[Export ("spacing")]
		nfloat Spacing { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Set Distribution to NSStackViewDistribution.EqualSpacing instead.")]
		[Export ("hasEqualSpacing")]
		bool HasEqualSpacing { get; set; }

		[Static, Export ("stackViewWithViews:")]
		NSStackView FromViews (NSView [] views);

		[Export ("addView:inGravity:")]
		void AddView (NSView aView, NSStackViewGravity gravity);

		[Export ("insertView:atIndex:inGravity:")]
		void InsertView (NSView aView, nuint index, NSStackViewGravity gravity);

		[Export ("removeView:")]
		void RemoveView (NSView aView);

		[Export ("viewsInGravity:")]
		NSView [] ViewsInGravity (NSStackViewGravity gravity);

		[Export ("setViews:inGravity:")]
		void SetViews (NSView [] views, NSStackViewGravity gravity);

		[Export ("setVisibilityPriority:forView:")]
		void SetVisibilityPriority (float /* NSStackViewVisibilityPriority = float */ priority, NSView aView);

		[Export ("visibilityPriorityForView:")]
		float /* NSStackViewVisibilityPriority = float */ VisibilityPriority (NSView aView);

		[Export ("setCustomSpacing:afterView:")]
		void SetCustomSpacing (nfloat spacing, NSView aView);

		[Export ("customSpacingAfterView:")]
		nfloat CustomSpacingAfterView (NSView aView);

		[Export ("clippingResistancePriorityForOrientation:")]
		float /* NSLayoutPriority = float */ ClippingResistancePriorityForOrientation (NSLayoutConstraintOrientation orientation);

		[Export ("setClippingResistancePriority:forOrientation:")]
		void SetClippingResistancePriority (float /* NSLayoutPriority = float */ clippingResistancePriority, NSLayoutConstraintOrientation orientation);

		[Export ("huggingPriorityForOrientation:")]
		float /* NSLayoutPriority = float */ HuggingPriority (NSLayoutConstraintOrientation orientation);

		[Export ("setHuggingPriority:forOrientation:")]
		void SetHuggingPriority (float /* NSLayoutPriority = float */ huggingPriority, NSLayoutConstraintOrientation orientation);

		[Export ("detachesHiddenViews")]
		bool DetachesHiddenViews { get; set; }

		[Export ("distribution", ArgumentSemantic.Assign)]
		NSStackViewDistribution Distribution { get; set; }

		[Export ("arrangedSubviews", ArgumentSemantic.Copy)]
		//		[Verify (StronglyTypedNSArray)]
		NSView [] ArrangedSubviews { get; }

		[Export ("addArrangedSubview:")]
		void AddArrangedSubview (NSView view);

		[Export ("insertArrangedSubview:atIndex:")]
		void InsertArrangedSubview (NSView view, nint index);

		[Export ("removeArrangedSubview:")]
		void RemoveArrangedSubview (NSView view);
	}

	interface INSStackViewDelegate { }

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSStackViewDelegate {
		[Export ("stackView:willDetachViews:"), DelegateName ("NSStackViewEvent")]
		void WillDetachViews (NSStackView stackView, NSView [] views);

		[Export ("stackView:didReattachViews:"), DelegateName ("NSStackViewEvent")]
		void DidReattachViews (NSStackView stackView, NSView [] views);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface NSStatusBar {
		[Static, Export ("systemStatusBar")]
		NSStatusBar SystemStatusBar { get; }

		[Export ("statusItemWithLength:")]
		NSStatusItem CreateStatusItem (nfloat length);

		[Export ("removeStatusItem:")]
		void RemoveStatusItem (NSStatusItem item);

		[Export ("isVertical")]
		bool IsVertical { get; }

		[Export ("thickness")]
		nfloat Thickness { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSButton))]
	interface NSStatusBarButton {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("appearsDisabled")]
		bool AppearsDisabled { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[PrivateDefaultCtor]
	partial interface NSStatusItem {
		[Export ("statusBar")]
		NSStatusBar StatusBar { get; }

		[Export ("length")]
		nfloat Length { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("action"), NullAllowed]
		Selector Action { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("sendActionOn:")]
		nint SendActionOn (NSTouchPhase mask);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'Menu' instead.")]
		[Export ("popUpStatusItemMenu:")]
		void PopUpStatusItemMenu (NSMenu menu);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use standard button instead.")]
		[Export ("drawStatusBarBackgroundInRect:withHighlight:")]
		void DrawStatusBarBackground (CGRect rect, bool highlight);

		//Detected properties
		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[NullAllowed]
		[Export ("doubleAction")]
		Selector DoubleAction { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("target", ArgumentSemantic.Assign), NullAllowed]
		NSObject Target { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("title")]
		string Title { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("attributedTitle")]
		NSAttributedString AttributedTitle { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("image")]
		NSImage Image { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("alternateImage")]
		NSImage AlternateImage { get; set; }

		[Export ("menu", ArgumentSemantic.Retain)]
		[NullAllowed]
		NSMenu Menu { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("toolTip"), NullAllowed]
		string ToolTip { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("highlightMode")]
		bool HighlightMode { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Soft-deprecation, forwards message to button, but will be gone in the future.")]
		[Export ("view")]
		[NullAllowed]
		NSView View { get; set; }

		[Export ("button", ArgumentSemantic.Retain)]
		NSStatusBarButton Button { get; }

		[Export ("behavior", ArgumentSemantic.Assign)]
		NSStatusItemBehavior Behavior { get; set; }

		[Export ("visible")]
		bool Visible { [Bind ("isVisible")] get; set; }

		[Export ("autosaveName")]
		string AutosaveName { get; set; }
	}

	[Static]
	[NoMacCatalyst]
	public partial static class NSStringAttributeKey {
		[Field ("NSFontAttributeName")]
		public static NSString Font { get; }

		[Field ("NSParagraphStyleAttributeName")]
		public static NSString ParagraphStyle { get; }

		[Field ("NSForegroundColorAttributeName")]
	    public static NSString ForegroundColor { get; }

		[Field ("NSUnderlineStyleAttributeName")]
	    public static NSString UnderlineStyle { get; }

		[Field ("NSSuperscriptAttributeName")]
	    public static NSString Superscript { get; }

		[Field ("NSBackgroundColorAttributeName")]
	    public static NSString BackgroundColor { get; }

		[Field ("NSAttachmentAttributeName")]
		public static NSString Attachment { get; }

		[Field ("NSLigatureAttributeName")]
		public static NSString Ligature { get; }

		[Field ("NSBaselineOffsetAttributeName")]
		public static NSString BaselineOffset { get; }

		[Field ("NSKernAttributeName")]
		public static NSString KerningAdjustment { get; }

		[Field ("NSTrackingAttributeName")]
		public static NSString Tracking { get; }

		[Field ("NSLinkAttributeName")]
		public static NSString Link { get; }

		[Field ("NSStrokeWidthAttributeName")]
		public static NSString StrokeWidth { get; }

		[Field ("NSStrokeColorAttributeName")]
		public static NSString StrokeColor { get; }

		[Field ("NSUnderlineColorAttributeName")]
		public static NSString UnderlineColor { get; }

		[Field ("NSStrikethroughStyleAttributeName")]
		public static NSString StrikethroughStyle { get; }

		[Field ("NSStrikethroughColorAttributeName")]
		public static NSString StrikethroughColor { get; }

		[Field ("NSShadowAttributeName")]
		public static NSString Shadow { get; }

		[Field ("NSObliquenessAttributeName")]
		public static NSString Obliqueness { get; }

		[Field ("NSExpansionAttributeName")]
		public static NSString Expansion { get; }

		[Field ("NSCursorAttributeName")]
		public static NSString Cursor { get; }

		[Field ("NSToolTipAttributeName")]
		public static NSString ToolTip { get; }

		[Field ("NSCharacterShapeAttributeName")]
		public static NSString CharacterShape { get; }

		[Field ("NSGlyphInfoAttributeName")]
		public static NSString GlyphInfo { get; }

		[Field ("NSWritingDirectionAttributeName")]
		public static NSString WritingDirection { get; }

		[Field ("NSMarkedClauseSegmentAttributeName")]
		public static NSString MarkedClauseSegment { get; }

		[Field ("NSSpellingStateAttributeName")]
		public static NSString SpellingState { get; }

		[Field ("NSVerticalGlyphFormAttributeName")]
		public static NSString VerticalGlyphForm { get; }

		[Field ("NSTextAlternativesAttributeName")]
		public static NSString TextAlternatives { get; }

		[Field ("NSTextEffectAttributeName")]
		public static NSString TextEffect { get; }

		// Internal
		[Internal, Field ("NSFileTypeDocumentOption")]
		public static NSString NSFileTypeDocumentOption { get; }

		[Internal, Field ("NSTargetTextScalingDocumentOption")]
		public static NSString TargetTextScalingDocumentOption { get; }

		[Internal, Field ("NSSourceTextScalingDocumentOption")]
		public static NSString SourceTextScalingDocumentOption { get; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSTextHighlightStyleAttributeName")]
		public static NSString TextHighlightStyle { get; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSTextHighlightColorSchemeAttributeName")]
		public static NSString TextHighlightColorScheme { get; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSAdaptiveImageGlyphAttributeName")]
		public static NSString AdaptiveImageGlyph { get; }

		[TV (18, 2), Mac (15, 2), iOS (18, 2), MacCatalyst (18, 2)]
		[Field ("NSWritingToolsExclusionAttributeName")]
		public static NSString WritingToolsExclusion { get; }
	}

	delegate NSObject NSStoryboardControllerCreator (NSCoder coder);

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSStoryboard {
		[Static, Export ("storyboardWithName:bundle:")]
		NSStoryboard FromName (string name, [NullAllowed] NSBundle storyboardBundleOrNil);

		[Export ("instantiateInitialController")]
		NSObject InstantiateInitialController ();

		[Export ("instantiateControllerWithIdentifier:")]
		NSObject InstantiateControllerWithIdentifier (string identifier);

		[Static]
		[NullAllowed, Export ("mainStoryboard", ArgumentSemantic.Strong)]
		NSStoryboard MainStoryboard { get; }

		[Export ("instantiateInitialControllerWithCreator:")]
		[return: NullAllowed]
		NSViewController InstantiateInitialController ([NullAllowed] NSStoryboardControllerCreator handler);

		[Export ("instantiateControllerWithIdentifier:creator:")]
		NSViewController InstantiateController (string identifier, [NullAllowed] NSStoryboardControllerCreator handler);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSStoryboardSegue {
		[DesignatedInitializer]
		[Export ("initWithIdentifier:source:destination:")]
		NativeHandle Constructor (string identifier, NSObject sourceController, NSObject destinationController);

		[Export ("identifier")]
		string Identifier { get; }

		[Export ("sourceController", ArgumentSemantic.Strong)]
		NSObject SourceController { get; }

		[Export ("destinationController", ArgumentSemantic.Strong)]
		NSObject DestinationController { get; }

		[Static, Export ("segueWithIdentifier:source:destination:performHandler:")]
		NSStoryboardSegue FromIdentifier (string identifier, NSObject sourceController, NSObject destinationController, Action performHandler);

		[Export ("perform")]
		void Perform ();
	}

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSSeguePerforming {
		[Export ("prepareForSegue:sender:")]
		void PrepareForSegue (NSStoryboardSegue segue, NSObject sender);

		[Export ("performSegueWithIdentifier:sender:")]
		void PerformSegue (string identifier, NSObject sender);

		[Export ("shouldPerformSegueWithIdentifier:sender:")]
		bool ShouldPerformSegue (string identifier, NSObject sender);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSController))]
	interface NSUserDefaultsController {
		[DesignatedInitializer]
		[Export ("initWithDefaults:initialValues:")]
		NativeHandle Constructor ([NullAllowed] NSUserDefaults defaults, [NullAllowed] NSDictionary initialValues);
		//
		//		[Export ("initWithCoder:")]
		//		NativeHandle Constructor (NSCoder coder);
		//
		[Export ("defaults", ArgumentSemantic.Strong)]
		NSUserDefaults Defaults { get; }

		[Export ("initialValues", ArgumentSemantic.Copy)]
		NSDictionary InitialValues { get; set; }

		[Export ("appliesImmediately")]
		bool AppliesImmediately { get; set; }

		[Export ("hasUnappliedChanges")]
		bool HasUnappliedChanges { get; }

		[Export ("values", ArgumentSemantic.Strong)]
		NSObject Values { get; }

		[Static, Export ("sharedUserDefaultsController")]
		NSUserDefaultsController SharedUserDefaultsController { get; }

		[Export ("revert:")]
		void Revert (NSObject sender);

		[Export ("save:")]
		void Save (NSObject sender);

		[Export ("revertToInitialValues:")]
		void RevertToInitialValues (NSObject sender);
	}

	interface INSUserInterfaceItemIdentification { }

	[NoMacCatalyst]
	[Protocol]
	interface NSUserInterfaceItemIdentification {
#if NET
		[Abstract]
#endif
		[Export ("identifier", ArgumentSemantic.Copy)]
		string Identifier { get; set; }
	}

	interface INSTextFinderClient { }

	[NoMacCatalyst]
	[Protocol]
#if !NET
	[Model]
	[BaseType (typeof (NSObject))]
#endif
	partial interface NSTextFinderClient {
#if !NET
		[Abstract]
#endif
		[Export ("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; }

#if !NET
		[Abstract]
#endif
		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; }

#if !NET
		[Abstract]
#endif
		[Export ("string", ArgumentSemantic.Copy)]
		string String { get; }

#if !NET
		[Abstract]
#endif
		[Export ("firstSelectedRange")]
		NSRange FirstSelectedRange { get; }

#if !NET
		[Abstract]
#endif
		[Export ("selectedRanges", ArgumentSemantic.Copy)]
		NSArray SelectedRanges { get; set; }

#if !NET
		[Abstract]
#endif
		[Export ("visibleCharacterRanges", ArgumentSemantic.Copy)]
		NSArray VisibleCharacterRanges { get; }

#if !NET
		[Abstract]
#endif
		[Export ("selectable")]
		bool Selectable { [Bind ("isSelectable")] get; }

#if !NET
		[Abstract]
#endif
		[Export ("stringAtIndex:effectiveRange:endsWithSearchBoundary:")]
#if NET
		string GetString (nuint index, out NSRange effectiveRange, bool endsWithSearchBoundary);
#else
		string StringAtIndexeffectiveRangeendsWithSearchBoundary (nuint characterIndex, ref NSRange outRange, bool outFlag);
#endif

#if !NET
		[Abstract]
#endif
		[Export ("stringLength")]
#if NET
		nuint StringLength { get; }
#else
		nuint StringLength ();
#endif

#if !NET
		[Abstract]
#endif
		[Export ("scrollRangeToVisible:")]
		void ScrollRangeToVisible (NSRange range);

#if !NET
		[Abstract]
#endif
		[Export ("shouldReplaceCharactersInRanges:withStrings:")]
#if NET
		bool ShouldReplaceCharacters (NSArray ranges, NSArray strings);
#else
		bool ShouldReplaceCharactersInRangeswithStrings (NSArray ranges, NSArray strings);
#endif

#if !NET
		[Abstract]
#endif
		[Export ("replaceCharactersInRange:withString:")]
#if NET
		void ReplaceCharacters (NSRange range, string str);
#else
		void ReplaceCharactersInRangewithString (NSRange range, string str);
#endif

#if !NET
		[Abstract]
#endif
		[Export ("didReplaceCharacters")]
		void DidReplaceCharacters ();

#if !NET
		[Abstract]
#endif
		[Export ("contentViewAtIndex:effectiveCharacterRange:")]
#if NET
		NSView GetContentView (nuint index, out NSRange outRange);
#else
		NSView ContentViewAtIndexeffectiveCharacterRange (nuint index, ref NSRange outRange);
#endif

#if !NET
		[Abstract]
#endif
		[Export ("rectsForCharacterRange:")]
#if NET
		NSArray GetRects (NSRange characterRange);
#else
		NSArray RectsForCharacterRange (NSRange range);
#endif

#if !NET
		[Abstract]
#endif
		[Export ("drawCharactersInRange:forContentView:")]
#if !NET
		void DrawCharactersInRangeforContentView (NSRange range, NSView view);
#else
		void DrawCharacters (NSRange range, NSView view);
#endif

	}

	/*
	interface INSTextFinderBarContainer { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject)), Model, Protocol]
	partial interface NSTextFinderBarContainer {
		[Abstract, Export ("findBarVisible")]
		bool FindBarVisible { [Bind ("isFindBarVisible")] get; set; }

		[Abstract, Export ("findBarView", ArgumentSemantic.Retain)]
		NSView FindBarView { get; set; }

		[Abstract, Export ("findBarViewDidChangeHeight")]
		void FindBarViewDidChangeHeight ();

		[Export ("contentView")]
		NSView ContentView { get; }
	}
	8/

	[NoMacCatalyst]
	[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	partial interface NSTextFinder : NSCoding {
		[Export ("client", ArgumentSemantic.Assign)]
		INSTextFinderClient Client { set; }

		[Export ("findBarContainer", ArgumentSemantic.Assign)]
		INSTextFinderBarContainer FindBarContainer { set; }

		[Export ("findIndicatorNeedsUpdate")]
		bool FindIndicatorNeedsUpdate { get; set; }

		[Export ("incrementalSearchingEnabled")]
		bool IncrementalSearchingEnabled { [Bind ("isIncrementalSearchingEnabled")] get; set; }

		[Export ("incrementalMatchRanges", ArgumentSemantic.Copy)]
		NSArray IncrementalMatchRanges { get; }

		[Export ("performAction:")]
		void PerformAction (NSTextFinderAction op);

		[Export ("validateAction:")]
		bool ValidateAction (NSTextFinderAction op);

		[Export ("cancelFindIndicator")]
		void CancelFindIndicator ();

		[Static]
		[Export ("drawIncrementalMatchHighlightInRect:")]
		void DrawIncrementalMatchHighlightInRect (CGRect rect);

		[Export ("noteClientStringWillChange")]
		void NoteClientStringWillChange ();
	}

	

	[NoMacCatalyst]
	[BaseType (typeof (NSAnimation))]
	interface NSViewAnimation {
		[Export ("initWithViewAnimations:")]
		NativeHandle Constructor (NSDictionary [] viewAnimations);

		[DesignatedInitializer]
		[Export ("initWithDuration:animationCurve:")]
		NativeHandle Constructor (double duration, NSAnimationCurve animationCurve);

		[Export ("viewAnimations", ArgumentSemantic.Copy)]
		NSDictionary [] ViewAnimations { get; set; }

		[Export ("animator")]
		NSObject Animator { [return: Proxy] get; }

		[Export ("animations")]
		NSDictionary Animations { get; set; }

		[Export ("animationForKey:")]
		NSObject AnimationForKey (string key);

		[Static]
		[Export ("defaultAnimationForKey:")]
		NSObject DefaultAnimationForKey (string key);

		[Field ("NSViewAnimationTargetKey")]
		NSString TargetKey { get; }

		[Field ("NSViewAnimationStartFrameKey")]
		NSString StartFrameKey { get; }

		[Field ("NSViewAnimationEndFrameKey")]
		NSString EndFrameKey { get; }

		[Field ("NSViewAnimationEffectKey")]
		NSString EffectKey { get; }

		[Field ("NSViewAnimationFadeInEffect")]
		NSString FadeInEffect { get; }

		[Field ("NSViewAnimationFadeOutEffect")]
		NSString FadeOutEffect { get; }
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSView))]
	interface NSView_NSTouchBar {
		[Export ("allowedTouchTypes")]
		NSTouchTypeMask GetAllowedTouchTypes ();

		[Export ("setAllowedTouchTypes:")]
		void SetAllowedTouchTypes (NSTouchTypeMask touchTypes);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSResponder))]
	interface NSViewController : NSResponder, NSUserInterfaceItemIdentification, NSEditor, NSSeguePerforming, NSExtensionRequestHandling {
		[DesignatedInitializer]
		[Export ("initWithNibName:bundle:")]
		NativeHandle Constructor ([NullAllowed] string nibNameOrNull, [NullAllowed] NSBundle nibBundleOrNull);

		[Export ("loadView")]
		void LoadView ();

		[Export ("nibName", ArgumentSemantic.Copy)]
		string NibName { get; }

		[Export ("nibBundle", ArgumentSemantic.Strong)]
		NSBundle NibBundle { get; }

		//Detected properties
		[Export ("representedObject", ArgumentSemantic.Strong)]
		NSObject RepresentedObject { get; set; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("view", ArgumentSemantic.Strong)]
		NSView View { get; set; }

		[Export ("viewLoaded")]
		bool ViewLoaded { [Bind ("isViewLoaded")] get; }

		[Export ("preferredContentSize")]
		CGSize PreferredContentSize { get; set; }

		[Export ("viewDidLoad")]
		void ViewDidLoad ();

		[Export ("viewWillAppear")]
		void ViewWillAppear ();

		[Export ("viewDidAppear")]
		void ViewDidAppear ();

		[Export ("viewWillDisappear")]
		void ViewWillDisappear ();

		[Export ("viewDidDisappear")]
		void ViewDidDisappear ();

		[Export ("updateViewConstraints")]
		void UpdateViewConstraints ();

		[Export ("viewWillLayout")]
		void ViewWillLayout ();

		[Export ("viewDidLayout")]
		void ViewDidLayout ();

		[Export ("presentedViewControllers", ArgumentSemantic.Assign)]
		NSViewController [] PresentedViewControllers { get; }

		[Export ("presentingViewController", ArgumentSemantic.UnsafeUnretained)]
		NSViewController PresentingViewController { get; }

		[Export ("presentViewController:animator:")]
		void PresentViewController (NSViewController viewController, INSViewControllerPresentationAnimator animator);

		[Export ("dismissViewController:")]
		void DismissViewController (NSViewController viewController);

		[Export ("dismissController:")]
		void DismissController (NSObject sender);

		[Export ("presentViewControllerAsSheet:")]
		void PresentViewControllerAsSheet (NSViewController viewController);

		[Export ("presentViewControllerAsModalWindow:")]
		void PresentViewControllerAsModalWindow (NSViewController viewController);

		[Export ("presentViewController:asPopoverRelativeToRect:ofView:preferredEdge:behavior:")]
		void PresentViewController (NSViewController viewController, CGRect positioningRect, NSView positioningView, nuint preferredEdge, NSPopoverBehavior behavior);

		[Export ("transitionFromViewController:toViewController:options:completionHandler:")]
		void TransitionFromViewController (NSViewController fromViewController, NSViewController toViewController, NSViewControllerTransitionOptions options, Action completion);

		[Export ("parentViewController")]
		NSViewController ParentViewController { get; }

		[Export ("childViewControllers", ArgumentSemantic.Copy)]
		NSViewController [] ChildViewControllers { get; set; }

		[Export ("addChildViewController:")]
		void AddChildViewController (NSViewController childViewController);

		[Export ("removeFromParentViewController")]
		void RemoveFromParentViewController ();

		[Export ("insertChildViewController:atIndex:")]
		void InsertChildViewController (NSViewController childViewController, nint index);

		[Export ("removeChildViewControllerAtIndex:")]
		void RemoveChildViewController (nint index);

		[Export ("preferredContentSizeDidChangeForViewController:")]
		void PreferredContentSizeDidChange (NSViewController viewController);

		[Export ("viewWillTransitionToSize:")]
		void ViewWillTransition (CGSize newSize);

		[Export ("storyboard", ArgumentSemantic.Strong)]
		NSStoryboard Storyboard { get; }

		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Use WidgetKit instead.")]
		[Export ("presentViewControllerInWidget:")]
		void PresentViewControllerInWidget (NSViewController viewController);

		[NullAllowed, Export ("extensionContext", ArgumentSemantic.Retain)]
		NSExtensionContext ExtensionContext { get; }

		[NullAllowed, Export ("sourceItemView", ArgumentSemantic.Strong)]
		NSView SourceItemView { get; set; }

		[Export ("preferredScreenOrigin", ArgumentSemantic.Assign)]
		CGPoint PreferredScreenOrigin { get; set; }

		[Export ("preferredMinimumSize")]
		CGSize PreferredMinimumSize { get; }

		[Export ("preferredMaximumSize")]
		CGSize PreferredMaximumSize { get; }

		[Mac (14, 0)]
		[NullAllowed]
		[Export ("viewIfLoaded", ArgumentSemantic.Strong)]
		NSView ViewIfLoaded { get; }

		[Mac (14, 0)]
		[Export ("presentViewController:asPopoverRelativeToRect:ofView:preferredEdge:behavior:hasFullSizeContent:")]
		void Present (NSViewController viewController, CGRect positioningRect, NSView positioningView, NSRectEdge preferredEdge, NSPopoverBehavior behavior, byte hasFullSizeContent);

		[Mac (14, 0)]
		[Export ("loadViewIfNeeded")]
		void LoadViewIfNeeded ();
	}

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSViewControllerPresentationAnimator {
		[Export ("animatePresentationOfViewController:fromViewController:")]
		[Abstract]
		void AnimatePresentation (NSViewController viewController, NSViewController fromViewController);

		[Export ("animateDismissalOfViewController:fromViewController:")]
		[Abstract]
		void AnimateDismissal (NSViewController viewController, NSViewController fromViewController);
	}

	interface INSViewControllerPresentationAnimator { }

	[NoMacCatalyst]
	[BaseType (typeof (NSViewController),
		Delegates = new [] { "WeakDelegate" },
		Events = new [] { typeof (NSPageControllerDelegate) })]
	partial interface NSPageController : NSAnimatablePropertyContainer {

		[Export ("initWithNibName:bundle:")]
		NativeHandle Constructor ([NullAllowed] string nibNameOrNull, [NullAllowed] NSBundle nibBundleOrNull);

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate"), NullAllowed]
		INSPageControllerDelegate Delegate { get; set; }

		[Export ("arrangedObjects", ArgumentSemantic.Copy)]
		NSObject [] ArrangedObjects { get; set; }

		[Export ("selectedViewController", ArgumentSemantic.Strong)]
		NSViewController SelectedViewController { get; }

		[Export ("transitionStyle")]
		NSPageControllerTransitionStyle TransitionStyle { get; set; }

		[Export ("completeTransition")]
		void CompleteTransition ();

		[Export ("selectedIndex")]
		nint SelectedIndex { get; set; }

		[Export ("takeSelectedIndexFrom:")]
		void NavigateTo (NSObject sender);

		[Export ("navigateForwardToObject:")]
		void NavigateForwardTo (NSObject target);

		[Export ("navigateBack:")]
		void NavigateBack (NSObject sender);

		[Export ("navigateForward:")]
		void NavigateForward (NSObject sender);
	}

	interface INSPageControllerDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject)), Model, Protocol]
	partial interface NSPageControllerDelegate {

		[Export ("pageController:identifierForObject:"), DelegateName ("NSPageControllerGetIdentifier"), DefaultValue ("String.Empty")]
		string GetIdentifier (NSPageController pageController, NSObject targetObject);

		[Export ("pageController:viewControllerForIdentifier:"), DelegateName ("NSPageControllerGetViewController"), DefaultValue (null)]
		NSViewController GetViewController (NSPageController pageController, string identifier);

		[Export ("pageController:frameForObject:"), DelegateName ("NSPageControllerGetFrame"), NoDefaultValue]
		CGRect GetFrame (NSPageController pageController, NSObject targetObject);

		[Export ("pageController:prepareViewController:withObject:"), EventArgs ("NSPageControllerPrepareViewController")]
		void PrepareViewController (NSPageController pageController, NSViewController viewController, NSObject targetObject);

		[Export ("pageController:didTransitionToObject:"), EventArgs ("NSPageControllerTransition")]
		void DidTransition (NSPageController pageController, NSObject targetObject);

		[Export ("pageControllerWillStartLiveTransition:")]
		void WillStartLiveTransition (NSPageController pageController);

		[Export ("pageControllerDidEndLiveTransition:")]
		void DidEndLiveTransition (NSPageController pageController);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSImageRep), Name = "NSPDFImageRep")]
	[DisableDefaultCtor] // -[NSPDFImageRep init]: unrecognized selector sent to instance 0x2652460
	interface NSPdfImageRep {
		[Export ("initWithData:")]
		NativeHandle Constructor (NSData pdfData);

		[Export ("PDFRepresentation", ArgumentSemantic.Retain)]
		NSData PdfRepresentation { get; }

		[Export ("bounds")]
		CGRect Bounds { get; }

		[Export ("currentPage")]
		nint CurrentPage { get; set; }

		[Export ("pageCount")]
		nint PageCount { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial interface NSTableColumn : NSUserInterfaceItemIdentification, NSCoding {
		[Export ("initWithIdentifier:")]
		[Sealed]
		NativeHandle Constructor (string identifier);

		[DesignatedInitializer]
		[Export ("initWithIdentifier:")]
		NativeHandle Constructor (NSString identifier);

		[Deprecated (PlatformName.MacOSX, 10, 10)]
		[Export ("dataCellForRow:")]
		NSCell DataCellForRow (nint row);

		[Export ("sizeToFit")]
		void SizeToFit ();

		[Export ("tableView")]
		NSTableView TableView { get; set; }

		[Export ("width")]
		nfloat Width { get; set; }

		[Export ("minWidth")]
		nfloat MinWidth { get; set; }

		[Export ("maxWidth")]
		nfloat MaxWidth { get; set; }

		[Export ("headerCell", ArgumentSemantic.Retain)]
		NSCell HeaderCell { get; set; }

		[Export ("dataCell")]
		NSCell DataCell { get; set; }

		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("sortDescriptorPrototype", ArgumentSemantic.Copy), NullAllowed]
		NSSortDescriptor SortDescriptorPrototype { get; set; }

		[Export ("resizingMask")]
		NSTableColumnResizing ResizingMask { get; set; }

		[Export ("headerToolTip"), NullAllowed]
		string HeaderToolTip { get; set; }

		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

		[Export ("title")]
		string Title { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSTableRowView : NSAccessibilityRow {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("selectionHighlightStyle")]
		NSTableViewSelectionHighlightStyle SelectionHighlightStyle { get; set; }

		[Export ("emphasized")]
		bool Emphasized { [Bind ("isEmphasized")] get; set; }

		[Export ("groupRowStyle")]
		bool GroupRowStyle { [Bind ("isGroupRowStyle")] get; set; }

		[Export ("selected")]
		bool Selected { [Bind ("isSelected")] get; set; }

		[Export ("floating")]
		bool Floating { [Bind ("isFloating")] get; set; }

		[Export ("draggingDestinationFeedbackStyle")]
		NSTableViewDraggingDestinationFeedbackStyle DraggingDestinationFeedbackStyle { get; set; }

		[Export ("indentationForDropOperation")]
		nfloat IndentationForDropOperation { get; set; }

		[Export ("interiorBackgroundStyle")]
		NSBackgroundStyle InteriorBackgroundStyle { get; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("numberOfColumns")]
		nint NumberOfColumns { get; }

		[Export ("targetForDropOperation")]
		bool TargetForDropOperation { [Bind ("isTargetForDropOperation")] get; set; }

		[Export ("drawBackgroundInRect:")]
		void DrawBackground (CGRect dirtyRect);

		[Export ("drawSelectionInRect:")]
		void DrawSelection (CGRect dirtyRect);

		[Export ("drawSeparatorInRect:")]
		void DrawSeparator (CGRect dirtyRect);

		[Export ("drawDraggingDestinationFeedbackInRect:")]
		void DrawDraggingDestinationFeedback (CGRect dirtyRect);

		[Export ("viewAtColumn:")]
		NSView ViewAtColumn (nint column);

		[Export ("previousRowSelected")]
		bool PreviousRowSelected { [Bind ("isPreviousRowSelected")] get; set; }

		[Export ("nextRowSelected")]
		bool NextRowSelected { [Bind ("isNextRowSelected")] get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	partial interface NSTableCellView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("backgroundStyle")]
		NSBackgroundStyle BackgroundStyle {
			get; set;
		}

		[Export ("imageView", ArgumentSemantic.Assign)]
		NSImageView ImageView {
			get; set;
		}

		[Export ("objectValue", ArgumentSemantic.Retain), NullAllowed]
		NSObject ObjectValue {
			get; set;
		}

		[Export ("rowSizeStyle")]
		NSTableViewRowSizeStyle RowSizeStyle {
			get; set;
		}

		[Export ("textField", ArgumentSemantic.Assign)]
		NSTextField TextField {
			get; set;
		}

		[Export ("draggingImageComponents", ArgumentSemantic.Retain)]
		NSArray DraggingImageComponents {
			get;
		}
	}

	[NoMacCatalyst]
	delegate void NSTableViewRowHandler (NSTableRowView rowView, nint row);

	[NoMacCatalyst]
	[BaseType (typeof (NSControl), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSTableViewDelegate) })]
	partial interface NSTableView : NSDraggingSource, NSAccessibilityTable {
		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("noteHeightOfRowsWithIndexesChanged:")]
		void NoteHeightOfRowsWithIndexesChanged (NSIndexSet indexSet);

		[Export ("tableColumns")]
		NSTableColumn [] TableColumns ();

		[Export ("numberOfColumns")]
		nint ColumnCount { get; }

		[Export ("numberOfRows")]
		nint RowCount { get; }

		[Export ("addTableColumn:")]
		void AddColumn (NSTableColumn tableColumn);

		[Export ("removeTableColumn:")]
		void RemoveColumn (NSTableColumn tableColumn);

		[Export ("moveColumn:toColumn:")]
		void MoveColumn (nint oldIndex, nint newIndex);

		[Export ("columnWithIdentifier:")]
		nint FindColumn (NSString identifier);

		[Export ("tableColumnWithIdentifier:")]
		NSTableColumn FindTableColumn (NSString identifier);

		[Export ("tile")]
		void Tile ();

		[Export ("sizeToFit")]
		void SizeToFit ();

		[Export ("sizeLastColumnToFit")]
		void SizeLastColumnToFit ();

		[Export ("scrollRowToVisible:")]
		void ScrollRowToVisible (nint row);

		[Export ("scrollColumnToVisible:")]
		void ScrollColumnToVisible (nint column);

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("noteNumberOfRowsChanged")]
		void NoteNumberOfRowsChanged ();

		[Export ("reloadDataForRowIndexes:columnIndexes:")]
		void ReloadData (NSIndexSet rowIndexes, NSIndexSet columnIndexes);

		[Export ("editedColumn")]
		nint EditedColumn { get; }

		[Export ("editedRow")]
		nint EditedRow { get; }

		[Export ("clickedColumn")]
		nint ClickedColumn { get; }

		[Export ("clickedRow")]
		nint ClickedRow { get; }

		[Export ("setIndicatorImage:inTableColumn:")]
		void SetIndicatorImage ([NullAllowed] NSImage anImage, NSTableColumn tableColumn);

		[Export ("indicatorImageInTableColumn:")]
		NSImage GetIndicatorImage (NSTableColumn tableColumn);

		[Export ("canDragRowsWithIndexes:atPoint:")]
		bool CanDragRows (NSIndexSet rowIndexes, CGPoint mouseDownPoint);

		[Export ("dragImageForRowsWithIndexes:tableColumns:event:offset:")]
#if NET
		NSImage DragImageForRows (NSIndexSet dragRows, NSTableColumn [] tableColumns, NSEvent dragEvent, ref CGPoint dragImageOffset);
#else
		NSImage DragImageForRowsWithIndexestableColumnseventoffset (NSIndexSet dragRows, NSTableColumn [] tableColumns, NSEvent dragEvent, ref CGPoint dragImageOffset);
#endif

		[Export ("setDraggingSourceOperationMask:forLocal:")]
		void SetDraggingSourceOperationMask (NSDragOperation mask, bool isLocal);

		[Export ("setDropRow:dropOperation:")]
		void SetDropRowDropOperation (nint row, NSTableViewDropOperation dropOperation);

		[Export ("selectAll:")]
		void SelectAll ([NullAllowed] NSObject sender);

		[Export ("deselectAll:")]
		void DeselectAll ([NullAllowed] NSObject sender);

		[Export ("selectColumnIndexes:byExtendingSelection:")]
		void SelectColumns (NSIndexSet indexes, bool byExtendingSelection);

		[Export ("selectRowIndexes:byExtendingSelection:")]
		void SelectRows (NSIndexSet indexes, bool byExtendingSelection);

		[Export ("selectedColumnIndexes")]
		NSIndexSet SelectedColumns { get; }

		[Export ("selectedRowIndexes")]
		NSIndexSet SelectedRows { get; }

		[Export ("deselectColumn:")]
		void DeselectColumn (nint column);

		[Export ("deselectRow:")]
		void DeselectRow (nint row);

		[Export ("selectedColumn")]
		nint SelectedColumn { get; }

		[Export ("selectedRow")]
		nint SelectedRow { get; }

		[Export ("isColumnSelected:")]
		bool IsColumnSelected (nint column);

		[Export ("isRowSelected:")]
		bool IsRowSelected (nint row);

		[Export ("numberOfSelectedColumns")]
		nint SelectedColumnsCount { get; }

		[Export ("numberOfSelectedRows")]
		nint SelectedRowCount { get; }

		[Export ("rectOfColumn:")]
		CGRect RectForColumn (nint column);

		[Export ("rectOfRow:")]
		CGRect RectForRow (nint row);

		[Export ("columnIndexesInRect:")]
		NSIndexSet GetColumnIndexesInRect (CGRect rect);

		[Export ("rowsInRect:")]
		NSRange RowsInRect (CGRect rect);

		[Export ("columnAtPoint:")]
		nint GetColumn (CGPoint point);

		[Export ("rowAtPoint:")]
		nint GetRow (CGPoint point);

		[Export ("frameOfCellAtColumn:row:")]
		CGRect GetCellFrame (nint column, nint row);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use View Based TableView and GetView.")]
		[Export ("preparedCellAtColumn:row:")]
		NSCell GetCell (nint column, nint row);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView with an NSTextField.")]
		[Export ("textShouldBeginEditing:")]
		bool TextShouldBeginEditing (NSText textObject);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView with an NSTextField.")]
		[Export ("textShouldEndEditing:")]
		bool TextShouldEndEditing (NSText textObject);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView with an NSTextField.")]
		[Export ("textDidBeginEditing:")]
		void TextDidBeginEditing (NSNotification notification);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView with an NSTextField.")]
		[Export ("textDidEndEditing:")]
		void TextDidEndEditing (NSNotification notification);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView with an NSTextField.")]
		[Export ("textDidChange:")]
		void TextDidChange (NSNotification notification);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView; observe the window’s firstResponder for focus change notifications.")]
		[Export ("shouldFocusCell:atColumn:row:")]
		bool ShouldFocusCell (NSCell cell, nint column, nint row);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView; directly interact with a particular view as required and call PerformClick on it, if necessary.")]
		[Export ("performClickOnCellAtColumn:row:")]
		void PerformClick (nint column, nint row);

		[Export ("editColumn:row:withEvent:select:")]
		void EditColumn (nint column, nint row, [NullAllowed] NSEvent theEvent, bool select);

		[Export ("drawRow:clipRect:")]
		void DrawRow (nint row, CGRect clipRect);

		[Export ("highlightSelectionInClipRect:")]
		void HighlightSelection (CGRect clipRect);

		[Export ("drawGridInClipRect:")]
		void DrawGrid (CGRect clipRect);

		[Export ("drawBackgroundInClipRect:")]
		void DrawBackground (CGRect clipRect);

		//Detected properties
		[Export ("dataSource", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDataSource { get; set; }

		[Wrap ("WeakDataSource")]
		[NullAllowed]
		INSTableViewDataSource DataSource { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSTableViewDelegate Delegate { get; set; }

		[Export ("headerView", ArgumentSemantic.Retain), NullAllowed]
		NSTableHeaderView HeaderView { get; set; }

		[Export ("cornerView", ArgumentSemantic.Retain)]
		NSView CornerView { get; set; }

		[Export ("allowsColumnReordering")]
		bool AllowsColumnReordering { get; set; }

		[Export ("allowsColumnResizing")]
		bool AllowsColumnResizing { get; set; }

		[Export ("columnAutoresizingStyle")]
		NSTableViewColumnAutoresizingStyle ColumnAutoresizingStyle { get; set; }

		[Export ("gridStyleMask")]
		NSTableViewGridStyle GridStyleMask { get; set; }

		[Export ("intercellSpacing")]
		CGSize IntercellSpacing { get; set; }

		[Export ("usesAlternatingRowBackgroundColors")]
		bool UsesAlternatingRowBackgroundColors { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("gridColor", ArgumentSemantic.Copy)]
		NSColor GridColor { get; set; }

		[Export ("rowHeight")]
		nfloat RowHeight { get; set; }

		[NullAllowed]
		[Export ("doubleAction")]
		Selector DoubleAction { get; set; }

		[Export ("sortDescriptors", ArgumentSemantic.Copy)]
		NSSortDescriptor [] SortDescriptors { get; set; }

		[Export ("highlightedTableColumn")]
		NSTableColumn HighlightedTableColumn { get; set; }

		[Export ("verticalMotionCanBeginDrag")]
		bool VerticalMotionCanBeginDrag { get; set; }

		[Export ("allowsMultipleSelection")]
		bool AllowsMultipleSelection { get; set; }

		[Export ("allowsEmptySelection")]
		bool AllowsEmptySelection { get; set; }

		[Export ("allowsColumnSelection")]
		bool AllowsColumnSelection { get; set; }

		[Export ("allowsTypeSelect")]
		bool AllowsTypeSelect { get; set; }

		[Export ("selectionHighlightStyle")]
		NSTableViewSelectionHighlightStyle SelectionHighlightStyle { get; set; }

		[Export ("draggingDestinationFeedbackStyle")]
		NSTableViewDraggingDestinationFeedbackStyle DraggingDestinationFeedbackStyle { get; set; }

		[Export ("autosaveName")]
		string AutosaveName { get; set; }

		[Export ("autosaveTableColumns")]
		bool AutosaveTableColumns { get; set; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use a View Based TableView; observe the window’s firstResponder.")]
		[Export ("focusedColumn")]
		nint FocusedColumn { get; set; }

		[Export ("effectiveRowSizeStyle")]
		NSTableViewRowSizeStyle EffectiveRowSizeStyle { get; }

		[Export ("viewAtColumn:row:makeIfNecessary:")]
		NSView GetView (nint column, nint row, bool makeIfNecessary);

		[Export ("rowViewAtRow:makeIfNecessary:")]
		NSTableRowView GetRowView (nint row, bool makeIfNecessary);

		[Export ("rowForView:")]
		nint RowForView (NSView view);

		[Export ("columnForView:")]
		nint ColumnForView (NSView view);

		// According to the header identifier should be non-null but example in 
		// https://bugzilla.xamarin.com/show_bug.cgi?id=36496 shows actual behavior differs
		[Export ("makeViewWithIdentifier:owner:")]
		NSView MakeView ([NullAllowed] string identifier, [NullAllowed] NSObject owner);

		[Export ("enumerateAvailableRowViewsUsingBlock:")]
		void EnumerateAvailableRowViews (NSTableViewRowHandler callback);

		[Export ("beginUpdates")]
		void BeginUpdates ();

		[Export ("endUpdates")]
		void EndUpdates ();

		[Export ("insertRowsAtIndexes:withAnimation:")]
		void InsertRows (NSIndexSet indexes, NSTableViewAnimation animationOptions);

		[Export ("removeRowsAtIndexes:withAnimation:")]
		void RemoveRows (NSIndexSet indexes, NSTableViewAnimation animationOptions);

		[Export ("moveRowAtIndex:toIndex:")]
		void MoveRow (nint oldIndex, nint newIndex);

		[Export ("rowSizeStyle")]
		NSTableViewRowSizeStyle RowSizeStyle { get; set; }

		[Export ("floatsGroupRows")]
		bool FloatsGroupRows { get; set; }

		[Field ("NSTableViewRowViewKey")]
		NSString RowViewKey { get; }

		[Export ("registerNib:forIdentifier:")]
		void RegisterNib ([NullAllowed] NSNib nib, string identifier);

		[Export ("didAddRowView:forRow:")]
		void RowViewAdded (NSTableRowView rowView, nint row);

		[Export ("didRemoveRowView:forRow:")]
		void RowViewRemoved (NSTableRowView rowView, nint row);

		[Export ("registeredNibsByIdentifier", ArgumentSemantic.Copy)]
		NSDictionary RegisteredNibsByIdentifier { get; }

		[Export ("usesStaticContents")]
		bool UsesStaticContents { get; set; }

		[Export ("hideRowsAtIndexes:withAnimation:")]
		void HideRows (NSIndexSet indexes, NSTableViewAnimation rowAnimation);

		[Export ("unhideRowsAtIndexes:withAnimation:")]
		void UnhideRows (NSIndexSet indexes, NSTableViewAnimation rowAnimation);

		[Export ("hiddenRowIndexes", ArgumentSemantic.Copy)]
		NSIndexSet HiddenRowIndexes { get; }

		[Export ("rowActionsVisible")]
		bool RowActionsVisible { get; set; }

		[Export ("userInterfaceLayoutDirection")]
		NSUserInterfaceLayoutDirection UserInterfaceLayoutDirection { get; set; }

		[Export ("usesAutomaticRowHeights")]
		bool UsesAutomaticRowHeights { get; set; }

		[Export ("style", ArgumentSemantic.Assign)]
		NSTableViewStyle Style { get; set; }

		[Export ("effectiveStyle")]
		NSTableViewStyle EffectiveStyle { get; }
	}

	interface INSTableViewDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface NSTableViewDelegate {
		[Export ("tableView:willDisplayCell:forTableColumn:row:"), EventArgs ("NSTableViewCell")]
		void WillDisplayCell (NSTableView tableView, NSObject cell, NSTableColumn tableColumn, nint row);

		[Export ("tableView:shouldEditTableColumn:row:"), DelegateName ("NSTableViewColumnRowPredicate"), DefaultValue (false)]
		bool ShouldEditTableColumn (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("selectionShouldChangeInTableView:"), DelegateName ("NSTableViewPredicate"), DefaultValue (true)]
		bool SelectionShouldChange (NSTableView tableView);

		[Export ("tableView:shouldSelectRow:"), DelegateName ("NSTableViewRowPredicate")]
		[DefaultValue (true)]
		bool ShouldSelectRow (NSTableView tableView, nint row);

		[Export ("tableView:selectionIndexesForProposedSelection:"), DelegateName ("NSTableViewIndexFilter"), DefaultValueFromArgument ("proposedSelectionIndexes")]
		NSIndexSet GetSelectionIndexes (NSTableView tableView, NSIndexSet proposedSelectionIndexes);

		[Export ("tableView:shouldSelectTableColumn:"), DelegateName ("NSTableViewColumnPredicate"), DefaultValue (true)]
		bool ShouldSelectTableColumn (NSTableView tableView, NSTableColumn tableColumn);

		[Export ("tableView:mouseDownInHeaderOfTableColumn:"), EventArgs ("NSTableViewTable")]
		void MouseDownInHeaderOfTableColumn (NSTableView tableView, NSTableColumn tableColumn);

		[Export ("tableView:didClickTableColumn:"), EventArgs ("NSTableViewTable")]
		void DidClickTableColumn (NSTableView tableView, NSTableColumn tableColumn);

		[Export ("tableView:didDragTableColumn:"), EventArgs ("NSTableViewTable")]
		void DidDragTableColumn (NSTableView tableView, NSTableColumn tableColumn);

		[Export ("tableView:heightOfRow:"), DelegateName ("NSTableViewRowHeight"), NoDefaultValue]
		nfloat GetRowHeight (NSTableView tableView, nint row);

		[Export ("tableView:typeSelectStringForTableColumn:row:"), DelegateName ("NSTableViewColumnRowString"), DefaultValue ("String.Empty")]
		string GetSelectString (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:nextTypeSelectMatchFromRow:toRow:forString:"), DelegateName ("NSTableViewSearchString"), DefaultValue (-1)]
		nint GetNextTypeSelectMatch (NSTableView tableView, nint startRow, nint endRow, string searchString);

		[Export ("tableView:shouldTypeSelectForEvent:withCurrentSearchString:"), DelegateName ("NSTableViewEventString"), DefaultValue (false)]
		bool ShouldTypeSelect (NSTableView tableView, NSEvent theEvent, string searchString);

		[Export ("tableView:shouldShowCellExpansionForTableColumn:row:"), DelegateName ("NSTableViewColumnRowPredicate"), DefaultValue (false)]
		bool ShouldShowCellExpansion (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:shouldTrackCell:forTableColumn:row:"), DelegateName ("NSTableViewCell"), DefaultValue (false)]
		bool ShouldTrackCell (NSTableView tableView, NSCell cell, NSTableColumn tableColumn, nint row);

		[Export ("tableView:dataCellForTableColumn:row:"), DelegateName ("NSTableViewCellGetter"), NoDefaultValue]
		NSCell GetDataCell (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:isGroupRow:"), DelegateName ("NSTableViewRowPredicate"), DefaultValue (false)]
		bool IsGroupRow (NSTableView tableView, nint row);

		[Export ("tableView:sizeToFitWidthOfColumn:"), DelegateName ("NSTableViewColumnWidth"), DefaultValue (80)]
		nfloat GetSizeToFitColumnWidth (NSTableView tableView, nint column);

		[Export ("tableView:shouldReorderColumn:toColumn:"), DelegateName ("NSTableReorder"), DefaultValue (false)]
		bool ShouldReorder (NSTableView tableView, nint columnIndex, nint newColumnIndex);

		[Export ("tableViewSelectionDidChange:"), EventArgs ("NSNotification")]
		void SelectionDidChange (NSNotification notification);

		[Export ("tableViewColumnDidMove:"), EventArgs ("NSNotification")]
		void ColumnDidMove (NSNotification notification);

		[Export ("tableViewColumnDidResize:"), EventArgs ("NSNotification")]
		void ColumnDidResize (NSNotification notification);

		[Export ("tableViewSelectionIsChanging:"), EventArgs ("NSNotification")]
		void SelectionIsChanging (NSNotification notification);

		[Export ("tableView:viewForTableColumn:row:"), DelegateName ("NSTableViewViewGetter"), NoDefaultValue]
		NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:rowViewForRow:"), DelegateName ("NSTableViewRowGetter"), DefaultValue (null)]
		NSTableRowView CoreGetRowView (NSTableView tableView, nint row);

		[Export ("tableView:didAddRowView:forRow:"), EventArgs ("NSTableViewRow")]
		void DidAddRowView (NSTableView tableView, NSTableRowView rowView, nint row);

		[Export ("tableView:didRemoveRowView:forRow:"), EventArgs ("NSTableViewRow")]
		void DidRemoveRowView (NSTableView tableView, NSTableRowView rowView, nint row);

		[Export ("tableView:rowActionsForRow:edge:"), DelegateName ("NSTableViewRowActionsGetter"), NoDefaultValue]
		//		[Verify (StronglyTypedNSArray)]
		NSTableViewRowAction [] RowActions (NSTableView tableView, nint row, NSTableRowActionEdge edge);
	}

	interface INSTableViewDataSource { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSTableViewDataSource {
		[Export ("numberOfRowsInTableView:")]
		nint GetRowCount (NSTableView tableView);

		[Export ("tableView:objectValueForTableColumn:row:")]
		NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:setObjectValue:forTableColumn:row:")]
		void SetObjectValue (NSTableView tableView, NSObject theObject, NSTableColumn tableColumn, nint row);

		[Export ("tableView:sortDescriptorsDidChange:")]
		void SortDescriptorsChanged (NSTableView tableView, NSSortDescriptor [] oldDescriptors);

		[Export ("tableView:writeRowsWithIndexes:toPasteboard:")]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use the 'GetPasteboardWriterForRow' method instead.")]
		bool WriteRows (NSTableView tableView, NSIndexSet rowIndexes, NSPasteboard pboard);

		[Export ("tableView:validateDrop:proposedRow:proposedDropOperation:")]
#if NET
		NSDragOperation ValidateDrop (NSTableView tableView, INSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#else
		NSDragOperation ValidateDrop (NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#endif

		[Export ("tableView:acceptDrop:row:dropOperation:")]
#if NET
		bool AcceptDrop (NSTableView tableView, INSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#else
		bool AcceptDrop (NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#endif

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSFilePromiseReceiver' instead.")]
		[Export ("tableView:namesOfPromisedFilesDroppedAtDestination:forDraggedRowsWithIndexes:")]
		string [] FilesDropped (NSTableView tableView, NSUrl dropDestination, NSIndexSet indexSet);

		[Export ("tableView:pasteboardWriterForRow:")]
		INSPasteboardWriting GetPasteboardWriterForRow (NSTableView tableView, nint row);

		[Export ("tableView:draggingSession:willBeginAtPoint:forRowIndexes:")]
		void DraggingSessionWillBegin (NSTableView tableView, NSDraggingSession draggingSession, CGPoint willBeginAtScreenPoint, NSIndexSet rowIndexes);

		[Export ("tableView:draggingSession:endedAtPoint:operation:")]
		void DraggingSessionEnded (NSTableView tableView, NSDraggingSession draggingSession, CGPoint endedAtScreenPoint, NSDragOperation operation);

		[Export ("tableView:updateDraggingItemsForDrag:")]
#if NET
		void UpdateDraggingItems (NSTableView tableView, INSDraggingInfo draggingInfo);
#else
		void UpdateDraggingItems (NSTableView tableView, NSDraggingInfo draggingInfo);
#endif
	}

	//
	// This is the mixed NSTableViewDataSource and NSTableViewDelegate
	//
	[NoMacCatalyst]
	[Model]
	[Synthetic]
	[BaseType (typeof (NSObject))]
	interface NSTableViewSource {
		//
		// These come from NSTableViewDataSource
		//
		[Export ("tableView:willDisplayCell:forTableColumn:row:")]
		void WillDisplayCell (NSTableView tableView, NSObject cell, NSTableColumn tableColumn, nint row);

		[Export ("tableView:shouldEditTableColumn:row:")]
		[DefaultValue (false)]
		bool ShouldEditTableColumn (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("selectionShouldChangeInTableView:")]
		[DefaultValue (false)]
		bool SelectionShouldChange (NSTableView tableView);

		[Export ("tableView:shouldSelectRow:")]
		[DefaultValue (true)]
		bool ShouldSelectRow (NSTableView tableView, nint row);

		[Export ("tableView:selectionIndexesForProposedSelection:")]
		NSIndexSet GetSelectionIndexes (NSTableView tableView, NSIndexSet proposedSelectionIndexes);

		[Export ("tableView:shouldSelectTableColumn:")]
		[DefaultValue (true)]
		bool ShouldSelectTableColumn (NSTableView tableView, NSTableColumn tableColumn);

		[Export ("tableView:mouseDownInHeaderOfTableColumn:")]
		void MouseDown (NSTableView tableView, NSTableColumn tableColumn);

		[Export ("tableView:didClickTableColumn:")]
		void DidClickTableColumn (NSTableView tableView, NSTableColumn tableColumn);

		[Export ("tableView:didDragTableColumn:")]
		void DidDragTableColumn (NSTableView tableView, NSTableColumn tableColumn);

		//FIXME: Binding NSRectPointer
		//[Export ("tableView:toolTipForCell:rect:tableColumn:row:mouseLocation:")]
		//string TableViewtoolTipForCellrecttableColumnrowmouseLocation (NSTableView tableView, NSCell cell, NSRectPointer rect, NSTableColumn tableColumn, int row, CGPoint mouseLocation);

		[Export ("tableView:heightOfRow:")]
		nfloat GetRowHeight (NSTableView tableView, nint row);

		[Export ("tableView:typeSelectStringForTableColumn:row:")]
		string GetSelectString (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:nextTypeSelectMatchFromRow:toRow:forString:")]
		nint GetNextTypeSelectMatch (NSTableView tableView, nint startRow, nint endRow, string searchString);

		[Export ("tableView:shouldTypeSelectForEvent:withCurrentSearchString:")]
		bool ShouldTypeSelect (NSTableView tableView, NSEvent theEvent, string searchString);

		[Export ("tableView:shouldShowCellExpansionForTableColumn:row:")]
		bool ShouldShowCellExpansion (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:shouldTrackCell:forTableColumn:row:")]
		bool ShouldTrackCell (NSTableView tableView, NSCell cell, NSTableColumn tableColumn, nint row);

		[Export ("tableView:dataCellForTableColumn:row:")]
		NSCell GetCell (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:isGroupRow:"), DefaultValue (false)]
		bool IsGroupRow (NSTableView tableView, nint row);

		[Export ("tableView:sizeToFitWidthOfColumn:")]
		nfloat GetSizeToFitColumnWidth (NSTableView tableView, nint column);

		[Export ("tableView:shouldReorderColumn:toColumn:")]
		bool ShouldReorder (NSTableView tableView, nint columnIndex, nint newColumnIndex);

		[Export ("tableViewSelectionDidChange:")]
		void SelectionDidChange (NSNotification notification);

		[Export ("tableViewColumnDidMove:")]
		void ColumnDidMove (NSNotification notification);

		[Export ("tableViewColumnDidResize:")]
		void ColumnDidResize (NSNotification notification);

		[Export ("tableViewSelectionIsChanging:")]
		void SelectionIsChanging (NSNotification notification);

		// NSTableViewDataSource
		[Export ("numberOfRowsInTableView:")]
		nint GetRowCount (NSTableView tableView);

		[Export ("tableView:objectValueForTableColumn:row:")]
		NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:setObjectValue:forTableColumn:row:")]
		void SetObjectValue (NSTableView tableView, NSObject theObject, NSTableColumn tableColumn, nint row);

		[Export ("tableView:sortDescriptorsDidChange:")]
		void SortDescriptorsChanged (NSTableView tableView, NSSortDescriptor [] oldDescriptors);

		[Export ("tableView:writeRowsWithIndexes:toPasteboard:")]
		bool WriteRows (NSTableView tableView, NSIndexSet rowIndexes, NSPasteboard pboard);

		[Export ("tableView:validateDrop:proposedRow:proposedDropOperation:")]
#if NET
		NSDragOperation ValidateDrop (NSTableView tableView, INSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#else
		NSDragOperation ValidateDrop (NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#endif

		[Export ("tableView:acceptDrop:row:dropOperation:")]
#if NET
		bool AcceptDrop (NSTableView tableView, INSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#else
		bool AcceptDrop (NSTableView tableView, NSDraggingInfo info, nint row, NSTableViewDropOperation dropOperation);
#endif

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSFilePromiseReceiver' objects instead.")]
		[Export ("tableView:namesOfPromisedFilesDroppedAtDestination:forDraggedRowsWithIndexes:")]
		string [] FilesDropped (NSTableView tableView, NSUrl dropDestination, NSIndexSet indexSet);

		[Export ("tableView:viewForTableColumn:row:")]
		NSView GetViewForItem (NSTableView tableView, NSTableColumn tableColumn, nint row);

		[Export ("tableView:rowViewForRow:")]
		NSTableRowView GetRowView (NSTableView tableView, nint row);

		[Export ("tableView:didAddRowView:forRow:")]
		void DidAddRowView (NSTableView tableView, NSTableRowView rowView, nint row);

		[Export ("tableView:didRemoveRowView:forRow:")]
		void DidRemoveRowView (NSTableView tableView, NSTableRowView rowView, nint row);

		[Export ("tableView:pasteboardWriterForRow:")]
		INSPasteboardWriting GetPasteboardWriterForRow (NSTableView tableView, nint row);

		[Export ("tableView:draggingSession:willBeginAtPoint:forRowIndexes:")]
		void DraggingSessionWillBegin (NSTableView tableView, NSDraggingSession draggingSession, CGPoint willBeginAtScreenPoint, NSIndexSet rowIndexes);

		[Export ("tableView:draggingSession:endedAtPoint:operation:")]
		void DraggingSessionEnded (NSTableView tableView, NSDraggingSession draggingSession, CGPoint endedAtScreenPoint, NSDragOperation operation);

		[Export ("tableView:updateDraggingItemsForDrag:")]
#if NET
		void UpdateDraggingItems (NSTableView tableView, INSDraggingInfo draggingInfo);
#else
		void UpdateDraggingItems (NSTableView tableView, NSDraggingInfo draggingInfo);
#endif
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextFieldCell))]
	interface NSTableHeaderCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("drawSortIndicatorWithFrame:inView:ascending:priority:")]
		void DrawSortIndicator (CGRect cellFrame, NSView controlView, bool ascending, nint priority);

		[Export ("sortIndicatorRectForBounds:")]
		CGRect GetSortIndicatorRect (CGRect theRect);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSTableHeaderView : NSViewToolTipOwner {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("draggedColumn")]
		nint DraggedColumn { get; }

		[Export ("draggedDistance")]
		nfloat DraggedDistance { get; }

		[Export ("resizedColumn")]
		nint ResizedColumn { get; }

		[Export ("headerRectOfColumn:")]
		CGRect GetHeaderRect (nint column);

		[Export ("columnAtPoint:")]
		nint GetColumn (CGPoint point);

		//Detected properties
		[Export ("tableView")]
		NSTableView TableView { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSTableViewRowAction : NSCopying {
		[Static]
		[Export ("rowActionWithStyle:title:handler:")]
		NSTableViewRowAction FromStyle (NSTableViewRowActionStyle style, string title, Action<NSTableViewRowAction, nint> handler);

		[Export ("style")]
		NSTableViewRowActionStyle Style { get; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; set; }

		[Export ("image", ArgumentSemantic.Strong)]
		[NullAllowed]
		NSImage Image { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSTabViewDelegate) })]
	partial interface NSTabView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("selectTabViewItem:")]
		void Select (NSTabViewItem tabViewItem);

		[Export ("selectTabViewItemAtIndex:")]
		void SelectAt (nint index);

		[Export ("selectTabViewItemWithIdentifier:")]
		void Select (NSObject identifier);

		[Export ("takeSelectedTabViewItemFromSender:")]
		void TakeSelectedTabViewItemFrom (NSObject sender);

		[Export ("selectFirstTabViewItem:")]
		void SelectFirst (NSObject sender);

		[Export ("selectLastTabViewItem:")]
		void SelectLast (NSObject sender);

		[Export ("selectNextTabViewItem:")]
		void SelectNext (NSObject sender);

		[Export ("selectPreviousTabViewItem:")]
		void SelectPrevious (NSObject sender);

		[Export ("selectedTabViewItem")]
		NSTabViewItem Selected { get; }

		[Export ("font", ArgumentSemantic.Retain)]
		NSFont Font { get; set; }

		[Export ("tabViewType")]
		NSTabViewType TabViewType { get; set; }

#if NET
		[Export ("tabViewItems")]
		NSTabViewItem [] Items { get; set; }
#else
		[Export ("tabViewItems")]
		NSTabViewItem [] Items { get; }

		[Export ("setTabViewItems:")]
		void SetItems (NSTabViewItem [] items);
#endif

		[Export ("allowsTruncatedLabels")]
		bool AllowsTruncatedLabels { get; set; }

		[Export ("minimumSize")]
		CGSize MinimumSize { get; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[Export ("controlTint")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "The 'ControlTint' property is not honored on 10.14.")]
		NSControlTint ControlTint { get; set; }

		[Export ("controlSize")]
		NSControlSize ControlSize { get; set; }

		[Export ("addTabViewItem:")]
		void Add (NSTabViewItem tabViewItem);

		[Export ("insertTabViewItem:atIndex:")]
		void Insert (NSTabViewItem tabViewItem, nint index);

		[Export ("removeTabViewItem:")]
		void Remove (NSTabViewItem tabViewItem);

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate", IsVirtual = true)]
		INSTabViewDelegate Delegate { get; set; }

		[Export ("tabViewItemAtPoint:")]
		NSTabViewItem TabViewItemAtPoint (CGPoint point);

		[Export ("contentRect")]
		CGRect ContentRect { get; }

		[Export ("numberOfTabViewItems")]
		nint Count { get; }

		[Export ("indexOfTabViewItem:")]
		nint IndexOf (NSTabViewItem tabViewItem);

		[Export ("tabViewItemAtIndex:")]
		NSTabViewItem Item (nint index);

		[Export ("indexOfTabViewItemWithIdentifier:")]
		nint IndexOf (NSObject identifier);

		[Export ("tabPosition")]
		NSTabPosition TabPosition { get; set; }

		[Export ("tabViewBorderType")]
		NSTabViewBorderType BorderType { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSViewController))]
	interface NSTabViewController : NSTabViewDelegate, NSToolbarDelegate {
		[Export ("initWithNibName:bundle:")]
		NativeHandle Constructor ([NullAllowed] string nibNameOrNull, [NullAllowed] NSBundle nibBundleOrNull);

		[Export ("tabStyle")]
		NSTabViewControllerTabStyle TabStyle { get; set; }

		[Export ("tabView", ArgumentSemantic.Strong)]
		NSTabView TabView { get; set; }

#if !NET && MONOMAC
		// This property does not exist in any stable header - it was probably added in a beta and then removed.
		[Obsoleted (PlatformName.MacOSX, 10, 10, message: "Do not use; this API was removed.")]
		[Export ("segmentedControl", ArgumentSemantic.Strong)]
		NSSegmentedControl SegmentedControl { get; set; }
#endif

		[Export ("transitionOptions")]
		NSViewControllerTransitionOptions TransitionOptions { get; set; }

		[Export ("canPropagateSelectedChildViewControllerTitle")]
		bool CanPropagateSelectedChildViewControllerTitle { get; set; }

		[Export ("tabViewItems", ArgumentSemantic.Copy)]
		NSTabViewItem [] TabViewItems { get; set; }

		[Export ("selectedTabViewItemIndex")]
		nint SelectedTabViewItemIndex { get; set; }

		[Export ("addTabViewItem:")]
		void AddTabViewItem (NSTabViewItem tabViewItem);

		[Export ("insertTabViewItem:atIndex:")]
		void InsertTabViewItem (NSTabViewItem tabViewItem, nint index);

		[Export ("removeTabViewItem:")]
		void RemoveTabViewItem (NSTabViewItem tabViewItem);

		[Export ("tabViewItemForViewController:")]
		NSTabViewItem GetTabViewItem (NSViewController viewController);

		// 'new' since it's inlined from NSTabViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("tabView:shouldSelectTabViewItem:"), DelegateName ("NSTabViewPredicate")]
		new bool ShouldSelectTabViewItem (NSTabView tabView, NSTabViewItem item);

		// 'new' since it's inlined from NSTabViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("tabView:willSelectTabViewItem:"), EventArgs ("NSTabViewItem")]
		new void WillSelect (NSTabView tabView, NSTabViewItem item);

		// 'new' since it's inlined from NSTabViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("tabView:didSelectTabViewItem:"), EventArgs ("NSTabViewItem")]
		new void DidSelect (NSTabView tabView, NSTabViewItem item);

		// 'new' since it's inlined from NSToolbarViewDelegate as this instance needs [RequiresSuper]
		[return: NullAllowed]
		[RequiresSuper]
		[Export ("toolbar:itemForItemIdentifier:willBeInsertedIntoToolbar:"), DelegateName ("NSToolbarWillInsert")]
		new NSToolbarItem WillInsertItem (NSToolbar toolbar, string itemIdentifier, bool willBeInserted);

		// 'new' since it's inlined from NSToolbarViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("toolbarDefaultItemIdentifiers:"), DelegateName ("NSToolbarIdentifiers")]
		new string [] DefaultItemIdentifiers (NSToolbar toolbar);

		// 'new' since it's inlined from NSToolbarViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("toolbarAllowedItemIdentifiers:"), DelegateName ("NSToolbarIdentifiers")]
		new string [] AllowedItemIdentifiers (NSToolbar toolbar);

		// 'new' since it's inlined from NSToolbarViewDelegate as this instance needs [RequiresSuper]
		[RequiresSuper]
		[Export ("toolbarSelectableItemIdentifiers:"), DelegateName ("NSToolbarIdentifiers")]
		new string [] SelectableItemIdentifiers (NSToolbar toolbar);
	}

	interface INSTabViewDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model, Protocol]
	interface NSTabViewDelegate {
		[Export ("tabView:shouldSelectTabViewItem:"), DelegateName ("NSTabViewPredicate"), DefaultValue (true)]
		bool ShouldSelectTabViewItem (NSTabView tabView, NSTabViewItem item);

		[Export ("tabView:willSelectTabViewItem:"), EventArgs ("NSTabViewItem")]
		void WillSelect (NSTabView tabView, NSTabViewItem item);

		[Export ("tabView:didSelectTabViewItem:"), EventArgs ("NSTabViewItem")]
		void DidSelect (NSTabView tabView, NSTabViewItem item);

		[Export ("tabViewDidChangeNumberOfTabViewItems:")]
		void NumberOfItemsChanged (NSTabView tabView);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSTabViewItem : NSCoding {
		[Export ("initWithIdentifier:")]
		NativeHandle Constructor (NSObject identifier);

		[Export ("identifier", ArgumentSemantic.Retain)]
		NSObject Identifier { get; set; }

		[Export ("view", ArgumentSemantic.Retain)]
		NSView View { get; set; }

		[Export ("initialFirstResponder")]
		NSObject InitialFirstResponder { get; set; }

		[Export ("label")]
		string Label { get; set; }

		[Export ("color", ArgumentSemantic.Copy)]
		NSColor Color { get; set; }

		[Export ("tabState")]
		NSTabState TabState { get; }

		[Export ("tabView")]
		NSTabView TabView { get; }

		[Export ("drawLabel:inRect:")]
		void DrawLabel (bool shouldTruncateLabel, CGRect labelRect);

		[Export ("sizeOfLabel:")]
		CGSize SizeOfLabel (bool computeMin);

		[Export ("toolTip"), NullAllowed]
		string ToolTip { get; set; }

		[Export ("image", ArgumentSemantic.Strong)]
		NSImage Image { get; set; }

		[Export ("viewController", ArgumentSemantic.Strong)]
		NSViewController ViewController { get; set; }

		[Static, Export ("tabViewItemWithViewController:")]
		NSTabViewItem GetTabViewItem (NSViewController viewController);
	}

	




	/* 	We are presuming that Apple will be adding this to new classes in the future.
	Because they want NSTextAttachmentCell to conform to this, they are essentially
	implementing this protocol in the past. So, we have decided to do the same. */
	[NoMacCatalyst]
	[Protocol (Name = "NSTextAttachmentCell")]
	interface NSTextAttachmentCellProtocol {

		[Abstract]
		[Export ("drawWithFrame:inView:")]
		void DrawWithFrame (CGRect cellFrame, [NullAllowed] NSView controlView);

		[Abstract]
		[Export ("wantsToTrackMouse")]
		bool WantsToTrackMouse ();

		[Abstract]
		[Export ("drawWithFrame:inView:characterIndex:")]
		void DrawWithFrame (CGRect cellFrame, [NullAllowed] NSView controlView, nuint charIndex);

		[Abstract]
		[Export ("drawWithFrame:inView:characterIndex:layoutManager:")]
		void DrawWithFrame (CGRect cellFrame, [NullAllowed] NSView controlView, nuint charIndex, NSLayoutManager layoutManager);

		[Abstract]
		[Export ("highlight:withFrame:inView:")]
		void Highlight (bool highlight, CGRect cellFrame, NSView controlView);

		[Abstract]
		[Export ("trackMouse:inRect:ofView:untilMouseUp:")]
		bool TrackMouse (NSEvent theEvent, CGRect cellFrame, NSView controlView, bool untilMouseUp);

		[Abstract]
		[Export ("cellSize")]
		CGSize CellSize { get; }

		[Abstract]
		[Export ("cellBaselineOffset")]
		CGPoint CellBaselineOffset { get; }

		[Abstract]
		[Export ("attachment")]
		[NullAllowed]
		NSTextAttachment Attachment { get; set; }

		[Abstract]
		[Export ("wantsToTrackMouseForEvent:inRect:ofView:atCharacterIndex:")]
		bool WantsToTrackMouse (NSEvent theEvent, CGRect cellFrame, NSView controlView, nuint charIndex);

		[Abstract]
		[Export ("trackMouse:inRect:ofView:atCharacterIndex:untilMouseUp:")]
		bool TrackMouse (NSEvent theEvent, CGRect cellFrame, NSView controlView, nuint charIndex, bool untilMouseUp);

		[Abstract]
		[Export ("cellFrameForTextContainer:proposedLineFragment:glyphPosition:characterIndex:")]
		CGRect CellFrameForTextContainer (NSTextContainer textContainer, CGRect lineFrag, CGPoint position, nuint charIndex);
	}





	[NoMacCatalyst]
	[BaseType (typeof (NSControl), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSTextFieldDelegate) })]
	partial interface NSTextField : NSAccessibilityNavigableStaticText, NSUserInterfaceValidations, NSTextContent {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("selectText:")]
		void SelectText ([NullAllowed] NSObject sender);

		[Export ("textShouldBeginEditing:")]
		bool ShouldBeginEditing (NSText textObject);

		[Export ("textShouldEndEditing:")]
		bool ShouldEndEditing (NSText textObject);

		[Export ("textDidBeginEditing:")]
		void DidBeginEditing (NSNotification notification);

		[Export ("textDidEndEditing:")]
		void DidEndEditing (NSNotification notification);

		[Export ("textDidChange:")]
		void DidChange (NSNotification notification);

		[Export ("acceptsFirstResponder")]
		bool AcceptsFirstResponder ();

		//Detected properties
		[NullAllowed]
		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[NullAllowed]
		[Export ("textColor", ArgumentSemantic.Copy)]
		NSColor TextColor { get; set; }

		[Export ("bordered")]
		bool Bordered { [Bind ("isBordered")] get; set; }

		[Export ("bezeled")]
		bool Bezeled { [Bind ("isBezeled")] get; set; }

		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("selectable")]
		bool Selectable { [Bind ("isSelectable")] get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSTextFieldDelegate Delegate { get; set; }

		[Export ("bezelStyle")]
		NSTextFieldBezelStyle BezelStyle { get; set; }

		[Export ("allowsEditingTextAttributes")]
		bool AllowsEditingTextAttributes { get; set; }

		[Export ("importsGraphics")]
		bool ImportsGraphics { get; set; }

		[Export ("preferredMaxLayoutWidth")]
		nfloat PreferredMaxLayoutWidth { get; set; }

		[NullAllowed]
		[Export ("placeholderString", ArgumentSemantic.Copy)]
		string PlaceholderString { get; set; }

		[NullAllowed]
		[Export ("placeholderAttributedString", ArgumentSemantic.Copy)]
		NSAttributedString PlaceholderAttributedString { get; set; }

		[Export ("maximumNumberOfLines", ArgumentSemantic.Assign)]
		nint MaximumNumberOfLines { get; set; }

		[Export ("allowsDefaultTighteningForTruncation")]
		bool AllowsDefaultTighteningForTruncation { get; set; }

		[Export ("lineBreakStrategy", ArgumentSemantic.Assign)]
		NSLineBreakStrategy LineBreakStrategy { get; set; }

		[Static]
		[Export ("labelWithString:")]
		NSTextField CreateLabel (string stringValue);

		[Static]
		[Export ("wrappingLabelWithString:")]
		NSTextField CreateWrappingLabel (string stringValue);

		[Static]
		[Export ("labelWithAttributedString:")]
		NSTextField CreateLabel (NSAttributedString attributedStringValue);

		[Static]
		[Export ("textFieldWithString:")]
		NSTextField CreateTextField ([NullAllowed] string stringValue);

		NSTextContentType ContentType {
			[Wrap ("NSTextContentTypeExtensions.GetValue (GetContentType ()!)")]
			get;
			[Wrap ("SetContentType (value.GetConstant()!)")]
			set;
		}

		[Mac (15, 2)]
		[Export ("allowsWritingTools")]
		bool AllowsWritingTools { get; set; }
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSTextField))]
	interface NSTextField_NSTouchBar {
		[Export ("isAutomaticTextCompletionEnabled")]
		bool GetAutomaticTextCompletionEnabled ();

		[Export ("automaticTextCompletionEnabled:")]
		void SetAutomaticTextCompletionEnabled (bool enabled);

		[Export ("allowsCharacterPickerTouchBarItem")]
		bool GetAllowsCharacterPickerTouchBarItem ();

		[Export ("setAllowsCharacterPickerTouchBarItem:")]
		void SetAllowsCharacterPickerTouchBarItem (bool allows);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextField))]
	interface NSSecureTextField {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);
	}

	interface INSTextFieldDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSTextFieldDelegate {
		[Export ("control:textShouldBeginEditing:"), DelegateName ("NSControlText"), DefaultValue (true)]
		bool TextShouldBeginEditing (NSControl control, NSText fieldEditor);

		[Export ("control:textShouldEndEditing:"), DelegateName ("NSControlText"), DefaultValue (true)]
		bool TextShouldEndEditing (NSControl control, NSText fieldEditor);

		[Export ("control:didFailToFormatString:errorDescription:"), DelegateName ("NSControlTextError"), DefaultValue (true)]
		bool DidFailToFormatString (NSControl control, string str, string error);

		[Export ("control:didFailToValidatePartialString:errorDescription:"), EventArgs ("NSControlTextError")]
		void DidFailToValidatePartialString (NSControl control, string str, string error);

		[Export ("control:isValidObject:"), DelegateName ("NSControlTextValidation"), DefaultValue (true)]
		bool IsValidObject (NSControl control, NSObject objectToValidate);

		[Export ("control:textView:doCommandBySelector:"), DelegateName ("NSControlCommand"), DefaultValue (false)]
		bool DoCommandBySelector (NSControl control, NSTextView textView, Selector commandSelector);

		[Export ("control:textView:completions:forPartialWordRange:indexOfSelectedItem:"), DelegateName ("NSControlTextFilter"), DefaultValue ("new string[0]")]
		string [] GetCompletions (NSControl control, NSTextView textView, string [] words, NSRange charRange, ref nint index);

		[Export ("controlTextDidEndEditing:"), EventArgs ("NSNotification")]
		void EditingEnded (NSNotification notification);

		[Export ("controlTextDidChange:"), EventArgs ("NSNotification")]
		void Changed (NSNotification notification);

		[Export ("controlTextDidBeginEditing:"), EventArgs ("NSNotification")]
		void EditingBegan (NSNotification notification);

		[Export ("textField:textView:candidatesForSelectedRange:"), DelegateName ("NSTextFieldGetCandidates"), DefaultValue (null)]
		[return: NullAllowed]
		NSObject [] GetCandidates (NSTextField textField, NSTextView textView, NSRange selectedRange);

		[Export ("textField:textView:candidates:forSelectedRange:"), DelegateName ("NSTextFieldTextCheckingResults"), DefaultValue (null)]
		NSTextCheckingResult [] GetTextCheckingResults (NSTextField textField, NSTextView textView, NSTextCheckingResult [] candidates, NSRange selectedRange);

		[Export ("textField:textView:shouldSelectCandidateAtIndex:"), DelegateName ("NSTextFieldSelectCandidate"), DefaultValue (false)]
		bool ShouldSelectCandidate (NSTextField textField, NSTextView textView, nuint index);
	}

	interface INSComboBoxDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSTextFieldDelegate))]
	[Model]
	[Protocol]
	interface NSComboBoxDelegate {
		[Export ("comboBoxWillPopUp:")]
		void WillPopUp (NSNotification notification);

		[Export ("comboBoxWillDismiss:")]
		void WillDismiss (NSNotification notification);

		[Export ("comboBoxSelectionDidChange:")]
		void SelectionChanged (NSNotification notification);

		[Export ("comboBoxSelectionIsChanging:")]
		void SelectionIsChanging (NSNotification notification);
	}

	interface INSTokenFieldCellDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSTokenFieldCellDelegate {
		[Export ("tokenFieldCell:completionsForSubstring:indexOfToken:indexOfSelectedItem:")]
		NSArray GetCompletionStrings (NSTokenFieldCell tokenFieldCell, string substring, nint tokenIndex, ref nint selectedIndex);

		[Export ("tokenFieldCell:shouldAddObjects:atIndex:")]
		NSArray ShouldAddObjects (NSTokenFieldCell tokenFieldCell, NSObject [] tokens, nuint index);

		[Export ("tokenFieldCell:displayStringForRepresentedObject:")]
		string GetDisplayString (NSTokenFieldCell tokenFieldCell, NSObject representedObject);

		[Export ("tokenFieldCell:editingStringForRepresentedObject:")]
		string GetEditingString (NSTokenFieldCell tokenFieldCell, NSObject representedObject);

		[Export ("tokenFieldCell:representedObjectForEditingString:")]
		[return: NullAllowed]
		NSObject GetRepresentedObject (NSTokenFieldCell tokenFieldCell, string editingString);

		[Export ("tokenFieldCell:writeRepresentedObjects:toPasteboard:")]
		bool WriteRepresentedObjects (NSTokenFieldCell tokenFieldCell, NSObject [] objects, NSPasteboard pboard);

		[Export ("tokenFieldCell:readFromPasteboard:")]
		NSObject [] Read (NSTokenFieldCell tokenFieldCell, NSPasteboard pboard);

		[Export ("tokenFieldCell:menuForRepresentedObject:")]
		NSMenu GetMenu (NSTokenFieldCell tokenFieldCell, NSObject representedObject);

		[Export ("tokenFieldCell:hasMenuForRepresentedObject:")]
		bool HasMenu (NSTokenFieldCell tokenFieldCell, NSObject representedObject);

		[Export ("tokenFieldCell:styleForRepresentedObject:")]
		NSTokenStyle GetStyle (NSTokenFieldCell tokenFieldCell, NSObject representedObject);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell))]
	interface NSTextFieldCell {
		[DesignatedInitializer]
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("initImageCell:")]
		NativeHandle Constructor (NSImage image);

		[Export ("setUpFieldEditorAttributes:")]
		NSText SetUpFieldEditorAttributes (NSText textObj);

		//Detected properties
		[NullAllowed]
		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[Export ("drawsBackground")]
		bool DrawsBackground { get; set; }

		[NullAllowed]
		[Export ("textColor", ArgumentSemantic.Copy)]
		NSColor TextColor { get; set; }

		[Export ("bezelStyle")]
		NSTextFieldBezelStyle BezelStyle { get; set; }

		[NullAllowed]
		[Export ("placeholderString")]
		string PlaceholderString { get; set; }

		[NullAllowed]
		[Export ("placeholderAttributedString", ArgumentSemantic.Copy)]
		NSAttributedString PlaceholderAttributedString { get; set; }

		[NullAllowed]
		[Export ("allowedInputSourceLocales")]
		string [] AllowedInputSourceLocales { get; set; }

		[Export ("wantsNotificationForMarkedText")]
		[Override]
		bool WantsNotificationForMarkedText { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextFieldCell))]
	[DisableDefaultCtor]
	interface NSTokenFieldCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("tokenStyle")]
		NSTokenStyle TokenStyle { get; set; }

		[Export ("completionDelay")]
		double CompletionDelay { get; set; }

		[Static]
		[Export ("defaultCompletionDelay")]
		double DefaultCompletionDelay { get; }

		[Export ("tokenizingCharacterSet", ArgumentSemantic.Copy), NullAllowed]
		NSCharacterSet CharacterSet { get; set; }

		[Static]
		[Export ("defaultTokenizingCharacterSet")]
		NSCharacterSet DefaultCharacterSet { get; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSTokenFieldCellDelegate Delegate { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextFieldCell))]
	interface NSSecureTextFieldCell {
		[Export ("initTextCell:")]
		NativeHandle Constructor (string aString);

		[Export ("echosBullets")]
		bool EchosBullets { get; set; }
	}



	[NoMacCatalyst]
	[BaseType (typeof (NSTextBlock))]
	[DisableDefaultCtor]
	interface NSTextTableBlock {
		[DesignatedInitializer]
		[Export ("initWithTable:startingRow:rowSpan:startingColumn:columnSpan:")]
		NativeHandle Constructor (NSTextTable table, nint row, nint rowSpan, nint col, nint colSpan);

		[Export ("table")]
		NSTextTable Table { get; }

		[Export ("startingRow")]
		nint StartingRow { get; }

		[Export ("rowSpan")]
		nint RowSpan { get; }

		[Export ("startingColumn")]
		nint StartingColumn { get; }

		[Export ("columnSpan")]
		nint ColumnSpan { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSTextBlock))]
	interface NSTextTable {
		[Export ("rectForBlock:layoutAtPoint:inRect:textContainer:characterRange:")]
		CGRect GetRectForBlock (NSTextTableBlock block, CGPoint startingPoint, CGRect rect, NSTextContainer textContainer, NSRange charRange);

		[Export ("boundsRectForBlock:contentRect:inRect:textContainer:characterRange:")]
		CGRect GetBoundsRect (NSTextTableBlock block, CGRect contentRect, CGRect rect, NSTextContainer textContainer, NSRange charRange);

		[Export ("drawBackgroundForBlock:withFrame:inView:characterRange:layoutManager:")]
		void DrawBackground (NSTextTableBlock block, CGRect frameRect, NSView controlView, NSRange charRange, NSLayoutManager layoutManager);

		//Detected properties
		[Export ("numberOfColumns")]
		nint Columns { get; set; }

		[Export ("layoutAlgorithm")]
		NSTextTableLayoutAlgorithm LayoutAlgorithm { get; set; }

		[Export ("collapsesBorders")]
		bool CollapsesBorders { get; set; }

		[Export ("hidesEmptyCells")]
		bool HidesEmptyCells { get; set; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSTextInput {
		[Abstract]
		[Deprecated (PlatformName.MacOSX, 10, 6)]
		[Export ("insertText:")]
		void InsertText (NSObject insertString);

		// The doCommandBySelector: conflicts with NSTextViewDelegate in generated code
		// It's also deprecated in NSTextInput, and why we're not adding it here

		[Abstract]
		[Export ("setMarkedText:selectedRange:")]
		void SetMarkedText (NSObject @string, NSRange selRange);

		[Abstract]
		[Export ("unmarkText")]
		void UnmarkText ();

		[Abstract]
		[Export ("hasMarkedText")]
		bool HasMarkedText { get; }

		[Abstract]
		[Export ("conversationIdentifier")]
		nint ConversationIdentifier { get; }

		[Abstract]
		[Export ("attributedSubstringFromRange:")]
		NSAttributedString GetAttributedSubstring (NSRange range);

		[Abstract]
		[Export ("markedRange")]
		NSRange MarkedRange { get; }

		[Abstract]
		[Export ("selectedRange")]
		NSRange SelectedRange { get; }

		[Abstract]
		[Export ("firstRectForCharacterRange:")]
		CGRect GetFirstRectForCharacterRange (NSRange range);

		[Abstract]
		[Export ("characterIndexForPoint:")]
		nuint GetCharacterIndex (CGPoint point);

		[Abstract]
		[Export ("validAttributesForMarkedText")]
		NSString [] ValidAttributesForMarkedText { get; }
	}

	

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Protocol, Model]
	interface NSTextInputClient {
#if NET
		[Abstract]
#endif
		[Export ("insertText:replacementRange:")]
		void InsertText (NSObject text, NSRange replacementRange);

#if NET
		[Abstract]
#endif
		[Export ("setMarkedText:selectedRange:replacementRange:")]
		void SetMarkedText (NSObject text, NSRange selectedRange, NSRange replacementRange);

#if NET
		[Abstract]
#endif
		[Export ("unmarkText")]
		void UnmarkText ();

#if NET
		[Abstract]
#endif
		[Export ("selectedRange")]
		NSRange SelectedRange { get; }

#if NET
		[Abstract]
#endif
		[Export ("markedRange")]
		NSRange MarkedRange { get; }

#if NET
		[Abstract]
#endif
		[Export ("hasMarkedText")]
		bool HasMarkedText { get; }

#if NET
		[Abstract]
#endif
		[return: NullAllowed]
		[Export ("attributedSubstringForProposedRange:actualRange:")]
		NSAttributedString GetAttributedSubstring (NSRange proposedRange, out NSRange actualRange);

#if NET
		[Abstract]
#endif
		[Export ("validAttributesForMarkedText")]
		NSString [] ValidAttributesForMarkedText { get; }

#if NET
		[Abstract]
#endif
		[Export ("firstRectForCharacterRange:actualRange:")]
		CGRect GetFirstRect (NSRange characterRange, out NSRange actualRange);

#if NET
		[Abstract]
#endif
		[Export ("characterIndexForPoint:")]
		nuint GetCharacterIndex (CGPoint point);

		[Export ("attributedString")]
		NSAttributedString AttributedString { get; }

		[Export ("fractionOfDistanceThroughGlyphForPoint:")]
		nfloat GetFractionOfDistanceThroughGlyph (CGPoint point);

		[Export ("baselineDeltaForCharacterAtIndex:")]
		nfloat GetBaselineDelta (nuint charIndex);

		[Export ("windowLevel")]
		NSWindowLevel WindowLevel { get; }

		[Export ("drawsVerticallyForCharacterAtIndex:")]
		bool DrawsVertically (nuint charIndex);

		[Mac (14, 0)]
		[Export ("unionRectInVisibleSelectedRange")]
		CGRect UnionRectInVisibleSelectedRange { get; }

		[Mac (14, 0)]
		[Export ("documentVisibleRect")]
		CGRect DocumentVisibleRect { get; }

		[Mac (14, 0)]
		[Export ("preferredTextAccessoryPlacement")]
		NSTextCursorAccessoryPlacement PreferredTextAccessoryPlacement { get; }

		[Mac (15, 0)]
		[Export ("supportsAdaptiveImageGlyph")]
		bool SupportsAdaptiveImageGlyph { get; }

		[Mac (15, 0)]
		[Export ("insertAdaptiveImageGlyph:replacementRange:")]
		void InsertAdaptiveImageGlyph (NSAdaptiveImageGlyph adaptiveImageGlyph, NSRange replacementRange);
	}

	

	[NoMacCatalyst]
	[BaseType (typeof (NSTextField))]
	interface NSTokenField {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("tokenStyle")]
		NSTokenStyle TokenStyle { get; set; }

		[Export ("completionDelay")]
		double CompletionDelay { get; set; }

		[Static]
		[Export ("defaultCompletionDelay")]
		double DefaultCompletionDelay { get; }

		[Static]
		[Export ("defaultTokenizingCharacterSet")]
		NSCharacterSet DefaultCharacterSet { get; }

		//Detected properties
		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSTokenFieldDelegate Delegate { get; set; }

		[Export ("tokenizingCharacterSet", ArgumentSemantic.Copy)]
		NSCharacterSet CharacterSet { get; set; }
	}

	interface INSTokenFieldDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSTokenFieldDelegate {
		[Export ("tokenField:completionsForSubstring:indexOfToken:indexOfSelectedItem:")]
		string [] GetCompletionStrings (NSTokenField tokenField, string substring, nint tokenIndex, nint selectedIndex);

		[Export ("tokenField:shouldAddObjects:atIndex:")]
		NSArray ShouldAddObjects (NSTokenField tokenField, NSArray tokens, nuint index);

		[Export ("tokenField:displayStringForRepresentedObject:")]
		string GetDisplayString (NSTokenField tokenField, NSObject representedObject);

		[Export ("tokenField:editingStringForRepresentedObject:")]
		string GetEditingString (NSTokenField tokenField, NSObject representedObject);

		[Export ("tokenField:representedObjectForEditingString:")]
		[return: NullAllowed]
		NSObject GetRepresentedObject (NSTokenField tokenField, string editingString);

		[Export ("tokenField:writeRepresentedObjects:toPasteboard:")]
		bool WriteRepresented (NSTokenField tokenField, NSArray objects, NSPasteboard pboard);

		[Export ("tokenField:readFromPasteboard:")]
		NSObject [] Read (NSTokenField tokenField, NSPasteboard pboard);

		[Export ("tokenField:menuForRepresentedObject:")]
		NSMenu GetMenu (NSTokenField tokenField, NSObject representedObject);

		[Export ("tokenField:hasMenuForRepresentedObject:")]
		bool HasMenu (NSTokenField tokenField, NSObject representedObject);

		[Export ("tokenField:styleForRepresentedObject:")]
		NSTokenStyle GetStyle (NSTokenField tokenField, NSObject representedObject);

	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSToolbarDelegate) })]
	[DisableDefaultCtor] // init was added in 10.13
	partial interface NSToolbar {
		[MacCatalyst (13, 1)]
		[Export ("init")]
		NativeHandle Constructor ();

		[DesignatedInitializer]
		[Export ("initWithIdentifier:")]
		NativeHandle Constructor (string identifier);

		[Export ("insertItemWithItemIdentifier:atIndex:")]
		void InsertItem (string itemIdentifier, nint index);

		[Export ("removeItemAtIndex:")]
		void RemoveItem (nint index);

		[Export ("runCustomizationPalette:")]
		void RunCustomizationPalette ([NullAllowed] NSObject sender);

		[Export ("customizationPaletteIsRunning")]
		bool IsCustomizationPaletteRunning { get; }

		[Export ("identifier")]
		string Identifier { get; }

		[Export ("items")]
		NSToolbarItem [] Items { get; }

		[NullAllowed]
		[Export ("visibleItems")]
		NSToolbarItem [] VisibleItems { get; }

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "Use the 'ItemIdentifiers' and 'DisplayMode' properties instead.")]
		[Deprecated (PlatformName.MacCatalyst, 18, 0, message: "Use the 'ItemIdentifiers' and 'DisplayMode' properties instead.")]
		[Export ("setConfigurationFromDictionary:")]
		void SetConfigurationFromDictionary (NSDictionary configDict);

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "Use the 'ItemIdentifiers' and 'DisplayMode' properties instead.")]
		[Deprecated (PlatformName.MacCatalyst, 18, 0, message: "Use the 'ItemIdentifiers' and 'DisplayMode' properties instead.")]
		[Export ("configurationDictionary")]
		NSDictionary ConfigurationDictionary { get; }

		[Export ("validateVisibleItems")]
		void ValidateVisibleItems ();

		//Detected properties
		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSToolbarDelegate Delegate { get; set; }

		[Export ("visible")]
		bool Visible { [Bind ("isVisible")] get; set; }

		[Export ("displayMode")]
		NSToolbarDisplayMode DisplayMode { get; set; }

		[Export ("selectedItemIdentifier"), NullAllowed]
		string SelectedItemIdentifier { get; set; }

		[Deprecated (PlatformName.MacOSX, 14, 0)]
		[Deprecated (PlatformName.MacCatalyst, 17, 0)]
		[Export ("sizeMode")]
		NSToolbarSizeMode SizeMode { get; set; }

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "No longer supported.")]
		[Deprecated (PlatformName.MacCatalyst, 18, 0, message: "No longer supported.")]
		[Export ("showsBaselineSeparator")]
		bool ShowsBaselineSeparator { get; set; }

		[Export ("allowsUserCustomization")]
		bool AllowsUserCustomization { get; set; }

		[Export ("autosavesConfiguration")]
		bool AutosavesConfiguration { get; set; }

		[NoMacCatalyst]
		[Field ("NSToolbarSeparatorItemIdentifier")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Ignored by system.")]
		NSString NSToolbarSeparatorItemIdentifier { get; }

		[Field ("NSToolbarSpaceItemIdentifier")]
		NSString NSToolbarSpaceItemIdentifier { get; }

		[Field ("NSToolbarFlexibleSpaceItemIdentifier")]
		NSString NSToolbarFlexibleSpaceItemIdentifier { get; }

		[Field ("NSToolbarShowColorsItemIdentifier")]
		NSString NSToolbarShowColorsItemIdentifier { get; }

		[Field ("NSToolbarShowFontsItemIdentifier")]
		NSString NSToolbarShowFontsItemIdentifier { get; }

		[NoMacCatalyst]
		[Field ("NSToolbarCustomizeToolbarItemIdentifier")]
		[Deprecated (PlatformName.MacOSX, 11, 0, message: "Ignored by system.")]
		NSString NSToolbarCustomizeToolbarItemIdentifier { get; }

		[Field ("NSToolbarPrintItemIdentifier")]
		NSString NSToolbarPrintItemIdentifier { get; }

		[MacCatalyst (13, 1)]
		[Export ("allowsExtensionItems")]
		bool AllowsExtensionItems { get; set; }

		[MacCatalyst (13, 1)]
		[Field ("NSToolbarToggleSidebarItemIdentifier")]
		NSString NSToolbarToggleSidebarItemIdentifier { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSToolbarCloudSharingItemIdentifier")]
		NSString NSToolbarCloudSharingItemIdentifier { get; }

		[Deprecated (PlatformName.MacOSX, 14, 0, message: "'CenteredItemIdentifiers' should be used instead.")]
		[Deprecated (PlatformName.MacCatalyst, 17, 0, message: "'CenteredItemIdentifiers' should be used instead.")]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("centeredItemIdentifier")]
		string CenteredItemIdentifier { get; set; }

		[NoMacCatalyst]
		[Field ("NSToolbarSidebarTrackingSeparatorItemIdentifier")]
		NSString NSToolbarSidebarTrackingSeparatorItemIdentifier { get; }

		[MacCatalyst (14, 0)]
		[NoMac]
		[Field ("NSToolbarPrimarySidebarTrackingSeparatorItemIdentifier", "UIKit")]
		NSString PrimarySidebarTrackingSeparatorItemIdentifier { get; }

		[MacCatalyst (14, 0)]
		[NoMac]
		[Field ("NSToolbarSupplementarySidebarTrackingSeparatorItemIdentifier", "UIKit")]
		NSString SupplementarySidebarTrackingSeparatorItemIdentifier { get; }

		[Mac (13, 0), MacCatalyst (16, 0)]
		[Export ("centeredItemIdentifiers", ArgumentSemantic.Copy)]
		NSSet<NSString> CenteredItemIdentifiers { get; set; }

		[MacCatalyst (16, 0)]
		[Mac (13, 0)]
		[Field ("NSToolbarItemKey")]
		NSString NSToolbarItemKey { get; }

		[Mac (14, 0), MacCatalyst (17, 0)]
		[Field ("NSToolbarToggleInspectorItemIdentifier")]
		NSString NSToolbarToggleInspectorItemIdentifier { get; }

		[NoMacCatalyst, Mac (14, 0)]
		[Field ("NSToolbarInspectorTrackingSeparatorItemIdentifier")]
		NSString NSToolbarInspectorTrackingSeparatorItemIdentifier { get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Field ("NSToolbarNewIndexKey")]
		NSString NSToolbarNewIndexKey { get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Export ("allowsDisplayModeCustomization")]
		bool AllowsDisplayModeCustomization { get; set; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Export ("itemIdentifiers", ArgumentSemantic.Copy)]
		string [] ItemIdentifiers { get; set; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Export ("removeItemWithItemIdentifier:")]
		void RemoveItem (string itemIdentifier);

		[Mac (15, 2), MacCatalyst (18, 2)]
		[Field ("NSToolbarWritingToolsItemIdentifier")]
		NSString NSToolbarWritingToolsItemIdentifier { get; }
	}

	interface INSToolbarDelegate { }

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[Model, Protocol]
	interface NSToolbarDelegate {
		[return: NullAllowed]
		[Export ("toolbar:itemForItemIdentifier:willBeInsertedIntoToolbar:"), DelegateName ("NSToolbarWillInsert"), DefaultValue (null)]
		NSToolbarItem WillInsertItem (NSToolbar toolbar, string itemIdentifier, bool willBeInserted);

		[Export ("toolbarDefaultItemIdentifiers:"), DelegateName ("NSToolbarIdentifiers"), DefaultValue (null)]
		string [] DefaultItemIdentifiers (NSToolbar toolbar);

		[Export ("toolbarAllowedItemIdentifiers:"), DelegateName ("NSToolbarIdentifiers"), DefaultValue (null)]
		string [] AllowedItemIdentifiers (NSToolbar toolbar);

		[Export ("toolbarSelectableItemIdentifiers:"), DelegateName ("NSToolbarIdentifiers"), DefaultValue (null)]
		string [] SelectableItemIdentifiers (NSToolbar toolbar);

		[Export ("toolbarWillAddItem:"), EventArgs ("NSNotification")]
		void WillAddItem (NSNotification notification);

		[Export ("toolbarDidRemoveItem:"), EventArgs ("NSNotification")]
		void DidRemoveItem (NSNotification notification);

		[Mac (13, 0), MacCatalyst (16, 0), DelegateName ("NSToolbarImmovableItemIdentifiers"), DefaultValue (null)]
		[Export ("toolbarImmovableItemIdentifiers:")]
		NSSet<NSString> GetToolbarImmovableItemIdentifiers (NSToolbar toolbar);

		[Mac (13, 0), MacCatalyst (16, 0)]
		[Export ("toolbar:itemIdentifier:canBeInsertedAtIndex:"), DelegateName ("NSToolbarCanInsert"), DefaultValue (true)]
		bool GetItemCanBeInsertedAt (NSToolbar toolbar, string itemIdentifier, nint index);
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSToolbarItemValidation {
		[Abstract]
		[Export ("validateToolbarItem:")]
		bool ValidateToolbarItem (NSToolbarItem item);
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSObject))]
	interface NSObject_NSToolbarItemValidation {
		[Export ("validateToolbarItem:")]
		bool ValidateToolbarItem (NSToolbarItem item);
	}

	/*
	[NoTV, NoiOS]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	interface NSToolbarItem : NSCopying, NSMenuItemValidation, NSValidatedUserInterfaceItem
#if __MACCATALYST__
		, UIPopoverPresentationControllerSourceItem
#endif
	{
		[DesignatedInitializer]
		[Export ("initWithItemIdentifier:")]
		NativeHandle Constructor (string itemIdentifier);

		[Export ("itemIdentifier")]
		string Identifier { get; }

		[NullAllowed]
		[Export ("toolbar")]
		NSToolbar Toolbar { get; }

		[Export ("validate")]
		void Validate ();

		[Deprecated (PlatformName.MacOSX, 15, 0, message: "Duplicates are no longer supported.")]
		[Deprecated (PlatformName.MacCatalyst, 18, 0, message: "Duplicates are no longer supported.")]
		[Export ("allowsDuplicatesInToolbar")]
		bool AllowsDuplicatesInToolbar { get; }

		//Detected properties
		[Export ("label")]
		string Label { get; set; }

		[Export ("paletteLabel")]
		string PaletteLabel { get; set; }

		[Export ("toolTip"), NullAllowed]
		string ToolTip { get; set; }

		[NoMacCatalyst]
		[Export ("menuFormRepresentation", ArgumentSemantic.Retain)]
		NSMenuItem MenuFormRepresentation { get; set; }

#pragma warning disable 0108 // Protocol is read only but must be get/set
		[Export ("action"), NullAllowed]
		Selector Action { get; set; }
#pragma warning restore 0108

		[Export ("target", ArgumentSemantic.Weak), NullAllowed]
		NSObject Target { get; set; }

#pragma warning disable 0108 // Protocol is read only but must be get/set
		[Export ("tag")]
		nint Tag { get; set; }
#pragma warning restore 0108

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("image", ArgumentSemantic.Retain), NullAllowed]
#if XAMCORE_5_0 && __MACCATALYST__
		UIImage Image { get; set; }
#else
		NSImage Image { get; set; }
#endif

		// We incorrectly bound 'Image' as NSImage in Mac Catalyst.
		// Provide this alternative until we can make 'Image' correct in XAMCORE_5_0
		// Obsolete this member in XAMCORE_5_0
		// and remove it in XAMCORE_6_0
#if __MACCATALYST__ && !XAMCORE_6_0
#if XAMCORE_5_0
		[Obsolete ("Use 'Image' instead.")]
#endif
		[Sealed]
		[Export ("image", ArgumentSemantic.Retain), NullAllowed]
		UIImage UIImage { get; set; }
#endif

		[NoMacCatalyst]
		[Export ("view", ArgumentSemantic.Retain)]
		NSView View { get; set; }

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use system constraints instead.")]
		[Export ("minSize")]
		CGSize MinSize { get; set; }

#if XAMCORE_5_0
		[NoMacCatalyst]
#else
		[Obsoleted (PlatformName.MacCatalyst, 13, 1, message: "Do not use; this API does not exist on this platform.")]
#endif
		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use system constraints instead.")]
		[Export ("maxSize")]
		CGSize MaxSize { get; set; }

#if XAMCORE_5_0
		[Export ("visibilityPriority")]
		NSToolbarItemVisibilityPriority VisibilityPriority { get; set; }
#else
		/// <summary>Indicate which toolbar items should be kept when the toolbar space is limited.</summary>
		/// <remarks>
		///   <para>The valid values come from the <see cref="NSToolbarItemVisibilityPriority" /> enum, and they can be referenced as follows:</para>
		///   <example>
		///     <code lang="csharp lang-csharp"><![CDATA[
		/// NSToolbarItem item = GetItem ();
		/// item.VisibilityPriority = (nint) (long) NSToolbarItemVisibilityPriority.High;
		/// ]]></code>
		///   </example>
		/// </remarks>
		[Export ("visibilityPriority")]
		nint VisibilityPriority { get; set; }
#endif

		[Export ("autovalidates")]
		bool Autovalidates { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("title")]
		string Title { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("bordered")]
		bool Bordered { [Bind ("isBordered")] get; set; }

		[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("navigational")]
		bool Navigational { [Bind ("isNavigational")] get; set; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("itemMenuFormRepresentation", ArgumentSemantic.Copy)]
		[NullAllowed]
		UIMenuElement ItemMenuFormRepresentation { get; set; }

		[Mac (13, 0)]
		[MacCatalyst (16, 0)]
		[Export ("possibleLabels", ArgumentSemantic.Copy)]
		NSSet<NSString> PossibleLabels { get; set; }

		[Mac (14, 0), MacCatalyst (17, 0)]
		[Export ("visible")]
		bool Visible { [Bind ("isVisible")] get; }

		[Mac (15, 0), MacCatalyst (18, 0)]
		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

		[Static]
		[NoMac]
		[MacCatalyst (13, 1)]
		[Export ("itemWithItemIdentifier:barButtonItem:")]
		NSToolbarItem Create (string itemIdentifier, UIBarButtonItem barButtonItem);
	}*/

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSToolbarItem))]
	interface NSToolbarItemGroup {
		[Export ("initWithItemIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string itemIdentifier);

		[Export ("subitems", ArgumentSemantic.Copy)]
		NSToolbarItem [] Subitems { get; set; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("groupWithItemIdentifier:titles:selectionMode:labels:target:action:")]
		NSToolbarItemGroup Create (string itemIdentifier, string [] titles, NSToolbarItemGroupSelectionMode selectionMode, [NullAllowed] string [] labels, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("groupWithItemIdentifier:images:selectionMode:labels:target:action:")]
		NSToolbarItemGroup Create (string itemIdentifier, NSImage [] images, NSToolbarItemGroupSelectionMode selectionMode, [NullAllowed] string [] labels, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[MacCatalyst (13, 1)]
		[Export ("controlRepresentation", ArgumentSemantic.Assign)]
		NSToolbarItemGroupControlRepresentation ControlRepresentation { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("selectionMode", ArgumentSemantic.Assign)]
		NSToolbarItemGroupSelectionMode SelectionMode { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("selectedIndex")]
		nint SelectedIndex { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("setSelected:atIndex:")]
		void SetSelected (bool selected, nint index);

		[MacCatalyst (13, 1)]
		[Export ("isSelectedAtIndex:")]
		bool GetSelected (nint index);
	}



	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSTouch))]
	interface NSTouch_NSTouchBar {
		[Export ("type")]
		NSTouchType GetTouchType ();

		[Export ("locationInView:")]
		CGPoint GetLocation ([NullAllowed] NSView view);

		[Export ("previousLocationInView:")]
		CGPoint GetPreviousLocation ([NullAllowed] NSView view);
	}

	[DesignatedDefaultCtor]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSTouchBarDelegate) })]
	interface NSTouchBar : NSCoding {
		[NullAllowed, Export ("customizationIdentifier")]
		string CustomizationIdentifier { get; set; }

		[Export ("customizationAllowedItemIdentifiers", ArgumentSemantic.Copy)]
		string [] CustomizationAllowedItemIdentifiers { get; set; }

		[Export ("customizationRequiredItemIdentifiers", ArgumentSemantic.Copy)]
		string [] CustomizationRequiredItemIdentifiers { get; set; }

		[Export ("defaultItemIdentifiers", ArgumentSemantic.Copy)]
		string [] DefaultItemIdentifiers { get; set; }

		[NullAllowed, Export ("principalItemIdentifier")]
		string PrincipalItemIdentifier { get; set; }

		[Export ("templateItems", ArgumentSemantic.Copy)]
		NSSet<NSTouchBarItem> TemplateItems { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		INSTouchBarDelegate Delegate { get; set; }

		[return: NullAllowed]
		[Export ("itemForIdentifier:")]
		NSTouchBarItem GetItemForIdentifier (string identifier);

		[Export ("visible")]
		bool Visible { [Bind ("isVisible")] get; }

		[NullAllowed, Export ("escapeKeyReplacementItemIdentifier")]
		string EscapeKeyReplacementItemIdentifier { get; set; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("automaticCustomizeTouchBarMenuItemEnabled")]
		bool AutomaticCustomizeTouchBarMenuItemEnabled { [Bind ("isAutomaticCustomizeTouchBarMenuItemEnabled")] get; set; }
	}

	interface INSTouchBarDelegate { }

	[MacCatalyst (13, 1)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSTouchBarDelegate {
		[Export ("touchBar:makeItemForIdentifier:"), DelegateName ("NSTouchBarMakeItem"), DefaultValue (null)]
		[return: NullAllowed]
		NSTouchBarItem MakeItem (NSTouchBar touchBar, string identifier);
	}

	/*
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSTouchBarItem : NSCoding {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[Wrap ("this (identifier.GetConstant ())")]
		NativeHandle Constructor (NSTouchBarItemIdentifier identifier);

		[Export ("identifier")]
		string Identifier { get; }

		[Export ("visibilityPriority")]
		float VisibilityPriority { get; set; }

		[NoMacCatalyst]
		[NullAllowed, Export ("view")]
		NSView View { get; }

		[NoMacCatalyst]
		[NullAllowed, Export ("viewController")]
		NSViewController ViewController { get; }

		[Export ("customizationLabel")]
		string CustomizationLabel { get; }

		[Export ("visible")]
		bool Visible { [Bind ("isVisible")] get; }
	}
	*/

	[MacCatalyst (13, 1)]
	public enum NSTouchBarItemIdentifier {
		[MacCatalyst (13, 1)]
		[Field ("NSTouchBarItemIdentifierFixedSpaceSmall")]
		FixedSpaceSmall,

		[MacCatalyst (13, 1)]
		[Field ("NSTouchBarItemIdentifierFixedSpaceLarge")]
		FixedSpaceLarge,

		[MacCatalyst (13, 1)]
		[Field ("NSTouchBarItemIdentifierFlexibleSpace")]
		FlexibleSpace,

		[MacCatalyst (13, 1)]
		[Field ("NSTouchBarItemIdentifierOtherItemsProxy")]
		OtherItemsProxy,

		[NoMacCatalyst]
		[Field ("NSTouchBarItemIdentifierCharacterPicker")]
		CharacterPicker,

		[NoMacCatalyst]
		[Field ("NSTouchBarItemIdentifierTextColorPicker")]
		TextColorPicker,

		[NoMacCatalyst]
		[Field ("NSTouchBarItemIdentifierTextStyle")]
		TextStyle,

		[NoMacCatalyst]
		[Field ("NSTouchBarItemIdentifierTextAlignment")]
		TextAlignment,

		[NoMacCatalyst]
		[Field ("NSTouchBarItemIdentifierTextList")]
		TextList,

		[NoMacCatalyst]
		[Field ("NSTouchBarItemIdentifierTextFormat")]
		TextFormat,

		[NoMacCatalyst]
		[Field ("NSTouchBarItemIdentifierCandidateList")]
		CandidateList
	}

	[MacCatalyst (13, 1)]
	[Protocol]
	interface NSTouchBarProvider {
		[Abstract]
		[NullAllowed, Export ("touchBar", ArgumentSemantic.Strong)]
		NSTouchBar TouchBar { get; }
	}

	interface INSTouchBarProvider { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSTrackingArea : NSCoding, NSCopying {
		[Export ("initWithRect:options:owner:userInfo:")]
		NativeHandle Constructor (CGRect rect, NSTrackingAreaOptions options, NSObject owner, [NullAllowed] NSDictionary userInfo);

		[Export ("rect")]
		CGRect Rect { get; }

		[Export ("options")]
		NSTrackingAreaOptions Options { get; }

		[Export ("owner")]
		NSObject Owner { get; }

		[Export ("userInfo")]
		NSDictionary UserInfo { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSTreeNode {
		[Static, Export ("treeNodeWithRepresentedObject:")]
		NSTreeNode FromRepresentedObject (NSObject modelObject);

		[Export ("initWithRepresentedObject:")]
		NativeHandle Constructor (NSObject modelObject);

		[Export ("representedObject")]
		NSObject RepresentedObject { get; }

		[Export ("indexPath")]
		NSIndexPath IndexPath { get; }

		[Export ("isLeaf")]
		bool IsLeaf { get; }

		[Export ("childNodes")]
		NSTreeNode [] Children { get; }

		//[Export ("mutableChildNodes")]
		//NSMutableArray MutableChildren { get; }

		[Export ("descendantNodeAtIndexPath:")]
		NSTreeNode DescendantNode (NSIndexPath atIndexPath);

		[Export ("parentNode")]
		NSTreeNode ParentNode { get; }

		[Export ("sortWithSortDescriptors:recursively:")]
		void SortWithSortDescriptors (NSSortDescriptor [] sortDescriptors, bool recursively);

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObjectController))]
	interface NSTreeController {
		[Export ("rearrangeObjects")]
		void RearrangeObjects ();

		[Export ("arrangedObjects")]
#if NET
		NSTreeNode ArrangedObjects { get; }
#else
		NSObject ArrangedObjects { get; }
#endif

		[Export ("childrenKeyPath")]
		string ChildrenKeyPath { get; set; }

		[Export ("countKeyPath")]
		string CountKeyPath { get; set; }

		[Export ("leafKeyPath")]
		string LeafKeyPath { get; set; }

		[Export ("sortDescriptors", ArgumentSemantic.Copy)]
		NSSortDescriptor [] SortDescriptors { get; set; }

		[Export ("content", ArgumentSemantic.Retain)]
		NSObject Content { get; set; }

		[Export ("add:")]
		void Add (NSObject sender);

		[Export ("remove:")]
		void Remove (NSObject sender);

		[Export ("addChild:")]
		void AddChild (NSObject sender);

		[Export ("insert:")]
		void Insert (NSObject sender);

		[Export ("insertChild:")]
		void InsertChild (NSObject sender);

		[Export ("canInsert")]
		bool CanInsert { get; }

		[Export ("canInsertChild")]
		bool CanInsertChild { get; }

		[Export ("canAddChild")]
		bool CanAddChild { get; }

		[Export ("insertObject:atArrangedObjectIndexPath:")]
		void InsertObject (NSObject object1, NSIndexPath indexPath);

		[Export ("insertObjects:atArrangedObjectIndexPaths:")]
		void InsertObjects (NSObject [] objects, NSArray indexPaths);

		[Export ("removeObjectAtArrangedObjectIndexPath:")]
		void RemoveObjectAtArrangedObjectIndexPath (NSIndexPath indexPath);

		[Export ("removeObjectsAtArrangedObjectIndexPaths:")]
		void RemoveObjectsAtArrangedObjectIndexPaths (NSIndexPath [] indexPaths);

		[Export ("avoidsEmptySelection")]
		bool AvoidsEmptySelection { get; set; }

		[Export ("preservesSelection")]
		bool PreservesSelection { get; set; }

		[Export ("selectsInsertedObjects")]
		bool SelectsInsertedObjects { get; set; }

		[Export ("alwaysUsesMultipleValuesMarker")]
		bool AlwaysUsesMultipleValuesMarker { get; set; }

		[Export ("selectedObjects")]
		NSObject [] SelectedObjects { get; }

		[Export ("selectionIndexPaths"), Protected]
		NSIndexPath [] GetSelectionIndexPaths ();

		[Export ("setSelectionIndexPaths:"), Protected]
		bool SetSelectionIndexPaths (NSIndexPath [] indexPaths);

		[Export ("selectionIndexPath"), Protected]
		NSIndexPath GetSelectionIndexPath ();

		[Export ("setSelectionIndexPath:"), Protected]
		bool SetSelectionIndexPath (NSIndexPath index);

		[Export ("addSelectionIndexPaths:")]
		bool AddSelectionIndexPaths (NSIndexPath [] indexPaths);

		[Export ("removeSelectionIndexPaths:")]
		bool RemoveSelectionIndexPaths (NSIndexPath [] indexPaths);

		[Export ("selectedNodes")]
		NSTreeNode [] SelectedNodes { get; }

		[Export ("moveNode:toIndexPath:")]
		void MoveNode (NSTreeNode node, NSIndexPath indexPath);

		[Export ("moveNodes:toIndexPath:")]
		void MoveNodes (NSTreeNode [] nodes, NSIndexPath startingIndexPath);

		[Export ("childrenKeyPathForNode:")]
		string ChildrenKeyPathForNode (NSTreeNode node);

		[Export ("countKeyPathForNode:")]
		string CountKeyPathForNode (NSTreeNode node);

		[Export ("leafKeyPathForNode:")]
		string LeafKeyPathForNode (NSTreeNode node);
	}





	[NoMacCatalyst]
	[BaseType (typeof (NSViewController))]
	interface NSTitlebarAccessoryViewController : NSAnimationDelegate, NSAnimatablePropertyContainer {
		[Export ("initWithNibName:bundle:")]
		NativeHandle Constructor ([NullAllowed] string nibNameOrNull, [NullAllowed] NSBundle nibBundleOrNull);

		[Export ("layoutAttribute")]
		NSLayoutAttribute LayoutAttribute { get; set; }

		[Export ("fullScreenMinHeight")]
		nfloat FullScreenMinHeight { get; set; }

		[RequiresSuper]
		[Export ("viewWillAppear")]
		void ViewWillAppear ();

		[RequiresSuper]
		[Export ("viewDidAppear")]
		void ViewDidAppear ();

		[RequiresSuper]
		[Export ("viewDidDisappear")]
		void ViewDidDisappear ();

		[Export ("hidden")]
		bool IsHidden { [Bind ("isHidden")] get; set; }

		[Export ("automaticallyAdjustsSize")]
		bool AutomaticallyAdjustsSize { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSVisualEffectView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("material")]
		NSVisualEffectMaterial Material { get; set; }

		[Export ("interiorBackgroundStyle")]
		NSBackgroundStyle InteriorBackgroundStyle { get; }

		[Export ("blendingMode")]
		NSVisualEffectBlendingMode BlendingMode { get; set; }

		[Export ("state")]
		NSVisualEffectState State { get; set; }

		[Export ("maskImage", ArgumentSemantic.Retain)]
		NSImage MaskImage { get; set; }

		[RequiresSuper]
		[Export ("viewDidMoveToWindow")]
		void ViewDidMove ();

		[RequiresSuper]
		[Export ("viewWillMoveToWindow:")]
		void ViewWillMove (NSWindow newWindow);

		[Export ("emphasized")]
		bool Emphasized { [Bind ("isEmphasized")] get; set; }
	}

	[NoMacCatalyst]
	delegate void NSWindowCompletionHandler (NSWindow window, NSError error);

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	partial interface NSWindowRestoration {
		// This method is required, but we don't generate the correct code for required static methods.
		// [Abstract]
		[Static]
		[Export ("restoreWindowWithIdentifier:state:completionHandler:")]
		void RestoreWindow (string identifier, NSCoder state, NSWindowCompletionHandler onCompletion);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSResponder))]
	interface NSWindowController : NSCoding, NSSeguePerforming {
		[DesignatedInitializer]
		[Export ("initWithWindow:")]
		NativeHandle Constructor (NSWindow window);

		[Export ("initWithWindowNibName:")]
		NativeHandle Constructor (string windowNibName);

		[Export ("initWithWindowNibName:owner:")]
		NativeHandle Constructor (string windowNibName, NSObject owner);

		[Export ("windowNibName")]
		string WindowNibName { get; }

		[Export ("windowNibPath")]
		string WindowNibPath { get; }

		[Export ("owner")]
		NSObject Owner { get; }

		[Export ("windowFrameAutosaveName")]
		string WindowFrameAutosaveName { get; set; }

		[Export ("shouldCascadeWindows")]
		bool ShouldCascadeWindows { get; set; }

		[Mac (13, 2)]
		[NullAllowed]
		[Export ("previewRepresentableActivityItems", ArgumentSemantic.Copy)]
		INSPreviewRepresentableActivityItem [] PreviewRepresentableActivityItems { get; set; }

		[Export ("document")]
		[NullAllowed]
		NSDocument Document { get; set; }

		[Export ("setDocumentEdited:")]
		void SetDocumentEdited (bool dirtyFlag);

		[Export ("shouldCloseDocument")]
		bool ShouldCloseDocument { get; set; }

		[Export ("window", ArgumentSemantic.Retain)]
		NSWindow Window { get; set; }

		[Export ("synchronizeWindowTitleWithDocumentName")]
		void SynchronizeWindowTitleWithDocumentName ();

		[Export ("windowTitleForDocumentDisplayName:")]
		string WindowTitleForDocumentDisplayName (string displayName);

		[Export ("close")]
		void Close ();

		[Export ("showWindow:")]
		void ShowWindow ([NullAllowed] NSObject sender);

		[Export ("isWindowLoaded")]
		bool IsWindowLoaded { get; }

		[Export ("windowWillLoad")]
		void WindowWillLoad ();

		[Export ("windowDidLoad")]
		void WindowDidLoad ();

		[Export ("loadWindow")]
		void LoadWindow ();

		[Export ("contentViewController", ArgumentSemantic.Retain)]
		NSViewController ContentViewController { get; set; }

		[Export ("storyboard", ArgumentSemantic.Strong)]
		NSStoryboard Storyboard { get; }

		[Export ("dismissController:")]
		void DismissController (NSObject sender);
	}


	[NoMacCatalyst]
	interface NSWorkspaceRenamedEventArgs {
		[Export ("NSWorkspaceVolumeLocalizedNameKey")]
		string VolumeLocalizedName { get; }

		[Export ("NSWorkspaceVolumeURLKey")]
		NSUrl VolumeUrl { get; }

		[Export ("NSWorkspaceVolumeOldLocalizedNameKey")]
		string OldVolumeLocalizedName { get; }

		[Export ("NSWorkspaceVolumeOldURLKey")]
		NSUrl OldVolumeUrl { get; }
	}

	[NoMacCatalyst]
	interface NSWorkspaceMountEventArgs {
		[Export ("NSWorkspaceVolumeLocalizedNameKey")]
		string VolumeLocalizedName { get; }

		[Export ("NSWorkspaceVolumeURLKey")]
		NSUrl VolumeUrl { get; }
	}

	[NoMacCatalyst]
	interface NSWorkspaceApplicationEventArgs {
		[Export ("NSWorkspaceApplicationKey")]
		NSRunningApplication Application { get; }
	}

	[NoMacCatalyst]
	interface NSWorkspaceFileOperationEventArgs {
		[Export ("NSOperationNumber")]
		nint FileType { get; }
	}

	delegate void NSWorkspaceUrlHandler (NSDictionary newUrls, NSError error);

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSWorkspace : NSWorkspaceAccessibilityExtensions {
		[Static]
		[Export ("sharedWorkspace"), ThreadSafe]
		NSWorkspace SharedWorkspace { get; }

		[Export ("notificationCenter"), ThreadSafe]
		NSNotificationCenter NotificationCenter { get; }

		[Export ("openFile:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use the 'OpenUrl' method instead.")]
		bool OpenFile (string fullPath);

		[Export ("openFile:withApplication:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		bool OpenFile (string fullPath, [NullAllowed] string appName);

		[Export ("openFile:withApplication:andDeactivate:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		bool OpenFile (string fullPath, [NullAllowed] string appName, bool deactivate);

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSWorkspace.OpenUrl' instead.")]
		[Export ("openFile:fromImage:at:inView:"), ThreadSafe]
		bool OpenFile (string fullPath, NSImage anImage, CGPoint point, NSView aView);

		[Export ("openURL:"), ThreadSafe]
		bool OpenUrl (NSUrl url);

		[Export ("launchApplication:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		bool LaunchApplication (string appName);

		[Export ("launchApplicationAtURL:options:configuration:error:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		NSRunningApplication LaunchApplication (NSUrl url, NSWorkspaceLaunchOptions options, NSDictionary configuration, out NSError error);

		[Export ("launchApplication:showIcon:autolaunch:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		bool LaunchApplication (string appName, bool showIcon, bool autolaunch);

		[Export ("fullPathForApplication:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use the 'UrlForApplication' method instead.")]
		[return: NullAllowed]
		string FullPathForApplication (string appName);

		[Export ("selectFile:inFileViewerRootedAtPath:"), ThreadSafe]
		bool SelectFile (string fullPath, string rootFullPath);

		[Export ("activateFileViewerSelectingURLs:"), ThreadSafe]
		void ActivateFileViewer (NSUrl [] fileUrls);

		[Export ("showSearchResultsForQueryString:"), ThreadSafe]
		bool ShowSearchResults (string queryString);

		[Export ("noteFileSystemChanged:")]
		void NoteFileSystemChanged (string path);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'NSWorkspace.UrlForApplication' or 'NSUrl.GetResourceValue' instead.")]
		[Export ("getInfoForFile:application:type:"), ThreadSafe]
		bool GetInfo (string fullPath, out string appName, out string fileType);

		[Export ("isFilePackageAtPath:"), ThreadSafe]
		bool IsFilePackage (string fullPath);

		[Export ("iconForFile:"), ThreadSafe]
		NSImage IconForFile (string fullPath);

		[Export ("iconForFiles:"), ThreadSafe]
		NSImage IconForFiles (string [] fullPaths);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'NSWorkspace.GetIcon' instead.")]
		[Export ("iconForFileType:"), ThreadSafe, Internal]
		NSImage IconForFileType (IntPtr fileTypeOrTypeCode);

		[Export ("setIcon:forFile:options:"), ThreadSafe]
		bool SetIconforFile (NSImage image, string fullPath, NSWorkspaceIconCreationOptions options);

		[Export ("fileLabels"), ThreadSafe]
		string [] FileLabels { get; }

		[Export ("fileLabelColors"), ThreadSafe]
		NSColor [] FileLabelColors { get; }

		[Export ("recycleURLs:completionHandler:"), ThreadSafe]
		void RecycleUrls (NSArray urls, NSWorkspaceUrlHandler completionHandler);

		[Export ("duplicateURLs:completionHandler:"), ThreadSafe]
		void DuplicateUrls (NSArray urls, NSWorkspaceUrlHandler completionHandler);

		[Export ("getFileSystemInfoForPath:isRemovable:isWritable:isUnmountable:description:type:"), ThreadSafe]
		bool GetFileSystemInfo (string fullPath, out bool removableFlag, out bool writableFlag, out bool unmountableFlag, out string description, out string fileSystemType);

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("performFileOperation:source:destination:files:tag:"), ThreadSafe]
		bool PerformFileOperation (NSString workspaceOperation, string source, string destination, string [] files, out nint tag);

		[Export ("unmountAndEjectDeviceAtPath:"), ThreadSafe]
		bool UnmountAndEjectDevice (string path);

		[Export ("unmountAndEjectDeviceAtURL:error:"), ThreadSafe]
		bool UnmountAndEjectDevice (NSUrl url, out NSError error);

		[Export ("extendPowerOffBy:")]
		nint ExtendPowerOffBy (nint requested);

		[Export ("hideOtherApplications")]
		void HideOtherApplications ();

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("mountedLocalVolumePaths")]
		string [] MountedLocalVolumePaths { get; }

		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("mountedRemovableMedia")]
		string [] MountedRemovableMedia { get; }

		[Export ("URLForApplicationWithBundleIdentifier:"), ThreadSafe]
		NSUrl UrlForApplication (string bundleIdentifier);

		[Export ("URLForApplicationToOpenURL:"), ThreadSafe]
		NSUrl UrlForApplication (NSUrl url);

		[Export ("URLsForApplicationsWithBundleIdentifier:")]
		NSUrl [] GetUrlsForApplications (string bundleIdentifier);

		[Export ("URLsForApplicationsToOpenURL:")]
		NSUrl [] GetUrlsForApplications (NSUrl url);

		[Async]
		[Export ("setDefaultApplicationAtURL:toOpenContentTypeOfFileAtURL:completionHandler:")]
		void SetDefaultApplicationToOpenContentType (NSUrl applicationUrl, NSUrl url, [NullAllowed] Action<NSError> completionHandler);

		[Async]
		[Export ("setDefaultApplicationAtURL:toOpenURLsWithScheme:completionHandler:")]
		void SetDefaultApplicationToOpenUrls (NSUrl applicationUrl, string urlScheme, [NullAllowed] Action<NSError> completionHandler);

		[Async]
		[Export ("setDefaultApplicationAtURL:toOpenFileAtURL:completionHandler:")]
		void SetDefaultApplicationToOpenFile (NSUrl applicationUrl, NSUrl url, [NullAllowed] Action<NSError> completionHandler);

		[Export ("URLForApplicationToOpenContentType:")]
		[return: NullAllowed]
		NSUrl GetUrlForApplicationToOpenContentType (UTType contentType);

		[Export ("URLsForApplicationsToOpenContentType:")]
		NSUrl [] GetUrlsForApplicationsToOpenContentType (UTType contentType);

		[Async]
		[Export ("setDefaultApplicationAtURL:toOpenContentType:completionHandler:")]
		void SetDefaultApplicationToOpenContentType (NSUrl applicationUrl, UTType contentType, [NullAllowed] Action<NSError> completionHandler);

		[Export ("absolutePathForAppBundleWithIdentifier:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use the 'UrlForApplication' method instead.")]
		[return: NullAllowed]
		string AbsolutePathForAppBundle (string bundleIdentifier);

		[Export ("launchAppWithBundleIdentifier:options:additionalEventParamDescriptor:launchIdentifier:"), ThreadSafe]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		bool LaunchApp (string bundleIdentifier, NSWorkspaceLaunchOptions options, NSAppleEventDescriptor descriptor, IntPtr identifier);

		[Internal]
		[Export ("openURLs:withAppBundleIdentifier:options:additionalEventParamDescriptor:launchIdentifiers:"), ThreadSafe]
		bool _OpenUrls (NSUrl [] urls, string bundleIdentifier, NSWorkspaceLaunchOptions options, NSAppleEventDescriptor descriptor, [NullAllowed] string [] identifiers);

		[Deprecated (PlatformName.MacOSX, 10, 7, message: "Use 'NSWorkspace.RunningApplications' instead.")]
		[Export ("launchedApplications")]
		NSDictionary [] LaunchedApplications { get; }

		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'NSWorkspace.FrontmostApplication' instead.")]
		[Export ("activeApplication")]
		NSDictionary ActiveApplication { get; }

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'NSUrl.GetResourceValue' instead.")]
		[Export ("typeOfFile:error:"), ThreadSafe]
		string TypeOfFile (string absoluteFilePath, out NSError outError);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'UTType.LocalizedDescription' instead.")]
		[Export ("localizedDescriptionForType:"), ThreadSafe]
		string LocalizedDescription (string typeName);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'UTType.PreferredFilenameExtension' instead.")]
		[Export ("preferredFilenameExtensionForType:"), ThreadSafe]
		string PreferredFilenameExtension (string typeName);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Compare against 'UTType.GetTypes' instead.")]
		[Export ("filenameExtension:isValidForType:"), ThreadSafe]
		bool IsFilenameExtensionValid (string filenameExtension, string typeName);

		[Deprecated (PlatformName.MacOSX, 12, 0, message: "Use 'UTType.ConformsToType' instead.")]
		[Export ("type:conformsToType:"), ThreadSafe]
		bool TypeConformsTo (string firstTypeName, string secondTypeName);

		[Export ("setDesktopImageURL:forScreen:options:error:")]
		bool SetDesktopImageUrl (NSUrl url, NSScreen screen, NSDictionary options, NSError error);

		[Export ("desktopImageURLForScreen:")]
		NSUrl DesktopImageUrl (NSScreen screen);

		[Export ("desktopImageOptionsForScreen:")]
		NSDictionary DesktopImageOptions (NSScreen screen);

		[Export ("runningApplications"), ThreadSafe]
		NSRunningApplication [] RunningApplications { get; }

		[Export ("frontmostApplication")]
		NSRunningApplication FrontmostApplication { get; }

		[Export ("menuBarOwningApplication")]
		NSRunningApplication MenuBarOwningApplication { get; }

		[Field ("NSWorkspaceWillPowerOffNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString WillPowerOffNotification { get; }

		[Field ("NSWorkspaceWillSleepNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString WillSleepNotification { get; }

		[Field ("NSWorkspaceDidWakeNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString DidWakeNotification { get; }

		[Field ("NSWorkspaceScreensDidSleepNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString ScreensDidSleepNotification { get; }

		[Field ("NSWorkspaceScreensDidWakeNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString ScreensDidWakeNotification { get; }

		[Field ("NSWorkspaceSessionDidBecomeActiveNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString SessionDidBecomeActiveNotification { get; }

		[Field ("NSWorkspaceSessionDidResignActiveNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString SessionDidResignActiveNotification { get; }

		[Field ("NSWorkspaceDidRenameVolumeNotification")]
		[Notification (typeof (NSWorkspaceRenamedEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidRenameVolumeNotification { get; }

		[Field ("NSWorkspaceDidMountNotification")]
		[Notification (typeof (NSWorkspaceMountEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidMountNotification { get; }

		[Field ("NSWorkspaceDidUnmountNotification")]
		[Notification (typeof (NSWorkspaceMountEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidUnmountNotification { get; }

		[Field ("NSWorkspaceWillUnmountNotification")]
		[Notification (typeof (NSWorkspaceMountEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString WillUnmountNotification { get; }

		[Field ("NSWorkspaceWillLaunchApplicationNotification")]
		[Notification (typeof (NSWorkspaceApplicationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString WillLaunchApplication { get; }

		[Field ("NSWorkspaceDidLaunchApplicationNotification")]
		[Notification (typeof (NSWorkspaceApplicationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidLaunchApplicationNotification { get; }

		[Field ("NSWorkspaceDidTerminateApplicationNotification")]
		[Notification (typeof (NSWorkspaceApplicationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidTerminateApplicationNotification { get; }

		[Field ("NSWorkspaceDidHideApplicationNotification")]
		[Notification (typeof (NSWorkspaceApplicationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidHideApplicationNotification { get; }

		[Field ("NSWorkspaceDidUnhideApplicationNotification")]
		[Notification (typeof (NSWorkspaceApplicationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidUnhideApplicationNotification { get; }

		[Field ("NSWorkspaceDidActivateApplicationNotification")]
		[Notification (typeof (NSWorkspaceApplicationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidActivateApplicationNotification { get; }

		[Field ("NSWorkspaceDidDeactivateApplicationNotification")]
		[Notification (typeof (NSWorkspaceApplicationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidDeactivateApplicationNotification { get; }

		[Field ("NSWorkspaceDidPerformFileOperationNotification")]
		[Notification (typeof (NSWorkspaceFileOperationEventArgs), "SharedWorkspace.NotificationCenter")]
		NSString DidPerformFileOperationNotification { get; }

		[Field ("NSWorkspaceDidChangeFileLabelsNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString DidChangeFileLabelsNotification { get; }

		[Field ("NSWorkspaceActiveSpaceDidChangeNotification")]
		[Notification ("SharedWorkspace.NotificationCenter")]
		NSString ActiveSpaceDidChangeNotification { get; }

		[Field ("NSWorkspaceLaunchConfigurationAppleEvent")]
		NSString LaunchConfigurationAppleEvent { get; }

		[Field ("NSWorkspaceLaunchConfigurationArguments")]
		NSString LaunchConfigurationArguments { get; }

		[Field ("NSWorkspaceLaunchConfigurationEnvironment")]
		NSString LaunchConfigurationEnvironment { get; }

		[Field ("NSWorkspaceLaunchConfigurationArchitecture")]
		NSString LaunchConfigurationArchitecture { get; }

		//
		// File operations
		//
		// Those not listed are not here, because they are documented as returing an error
		//
		[Field ("NSWorkspaceRecycleOperation")]
		NSString OperationRecycle { get; }

		[Field ("NSWorkspaceDuplicateOperation")]
		NSString OperationDuplicate { get; }

		[Field ("NSWorkspaceMoveOperation")]
		NSString OperationMove { get; }

		[Field ("NSWorkspaceCopyOperation")]
		NSString OperationCopy { get; }

		[Field ("NSWorkspaceLinkOperation")]
		NSString OperationLink { get; }

		[Field ("NSWorkspaceDestroyOperation")]
		NSString OperationDestroy { get; }

		[Export ("openURL:options:configuration:error:")]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		[return: NullAllowed]
#if NET
		NSRunningApplication OpenUrl (NSUrl url, NSWorkspaceLaunchOptions options, NSDictionary configuration, out NSError error);
#else
		NSRunningApplication OpenURL (NSUrl url, NSWorkspaceLaunchOptions options, NSDictionary configuration, out NSError error);
#endif

		[Export ("openURLs:withApplicationAtURL:options:configuration:error:")]
		[Deprecated (PlatformName.MacOSX, 10, 15)]
		[return: NullAllowed]
#if NET
		NSRunningApplication OpenUrls (NSUrl [] urls, NSUrl applicationURL, NSWorkspaceLaunchOptions options, NSDictionary configuration, out NSError error);
#else
		NSRunningApplication OpenURLs (NSUrl [] urls, NSUrl applicationURL, NSWorkspaceLaunchOptions options, NSDictionary configuration, out NSError error);
#endif

		[Field ("NSWorkspaceAccessibilityDisplayOptionsDidChangeNotification")]
		[Notification]
		NSString DisplayOptionsDidChangeNotification { get; }

		[Export ("requestAuthorizationOfType:completionHandler:")]
		void RequestAuthorization (NSWorkspaceAuthorizationType type, Action<NSWorkspaceAuthorization, NSError> completionHandler);

		[Async]
		[Export ("openApplicationAtURL:configuration:completionHandler:")]
		void OpenApplication (NSUrl applicationUrl, NSWorkspaceOpenConfiguration configuration, [NullAllowed] Action<NSRunningApplication, NSError> completionHandler);

		[Async]
		[Export ("openURL:configuration:completionHandler:")]
		void OpenUrl (NSUrl url, NSWorkspaceOpenConfiguration configuration, [NullAllowed] Action<NSRunningApplication, NSError> completionHandler);

		[Async]
		[Export ("openURLs:withApplicationAtURL:configuration:completionHandler:")]
		void OpenUrls (NSUrl [] urls, NSUrl applicationUrl, NSWorkspaceOpenConfiguration configuration, [NullAllowed] Action<NSRunningApplication, NSError> completionHandler);

		[Export ("iconForContentType:")]
		NSImage GetIcon (UTType contentType);
	}



	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[ThreadSafe] // NSRunningApplication is documented to be thread-safe.
	partial interface NSRunningApplication {
		[Export ("terminated")]
		bool Terminated { [Bind ("isTerminated")] get; }

		[Export ("finishedLaunching")]
		bool FinishedLaunching { [Bind ("isFinishedLaunching")] get; }

		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; }

		[Export ("active")]
		bool Active { [Bind ("isActive")] get; }

		[Export ("activationPolicy")]
		NSApplicationActivationPolicy ActivationPolicy { get; }

		[NullAllowed]
		[Export ("localizedName", ArgumentSemantic.Copy)]
		string LocalizedName { get; }

		[NullAllowed]
		[Export ("bundleIdentifier", ArgumentSemantic.Copy)]
		string BundleIdentifier { get; }

		[NullAllowed]
		[Export ("bundleURL", ArgumentSemantic.Copy)]
		NSUrl BundleUrl { get; }

		[NullAllowed]
		[Export ("executableURL", ArgumentSemantic.Copy)]
		NSUrl ExecutableUrl { get; }

		[Export ("processIdentifier")]
		int ProcessIdentifier { get; } /* pid_t = int */

		[NullAllowed]
		[Export ("launchDate", ArgumentSemantic.Copy)]
		NSDate LaunchDate { get; }

		[NullAllowed]
		[Export ("icon", ArgumentSemantic.Strong)]
		NSImage Icon { get; }

		[Export ("executableArchitecture")]
		nint ExecutableArchitecture { get; }

		[Export ("hide")]
		bool Hide ();

		[Export ("unhide")]
		bool Unhide ();

		[Export ("activateWithOptions:")]
		bool Activate (NSApplicationActivationOptions options);

		[Export ("terminate")]
		bool Terminate ();

		[Export ("forceTerminate")]
		bool ForceTerminate ();

		[Static]
		[Export ("runningApplicationsWithBundleIdentifier:")]
		NSRunningApplication [] GetRunningApplications (string bundleIdentifier);

		[Static]
		[Export ("runningApplicationWithProcessIdentifier:")]
		NSRunningApplication GetRunningApplication (int /* pid_t = int */ pid);

		[Static]
		[ThreadSafe]
		[Export ("currentApplication")]
		NSRunningApplication CurrentApplication { get; }

		[Export ("ownsMenuBar")]
		bool OwnsMenuBar { get; }

		[Mac (14, 0)]
		[Export ("activateFromApplication:options:")]
		bool Activate (NSRunningApplication application, NSApplicationActivationOptions options);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	interface NSStepper : NSAccessibilityStepper {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		//Detected properties
		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("increment")]
		double Increment { get; set; }

		[Export ("valueWraps")]
		bool ValueWraps { get; set; }

		[Export ("autorepeat")]
		bool Autorepeat { get; set; }

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSActionCell))]
	interface NSStepperCell {
		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("increment")]
		double Increment { get; set; }

		[Export ("valueWraps")]
		bool ValueWraps { get; set; }

		[Export ("autorepeat")]
		bool Autorepeat { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPredicateEditorRowTemplate : NSCoding, NSCopying {
		[Export ("matchForPredicate:")]
		double MatchForPredicate (NSPredicate predicate);

		[Export ("templateViews")]
		NSObject [] TemplateViews { get; }

		[Export ("setPredicate:")]
		void SetPredicate (NSPredicate predicate);

		[Export ("predicateWithSubpredicates:")]
		NSPredicate PredicateWithSubpredicates (NSPredicate [] subpredicates);

		[Export ("displayableSubpredicatesOfPredicate:")]
		NSPredicate [] DisplayableSubpredicatesOfPredicate (NSPredicate predicate);

		[Export ("initWithLeftExpressions:rightExpressions:modifier:operators:options:")]
		//NSObject InitWithLeftExpressionsrightExpressionsmodifieroperatorsoptions (NSArray leftExpressions, NSArray rightExpressions, NSComparisonPredicateModifier modifier, NSArray operators, uint options);
		NativeHandle Constructor (NSExpression [] leftExpressions, NSExpression [] rightExpressions, NSComparisonPredicateModifier modifier, NSObject [] operators, NSComparisonPredicateOptions options);

		[Export ("initWithLeftExpressions:rightExpressionAttributeType:modifier:operators:options:")]
		//NSObject InitWithLeftExpressionsrightExpressionAttributeTypemodifieroperatorsoptions (NSArray leftExpressions, NSAttributeType attributeType, NSComparisonPredicateModifier modifier, NSArray operators, uint options);
		NativeHandle Constructor (NSExpression [] leftExpressions, NSAttributeType attributeType, NSComparisonPredicateModifier modifier, NSObject [] operators, NSComparisonPredicateOptions options);

		[Export ("initWithCompoundTypes:")]
		NativeHandle Constructor (NSNumber [] compoundTypes);

		[Export ("leftExpressions")]
		NSExpression [] LeftExpressions { get; }

		[Export ("rightExpressions")]
		NSExpression [] RightExpressions { get; }

		[Export ("rightExpressionAttributeType")]
		NSAttributeType RightExpressionAttributeType { get; }

		[Export ("modifier")]
		NSComparisonPredicateModifier Modifier { get; }

		[Export ("operators")]
		NSObject [] Operators { get; }

		[Export ("options")]
		NSComparisonPredicateOptions Options { get; }

		[Export ("compoundTypes")]
		NSNumber [] CompoundTypes { get; }

		[Static]
		[Export ("templatesWithAttributeKeyPaths:inEntityDescription:")]
		//NSArray TemplatesWithAttributeKeyPathsinEntityDescription (NSArray keyPaths, NSEntityDescription entityDescription);
		NSPredicateEditorRowTemplate [] GetTemplates (string [] keyPaths, NSEntityDescription entityDescription);

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSPressureConfiguration {
		[Export ("pressureBehavior")]
		NSPressureBehavior PressureBehavior { get; }

		[DesignatedInitializer]
		[Export ("initWithPressureBehavior:")]
		NativeHandle Constructor (NSPressureBehavior pressureBehavior);

		[Export ("set")]
		void Set ();
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl), Delegates = new string [] { "Delegate" }, Events = new Type [] { typeof (NSRuleEditorDelegate) })]
	partial interface NSRuleEditor {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("reloadCriteria")]
		void ReloadCriteria ();

		[Export ("predicate")]
		NSPredicate Predicate { get; }

		[Export ("reloadPredicate")]
		void ReloadPredicate ();

		[Export ("predicateForRow:")]
		NSPredicate GetPredicate (nint row);

		[Export ("numberOfRows")]
		nint NumberOfRows { get; }

		[Export ("subrowIndexesForRow:")]
		NSIndexSet SubrowIndexes (nint rowIndex);

		[Export ("criteriaForRow:")]
		NSArray Criteria (nint row);

		[Export ("displayValuesForRow:")]
		NSObject [] DisplayValues (nint row);

		[Export ("rowForDisplayValue:")]
		nint Row (NSObject displayValue);

		[Export ("rowTypeForRow:")]
		NSRuleEditorRowType RowType (nint rowIndex);

		[Export ("parentRowForRow:")]
		nint ParentRow (nint rowIndex);

		[Export ("addRow:")]
		void AddRow (NSObject sender);

		[Export ("insertRowAtIndex:withType:asSubrowOfRow:animate:")]
		void InsertRowAtIndex (nint rowIndex, NSRuleEditorRowType rowType, nint parentRow, bool shouldAnimate);

		[Export ("setCriteria:andDisplayValues:forRowAtIndex:")]
		void SetCriteria (NSArray criteria, NSArray values, nint rowIndex);

		[Export ("removeRowAtIndex:")]
		void RemoveRowAtIndex (nint rowIndex);

		[Export ("removeRowsAtIndexes:includeSubrows:")]
		void RemoveRowsAtIndexes (NSIndexSet rowIndexes, bool includeSubrows);

		[Export ("selectedRowIndexes")]
		NSIndexSet SelectedRows { get; }

		[Export ("selectRowIndexes:byExtendingSelection:")]
		void SelectRows (NSIndexSet indexes, bool extend);

		//Detected properties
		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		INSRuleEditorDelegate Delegate { get; set; }

		[Export ("formattingStringsFilename")]
		string FormattingStringsFilename { get; set; }

		[Export ("formattingDictionary", ArgumentSemantic.Copy)]
		NSDictionary FormattingDictionary { get; set; }

		[Export ("nestingMode")]
		NSRuleEditorNestingMode NestingMode { get; set; }

		[Export ("rowHeight")]
		nfloat RowHeight { get; set; }

		[Export ("editable")]
		bool Editable { [Bind ("isEditable")] get; set; }

		[Export ("canRemoveAllRows")]
		bool CanRemoveAllRows { get; set; }

		[Export ("rowClass")]
		Class RowClass { get; set; }

		[Export ("rowTypeKeyPath")]
		string RowTypeKeyPath { get; set; }

		[Export ("subrowsKeyPath")]
		string SubrowsKeyPath { get; set; }

		[Export ("criteriaKeyPath")]
		string CriteriaKeyPath { get; set; }

		[Export ("displayValuesKeyPath")]
		string DisplayValuesKeyPath { get; set; }
	}

	interface INSRuleEditorDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSRuleEditorDelegate {
		[Abstract]
		[Export ("ruleEditor:numberOfChildrenForCriterion:withRowType:"), DelegateName ("NSRuleEditorNumberOfChildren"), DefaultValue (0)]
		nint NumberOfChildren (NSRuleEditor editor, NSObject criterion, NSRuleEditorRowType rowType);

		[Abstract]
		[Export ("ruleEditor:child:forCriterion:withRowType:"), DelegateName ("NSRulerEditorChildCriterion"), DefaultValue (null)]
		NSObject ChildForCriterion (NSRuleEditor editor, nint index, NSObject criterion, NSRuleEditorRowType rowType);

		[Abstract]
		[Export ("ruleEditor:displayValueForCriterion:inRow:"), DelegateName ("NSRulerEditorDisplayValue"), DefaultValue (null)]
		NSObject DisplayValue (NSRuleEditor editor, NSObject criterion, nint row);

#if !NET
		[Abstract]
#endif
		[Export ("ruleEditor:predicatePartsForCriterion:withDisplayValue:inRow:"), DelegateName ("NSRulerEditorPredicateParts"), DefaultValue (null)]
		NSDictionary PredicateParts (NSRuleEditor editor, NSObject criterion, NSObject value, nint row);

#if !NET
		[Abstract]
#endif
		[Export ("ruleEditorRowsDidChange:"), EventArgs ("NSNotification")]
		void RowsDidChange (NSNotification notification);

		[Export ("controlTextDidEndEditing:"), EventArgs ("NSNotification")]
		void EditingEnded (NSNotification notification);

		[Export ("controlTextDidChange:"), EventArgs ("NSNotification")]
		void Changed (NSNotification notification);

		[Export ("controlTextDidBeginEditing:"), EventArgs ("NSNotification")]
		void EditingBegan (NSNotification notification);

	}

	[NoMacCatalyst]
	[BaseType (typeof (NSRuleEditor))]
	interface NSPredicateEditor {
		//Detected properties
		[Export ("rowTemplates", ArgumentSemantic.Copy)]
		NSPredicateEditorRowTemplate [] RowTemplates { get; set; }

	}

	// Start of NSSharingService.h

	delegate void NSSharingServiceHandler ();

	[NoMacCatalyst]
	[BaseType (typeof (NSObject),
			   Delegates = new string [] { "WeakDelegate" },
	Events = new Type [] { typeof (NSSharingServiceDelegate) })]
	interface NSSharingService {

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSSharingServiceDelegate Delegate { get; set; }

		[Export ("title", ArgumentSemantic.Copy)]
		string Title { get; }

		[Export ("image", ArgumentSemantic.Strong)]
		NSImage Image { get; }

		[Export ("alternateImage", ArgumentSemantic.Strong)]
		NSImage AlternateImage { get; }

		[Deprecated (PlatformName.MacOSX, 13, 0, message: "Use 'NSSharingServicePicker.StandardShareMenuItem' instead.")]
		[Export ("sharingServicesForItems:")]
		[Static]
		NSSharingService [] SharingServicesForItems (NSObject [] items);

		[Export ("sharingServiceNamed:")]
		[Static]
		NSSharingService GetSharingService (NSString serviceName);

		[DesignatedInitializer]
		[Export ("initWithTitle:image:alternateImage:handler:")]
		NativeHandle Constructor (string title, NSImage image, NSImage alternateImage, NSSharingServiceHandler handler);

		[Export ("canPerformWithItems:")]
		bool CanPerformWithItems ([NullAllowed] NSObject [] items);

		[Export ("performWithItems:")]
		void PerformWithItems (NSObject [] items);

		[Export ("menuItemTitle")]
		string MenuItemTitle { get; set; }

		[Export ("recipients", ArgumentSemantic.Copy)]
		NSObject [] Recipients { get; set; }

		[Export ("subject")]
		string Subject { get; set; }

		[Export ("messageBody")]
		string MessageBody { get; }

		[Export ("permanentLink", ArgumentSemantic.Copy)]
		NSUrl PermanentLink { get; }

		[Export ("accountName")]
		string AccountName { get; }

		[Export ("attachmentFileURLs", ArgumentSemantic.Copy)]
		NSUrl [] AttachmentFileUrls { get; }
	}

	[NoMacCatalyst]
	enum NSSharingServiceName {

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNamePostOnFacebook")]
		PostOnFacebook,

		[Field ("NSSharingServiceNamePostOnTwitter")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		PostOnTwitter,

		[Field ("NSSharingServiceNamePostOnSinaWeibo")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		PostOnSinaWeibo,

		[Field ("NSSharingServiceNameComposeEmail")]
		ComposeEmail,

		[Field ("NSSharingServiceNameComposeMessage")]
		ComposeMessage,

		[Field ("NSSharingServiceNameSendViaAirDrop")]
		SendViaAirDrop,

		[Field ("NSSharingServiceNameAddToSafariReadingList")]
		AddToSafariReadingList,

		[Field ("NSSharingServiceNameAddToIPhoto")]
		AddToIPhoto,

		[Field ("NSSharingServiceNameAddToAperture")]
		AddToAperture,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNameUseAsTwitterProfileImage")]
		UseAsTwitterProfileImage,

		[Field ("NSSharingServiceNameUseAsDesktopPicture")]
		UseAsDesktopPicture,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNamePostImageOnFlickr")]
		PostImageOnFlickr,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNamePostVideoOnVimeo")]
		PostVideoOnVimeo,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNamePostVideoOnYouku")]
		PostVideoOnYouku,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNamePostVideoOnTudou")]
		PostVideoOnTudou,

		[Field ("NSSharingServiceNameCloudSharing")]
		CloudSharing,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNamePostOnTencentWeibo")]
		PostOnTencentWeibo,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNamePostOnLinkedIn")]
		PostOnLinkedIn,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNameUseAsFacebookProfileImage")]
		UseAsFacebookProfileImage,

		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use the proprietary SDK instead.")]
		[Field ("NSSharingServiceNameUseAsLinkedInProfileImage")]
		UseAsLinkedInProfileImage,
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSSharingServiceDelegate {
		[Export ("sharingService:willShareItems:"), EventArgs ("NSSharingServiceItems")]
		void WillShareItems (NSSharingService sharingService, NSObject [] items);

		[Export ("sharingService:didFailToShareItems:error:"), EventArgs ("NSSharingServiceDidFailToShareItems")]
		void DidFailToShareItems (NSSharingService sharingService, NSObject [] items, NSError error);

		[Export ("sharingService:didShareItems:"), EventArgs ("NSSharingServiceItems")]
		void DidShareItems (NSSharingService sharingService, NSObject [] items);

		[Export ("sharingService:sourceFrameOnScreenForShareItem:"), DelegateName ("NSSharingServiceSourceFrameOnScreenForShareItem"), DefaultValue (null)]
		CGRect SourceFrameOnScreenForShareItem (NSSharingService sharingService, INSPasteboardWriting item);

		[Export ("sharingService:transitionImageForShareItem:contentRect:"), DelegateName ("NSSharingServiceTransitionImageForShareItem"), DefaultValue (null)]
		NSImage TransitionImageForShareItem (NSSharingService sharingService, INSPasteboardWriting item, CGRect contentRect);

		[Export ("sharingService:sourceWindowForShareItems:sharingContentScope:"), DelegateName ("NSSharingServiceSourceWindowForShareItems"), DefaultValue (null)]
		NSWindow SourceWindowForShareItems (NSSharingService sharingService, NSObject [] items, NSSharingContentScope sharingContentScope);

		[Export ("anchoringViewForSharingService:showRelativeToRect:preferredEdge:"), DelegateName ("NSSharingServiceAnchoringViewForSharingService"), DefaultValue (null)]
		[return: NullAllowed]
		NSView CreateAnchoringView (NSSharingService sharingService, ref CGRect positioningRect, ref NSRectEdge preferredEdge);
	}

	interface INSSharingServiceDelegate { }

	interface INSCloudSharingServiceDelegate { }

	[Protocol, Model]
	[NoMacCatalyst]
	[BaseType (typeof (NSSharingServiceDelegate))]
	interface NSCloudSharingServiceDelegate {
		[Export ("sharingService:didCompleteForItems:error:")]
		void Completed (NSSharingService sharingService, NSObject [] items, [NullAllowed] NSError error);

		[Export ("optionsForSharingService:shareProvider:")]
		NSCloudKitSharingServiceOptions Options (NSSharingService cloudKitSharingService, NSItemProvider provider);

		[Export ("sharingService:didSaveShare:")]
		void Saved (NSSharingService sharingService, CKShare share);

		[Export ("sharingService:didStopSharing:")]
		void Stopped (NSSharingService sharingService, CKShare share);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject),
			   Delegates = new string [] { "WeakDelegate" },
	Events = new Type [] { typeof (NSSharingServicePickerDelegate) })]
	interface NSSharingServicePicker {
		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSSharingServicePickerDelegate Delegate { get; set; }

		[DesignatedInitializer]
		[Export ("initWithItems:")]
		NativeHandle Constructor (NSObject [] items);

		[Export ("showRelativeToRect:ofView:preferredEdge:")]
		void ShowRelativeToRect (CGRect rect, NSView view, NSRectEdge preferredEdge);

		[Mac (13, 0)]
		[Export ("standardShareMenuItem")]
		NSMenuItem StandardShareMenuItem { get; }

		[NoiOS, Mac (13, 0)]
		[Export ("close")]
		void Close ();
	}

	interface INSSharingServicePickerDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface NSSharingServicePickerDelegate {
		[Export ("sharingServicePicker:sharingServicesForItems:proposedSharingServices:"), DelegateName ("NSSharingServicePickerSharingServicesForItems"), DefaultValueFromArgument ("proposedServices")]
		NSSharingService [] SharingServicesForItems (NSSharingServicePicker sharingServicePicker, NSObject [] items, NSSharingService [] proposedServices);

		[Export ("sharingServicePicker:delegateForSharingService:"), DelegateName ("NSSharingServicePickerDelegateForSharingService"), DefaultValue (null)]
		INSSharingServiceDelegate DelegateForSharingService (NSSharingServicePicker sharingServicePicker, NSSharingService sharingService);

		[Export ("sharingServicePicker:didChooseSharingService:"), EventArgs ("NSSharingServicePickerDidChooseSharingService")]
		void DidChooseSharingService (NSSharingServicePicker sharingServicePicker, NSSharingService service);

		[Mac (15, 0)]
		[Export ("sharingServicePickerCollaborationModeRestrictions:"), DelegateName ("NSSharingServicePickerDelegateCollaborationModeRestrictions"), DefaultValue (null)]
		[return: NullAllowed]
		NSSharingCollaborationModeRestriction [] GetCollaborationModeRestrictions (NSSharingServicePicker sharingServicePicker);
	}

	

	partial interface NSCollectionViewDelegate {
		[Export ("collectionView:pasteboardWriterForItemAtIndex:")]
		INSPasteboardWriting PasteboardWriterForItem (NSCollectionView collectionView, nuint index);

		[Export ("collectionView:updateDraggingItemsForDrag:")]
#if NET
		void UpdateDraggingItemsForDrag (NSCollectionView collectionView, INSDraggingInfo draggingInfo);
#else
		void UpdateDraggingItemsForDrag (NSCollectionView collectionView, NSDraggingInfo draggingInfo);
#endif

		[Export ("collectionView:draggingSession:willBeginAtPoint:forItemsAtIndexes:")]
		void DraggingSessionWillBegin (NSCollectionView collectionView, NSDraggingSession draggingSession,
			CGPoint screenPoint, NSIndexSet indexes);

		[Export ("collectionView:draggingSession:endedAtPoint:dragOperation:")]
		void DraggingSessionEnded (NSCollectionView collectionView, NSDraggingSession draggingSession,
			CGPoint screenPoint, NSDragOperation dragOperation);
	}

	public partial class NSColor {
		[Static, Export ("colorWithGenericGamma22White:alpha:")]
		public static NSColor FromGamma22White (nfloat white, nfloat alpha);

		[Static, Export ("colorWithSRGBRed:green:blue:alpha:")]
		public static NSColor FromSrgb (nfloat red, nfloat green, nfloat blue, nfloat alpha);

		[Notification, Field ("NSSystemColorsDidChangeNotification")]
		public NSString SystemColorsChanged { get; }
	}

	partial interface NSDocumentController {
		[Export ("duplicateDocumentWithContentsOfURL:copying:displayName:error:")]
		NSDocument DuplicateDocumentWithContentsOfUrl (NSUrl url, bool duplicateByCopying,
			[NullAllowed] string displayName, out NSError error);

		[Export ("reopenDocumentForURL:withContentsOfURL:display:completionHandler:")]
		void ReopenDocumentForUrl ([NullAllowed] NSUrl url, NSUrl contentsUrl,
			bool displayDocument, OpenDocumentCompletionHandler completionHandler);
	}

	partial interface NSViewColumnMoveEventArgs {
		[Export ("NSOldColumn")]
		nint OldColumn { get; }

		[Export ("NSNewColumn")]
		nint NewColumn { get; }
	}

	partial interface NSViewColumnResizeEventArgs {
		[Export ("NSTableColumn")]
		NSTableColumn Column { get; }

		[Export ("NSOldWidth")]
		nint OldWidth { get; }
	}

	partial interface NSOutlineViewItemEventArgs {
		[Export ("NSObject")]
		NSObject Item { get; }
	}

	partial interface NSOutlineView : NSAccessibilityOutline {

		[Notification, Field ("NSOutlineViewSelectionDidChangeNotification")]
		NSString SelectionDidChangeNotification { get; }

		[Notification, Field ("NSOutlineViewSelectionIsChangingNotification")]
		NSString SelectionIsChangingNotification { get; }

		[Notification (typeof (NSViewColumnMoveEventArgs))]
		[Field ("NSOutlineViewColumnDidMoveNotification")]
		NSString ColumnDidMoveNotification { get; }

		[Notification (typeof (NSViewColumnResizeEventArgs))]
		[Field ("NSOutlineViewColumnDidResizeNotification")]
		NSString ColumnDidResizeNotification { get; }

		[Notification (typeof (NSOutlineViewItemEventArgs))]
		[Field ("NSOutlineViewItemWillExpandNotification")]
		NSString ItemWillExpandNotification { get; }

		[Notification (typeof (NSOutlineViewItemEventArgs))]
		[Field ("NSOutlineViewItemDidExpandNotification")]
		NSString ItemDidExpandNotification { get; }

		[Notification (typeof (NSOutlineViewItemEventArgs))]
		[Field ("NSOutlineViewItemWillCollapseNotification")]
		NSString ItemWillCollapseNotification { get; }

		[Notification (typeof (NSOutlineViewItemEventArgs))]
		[Field ("NSOutlineViewItemDidCollapseNotification")]
		NSString ItemDidCollapseNotification { get; }

		// - (void)moveItemAtIndex:(NSInteger)fromIndex inParent:(id)oldParent toIndex:(NSInteger)toIndex inParent:(id)newParent NS_AVAILABLE_MAC(10_7);
		[Export ("moveItemAtIndex:inParent:toIndex:inParent:")]
		void MoveItem (nint fromIndex, [NullAllowed] NSObject oldParent, nint toIndex, [NullAllowed] NSObject newParent);

		[Export ("insertItemsAtIndexes:inParent:withAnimation:")]
		void InsertItems (NSIndexSet indexes, [NullAllowed] NSObject parent, NSTableViewAnimation animationOptions);

		[Export ("removeItemsAtIndexes:inParent:withAnimation:")]
		void RemoveItems (NSIndexSet indexes, [NullAllowed] NSObject parent, NSTableViewAnimation animationOptions);

		[Export ("insertRowsAtIndexes:withAnimation:")]
		void InsertRows (NSIndexSet indexes, NSTableViewAnimation animationOptions);

		[Export ("removeRowsAtIndexes:withAnimation:")]
		void RemoveRows (NSIndexSet indexes, NSTableViewAnimation animationOptions);

		// - (void)moveRowAtIndex:(NSInteger)oldIndex toIndex:(NSInteger)newIndex UNAVAILABLE_ATTRIBUTE;
		[Export ("moveRowAtIndex:toIndex:")]
		void MoveRow (nint oldIndex, nint newIndex);
	}

	partial interface NSOutlineViewDataSource {
		// - (id <NSPasteboardWriting>)outlineView:(NSOutlineView *)outlineView pasteboardWriterForItem:(id)item NS_AVAILABLE_MAC(10_7);
		[Export ("outlineView:pasteboardWriterForItem:")]
		INSPasteboardWriting PasteboardWriterForItem (NSOutlineView outlineView, NSObject item);

		// - (void)outlineView:(NSOutlineView *)outlineView draggingSession:(NSDraggingSession *)session willBeginAtPoint:(NSPoint)screenPoint forItems:(NSArray *)draggedItems NS_AVAILABLE_MAC(10_7);
		[Export ("outlineView:draggingSession:willBeginAtPoint:forItems:")]
		void DraggingSessionWillBegin (NSOutlineView outlineView, NSDraggingSession session, CGPoint screenPoint, NSArray draggedItems);

		// - (void)outlineView:(NSOutlineView *)outlineView draggingSession:(NSDraggingSession *)session endedAtPoint:(NSPoint)screenPoint operation:(NSDragOperation)operation NS_AVAILABLE_MAC(10_7);
		[Export ("outlineView:draggingSession:endedAtPoint:operation:")]
		void DraggingSessionEnded (NSOutlineView outlineView, NSDraggingSession session, CGPoint screenPoint, NSDragOperation operation);

		// - (void)outlineView:(NSOutlineView *)outlineView updateDraggingItemsForDrag:(id <NSDraggingInfo>)draggingInfo NS_AVAILABLE_MAC(10_7);
		[Export ("outlineView:updateDraggingItemsForDrag:")]
#if NET
		void UpdateDraggingItemsForDrag (NSOutlineView outlineView, INSDraggingInfo draggingInfo);
#else
		void UpdateDraggingItemsForDrag (NSOutlineView outlineView, NSDraggingInfo draggingInfo);
#endif
	}

	interface NSWindowExposeEventArgs {
		[Export ("NSExposedRect", ArgumentSemantic.Copy)]
		CGRect ExposedRect { get; }
	}

	interface NSWindowBackingPropertiesEventArgs {
		[Export ("NSBackingPropertyOldScaleFactorKey")]
		nint OldScaleFactor { get; }

		[Export ("NSBackingPropertyOldColorSpaceKey")]
		NSColorSpace OldColorSpace { get; }
	}

	

	partial interface NSPrintOperation {
		[Export ("preferredRenderingQuality")]
		NSPrintRenderingQuality PreferredRenderingQuality { get; }
	}

#if !NET
	// This category is implemented directly on the NSResponder class instead.
	// Ref: https://github.com/xamarin/xamarin-macios/issues/4837
	[NoMacCatalyst]
	[Category, BaseType (typeof (NSResponder))]
	partial interface NSControlEditingSupport {
		[Export ("validateProposedFirstResponder:forEvent:")]
		bool ValidateProposedFirstResponder (NSResponder responder, [NullAllowed] NSEvent forEvent);
	}
#endif

	partial interface NSResponder {
		[Export ("wantsScrollEventsForSwipeTrackingOnAxis:")]
		bool WantsScrollEventsForSwipeTrackingOnAxis (NSEventGestureAxis axis);

		[Export ("supplementalTargetForAction:sender:")]
		NSObject SupplementalTargetForAction (Selector action, [NullAllowed] NSObject sender);

		[Export ("smartMagnifyWithEvent:")]
		void SmartMagnify (NSEvent withEvent);

		[Export ("quickLookWithEvent:")]
		void QuickLook (NSEvent withEvent);

		// Inlined the NSControlEditingSupport category. Needs to be here to make the API easier to be used.
		// Ref: https://github.com/xamarin/xamarin-macios/issues/4837
		[Export ("validateProposedFirstResponder:forEvent:")]
		bool ValidateProposedFirstResponder (NSResponder responder, [NullAllowed] NSEvent forEvent);

		[MacCatalyst (13, 1)]
		[Export ("changeModeWithEvent:")]
		void ChangeMode (NSEvent withEvent);
	}

	[NoMacCatalyst]
	[Category, BaseType (typeof (NSResponder))]
	partial interface NSStandardKeyBindingMethods {
		[Export ("quickLookPreviewItems:")]
		void QuickLookPreviewItems (NSObject sender);
	}

	[NoMacCatalyst]
	[Category, BaseType (typeof (NSView))]
	partial interface NSRulerMarkerClientViewDelegation {
		[Export ("rulerView:locationForPoint:")]
		nfloat RulerViewLocation (NSRulerView ruler, CGPoint locationForPoint);

		[Export ("rulerView:pointForLocation:")]
		CGPoint RulerViewPoint (NSRulerView ruler, nfloat pointForLocation);
	}

	[NoMacCatalyst]
	[Category, BaseType (typeof (NSResponder))]
	partial interface NSTextFinderSupport {
		[Export ("performTextFinderAction:")]
		void PerformTextFinderAction ([NullAllowed] NSObject sender);
	}

	partial interface NSRunningApplication {
		[Static, Export ("terminateAutomaticallyTerminableApplications")]
		void TerminateAutomaticallyTerminableApplications ();
	}

	delegate void NSSpellCheckerShowCorrectionIndicatorOfTypeHandler (string acceptedString);

	partial interface NSSpellChecker {
		[Export ("correctionForWordRange:inString:language:inSpellDocumentWithTag:")]
		string GetCorrection (NSRange forWordRange, string inString, string language, nint inSpellDocumentWithTag);

		[Export ("languageForWordRange:inString:orthography:")]
		string GetLanguage (NSRange forWordRange, string inString, NSOrthography orthography);

		[Export ("recordResponse:toCorrection:forWord:language:inSpellDocumentWithTag:")]
		void RecordResponse (NSCorrectionResponse response, string toCorrection, string forWord, string language, nint inSpellDocumentWithTag);

		[Export ("dismissCorrectionIndicatorForView:")]
		void DismissCorrectionIndicator (NSView forView);

		[Export ("showCorrectionIndicatorOfType:primaryString:alternativeStrings:forStringInRect:view:completionHandler:")]
		void ShowCorrectionIndicatorOfType (NSCorrectionIndicatorType type, string primaryString, string [] alternativeStrings,
			CGRect forStringInRect, NSRulerView view, NSSpellCheckerShowCorrectionIndicatorOfTypeHandler completionHandler);

		[Static, Export ("isAutomaticTextReplacementEnabled")]
		bool IsAutomaticTextReplacementEnabled { get; }

		[Static, Export ("isAutomaticSpellingCorrectionEnabled")]
		bool IsAutomaticSpellingCorrectionEnabled { get; }

		[Field ("NSTextCheckingOrthographyKey")]
		NSString TextCheckingOrthographyKey { get; }

		[Field ("NSTextCheckingQuotesKey")]
		NSString TextCheckingQuotesKey { get; }

		[Field ("NSTextCheckingReplacementsKey")]
		NSString TextCheckingReplacementsKey { get; }

		[Field ("NSTextCheckingReferenceDateKey")]
		NSString TextCheckingReferenceDateKey { get; }

		[Field ("NSTextCheckingReferenceTimeZoneKey")]
		NSString TextCheckingReferenceTimeZoneKey { get; }

		[Field ("NSTextCheckingDocumentURLKey")]
		NSString TextCheckingDocumentURLKey { get; }

		[Field ("NSTextCheckingDocumentTitleKey")]
		NSString TextCheckingDocumentTitleKey { get; }

		[Field ("NSTextCheckingDocumentAuthorKey")]
		NSString TextCheckingDocumentAuthorKey { get; }

		[Field ("NSTextCheckingRegularExpressionsKey")]
		NSString TextCheckingRegularExpressionsKey { get; }

		[Notification, Field ("NSSpellCheckerDidChangeAutomaticSpellingCorrectionNotification")]
		NSString DidChangeAutomaticSpellingCorrectionNotification { get; }

		[Notification, Field ("NSSpellCheckerDidChangeAutomaticTextReplacementNotification")]
		NSString DidChangeAutomaticTextReplacementNotification { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSTextCheckingSelectedRangeKey")]
		NSString TextCheckingSelectedRangeKey { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSSpellCheckerDidChangeAutomaticCapitalizationNotification")]
		[Notification]
		NSString DidChangeAutomaticCapitalizationNotification { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSSpellCheckerDidChangeAutomaticPeriodSubstitutionNotification")]
		[Notification]
		NSString DidChangeAutomaticPeriodSubstitutionNotification { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSSpellCheckerDidChangeAutomaticTextCompletionNotification")]
		[Notification]
		NSString DidChangeAutomaticTextCompletionNotification { get; }

		[NoMacCatalyst, Mac (14, 0)]
		[Static]
		[Export ("automaticInlinePredictionEnabled")]
		bool IsAutomaticInlinePredictionEnabled { [Bind ("isAutomaticInlinePredictionEnabled")] get; }

		[NoMacCatalyst, Mac (14, 0)]
		[Field ("NSTextCheckingGenerateInlinePredictionsKey")]
		NSString TextCheckingGenerateInlinePredictionsKey { get; }
	}





#if !NET
	[NoMacCatalyst]
	[Category, BaseType (typeof (NSApplication))]
	partial interface NSRemoteNotifications_NSApplication {

		[Obsolete ("Use 'NSApplication.LaunchUserNotificationKey' instead.")]
		[Field ("NSApplicationLaunchUserNotificationKey", "AppKit")]
		NSString NSApplicationLaunchUserNotificationKey { get; }
	}
#endif

	partial interface NSControlTextEditingEventArgs {
		[Export ("NSFieldEditor")]
		NSTextView FieldEditor { get; }
	}

	partial interface NSControl {

		[Notification (typeof (NSControlTextEditingEventArgs))]
		[Field ("NSControlTextDidBeginEditingNotification")]
		NSString TextDidBeginEditingNotification { get; }

		[Notification (typeof (NSControlTextEditingEventArgs))]
		[Field ("NSControlTextDidEndEditingNotification")]
		NSString TextDidEndEditingNotification { get; }

		[Notification (typeof (NSControlTextEditingEventArgs))]
		[Field ("NSControlTextDidChangeNotification")]
		NSString TextDidChangeNotification { get; }

		[Export ("allowsExpansionToolTips")]
		bool AllowsExpansionToolTips { get; set; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSViewToolTipOwner {
		[Abstract]
		[Export ("view:stringForToolTip:point:userData:")]
		string GetStringForToolTip (NSView view, nint tag, CGPoint point, IntPtr data);
	}

	partial interface NSMatrix : NSUserInterfaceValidations, NSViewToolTipOwner {

		[Export ("autorecalculatesCellSize")]
		bool AutoRecalculatesCellSize { get; set; }
	}

	partial interface NSForm {

		[Export ("preferredTextFieldWidth")]
		nfloat PreferredTextFieldWidth { get; set; }
	}

	partial interface NSFormCell {

		[Export ("preferredTextFieldWidth")]
		nfloat PreferredTextFieldWidth { get; set; }
	}

	public partial class NSColor {

#if !NET
		[Obsolete ("Use 'UnderPageBackground' instead.")]
		[Static, Export ("underPageBackgroundColor")]
		public static  NSColor UnderPageBackgroundColor { get; }
#endif

		[Static, Export ("underPageBackgroundColor")]
		public static NSColor UnderPageBackground { get; }

		[Static, Export ("colorWithCGColor:")]
		public static NSColor FromCGColor (CGColor cgColor);
	}

	delegate bool NSCustomImageRepDrawingHandler (CGRect dstRect);

	partial interface NSCustomImageRep {

		[Export ("initWithSize:flipped:drawingHandler:")]
		NativeHandle Constructor (CGSize size, bool flipped, NSCustomImageRepDrawingHandler drawingHandler);

		[Export ("drawingHandler")]
		NSCustomImageRepDrawingHandler DrawingHandler { get; }
	}

	delegate void NSDocumentMoveCompletionHandler (bool didMove);
	delegate void NSDocumentMoveToUrlCompletionHandler (NSError error);
	delegate void NSDocumentLockDocumentCompletionHandler (bool didLock);
	delegate void NSDocumentUnlockDocumentCompletionHandler (bool didUnlock);
	delegate void NSDocumentLockCompletionHandler (NSError error);
	delegate void NSDocumentUnlockCompletionHandler (NSError error);

	partial interface NSDocument : NSEditorRegistration, NSFilePresenter, NSMenuItemValidation
#if NET
	, NSUserInterfaceValidations // ValidateUserInterfaceItem was bound with NSObject and fix would break API compat  
#endif
	{
		[Export ("draft")]
		bool IsDraft { [Bind ("isDraft")] get; set; }

		[Export ("backupFileURL")]
		NSUrl BackupFileUrl { get; }

		[Export ("browseDocumentVersions:")]
		void BrowseDocumentVersions (NSObject sender);

		[Static, Export ("autosavesDrafts")]
		bool AutoSavesDrafts { get; }

		[Export ("renameDocument:")]
		void RenameDocument (NSObject sender);

		[Export ("moveDocumentToUbiquityContainer:")]
		void MoveDocumentToUbiquityContainer (NSObject sender);

		[Export ("moveDocument:")]
		void MoveDocument (NSObject sender);

		[Export ("moveDocumentWithCompletionHandler:")]
		void MoveDocumentWithCompletionHandler (NSDocumentMoveCompletionHandler completionHandler);

		[Export ("moveToURL:completionHandler:")]
		void MoveToUrl (NSUrl url, NSDocumentMoveToUrlCompletionHandler completionHandler);

		[Export ("lockDocument:")]
		void LockDocument (NSObject sender);

		[Export ("unlockDocument:")]
		void UnlockDocument (NSObject sender);

		[Export ("lockDocumentWithCompletionHandler:")]
		void LockDocumentWithCompletionHandler (NSDocumentLockDocumentCompletionHandler completionHandler);

		[Export ("lockWithCompletionHandler:")]
		void LockWithCompletionHandler (NSDocumentLockCompletionHandler completionHandler);

		[Export ("unlockDocumentWithCompletionHandler:")]
		void UnlockDocumentWithCompletionHandler (NSDocumentUnlockDocumentCompletionHandler completionHandler);

		[Export ("unlockWithCompletionHandler:")]
		void UnlockWithCompletionHandler (NSDocumentUnlockCompletionHandler completionHandler);

		[Export ("isLocked")]
		bool IsLocked { get; }

		[Export ("defaultDraftName")]
		string DefaultDraftName { get; }

		[Static, Export ("usesUbiquitousStorage")]
		bool UsesUbiquitousStorage { get; }

		[MacCatalyst (13, 1)]
		[Export ("encodeRestorableStateWithCoder:backgroundQueue:")]
		void EncodeRestorableState (NSCoder coder, NSOperationQueue queue);
	}

	delegate void NSDocumentControllerOpenPanelWithCompletionHandler (NSArray urlsToOpen);
	delegate void NSDocumentControllerOpenPanelResultHandler (nint result);

	partial interface NSDocumentController : NSMenuItemValidation
#if NET
	, NSUserInterfaceValidations // ValidateUserInterfaceItem was bound with NSObject and fix would break API compat  
#endif
	{

		[Export ("beginOpenPanelWithCompletionHandler:")]
		void BeginOpenPanelWithCompletionHandler (NSDocumentControllerOpenPanelWithCompletionHandler completionHandler);

		[Export ("beginOpenPanel:forTypes:completionHandler:")]
		void BeginOpenPanel (NSOpenPanel openPanel, NSArray inTypes, NSDocumentControllerOpenPanelResultHandler completionHandler);

		[MacCatalyst (13, 1)]
		[Export ("allowsAutomaticShareMenu")]
		bool AllowsAutomaticShareMenu { get; }

		[MacCatalyst (13, 1)]
		[Export ("standardShareMenuItem")]
		NSMenuItem StandardShareMenuItem { get; }
	}

	public partial class NSImage {

		[Static, Export ("imageWithSize:flipped:drawingHandler:")]
		public NSImage ImageWithSize (CGSize size, bool flipped, NSCustomImageRepDrawingHandler drawingHandler);
	}

	partial interface NSSplitViewDividerIndexEventArgs {
		// FIXME: The generator can't handle Nullable<int>, and
		// the key may or may not exist; if it doesn't exist, then
		// the generator will have this property always return 0,
		// which may actually be a valid index value. Either the
		// generator needs to support nullable, or ProbePresence
		// on non-boolean property types.
		//
		// [Export ("NSSplitViewDividerIndex")]
		// int? DividerIndex { get; }
	}

	[NoMacCatalyst]
	[Category, BaseType (typeof (NSSegmentedCell))]
	partial interface NSSegmentBackgroundStyle_NSSegmentedCell {

		[Field ("NSSharingServiceNamePostOnFacebook")]
		NSString SharingServiceNamePostOnFacebook { get; }

		[Field ("NSSharingServiceNamePostOnTwitter")]
		NSString SharingServiceNamePostOnTwitter { get; }

		[Field ("NSSharingServiceNamePostOnSinaWeibo")]
		NSString SharingServiceNamePostOnSinaWeibo { get; }

		[Field ("NSSharingServiceNameComposeEmail")]
		NSString SharingServiceNameComposeEmail { get; }

		[Field ("NSSharingServiceNameComposeMessage")]
		NSString SharingServiceNameComposeMessage { get; }

		[Field ("NSSharingServiceNameSendViaAirDrop")]
		NSString SharingServiceNameSendViaAirDrop { get; }

		[Field ("NSSharingServiceNameAddToSafariReadingList")]
		NSString SharingServiceNameAddToSafariReadingList { get; }

		[Field ("NSSharingServiceNameAddToIPhoto")]
		NSString SharingServiceNameAddToIPhoto { get; }

		[Field ("NSSharingServiceNameAddToAperture")]
		NSString SharingServiceNameAddToAperture { get; }

		[Field ("NSSharingServiceNameUseAsTwitterProfileImage")]
		NSString SharingServiceNameUseAsTwitterProfileImage { get; }

		[Field ("NSSharingServiceNameUseAsDesktopPicture")]
		NSString SharingServiceNameUseAsDesktopPicture { get; }

		[Field ("NSSharingServiceNamePostImageOnFlickr")]
		NSString SharingServiceNamePostImageOnFlickr { get; }

		[Field ("NSSharingServiceNamePostVideoOnVimeo")]
		NSString SharingServiceNamePostVideoOnVimeo { get; }

		[Field ("NSSharingServiceNamePostVideoOnYouku")]
		NSString SharingServiceNamePostVideoOnYouku { get; }

		[Field ("NSSharingServiceNamePostVideoOnTudou")]
		NSString SharingServiceNamePostVideoOnTudou { get; }
	}



	/*partial interface NSTextViewDelegate {

		[Export ("textView:willShowSharingServicePicker:forItems:"), DelegateName (...)]
		NSSharingServicePicker WillShowSharingService (NSTextView textView,
			NSSharingServicePicker servicePicker, NSArray forItems);
	}*/

	interface NSTextAlternativesSelectedAlternativeStringEventArgs {
		[Export ("NSAlternativeString")]
		string AlternativeString { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	public partial class NSTextAlternatives : NSObject {
		
		public NSTextAlternatives (NativeHandle handle) : base (handle) {}

		[Export ("initWithPrimaryString:alternativeStrings:")]
		public NativeHandle Constructor (string primaryString, NSArray alternativeStrings);

		[Export ("primaryString", ArgumentSemantic.Copy)]
		public string PrimaryString { get; }

		[Export ("alternativeStrings", ArgumentSemantic.Copy)]
		public NSArray AlternativeStrings { get; }

		[Export ("noteSelectedAlternativeString:")]
		public void NoteSelectedAlternativeString (string alternativeString);

		[Notification (typeof (NSTextAlternativesSelectedAlternativeStringEventArgs)),
			Field ("NSTextAlternativesSelectedAlternativeStringNotification")]
		public NSString SelectedAlternativeStringNotification { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	public partial class NSGlyphInfo : NSObject, NSCoding, NSCopying {
		
		public NSGlyphInfo (NativeHandle handle) : base (handle) {}

		[Static, Export ("glyphInfoWithGlyphName:forFont:baseString:")]
		public static NSGlyphInfo Get (string glyphName, NSFont forFont, string baseString);

		[Static, Export ("glyphInfoWithGlyph:forFont:baseString:")]
		public static NSGlyphInfo Get (uint /* NSGlyph = unsigned int */ glyph, NSFont forFont, string baseString);

		[Static, Export ("glyphInfoWithCharacterIdentifier:collection:baseString:")]
		public static 	NSGlyphInfo Get (nuint characterIdentifier, NSCharacterCollection characterCollection, string baseString);

		[Export ("glyphName")]
		public string GlyphName { get; }

		[Export ("characterIdentifier")]
		public 	nuint CharacterIdentifier { get; }

		[Export ("characterCollection")]
		public NSCharacterCollection CharacterCollection { get; }

		[Static]
		[Export ("glyphInfoWithCGGlyph:forFont:baseString:")]
		[return: NullAllowed]
		public static NSGlyphInfo GetGlyphInfo (ushort glyph, NSFont font, string @string);

		[Export ("glyphID")]
		public ushort GlyphId { get; }

		[Export ("baseString")]
		public 	string BaseString { get; }
	}

	partial interface NSTableViewDelegate {

		[Export ("tableView:toolTipForCell:rect:tableColumn:row:mouseLocation:"), DelegateName ("NSTableViewToolTip"), DefaultValue ("null")]
		NSString GetToolTip (NSTableView tableView, NSCell cell, ref CGRect rect, [NullAllowed] NSTableColumn tableColumn, nint row, CGPoint mouseLocation);

		[NoMacCatalyst, Mac (14, 0)]
		[Export ("tableView:userCanChangeVisibilityOfTableColumn:"), DelegateName ("NSTableViewUserCanChangeColumnVisibility"), DefaultValue (false)]
		bool UserCanChangeVisibility (NSTableView tableView, NSTableColumn column);

		[NoMacCatalyst, Mac (14, 0)]
		[Export ("tableView:userDidChangeVisibilityOfTableColumns:"), EventArgs ("NSTableViewUserCanChangeColumnsVisibility")]
		void UserDidChangeVisibility (NSTableView tableView, NSTableColumn [] columns);
	}

	partial interface NSBrowser {
		[Notification, Field ("NSBrowserColumnConfigurationDidChangeNotification")]
		NSString ColumnConfigurationChangedNotification { get; }
	}

	partial interface NSColorPanel {
		[Notification, Field ("NSColorPanelColorDidChangeNotification")]
		NSString ColorChangedNotification { get; }
	}

	public partial class NSFont {
		[Notification, Field ("NSAntialiasThresholdChangedNotification")]
		public NSString AntialiasThresholdChangedNotification { get; }

		[Notification, Field ("NSFontSetChangedNotification")]
		public NSString FontSetChangedNotification { get; }
	}

	partial interface NSHelpManager {
		[Notification, Field ("NSContextHelpModeDidActivateNotification")]
		NSString ContextHelpModeDidActivateNotification { get; }

		[Notification, Field ("NSContextHelpModeDidDeactivateNotification")]
		NSString ContextHelpModeDidDeactivateNotification { get; }
	}

	partial interface NSDrawer {
		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSSplitViewController' instead.")]
		[Notification, Field ("NSDrawerWillOpenNotification")]
		NSString WillOpenNotification { get; }

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSSplitViewController' instead.")]
		[Notification, Field ("NSDrawerDidOpenNotification")]
		NSString DidOpenNotification { get; }

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSSplitViewController' instead.")]
		[Notification, Field ("NSDrawerWillCloseNotification")]
		NSString WillCloseNotification { get; }

		[Deprecated (PlatformName.MacOSX, 10, 13, message: "Use 'NSSplitViewController' instead.")]
		[Notification, Field ("NSDrawerDidCloseNotification")]
		NSString DidCloseNotification { get; }
	}

	

	partial interface NSPopUpButtonCell : NSMenuItemValidation {
		[Notification, Field ("NSPopUpButtonCellWillPopUpNotification")]
		NSString WillPopUpNotification { get; }
	}

	partial interface NSPopUpButton {
		[Notification, Field ("NSPopUpButtonWillPopUpNotification")]
		NSString WillPopUpNotification { get; }
	}

	partial interface NSRuleEditor {
		[Notification, Field ("NSRuleEditorRowsDidChangeNotification")]
		NSString RowsDidChangeNotification { get; }
	}



	partial interface NSTableView : NSUserInterfaceValidations {
		[Notification, Field ("NSTableViewSelectionDidChangeNotification")]
		NSString SelectionDidChangeNotification { get; }

		[Notification, Field ("NSTableViewSelectionIsChangingNotification")]
		NSString SelectionIsChangingNotification { get; }

		[Notification (typeof (NSViewColumnMoveEventArgs))]
		[Field ("NSTableViewColumnDidMoveNotification")]
		NSString ColumnDidMoveNotification { get; }

		[Notification (typeof (NSViewColumnResizeEventArgs))]
		[Field ("NSTableViewColumnDidResizeNotification")]
		NSString ColumnDidResizeNotification { get; }
	}

	[NoMacCatalyst]
	partial interface NSTextDidEndEditingEventArgs {
		// FIXME: I think this is essentially a flags value
		// of movements and characters. The docs are a bit
		// confusing.
		[Export ("NSTextMovement")]
		nint Movement { get; }
	}



	partial interface NSToolbarItemEventArgs {
		[Export ("item")]
		NSToolbarItem Item { get; }
	}

	partial interface NSToolbar {
		[Notification (typeof (NSToolbarItemEventArgs))]
		[Field ("NSToolbarWillAddItemNotification")]
		NSString NSToolbarWillAddItemNotification { get; }

		[Notification (typeof (NSToolbarItemEventArgs))]
		[Field ("NSToolbarDidRemoveItemNotification")]
		NSString NSToolbarDidRemoveItemNotification { get; }
	}

	partial interface NSImageRep {
		[Notification, Field ("NSImageRepRegistryDidChangeNotification")]
		NSString RegistryDidChangeNotification { get; }
	}

	interface INSAccessibility { };
	interface INSAccessibilityElement { };

	[NoMacCatalyst]
	[Native]
	public enum NSAccessibilityOrientation : long {
		Unknown = 0,
		Vertical = 1,
		Horizontal = 2,
	}

	[NoMacCatalyst]
	[Native]
	public enum NSAccessibilitySortDirection : long {
		Unknown = 0,
		Ascending = 1,
		Descending = 2,
	}

	[NoMacCatalyst]
	[Native]
	public enum NSAccessibilityRulerMarkerType : long {
		Unknown = 0,
		TabStopLeft = 1,
		TabStopRight = 2,
		TabStopCenter = 3,
		TabStopDecimal = 4,
		IndentHead = 5,
		IndentTail = 6,
		IndentFirstLine = 7,
	}

	[NoMacCatalyst]
	[Native]
	public enum NSAccessibilityUnits : long {
		Unknown = 0,
		Inches = 1,
		Centimeters = 2,
		Points = 3,
		Picas = 4,
	}

	[NoMacCatalyst]
	[Native]
	public enum NSAccessibilityPriorityLevel : long {
		Low = 10,
		Medium = 50,
		High = 90,
	}

	// 10.9 for fields/notification but 10.10 for protocol
	// attributes added to both cases in NSAccessibility.cs
	[NoMacCatalyst]
	[NoiOS]
	[NoTV]
	[Protocol]
	interface NSAccessibility {
		[Abstract]
		[Export ("accessibilityFrame", ArgumentSemantic.Assign)]
		CGRect AccessibilityFrame { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityIdentifier")]
		string AccessibilityIdentifier { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityParent", ArgumentSemantic.Weak)]
		NSObject AccessibilityParent { get; set; }

		[Abstract]
		[Export ("accessibilityFocused")]
		bool AccessibilityFocused { [Bind ("isAccessibilityFocused")] get; set; }

		[Abstract]
		[Export ("accessibilityElement")]
		bool AccessibilityElement { [Bind ("isAccessibilityElement")] get; set; }

		[Abstract]
		[Export ("accessibilityActivationPoint", ArgumentSemantic.Assign)]
		CGPoint AccessibilityActivationPoint { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityTopLevelUIElement", ArgumentSemantic.Weak)]
		NSObject AccessibilityTopLevelUIElement { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityURL", ArgumentSemantic.Copy)]
		NSUrl AccessibilityUrl { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityValue", ArgumentSemantic.Strong)]
		NSObject AccessibilityValue { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityValueDescription")]
		string AccessibilityValueDescription { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityVisibleChildren", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityVisibleChildren { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySubrole")]
		string AccessibilitySubrole { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityTitle")]
		string AccessibilityTitle { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityTitleUIElement", ArgumentSemantic.Weak)]
		NSObject AccessibilityTitleUIElement { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityNextContents", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityNextContents { get; set; }

		[Abstract]
		[Export ("accessibilityOrientation", ArgumentSemantic.Assign)]
		NSAccessibilityOrientation AccessibilityOrientation { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityOverflowButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityOverflowButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityPlaceholderValue")]
		string AccessibilityPlaceholderValue { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityPreviousContents", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityPreviousContents { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityRole")]
		string AccessibilityRole { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityRoleDescription")]
		string AccessibilityRoleDescription { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySearchButton", ArgumentSemantic.Strong)]
		NSObject AccessibilitySearchButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySearchMenu", ArgumentSemantic.Strong)]
		NSObject AccessibilitySearchMenu { get; set; }

		[Abstract]
		[Export ("accessibilitySelected")]
		bool AccessibilitySelected { [Bind ("isAccessibilitySelected")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySelectedChildren", ArgumentSemantic.Copy)]
		NSObject [] AccessibilitySelectedChildren { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityServesAsTitleForUIElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityServesAsTitleForUIElements { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityShownMenu", ArgumentSemantic.Strong)]
		NSObject AccessibilityShownMenu { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMinValue", ArgumentSemantic.Strong)]
		NSObject AccessibilityMinValue { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMaxValue", ArgumentSemantic.Strong)]
		NSObject AccessibilityMaxValue { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityLinkedUIElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityLinkedUIElements { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityWindow", ArgumentSemantic.Weak)]
		NSObject AccessibilityWindow { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityHelp")]
		string AccessibilityHelp { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityFilename")]
		string AccessibilityFilename { get; set; }

		[Abstract]
		[Export ("accessibilityExpanded")]
		bool AccessibilityExpanded { [Bind ("isAccessibilityExpanded")] get; set; }

		[Abstract]
		[Export ("accessibilityEdited")]
		bool AccessibilityEdited { [Bind ("isAccessibilityEdited")] get; set; }

		[Abstract]
		[Export ("accessibilityEnabled")]
		bool AccessibilityEnabled { [Bind ("isAccessibilityEnabled")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityChildren", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityChildren { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityClearButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityClearButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityCancelButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityCancelButton { get; set; }

		[Abstract]
		[Export ("accessibilityProtectedContent")]
		bool AccessibilityProtectedContent { [Bind ("isAccessibilityProtectedContent")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityContents", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityContents { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityLabel")]
		string AccessibilityLabel { get; set; }

		[Abstract]
		[Export ("accessibilityAlternateUIVisible")]
		bool AccessibilityAlternateUIVisible { [Bind ("isAccessibilityAlternateUIVisible")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySharedFocusElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilitySharedFocusElements { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityApplicationFocusedUIElement", ArgumentSemantic.Strong)]
		NSObject AccessibilityApplicationFocusedUIElement { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMainWindow", ArgumentSemantic.Strong)]
		NSObject AccessibilityMainWindow { get; set; }

		[Abstract]
		[Export ("accessibilityHidden")]
		bool AccessibilityHidden { [Bind ("isAccessibilityHidden")] get; set; }

		[Abstract]
		[Export ("accessibilityFrontmost")]
		bool AccessibilityFrontmost { [Bind ("isAccessibilityFrontmost")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityFocusedWindow", ArgumentSemantic.Strong)]
		NSObject AccessibilityFocusedWindow { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityWindows", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityWindows { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityExtrasMenuBar", ArgumentSemantic.Weak)]
		NSObject AccessibilityExtrasMenuBar { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMenuBar", ArgumentSemantic.Weak)]
		NSObject AccessibilityMenuBar { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityColumnTitles", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityColumnTitles { get; set; }

		[Abstract]
		[Export ("accessibilityOrderedByRow")]
		bool AccessibilityOrderedByRow { [Bind ("isAccessibilityOrderedByRow")] get; set; }

		[Abstract]
		[Export ("accessibilityHorizontalUnits", ArgumentSemantic.Assign)]
		NSAccessibilityUnits AccessibilityHorizontalUnits { get; set; }

		[Abstract]
		[Export ("accessibilityVerticalUnits", ArgumentSemantic.Assign)]
		NSAccessibilityUnits AccessibilityVerticalUnits { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityHorizontalUnitDescription")]
		string AccessibilityHorizontalUnitDescription { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityVerticalUnitDescription")]
		string AccessibilityVerticalUnitDescription { get; set; }

		[Abstract]
		[Export ("accessibilityLayoutPointForScreenPoint:")]
		CGPoint GetAccessibilityLayoutForScreen (CGPoint point);

		[Abstract]
		[Export ("accessibilityLayoutSizeForScreenSize:")]
		CGSize GetAccessibilityLayoutForScreen (CGSize size);

		[Abstract]
		[Export ("accessibilityScreenPointForLayoutPoint:")]
		CGPoint GetAccessibilityScreenForLayout (CGPoint point);

		[Abstract]
		[Export ("accessibilityScreenSizeForLayoutSize:")]
		CGSize GetAccessibilityScreenForLayout (CGSize size);

		[Abstract]
		[NullAllowed, Export ("accessibilityHandles", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityHandles { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityWarningValue", ArgumentSemantic.Strong)]
		NSObject AccessibilityWarningValue { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityCriticalValue", ArgumentSemantic.Strong)]
		NSObject AccessibilityCriticalValue { get; set; }

		[Abstract]
		[Export ("accessibilityDisclosed")]
		bool AccessibilityDisclosed { [Bind ("isAccessibilityDisclosed")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityDisclosedByRow", ArgumentSemantic.Weak)]
		NSObject AccessibilityDisclosedByRow { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityDisclosedRows", ArgumentSemantic.Strong)]
		NSObject AccessibilityDisclosedRows { get; set; }

		[Abstract]
		[Export ("accessibilityDisclosureLevel")]
		nint AccessibilityDisclosureLevel { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMarkerUIElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityMarkerUIElements { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMarkerValues", ArgumentSemantic.Strong)]
		NSObject AccessibilityMarkerValues { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMarkerGroupUIElement", ArgumentSemantic.Strong)]
		NSObject AccessibilityMarkerGroupUIElement { get; set; }

		[Abstract]
		[Export ("accessibilityUnits", ArgumentSemantic.Assign)]
		NSAccessibilityUnits AccessibilityUnits { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityUnitDescription")]
		string AccessibilityUnitDescription { get; set; }

		[Abstract]
		[Export ("accessibilityRulerMarkerType", ArgumentSemantic.Assign)]
		NSAccessibilityRulerMarkerType AccessibilityRulerMarkerType { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMarkerTypeDescription")]
		string AccessibilityMarkerTypeDescription { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityHorizontalScrollBar", ArgumentSemantic.Strong)]
		NSObject AccessibilityHorizontalScrollBar { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityVerticalScrollBar", ArgumentSemantic.Strong)]
		NSObject AccessibilityVerticalScrollBar { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityAllowedValues", ArgumentSemantic.Copy)]
		NSNumber [] AccessibilityAllowedValues { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityLabelUIElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityLabelUIElements { get; set; }

		[Abstract]
		[Export ("accessibilityLabelValue")]
		float AccessibilityLabelValue { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySplitters", ArgumentSemantic.Copy)]
		NSObject [] AccessibilitySplitters { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityDecrementButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityDecrementButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityIncrementButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityIncrementButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityTabs", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityTabs { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityHeader", ArgumentSemantic.Strong)]
		NSObject AccessibilityHeader { get; set; }

		[Abstract]
		[Export ("accessibilityColumnCount")]
		nint AccessibilityColumnCount { get; set; }

		[Abstract]
		[Export ("accessibilityRowCount")]
		nint AccessibilityRowCount { get; set; }

		[Abstract]
		[Export ("accessibilityIndex")]
		nint AccessibilityIndex { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityColumns", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityColumns { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityRows", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityRows { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityVisibleRows", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityVisibleRows { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySelectedRows", ArgumentSemantic.Copy)]
		NSObject [] AccessibilitySelectedRows { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityVisibleColumns", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityVisibleColumns { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySelectedColumns", ArgumentSemantic.Copy)]
		NSObject [] AccessibilitySelectedColumns { get; set; }

		[Abstract]
		[Export ("accessibilitySortDirection", ArgumentSemantic.Assign)]
		NSAccessibilitySortDirection AccessibilitySortDirection { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityRowHeaderUIElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityRowHeaderUIElements { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySelectedCells", ArgumentSemantic.Copy)]
		NSObject [] AccessibilitySelectedCells { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityVisibleCells", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityVisibleCells { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityColumnHeaderUIElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilityColumnHeaderUIElements { get; set; }

		[Abstract]
		[Export ("accessibilityCellForColumn:row:")]
		[return: NullAllowed]
		NSObject GetAccessibilityCellForColumn (nint column, nint row);

		[Abstract]
		[Export ("accessibilityRowIndexRange", ArgumentSemantic.Assign)]
		NSRange AccessibilityRowIndexRange { get; set; }

		[Abstract]
		[Export ("accessibilityColumnIndexRange", ArgumentSemantic.Assign)]
		NSRange AccessibilityColumnIndexRange { get; set; }

		[Abstract]
		[Export ("accessibilityInsertionPointLineNumber")]
		nint AccessibilityInsertionPointLineNumber { get; set; }

		[Abstract]
		[Export ("accessibilitySharedCharacterRange", ArgumentSemantic.Assign)]
		NSRange AccessibilitySharedCharacterRange { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySharedTextUIElements", ArgumentSemantic.Copy)]
		NSObject [] AccessibilitySharedTextUIElements { get; set; }

		[Abstract]
		[Export ("accessibilityVisibleCharacterRange", ArgumentSemantic.Assign)]
		NSRange AccessibilityVisibleCharacterRange { get; set; }

		[Abstract]
		[Export ("accessibilityNumberOfCharacters")]
		nint AccessibilityNumberOfCharacters { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySelectedText")]
		string AccessibilitySelectedText { get; set; }

		[Abstract]
		[Export ("accessibilitySelectedTextRange", ArgumentSemantic.Assign)]
		NSRange AccessibilitySelectedTextRange { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySelectedTextRanges", ArgumentSemantic.Copy)]
		NSValue [] AccessibilitySelectedTextRanges { get; set; }

		[Abstract]
		[Export ("accessibilityAttributedStringForRange:")]
		[return: NullAllowed]
		NSAttributedString GetAccessibilityAttributedString (NSRange range);

		[Abstract]
		[Export ("accessibilityRangeForLine:")]
		NSRange GetAccessibilityRangeForLine (nint line);

		[Abstract]
		[Export ("accessibilityStringForRange:")]
		[return: NullAllowed]
		string GetAccessibilityString (NSRange range);

		[Abstract]
		[Export ("accessibilityRangeForPosition:")]
		NSRange GetAccessibilityRange (CGPoint point);

		[Abstract]
		[Export ("accessibilityRangeForIndex:")]
		NSRange GetAccessibilityRange (nint index);

		[Abstract]
		[Export ("accessibilityFrameForRange:")]
		CGRect GetAccessibilityFrame (NSRange range);

		[Abstract]
		[Export ("accessibilityRTFForRange:")]
		[return: NullAllowed]
		NSData GetAccessibilityRtf (NSRange range);

		[Abstract]
		[Export ("accessibilityStyleRangeForIndex:")]
		NSRange GetAccessibilityStyleRange (nint index);

		[Abstract]
		[Export ("accessibilityLineForIndex:")]
		nint GetAccessibilityLine (nint index);

		[Abstract]
		[NullAllowed, Export ("accessibilityToolbarButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityToolbarButton { get; set; }

		[Abstract]
		[Export ("accessibilityModal")]
		bool AccessibilityModal { [Bind ("isAccessibilityModal")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityProxy", ArgumentSemantic.Strong)]
		NSObject AccessibilityProxy { get; set; }

		[Abstract]
		[Export ("accessibilityMain")]
		bool AccessibilityMain { [Bind ("isAccessibilityMain")] get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityFullScreenButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityFullScreenButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityGrowArea", ArgumentSemantic.Strong)]
		NSObject AccessibilityGrowArea { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityDocument")]
		string AccessibilityDocument { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityDefaultButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityDefaultButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityCloseButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityCloseButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityZoomButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityZoomButton { get; set; }

		[Abstract]
		[NullAllowed, Export ("accessibilityMinimizeButton", ArgumentSemantic.Strong)]
		NSObject AccessibilityMinimizeButton { get; set; }

		[Abstract]
		[Export ("accessibilityMinimized")]
		bool AccessibilityMinimized { [Bind ("isAccessibilityMinimized")] get; set; }

		[Abstract]
		[Export ("accessibilityPerformCancel")]
		bool AccessibilityPerformCancel ();

		[Abstract]
		[Export ("accessibilityPerformConfirm")]
		bool AccessibilityPerformConfirm ();

		[Abstract]
		[Export ("accessibilityPerformDecrement")]
		bool AccessibilityPerformDecrement ();

		[Abstract]
		[Export ("accessibilityPerformDelete")]
		bool AccessibilityPerformDelete ();

		[Abstract]
		[Export ("accessibilityPerformIncrement")]
		bool AccessibilityPerformIncrement ();

		[Abstract]
		[Export ("accessibilityPerformPick")]
		bool AccessibilityPerformPick ();

		[Abstract]
		[Export ("accessibilityPerformPress")]
		bool AccessibilityPerformPress ();

		[Abstract]
		[Export ("accessibilityPerformRaise")]
		bool AccessibilityPerformRaise ();

		[Abstract]
		[Export ("accessibilityPerformShowAlternateUI")]
		bool AccessibilityPerformShowAlternateUI ();

		[Abstract]
		[Export ("accessibilityPerformShowDefaultUI")]
		bool AccessibilityPerformShowDefaultUI ();

		[Abstract]
		[Export ("accessibilityPerformShowMenu")]
		bool AccessibilityPerformShowMenu ();

		[Abstract]
		[Export ("isAccessibilitySelectorAllowed:")]
		bool IsAccessibilitySelectorAllowed (Selector selector);

#if NET
		[Abstract]
#endif
		[Export ("accessibilityRequired")]
		bool AccessibilityRequired { [Bind ("isAccessibilityRequired")] get; set; }

		[Notification]
		[Field ("NSAccessibilityMainWindowChangedNotification")]
		NSString MainWindowChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityFocusedWindowChangedNotification")]
		NSString FocusedWindowChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityFocusedUIElementChangedNotification")]
		NSString UIElementFocusedChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityApplicationActivatedNotification")]
		NSString ApplicationActivatedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityApplicationDeactivatedNotification")]
		NSString ApplicationDeactivatedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityApplicationHiddenNotification")]
		NSString ApplicationHiddenNotification { get; }

		[Notification]
		[Field ("NSAccessibilityApplicationShownNotification")]
		NSString ApplicationShownNotification { get; }

		[Notification]
		[Field ("NSAccessibilityWindowCreatedNotification")]
		NSString WindowCreatedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityWindowMovedNotification")]
		NSString WindowMovedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityWindowResizedNotification")]
		NSString WindowResizedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityWindowMiniaturizedNotification")]
		NSString WindowMiniaturizedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityWindowDeminiaturizedNotification")]
		NSString WindowDeminiaturizedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityDrawerCreatedNotification")]
		NSString DrawerCreatedNotification { get; }

		[Notification]
		[Field ("NSAccessibilitySheetCreatedNotification")]
		NSString SheetCreatedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityUIElementDestroyedNotification")]
		NSString UIElementDestroyedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityValueChangedNotification")]
		NSString ValueChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityTitleChangedNotification")]
		NSString TitleChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityResizedNotification")]
		NSString ResizedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityMovedNotification")]
		NSString MovedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityCreatedNotification")]
		NSString CreatedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityLayoutChangedNotification")]
		NSString LayoutChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityHelpTagCreatedNotification")]
		NSString HelpTagCreatedNotification { get; }

		[Notification]
		[Field ("NSAccessibilitySelectedTextChangedNotification")]
		NSString SelectedTextChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityRowCountChangedNotification")]
		NSString RowCountChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilitySelectedChildrenChangedNotification")]
		NSString SelectedChildrenChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilitySelectedRowsChangedNotification")]
		NSString SelectedRowsChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilitySelectedColumnsChangedNotification")]
		NSString SelectedColumnsChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityRowExpandedNotification")]
		NSString RowExpandedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityRowCollapsedNotification")]
		NSString RowCollapsedNotification { get; }

		[Notification]
		[Field ("NSAccessibilitySelectedCellsChangedNotification")]
		NSString SelectedCellsChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityUnitsChangedNotification")]
		NSString UnitsChangedNotification { get; }

		[Notification]
		[Field ("NSAccessibilitySelectedChildrenMovedNotification")]
		NSString SelectedChildrenMovedNotification { get; }

		[Notification]
		[Field ("NSAccessibilityAnnouncementRequestedNotification")]
		NSString AnnouncementRequestedNotification { get; }

#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("accessibilityChildrenInNavigationOrder", ArgumentSemantic.Copy)]
		NSAccessibilityElement [] AccessibilityChildrenInNavigationOrder { get; set; }

#if NET
		[Abstract]
#endif
		[Export ("accessibilityCustomRotors", ArgumentSemantic.Copy)]
		NSAccessibilityCustomRotor [] AccessibilityCustomRotors { get; set; }

#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("accessibilityCustomActions", ArgumentSemantic.Copy)]
		NSAccessibilityCustomAction [] AccessibilityCustomActions { get; set; }

		[Mac (14, 0)]
#if XAMCORE_5_0
		[Abstract]
#endif
		[Export ("accessibilityUserInputLabels", ArgumentSemantic.Copy)]
		string [] AccessibilityUserInputLabels { get; set; }

		[Mac (14, 0)]
#if XAMCORE_5_0
		[Abstract]
#endif
		[Export ("accessibilityAttributedUserInputLabels", ArgumentSemantic.Copy)]
		NSAttributedString [] AccessibilityAttributedUserInputLabels { get; set; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSCollectionViewSectionHeaderView : NSCollectionViewElement {
		[NullAllowed, Export ("sectionCollapseButton", ArgumentSemantic.Assign)]
		NSButton SectionCollapseButton { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSAccessibilityElement : NSAccessibility {
		[Export ("accessibilityAddChildElement:")]
		void AccessibilityAddChildElement (NSAccessibilityElement childElement);

		[Static, Export ("accessibilityElementWithRole:frame:label:parent:")]
		NSObject CreateElement (NSString role, CGRect frame, NSString label, NSObject parent);

		[Export ("accessibilityFrameInParentSpace")]
		CGRect AccessibilityFrameInParentSpace { get; set; }
	}

	[NoMacCatalyst]
	[Static]
	partial interface NSAccessibilityAttributes {
		[Field ("NSAccessibilitySharedFocusElementsAttribute")]
		NSString SharedFocusElementsAttribute { get; }

		[Field ("NSAccessibilityAlternateUIVisibleAttribute")]
		NSString AlternateUIVisibleAttribute { get; }

		[Field ("NSAccessibilityListItemPrefixTextAttribute")]
		NSString ListItemPrefixTextAttribute { get; }

		[Field ("NSAccessibilityListItemIndexTextAttribute")]
		NSString ListItemIndexTextAttribute { get; }

		[Field ("NSAccessibilityListItemLevelTextAttribute")]
		NSString ListItemLevelTextAttribute { get; }

		[Field ("NSAccessibilityRoleAttribute")]
		NSString RoleAttribute { get; }

		[Field ("NSAccessibilityRoleDescriptionAttribute")]
		NSString RoleDescriptionAttribute { get; }

		[Field ("NSAccessibilitySubroleAttribute")]
		NSString SubroleAttribute { get; }

		[Field ("NSAccessibilityHelpAttribute")]
		NSString HelpAttribute { get; }

		[Field ("NSAccessibilityValueAttribute")]
		NSString ValueAttribute { get; }

		[Field ("NSAccessibilityMinValueAttribute")]
		NSString MinValueAttribute { get; }

		[Field ("NSAccessibilityMaxValueAttribute")]
		NSString MaxValueAttribute { get; }

		[Field ("NSAccessibilityEnabledAttribute")]
		NSString EnabledAttribute { get; }

		[Field ("NSAccessibilityFocusedAttribute")]
		NSString FocusedAttribute { get; }

		[Field ("NSAccessibilityParentAttribute")]
		NSString ParentAttribute { get; }

		[Field ("NSAccessibilityChildrenAttribute")]
		NSString ChildrenAttribute { get; }

		[Field ("NSAccessibilityWindowAttribute")]
		NSString WindowAttribute { get; }

#if !NET
		[Obsolete ("Use 'TopLevelUIElementAttribute' instead.")]
		[Field ("NSAccessibilityTopLevelUIElementAttribute")]
		NSString ToplevelUIElementAttribute { get; }
#endif

		[Field ("NSAccessibilityTopLevelUIElementAttribute")]
		NSString TopLevelUIElementAttribute { get; }

		[Field ("NSAccessibilitySelectedChildrenAttribute")]
		NSString SelectedChildrenAttribute { get; }

		[Field ("NSAccessibilityVisibleChildrenAttribute")]
		NSString VisibleChildrenAttribute { get; }

		[Field ("NSAccessibilityPositionAttribute")]
		NSString PositionAttribute { get; }

		[Field ("NSAccessibilitySizeAttribute")]
		NSString SizeAttribute { get; }

		[Field ("NSAccessibilityContentsAttribute")]
		NSString ContentsAttribute { get; }

		[Field ("NSAccessibilityTitleAttribute")]
		NSString TitleAttribute { get; }

		[Field ("NSAccessibilityDescriptionAttribute")]
		NSString DescriptionAttribute { get; }

		[Field ("NSAccessibilityShownMenuAttribute")]
		NSString ShownMenuAttribute { get; }

		[Field ("NSAccessibilityValueDescriptionAttribute")]
		NSString ValueDescriptionAttribute { get; }

		[Field ("NSAccessibilityPreviousContentsAttribute")]
		NSString PreviousContentsAttribute { get; }

		[Field ("NSAccessibilityNextContentsAttribute")]
		NSString NextContentsAttribute { get; }

		[Field ("NSAccessibilityHeaderAttribute")]
		NSString HeaderAttribute { get; }

		[Field ("NSAccessibilityEditedAttribute")]
		NSString EditedAttribute { get; }

		[Field ("NSAccessibilityTabsAttribute")]
		NSString TabsAttribute { get; }

		[Field ("NSAccessibilityHorizontalScrollBarAttribute")]
		NSString HorizontalScrollBarAttribute { get; }

		[Field ("NSAccessibilityVerticalScrollBarAttribute")]
		NSString VerticalScrollBarAttribute { get; }

		[Field ("NSAccessibilityOverflowButtonAttribute")]
		NSString OverflowButtonAttribute { get; }

		[Field ("NSAccessibilityIncrementButtonAttribute")]
		NSString IncrementButtonAttribute { get; }

		[Field ("NSAccessibilityDecrementButtonAttribute")]
		NSString DecrementButtonAttribute { get; }

		[Field ("NSAccessibilityFilenameAttribute")]
		NSString FilenameAttribute { get; }

		[Field ("NSAccessibilityExpandedAttribute")]
		NSString ExpandedAttribute { get; }

		[Field ("NSAccessibilitySelectedAttribute")]
		NSString SelectedAttribute { get; }

		[Field ("NSAccessibilitySplittersAttribute")]
		NSString SplittersAttribute { get; }

		[Field ("NSAccessibilityDocumentAttribute")]
		NSString DocumentAttribute { get; }

		[Field ("NSAccessibilityActivationPointAttribute")]
		NSString ActivationPointAttribute { get; }

		[Field ("NSAccessibilityURLAttribute")]
		NSString URLAttribute { get; }

		[Field ("NSAccessibilityIndexAttribute")]
		NSString IndexAttribute { get; }

		[Field ("NSAccessibilityRowCountAttribute")]
		NSString RowCountAttribute { get; }

		[Field ("NSAccessibilityColumnCountAttribute")]
		NSString ColumnCountAttribute { get; }

		[Field ("NSAccessibilityOrderedByRowAttribute")]
		NSString OrderedByRowAttribute { get; }

		[Field ("NSAccessibilityWarningValueAttribute")]
		NSString WarningValueAttribute { get; }

		[Field ("NSAccessibilityCriticalValueAttribute")]
		NSString CriticalValueAttribute { get; }

		[Field ("NSAccessibilityPlaceholderValueAttribute")]
		NSString PlaceholderValueAttribute { get; }

		[Field ("NSAccessibilityContainsProtectedContentAttribute")]
		NSString ContainsProtectedContentAttribute { get; }

		[Field ("NSAccessibilityTitleUIElementAttribute")]
		NSString TitleUIAttribute { get; }

		[Field ("NSAccessibilityServesAsTitleForUIElementsAttribute")]
		NSString ServesAsTitleForUIElementsAttribute { get; }

		[Field ("NSAccessibilityLinkedUIElementsAttribute")]
		NSString LinkedUIElementsAttribute { get; }

		[Field ("NSAccessibilitySelectedTextAttribute")]
		NSString SelectedTextAttribute { get; }

		[Field ("NSAccessibilitySelectedTextRangeAttribute")]
		NSString SelectedTextRangeAttribute { get; }

		[Field ("NSAccessibilityNumberOfCharactersAttribute")]
		NSString NumberOfCharactersAttribute { get; }

		[Field ("NSAccessibilityVisibleCharacterRangeAttribute")]
		NSString VisibleCharacterRangeAttribute { get; }

		[Field ("NSAccessibilitySharedTextUIElementsAttribute")]
		NSString SharedTextUIElementsAttribute { get; }

		[Field ("NSAccessibilitySharedCharacterRangeAttribute")]
		NSString SharedCharacterRangeAttribute { get; }

		[Field ("NSAccessibilityInsertionPointLineNumberAttribute")]
		NSString InsertionPointLineNumberAttribute { get; }

		[Field ("NSAccessibilitySelectedTextRangesAttribute")]
		NSString SelectedTextRangesAttribute { get; }

		[Field ("NSAccessibilityLineForIndexParameterizedAttribute")]
		NSString LineForIndexParameterizedAttribute { get; }

		[Field ("NSAccessibilityRangeForLineParameterizedAttribute")]
		NSString RangeForLineParameterizedAttribute { get; }

		[Field ("NSAccessibilityStringForRangeParameterizedAttribute")]
		NSString StringForRangeParameterizeAttribute { get; }

		[Field ("NSAccessibilityRangeForPositionParameterizedAttribute")]
		NSString RangeForPositionParameterizedAttribute { get; }

		[Field ("NSAccessibilityRangeForIndexParameterizedAttribute")]
		NSString RangeForIndexParameterizedAttribute { get; }

		[Field ("NSAccessibilityBoundsForRangeParameterizedAttribute")]
		NSString BoundsForRangeParameterizedAttribute { get; }

		[Field ("NSAccessibilityRTFForRangeParameterizedAttribute")]
		NSString RTFForRangeParameterizedAttribute { get; }

		[Field ("NSAccessibilityStyleRangeForIndexParameterizedAttribute")]
		NSString StyleRangeForIndexParameterizedAttribute { get; }

		[Field ("NSAccessibilityAttributedStringForRangeParameterizedAttribute")]
		NSString AttributedStringForRangeParameterizedAttribute { get; }

		[Field ("NSAccessibilityFontTextAttribute")]
		NSString FontTextAttribute { get; }

		[Field ("NSAccessibilityForegroundColorTextAttribute")]
		NSString ForegroundColorTextAttribute { get; }

		[Field ("NSAccessibilityBackgroundColorTextAttribute")]
		NSString BackgroundColorTextAttribute { get; }

		[Field ("NSAccessibilityUnderlineColorTextAttribute")]
		NSString UnderlineColorTextAttribute { get; }

		[Field ("NSAccessibilityStrikethroughColorTextAttribute")]
		NSString StrikethroughColorTextAttribute { get; }

		[Field ("NSAccessibilityUnderlineTextAttribute")]
		NSString UnderlineTextAttribute { get; }

		[Field ("NSAccessibilitySuperscriptTextAttribute")]
		NSString SuperscriptTextAttribute { get; }

		[Field ("NSAccessibilityStrikethroughTextAttribute")]
		NSString StrikethroughTextAttribute { get; }

		[Field ("NSAccessibilityShadowTextAttribute")]
		NSString ShadowTextAttribute { get; }

		[Field ("NSAccessibilityAttachmentTextAttribute")]
		NSString AttachmentTextAttribute { get; }

		[Field ("NSAccessibilityLinkTextAttribute")]
		NSString LinkTextAttribute { get; }

		[Field ("NSAccessibilityAutocorrectedTextAttribute")]
		NSString AutocorrectedAttribute { get; }

		[Field ("NSAccessibilityMisspelledTextAttribute")]
		NSString MisspelledTextAttribute { get; }

		[Field ("NSAccessibilityMarkedMisspelledTextAttribute")]
		NSString MarkedMisspelledTextAttribute { get; }

		[Field ("NSAccessibilityMainAttribute")]
		NSString MainAttribute { get; }

		[Field ("NSAccessibilityMinimizedAttribute")]
		NSString MinimizedAttribute { get; }

		[Field ("NSAccessibilityCloseButtonAttribute")]
		NSString CloseButtonAttribute { get; }

		[Field ("NSAccessibilityZoomButtonAttribute")]
		NSString ZoomButtonAttribute { get; }

		[Field ("NSAccessibilityMinimizeButtonAttribute")]
		NSString MinimizeButtonAttribute { get; }

		[Field ("NSAccessibilityToolbarButtonAttribute")]
		NSString ToolbarButtonAttribute { get; }

		[Field ("NSAccessibilityProxyAttribute")]
		NSString ProxyAttribute { get; }

		[Field ("NSAccessibilityGrowAreaAttribute")]
		NSString GrowAreaAttribute { get; }

		[Field ("NSAccessibilityModalAttribute")]
		NSString ModalAttribute { get; }

		[Field ("NSAccessibilityDefaultButtonAttribute")]
		NSString DefaultButtonAttribute { get; }

		[Field ("NSAccessibilityCancelButtonAttribute")]
		NSString CancelButtonAttribute { get; }

		[Field ("NSAccessibilityFullScreenButtonAttribute")]
		NSString FullScreenButtonAttribute { get; }

		[Field ("NSAccessibilityMenuBarAttribute")]
		NSString MenuBarAttribute { get; }

		[Field ("NSAccessibilityWindowsAttribute")]
		NSString WindowsAttribute { get; }

		[Field ("NSAccessibilityFrontmostAttribute")]
		NSString FrontmostAttribute { get; }

		[Field ("NSAccessibilityHiddenAttribute")]
		NSString HiddenAttribute { get; }

		[Field ("NSAccessibilityMainWindowAttribute")]
		NSString MainWindowAttribute { get; }

		[Field ("NSAccessibilityFocusedWindowAttribute")]
		NSString FocusedWindowAttribute { get; }

		[Field ("NSAccessibilityFocusedUIElementAttribute")]
		NSString FocusedUIElementAttribute { get; }

		[Field ("NSAccessibilityExtrasMenuBarAttribute")]
		NSString ExtrasMenuBarAttribute { get; }

		[Field ("NSAccessibilityColumnTitlesAttribute")]
		NSString ColumnTitlesAttribute { get; }

		[Field ("NSAccessibilitySearchButtonAttribute")]
		NSString SearchButtonAttribute { get; }

		[Field ("NSAccessibilitySearchMenuAttribute")]
		NSString SearchMenuAttribute { get; }

		[Field ("NSAccessibilityClearButtonAttribute")]
		NSString ClearButtonAttribute { get; }

		[Field ("NSAccessibilityRowsAttribute")]
		NSString RowsAttribute { get; }

		[Field ("NSAccessibilityVisibleRowsAttribute")]
		NSString VisibleRowsAttribute { get; }

		[Field ("NSAccessibilitySelectedRowsAttribute")]
		NSString SelectedRowsAttribute { get; }

		[Field ("NSAccessibilityColumnsAttribute")]
		NSString ColumnsAttribute { get; }

		[Field ("NSAccessibilityVisibleColumnsAttribute")]
		NSString VisibleColumnsAttribute { get; }

		[Field ("NSAccessibilitySelectedColumnsAttribute")]
		NSString SelectedColumnsAttribute { get; }

		[Field ("NSAccessibilitySortDirectionAttribute")]
		NSString SortDirectionAttribute { get; }

		[Field ("NSAccessibilitySelectedCellsAttribute")]
		NSString SelectedCellsAttribute { get; }

		[Field ("NSAccessibilityVisibleCellsAttribute")]
		NSString VisibleCellsAttribute { get; }

		[Field ("NSAccessibilityRowHeaderUIElementsAttribute")]
		NSString RowHeaderUIElementsAttribute { get; }

		[Field ("NSAccessibilityColumnHeaderUIElementsAttribute")]
		NSString ColumnHeaderUIElementsAttribute { get; }

		[Field ("NSAccessibilityCellForColumnAndRowParameterizedAttribute")]
		NSString CellForColumnAndRowParameterizedAttribute { get; }

		[Field ("NSAccessibilityRowIndexRangeAttribute")]
		NSString RowIndexRangeAttribute { get; }

		[Field ("NSAccessibilityColumnIndexRangeAttribute")]
		NSString ColumnIndexRangeAttribute { get; }

		[Field ("NSAccessibilityHorizontalUnitsAttribute")]
		NSString HorizontalUnitsAttribute { get; }

		[Field ("NSAccessibilityVerticalUnitsAttribute")]
		NSString VerticalUnitsAttribute { get; }

		[Field ("NSAccessibilityHorizontalUnitDescriptionAttribute")]
		NSString HorizontalUnitDescriptionAttribute { get; }

		[Field ("NSAccessibilityVerticalUnitDescriptionAttribute")]
		NSString VerticalUnitDescriptionAttribute { get; }

		[Field ("NSAccessibilityLayoutPointForScreenPointParameterizedAttribute")]
		NSString LayoutPointForScreenPointParameterizedAttribute { get; }

		[Field ("NSAccessibilityLayoutSizeForScreenSizeParameterizedAttribute")]
		NSString LayoutSizeForScreenSizeParameterizedAttribute { get; }

		[Field ("NSAccessibilityScreenPointForLayoutPointParameterizedAttribute")]
		NSString ScreenPointForLayoutPointParameterizedAttribute { get; }

		[Field ("NSAccessibilityScreenSizeForLayoutSizeParameterizedAttribute")]
		NSString ScreenSizeForLayoutSizeParameterizedAttribute { get; }

		[Field ("NSAccessibilityHandlesAttribute")]
		NSString HandlesAttribute { get; }

		[Field ("NSAccessibilityDisclosingAttribute")]
		NSString DisclosingAttribute { get; }

		[Field ("NSAccessibilityDisclosedRowsAttribute")]
		NSString DisclosedRowsAttribute { get; }

		[Field ("NSAccessibilityDisclosedByRowAttribute")]
		NSString DisclosedByRowAttribute { get; }

		[Field ("NSAccessibilityDisclosureLevelAttribute")]
		NSString DisclosureLevelAttribute { get; }

		[Field ("NSAccessibilityAllowedValuesAttribute")]
		NSString AllowedValuesAttribute { get; }

		[Field ("NSAccessibilityLabelUIElementsAttribute")]
		NSString LabelUIElementsAttribute { get; }

		[Field ("NSAccessibilityLabelValueAttribute")]
		NSString LabelValueAttribute { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'NSAccessibility' methods instead.")]
		[Field ("NSAccessibilityMatteHoleAttribute")]
		NSString MatteHoleAttribute { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use 'NSAccessibility' methods instead.")]
		[Field ("NSAccessibilityMatteContentUIElementAttribute")]
		NSString MatteContentUIElementAttribute { get; }

		[Field ("NSAccessibilityMarkerUIElementsAttribute")]
		NSString MarkerUIElementsAttribute { get; }

		[Field ("NSAccessibilityMarkerValuesAttribute")]
		NSString MarkerValuesAttribute { get; }

		[Field ("NSAccessibilityMarkerGroupUIElementAttribute")]
		NSString MarkerGroupUIElementAttribute { get; }

		[Field ("NSAccessibilityUnitsAttribute")]
		NSString UnitsAttribute { get; }

		[Field ("NSAccessibilityUnitDescriptionAttribute")]
		NSString UnitDescriptionAttribute { get; }

		[Field ("NSAccessibilityMarkerTypeAttribute")]
		NSString MarkerTypeAttribute { get; }

		[Field ("NSAccessibilityMarkerTypeDescriptionAttribute")]
		NSString MarkerTypeDescriptionAttribute { get; }

		[Field ("NSAccessibilityIdentifierAttribute")]
		NSString IdentifierAttribute { get; }

		[Field ("NSAccessibilityRequiredAttribute")]
		NSString RequiredAttribute { get; }

		[Field ("NSAccessibilityTextAlignmentAttribute")]
		NSString TextAlignmentAttribute { get; }

		[Field ("NSAccessibilityLanguageTextAttribute")]
		NSString LanguageTextAttribute { get; }

		[Field ("NSAccessibilityCustomTextAttribute")]
		NSString CustomTextAttribute { get; }

		[Field ("NSAccessibilityAnnotationTextAttribute")]
		NSString AnnotationTextAttribute { get; }
	}

	[Static]
	[NoMacCatalyst]
	partial interface NSAccessibilityAnnotationAttributeKey {
		[Field ("NSAccessibilityAnnotationLabel")]
		NSString AnnotationLabel { get; }

		[Field ("NSAccessibilityAnnotationElement")]
		NSString AnnotationElement { get; }

		[Field ("NSAccessibilityAnnotationLocation")]
		NSString AnnotationLocation { get; }
	}

	[Static]
	[NoMacCatalyst]
	interface NSAccessibilityFontKeys {
		[Field ("NSAccessibilityFontNameKey")]
		NSString FontNameKey { get; }

		[Field ("NSAccessibilityFontFamilyKey")]
		NSString FontFamilyKey { get; }

		[Field ("NSAccessibilityVisibleNameKey")]
		NSString VisibleNameKey { get; }

		[Field ("NSAccessibilityFontSizeKey")]
		NSString FontSizeKey { get; }
	}

	[Static]
	[NoMacCatalyst]
	interface NSAccessibilityRoles {
		[Field ("NSAccessibilityUnknownRole")]
		NSString UnknownRole { get; }

		[Field ("NSAccessibilityButtonRole")]
		NSString ButtonRole { get; }

		[Field ("NSAccessibilityRadioButtonRole")]
		NSString RadioButtonRole { get; }

		[Field ("NSAccessibilityCheckBoxRole")]
		NSString CheckBoxRole { get; }

		[Field ("NSAccessibilitySliderRole")]
		NSString SliderRole { get; }

		[Field ("NSAccessibilityTabGroupRole")]
		NSString TabGroupRole { get; }

		[Field ("NSAccessibilityTextFieldRole")]
		NSString TextFieldRole { get; }

		[Field ("NSAccessibilityStaticTextRole")]
		NSString StaticTextRole { get; }

		[Field ("NSAccessibilityTextAreaRole")]
		NSString TextAreaRole { get; }

		[Field ("NSAccessibilityScrollAreaRole")]
		NSString ScrollAreaRole { get; }

		[Field ("NSAccessibilityPopUpButtonRole")]
		NSString PopUpButtonRole { get; }

		[Field ("NSAccessibilityMenuButtonRole")]
		NSString MenuButtonRole { get; }

		[Field ("NSAccessibilityTableRole")]
		NSString TableRole { get; }

		[Field ("NSAccessibilityApplicationRole")]
		NSString ApplicationRole { get; }

		[Field ("NSAccessibilityGroupRole")]
		NSString GroupRole { get; }

		[Field ("NSAccessibilityRadioGroupRole")]
		NSString RadioGroupRole { get; }

		[Field ("NSAccessibilityListRole")]
		NSString ListRole { get; }

		[Field ("NSAccessibilityScrollBarRole")]
		NSString ScrollBarRole { get; }

		[Field ("NSAccessibilityValueIndicatorRole")]
		NSString ValueIndicatorRole { get; }

		[Field ("NSAccessibilityImageRole")]
		NSString ImageRole { get; }

		[Field ("NSAccessibilityMenuBarRole")]
		NSString MenuRole { get; }

		[Field ("NSAccessibilityMenuItemRole")]
		NSString MenuItemRole { get; }

		[Field ("NSAccessibilityColumnRole")]
		NSString ColumnRole { get; }

		[Field ("NSAccessibilityRowRole")]
		NSString RowRole { get; }

		[Field ("NSAccessibilityToolbarRole")]
		NSString ToolbarRole { get; }

		[Field ("NSAccessibilityBusyIndicatorRole")]
		NSString BusyIndicatorRole { get; }

		[Field ("NSAccessibilityProgressIndicatorRole")]
		NSString ProgressIndicatorRole { get; }

		[Field ("NSAccessibilityWindowRole")]
		NSString WindowRole { get; }

		[Field ("NSAccessibilityDrawerRole")]
		NSString DrawerRole { get; }

		[Field ("NSAccessibilitySystemWideRole")]
		NSString SystemWideRole { get; }

		[Field ("NSAccessibilityOutlineRole")]
		NSString OutlineRole { get; }

		[Field ("NSAccessibilityIncrementorRole")]
		NSString IncrementorRole { get; }

		[Field ("NSAccessibilityBrowserRole")]
		NSString BrowserRole { get; }

		[Field ("NSAccessibilityComboBoxRole")]
		NSString ComboBoxRole { get; }

		[Field ("NSAccessibilitySplitGroupRole")]
		NSString SplitGroupRole { get; }

		[Field ("NSAccessibilitySplitterRole")]
		NSString SplitterRole { get; }

		[Field ("NSAccessibilityColorWellRole")]
		NSString ColorWellRole { get; }

		[Field ("NSAccessibilityGrowAreaRole")]
		NSString GrowAreaRole { get; }

		[Field ("NSAccessibilitySheetRole")]
		NSString SheetRole { get; }

		[Field ("NSAccessibilityHelpTagRole")]
		NSString HelpTagRole { get; }

		[Field ("NSAccessibilityMatteRole")]
		NSString MatteRole { get; }

		[Field ("NSAccessibilityRulerRole")]
		NSString RulerRole { get; }

		[Field ("NSAccessibilityRulerMarkerRole")]
		NSString RulerMarkerRole { get; }

		[Field ("NSAccessibilityLinkRole")]
		NSString LinkRole { get; }

		[Field ("NSAccessibilityDisclosureTriangleRole")]
		NSString DisclosureTriangleRole { get; }

		[Field ("NSAccessibilityGridRole")]
		NSString GridRole { get; }

		[Field ("NSAccessibilityRelevanceIndicatorRole")]
		NSString RelevanceIndicatorRole { get; }

		[Field ("NSAccessibilityLevelIndicatorRole")]
		NSString LevelIndicatorRole { get; }

		[Field ("NSAccessibilityCellRole")]
		NSString CellRole { get; }

		[Field ("NSAccessibilityPopoverRole")]
		NSString PopoverRole { get; }

		[Field ("NSAccessibilityLayoutAreaRole")]
		NSString LayoutAreaRole { get; }

		[Field ("NSAccessibilityLayoutItemRole")]
		NSString LayoutItemRole { get; }

		[Field ("NSAccessibilityHandleRole")]
		NSString HandleRole { get; }

		[Field ("NSAccessibilityMenuBarItemRole")]
		NSString MenuBarItemRole { get; }

		[Field ("NSAccessibilityPageRole")]
		NSString PageRole { get; }
	}

	[Static]
	[NoMacCatalyst]
	interface NSAccessibilitySubroles {
		[Field ("NSAccessibilityUnknownSubrole")]
		NSString UnknownSubrole { get; }

		[Field ("NSAccessibilityCloseButtonSubrole")]
		NSString CloseButtonSubrole { get; }

		[Field ("NSAccessibilityZoomButtonSubrole")]
		NSString ZoomButtonSubrole { get; }

		[Field ("NSAccessibilityMinimizeButtonSubrole")]
		NSString MinimizeButtonSubrole { get; }

		[Field ("NSAccessibilityToolbarButtonSubrole")]
		NSString ToolbarButtonSubrole { get; }

		[Field ("NSAccessibilityTableRowSubrole")]
		NSString TableRowSubrole { get; }

		[Field ("NSAccessibilityOutlineRowSubrole")]
		NSString OutlineRowSubrole { get; }

		[Field ("NSAccessibilitySecureTextFieldSubrole")]
		NSString SecureTextFieldSubrole { get; }

		[Field ("NSAccessibilityStandardWindowSubrole")]
		NSString StandardWindowSubrole { get; }

		[Field ("NSAccessibilityDialogSubrole")]
		NSString DialogSubrole { get; }

		[Field ("NSAccessibilitySystemDialogSubrole")]
		NSString SystemDialogSubrole { get; }

		[Field ("NSAccessibilityFloatingWindowSubrole")]
		NSString FloatingWindowSubrole { get; }

		[Field ("NSAccessibilitySystemFloatingWindowSubrole")]
		NSString SystemFloatingWindowSubrole { get; }

		[Field ("NSAccessibilityIncrementArrowSubrole")]
		NSString IncrementArrowSubrole { get; }

		[Field ("NSAccessibilityDecrementArrowSubrole")]
		NSString DecrementArrowSubrole { get; }

		[Field ("NSAccessibilityIncrementPageSubrole")]
		NSString IncrementPageSubrole { get; }

		[Field ("NSAccessibilityDecrementPageSubrole")]
		NSString DecrementPageSubrole { get; }

		[Field ("NSAccessibilitySearchFieldSubrole")]
		NSString SearchFieldSubrole { get; }

		[Field ("NSAccessibilityTextAttachmentSubrole")]
		NSString TextAttachmentSubrole { get; }

		[Field ("NSAccessibilityTextLinkSubrole")]
		NSString TextLinkSubrole { get; }

		[Field ("NSAccessibilityTimelineSubrole")]
		NSString TimelineSubrole { get; }

		[Field ("NSAccessibilitySortButtonSubrole")]
		NSString SortButtonSubrole { get; }

		[Field ("NSAccessibilityRatingIndicatorSubrole")]
		NSString RatingIndicatorSubrole { get; }

		[Field ("NSAccessibilityContentListSubrole")]
		NSString ContentListSubrole { get; }

		[Field ("NSAccessibilityDefinitionListSubrole")]
		NSString DefinitionListSubrole { get; }

		[Field ("NSAccessibilityFullScreenButtonSubrole")]
		NSString FullScreenButtonSubrole { get; }

		[Field ("NSAccessibilityToggleSubrole")]
		NSString ToggleSubrole { get; }

		[Field ("NSAccessibilitySwitchSubrole")]
		NSString SwitchSubrole { get; }

		[Field ("NSAccessibilityDescriptionListSubrole")]
		NSString DescriptionListSubrole { get; }

		[Field ("NSAccessibilityTabButtonSubrole")]
		NSString TabButtonSubrole { get; }

		[Field ("NSAccessibilityCollectionListSubrole")]
		NSString CollectionListSubrole { get; }

		[Field ("NSAccessibilitySectionListSubrole")]
		NSString SectionListSubrole { get; }
	}

#if !NET
	[Static]
	[NoMacCatalyst]
	interface NSAccessibilityNotifications {
		[Obsolete ("Use the 'Notifications.MainWindowChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityMainWindowChangedNotification")]
		NSString MainWindowChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.FocusedWindowChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityFocusedWindowChangedNotification")]
		NSString FocusedWindowChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.UIElementFocusedChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityFocusedUIElementChangedNotification")]
		NSString UIElementFocusedChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.ApplicationActivatedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityApplicationActivatedNotification")]
		NSString ApplicationActivatedNotification { get; }

		[Obsolete ("Use the 'Notifications.ApplicationDeactivatedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityApplicationDeactivatedNotification")]
		NSString ApplicationDeactivatedNotification { get; }

		[Obsolete ("Use the 'Notifications.ApplicationHiddenNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityApplicationHiddenNotification")]
		NSString ApplicationHiddenNotification { get; }

		[Obsolete ("Use the 'Notifications.ApplicationShownNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityApplicationShownNotification")]
		NSString ApplicationShownNotification { get; }

		[Obsolete ("Use the 'Notifications.WindowCreatedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityWindowCreatedNotification")]
		NSString WindowCreatedNotification { get; }

		[Obsolete ("Use the 'Notifications.WindowMovedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityWindowMovedNotification")]
		NSString WindowMovedNotification { get; }

		[Obsolete ("Use the 'Notifications.WindowResizedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityWindowResizedNotification")]
		NSString WindowResizedNotification { get; }

		[Obsolete ("Use the 'Notifications.WindowMiniaturizedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityWindowMiniaturizedNotification")]
		NSString WindowMiniaturizedNotification { get; }

		[Obsolete ("Use the 'Notifications.WindowDeminiaturizedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityWindowDeminiaturizedNotification")]
		NSString WindowDeminiaturizedNotification { get; }

		[Obsolete ("Use the 'Notifications.DrawerCreatedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityDrawerCreatedNotification")]
		NSString DrawerCreatedNotification { get; }

		[Obsolete ("Use the 'Notifications.SheetCreatedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilitySheetCreatedNotification")]
		NSString SheetCreatedNotification { get; }

		[Obsolete ("Use the 'Notifications.UIElementDestroyedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityUIElementDestroyedNotification")]
		NSString UIElementDestroyedNotification { get; }

		[Obsolete ("Use the 'Notifications.ValueChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityValueChangedNotification")]
		NSString ValueChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.TitleChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityTitleChangedNotification")]
		NSString TitleChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.ResizedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityResizedNotification")]
		NSString ResizedNotification { get; }

		[Obsolete ("Use the 'Notifications.MovedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityMovedNotification")]
		NSString MovedNotification { get; }

		[Obsolete ("Use the 'Notifications.CreatedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityCreatedNotification")]
		NSString CreatedNotification { get; }

		[Obsolete ("Use the 'Notifications.LayoutChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityLayoutChangedNotification")]
		NSString LayoutChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.HelpTagCreatedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityHelpTagCreatedNotification")]
		NSString HelpTagCreatedNotification { get; }

		[Obsolete ("Use the 'Notifications.SelectedTextChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilitySelectedTextChangedNotification")]
		NSString SelectedTextChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.RowCountChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityRowCountChangedNotification")]
		NSString RowCountChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.SelectedChildrenChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilitySelectedChildrenChangedNotification")]
		NSString SelectedChildrenChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.SelectedRowsChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilitySelectedRowsChangedNotification")]
		NSString SelectedRowsChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.SelectedColumnsChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilitySelectedColumnsChangedNotification")]
		NSString SelectedColumnsChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.RowExpandedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityRowExpandedNotification")]
		NSString RowExpandedNotification { get; }

		[Obsolete ("Use the 'Notifications.RowCollapsedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityRowCollapsedNotification")]
		NSString RowCollapsedNotification { get; }

		[Obsolete ("Use the 'Notifications.SelectedCellsChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilitySelectedCellsChangedNotification")]
		NSString SelectedCellsChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.UnitsChangedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityUnitsChangedNotification")]
		NSString UnitsChangedNotification { get; }

		[Obsolete ("Use the 'Notifications.SelectedChildrenMovedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilitySelectedChildrenMovedNotification")]
		NSString SelectedChildrenMovedNotification { get; }

		[Obsolete ("Use the 'Notifications.AnnouncementRequestedNotification' helper method instead on the accessibility item in question.")]
		[Field ("NSAccessibilityAnnouncementRequestedNotification")]
		NSString AnnouncementRequestedNotification { get; }
	}

	[Static]
	[NoMacCatalyst]
	interface NSWorkspaceAccessibilityNotifications {
		[Field ("NSWorkspaceAccessibilityDisplayOptionsDidChangeNotification")]
		NSString DisplayOptionsDidChangeNotification { get; }
	}
#endif

	[Static]
	[NoMacCatalyst]
	interface NSAccessibilityNotificationUserInfoKeys {
		[Field ("NSAccessibilityUIElementsKey")]
		NSString UIElementsKey { get; }

		[Field ("NSAccessibilityPriorityKey")]
		NSString PriorityKey { get; }

		[Field ("NSAccessibilityAnnouncementKey")]
		NSString AnnouncementKey { get; }
	}

	[Static]
	[NoMacCatalyst]
	interface NSAccessibilityActions {
		[Field ("NSAccessibilityPressAction")]
		NSString PressAction { get; }

		[Field ("NSAccessibilityIncrementAction")]
		NSString IncrementAction { get; }

		[Field ("NSAccessibilityDecrementAction")]
		NSString DecrementAction { get; }

		[Field ("NSAccessibilityConfirmAction")]
		NSString ConfirmAction { get; }

		[Field ("NSAccessibilityPickAction")]
		NSString PickAction { get; }

		[Field ("NSAccessibilityCancelAction")]
		NSString CancelAction { get; }

		[Field ("NSAccessibilityRaiseAction")]
		NSString RaiseAction { get; }

		[Field ("NSAccessibilityShowMenuAction")]
		NSString ShowMenu { get; }

		[Field ("NSAccessibilityDeleteAction")]
		NSString DeleteAction { get; }

		[Field ("NSAccessibilityShowAlternateUIAction")]
		NSString ShowAlternateUIAction { get; }

		[Field ("NSAccessibilityShowDefaultUIAction")]
		NSString ShowDefaultUIAction { get; }
	}

	[NoMacCatalyst]
	[NoiOS]
	[NoTV]
	[Protocol (Name = "NSAccessibilityElement")] // exists both as a type and a protocol in ObjC, Swift uses NSAccessibilityElementProtocol
	interface NSAccessibilityElementProtocol {
		[Abstract]
		[Export ("accessibilityFrame")]
		CGRect AccessibilityFrame { get; }

		[Abstract]
		[NullAllowed, Export ("accessibilityParent")]
		NSObject AccessibilityParent { get; }

		[Export ("isAccessibilityFocused")]
		bool AccessibilityFocused { get; }

		[Export ("accessibilityIdentifier")]
		string AccessibilityIdentifier { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityGroup : NSAccessibilityElementProtocol {
	}

	[NoMacCatalyst]
	[NoiOS]
	[NoTV]
	[Protocol]
	interface NSAccessibilityButton : NSAccessibilityElementProtocol {
		[Abstract]
		[NullAllowed, Export ("accessibilityLabel")]
		string AccessibilityLabel { get; }

		[Abstract]
		[Export ("accessibilityPerformPress")]
		bool AccessibilityPerformPress ();
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilitySwitch : NSAccessibilityButton {
		[Abstract]
		[NullAllowed, Export ("accessibilityValue")]
		string AccessibilityValue { get; }

		[Export ("accessibilityPerformIncrement")]
		bool AccessibilityPerformIncrement ();

		[Export ("accessibilityPerformDecrement")]
		bool AccessibilityPerformDecrement ();
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityRadioButton : NSAccessibilityButton {
		[Abstract]
		[NullAllowed, Export ("accessibilityValue")]
		NSNumber AccessibilityValue { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityCheckBox : NSAccessibilityButton {
		[Abstract]
		[NullAllowed, Export ("accessibilityValue")]
		NSNumber AccessibilityValue { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityStaticText : NSAccessibilityElementProtocol {
		[Abstract]
		[NullAllowed, Export ("accessibilityValue")]
		string AccessibilityValue { get; }

		[Export ("accessibilityAttributedStringForRange:")]
		[return: NullAllowed]
		NSAttributedString GetAccessibilityAttributedString (NSRange range);

		[Export ("accessibilityVisibleCharacterRange")]
		NSRange AccessibilityVisibleCharacterRange { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityNavigableStaticText : NSAccessibilityStaticText {
		[Abstract]
		[Export ("accessibilityStringForRange:")]
		[return: NullAllowed]
		string GetAccessibilityString (NSRange range);

		[Abstract]
		[Export ("accessibilityLineForIndex:")]
		nint GetAccessibilityLine (nint index);

		[Abstract]
		[Export ("accessibilityRangeForLine:")]
		NSRange GetAccessibilityRangeForLine (nint lineNumber);

		[Abstract]
		[Export ("accessibilityFrameForRange:")]
		CGRect GetAccessibilityFrame (NSRange range);
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityProgressIndicator : NSAccessibilityGroup {
		[Abstract]
		[NullAllowed, Export ("accessibilityValue")]
		NSNumber AccessibilityValue { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityStepper : NSAccessibilityElementProtocol {
		[Abstract]
		[NullAllowed, Export ("accessibilityLabel")]
		string AccessibilityLabel { get; }

		[Abstract]
		[Export ("accessibilityPerformIncrement")]
		bool AccessibilityPerformIncrement ();

		[Abstract]
		[Export ("accessibilityPerformDecrement")]
		bool AccessibilityPerformDecrement ();

		[NullAllowed, Export ("accessibilityValue")]
		NSObject AccessibilityValue { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilitySlider : NSAccessibilityElementProtocol {
		[Abstract]
		[NullAllowed, Export ("accessibilityLabel")]
		string AccessibilityLabel { get; }

		[Abstract]
		[NullAllowed, Export ("accessibilityValue")]
		NSObject AccessibilityValue { get; }

		[Abstract]
		[Export ("accessibilityPerformIncrement")]
		bool AccessibilityPerformIncrement ();

		[Abstract]
		[Export ("accessibilityPerformDecrement")]
		bool AccessibilityPerformDecrement ();
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityImage : NSAccessibilityElementProtocol {
		[Abstract]
		[NullAllowed, Export ("accessibilityLabel")]
		string AccessibilityLabel { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityContainsTransientUI : NSAccessibilityElementProtocol {
		[Abstract]
		[Export ("accessibilityPerformShowAlternateUI")]
		bool AccessibilityPerformShowAlternateUI ();

		[Abstract]
		[Export ("accessibilityPerformShowDefaultUI")]
		bool AccessibilityPerformShowDefaultUI ();

		[Abstract]
		[Export ("isAccessibilityAlternateUIVisible")]
		bool IsAccessibilityAlternateUIVisible { get; }
	}

	interface INSAccessibilityRow { }

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityTable : NSAccessibilityGroup {
		[Abstract]
		[NullAllowed, Export ("accessibilityLabel")]
		string AccessibilityLabel { get; }

		[Abstract]
		[NullAllowed, Export ("accessibilityRows")]
		INSAccessibilityRow [] AccessibilityRows { get; }

		[NullAllowed, Export ("accessibilitySelectedRows")]
		INSAccessibilityRow [] AccessibilitySelectedRows { get; set; }

		[Export ("accessibilityVisibleRows")]
		INSAccessibilityRow [] AccessibilityVisibleRows { get; }

		[Export ("accessibilityColumns")]
		NSObject [] AccessibilityColumns { get; }

		[Export ("accessibilityVisibleColumns")]
		NSObject [] AccessibilityVisibleColumns { get; }

		[Export ("accessibilitySelectedColumns")]
		NSObject [] AccessibilitySelectedColumns { get; }

		[Export ("accessibilityHeaderGroup")]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'AccessibilityHeader' instead.")]
		string AccessibilityHeaderGroup { get; }

		[Export ("accessibilitySelectedCells")]
		NSObject [] AccessibilitySelectedCells { get; }

		[Export ("accessibilityVisibleCells")]
		NSObject [] AccessibilityVisibleCells { get; }

		[Export ("accessibilityRowHeaderUIElements")]
		NSObject [] AccessibilityRowHeaderUIElements { get; }

		[Export ("accessibilityColumnHeaderUIElements")]
		NSObject [] AccessibilityColumnHeaderUIElements { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityOutline : NSAccessibilityTable {
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityList : NSAccessibilityTable {
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityRow : NSAccessibilityGroup {
		[Abstract]
		[Export ("accessibilityIndex")]
		nint AccessibilityIndex { get; }

		[Export ("accessibilityDisclosureLevel")]
		nint AccessibilityDisclosureLevel { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityLayoutArea : NSAccessibilityGroup {
		[Abstract]
		[Export ("accessibilityLabel")]
		string AccessibilityLabel { get; }

		[Abstract]
		[NullAllowed, Export ("accessibilityChildren")]
		NSObject [] AccessibilityChildren { get; }

		[Abstract]
		[NullAllowed, Export ("accessibilitySelectedChildren")]
		NSObject [] AccessibilitySelectedChildren { get; }

		[Abstract]
		[Export ("accessibilityFocusedUIElement")]
		NSObject AccessibilityFocusedUIElement { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityLayoutItem : NSAccessibilityGroup {
		[Export ("setAccessibilityFrame:")]
		void SetAccessibilityFrame (CGRect frame);
	}

	[NoMacCatalyst]
	interface NSObjectAccessibilityExtensions {
		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityAttributeNames")]
		NSArray AccessibilityAttributeNames { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityAttributeValue:")]
		NSObject GetAccessibilityValue (NSString attribute);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityIsAttributeSettable:")]
		bool IsAccessibilityAttributeSettable (NSString attribute);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilitySetValue:forAttribute:")]
		void SetAccessibilityValue (NSString attribute, NSObject value);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityParameterizedAttributeNames")]
		NSArray AccessibilityParameterizedAttributeNames { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityAttributeValue:forParameter:")]
		NSObject GetAccessibilityValue (NSString attribute, NSObject parameter);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityActionNames")]
		NSArray AccessibilityActionNames { get; }

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityActionDescription:")]
		NSString GetAccessibilityActionDescription (NSString action);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityPerformAction:")]
		void AccessibilityPerformAction (NSString action);

		[Deprecated (PlatformName.MacOSX, 10, 10, message: "Use the NSAccessibility protocol methods instead.")]
		[Export ("accessibilityIsIgnored")]
		bool AccessibilityIsIgnored { get; }

		[Export ("accessibilityHitTest:")]
		NSObject GetAccessibilityHitTest (CGPoint point);

		[Export ("accessibilityFocusedUIElement")]
		NSObject GetAccessibilityFocusedUIElement ();

		[Export ("accessibilityIndexOfChild:")]
		nuint GetAccessibilityIndexOfChild (NSObject child);

		[Export ("accessibilityArrayAttributeCount:")]
		nuint GetAccessibilityArrayAttributeCount (NSString attribute);

		[Export ("accessibilityArrayAttributeValues:index:maxCount:")]
		NSObject [] GetAccessibilityArrayAttributeValues (NSString attribute, nuint index, nuint maxCount);

		[DebuggerBrowsable (DebuggerBrowsableState.Never)]
		[Export ("accessibilityNotifiesWhenDestroyed")]
		bool AccessibilityNotifiesWhenDestroyed { get; }
	}

	[NoMacCatalyst]
	interface NSWorkspaceAccessibilityExtensions {
		[Export ("accessibilityDisplayShouldIncreaseContrast")]
		bool AccessibilityDisplayShouldIncreaseContrast { get; }

		[Export ("accessibilityDisplayShouldDifferentiateWithoutColor")]
		bool AccessibilityDisplayShouldDifferentiateWithoutColor { get; }

		[Export ("accessibilityDisplayShouldReduceTransparency")]
		bool AccessibilityDisplayShouldReduceTransparency { get; }

		[Export ("accessibilityDisplayShouldInvertColors")]
		bool AccessibilityDisplayShouldInvertColors { get; }

		[Export ("accessibilityDisplayShouldReduceMotion")]
		bool AccessibilityDisplayShouldReduceMotion { get; }

		[Export ("voiceOverEnabled")]
		bool VoiceOverEnabled { [Bind ("isVoiceOverEnabled")] get; }

		[Export ("switchControlEnabled")]
		bool SwitchControlEnabled { [Bind ("isSwitchControlEnabled")] get; }
	}

	interface INSFilePromiseProviderDelegate { }

	[DesignatedDefaultCtor]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSFilePromiseProvider : NSPasteboardWriting {
		[Export ("fileType")]
		string FileType { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		INSFilePromiseProviderDelegate Delegate { get; set; }

		[NullAllowed, Export ("userInfo", ArgumentSemantic.Strong)]
		NSObject UserInfo { get; set; }

		[Export ("initWithFileType:delegate:")]
		NativeHandle Constructor (string fileType, INSFilePromiseProviderDelegate @delegate);
	}

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSFilePromiseProviderDelegate {
		[Abstract]
		[Export ("filePromiseProvider:fileNameForType:")]
		string GetFileNameForDestination (NSFilePromiseProvider filePromiseProvider, string fileType);

#if NET
		[Abstract]
#endif
		[Export ("filePromiseProvider:writePromiseToURL:completionHandler:")]
		void WritePromiseToUrl (NSFilePromiseProvider filePromiseProvider, NSUrl url, [NullAllowed] Action<NSError> completionHandler);

		[Export ("operationQueueForFilePromiseProvider:")]
		NSOperationQueue GetOperationQueue (NSFilePromiseProvider filePromiseProvider);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSFilePromiseReceiver : NSPasteboardReading {
		[Static]
		[Export ("readableDraggedTypes", ArgumentSemantic.Copy)]
		string [] ReadableDraggedTypes { get; }

		[Export ("fileTypes", ArgumentSemantic.Copy)]
		string [] FileTypes { get; }

		[Export ("fileNames", ArgumentSemantic.Copy)]
		string [] FileNames { get; }

		[Export ("receivePromisedFilesAtDestination:options:operationQueue:reader:")]
		void ReceivePromisedFiles (NSUrl destinationDir, NSDictionary options, NSOperationQueue operationQueue, Action<NSUrl, NSError> reader);
	}

	interface INSValidatedUserInterfaceItem { }

	[NoMacCatalyst]
	[Protocol]
	interface NSValidatedUserInterfaceItem {
		[Abstract]
		[NullAllowed, Export ("action")]
		Selector Action { get; }

		[Abstract]
		[Export ("tag")]
		nint Tag { get; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSCloudSharingValidation {
		[Abstract]
		[Export ("cloudShareForUserInterfaceItem:")]
		[return: NullAllowed]
		CKShare GetCloudShare (INSValidatedUserInterfaceItem item);
	}

	[NoMacCatalyst]
	[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'Metal' Framework instead.")]
	[BaseType (typeof (CAOpenGLLayer))]
	interface NSOpenGLLayer {
		[NullAllowed, Export ("view", ArgumentSemantic.Assign)]
		NSView View { get; set; }

		[NullAllowed, Export ("openGLPixelFormat", ArgumentSemantic.Strong)]
		NSOpenGLPixelFormat OpenGLPixelFormat { get; set; }

		[NullAllowed, Export ("openGLContext", ArgumentSemantic.Strong)]
		NSOpenGLContext OpenGLContext { get; set; }

		[Export ("openGLPixelFormatForDisplayMask:")]
		NSOpenGLPixelFormat GetOpenGLPixelFormat (uint mask);

		[Export ("openGLContextForPixelFormat:")]
		NSOpenGLContext GetOpenGLContext (NSOpenGLPixelFormat pixelFormat);

		[Export ("canDrawInOpenGLContext:pixelFormat:forLayerTime:displayTime:")]
		bool CanDraw (NSOpenGLContext context, NSOpenGLPixelFormat pixelFormat, double t, ref CVTimeStamp ts);

		[Export ("drawInOpenGLContext:pixelFormat:forLayerTime:displayTime:")]
		void Draw (NSOpenGLContext context, NSOpenGLPixelFormat pixelFormat, double t, ref CVTimeStamp ts);
	}

	[NoMacCatalyst]
	[Protocol (IsInformal = true)]
	interface NSToolTipOwner {
		[Abstract]
		[Export ("view:stringForToolTip:point:userData:")]
		string GetStringForToolTip (NSView view, nint tag, CGPoint point, IntPtr data);
	}

	interface INSToolTipOwner { }

	interface INSUserInterfaceValidations { }

	[Protocol]
	[NoMacCatalyst]
	[NoiOS]
	interface NSUserInterfaceValidations {
		[Abstract]
		[Export ("validateUserInterfaceItem:")]
		bool ValidateUserInterfaceItem (INSValidatedUserInterfaceItem item);
	}

	[NoMacCatalyst]
	[Protocol (IsInformal = true)]
	interface NSMenuValidation {
		[Abstract]
		[Export ("validateMenuItem:")]
		bool ValidateMenuItem (NSMenuItem menuItem);
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSMenuItemValidation {
		[Abstract]
		[Export ("validateMenuItem:")]
		bool ValidateMenuItem (NSMenuItem menuItem);
	}

	public interface INSCandidateListTouchBarItemDelegate { }

	delegate NSAttributedString AttributedStringForCandidateHandler (NSObject candidate, nint index);

	/*
	[NoMacCatalyst]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSCandidateListTouchBarItem {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[NullAllowed, Export ("client", ArgumentSemantic.Weak)]
		INSTextInputClient Client { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		INSCandidateListTouchBarItemDelegate Delegate { get; set; }

		[Export ("collapsed")]
		bool Collapsed { [Bind ("isCollapsed")] get; set; }

		[Export ("allowsCollapsing")]
		bool AllowsCollapsing { get; set; }

		[Export ("candidateListVisible")]
		bool CandidateListVisible { [Bind ("isCandidateListVisible")] get; }

		[Export ("updateWithInsertionPointVisibility:")]
		void UpdateWithInsertionPointVisibility (bool isVisible);

		[Export ("allowsTextInputContextCandidates")]
		bool AllowsTextInputContextCandidates { get; set; }

		[NullAllowed, Export ("attributedStringForCandidate", ArgumentSemantic.Copy)]
		AttributedStringForCandidateHandler AttributedStringForCandidate { get; set; }

		[Export ("candidates", ArgumentSemantic.Copy)]
		NSObject [] Candidates { get; }

		[Export ("setCandidates:forSelectedRange:inString:")]
		void SetCandidates (NSObject [] candidates, NSRange selectedRange, [NullAllowed] string originalString);

		[NullAllowed]
		[Export ("customizationLabel")]
		string CustomizationLabel { get; set; }
	}
	*/

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSCandidateListTouchBarItemDelegate {
		[Export ("candidateListTouchBarItem:beginSelectingCandidateAtIndex:")]
		void BeginSelectingCandidate (NSCandidateListTouchBarItem anItem, nint index);

		[Export ("candidateListTouchBarItem:changeSelectionFromCandidateAtIndex:toIndex:")]
		void ChangeSelectionFromCandidate (NSCandidateListTouchBarItem anItem, nint previousIndex, nint index);

		[Export ("candidateListTouchBarItem:endSelectingCandidateAtIndex:")]
		void EndSelectingCandidate (NSCandidateListTouchBarItem anItem, nint index);

		[Export ("candidateListTouchBarItem:changedCandidateListVisibility:")]
		void ChangedCandidateListVisibility (NSCandidateListTouchBarItem anItem, bool isVisible);
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSView))]
	interface NSView_NSCandidateListTouchBarItem {
		[Export ("candidateListTouchBarItem")]
		NSCandidateListTouchBarItem GetCandidateListTouchBarItem ();
	}

	

	[NoMacCatalyst]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSCustomTouchBarItem {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[Export ("view", ArgumentSemantic.Strong)]
		NSView View { get; set; }

		[Export ("viewController", ArgumentSemantic.Strong)]
		NSViewController ViewController { get; set; }

		[NullAllowed]
		[Export ("customizationLabel")]
		string CustomizationLabel { get; set; }
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSGestureRecognizer))]
	interface NSGestureRecognizer_NSTouchBar {
		[Export ("allowedTouchTypes", ArgumentSemantic.Assign)]
		NSTouchTypeMask GetAllowedTouchTypes ();

		[Export ("setAllowedTouchTypes:", ArgumentSemantic.Assign)]
		void SetAllowedTouchTypes (NSTouchTypeMask types);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSGroupTouchBarItem {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[Static]
		[Export ("groupItemWithIdentifier:items:")]
		NSGroupTouchBarItem CreateGroupItem (string identifier, NSTouchBarItem [] items);

		[Export ("groupTouchBar", ArgumentSemantic.Strong)]
		NSTouchBar GroupTouchBar { get; set; }

		[NullAllowed]
		[Export ("customizationLabel")]
		string CustomizationLabel { get; set; }

		[NoMacCatalyst]
		[Static]
		[Export ("groupItemWithIdentifier:items:allowedCompressionOptions:")]
		NSGroupTouchBarItem CreateGroupItem (string identifier, NSTouchBarItem [] items, NSUserInterfaceCompressionOptions allowedCompressionOptions);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("alertStyleGroupItemWithIdentifier:")]
		NSGroupTouchBarItem CreateAlertStyleGroupItem (string identifier);

		[NoMacCatalyst]
		[Export ("groupUserInterfaceLayoutDirection", ArgumentSemantic.Assign)]
		NSUserInterfaceLayoutDirection GroupUserInterfaceLayoutDirection { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("prefersEqualWidths")]
		bool PrefersEqualWidths { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("preferredItemWidth")]
		nfloat PreferredItemWidth { get; set; }

		[NoMacCatalyst]
		[Export ("effectiveCompressionOptions")]
		NSUserInterfaceCompressionOptions EffectiveCompressionOptions { get; }

		[NoMacCatalyst]
		[Export ("prioritizedCompressionOptions", ArgumentSemantic.Copy)]
		NSUserInterfaceCompressionOptions [] PrioritizedCompressionOptions { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSPopoverTouchBarItem {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[Export ("popoverTouchBar", ArgumentSemantic.Strong)]
		NSTouchBar PopoverTouchBar { get; set; }

		[NullAllowed]
		[Export ("customizationLabel")]
		string CustomizationLabel { get; set; }

		[NoMacCatalyst]
		[Export ("collapsedRepresentation", ArgumentSemantic.Strong)]
		NSView CollapsedRepresentation { get; set; }

		[NullAllowed, Export ("collapsedRepresentationImage", ArgumentSemantic.Strong)]
		NSImage CollapsedRepresentationImage { get; set; }

		[Export ("collapsedRepresentationLabel", ArgumentSemantic.Strong)]
		string CollapsedRepresentationLabel { get; set; }

		[NullAllowed, Export ("pressAndHoldTouchBar", ArgumentSemantic.Strong)]
		NSTouchBar PressAndHoldTouchBar { get; set; }

		[Export ("showsCloseButton")]
		bool ShowsCloseButton { get; set; }

		[Export ("showPopover:")]
		void ShowPopover ([NullAllowed] NSObject sender);

		[Export ("dismissPopover:")]
		void DismissPopover ([NullAllowed] NSObject sender);

		[NoMacCatalyst]
		[Export ("makeStandardActivatePopoverGestureRecognizer")]
		NSGestureRecognizer MakeStandardActivatePopoverGestureRecognizer ();
	}

	interface INSScrubberDataSource { }
	interface INSScrubberDelegate { }

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSScrubberDataSource {
		[Abstract]
		[Export ("numberOfItemsForScrubber:")]
		nint GetNumberOfItems (NSScrubber scrubber);

		[Abstract]
		[Export ("scrubber:viewForItemAtIndex:")]
		NSScrubberItemView GetViewForItem (NSScrubber scrubber, nint index);
	}

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSScrubberDelegate {
		[Export ("scrubber:didSelectItemAtIndex:")]
		void DidSelectItem (NSScrubber scrubber, nint selectedIndex);

		[Export ("scrubber:didHighlightItemAtIndex:")]
		void DidHighlightItem (NSScrubber scrubber, nint highlightedIndex);

		[Export ("scrubber:didChangeVisibleRange:")]
		void DidChangeVisible (NSScrubber scrubber, NSRange visibleRange);

		[Export ("didBeginInteractingWithScrubber:")]
		void DidBeginInteracting (NSScrubber scrubber);

		[Export ("didFinishInteractingWithScrubber:")]
		void DidFinishInteracting (NSScrubber scrubber);

		[Export ("didCancelInteractingWithScrubber:")]
		void DidCancelInteracting (NSScrubber scrubber);
	}

	[DesignatedDefaultCtor]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSScrubberSelectionStyle : NSCoding {
		[Static]
		[Export ("outlineOverlayStyle", ArgumentSemantic.Strong)]
		NSScrubberSelectionStyle OutlineOverlayStyle { get; }

		[Static]
		[Export ("roundedBackgroundStyle", ArgumentSemantic.Strong)]
		NSScrubberSelectionStyle RoundedBackgroundStyle { get; }

		[Export ("makeSelectionView")]
		NSScrubberSelectionView MakeSelectionView ();
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSScrubber {
		[NullAllowed, Export ("dataSource", ArgumentSemantic.Weak)]
		INSScrubberDataSource DataSource { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		INSScrubberDelegate Delegate { get; set; }

		[Export ("scrubberLayout", ArgumentSemantic.Strong)]
		NSScrubberLayout ScrubberLayout { get; set; }

		[Export ("numberOfItems")]
		nint NumberOfItems { get; }

		[Export ("highlightedIndex")]
		nint HighlightedIndex { get; }

		[Export ("selectedIndex")]
		nint SelectedIndex { get; set; }

		[Export ("mode", ArgumentSemantic.Assign)]
		NSScrubberMode Mode { get; set; }

		[Export ("itemAlignment", ArgumentSemantic.Assign)]
		NSScrubberAlignment ItemAlignment { get; set; }

		[Export ("continuous")]
		bool Continuous { [Bind ("isContinuous")] get; set; }

		[Export ("floatsSelectionViews")]
		bool FloatsSelectionViews { get; set; }

		[NullAllowed, Export ("selectionBackgroundStyle", ArgumentSemantic.Strong)]
		NSScrubberSelectionStyle SelectionBackgroundStyle { get; set; }

		[NullAllowed, Export ("selectionOverlayStyle", ArgumentSemantic.Strong)]
		NSScrubberSelectionStyle SelectionOverlayStyle { get; set; }

		[Export ("showsArrowButtons")]
		bool ShowsArrowButtons { get; set; }

		[Export ("showsAdditionalContentIndicators")]
		bool ShowsAdditionalContentIndicators { get; set; }

		[NullAllowed, Export ("backgroundColor", ArgumentSemantic.Copy)]
		NSColor BackgroundColor { get; set; }

		[NullAllowed, Export ("backgroundView", ArgumentSemantic.Strong)]
		NSView BackgroundView { get; set; }

		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("performSequentialBatchUpdates:")]
		void PerformSequentialBatchUpdates (Action updateHandler);

		[Export ("insertItemsAtIndexes:")]
		void InsertItems (NSIndexSet indexes);

		[Export ("removeItemsAtIndexes:")]
		void RemoveItems (NSIndexSet indexes);

		[Export ("reloadItemsAtIndexes:")]
		void ReloadItems (NSIndexSet indexes);

		[Export ("moveItemAtIndex:toIndex:")]
		void MoveItem (nint oldIndex, nint newIndex);

		[Export ("scrollItemAtIndex:toAlignment:")]
		void ScrollItem (nint index, NSScrubberAlignment alignment);

		[Export ("itemViewForItemAtIndex:")]
		NSScrubberItemView GetItemViewForItem (nint index);

		[Export ("registerClass:forItemIdentifier:")]
		void RegisterClass ([NullAllowed] Class itemViewClass, string itemIdentifier);

		[Export ("registerNib:forItemIdentifier:")]
		void RegisterNib ([NullAllowed] NSNib nib, string itemIdentifier);

		[Export ("makeItemWithIdentifier:owner:")]
		NSScrubberItemView MakeItem (string itemIdentifier, [NullAllowed] NSObject owner);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSView))]
	interface NSScrubberArrangedView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("selected")]
		bool Selected { [Bind ("isSelected")] get; set; }

		[Export ("highlighted")]
		bool Highlighted { [Bind ("isHighlighted")] get; set; }

		[RequiresSuper]
		[Export ("applyLayoutAttributes:")]
		void ApplyLayoutAttributes (NSScrubberLayoutAttributes layoutAttributes);
	}

	// These are empty but types used in other bindings
	[NoMacCatalyst]
	[BaseType (typeof (NSScrubberArrangedView))]
	interface NSScrubberItemView {
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSScrubberArrangedView))]
	interface NSScrubberSelectionView {
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSScrubberItemView))]
	interface NSScrubberTextItemView {
		[Export ("textField", ArgumentSemantic.Strong)]
		NSTextField TextField { get; }

		[Export ("title")]
		string Title { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSScrubberItemView))]
	interface NSScrubberImageItemView {
		[Export ("imageView", ArgumentSemantic.Strong)]
		NSImageView ImageView { get; }

		[Export ("image", ArgumentSemantic.Copy)]
		NSImage Image { get; set; }

		[Export ("imageAlignment", ArgumentSemantic.Assign)]
		NSImageAlignment ImageAlignment { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSScrubberLayoutAttributes : NSCopying {
		[Export ("itemIndex")]
		nint ItemIndex { get; set; }

		[Export ("frame", ArgumentSemantic.Assign)]
		CGRect Frame { get; set; }

		[Export ("alpha")]
		nfloat Alpha { get; set; }

		[Static]
		[Export ("layoutAttributesForItemAtIndex:")]
		NSScrubberLayoutAttributes CreateLayoutAttributes (nint index);
	}

	[DesignatedDefaultCtor]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSScrubberLayout : NSCoding {
		[Static]
		[Export ("layoutAttributesClass")]
		Class LayoutAttributesClass { get; }

		[NullAllowed, Export ("scrubber", ArgumentSemantic.Weak)]
		NSScrubber Scrubber { get; }

		[Export ("visibleRect")]
		CGRect VisibleRect { get; }

		[RequiresSuper]
		[Export ("invalidateLayout")]
		void InvalidateLayout ();

		[Export ("prepareLayout")]
		void PrepareLayout ();

		[Export ("scrubberContentSize")]
		CGSize ScrubberContentSize { get; }

		[Export ("layoutAttributesForItemAtIndex:")]
		NSScrubberLayoutAttributes LayoutAttributesForItem (nint index);

		[Export ("layoutAttributesForItemsInRect:")]
		NSSet<NSScrubberLayoutAttributes> LayoutAttributesForItems (CGRect rect);

		[Export ("shouldInvalidateLayoutForSelectionChange")]
		bool ShouldInvalidateLayoutForSelectionChange ();

		[Export ("shouldInvalidateLayoutForHighlightChange")]
		bool ShouldInvalidateLayoutForHighlightChange ();

		[Export ("shouldInvalidateLayoutForChangeFromVisibleRect:toVisibleRect:")]
		bool ShouldInvalidateLayoutForChangeFromVisibleRect (CGRect fromVisibleRect, CGRect toVisibleRect);

		[Export ("automaticallyMirrorsInRightToLeftLayout")]
		bool AutomaticallyMirrorsInRightToLeftLayout { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Protocol, Model]
	interface NSScrubberFlowLayoutDelegate : NSScrubberDelegate {
		[Export ("scrubber:layout:sizeForItemAtIndex:")]
		CGSize Layout (NSScrubber scrubber, NSScrubberFlowLayout layout, nint itemIndex);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSScrubberLayout))]
	interface NSScrubberFlowLayout {
		[Export ("itemSpacing")]
		nfloat ItemSpacing { get; set; }

		[Export ("itemSize", ArgumentSemantic.Assign)]
		CGSize ItemSize { get; set; }

		[Export ("invalidateLayoutForItemsAtIndexes:")]
		void InvalidateLayoutForItems (NSIndexSet invalidItemIndexes);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSScrubberLayout))]
	interface NSScrubberProportionalLayout {
		[Export ("numberOfVisibleItems")]
		nint NumberOfVisibleItems { get; set; }

		[Export ("initWithNumberOfVisibleItems:")]
		[DesignatedInitializer]
		NativeHandle Constructor (nint numberOfVisibleItems);
	}

	public interface INSSharingServicePickerTouchBarItemDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Protocol, Model]
	interface NSSharingServicePickerTouchBarItemDelegate : NSSharingServicePickerDelegate {
		[Abstract]
		[Export ("itemsForSharingServicePickerTouchBarItem:")]
		INSPasteboardWriting [] ItemsForSharingServicePickerTouchBarItem (NSSharingServicePickerTouchBarItem pickerTouchBarItem);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSSharingServicePickerTouchBarItem {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[NoMacCatalyst]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		INSSharingServicePickerTouchBarItemDelegate Delegate { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("buttonTitle")]
		string ButtonTitle { get; set; }

		[NullAllowed, Export ("buttonImage", ArgumentSemantic.Retain)]
		NSImage ButtonImage { get; set; }

		// defined in the NSSharingServicePickerTouchBarItem (UIActivityItemsConfiguration) category in UIKit
		[NoMac]
		[Export ("activityItemsConfiguration", ArgumentSemantic.Strong), NullAllowed]
		IUIActivityItemsConfigurationReading ActivityItemsConfiguration { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSSliderAccessory : NSCoding, NSAccessibility, NSAccessibilityElementProtocol {
		[Static]
		[Export ("accessoryWithImage:")]
		NSSliderAccessory CreateAccessory (NSImage image);

		[Export ("behavior", ArgumentSemantic.Copy)]
		NSSliderAccessoryBehavior Behavior { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[MacCatalyst (13, 1)]
		[Field ("NSSliderAccessoryWidthDefault")]
		double DefaultWidth { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSSliderAccessoryWidthWide")]
		double WidthWide { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	interface NSSliderAccessoryBehavior : NSCoding, NSCopying {
		[Static]
		[Export ("automaticBehavior", ArgumentSemantic.Copy)]
		NSSliderAccessoryBehavior AutomaticBehavior { get; }

		[Static]
		[Export ("valueStepBehavior", ArgumentSemantic.Copy)]
		NSSliderAccessoryBehavior ValueStepBehavior { get; }

		[Static]
		[Export ("valueResetBehavior", ArgumentSemantic.Copy)]
		NSSliderAccessoryBehavior ValueResetBehavior { get; }

		[Static]
		[Export ("behaviorWithTarget:action:")]
		NSSliderAccessoryBehavior CreateBehavior ([NullAllowed] NSObject target, Selector action);

		[Static]
		[Export ("behaviorWithHandler:")]
		NSSliderAccessoryBehavior CreateBehavior (Action<NSSliderAccessory> handler);

		[Export ("handleAction:")]
		void HandleAction (NSSliderAccessory sender);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSAccessibilityCustomAction {
		[Export ("initWithName:handler:")]
		NativeHandle Constructor (string name, [NullAllowed] Func<bool> handler);

		[Export ("initWithName:target:selector:")]
		NativeHandle Constructor (string name, NSObject target, Selector selector);

		[Export ("name")]
		string Name { get; set; }

		[NullAllowed, Export ("handler", ArgumentSemantic.Copy)]
		Func<bool> Handler { get; set; }

		[NullAllowed, Export ("target", ArgumentSemantic.Weak)]
		NSObject Target { get; set; }

		[Advice (@"It must conform to one of the following signatures: 'bool ActionMethod ()' or 'bool ActionMethod (NSAccessibilityCustomAction)' and be decorated with a corresponding [Export].")]
		[NullAllowed, Export ("selector", ArgumentSemantic.Assign)]
		Selector Selector { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSAccessibilityCustomRotor {
		[Export ("initWithLabel:itemSearchDelegate:")]
		NativeHandle Constructor (string label, INSAccessibilityCustomRotorItemSearchDelegate itemSearchDelegate);

		[Export ("initWithRotorType:itemSearchDelegate:")]
		NativeHandle Constructor (NSAccessibilityCustomRotorType rotorType, INSAccessibilityCustomRotorItemSearchDelegate itemSearchDelegate);

		[Export ("type", ArgumentSemantic.Assign)]
		NSAccessibilityCustomRotorType Type { get; set; }

		[Export ("label")]
		string Label { get; set; }

		[NullAllowed, Export ("itemSearchDelegate", ArgumentSemantic.Weak)]
		INSAccessibilityCustomRotorItemSearchDelegate ItemSearchDelegate { get; set; }

		[NullAllowed, Export ("itemLoadingDelegate", ArgumentSemantic.Weak)]
		INSAccessibilityElementLoading ItemLoadingDelegate { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSAccessibilityCustomRotorSearchParameters {
		[NullAllowed, Export ("currentItem", ArgumentSemantic.Strong)]
		NSAccessibilityCustomRotorItemResult CurrentItem { get; set; }

		[Export ("searchDirection", ArgumentSemantic.Assign)]
		NSAccessibilityCustomRotorSearchDirection SearchDirection { get; set; }

		[Export ("filterString")]
		string FilterString { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSAccessibilityCustomRotorItemResult {
		[Export ("initWithTargetElement:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSAccessibilityElement targetElement);

		[Export ("initWithItemLoadingToken:customLabel:")]
		[DesignatedInitializer]
		NativeHandle Constructor (INSSecureCoding itemLoadingToken, string customLabel);

		[NullAllowed, Export ("targetElement", ArgumentSemantic.Weak)]
		NSAccessibilityElement TargetElement { get; }

		[NullAllowed, Export ("itemLoadingToken", ArgumentSemantic.Strong)]
		INSSecureCoding ItemLoadingToken { get; }

		[Export ("targetRange", ArgumentSemantic.Assign)]
		NSRange TargetRange { get; set; }

		[NullAllowed, Export ("customLabel")]
		string CustomLabel { get; set; }
	}

	interface INSAccessibilityCustomRotorItemSearchDelegate { }

	[NoMacCatalyst]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface NSAccessibilityCustomRotorItemSearchDelegate {
		[Abstract]
		[Export ("rotor:resultForSearchParameters:")]
		[return: NullAllowed]
		NSAccessibilityCustomRotorItemResult GetResult (NSAccessibilityCustomRotor rotor, NSAccessibilityCustomRotorSearchParameters searchParameters);
	}

	interface INSAccessibilityElementLoading { }

	[NoMacCatalyst]
	[Protocol]
	interface NSAccessibilityElementLoading {
		[Abstract]
		[Export ("accessibilityElementWithToken:")]
		[return: NullAllowed]
		NSAccessibilityElement GetAccessibilityElement (INSSecureCoding token);

		[Export ("accessibilityRangeInTargetElementWithToken:")]
		NSRange GetAccessibilityRangeInTargetElement (INSSecureCoding token);
	}

	interface INSCollectionViewPrefetching { }

	[NoMacCatalyst]
	[Protocol]
	interface NSCollectionViewPrefetching {
		[Abstract]
		[Export ("collectionView:prefetchItemsAtIndexPaths:")]
		void PrefetchItems (NSCollectionView collectionView, NSIndexPath [] indexPaths);

		[Export ("collectionView:cancelPrefetchingForItemsAtIndexPaths:")]
		void CancelPrefetching (NSCollectionView collectionView, NSIndexPath [] indexPaths);
	}

	delegate bool DownloadFontAssetsRequestCompletionHandler (NSError error);

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
#if NET
	interface NSFontAssetRequest : NSProgressReporting
#else
	interface NSFontAssetRequest : INSProgressReporting
#endif
	{
		[Export ("initWithFontDescriptors:options:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSFontDescriptor [] fontDescriptors, NSFontAssetRequestOptions options);

		[Export ("downloadedFontDescriptors", ArgumentSemantic.Copy)]
		NSFontDescriptor [] DownloadedFontDescriptors { get; }

#pragma warning disable 0108 // warning CS0108: 'NSFontAssetRequest.Progress' hides inherited member 'NSProgressReporting.Progress'. Use the new keyword if hiding was intended.
		[Export ("progress", ArgumentSemantic.Strong)]
		NSProgress Progress { get; }
#pragma warning restore

		[Export ("downloadFontAssetsWithCompletionHandler:")]
		void DownloadFontAssets (DownloadFontAssetsRequestCompletionHandler completionHandler);
	}

	[NoMacCatalyst]
	[Category]
	[BaseType (typeof (NSObject))]
	interface NSObject_NSFontPanelValidationAdditions {
		[Export ("validModesForFontPanel:")]
		NSFontPanelModeMask GetValidModes (NSFontPanel fontPanel);
	}

	[DesignatedDefaultCtor]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSUserInterfaceCompressionOptions : NSCopying, NSCoding {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[Export ("initWithCompressionOptions:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSSet<NSUserInterfaceCompressionOptions> options);

		[Export ("containsOptions:")]
		bool Contains (NSUserInterfaceCompressionOptions options);

		[Export ("intersectsOptions:")]
		bool Intersects (NSUserInterfaceCompressionOptions options);

		[Export ("empty")]
		bool Empty { [Bind ("isEmpty")] get; }

		[Export ("optionsByAddingOptions:")]
		NSUserInterfaceCompressionOptions GetOptionsByAdding (NSUserInterfaceCompressionOptions options);

		[Export ("optionsByRemovingOptions:")]
		NSUserInterfaceCompressionOptions GetOptionsByRemoving (NSUserInterfaceCompressionOptions options);

		[Static]
		[Export ("hideImagesOption", ArgumentSemantic.Copy)]
		NSUserInterfaceCompressionOptions HideImagesOption { get; }

		[Static]
		[Export ("hideTextOption", ArgumentSemantic.Copy)]
		NSUserInterfaceCompressionOptions HideTextOption { get; }

		[Static]
		[Export ("reduceMetricsOption", ArgumentSemantic.Copy)]
		NSUserInterfaceCompressionOptions ReduceMetricsOption { get; }

		[Static]
		[Export ("breakEqualWidthsOption", ArgumentSemantic.Copy)]
		NSUserInterfaceCompressionOptions BreakEqualWidthsOption { get; }

		[Static]
		[Export ("standardOptions", ArgumentSemantic.Copy)]
		NSUserInterfaceCompressionOptions StandardOptions { get; }
	}

	interface INSUserInterfaceCompression { }

	[NoMacCatalyst]
	[Protocol]
	interface NSUserInterfaceCompression {
		[Abstract]
		[Export ("compressWithPrioritizedCompressionOptions:")]
		void Compress (NSUserInterfaceCompressionOptions [] prioritizedOptions);

		[Abstract]
		[Export ("minimumSizeWithPrioritizedCompressionOptions:")]
		CGSize GetMinimumSize (NSUserInterfaceCompressionOptions [] prioritizedOptions);

		[Abstract]
		[Export ("activeCompressionOptions", ArgumentSemantic.Copy)]
		NSUserInterfaceCompressionOptions ActiveCompressionOptions { get; }
	}





	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSButtonTouchBarItem {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		NativeHandle Constructor (string identifier);

		[Static]
		[Export ("buttonTouchBarItemWithIdentifier:title:target:action:")]
		NSButtonTouchBarItem Create ([BindAs (typeof (NSTouchBarItemIdentifier))] NSString identifier, string title, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Export ("buttonTouchBarItemWithIdentifier:image:target:action:")]
		NSButtonTouchBarItem Create ([BindAs (typeof (NSTouchBarItemIdentifier))] NSString identifier, NSImage image, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Export ("buttonTouchBarItemWithIdentifier:title:image:target:action:")]
		NSButtonTouchBarItem Create ([BindAs (typeof (NSTouchBarItemIdentifier))] NSString identifier, string title, NSImage image, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Export ("title")]
		string Title { get; set; }

		[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
		NSImage Image { get; set; }

		[NullAllowed, Export ("bezelColor", ArgumentSemantic.Copy)]
		Color BezelColor { get; set; }

		[NullAllowed, Export ("target", ArgumentSemantic.Weak)]
		NSObject Target { get; set; }

		[NullAllowed, Export ("action", ArgumentSemantic.Assign)]
		Selector Action { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[NullAllowed]
		[Export ("customizationLabel")]
		string CustomizationLabel { get; set; }
	}

	[NoMacCatalyst]
	[Native]
	public enum NSCollectionLayoutSectionOrthogonalScrollingBehavior : long {
		None,
		Continuous,
		ContinuousGroupLeadingBoundary,
		Paging,
		GroupPaging,
		GroupPagingCentered,
	}

	[MacCatalyst (13, 1)]
	[Native]
	public enum NSPickerTouchBarItemControlRepresentation : long {
		Automatic = 0,
		Expanded = 1,
		Collapsed = 2,
	}

	[MacCatalyst (13, 1)]
	[Native]
	public enum NSPickerTouchBarItemSelectionMode : long {
		SelectOne = 0,
		SelectAny = 1,
		Momentary = 2,
	}

	[NoMacCatalyst]
	[Native]
	public enum NSTextInputTraitType : long {
		Default,
		No,
		Yes,
	}

	[MacCatalyst (13, 1)]
	[Native]
	public enum NSToolbarItemGroupControlRepresentation : long {
		Automatic,
		Expanded,
		Collapsed,
	}

	[MacCatalyst (13, 1)]
	[Native]
	public enum NSToolbarItemGroupSelectionMode : long {
		SelectOne = 0,
		SelectAny = 1,
		Momentary = 2,
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSPickerTouchBarItem {
		[Static]
		[Export ("pickerTouchBarItemWithIdentifier:labels:selectionMode:target:action:")]
		NSPickerTouchBarItem Create (NSTouchBarItemIdentifier identifier, string [] labels, NSPickerTouchBarItemSelectionMode selectionMode, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Export ("pickerTouchBarItemWithIdentifier:images:selectionMode:target:action:")]
		NSPickerTouchBarItem Create (NSTouchBarItemIdentifier identifier, NSImage [] images, NSPickerTouchBarItemSelectionMode selectionMode, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Export ("controlRepresentation", ArgumentSemantic.Assign)]
		NSPickerTouchBarItemControlRepresentation ControlRepresentation { get; set; }

		[Export ("collapsedRepresentationLabel")]
		string CollapsedRepresentationLabel { get; set; }

		[NullAllowed, Export ("collapsedRepresentationImage", ArgumentSemantic.Strong)]
		NSImage CollapsedRepresentationImage { get; set; }

		[Export ("selectedIndex")]
		nint SelectedIndex { get; set; }

		[NullAllowed, Export ("selectionColor", ArgumentSemantic.Copy)]
		Color SelectionColor { get; set; }

		[Export ("selectionMode", ArgumentSemantic.Assign)]
		NSPickerTouchBarItemSelectionMode SelectionMode { get; set; }

		[Export ("numberOfOptions")]
		nint NumberOfOptions { get; set; }

		[Export ("setImage:atIndex:")]
		void SetImage ([NullAllowed] NSImage image, nint index);

		[Export ("imageAtIndex:")]
		[return: NullAllowed]
		NSImage GetImage (nint index);

		[Export ("setLabel:atIndex:")]
		void SetLabel (string label, nint index);

		[Export ("labelAtIndex:")]
		[return: NullAllowed]
		string GetLabel (nint index);

		[NullAllowed, Export ("target", ArgumentSemantic.Weak)]
		NSObject Target { get; set; }

		[NullAllowed, Export ("action", ArgumentSemantic.Assign)]
		Selector Action { get; set; }

		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		[Export ("setEnabled:atIndex:")]
		void SetEnabled (bool enabled, nint index);

		[Export ("isEnabledAtIndex:")]
		bool GetEnabled (nint index);

		[NullAllowed]
		[Export ("customizationLabel", ArgumentSemantic.Copy)]
		string CustomizationLabel { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSCollectionViewCompositionalLayoutConfiguration : NSCopying {
		[Export ("scrollDirection", ArgumentSemantic.Assign)]
		NSCollectionViewScrollDirection ScrollDirection { get; set; }

		[Export ("interSectionSpacing")]
		nfloat InterSectionSpacing { get; set; }

		[Export ("boundarySupplementaryItems", ArgumentSemantic.Copy)]
		NSCollectionLayoutBoundarySupplementaryItem [] BoundarySupplementaryItems { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	interface NSColorSampler {
		[Export ("showSamplerWithSelectionHandler:")]
		void ShowSampler (Action<NSColor> selectionHandler);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSControl))]
	[DesignatedDefaultCtor]
	interface NSSwitch : NSAccessibilitySwitch {
		[Export ("state")]
		nint State { get; set; }
	}



	[NoMacCatalyst]
	delegate NSCollectionLayoutSection NSCollectionViewCompositionalLayoutSectionProvider (nint section, INSCollectionLayoutEnvironment layout);

	[NoMacCatalyst]
	[BaseType (typeof (NSCollectionViewLayout))]
	[DisableDefaultCtor]
	interface NSCollectionViewCompositionalLayout {
		[Export ("initWithSection:")]
		NativeHandle Constructor (NSCollectionLayoutSection section);

		[Export ("initWithSection:configuration:")]
		NativeHandle Constructor (NSCollectionLayoutSection section, NSCollectionViewCompositionalLayoutConfiguration configuration);

		[Export ("initWithSectionProvider:")]
		NativeHandle Constructor (NSCollectionViewCompositionalLayoutSectionProvider sectionProvider);

		[Export ("initWithSectionProvider:configuration:")]
		NativeHandle Constructor (NSCollectionViewCompositionalLayoutSectionProvider sectionProvider, NSCollectionViewCompositionalLayoutConfiguration configuration);

		[Export ("configuration", ArgumentSemantic.Copy)]
		NSCollectionViewCompositionalLayoutConfiguration Configuration { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSTouchBarItem))]
	[DisableDefaultCtor]
	interface NSStepperTouchBarItem {
		[Static]
		[Export ("stepperTouchBarItemWithIdentifier:formatter:")]
		NSStepperTouchBarItem Create (NSTouchBarItemIdentifier identifier, NSFormatter formatter);

		[Static]
		[Export ("stepperTouchBarItemWithIdentifier:drawingHandler:")]
		NSStepperTouchBarItem Create (NSTouchBarItemIdentifier identifier, Action<CGRect, double> drawingHandler);

		[Export ("maxValue")]
		double MaxValue { get; set; }

		[Export ("minValue")]
		double MinValue { get; set; }

		[Export ("increment")]
		double Increment { get; set; }

		[Export ("value")]
		double Value { get; set; }

		[NullAllowed, Export ("target", ArgumentSemantic.Weak)]
		NSObject Target { get; set; }

		[NullAllowed, Export ("action", ArgumentSemantic.Assign)]
		Selector Action { get; set; }

		[NullAllowed]
		[Export ("customizationLabel")]
		string CustomizationLabel { get; set; }
	}

	[Protocol]
	[NoMacCatalyst]
	interface NSTextInputTraits {
		[Export ("autocorrectionType", ArgumentSemantic.Assign)]
		NSTextInputTraitType AutocorrectionType { get; set; }

		[Export ("spellCheckingType", ArgumentSemantic.Assign)]
		NSTextInputTraitType SpellCheckingType { get; set; }

		[Export ("grammarCheckingType", ArgumentSemantic.Assign)]
		NSTextInputTraitType GrammarCheckingType { get; set; }

		[Export ("smartQuotesType", ArgumentSemantic.Assign)]
		NSTextInputTraitType SmartQuotesType { get; set; }

		[Export ("smartDashesType", ArgumentSemantic.Assign)]
		NSTextInputTraitType SmartDashesType { get; set; }

		[Export ("smartInsertDeleteType", ArgumentSemantic.Assign)]
		NSTextInputTraitType SmartInsertDeleteType { get; set; }

		[Export ("textReplacementType", ArgumentSemantic.Assign)]
		NSTextInputTraitType TextReplacementType { get; set; }

		[Export ("dataDetectionType", ArgumentSemantic.Assign)]
		NSTextInputTraitType DataDetectionType { get; set; }

		[Export ("linkDetectionType", ArgumentSemantic.Assign)]
		NSTextInputTraitType LinkDetectionType { get; set; }

		[Export ("textCompletionType", ArgumentSemantic.Assign)]
		NSTextInputTraitType TextCompletionType { get; set; }

		[Mac (14, 0)]
		[Export ("inlinePredictionType", ArgumentSemantic.Assign)]
		NSTextInputTraitType InlinePredictionType { get; set; }

		[Mac (15, 0)]
		[Export ("mathExpressionCompletionType", ArgumentSemantic.Assign)]
		NSTextInputTraitType MathExpressionCompletionType { get; set; }

		[Mac (15, 0)]
		[Export ("writingToolsBehavior", ArgumentSemantic.Assign)]
		NSWritingToolsBehavior WritingToolsBehavior { get; set; }

		[Mac (15, 0)]
		[Export ("allowedWritingToolsResultOptions")]
		NSWritingToolsResultOptions AllowedWritingToolsResultOptions { get; set; }

	}

	interface INSTextCheckingClient { }

	[Protocol]
	[NoMacCatalyst]
	interface NSTextCheckingClient : NSTextInputTraits, NSTextInputClient {
		[Abstract]
		[Export ("annotatedSubstringForProposedRange:actualRange:")]
		[return: NullAllowed]
		NSAttributedString GetAnnotatedSubstring (NSRange range, [NullAllowed] ref NSRange actualRange);

		[Abstract]
		[Export ("setAnnotations:range:")]
		void SetAnnotations (NSDictionary<NSString, NSString> annotations, NSRange range);

		[Abstract]
		[Export ("addAnnotations:range:")]
		void AddAnnotations (NSDictionary<NSString, NSString> annotations, NSRange range);

		[Abstract]
		[Export ("removeAnnotation:range:")]
		void RemoveAnnotation (string annotationName, NSRange range);

		[Abstract]
		[Export ("replaceCharactersInRange:withAnnotatedString:")]
		void ReplaceCharacters (NSRange range, NSAttributedString annotatedString);

		[Abstract]
		[Export ("selectAndShowRange:")]
		void SelectAndShow (NSRange range);

		[Abstract]
		[Export ("viewForRange:firstRect:actualRange:")]
		[return: NullAllowed]
		NSView GetView (NSRange range, [NullAllowed] ref CGRect firstRect, [NullAllowed] ref NSRange actualRange);

		[Abstract]
		[NullAllowed, Export ("candidateListTouchBarItem")]
		NSCandidateListTouchBarItem CandidateListTouchBarItem { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSWorkspaceOpenConfiguration : NSCopying {
		[Static]
		[Export ("configuration")]
		NSWorkspaceOpenConfiguration Create ();

		[Export ("promptsUserIfNeeded")]
		bool PromptsUserIfNeeded { get; set; }

		[Export ("addsToRecentItems")]
		bool AddsToRecentItems { get; set; }

		[Export ("activates")]
		bool Activates { get; set; }

		[Export ("hides")]
		bool Hides { get; set; }

		[Export ("hidesOthers")]
		bool HidesOthers { get; set; }

		[Export ("forPrinting")]
		bool ForPrinting { [Bind ("isForPrinting")] get; set; }

		[Export ("createsNewApplicationInstance")]
		bool CreatesNewApplicationInstance { get; set; }

		[Export ("allowsRunningApplicationSubstitution")]
		bool AllowsRunningApplicationSubstitution { get; set; }

		[Export ("arguments", ArgumentSemantic.Copy)]
		string [] Arguments { get; set; }

		[Export ("environment", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> Environment { get; set; }

		[NullAllowed, Export ("appleEvent", ArgumentSemantic.Strong)]
		NSAppleEventDescriptor AppleEvent { get; set; }

		[Internal]
		[Export ("architecture")]
		int _LaunchArchitecture { get; set; }

		CFBundle.Architecture LaunchArchitecture {
			[Wrap ("(CFBundle.Architecture) this._LaunchArchitecture")]
			get;
			[Wrap ("this._LaunchArchitecture = (int) value")]
			set;
		}

		[Export ("requiresUniversalLinks")]
		bool RequiresUniversalLinks { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSTextCheckingController {
		[Export ("initWithClient:")]
		[DesignatedInitializer]
		NativeHandle Constructor (INSTextCheckingClient client);

		[Export ("client")]
		INSTextCheckingClient Client { get; }

		[Export ("invalidate")]
		void Invalidate ();

		[Export ("didChangeTextInRange:")]
		void DidChangeText (NSRange range);

		[Export ("insertedTextInRange:")]
		void InsertedText (NSRange range);

		[Export ("didChangeSelectedRange")]
		void DidChangeSelectedRange ();

		[Export ("considerTextCheckingForRange:")]
		void ConsiderTextChecking (NSRange range);

		[Export ("checkTextInRange:types:options:")]
		[EditorBrowsable (EditorBrowsableState.Advanced)]
		void CheckText (NSRange range, NSTextCheckingTypes checkingTypes, NSDictionary options);

		[Wrap ("CheckText (range, checkingTypes, options.GetDictionary ()!)")]
		void CheckText (NSRange range, NSTextCheckingTypes checkingTypes, NSTextCheckingOptions options);

		[Export ("checkTextInSelection:")]
		void CheckTextInSelection ([NullAllowed] NSObject sender);

		[Export ("checkTextInDocument:")]
		void CheckTextInDocument ([NullAllowed] NSObject sender);

		[Export ("orderFrontSubstitutionsPanel:")]
		void OrderFrontSubstitutionsPanel ([NullAllowed] NSObject sender);

		[Export ("checkSpelling:")]
		void CheckSpelling ([NullAllowed] NSObject sender);

		[Export ("showGuessPanel:")]
		void ShowGuessPanel ([NullAllowed] NSObject sender);

		[Export ("changeSpelling:")]
		void ChangeSpelling ([NullAllowed] NSObject sender);

		[Export ("ignoreSpelling:")]
		void IgnoreSpelling ([NullAllowed] NSObject sender);

		[Export ("updateCandidates")]
		void UpdateCandidates ();

		[Export ("validAnnotations")]
		string [] ValidAnnotations { get; }

		[Export ("menuAtIndex:clickedOnSelection:effectiveRange:")]
		[return: NullAllowed]
		NSMenu GetMenu (nuint location, bool clickedOnSelection, ref NSRange effectiveRange);

		[Export ("spellCheckerDocumentTag")]
		nint SpellCheckerDocumentTag { get; set; }
	}

	[NoMacCatalyst]
	delegate NSCollectionViewItem NSCollectionViewDiffableDataSourceItemProvider (NSCollectionView collectionView, NSIndexPath indexPath, NSObject itemIdentifierType);

	[NoMacCatalyst]
	delegate NSView NSCollectionViewDiffableDataSourceSupplementaryViewProvider (NSCollectionView collectionView, string str, NSIndexPath indexPath);

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSCollectionViewDiffableDataSource<SectionIdentifierType, ItemIdentifierType> : NSCollectionViewDataSource
		where SectionIdentifierType : NSObject
		where ItemIdentifierType : NSObject {

		[Export ("initWithCollectionView:itemProvider:")]
		NativeHandle Constructor (NSCollectionView collectionView, NSCollectionViewDiffableDataSourceItemProvider itemProvider);

		[Export ("snapshot")]
		NSDiffableDataSourceSnapshot<SectionIdentifierType, ItemIdentifierType> Snapshot { get; }

		[Export ("applySnapshot:animatingDifferences:")]
		void Apply (NSDiffableDataSourceSnapshot<SectionIdentifierType, ItemIdentifierType> snapshot, bool animatingDifferences);

		[Export ("itemIdentifierForIndexPath:")]
		[return: NullAllowed]
		ItemIdentifierType GetItemIdentifier (NSIndexPath indexPath);

		[Export ("indexPathForItemIdentifier:")]
		[return: NullAllowed]
		NSIndexPath GetIndexPath (ItemIdentifierType identifier);

		[NullAllowed, Export ("supplementaryViewProvider", ArgumentSemantic.Copy)]
		NSCollectionViewDiffableDataSourceSupplementaryViewProvider SupplementaryViewProvider { get; set; }
	}

	[NoMacCatalyst]
	public enum NSFontDescriptorSystemDesign {
		[Field ("NSFontDescriptorSystemDesignDefault")]
		Default,

		[Field ("NSFontDescriptorSystemDesignSerif")]
		Serif,

		[Field ("NSFontDescriptorSystemDesignMonospaced")]
		Monospaced,

		[Field ("NSFontDescriptorSystemDesignRounded")]
		Rounded,
	}

	[NoMacCatalyst]
	public enum NSFontTextStyle {
		[Field ("NSFontTextStyleLargeTitle")]
		LargeTitle,

		[Field ("NSFontTextStyleTitle1")]
		Title1,

		[Field ("NSFontTextStyleTitle2")]
		Title2,

		[Field ("NSFontTextStyleTitle3")]
		Title3,

		[Field ("NSFontTextStyleHeadline")]
		Headline,

		[Field ("NSFontTextStyleSubheadline")]
		Subheadline,

		[Field ("NSFontTextStyleBody")]
		Body,

		[Field ("NSFontTextStyleCallout")]
		Callout,

		[Field ("NSFontTextStyleFootnote")]
		Footnote,

		[Field ("NSFontTextStyleCaption1")]
		Caption1,

		[Field ("NSFontTextStyleCaption2")]
		Caption2,
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSToolbarItem))]
#if XAMCORE_5_0
	[DisableDefaultCtor]
#endif
	interface NSSharingServicePickerToolbarItem {
		[DesignatedInitializer]
		[Export ("initWithItemIdentifier:")]
		NativeHandle Constructor (string itemIdentifier);

		[NoMacCatalyst]
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSSharingServicePickerToolbarItemDelegate Delegate { get; set; }

		[NoMacCatalyst]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// Defined in the NSSharingServicePickerToolbarItem (UIActivityItemsConfiguration) category in UIKIt
		[NoMac]
		[Export ("activityItemsConfiguration", ArgumentSemantic.Strong), NullAllowed]
		IUIActivityItemsConfigurationReading ActivityItemsConfiguration { get; set; }
	}

	public interface INSSharingServicePickerToolbarItemDelegate { }

	[NoMacCatalyst]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSSharingServicePickerDelegate))]
	interface NSSharingServicePickerToolbarItemDelegate {
		[Abstract]
		[Export ("itemsForSharingServicePickerToolbarItem:")]
		NSObject [] GetItems (NSSharingServicePickerToolbarItem pickerToolbarItem);
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSToolbarItem))]
	[DisableDefaultCtor]
	interface NSSearchToolbarItem {
		[DesignatedInitializer]
		[Export ("initWithItemIdentifier:")]
		NativeHandle Constructor (string itemIdentifier);

		[NoMacCatalyst]
		[Export ("searchField", ArgumentSemantic.Strong)]
		NSSearchField SearchField { get; set; }

		[Export ("resignsFirstResponderWithCancel")]
		bool ResignsFirstResponderWithCancel { get; set; }

		[Export ("preferredWidthForSearchField")]
		nfloat PreferredWidthForSearchField { get; set; }

		[Export ("beginSearchInteraction")]
		void BeginSearchInteraction ();

		[Export ("endSearchInteraction")]
		void EndSearchInteraction ();
	}

	[NoMacCatalyst]
	delegate NSView NSTableViewDiffableDataSourceCellProvider (NSTableView tableView, NSTableColumn column, nint row, NSObject itemId);
	[NoMacCatalyst]
	delegate NSTableRowView NSTableViewDiffableDataSourceRowProvider (NSTableView tableView, nint row, NSObject identifier);
	[NoMacCatalyst]
	delegate NSView NSTableViewDiffableDataSourceSectionHeaderViewProvider (NSTableView tableView, nint row, NSObject sectionId);

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSTableViewDiffableDataSource<SectionIdentifierType, ItemIdentifierType> : NSTableViewDataSource
		where SectionIdentifierType : NSObject
		where ItemIdentifierType : NSObject {
		[Export ("initWithTableView:cellProvider:")]
		NativeHandle Constructor (NSTableView tableView, NSTableViewDiffableDataSourceCellProvider cellProvider);

		[Export ("snapshot")]
		NSDiffableDataSourceSnapshot<SectionIdentifierType, ItemIdentifierType> Snapshot ();

		[Export ("applySnapshot:animatingDifferences:")]
		void ApplySnapshot (NSDiffableDataSourceSnapshot<SectionIdentifierType, ItemIdentifierType> snapshot, bool animatingDifferences);

		[Export ("applySnapshot:animatingDifferences:completion:")]
		[Async]
		void ApplySnapshot (NSDiffableDataSourceSnapshot<SectionIdentifierType, ItemIdentifierType> snapshot, bool animatingDifferences, [NullAllowed] Action completion);

		[Export ("itemIdentifierForRow:")]
		[return: NullAllowed]
		ItemIdentifierType GetItemIdentifier (nint row);

		[Export ("rowForItemIdentifier:")]
		nint GetRowForItemIdentifier (ItemIdentifierType itemIdentifier);

		[Export ("sectionIdentifierForRow:")]
		[return: NullAllowed]
		SectionIdentifierType GetSectionIdentifier (nint row);

		[Export ("rowForSectionIdentifier:")]
		nint GetRowForSectionIdentifier (SectionIdentifierType sectionIdentifier);

		[NullAllowed, Export ("rowViewProvider", ArgumentSemantic.Copy)]
		NSTableViewDiffableDataSourceRowProvider RowViewProvider { get; set; }

		[NullAllowed, Export ("sectionHeaderViewProvider", ArgumentSemantic.Copy)]
		NSTableViewDiffableDataSourceSectionHeaderViewProvider SectionHeaderViewProvider { get; set; }

		[Export ("defaultRowAnimation", ArgumentSemantic.Assign)]
		NSTableViewAnimationOptions DefaultRowAnimation { get; set; }
	}

	[NoMacCatalyst]
	[Protocol]
	interface NSTextContent {
		[Abstract]
		[Export ("contentType")]
		NSString GetContentType ();

		[Abstract]
		[Export ("setContentType:")]
		void SetContentType (NSString contentType);
	}

	

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSTintConfiguration : NSCopying, NSSecureCoding {
		[Static]
		[Export ("defaultTintConfiguration", ArgumentSemantic.Strong)]
		NSTintConfiguration DefaultTintConfiguration { get; }

		[Static]
		[Export ("monochromeTintConfiguration", ArgumentSemantic.Strong)]
		NSTintConfiguration MonochromeTintConfiguration { get; }

		[Static]
		[Export ("tintConfigurationWithPreferredColor:")]
		NSTintConfiguration CreateWithPreferredColor (NSColor color);

		[Static]
		[Export ("tintConfigurationWithFixedColor:")]
		NSTintConfiguration CreateWithFixedColor (NSColor color);

		[NullAllowed, Export ("baseTintColor", ArgumentSemantic.Strong)]
		NSColor BaseTintColor { get; }

		[NullAllowed, Export ("equivalentContentTintColor", ArgumentSemantic.Strong)]
		NSColor EquivalentContentTintColor { get; }

		[Export ("adaptsToUserAccentColor")]
		bool AdaptsToUserAccentColor { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSToolbarItem))]
	[DisableDefaultCtor]
	interface NSTrackingSeparatorToolbarItem {
		[DesignatedInitializer]
		[Export ("initWithItemIdentifier:")]
		NativeHandle Constructor (string itemIdentifier);

		[Static]
		[Export ("trackingSeparatorToolbarItemWithIdentifier:splitView:dividerIndex:")]
		NSTrackingSeparatorToolbarItem GetTrackingSeparatorToolbar (string identifier, NSSplitView splitView, nint dividerIndex);

		[Export ("splitView", ArgumentSemantic.Strong)]
		NSSplitView SplitView { get; set; }

		[Export ("dividerIndex")]
		nint DividerIndex { get; set; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSImageSymbolConfiguration : NSCopying, NSSecureCoding {
		[Static]
		[Export ("configurationWithPointSize:weight:scale:")]
		NSImageSymbolConfiguration Create (nfloat pointSize, double weight, NSImageSymbolScale scale);

		[Static]
		[Export ("configurationWithPointSize:weight:")]
		NSImageSymbolConfiguration Create (nfloat pointSize, double weight);

		[Static]
		[Export ("configurationWithTextStyle:scale:")]
		NSImageSymbolConfiguration Create (string style, NSImageSymbolScale scale);

		[Static]
		[Export ("configurationWithTextStyle:")]
		NSImageSymbolConfiguration Create (string style);

		[Static]
		[Export ("configurationWithScale:")]
		NSImageSymbolConfiguration Create (NSImageSymbolScale scale);

		[Static]
		[Export ("configurationWithHierarchicalColor:")]
		NSImageSymbolConfiguration Create (NSColor hierarchicalColor);

		[Static]
		[Export ("configurationWithPaletteColors:")]
		NSImageSymbolConfiguration Create (NSColor [] paletteColors);

		[Static]
		[Export ("configurationPreferringMulticolor")]
		NSImageSymbolConfiguration Create ();

		[Export ("configurationByApplyingConfiguration:")]
		NSImageSymbolConfiguration Create (NSImageSymbolConfiguration configuration);

		[Mac (13, 0)]
		[Static]
		[Export ("configurationPreferringMonochrome")]
		NSImageSymbolConfiguration CreateConfigurationPreferringMonochrome ();

		[Mac (13, 0)]
		[Static]
		[Export ("configurationPreferringHierarchical")]
		NSImageSymbolConfiguration CreateConfigurationPreferringHierarchical ();
	}

	[NoMacCatalyst, Mac (13, 0)]
	[BaseType (typeof (NSControl))]
	interface NSComboButton {
		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Static]
		[Export ("comboButtonWithTitle:menu:target:action:")]
		NSComboButton Create (string title, [NullAllowed] NSMenu menu, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Export ("comboButtonWithImage:menu:target:action:")]
		NSComboButton Create (NSImage image, [NullAllowed] NSMenu menu, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Static]
		[Export ("comboButtonWithTitle:image:menu:target:action:")]
		NSComboButton Create (string title, NSImage image, [NullAllowed] NSMenu menu, [NullAllowed] NSObject target, [NullAllowed] Selector action);

		[Export ("title")]
		string Title { get; set; }

		[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
		NSImage Image { get; set; }

		[Export ("imageScaling", ArgumentSemantic.Assign)]
		NSImageScaling ImageScaling { get; set; }

		[Export ("menu", ArgumentSemantic.Strong)]
		NSMenu Menu { get; set; }

		[Export ("style", ArgumentSemantic.Assign)]
		NSComboButtonStyle Style { get; set; }
	}

	

	[NoMacCatalyst, Mac (14, 0)]
	[BaseType (typeof (NSObject))]
	interface NSNibConnector : NSCoding {
		[NullAllowed, Export ("source", ArgumentSemantic.Weak)]
		NSObject Source { get; set; }

		[NullAllowed, Export ("destination", ArgumentSemantic.Weak)]
		NSObject Destination { get; set; }

		[Export ("label")]
		string Label { get; set; }

		[Export ("replaceObject:withObject:")]
		void Replace (NSObject oldObject, NSObject newObject);

		[Export ("establishConnection")]
		void EstablishConnection ();
	}

	[NoMacCatalyst, Mac (14, 0)]
	[BaseType (typeof (NSNibConnector))]
	interface NSNibControlConnector {
		[Export ("establishConnection")]
		void EstablishConnection ();
	}

	[NoMacCatalyst, Mac (14, 0)]
	[BaseType (typeof (NSView))]
	interface NSTextInsertionIndicator {

		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frameRect);

		[Export ("displayMode", ArgumentSemantic.Assign)]
		NSTextInsertionIndicatorDisplayMode DisplayMode { get; set; }

		[NullAllowed, Export ("color", ArgumentSemantic.Copy)]
		NSColor Color { get; set; }

		[Export ("automaticModeOptions", ArgumentSemantic.Assign)]
		NSTextInsertionIndicatorAutomaticModeOptions AutomaticModeOptions { get; set; }

		[NullAllowed, Export ("effectsViewInserter", ArgumentSemantic.Copy)]
		Action<NSView> EffectsViewInserter { get; set; }
	}

	[NoMacCatalyst, Mac (14, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSMenuItemBadge : NSCopying {
		[Static]
		[Export ("updatesWithCount:")]
		NSMenuItemBadge CreateUpdates (nint itemCount);

		[Static]
		[Export ("newItemsWithCount:")]
		[return: Release]
		NSMenuItemBadge CreateNewItems (nint itemCount);

		[Static]
		[Export ("alertsWithCount:")]
		NSMenuItemBadge CreateAlerts (nint itemCount);

		[Export ("initWithCount:type:")]
		NativeHandle Constructor (nint itemCount, NSMenuItemBadgeType type);

		[Export ("initWithCount:")]
		NativeHandle Constructor (nint itemCount);

		[Export ("initWithString:")]
		NativeHandle Constructor (string @string);

		[Export ("itemCount")]
		nint ItemCount { get; }

		[Export ("type")]
		NSMenuItemBadgeType Type { get; }

		[NullAllowed, Export ("stringValue")]
		string StringValue { get; }
	}

	[Protocol]
	interface NSAccessibilityColor {
		[Abstract]
		[Export ("accessibilityName")]
		string AccessibilityName { get; }
	}

	[NoMacCatalyst, Mac (14, 0)]
	[BaseType (typeof (NSNibConnector))]
	interface NSNibOutletConnector {
		[NoiOS]
		[Export ("establishConnection")]
		void EstablishConnection ();
	}

	[NoMacCatalyst]
	[Protocol]
	// This protocol is a candidate for [Model] as well, but the OS will check whether 'showAllHelpTopicsForSearchString:' is implemented
	// and behave differentely depending on the result. This is not possible to achieve with the generated [Model] class (all selectors
	// are always implemented), so to avoid potential confusion just offer the protocol interface for developers to use.
	interface NSUserInterfaceItemSearching {
		[Abstract]
		[Export ("searchForItemsWithSearchString:resultLimit:matchedItemHandler:")]
		void SearchForItems (string searchString, nint resultLimit, Action<NSObject []> matchedItemHandler);

		[Abstract]
		[Export ("localizedTitlesForItem:")]
		string [] GetLocalizedTitles (NSObject forItem);

		[Export ("performActionForItem:")]
		void PerformAction (NSObject forItem);

		[Export ("showAllHelpTopicsForSearchString:")]
		void ShowAllHelpTopics (string searchString);
	}

	interface INSUserInterfaceItemSearching { }

	[Mac (15, 0)]
	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSSharingCollaborationModeRestriction : NSSecureCoding, NSCopying {
		[Export ("disabledMode")]
		NSSharingCollaborationMode DisabledMode { get; }

		[Export ("alertTitle", ArgumentSemantic.Copy), NullAllowed]
		string AlertTitle { get; }

		[Export ("alertMessage", ArgumentSemantic.Copy), NullAllowed]
		string AlertMessage { get; }

		[Export ("alertDismissButtonTitle", ArgumentSemantic.Copy), NullAllowed]
		string AlertDismissButtonTitle { get; }

		[Export ("alertRecoverySuggestionButtonTitle", ArgumentSemantic.Copy), NullAllowed]
		string AlertRecoverySuggestionButtonTitle { get; }

		[Export ("alertRecoverySuggestionButtonLaunchURL", ArgumentSemantic.Copy), NullAllowed]
#if XAMCORE_5_0
		NSUrl AlertRecoverySuggestionButtonLaunchUrl { get; }
#else
		NSUrl AlertRecoverySuggestionButtonLaunchUrl {
			get;
			[Obsolete ("Do not use, the native class doesn't have this setter.")]
			set;
		}
#endif

		[Export ("initWithDisabledMode:")]
		NativeHandle Constructor (NSSharingCollaborationMode disabledMode);

		[Export ("initWithDisabledMode:alertTitle:alertMessage:")]
		NativeHandle Constructor (NSSharingCollaborationMode disabledMode, string alertTitle, string alertMessage);

		[Export ("initWithDisabledMode:alertTitle:alertMessage:alertDismissButtonTitle:")]
		NativeHandle Constructor (NSSharingCollaborationMode disabledMode, string alertTitle, string alertMessage, string alertDismissButtonTitle);

		[Export ("initWithDisabledMode:alertTitle:alertMessage:alertDismissButtonTitle:alertRecoverySuggestionButtonTitle:alertRecoverySuggestionButtonLaunchURL:")]
		NativeHandle Constructor (NSSharingCollaborationMode disabledMode, string alertTitle, string alertMessage, string alertDismissButtonTitle, string alertRecoverySuggestionButtonTitle, NSUrl alertRecoverySuggestionButtonLaunchUrl);
	}

	[Mac (15, 0), NoMacCatalyst]
	[Protocol (BackwardsCompatibleCodeGeneration = false)]
	interface NSViewContentSelectionInfo {
		[Export ("selectionAnchorRect")]
		CGRect /* NSRect */ SelectionAnchorRect { get; }
	}

	[Native]
	enum NSToolbarItemVisibilityPriority : long {
		Standard = 0,
		Low = -1000,
		High = 1000,
		User = 2000,
	}

	[Category]
	[BaseType (typeof (NSResponder))]
	[Mac (15, 2), NoMacCatalyst]
	interface NSResponder_NSWritingToolsSupport {
		[Export ("showWritingTools:")]
		void ShowWritingTools ([NullAllowed] NSObject sender);
	}

	[NoMacCatalyst, Mac (15, 2)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSTextPreview {
		[Export ("initWithSnapshotImage:presentationFrame:candidateRects:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CGImage snapshotImage, CGRect presentationFrame, [BindAs (typeof (CGRect []))] NSValue [] candidateRects);

		[Export ("initWithSnapshotImage:presentationFrame:")]
		NativeHandle Constructor (CGImage snapshotImage, CGRect presentationFrame);

		[Export ("previewImage")]
		CGImage PreviewImage { get; }

		[Export ("presentationFrame")]
		CGRect PresentationFrame { get; }

		[Export ("candidateRects")]
		[BindAs (typeof (CGRect []))]
		NSValue [] CandidateRects { get; }
	}
}
