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
	//[NoMacCatalyst]
	//[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	public partial class NSTextBlock : NSCoding {
		[Export ("setValue:type:forDimension:")]
		public extern void SetValue (nfloat val, NSTextBlockValueType type, NSTextBlockDimension dimension);

		[Export ("valueForDimension:")]
		public extern nfloat GetValue (NSTextBlockDimension dimension);

		[Export ("valueTypeForDimension:")]
		public extern NSTextBlockValueType GetValueType (NSTextBlockDimension dimension);

		[Export ("setContentWidth:type:")]
		public extern void SetContentWidth (nfloat val, NSTextBlockValueType type);

		[Export ("contentWidth")]
		public extern nfloat ContentWidth { get; }

		[Export ("contentWidthValueType")]
		public extern NSTextBlockValueType ContentWidthValueType { get; }

		[Export ("setWidth:type:forLayer:edge:")]
		public extern void SetWidth (nfloat val, NSTextBlockValueType type, NSTextBlockLayer layer, NSRectEdge edge);

		[Export ("setWidth:type:forLayer:")]
		public extern void SetWidth (nfloat val, NSTextBlockValueType type, NSTextBlockLayer layer);

		[Export ("widthForLayer:edge:")]
		public extern nfloat GetWidth (NSTextBlockLayer layer, NSRectEdge edge);

		[Export ("widthValueTypeForLayer:edge:")]
		public extern NSTextBlockValueType WidthValueTypeForLayer (NSTextBlockLayer layer, NSRectEdge edge);

		[Export ("setBorderColor:forEdge:")]
		public extern void SetBorderColor (NSColor color, NSRectEdge edge);

		[Export ("setBorderColor:")]
		public extern void SetBorderColor (NSColor color);

		[Export ("borderColorForEdge:")]
		public extern NSColor GetBorderColor (NSRectEdge edge);

		[Export ("rectForLayoutAtPoint:inRect:textContainer:characterRange:")]
		public extern CGRect GetRectForLayout (CGPoint startingPoint, CGRect rect, NSTextContainer textContainer, NSRange charRange);

		[Export ("boundsRectForContentRect:inRect:textContainer:characterRange:")]
		public extern CGRect GetBoundsRect (CGRect contentRect, CGRect rect, NSTextContainer textContainer, NSRange charRange);

		[Export ("drawBackgroundWithFrame:inView:characterRange:layoutManager:")]
		public extern void DrawBackground (CGRect frameRect, NSView controlView, NSRange charRange, NSLayoutManager layoutManager);

		//Detected properties
		[Export ("verticalAlignment")]
		public extern NSTextBlockVerticalAlignment VerticalAlignment { get; set; }

		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		public extern NSColor BackgroundColor { get; set; }

	}
}