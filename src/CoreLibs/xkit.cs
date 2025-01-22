// This file contains api definitions shared between AppKit and UIKit

using System;
using System.Diagnostics;
using System.ComponentModel;
using Foundation;
using ObjCRuntime;
using CoreAnimation;
using CoreGraphics;
using CoreLibs;
using CoreText;
using UniformTypeIdentifiers;

using CGGlyph = System.UInt16;
using NSGlyph = System.UInt32;

#if HAS_WEBKIT
using WebKit;
#else
using WebPreferences = Foundation.NSObject;
#endif

#if !MONOMAC
using NSColor = UIKit.UIColor;
using NSFont = UIKit.UIFont;
#endif

// dummy types to simplify build
#if !MONOMAC
using NSAppearance = UIKit.UIAppearance;
using NSCell = System.Object;
using NSGlyphGenerator = System.Object;
using NSGlyphStorageOptions = System.Object;
using NSImageScaling = System.Object;
using NSRulerMarker = System.Object;
using NSRulerView = System.Object;
using NSTextAttachmentCell = System.Object;
using NSTextBlock = System.Object;
using NSTextTableBlock = System.Object;
using NSTextTabType = System.Object;
using NSTextStorageEditedFlags = System.Object;
using NSTextView = System.Object;
using NSTypesetter = System.Object;
using NSTypesetterBehavior = System.Object;
using NSView = System.Object;
using NSWindow = System.Object;
#else
using UICollectionLayoutListConfiguration=System.Object;
using UIContentInsetsReference=System.Object;
using UIEdgeInsets=System.Object;
using UITraitCollection=System.Object;
#endif // !MONOMAC

#if MONOMAC
using BezierPath=AppKit.NSBezierPath;
using Image=AppKit.NSImage;
using TextAlignment=AppKit.NSTextAlignment;
using LineBreakMode=AppKit.NSLineBreakMode;
using CollectionLayoutSectionOrthogonalScrollingBehavior=AppKit.NSCollectionLayoutSectionOrthogonalScrollingBehavior;
using CollectionElementCategory=AppKit.NSCollectionElementCategory;
using StringAttributes=AppKit.NSStringAttributes;
using View=AppKit.NSView;
using UICollectionLayoutSectionOrthogonalScrollingProperties = System.Object;
#else
using BezierPath = UIKit.UIBezierPath;
using Image = UIKit.UIImage;
using TextAlignment = UIKit.UITextAlignment;
using LineBreakMode = UIKit.UILineBreakMode;
using CollectionLayoutSectionOrthogonalScrollingBehavior = UIKit.UICollectionLayoutSectionOrthogonalScrollingBehavior;
using CollectionElementCategory = UIKit.UICollectionElementCategory;
using StringAttributes = UIKit.UIStringAttributes;
using View = UIKit.UIView;
#endif

#if MONOMAC
	using IXWritingToolsCoordinatorDelegate = AppKit.INSWritingToolsCoordinatorDelegate;
	using XWritingToolsBehavior = AppKit.NSWritingToolsBehavior;
	using XWritingToolsCoordinator = AppKit.NSWritingToolsCoordinator;
	using XWritingToolsCoordinatorAnimationParameters = AppKit.NSWritingToolsCoordinatorAnimationParameters;
	using XWritingToolsCoordinatorContext = AppKit.NSWritingToolsCoordinatorContext;
	using XWritingToolsCoordinatorContextScope = AppKit.NSWritingToolsCoordinatorContextScope;
	using XWritingToolsCoordinatorDelegate = AppKit.NSWritingToolsCoordinatorDelegate;
	using XWritingToolsCoordinatorDelegateReplaceRangeCallback = AppKit.NSWritingToolsCoordinatorDelegateReplaceRangeCallback;
	using XWritingToolsCoordinatorDelegateRequestsBoundingBezierPathsCallback = AppKit.NSWritingToolsCoordinatorDelegateRequestsBoundingBezierPathsCallback;
	using XWritingToolsCoordinatorDelegateRequestsContextsCallback = AppKit.NSWritingToolsCoordinatorDelegateRequestsContextsCallback;
	using XWritingToolsCoordinatorDelegateRequestsDecorationContainerViewCallback = AppKit.NSWritingToolsCoordinatorDelegateRequestsDecorationContainerViewCallback;
	using XWritingToolsCoordinatorDelegateRequestsPreviewForTextAnimationCallback = AppKit.NSWritingToolsCoordinatorDelegateRequestsPreviewForTextAnimationCallback;
	using XWritingToolsCoordinatorDelegateRequestsRangeCallback = AppKit.NSWritingToolsCoordinatorDelegateRequestsRangeCallback;
	using XWritingToolsCoordinatorDelegateRequestsSingleContainerSubrangesCallback = AppKit.NSWritingToolsCoordinatorDelegateRequestsSingleContainerSubrangesCallback;
	using XWritingToolsCoordinatorDelegateRequestsUnderlinePathsCallback = AppKit.NSWritingToolsCoordinatorDelegateRequestsUnderlinePathsCallback;
	using XWritingToolsCoordinatorState = AppKit.NSWritingToolsCoordinatorState;
	using XWritingToolsCoordinatorTextAnimation = AppKit.NSWritingToolsCoordinatorTextAnimation;
	using XWritingToolsCoordinatorTextReplacementReason = AppKit.NSWritingToolsCoordinatorTextReplacementReason;
	using XWritingToolsCoordinatorTextUpdateReason = AppKit.NSWritingToolsCoordinatorTextUpdateReason;
	using XWritingToolsResultOptions = AppKit.NSWritingToolsResultOptions;
#else
using IXWritingToolsCoordinatorDelegate = UIKit.IUIWritingToolsCoordinatorDelegate;
using XWritingToolsBehavior = UIKit.UIWritingToolsBehavior;
using XWritingToolsCoordinator = UIKit.UIWritingToolsCoordinator;
using XWritingToolsCoordinatorAnimationParameters = UIKit.UIWritingToolsCoordinatorAnimationParameters;
using XWritingToolsCoordinatorContext = UIKit.UIWritingToolsCoordinatorContext;
using XWritingToolsCoordinatorContextScope = UIKit.UIWritingToolsCoordinatorContextScope;
using XWritingToolsCoordinatorDelegate = UIKit.UIWritingToolsCoordinatorDelegate;
using XWritingToolsCoordinatorDelegateReplaceRangeCallback = UIKit.UIWritingToolsCoordinatorDelegateReplaceRangeCallback;
using XWritingToolsCoordinatorDelegateRequestsBoundingBezierPathsCallback = UIKit.UIWritingToolsCoordinatorDelegateRequestsBoundingBezierPathsCallback;
using XWritingToolsCoordinatorDelegateRequestsContextsCallback = UIKit.UIWritingToolsCoordinatorDelegateRequestsContextsCallback;
using XWritingToolsCoordinatorDelegateRequestsDecorationContainerViewCallback = UIKit.UIWritingToolsCoordinatorDelegateRequestsDecorationContainerViewCallback;
using XWritingToolsCoordinatorDelegateRequestsPreviewForTextAnimationCallback = UIKit.UIWritingToolsCoordinatorDelegateRequestsPreviewForTextAnimationCallback;
using XWritingToolsCoordinatorDelegateRequestsRangeCallback = UIKit.UIWritingToolsCoordinatorDelegateRequestsRangeCallback;
using XWritingToolsCoordinatorDelegateRequestsSingleContainerSubrangesCallback = UIKit.UIWritingToolsCoordinatorDelegateRequestsSingleContainerSubrangesCallback;
using XWritingToolsCoordinatorDelegateRequestsUnderlinePathsCallback = UIKit.UIWritingToolsCoordinatorDelegateRequestsUnderlinePathsCallback;
using XWritingToolsCoordinatorState = UIKit.UIWritingToolsCoordinatorState;
using XWritingToolsCoordinatorTextAnimation = UIKit.UIWritingToolsCoordinatorTextAnimation;
using XWritingToolsCoordinatorTextReplacementReason = UIKit.UIWritingToolsCoordinatorTextReplacementReason;
using XWritingToolsCoordinatorTextUpdateReason = UIKit.UIWritingToolsCoordinatorTextUpdateReason;
using XWritingToolsResultOptions = UIKit.UIWritingToolsResultOptions;
#endif

#if !NET
using NativeHandle = System.IntPtr;
#endif

#if MONOMAC
namespace AppKit {
#else
namespace UIKit {
#endif



	// NSInteger -> NSLayoutManager.h
	/// <summary>An enumeration whose values specify actions caused by control characters.</summary>
	[Native]
	[Flags]
	[MacCatalyst (13, 1)]
	public enum NSControlCharacterAction : long {
		ZeroAdvancement = (1 << 0),
		Whitespace = (1 << 1),
		HorizontalTab = (1 << 2),
		LineBreak = (1 << 3),
		ParagraphBreak = (1 << 4),
		ContainerBreak = (1 << 5),

#if !NET && !__MACCATALYST__ && !MONOMAC
		[Obsolete ("Use 'ZeroAdvancement' instead.")]
		ZeroAdvancementAction = ZeroAdvancement,
		[Obsolete ("Use 'Whitespace' instead.")]
		WhitespaceAction = Whitespace,
		[Obsolete ("Use 'HorizontalTab' instead.")]
		HorizontalTabAction = HorizontalTab,
		[Obsolete ("Use 'LineBreak' instead.")]
		LineBreakAction = LineBreak,
		[Obsolete ("Use 'ParagraphBreak' instead.")]
		ParagraphBreakAction = ParagraphBreak,
		[Obsolete ("Use 'ContainerBreak' instead.")]
		ContainerBreakAction = ContainerBreak,
#endif
	}

	[TV (13, 0), iOS (13, 0), MacCatalyst (13, 0)]
	[Flags]
	[Native]
	public enum NSDirectionalRectEdge : ulong {
		None = 0x0,
		Top = 1uL << 0,
		Leading = 1uL << 1,
		Bottom = 1uL << 2,
		Trailing = 1uL << 3,
		All = Top | Leading | Bottom | Trailing,
	}

	// NSInteger -> NSLayoutManager.h
	/// <summary>An enumeration whose values specify characteristics of a glyph.</summary>
	[MacCatalyst (13, 1)]
	[Native]
	public enum NSGlyphProperty : long {
		Null = (1 << 0),
		ControlCharacter = (1 << 1),
		Elastic = (1 << 2),
		NonBaseCharacter = (1 << 3),
	}

	// NSInteger -> NSLayoutConstraint.h
	/// <summary>An enumeration of attributes for use with constraint-based layouts.</summary>
	///     <remarks>Values used to specify particular constraint attributes in constraint-based layouts. These values are primarily used by methods in the <see cref="T:UIKit.NSLayoutConstraint" /> class. </remarks>
	[Native]
	[MacCatalyst (13, 1)]
	public enum NSLayoutAttribute : long {
		NoAttribute = 0,
		Left = 1,
		Right,
		Top,
		Bottom,
		Leading,
		Trailing,
		Width,
		Height,
		CenterX,
		CenterY,
		Baseline,
		[MacCatalyst (13, 1)]
		LastBaseline = Baseline,
		[MacCatalyst (13, 1)]
		FirstBaseline,

		[NoMac]
		[MacCatalyst (13, 1)]
		LeftMargin,
		[NoMac]
		[MacCatalyst (13, 1)]
		RightMargin,
		[NoMac]
		[MacCatalyst (13, 1)]
		TopMargin,
		[NoMac]
		[MacCatalyst (13, 1)]
		BottomMargin,
		[NoMac]
		[MacCatalyst (13, 1)]
		LeadingMargin,
		[NoMac]
		[MacCatalyst (13, 1)]
		TrailingMargin,
		[NoMac]
		[MacCatalyst (13, 1)]
		CenterXWithinMargins,
		[NoMac]
		[MacCatalyst (13, 1)]
		CenterYWithinMargins,
	}

	// NSUInteger -> NSLayoutConstraint.h
	/// <include file="../docs/api/UIKit/NSLayoutFormatOptions.xml" path="/Documentation/Docs[@DocId='T:UIKit.NSLayoutFormatOptions']/*" />
	[Native]
	[Flags]
	[MacCatalyst (13, 1)]
	public enum NSLayoutFormatOptions : ulong {
		None = 0,

		AlignAllLeft = (1 << (int) NSLayoutAttribute.Left),
		AlignAllRight = (1 << (int) NSLayoutAttribute.Right),
		AlignAllTop = (1 << (int) NSLayoutAttribute.Top),
		AlignAllBottom = (1 << (int) NSLayoutAttribute.Bottom),
		AlignAllLeading = (1 << (int) NSLayoutAttribute.Leading),
		AlignAllTrailing = (1 << (int) NSLayoutAttribute.Trailing),
		AlignAllCenterX = (1 << (int) NSLayoutAttribute.CenterX),
		AlignAllCenterY = (1 << (int) NSLayoutAttribute.CenterY),
		AlignAllBaseline = (1 << (int) NSLayoutAttribute.Baseline),
		[MacCatalyst (13, 1)]
		AlignAllLastBaseline = (1 << (int) NSLayoutAttribute.LastBaseline),
		[MacCatalyst (13, 1)]
		AlignAllFirstBaseline = (1 << (int) NSLayoutAttribute.FirstBaseline),

		AlignmentMask = 0xFFFF,

		/* choose only one of these three
		 */
		DirectionLeadingToTrailing = 0 << 16, // default
		DirectionLeftToRight = 1 << 16,
		DirectionRightToLeft = 2 << 16,

		[NoMac]
		[MacCatalyst (13, 1)]
		SpacingEdgeToEdge = 0 << 19,
		[NoMac]
		[MacCatalyst (13, 1)]
		SpacingBaselineToBaseline = 1 << 19,
		[NoMac]
		[MacCatalyst (13, 1)]
		SpacingMask = 1 << 19,

		DirectionMask = 0x3 << 16,
	}

	// NSInteger -> UITextInput.h
	/// <summary>An enumeration that specifies the relation between two attributes in a <see cref="T:UIKit.NSLayoutConstraint" /></summary>
	///     <remarks>Constraint-based layouts are based on relationships between the values of two <see cref="T:UIKit.NSLayoutAttribute" />s. Constraints can be made more flexible by allowing relationships other than strict equality, that is, <see cref="F:UIKit.NSLayoutRelation.GreaterThanOrEqual" /> or <see cref="F:UIKit.NSLayoutRelation.LessThanOrEqual" />. With relations other than <see cref="F:UIKit.NSLayoutRelation.Equal" /> the constraint solver will attempt to minimize the difference in attributes. If <see cref="F:UIKit.NSLayoutRelation.Equal" /> is specified and the constraint solver cannot solve the system of constraints, the constraint solver will throw an exception. </remarks>
	[Native]
	[MacCatalyst (13, 1)]
	public enum NSLayoutRelation : long {
		LessThanOrEqual = -1,
		Equal = 0,
		GreaterThanOrEqual = 1,
	}

	[MacCatalyst (13, 1)]
	[Flags]
	[Native]
	public enum NSLineBreakStrategy : ulong {
		[iOS (14, 0), TV (14, 0), MacCatalyst (14, 0)]
		None = 0x0,
		PushOut = 1uL << 0,
		[iOS (14, 0), TV (14, 0), MacCatalyst (14, 0)]
		HangulWordPriority = 1uL << 1,
		[iOS (14, 0), TV (14, 0), MacCatalyst (14, 0)]
		Standard = 0xffff,
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum NSRectAlignment : long {
		None = 0,
		Top,
		TopLeading,
		Leading,
		BottomLeading,
		Bottom,
		BottomTrailing,
		Trailing,
		TopTrailing,
	}

