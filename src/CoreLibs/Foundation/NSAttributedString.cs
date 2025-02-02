// 
// NSAttributedString.cs: Implements the managed NSAttributedString
//
// Authors: Marek Safar (marek.safar@gmail.com)
//     
// Copyright 2012, Xamarin Inc.
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

#nullable enable

using System;
using CoreFoundation;
using CoreText;
using ObjCRuntime;
#if MONOMAC || __MACCATALYST__
using AppKit;
#endif
#if !MONOMAC
using UIKit;
#endif

namespace Foundation {
	public partial class NSAttributedString {

		/// <summary>Create a new <see cref="NSAttributedString" />.</summary>
		/// <param name="url">A url to the document to load.</param>
		/// <param name="options">A dictionary of attributes that specifies how to interpret the document contents.</param>
		/// <param name="resultDocumentAttributes">Upon return, a dictionary of document-specific keys.</param>
		/// <param name="error">The error if an error occurred.</param>
		public static NSAttributedString? Create (NSUrl url, NSDictionary options, out NSDictionary resultDocumentAttributes, out NSError error)
		{
			var rv = new NSAttributedString (NSObjectFlag.Empty);
			rv.InitializeHandle (rv._InitWithUrl (url, options, out resultDocumentAttributes, out error), string.Empty, false);
			if (rv.Handle == IntPtr.Zero) {
				rv.Dispose ();
				return null;
			}
			return rv;
		}

		/// <summary>Create a new <see cref="NSAttributedString" />.</summary>
		/// <param name="url">A url to the document to load.</param>
		/// <param name="options">A dictionary of attributes that specifies how to interpret the document contents.</param>
		/// <param name="resultDocumentAttributes">Upon return, a dictionary of document-specific keys.</param>
		/// <param name="error">The error if an error occurred.</param>
		public static NSAttributedString? Create (NSUrl url, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, out NSError error)
		{
			return Create (url, options.Dictionary, out resultDocumentAttributes, out error);
		}

		/// <summary>Create a new <see cref="NSAttributedString" />.</summary>
		/// <param name="data">The data to load.</param>
		/// <param name="options">A dictionary of attributes that specifies how to interpret the document contents.</param>
		/// <param name="resultDocumentAttributes">Upon return, a dictionary of document-specific keys.</param>
		/// <param name="error">The error if an error occurred.</param>
		public static NSAttributedString? Create (NSData data, NSDictionary options, out NSDictionary resultDocumentAttributes, out NSError error)
		{
			var rv = new NSAttributedString (NSObjectFlag.Empty);
			rv.InitializeHandle (rv._InitWithData (data, options, out resultDocumentAttributes, out error), string.Empty, false);
			if (rv.Handle == IntPtr.Zero) {
				rv.Dispose ();
				return null;
			}
			return rv;
		}

		/// <summary>Create a new <see cref="NSAttributedString" />.</summary>
		/// <param name="data">The data to load.</param>
		/// <param name="options">A dictionary of attributes that specifies how to interpret the document contents.</param>
		/// <param name="resultDocumentAttributes">Upon return, a dictionary of document-specific keys.</param>
		/// <param name="error">The error if an error occurred.</param>
		public static NSAttributedString? Create (NSData data, NSAttributedStringDocumentAttributes options, out NSDictionary resultDocumentAttributes, out NSError error)
		{
			return Create (data, options.Dictionary, out resultDocumentAttributes, out error);
		}

#if __MACOS__ || XAMCORE_5_0
		/*
		public NSAttributedString (NSUrl url, NSAttributedStringDocumentAttributes documentAttributes, out NSError error)
		: this (url, documentAttributes, out var _, out error) {}

		public NSAttributedString (NSData data, NSAttributedStringDocumentAttributes documentAttributes, out NSError error)
		: this (data, documentAttributes, out var _, out error) {}

		public NSAttributedString (NSUrl url, out NSError error)
		: this (url, new NSDictionary (), out var _, out error) {}

		public NSAttributedString (NSData data, out NSError error)
		: this (data, new NSDictionary (), out var _, out error) {}*/
#else
		public NSAttributedString (NSUrl url, NSAttributedStringDocumentAttributes documentAttributes, ref NSError error)
		: this (url, documentAttributes, out var _, ref error) { }

		public NSAttributedString (NSData data, NSAttributedStringDocumentAttributes documentAttributes, ref NSError error)
		: this (data, documentAttributes, out var _, ref error) { }

		public NSAttributedString (NSUrl url, ref NSError error)
		: this (url, new NSDictionary (), out var _, ref error) { }

		public NSAttributedString (NSData data, ref NSError error)
		: this (data, new NSDictionary (), out var _, ref error) { }
#endif

#if __MACOS__
		public NSAttributedString (string str, NSStringAttributes? attributes)
			//: this (str, attributes?.Dictionary)
		{
			Handle = Constructor(str, attributes?.Dictionary);
		}
		
		public NSAttributedString (string str)
			//: this (str, attributes?.Dictionary)
		{
			Handle = Constructor(str, null);
		}
		
