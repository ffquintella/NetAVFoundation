//namespace CoreLibs.ObjCRuntime.osx;

/*public class NSObject
{
    
}*/

using System.ComponentModel;
using CoreLibs;
using ObjCRuntime;

namespace Foundation
{
	[Protocol(Name = "NSObject")] // exists both as a type and a protocol in ObjC, Swift uses NSObjectProtocol
	public partial class NSObject: INativeObject
	{
		//NSObjectProtocol

		[Abstract] [Export("description")] public string Description { get; }

		[Export("debugDescription")] public string DebugDescription { get; }

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("superclass")]
		public extern Class Superclass { get; }

		// defined multiple times (method, property and even static), one (not static) is required
		// and that match Apple's documentation
		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("hash")]
		public extern nuint GetNativeHash();

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("isEqual:")]
		public extern bool IsEqual([NullAllowed] NSObject anObject);

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("class")]
		public extern Class Class { get; }

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Export("self")]
		//[Transient]
		public extern NSObject Self { get; }

		[Abstract]
		[Export("performSelector:")]
		public extern NSObject PerformSelector(Selector aSelector);

		[Abstract]
		[Export("performSelector:withObject:")]
		public extern NSObject PerformSelector(Selector aSelector, [NullAllowed] NSObject anObject);

		[Abstract]
		[Export("performSelector:withObject:withObject:")]
		public extern NSObject PerformSelector(Selector aSelector, NSObject? object1, NSObject? object2);

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("isProxy")]
		public extern bool IsProxy { get; }

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("isKindOfClass:")]
		public extern  bool IsKindOfClass([NullAllowed] Class aClass);

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("isMemberOfClass:")]
		public extern bool IsMemberOfClass([NullAllowed] Class aClass);

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("conformsToProtocol:")]
		public extern bool ConformsToProtocol([NullAllowed] NativeHandle /* Protocol */ aProtocol);

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("respondsToSelector:")]
		public extern bool RespondsToSelector([NullAllowed] Selector sel);

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("retain")]
		public extern NSObject DangerousRetain();

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("release")]
		public extern void DangerousRelease();

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("autorelease")]
		public extern NSObject DangerousAutorelease();

		[Abstract] [Export("retainCount")] public nuint RetainCount { get; }

		[Abstract]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Export("zone")]
		public extern NSZone Zone { get; }
	}
}