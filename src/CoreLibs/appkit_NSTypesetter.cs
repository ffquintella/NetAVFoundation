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
using UIKit;
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
	[NoMacCatalyst]
	[BaseType (typeof (NSTypesetter))]
	public class NSATSTypesetter {
		[Static]
		[Export ("sharedTypesetter")]
		public static extern NSATSTypesetter SharedTypesetter { get; }
	}

	[NoMacCatalyst]
	[BaseType (typeof (NSObject))]
	partial class NSTypesetter {

	}
	
	public partial class NSTypesetter {
		[Export ("substituteFontForFont:")]
		public extern NSFont GetSubstituteFont (NSFont originalFont);

		[Export ("textTabForGlyphLocation:writingDirection:maxLocation:")]
		public extern NSTextTab GetTextTab (nfloat glyphLocation, NSWritingDirection direction, nfloat maxLocation);

		[Export ("setParagraphGlyphRange:separatorGlyphRange:")]
		public extern void SetParagraphGlyphRange (NSRange paragraphRange, NSRange paragraphSeparatorRange);

		[Export ("paragraphGlyphRange")]
		public extern NSRange ParagraphGlyphRange { get; }

		[Export ("paragraphSeparatorGlyphRange")]
		public extern NSRange ParagraphSeparatorGlyphRange { get; }

		[Export ("paragraphCharacterRange")]
		public extern NSRange ParagraphCharacterRange { get; }

		[Export ("paragraphSeparatorCharacterRange")]
		public extern NSRange ParagraphSeparatorCharacterRange { get; }

		[Export ("layoutParagraphAtPoint:")]
		public extern nuint LayoutParagraphAtPoint (ref CGPoint lineFragmentOrigin);

		[Export ("beginParagraph")]
		public extern void BeginParagraph ();

		[Export ("endParagraph")]
		public extern void EndParagraph ();

		[Export ("beginLineWithGlyphAtIndex:")]
		public extern void BeginLine (nuint glyphIndex);

		[Export ("endLineWithGlyphRange:")]
		public extern void EndLine (NSRange lineGlyphRange);

		[Export ("lineSpacingAfterGlyphAtIndex:withProposedLineFragmentRect:")]
		public extern nfloat GetLineSpacingAfterGlyph (nuint glyphIndex, CGRect proposedLineFragmentRect);

		[Export ("paragraphSpacingBeforeGlyphAtIndex:withProposedLineFragmentRect:")]
		public extern nfloat GetParagraphSpacingBeforeGlyph (nuint glyphIndex, CGRect proposedLineFragmentRect);

		[Export ("paragraphSpacingAfterGlyphAtIndex:withProposedLineFragmentRect:")]
		public extern nfloat GetParagraphSpacingAfterGlyph (nuint glyphIndex, CGRect proposedLineFragmentRect);

		[Export ("getLineFragmentRect:usedRect:forParagraphSeparatorGlyphRange:atProposedOrigin:")]
		public extern void GetLineFragment (out CGRect lineFragmentRect, out CGRect lineFragmentUsedRect, NSRange paragraphSeparatorGlyphRange, CGPoint proposedOrigin);

		[Export ("attributesForExtraLineFragment")]
		public extern NSDictionary AttributesForExtraLineFragment ();

		[Export ("actionForControlCharacterAtIndex:")]
		public extern NSTypesetterControlCharacterAction GetActionForControlCharacter (nuint charIndex);

		[Export ("layoutManager")]
		public extern NSLayoutManager LayoutManager { get; }

		[Export ("textContainers")]
		public extern NSTextContainer [] TextContainers { get; }

		[Export ("currentTextContainer")]
		public extern NSTextContainer CurrentTextContainer { get; }

		[Export ("currentParagraphStyle")]
		public extern NSParagraphStyle CurrentParagraphStyle { get; }

		[Export ("setHardInvalidation:forGlyphRange:")]
		public extern void SetHardInvalidation (bool value, NSRange glyphRange);

		[Export ("layoutGlyphsInLayoutManager:startingAtGlyphIndex:maxNumberOfLineFragments:nextGlyphIndex:")]
		public extern void LayoutGlyphs (NSLayoutManager layoutManager, nuint startGlyphIndex, nuint maxLineFragments, out nuint nextGlyph);

		[Export ("layoutCharactersInRange:forLayoutManager:maximumNumberOfLineFragments:")]
		public extern NSRange LayoutCharacters (NSRange characterRange, NSLayoutManager layoutManager, nuint maxLineFragments);

		// TODO: provide a higher level C# API for this too
		[Static]
		[Export ("printingAdjustmentInLayoutManager:forNominallySpacedGlyphRange:packedGlyphs:count:")]
		public static extern CGSize GetInterGlyphSpacing (NSLayoutManager layoutManager, NSRange nominallySpacedGlyphsRange, IntPtr packedGlyphs, nuint packedGlyphsCount);

		[Export ("baselineOffsetInLayoutManager:glyphIndex:")]
		public extern nfloat GetBaselineOffset (NSLayoutManager layoutManager, nuint glyphIndex);

		[Static]
		[Export ("sharedSystemTypesetter")]
		public static extern NSTypesetter SharedSystemTypesetter { get; }

		[Static]
		[Export ("sharedSystemTypesetterForBehavior:")]
		public static extern NSTypesetter GetSharedSystemTypesetter (NSTypesetterBehavior forBehavior);

		[Static]
		[Export ("defaultTypesetterBehavior")]
		public static extern NSTypesetterBehavior DefaultTypesetterBehavior { get; }

		//
		// Detected properties
		[Export ("usesFontLeading")]
		public extern bool UsesFontLeading { get; set; }

		[Export ("typesetterBehavior")]
		NSTypesetterBehavior TypesetterBehavior { get; set; }

		[Export ("hyphenationFactor")]
		public extern float HyphenationFactor { get; set; } /* float, not CGFloat */

		[Export ("lineFragmentPadding")]
		public extern nfloat LineFragmentPadding { get; set; }

		[Export ("bidiProcessingEnabled")]
		public extern bool BidiProcessingEnabled { get; set; }

		[Export ("attributedString")]
		public extern NSAttributedString AttributedString { get; set; }


		///
		/// NSLayoutPhaseInterface
		///

		[Export ("willSetLineFragmentRect:forGlyphRange:usedRect:baselineOffset:")]
		public extern void WillSetLineFragment (ref CGRect lineRect, NSRange glyphRange, ref CGRect usedRect, ref nfloat baselineOffset);

		[Export ("shouldBreakLineByWordBeforeCharacterAtIndex:")]
		public extern bool ShouldBreakLineByWordBeforeCharacter (nuint charIndex);

		[Export ("shouldBreakLineByHyphenatingBeforeCharacterAtIndex:")]
		public extern bool ShouldBreakLineByHyphenatingBeforeCharacter (nuint charIndex);

		[Export ("hyphenationFactorForGlyphAtIndex:")]
		public extern float /* float, not CGFloat */ HyphenationFactorForGlyph (nuint glyphIndex);

		[Export ("hyphenCharacterForGlyphAtIndex:")]
		public extern uint /* UTF32Char */ HyphenCharacterForGlyph (nuint glyphIndex);

		[Export ("boundingBoxForControlGlyphAtIndex:forTextContainer:proposedLineFragment:glyphPosition:characterIndex:")]
		public extern CGRect GetBoundingBoxForControlGlyph (nuint glyphIndex, NSTextContainer textContainer, CGRect proposedLineFragment, CGPoint glyphPosition, nuint charIndex);

		//
		// NSGlyphStorageInterface
		//
		[Export ("characterRangeForGlyphRange:actualGlyphRange:")]
		public extern NSRange GetCharacterRangeForGlyphRange (NSRange glyphRange, out NSRange actualGlyphRange);

		[Export ("glyphRangeForCharacterRange:actualCharacterRange:")]
		public extern NSRange GlyphRangeForCharacterRange (NSRange charRange, out NSRange actualCharRange);

		// TODO: could use a higher level API
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		[Export ("getGlyphsInRange:glyphs:characterIndexes:glyphInscriptions:elasticBits:bidiLevels:")]
		public extern nuint GetGlyphsInRange (NSRange glyphsRange, IntPtr glyphBuffer, IntPtr charIndexBuffer, IntPtr inscribeBuffer, IntPtr elasticBuffer, IntPtr bidiLevelBuffer);

		[Export ("getLineFragmentRect:usedRect:remainingRect:forStartingGlyphAtIndex:proposedRect:lineSpacing:paragraphSpacingBefore:paragraphSpacingAfter:")]
		public extern void GetLineFragment (out CGRect lineFragment, out CGRect lineFragmentUsed, out CGRect remaining, nuint startingGlyphIndex, CGRect proposedRect, nfloat lineSpacing, nfloat paragraphSpacingBefore, nfloat paragraphSpacingAfter);

		[Export ("setLineFragmentRect:forGlyphRange:usedRect:baselineOffset:")]
		public extern void SetLineFragment (CGRect fragmentRect, NSRange glyphRange, CGRect usedRect, nfloat baselineOffset);

		[Export ("substituteGlyphsInRange:withGlyphs:")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		public extern void SubstituteGlyphs (NSRange glyphRange, IntPtr glyphs);

		[Export ("insertGlyph:atGlyphIndex:characterIndex:")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		public extern void InsertGlyph (uint glyph, nuint glyphIndex, nuint characterIndex); // glyph is NSGlyph - typedef unsigned int NSGlyph;

		[Export ("deleteGlyphsInRange:")]
		[Deprecated (PlatformName.MacOSX, 10, 13)]
		public extern void DeleteGlyphs (NSRange glyphRange);

		[Export ("setNotShownAttribute:forGlyphRange:")]
		public extern void SetNotShownAttribute (bool flag, NSRange glyphRange);

		[Export ("setDrawsOutsideLineFragment:forGlyphRange:")]
		public extern void SetDrawsOutsideLineFragment (bool flag, NSRange glyphRange);

		// TODO: high level C# binding
		[Export ("setLocation:withAdvancements:forStartOfGlyphRange:")]
		public extern void SetLocation (CGPoint location, IntPtr advancements, NSRange glyphRange);

		[Export ("setAttachmentSize:forGlyphRange:")]
		public extern void SetAttachmentSize (CGSize attachmentSize, NSRange glyphRange);

		// TODO: high level C# binding
		[Export ("setBidiLevels:forGlyphRange:")]
		public extern void SetBidiLevels (IntPtr levels, NSRange glyphRange);
	}
}