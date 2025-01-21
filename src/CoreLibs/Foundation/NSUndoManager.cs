//
// This file implements the NSUndoManager interfase
//
// Authors:
//   Paola Villarreal
//
// Copyright 2015 Xamarin Inc.
//
//

#nullable enable

using System;
using CoreLibs;
using Foundation;
using ObjCRuntime;

namespace Foundation {
	public partial class NSUndoManager {
#if !NET
		public virtual void SetActionName (string actionName)
		{
			SetActionname (actionName);
		}
#endif

#if NET
		public NSRunLoopMode [] RunLoopModes {
			get
			{
				throw new NotImplementedException();
				/*
				var modes = WeakRunLoopModes;
				if (modes is null)
					return Array.Empty<NSRunLoopMode> ();

				var array = new NSRunLoopMode [modes.Length];
				for (int n = 0; n < modes.Length; n++)
					array [n] = NSRunLoopModeExtensions.GetValue (modes [n]);
				return array;
				*/
			}
			set {
				WeakRunLoopModes = value?.GetConstants ()!;
			}
		}
#endif
	}
	
	[BaseType (typeof (NSObject))]
	partial class NSUndoManager {
		[Export ("beginUndoGrouping")]
		public extern void BeginUndoGrouping ();

		[Export ("endUndoGrouping")]
		public extern void EndUndoGrouping ();

		[Export ("groupingLevel")]
		public extern nint GroupingLevel { get; }

		[Export ("disableUndoRegistration")]
		public extern void DisableUndoRegistration ();

		[Export ("enableUndoRegistration")]
		public extern void EnableUndoRegistration ();

		[Export ("isUndoRegistrationEnabled")]
		public extern bool IsUndoRegistrationEnabled { get; }

		[Export ("groupsByEvent")]
		public extern bool GroupsByEvent { get; set; }

		[Export ("levelsOfUndo")]
		public extern nint LevelsOfUndo { get; set; }

#if NET
		[Export ("runLoopModes", ArgumentSemantic.Copy)]
		public extern NSString [] WeakRunLoopModes { get; set; }
#else
		[Export ("runLoopModes")]
		string [] RunLoopModes { get; set; }
#endif

		[Export ("undo")]
		public extern void Undo ();

		[Export ("redo")]
		public extern void Redo ();

		[Export ("undoNestedGroup")]
		public extern void UndoNestedGroup ();

		[Export ("canUndo")]
		public extern bool CanUndo { get; }

		[Export ("canRedo")]
		public extern bool CanRedo { get; }

		//[Watch (10, 4), TV (17, 4), Mac (14, 4), iOS (17, 4), MacCatalyst (17, 4)]
		[Export ("undoCount")]
		public extern nuint UndoCount { get; }

		//[Watch (10, 4), TV (17, 4), Mac (14, 4), iOS (17, 4), MacCatalyst (17, 4)]
		[Export ("redoCount")]
		public extern nuint RedoCount { get; }

		[Export ("isUndoing")]
		public extern bool IsUndoing { get; }

		[Export ("isRedoing")]
		public extern bool IsRedoing { get; }

		[Export ("removeAllActions")]
		public extern void RemoveAllActions ();

		[Export ("removeAllActionsWithTarget:")]
		public extern void RemoveAllActions (NSObject target);

		[Export ("registerUndoWithTarget:selector:object:")]
		public extern void RegisterUndoWithTarget (NSObject target, Selector selector, [NullAllowed] NSObject anObject);

		[Export ("prepareWithInvocationTarget:")]
		public extern NSObject PrepareWithInvocationTarget (NSObject target);

		[Export ("undoActionName")]
		public extern string UndoActionName { get; }

		[Export ("redoActionName")]
		public extern string RedoActionName { get; }

#if NET
		[Export ("setActionName:")]
		public extern void SetActionName (string actionName);
#else
		[Advice ("Use the correctly named method: 'SetActionName'.")]
		[Export ("setActionName:")]
		public extern void SetActionname (string actionName);
#endif

		[Export ("undoMenuItemTitle")]
		public extern string UndoMenuItemTitle { get; }

		[Export ("redoMenuItemTitle")]
		public extern string RedoMenuItemTitle { get; }

		[Export ("undoMenuTitleForUndoActionName:")]
		public extern string UndoMenuTitleForUndoActionName (string name);

		[Export ("redoMenuTitleForUndoActionName:")]
		public extern string RedoMenuTitleForUndoActionName (string name);

		[Field ("NSUndoManagerCheckpointNotification")]
		[Notification]
		public extern NSString CheckpointNotification { get; }

		[Field ("NSUndoManagerDidOpenUndoGroupNotification")]
		[Notification]
		public extern NSString DidOpenUndoGroupNotification { get; }

		[Field ("NSUndoManagerDidRedoChangeNotification")]
		[Notification]
		public extern NSString DidRedoChangeNotification { get; }

		[Field ("NSUndoManagerDidUndoChangeNotification")]
		[Notification]
		public extern NSString DidUndoChangeNotification { get; }

		[Field ("NSUndoManagerWillCloseUndoGroupNotification")]
		[Notification (typeof (NSUndoManagerCloseUndoGroupEventArgs))]
		public extern NSString WillCloseUndoGroupNotification { get; }

		[Field ("NSUndoManagerWillRedoChangeNotification")]
		[Notification]
		public extern NSString WillRedoChangeNotification { get; }

		[Field ("NSUndoManagerWillUndoChangeNotification")]
		[Notification]
		public extern NSString WillUndoChangeNotification { get; }

		[Export ("setActionIsDiscardable:")]
		public extern void SetActionIsDiscardable (bool discardable);

		[Export ("undoActionIsDiscardable")]
		public extern bool UndoActionIsDiscardable { get; }

		[Export ("redoActionIsDiscardable")]
		public extern bool RedoActionIsDiscardable { get; }

		[Field ("NSUndoManagerGroupIsDiscardableKey")]
		public extern NSString GroupIsDiscardableKey { get; }

		[Field ("NSUndoManagerDidCloseUndoGroupNotification")]
		[Notification (typeof (NSUndoManagerCloseUndoGroupEventArgs))]
		public extern NSString DidCloseUndoGroupNotification { get; }

		[MacCatalyst (13, 1)]
		[Export ("registerUndoWithTarget:handler:")]
		public extern void RegisterUndo (NSObject target, Action<NSObject> undoHandler);

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("undoActionUserInfoValueForKey:")]
		[return: NullAllowed]
		public extern NSObject GetUndoActionUserInfoValue (string key);

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("redoActionUserInfoValueForKey:")]
		[return: NullAllowed]
		public extern NSObject GetRedoActionUserInfoValue (string key);

		//[Watch (11, 0), TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("setActionUserInfoValue:forKey:")]
		public extern void SetActionUserInfoValue ([NullAllowed] NSObject info, string key);
	}
}
