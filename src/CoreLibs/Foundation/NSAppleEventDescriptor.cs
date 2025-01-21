//
// NSAppleEventDescriptor.cs
//
// Copyright 2015 Xamarin Inc

#if MONOMAC

using System;

using AppKit;
using CoreLibs;
using ObjCRuntime;


// In Apple headers, this is a typedef to a pointer to a private struct
using NSAppleEventManagerSuspensionID = System.IntPtr;
// These two are both four char codes i.e. defined on a uint with constant like 'xxxx'
using AEKeyword = System.UInt32;
using OSType = System.UInt32;
// typedef double NSTimeInterval;
using NSTimeInterval = System.Double;

namespace Foundation
{
	public enum NSAppleEventDescriptorType {
		Record,
		List,
	}

	public partial class NSAppleEventDescriptor
	{
		public NSAppleEventDescriptor (NSAppleEventDescriptorType type)
		{
			switch (type) {
			case NSAppleEventDescriptorType.List:
				InitializeHandle (_InitListDescriptor (), "listDescriptor");
				break;
			case NSAppleEventDescriptorType.Record:
				InitializeHandle (_InitRecordDescriptor (), "recordDescriptor");
				break;
			default:
				throw new ArgumentOutOfRangeException ("type");
			}
		}
	}
	
