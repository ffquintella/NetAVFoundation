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
//using CoreData;
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

//using CGGlyph = System.UInt16;
using NSGlyph = System.UInt32;

#endregion

namespace AppKit
{

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class NSLayoutManager : NSCoding {

#if !NET
		// This was removed in the headers in the macOS 10.11 SDK
		[NoiOS]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'TextStorage' instead.")]
		[Export ("attributedString")]
		NSAttributedString AttributedString { get; }
#endif

		[Export ("textContainers")]
		public extern NSTextContainer [] TextContainers { get; }

		[Export ("addTextContainer:")]
		public extern void AddTextContainer (NSTextContainer container);

		[Export ("insertTextContainer:atIndex:")]
		public extern void InsertTextContainer (NSTextContainer container, /* NSUInteger */ nint index);

		[Export ("removeTextContainerAtIndex:")]
		public extern void RemoveTextContainer (/* NSUInteger */ nint index);

		[Export ("textContainerChangedGeometry:")]
		public extern void TextContainerChangedGeometry (NSTextContainer container);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("textContainerChangedTextView:")]
		public extern void TextContainerChangedTextView (NSTextContainer container);

#if !NET
		// This was removed in the headers in the macOS 10.11 SDK
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("layoutOptions")]
		NSGlyphStorageOptions LayoutOptions { get; }
#endif

		[Export ("hasNonContiguousLayout")]
		public extern bool HasNonContiguousLayout { get; }

		/* InvalidateGlyphs */
#if NET || MONOMAC
		[Protected]
#else
		[Internal]
		[Sealed]
#endif
		[Export ("invalidateGlyphsForCharacterRange:changeInLength:actualCharacterRange:")]
		public extern void InvalidateGlyphs (NSRange characterRange, /* NSInteger */ nint delta, /* nullable NSRangePointer */ IntPtr actualCharacterRange);

		[Wrap ("InvalidateGlyphs (characterRange, delta, IntPtr.Zero)")]
		public extern void InvalidateGlyphs (NSRange characterRange, /* NSInteger */ nint delta);

#if NET || MONOMAC
		[Sealed]
#endif
		[Export ("invalidateGlyphsForCharacterRange:changeInLength:actualCharacterRange:")]
#if NET || MONOMAC
		public extern void InvalidateGlyphs (NSRange characterRange, /* NSInteger */ nint delta, /* nullable NSRangePointer */ out NSRange actualCharacterRange);
#else
		public extern void InvalidateGlyphs (NSRange charRange, /* NSInteger */ nint delta, /* nullable NSRangePointer */ out NSRange actualCharRange);
#endif

		/* InvalidateLayout */
#if NET || MONOMAC
		[Protected]
#else
		[Internal]
		[Sealed]
#endif
		[Export ("invalidateLayoutForCharacterRange:actualCharacterRange:")]
		public extern void InvalidateLayout (NSRange characterRange, /* nullable NSRangePointer */ IntPtr actualCharacterRange);

		[Wrap ("InvalidateLayout (characterRange, IntPtr.Zero)")]
		public extern void InvalidateLayout (NSRange characterRange);

#if NET || MONOMAC
		[Sealed]
#endif
		[Export ("invalidateLayoutForCharacterRange:actualCharacterRange:")]
#if NET || MONOMAC
		public extern void InvalidateLayout (NSRange characterRange, /* nullable NSRangePointer */ out NSRange actualCharacterRange);
#else
		public extern void InvalidateLayout (NSRange charRange, /* nullable NSRangePointer */ out NSRange actualCharRange);
#endif

		[Export ("invalidateDisplayForCharacterRange:")]
#if NET
		public extern void InvalidateDisplayForCharacterRange (NSRange characterRange);
#else
		public extern void InvalidateDisplayForCharacterRange (NSRange charRange);
#endif

		[Export ("invalidateDisplayForGlyphRange:")]
		public extern void InvalidateDisplayForGlyphRange (NSRange glyphRange);

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use ProcessEditing (NSTextStorage textStorage, NSTextStorageEditActions editMask, NSRange newCharacterRange, nint delta, NSRange invalidatedCharacterRange) instead).")]
		[Export ("textStorage:edited:range:changeInLength:invalidatedRange:")]
		public extern void TextStorageEdited (NSTextStorage str, NSTextStorageEditedFlags editedMask, NSRange newCharRange, nint changeInLength, NSRange invalidatedCharRange);
#endif

		[Export ("ensureGlyphsForCharacterRange:")]
#if NET
		public extern void EnsureGlyphsForCharacterRange (NSRange characterRange);
#else
		public extern void EnsureGlyphsForCharacterRange (NSRange charRange);
#endif

		[Export ("ensureGlyphsForGlyphRange:")]
		public extern void EnsureGlyphsForGlyphRange (NSRange glyphRange);

		[Export ("ensureLayoutForCharacterRange:")]
#if NET
		public extern void EnsureLayoutForCharacterRange (NSRange characterRange);
#else
		public extern void EnsureLayoutForCharacterRange (NSRange charRange);
#endif

		[Export ("ensureLayoutForGlyphRange:")]
		public extern void EnsureLayoutForGlyphRange (NSRange glyphRange);

		[Export ("ensureLayoutForTextContainer:")]
		public extern void EnsureLayoutForTextContainer (NSTextContainer container);

		[Export ("ensureLayoutForBoundingRect:inTextContainer:")]
		public extern void EnsureLayoutForBoundingRect (CGRect bounds, NSTextContainer container);

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'SetGlyphs' instead.")]
		[Export ("insertGlyph:atGlyphIndex:characterIndex:")]
		public extern void InsertGlyph (NSGlyph glyph, nint glyphIndex, nint charIndex);
#endif

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'SetGlyphs' instead.")]
		[Export ("replaceGlyphAtIndex:withGlyph:")]
		public extern void ReplaceGlyphAtIndex (nint glyphIndex, NSGlyph newGlyph);
#endif

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'SetGlyphs' instead.")]
		[Export ("deleteGlyphsInRange:")]
		public extern void DeleteGlyphs (NSRange glyphRange);