	[iOS (13, 0), TV (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum NSTextScalingType : long {
		Standard = 0,
		iOS,
	}

	// NSInteger -> NSLayoutManager.h
	/// <summary>An enumeration whose values specify the direction in which text is laid out. Used with <see cref="P:UIKit.NSTextContainer.LayoutOrientation" />.</summary>
	[Native]
	[MacCatalyst (13, 1)]
	public enum NSTextLayoutOrientation : long {
		Horizontal,
		Vertical,
	}

	// NSUInteger -> NSTextStorage.h
	/// <summary>A flagging enumeration whose values are used by Text Kit to specify whether actions pertain to attributes, characters, or both.</summary>
	[Native]
	[Flags]
	[MacCatalyst (13, 1)]
	public enum NSTextStorageEditActions : ulong {
		Attributes = 1,
		Characters = 2,
	}

	

	[NoiOS]
	[NoTV]
	[NoMacCatalyst]
	//[Category]
	[BaseType (typeof (NSLayoutManager))]
	interface NSLayoutManager_NSTextViewSupport {
		[Export ("rulerMarkersForTextView:paragraphStyle:ruler:")]
		NSRulerMarker [] GetRulerMarkers (NSTextView textView, NSParagraphStyle paragraphStyle, NSRulerView ruler);

		[return: NullAllowed]
		[Export ("rulerAccessoryViewForTextView:paragraphStyle:ruler:enabled:")]
		NSView GetRulerAccessoryView (NSTextView textView, NSParagraphStyle paragraphStyle, NSRulerView ruler, bool enabled);

		[Export ("layoutManagerOwnsFirstResponderInWindow:")]
		bool LayoutManagerOwnsFirstResponder (NSWindow window);

		[return: NullAllowed]
		[Export ("firstTextView", ArgumentSemantic.Assign)]
		NSTextView GetFirstTextView ();

		[return: NullAllowed]
		[Export ("textViewForBeginningOfSelection")]
		NSTextView GetTextViewForBeginningOfSelection ();
	}



	/// <summary>A delegate object that exposes events for <see cref="T:UIKit.NSLayoutManager" />s.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/UIKit/Reference/NSLayoutManagerDelegate_Protocol_TextKit/index.html">Apple documentation for <c>NSLayoutManagerDelegate</c></related>
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	[MacCatalyst (13, 1)]
	interface NSLayoutManagerDelegate {
		[Export ("layoutManagerDidInvalidateLayout:")]
#if MONOMAC && !NET
		void LayoutInvalidated (NSLayoutManager sender);
#else
		void DidInvalidatedLayout (NSLayoutManager sender);
#endif

		[Export ("layoutManager:didCompleteLayoutForTextContainer:atEnd:")]
#if NET || !MONOMAC
		void DidCompleteLayout (NSLayoutManager layoutManager, [NullAllowed] NSTextContainer textContainer, bool layoutFinishedFlag);
#else
		void LayoutCompleted (NSLayoutManager layoutManager, NSTextContainer textContainer, bool layoutFinishedFlag);
#endif

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("layoutManager:shouldUseTemporaryAttributes:forDrawingToScreen:atCharacterIndex:effectiveRange:")]
		[return: NullAllowed]
#if NET
		NSDictionary<NSString, NSObject> ShouldUseTemporaryAttributes (NSLayoutManager layoutManager, NSDictionary<NSString, NSObject> temporaryAttributes, bool drawingToScreen, nuint characterIndex, ref NSRange effectiveCharacterRange);
#else
		NSDictionary ShouldUseTemporaryAttributes (NSLayoutManager layoutManager, NSDictionary temporaryAttributes, bool drawingToScreen, nint charIndex, IntPtr effectiveCharRange);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:shouldGenerateGlyphs:properties:characterIndexes:font:forGlyphRange:")]
#if NET
		nuint ShouldGenerateGlyphs (NSLayoutManager layoutManager, IntPtr glyphBuffer, IntPtr properties, IntPtr characterIndexes, NSFont font, NSRange glyphRange);
#else
		nuint ShouldGenerateGlyphs (NSLayoutManager layoutManager, IntPtr glyphBuffer, IntPtr props, IntPtr charIndexes, NSFont aFont, NSRange glyphRange);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:lineSpacingAfterGlyphAtIndex:withProposedLineFragmentRect:")]
#if NET || MONOMAC
		nfloat GetLineSpacingAfterGlyph (NSLayoutManager layoutManager, nuint glyphIndex, CGRect rect);
#else
		nfloat LineSpacingAfterGlyphAtIndex (NSLayoutManager layoutManager, nuint glyphIndex, CGRect rect);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:paragraphSpacingBeforeGlyphAtIndex:withProposedLineFragmentRect:")]
#if NET || MONOMAC
		nfloat GetParagraphSpacingBeforeGlyph (NSLayoutManager layoutManager, nuint glyphIndex, CGRect rect);
#else
		nfloat ParagraphSpacingBeforeGlyphAtIndex (NSLayoutManager layoutManager, nuint glyphIndex, CGRect rect);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:paragraphSpacingAfterGlyphAtIndex:withProposedLineFragmentRect:")]
#if NET || MONOMAC
		nfloat GetParagraphSpacingAfterGlyph (NSLayoutManager layoutManager, nuint glyphIndex, CGRect rect);
#else
		nfloat ParagraphSpacingAfterGlyphAtIndex (NSLayoutManager layoutManager, nuint glyphIndex, CGRect rect);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:shouldUseAction:forControlCharacterAtIndex:")]
#if NET
		NSControlCharacterAction ShouldUseAction (NSLayoutManager layoutManager, NSControlCharacterAction action, nuint characterIndex);
#else
		NSControlCharacterAction ShouldUseAction (NSLayoutManager layoutManager, NSControlCharacterAction action, nuint charIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:shouldBreakLineByWordBeforeCharacterAtIndex:")]
#if NET
		bool ShouldBreakLineByWordBeforeCharacter (NSLayoutManager layoutManager, nuint characterIndex);
#else
		bool ShouldBreakLineByWordBeforeCharacter (NSLayoutManager layoutManager, nuint charIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:shouldBreakLineByHyphenatingBeforeCharacterAtIndex:")]
#if NET
		bool ShouldBreakLineByHyphenatingBeforeCharacter (NSLayoutManager layoutManager, nuint characterIndex);
#else
		bool ShouldBreakLineByHyphenatingBeforeCharacter (NSLayoutManager layoutManager, nuint charIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:boundingBoxForControlGlyphAtIndex:forTextContainer:proposedLineFragment:glyphPosition:characterIndex:")]
#if NET
		CGRect GetBoundingBox (NSLayoutManager layoutManager, nuint glyphIndex, NSTextContainer textContainer, CGRect proposedRect, CGPoint glyphPosition, nuint characterIndex);
#elif MONOMAC
		CGRect GetBoundingBox (NSLayoutManager layoutManager, nuint glyphIndex, NSTextContainer textContainer, CGRect proposedRect, CGPoint glyphPosition, nuint charIndex);
#else
		CGRect BoundingBoxForControlGlyph (NSLayoutManager layoutManager, nuint glyphIndex, NSTextContainer textContainer, CGRect proposedRect, CGPoint glyphPosition, nuint charIndex);
#endif

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:textContainer:didChangeGeometryFromSize:")]
		void DidChangeGeometry (NSLayoutManager layoutManager, NSTextContainer textContainer, CGSize oldSize);

		[MacCatalyst (13, 1)]
		[Export ("layoutManager:shouldSetLineFragmentRect:lineFragmentUsedRect:baselineOffset:inTextContainer:forGlyphRange:")]
		bool ShouldSetLineFragmentRect (NSLayoutManager layoutManager, ref CGRect lineFragmentRect, ref CGRect lineFragmentUsedRect, ref nfloat baselineOffset, NSTextContainer textContainer, NSRange glyphRange);
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class NSDiffableDataSourceSnapshot<SectionIdentifierType, ItemIdentifierType> : NSCopying
		where SectionIdentifierType : NSObject
		where ItemIdentifierType : NSObject {

		[Export ("numberOfItems")]
		nint NumberOfItems { get; }

		[Export ("numberOfSections")]
		nint NumberOfSections { get; }

		[Export ("sectionIdentifiers")]
		SectionIdentifierType [] SectionIdentifiers { get; }

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("reloadedSectionIdentifiers")]
		SectionIdentifierType [] ReloadedSectionIdentifiers { get; }

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("reloadedItemIdentifiers")]
		ItemIdentifierType [] ReloadedItemIdentifiers { get; }

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("reconfiguredItemIdentifiers")]
		ItemIdentifierType [] ReconfiguredItemIdentifiers { get; }

		[Export ("itemIdentifiers")]
		ItemIdentifierType [] ItemIdentifiers { get; }

		[Export ("numberOfItemsInSection:")]
		extern nint GetNumberOfItems (SectionIdentifierType sectionIdentifier);

		[Export ("itemIdentifiersInSectionWithIdentifier:")]
		extern ItemIdentifierType [] GetItemIdentifiersInSection (SectionIdentifierType sectionIdentifier);

		[Export ("sectionIdentifierForSectionContainingItemIdentifier:")]
		[return: NullAllowed]
		extern SectionIdentifierType GetSectionIdentifierForSection (ItemIdentifierType itemIdentifier);

		[Export ("indexOfItemIdentifier:")]
		extern nint GetIndex (ItemIdentifierType itemIdentifier);

		[Export ("indexOfSectionIdentifier:")]
		extern nint GetIndex (SectionIdentifierType sectionIdentifier);

		[Export ("appendItemsWithIdentifiers:")]
		extern void AppendItems (ItemIdentifierType [] identifiers);

		[Export ("appendItemsWithIdentifiers:intoSectionWithIdentifier:")]
		extern void AppendItems (ItemIdentifierType [] identifiers, SectionIdentifierType sectionIdentifier);

		[Export ("insertItemsWithIdentifiers:beforeItemWithIdentifier:")]
		extern void InsertItemsBefore (ItemIdentifierType [] identifiers, ItemIdentifierType itemIdentifier);

		[Export ("insertItemsWithIdentifiers:afterItemWithIdentifier:")]
		extern void InsertItemsAfter (ItemIdentifierType [] identifiers, ItemIdentifierType itemIdentifier);

		[Export ("deleteItemsWithIdentifiers:")]
		extern void DeleteItems (ItemIdentifierType [] identifiers);

		[Export ("deleteAllItems")]
		extern void DeleteAllItems ();

		[Export ("moveItemWithIdentifier:beforeItemWithIdentifier:")]
		extern void MoveItemBefore (ItemIdentifierType fromIdentifier, ItemIdentifierType toIdentifier);

		[Export ("moveItemWithIdentifier:afterItemWithIdentifier:")]
		extern void MoveItemAfter (ItemIdentifierType fromIdentifier, ItemIdentifierType toIdentifier);

		[Export ("reloadItemsWithIdentifiers:")]
		extern void ReloadItems (ItemIdentifierType [] identifiers);

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("reconfigureItemsWithIdentifiers:")]
		extern void ReconfigureItems (ItemIdentifierType [] identifiers);

		[Export ("appendSectionsWithIdentifiers:")]
		extern void AppendSections (SectionIdentifierType [] sectionIdentifiers);

		[Export ("insertSectionsWithIdentifiers:beforeSectionWithIdentifier:")]
		extern void InsertSectionsBefore (SectionIdentifierType [] sectionIdentifiers, SectionIdentifierType toSectionIdentifier);

		[Export ("insertSectionsWithIdentifiers:afterSectionWithIdentifier:")]
		extern void InsertSectionsAfter (SectionIdentifierType [] sectionIdentifiers, SectionIdentifierType toSectionIdentifier);

		[Export ("deleteSectionsWithIdentifiers:")]
		extern void DeleteSections (SectionIdentifierType [] sectionIdentifiers);

		[Export ("moveSectionWithIdentifier:beforeSectionWithIdentifier:")]
		extern void MoveSectionBefore (SectionIdentifierType fromSectionIdentifier, SectionIdentifierType toSectionIdentifier);

		[Export ("moveSectionWithIdentifier:afterSectionWithIdentifier:")]
		extern void MoveSectionAfter (SectionIdentifierType fromSectionIdentifier, SectionIdentifierType toSectionIdentifier);

		[Export ("reloadSectionsWithIdentifiers:")]
		extern void ReloadSections (SectionIdentifierType [] sectionIdentifiers);
	}

	/// <summary>A class that specifies paragraph-relevant attributes of an <see cref="T:Foundation.NSAttributedString" />.</summary>
	///     <remarks>An immutable set of attributes associated with the display of an <see cref="T:Foundation.NSAttributedString" />. Important: the application developer must use the subtype <see cref="T:UIKit.NSMutableParagraphStyle" /> if they modify the paragraph style after assignment to a <see cref="T:Foundation.NSAttributedString" />. Modifying an attribute of an assigned <see cref="T:UIKit.NSParagraphStyle" /> may result in a program crash.<para tool="threads">The members of this class can be used from a background thread.</para></remarks>
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Cocoa/Reference/ApplicationKit/Classes/NSParagraphStyle_Class/index.html">Apple documentation for <c>NSParagraphStyle</c></related>
	[ThreadSafe]
	[BaseType (typeof (NSObject))]
	[MacCatalyst (13, 1)]
	public partial class NSParagraphStyle : NSMutableCopying {
		
		public NSParagraphStyle (IntPtr handle) : base (handle)
		{
		}
		
		[Export ("lineSpacing")]
		public nfloat LineSpacing { get; [NotImplemented] set; }

		[Export ("paragraphSpacing")]
		public nfloat ParagraphSpacing { get; [NotImplemented] set; }

		[Export ("alignment")]
		public TextAlignment Alignment { get; [NotImplemented] set; }

		[Export ("headIndent")]
		public nfloat HeadIndent { get; [NotImplemented] set; }

		[Export ("tailIndent")]
		public nfloat TailIndent { get; [NotImplemented] set; }

		[Export ("firstLineHeadIndent")]
		public nfloat FirstLineHeadIndent { get; [NotImplemented] set; }

		[Export ("minimumLineHeight")]
		public nfloat MinimumLineHeight { get; [NotImplemented] set; }

		[Export ("maximumLineHeight")]
		public nfloat MaximumLineHeight { get; [NotImplemented] set; }

		[Export ("lineBreakMode")]
		public LineBreakMode LineBreakMode { get; [NotImplemented] set; }

		[Export ("baseWritingDirection")]
		public NSWritingDirection BaseWritingDirection { get; [NotImplemented] set; }

		[Export ("lineHeightMultiple")]
		public nfloat LineHeightMultiple { get; [NotImplemented] set; }

		[Export ("paragraphSpacingBefore")]
		public nfloat ParagraphSpacingBefore { get; [NotImplemented] set; }

		[Export ("hyphenationFactor")]
		public float HyphenationFactor { get; [NotImplemented] set; } // Returns a float, not nfloat.

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("usesDefaultHyphenation")]
		public bool UsesDefaultHyphenation { get; }

		[Static]
		[Export ("defaultWritingDirectionForLanguage:")]
		static extern public NSWritingDirection GetDefaultWritingDirection ([NullAllowed] string languageName);

#if MONOMAC && !NET
		[Obsolete ("Use the 'GetDefaultWritingDirection' method instead.")]
		[Static]
		[Export ("defaultWritingDirectionForLanguage:")]
		public NSWritingDirection DefaultWritingDirection ([NullAllowed] string languageName);
#endif

		[Static]
		[Export ("defaultParagraphStyle", ArgumentSemantic.Copy)]
		public static NSParagraphStyle Default { get; }

#if MONOMAC && !NET
		[Obsolete ("Use the 'Default' property instead.")]
		[Static]
		[Export ("defaultParagraphStyle", ArgumentSemantic.Copy)]
		public static NSParagraphStyle DefaultParagraphStyle { get; [NotImplemented] set; }
#endif

		[Export ("defaultTabInterval")]
		public nfloat DefaultTabInterval { get; [NotImplemented] set; }

		[Export ("tabStops", ArgumentSemantic.Copy)]
		[NullAllowed]
		public NSTextTab [] TabStops { get; [NotImplemented] set; }

		[MacCatalyst (13, 1)]
		[Export ("allowsDefaultTighteningForTruncation")]
		public bool AllowsDefaultTighteningForTruncation { get; [NotImplemented] set; }

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("textBlocks")]
#if NET
		public NSTextBlock [] TextBlocks { get; [NotImplemented] set; }
#else
		public NSTextTableBlock [] TextBlocks { get; [NotImplemented] set; }
#endif

		[MacCatalyst (13, 1)]
		[Export ("textLists")] 
		NSTextList [] TextLists { get; [NotImplemented] set; }

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("tighteningFactorForTruncation")]
		public float TighteningFactorForTruncation { get; [NotImplemented] set; } /* float, not CGFloat */

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("headerLevel")]
		public nint HeaderLevel { get; [NotImplemented] set; }

