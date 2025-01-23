using AVFoundation;
using NetAVFoundation;
using UIKit;

namespace ConsoleLab;

public class CameraTest
{
    AVCaptureDevice? device;
    AVCaptureDeviceInput? input;
    AVCaptureStillImageOutput? output;
    AVCaptureSession? session;
    
    public CameraTest()
    {
        
    }

    public void CaptureSS()
    {
        device = AVCaptureDevice.GetDefaultDevice(AVMediaTypes.Video.GetConstant());
        input = AVCaptureDeviceInput.FromDevice(device, out var error);
       
        if (error == null)
        {
            session = new AVCaptureSession();
            session.AddInput(input);
            session.SessionPreset = AVCaptureSession.PresetPhoto;
            var previewLayer = AVCaptureVideoPreviewLayer.FromSession(session);
            previewLayer.Frame = new CoreGraphics.CGRect(0, 0, 300, 300);
            //var view = new UIView();
            //view.Layer = previewLayer;
            output = new AVCaptureStillImageOutput();
            session.AddOutput(output);
            session.StartRunning();
        }
        /*
        if (error == null)
        {
            session = new AVCaptureSession();
            session.AddInput(input);
            session.SessionPreset = AVCaptureSession.PresetPhoto;
            var previewLayer = AVCaptureVideoPreviewLayer.FromSession(session);
            previewLayer.Frame = Control.Bounds;
            Control.Layer = previewLayer;
            output = new AVCaptureStillImageOutput();
            session.AddOutput(output);
            session.StartRunning();
        }
        */
    }
    
    
}