#endif

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'SetGlyphs' instead.")]
		[Export ("setCharacterIndex:forGlyphAtIndex:")]
		public extern void SetCharacterIndex (nint charIndex, nint glyphIndex);
#endif

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'SetGlyphs' instead.")]
		[Export ("setIntAttribute:value:forGlyphAtIndex:")]
		public extern void SetIntAttribute (nint attributeTag, nint value, nint glyphIndex);
#endif

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'SetGlyphs' instead.")]
		[Export ("invalidateGlyphsOnLayoutInvalidationForGlyphRange:")]
		public extern void InvalidateGlyphsOnLayoutInvalidation (NSRange glyphRange);
#endif

		[Export ("numberOfGlyphs")]
#if NET || !MONOMAC
		/* NSUInteger */
		public extern nuint NumberOfGlyphs { get; }
#else
		public extern /* NSUInteger */ nint NumberOfGlyphs { get; }
#endif

		[Export ("glyphAtIndex:isValidIndex:")]
		//[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'GetCGGlyph' instead).")]
		//[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'GetGlyph' instead.")]
		//[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'GetGlyph' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'GetGlyph' instead.")]
#if MONOMAC
#if NET
		public extern NSGlyph GlyphAtIndex (nuint glyphIndex, ref bool isValidIndex);
#else
		public extern NSGlyph GlyphAtIndex (nint glyphIndex, ref bool isValidIndex);
#endif
#else
		public extern CGGlyph GlyphAtIndex (nuint glyphIndex, ref bool isValidIndex);
#endif // MONOMAC

		[Export ("glyphAtIndex:")]
		//[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'GetCGGlyph' instead).")]
		//[Deprecated (PlatformName.iOS, 9, 0, message: "Use 'GetGlyph' instead.")]
		//[Deprecated (PlatformName.TvOS, 9, 0, message: "Use 'GetGlyph' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'GetGlyph' instead.")]
#if MONOMAC
#if NET
		public extern NSGlyph GlyphAtIndex (nuint glyphIndex);
#else
		public extern NSGlyph GlyphAtIndex (nint glyphIndex);
#endif
#else
		public extern CGGlyph GlyphAtIndex (nuint glyphIndex);
#endif // MONOMAC

		[Export ("isValidGlyphIndex:")]
#if NET
		public extern bool IsValidGlyph (nuint glyphIndex);
#elif MONOMAC
		public extern bool IsValidGlyphIndex (nint glyphIndex);
#else
		public extern bool IsValidGlyphIndex (nuint glyphIndex);
#endif

		[Export ("characterIndexForGlyphAtIndex:")]
#if NET
		public extern nuint GetCharacterIndex (nuint glyphIndex);
#elif MONOMAC
		public extern nuint CharacterIndexForGlyphAtIndex (nint glyphIndex);
#else
		public extern nuint CharacterIndexForGlyphAtIndex (nuint glyphIndex);
#endif

		[Export ("glyphIndexForCharacterAtIndex:")]
#if NET
		public extern nuint GetGlyphIndex (nuint characterIndex);
#elif MONOMAC
		public extern nuint GlyphIndexForCharacterAtIndex (nint charIndex);
#else
		public extern nuint GlyphIndexForCharacterAtIndex (nuint charIndex);
#endif

#if !NET
		[NoiOS]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use 'GetGlyphs' instead).")]
		[Export ("intAttribute:forGlyphAtIndex:")]
		public extern nint GetIntAttribute (nint attributeTag, nint glyphIndex);
#endif

		[Export ("setTextContainer:forGlyphRange:")]
#if NET || !MONOMAC
		public extern void SetTextContainer (NSTextContainer container, NSRange glyphRange);
#else
		public extern void SetTextContainerForRange (NSTextContainer container, NSRange glyphRange);
#endif

		[Export ("setLineFragmentRect:forGlyphRange:usedRect:")]
#if NET
		public extern void SetLineFragment (CGRect fragmentRect, NSRange glyphRange, CGRect usedRect);
#else
		public extern void SetLineFragmentRect (CGRect fragmentRect, NSRange glyphRange, CGRect usedRect);
#endif

		[Export ("setExtraLineFragmentRect:usedRect:textContainer:")]
#if NET
		public extern void SetExtraLineFragment (CGRect fragmentRect, CGRect usedRect, NSTextContainer container);
#else
		public extern void SetExtraLineFragmentRect (CGRect fragmentRect, CGRect usedRect, NSTextContainer container);
#endif

		[Export ("setLocation:forStartOfGlyphRange:")]
#if MONOMAC || NET
		public extern void SetLocation (CGPoint location, NSRange forStartOfGlyphRange);
#else
		public extern void SetLocation (CGPoint location, NSRange glyphRange);
#endif

		[Export ("setNotShownAttribute:forGlyphAtIndex:")]
#if NET || !MONOMAC
		public extern void SetNotShownAttribute (bool flag, nuint glyphIndex);
#else
		public extern void SetNotShownAttribute (bool flag, nint glyphIndex);
#endif

		[Export ("setDrawsOutsideLineFragment:forGlyphAtIndex:")]
#if NET || !MONOMAC
		public extern void SetDrawsOutsideLineFragment (bool flag, nuint glyphIndex);
#else
		public extern void SetDrawsOutsideLineFragment (bool flag, nint glyphIndex);
#endif

		[Export ("setAttachmentSize:forGlyphRange:")]
		public extern void SetAttachmentSize (CGSize attachmentSize, NSRange glyphRange);

		[Export ("getFirstUnlaidCharacterIndex:glyphIndex:")]
#if NET
		public extern void GetFirstUnlaidCharacterIndex (out nuint characterIndex, out nuint glyphIndex);
#else
		public extern void GetFirstUnlaidCharacterIndex (ref nuint charIndex, ref nuint glyphIndex);
#endif

		[Export ("firstUnlaidCharacterIndex")]
#if NET || !MONOMAC
		public extern nuint FirstUnlaidCharacterIndex { get; }