		[MacCatalyst (13, 1)]
		[Export ("lineBreakStrategy")]
		public NSLineBreakStrategy LineBreakStrategy { get; [NotImplemented] set; }
	}

	/// <summary>A class that extends <see cref="T:UIKit.NSParagraphStyle" /> to allow changing subattributes.</summary>
	///     <remarks>
	///       <para>
	///       </para>
	///       <para tool="threads">The members of this class can be used from a background thread.</para>
	///     </remarks>
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Cocoa/Reference/ApplicationKit/Classes/NSMutableParagraphStyle_Class/index.html">Apple documentation for <c>NSMutableParagraphStyle</c></related>
	[ThreadSafe]
	[BaseType (typeof (NSParagraphStyle))]
	[MacCatalyst (13, 1)]
	interface NSMutableParagraphStyle {
		[Export ("lineSpacing")]
		[Override]
		nfloat LineSpacing { get; set; }

		[Export ("alignment")]
		[Override]
		TextAlignment Alignment { get; set; }

		[Export ("headIndent")]
		[Override]
		nfloat HeadIndent { get; set; }

		[Export ("tailIndent")]
		[Override]
		nfloat TailIndent { get; set; }

		[Export ("firstLineHeadIndent")]
		[Override]
		nfloat FirstLineHeadIndent { get; set; }

		[Export ("minimumLineHeight")]
		[Override]
		nfloat MinimumLineHeight { get; set; }

		[Export ("maximumLineHeight")]
		[Override]
		nfloat MaximumLineHeight { get; set; }

		[Export ("lineBreakMode")]
		[Override]
		LineBreakMode LineBreakMode { get; set; }

		[Export ("baseWritingDirection")]
		[Override]
		NSWritingDirection BaseWritingDirection { get; set; }

		[Export ("lineHeightMultiple")]
		[Override]
		nfloat LineHeightMultiple { get; set; }

		[Export ("paragraphSpacing")]
		[Override]
		nfloat ParagraphSpacing { get; set; }

		[Export ("paragraphSpacingBefore")]
		[Override]
		nfloat ParagraphSpacingBefore { get; set; }

		[Export ("hyphenationFactor")]
		[Override]
		float HyphenationFactor { get; set; } // Returns a float, not nfloat.

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("usesDefaultHyphenation")]
		bool UsesDefaultHyphenation { get; set; }

		[Export ("defaultTabInterval")]
		[Override]
		nfloat DefaultTabInterval { get; set; }

		[Export ("tabStops", ArgumentSemantic.Copy)]
		[Override]
		[NullAllowed]
		NSTextTab [] TabStops { get; set; }

		[MacCatalyst (13, 1)]
		[Override]
		[Export ("allowsDefaultTighteningForTruncation")]
		bool AllowsDefaultTighteningForTruncation { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("addTabStop:")]
		void AddTabStop (NSTextTab textTab);

		[MacCatalyst (13, 1)]
		[Export ("removeTabStop:")]
		void RemoveTabStop (NSTextTab textTab);

		[MacCatalyst (13, 1)]
		[Export ("setParagraphStyle:")]
		void SetParagraphStyle (NSParagraphStyle paragraphStyle);

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Override]
		[Export ("textBlocks")]
#if NET
		NSTextBlock [] TextBlocks { get; set; }
#else
		NSTextTableBlock [] TextBlocks { get; set; }
#endif

		[MacCatalyst (13, 1)]
		[Override]
		[Export ("textLists")]
		NSTextList [] TextLists { get; set; }

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("tighteningFactorForTruncation")]
		[Override]
		float TighteningFactorForTruncation { get; set; } /* float, not CGFloat */

		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("headerLevel")]
		[Override]
		nint HeaderLevel { get; set; }

		[MacCatalyst (13, 1)]
		[Override]
		[Export ("lineBreakStrategy", ArgumentSemantic.Assign)]
		NSLineBreakStrategy LineBreakStrategy { get; set; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	delegate NSCollectionLayoutGroupCustomItem [] NSCollectionLayoutGroupCustomItemProvider (INSCollectionLayoutEnvironment layoutEnvironment);

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSCollectionLayoutItem))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutGroup : NSCopying {

		[Static]
		[Export ("horizontalGroupWithLayoutSize:subitem:count:")]
#if MONOMAC && !NET
		NSCollectionLayoutGroup CreateHorizontalGroup (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem subitem, nint count);
#else
		static extern NSCollectionLayoutGroup CreateHorizontal (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem subitem, nint count);
#endif

		[Static]
		[Export ("horizontalGroupWithLayoutSize:subitems:")]
#if MONOMAC && !NET
		NSCollectionLayoutGroup CreateHorizontalGroup (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem [] subitems);
#else
		static extern NSCollectionLayoutGroup CreateHorizontal (NSCollectionLayoutSize layoutSize, params NSCollectionLayoutItem [] subitems);
#endif

		[Static]
		[Export ("verticalGroupWithLayoutSize:subitem:count:")]
#if MONOMAC && !NET
		NSCollectionLayoutGroup CreateVerticalGroup (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem subitem, nint count);
#else
		static extern NSCollectionLayoutGroup CreateVertical (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem subitem, nint count);
#endif

		[Static]
		[Export ("verticalGroupWithLayoutSize:subitems:")]
#if MONOMAC && !NET
		NSCollectionLayoutGroup CreateVerticalGroup (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem [] subitems);
#else
		static extern NSCollectionLayoutGroup CreateVertical (NSCollectionLayoutSize layoutSize, params NSCollectionLayoutItem [] subitems);
#endif

		[Static]
		[Export ("customGroupWithLayoutSize:itemProvider:")]
#if MONOMAC && !NET
		NSCollectionLayoutGroup CreateCustomGroup (NSCollectionLayoutSize layoutSize, NSCollectionLayoutGroupCustomItemProvider itemProvider);
#else
		static extern NSCollectionLayoutGroup CreateCustom (NSCollectionLayoutSize layoutSize, NSCollectionLayoutGroupCustomItemProvider itemProvider);
#endif

		[Export ("supplementaryItems", ArgumentSemantic.Copy)]
		NSCollectionLayoutSupplementaryItem [] SupplementaryItems { get; set; }

		[NullAllowed, Export ("interItemSpacing", ArgumentSemantic.Copy)]
		NSCollectionLayoutSpacing InterItemSpacing { get; set; }

		[Export ("subitems")]
		NSCollectionLayoutItem [] Subitems { get; }

		[Export ("visualDescription")]
		string VisualDescription { get; }

		[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0), Mac (13, 0)]
		[Static]
		[Export ("horizontalGroupWithLayoutSize:repeatingSubitem:count:")]
		static extern NSCollectionLayoutGroup GetHorizontalGroup (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem repeatingSubitem, nint count);

		[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0), Mac (13, 0)]
		[Static]
		[Export ("verticalGroupWithLayoutSize:repeatingSubitem:count:")]
		static extern NSCollectionLayoutGroup GetVerticalGroup (NSCollectionLayoutSize layoutSize, NSCollectionLayoutItem repeatingSubitem, nint count);
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	delegate void NSCollectionLayoutSectionVisibleItemsInvalidationHandler (INSCollectionLayoutVisibleItem [] visibleItems, CGPoint contentOffset, INSCollectionLayoutEnvironment layoutEnvironment);

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutSection : NSCopying {

		[Static]
		[Export ("sectionWithGroup:")]
		static extern NSCollectionLayoutSection Create (NSCollectionLayoutGroup group);

		//[Export ("contentInsets", ArgumentSemantic.Assign)]
		//NSDirectionalEdgeInsets ContentInsets { get; set; }

		[Export ("interGroupSpacing")]
		nfloat InterGroupSpacing { get; set; }

		[NoMac]
		[MacCatalyst (14, 0)]
		[TV (14, 0), iOS (14, 0)]
		[Export ("contentInsetsReference", ArgumentSemantic.Assign)]
		UIContentInsetsReference ContentInsetsReference { get; set; }

		[Export ("orthogonalScrollingBehavior", ArgumentSemantic.Assign)]
		CollectionLayoutSectionOrthogonalScrollingBehavior OrthogonalScrollingBehavior { get; set; }

		[Export ("boundarySupplementaryItems", ArgumentSemantic.Copy)]
		NSCollectionLayoutBoundarySupplementaryItem [] BoundarySupplementaryItems { get; set; }

		//[Deprecated (PlatformName.iOS, 16, 0)]
		//[Deprecated (PlatformName.TvOS, 16, 0)]
		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[Export ("supplementariesFollowContentInsets")]
		bool SupplementariesFollowContentInsets { get; set; }

		[NullAllowed, Export ("visibleItemsInvalidationHandler", ArgumentSemantic.Copy)]
		NSCollectionLayoutSectionVisibleItemsInvalidationHandler VisibleItemsInvalidationHandler { get; set; }

		[Export ("decorationItems", ArgumentSemantic.Copy)]
		NSCollectionLayoutDecorationItem [] DecorationItems { get; set; }

		// NSCollectionLayoutSection (UICollectionLayoutListSection) category
		[NoMac]
		[MacCatalyst (14, 0)]
		[TV (14, 0), iOS (14, 0)]
		[Static]
		[Export ("sectionWithListConfiguration:layoutEnvironment:")]
		static extern NSCollectionLayoutSection GetSection (UICollectionLayoutListConfiguration listConfiguration, INSCollectionLayoutEnvironment layoutEnvironment);

		// NSCollectionLayoutSection (TVMediaItemContentConfiguration) category
		[TV (15, 0), NoMac, NoiOS, NoMacCatalyst]
		[Static]
		[Export ("orthogonalLayoutSectionForMediaItems")]
		static extern NSCollectionLayoutSection GetOrthogonalLayoutSectionForMediaItems ();

		[TV (16, 0), iOS (16, 0), NoMac]
		[MacCatalyst (16, 0)]
		[Export ("supplementaryContentInsetsReference", ArgumentSemantic.Assign)]
		UIContentInsetsReference SupplementaryContentInsetsReference { get; set; }

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0), NoMac]
		[Export ("orthogonalScrollingProperties")]
		UICollectionLayoutSectionOrthogonalScrollingProperties OrthogonalScrollingProperties { get; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutGroupCustomItem : NSCopying {
		[Static]
		[Export ("customItemWithFrame:")]
		static extern NSCollectionLayoutGroupCustomItem Create (CGRect frame);

		[Static]
		[Export ("customItemWithFrame:zIndex:")]
		static extern NSCollectionLayoutGroupCustomItem Create (CGRect frame, nint zIndex);

		[Export ("frame")]
		CGRect Frame { get; }

		[Export ("zIndex")]
		nint ZIndex { get; }
	}

	interface INSCollectionLayoutContainer { }

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Protocol]
	partial class NSCollectionLayoutContainer {
		[Abstract]
		[Export ("contentSize")]
		CGSize ContentSize { get; }

		[Abstract]
		[Export ("effectiveContentSize")]
		CGSize EffectiveContentSize { get; }

		/*
		[Abstract]
		[Export ("contentInsets")]
		NSDirectionalEdgeInsets ContentInsets { get; }

		[Abstract]
		[Export ("effectiveContentInsets")]
		NSDirectionalEdgeInsets EffectiveContentInsets { get; }
		*/
	}

	interface INSCollectionLayoutEnvironment { }

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Protocol]
	partial class NSCollectionLayoutEnvironment {

		[Abstract]
		[Export ("container")]
		INSCollectionLayoutContainer Container { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Abstract]
		[Export ("traitCollection")]
		UITraitCollection TraitCollection { get; }
	}

	interface INSCollectionLayoutVisibleItem { }

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Protocol]
	partial class NSCollectionLayoutVisibleItem
#if !MONOMAC
	: UIDynamicItem
#endif
	{

		[Abstract]
		[Export ("alpha")]
		nfloat Alpha { get; set; }

		[Abstract]
		[Export ("zIndex")]
		nint ZIndex { get; set; }

		[Abstract]
		[Export ("hidden")]
		bool Hidden { [Bind ("isHidden")] get; set; }

#pragma warning disable 0109 // warning CS0109: The member 'NSCollectionLayoutVisibleItem.Center' does not hide an accessible member. The new keyword is not required.
		// Inherited from UIDynamicItem for !MONOMAC
		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Abstract]
		[Export ("center", ArgumentSemantic.Assign)]
		new CGPoint Center { get; set; }
#pragma warning restore

#pragma warning disable 0109 // warning CS0109: The member 'NSCollectionLayoutVisibleItem.Bounds' does not hide an accessible member. The new keyword is not required.
		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Abstract]
		[Export ("bounds")]
		new CGRect Bounds { get; }
