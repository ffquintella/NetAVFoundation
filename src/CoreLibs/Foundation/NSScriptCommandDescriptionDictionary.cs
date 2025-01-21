// Copyright 2015 Xamarin, Inc.
using System;
using CoreLibs;
using Foundation;
using ObjCRuntime;

namespace Foundation {

#if MONOMAC || __MACCATALYST__

	public static class NSScriptCommandDescriptionDictionaryKeys {
		private static NSString cmdClass = new NSString ("CommandClass");
		public static NSString CommandClassKey { 
			get { return cmdClass; }
		}
		
		public static NSString AppleEventCodeKey { 
			get { return NSScriptCommonKeys.AppleEventCodeKey; }
		}
		
		private static NSString codeClass = new NSString ("AppleEventClassCode");
		public static NSString AppleEventClassCodeKey { 
			get { return codeClass; }
		}
		
		public static NSString TypeKey {
			get { return NSScriptCommonKeys.TypeKey; }
		}
		
		private static NSString resultAppEventCode = new NSString ("ResultAppleEventCode");
		public static NSString ResultAppleEventCodeKey { 
			get { return resultAppEventCode; }
		}
		
		private static NSString args = new NSString ("Arguments");
		public static NSString ArgumentsKey {
			get { return args; }
		}
	}

	public partial class NSScriptCommandDescriptionDictionary {

		public void Add (NSScriptCommandArgumentDescription arg)
		{
			if (arg is null)
				throw new ArgumentNullException ("arg");
			if (Arguments is null)
				Arguments = new NSMutableDictionary (); 
			using (var nsName = new NSString (arg.Name)) {
				Arguments.Add (nsName, arg.Dictionary);
			}
		}

		public bool Remove (NSScriptCommandArgumentDescription arg)
		{
			if (arg is null)
				throw new ArgumentNullException ("arg");
			using (var nsName = new NSString (arg.Name)) {
				return Arguments?.Remove (nsName) ?? false;
			}
		}
	}

	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (15, 0)]
	//[StrongDictionary ("NSScriptCommandArgumentDescriptionKeys")]
	public partial class NSScriptCommandArgumentDescription {
		string AppleEventCode { get; set; }
		string Type { get; set; }
		string Optional { get; set; }
	}
	
	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (15, 0)]
	//[StrongDictionary ("NSScriptCommandDescriptionDictionaryKeys")]
	public partial class NSScriptCommandDescriptionDictionary  {
		public string CommandClass { get; set; }
		public string AppleEventCode { get; set; }
		public string AppleEventClassCode { get; set; }
		public string Type { get; set; }
		public string ResultAppleEventCode { get; set; }
		public NSMutableDictionary Arguments { get; set; }
		
		public NSMutableDictionary Dictionary { get; set; }
	}
	
#endif

}