#else
		public extern nint FirstUnlaidCharacterIndex { get; }
#endif

		[Export ("firstUnlaidGlyphIndex")]
#if NET || !MONOMAC
		public extern nuint FirstUnlaidGlyphIndex { get; }
#else
		public extern nint FirstUnlaidGlyphIndex { get; }
#endif

		/* GetTextContainer */
#if NET || MONOMAC
		[Protected]
#else
		[Sealed]
		[Internal]
#endif
		[return: NullAllowed]
		[Export ("textContainerForGlyphAtIndex:effectiveRange:")]
		public extern NSTextContainer GetTextContainer (nuint glyphIndex, /* nullable NSRangePointer */ IntPtr effectiveGlyphRange);

		[return: NullAllowed]
		[Wrap ("GetTextContainer (glyphIndex, IntPtr.Zero)")]
		public extern NSTextContainer GetTextContainer (nuint glyphIndex);

#if NET || MONOMAC
		[Sealed]
#endif
		[return: NullAllowed]
		[Export ("textContainerForGlyphAtIndex:effectiveRange:")]
		public extern NSTextContainer GetTextContainer (nuint glyphIndex, /* nullable NSRangePointer */ out NSRange effectiveGlyphRange);

#if NET || MONOMAC
		[Protected]
#else
		[Sealed]
		[Internal]
#endif
		[return: NullAllowed]
		[Export ("textContainerForGlyphAtIndex:effectiveRange:withoutAdditionalLayout:")]
		public extern NSTextContainer GetTextContainer (nuint glyphIndex, IntPtr effectiveGlyphRange, bool withoutAdditionalLayout);

		[return: NullAllowed]
		[Wrap ("GetTextContainer (glyphIndex, IntPtr.Zero, flag)")]
		public extern NSTextContainer GetTextContainer (nuint glyphIndex, bool flag);

#if NET || MONOMAC
		[Sealed]
#endif
		[return: NullAllowed]
		[Export ("textContainerForGlyphAtIndex:effectiveRange:withoutAdditionalLayout:")]
		public extern NSTextContainer GetTextContainer (nuint glyphIndex, /* nullable NSRangePointer */ out NSRange effectiveGlyphRange, bool withoutAdditionalLayout);

		[Export ("usedRectForTextContainer:")]
#if NET
		public extern CGRect GetUsedRect (NSTextContainer container);
#else
		public extern CGRect GetUsedRectForTextContainer (NSTextContainer container);
#endif

		/* GetLineFragmentRect (NSUInteger, NSRangePointer) */
		[Protected]
		[Export ("lineFragmentRectForGlyphAtIndex:effectiveRange:")]
		public extern CGRect GetLineFragmentRect (nuint glyphIndex, /* nullable NSRangePointer */ IntPtr effectiveGlyphRange);

		[Wrap ("GetLineFragmentRect (glyphIndex, IntPtr.Zero)")]
		public extern CGRect GetLineFragmentRect (nuint glyphIndex);

		[Sealed]
		[Export ("lineFragmentRectForGlyphAtIndex:effectiveRange:")]
		public extern CGRect GetLineFragmentRect (nuint glyphIndex, out /* nullable NSRangePointer */ NSRange effectiveGlyphRange);

		/* GetLineFragmentRect (NSUInteger, NSRangePointer, bool) */
		[MacCatalyst (13, 1)]
#if MONOMAC || NET
		[Protected]
#else
		[Sealed]
		[Internal]
#endif
		[Export ("lineFragmentRectForGlyphAtIndex:effectiveRange:withoutAdditionalLayout:")]
		public extern CGRect GetLineFragmentRect (nuint glyphIndex, /* nullable NSRangePointer */ IntPtr effectiveGlyphRange, bool withoutAdditionalLayout);

		[MacCatalyst (13, 1)]
		[Wrap ("GetLineFragmentRect (glyphIndex, IntPtr.Zero)")]
		public extern CGRect GetLineFragmentRect (nuint glyphIndex, bool withoutAdditionalLayout);

		[MacCatalyst (13, 1)]
#if MONOMAC || NET
		[Sealed]
#endif
		[Export ("lineFragmentRectForGlyphAtIndex:effectiveRange:withoutAdditionalLayout:")]
		public extern CGRect GetLineFragmentRect (nuint glyphIndex, out /* nullable NSRangePointer */ NSRange effectiveGlyphRange, bool withoutAdditionalLayout);

		/* GetLineFragmentUsedRect (NSUInteger, NSRangePointer) */
		[Protected]
		[Export ("lineFragmentUsedRectForGlyphAtIndex:effectiveRange:")]
		public extern CGRect GetLineFragmentUsedRect (nuint glyphIndex, /* nullable NSRangePointer */ IntPtr effectiveGlyphRange);

		[Wrap ("GetLineFragmentUsedRect (glyphIndex, IntPtr.Zero)")]
		public extern CGRect GetLineFragmentUsedRect (nuint glyphIndex);

		[Sealed]
		[Export ("lineFragmentUsedRectForGlyphAtIndex:effectiveRange:")]
		public extern CGRect GetLineFragmentUsedRect (nuint glyphIndex, out /* nullable NSRangePointer */ NSRange effectiveGlyphRange);

		/* GetLineFragmentUsedRect (NSUInteger, NSRangePointer, bool) */
		[MacCatalyst (13, 1)]
#if MONOMAC || NET
		[Protected]
#else
		[Sealed]
		[Internal]
#endif
		[Export ("lineFragmentUsedRectForGlyphAtIndex:effectiveRange:withoutAdditionalLayout:")]
		public extern CGRect GetLineFragmentUsedRect (nuint glyphIndex, /* nullable NSRangePointer */ IntPtr effectiveGlyphRange, bool withoutAdditionalLayout);

		[MacCatalyst (13, 1)]
		[Wrap ("GetLineFragmentUsedRect (glyphIndex, IntPtr.Zero)")]
		public extern CGRect GetLineFragmentUsedRect (nuint glyphIndex, bool withoutAdditionalLayout);

		[MacCatalyst (13, 1)]