#pragma warning restore

		/*
		[NoMac]
		[MacCatalyst (13, 1)]
		[Abstract]
		[Export ("transform3D", ArgumentSemantic.Assign)]
		CATransform3D Transform3D { get; set; }
		*/

		[Abstract]
		[Export ("name")]
		string Name { get; }

		[Abstract]
		[Export ("indexPath")]
		NSIndexPath IndexPath { get; }

		[Abstract]
		[Export ("frame")]
		CGRect Frame { get; }

		[Abstract]
		[Export ("representedElementCategory")]
		CollectionElementCategory RepresentedElementCategory {
			get;
		}

		[Abstract]
		[NullAllowed, Export ("representedElementKind")]
		string RepresentedElementKind { get; }
	}

	/// <include file="../docs/api/UIKit/NSLayoutAnchor`1.xml" path="/Documentation/Docs[@DocId='T:UIKit.NSLayoutAnchor`1']/*" />
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // Handle is nil
	public class NSLayoutAnchor<AnchorType> : NSCopying {
		[Export ("constraintEqualToAnchor:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintEqualToAnchor (NSLayoutAnchor<AnchorType> anchor);
#else
		public extern NSLayoutConstraint ConstraintEqualTo (NSLayoutAnchor<AnchorType> anchor);
#endif

		[Export ("constraintGreaterThanOrEqualToAnchor:")]
#if MONOMAC && !NET
		public extern NSLayoutConstraint ConstraintGreaterThanOrEqualToAnchor (NSLayoutAnchor<AnchorType> anchor);
#else
		public extern NSLayoutConstraint ConstraintGreaterThanOrEqualTo (NSLayoutAnchor<AnchorType> anchor);
#endif

		[Export ("constraintLessThanOrEqualToAnchor:")]
#if MONOMAC && !NET
		public extern NSLayoutConstraint ConstraintLessThanOrEqualToAnchor (NSLayoutAnchor<AnchorType> anchor);
#else
		public extern NSLayoutConstraint ConstraintLessThanOrEqualTo (NSLayoutAnchor<AnchorType> anchor);
#endif

		[Export ("constraintEqualToAnchor:constant:")]
#if MONOMAC && !NET
		public extern NSLayoutConstraint ConstraintEqualToAnchor (NSLayoutAnchor<AnchorType> anchor, nfloat constant);
#else
		public extern NSLayoutConstraint ConstraintEqualTo (NSLayoutAnchor<AnchorType> anchor, nfloat constant);
#endif

		[Export ("constraintGreaterThanOrEqualToAnchor:constant:")]
#if MONOMAC && !NET
		public extern NSLayoutConstraint ConstraintGreaterThanOrEqualToAnchor (NSLayoutAnchor<AnchorType> anchor, nfloat constant);
#else
		public extern NSLayoutConstraint ConstraintGreaterThanOrEqualTo (NSLayoutAnchor<AnchorType> anchor, nfloat constant);
#endif

		[Export ("constraintLessThanOrEqualToAnchor:constant:")]
#if MONOMAC && !NET
		public extern NSLayoutConstraint ConstraintLessThanOrEqualToAnchor (NSLayoutAnchor<AnchorType> anchor, nfloat constant);
#else
		public extern NSLayoutConstraint ConstraintLessThanOrEqualTo (NSLayoutAnchor<AnchorType> anchor, nfloat constant);
#endif

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("name")]
		public extern string Name { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[NullAllowed, Export ("item", ArgumentSemantic.Weak)]
		public extern NSObject Item { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("hasAmbiguousLayout")]
		public extern bool HasAmbiguousLayout { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("constraintsAffectingLayout")]
		public extern NSLayoutConstraint [] ConstraintsAffectingLayout { get; }
	}

	/// <summary>An <see cref="T:UIKit.NSLayoutAnchor`1" /> whose methods create horizontal <see cref="T:UIKit.NSLayoutConstraint" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/AppKit/Reference/NSLayoutXAxisAnchor/index.html">Apple documentation for <c>NSLayoutXAxisAnchor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSLayoutAnchor<NSLayoutXAxisAnchor>))]
	[DisableDefaultCtor] // Handle is nil
	interface NSLayoutXAxisAnchor {
		[MacCatalyst (13, 1)]
		[Export ("anchorWithOffsetToAnchor:")]
#if MONOMAC && !NET
		NSLayoutDimension GetAnchorWithOffset (NSLayoutXAxisAnchor otherAnchor);
#else
		NSLayoutDimension CreateAnchorWithOffset (NSLayoutXAxisAnchor otherAnchor);
#endif

		[MacCatalyst (13, 1)]
		[Export ("constraintEqualToSystemSpacingAfterAnchor:multiplier:")]
		NSLayoutConstraint ConstraintEqualToSystemSpacingAfterAnchor (NSLayoutXAxisAnchor anchor, nfloat multiplier);

		[MacCatalyst (13, 1)]
		[Export ("constraintGreaterThanOrEqualToSystemSpacingAfterAnchor:multiplier:")]
		NSLayoutConstraint ConstraintGreaterThanOrEqualToSystemSpacingAfterAnchor (NSLayoutXAxisAnchor anchor, nfloat multiplier);

		[MacCatalyst (13, 1)]
		[Export ("constraintLessThanOrEqualToSystemSpacingAfterAnchor:multiplier:")]
		NSLayoutConstraint ConstraintLessThanOrEqualToSystemSpacingAfterAnchor (NSLayoutXAxisAnchor anchor, nfloat multiplier);
	}

	/// <summary>An <see cref="T:UIKit.NSLayoutAnchor`1" /> whose methods create vertical <see cref="T:UIKit.NSLayoutConstraint" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/AppKit/Reference/NSLayoutYAxisAnchor/index.html">Apple documentation for <c>NSLayoutYAxisAnchor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSLayoutAnchor<NSLayoutYAxisAnchor>))]
	[DisableDefaultCtor] // Handle is nil
	interface NSLayoutYAxisAnchor {
		[MacCatalyst (13, 1)]
		[Export ("anchorWithOffsetToAnchor:")]
#if MONOMAC && !NET
		NSLayoutDimension GetAnchorWithOffset (NSLayoutYAxisAnchor otherAnchor);
#else
		NSLayoutDimension CreateAnchorWithOffset (NSLayoutYAxisAnchor otherAnchor);
#endif

		[MacCatalyst (13, 1)]
		[Export ("constraintEqualToSystemSpacingBelowAnchor:multiplier:")]
		NSLayoutConstraint ConstraintEqualToSystemSpacingBelowAnchor (NSLayoutYAxisAnchor anchor, nfloat multiplier);

		[MacCatalyst (13, 1)]
		[Export ("constraintGreaterThanOrEqualToSystemSpacingBelowAnchor:multiplier:")]
		NSLayoutConstraint ConstraintGreaterThanOrEqualToSystemSpacingBelowAnchor (NSLayoutYAxisAnchor anchor, nfloat multiplier);

		[MacCatalyst (13, 1)]
		[Export ("constraintLessThanOrEqualToSystemSpacingBelowAnchor:multiplier:")]
		NSLayoutConstraint ConstraintLessThanOrEqualToSystemSpacingBelowAnchor (NSLayoutYAxisAnchor anchor, nfloat multiplier);
	}

	/// <summary>An <see cref="T:UIKit.NSLayoutAnchor`1" /> whose methods create dimensional <see cref="T:UIKit.NSLayoutConstraint" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/AppKit/Reference/NSLayoutDimension_ClassReference/index.html">Apple documentation for <c>NSLayoutDimension</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSLayoutAnchor<NSLayoutDimension>))]
	[DisableDefaultCtor] // Handle is nil
	interface NSLayoutDimension {
		[Export ("constraintEqualToConstant:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintEqualToConstant (nfloat constant);
#else
		NSLayoutConstraint ConstraintEqualTo (nfloat constant);
#endif

		[Export ("constraintGreaterThanOrEqualToConstant:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintGreaterThanOrEqualToConstant (nfloat constant);
#else
		NSLayoutConstraint ConstraintGreaterThanOrEqualTo (nfloat constant);
#endif

		[Export ("constraintLessThanOrEqualToConstant:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintLessThanOrEqualToConstant (nfloat constant);
#else
		NSLayoutConstraint ConstraintLessThanOrEqualTo (nfloat constant);
#endif

		[Export ("constraintEqualToAnchor:multiplier:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintEqualToAnchor (NSLayoutDimension anchor, nfloat multiplier);
#else
		NSLayoutConstraint ConstraintEqualTo (NSLayoutDimension anchor, nfloat multiplier);
#endif

		[Export ("constraintGreaterThanOrEqualToAnchor:multiplier:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintGreaterThanOrEqualToAnchor (NSLayoutDimension anchor, nfloat multiplier);
#else
		NSLayoutConstraint ConstraintGreaterThanOrEqualTo (NSLayoutDimension anchor, nfloat multiplier);
#endif

		[Export ("constraintLessThanOrEqualToAnchor:multiplier:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintLessThanOrEqualToAnchor (NSLayoutDimension anchor, nfloat multiplier);
#else
		NSLayoutConstraint ConstraintLessThanOrEqualTo (NSLayoutDimension anchor, nfloat multiplier);
#endif

		[Export ("constraintEqualToAnchor:multiplier:constant:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintEqualToAnchor (NSLayoutDimension anchor, nfloat multiplier, nfloat constant);
#else
		NSLayoutConstraint ConstraintEqualTo (NSLayoutDimension anchor, nfloat multiplier, nfloat constant);
#endif

		[Export ("constraintGreaterThanOrEqualToAnchor:multiplier:constant:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintGreaterThanOrEqualToAnchor (NSLayoutDimension anchor, nfloat multiplier, nfloat constant);
#else
		NSLayoutConstraint ConstraintGreaterThanOrEqualTo (NSLayoutDimension anchor, nfloat multiplier, nfloat constant);
#endif

		[Export ("constraintLessThanOrEqualToAnchor:multiplier:constant:")]
#if MONOMAC && !NET
		NSLayoutConstraint ConstraintLessThanOrEqualToAnchor (NSLayoutDimension anchor, nfloat multiplier, nfloat constant);
#else
		NSLayoutConstraint ConstraintLessThanOrEqualTo (NSLayoutDimension anchor, nfloat multiplier, nfloat constant);
#endif
	}

	/// <include file="../docs/api/UIKit/NSLayoutConstraint.xml" path="/Documentation/Docs[@DocId='T:UIKit.NSLayoutConstraint']/*" />
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class NSLayoutConstraint
#if MONOMAC
		//: NSAnimatablePropertyContainer
#endif
{
		[Static]
		[Export ("constraintsWithVisualFormat:options:metrics:views:")]
		public static extern NSLayoutConstraint [] FromVisualFormat (string format, NSLayoutFormatOptions formatOptions, [NullAllowed] NSDictionary metrics, NSDictionary views);

		[Static]
		[Export ("constraintWithItem:attribute:relatedBy:toItem:attribute:multiplier:constant:")]
		public static extern NSLayoutConstraint Create (INativeObject view1, NSLayoutAttribute attribute1, NSLayoutRelation relation, [NullAllowed] INativeObject view2, NSLayoutAttribute attribute2, nfloat multiplier, nfloat constant);

		[Export ("priority")]
		public extern float Priority { get; set; } // Returns a float, not nfloat.

		[Export ("shouldBeArchived")]
		public extern bool ShouldBeArchived { get; set; }

		[NullAllowed, Export ("firstItem", ArgumentSemantic.Assign)]
		public extern NSObject? FirstItem { get; }

		[Export ("firstAttribute")]
		public extern NSLayoutAttribute FirstAttribute { get; }

		[Export ("relation")]
		public extern NSLayoutRelation Relation { get; }

		[Export ("secondItem", ArgumentSemantic.Assign)]
		[NullAllowed]
		public extern NSObject? SecondItem { get; }

		[Export ("secondAttribute")]
		public extern NSLayoutAttribute SecondAttribute { get; }

		[Export ("multiplier")]
		public extern nfloat Multiplier { get; }

		[Export ("constant")]
		public extern nfloat Constant { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("active")]
		public extern bool Active { [Bind ("isActive")] get; set; }

		[MacCatalyst (13, 1)]
		[Static, Export ("activateConstraints:")]
		public extern void ActivateConstraints (NSLayoutConstraint [] constraints);

		[MacCatalyst (13, 1)]
		[Static, Export ("deactivateConstraints:")]
		public extern void DeactivateConstraints (NSLayoutConstraint [] constraints);

		[MacCatalyst (13, 1)]
		[Export ("firstAnchor", ArgumentSemantic.Copy)]
#if MONOMAC && !NET
		public extern NSLayoutAnchor<NSObject> FirstAnchor { get; }
#else
		[Internal]
		internal extern IntPtr _FirstAnchor<AnchorType> ();
#endif

		[MacCatalyst (13, 1)]
		[Export ("secondAnchor", ArgumentSemantic.Copy)]
#if MONOMAC && !NET
		[NullAllowed]
		public extern NSLayoutAnchor<NSObject> SecondAnchor { get; }
#else
		[Internal]
		public extern IntPtr _SecondAnchor<AnchorType> ();
#endif

		[NullAllowed, Export ("identifier")]
		public extern string? Identifier { get; set; }
	}

	/// <summary>Defines the relationship between <see cref="T:UIKit.NSTextAttachment" />s and a <see cref="T:UIKit.NSLayoutManager" />.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/UIKit/Reference/NSTextAttachmentContainer_Protocol/index.html">Apple documentation for <c>NSTextAttachmentContainer</c></related>
	[Introduced (PlatformName.iOS)]
	[MacCatalyst (13, 1)]
	[Model]
	[Protocol]
	public partial class NSTextAttachmentContainer : NSObject {
		
		public NSTextAttachmentContainer (IntPtr handle) : base (handle) {}
		
		[MacCatalyst (13, 1)]
		[Abstract]
		[Export ("imageForBounds:textContainer:characterIndex:")]
		[return: NullAllowed]
#if MONOMAC && !NET
		Image GetImage (CGRect imageBounds, [NullAllowed] NSTextContainer textContainer, nuint charIndex);
#else
		public extern Image GetImageForBounds (CGRect bounds, [NullAllowed] NSTextContainer textContainer, nuint characterIndex);
#endif

		[MacCatalyst (13, 1)]
		[Abstract]
		[Export ("attachmentBoundsForTextContainer:proposedLineFragment:glyphPosition:characterIndex:")]
		public extern CGRect GetAttachmentBounds ([NullAllowed] NSTextContainer textContainer, CGRect proposedLineFragment, CGPoint glyphPosition, nuint characterIndex);
	}

	/// <summary>An attachment to a <see cref="T:Foundation.NSAttributedString" />.</summary>
	///     
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/UIKit/Reference/NSTextAttachment_Class_TextKit/index.html">Apple documentation for <c>NSTextAttachment</c></related>
	//[MacCatalyst (13, 1)]
	public partial class NSTextAttachment : NSTextAttachmentContainer
#if !MONOMAC
	, UIAccessibilityContentSizeCategoryImageAdjusting
#endif // !MONOMAC
	{

		public NSTextAttachment(IntPtr Handle) : base(Handle) {}
		
		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("initWithFileWrapper:")]
		public extern NativeHandle Constructor (NSFileWrapper fileWrapper);

		[MacCatalyst (13, 1)]
		[DesignatedInitializer]
		[Export ("initWithData:ofType:")]
		[PostGet ("Contents")]
		public extern NativeHandle Constructor ([NullAllowed] NSData contentData, [NullAllowed] string uti);

		[MacCatalyst (13, 1)]
		[NullAllowed]
		[Export ("contents", ArgumentSemantic.Retain)]
		public NSData Contents { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed]
		[Export ("fileType", ArgumentSemantic.Retain)]
		public string FileType { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed]
		[Export ("image", ArgumentSemantic.Retain)]
		public Image Image { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("bounds")]
		public CGRect Bounds { get; set; }

		[NullAllowed]
		[Export ("fileWrapper", ArgumentSemantic.Retain)]
		public NSFileWrapper FileWrapper { get; set; }

		[NoiOS]
		[NoTV]
		[NoMacCatalyst]
		[Export ("attachmentCell", ArgumentSemantic.Retain)]
		public NSTextAttachmentCell AttachmentCell { get; set; }

		[NoMac]
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Static]
		[Export ("textAttachmentWithImage:")]
		public static extern NSTextAttachment Create (Image image);

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("lineLayoutPadding")]
		public nfloat LineLayoutPadding { get; set; }

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("textAttachmentViewProviderClassForFileType:")]
		[return: NullAllowed]
		public extern Class GetTextAttachmentViewProviderClass (string fileType);

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Static]
		[Export ("registerTextAttachmentViewProviderClass:forFileType:")]
		public static extern void RegisterViewProviderClass (Class textAttachmentViewProviderClass, string fileType);

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("allowsTextAttachmentView")]
		public bool AllowsTextAttachmentView { get; set; }

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("usesTextAttachmentView")]
		public bool UsesTextAttachmentView { get; }
	}

	[TV (15, 0), iOS (15, 0)]
	[MacCatalyst (15, 0)]
	[Protocol]
	public partial class NSTextAttachment {

		[MacCatalyst (15, 0)]
		[Abstract]
		[Export ("imageForBounds:attributes:location:textContainer:")]
		[return: NullAllowed]
		public extern Image GetImageForBounds (CGRect bounds, NSDictionary<NSString, NSObject> attributes, INSTextLocation location, [NullAllowed] NSTextContainer textContainer);

		[MacCatalyst (15, 0)]
		[Abstract]
		[Export ("attachmentBoundsForAttributes:location:textContainer:proposedLineFragment:position:")]
		public extern CGRect GetAttachmentBounds (NSDictionary<NSString, NSObject> attributes, INSTextLocation location, [NullAllowed] NSTextContainer textContainer, CGRect proposedLineFragment, CGPoint position);

		[MacCatalyst (15, 0)]
		[Abstract]
		[Export ("viewProviderForParentView:location:textContainer:")]
		[return: NullAllowed]
		public extern NSTextAttachmentViewProvider GetViewProvider ([NullAllowed] View parentView, INSTextLocation location, [NullAllowed] NSTextContainer textContainer);
	}

	

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutAnchor : NSCopying {
		[Static]
		[Export ("layoutAnchorWithEdges:")]
		static extern NSCollectionLayoutAnchor Create (NSDirectionalRectEdge edges);

		[Static]
		[Export ("layoutAnchorWithEdges:absoluteOffset:")]
		static extern NSCollectionLayoutAnchor CreateFromAbsoluteOffset (NSDirectionalRectEdge edges, CGPoint absoluteOffset);

		[Static]
		[Export ("layoutAnchorWithEdges:fractionalOffset:")]
		static extern NSCollectionLayoutAnchor CreateFromFractionalOffset (NSDirectionalRectEdge edges, CGPoint fractionalOffset);

		[Export ("edges")]
		NSDirectionalRectEdge Edges { get; }

		[Export ("offset")]
		CGPoint Offset { get; }

		[Export ("isAbsoluteOffset")]
		bool IsAbsoluteOffset { get; }

		[Export ("isFractionalOffset")]
		bool IsFractionalOffset { get; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutDimension : NSCopying {
		[Static]
		[Export ("fractionalWidthDimension:")]
#if MONOMAC && !NET
		NSCollectionLayoutDimension CreateFractionalWidthDimension (nfloat fractionalWidth);
#else
		static extern NSCollectionLayoutDimension CreateFractionalWidth (nfloat fractionalWidth);
#endif

		[Static]
		[Export ("fractionalHeightDimension:")]
#if MONOMAC && !NET
		NSCollectionLayoutDimension CreateFractionalHeightDimension (nfloat fractionalHeight);
#else
		static extern NSCollectionLayoutDimension CreateFractionalHeight (nfloat fractionalHeight);
#endif

		[Static]
		[Export ("absoluteDimension:")]
#if MONOMAC && !NET
		NSCollectionLayoutDimension CreateAbsoluteDimension (nfloat absoluteDimension);
#else
		static extern NSCollectionLayoutDimension CreateAbsolute (nfloat absoluteDimension);
#endif

		[Static]
		[Export ("estimatedDimension:")]
#if MONOMAC && !NET
		NSCollectionLayoutDimension CreateEstimatedDimension (nfloat estimatedDimension);
#else
		static extern NSCollectionLayoutDimension CreateEstimated (nfloat estimatedDimension);
#endif

		[Export ("isFractionalWidth")]
		bool IsFractionalWidth { get; }

		[Export ("isFractionalHeight")]
		bool IsFractionalHeight { get; }

		[Export ("isAbsolute")]
		bool IsAbsolute { get; }

		[Export ("isEstimated")]
		bool IsEstimated { get; }

		[Export ("dimension")]
		nfloat Dimension { get; }

		[TV (17, 0), iOS (17, 0), NoMac, MacCatalyst (17, 0)]
		[Static]
		[Export ("uniformAcrossSiblingsWithEstimate:")]
		static extern NSCollectionLayoutDimension CreateUniformAcrossSiblings (nfloat estimatedDimension);

		[TV (17, 0), iOS (17, 0), MacCatalyst (17, 0), NoMac]
		[Export ("isUniformAcrossSiblings")]
		bool IsUniformAcrossSiblings { get; }
	}


	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutSize : NSCopying {
		[Static]
		[Export ("sizeWithWidthDimension:heightDimension:")]
		static extern NSCollectionLayoutSize Create (NSCollectionLayoutDimension width, NSCollectionLayoutDimension height);

		[Export ("widthDimension")]
		NSCollectionLayoutDimension WidthDimension { get; }

		[Export ("heightDimension")]
		NSCollectionLayoutDimension HeightDimension { get; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutSpacing : NSCopying {
		[Static]
		[Export ("flexibleSpacing:")]
#if MONOMAC && !NET
		NSCollectionLayoutSpacing CreateFlexibleSpacing (nfloat flexibleSpacing);
#else
		static extern NSCollectionLayoutSpacing CreateFlexible (nfloat flexibleSpacing);
#endif

		[Static]
		[Export ("fixedSpacing:")]
#if MONOMAC && !NET
		NSCollectionLayoutSpacing CreateFixedSpacing (nfloat fixedSpacing);
#else
		static extern NSCollectionLayoutSpacing CreateFixed (nfloat fixedSpacing);
#endif

		[Export ("spacing")]
		nfloat Spacing { get; }

		[Export ("isFlexibleSpacing")]
		bool IsFlexibleSpacing { get; }

		[Export ("isFixedSpacing")]
		bool IsFixedSpacing { get; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutEdgeSpacing : NSCopying {
		[Static]
		[Export ("spacingForLeading:top:trailing:bottom:")]
#if MONOMAC && !NET
		NSCollectionLayoutEdgeSpacing CreateSpacing ([NullAllowed] NSCollectionLayoutSpacing leading, [NullAllowed] NSCollectionLayoutSpacing top, [NullAllowed] NSCollectionLayoutSpacing trailing, [NullAllowed] NSCollectionLayoutSpacing bottom);
#else
		static extern NSCollectionLayoutEdgeSpacing Create ([NullAllowed] NSCollectionLayoutSpacing leading, [NullAllowed] NSCollectionLayoutSpacing top, [NullAllowed] NSCollectionLayoutSpacing trailing, [NullAllowed] NSCollectionLayoutSpacing bottom);
#endif

		[NullAllowed, Export ("leading")]
		NSCollectionLayoutSpacing Leading { get; }

		[NullAllowed, Export ("top")]
		NSCollectionLayoutSpacing Top { get; }

		[NullAllowed, Export ("trailing")]
		NSCollectionLayoutSpacing Trailing { get; }

		[NullAllowed, Export ("bottom")]
		NSCollectionLayoutSpacing Bottom { get; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSCollectionLayoutItem))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutSupplementaryItem : NSCopying {
		[Static]
		[Export ("supplementaryItemWithLayoutSize:elementKind:containerAnchor:")]
		static extern NSCollectionLayoutSupplementaryItem Create (NSCollectionLayoutSize layoutSize, string elementKind, NSCollectionLayoutAnchor containerAnchor);

		[Static]
		[Export ("supplementaryItemWithLayoutSize:elementKind:containerAnchor:itemAnchor:")]
		static extern NSCollectionLayoutSupplementaryItem Create (NSCollectionLayoutSize layoutSize, string elementKind, NSCollectionLayoutAnchor containerAnchor, NSCollectionLayoutAnchor itemAnchor);

		[Export ("zIndex")]
		nint ZIndex { get; set; }

		[Export ("elementKind")]
		string ElementKind { get; }

		[Export ("containerAnchor")]
		NSCollectionLayoutAnchor ContainerAnchor { get; }

		[NullAllowed, Export ("itemAnchor")]
		NSCollectionLayoutAnchor ItemAnchor { get; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutItem : NSCopying {
		[Static]
		[Export ("itemWithLayoutSize:")]
		static extern NSCollectionLayoutItem Create (NSCollectionLayoutSize layoutSize);

		[Static]
		[Export ("itemWithLayoutSize:supplementaryItems:")]
		static extern NSCollectionLayoutItem Create (NSCollectionLayoutSize layoutSize, params NSCollectionLayoutSupplementaryItem [] supplementaryItems);

		//[Export ("contentInsets", ArgumentSemantic.Assign)]
		//NSDirectionalEdgeInsets ContentInsets { get; set; }

		[NullAllowed, Export ("edgeSpacing", ArgumentSemantic.Copy)]
		NSCollectionLayoutEdgeSpacing EdgeSpacing { get; set; }

		[Export ("layoutSize")]
		NSCollectionLayoutSize LayoutSize { get; }

		[Export ("supplementaryItems")]
		NSCollectionLayoutSupplementaryItem [] SupplementaryItems { get; }
	}

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSCollectionLayoutSupplementaryItem))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutBoundarySupplementaryItem : NSCopying {
		[Static]
		[Export ("boundarySupplementaryItemWithLayoutSize:elementKind:alignment:")]
		static extern NSCollectionLayoutBoundarySupplementaryItem Create (NSCollectionLayoutSize layoutSize, string elementKind, NSRectAlignment alignment);

		[Static]
		[Export ("boundarySupplementaryItemWithLayoutSize:elementKind:alignment:absoluteOffset:")]
		static extern NSCollectionLayoutBoundarySupplementaryItem Create (NSCollectionLayoutSize layoutSize, string elementKind, NSRectAlignment alignment, CGPoint absoluteOffset);

		[Export ("extendsBoundary")]
		bool ExtendsBoundary { get; set; }

		[Export ("pinToVisibleBounds")]
		bool PinToVisibleBounds { get; set; }

		[Export ("alignment")]
		NSRectAlignment Alignment { get; }

		[Export ("offset")]
		CGPoint Offset { get; }
	}

	[MacCatalyst (13, 1)]
	[TV (13, 0), iOS (13, 0)]
	[BaseType (typeof (NSCollectionLayoutItem))]
	[DisableDefaultCtor]
	partial class NSCollectionLayoutDecorationItem : NSCopying {
		[Static]
		[Export ("backgroundDecorationItemWithElementKind:")]
		static extern NSCollectionLayoutDecorationItem Create (string elementKind);

		[Export ("zIndex")]
		nint ZIndex { get; set; }

		[Export ("elementKind")]
		string ElementKind { get; }
	}

	/// <include file="../docs/api/UIKit/NSDataAsset.xml" path="/Documentation/Docs[@DocId='T:UIKit.NSDataAsset']/*" />
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // - (instancetype)init NS_UNAVAILABLE;
	partial class NSDataAsset : NSCopying {
		[Export ("initWithName:")]
		static extern NativeHandle Constructor (string name);

		[Export ("initWithName:bundle:")]
		[DesignatedInitializer]
		static extern NativeHandle Constructor (string name, NSBundle bundle);

		[Export ("name")]
		string Name { get; }

		[Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		[Export ("typeIdentifier")] // Uniform Type Identifier
		NSString TypeIdentifier { get; }
	}

	/// <summary>The visual attributes associated with a drop shadow.</summary>
	///     <remarks>
	///       <para>The <see cref="T:UIKit.NSShadow" /> class encapsulates the visual attributes of a drop shadow.</para>
	///     </remarks>
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Cocoa/Reference/ApplicationKit/Classes/NSShadow_Class/index.html">Apple documentation for <c>NSShadow</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class NSShadow : NSCopying {
		
		public NSShadow(NativeHandle handle) : base(handle) {}
		
		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("set")]
		public extern void Set ();

		[Export ("shadowOffset", ArgumentSemantic.Assign)]
		public CGSize ShadowOffset { get; set; }

		[Export ("shadowBlurRadius", ArgumentSemantic.Assign)]
		public nfloat ShadowBlurRadius { get; set; }

#if MONOMAC
		[Export ("shadowColor", ArgumentSemantic.Copy)]
#else
		[Export ("shadowColor", ArgumentSemantic.Retain), NullAllowed]
#endif
		public NSColor ShadowColor { get; set; }
	}

	/// <summary>Represents a tab location in Text Kit.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/UIKit/Reference/NSTextTab_Class_TextKit/index.html">Apple documentation for <c>NSTextTab</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class NSTextTab : NSCopying {
		[DesignatedInitializer]
		[Export ("initWithTextAlignment:location:options:")]
		[PostGet ("Options")]
		public extern NativeHandle Constructor (TextAlignment alignment, nfloat location, NSDictionary options);

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("initWithType:location:")]
		public extern NativeHandle Constructor (NSTextTabType type, nfloat location);

		[Export ("alignment")]
		public TextAlignment Alignment { get; }

		[Export ("options")]
		public NSDictionary Options { get; }

		[Export ("location")]
		public nfloat Location { get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("tabStopType")]
		public NSTextTabType TabStopType { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("columnTerminatorsForLocale:")]
		public static extern NSCharacterSet GetColumnTerminators ([NullAllowed] NSLocale locale);

		[Field ("NSTabColumnTerminatorsAttributeName")]
		public NSString ColumnTerminatorsAttributeName { get; }
	}

	[MacCatalyst (13, 1)]
	[Protocol]
	// no [Model] since it's not exposed in any API
	// only NSTextContainer conforms to it but it's only queried by iOS itself
	public partial class NSTextLayoutOrientationProvider {
		[Abstract]
		[Export ("layoutOrientation")]
		NSTextLayoutOrientation LayoutOrientation {
			get;
		}
	}

	/// <include file="../docs/api/UIKit/NSTextContainer.xml" path="/Documentation/Docs[@DocId='T:UIKit.NSTextContainer']/*" />
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class NSTextContainer : NSTextLayoutOrientationProvider {
		[NoMac]
		[MacCatalyst (13, 1)]
		[DesignatedInitializer]
		[Export ("initWithSize:")]
		 extern NativeHandle Constructor (CGSize size);

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("initWithContainerSize:"), Internal]
		[Sealed]
		 extern IntPtr InitWithContainerSize (CGSize size);

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("initWithSize:"), Internal]
		[Sealed]
		 extern IntPtr InitWithSize (CGSize size);

		[NullAllowed] // by default this property is null
		[Export ("layoutManager", ArgumentSemantic.Assign)]
		NSLayoutManager LayoutManager { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("size")]
		CGSize Size { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("exclusionPaths", ArgumentSemantic.Copy)]
		BezierPath [] ExclusionPaths { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("lineBreakMode")]
		LineBreakMode LineBreakMode { get; set; }

		[Export ("lineFragmentPadding")]
		nfloat LineFragmentPadding { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("maximumNumberOfLines")]
		nuint MaximumNumberOfLines { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("lineFragmentRectForProposedRect:atIndex:writingDirection:remainingRect:")]
#if MONOMAC && !NET
		CGRect GetLineFragmentRect (CGRect proposedRect, nuint characterIndex, NSWritingDirection baseWritingDirection, ref CGRect remainingRect);
#else
		 extern CGRect GetLineFragmentRect (CGRect proposedRect, nuint characterIndex, NSWritingDirection baseWritingDirection, out CGRect remainingRect);
#endif

		[Export ("widthTracksTextView")]
		bool WidthTracksTextView { get; set; }

		[Export ("heightTracksTextView")]
		bool HeightTracksTextView { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("replaceLayoutManager:")]
		 extern void ReplaceLayoutManager (NSLayoutManager newLayoutManager);

		[MacCatalyst (13, 1)]
		[Export ("simpleRectangularTextContainer")]
		bool IsSimpleRectangularTextContainer { [Bind ("isSimpleRectangularTextContainer")] get; }

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11)]
		[Export ("containsPoint:")]
		 extern bool ContainsPoint (CGPoint point);

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Export ("textView", ArgumentSemantic.Weak)]
		NSTextView TextView { get; set; }

		[NoiOS]
		[NoMacCatalyst]
		[NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 11, message: "Use Size instead.")]
		[Export ("containerSize")]
		CGSize ContainerSize { get; set; }

		[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("textLayoutManager", ArgumentSemantic.Weak)]
		NSTextLayoutManager TextLayoutManager { get; }
	}

	/// <summary>String drawing extension methods for <see cref="T:Foundation.NSString" />.</summary>
	[ThreadSafe]
	//[Category, BaseType (typeof (NSString))]
	partial class NSExtendedStringDrawing: NSString {
		[MacCatalyst (13, 1)]
		[Export ("drawWithRect:options:attributes:context:")]
		extern void WeakDrawString (CGRect rect, NSStringDrawingOptions options, [NullAllowed] NSDictionary attributes, [NullAllowed] NSStringDrawingContext context);

		[MacCatalyst (13, 1)]
		[Wrap ("WeakDrawString (This, rect, options, attributes.GetDictionary (), context)")]
		extern void DrawString (CGRect rect, NSStringDrawingOptions options, StringAttributes attributes, [NullAllowed] NSStringDrawingContext context);

		[MacCatalyst (13, 1)]
		[Export ("boundingRectWithSize:options:attributes:context:")]
		extern CGRect WeakGetBoundingRect (CGSize size, NSStringDrawingOptions options, [NullAllowed] NSDictionary attributes, [NullAllowed] NSStringDrawingContext context);

		[MacCatalyst (13, 1)]
		[Wrap ("WeakGetBoundingRect (This, size, options, attributes.GetDictionary (), context)")]
		extern CGRect GetBoundingRect (CGSize size, NSStringDrawingOptions options, StringAttributes attributes, [NullAllowed] NSStringDrawingContext context);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	interface NSTextLayoutManagerDelegate {
		[Export ("textLayoutManager:textLayoutFragmentForLocation:inTextElement:")]
		NSTextLayoutFragment GetTextLayoutFragment (NSTextLayoutManager textLayoutManager, INSTextLocation location, NSTextElement textElement);

		[Export ("textLayoutManager:shouldBreakLineBeforeLocation:hyphenating:")]
		bool ShouldBreakLineBeforeLocation (NSTextLayoutManager textLayoutManager, INSTextLocation location, bool hyphenating);

		[Export ("textLayoutManager:renderingAttributesForLink:atLocation:defaultAttributes:")]
		[return: NullAllowed]
		NSDictionary<NSString, NSObject> GetRenderingAttributes (NSTextLayoutManager textLayoutManager, NSObject link, INSTextLocation location, NSDictionary<NSString, NSObject> renderingAttributes);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextLayoutManagerSegmentType : long {
		Standard = 0,
		Selection = 1,
		Highlight = 2,
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Flags]
	[Native]
	public enum NSTextLayoutManagerSegmentOptions : ulong {
		None = 0x0,
		RangeNotRequired = (1uL << 0),
		MiddleFragmentsExcluded = (1uL << 1),
		HeadSegmentExtended = (1uL << 2),
		TailSegmentExtended = (1uL << 3),
		UpstreamAffinity = (1uL << 4),
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Flags]
	[Native]
	public enum NSTextLayoutFragmentEnumerationOptions : ulong {
		None = 0x0,
		Reverse = (1uL << 0),
		EstimatesSize = (1uL << 1),
		EnsuresLayout = (1uL << 2),
		EnsuresExtraLineFragment = (1uL << 3),
	}

	interface INSTextLayoutManagerDelegate { }

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	delegate bool NSTextLayoutManagerEnumerateRenderingAttributesDelegate (NSTextLayoutManager textLayoutManager, NSDictionary<NSString, NSObject> attributes, NSTextRange textRange);

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	delegate bool NSTextLayoutManagerEnumerateTextSegmentsDelegate (NSTextRange textSegmentRange, CGRect textSegmentFrame, nfloat baselinePosition, NSTextContainer textContainer);

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	//[DesignatedDefaultCtor]
	[BaseType (typeof (NSObject))]
	public partial class NSTextLayoutManager :  NSTextSelectionDataSource {
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSTextLayoutManagerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export ("usesFontLeading")]
		bool UsesFontLeading { get; set; }

		[Export ("limitsLayoutForSuspiciousContents")]
		bool LimitsLayoutForSuspiciousContents { get; set; }

		[Export ("usesHyphenation")]
		bool UsesHyphenation { get; set; }

		[NullAllowed, Export ("textContentManager", ArgumentSemantic.Weak)]
		NSTextContentManager TextContentManager { get; }

		[Export ("replaceTextContentManager:")]
		extern void Replace (NSTextContentManager textContentManager);

		[NullAllowed, Export ("textContainer", ArgumentSemantic.Strong)]
		NSTextContainer TextContainer { get; set; }

		[Export ("usageBoundsForTextContainer")]
		CGRect UsageBoundsForTextContainer { get; }

		[Export ("textViewportLayoutController", ArgumentSemantic.Strong)]
		NSTextViewportLayoutController TextViewportLayoutController { get; }

		[NullAllowed, Export ("layoutQueue", ArgumentSemantic.Strong)]
		NSOperationQueue LayoutQueue { get; set; }

		[Export ("ensureLayoutForRange:")]
		extern void EnsureLayout (NSTextRange range);

		[Export ("ensureLayoutForBounds:")]
		extern void EnsureLayout (CGRect bounds);

		[Export ("invalidateLayoutForRange:")]
		extern void InvalidateLayout (NSTextRange range);

		[Export ("textLayoutFragmentForPosition:")]
		[return: NullAllowed]
		extern NSTextLayoutFragment GetTextLayoutFragment (CGPoint position);

		[Export ("textLayoutFragmentForLocation:")]
		[return: NullAllowed]
		extern NSTextLayoutFragment GetTextLayoutFragment (INSTextLocation location);

		[Export ("enumerateTextLayoutFragmentsFromLocation:options:usingBlock:")]
		[return: NullAllowed]
		extern INSTextLocation EnumerateTextLayoutFragments ([NullAllowed] INSTextLocation location, NSTextLayoutFragmentEnumerationOptions options, Func<NSTextLayoutFragment, bool> handler);

		[Export ("textSelections", ArgumentSemantic.Strong)]
		NSTextSelection [] TextSelections { get; set; }

		[Export ("textSelectionNavigation", ArgumentSemantic.Strong)]
		NSTextSelectionNavigation TextSelectionNavigation { get; set; }

		[Export ("enumerateRenderingAttributesFromLocation:reverse:usingBlock:")]
		extern void EnumerateRenderingAttributes (INSTextLocation location, bool reverse, NSTextLayoutManagerEnumerateRenderingAttributesDelegate handler);

		[Export ("setRenderingAttributes:forTextRange:")]
		extern void SetRenderingAttributes (NSDictionary<NSString, NSObject> renderingAttributes, NSTextRange textRange);

		[Export ("addRenderingAttribute:value:forTextRange:")]
		extern void AddRenderingAttribute (string renderingAttribute, [NullAllowed] NSObject value, NSTextRange textRange);

		[Export ("removeRenderingAttribute:forTextRange:")]
		extern void RemoveRenderingAttribute (string renderingAttribute, NSTextRange textRange);

		[Export ("invalidateRenderingAttributesForTextRange:")]
		extern void InvalidateRenderingAttributes (NSTextRange textRange);

		[NullAllowed, Export ("renderingAttributesValidator", ArgumentSemantic.Copy)]
		Action<NSTextLayoutManager, NSTextLayoutFragment> RenderingAttributesValidator { get; set; }

		[Static]
		[Export ("linkRenderingAttributes")]
		NSDictionary<NSString, NSObject> LinkRenderingAttributes { get; }

		[Export ("renderingAttributesForLink:atLocation:")]
		extern NSDictionary<NSString, NSObject> GetRenderingAttributes (NSObject link, INSTextLocation location);

		[Export ("enumerateTextSegmentsInRange:type:options:usingBlock:")]
		extern void EnumerateTextSegments (NSTextRange textRange, NSTextLayoutManagerSegmentType type, NSTextLayoutManagerSegmentOptions options, NSTextLayoutManagerEnumerateTextSegmentsDelegate handler);

		[Export ("replaceContentsInRange:withTextElements:")]
		extern void ReplaceContents (NSTextRange range, NSTextElement [] textElements);

		[Export ("replaceContentsInRange:withAttributedString:")]
		extern void ReplaceContents (NSTextRange range, NSAttributedString attributedString);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Flags]
	[Native]
	public enum NSTextContentManagerEnumerationOptions : ulong {
		None = 0x0,
		Reverse = (1uL << 0),
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	interface NSTextContentManagerDelegate {
		[Export ("textContentManager:textElementAtLocation:")]
		[return: NullAllowed]
		NSTextElement GetTextContentManager (NSTextContentManager textContentManager, INSTextLocation location);

		[Export ("textContentManager:shouldEnumerateTextElement:options:")]
		bool ShouldEnumerateTextElement (NSTextContentManager textContentManager, NSTextElement textElement, NSTextContentManagerEnumerationOptions options);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Protocol]
	partial class NSTextElementProvider {
		[Abstract]
		[Export ("documentRange", ArgumentSemantic.Strong)]
		NSTextRange DocumentRange { get; }

		[Abstract]
		[Export ("enumerateTextElementsFromLocation:options:usingBlock:")]
		[return: NullAllowed]
		extern INSTextLocation? EnumerateTextElements ([NullAllowed] INSTextLocation textLocation, NSTextContentManagerEnumerationOptions options, Func<NSTextElement, bool> handler);

		[Abstract]
		[Export ("replaceContentsInRange:withTextElements:")]
		extern void ReplaceContents (NSTextRange range, [NullAllowed] NSTextElement [] textElements);

		[Abstract]
		[Export ("synchronizeToBackingStore:")]
		extern void Synchronize ([NullAllowed] Action<NSError> completionHandler);

		[Export ("locationFromLocation:withOffset:")]
		[return: NullAllowed]
		extern INSTextLocation GetLocation (INSTextLocation location, nint offset);

		[Export ("offsetFromLocation:toLocation:")]
		extern nint GetOffset (INSTextLocation from, INSTextLocation to);

		[Export ("adjustedRangeFromRange:forEditingTextSelection:")]
		[return: NullAllowed]
		extern NSTextRange AdjustedRange (NSTextRange textRange, bool forEditingTextSelection);
	}

	interface INSTextContentManagerDelegate { }

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSTextContentManager : NSTextElementProvider {
		[Notification]
		[Field ("NSTextContentStorageUnsupportedAttributeAddedNotification")]
		NSString StorageUnsupportedAttributeAddedNotification { get; }

		[DesignatedInitializer]
		[Export ("init")]
		extern NativeHandle Constructor ();

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSTextContentManagerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export ("textLayoutManagers", ArgumentSemantic.Copy)]
		NSTextLayoutManager [] TextLayoutManagers { get; }

		[Export ("addTextLayoutManager:")]
		extern void Add (NSTextLayoutManager textLayoutManager);

		[Export ("removeTextLayoutManager:")]
		extern void Remove (NSTextLayoutManager textLayoutManager);

		[NullAllowed, Export ("primaryTextLayoutManager", ArgumentSemantic.Strong)]
		NSTextLayoutManager PrimaryTextLayoutManager { get; set; }

		[Async]
		[Export ("synchronizeTextLayoutManagers:")]
		extern void SynchronizeTextLayoutManagers ([NullAllowed] Action<NSError> completionHandler);

		[Export ("textElementsForRange:")]
		extern NSTextElement [] GetTextElements (NSTextRange range);

		[Export ("hasEditingTransaction")]
		bool HasEditingTransaction { get; }

		[Async]
		[Export ("performEditingTransactionUsingBlock:")]
		extern void PerformEditingTransaction (Action transaction);

		[Export ("recordEditActionInRange:newTextRange:")]
		extern void RecordEditAction (NSTextRange originalTextRange, NSTextRange newTextRange);

		[Export ("automaticallySynchronizesTextLayoutManagers")]
		bool AutomaticallySynchronizesTextLayoutManagers { get; set; }

		[Export ("automaticallySynchronizesToBackingStore")]
		bool AutomaticallySynchronizesToBackingStore { get; set; }
	}

	public interface INSTextLocation { }

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Protocol]
	interface NSTextLocation {
		[Abstract]
		[Export ("compare:")]
		NSComparisonResult Compare (INSTextLocation location);
	}

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	partial class NSTextElement: NSObject {
		[Export ("initWithTextContentManager:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor ([NullAllowed] NSTextContentManager textContentManager);

		[NullAllowed, Export ("textContentManager", ArgumentSemantic.Weak)]
		NSTextContentManager TextContentManager { get; set; }

		[NullAllowed, Export ("elementRange", ArgumentSemantic.Strong)]
		NSTextRange ElementRange { get; set; }

		[TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("childElements", ArgumentSemantic.Copy)]
		NSTextElement [] ChildElements { get; }

		[TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[NullAllowed, Export ("parentElement", ArgumentSemantic.Weak)]
		NSTextElement ParentElement { get; }

		[TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("isRepresentedElement")]
		bool IsRepresentedElement { get; }
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSTextElement))]
	interface NSTextParagraph {
		[Export ("initWithAttributedString:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSAttributedString attributedString);

		[Export ("initWithTextContentManager:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSTextContentManager textContentManager);

		[Export ("attributedString", ArgumentSemantic.Strong)]
		NSAttributedString AttributedString { get; }

		[NullAllowed, Export ("paragraphContentRange", ArgumentSemantic.Strong)]
		NSTextRange ParagraphContentRange { get; }

		[NullAllowed, Export ("paragraphSeparatorRange", ArgumentSemantic.Strong)]
		NSTextRange ParagraphSeparatorRange { get; }
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSTextLineFragment : NSSecureCoding {
		[Export ("initWithAttributedString:range:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (NSAttributedString attributedString, NSRange range);

		[Export ("initWithString:attributes:range:")]
		extern NativeHandle Constructor (string @string, NSDictionary<NSString, NSObject> attributes, NSRange range);

		[Export ("attributedString", ArgumentSemantic.Strong)]
		NSAttributedString AttributedString { get; }

		[Export ("characterRange")]
		NSRange CharacterRange { get; }

		[Export ("typographicBounds")]
		CGRect TypographicBounds { get; }

		[Export ("glyphOrigin")]
		CGPoint GlyphOrigin { get; }

		[Export ("drawAtPoint:inContext:")]
		extern void Draw (CGPoint point, CGContext context);

		[Export ("locationForCharacterAtIndex:")]
		extern CGPoint GetLocation (nint characterIndex);

		[Export ("characterIndexForPoint:")]
		extern nint GetCharacterIndex (CGPoint point);

		[Export ("fractionOfDistanceThroughGlyphForPoint:")]
		extern nfloat GetFractionOfDistanceThroughGlyph (CGPoint point);
	}

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextLayoutFragmentState : ulong {
		None = 0,
		EstimatedUsageBounds = 1,
		CalculatedUsageBounds = 2,
		LayoutAvailable = 3,
	}

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public partial class NSTextAttachmentViewProvider {
		[Export ("initWithTextAttachment:parentView:textLayoutManager:location:")]
		[DesignatedInitializer]
		public extern NativeHandle Constructor (NSTextAttachment textAttachment, [NullAllowed] View parentView, [NullAllowed] NSTextLayoutManager textLayoutManager, INSTextLocation location);

		[NullAllowed, Export ("textAttachment", ArgumentSemantic.Weak)]
		public NSTextAttachment TextAttachment { get; }

		[NullAllowed, Export ("textLayoutManager", ArgumentSemantic.Weak)]
		public NSTextLayoutManager TextLayoutManager { get; }

		[Export ("location", ArgumentSemantic.Strong)]
		public INSTextLocation Location { get; }

		[NullAllowed, Export ("view", ArgumentSemantic.Strong)]
		public View View { get; set; }

		[Export ("loadView")]
		public extern void LoadView ();

		[Export ("tracksTextAttachmentViewBounds")]
		public extern bool TracksTextAttachmentViewBounds { get; set; }

		[Export ("attachmentBoundsForAttributes:location:textContainer:proposedLineFragment:position:")]
		public extern CGRect GetAttachmentBounds (NSDictionary<NSString, NSObject> attributes, INSTextLocation location, [NullAllowed] NSTextContainer textContainer, CGRect proposedLineFragment, CGPoint position);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSTextLayoutFragment : NSSecureCoding {
		[Export ("initWithTextElement:range:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (NSTextElement textElement, [NullAllowed] NSTextRange rangeInElement);

		[NullAllowed, Export ("textLayoutManager", ArgumentSemantic.Weak)]
		NSTextLayoutManager TextLayoutManager { get; }

		[NullAllowed, Export ("textElement", ArgumentSemantic.Weak)]
		NSTextElement TextElement { get; }

		[Export ("rangeInElement", ArgumentSemantic.Strong)]
		NSTextRange RangeInElement { get; }

		[Export ("textLineFragments", ArgumentSemantic.Copy)]
		NSTextLineFragment [] TextLineFragments { get; }

		[NullAllowed, Export ("layoutQueue", ArgumentSemantic.Strong)]
		NSOperationQueue LayoutQueue { get; set; }

		[Export ("state")]
		NSTextLayoutFragmentState State { get; }

		[Export ("invalidateLayout")]
		extern void InvalidateLayout ();

		[Export ("layoutFragmentFrame")]
		CGRect LayoutFragmentFrame { get; }

		[Export ("renderingSurfaceBounds")]
		CGRect RenderingSurfaceBounds { get; }

		[Export ("leadingPadding")]
		nfloat LeadingPadding { get; }

		[Export ("trailingPadding")]
		nfloat TrailingPadding { get; }

		[Export ("topMargin")]
		nfloat TopMargin { get; }

		[Export ("bottomMargin")]
		nfloat BottomMargin { get; }

		[Export ("drawAtPoint:inContext:")]
		extern void Draw (CGPoint point, CGContext context);

		[Export ("textAttachmentViewProviders", ArgumentSemantic.Copy)]
		NSTextAttachmentViewProvider [] TextAttachmentViewProviders { get; }

		[Export ("frameForTextAttachmentAtLocation:")]
		extern CGRect GetFrameForTextAttachment (INSTextLocation location);

		[TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("textLineFragmentForVerticalOffset:requiresExactMatch:")]
		[return: NullAllowed]
		extern NSTextLineFragment GetTextLineFragment (nfloat verticalOffset, bool requiresExactMatch);

		[TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		[Export ("textLineFragmentForTextLocation:isUpstreamAffinity:")]
		[return: NullAllowed]
		extern NSTextLineFragment GetTextLineFragment (INSTextLocation textLocation, bool isUpstreamAffinity);
	}

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	//[DisableDefaultCtor]
	public class NSTextRange : NSObject {
		[Export ("initWithLocation:endLocation:")]
		[DesignatedInitializer]
		public extern NativeHandle Constructor (INSTextLocation location, [NullAllowed] INSTextLocation endLocation);

		[Export ("initWithLocation:")]
		public extern NativeHandle Constructor (INSTextLocation location);

		[Export ("empty")]
		public extern bool Empty { [Bind ("isEmpty")] get; }

		[Export ("location", ArgumentSemantic.Strong)]
		public extern INSTextLocation Location { get; }

		[Export ("endLocation", ArgumentSemantic.Strong)]
		public extern INSTextLocation EndLocation { get; }

		[Export ("isEqualToTextRange:")]
		public extern bool IsEqual (NSTextRange textRange);

		[Export ("containsLocation:")]
		public extern bool Contains (INSTextLocation location);

		[Export ("containsRange:")]
		public extern bool Contains (NSTextRange textRange);

		[Export ("intersectsWithTextRange:")]
		public extern bool Intersects (NSTextRange textRange);

		[Export ("textRangeByIntersectingWithTextRange:")]
		[return: NullAllowed]
		public extern NSTextRange GetTextRangeByIntersecting (NSTextRange textRange);

		[Export ("textRangeByFormingUnionWithTextRange:")]
		public extern NSTextRange GetTextRangeByFormingUnion (NSTextRange textRange);
	}

	interface INSTextViewportLayoutControllerDelegate { }

	[TV (15, 0), iOS (15, 0)]
	[MacCatalyst (15, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	interface NSTextViewportLayoutControllerDelegate {
		[Abstract]
		[Export ("viewportBoundsForTextViewportLayoutController:")]
		CGRect GetViewportBounds (NSTextViewportLayoutController textViewportLayoutController);

		[Abstract]
		[Export ("textViewportLayoutController:configureRenderingSurfaceForTextLayoutFragment:")]
		void ConfigureRenderingSurface (NSTextViewportLayoutController textViewportLayoutController, NSTextLayoutFragment textLayoutFragment);

		[Export ("textViewportLayoutControllerWillLayout:")]
		void WillLayout (NSTextViewportLayoutController textViewportLayoutController);

		[Export ("textViewportLayoutControllerDidLayout:")]
		void DidLayout (NSTextViewportLayoutController textViewportLayoutController);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSTextViewportLayoutController {
		[Export ("initWithTextLayoutManager:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSTextLayoutManager textLayoutManager);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		INSTextViewportLayoutControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[NullAllowed, Export ("textLayoutManager", ArgumentSemantic.Weak)]
		NSTextLayoutManager TextLayoutManager { get; }

		[Export ("viewportBounds")]
		CGRect ViewportBounds { get; }

		[NullAllowed, Export ("viewportRange")]
		NSTextRange ViewportRange { get; }

		[Export ("layoutViewport")]
		void LayoutViewport ();

		[Export ("relocateViewportToTextLocation:")]
		nfloat RelocateViewport (INSTextLocation textLocation);

		[Export ("adjustViewportByVerticalOffset:")]
		void AdjustViewport (nfloat verticalOffset);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextSelectionGranularity : long {
		Character,
		Word,
		Paragraph,
		Line,
		Sentence,
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextSelectionAffinity : long {
		Upstream = 0,
		Downstream = 1,
	}


	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	partial class NSTextSelection : NSSecureCoding {
		[Export ("initWithRanges:affinity:granularity:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (NSTextRange [] textRanges, NSTextSelectionAffinity affinity, NSTextSelectionGranularity granularity);

		[Export ("initWithRange:affinity:granularity:")]
		extern NativeHandle Constructor (NSTextRange range, NSTextSelectionAffinity affinity, NSTextSelectionGranularity granularity);

		[Export ("initWithLocation:affinity:")]
		extern NativeHandle Constructor (INSTextLocation location, NSTextSelectionAffinity affinity);

		[Export ("textRanges", ArgumentSemantic.Copy)]
		NSTextRange [] TextRanges { get; }

		[Export ("granularity")]
		NSTextSelectionGranularity Granularity { get; }

		[Export ("affinity")]
		NSTextSelectionAffinity Affinity { get; }

		[Export ("transient")]
		bool Transient { [Bind ("isTransient")] get; }

		[Export ("anchorPositionOffset")]
		nfloat AnchorPositionOffset { get; set; }

		[Export ("logical")]
		bool Logical { [Bind ("isLogical")] get; set; }

		[NullAllowed, Export ("secondarySelectionLocation", ArgumentSemantic.Strong)]
		INSTextLocation SecondarySelectionLocation { get; set; }

		[Export ("typingAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> TypingAttributes { get; set; }

		[Export ("textSelectionWithTextRanges:")]
		extern NSTextSelection GetTextSelection (NSTextRange [] textRanges);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	delegate void NSTextSelectionDataSourceEnumerateSubstringsDelegate (NSString substring, NSTextRange substringRange, NSTextRange enclodingRange, out bool stop);

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	delegate void NSTextSelectionDataSourceEnumerateCaretOffsetsDelegate (nfloat caretOffset, INSTextLocation location, bool leadingEdge, out bool stop);

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	delegate void NSTextSelectionDataSourceEnumerateContainerBoundariesDelegate (INSTextLocation location, out bool stop);

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextSelectionNavigationLayoutOrientation : long {
		Horizontal = 0,
		Vertical = 1,
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextSelectionNavigationWritingDirection : long {
		LeftToRight = 0,
		RightToLeft = 1,
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	public partial class NSTextSelectionDataSource: NSObject {
		[Abstract]
		[Export ("documentRange", ArgumentSemantic.Strong)]
		NSTextRange DocumentRange { get; }

		[Abstract]
		[Export ("enumerateSubstringsFromLocation:options:usingBlock:")]
		extern void EnumerateSubstrings (INSTextLocation location, NSStringEnumerationOptions options, NSTextSelectionDataSourceEnumerateSubstringsDelegate handler);

		[Abstract]
		[Export ("textRangeForSelectionGranularity:enclosingLocation:")]
		[return: NullAllowed]
		extern NSTextRange GetTextRange (NSTextSelectionGranularity selectionGranularity, INSTextLocation location);

		[Abstract]
		[Export ("locationFromLocation:withOffset:")]
		[return: NullAllowed]
		extern INSTextLocation GetLocation (INSTextLocation location, nint offset);

		[Abstract]
		[Export ("offsetFromLocation:toLocation:")]
		extern  nint GetOffsetFromLocation (INSTextLocation from, INSTextLocation to);

		[Abstract]
		[Export ("baseWritingDirectionAtLocation:")]
		extern NSTextSelectionNavigationWritingDirection GetBaseWritingDirection (INSTextLocation location);

		[Abstract]
		[Export ("enumerateCaretOffsetsInLineFragmentAtLocation:usingBlock:")]
		extern void EnumerateCaretOffsets (INSTextLocation location, NSTextSelectionDataSourceEnumerateCaretOffsetsDelegate handler);

		[Abstract]
		[Export ("lineFragmentRangeForPoint:inContainerAtLocation:")]
		[return: NullAllowed]
		extern NSTextRange GetLineFragmentRange (CGPoint point, INSTextLocation location);

		[Export ("enumerateContainerBoundariesFromLocation:reverse:usingBlock:")]
		extern void EnumerateContainerBoundaries (INSTextLocation location, bool reverse, NSTextSelectionDataSourceEnumerateContainerBoundariesDelegate handler);

		[Export ("textLayoutOrientationAtLocation:")]
		extern NSTextSelectionNavigationLayoutOrientation GetTextLayoutOrientation (INSTextLocation location);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextSelectionNavigationDirection : long {
		Forward,
		Backward,
		Right,
		Left,
		Up,
		Down,
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Native]
	public enum NSTextSelectionNavigationDestination : long {
		Character,
		Word,
		Line,
		Sentence,
		Paragraph,
		Container,
		Document,
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[Flags]
	[Native]
	public enum NSTextSelectionNavigationModifier : ulong {
		Extend = (1uL << 0),
		Visual = (1uL << 1),
		Multiple = (1uL << 2),
	}

	interface INSTextSelectionDataSource { }

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface NSTextSelectionNavigation {
		[Export ("initWithDataSource:")]
		[DesignatedInitializer]
		NativeHandle Constructor (INSTextSelectionDataSource dataSource);

		[Wrap ("WeakTextSelectionDataSource")]
		[NullAllowed]
		INSTextSelectionDataSource TextSelectionDataSource { get; }

		[NullAllowed, Export ("textSelectionDataSource", ArgumentSemantic.Weak)]
		NSObject WeakTextSelectionDataSource { get; }

		[Export ("allowsNonContiguousRanges")]
		bool AllowsNonContiguousRanges { get; set; }

		[Export ("rotatesCoordinateSystemForLayoutOrientation")]
		bool RotatesCoordinateSystemForLayoutOrientation { get; set; }

		[Export ("flushLayoutCache")]
		void FlushLayoutCache ();

		[Export ("destinationSelectionForTextSelection:direction:destination:extending:confined:")]
		[return: NullAllowed]
		NSTextSelection GetDestinationSelection (NSTextSelection textSelection, NSTextSelectionNavigationDirection direction, NSTextSelectionNavigationDestination destination, bool extending, bool confined);

		[Export ("textSelectionsInteractingAtPoint:inContainerAtLocation:anchors:modifiers:selecting:bounds:")]
		NSTextSelection [] GetTextSelectionsInteracting (CGPoint point, INSTextLocation containerLocation, NSTextSelection [] anchors, NSTextSelectionNavigationModifier modifiers, bool selecting, CGRect bounds);

		[Export ("textSelectionForSelectionGranularity:enclosingTextSelection:")]
		NSTextSelection GetTextSelection (NSTextSelectionGranularity selectionGranularity, NSTextSelection textSelection);

		[Export ("textSelectionForSelectionGranularity:enclosingPoint:inContainerAtLocation:")]
		[return: NullAllowed]
		NSTextSelection GetTextSelection (NSTextSelectionGranularity selectionGranularity, CGPoint point, INSTextLocation location);

		[Export ("resolvedInsertionLocationForTextSelection:writingDirection:")]
		[return: NullAllowed]
		INSTextLocation GetResolvedInsertionLocation (NSTextSelection textSelection, NSTextSelectionNavigationWritingDirection writingDirection);

		[Export ("deletionRangesForTextSelection:direction:destination:allowsDecomposition:")]
		NSTextRange [] GetDeletionRanges (NSTextSelection textSelection, NSTextSelectionNavigationDirection direction, NSTextSelectionNavigationDestination destination, bool allowsDecomposition);
	}

	[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	interface NSTextContentStorageDelegate : NSTextContentManagerDelegate {
		[Export ("textContentStorage:textParagraphWithRange:")]
		[return: NullAllowed]
		NSTextParagraph GetTextParagraph (NSTextContentStorage textContentStorage, NSRange range);
	}

	public interface INSTextContentStorageDelegate { }



	//[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
	enum NSTextListMarkerFormats {
		//[DefaultEnumValue]
		[Field (null)]
		CustomString = -1,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerBox")]
		Box,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerCheck")]
		Check,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerCircle")]
		Circle,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerDiamond")]
		Diamond,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerDisc")]
		Disc,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerHyphen")]
		Hyphen,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerSquare")]
		Square,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerLowercaseHexadecimal")]
		LowercaseHexadecimal,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerUppercaseHexadecimal")]
		UppercaseHexadecimal,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerOctal")]
		Octal,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerLowercaseAlpha")]
		LowercaseAlpha,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerUppercaseAlpha")]
		UppercaseAlpha,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerLowercaseLatin")]
		LowercaseLatin,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerUppercaseLatin")]
		UppercaseLatin,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerLowercaseRoman")]
		LowercaseRoman,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerUppercaseRoman")]
		UppercaseRoman,

		[MacCatalyst (13, 1)]
		[Field ("NSTextListMarkerDecimal")]
		Decimal,
	}

	[TV (16, 0), iOS (16, 0), MacCatalyst (16, 0)]
	[Flags]
	[Native]
	public enum NSTextListOptions : ulong {
		None = 0,
		PrependEnclosingMarker = 1,
	}

	//[TV (15, 0), iOS (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSTextContentManager))]
	public class NSTextContentStorage : NSTextStorageObserving {
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		public extern INSTextContentStorageDelegate? Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		public extern NSObject? WeakDelegate { get; set; }

		[NullAllowed, Export ("attributedString", ArgumentSemantic.Copy)]
		public extern NSAttributedString? AttributedString { get; set; }

		[Export ("attributedStringForTextElement:")]
		[return: NullAllowed]
		extern NSAttributedString? GetAttributedString (NSTextElement textElement);

		[Export ("textElementForAttributedString:")]
		[return: NullAllowed]
		extern NSTextElement? GetTextElement (NSAttributedString attributedString);

		[Export ("locationFromLocation:withOffset:")]
		[return: NullAllowed]
		public extern INSTextLocation? GetLocation (INSTextLocation location, nint offset);

		[Export ("offsetFromLocation:toLocation:")]
		public extern nint GetOffset (INSTextLocation from, INSTextLocation to);

		[Export ("adjustedRangeFromRange:forEditingTextSelection:")]
		[return: NullAllowed]
		public extern NSTextRange? GetAdjustedRange (NSTextRange textRange, bool forEditingTextSelection);
	}

	[MacCatalyst (13, 0)]
	[BaseType (typeof (NSObject))]
	partial class NSTextList : NSCopying {
		[Export ("initWithMarkerFormat:options:")]
		extern NativeHandle Constructor (string format, NSTextListOptions mask);

		[Wrap ("this (format, NSTextListOptions.None)")]
		extern NativeHandle Constructor (string format);

		[Wrap ("this (format.GetConstant(), mask)")]
		extern NativeHandle Constructor (NSTextListMarkerFormats format, NSTextListOptions mask);

		[Wrap ("this (format.GetConstant(), NSTextListOptions.None)")]
		extern NativeHandle Constructor (NSTextListMarkerFormats format);

#if NET
		[BindAs (typeof (NSTextListMarkerFormats))] 
#endif
		[Export ("markerFormat")]
#if NET
		NSString MarkerFormat { get; }
#else
		[Obsolete ("Use 'CustomMarkerFormat' instead.")]
		[EditorBrowsable (EditorBrowsableState.Never)]
		string MarkerFormat { get; }
#endif

		[Sealed]
		[Export ("markerFormat")]
		string CustomMarkerFormat { get; }

		[TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("initWithMarkerFormat:options:startingItemNumber:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (string markerFormat, NSTextListOptions options, nint startingItemNumber);

		[Export ("listOptions")]
		NSTextListOptions ListOptions { get; }

		[Export ("markerForItemNumber:")]
		extern string GetMarker (nint itemNum);

		//Detected properties
		[Export ("startingItemNumber")]
		nint StartingItemNumber { get; set; }

		[TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("ordered")]
		bool Ordered { [Bind ("isOrdered")] get; }

	}

	[TV (16, 0), Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
	[BaseType (typeof (NSTextParagraph))]
	interface NSTextListElement {
		[Export ("initWithAttributedString:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSAttributedString attributedString);

		[Export ("initWithTextContentManager:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSTextContentManager textContentManager);

		[Export ("initWithParentElement:textList:contents:markerAttributes:childElements:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSTextListElement parent, NSTextList textList, [NullAllowed] NSAttributedString contents, [NullAllowed] NSDictionary markerAttributes, [NullAllowed] NSTextListElement [] children);

		[Static]
		[Export ("textListElementWithContents:markerAttributes:textList:childElements:")]
		NSTextListElement Create (NSAttributedString contents, [NullAllowed] NSDictionary markerAttributes, NSTextList textList, [NullAllowed] NSTextListElement [] children);

		[Static]
		[Export ("textListElementWithChildElements:textList:nestingLevel:")]
		[return: NullAllowed]
		NSTextListElement Create (NSTextListElement [] children, NSTextList textList, nint nestingLevel);

		[Export ("textList", ArgumentSemantic.Strong)]
		NSTextList TextList { get; }

		[NullAllowed, Export ("contents", ArgumentSemantic.Strong)]
		NSAttributedString Contents { get; }

		[NullAllowed, Export ("markerAttributes", ArgumentSemantic.Strong)]
		NSDictionary WeakMarkerAttributes { get; }

		[Export ("attributedString", ArgumentSemantic.Strong)]
		NSAttributedString AttributedString { get; }

		[Export ("childElements", ArgumentSemantic.Copy)]
		NSTextListElement [] ChildElements { get; }

		[NullAllowed, Export ("parentElement", ArgumentSemantic.Weak)]
		NSTextListElement ParentElement { get; }
	}

	enum NSAttributedStringDocumentType {
		//[DefaultEnumValue]
		[Field (null)]
		Unknown = NSDocumentType.Unknown,

		[Field ("NSPlainTextDocumentType")]
		Plain = NSDocumentType.PlainText,

		[Field ("NSRTFDTextDocumentType")]
		Rtfd = NSDocumentType.RTFD,

		[Field ("NSRTFTextDocumentType")]
		Rtf = NSDocumentType.RTF,

		[Field ("NSHTMLTextDocumentType")]
		Html = NSDocumentType.HTML,

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSMacSimpleTextDocumentType")]
		MacSimple = NSDocumentType.MacSimpleText,

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSDocFormatTextDocumentType")]
		DocFormat = NSDocumentType.DocFormat,

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSWordMLTextDocumentType")]
		WordML = NSDocumentType.WordML,

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSWebArchiveTextDocumentType")]
		WebArchive = NSDocumentType.WebArchive,

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSOfficeOpenXMLTextDocumentType")]
		OfficeOpenXml = NSDocumentType.OfficeOpenXml,

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSOpenDocumentTextDocumentType")]
		OpenDocument = NSDocumentType.OpenDocument,
	}

	[Static]
	[Internal]
	public static partial class NSAttributedStringDocumentAttributeKey {
		[Field ("NSDocumentTypeDocumentAttribute")]
		public static NSString DocumentTypeDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSConvertedDocumentAttribute")]
		public static NSString ConvertedDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSFileTypeDocumentAttribute")]
		public static NSString FileTypeDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSTitleDocumentAttribute")]
		public static NSString TitleDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSCompanyDocumentAttribute")]
		public static NSString CompanyDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSCopyrightDocumentAttribute")]
		public static NSString CopyrightDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSSubjectDocumentAttribute")]
		public static NSString SubjectDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSAuthorDocumentAttribute")]
		public static NSString AuthorDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSKeywordsDocumentAttribute")]
		public static NSString KeywordsDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSCommentDocumentAttribute")]
		public static NSString CommentDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSEditorDocumentAttribute")]
		public static NSString EditorDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSCreationTimeDocumentAttribute")]
		public static NSString CreationTimeDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSModificationTimeDocumentAttribute")]
		public static NSString ModificationTimeDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSManagerDocumentAttribute")]
		public static NSString ManagerDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSCategoryDocumentAttribute")]
		public static NSString CategoryDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSAppearanceDocumentAttribute")]
		public static NSString AppearanceDocumentAttribute { get; }

		[Field ("NSCharacterEncodingDocumentAttribute")]
		public static NSString CharacterEncodingDocumentAttribute { get; }

		[Field ("NSDefaultAttributesDocumentAttribute")]
		public static NSString DefaultAttributesDocumentAttribute { get; }

		[Field ("NSPaperSizeDocumentAttribute")]
		public static NSString PaperSizeDocumentAttribute { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("NSPaperMarginDocumentAttribute")]
		public static NSString PaperMarginDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSLeftMarginDocumentAttribute")]
		public static NSString LeftMarginDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSRightMarginDocumentAttribute")]
		public static NSString RightMarginDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSTopMarginDocumentAttribute")]
		public static NSString TopMarginDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSBottomMarginDocumentAttribute")]
		public static NSString BottomMarginDocumentAttribute { get; }

		[Field ("NSViewSizeDocumentAttribute")]
		public static NSString ViewSizeDocumentAttribute { get; }

		[Field ("NSViewZoomDocumentAttribute")]
		public static NSString ViewZoomDocumentAttribute { get; }

		[Field ("NSViewModeDocumentAttribute")]
		public static NSString ViewModeDocumentAttribute { get; }

		[Field ("NSReadOnlyDocumentAttribute")]
		public static NSString ReadOnlyDocumentAttribute { get; }

		[Field ("NSBackgroundColorDocumentAttribute")]
		public static NSString BackgroundColorDocumentAttribute { get; }

		[Field ("NSHyphenationFactorDocumentAttribute")]
		public static NSString HyphenationFactorDocumentAttribute { get; }

		[Field ("NSDefaultTabIntervalDocumentAttribute")]
		public static NSString DefaultTabIntervalDocumentAttribute { get; }

		[Field ("NSTextLayoutSectionsAttribute")]
		public static NSString TextLayoutSectionsAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSExcludedElementsDocumentAttribute")]
		public static NSString ExcludedElementsDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSTextEncodingNameDocumentAttribute")]
		public static NSString TextEncodingNameDocumentAttribute { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSPrefixSpacesDocumentAttribute")]
		public static NSString PrefixSpacesDocumentAttribute { get; }

		[Field ("NSTextScalingDocumentAttribute")]
		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		public static NSString TextScalingDocumentAttribute { get; }

		[Field ("NSSourceTextScalingDocumentAttribute")]
		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		public static NSString SourceTextScalingDocumentAttribute { get; }

		[Field ("NSCocoaVersionDocumentAttribute")]
		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		public static NSString CocoaVersionDocumentAttribute { get; }

		[Field ("NSDefaultFontExcludedDocumentAttribute")]
		//[TV (17, 0), Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0)]
		public static NSString DefaultFontExcludedDocumentAttribute { get; }
	}

	[StrongDictionary (nameof (NSAttributedStringDocumentReadingOptionKey), Suffix = "DocumentOption")]
	interface NSAttributedStringDocumentReadingOptions {
#if XAMCORE_5_0
		[Export ("DocumentTypeDocumentOption")]
		NSAttributedStringDocumentType StrongDocumentType { get; set; }
#else
		NSAttributedStringDocumentType DocumentType { get; set; }
#endif

		// It's not documented which attributes go in this dictionary.
		NSDictionary DefaultAttributes { get; set; }

		NSStringEncoding CharacterEncoding { get; set; }

		[NoiOS, NoTV, NoMacCatalyst]
		WebPreferences WebPreferences { get; set; }

		[NoiOS, NoTV, NoMacCatalyst]
		NSObject WebResourceLoadDelegate { get; set; }

		[NoiOS, NoTV, NoMacCatalyst]
		NSUrl BaseUrl { get; set; }

		[NoiOS, NoTV, NoMacCatalyst]
		string TextEncodingName { get; set; }

		[NoiOS, NoTV, NoMacCatalyst]
		float TextSizeMultiplier { get; set; }

		[NoiOS, NoTV, NoMacCatalyst]
		float Timeout { get; set; }

		[iOS (13, 0)]
		[TV (13, 0)]
		NSTextScalingType TargetTextScaling { get; set; }

		[iOS (13, 0)]
		[TV (13, 0)]
		NSTextScalingType SourceTextScaling { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		bool TextKit1ListMarkerFormat { get; set; }
	}

	[Static]
	[Internal]
	public static class NSAttributedStringDocumentReadingOptionKey {
		[MacCatalyst (13, 1)]
		[Field ("NSDocumentTypeDocumentOption")]
		public static NSString DocumentTypeDocumentOption { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSDefaultAttributesDocumentOption")]
		public static NSString DefaultAttributesDocumentOption { get; }

		[MacCatalyst (13, 1)]
		[Field ("NSCharacterEncodingDocumentOption")]
		public static NSString CharacterEncodingDocumentOption { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSWebPreferencesDocumentOption")]
		public static NSString WebPreferencesDocumentOption { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSWebResourceLoadDelegateDocumentOption")]
		public static NSString WebResourceLoadDelegateDocumentOption { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSBaseURLDocumentOption")]
		public static NSString BaseUrlDocumentOption { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSTextEncodingNameDocumentOption")]
		public static NSString TextEncodingNameDocumentOption { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSTextSizeMultiplierDocumentOption")]
		public static NSString TextSizeMultiplierDocumentOption { get; }

		[NoiOS, NoTV, NoMacCatalyst]
		[Field ("NSTimeoutDocumentOption")]
		public static NSString TimeoutDocumentOption { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("NSTargetTextScalingDocumentOption")]
		public static NSString TargetTextScalingDocumentOption { get; }

		//[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Field ("NSSourceTextScalingDocumentOption")]
		public static NSString SourceTextScalingDocumentOption { get; }

		// comes from webkit
		//[iOS (13, 0), MacCatalyst (13, 1), NoTV]
		[Field ("NSReadAccessURLDocumentOption", "WebKit")]
		public static NSString ReadAccessUrlDocumentOption { get; }

		//[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Field ("NSTextKit1ListMarkerFormatDocumentOption")]
		public static NSString TextKit1ListMarkerFormatDocumentOption { get; }
	}

	//[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	public class NSAdaptiveImageGlyph :  CTAdaptiveImageProviding {
		[DesignatedInitializer]
		[Export ("initWithImageContent:")]
		extern NativeHandle Constructor (NSData imageContent);

		[Export ("imageContent")]
		NSData ImageContent { get; }

		[Export ("contentIdentifier")]
		string ContentIdentifier { get; }

		[Export ("contentDescription", ArgumentSemantic.Copy)]
		string ContentDescription { get; }

		[Static]
		[Export ("contentType")]
		UTType ContentType { get; }
	}

	[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum NSTextHighlightStyle {
		//[DefaultEnumValue]
		[Field ("NSTextHighlightStyleDefault")]
		Default,
	}

	[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum NSTextHighlightColorScheme {
		//[DefaultEnumValue]
		[Field ("NSTextHighlightColorSchemeDefault")]
		Default,
		[Field ("NSTextHighlightColorSchemePurple")]
		Purple,
		[Field ("NSTextHighlightColorSchemePink")]
		Pink,
		[Field ("NSTextHighlightColorSchemeOrange")]
		Orange,
		[Field ("NSTextHighlightColorSchemeMint")]
		Mint,
		[Field ("NSTextHighlightColorSchemeBlue")]
		Blue,

	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[Native]
#if MONOMAC
	public enum NSWritingToolsCoordinatorTextUpdateReason : long
#else
	public enum UIWritingToolsCoordinatorTextUpdateReason : long
#endif
	{
		Typing,
		UndoRedo,
	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[Native]
#if MONOMAC
	public enum NSWritingToolsCoordinatorState : long
#else
	public enum UIWritingToolsCoordinatorState : long
#endif
	{
		Inactive,
		Noninteractive,
		InteractiveResting,
		InteractiveStreaming,
	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[Native]
#if MONOMAC
	public enum NSWritingToolsCoordinatorTextReplacementReason : long
#else
	public enum UIWritingToolsCoordinatorTextReplacementReason : long
#endif
	{
		Interactive,
		Noninteractive,
	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[Native]
#if MONOMAC
	public enum NSWritingToolsCoordinatorContextScope : long
#else
	public enum UIWritingToolsCoordinatorContextScope : long
#endif
	{
		UserSelection,
		FullDocument,
		VisibleArea,
	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[Native]
#if MONOMAC
	public enum NSWritingToolsCoordinatorTextAnimation : long
#else
	public enum UIWritingToolsCoordinatorTextAnimation : long
#endif
	{
		Anticipate,
		Remove,
		Insert,
		[NoiOS, NoMacCatalyst]
		AnticipateInactive = 8,
		[NoiOS, NoMacCatalyst]
		Translate = 9,
	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[BaseType (typeof (NSObject))]
#if MONOMAC
	interface NSWritingToolsCoordinator
#else
	interface UIWritingToolsCoordinator : UIInteraction
#endif
	{
		[Static]
		[Export ("isWritingToolsAvailable")]
		bool IsWritingToolsAvailable { get; }

		[Export ("initWithDelegate:")]
		NativeHandle Constructor ([NullAllowed] IXWritingToolsCoordinatorDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IXWritingToolsCoordinatorDelegate Delegate { get; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

#if MONOMAC
		[NullAllowed, Export ("view", ArgumentSemantic.Weak)]
		View View { get; }
#endif

		[NullAllowed, Export ("effectContainerView", ArgumentSemantic.Weak)]
		View EffectContainerView { get; set; }

		[NullAllowed, Export ("decorationContainerView", ArgumentSemantic.Weak)]
		View DecorationContainerView { get; set; }

		[Export ("state")]
		XWritingToolsCoordinatorState State { get; }

		[Export ("stopWritingTools")]
		void StopWritingTools ();

		[Export ("preferredBehavior", ArgumentSemantic.Assign)]
		XWritingToolsBehavior PreferredBehavior { get; set; }

		[Export ("behavior")]
		XWritingToolsBehavior Behavior { get; }

		[Export ("preferredResultOptions", ArgumentSemantic.Assign)]
		XWritingToolsResultOptions PreferredResultOptions { get; set; }

		[Export ("resultOptions")]
		XWritingToolsResultOptions ResultOptions { get; }

		[Export ("updateRange:withText:reason:forContextWithIdentifier:")]
		void UpdateRange (NSRange range, NSAttributedString replacementText, XWritingToolsCoordinatorTextUpdateReason reason, NSUuid contextId);

		[Export ("updateForReflowedTextInContextWithIdentifier:")]
		void UpdateForReflowedTextInContext (NSUuid contextId);
	}

#if MONOMAC
	interface INSWritingToolsCoordinatorDelegate {}
#else
	interface IUIWritingToolsCoordinatorDelegate { }
#endif

#if MONOMAC
	delegate void NSWritingToolsCoordinatorDelegateRequestsContextsCallback (XWritingToolsCoordinatorContext[] contexts);
	delegate void NSWritingToolsCoordinatorDelegateReplaceRangeCallback ([NullAllowed] NSAttributedString replacementText);
	delegate void NSWritingToolsCoordinatorDelegateRequestsRangeCallback (NSRange range, NSUuid contextId);
	delegate void NSWritingToolsCoordinatorDelegateRequestsBoundingBezierPathsCallback (BezierPath[] paths);
	delegate void NSWritingToolsCoordinatorDelegateRequestsUnderlinePathsCallback (BezierPath[] paths);
	delegate void NSWritingToolsCoordinatorDelegateRequestsPreviewForTextAnimationCallback ([NullAllowed] NSTextPreview [] view); // different signature vs other platforms
	delegate void NSWritingToolsCoordinatorDelegateRequestsPreviewCallback ([NullAllowed] NSTextPreview textPreview); // doesn't exist on other platforms
	delegate void NSWritingToolsCoordinatorDelegateRequestsSingleContainerSubrangesCallback (/* [BindAs (typeof (NSRange[]))] */ NSValue[] ranges); // BindAs doesn't work here
	delegate void NSWritingToolsCoordinatorDelegateRequestsDecorationContainerViewCallback (View view);
#else
	delegate void UIWritingToolsCoordinatorDelegateRequestsContextsCallback (XWritingToolsCoordinatorContext [] contexts);
	delegate void UIWritingToolsCoordinatorDelegateReplaceRangeCallback ([NullAllowed] NSAttributedString replacementText);
	delegate void UIWritingToolsCoordinatorDelegateRequestsRangeCallback (NSRange range, NSUuid contextId);
	delegate void UIWritingToolsCoordinatorDelegateRequestsBoundingBezierPathsCallback (BezierPath [] paths);
	delegate void UIWritingToolsCoordinatorDelegateRequestsUnderlinePathsCallback (BezierPath [] paths);
	delegate void UIWritingToolsCoordinatorDelegateRequestsPreviewForTextAnimationCallback ([NullAllowed] View view); // different signature vs macOS
	delegate void UIWritingToolsCoordinatorDelegateRequestsSingleContainerSubrangesCallback (/* [BindAs (typeof (NSRange[]))] */ NSValue [] ranges); // BindAs doesn't work here
	delegate void UIWritingToolsCoordinatorDelegateRequestsDecorationContainerViewCallback (View view);
#endif

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[Protocol (BackwardsCompatibleCodeGeneration = false), Model]
	[BaseType (typeof (NSObject))]
#if MONOMAC
	interface NSWritingToolsCoordinatorDelegate
#else
	interface UIWritingToolsCoordinatorDelegate
#endif
	{
		[Abstract]
		[Export ("writingToolsCoordinator:requestsContextsForScope:completion:")]
		void RequestsContexts (XWritingToolsCoordinator writingToolsCoordinator, XWritingToolsCoordinatorContextScope scope, XWritingToolsCoordinatorDelegateRequestsContextsCallback completion);

		[Abstract]
		[Export ("writingToolsCoordinator:replaceRange:inContext:proposedText:reason:animationParameters:completion:")]
		void ReplaceRange (XWritingToolsCoordinator writingToolsCoordinator, NSRange range, XWritingToolsCoordinatorContext context, NSAttributedString replacementText, XWritingToolsCoordinatorTextReplacementReason reason, [NullAllowed] XWritingToolsCoordinatorAnimationParameters animationParameters, XWritingToolsCoordinatorDelegateReplaceRangeCallback completion);

		[Abstract]
		[Export ("writingToolsCoordinator:selectRanges:inContext:completion:")]
		void SelectRanges (XWritingToolsCoordinator writingToolsCoordinator, NSValue [] ranges, XWritingToolsCoordinatorContext context, Action completion);

		[Abstract]
		[Export ("writingToolsCoordinator:requestsRangeInContextWithIdentifierForPoint:completion:")]
		void RequestsRange (XWritingToolsCoordinator writingToolsCoordinator, CGPoint point, XWritingToolsCoordinatorDelegateRequestsRangeCallback completion);

		[Abstract]
		[Export ("writingToolsCoordinator:requestsBoundingBezierPathsForRange:inContext:completion:")]
		void RequestsBoundingBezierPaths (XWritingToolsCoordinator writingToolsCoordinator, NSRange range, XWritingToolsCoordinatorContext context, XWritingToolsCoordinatorDelegateRequestsBoundingBezierPathsCallback completion);

		[Abstract]
		[Export ("writingToolsCoordinator:requestsUnderlinePathsForRange:inContext:completion:")]
		void RequestsUnderlinePaths (XWritingToolsCoordinator writingToolsCoordinator, NSRange range, XWritingToolsCoordinatorContext context, XWritingToolsCoordinatorDelegateRequestsUnderlinePathsCallback completion);

		[Abstract]
		[Export ("writingToolsCoordinator:prepareForTextAnimation:forRange:inContext:completion:")]
		void PrepareForTextAnimation (XWritingToolsCoordinator writingToolsCoordinator, XWritingToolsCoordinatorTextAnimation textAnimation, NSRange range, XWritingToolsCoordinatorContext context, Action completion);

		[Abstract]
		[Export ("writingToolsCoordinator:requestsPreviewForTextAnimation:ofRange:inContext:completion:")]
		void RequestsPreviewForTextAnimation (XWritingToolsCoordinator writingToolsCoordinator, XWritingToolsCoordinatorTextAnimation textAnimation, NSRange range, XWritingToolsCoordinatorContext context, XWritingToolsCoordinatorDelegateRequestsPreviewForTextAnimationCallback completion);

#if MONOMAC
		[Abstract]
		[Export ("writingToolsCoordinator:requestsPreviewForRect:inContext:completion:")]
		void RequestsPreview (XWritingToolsCoordinator writingToolsCoordinator, CGRect rect, XWritingToolsCoordinatorContext context, NSWritingToolsCoordinatorDelegateRequestsPreviewCallback completion);
#endif

		[Abstract]
		[Export ("writingToolsCoordinator:finishTextAnimation:forRange:inContext:completion:")]
		void FinishTextAnimation (XWritingToolsCoordinator writingToolsCoordinator, XWritingToolsCoordinatorTextAnimation textAnimation, NSRange range, XWritingToolsCoordinatorContext context, Action completion);

		[Export ("writingToolsCoordinator:requestsSingleContainerSubrangesOfRange:inContext:completion:")]
		void RequestsSingleContainerSubranges (XWritingToolsCoordinator writingToolsCoordinator, NSRange range, XWritingToolsCoordinatorContext context, XWritingToolsCoordinatorDelegateRequestsSingleContainerSubrangesCallback completion);

		[Export ("writingToolsCoordinator:requestsDecorationContainerViewForRange:inContext:completion:")]
		void RequestsDecorationContainerView (XWritingToolsCoordinator writingToolsCoordinator, NSRange range, XWritingToolsCoordinatorContext context, XWritingToolsCoordinatorDelegateRequestsDecorationContainerViewCallback completion);

		[Export ("writingToolsCoordinator:willChangeToState:completion:")]
		void WillChangeToState (XWritingToolsCoordinator writingToolsCoordinator, XWritingToolsCoordinatorState newState, Action completion);
	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
#if MONOMAC
	interface NSWritingToolsCoordinatorAnimationParameters
#else
	interface UIWritingToolsCoordinatorAnimationParameters
#endif
	{
		[Export ("duration")]
		nfloat Duration { get; }

		[Export ("delay")]
		nfloat Delay { get; }

		[NullAllowed, Export ("progressHandler", ArgumentSemantic.Copy)]
		Action<float> ProgressHandler { get; set; }

		[NullAllowed, Export ("completionHandler", ArgumentSemantic.Copy)]
		Action CompletionHandler { get; set; }
	}

	[NoTV, MacCatalyst (18, 2), iOS (18, 2), Mac (15, 2)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
#if MONOMAC
	interface NSWritingToolsCoordinatorContext
#else
	interface UIWritingToolsCoordinatorContext
#endif
	{
		[Export ("initWithAttributedString:range:")]
		[DesignatedInitializer]
		NativeHandle Constructor (NSAttributedString attributedString, NSRange range);

		[Export ("attributedString", ArgumentSemantic.Copy)]
		NSAttributedString AttributedString { get; }

		[Export ("range")]
		NSRange Range { get; }

		[Export ("identifier", ArgumentSemantic.Strong)]
		NSUuid Identifier { get; }

		[Export ("resolvedRange")]
		NSRange ResolvedRange { get; }
	}

}
