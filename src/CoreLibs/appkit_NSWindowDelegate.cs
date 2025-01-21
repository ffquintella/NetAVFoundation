#region USING
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreFoundation;
using CoreImage;
using CoreAnimation;
using CoreData;
using CoreLibs;
//using CoreLibs.AppKit;
//using Intents;
//using SharedWithYouCore;
//using Symbols;
#if !__MACCATALYST__
using OpenGL;
#endif
using CoreVideo;
//using CloudKit;
using UniformTypeIdentifiers;

#if __MACCATALYST__
//using UIKit;
#else
using UIMenu = Foundation.NSObject;
using UIMenuElement = Foundation.NSObject;
#endif

using CGGlyph = System.UInt16;
#if __MACCATALYST__
using CAOpenGLLayer = Foundation.NSObject;
using CGLContext = Foundation.NSObject;
using CGLPixelFormat = Foundation.NSObject;
//using Color = UIKit.UIColor;
using NSColorList = Foundation.NSObject;
#else
using Color = AppKit.NSColor;
using IUIActivityItemsConfigurationReading = System.Object;
using UIBarButtonItem = Foundation.NSObject;
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

#endregion

namespace AppKit
{
	public interface INSWindowDelegate { }

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	public class NSWindowDelegate {
		[Export ("windowShouldClose:"), DelegateName ("NSObjectPredicate"), DefaultValue (true)]
		public extern bool WindowShouldClose (NSObject sender);

		[Export ("windowWillReturnFieldEditor:toObject:"), DelegateName ("NSWindowClient"), DefaultValue (null)]
		public extern NSObject WillReturnFieldEditor (NSWindow sender, NSObject client);

		[Export ("windowWillResize:toSize:"), DelegateName ("NSWindowResize"), DefaultValueFromArgument ("toFrameSize")]
		public extern CGSize WillResize (NSWindow sender, CGSize toFrameSize);

		[Export ("windowWillUseStandardFrame:defaultFrame:"), DelegateName ("NSWindowFrame"), DefaultValueFromArgument ("newFrame")]
		public extern CGRect WillUseStandardFrame (NSWindow window, CGRect newFrame);

		[Export ("windowShouldZoom:toFrame:"), DelegateName ("NSWindowFramePredicate"), DefaultValue (true)]
		public extern bool ShouldZoom (NSWindow window, CGRect newFrame);

		[Export ("windowWillReturnUndoManager:"), DelegateName ("NSWindowUndoManager"), DefaultValue (null)]
		public extern NSUndoManager WillReturnUndoManager (NSWindow window);

		[Export ("window:willPositionSheet:usingRect:"), DelegateName ("NSWindowSheetRect"), DefaultValueFromArgument ("usingRect")]
		public extern CGRect WillPositionSheet (NSWindow window, NSWindow sheet, CGRect usingRect);

		[Export ("window:shouldPopUpDocumentPathMenu:"), DelegateName ("NSWindowMenu"), DefaultValue (true)]
		public extern bool ShouldPopUpDocumentPathMenu (NSWindow window, NSMenu menu);

		[Export ("window:shouldDragDocumentWithEvent:from:withPasteboard:"), DelegateName ("NSWindowDocumentDrag"), DefaultValue (true)]
		public extern bool ShouldDragDocumentWithEvent (NSWindow window, NSEvent theEvent, CGPoint dragImageLocation, NSPasteboard withPasteboard);

		[Export ("windowDidResize:"), EventArgs ("NSNotification")]
		public extern void DidResize (NSNotification notification);

		[Export ("windowDidExpose:"), EventArgs ("NSNotification")]
		public extern void DidExpose (NSNotification notification);

		[Export ("windowWillMove:"), EventArgs ("NSNotification")]
		public extern void WillMove (NSNotification notification);

		[Export ("windowDidMove:"), EventArgs ("NSNotification")]
		public extern void DidMove (NSNotification notification);

		[Export ("windowDidBecomeKey:"), EventArgs ("NSNotification")]
		public extern void DidBecomeKey (NSNotification notification);

		[Export ("windowDidResignKey:"), EventArgs ("NSNotification")]
		public extern void DidResignKey (NSNotification notification);

		[Export ("windowDidBecomeMain:"), EventArgs ("NSNotification")]
		public extern void DidBecomeMain (NSNotification notification);

		[Export ("windowDidResignMain:"), EventArgs ("NSNotification")]
		public extern void DidResignMain (NSNotification notification);

		[Export ("windowWillClose:"), EventArgs ("NSNotification")]
		public extern void WillClose (NSNotification notification);

		[Export ("windowWillMiniaturize:"), EventArgs ("NSNotification")]
		public extern void WillMiniaturize (NSNotification notification);

		[Export ("windowDidMiniaturize:"), EventArgs ("NSNotification")]
		public extern void DidMiniaturize (NSNotification notification);

		[Export ("windowDidDeminiaturize:"), EventArgs ("NSNotification")]
		public extern void DidDeminiaturize (NSNotification notification);

		[Export ("windowDidUpdate:"), EventArgs ("NSNotification")]
		public extern void DidUpdate (NSNotification notification);

		[Export ("windowDidChangeScreen:"), EventArgs ("NSNotification")]
		public extern void DidChangeScreen (NSNotification notification);

		[Export ("windowDidChangeScreenProfile:"), EventArgs ("NSNotification")]
		public extern void DidChangeScreenProfile (NSNotification notification);

		[Export ("windowWillBeginSheet:"), EventArgs ("NSNotification")]
		public extern void WillBeginSheet (NSNotification notification);

		[Export ("windowDidEndSheet:"), EventArgs ("NSNotification")]
		public extern void DidEndSheet (NSNotification notification);

		[Export ("windowWillStartLiveResize:"), EventArgs ("NSNotification")]
		public extern void WillStartLiveResize (NSNotification notification);

		[Export ("windowDidEndLiveResize:"), EventArgs ("NSNotification")]
		public extern void DidEndLiveResize (NSNotification notification);

		[Export ("windowWillEnterFullScreen:"), EventArgs ("NSNotification")]
		public extern void WillEnterFullScreen (NSNotification notification);

		[Export ("windowDidEnterFullScreen:"), EventArgs ("NSNotification")]
		public extern void DidEnterFullScreen (NSNotification notification);

		[Export ("windowWillExitFullScreen:"), EventArgs ("NSNotification")]
		public extern void WillExitFullScreen (NSNotification notification);

		[Export ("windowDidExitFullScreen:"), EventArgs ("NSNotification")]
		public extern void DidExitFullScreen (NSNotification notification);

		[Export ("windowDidFailToEnterFullScreen:"), EventArgs ("NSWindow")]
		public extern void DidFailToEnterFullScreen (NSWindow window);

		[Export ("windowDidFailToExitFullScreen:"), EventArgs ("NSWindow")]
		public extern void DidFailToExitFullScreen (NSWindow window);

		[Export ("window:willUseFullScreenContentSize:"), DelegateName ("NSWindowSize"), DefaultValueFromArgument ("proposedSize")]
		public extern CGSize WillUseFullScreenContentSize (NSWindow window, CGSize proposedSize);

		[Export ("window:willUseFullScreenPresentationOptions:"), DelegateName ("NSWindowApplicationPresentationOptions"), DefaultValueFromArgument ("proposedOptions")]
		public extern NSApplicationPresentationOptions WillUseFullScreenPresentationOptions (NSWindow window, NSApplicationPresentationOptions proposedOptions);

		[Export ("customWindowsToEnterFullScreenForWindow:"), DelegateName ("NSWindowWindows"), DefaultValue (null)]
		public extern NSWindow [] CustomWindowsToEnterFullScreen (NSWindow window);

		[Export ("customWindowsToExitFullScreenForWindow:"), DelegateName ("NSWindowWindows"), DefaultValue (null)]
		public extern NSWindow [] CustomWindowsToExitFullScreen (NSWindow window);

		[Export ("window:startCustomAnimationToEnterFullScreenWithDuration:"), EventArgs ("NSWindowDuration")]
		public extern void StartCustomAnimationToEnterFullScreen (NSWindow window, double duration);

		[Export ("window:startCustomAnimationToExitFullScreenWithDuration:"), EventArgs ("NSWindowDuration")]
		public extern void StartCustomAnimationToExitFullScreen (NSWindow window, double duration);

		[Export ("window:willEncodeRestorableState:"), EventArgs ("NSWindowCoder")]
		public extern void WillEncodeRestorableState (NSWindow window, NSCoder coder);

		[Export ("window:didDecodeRestorableState:"), EventArgs ("NSWindowCoder")]
		public extern void DidDecodeRestorableState (NSWindow window, NSCoder coder);

		//[Mac (13, 2)]
		[Export ("previewRepresentableActivityItemsForWindow:")]
		[return: NullAllowed]
		//[IgnoredInDelegate]
		public extern INSPreviewRepresentableActivityItem [] GetPreviewRepresentableActivityItems (NSWindow window);

		[Export ("window:willResizeForVersionBrowserWithMaxPreferredSize:maxAllowedSize:"), DelegateName ("NSWindowSizeSize"), DefaultValueFromArgument ("maxPreferredSize")]
		public extern CGSize WillResizeForVersionBrowser (NSWindow window, CGSize maxPreferredSize, CGSize maxAllowedSize);

		[Export ("windowWillEnterVersionBrowser:"), EventArgs ("NSNotification")]
		public extern void WillEnterVersionBrowser (NSNotification notification);

		[Export ("windowDidEnterVersionBrowser:"), EventArgs ("NSNotification")]
		public extern void DidEnterVersionBrowser (NSNotification notification);

		[Export ("windowWillExitVersionBrowser:"), EventArgs ("NSNotification")]
		public extern void WillExitVersionBrowser (NSNotification notification);

		[Export ("windowDidExitVersionBrowser:"), EventArgs ("NSNotification")]
		public extern void DidExitVersionBrowser (NSNotification notification);

		[Export ("windowDidChangeBackingProperties:"), EventArgs ("NSNotification")]
		public extern void DidChangeBackingProperties (NSNotification notification);

		//[Mac (15, 0)]
		[Export ("windowForSharingRequestFromWindow:"), DelegateName ("NSWindowNSWindow"), DefaultValue (null)]
		[return: NullAllowed]
		public extern NSWindow GetWindowForSharingRequest (NSWindow fromWindow);
	}

}