#if MONOMAC || NET
		[Sealed]
#endif
		[Export ("lineFragmentUsedRectForGlyphAtIndex:effectiveRange:withoutAdditionalLayout:")]
		public extern CGRect GetLineFragmentUsedRect (nuint glyphIndex, out /* nullable NSRangePointer */ NSRange effectiveGlyphRange, bool withoutAdditionalLayout);

		[Export ("extraLineFragmentRect")]
		public extern CGRect ExtraLineFragmentRect { get; }

		[Export ("extraLineFragmentUsedRect")]
		public extern CGRect ExtraLineFragmentUsedRect { get; }

		[Export ("extraLineFragmentTextContainer")]
		public extern NSTextContainer ExtraLineFragmentTextContainer { get; }

		[Export ("locationForGlyphAtIndex:")]
#if NET
		public extern CGPoint GetLocationForGlyph (nuint glyphIndex);
#elif MONOMAC
		public extern CGPoint LocationForGlyphAtIndex (nint glyphIndex);
#else
		public extern CGPoint LocationForGlyphAtIndex (nuint glyphIndex);
#endif

		[Export ("notShownAttributeForGlyphAtIndex:")]
#if NET
		public extern bool IsNotShownAttributeForGlyph (nuint glyphIndex);
#elif MONOMAC
		public extern bool NotShownAttributeForGlyphAtIndex (nint glyphIndex);
#else
		public extern bool NotShownAttributeForGlyphAtIndex (nuint glyphIndex);
#endif

		[Export ("drawsOutsideLineFragmentForGlyphAtIndex:")]
#if NET
		public extern bool DrawsOutsideLineFragmentForGlyph (nuint glyphIndex);
#elif MONOMAC
		public extern bool DrawsOutsideLineFragmentForGlyphAt (nint glyphIndex);
#else
		public extern bool DrawsOutsideLineFragmentForGlyphAtIndex (nuint glyphIndex);
#endif

		[Export ("attachmentSizeForGlyphAtIndex:")]
#if NET
		public extern CGSize GetAttachmentSizeForGlyph (nuint glyphIndex);
#elif MONOMAC
		public extern CGSize AttachmentSizeForGlyphAt (nint glyphIndex);
#else
		public extern CGSize AttachmentSizeForGlyphAtIndex (nuint glyphIndex);
#endif

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("setLayoutRect:forTextBlock:glyphRange:")]
		public extern void SetLayoutRect (CGRect layoutRect, NSTextBlock forTextBlock, NSRange glyphRange);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("setBoundsRect:forTextBlock:glyphRange:")]
		public extern 	void SetBoundsRect (CGRect boundsRect, NSTextBlock forTextBlock, NSRange glyphRange);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("layoutRectForTextBlock:glyphRange:")]
#if NET
		public extern CGRect GetLayoutRect (NSTextBlock block, NSRange glyphRange);
#else
		public extern CGRect LayoutRect (NSTextBlock block, NSRange glyphRange);
#endif

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("boundsRectForTextBlock:glyphRange:")]
#if NET
		public extern CGRect GetBoundsRect (NSTextBlock block, NSRange glyphRange);
#else
		public extern CGRect BoundsRect (NSTextBlock block, NSRange glyphRange);
#endif

		/* GetLayoutRect (NSTextBlock, NSUInteger, nullable NSRangePointer) */

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Protected]
		[Export ("layoutRectForTextBlock:atIndex:effectiveRange:")]
		public extern CGRect GetLayoutRect (NSTextBlock block, nuint glyphIndex, IntPtr effectiveGlyphRange);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Wrap ("GetLayoutRect (block, glyphIndex, IntPtr.Zero)")]
		public extern CGRect GetLayoutRect (NSTextBlock block, nuint glyphIndex);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Sealed]
		[Export ("layoutRectForTextBlock:atIndex:effectiveRange:")]
		public extern CGRect GetLayoutRect (NSTextBlock block, nuint glyphIndex, out NSRange effectiveGlyphRange);

		/* GetBoundsRect (NSTextBlock, NSUInteger, nullable NSRangePointer) */

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Protected]
		[Export ("boundsRectForTextBlock:atIndex:effectiveRange:")]
		public extern CGRect GetBoundsRect (NSTextBlock block, nuint glyphIndex, IntPtr effectiveGlyphRange);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Wrap ("GetBoundsRect (block, glyphIndex, IntPtr.Zero)")]
		public extern CGRect GetBoundsRect (NSTextBlock block, nuint glyphIndex);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Sealed]
		[Export ("boundsRectForTextBlock:atIndex:effectiveRange:")]
		public extern CGRect GetBoundsRect (NSTextBlock block, nuint glyphIndex, out NSRange effectiveGlyphRange);

		/* GetGlyphRange (NSRange, nullable NSRangePointer) */

#if NET || !MONOMAC
		[Protected]
#else
		[Internal][Sealed]
#endif
		[Export ("glyphRangeForCharacterRange:actualCharacterRange:")]
		public extern NSRange GetGlyphRange (NSRange characterRange, IntPtr actualCharacterRange);

		[Wrap ("GetGlyphRange (characterRange, IntPtr.Zero)")]
		public extern NSRange GetGlyphRange (NSRange characterRange);

		[Sealed]
		[Export ("glyphRangeForCharacterRange:actualCharacterRange:")]
		public extern NSRange GetGlyphRange (NSRange characterRange, out NSRange actualCharacterRange);

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Obsolete ("Use 'GetGlyphRange' instead.")]
		[Export ("glyphRangeForCharacterRange:actualCharacterRange:")]
		public extern NSRange GlyphRangeForCharacterRange (NSRange charRange, out NSRange actualCharRange);
#endif

		/* GetCharacterRange (NSRange, nullable NSRangePointer) */
#if NET || !MONOMAC
		[Protected]
#else
		[Internal][Sealed]
