using Foundation;
using ObjCRuntime;

namespace CoreLibs.Foundation;

[ClassType(typeof(NSString), Runtime.MTTypeFlags.CustomType)]
public class NewNSString : NSValue//, IComparable<NSString>
{
    
    const string selUTF8String = "UTF8String";
    const string selInitWithCharactersLength = "initWithCharacters:length:";
    
    public NewNSString (string str) : base("NSString")
    {
        if (str is null)
            throw new ArgumentNullException ("str");

        Handle = CreateWithCharacters (ClassHandle, str, 0, str.Length);
			
    }
    
    static NativeHandle CreateWithCharacters (NativeHandle classHandle, string str, int offset, int length, bool autorelease = false)
    {
        //var chandle = Class.GetHandle(nameof(NSString));
			
        unsafe {
            fixed (char* ptrFirstChar = str) {
                var ptrStart = (IntPtr) (ptrFirstChar + offset);
#if MONOMAC
					var resHandle = Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr (chandle, Selector.GetHandle (selInitWithCharactersLength), ptrStart, (IntPtr) length);
					
					//Messaging.void_objc_msgSend_IntPtr_IntPtr (handle, selInitWithCharactersLengthHandle, ptrStart, (IntPtr) length);
#else
                var resHandle = Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr (classHandle, Selector.GetHandle (selInitWithCharactersLength), ptrStart, (IntPtr) length);
#endif

                if (autorelease)
                    NSObject.DangerousAutorelease (resHandle);

                return resHandle;
            }
        }
    }
}