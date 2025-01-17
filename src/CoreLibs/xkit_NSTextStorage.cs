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

//using CGGlyph = System.UInt16;
using NSGlyph = System.UInt32;

#endregion

namespace AppKit
{
	/// <include file="../docs/api/UIKit/NSTextStorage.xml" path="/Documentation/Docs[@DocId='T:UIKit.NSTextStorage']/*" />
	[MacCatalyst(13, 1)]
	[BaseType(typeof(NSMutableAttributedString), Delegates = new string[] { "Delegate" },
		Events = new Type[] { typeof(NSTextStorageDelegate) })]
	public partial class NSTextStorage : NSCoding
	{
		[Export("initWithString:")]
		public extern NativeHandle Constructor(string str);

		[Export("layoutManagers")]
#if MONOMAC || NET
		public extern NSLayoutManager[] LayoutManagers { get; }
#else
		public extern NSObject [] LayoutManagers { get; }
#endif

		[Export("addLayoutManager:")]
		[PostGet("LayoutManagers")]
		public extern void AddLayoutManager(NSLayoutManager aLayoutManager);

		[Export("removeLayoutManager:")]
		[PostGet("LayoutManagers")]
		public extern void RemoveLayoutManager(NSLayoutManager aLayoutManager);

		[Export("editedMask")]
#if MONOMAC && !NET
		public extern NSTextStorageEditedFlags EditedMask {
#else
		NSTextStorageEditActions EditedMask
		{
#endif
			get;
#if !NET && !MONOMAC && !__MACCATALYST__
			[NotImplemented]
			set;
#endif
		}

		[Export("editedRange")] public extern NSRange EditedRange { get; }

		[Export("changeInLength")] public extern nint ChangeInLength { get; }

		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Assign)]
		public extern NSObject? WeakDelegate { get; set; }

		[Wrap("WeakDelegate")] public extern INSTextStorageDelegate Delegate { get; set; }

		[Export("edited:range:changeInLength:")]
#if MONOMAC && !NET
		public extern void Edited (nuint editedMask, NSRange editedRange, nint delta);
#else
		public extern void Edited(NSTextStorageEditActions editedMask, NSRange editedRange, nint delta);
#endif

		[Export("processEditing")]
		public extern void ProcessEditing();

		[Export("fixesAttributesLazily")] public extern bool FixesAttributesLazily { get; }

		[Export("invalidateAttributesInRange:")]
		public extern void InvalidateAttributes(NSRange range);

		[Export("ensureAttributesAreFixedInRange:")]
		public extern void EnsureAttributesAreFixed(NSRange range);

		[Notification, Field("NSTextStorageWillProcessEditingNotification")]
#if !MONOMAC || NET
		[Internal]
#endif
		public extern NSString WillProcessEditingNotification { get; }

		[Notification, Field("NSTextStorageDidProcessEditingNotification")]
#if !MONOMAC || NET
		[Internal]
#endif
		public extern NSString DidProcessEditingNotification { get; }

		//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed]
		[Export("textStorageObserver", ArgumentSemantic.Weak)]
		public extern INSTextStorageObserving? TextStorageObserver { get; set; }
	}


	/// <summary>Interface representing the required methods (if any) of the protocol <see cref="T:UIKit.NSTextStorageDelegate" />.</summary>
	///     <remarks>
	///       <para>This interface contains the required methods (if any) from the protocol defined by <see cref="T:UIKit.NSTextStorageDelegate" />.</para>
	///       <para>If developers create classes that implement this interface, the implementation methods will automatically be exported to Objective-C with the matching signature from the method defined in the <see cref="T:UIKit.NSTextStorageDelegate" /> protocol.</para>
	///       <para>Optional methods (if any) are provided by the <see cref="T:UIKit.NSTextStorageDelegate_Extensions" /> class as extension methods to the interface, allowing developers to invoke any optional methods on the protocol.</para>
	///     </remarks>
	public interface INSTextStorageDelegate { }
	
	public interface INSTextStorageObserving { }

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Protocol]
	public class NSTextStorageObserving {
		[Abstract]
		[NullAllowed, Export ("textStorage", ArgumentSemantic.Strong)]
		public extern NSTextStorage? TextStorage { get; set; }

		[Abstract]
		[Export ("processEditingForTextStorage:edited:range:changeInLength:invalidatedRange:")]
		public extern void ProcessEditing (NSTextStorage textStorage, NSTextStorageEditActions editMask, NSRange newCharRange, nint delta, NSRange invalidatedCharRange);

		[Abstract]
		[Export ("performEditingTransactionForTextStorage:usingBlock:")]
		public extern void PerformEditingTransaction (NSTextStorage textStorage, Action transaction);
	}
	

	/// <summary>A delegate object that provides events relating to processing editing for <see cref="T:UIKit.NSTextStorage" />.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/UIKit/Reference/NSTextStorageDelegate_Protocol_TextKit/index.html">Apple documentation for <c>NSTextStorageDelegate</c></related>
	[MacCatalyst (13, 1)]
	[Model]
	[BaseType (typeof (NSObject))]
	[Protocol]
	public partial class NSTextStorageDelegate {
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use WillProcessEditing instead.")]
		[Export ("textStorageWillProcessEditing:")]
		public extern void TextStorageWillProcessEditing (NSNotification notification);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use DidProcessEditing instead.")]
		[Export ("textStorageDidProcessEditing:")]
		public extern void TextStorageDidProcessEditing (NSNotification notification);

		[MacCatalyst (13, 1)]
		[Export ("textStorage:willProcessEditing:range:changeInLength:")]
		[EventArgs ("NSTextStorage")]
		public extern void WillProcessEditing (NSTextStorage textStorage, NSTextStorageEditActions editedMask, NSRange editedRange, nint delta);

		[MacCatalyst (13, 1)]
		[Export ("textStorage:didProcessEditing:range:changeInLength:")]
		[EventArgs ("NSTextStorage")]
		public extern void DidProcessEditing (NSTextStorage textStorage, NSTextStorageEditActions editedMask, NSRange editedRange, nint delta);
	}
}