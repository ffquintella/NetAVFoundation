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

using System;
using ObjCRuntime;

// Disable until we get around to enable + fix any issues.
#nullable disable

namespace Foundation {
	public partial class NSXpcConnection : NSObject {
		public TProtocol CreateRemoteObjectProxy<TProtocol> ()
			where TProtocol : class, INativeObject
		{
			IntPtr nativeProxyPtr = _CreateRemoteObjectProxy ();
			return Runtime.GetINativeObject<TProtocol> (nativeProxyPtr, true);
		}

		public TProtocol CreateRemoteObjectProxy<TProtocol> (Action<NSError> errorHandler)
			where TProtocol : class, INativeObject
		{
			IntPtr nativeProxyPtr = _CreateRemoteObjectProxy (errorHandler);
			return Runtime.GetINativeObject<TProtocol> (nativeProxyPtr, true);
		}

		public TProtocol CreateSynchronousRemoteObjectProxy<TProtocol> (Action<NSError> errorHandler)
			where TProtocol : class, INativeObject
		{
			IntPtr nativeProxyPtr = _CreateSynchronousRemoteObjectProxy (errorHandler);
			return Runtime.GetINativeObject<TProtocol> (nativeProxyPtr, true);
		}
	}
	
	[BaseType (typeof (NSObject), Name = "NSXPCConnection")]
	[DisableDefaultCtor]
	partial class NSXpcConnection {
		[Export ("initWithServiceName:")]
		[NoiOS]
		[NoWatch]
		[NoTV]
		[NoMacCatalyst]
		public extern NativeHandle Constructor (string xpcServiceName);

		[Export ("serviceName")]
		public extern string ServiceName { get; }

		[Export ("initWithMachServiceName:options:")]
		[NoiOS]
		[NoWatch]
		[NoTV]
		[NoMacCatalyst]
		public extern NativeHandle Constructor (string machServiceName, NSXpcConnectionOptions options);

		[Export ("initWithListenerEndpoint:")] 
		extern NativeHandle Constructor (NSXpcListenerEndpoint endpoint);

		[Export ("endpoint")]
		extern NSXpcListenerEndpoint Endpoint { get; }

		[Export ("exportedInterface", ArgumentSemantic.Retain)]
		[NullAllowed]
		public extern NSXpcInterface? ExportedInterface { get; set; }

		[Export ("exportedObject", ArgumentSemantic.Retain)]
		[NullAllowed]
		public extern NSObject? ExportedObject { get; set; }

		[Export ("remoteObjectInterface", ArgumentSemantic.Retain)]
		[NullAllowed]
		public extern NSXpcInterface? RemoteInterface { get; set; }

		[Export ("interruptionHandler", ArgumentSemantic.Copy)]
		public extern Action InterruptionHandler { get; set; }

		[Export ("invalidationHandler", ArgumentSemantic.Copy)]
		public extern Action InvalidationHandler { get; set; }

		[Advice ("Prefer using 'Activate' for initial activation of a connection.")]
		[Export ("resume")]
		public extern void Resume ();

		[Export ("suspend")]
		public extern void Suspend ();

		[Export ("invalidate")]
		public extern void Invalidate ();

		[Export ("auditSessionIdentifier")]
		public extern int AuditSessionIdentifier { get; }

		[Export ("processIdentifier")]
		public extern int PeerProcessIdentifier { get; }

		[Export ("effectiveUserIdentifier")]
		public extern int PeerEffectiveUserId { get; }

		[Export ("effectiveGroupIdentifier")]
		public extern int PeerEffectiveGroupId { get; }

		[Export ("currentConnection")]
		[Static]
		public extern NSXpcConnection CurrentConnection { [return: NullAllowed] get; }

		[Export ("scheduleSendBarrierBlock:")]
		//[iOS (13, 0)]
		[Watch (6, 0)]
		[TV (13, 0)]
		[MacCatalyst (13, 1)]
		public extern void ScheduleSendBarrier (Action block);

		[Export ("remoteObjectProxy"), Internal]
		public extern IntPtr _CreateRemoteObjectProxy ();

		[Export ("remoteObjectProxyWithErrorHandler:"), Internal]
		public extern IntPtr _CreateRemoteObjectProxy ([BlockCallback] Action<NSError> errorHandler);

		[MacCatalyst (13, 1)]
		[Export ("synchronousRemoteObjectProxyWithErrorHandler:"), Internal]
		public extern IntPtr _CreateSynchronousRemoteObjectProxy ([BlockCallback] Action<NSError> errorHandler);

		//[Watch (7, 0), TV (14, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("activate")]
		public extern void Activate ();

		//[NoWatch, NoTV, NoiOS, Mac (13, 0)]
		[NoMacCatalyst]
		[Export ("setCodeSigningRequirement:")]
		public extern void SetCodeSigningRequirement (string requirement);
	}
}