#endif
		[Export ("characterRangeForGlyphRange:actualGlyphRange:")]
		public extern NSRange GetCharacterRange (NSRange glyphRange, IntPtr actualGlyphRange);

		[Wrap ("GetCharacterRange (glyphRange, IntPtr.Zero)")]
		public extern NSRange GetCharacterRange (NSRange glyphRange);

		[Sealed]
		[Export ("characterRangeForGlyphRange:actualGlyphRange:")]
		public extern NSRange GetCharacterRange (NSRange glyphRange, out NSRange actualGlyphRange);

#if MONOMAC && !NET
		[Obsolete ("Use 'GetCharacterRange' instead.")]
		[Export ("characterRangeForGlyphRange:actualGlyphRange:")]
		NSRange CharacterRangeForGlyphRange (NSRange glyphRange, out NSRange actualGlyphRange);
#endif

		[Export ("glyphRangeForTextContainer:")]
		public extern NSRange GetGlyphRange (NSTextContainer container);

		[Export ("rangeOfNominallySpacedGlyphsContainingIndex:")]
#if NET
		public extern NSRange GetRangeOfNominallySpacedGlyphsContainingIndex (nuint glyphIndex);
#elif MONOMAC
		NSRange RangeOfNominallySpacedGlyphsContainingIndex (nint glyphIndex);
#else
		NSRange RangeOfNominallySpacedGlyphsContainingIndex (nuint glyphIndex);
#endif

		[Internal]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("rectArrayForGlyphRange:withinSelectedGlyphRange:inTextContainer:rectCount:")]
		[Deprecated (PlatformName.MacOSX, 10, 11)]
		public extern IntPtr GetRectArray (NSRange glyphRange, NSRange selectedGlyphRange, IntPtr textContainerHandle, out nuint rectCount);

		[Export ("boundingRectForGlyphRange:inTextContainer:")]
#if NET
		public extern CGRect GetBoundingRect (NSRange glyphRange, NSTextContainer container);
#else
		public extern CGRect BoundingRectForGlyphRange (NSRange glyphRange, NSTextContainer container);
#endif

		[Export ("glyphRangeForBoundingRect:inTextContainer:")]
#if NET
		public extern NSRange GetGlyphRangeForBoundingRect (CGRect bounds, NSTextContainer container);
#else
		public extern NSRange GlyphRangeForBoundingRect (CGRect bounds, NSTextContainer container);
#endif

		[Export ("glyphRangeForBoundingRectWithoutAdditionalLayout:inTextContainer:")]
#if NET
		public extern NSRange GetGlyphRangeForBoundingRectWithoutAdditionalLayout (CGRect bounds, NSTextContainer container);
#else
		public extern NSRange GlyphRangeForBoundingRectWithoutAdditionalLayout (CGRect bounds, NSTextContainer container);
#endif

		[Export ("glyphIndexForPoint:inTextContainer:fractionOfDistanceThroughGlyph:")]
#if NET
		public extern nuint GetGlyphIndex (CGPoint point, NSTextContainer container, /* nullable CGFloat */ out nfloat fractionOfDistanceThroughGlyph);
#elif MONOMAC
		public extern nuint GlyphIndexForPointInTextContainer (CGPoint point, NSTextContainer container, ref nfloat fractionOfDistanceThroughGlyph);
#else
		public extern nuint GlyphIndexForPoint (CGPoint point, NSTextContainer container, ref nfloat partialFraction);
#endif

		[Export ("glyphIndexForPoint:inTextContainer:")]
#if NET
		public extern nuint GetGlyphIndex (CGPoint point, NSTextContainer container);
#else
		public extern nuint GlyphIndexForPoint (CGPoint point, NSTextContainer container);
#endif

		[Export ("fractionOfDistanceThroughGlyphForPoint:inTextContainer:")]
#if NET
		public extern nfloat GetFractionOfDistanceThroughGlyph (CGPoint point, NSTextContainer container);
#else
		public extern nfloat FractionOfDistanceThroughGlyphForPoint (CGPoint point, NSTextContainer container);
#endif

		// GetCharacterIndex (CGPoint, NSTextContainer, nullable CGFloat*)
#if NET
		[Protected]
#else
		[Sealed]
		[Internal]
#endif
		[Export ("characterIndexForPoint:inTextContainer:fractionOfDistanceBetweenInsertionPoints:")]
		protected extern nuint GetCharacterIndex (CGPoint point, NSTextContainer container, IntPtr fractionOfDistanceBetweenInsertionPoints);

		[Wrap ("GetCharacterIndex (point, container, IntPtr.Zero)")]
		public extern nuint GetCharacterIndex (CGPoint point, NSTextContainer container);

		[Sealed]
		[Export ("characterIndexForPoint:inTextContainer:fractionOfDistanceBetweenInsertionPoints:")]
		public extern nuint GetCharacterIndex (CGPoint point, NSTextContainer container, out nfloat fractionOfDistanceBetweenInsertionPoints);

#if !NET
		[Obsolete ("Use 'GetCharacterIndex' instead.")]
		[Export ("characterIndexForPoint:inTextContainer:fractionOfDistanceBetweenInsertionPoints:")]
#if MONOMAC
		public extern nuint CharacterIndexForPoint (CGPoint point, NSTextContainer container, ref nfloat fractionOfDistanceBetweenInsertionPoints);
#else
		public extern nuint CharacterIndexForPoint (CGPoint point, NSTextContainer container, ref nfloat partialFraction);
#endif
#endif

#if NET || !MONOMAC
		[Protected]
#endif
		[Export ("getLineFragmentInsertionPointsForCharacterAtIndex:alternatePositions:inDisplayOrder:positions:characterIndexes:")]
#if NET || !MONOMAC
		public extern nuint GetLineFragmentInsertionPoints (nuint characterIndex, bool alternatePositions, bool inDisplayOrder, IntPtr positions, IntPtr characterIndexes);
#else
		public extern nuint GetLineFragmentInsertionPoints (nuint charIndex, bool aFlag, bool dFlag, IntPtr positions, IntPtr charIndexes);
