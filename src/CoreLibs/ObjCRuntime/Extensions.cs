using CoreFoundation;
using Foundation;

namespace ObjCRuntime {
	static class Extensions {
		public static byte AsByte (this bool value)
		{
			return value ? (byte) 1 : (byte) 0;
		}

		public static CFStringTransform transform = CFStringTransform.ToUnicodeName;
		public static CFString GetConstant(this CFStringTransform transform)
		{
			var constant = new CFString(transform.ToString ());
			return constant;
		}
		
	}
}