		//public extern NativeHandle Constructor (string str, [NullAllowed] NSDictionary attributes);
		
		public NSAttributedString (NSObjectFlag flag)
		{
			if(flag != NSObjectFlag.Empty)
				throw new ArgumentException ("Only NSObjectFlag.Empty is allowed");
			Handle = IntPtr.Zero;
		}
#endif // __MACOS__

		public string? Value {
			get {
				return CFString.FromHandle (LowLevelValue);
			}
		}

		public NSDictionary? GetAttributes (nint location, out NSRange effectiveRange)
		{
			return Runtime.GetNSObject<NSDictionary> (LowLevelGetAttributes (location, out effectiveRange));
		}

#if NET
		public IntPtr LowLevelGetAttributes (nint location, out NSRange effectiveRange)
		{
			unsafe {
				fixed (NSRange *effectiveRangePtr = &effectiveRange) {
					return LowLevelGetAttributes (location, (IntPtr) effectiveRangePtr);
				}
			}
		}
#endif

		public NSAttributedString (string str, CTStringAttributes? attributes)
			//: this (str, attributes?.Dictionary)
		{
		}

		public CTStringAttributes? GetCoreTextAttributes (nint location, out NSRange effectiveRange)
		{
			var attr = GetAttributes (location, out effectiveRange);
			return attr is null ? null : new CTStringAttributes (attr);
		}

		public CTStringAttributes? GetCoreTextAttributes (nint location, out NSRange longestEffectiveRange, NSRange rangeLimit)
		{
			var attr = GetAttributes (location, out longestEffectiveRange, rangeLimit);
			return attr is null ? null : new CTStringAttributes (attr);
		}

		public NSAttributedString Substring (nint start, nint len)
		{
			return Substring (new NSRange (start, len));
		}

#if !MONOMAC
		
		/*
		public NSAttributedString (string str, UIStringAttributes? attributes)
			: this (str, attributes?.Dictionary)
		{
		}
		*/

		public UIStringAttributes? GetUIKitAttributes (nint location, out NSRange effectiveRange)
		{
			var attr = GetAttributes (location, out effectiveRange);
			return attr is null ? null : new UIStringAttributes (attr);
		}

		public UIStringAttributes? GetUIKitAttributes (nint location, out NSRange longestEffectiveRange, NSRange rangeLimit)
		{
			var attr = GetAttributes (location, out longestEffectiveRange, rangeLimit);
			return attr is null ? null : new UIStringAttributes (attr);
		}

		static internal NSDictionary? ToDictionary (
						  UIFont? font,
						  UIColor? foregroundColor,
						  UIColor? backgroundColor,
						  UIColor? strokeColor,
						  NSParagraphStyle? paragraphStyle,
						  NSLigatureType ligature,
						  float kerning,
						  NSUnderlineStyle underlineStyle,
#if !WATCH
						  NSShadow? shadow,
#endif
						  float strokeWidth,
						  NSUnderlineStyle strikethroughStyle)
		{
			var attr = new UIStringAttributes ();
			if (font is not null) {
				attr.Font = font;
			}
			if (foregroundColor is not null) {
				attr.ForegroundColor = foregroundColor;
			}
			if (backgroundColor is not null) {
				attr.BackgroundColor = backgroundColor;
			}
			if (strokeColor is not null) {
				attr.StrokeColor = strokeColor;
			}
			if (paragraphStyle is not null) {
				attr.ParagraphStyle = paragraphStyle;
			}
			if (ligature != NSLigatureType.Default) {
				attr.Ligature = ligature;
			}
			if (kerning != 0) {
				attr.KerningAdjustment = kerning;
			}
			if (underlineStyle != NSUnderlineStyle.None) {
				attr.UnderlineStyle = underlineStyle;
			}
#if !WATCH
			if (shadow is not null) {
				attr.Shadow = shadow;
			}
#endif
			if (strokeWidth != 0) {
				attr.StrokeWidth = strokeWidth;
			}
			if (strikethroughStyle != NSUnderlineStyle.None) {
				attr.StrikethroughStyle = strikethroughStyle;
			}
			var dict = attr.Dictionary;
			return dict.Count == 0 ? null : dict;
		}

		/*
		public NSAttributedString (string str,
					   UIFont? font = null,
					   UIColor? foregroundColor = null,
					   UIColor? backgroundColor = null,
					   UIColor? strokeColor = null,
					   NSParagraphStyle? paragraphStyle = null,
					   NSLigatureType ligatures = NSLigatureType.Default,
					   float kerning = 0,
					   NSUnderlineStyle underlineStyle = NSUnderlineStyle.None,
#if !WATCH
					   NSShadow? shadow = null,
#endif
					   float strokeWidth = 0,
					   NSUnderlineStyle strikethroughStyle = NSUnderlineStyle.None)
		: this (str, ToDictionary (font, foregroundColor, backgroundColor, strokeColor, paragraphStyle, ligatures, kerning, underlineStyle,
#if !WATCH
			shadow,
#endif
			strokeWidth, strikethroughStyle))
		{
		}
		*/
#endif

	}
}