#endif

		/* GetTemporaryAttributes (NSUInteger, nullable NSRangePointer) */

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Protected]
		[Export ("temporaryAttributesAtCharacterIndex:effectiveRange:")]
		public extern NSDictionary<NSString, NSObject> GetTemporaryAttributes (nuint characterIndex, IntPtr effectiveCharacterRange);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Wrap ("GetTemporaryAttributes (characterIndex, IntPtr.Zero)")]
		public extern NSDictionary<NSString, NSObject> GetTemporaryAttributes (nuint characterIndex);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Sealed]
		[Export ("temporaryAttributesAtCharacterIndex:effectiveRange:")]
		public extern NSDictionary<NSString, NSObject> GetTemporaryAttributes (nuint characterIndex, out NSRange effectiveCharacterRange);

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("setTemporaryAttributes:forCharacterRange:")]
		public extern void SetTemporaryAttributes (NSDictionary attrs, NSRange charRange);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("addTemporaryAttributes:forCharacterRange:")]
#if NET
		public extern void AddTemporaryAttributes (NSDictionary<NSString, NSObject> attributes, NSRange characterRange);
#else
		public extern void AddTemporaryAttributes (NSDictionary attrs, NSRange charRange);
#endif

		// This API can take an NSString or managed string, but some related API
		// takes a generic dictionary that can't use a managed string, so for symmetry
		// provide an NSString overload as well.
#if !NET
		[Sealed]
#endif
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("removeTemporaryAttribute:forCharacterRange:")]
		public extern void RemoveTemporaryAttribute (NSString attributeName, NSRange characterRange);

#if NET
		[Sealed]
#endif
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("removeTemporaryAttribute:forCharacterRange:")]
#if NET
		public extern void RemoveTemporaryAttribute (string attributeName, NSRange characterRange);
#else
		public extern void RemoveTemporaryAttribute (string attrName, NSRange charRange);
#endif

		/* GetTemporaryAttribute (NSString, NSUInteger, nullable NSRangePointer) */
		[Protected]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("temporaryAttribute:atCharacterIndex:effectiveRange:")]
		public extern NSObject GetTemporaryAttribute (NSString attributeName, nuint characterIndex, /* nullable NSRangePointer */ IntPtr effectiveRange);

		[Wrap ("GetTemporaryAttribute (attributeName, characterIndex, IntPtr.Zero)")]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		public extern NSObject GetTemporaryAttribute (NSString attributeName, nuint characterIndex);

		[Sealed]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("temporaryAttribute:atCharacterIndex:effectiveRange:")]
		public extern NSObject GetTemporaryAttribute (NSString attributeName, nuint characterIndex, /* nullable NSRangePointer */ out NSRange effectiveRange);

		/* GetTemporaryAttribute (NSString, NSUInteger, nullable NSRangePointer, NSRange) */

		[Protected]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("temporaryAttribute:atCharacterIndex:longestEffectiveRange:inRange:")]
		public extern NSObject GetTemporaryAttribute (NSString attributeName, nuint characterIndex, /* nullable NSRangePointer */ IntPtr longestEffectiveRange, NSRange rangeLimit);

		[Wrap ("GetTemporaryAttribute (attributeName, characterIndex, IntPtr.Zero, rangeLimit)")]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		public extern NSObject GetTemporaryAttribute (NSString attributeName, nuint characterIndex, NSRange rangeLimit);

		[Sealed]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("temporaryAttribute:atCharacterIndex:longestEffectiveRange:inRange:")]
		public extern NSObject GetTemporaryAttribute (NSString attributeName, nuint characterIndex, /* nullable NSRangePointer */ out NSRange longestEffectiveRange, NSRange rangeLimit);

		/* GetTemporaryAttributes (NSUInteger, nullable NSRangePointer, NSRange) */

		[Protected]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("temporaryAttributesAtCharacterIndex:longestEffectiveRange:inRange:")]
		protected extern NSDictionary<NSString, NSObject> GetTemporaryAttributes (nuint characterIndex, /* nullable NSRangePointer */ IntPtr longestEffectiveRange, NSRange rangeLimit);

		[Wrap ("GetTemporaryAttributes (characterIndex, IntPtr.Zero, rangeLimit)")]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		public extern NSDictionary<NSString, NSObject> GetTemporaryAttributes (nuint characterIndex, NSRange rangeLimit);

		[Sealed]
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("temporaryAttributesAtCharacterIndex:longestEffectiveRange:inRange:")]
		public extern NSDictionary<NSString, NSObject> GetTemporaryAttributes (nuint characterIndex, /* nullable NSRangePointer */ out NSRange longestEffectiveRange, NSRange rangeLimit);

		// This method can take an NSString or managed string, but some related API
		// takes a generic dictionary that can't use a managed string, so for symmetry
		// provide an NSString overload as well.
#if !NET
		[Sealed]
#endif
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("addTemporaryAttribute:value:forCharacterRange:")]
		public extern void AddTemporaryAttribute (NSString attributeName, NSObject value, NSRange characterRange);

#if NET
		[Sealed]
#endif
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("addTemporaryAttribute:value:forCharacterRange:")]
#if NET
		public extern void AddTemporaryAttribute (string attributeName, NSObject value, NSRange characterRange);
#else
		public extern void AddTemporaryAttribute (string attrName, NSObject value, NSRange charRange);
#endif

#if !NET
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("substituteFontForFont:")]
		public extern NSFont SubstituteFontForFont (NSFont originalFont);
#endif

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("defaultLineHeightForFont:")]
#if NET
		public extern nfloat GetDefaultLineHeight (NSFont font);
#else
		public extern nfloat DefaultLineHeightForFont (NSFont theFont);
#endif

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("defaultBaselineOffsetForFont:")]
#if NET
		public extern nfloat GetDefaultBaselineOffset (NSFont font);
#else
		public extern nfloat DefaultBaselineOffsetForFont (NSFont theFont);