		[NoiOS, NoTV, NoWatch]
	[MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	public partial class NSAppleEventDescriptor :  NSCopying {
		[Static]
		[Export ("nullDescriptor")]
		public static extern NSAppleEventDescriptor NullDescriptor { get; }

		/*		[Static]
		[Export ("descriptorWithDescriptorType:bytes:length:")]
		NSAppleEventDescriptor DescriptorWithDescriptorTypebyteslength (DescType descriptorType, void bytes, uint byteCount);

		[Static]
		[Export ("descriptorWithDescriptorType:data:")]
		NSAppleEventDescriptor DescriptorWithDescriptorTypedata (DescType descriptorType, NSData data);*/

		[Static]
		[Export ("descriptorWithBoolean:")]
		public static extern NSAppleEventDescriptor DescriptorWithBoolean (Boolean boolean);

		[Static]
		[Export ("descriptorWithEnumCode:")]
		public static extern NSAppleEventDescriptor DescriptorWithEnumCode (OSType enumerator);

		[Static]
		[Export ("descriptorWithInt32:")]
		public static extern NSAppleEventDescriptor DescriptorWithInt32 (int /* int32 */ signedInt);

		[Static]
		[Export ("descriptorWithTypeCode:")]
		public static extern NSAppleEventDescriptor DescriptorWithTypeCode (OSType typeCode);

		[Static]
		[Export ("descriptorWithString:")]
		public static extern NSAppleEventDescriptor DescriptorWithString (string str);

		/*[Static]
		[Export ("appleEventWithEventClass:eventID:targetDescriptor:returnID:transactionID:")]
		NSAppleEventDescriptor AppleEventWithEventClasseventIDtargetDescriptorreturnIDtransactionID (AEEventClass eventClass, AEEventID eventID, NSAppleEventDescriptor targetDescriptor, AEReturnID returnID, AETransactionID transactionID);*/

		[Static]
		[Export ("listDescriptor")]
		public static extern NSAppleEventDescriptor ListDescriptor { get; }

		[Static]
		[Export ("recordDescriptor")]
		public static extern NSAppleEventDescriptor RecordDescriptor { get; }

		/*[Export ("initWithAEDescNoCopy:")]
		NSObject InitWithAEDescNoCopy (const AEDesc aeDesc);

		[Export ("initWithDescriptorType:bytes:length:")]
		NSObject InitWithDescriptorTypebyteslength (DescType descriptorType, void bytes, uint byteCount);

		[Export ("initWithDescriptorType:data:")]
		NSObject InitWithDescriptorTypedata (DescType descriptorType, NSData data);

		[Export ("initWithEventClass:eventID:targetDescriptor:returnID:transactionID:")]
		NSObject InitWithEventClasseventIDtargetDescriptorreturnIDtransactionID (AEEventClass eventClass, AEEventID eventID, NSAppleEventDescriptor targetDescriptor, AEReturnID returnID, AETransactionID transactionID);*/

		[Internal]
		[Sealed]
		[Export ("initListDescriptor")]
		internal  extern IntPtr _InitListDescriptor ();

		[Internal]
		[Sealed]
		[Export ("initRecordDescriptor")]
		internal  extern IntPtr _InitRecordDescriptor ();

		/*[Export ("aeDesc")]
		const AEDesc AeDesc ();

		[Export ("descriptorType")]
		DescType DescriptorType ();*/

		[Export ("data")]
		public extern NSData Data { get; }

		[Export ("booleanValue")]
		public extern Boolean BooleanValue { get; }

		[Export ("enumCodeValue")]
		public extern OSType EnumCodeValue ();

		[Export ("int32Value")]
		public extern Int32 Int32Value { get; }

		[Export ("typeCodeValue")]
		public extern OSType TypeCodeValue { get; }

		[NullAllowed]
		[Export ("stringValue")]
		extern string? StringValue { get; }

		[Export ("eventClass")]
		public extern AEEventClass EventClass { get; }

		[Export ("eventID")]
		public extern AEEventID EventID { get; }

		/*[Export ("returnID")]
		AEReturnID ReturnID ();

		[Export ("transactionID")]
		AETransactionID TransactionID ();*/

		[Export ("setParamDescriptor:forKeyword:")]
		public extern void SetParamDescriptorforKeyword (NSAppleEventDescriptor descriptor, AEKeyword keyword);

		[return: NullAllowed]
		[Export ("paramDescriptorForKeyword:")]
		public extern NSAppleEventDescriptor ParamDescriptorForKeyword (AEKeyword keyword);

		[Export ("removeParamDescriptorWithKeyword:")]
		public extern void RemoveParamDescriptorWithKeyword (AEKeyword keyword);

		[Export ("setAttributeDescriptor:forKeyword:")]
		public extern void SetAttributeDescriptorforKeyword (NSAppleEventDescriptor descriptor, AEKeyword keyword);

		[return: NullAllowed]
		[Export ("attributeDescriptorForKeyword:")]
		public extern NSAppleEventDescriptor? AttributeDescriptorForKeyword (AEKeyword keyword);

		[Export ("numberOfItems")]
		public extern nint NumberOfItems { get; }

		[Export ("insertDescriptor:atIndex:")]
		public extern void InsertDescriptoratIndex (NSAppleEventDescriptor descriptor, nint index);

		[return: NullAllowed]
		[Export ("descriptorAtIndex:")]
		public extern NSAppleEventDescriptor? DescriptorAtIndex (nint index);

		[Export ("removeDescriptorAtIndex:")]
		public extern void RemoveDescriptorAtIndex (nint index);

		[Export ("setDescriptor:forKeyword:")]
		public extern void SetDescriptorforKeyword (NSAppleEventDescriptor descriptor, AEKeyword keyword);

		[return: NullAllowed]
		[Export ("descriptorForKeyword:")]
		public extern NSAppleEventDescriptor? DescriptorForKeyword (AEKeyword keyword);

		[Export ("removeDescriptorWithKeyword:")]
		public extern void RemoveDescriptorWithKeyword (AEKeyword keyword);

		[Export ("keywordForDescriptorAtIndex:")]
		public extern AEKeyword KeywordForDescriptorAtIndex (nint index);

		/*[Export ("coerceToDescriptorType:")]
		NSAppleEventDescriptor CoerceToDescriptorType (DescType descriptorType);*/

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("currentProcessDescriptor")]
		public extern static NSAppleEventDescriptor CurrentProcessDescriptor { get; }

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("descriptorWithDouble:")]
		public extern static NSAppleEventDescriptor FromDouble (double doubleValue);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("descriptorWithDate:")]
		public extern static NSAppleEventDescriptor FromDate (NSDate date);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("descriptorWithFileURL:")]
		public extern static NSAppleEventDescriptor FromFileURL (NSUrl fileURL);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("descriptorWithProcessIdentifier:")]
		public extern static NSAppleEventDescriptor FromProcessIdentifier (int processIdentifier);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("descriptorWithBundleIdentifier:")]
		public extern static NSAppleEventDescriptor FromBundleIdentifier (string bundleIdentifier);

		[MacCatalyst (13, 1)]
		[Static]
		[Export ("descriptorWithApplicationURL:")]
		public extern static NSAppleEventDescriptor FromApplicationURL (NSUrl applicationURL);

		[MacCatalyst (13, 1)]
		[Export ("doubleValue")]
		public extern double DoubleValue { get; }

		[NoMacCatalyst]
		[Export ("sendEventWithOptions:timeout:error:")]
		[return: NullAllowed]
		public extern NSAppleEventDescriptor SendEvent (NSAppleEventSendOptions sendOptions, double timeoutInSeconds, [NullAllowed] out NSError error);

		[MacCatalyst (13, 1)]
		[Export ("isRecordDescriptor")]
		public extern bool IsRecordDescriptor { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("dateValue", ArgumentSemantic.Copy)]
		public extern NSDate? DateValue { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("fileURLValue", ArgumentSemantic.Copy)]
		public extern NSUrl? FileURLValue { get; }
	}
}

#endif // MONOMAC
