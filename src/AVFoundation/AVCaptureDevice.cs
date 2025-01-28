using System.Runtime.InteropServices;
using CoreLibs;
using CoreLibs.Foundation;
using Foundation;
using ObjCRuntime;

namespace AVFoundation;

public partial class AVCaptureDevice : NSObject
{

    
    public AVCaptureDevice(IntPtr handle) : base(handle)
    {
    }
    
    public AVCaptureDevice() : base()
    {
    }

    //[Wrap ("GetDefaultDevice (mediaType.GetConstant ()!)")]
    //[return: NullAllowed]
    public static AVCaptureDevice? GetDefaultDevice(AVMediaTypes mediaType)
    {
        return null;
    }

    //[MacCatalyst(13, 1)]
    //[Static]
    //[Export("defaultDeviceWithMediaType:")]
    //[return: NullAllowed]
    //[DllImport(Constants.AVFoundationLibrary, EntryPoint = "defaultDeviceWithMediaType:", CharSet = CharSet.Unicode)]

    public static  AVCaptureDevice? GetDefaultDevice(NSString mediaType)
    {
        
        //var ptr = Class.GetHandle(nameof(AVCaptureDevice));
        
        //var classHandle = Class.GetClassHandle(typeof(AVCaptureDevice), true, out _);
        
        var avCaptureDevice = new AVCaptureDevice();
        
        
        
        avCaptureDevice.handle = avCaptureDevice.CreteDeviceWithMediaType(mediaType.Handle);
        
        
        
        return avCaptureDevice;
    }
    
    //[Export("defaultDeviceWithMediaType:")]
    public IntPtr CreteDeviceWithMediaType(IntPtr mediaType)
    {
        var resHandle = IntPtr.Zero;
        
        var classHandle = Class.GetClassHandle(typeof(AVCaptureDevice), true, out _);
			
        unsafe {

            //resHandle = Messaging.IntPtr_objc_msgSend (class_ptr, Selector.GetHandle(Selector.Alloc));
				
            resHandle = Messaging.IntPtr_objc_msgSend_IntPtr (handle, Selector.GetHandle("defaultDeviceWithMediaType:"), mediaType);
				
        }
        return resHandle;
    }
}