#endif

		[NullAllowed]
		[Export ("textStorage", ArgumentSemantic.Assign)]
		public extern NSTextStorage TextStorage { get; set; }

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("glyphGenerator", ArgumentSemantic.Retain)]
		public extern NSGlyphGenerator GlyphGenerator { get; set; }

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("typesetter", ArgumentSemantic.Retain)]
		public extern NSTypesetter Typesetter { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		public extern NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDelegate")]
		public extern INSLayoutManagerDelegate Delegate { get; set; }

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("backgroundLayoutEnabled")]
		public extern bool BackgroundLayoutEnabled { get; set; }

		[NoiOS]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[NoMacCatalyst]
		[Export ("usesScreenFonts")]
		public extern bool UsesScreenFonts { get; set; }

		[Export ("showsInvisibleCharacters")]
		public extern bool ShowsInvisibleCharacters { get; set; }

		[Export ("showsControlCharacters")]
		public extern bool ShowsControlCharacters { get; set; }

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Please use 'UsesDefaultHyphenation' or 'NSParagraphStyle.HyphenationFactor' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Please use 'UsesDefaultHyphenation' or 'NSParagraphStyle.HyphenationFactor' instead.")]
	//	[Deprecated (PlatformName.TvOS, 13, 0, message: "Please use 'UsesDefaultHyphenation' or 'NSParagraphStyle.HyphenationFactor' instead.")]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Please use 'UsesDefaultHyphenation' or 'NSParagraphStyle.HyphenationFactor' instead.")]
		[Export ("hyphenationFactor")]
#if MONOMAC
		public extern float HyphenationFactor { get; set; } /* This is defined as float in AppKit headers. */
#else
		public extern nfloat HyphenationFactor { get; set; } /* This is defined as CGFloat in UIKit headers. */
#endif

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("defaultAttachmentScaling")]
		public extern NSImageScaling DefaultAttachmentScaling { get; set; }

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("typesetterBehavior")]
		public extern NSTypesetterBehavior TypesetterBehavior { get; set; }

		[Export ("allowsNonContiguousLayout")]
		public extern bool AllowsNonContiguousLayout { get; set; }

		[Export ("usesFontLeading")]
		public extern bool UsesFontLeading { get; set; }

		[Export ("drawBackgroundForGlyphRange:atPoint:")]
#if NET
		public extern void DrawBackground (NSRange glyphsToShow, CGPoint origin);
#else
		public extern void DrawBackgroundForGlyphRange (NSRange glyphsToShow, CGPoint origin);
#endif

		[Export ("drawGlyphsForGlyphRange:atPoint:")]
#if NET || !MONOMAC
		public extern void DrawGlyphs (NSRange glyphsToShow, CGPoint origin);
#else
		public extern void DrawGlyphsForGlyphRange (NSRange glyphsToShow, CGPoint origin);
#endif

		[Protected] // Class can be subclassed, and most methods can be overridden.
		[MacCatalyst (13, 1)]
		[Export ("getGlyphsInRange:glyphs:properties:characterIndexes:bidiLevels:")]
		public extern nuint GetGlyphs (NSRange glyphRange, IntPtr glyphBuffer, IntPtr properties, IntPtr characterIndexBuffer, IntPtr bidiLevelBuffer);

#if !NET && !MONOMAC
		[Sealed]
#endif
		[MacCatalyst (13, 1)]
		[Export ("propertyForGlyphAtIndex:")]
		public extern NSGlyphProperty GetProperty (nuint glyphIndex);

#if !NET && !MONOMAC
		[Obsolete ("Use 'GetProperty' instead.")]
		[Export ("propertyForGlyphAtIndex:")]
		public extern NSGlyphProperty PropertyForGlyphAtIndex (nuint glyphIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("CGGlyphAtIndex:isValidIndex:")]
#if NET
		public extern CGGlyph GetGlyph (nuint glyphIndex, out bool isValidIndex);
#elif MONOMAC
		public extern CGGlyph GetCGGlyph (nuint glyphIndex, out bool isValidIndex);
#else
		public extern CGGlyph GetGlyph (nuint glyphIndex, ref bool isValidIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("CGGlyphAtIndex:")]
#if NET
		public extern CGGlyph GetGlyph (nuint glyphIndex);
#elif MONOMAC
		public extern CGGlyph GetCGGlyph (nuint glyphIndex);
#else
		public extern CGGlyph GetGlyph (nuint glyphIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("processEditingForTextStorage:edited:range:changeInLength:invalidatedRange:")]
#if NET
		public extern void ProcessEditing (NSTextStorage textStorage, NSTextStorageEditActions editMask, NSRange newCharacterRange, /* NSInteger */ nint delta, NSRange invalidatedCharacterRange);
#else
		public extern void ProcessEditing (NSTextStorage textStorage, NSTextStorageEditActions editMask, NSRange newCharRange, /* NSInteger */ nint delta, NSRange invalidatedCharRange);
#endif

		// This method can only be called from
		// NSLayoutManagerDelegate.ShouldGenerateGlyphs, and that method takes
		// the same IntPtr arguments as this one. This means that creating a
		// version of this method with nice(r) types (arrays instead of
		// IntPtr) is useless, since what the caller has is IntPtrs (from the
		// ShouldGenerateGlyphs parameters). We can revisit this if we ever
		// fix the generator to have support for C-style arrays.
		[MacCatalyst (13, 1)]
		[Export ("setGlyphs:properties:characterIndexes:font:forGlyphRange:")]
#if NET
		public extern void SetGlyphs (IntPtr glyphs, IntPtr properties, IntPtr characterIndexes, NSFont font, NSRange glyphRange);
#else
		public extern void SetGlyphs (IntPtr glyphs, IntPtr props, IntPtr charIndexes, NSFont aFont, NSRange glyphRange);
#endif

#if !(NET || MONOMAC)
		[Sealed]
#endif
		[MacCatalyst (13, 1)]
		[Export ("truncatedGlyphRangeInLineFragmentForGlyphAtIndex:")]
		public extern NSRange GetTruncatedGlyphRangeInLineFragment (nuint glyphIndex);

