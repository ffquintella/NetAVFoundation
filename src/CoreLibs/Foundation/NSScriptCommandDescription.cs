// Copyright 2015 Xamarin, Inc.

using System;
using Foundation;
using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {

#if MONOMAC || __MACCATALYST__

	// The kyes are not found in any of the public headers from apple. That is the reason
	// to use this technique.
	static class NSScriptCommonKeys {
		private static NSString appEventCode = new NSString ("AppleEventCode"); 
		public static NSString AppleEventCodeKey {
			get { return appEventCode; }
		}
		
		private static NSString typeKey = new NSString ("Type");
		public static NSString TypeKey {
			get { return typeKey; }
		}
	}
	
	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (15, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	public partial class NSScriptCommandDescription : NSCoding {

		[Internal]
		[DesignatedInitializer]
		[Export ("initWithSuiteName:commandName:dictionary:")]
		public extern NativeHandle Constructor (NSString suiteName, NSString commandName, [NullAllowed] NSDictionary commandDeclaration);

		[Internal]
		[Export ("appleEventClassCode")]
		public extern int FCCAppleEventClassCode { get; }

		[Internal]
		[Export ("appleEventCode")]
		public extern int FCCAppleEventCode { get; }

		[Export ("commandClassName")]
		public extern string ClassName { get; }

		[Export ("commandName")]
		public extern string Name { get; }

		[Export ("suiteName")]
		public extern string SuitName { get; }

		[Internal]
		[Export ("appleEventCodeForArgumentWithName:")]
		public extern int FCCAppleEventCodeForArgument (NSString name);

		[Export ("argumentNames")]
		public extern string [] ArgumentNames { get; }

		[Internal]
		[Export ("isOptionalArgumentWithName:")]
		public extern bool NSIsOptionalArgument (NSString name);

		[return: NullAllowed]
		[Internal]
		[Export ("typeForArgumentWithName:")]
		public extern NSString GetNSTypeForArgument (NSString name);

		[Internal]
		[Export ("appleEventCodeForReturnType")]
		public extern int FCCAppleEventCodeForReturnType { get; }

		[NullAllowed]
		[Export ("returnType")]
		public extern string ReturnType { get; }

		[Internal]
		[Export ("createCommandInstance")]
		public extern IntPtr CreateCommandInstancePtr ();
	}

	public partial class NSScriptCommandDescription {

		public NSScriptCommandDescription(NSString suiteName, NSString commandName,
			[NullAllowed] NSDictionary commandDeclaration)
		{
			Handle = Constructor(suiteName, commandName, commandDeclaration);
		}
		
		NSScriptCommandDescriptionDictionary description = null;

		static int ToIntValue (string fourCC)
		{
			if (fourCC.Length != 4)
				throw new FormatException (string.Format ("{0} must have a lenght of 4", nameof (fourCC)));
			int ret = 0;
			for (int i = 0; i < 4; i++) {
				ret <<= 8;
				ret |= fourCC[i];
			}
			return ret;
		}

		public static NSScriptCommandDescription Create (string suiteName, string commandName, NSScriptCommandDescriptionDictionary commandDeclaration)
		{
			if (String.IsNullOrEmpty (suiteName))
				throw new ArgumentException ("suiteName cannot be null or empty");
			if (String.IsNullOrEmpty (commandName))
				throw new ArgumentException ("commandName cannot be null or empty");
			if (commandDeclaration is null)
				throw new ArgumentNullException ("commandDeclaration");

			// ensure that the passed description is well formed
			if (String.IsNullOrEmpty (commandDeclaration.CommandClass))
				throw new ArgumentException ("cmdClass");
			if (String.IsNullOrEmpty (commandDeclaration.AppleEventCode))
				throw new ArgumentException ("eventCode");
			if (commandDeclaration.AppleEventCode.Length != 4)
				throw new ArgumentException ("eventCode must be a four characters string.");
			if (String.IsNullOrEmpty (commandDeclaration.AppleEventClassCode))
				throw new ArgumentException ("eventClass");
			if (commandDeclaration.AppleEventClassCode.Length != 4)
				throw new ArgumentException ("eventClass must be a four characters string.");
			if (commandDeclaration.ResultAppleEventCode is not null && commandDeclaration.ResultAppleEventCode.Length != 4)
				throw new ArgumentException ("resultAppleEvent must be a four characters string.");
			
			using (var nsSuitName = new NSString (suiteName))
			using (var nsCommandName = new NSString (commandName)) {
				try {
					var cmd = new NSScriptCommandDescription (nsSuitName, nsCommandName, commandDeclaration.Dictionary);
					cmd.description = commandDeclaration;
					return cmd;
				} catch (Exception e) {
					// this exception is raised by the platform because the internal constructor returns a nil
					// from the docs we know:
					// 
					// Returns nil if the event constant or class name for the command description is missing; also returns nil
					// if the return type or argument values are of the wrong type.
					// 
					// the conclusion is that the user created a wrong description dict, we let him know
					throw new ArgumentException ("commandDeclaration",
						"Wrong description dictionary: Check that the event constant, class name and argument definitions are well formed as per apple documentation.", e);
				}
			}
		}

		public string AppleEventClassCode {
			get { return Runtime.ToFourCCString (FCCAppleEventClassCode); }
		}

		public string AppleEventCode {
			get { return Runtime.ToFourCCString (FCCAppleEventCode); }
		}

		public string GetTypeForArgument (string name)
		{
			if (name is null)
				throw new ArgumentNullException ("name");
				
			using (var nsName = new NSString(name))
			using (var nsType = GetNSTypeForArgument (nsName)) {
				return nsType?.ToString ();
			}
		}

		public string GetAppleEventCodeForArgument (string name)
		{
			if (name is null)
				throw new ArgumentNullException (name);

			using (var nsName = new NSString (name)) {
				return Runtime.ToFourCCString (FCCAppleEventCodeForArgument (nsName));
			}
		}
		
		public bool IsOptionalArgument (string name) 
		{
			using (var nsName = new NSString (name)) {
				return NSIsOptionalArgument (nsName);
			}
		}

		public string AppleEventCodeForReturnType {
			get { return Runtime.ToFourCCString (FCCAppleEventCodeForReturnType); }
		}

		public NSScriptCommand CreateCommand ()
		{
			return new NSScriptCommand (CreateCommandInstancePtr ());
		}

		public NSDictionary Dictionary {
			get { return description.Dictionary; }
		}
	}
#endif
	
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	[MacCatalyst (15, 0)]
	[NoiOS]
	[NoTV]
	[NoWatch]
	public partial class NSScriptCommand : NSCoding {

		public NSScriptCommand (NSScriptCommandDescription cmdDescription)
		{
			if (cmdDescription == null)
				throw new ArgumentNullException ("cmdDescription");
			Handle = Constructor (cmdDescription);
		}
		
		public NSScriptCommand (IntPtr handle) : base(handle) {}
		
		[Internal]
		[DesignatedInitializer]
		[Export ("initWithCommandDescription:")]
		public extern NativeHandle Constructor (NSScriptCommandDescription cmdDescription);

		[Internal]
		[Static]
		[Export ("currentCommand")]
		public extern IntPtr GetCurrentCommand ();

		[Export ("appleEvent")]
		[NullAllowed]
		public extern NSAppleEventDescriptor AppleEvent { get; }

		[Export ("executeCommand")]
		public extern IntPtr Execute ();

		[NullAllowed]
		[Export ("evaluatedReceivers")]
		public extern NSObject EvaluatedReceivers { get; }
	}


}
