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
using UICollectionLayoutListConfiguration=System.Object;
using UIContentInsetsReference=System.Object;
using UIEdgeInsets=System.Object;
using UITraitCollection=System.Object;

#if !NET
using NativeHandle = System.IntPtr;
#endif

#nullable enable

#endregion

namespace UIKit
{

	/*// NSUInteger -> UICollisionBehavior.h
	[Native]
	[Flags]
	[MacCatalyst (13, 1)]
	public enum UICollisionBehaviorMode : ulong {
		Items = 1,
		Boundaries = 2,
		Everything = UInt64.MaxValue
	}*/
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (UIDynamicBehavior),
		   Delegates = new string [] { "CollisionDelegate" },
		   Events = new Type [] { typeof (UICollisionBehaviorDelegate) })]
	

	public interface IUICollisionBehaviorDelegate { }

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[Protocol]
	[Model]
	public interface UICollisionBehaviorDelegate {
		[Export ("collisionBehavior:beganContactForItem:withItem:atPoint:")]
		[EventArgs ("UICollisionBeganContact")]
		void BeganContact (UICollisionBehavior behavior, IUIDynamicItem firstItem, IUIDynamicItem secondItem, CGPoint atPoint);

		[Export ("collisionBehavior:endedContactForItem:withItem:")]
		[EventArgs ("UICollisionEndedContact")]
		void EndedContact (UICollisionBehavior behavior, IUIDynamicItem firstItem, IUIDynamicItem secondItem);

		[Export ("collisionBehavior:beganContactForItem:withBoundaryIdentifier:atPoint:")]
		[EventArgs ("UICollisionBeganBoundaryContact")]
		void BeganBoundaryContact (UICollisionBehavior behavior, IUIDynamicItem dynamicItem, [NullAllowed] NSObject boundaryIdentifier, CGPoint atPoint);

		[Export ("collisionBehavior:endedContactForItem:withBoundaryIdentifier:")]
		[EventArgs ("UICollisionEndedBoundaryContact")]
		void EndedBoundaryContact (UICollisionBehavior behavior, IUIDynamicItem dynamicItem, [NullAllowed] NSObject boundaryIdentifier);
	}
	
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class UIResponder : NSObject
	{
	
	/* COMMENTED UNIT WE NEED IT 
		//UIAccessibilityAction, UIAccessibilityFocus, UIUserActivityRestoring, UIResponderStandardEditActions
#if !TVOS
	//, UIAccessibilityDragging
#endif // !TVOS
#if IOS
	//, UIPasteConfigurationSupporting, UIActivityItemsConfigurationProviding
#if __MACCATALYST__
	//, NSTouchBarProvider
#endif // __MACCATALYST__
#endif // IOS
	{

		[Export ("nextResponder")]
		public extern UIResponder NextResponder { get; }

		[Export ("canBecomeFirstResponder")]
		public extern bool CanBecomeFirstResponder { get; }

		[Export ("becomeFirstResponder")]
		public extern bool BecomeFirstResponder ();

		[Export ("canResignFirstResponder")]
		public extern bool CanResignFirstResponder { get; }

		[Export ("resignFirstResponder")]
		public extern bool ResignFirstResponder ();

		[Export ("isFirstResponder")]
		public extern bool IsFirstResponder { get; }

		[Export ("touchesBegan:withEvent:")]
		public extern void TouchesBegan (NSSet touches, [NullAllowed] UIEvent evt);

		[Export ("touchesMoved:withEvent:")]
		public extern void TouchesMoved (NSSet touches, [NullAllowed] UIEvent evt);

		[Export ("touchesEnded:withEvent:")]
		public extern void TouchesEnded (NSSet touches, [NullAllowed] UIEvent evt);

		[Export ("touchesCancelled:withEvent:")]
		public extern void TouchesCancelled (NSSet touches, [NullAllowed] UIEvent evt);

		[Export ("motionBegan:withEvent:")]
		public extern void MotionBegan (UIEventSubtype motion, [NullAllowed] UIEvent evt);

		[Export ("motionEnded:withEvent:")]
		public extern void MotionEnded (UIEventSubtype motion, [NullAllowed] UIEvent evt);

		[Export ("motionCancelled:withEvent:")]
		public extern void MotionCancelled (UIEventSubtype motion, [NullAllowed] UIEvent evt);

		[Export ("canPerformAction:withSender:")]
		public extern bool CanPerform (Selector action, [NullAllowed] NSObject withSender);

		[Export ("undoManager"), NullAllowed]
		public extern NSUndoManager UndoManager { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("editingInteractionConfiguration")]
		public extern UIEditingInteractionConfiguration EditingInteractionConfiguration { get; }

		// 3.2

		[Export ("inputAccessoryView")]
		public extern UIView InputAccessoryView { get; }

		[Export ("inputView")]
		public extern UIView InputView { get; }

		[Export ("reloadInputViews")]
		public extern void ReloadInputViews ();

		[Export ("remoteControlReceivedWithEvent:")]
		public extern void RemoteControlReceived ([NullAllowed] UIEvent theEvent);

		//
		// 7.0
		//

		[Export ("keyCommands")]
		public extern UIKeyCommand [] KeyCommands { get; }

		[Static, Export ("clearTextInputContextIdentifier:")]
		public extern void ClearTextInputContextIdentifier (NSString identifier);

		[Export ("targetForAction:withSender:")]
		public extern NSObject GetTargetForAction (Selector action, [NullAllowed] NSObject sender);

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("buildMenuWithBuilder:")]
		public extern void BuildMenu (IUIMenuBuilder builder);

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("validateCommand:")]
		public extern public extern void ValidateCommand (UICommand command);

		[Export ("textInputContextIdentifier")]
		public extern NSString TextInputContextIdentifier { get; }

		[Export ("textInputMode")]
		public extern UITextInputMode TextInputMode { get; }

		[MacCatalyst (13, 1)]
		[Export ("inputViewController")]
		UIInputViewController InputViewController { get; }

		[MacCatalyst (13, 1)]
		[Export ("inputAccessoryViewController")]
		UIInputViewController InputAccessoryViewController { get; }

		[MacCatalyst (13, 1)]
		[Export ("userActivity"), NullAllowed]
		NSUserActivity UserActivity { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("updateUserActivityState:")]
		void UpdateUserActivityState (NSUserActivity activity);

		[MacCatalyst (13, 1)]
		[Export ("pressesBegan:withEvent:")]
		void PressesBegan (NSSet<UIPress> presses, UIPressesEvent evt);

		[MacCatalyst (13, 1)]
		[Export ("pressesChanged:withEvent:")]
		void PressesChanged (NSSet<UIPress> presses, UIPressesEvent evt);

		[MacCatalyst (13, 1)]
		[Export ("pressesEnded:withEvent:")]
		void PressesEnded (NSSet<UIPress> presses, UIPressesEvent evt);

		[MacCatalyst (13, 1)]
		[Export ("pressesCancelled:withEvent:")]
		void PressesCancelled (NSSet<UIPress> presses, UIPressesEvent evt);

		// from UIResponderInputViewAdditions (UIResponder) - other members already inlined

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("inputAssistantItem", ArgumentSemantic.Strong)]
		UITextInputAssistantItem InputAssistantItem { get; }

		[MacCatalyst (13, 1)]
		[Export ("touchesEstimatedPropertiesUpdated:")]
		void TouchesEstimatedPropertiesUpdated (NSSet touches);

		// from UIResponder (UIActivityItemsConfiguration)

#pragma warning disable 0109 // warning CS0109: The member 'UIResponder.ActivityItemsConfiguration' does not hide an accessible member. The new keyword is not required.
		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("activityItemsConfiguration", ArgumentSemantic.Strong)]
		new IUIActivityItemsConfigurationReading ActivityItemsConfiguration { get; set; }
#pragma warning restore

		// from UIResponder (UICaptureTextFromCameraSupporting)
		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("captureTextFromCamera:")]
		void CaptureTextFromCamera ([NullAllowed] NSObject sender);

		[MacCatalyst (13, 1)]
		[NoTV, NoiOS]
		[Export ("makeTouchBar")]
		[return: NullAllowed]
		NSTouchBar CreateTouchBar ();

#pragma warning disable 0108 // warning CS0108: 'NSFontAssetRequest.Progress' hides inherited member 'NSProgressReporting.Progress'. Use the new keyword if hiding was intended.
		[MacCatalyst (13, 1)]
		[NoTV, NoiOS]
		[Export ("touchBar", ArgumentSemantic.Strong)]
		[NullAllowed]
		NSTouchBar TouchBar { get; set; }
#pragma warning restore
	}
	
    [MacCatalyst (13, 1)]
	[BaseType (typeof (UIResponder))]
	public class UIView : UIResponder
		//UIAppearance, UIAppearanceContainer, UIAccessibility, UIDynamicItem, NSCoding, UIAccessibilityIdentification, UITraitEnvironment, UICoordinateSpace, UIFocusItem, UIFocusItemContainer
		//, UITraitChangeObservable
#if !TVOS
		//, UILargeContentViewerItem, UIPopoverPresentationControllerSourceItem
#endif
		//, CALayerDelegate 
	{
		[DesignatedInitializer]
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frame);

		[Export ("addSubview:")]
		[PostGet ("Subviews")]
		void AddSubview (UIView view);

		[ThreadSafe, Export ("drawRect:")]
		void Draw (CGRect rect);

		[Export ("backgroundColor", ArgumentSemantic.Retain)]
		[Appearance]
		[NullAllowed]
		UIColor BackgroundColor { get; set; }

		[ThreadSafe]
		[Export ("bounds")]
		new CGRect Bounds { get; set; }

		[Export ("userInteractionEnabled")]
		bool UserInteractionEnabled { [Bind ("isUserInteractionEnabled")] get; set; }

		[Export ("tag")]
		nint Tag { get; set; }

		[ThreadSafe]
		[Export ("layer", ArgumentSemantic.Retain)]
		CALayer Layer { get; }

		[Export ("frame")]
		new CGRect Frame { get; set; }

		[Export ("center")]
		new CGPoint Center { get; set; }

		[Export ("transform")]
		new CGAffineTransform Transform { get; set; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("multipleTouchEnabled")]
		bool MultipleTouchEnabled { [Bind ("isMultipleTouchEnabled")] get; set; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("exclusiveTouch")]
		bool ExclusiveTouch { [Bind ("isExclusiveTouch")] get; set; }

		[Export ("hitTest:withEvent:")]
		[return: NullAllowed]
		UIView HitTest (CGPoint point, [NullAllowed] UIEvent uievent);

		[Export ("pointInside:withEvent:")]
		bool PointInside (CGPoint point, [NullAllowed] UIEvent uievent);

		[Export ("convertPoint:toView:")]
		CGPoint ConvertPointToView (CGPoint point, [NullAllowed] UIView toView);

		[Export ("convertPoint:fromView:")]
		CGPoint ConvertPointFromView (CGPoint point, [NullAllowed] UIView fromView);

		[Export ("convertRect:toView:")]
		CGRect ConvertRectToView (CGRect rect, [NullAllowed] UIView toView);

		[Export ("convertRect:fromView:")]
		CGRect ConvertRectFromView (CGRect rect, [NullAllowed] UIView fromView);

		[Export ("autoresizesSubviews")]
		bool AutosizesSubviews { get; set; }

		[Export ("autoresizingMask")]
		UIViewAutoresizing AutoresizingMask { get; set; }

		[Export ("sizeThatFits:")]
		CGSize SizeThatFits (CGSize size);

		[Export ("sizeToFit")]
		void SizeToFit ();

		[NullAllowed]
		[Export ("superview")]
		UIView Superview { get; }

		[Export ("subviews", ArgumentSemantic.Copy)]
		UIView [] Subviews { get; }

		[Export ("window")]
		[Transient]
		[NullAllowed]
		UIWindow Window { get; }

		[Export ("removeFromSuperview")]
		void RemoveFromSuperview ();

		[Export ("insertSubview:atIndex:")]
		[PostGet ("Subviews")]
		void InsertSubview (UIView view, nint atIndex);

		[Export ("exchangeSubviewAtIndex:withSubviewAtIndex:")]
		void ExchangeSubview (nint atIndex, nint withSubviewAtIndex);

		[Export ("insertSubview:belowSubview:")]
		[PostGet ("Subviews")]
		void InsertSubviewBelow (UIView view, UIView siblingSubview);

		[Export ("insertSubview:aboveSubview:")]
		[PostGet ("Subviews")]
		void InsertSubviewAbove (UIView view, UIView siblingSubview);

		[Export ("bringSubviewToFront:")]
		void BringSubviewToFront (UIView view);

		[Export ("sendSubviewToBack:")]
		void SendSubviewToBack (UIView view);

		[Export ("didAddSubview:")]
		void SubviewAdded (UIView uiview);

		[Export ("willRemoveSubview:")]
		void WillRemoveSubview (UIView uiview);

		[Export ("willMoveToSuperview:")]
		void WillMoveToSuperview ([NullAllowed] UIView newsuper);

		[Export ("didMoveToSuperview")]
		void MovedToSuperview ();

		[Export ("willMoveToWindow:")]
		void WillMoveToWindow ([NullAllowed] UIWindow window);

		[Export ("didMoveToWindow")]
		void MovedToWindow ();

		[Export ("isDescendantOfView:")]
		bool IsDescendantOfView (UIView view);

		[return: NullAllowed]
		[Export ("viewWithTag:")]
		UIView ViewWithTag (nint tag);

		[Export ("setNeedsLayout")]
		void SetNeedsLayout ();

		[Export ("layoutIfNeeded")]
		void LayoutIfNeeded ();

		[Export ("layoutSubviews")]
		void LayoutSubviews ();

		[Export ("setNeedsDisplay")]
		void SetNeedsDisplay ();

		[Export ("setNeedsDisplayInRect:")]
		void SetNeedsDisplayInRect (CGRect rect);

		[Export ("clipsToBounds")]
		bool ClipsToBounds { get; set; }

		[Export ("alpha")]
		nfloat Alpha { get; set; }

		[Export ("opaque")]
		bool Opaque { [Bind ("isOpaque")] get; set; }

		[Export ("clearsContextBeforeDrawing")]
		bool ClearsContextBeforeDrawing { get; set; }

		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

		[Export ("contentMode")]
		UIViewContentMode ContentMode { get; set; }

		[NoTV]
		[Export ("contentStretch")]
		[Deprecated (PlatformName.iOS, 6, 0, message: "Use 'CreateResizableImage' instead.")]
		[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'CreateResizableImage' instead.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'CreateResizableImage' instead.")]
		CGRect ContentStretch { get; set; }

		[Static]
		[Export ("beginAnimations:context:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void BeginAnimations ([NullAllowed] string animationID, IntPtr context);

		[Static]
		[Export ("commitAnimations")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void CommitAnimations ();

		[Static]
		[Export ("setAnimationDelegate:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationDelegate (NSObject del);

		[Static]
		[Export ("setAnimationWillStartSelector:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationWillStartSelector (Selector sel);

		[Static]
		[Export ("setAnimationDidStopSelector:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationDidStopSelector (Selector sel);

		[Static]
		[Export ("setAnimationDuration:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationDuration (double duration);

		[Static]
		[Export ("setAnimationDelay:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationDelay (double delay);

		[Static]
		[Export ("setAnimationStartDate:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationStartDate (NSDate startDate);

		[Static]
		[Export ("setAnimationCurve:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationCurve (UIViewAnimationCurve curve);

		[Static]
		[Export ("setAnimationRepeatCount:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationRepeatCount (float repeatCount );

		[Static]
		[Export ("setAnimationRepeatAutoreverses:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationRepeatAutoreverses (bool repeatAutoreverses);

		[Static]
		[Export ("setAnimationBeginsFromCurrentState:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationBeginsFromCurrentState (bool fromCurrentState);

		[Static]
		[Export ("setAnimationTransition:forView:cache:")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use the 'Action' handler based animation APIs instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use the 'Action' handler based animation APIs instead.")]
		void SetAnimationTransition (UIViewAnimationTransition transition, UIView forView, bool cache);

		[Static]
		[Export ("areAnimationsEnabled")]
		bool AnimationsEnabled { [Bind ("areAnimationsEnabled")] get; [Bind ("setAnimationsEnabled:")] set; }

		// 3.2:
		[Export ("addGestureRecognizer:"), PostGet ("GestureRecognizers")]
		void AddGestureRecognizer (UIGestureRecognizer gestureRecognizer);

		[Export ("removeGestureRecognizer:"), PostGet ("GestureRecognizers")]
		void RemoveGestureRecognizer (UIGestureRecognizer gestureRecognizer);

		[NullAllowed] // by default this property is null
		[Export ("gestureRecognizers", ArgumentSemantic.Copy)]
		UIGestureRecognizer [] GestureRecognizers { get; set; }

		[Static, Export ("animateWithDuration:animations:")]
		void Animate (double duration,  Action animation);

		[Static, Export ("animateWithDuration:animations:completion:")]
		[Async]
		void AnimateNotify (double duration,  Action animation, [NullAllowed] UICompletionHandler completion);

		[Static, Export ("animateWithDuration:delay:options:animations:completion:")]
		[Async]
		void AnimateNotify (double duration, double delay, UIViewAnimationOptions options, Action animation, [NullAllowed] UICompletionHandler completion);

		[Static, Export ("transitionFromView:toView:duration:options:completion:")]
		[Async]
		void TransitionNotify (UIView fromView, UIView toView, double duration, UIViewAnimationOptions options, [NullAllowed] UICompletionHandler completion);

		[Static, Export ("transitionWithView:duration:options:animations:completion:")]
		[Async]
		void TransitionNotify (UIView withView, double duration, UIViewAnimationOptions options, [NullAllowed] Action animation, [NullAllowed] UICompletionHandler completion);

		[Export ("contentScaleFactor")]
		nfloat ContentScaleFactor { get; set; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("viewPrintFormatter")]
		UIViewPrintFormatter ViewPrintFormatter { get; }

		[NoTV]
		[MacCatalyst (13, 1)]
		[Export ("drawRect:forViewPrintFormatter:")]
		void DrawRect (CGRect area, UIViewPrintFormatter formatter);

		//
		// 6.0
		//

		[Export ("constraints")]
		NSLayoutConstraint [] Constraints { get; }

		[Export ("addConstraint:")]
		void AddConstraint (NSLayoutConstraint constraint);

		[Export ("addConstraints:")]
		void AddConstraints (NSLayoutConstraint [] constraints);

		[Export ("removeConstraint:")]
		void RemoveConstraint (NSLayoutConstraint constraint);

		[Export ("removeConstraints:")]
		void RemoveConstraints (NSLayoutConstraint [] constraints);

		[Export ("needsUpdateConstraints")]
		bool NeedsUpdateConstraints ();

		[Export ("setNeedsUpdateConstraints")]
		void SetNeedsUpdateConstraints ();

		[Static]
		[Export ("requiresConstraintBasedLayout")]
		bool RequiresConstraintBasedLayout ();

		[Export ("alignmentRectForFrame:")]
		CGRect AlignmentRectForFrame (CGRect frame);

		[Export ("frameForAlignmentRect:")]
		CGRect FrameForAlignmentRect (CGRect alignmentRect);

		[Export ("alignmentRectInsets")]
		UIEdgeInsets AlignmentRectInsets { get; }

		[NoTV]
		[Export ("viewForBaselineLayout")]
		[Deprecated (PlatformName.iOS, 9, 0, message: "Override 'ViewForFirstBaselineLayout' or 'ViewForLastBaselineLayout'.")]
		[MacCatalyst (13, 1)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Override 'ViewForFirstBaselineLayout' or 'ViewForLastBaselineLayout'.")]
		UIView ViewForBaselineLayout { get; }

		[MacCatalyst (13, 1)]
		[Export ("viewForFirstBaselineLayout")]
		UIView ViewForFirstBaselineLayout { get; }

		[MacCatalyst (13, 1)]
		[Export ("viewForLastBaselineLayout")]
		UIView ViewForLastBaselineLayout { get; }


		[Export ("intrinsicContentSize")]
		CGSize IntrinsicContentSize { get; }

		[Export ("invalidateIntrinsicContentSize")]
		void InvalidateIntrinsicContentSize ();

		[Export ("contentHuggingPriorityForAxis:")]
		float ContentHuggingPriority (UILayoutConstraintAxis axis); // This returns a float, not nfloat.

		[Export ("setContentHuggingPriority:forAxis:")]
		void SetContentHuggingPriority (float priority , UILayoutConstraintAxis axis);

		[Export ("contentCompressionResistancePriorityForAxis:")]
		float ContentCompressionResistancePriority (UILayoutConstraintAxis axis); // This returns a float, not nfloat.

		[Export ("setContentCompressionResistancePriority:forAxis:")]
		void SetContentCompressionResistancePriority (float priority , UILayoutConstraintAxis axis);

		[Export ("constraintsAffectingLayoutForAxis:")]
		NSLayoutConstraint [] GetConstraintsAffectingLayout (UILayoutConstraintAxis axis);

		[Export ("hasAmbiguousLayout")]
		bool HasAmbiguousLayout { get; }

		[Export ("exerciseAmbiguityInLayout")]
		void ExerciseAmbiguityInLayout ();

		[Export ("systemLayoutSizeFittingSize:")]
		CGSize SystemLayoutSizeFittingSize (CGSize size);

		[Export ("decodeRestorableStateWithCoder:")]
		void DecodeRestorableState (NSCoder coder);

		[Export ("encodeRestorableStateWithCoder:")]
		void EncodeRestorableState (NSCoder coder);

		[NullAllowed] // by default this property is null
		[Export ("restorationIdentifier", ArgumentSemantic.Copy)]
		string RestorationIdentifier { get; set; }

		[Export ("gestureRecognizerShouldBegin:")]
		bool GestureRecognizerShouldBegin (UIGestureRecognizer gestureRecognizer);

		[Export ("translatesAutoresizingMaskIntoConstraints")]
		bool TranslatesAutoresizingMaskIntoConstraints { get; set; }

		[Export ("updateConstraintsIfNeeded")]
		void UpdateConstraintsIfNeeded ();

		[Export ("updateConstraints")]
		[RequiresSuper]
		void UpdateConstraints ();

		[Field ("UIViewNoIntrinsicMetric")]
		nfloat NoIntrinsicMetric { get; }

		[Field ("UILayoutFittingCompressedSize")]
		CGSize UILayoutFittingCompressedSize { get; }

		[Field ("UILayoutFittingExpandedSize")]
		CGSize UILayoutFittingExpandedSize { get; }

		[NullAllowed]
		[Export ("tintColor")]
		[Appearance]
		UIColor TintColor { get; set; }

		[Export ("tintAdjustmentMode")]
		UIViewTintAdjustmentMode TintAdjustmentMode { get; set; }

		[Export ("tintColorDidChange")]
		void TintColorDidChange ();

		[Static, Export ("performWithoutAnimation:")]
		void PerformWithoutAnimation (Action actionsWithoutAnimation);

		[Static, Export ("performSystemAnimation:onViews:options:animations:completion:")]
		[Async]
		void PerformSystemAnimation (UISystemAnimation animation, UIView [] views, UIViewAnimationOptions options, [NullAllowed] Action parallelAnimations, [NullAllowed] UICompletionHandler completion);

		[TV (13, 0), iOS (13, 0)] // Yep headers stated iOS 12 but they are such a liars...
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("modifyAnimationsWithRepeatCount:autoreverses:animations:")]
		void ModifyAnimations (nfloat count, bool autoreverses, Action animations);

		[Static, Export ("animateKeyframesWithDuration:delay:options:animations:completion:")]
		[Async]
		void AnimateKeyframes (double duration, double delay, UIViewKeyframeAnimationOptions options, Action animations, [NullAllowed] UICompletionHandler completion);

		[Static, Export ("addKeyframeWithRelativeStartTime:relativeDuration:animations:")]
		void AddKeyframeWithRelativeStartTime (double frameStartTime, double frameDuration, Action animations);

		[Export ("addMotionEffect:")]
		[PostGet ("MotionEffects")]
		void AddMotionEffect (UIMotionEffect effect);

		[Export ("removeMotionEffect:")]
		[PostGet ("MotionEffects")]
		void RemoveMotionEffect (UIMotionEffect effect);

		[NullAllowed] // by default this property is null
		[Export ("motionEffects", ArgumentSemantic.Copy)]
		UIMotionEffect [] MotionEffects { get; set; }

		[return: NullAllowed]
		[Export ("snapshotViewAfterScreenUpdates:")]
		UIView SnapshotView (bool afterScreenUpdates);

		[Export ("resizableSnapshotViewFromRect:afterScreenUpdates:withCapInsets:")]
		[return: NullAllowed]
		UIView ResizableSnapshotView (CGRect rect, bool afterScreenUpdates, UIEdgeInsets capInsets);

		[Export ("drawViewHierarchyInRect:afterScreenUpdates:")]
		bool DrawViewHierarchy (CGRect rect, bool afterScreenUpdates);

		[Static]
		[Export ("animateWithDuration:delay:usingSpringWithDamping:initialSpringVelocity:options:animations:completion:")]
		[Async]
		void AnimateNotify (double duration, double delay, nfloat springWithDampingRatio, nfloat initialSpringVelocity, UIViewAnimationOptions options, Action animations, [NullAllowed] UICompletionHandler completion);


		[MacCatalyst (13, 1)]
		[NullAllowed] // by default this property is null
		[Export ("maskView", ArgumentSemantic.Retain)]
		UIView MaskView { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("systemLayoutSizeFittingSize:withHorizontalFittingPriority:verticalFittingPriority:")]
		// float, not CGFloat / nfloat, but we can't use an enum in the signature
		CGSize SystemLayoutSizeFittingSize (CGSize targetSize,  float horizontalFittingPriority,  float verticalFittingPriority);

		[MacCatalyst (13, 1)]
		[Export ("layoutMargins")]
		UIEdgeInsets LayoutMargins { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("directionalLayoutMargins", ArgumentSemantic.Assign)]
		NSDirectionalEdgeInsets DirectionalLayoutMargins { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("preservesSuperviewLayoutMargins")]
		bool PreservesSuperviewLayoutMargins { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("insetsLayoutMarginsFromSafeArea")]
		bool InsetsLayoutMarginsFromSafeArea { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("layoutMarginsDidChange")]
		void LayoutMarginsDidChange ();

		[MacCatalyst (13, 1)]
		[Export ("safeAreaInsets")]
		UIEdgeInsets SafeAreaInsets { get; }

		[MacCatalyst (13, 1)]
		[Export ("safeAreaInsetsDidChange")]
		void SafeAreaInsetsDidChange ();

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("userInterfaceLayoutDirectionForSemanticContentAttribute:")]
		UIUserInterfaceLayoutDirection GetUserInterfaceLayoutDirection (UISemanticContentAttribute attribute);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("userInterfaceLayoutDirectionForSemanticContentAttribute:relativeToLayoutDirection:")]
		UIUserInterfaceLayoutDirection GetUserInterfaceLayoutDirection (UISemanticContentAttribute semanticContentAttribute, UIUserInterfaceLayoutDirection layoutDirection);

		[MacCatalyst (13, 1)]
		[Export ("effectiveUserInterfaceLayoutDirection")]
		UIUserInterfaceLayoutDirection EffectiveUserInterfaceLayoutDirection { get; }

		[MacCatalyst (13, 1)]
		[Export ("semanticContentAttribute", ArgumentSemantic.Assign)]
		UISemanticContentAttribute SemanticContentAttribute { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("layoutMarginsGuide", ArgumentSemantic.Strong)]
		UILayoutGuide LayoutMarginsGuide { get; }

		[MacCatalyst (13, 1)]
		[Export ("readableContentGuide", ArgumentSemantic.Strong)]
		UILayoutGuide ReadableContentGuide { get; }

		[MacCatalyst (13, 1)]
		[Export ("safeAreaLayoutGuide", ArgumentSemantic.Strong)]
		UILayoutGuide SafeAreaLayoutGuide { get; }

		[NoTV, iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("keyboardLayoutGuide")]
		UIKeyboardLayoutGuide KeyboardLayoutGuide { get; }

		[MacCatalyst (13, 1)]
		[Export ("inheritedAnimationDuration")]
		[Static]
		double InheritedAnimationDuration { get; }

		[MacCatalyst (13, 1)]
		[Export ("leadingAnchor")]
		NSLayoutXAxisAnchor LeadingAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("trailingAnchor")]
		NSLayoutXAxisAnchor TrailingAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("leftAnchor")]
		NSLayoutXAxisAnchor LeftAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("rightAnchor")]
		NSLayoutXAxisAnchor RightAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("topAnchor")]
		NSLayoutYAxisAnchor TopAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("bottomAnchor")]
		NSLayoutYAxisAnchor BottomAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("widthAnchor")]
		NSLayoutDimension WidthAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("heightAnchor")]
		NSLayoutDimension HeightAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("centerXAnchor")]
		NSLayoutXAxisAnchor CenterXAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("centerYAnchor")]
		NSLayoutYAxisAnchor CenterYAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("firstBaselineAnchor")]
		NSLayoutYAxisAnchor FirstBaselineAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("lastBaselineAnchor")]
		NSLayoutYAxisAnchor LastBaselineAnchor { get; }

		[MacCatalyst (13, 1)]
		[Export ("layoutGuides")]
		UILayoutGuide [] LayoutGuides { get; }

		[MacCatalyst (13, 1)]
		[Export ("addLayoutGuide:")]
		void AddLayoutGuide (UILayoutGuide guide);

		[MacCatalyst (13, 1)]
		[Export ("removeLayoutGuide:")]
		void RemoveLayoutGuide (UILayoutGuide guide);

		[MacCatalyst (13, 1)]
		[Export ("focused")]
		bool Focused { [Bind ("isFocused")] get; }

		[NullAllowed]
		[NoTV, iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("focusGroupIdentifier")]
		new string FocusGroupIdentifier { get; set; }

		[NoTV, iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("focusGroupPriority")]
		new nint FocusGroupPriority { get; set; }

		[NoTV, iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("focusEffect", ArgumentSemantic.Copy)]
		new UIFocusEffect FocusEffect { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("canBecomeFocused")]
		new bool CanBecomeFocused { get; }

		[TV (13, 0)] // Headers state Watch 5.0
		[MacCatalyst (13, 1)]
		[Export ("addInteraction:")]
		void AddInteraction (IUIInteraction interaction);

		[TV (13, 0)] // Headers state Watch 5.0
		[MacCatalyst (13, 1)]
		[Export ("removeInteraction:")]
		void RemoveInteraction (IUIInteraction interaction);

		[TV (13, 0)] // Headers state Watch 5.0
		[MacCatalyst (13, 1)]
		[Export ("interactions", ArgumentSemantic.Copy)]
		IUIInteraction [] Interactions { get; set; }

		// UIAccessibilityInvertColors category
		[MacCatalyst (13, 1)]
		[Export ("accessibilityIgnoresInvertColors")]
		bool AccessibilityIgnoresInvertColors { get; set; }

		// From UserInterfaceStyle category

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("overrideUserInterfaceStyle", ArgumentSemantic.Assign)]
		UIUserInterfaceStyle OverrideUserInterfaceStyle { get; set; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("transform3D", ArgumentSemantic.Assign)]
		CATransform3D Transform3D { get; set; }

		// Category UIView (UIContentSizeCategoryLimit)

		[BindAs (typeof (UIContentSizeCategory))]
		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("minimumContentSizeCategory")]
		NSString MinimumContentSizeCategory { get; set; }

		[BindAs (typeof (UIContentSizeCategory))]
		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("maximumContentSizeCategory")]
		NSString MaximumContentSizeCategory { get; set; }

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("appliedContentSizeCategoryLimitsDescription")]
		string AppliedContentSizeCategoryLimitsDescription { get; }

#if TVOS
#pragma warning disable 0109 // The member 'member' does not hide an inherited member. The new keyword is not required
#endif
		// From UIView (UILargeContentViewer)

		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("showsLargeContentViewer")]
		new bool ShowsLargeContentViewer { get; set; }

		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("largeContentTitle")]
		new string LargeContentTitle { get; set; }

		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("largeContentImage", ArgumentSemantic.Strong)]
		new UIImage LargeContentImage { get; set; }

		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("scalesLargeContentImage")]
		new bool ScalesLargeContentImage { get; set; }

		[NoTV, iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("largeContentImageInsets", ArgumentSemantic.Assign)]
		new UIEdgeInsets LargeContentImageInsets { get; set; }
#if TVOS
#pragma warning restore 0109
#endif

		[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("anchorPoint", ArgumentSemantic.Assign)]
		CGPoint AnchorPoint { get; set; }

		// from the category (UIView) <UITraitChangeObservable> 
		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("traitOverrides")]
		IUITraitOverrides TraitOverrides { get; }

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("updateTraitsIfNeeded")]
		void UpdateTraitsIfNeeded ();

		[NoTV, iOS (17, 0), MacCatalyst (17, 0)]
		[NullAllowed, Export ("hoverStyle", ArgumentSemantic.Copy)]
		UIHoverStyle HoverStyle { get; set; }

		[Async]
		[iOS (17, 0), MacCatalyst (17, 0), TV (17, 0)]
		[Static]
		[Export ("animateWithSpringDuration:bounce:initialSpringVelocity:delay:options:animations:completion:")]
		void Animate (double duration, nfloat bounce, nfloat velocity, double delay, UIViewAnimationOptions options, Action animations, [NullAllowed] Action<bool> completion);
	}

	[MacCatalyst (13, 1)]
	[Category, BaseType (typeof (UIView))]
	interface UIView_UITextField {
		[Export ("endEditing:")]
		bool EndEditing (bool force);
		
		*/
	}

	// MOCKED CLASSES UNTILL WE NEED IT 
	public class UIView : NSObject
	{
		
	}

	public class UICollectionViewLayout : NSCoding
	{
	}

	public class UICollectionViewLayoutAttributes : NSObject
	{
		
	}
	
	public class UIViewController : NSObject
	{
	}

}