#if !(NET || MONOMAC)
		[Obsolete ("Use 'GetTruncatedGlyphRangeInLineFragment' instead.")]
		[Export ("truncatedGlyphRangeInLineFragmentForGlyphAtIndex:")]
		public extern NSRange TruncatedGlyphRangeInLineFragmentForGlyphAtIndex (nuint glyphIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("enumerateLineFragmentsForGlyphRange:usingBlock:")]
		public extern void EnumerateLineFragments (NSRange glyphRange, NSTextLayoutEnumerateLineFragments callback);

		[MacCatalyst (13, 1)]
		[Export ("enumerateEnclosingRectsForGlyphRange:withinSelectedGlyphRange:inTextContainer:usingBlock:")]
		public extern void EnumerateEnclosingRects (NSRange glyphRange, NSRange selectedRange, NSTextContainer textContainer, NSTextLayoutEnumerateEnclosingRects callback);

		//[Deprecated (PlatformName.MacOSX, 10, 15, message: "Use the overload that takes 'nint glyphCount' instead.")]
		//[Deprecated (PlatformName.iOS, 13, 0, message: "Use the overload that takes 'nint glyphCount' instead.")]
		//[Deprecated (PlatformName.TvOS, 13, 0, message: "Use the overload that takes 'nint glyphCount' instead.")]
		[NoMacCatalyst]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use the overload that takes 'nint glyphCount' instead.")]
		[Protected] // Can be overridden
		[Export ("showCGGlyphs:positions:count:font:matrix:attributes:inContext:")]
		public extern void ShowGlyphs (IntPtr glyphs, IntPtr positions, nuint glyphCount, NSFont font, CGAffineTransform textMatrix, NSDictionary attributes, CGContext graphicsContext);

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Protected] // Can be overridden
		[Export ("showCGGlyphs:positions:count:font:textMatrix:attributes:inContext:")]
		public extern void ShowGlyphs (IntPtr glyphs, IntPtr positions, nint glyphCount, NSFont font, CGAffineTransform textMatrix, NSDictionary attributes, CGContext graphicsContext);

		// Unfortunately we can't provide a nicer API for this, because it uses C-style arrays.
		// And providing a nicer overload when it's only purpose is to be overridden is useless.
		[Advice ("This method should never be called, only overridden.")] // According to Apple's documentation
		[Protected]
		[Export ("fillBackgroundRectArray:count:forCharacterRange:color:")]
		public extern void FillBackground (IntPtr rectArray, nuint rectCount, NSRange characterRange, NSColor color);

		[Export ("drawUnderlineForGlyphRange:underlineType:baselineOffset:lineFragmentRect:lineFragmentGlyphRange:containerOrigin:")]
		public extern void DrawUnderline (NSRange glyphRange, NSUnderlineStyle underlineVal, nfloat baselineOffset, CGRect lineRect, NSRange lineGlyphRange, CGPoint containerOrigin);

		[Export ("underlineGlyphRange:underlineType:lineFragmentRect:lineFragmentGlyphRange:containerOrigin:")]
		public extern void Underline (NSRange glyphRange, NSUnderlineStyle underlineVal, CGRect lineRect, NSRange lineGlyphRange, CGPoint containerOrigin);

		[Export ("drawStrikethroughForGlyphRange:strikethroughType:baselineOffset:lineFragmentRect:lineFragmentGlyphRange:containerOrigin:")]
		public extern void DrawStrikethrough (NSRange glyphRange, NSUnderlineStyle strikethroughVal, nfloat baselineOffset, CGRect lineRect, NSRange lineGlyphRange, CGPoint containerOrigin);

		[Export ("strikethroughGlyphRange:strikethroughType:lineFragmentRect:lineFragmentGlyphRange:containerOrigin:")]
		public extern void Strikethrough (NSRange glyphRange, NSUnderlineStyle strikethroughVal, CGRect lineRect, NSRange lineGlyphRange, CGPoint containerOrigin);

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("showAttachmentCell:inRect:characterIndex:")]
		public extern void ShowAttachmentCell (NSCell cell, CGRect rect, nuint characterIndex);

		[MacCatalyst (13, 1)]
		[Export ("limitsLayoutForSuspiciousContents")]
		public extern bool LimitsLayoutForSuspiciousContents { get; set; }

		//[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("usesDefaultHyphenation")]
		public extern bool UsesDefaultHyphenation { get; set; }
	}
	
	/// <summary>Interface representing the required methods (if any) of the protocol <see cref="T:UIKit.NSLayoutManagerDelegate" />.</summary>
	///     <remarks>
	///       <para>This interface contains the required methods (if any) from the protocol defined by <see cref="T:UIKit.NSLayoutManagerDelegate" />.</para>
	///       <para>If developers create classes that implement this interface, the implementation methods will automatically be exported to Objective-C with the matching signature from the method defined in the <see cref="T:UIKit.NSLayoutManagerDelegate" /> protocol.</para>
	///       <para>Optional methods (if any) are provided by the <see cref="T:UIKit.NSLayoutManagerDelegate_Extensions" /> class as extension methods to the interface, allowing developers to invoke any optional methods on the protocol.</para>
	///     </remarks>
	public interface INSLayoutManagerDelegate { }
	

	/// <summary>A delegate used as the callback in <see cref="M:UIKit.NSLayoutManager.EnumerateLineFragments(Foundation.NSRange,UIKit.NSTextLayoutEnumerateLineFragments)" />.</summary>
	public delegate void NSTextLayoutEnumerateLineFragments (CGRect rect, CGRect usedRectangle, NSTextContainer textContainer, NSRange glyphRange, out bool stop);
	/// <summary>A delegate used as the callback in <see cref="M:UIKit.NSLayoutManager.EnumerateEnclosingRects(Foundation.NSRange,Foundation.NSRange,UIKit.NSTextContainer,UIKit.NSTextLayoutEnumerateEnclosingRects)" />.</summary>
	public delegate void NSTextLayoutEnumerateEnclosingRects (CGRect rect, out bool stop);

}