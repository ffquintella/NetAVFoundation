//
// API for the Metal framework
//
// Authors:
//   Miguel de Icaza
//
// Copyrigh 2014-2015, Xamarin Inc.
//
// TODO:
//    * Provide friendly accessors instead of those IntPtrs that point to arrays
//    * MTLRenderPipelineReflection: the two arrays are NSObject
//    * Make the *array classes implement all the ICollection methods.
//

using System;
using System.ComponentModel;

using CoreAnimation;
//using CoreData;
using CoreGraphics;
using CoreImage;
//using CoreLocation;
using CoreFoundation;
using CoreLibs;
using Foundation;
using ObjCRuntime;

#if !NET
using NativeHandle = System.IntPtr;
#endif

#if TVOS
using MTLAccelerationStructureSizes = Foundation.NSObject;
#endif

namespace Metal {

	/// <summary>Completion handler for deallocating a buffer.</summary>
	delegate void MTLDeallocator (IntPtr pointer, nuint length);

	delegate void MTLNewComputePipelineStateWithReflectionCompletionHandler (IMTLComputePipelineState computePipelineState, MTLComputePipelineReflection reflection, NSError error);

	delegate void MTLDrawablePresentedHandler (IMTLDrawable drawable);

	delegate void MTLNewRenderPipelineStateWithReflectionCompletionHandler (IMTLRenderPipelineState renderPipelineState, MTLRenderPipelineReflection reflection, NSError error);

	interface IMTLCommandEncoder { }

	/// <summary>Encapsulates a single parameter to a Metal function.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLArgument_Ref/index.html">Apple documentation for <c>MTLArgument</c></related>
	//[Deprecated (PlatformName.MacOSX, 13, 0)]
	//[Deprecated (PlatformName.iOS, 16, 0)]
	//[Deprecated (PlatformName.TvOS, 16, 0)]
	[Deprecated (PlatformName.MacCatalyst, 16, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLArgument: NSObject {
		[Export ("name")]
		public extern string Name { get; }

		[Export ("type")]
		public extern MTLArgumentType Type { get; }

		[Export ("access")]
		public extern MTLArgumentAccess Access { get; }

		[Export ("index")]
		public extern nuint Index { get; }

		[Export ("active")]
		public extern bool Active { [Bind ("isActive")] get; }

		[Export ("bufferAlignment")]
		public extern nuint BufferAlignment { get; }

		[Export ("bufferDataSize")]
		public extern nuint BufferDataSize { get; }

		[Export ("bufferDataType")]
		public extern MTLDataType BufferDataType { get; }

		[NullAllowed]
		[Export ("bufferStructType")]
		public extern MTLStructType BufferStructType { get; }

		[Export ("threadgroupMemoryAlignment")]
		public extern nuint ThreadgroupMemoryAlignment { get; }

		[Export ("threadgroupMemoryDataSize")]
		public extern nuint ThreadgroupMemoryDataSize { get; }

		[Export ("textureType")]
		public extern MTLTextureType TextureType { get; }

		[Export ("textureDataType")]
		public extern MTLDataType TextureDataType { get; }

		[MacCatalyst (13, 1)]
		[Export ("isDepthTexture")]
		public extern bool IsDepthTexture { get; }

		[MacCatalyst (13, 1)]
		[Export ("arrayLength")]
		public extern nuint ArrayLength { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("bufferPointerType")]
		public extern MTLPointerType BufferPointerType { get; }
	}

	/// <summary>Encapsulates the details of an array argument to a Metal function.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLArrayType_Ref/index.html">Apple documentation for <c>MTLArrayType</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (MTLType))]
	partial class MTLArrayType: MTLType {
		[Export ("arrayLength")]
		extern nuint Length { get; }

		[Export ("elementType")]
		extern MTLDataType ElementType { get; }

		[Export ("stride")]
		extern nuint Stride { get; }

		[Export ("elementStructType")]
		[return: NullAllowed]
		extern MTLStructType? ElementStructType ();

		[Export ("elementArrayType")]
		[return: NullAllowed]
		extern MTLArrayType? ElementArrayType ();

		[MacCatalyst (13, 1)]
		[Export ("argumentIndexStride")]
		extern nuint ArgumentIndexStride { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("elementTextureReferenceType")]
		MTLTextureReferenceType ElementTextureReferenceType { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("elementPointerType")]
		extern MTLPointerType? ElementPointerType { get; }
	}

	/// <summary>System protocol for enqueuing and writing commands into a buffer.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLCommandEncoder {
		[Abstract, Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract, Export ("label")]
		extern string Label { get; set; }

		[Abstract, Export ("endEncoding")]
		extern void EndEncoding ();

		[Abstract, Export ("insertDebugSignpost:")]
		extern void InsertDebugSignpost (string signpost);

		[Abstract, Export ("pushDebugGroup:")]
		extern void PushDebugGroup (string debugGroup);

		[Abstract, Export ("popDebugGroup")]
		extern void PopDebugGroup ();
	}

	public interface IMTLBuffer: INativeObject { }

	/// <summary>System protocol for raw data that is accessible in strides.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class  MTLBuffer : MTLResource {
		[Abstract, Export ("length")]
		extern nuint Length { get; }

		[Abstract, Export ("contents")]
		extern IntPtr Contents { get; }

		[NoiOS, NoTV, MacCatalyst (15, 0)]
		[Abstract, Export ("didModifyRange:")]
		extern void DidModify (NSRange range);

		[MacCatalyst (13, 1)]
		[return: NullAllowed]
#if NET || !MONOMAC
		[Abstract]
#endif
		[Export ("newTextureWithDescriptor:offset:bytesPerRow:")]
		[return: Release]
		extern IMTLTexture CreateTexture (MTLTextureDescriptor descriptor, nuint offset, nuint bytesPerRow);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("addDebugMarker:range:")]
		extern void AddDebugMarker (string marker, NSRange range);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("removeAllDebugMarkers")]
		extern void RemoveAllDebugMarkers ();

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[NullAllowed, Export ("remoteStorageBuffer")]
		extern IMTLBuffer RemoteStorageBuffer { get; }

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("newRemoteBufferViewForDevice:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLBuffer CreateRemoteBuffer (IMTLDevice device);

		//[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("gpuAddress")]
		extern ulong GpuAddress { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLBufferLayoutDescriptor : NSCopying {
		[Export ("stride")]
		nuint Stride { get; set; }

		[Export ("stepFunction", ArgumentSemantic.Assign)]
		MTLStepFunction StepFunction { get; set; }

		[Export ("stepRate")]
		nuint StepRate { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class  MTLBufferLayoutDescriptorArray {
		[Internal]
		[Export ("objectAtIndexedSubscript:")]
		extern MTLBufferLayoutDescriptor ObjectAtIndexedSubscript (nuint index);

		[Internal]
		[Export ("setObject:atIndexedSubscript:")]
		extern void SetObject ([NullAllowed] MTLBufferLayoutDescriptor bufferDesc, nuint index);
	}


	public partial interface IMTLCommandBuffer { }

	/// <summary>Protocol for commands that are run on a GPU</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLCommandBuffer {

		[Abstract, Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract, Export ("commandQueue")]
		extern IMTLCommandQueue CommandQueue { get; }

		[Abstract, Export ("retainedReferences")]
		extern bool RetainedReferences { get; }

		[Abstract, Export ("label")]
		extern string Label { get; set; }

		[Abstract, Export ("status")]
		extern MTLCommandBufferStatus Status { get; }

		[Abstract, Export ("error")]
		extern NSError Error { get; }

		[Abstract, Export ("enqueue")]
		extern void Enqueue ();

		[Abstract, Export ("commit")]
		extern void Commit ();

		[Abstract, Export ("addScheduledHandler:")]
		extern void AddScheduledHandler (Action<IMTLCommandBuffer> block);

		[Abstract, Export ("waitUntilScheduled")]
		extern void WaitUntilScheduled ();

		[Abstract, Export ("addCompletedHandler:")]
		extern void AddCompletedHandler (Action<IMTLCommandBuffer> block);

		[Abstract, Export ("waitUntilCompleted")]
		extern void WaitUntilCompleted ();

		[Abstract, Export ("blitCommandEncoder")]
		extern IMTLBlitCommandEncoder BlitCommandEncoder { get; }

		[Abstract, Export ("computeCommandEncoder")]
		extern IMTLComputeCommandEncoder ComputeCommandEncoder { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("computeCommandEncoderWithDispatchType:")]
		[return: NullAllowed]
		extern IMTLComputeCommandEncoder ComputeCommandEncoderDispatch (MTLDispatchType dispatchType);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("encodeWaitForEvent:value:")]
		extern void EncodeWait (IMTLEvent @event, ulong value);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("encodeSignalEvent:value:")]
		extern void EncodeSignal (IMTLEvent @event, ulong value);

		[Field ("MTLCommandBufferErrorDomain")]
		NSString ErrorDomain { get; }

		[Abstract]
		[Export ("parallelRenderCommandEncoderWithDescriptor:")]
		[return: NullAllowed]
		extern IMTLParallelRenderCommandEncoder CreateParallelRenderCommandEncoder (MTLRenderPassDescriptor renderPassDescriptor);

		[Abstract]
		[Export ("presentDrawable:")]
		extern void PresentDrawable (IMTLDrawable drawable);

		[Abstract]
		[Export ("presentDrawable:atTime:")]
		extern void PresentDrawable (IMTLDrawable drawable, double presentationTime);

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[Introduced (PlatformName.MacCatalyst, 13, 4)]
		[Export ("presentDrawable:afterMinimumDuration:")]
		extern void PresentDrawableAfter (IMTLDrawable drawable, double duration);

		[Abstract]
		[Export ("renderCommandEncoderWithDescriptor:")]
		extern IMTLRenderCommandEncoder CreateRenderCommandEncoder (MTLRenderPassDescriptor renderPassDescriptor);

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[MacCatalyst (13, 1)]
		[Export ("kernelStartTime")]
		extern double /* CFTimeInterval */ KernelStartTime { get; }

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[MacCatalyst (13, 1)]
		[Export ("kernelEndTime")]
		extern double /* CFTimeInterval */ KernelEndTime { get; }

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[MacCatalyst (13, 1)]
		[Export ("GPUStartTime")]
		extern double /* CFTimeInterval */ GpuStartTime { get; }

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[MacCatalyst (13, 1)]
		[Export ("GPUEndTime")]
		double /* CFTimeInterval */ GpuEndTime { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[Export ("pushDebugGroup:")]
		extern void PushDebugGroup (string @string);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[Export ("popDebugGroup")]
		extern void PopDebugGroup ();

		[Abstract (GenerateExtensionMethod = true)]
		[MacCatalyst (14, 0), iOS (13, 0), TV (16, 0)]
		[NullAllowed, Export ("resourceStateCommandEncoder")]
		extern IMTLResourceStateCommandEncoder ResourceStateCommandEncoder { get; }

		//[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("errorOptions")]
		extern MTLCommandBufferErrorOption ErrorOptions { get; }

		//[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("logs")]
		extern IMTLLogContainer Logs { get; }

		//[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("computeCommandEncoderWithDescriptor:")]
		extern IMTLComputeCommandEncoder CreateComputeCommandEncoder (MTLComputePassDescriptor computePassDescriptor);

		//[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("blitCommandEncoderWithDescriptor:")]
		extern IMTLBlitCommandEncoder CreateBlitCommandEncoder (MTLBlitPassDescriptor blitPassDescriptor);

		[Abstract (GenerateExtensionMethod = true)]
		//[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("resourceStateCommandEncoderWithDescriptor:")]
		extern IMTLResourceStateCommandEncoder CreateResourceStateCommandEncoder (MTLResourceStatePassDescriptor resourceStatePassDescriptor);

		[Abstract (GenerateExtensionMethod = true)]
		//[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("accelerationStructureCommandEncoder")]
		extern IMTLAccelerationStructureCommandEncoder CreateAccelerationStructureCommandEncoder ();

		//[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("accelerationStructureCommandEncoderWithDescriptor:")]
		extern IMTLAccelerationStructureCommandEncoder CreateAccelerationStructureCommandEncoder (MTLAccelerationStructurePassDescriptor descriptor);

		[Abstract]
		//[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("useResidencySet:")]
		extern void UseResidencySet (IMTLResidencySet residencySet);

		[Abstract]
		//[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("useResidencySets:count:")]
		extern void UseResidencySets (IntPtr /* const id <MTLResidencySet> _Nonnull[_Nonnull] */ residencySets, nuint count);
	}

	public partial interface IMTLCommandQueue { }

	/// <summary>System protocol for objects that can queue command buffers for running on a GPU.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLCommandQueue {

		[Abstract, Export ("label")]
		extern string Label { get; set; }

		[Abstract, Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract, Export ("commandBuffer")]
		[Autorelease]
		[return: NullAllowed]
		extern IMTLCommandBuffer CommandBuffer ();

		[Abstract, Export ("commandBufferWithUnretainedReferences")]
		[Autorelease]
		[return: NullAllowed]
		extern IMTLCommandBuffer CommandBufferWithUnretainedReferences ();

		
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'MTLCaptureScope' instead.")]
		[Abstract, Export ("insertDebugCaptureBoundary")]
		extern void InsertDebugCaptureBoundary ();

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("commandBufferWithDescriptor:")]
		[return: NullAllowed]
		extern IMTLCommandBuffer CreateCommandBuffer (MTLCommandBufferDescriptor descriptor);

		[Abstract]
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("addResidencySet:")]
		extern void AddResidencySet (IMTLResidencySet residencySet);

		[Abstract]
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("addResidencySets:count:")]
		extern void AddResidencySets (IntPtr residencySets, nuint count);

		[Abstract]
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("removeResidencySet:")]
		extern void RemoveResidencySet (IMTLResidencySet residencySet);

		[Abstract]
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("removeResidencySets:count:")]
		extern void RemoveResidencySets (IntPtr residencySets, nuint count);
	}

	public interface IMTLComputeCommandEncoder: INativeObject { }

	/// <summary>Protocol for encoding and running parallel commands on a GPU.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLComputeCommandEncoder : MTLCommandEncoder {

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("dispatchType")]
		extern MTLDispatchType DispatchType { get; }

		[Abstract, Export ("setComputePipelineState:")]
		extern void SetComputePipelineState (IMTLComputePipelineState state);

		[Abstract, Export ("setBuffer:offset:atIndex:")]
		extern void SetBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[Abstract, Export ("setTexture:atIndex:")]
		extern void SetTexture (IMTLTexture texture, nuint index);

		[Abstract, Export ("setSamplerState:atIndex:")]
		extern void SetSamplerState (IMTLSamplerState sampler, nuint index);

		[Abstract, Export ("setSamplerState:lodMinClamp:lodMaxClamp:atIndex:")]
		extern void SetSamplerState (IMTLSamplerState sampler, float /* float, not CGFloat */ lodMinClamp, float /* float, not CGFloat */ lodMaxClamp, nuint index);

		[Abstract, Export ("setThreadgroupMemoryLength:atIndex:")]
		extern void SetThreadgroupMemoryLength (nuint length, nuint index);

		[Abstract, Export ("dispatchThreadgroups:threadsPerThreadgroup:")]
		extern void DispatchThreadgroups (MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup);

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("dispatchThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerThreadgroup:")]
		extern void DispatchThreadgroups (IMTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerThreadgroup);

#if NET
		[Abstract]
		[Export ("setBuffers:offsets:withRange:")]
		extern void SetBuffers (IntPtr buffers, IntPtr offsets, NSRange range);
#else
		[Abstract]
		[Export ("setBuffers:offsets:withRange:")]
		void SetBuffers (IMTLBuffer [] buffers, IntPtr offsets, NSRange range);
#endif


		[Abstract]
		[Export ("setSamplerStates:lodMinClamps:lodMaxClamps:withRange:")]
		extern void SetSamplerStates (IMTLSamplerState [] samplers, IntPtr floatArrayPtrLodMinClamps, IntPtr floatArrayPtrLodMaxClamps, NSRange range);

		[Abstract]
		[Export ("setSamplerStates:withRange:")]
		extern void SetSamplerStates (IMTLSamplerState [] samplers, NSRange range);

		[Abstract]
		[Export ("setTextures:withRange:")]
		extern void SetTextures (IMTLTexture [] textures, NSRange range);

		[MacCatalyst (13, 1)]
		[Abstract]
		[Export ("setBufferOffset:atIndex:")]
		extern void SetBufferOffset (nuint offset, nuint index);

		[MacCatalyst (13, 1)]
		[Abstract]
		[Export ("setBytes:length:atIndex:")]
		extern void SetBytes (IntPtr bytes, nuint length, nuint index);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setStageInRegion:")]
		extern void SetStage (MTLRegion region);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setStageInRegionWithIndirectBuffer:indirectBufferOffset:")]
		extern void SetStageInRegion (IMTLBuffer indirectBuffer, nuint indirectBufferOffset);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("updateFence:")]
		extern void Update (IMTLFence fence);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("waitForFence:")]
		extern void Wait (IMTLFence fence);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("dispatchThreads:threadsPerThreadgroup:")]
		extern void DispatchThreads (MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useResource:usage:")]
		extern void UseResource (IMTLResource resource, MTLResourceUsage usage);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useResources:count:usage:")]
		extern void UseResources (IMTLResource [] resources, nuint count, MTLResourceUsage usage);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useHeap:")]
		extern void UseHeap (IMTLHeap heap);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useHeaps:count:")]
		extern void UseHeaps (IMTLHeap [] heaps, nuint count);

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[TV (14, 5)]
#if NET
		[Abstract]
#endif
		[Export ("setImageblockWidth:height:")]
		extern void SetImageblock (nuint width, nuint height);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("memoryBarrierWithScope:")]
		extern void MemoryBarrier (MTLBarrierScope scope);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("memoryBarrierWithResources:count:")]
		extern void MemoryBarrier (IMTLResource [] resources, nuint count);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("executeCommandsInBuffer:withRange:")]
		extern void ExecuteCommands (IMTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:")]
		extern void ExecuteCommands (IMTLIndirectCommandBuffer indirectCommandbuffer, IMTLBuffer indirectRangeBuffer, nuint indirectBufferOffset);

#if NET
		[Abstract]
#endif
		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("sampleCountersInBuffer:atSampleIndex:withBarrier:")]
#if NET
		extern void SampleCounters (IMTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#else
		[Obsolete ("Use the overload that takes an IMTLCounterSampleBuffer instead.")]
		void SampleCounters (MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#endif

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("setVisibleFunctionTable:atBufferIndex:")]
		extern void SetVisibleFunctionTable ([NullAllowed] IMTLVisibleFunctionTable visibleFunctionTable, nuint bufferIndex);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("setVisibleFunctionTables:withBufferRange:")]
		extern void SetVisibleFunctionTables (IMTLVisibleFunctionTable [] visibleFunctionTables, NSRange range);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("setIntersectionFunctionTable:atBufferIndex:")]
		extern void SetIntersectionFunctionTable ([NullAllowed] IMTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("setIntersectionFunctionTables:withBufferRange:")]
		extern void SetIntersectionFunctionTables (IMTLIntersectionFunctionTable [] intersectionFunctionTables, NSRange range);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("setAccelerationStructure:atBufferIndex:")]
		extern void SetAccelerationStructure ([NullAllowed] IMTLAccelerationStructure accelerationStructure, nuint bufferIndex);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setBuffer:offset:attributeStride:atIndex:")]
		extern void SetBuffer (IMTLBuffer buffer, nuint offset, nuint stride, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setBuffers:offsets:attributeStrides:withRange:")]
		extern void SetBuffers (IntPtr /* IMTLBuffer[] */ buffers, IntPtr /* nuint[] */ offsets, IntPtr /* nuint[] */ strides, NSRange range);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setBufferOffset:attributeStride:atIndex:")]
		extern void SetBufferOffset (nuint offset, nuint stride, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setBytes:length:attributeStride:atIndex:")]
		extern void SetBytes (IntPtr bytes, nuint length, nuint stride, nuint index);

	}

	/// <summary>Encapsulates the details of the arguments of the compute function used to create an <see cref="T:Metal.IMTLComputePipelineState" /> object.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLComputePipelineReflection_Ref/index.html">Apple documentation for <c>MTLComputePipelineReflection</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLComputePipelineReflection: NSObject {
		
		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[Export ("arguments")]
#if NET
		extern MTLArgument [] Arguments { get; }
#else
		NSObject [] Arguments { get; }
#endif

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("bindings")]
		extern IMTLBinding [] Bindings { get; }
	}

	interface IMTLComputePipelineState { }
	/// <summary>System protocol that represents a compiled compute program.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial interface MTLComputePipelineState {
		[Abstract, Export ("device")]
		IMTLDevice Device { get; }

		[Abstract, Export ("maxTotalThreadsPerThreadgroup")]
		nuint MaxTotalThreadsPerThreadgroup { get; }

		[Abstract, Export ("threadExecutionWidth")]
		nuint ThreadExecutionWidth { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("label")]
		string Label { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("staticThreadgroupMemoryLength")]
		nuint StaticThreadgroupMemoryLength { get; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("imageblockMemoryLengthForDimensions:")]
		nuint GetImageblockMemoryLength (MTLSize imageblockDimensions);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("supportIndirectCommandBuffers")]
		bool SupportIndirectCommandBuffers { get; }

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("functionHandleWithFunction:")]
		IMTLFunctionHandle CreateFunctionHandle (IMTLFunction function);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("newComputePipelineStateWithAdditionalBinaryFunctions:error:")]
		[return: Release]
		IMTLComputePipelineState CreateComputePipelineState (IMTLFunction [] functions, [NullAllowed] out NSError error);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("newVisibleFunctionTableWithDescriptor:")]
		[return: Release]
		IMTLVisibleFunctionTable CreateVisibleFunctionTable (MTLVisibleFunctionTableDescriptor descriptor);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("newIntersectionFunctionTableWithDescriptor:")]
		[return: Release]
		IMTLIntersectionFunctionTable CreateIntersectionFunctionTable (MTLIntersectionFunctionTableDescriptor descriptor);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("gpuResourceID")]
		MTLResourceId GpuResourceId { get; }

		[Abstract]
		[Export ("shaderValidation")]
		MTLShaderValidation ShaderValidation { get; }
	}

	interface IMTLBlitCommandEncoder { }

	/// <summary>Protocol for writing data into frame buffers.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLBlitCommandEncoder : MTLCommandEncoder {

		[NoiOS, NoTV, MacCatalyst (15, 0)]
		[Abstract, Export ("synchronizeResource:")]
		extern void Synchronize (IMTLResource resource);

		[NoiOS, NoTV, MacCatalyst (15, 0)]
		[Abstract, Export ("synchronizeTexture:slice:level:")]
		extern void Synchronize (IMTLTexture texture, nuint slice, nuint level);

		[Abstract, Export ("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:")]
		extern void CopyFromTexture (IMTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, IMTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin);

		[Abstract, Export ("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:")]
		extern void CopyFromBuffer (IMTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, IMTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin);

		[MacCatalyst (13, 1)]
#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[Export ("copyFromBuffer:sourceOffset:sourceBytesPerRow:sourceBytesPerImage:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:options:")]
		extern void CopyFromBuffer (IMTLBuffer sourceBuffer, nuint sourceOffset, nuint sourceBytesPerRow, nuint sourceBytesPerImage, MTLSize sourceSize, IMTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin, MTLBlitOption options);

		[Abstract, Export ("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:")]
		extern void CopyFromTexture (IMTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, IMTLBuffer destinationBuffer, nuint destinationOffset, nuint destinatinBytesPerRow, nuint destinationBytesPerImage);

		[MacCatalyst (13, 1)]
#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[Export ("copyFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toBuffer:destinationOffset:destinationBytesPerRow:destinationBytesPerImage:options:")]
		extern void CopyFromTexture (IMTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, IMTLBuffer destinationBuffer, nuint destinationOffset, nuint destinatinBytesPerRow, nuint destinationBytesPerImage, MTLBlitOption options);

		[Abstract, Export ("generateMipmapsForTexture:")]
		extern void GenerateMipmapsForTexture (IMTLTexture texture);

		[Abstract, Export ("fillBuffer:range:value:")]
		extern void FillBuffer (IMTLBuffer buffer, NSRange range, byte value);

		[Abstract, Export ("copyFromBuffer:sourceOffset:toBuffer:destinationOffset:size:")]
		extern void CopyFromBuffer (IMTLBuffer sourceBuffer, nuint sourceOffset, IMTLBuffer destinationBuffer, nuint destinationOffset, nuint size);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("updateFence:")]
		extern void Update (IMTLFence fence);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("waitForFence:")]
		extern void Wait (IMTLFence fence);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("optimizeContentsForGPUAccess:")]
		extern void OptimizeContentsForGpuAccess (IMTLTexture texture);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("optimizeContentsForGPUAccess:slice:level:")]
		extern void OptimizeContentsForGpuAccess (IMTLTexture texture, nuint slice, nuint level);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("optimizeContentsForCPUAccess:")]
		extern void OptimizeContentsForCpuAccess (IMTLTexture texture);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("optimizeContentsForCPUAccess:slice:level:")]
		extern void OptimizeContentsForCpuAccess (IMTLTexture texture, nuint slice, nuint level);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("resetCommandsInBuffer:withRange:")]
		extern void ResetCommands (IMTLIndirectCommandBuffer buffer, NSRange range);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("copyIndirectCommandBuffer:sourceRange:destination:destinationIndex:")]
		extern void Copy (IMTLIndirectCommandBuffer source, NSRange sourceRange, IMTLIndirectCommandBuffer destination, nuint destinationIndex);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("optimizeIndirectCommandBuffer:withRange:")]
		extern void Optimize (IMTLIndirectCommandBuffer indirectCommandBuffer, NSRange range);

		// @optional in macOS and Mac Catalyst
#if NET && !__MACOS__ && !__MACCATALYST__
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[TV (16, 0), iOS (13, 0), MacCatalyst (15, 0)]
		[Export ("getTextureAccessCounters:region:mipLevel:slice:resetCounters:countersBuffer:countersBufferOffset:")]
		extern void GetTextureAccessCounters (IMTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice, bool resetCounters, IMTLBuffer countersBuffer, nuint countersBufferOffset);

		// @optional in macOS and Mac Catalyst
#if NET && !__MACOS__ && !__MACCATALYST__
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[TV (16, 0), iOS (13, 0), MacCatalyst (15, 0)]
		[Export ("resetTextureAccessCounters:region:mipLevel:slice:")]
		extern void ResetTextureAccessCounters (IMTLTexture texture, MTLRegion region, nuint mipLevel, nuint slice);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("copyFromTexture:sourceSlice:sourceLevel:toTexture:destinationSlice:destinationLevel:sliceCount:levelCount:")]
		extern void Copy (IMTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, IMTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, nuint sliceCount, nuint levelCount);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("copyFromTexture:toTexture:")]
		extern void Copy (IMTLTexture sourceTexture, IMTLTexture destinationTexture);

#if NET
		[Abstract]
#endif
		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("sampleCountersInBuffer:atSampleIndex:withBarrier:")]
#if NET
		extern void SampleCounters (IMTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#else
		void SampleCounters (MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#endif

#if NET
		[Abstract]
#endif
		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("resolveCounters:inRange:destinationBuffer:destinationOffset:")]
#if NET
		extern void ResolveCounters (IMTLCounterSampleBuffer sampleBuffer, NSRange range, IMTLBuffer destinationBuffer, nuint destinationOffset);
#else
		void ResolveCounters (MTLCounterSampleBuffer sampleBuffer, NSRange range, IMTLBuffer destinationBuffer, nuint destinationOffset);
#endif
	}

	interface IMTLFence { }

	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	interface MTLFence {
		[Abstract]
		[Export ("device")]
		IMTLDevice Device { get; }

		[Abstract]
		[NullAllowed, Export ("label")]
		string Label { get; set; }
	}

	public partial interface IMTLDevice: INativeObject { }

	/// <summary>System protocol for interacting with a single graphics device.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	public  static partial class MTLDevice {

		[Abstract, Export ("name")]
		public extern static string Name { get; }

#if NET
		[Abstract] // new required member, but that breaks our binary compat, so we can't do that in our existing code.
#endif
		[MacCatalyst (13, 1)]
		[Export ("maxThreadsPerThreadgroup")]
		public extern static MTLSize MaxThreadsPerThreadgroup { get; }

#if NET
		[Abstract] // new required member, but that breaks our binary compat, so we can't do that in our existing code.
#endif
		[MacCatalyst (15, 0)]
		[NoiOS]
		[NoTV]
		[Export ("lowPower")]
		public extern static bool LowPower { [Bind ("isLowPower")] get; }

#if NET
		[Abstract] // new required member, but that breaks our binary compat, so we can't do that in our existing code.
#endif
		[MacCatalyst (15, 0)]
		[NoiOS]
		[NoTV]
		[Export ("headless")]
		public extern static bool Headless { [Bind ("isHeadless")] get; }

		[iOS (17, 0), TV (17, 0), MacCatalyst (15, 0)]
#if NET
		[Abstract]
#endif
		[Export ("recommendedMaxWorkingSetSize")]
		public extern static ulong RecommendedMaxWorkingSetSize { get; }

#if NET
		[Abstract] // new required member, but that breaks our binary compat, so we can't do that in our existing code.
#endif
		[MacCatalyst (15, 0)]
		[NoiOS]
		[NoTV]
		[Export ("depth24Stencil8PixelFormatSupported")]
		public extern static bool Depth24Stencil8PixelFormatSupported { [Bind ("isDepth24Stencil8PixelFormatSupported")] get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("heapTextureSizeAndAlignWithDescriptor:")]
		extern static MTLSizeAndAlign GetHeapTextureSizeAndAlign (MTLTextureDescriptor desc);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("heapBufferSizeAndAlignWithLength:options:")]
		public extern static MTLSizeAndAlign GetHeapBufferSizeAndAlignWithLength (nuint length, MTLResourceOptions options);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newHeapWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLHeap? CreateHeap (MTLHeapDescriptor descriptor);

		[Abstract, Export ("newCommandQueue")]
		[return: NullAllowed]
		[return: Release]
		public extern static IMTLCommandQueue CreateCommandQueue ();

		[Abstract, Export ("newCommandQueueWithMaxCommandBufferCount:")]
		[return: NullAllowed]
		[return: Release]
		public extern static IMTLCommandQueue CreateCommandQueue (nuint maxCommandBufferCount);

		[Abstract, Export ("newBufferWithLength:options:")]
		[return: NullAllowed]
		[return: Release]
		public extern static IMTLBuffer CreateBuffer (nuint length, MTLResourceOptions options);

		[Abstract, Export ("newBufferWithBytes:length:options:")]
		[return: NullAllowed]
		[return: Release]
		public extern static IMTLBuffer CreateBuffer (IntPtr pointer, nuint length, MTLResourceOptions options);

		[Abstract, Export ("newBufferWithBytesNoCopy:length:options:deallocator:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLBuffer? CreateBufferNoCopy (IntPtr pointer, nuint length, MTLResourceOptions options, MTLDeallocator deallocator);

		[Abstract, Export ("newDepthStencilStateWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLDepthStencilState CreateDepthStencilState (MTLDepthStencilDescriptor descriptor);

		[Abstract, Export ("newTextureWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLTexture CreateTexture (MTLTextureDescriptor descriptor);

		/*
#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[return: NullAllowed]
		[return: Release]
		[Export ("newTextureWithDescriptor:iosurface:plane:")]
		public extern static IMTLTexture CreateTexture (MTLTextureDescriptor descriptor, IOSurface.IOSurface iosurface, nuint plane);
*/

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newSharedTextureWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLTexture CreateSharedTexture (MTLTextureDescriptor descriptor);

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newSharedTextureWithHandle:")]
		[return: NullAllowed]
		[return: Release]
		public extern static IMTLTexture CreateSharedTexture (MTLSharedTextureHandle sharedHandle);

		[Abstract, Export ("newSamplerStateWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLSamplerState CreateSamplerState (MTLSamplerDescriptor descriptor);

		[Abstract, Export ("newDefaultLibrary")]
		[return: Release]
		extern static IMTLLibrary CreateDefaultLibrary ();

		[Abstract, Export ("newLibraryWithFile:error:")]
		[return: Release]
		extern static IMTLLibrary CreateLibrary (string filepath, out NSError error);

#if !NET
		[Abstract, Export ("newLibraryWithData:error:")]
		[return: Release]
		[Obsolete ("Use the overload that take a 'DispatchData' instead.")]
		IMTLLibrary CreateLibrary (NSObject data, out NSError error);
#endif

#if NET
		[Abstract]
		[Export ("newLibraryWithData:error:")]
		[return: Release]
		extern static IMTLLibrary CreateLibrary (DispatchData data, out NSError error);
#endif

		[Abstract, Export ("newLibraryWithSource:options:error:")]
		[return: Release]
		extern static IMTLLibrary CreateLibrary (string source, MTLCompileOptions options, out NSError error);

		[Abstract, Export ("newLibraryWithSource:options:completionHandler:")]
		[Async]
		extern static void CreateLibrary (string source, MTLCompileOptions options, Action<IMTLLibrary, NSError> completionHandler);

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("newDefaultLibraryWithBundle:error:")]
		[return: Release]
		[return: NullAllowed]
#if NET
		extern static IMTLLibrary CreateDefaultLibrary (NSBundle bundle, out NSError error);
#else
		[Obsolete ("Use 'CreateDefaultLibrary' instead.")]
		IMTLLibrary CreateLibrary (NSBundle bundle, out NSError error);
#endif

		[Abstract, Export ("newRenderPipelineStateWithDescriptor:error:")]
		[return: Release]
		extern static IMTLRenderPipelineState CreateRenderPipelineState (MTLRenderPipelineDescriptor descriptor, out NSError error);

		[Abstract, Export ("newRenderPipelineStateWithDescriptor:completionHandler:")]
		extern static void CreateRenderPipelineState (MTLRenderPipelineDescriptor descriptor, Action<IMTLRenderPipelineState, NSError> completionHandler);

		[Abstract]
		[Export ("newRenderPipelineStateWithDescriptor:options:reflection:error:")]
		[return: Release]
		extern static IMTLRenderPipelineState CreateRenderPipelineState (MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, out MTLRenderPipelineReflection reflection, out NSError error);

		[Abstract]
		[Export ("newRenderPipelineStateWithDescriptor:options:completionHandler:")]
		extern static void CreateRenderPipelineState (MTLRenderPipelineDescriptor descriptor, MTLPipelineOption options, Action<IMTLRenderPipelineState, MTLRenderPipelineReflection, NSError> completionHandler);

		[Abstract]
		[Export ("newComputePipelineStateWithFunction:options:reflection:error:")]
		[return: Release]
		extern static IMTLComputePipelineState CreateComputePipelineState (IMTLFunction computeFunction, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error);

		[Abstract]
		[Export ("newComputePipelineStateWithFunction:completionHandler:")]
		extern static void CreateComputePipelineState (IMTLFunction computeFunction, Action<IMTLComputePipelineState, NSError> completionHandler);

		[Abstract, Export ("newComputePipelineStateWithFunction:error:")]
		[return: Release]
		extern static IMTLComputePipelineState CreateComputePipelineState (IMTLFunction computeFunction, out NSError error);

		[Abstract, Export ("newComputePipelineStateWithFunction:options:completionHandler:")]
		extern static void CreateComputePipelineState (IMTLFunction computeFunction, MTLPipelineOption options, Action<IMTLComputePipelineState, MTLComputePipelineReflection, NSError> completionHandler);

		[MacCatalyst (13, 1)]
#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[Export ("newComputePipelineStateWithDescriptor:options:reflection:error:")]
		[return: Release]
		extern static IMTLComputePipelineState CreateComputePipelineState (MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, out MTLComputePipelineReflection reflection, out NSError error);

		[MacCatalyst (13, 1)]
#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[Export ("newComputePipelineStateWithDescriptor:options:completionHandler:")]
	    extern static void CreateComputePipelineState (MTLComputePipelineDescriptor descriptor, MTLPipelineOption options, MTLNewComputePipelineStateWithReflectionCompletionHandler completionHandler);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newFence")]
		[return: Release]
		extern static IMTLFence CreateFence ();

		[Abstract, Export ("supportsFeatureSet:")]
		extern static bool SupportsFeatureSet (MTLFeatureSet featureSet);

		[MacCatalyst (13, 1)]
#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[Export ("supportsTextureSampleCount:")]
		public extern static bool SupportsTextureSampleCount (nuint sampleCount);

		[NoiOS, NoTV, MacCatalyst (15, 0)]
#if NET
		[Abstract]
#endif
		[Export ("removable")]
		public extern static bool Removable { [Bind ("isRemovable")] get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("readWriteTextureSupport")]
		public extern static MTLReadWriteTextureTier ReadWriteTextureSupport { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("argumentBuffersSupport")]
		public extern static MTLArgumentBuffersTier ArgumentBuffersSupport { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("rasterOrderGroupsSupported")]
		public extern static bool RasterOrderGroupsSupported { [Bind ("areRasterOrderGroupsSupported")] get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newLibraryWithURL:error:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLLibrary CreateLibrary (NSUrl url, [NullAllowed] out NSError error);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("minimumLinearTextureAlignmentForPixelFormat:")]
		public extern static nuint GetMinimumLinearTextureAlignment (MTLPixelFormat format);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("minimumTextureBufferAlignmentForPixelFormat:")]
		public extern static nuint GetMinimumTextureBufferAlignment (MTLPixelFormat format);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("maxThreadgroupMemoryLength")]
		public extern static nuint MaxThreadgroupMemoryLength { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("maxArgumentBufferSamplerCount")]
		public extern static nuint MaxArgumentBufferSamplerCount { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("programmableSamplePositionsSupported")]
		public extern static bool ProgrammableSamplePositionsSupported { [Bind ("areProgrammableSamplePositionsSupported")] get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("getDefaultSamplePositions:count:")]
		public extern static void GetDefaultSamplePositions (IntPtr positions, nuint count);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newArgumentEncoderWithArguments:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLArgumentEncoder? CreateArgumentEncoder (MTLArgumentDescriptor [] arguments);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newIndirectCommandBufferWithDescriptor:maxCommandCount:options:")]
		[return: NullAllowed]
		[return: Release]
		extern static  IMTLIndirectCommandBuffer? CreateIndirectCommandBuffer (MTLIndirectCommandBufferDescriptor descriptor, nuint maxCount, MTLResourceOptions options);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[return: NullAllowed]
		[return: Release]
		[Export ("newEvent")]
		extern static  IMTLEvent? CreateEvent ();

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[return: NullAllowed]
		[return: Release]
		[Export ("newSharedEvent")]
		extern static IMTLSharedEvent? CreateSharedEvent ();

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newSharedEventWithHandle:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLSharedEvent? CreateSharedEvent (MTLSharedEventHandle sharedEventHandle);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("maxBufferLength")]
		public extern static nuint MaxBufferLength { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("registryID")]
		public extern static ulong RegistryId { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("currentAllocatedSize")]
		public extern static nuint CurrentAllocatedSize { get; }

#if false // https://bugzilla.xamarin.com/show_bug.cgi?id=59342
		[NoiOS, NoTV]
		[Notification]
		[Field ("MTLDeviceWasAddedNotification")]
		NSString DeviceWasAdded { get; }

		[NoiOS, NoTV]
		[Notification]
		[Field ("MTLDeviceRemovalRequestedNotification")]
		NSString DeviceRemovalRequested { get; }

		[NoiOS, NoTV]
		[Notification]
		[Field ("MTLDeviceWasRemovedNotification")]
		NSString DeviceWasRemoved { get; }
#endif

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[TV (14, 5)]
#if NET
		[Abstract]
#endif
		[Export ("newRenderPipelineStateWithTileDescriptor:options:reflection:error:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLRenderPipelineState? CreateRenderPipelineState (MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, [NullAllowed] out MTLRenderPipelineReflection reflection, [NullAllowed] out NSError error);

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[TV (14, 5)]
#if NET
		[Abstract]
#endif
		[Export ("newRenderPipelineStateWithTileDescriptor:options:completionHandler:")]
		extern static void CreateRenderPipelineState (MTLTileRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[MacCatalyst (13, 4), TV (16, 0), iOS (13, 0)]
		[Export ("supportsVertexAmplificationCount:")]
		public extern static bool SupportsVertexAmplification (nuint count);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[MacCatalyst (13, 4), TV (16, 0), iOS (13, 0)]
		[Export ("supportsRasterizationRateMapWithLayerCount:")]
		public extern static bool SupportsRasterizationRateMap (nuint layerCount);

		[Abstract (GenerateExtensionMethod = true)]
		[MacCatalyst (14, 0), TV (16, 0), iOS (13, 0)]
		[Export ("sparseTileSizeWithTextureType:pixelFormat:sampleCount:")]
		public extern static MTLSize GetSparseTileSize (MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount);

		[Abstract (GenerateExtensionMethod = true)]
		[MacCatalyst (14, 0), TV (16, 0), iOS (13, 0)]
		[Export ("sparseTileSizeInBytes")]
		public extern static nuint SparseTileSizeInBytes { get; }

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[MacCatalyst (13, 4), TV (16, 0), iOS (13, 0)]
		[Export ("newRasterizationRateMapWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		extern static IMTLRasterizationRateMap? CreateRasterizationRateMap (MTLRasterizationRateMapDescriptor descriptor);

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[TV (16, 0), iOS (13, 0)]
		[Export ("convertSparseTileRegions:toPixelRegions:withTileSize:numRegions:")]
		extern static void ConvertSparseTileRegions (IntPtr tileRegions, IntPtr pixelRegions, MTLSize tileSize, nuint numRegions);

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[TV (16, 0), iOS (13, 0)]
		[Export ("convertSparsePixelRegions:toTileRegions:withTileSize:alignmentMode:numRegions:")]
		extern static void ConvertSparsePixelRegions (IntPtr pixelRegions, IntPtr tileRegions, MTLSize tileSize, MTLSparseTextureRegionAlignmentMode mode, nuint numRegions);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("hasUnifiedMemory")]
		public extern static bool HasUnifiedMemory { get; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("supportsFamily:")]
		public extern static bool SupportsFamily (MTLGpuFamily gpuFamily);

#if NET
		[Abstract]
#endif
		[iOS (14, 0), NoTV, MacCatalyst (14, 0)]
		[Export ("barycentricCoordsSupported")]
		public extern static bool BarycentricCoordsSupported { [Bind ("areBarycentricCoordsSupported")] get; }

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("supportsShaderBarycentricCoordinates")]
		public extern static bool SupportsShaderBarycentricCoordinates { get; }

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("peerIndex")]
		public extern static uint PeerIndex { get; }

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("peerCount")]
		public extern static uint PeerCount { get; }

#if NET
		[Abstract]
#endif
		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("counterSets")]
#if NET
		extern static IMTLCounterSet[] CounterSets { get; }
#else
		[Obsolete ("Use 'GetIMTLCounterSets' instead.")]
		MTLCounterSet [] CounterSets { get; }
#endif

#if NET
		[Abstract]
#endif
		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("newCounterSampleBufferWithDescriptor:error:")]
		[return: NullAllowed]
		[return: Release]
#if NET
		public extern static IMTLCounterSampleBuffer CreateCounterSampleBuffer (MTLCounterSampleBufferDescriptor descriptor, [NullAllowed] out NSError error);
#else
		[Obsolete ("Use 'CreateIMTLCounterSampleBuffer' instead.")]
		MTLCounterSampleBuffer CreateCounterSampleBuffer (MTLCounterSampleBufferDescriptor descriptor, [NullAllowed] out NSError error);
#endif

#if NET
		[Abstract]
#endif
		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("sampleTimestamps:gpuTimestamp:")]
		public extern static void GetSampleTimestamps (nuint cpuTimestamp, nuint gpuTimestamp);

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("peerGroupID")]
		public extern static ulong PeerGroupId { get; }

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("maxTransferRate")]
		public extern static ulong MaxTransferRate { get; }

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("location")]
		public extern static MTLDeviceLocation Location { get; }

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("locationNumber")]
		public extern static nuint LocationNumber { get; }

		[Abstract (GenerateExtensionMethod = true)]
		[TV (16, 0), iOS (14, 5), MacCatalyst (14, 5)]
		[Export ("supports32BitFloatFiltering")]
		public extern static bool Supports32BitFloatFiltering { get; }

		[Abstract (GenerateExtensionMethod = true)]
		[TV (16, 0), iOS (14, 5), MacCatalyst (14, 5)]
		[Export ("supports32BitMSAA")]
		public extern static bool Supports32BitMsaa { get; }

		[iOS (16, 4), TV (16, 4), MacCatalyst (16, 4)]
#if NET
		[Abstract]
#endif
		[Export ("supportsBCTextureCompression")]
		public extern static bool SupportsBCTextureCompression { get; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("supportsPullModelInterpolation")]
		public extern static bool SupportsPullModelInterpolation { get; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("supportsCounterSampling:")]
		public extern static bool SupportsCounterSampling (MTLCounterSamplingPoint samplingPoint);

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("supportsDynamicLibraries")]
		public extern static bool SupportsDynamicLibraries { get; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("newDynamicLibrary:error:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLDynamicLibrary CreateDynamicLibrary (IMTLLibrary library, [NullAllowed] out NSError error);

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("newDynamicLibraryWithURL:error:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLDynamicLibrary CreateDynamicLibrary (NSUrl url, [NullAllowed] out NSError error);

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("newBinaryArchiveWithDescriptor:error:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLBinaryArchive CreateBinaryArchive (MTLBinaryArchiveDescriptor descriptor, [NullAllowed] out NSError error);

		[Abstract (GenerateExtensionMethod = true)]
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("supportsRaytracing")]
		 extern static bool SupportsRaytracing { get; }

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("accelerationStructureSizesWithDescriptor:")]
#pragma warning disable 0618 // warning CS0618: 'MTLAccelerationStructureSizes' is obsolete: 'This API is not available on this platform.'
		 extern static MTLAccelerationStructureSizes CreateAccelerationStructureSizes (MTLAccelerationStructureDescriptor descriptor);
#pragma warning restore

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("newAccelerationStructureWithSize:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLAccelerationStructure CreateAccelerationStructure (nuint size);

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("newAccelerationStructureWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLAccelerationStructure CreateAccelerationStructure (MTLAccelerationStructureDescriptor descriptor);

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("supportsFunctionPointers")]
		public extern static bool SupportsFunctionPointers { get; }

		[TV (16, 0), iOS (14, 5), MacCatalyst (14, 5)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("supportsQueryTextureLOD")]
		public extern static bool SupportsQueryTextureLod { get; }

#if NET
		[Abstract]
#endif
		[iOS (15, 0), MacCatalyst (15, 0), TV (15, 0)]
		[Export ("supportsRenderDynamicLibraries")]
		public extern static bool SupportsRenderDynamicLibraries { get; }

		[iOS (15, 0), MacCatalyst (15, 0), TV (16, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("supportsRaytracingFromRender")]
		public extern static bool SupportsRaytracingFromRender { get; }

		[iOS (15, 0), MacCatalyst (15, 0), TV (16, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("supportsPrimitiveMotionBlur")]
		public extern static bool SupportsPrimitiveMotionBlur { get; }

		[iOS (15, 0), MacCatalyst (15, 0), TV (16, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("supportsFunctionPointersFromRender")]
		public extern static bool SupportsFunctionPointersFromRender { get; }

#if NET
		[Abstract]
#endif
		[iOS (15, 0), MacCatalyst (15, 0), TV (15, 0)]
		[Export ("newLibraryWithStitchedDescriptor:error:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLLibrary CreateLibrary (MTLStitchedLibraryDescriptor descriptor, [NullAllowed] out NSError error);

#if NET
		[Abstract]
#endif
		[Async]
		[iOS (15, 0), MacCatalyst (15, 0), TV (15, 0)]
		[Export ("newLibraryWithStitchedDescriptor:completionHandler:")]
		 extern static void CreateLibrary (MTLStitchedLibraryDescriptor descriptor, Action<IMTLLibrary, NSError> completionHandler);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("architecture")]
		 extern static MTLArchitecture Architecture { get; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("heapAccelerationStructureSizeAndAlignWithDescriptor:")]
		 extern static MTLSizeAndAlign GetHeapAccelerationStructureSizeAndAlign (MTLAccelerationStructureDescriptor descriptor);

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("heapAccelerationStructureSizeAndAlignWithSize:")]
		public extern static MTLSizeAndAlign GetHeapAccelerationStructureSizeAndAlign (nuint size);

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("newArgumentEncoderWithBufferBinding:")]
		[return: Release]
		 extern static IMTLArgumentEncoder CreateArgumentEncoder (IMTLBufferBinding bufferBinding);

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("newRenderPipelineStateWithMeshDescriptor:options:reflection:error:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLRenderPipelineState CreateRenderPipelineState (MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, [NullAllowed] out MTLRenderPipelineReflection reflection, [NullAllowed] out NSError error);

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("newRenderPipelineStateWithMeshDescriptor:options:completionHandler:")]
		 extern static void CreateRenderPipelineState (MTLMeshRenderPipelineDescriptor descriptor, MTLPipelineOption options, MTLNewRenderPipelineStateWithReflectionCompletionHandler completionHandler);

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("sparseTileSizeInBytesForSparsePageSize:")]
		 extern static nuint GetSparseTileSizeInBytes (MTLSparsePageSize sparsePageSize);

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("sparseTileSizeWithTextureType:pixelFormat:sampleCount:sparsePageSize:")]
		extern static MTLSize GetSparseTileSize (MTLTextureType textureType, MTLPixelFormat pixelFormat, nuint sampleCount, MTLSparsePageSize sparsePageSize);

		[NoiOS, Mac (13, 3), NoTV, NoMacCatalyst]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("maximumConcurrentCompilationTaskCount")]
		public extern static nuint MaximumConcurrentCompilationTaskCount { get; }

		[NoiOS, Mac (13, 3), NoTV, NoMacCatalyst]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("shouldMaximizeConcurrentCompilation")]
		public extern static bool ShouldMaximizeConcurrentCompilation { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Abstract]
		[Export ("newLogStateWithDescriptor:error:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLLogState GetNewLogState (MTLLogStateDescriptor descriptor, out NSError error);

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Abstract]
		[Export ("newCommandQueueWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		 extern static IMTLCommandQueue CreateCommandQueue (MTLCommandQueueDescriptor descriptor);

#if NET
		[Abstract]
#endif
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[return: NullAllowed]
		[Export ("newResidencySetWithDescriptor:error:")]
		[return: Release]
		 extern static IMTLResidencySet CreateResidencySet (MTLResidencySetDescriptor descriptor, out NSError error);
	}

	/// <summary>Interface representing the required methods (if any) of the protocol <see cref="T:Metal.MTLDrawable" />.</summary>
	///     <remarks>
	///       <para>This interface contains the required methods (if any) from the protocol defined by <see cref="T:Metal.MTLDrawable" />.</para>
	///       <para>If developers create classes that implement this interface, the implementation methods will automatically be exported to Objective-C with the matching signature from the method defined in the <see cref="T:Metal.MTLDrawable" /> protocol.</para>
	///       <para>Optional methods (if any) are provided by the <see cref="T:Metal.MTLDrawable_Extensions" /> class as extension methods to the interface, allowing developers to invoke any optional methods on the protocol.</para>
	///     </remarks>
	/// <summary>Extension methods to the <see cref="T:Metal.IMTLDrawable" /> interface to support all the methods from the <see cref="T:Metal.MTLDrawable" /> protocol.</summary>
	///     <remarks>
	///       <para>The extension methods for <see cref="T:Metal.IMTLDrawable" /> allow developers to treat instances of the interface as having all the optional methods of the original <see cref="T:Metal.MTLDrawable" /> protocol.   Since the interface only contains the required members, these extension methods allow developers to call the optional members of the protocol.</para>
	///     </remarks>
	interface IMTLDrawable { }
	/// <summary>Interface definition for objects that can receive rendering commands.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLDrawable_Ref/index.html">Apple documentation for <c>MTLDrawable</c></related>
	[MacCatalyst (13, 1)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	partial class MTLDrawable {
		[Abstract, Export ("present")] extern void Present ();

		[Abstract, Export ("presentAtTime:")]
		extern void Present (double presentationTime);

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[Introduced (PlatformName.MacCatalyst, 13, 4)]
		[Export ("presentAfterMinimumDuration:")]
		extern void PresentAfter (double duration);

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[Introduced (PlatformName.MacCatalyst, 13, 4)]
		[Export ("addPresentedHandler:")]
		extern void AddPresentedHandler (Action<IMTLDrawable> block);

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[Introduced (PlatformName.MacCatalyst, 13, 4)]
		[Export ("presentedTime")]
		extern double /* CFTimeInterval */ PresentedTime { get; }

#if NET
		[Abstract] // @required but we can't add abstract members in C# and keep binary compatibility
#endif
		[Introduced (PlatformName.MacCatalyst, 13, 4)]
		[Export ("drawableID")]
#if NET
		extern nuint DrawableId { get; }
#else
		nuint DrawableID { get; }
#endif
	}

	public interface IMTLTexture { }

	// Apple added several new *required* members in iOS 9,
	// but that breaks our binary compat, so we can't do that in our existing code.
	/// <summary>System protocol for image data that is used by vertex shaders, fragment shaders, and compute kernels.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLTexture : MTLResource {
		[MacCatalyst (13, 1)]
		//[Deprecated (PlatformName.iOS, 10, 0)]
		//[Deprecated (PlatformName.MacOSX, 10, 12)]
		//[Deprecated (PlatformName.TvOS, 10, 0)]
		[Deprecated (PlatformName.MacCatalyst, 13, 1)]
		[Abstract, Export ("rootResource")]
		extern IMTLResource RootResource { get; }

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[NullAllowed] // by default this property is null
		[Export ("parentTexture")]
		extern IMTLTexture ParentTexture { get; }

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("parentRelativeLevel")]
		extern nuint ParentRelativeLevel { get; }

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("parentRelativeSlice")]
		extern nuint ParentRelativeSlice { get; }

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[NullAllowed] // by default this property is null
		[Export ("buffer")]
		extern IMTLBuffer Buffer { get; }

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("bufferOffset")]
		extern nuint BufferOffset { get; }

#if NET
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("bufferBytesPerRow")]
		extern nuint BufferBytesPerRow { get; }

		[Abstract, Export ("textureType")]
		extern MTLTextureType TextureType { get; }

		[Abstract, Export ("pixelFormat")]
		extern MTLPixelFormat PixelFormat { get; }

		[Abstract, Export ("width")]
		extern nuint Width { get; }

		[Abstract, Export ("height")]
		extern nuint Height { get; }

		[Abstract, Export ("depth")]
		extern nuint Depth { get; }

		[Abstract, Export ("mipmapLevelCount")]
		extern nuint MipmapLevelCount { get; }
		
		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[Abstract, Export ("sampleCount")]
		extern nuint SampleCount { get; }

		[Abstract, Export ("arrayLength")]
		extern nuint ArrayLength { get; }

		[Abstract, Export ("framebufferOnly")]
		extern bool FramebufferOnly { [Bind ("isFramebufferOnly")] get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("allowGPUOptimizedContents")]
		extern bool AllowGpuOptimizedContents { get; }

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Mac (12, 5), iOS (15, 0), MacCatalyst (15, 0), TV (16, 0)]
		[Export ("compressionType")]
		extern MTLTextureCompressionType CompressionType { get; }

		[Abstract, Export ("newTextureViewWithPixelFormat:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLTexture CreateTextureView (MTLPixelFormat pixelFormat);

#if NET
		[Abstract]
#endif
		[Export ("usage")]
		extern MTLTextureUsage Usage { get; }

#if NET
		[Abstract]
#endif
		[Export ("newTextureViewWithPixelFormat:textureType:levels:slices:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLTexture CreateTextureView (MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange);

		[Abstract]
		[Export ("getBytes:bytesPerRow:bytesPerImage:fromRegion:mipmapLevel:slice:")]
		extern void GetBytes (IntPtr pixelBytes, nuint bytesPerRow, nuint bytesPerImage, MTLRegion region, nuint level, nuint slice);

		[Abstract]
		[Export ("getBytes:bytesPerRow:fromRegion:mipmapLevel:")]
		extern void GetBytes (IntPtr pixelBytes, nuint bytesPerRow, MTLRegion region, nuint level);

		[Abstract]
		[Export ("replaceRegion:mipmapLevel:slice:withBytes:bytesPerRow:bytesPerImage:")]
		extern void ReplaceRegion (MTLRegion region, nuint level, nuint slice, IntPtr pixelBytes, nuint bytesPerRow, nuint bytesPerImage);

		[Abstract]
		[Export ("replaceRegion:mipmapLevel:withBytes:bytesPerRow:")]
		extern void ReplaceRegion (MTLRegion region, nuint level, IntPtr pixelBytes, nuint bytesPerRow);

		/*
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("iosurface")]
		IOSurface.IOSurface IOSurface { get; }
		*/

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("iosurfacePlane")]
		extern nuint IOSurfacePlane { get; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("shareable")]
		extern bool Shareable { [Bind ("isShareable")] get; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[return: NullAllowed]
		[return: Release]
		[Export ("newSharedTextureHandle")]
		extern MTLSharedTextureHandle CreateSharedTextureHandle ();

		// @optional in macOS and Mac Catalyst
#if NET && !__MACOS__ && !__MACCATALYST__
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[TV (16, 0), iOS (13, 0), MacCatalyst (15, 0)]
		[Export ("firstMipmapInTail")]
		extern nuint FirstMipmapInTail { get; }

		// @optional in macOS and Mac Catalyst
#if NET && !__MACOS__ && !__MACCATALYST__
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[TV (16, 0), iOS (13, 0), MacCatalyst (15, 0)]
		[Export ("tailSizeInBytes")]
		extern nuint TailSizeInBytes { get; }

		// @optional in macOS and Mac Catalyst
#if NET && !__MACOS__ && !__MACCATALYST__
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[TV (16, 0), iOS (13, 0), MacCatalyst (15, 0)]
		[Export ("isSparse")]
		extern bool IsSparse { get; }

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("swizzle")]
		extern MTLTextureSwizzleChannels Swizzle { get; }

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("newTextureViewWithPixelFormat:textureType:levels:slices:swizzle:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLTexture? Create (MTLPixelFormat pixelFormat, MTLTextureType textureType, NSRange levelRange, NSRange sliceRange, MTLTextureSwizzleChannels swizzle);

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[NullAllowed, Export ("remoteStorageTexture")]
		extern IMTLTexture RemoteStorageTexture { get; }

#if NET
		[Abstract]
#endif
		[NoiOS, NoTV]
		[NoMacCatalyst]
		[Export ("newRemoteTextureViewForDevice:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLTexture CreateRemoteTexture (IMTLDevice device);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("gpuResourceID")]
		extern MTLResourceId GpuResourceId { get; }
	}


	/// <summary>Configuration for <see cref="T:Metal.IMTLTexture" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLTextureDescriptor_Ref/index.html">Apple documentation for <c>MTLTextureDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLTextureDescriptor : NSCopying {

		[Export ("textureType", ArgumentSemantic.Assign)]
		extern MTLTextureType TextureType { get; set; }

		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		extern MTLPixelFormat PixelFormat { get; set; }

		[Export ("width")]
		extern nuint Width { get; set; }

		[Export ("height")]
		extern nuint Height { get; set; }

		[Export ("depth")]
		extern nuint Depth { get; set; }

		[Export ("mipmapLevelCount")]
		extern nuint MipmapLevelCount { get; set; }
		
		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[Export ("sampleCount")]
		extern nuint SampleCount { get; set; }

		[Export ("arrayLength")]
		extern nuint ArrayLength { get; set; }

		[Export ("resourceOptions", ArgumentSemantic.Assign)]
		extern MTLResourceOptions ResourceOptions { get; set; }

		[Static, Export ("texture2DDescriptorWithPixelFormat:width:height:mipmapped:")]
		static extern MTLTextureDescriptor CreateTexture2DDescriptor (MTLPixelFormat pixelFormat, nuint width, nuint height, bool mipmapped);

		[Static, Export ("textureCubeDescriptorWithPixelFormat:size:mipmapped:")]
		static extern MTLTextureDescriptor CreateTextureCubeDescriptor (MTLPixelFormat pixelFormat, nuint size, bool mipmapped);

		[MacCatalyst (13, 1)]
		[Static, Export ("textureBufferDescriptorWithPixelFormat:width:resourceOptions:usage:")]
		static extern MTLTextureDescriptor CreateTextureBufferDescriptor (MTLPixelFormat pixelFormat, nuint width, MTLResourceOptions resourceOptions, MTLTextureUsage usage);

		[MacCatalyst (13, 1)]
		[Export ("cpuCacheMode", ArgumentSemantic.Assign)]
		extern MTLCpuCacheMode CpuCacheMode { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("storageMode", ArgumentSemantic.Assign)]
		extern MTLStorageMode StorageMode { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("usage", ArgumentSemantic.Assign)]
		extern MTLTextureUsage Usage { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("allowGPUOptimizedContents")]
		extern bool AllowGpuOptimizedContents { get; set; }

		[Mac (12, 5), iOS (15, 0), MacCatalyst (15, 0), TV (17, 0)]
		[Export ("compressionType")]
		extern MTLTextureCompressionType CompressionType { get; set; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("hazardTrackingMode", ArgumentSemantic.Assign)]
		extern MTLHazardTrackingMode HazardTrackingMode { get; set; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("swizzle", ArgumentSemantic.Assign)]
		extern MTLTextureSwizzleChannels Swizzle { get; set; }
	}

	/// <summary>Configures a sampler (see <see cref="T:Metal.IMTLSamplerState" />).</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLSamplerDescriptor_Ref/index.html">Apple documentation for <c>MTLSamplerDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLSamplerDescriptor : NSCopying {

		[Export ("minFilter", ArgumentSemantic.Assign)]
		extern MTLSamplerMinMagFilter MinFilter { get; set; }

		[Export ("magFilter", ArgumentSemantic.Assign)]
		extern MTLSamplerMinMagFilter MagFilter { get; set; }

		[Export ("mipFilter", ArgumentSemantic.Assign)]
		extern MTLSamplerMipFilter MipFilter { get; set; }

		[Export ("maxAnisotropy")]
		extern nuint MaxAnisotropy { get; set; }

		[Export ("sAddressMode", ArgumentSemantic.Assign)]
		extern MTLSamplerAddressMode SAddressMode { get; set; }

		[Export ("tAddressMode", ArgumentSemantic.Assign)]
		extern MTLSamplerAddressMode TAddressMode { get; set; }

		[Export ("rAddressMode", ArgumentSemantic.Assign)]
		extern MTLSamplerAddressMode RAddressMode { get; set; }

		[Export ("normalizedCoordinates")]
		extern bool NormalizedCoordinates { get; set; }

		[Export ("lodMinClamp")]
		extern float LodMinClamp { get; set; } /* float, not CGFloat */

		[Export ("lodMaxClamp")]
		extern float LodMaxClamp { get; set; } /* float, not CGFloat */

		[MacCatalyst (13, 1)]
		[Export ("lodAverage")]
		extern bool LodAverage { get; set; }

		[iOS (14, 0), TV (17, 0)]
		[MacCatalyst (14, 0)]
		[Export ("borderColor", ArgumentSemantic.Assign)]
		extern MTLSamplerBorderColor BorderColor { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("compareFunction")]
		extern MTLCompareFunction CompareFunction { get; set; }

		[Export ("label")]
		[NullAllowed]
		extern string Label { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("supportArgumentBuffers")]
		extern bool SupportArgumentBuffers { get; set; }
	}

	public interface IMTLSamplerState: INativeObject { }
	/// <summary>System protocol the way that shaders or compute kernels will sample textures.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLSamplerState {

		[Abstract, Export ("label")]
		extern string Label { get; }

		[Abstract, Export ("device")]
		extern IMTLDevice Device { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("gpuResourceID")]
		extern MTLResourceId GpuResourceId { get; }
	}

	/// <summary>Configures a rendering pipeline with rasterization properties, visibility, blending, and shader functions.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPipelineDescriptor_Ref/index.html">Apple documentation for <c>MTLRenderPipelineDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLRenderPipelineDescriptor : NSCopying {

		[Export ("label")]
		[NullAllowed]
		extern string Label { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("vertexFunction", ArgumentSemantic.Retain)]
		extern IMTLFunction VertexFunction { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("fragmentFunction", ArgumentSemantic.Retain)]
		extern IMTLFunction FragmentFunction { get; set; }

		[Export ("vertexDescriptor", ArgumentSemantic.Copy)]
		[NullAllowed]
		extern MTLVertexDescriptor? VertexDescriptor { get; set; }


		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[Export ("sampleCount")]
		extern nuint SampleCount { get; set; }

		[Export ("alphaToCoverageEnabled")]
		extern bool AlphaToCoverageEnabled { [Bind ("isAlphaToCoverageEnabled")] get; set; }

		[Export ("alphaToOneEnabled")]
		extern bool AlphaToOneEnabled { [Bind ("isAlphaToOneEnabled")] get; set; }

		[Export ("rasterizationEnabled")]
		extern bool RasterizationEnabled { [Bind ("isRasterizationEnabled")] get; set; }

		[Export ("reset")]
		extern void Reset ();

		[Export ("colorAttachments")]
		extern MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments { get; }

		[Export ("depthAttachmentPixelFormat")]
		extern MTLPixelFormat DepthAttachmentPixelFormat { get; set; }

		[Export ("stencilAttachmentPixelFormat")]
		extern MTLPixelFormat StencilAttachmentPixelFormat { get; set; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("inputPrimitiveTopology", ArgumentSemantic.Assign)]
		extern MTLPrimitiveTopologyClass InputPrimitiveTopology { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tessellationPartitionMode", ArgumentSemantic.Assign)]
		extern MTLTessellationPartitionMode TessellationPartitionMode { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("maxTessellationFactor")]
		extern nuint MaxTessellationFactor { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tessellationFactorScaleEnabled")]
		extern bool IsTessellationFactorScaleEnabled { [Bind ("isTessellationFactorScaleEnabled")] get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tessellationFactorFormat", ArgumentSemantic.Assign)]
		extern MTLTessellationFactorFormat TessellationFactorFormat { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tessellationControlPointIndexType", ArgumentSemantic.Assign)]
		extern MTLTessellationControlPointIndexType TessellationControlPointIndexType { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tessellationFactorStepFunction", ArgumentSemantic.Assign)]
		extern MTLTessellationFactorStepFunction TessellationFactorStepFunction { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("tessellationOutputWindingOrder", ArgumentSemantic.Assign)]
		extern MTLWinding TessellationOutputWindingOrder { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("vertexBuffers")]
		extern MTLPipelineBufferDescriptorArray VertexBuffers { get; }

		[MacCatalyst (13, 1)]
		[Export ("fragmentBuffers")]
		extern MTLPipelineBufferDescriptorArray FragmentBuffers { get; }

		[MacCatalyst (13, 1)]
		[Export ("rasterSampleCount")]
		extern nuint RasterSampleCount { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("supportIndirectCommandBuffers")]
		extern bool SupportIndirectCommandBuffers { get; set; }

		[Introduced (PlatformName.MacCatalyst, 13, 4)]
		[TV (17, 0), iOS (13, 0)]
		[Export ("maxVertexAmplificationCount")]
		extern nuint MaxVertexAmplificationCount { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("binaryArchives", ArgumentSemantic.Copy)]
		extern IMTLBinaryArchive [] BinaryArchives { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("vertexPreloadedLibraries", ArgumentSemantic.Copy)]
		extern IMTLDynamicLibrary [] VertexPreloadedLibraries { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("vertexLinkedFunctions", ArgumentSemantic.Copy)]
		extern MTLLinkedFunctions VertexLinkedFunctions { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("supportAddingVertexBinaryFunctions")]
		extern bool SupportAddingVertexBinaryFunctions { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("supportAddingFragmentBinaryFunctions")]
		bool SupportAddingFragmentBinaryFunctions { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("maxVertexCallStackDepth")]
		extern nuint MaxVertexCallStackDepth { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("maxFragmentCallStackDepth")]
		extern nuint MaxFragmentCallStackDepth { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("fragmentPreloadedLibraries", ArgumentSemantic.Copy)]
		extern IMTLDynamicLibrary [] FragmentPreloadedLibraries { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("fragmentLinkedFunctions", ArgumentSemantic.Copy)]
		extern MTLLinkedFunctions FragmentLinkedFunctions { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("shaderValidation")]
		extern MTLShaderValidation ShaderValidation { get; set; }
	}

	/// <summary>An array of <see cref="T:Metal.MTLRenderPipelineColorAttachmentDescriptor" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPipelineColorAttachmentDescriptorArray_Ref/index.html">Apple documentation for <c>MTLRenderPipelineColorAttachmentDescriptorArray</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLRenderPipelineColorAttachmentDescriptorArray: NSObject {

		[Export ("objectAtIndexedSubscript:"), Internal]
		public extern MTLRenderPipelineColorAttachmentDescriptor ObjectAtIndexedSubscript (nuint attachmentIndex);

		[Export ("setObject:atIndexedSubscript:"), Internal]
		public extern void SetObject ([NullAllowed] MTLRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex);
	}

	interface IMTLRenderPipelineState { }

	/// <summary>System protocol for encoding the state of a rendering pipeline.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial interface MTLRenderPipelineState {

		[Abstract, Export ("label")]
		string Label { get; }

		[Abstract, Export ("device")]
		IMTLDevice Device { get; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("maxTotalThreadsPerThreadgroup")]
		nuint MaxTotalThreadsPerThreadgroup { get; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("threadgroupSizeMatchesTileSize")]
		bool ThreadgroupSizeMatchesTileSize { get; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("imageblockSampleLength")]
		nuint ImageblockSampleLength { get; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("imageblockMemoryLengthForDimensions:")]
		nuint GetImageblockMemoryLength (MTLSize imageblockDimensions);

		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("supportIndirectCommandBuffers")]
		bool SupportIndirectCommandBuffers { get; }

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("functionHandleWithFunction:stage:")]
		[return: NullAllowed]
		IMTLFunctionHandle FunctionHandleWithFunction (IMTLFunction function, MTLRenderStages stage);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("newVisibleFunctionTableWithDescriptor:stage:")]
		[return: NullAllowed]
		[return: Release]
		IMTLVisibleFunctionTable NewVisibleFunctionTableWithDescriptor (MTLVisibleFunctionTableDescriptor descriptor, MTLRenderStages stage);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("newIntersectionFunctionTableWithDescriptor:stage:")]
		[return: NullAllowed]
		[return: Release]
		IMTLIntersectionFunctionTable NewIntersectionFunctionTableWithDescriptor (MTLIntersectionFunctionTableDescriptor descriptor, MTLRenderStages stage);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("newRenderPipelineStateWithAdditionalBinaryFunctions:error:")]
		[return: NullAllowed]
		[return: Release]
		IMTLRenderPipelineState NewRenderPipelineStateWithAdditionalBinaryFunctions (MTLRenderPipelineFunctionsDescriptor additionalBinaryFunctions, [NullAllowed] out NSError error);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Abstract]
		[Export ("meshThreadExecutionWidth")]
		nuint MeshThreadExecutionWidth { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Abstract]
		[Export ("maxTotalThreadgroupsPerMeshGrid")]
		nuint MaxTotalThreadgroupsPerMeshGrid { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Abstract]
		[Export ("gpuResourceID")]
		MTLResourceId GpuResourceId { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("maxTotalThreadsPerMeshThreadgroup")]
		nuint MaxTotalThreadsPerMeshThreadgroup { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("maxTotalThreadsPerObjectThreadgroup")]
		nuint MaxTotalThreadsPerObjectThreadgroup { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("objectThreadExecutionWidth")]
		nuint ObjectThreadExecutionWidth { get; }

		[Abstract]
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("shaderValidation")]
		MTLShaderValidation ShaderValidation { get; }
	}

	/// <summary>Configures how vertex and attribute data are fetched by a vertex shader function.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLVertexBufferLayoutDescriptor_Ref/index.html">Apple documentation for <c>MTLVertexBufferLayoutDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLVertexBufferLayoutDescriptor : NSCopying {
		[Export ("stride", ArgumentSemantic.UnsafeUnretained)]
		public extern nuint Stride { get; set; }

		[Export ("stepFunction", ArgumentSemantic.Assign)]
		public extern MTLVertexStepFunction StepFunction { get; set; }

		[Export ("stepRate", ArgumentSemantic.UnsafeUnretained)]
		public extern nuint StepRate { get; set; }
	}

	/// <summary>Holds an array of <see cref="T:Metal.MTLVertexBufferLayoutDescriptor" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLVertexBufferLayoutDescriptorArray_Ref/index.html">Apple documentation for <c>MTLVertexBufferLayoutDescriptorArray</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLVertexBufferLayoutDescriptorArray: NSObject {
		[Export ("objectAtIndexedSubscript:"), Internal]
		public extern MTLVertexBufferLayoutDescriptor ObjectAtIndexedSubscript (nuint index);

		[Export ("setObject:atIndexedSubscript:"), Internal]
		public extern void SetObject ([NullAllowed] MTLVertexBufferLayoutDescriptor bufferDesc, nuint index);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	interface MTLAttribute {
		[Export ("name")]
		string Name { get; }

		[Export ("attributeIndex")]
		nuint AttributeIndex { get; }

		[Export ("attributeType")]
		MTLDataType AttributeType { get; }

		[Export ("active")]
		bool Active { [Bind ("isActive")] get; }

		[Export ("patchData")]
		bool IsPatchData { [Bind ("isPatchData")] get; }

		[Export ("patchControlPointData")]
		bool IsPatchControlPointData { [Bind ("isPatchControlPointData")] get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLAttributeDescriptor : NSCopying {
		[Export ("format", ArgumentSemantic.Assign)]
		public extern MTLAttributeFormat Format { get; set; }

		[Export ("offset")]
		public extern nuint Offset { get; set; }

		[Export ("bufferIndex")]
		public extern nuint BufferIndex { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLAttributeDescriptorArray: NSObject {
		[Internal]
		[Export ("objectAtIndexedSubscript:")]
		internal extern MTLAttributeDescriptor ObjectAtIndexedSubscript (nuint index);

		[Internal]
		[Export ("setObject:atIndexedSubscript:")]
		internal extern void SetObject ([NullAllowed] MTLAttributeDescriptor attributeDesc, nuint index);
	}

	/// <summary>An attribute for per-vertex input for a vertex shader function.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLVertexAttributeDescriptor_Ref/index.html">Apple documentation for <c>MTLVertexAttributeDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLVertexAttributeDescriptor : NSCopying {
		[Export ("format", ArgumentSemantic.Assign)]
		public extern MTLVertexFormat Format { get; set; }

		[Export ("offset", ArgumentSemantic.Assign)]
		public extern nuint Offset { get; set; }

		[Export ("bufferIndex", ArgumentSemantic.Assign)]
		public extern nuint BufferIndex { get; set; }
	}

	/// <summary>Holds an array of <see cref="T:Metal.MTLVertexAttributeDescriptor" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLVertexAttributeDescriptorArray_Ref/index.html">Apple documentation for <c>MTLVertexAttributeDescriptorArray</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLVertexAttributeDescriptorArray: NSObject {
		[Export ("objectAtIndexedSubscript:"), Internal]
		public extern MTLVertexAttributeDescriptor ObjectAtIndexedSubscript (nuint index);

		[Export ("setObject:atIndexedSubscript:"), Internal]
		public extern void SetObject ([NullAllowed] MTLVertexAttributeDescriptor attributeDesc, nuint index);
	}

	/// <summary>Maps vertex data in memory to attributes in a vertex shader.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLVertexDescriptor_Ref/index.html">Apple documentation for <c>MTLVertexDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLVertexDescriptor : NSCopying {
		[Static, Export ("vertexDescriptor")]
		public static extern MTLVertexDescriptor Create ();

		[Export ("reset")]
		public extern void Reset ();

		[Export ("layouts")]
		public extern MTLVertexBufferLayoutDescriptorArray Layouts { get; }

		[Export ("attributes")]
		public extern MTLVertexAttributeDescriptorArray Attributes { get; }
	}

	/// <summary>An attribute for per-vertex input to a vertex shader function.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLVertexAttribute_Ref/index.html">Apple documentation for <c>MTLVertexAttribute</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial interface MTLVertexAttribute {
		[Export ("attributeIndex")]
		nuint AttributeIndex { get; }

		[MacCatalyst (13, 1)]
		[Export ("attributeType")]
		MTLDataType AttributeType { get; }

		[Export ("active")]
		bool Active { [Bind ("isActive")] get; }

		[Export ("name")]
		string Name { get; }

		[MacCatalyst (13, 1)]
		[Export ("patchData")]
		bool PatchData { [Bind ("isPatchData")] get; }

		[MacCatalyst (13, 1)]
		[Export ("patchControlPointData")]
		bool PatchControlPointData { [Bind ("isPatchControlPointData")] get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	//[DisableDefaultCtor]
	class MTLFunctionConstantValues : NSCopying {
		[MacCatalyst (13, 1)]
		[Export ("init")]
		extern NativeHandle Constructor ();

		[Export ("setConstantValue:type:atIndex:")]
		extern void SetConstantValue (IntPtr value, MTLDataType type, nuint index);

		[Export ("setConstantValues:type:withRange:")]
		extern void SetConstantValues (IntPtr values, MTLDataType type, NSRange range);

		[Export ("setConstantValue:type:withName:")]
		extern void SetConstantValue (IntPtr value, MTLDataType type, string name);

		[Export ("reset")]
		extern void Reset ();
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLFunctionConstant: NSObject {
		[Export ("name")]
		extern string Name { get; }

		[Export ("type")]
		extern MTLDataType Type { get; }

		[Export ("index")]
		extern nuint Index { get; }

		[Export ("required")]
		extern bool IsRequired { get; }
	}

	interface IMTLFunction: INativeObject { }
	/// <summary>System protocol for shader functions that are suitable for use on a GPU in a shader or compute function.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLFunction {

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[Abstract, Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract, Export ("functionType")]
		extern MTLFunctionType FunctionType { get; }

		[Abstract, Export ("vertexAttributes")]
		extern MTLVertexAttribute [] VertexAttributes { get; }

		[Abstract, Export ("name")]
		extern string Name { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("patchType")]
		extern MTLPatchType PatchType { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("patchControlPointCount")]
		extern nint PatchControlPointCount { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("stageInputAttributes")]
		extern MTLAttribute [] StageInputAttributes { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("functionConstantsDictionary")]
		extern NSDictionary<NSString, MTLFunctionConstant> FunctionConstants { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newArgumentEncoderWithBufferIndex:")]
		[return: Release]
		extern IMTLArgumentEncoder CreateArgumentEncoder (nuint bufferIndex);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newArgumentEncoderWithBufferIndex:reflection:")]
		[return: Release]
		extern IMTLArgumentEncoder CreateArgumentEncoder (nuint bufferIndex, [NullAllowed] out MTLArgument reflection);

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("options")]
		extern MTLFunctionOptions Options { get; }
	}

	interface IMTLLibrary { }

	/// <summary>System protocol for libraries of shaders.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLLibrary {

		[Abstract, Export ("label")]
		extern string Label { get; set; }

		[Abstract, Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract, Export ("functionNames")]
		extern string [] FunctionNames { get; }

		[Abstract, Export ("newFunctionWithName:")]
		[return: Release]
		extern IMTLFunction CreateFunction (string functionName);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newFunctionWithName:constantValues:error:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLFunction CreateFunction (string name, MTLFunctionConstantValues constantValues, out NSError error);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newFunctionWithName:constantValues:completionHandler:")]
		[Async]
		extern void CreateFunction (string name, MTLFunctionConstantValues constantValues, Action<IMTLFunction, NSError> completionHandler);

		[Field ("MTLLibraryErrorDomain")]
		NSString ErrorDomain { get; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("newFunctionWithDescriptor:completionHandler:")]
		extern void CreateFunction (MTLFunctionDescriptor descriptor, Action<IMTLFunction, NSError> completionHandler);

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("newFunctionWithDescriptor:error:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLFunction CreateFunction (MTLFunctionDescriptor descriptor, [NullAllowed] out NSError error);

		// protocol, so no Async
		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("newIntersectionFunctionWithDescriptor:completionHandler:")]
		extern void CreateIntersectionFunction (MTLIntersectionFunctionDescriptor descriptor, Action<IMTLFunction, NSError> completionHandler);

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("newIntersectionFunctionWithDescriptor:error:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLFunction CreateIntersectionFunction (MTLIntersectionFunctionDescriptor descriptor, [NullAllowed] out NSError error);

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("type")]
		extern MTLLibraryType Type { get; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("installName")]
		extern string InstallName { get; }
	}

	/// <summary>Configures the compilation of a Metal shader library.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLCompileOptions_Ref/index.html">Apple documentation for <c>MTLCompileOptions</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLCompileOptions : NSCopying {

		[NullAllowed] // by default this property is null
		[Export ("preprocessorMacros", ArgumentSemantic.Copy)]
#if NET
		extern NSDictionary<NSString, NSObject> PreprocessorMacros { get; set; }
#else
		NSDictionary PreprocessorMacros { get; set; }
#endif
		
		[Deprecated (PlatformName.TvOS, 18, 0, message: "Use 'MathMode' instead.")]
		[Export ("fastMathEnabled")]
		extern bool FastMathEnabled { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("languageVersion", ArgumentSemantic.Assign)]
		extern MTLLanguageVersion LanguageVersion { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("libraryType", ArgumentSemantic.Assign)]
		extern MTLLibraryType LibraryType { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("installName")]
		extern string InstallName { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("libraries", ArgumentSemantic.Copy)]
		extern IMTLDynamicLibrary [] Libraries { get; set; }

		[Introduced (PlatformName.MacCatalyst, 14, 0)]
		[iOS (13, 0), TV (14, 0)]
		[Export ("preserveInvariance")]
		extern bool PreserveInvariance { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
		[Export ("optimizationLevel", ArgumentSemantic.Assign)]
		extern MTLLibraryOptimizationLevel OptimizationLevel { get; set; }

		[Mac (13, 3), iOS (16, 4), MacCatalyst (16, 4), TV (16, 4)]
		[Export ("compileSymbolVisibility", ArgumentSemantic.Assign)]
		extern MTLCompileSymbolVisibility CompileSymbolVisibility { get; set; }

		[Mac (13, 3), iOS (16, 4), MacCatalyst (16, 4), TV (16, 4)]
		[Export ("allowReferencingUndefinedSymbols")]
		extern bool AllowReferencingUndefinedSymbols { get; set; }

		[Mac (13, 3), iOS (16, 4), MacCatalyst (16, 4), TV (16, 4)]
		[Export ("maxTotalThreadsPerThreadgroup")]
		extern nuint MaxTotalThreadsPerThreadgroup { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("mathMode")]
		extern MTLMathMode MathMode { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("mathFloatingPointFunctions")]
		extern MTLMathFloatingPointFunctions MathFloatingPointFunctions { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("enableLogging")]
		extern bool EnableLogging { get; set; }
	}

	/// <summary>Configures a stencil test operation.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLStencilDescriptor_Ref/index.html">Apple documentation for <c>MTLStencilDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLStencilDescriptor : NSCopying {
		[Export ("stencilCompareFunction")]
		extern MTLCompareFunction StencilCompareFunction { get; set; }

		[Export ("stencilFailureOperation")]
		extern MTLStencilOperation StencilFailureOperation { get; set; }

		[Export ("depthFailureOperation")]
		extern MTLStencilOperation DepthFailureOperation { get; set; }

		[Export ("depthStencilPassOperation")]
		extern MTLStencilOperation DepthStencilPassOperation { get; set; }

		[Export ("readMask")]
		extern uint ReadMask { get; set; } /* uint32_t */

		[Export ("writeMask")]
		extern uint WriteMask { get; set; } /* uint32_t */
	}

	/// <summary>Describes a single field within a <see cref="T:Metal.MTLStructType" /> struct.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLStructMember_Ref/index.html">Apple documentation for <c>MTLStructMember</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLStructMember: NSObject {
		[Export ("name")]
		extern string Name { get; }

		[Export ("offset")]
		extern nuint Offset { get; }

		[Export ("dataType")]
		extern MTLDataType DataType { get; }

#if NET
		[Export ("structType")]
		[NullAllowed]
		extern MTLStructType StructType { get; }

		[Export ("arrayType")]
		[NullAllowed]
		extern MTLArrayType ArrayType { get; }
#else
		[Export ("structType")]
		[return: NullAllowed]
		MTLStructType StructType ();

		[Export ("arrayType")]
		[return: NullAllowed]
		MTLArrayType ArrayType ();
#endif

		[MacCatalyst (13, 1)]
		[Export ("argumentIndex")]
		extern nuint ArgumentIndex { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("textureReferenceType")]
		extern MTLTextureReferenceType TextureReferenceType { get; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("pointerType")]
		extern MTLPointerType PointerType { get; }
	}

	/// <summary>Defines a type representing a struct, which can be passed as an argument to Metal functions.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLStructType_Ref/index.html">Apple documentation for <c>MTLStructType</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (MTLType))]
	class MTLStructType: MTLType {
		[Export ("members")]
		extern MTLStructMember [] Members { get; }

		[Export ("memberByName:")]
		[return: NullAllowed]
		extern MTLStructMember Lookup (string name);
	}

	interface IMTLDepthStencilState { }

	/// <summary>System protocol for describing how the depth stencil should interact with the depth buffer during rendering.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial interface MTLDepthStencilState {
		[Abstract]
		[Export ("label")]
		string Label { get; }

		[Abstract]
		[Export ("device")]
		IMTLDevice Device { get; }
	}

	/// <summary>Configures a depth stencil test operation.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLDepthStencilDescriptor_Ref/index.html">Apple documentation for <c>MTLDepthStencilDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	partial class MTLDepthStencilDescriptor : NSCopying {

		[Export ("depthCompareFunction")]
		extern MTLCompareFunction DepthCompareFunction { get; set; }

		[Export ("depthWriteEnabled")]
		extern bool DepthWriteEnabled { [Bind ("isDepthWriteEnabled")] get; set; }

		[Export ("frontFaceStencil", ArgumentSemantic.Copy)]
		[NullAllowed]
		extern MTLStencilDescriptor FrontFaceStencil { get; set; }

		[Export ("backFaceStencil", ArgumentSemantic.Copy)]
		[NullAllowed]
		extern MTLStencilDescriptor BackFaceStencil { get; set; }

		[Export ("label")]
		[NullAllowed]
		extern string Label { get; set; }
	}

	interface IMTLParallelRenderCommandEncoder { }

	/// <summary>System protocol for breaking a single rendering pass into parallel command sets.</summary>
	/// <summary>Extension methods to the <see cref="T:Metal.IMTLParallelRenderCommandEncoder" /> interface to support all the methods from the <see cref="T:Metal.IMTLParallelRenderCommandEncoder" /> protocol.</summary>
	///     <remarks>
	///       <para>The extension methods for <see cref="T:Metal.IMTLParallelRenderCommandEncoder" /> allow developers to treat instances of the interface as having all the optional methods of the original <see cref="T:Metal.IMTLParallelRenderCommandEncoder" /> protocol.   Since the interface only contains the required members, these extension methods allow developers to call the optional members of the protocol.</para>
	///     </remarks>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	class MTLParallelRenderCommandEncoder : MTLCommandEncoder {
		[Abstract]
		[Export ("renderCommandEncoder")]
		[Autorelease]
		[return: NullAllowed]
		extern IMTLRenderCommandEncoder CreateRenderCommandEncoder ();

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setColorStoreAction:atIndex:")]
		extern void SetColorStoreAction (MTLStoreAction storeAction, nuint colorAttachmentIndex);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setDepthStoreAction:")]
		extern void SetDepthStoreAction (MTLStoreAction storeAction);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setStencilStoreAction:")]
		extern void SetStencilStoreAction (MTLStoreAction storeAction);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setColorStoreActionOptions:atIndex:")]
		extern void SetColorStoreActionOptions (MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setDepthStoreActionOptions:")]
		extern void SetDepthStoreActionOptions (MTLStoreActionOptions storeActionOptions);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setStencilStoreActionOptions:")]
		extern void SetStencilStoreActionOptions (MTLStoreActionOptions storeActionOptions);
	}

	public interface IMTLRenderCommandEncoder { }

	/// <summary>System protocol for encoding render commands and state into a buffer.</summary>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLRenderCommandEncoder : MTLCommandEncoder {

		[Abstract, Export ("setRenderPipelineState:")]
		extern void SetRenderPipelineState (IMTLRenderPipelineState pipelineState);

		[Abstract, Export ("setVertexBuffer:offset:atIndex:")]
		extern void SetVertexBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[Abstract, Export ("setVertexTexture:atIndex:")]
		extern void SetVertexTexture (IMTLTexture texture, nuint index);

		[Abstract, Export ("setVertexSamplerState:atIndex:")]
		extern void SetVertexSamplerState (IMTLSamplerState sampler, nuint index);

		[Abstract, Export ("setVertexSamplerState:lodMinClamp:lodMaxClamp:atIndex:")]
		extern void SetVertexSamplerState (IMTLSamplerState sampler, float /* float, not CGFloat */ lodMinClamp, float /* float, not CGFloat */ lodMaxClamp, nuint index);

		[Abstract, Export ("setViewport:")]
		extern void SetViewport (MTLViewport viewport);

		[Abstract, Export ("setFrontFacingWinding:")]
		extern void SetFrontFacingWinding (MTLWinding frontFacingWinding);

		[Abstract, Export ("setCullMode:")]
		extern void SetCullMode (MTLCullMode cullMode);

		[MacCatalyst (13, 1)]
#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[Export ("setDepthClipMode:")]
		extern void SetDepthClipMode (MTLDepthClipMode depthClipMode);

		[Abstract, Export ("setDepthBias:slopeScale:clamp:")]
		extern void SetDepthBias (float /* float, not CGFloat */ depthBias, float /* float, not CGFloat */ slopeScale, float /* float, not CGFloat */ clamp);

		[Abstract, Export ("setScissorRect:")]
		extern void SetScissorRect (MTLScissorRect rect);

		[Abstract, Export ("setTriangleFillMode:")]
		extern void SetTriangleFillMode (MTLTriangleFillMode fillMode);

		[Abstract, Export ("setFragmentBuffer:offset:atIndex:")]
		extern void SetFragmentBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[MacCatalyst (13, 1)]
		[Abstract, Export ("setFragmentBufferOffset:atIndex:")]
		extern void SetFragmentBufferOffset (nuint offset, nuint index);

		[MacCatalyst (13, 1)]
		[Abstract, Export ("setFragmentBytes:length:atIndex:")]
		extern void SetFragmentBytes (IntPtr bytes, nuint length, nuint index);

		[Abstract, Export ("setFragmentTexture:atIndex:")]
		extern void SetFragmentTexture (IMTLTexture texture, nuint index);

		[Abstract, Export ("setFragmentSamplerState:atIndex:")]
		extern void SetFragmentSamplerState (IMTLSamplerState sampler, nuint index);

		[Abstract, Export ("setFragmentSamplerState:lodMinClamp:lodMaxClamp:atIndex:")]
		extern void SetFragmentSamplerState (IMTLSamplerState sampler, float /* float, not CGFloat */ lodMinClamp, float /* float, not CGFloat */ lodMaxClamp, nuint index);

		[Abstract, Export ("setBlendColorRed:green:blue:alpha:")]
		extern void SetBlendColor (float /* float, not CGFloat */ red, float /* float, not CGFloat */ green, float /* float, not CGFloat */ blue, float /* float, not CGFloat */ alpha);

		[Abstract, Export ("setDepthStencilState:")]
		extern void SetDepthStencilState (IMTLDepthStencilState depthStencilState);

		[Abstract, Export ("setStencilReferenceValue:")]
		extern void SetStencilReferenceValue (uint /* uint32_t */ referenceValue);

		[MacCatalyst (13, 1)]
#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[Export ("setStencilFrontReferenceValue:backReferenceValue:")]
		extern void SetStencilFrontReferenceValue (uint frontReferenceValue, uint backReferenceValue);

		[Abstract, Export ("setVisibilityResultMode:offset:")]
		extern void SetVisibilityResultMode (MTLVisibilityResultMode mode, nuint offset);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setColorStoreAction:atIndex:")]
		extern void SetColorStoreAction (MTLStoreAction storeAction, nuint colorAttachmentIndex);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setDepthStoreAction:")]
		extern void SetDepthStoreAction (MTLStoreAction storeAction);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setStencilStoreAction:")]
		extern void SetStencilStoreAction (MTLStoreAction storeAction);

		[Abstract, Export ("drawPrimitives:vertexStart:vertexCount:instanceCount:")]
		extern void DrawPrimitives (MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount);

		[Abstract, Export ("drawPrimitives:vertexStart:vertexCount:")]
		extern void DrawPrimitives (MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount);

		[Abstract, Export ("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:")]
		extern void DrawIndexedPrimitives (MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, IMTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount);

		[Abstract, Export ("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:")]
		extern void DrawIndexedPrimitives (MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, IMTLBuffer indexBuffer, nuint indexBufferOffset);

#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:")]
		extern void DrawPrimitives (MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance);

#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:")]
		extern void DrawIndexedPrimitives (MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, IMTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance);

#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("drawPrimitives:indirectBuffer:indirectBufferOffset:")]
		extern void DrawPrimitives (MTLPrimitiveType primitiveType, IMTLBuffer indirectBuffer, nuint indirectBufferOffset);

#if NET
		// Apple added a new required member in iOS 9, but that breaks our binary compat, so we can't do that in our existing code.
		[Abstract]
#endif
		[MacCatalyst (13, 1)]
		[Export ("drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:")]
		extern void DrawIndexedPrimitives (MTLPrimitiveType primitiveType, MTLIndexType indexType, IMTLBuffer indexBuffer, nuint indexBufferOffset, IMTLBuffer indirectBuffer, nuint indirectBufferOffset);

		[Abstract, Export ("setFragmentBuffers:offsets:withRange:")]
		extern void SetFragmentBuffers (IMTLBuffer buffers, IntPtr IntPtrOffsets, NSRange range);

		[Abstract, Export ("setFragmentSamplerStates:lodMinClamps:lodMaxClamps:withRange:")]
		extern void SetFragmentSamplerStates (IMTLSamplerState [] samplers, IntPtr floatArrayPtrLodMinClamps, IntPtr floatArrayPtrLodMaxClamps, NSRange range);

		[Abstract, Export ("setFragmentSamplerStates:withRange:")]
		extern void SetFragmentSamplerStates (IMTLSamplerState [] samplers, NSRange range);

		[Abstract, Export ("setFragmentTextures:withRange:")]
		extern void SetFragmentTextures (IMTLTexture [] textures, NSRange range);

		[Abstract, Export ("setVertexBuffers:offsets:withRange:")]
		extern void SetVertexBuffers (IMTLBuffer [] buffers, IntPtr uintArrayPtrOffsets, NSRange range);

		[MacCatalyst (13, 1)]
		[Abstract, Export ("setVertexBufferOffset:atIndex:")]
		extern void SetVertexBufferOffset (nuint offset, nuint index);

		[MacCatalyst (13, 1)]
		[Abstract, Export ("setVertexBytes:length:atIndex:")]
		extern void SetVertexBytes (IntPtr bytes, nuint length, nuint index);

		[Abstract, Export ("setVertexSamplerStates:lodMinClamps:lodMaxClamps:withRange:")]
		extern void SetVertexSamplerStates (IMTLSamplerState [] samplers, IntPtr floatArrayPtrLodMinClamps, IntPtr floatArrayPtrLodMaxClamps, NSRange range);

		[Abstract, Export ("setVertexSamplerStates:withRange:")]
		extern void SetVertexSamplerStates (IMTLSamplerState [] samplers, NSRange range);

		[Abstract]
		[Export ("setVertexTextures:withRange:")]
		extern void SetVertexTextures (IMTLTexture [] textures, NSRange range);

		[NoiOS, NoTV]
		[Deprecated (PlatformName.MacOSX, 10, 14, message: "Use 'MemoryBarrier (MTLBarrierScope, MTLRenderStages, MTLRenderStages)' instead.")]
		[NoMacCatalyst]
#if NET
		[Abstract]
#endif
		[Export ("textureBarrier")]
		extern void TextureBarrier ();

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("updateFence:afterStages:")]
		extern void Update (IMTLFence fence, MTLRenderStages stages);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("waitForFence:beforeStages:")]
		extern void Wait (IMTLFence fence, MTLRenderStages stages);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTessellationFactorBuffer:offset:instanceStride:")]
		extern void SetTessellationFactorBuffer ([NullAllowed] IMTLBuffer buffer, nuint offset, nuint instanceStride);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTessellationFactorScale:")]
		extern void SetTessellationFactorScale (float scale);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:")]
		extern void DrawPatches (nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, [NullAllowed] IMTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("drawPatches:patchIndexBuffer:patchIndexBufferOffset:indirectBuffer:indirectBufferOffset:")]
		extern void DrawPatches (nuint numberOfPatchControlPoints, [NullAllowed] IMTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, IMTLBuffer indirectBuffer, nuint indirectBufferOffset);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:")]
		extern void DrawIndexedPatches (nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, [NullAllowed] IMTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, IMTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("drawIndexedPatches:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:indirectBuffer:indirectBufferOffset:")]
		extern void DrawIndexedPatches (nuint numberOfPatchControlPoints, [NullAllowed] IMTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, IMTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, IMTLBuffer indirectBuffer, nuint indirectBufferOffset);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setViewports:count:")]
		extern void SetViewports (IntPtr viewports, nuint count);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setScissorRects:count:")]
		extern void SetScissorRects (IntPtr scissorRects, nuint count);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setColorStoreActionOptions:atIndex:")]
		extern void SetColorStoreActionOptions (MTLStoreActionOptions storeActionOptions, nuint colorAttachmentIndex);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setDepthStoreActionOptions:")]
		extern void SetDepthStoreActionOptions (MTLStoreActionOptions storeActionOptions);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setStencilStoreActionOptions:")]
		extern void SetStencilStoreActionOptions (MTLStoreActionOptions storeActionOptions);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useResource:usage:")]
		extern void UseResource (IMTLResource resource, MTLResourceUsage usage);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useResources:count:usage:")]
		extern void UseResources (IMTLResource [] resources, nuint count, MTLResourceUsage usage);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useHeap:")]
		extern void UseHeap (IMTLHeap heap);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("useHeaps:count:")]
		extern void UseHeaps (IMTLHeap [] heaps, nuint count);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("executeCommandsInBuffer:withRange:")]
		extern void ExecuteCommands (IMTLIndirectCommandBuffer indirectCommandBuffer, NSRange executionRange);

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("executeCommandsInBuffer:indirectBuffer:indirectBufferOffset:")]
		extern void ExecuteCommands (IMTLIndirectCommandBuffer indirectCommandbuffer, IMTLBuffer indirectRangeBuffer, nuint indirectBufferOffset);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[iOS (16, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Export ("memoryBarrierWithScope:afterStages:beforeStages:")]
		extern void MemoryBarrier (MTLBarrierScope scope, MTLRenderStages after, MTLRenderStages before);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[iOS (16, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Export ("memoryBarrierWithResources:count:afterStages:beforeStages:")]
		extern void MemoryBarrier (IMTLResource [] resources, nuint count, MTLRenderStages after, MTLRenderStages before);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("tileWidth")]
		extern nuint TileWidth { get; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("tileHeight")]
		extern nuint TileHeight { get; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileBytes:length:atIndex:")]
		extern void SetTileBytes (IntPtr /* void* */ bytes, nuint length, nuint index);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileBuffer:offset:atIndex:")]
		extern void SetTileBuffer ([NullAllowed] IMTLBuffer buffer, nuint offset, nuint index);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileBufferOffset:atIndex:")]
		extern void SetTileBufferOffset (nuint offset, nuint index);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileBuffers:offsets:withRange:")]
		extern void SetTileBuffers (IMTLBuffer [] buffers, IntPtr offsets, NSRange range);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileTexture:atIndex:")]
		extern void SetTileTexture ([NullAllowed] IMTLTexture texture, nuint index);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileTextures:withRange:")]
		extern void SetTileTextures (IMTLTexture [] textures, NSRange range);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileSamplerState:atIndex:")]
		extern void SetTileSamplerState ([NullAllowed] IMTLSamplerState sampler, nuint index);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileSamplerStates:withRange:")]
		extern void SetTileSamplerStates (IMTLSamplerState [] samplers, NSRange range);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileSamplerState:lodMinClamp:lodMaxClamp:atIndex:")]
		extern void SetTileSamplerState ([NullAllowed] IMTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setTileSamplerStates:lodMinClamps:lodMaxClamps:withRange:")]
		extern void SetTileSamplerStates (IMTLSamplerState [] samplers, IntPtr /* float[] */ lodMinClamps, IntPtr /* float[] */ lodMaxClamps, NSRange range);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("dispatchThreadsPerTile:")]
		extern 	void DispatchThreadsPerTile (MTLSize threadsPerTile);

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setThreadgroupMemoryLength:offset:atIndex:")]
		extern void SetThreadgroupMemoryLength (nuint length, nuint offset, nuint index);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[MacCatalyst (13, 4), TV (16, 0), iOS (13, 0)]
		[Export ("setVertexAmplificationCount:viewMappings:")]
		extern void SetVertexAmplificationCount (nuint count, MTLVertexAmplificationViewMapping viewMappings);

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("useResource:usage:stages:")]
		extern void UseResource (IMTLResource resource, MTLResourceUsage usage, MTLRenderStages stages);

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("useResources:count:usage:stages:")]
		extern void UseResources (IMTLResource [] resources, nuint count, MTLResourceUsage usage, MTLRenderStages stages);

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("useHeap:stages:")]
		extern void UseHeap (IMTLHeap heap, MTLRenderStages stages);

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("useHeaps:count:stages:")]
		extern void UseHeaps (IMTLHeap [] heaps, nuint count, MTLRenderStages stages);

#if NET
		[Abstract]
#endif
		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("sampleCountersInBuffer:atSampleIndex:withBarrier:")]
#if NET
		extern void SampleCounters (IMTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#else
		void SampleCounters (MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#endif

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setVertexVisibleFunctionTable:atBufferIndex:")]
		extern void SetVertexVisibleFunctionTable ([NullAllowed] IMTLVisibleFunctionTable functionTable, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setVertexVisibleFunctionTables:withBufferRange:")]
		extern void SetVertexVisibleFunctionTables (IMTLVisibleFunctionTable [] functionTables, NSRange range);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setVertexIntersectionFunctionTable:atBufferIndex:")]
		extern void SetVertexIntersectionFunctionTable ([NullAllowed] IMTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setVertexIntersectionFunctionTables:withBufferRange:")]
		extern void SetVertexIntersectionFunctionTables (IMTLIntersectionFunctionTable [] intersectionFunctionTable, NSRange range);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setVertexAccelerationStructure:atBufferIndex:")]
		extern void SetVertexAccelerationStructure ([NullAllowed] IMTLAccelerationStructure accelerationStructure, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setFragmentAccelerationStructure:atBufferIndex:")]
		extern void SetFragmentAccelerationStructure ([NullAllowed] IMTLAccelerationStructure accelerationStructure, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setFragmentIntersectionFunctionTable:atBufferIndex:")]
		extern void SetFragmentIntersectionFunctionTable ([NullAllowed] IMTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setFragmentIntersectionFunctionTables:withBufferRange:")]
		extern void SetFragmentIntersectionFunctionTables (IMTLIntersectionFunctionTable [] intersectionFunctionTable, NSRange range);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setFragmentVisibleFunctionTable:atBufferIndex:")]
		extern void SetFragmentVisibleFunctionTable ([NullAllowed] IMTLVisibleFunctionTable functionTable, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setFragmentVisibleFunctionTables:withBufferRange:")]
		extern void SetFragmentVisibleFunctionTables (IMTLVisibleFunctionTable [] functionTables, NSRange range);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setTileAccelerationStructure:atBufferIndex:")]
		extern void SetTileAccelerationStructure ([NullAllowed] IMTLAccelerationStructure accelerationStructure, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setTileIntersectionFunctionTable:atBufferIndex:")]
		extern void SetTileIntersectionFunctionTable ([NullAllowed] IMTLIntersectionFunctionTable intersectionFunctionTable, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setTileIntersectionFunctionTables:withBufferRange:")]
		extern void SetTileIntersectionFunctionTables (IMTLIntersectionFunctionTable [] intersectionFunctionTable, NSRange range);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setTileVisibleFunctionTable:atBufferIndex:")]
		extern void SetTileVisibleFunctionTable ([NullAllowed] IMTLVisibleFunctionTable functionTable, nuint bufferIndex);

		[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setTileVisibleFunctionTables:withBufferRange:")]
		extern void SetTileVisibleFunctionTables (IMTLVisibleFunctionTable [] functionTables, NSRange range);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setVertexBuffer:offset:attributeStride:atIndex:")]
		extern void SetVertexBuffer ([NullAllowed] IMTLBuffer buffer, nuint offset, nuint stride, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setVertexBuffers:offsets:attributeStrides:withRange:")]
		extern 	void SetVertexBuffers (IntPtr buffers, IntPtr offsets, IntPtr strides, NSRange range);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setVertexBufferOffset:attributeStride:atIndex:")]
		extern void SetVertexBufferOffset (nuint offset, nuint stride, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setVertexBytes:length:attributeStride:atIndex:")]
		extern void SetVertexBytes (IntPtr bytes, nuint length, nuint stride, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:")]
		extern void DrawMeshThreadgroups (MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("drawMeshThreadgroupsWithIndirectBuffer:indirectBufferOffset:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:")]
		extern void DrawMeshThreadgroups (IMTLBuffer indirectBuffer, nuint indirectBufferOffset, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:")]
		extern void DrawMeshThreads (MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshBufferOffset:atIndex:")]
		extern void SetMeshBufferOffset (nuint offset, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshBuffers:offsets:withRange:")]
		extern void SetMeshBuffers (IntPtr buffers, IntPtr offsets, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshTexture:atIndex:")]
		extern void SetMeshTexture ([NullAllowed] IMTLTexture texture, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshTextures:withRange:")]
		extern void SetMeshTextures (IntPtr textures, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshSamplerState:atIndex:")]
		extern void SetMeshSamplerState ([NullAllowed] IMTLSamplerState sampler, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshSamplerStates:withRange:")]
		extern void SetMeshSamplerStates (IntPtr samplers, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshSamplerState:lodMinClamp:lodMaxClamp:atIndex:")]
		extern void SetMeshSamplerState ([NullAllowed] IMTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshSamplerStates:lodMinClamps:lodMaxClamps:withRange:")]
		extern void SetMeshSamplerStates (IntPtr samplers, IntPtr lodMinClamps, IntPtr lodMaxClamps, NSRange range);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectBuffer:offset:atIndex:")]
		extern void SetObjectBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectBufferOffset:atIndex:")]
		extern void SetObjectBufferOffset (nuint offset, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectBuffers:offsets:withRange:")]
		extern void SetObjectBuffers (IntPtr buffers, IntPtr offsets, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectBytes:length:atIndex:")]
		extern void SetObjectBytes (IntPtr bytes, nuint length, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshBuffer:offset:atIndex:")]
		extern void SetMeshBuffer ([NullAllowed] IMTLBuffer buffer, nuint offset, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshBytes:length:atIndex:")]
		extern void SetMeshBytes (IntPtr bytes, nuint length, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectSamplerState:atIndex:")]
		extern void SetObjectSamplerState ([NullAllowed] IMTLSamplerState sampler, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectSamplerState:lodMinClamp:lodMaxClamp:atIndex:")]
		extern void SetObjectSamplerState ([NullAllowed] IMTLSamplerState sampler, float lodMinClamp, float lodMaxClamp, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectSamplerStates:lodMinClamps:lodMaxClamps:withRange:")]
		extern void SetObjectSamplerStates (IntPtr samplers, IntPtr lodMinClamps, IntPtr lodMaxClamps, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectSamplerStates:withRange:")]
		extern void SetObjectSamplerStates (IntPtr samplers, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectTexture:atIndex:")]
		extern void SetObjectTexture ([NullAllowed] IMTLTexture texture, nuint index);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectTextures:withRange:")]
		extern void SetObjectTextures (IntPtr textures, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectThreadgroupMemoryLength:atIndex:")]
		extern void SetObjectThreadgroupMemoryLength (nuint length, nuint index);
	}

	/// <summary>Configures a color attachment associated with a rendering pipeline.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPipelineColorAttachmentDescriptor_Ref/index.html">Apple documentation for <c>MTLRenderPipelineColorAttachmentDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLRenderPipelineColorAttachmentDescriptor : NSCopying {

		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		public extern MTLPixelFormat PixelFormat { get; set; }

		[Export ("blendingEnabled")]
		public extern bool BlendingEnabled { [Bind ("isBlendingEnabled")] get; set; }

		[Export ("sourceRGBBlendFactor", ArgumentSemantic.Assign)]
		public extern MTLBlendFactor SourceRgbBlendFactor { get; set; }

		[Export ("destinationRGBBlendFactor", ArgumentSemantic.Assign)]
		public extern MTLBlendFactor DestinationRgbBlendFactor { get; set; }

		[Export ("rgbBlendOperation", ArgumentSemantic.Assign)]
		public extern MTLBlendOperation RgbBlendOperation { get; set; }

		[Export ("sourceAlphaBlendFactor", ArgumentSemantic.Assign)]
		public extern MTLBlendFactor SourceAlphaBlendFactor { get; set; }

		[Export ("destinationAlphaBlendFactor", ArgumentSemantic.Assign)]
		public extern MTLBlendFactor DestinationAlphaBlendFactor { get; set; }

		[Export ("alphaBlendOperation", ArgumentSemantic.Assign)]
		public extern MTLBlendOperation AlphaBlendOperation { get; set; }

		[Export ("writeMask", ArgumentSemantic.Assign)]
		public extern MTLColorWriteMask WriteMask { get; set; }
	}

	/// <summary>The arguments (see <see cref="T:Metal.MTLArgument" />) of a vertex or fragment function within a <see cref="T:Metal.IMTLRenderPipelineState" />.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPipelineReflection_Ref/index.html">Apple documentation for <c>MTLRenderPipelineReflection</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLRenderPipelineReflection {

		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[Export ("vertexArguments")]
		[NullAllowed]
#if NET
		extern MTLArgument [] VertexArguments { get; }
#else
		NSObject [] VertexArguments { get; }
#endif


		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[Export ("fragmentArguments")]
		[NullAllowed]
#if NET
		extern MTLArgument [] FragmentArguments { get; }
#else
		NSObject [] FragmentArguments { get; }
#endif

		[Deprecated (PlatformName.MacCatalyst, 16, 0)]
		[TV (14, 5)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("tileArguments")]
		extern MTLArgument [] TileArguments { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("vertexBindings")]
		extern IMTLBinding [] VertexBindings { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("fragmentBindings")]
		extern IMTLBinding [] FragmentBindings { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("tileBindings")]
		extern IMTLBinding [] TileBindings { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("objectBindings")]
		extern IMTLBinding [] ObjectBindings { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("meshBindings")]
		extern IMTLBinding [] MeshBindings { get; }
	}

	/// <summary>Configures a render target of a framebuffer.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPassAttachmentDescriptor_Ref/index.html">Apple documentation for <c>MTLRenderPassAttachmentDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLRenderPassAttachmentDescriptor : NSCopying {

		[NullAllowed] // by default this property is null
		[Export ("texture", ArgumentSemantic.Retain)]
		public extern IMTLTexture? Texture { get; set; }

		[Export ("level")]
		public extern nuint Level { get; set; }

		[Export ("slice")]
		public extern nuint Slice { get; set; }

		[Export ("depthPlane")]
		public extern nuint DepthPlane { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("resolveTexture", ArgumentSemantic.Retain)]
		public extern IMTLTexture? ResolveTexture { get; set; }

		[Export ("resolveLevel")]
		public extern nuint ResolveLevel { get; set; }

		[Export ("resolveSlice")]
		public extern nuint ResolveSlice { get; set; }

		[Export ("resolveDepthPlane")]
		public extern nuint ResolveDepthPlane { get; set; }

		[Export ("loadAction")]
		public extern MTLLoadAction LoadAction { get; set; }

		[Export ("storeAction")]
		public extern MTLStoreAction StoreAction { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("storeActionOptions", ArgumentSemantic.Assign)]
		public extern MTLStoreActionOptions StoreActionOptions { get; set; }
	}

	/// <summary>A <see cref="T:Metal.MTLRenderPassAttachmentDescriptor" /> that holds the clear color for the rendering pass.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPassColorAttachmentDescriptor_Ref/index.html">Apple documentation for <c>MTLRenderPassColorAttachmentDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (MTLRenderPassAttachmentDescriptor))]
	public partial class MTLRenderPassColorAttachmentDescriptor: MTLRenderPassAttachmentDescriptor {
		[Export ("clearColor")]
		public extern MTLClearColor ClearColor { get; set; }
	}

	/// <summary>A <see cref="T:Metal.MTLRenderPassAttachmentDescriptor" /> that holds the clear depth for a rendering pass.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPassDepthAttachmentDescriptor_Ref/index.html">Apple documentation for <c>MTLRenderPassDepthAttachmentDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (MTLRenderPassAttachmentDescriptor))]
	public partial class MTLRenderPassDepthAttachmentDescriptor: MTLRenderPassAttachmentDescriptor {

		[Export ("clearDepth")]
		public extern double ClearDepth { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("depthResolveFilter")]
		public extern MTLMultisampleDepthResolveFilter DepthResolveFilter { get; set; }
	}

	/// <summary>A <see cref="T:Metal.MTLRenderPassAttachmentDescriptor" /> that holds the clear stencil for a rendering pass.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/help/MTLRenderPassStencilAttachmentDescriptor_Ref/index.html">Apple documentation for <c>MTLRenderPassStencilAttachmentDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (MTLRenderPassAttachmentDescriptor))]
	public partial class MTLRenderPassStencilAttachmentDescriptor: MTLRenderPassAttachmentDescriptor {

		[Export ("clearStencil")]
		public extern uint ClearStencil { get; set; } /* uint32_t */

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("stencilResolveFilter", ArgumentSemantic.Assign)]
		public extern MTLMultisampleStencilResolveFilter StencilResolveFilter { get; set; }
	}

	/// <summary>Holds an array of <see cref="T:Metal.MTLRenderPassColorAttachmentDescriptor" /> objects.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPassColorAttachmentDescriptorArray_Ref/index.html">Apple documentation for <c>MTLRenderPassColorAttachmentDescriptorArray</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLRenderPassColorAttachmentDescriptorArray: NSObject {
		[Export ("objectAtIndexedSubscript:"), Internal]
		public extern MTLRenderPassColorAttachmentDescriptor ObjectAtIndexedSubscript (nuint attachmentIndex);

		[Export ("setObject:atIndexedSubscript:"), Internal]
		public extern void SetObject ([NullAllowed] MTLRenderPassColorAttachmentDescriptor attachment, nuint attachmentIndex);
	}

	/// <summary>Defines the rendering target for pixels generated by a rendering pass.</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLRenderPassDescriptor_Ref/index.html">Apple documentation for <c>MTLRenderPassDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLRenderPassDescriptor : NSCopying {

		[Export ("colorAttachments")]
		public extern MTLRenderPassColorAttachmentDescriptorArray ColorAttachments { get; }

		[Export ("depthAttachment", ArgumentSemantic.Copy)]
		[NullAllowed]
		public extern MTLRenderPassDepthAttachmentDescriptor? DepthAttachment { get; set; }

		[Export ("stencilAttachment", ArgumentSemantic.Copy)]
		[NullAllowed]
		public extern MTLRenderPassStencilAttachmentDescriptor? StencilAttachment { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("visibilityResultBuffer", ArgumentSemantic.Retain)]
		public extern IMTLBuffer? VisibilityResultBuffer { get; set; }

		[Static, Export ("renderPassDescriptor")]
		[Autorelease]
		public static extern MTLRenderPassDescriptor CreateRenderPassDescriptor ();

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("renderTargetArrayLength")]
		public extern nuint RenderTargetArrayLength { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("setSamplePositions:count:")]
		public extern unsafe void SetSamplePositions ([NullAllowed] IntPtr positions, nuint count);

		[MacCatalyst (13, 1)]
		[Export ("getSamplePositions:count:")]
		public extern nuint GetSamplePositions ([NullAllowed] IntPtr positions, nuint count);

		[TV (14, 5)]
		[MacCatalyst (14, 0)]
		[Export ("imageblockSampleLength")]
		public extern nuint ImageblockSampleLength { get; set; }

		[TV (14, 5)]
		[MacCatalyst (14, 0)]
		[Export ("threadgroupMemoryLength")]
		public extern nuint ThreadgroupMemoryLength { get; set; }

		[TV (14, 5)]
		[MacCatalyst (14, 0)]
		[Export ("tileWidth")]
		public extern nuint TileWidth { get; set; }

		[TV (14, 5)]
		[MacCatalyst (14, 0)]
		[Export ("tileHeight")]
		public extern nuint TileHeight { get; set; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("defaultRasterSampleCount")]
		public extern nuint DefaultRasterSampleCount { get; set; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("renderTargetWidth")]
		public extern nuint RenderTargetWidth { get; set; }

		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("renderTargetHeight")]
		public extern nuint RenderTargetHeight { get; set; }

		/* Selectors reported missing by instrospection: https://github.com/xamarin/maccore/issues/1978
				[NoMac, NoTV, iOS (13, 0)]
				[NoMacCatalyst]
				[Export ("maxVertexAmplificationCount")]
				nuint MaxVertexAmplificationCount { get; set; }
		*/

		[Introduced (PlatformName.MacCatalyst, 13, 4)]
		[TV (17, 0), iOS (13, 0)]
		[NullAllowed, Export ("rasterizationRateMap", ArgumentSemantic.Strong)]
		extern IMTLRasterizationRateMap? RasterizationRateMap { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("sampleBufferAttachments")]
		public extern MTLRenderPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments { get; }
	}


	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	// note: type works only on devices, symbol is missing on the simulator
	partial class MTLHeapDescriptor : NSCopying {
		[Export ("size")]
		extern nuint Size { get; set; }

		[Export ("storageMode", ArgumentSemantic.Assign)]
		extern MTLStorageMode StorageMode { get; set; }

		[Export ("cpuCacheMode", ArgumentSemantic.Assign)]
		extern MTLCpuCacheMode CpuCacheMode { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0), TV (15, 0)]
		[Export ("hazardTrackingMode", ArgumentSemantic.Assign)]
		extern MTLHazardTrackingMode HazardTrackingMode { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0), TV (15, 0)]
		[Export ("resourceOptions", ArgumentSemantic.Assign)]
		extern MTLResourceOptions ResourceOptions { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0), TV (15, 0)]
		[Export ("type", ArgumentSemantic.Assign)]
		extern MTLHeapType Type { get; set; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("sparsePageSize", ArgumentSemantic.Assign)]
		extern MTLSparsePageSize SparsePageSize { get; set; }

	}

	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	class MTLHeap : MTLAllocation {
		[Abstract]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[Abstract]
		[Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract]
		[Export ("storageMode")]
		extern MTLStorageMode StorageMode { get; }

		[Abstract]
		[Export ("cpuCacheMode")]
		extern MTLCpuCacheMode CpuCacheMode { get; }

		[Abstract]
		[Export ("size")]
		extern nuint Size { get; }

		[Abstract]
		[Export ("usedSize")]
		extern nuint UsedSize { get; }

		[Abstract]
		[Export ("maxAvailableSizeWithAlignment:")]
		extern nuint GetMaxAvailableSize (nuint alignment);

		[Abstract]
		[Export ("newBufferWithLength:options:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLBuffer CreateBuffer (nuint length, MTLResourceOptions options);

		[Abstract]
		[Export ("newTextureWithDescriptor:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLTexture CreateTexture (MTLTextureDescriptor desc);

		[Abstract]
		[Export ("setPurgeableState:")]
		extern MTLPurgeableState SetPurgeableState (MTLPurgeableState state);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("currentAllocatedSize")]
		extern nuint CurrentAllocatedSize { get; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("hazardTrackingMode")]
		extern MTLHazardTrackingMode HazardTrackingMode { get; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("resourceOptions")]
		extern MTLResourceOptions ResourceOptions { get; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("type")]
		extern MTLHeapType Type { get; }

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newBufferWithLength:options:offset:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLBuffer CreateBuffer (nuint length, MTLResourceOptions options, nuint offset);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("newTextureWithDescriptor:offset:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLTexture CreateTexture (MTLTextureDescriptor descriptor, nuint offset);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("newAccelerationStructureWithSize:")]
		[return: NullAllowed, Release]
		extern IMTLAccelerationStructure CreateAccelerationStructure (nuint size);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("newAccelerationStructureWithDescriptor:")]
		[return: NullAllowed, Release]
		extern IMTLAccelerationStructure CreateAccelerationStructure (MTLAccelerationStructureDescriptor descriptor);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("newAccelerationStructureWithSize:offset:")]
		[return: NullAllowed, Release]
		extern IMTLAccelerationStructure CreateAccelerationStructure (nuint size, nuint offset);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Export ("newAccelerationStructureWithDescriptor:offset:")]
		[return: NullAllowed, Release]
		extern IMTLAccelerationStructure? CreateAccelerationStructure (MTLAccelerationStructureDescriptor descriptor, nuint offset);
	}

	interface IMTLResource { }
	public interface IMTLHeap: INativeObject { }
	/// <summary>System protocol for for allocated segments of GPU memory.</summary>
	/// <summary>Extension methods to the <see cref="T:Metal.IMTLResource" /> interface to support all the methods from the <see cref="T:Metal.IMTLResource" /> protocol.</summary>
	///     <remarks>
	///       <para>The extension methods for <see cref="T:Metal.IMTLResource" /> allow developers to treat instances of the interface as having all the optional methods of the original <see cref="T:Metal.IMTLResource" /> protocol.   Since the interface only contains the required members, these extension methods allow developers to call the optional members of the protocol.</para>
	///     </remarks>
	[MacCatalyst (13, 1)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	partial class MTLResource : MTLAllocation {

		[Abstract, Export ("label")]
		extern string Label { get; set; }

		[Abstract, Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract, Export ("cpuCacheMode")]
		extern MTLCpuCacheMode CpuCacheMode { get; }

#if NET
		[Abstract] // new required member, but that breaks our binary compat, so we can't do that in our existing code.
#endif
		[MacCatalyst (13, 1)]
		[Export ("storageMode")]
		extern MTLStorageMode StorageMode { get; }

		[Abstract, Export ("setPurgeableState:")]
		extern MTLPurgeableState SetPurgeableState (MTLPurgeableState state);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[NullAllowed, Export ("heap")]
		extern IMTLHeap Heap { get; }

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("makeAliasable")]
		extern void MakeAliasable ();

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("isAliasable")]
		extern bool IsAliasable { get; }

		[TV (17, 4), Mac (14, 4), iOS (17, 4), MacCatalyst (17, 4)]
#if NET
		[Abstract]
#endif
		[Export ("setOwnerWithIdentity:")]
		extern int SetOwnerWithIdentity (uint taskIdToken);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("allocatedSize")]
		extern new nuint AllocatedSize { get; }

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("resourceOptions")]
		extern MTLResourceOptions ResourceOptions { get; }

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("heapOffset")]
		extern nuint HeapOffset { get; }

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("hazardTrackingMode")]
		extern MTLHazardTrackingMode HazardTrackingMode { get; }
	}

	/// <summary>Describes the compute state used during a compute operation pass. (See also <see cref="T:Metal.IMTLComputePipelineState" />.)</summary>
	///     
	///     <related type="externalDocumentation" href="https://developer.apple.com/library/ios/documentation/Metal/Reference/MTLComputePipelineDescriptor_ClassReference/index.html">Apple documentation for <c>MTLComputePipelineDescriptor</c></related>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLComputePipelineDescriptor : NSCopying {

		[Export ("label")]
		[NullAllowed]
		extern string Label { get; set; }

		[Export ("computeFunction", ArgumentSemantic.Strong)]
		[NullAllowed]
		extern IMTLFunction ComputeFunction { get; set; }

		[Export ("threadGroupSizeIsMultipleOfThreadExecutionWidth")]
		extern bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth { get; set; }

		[Export ("reset")]
		extern void Reset ();

		[MacCatalyst (13, 1)]
		[Export ("maxTotalThreadsPerThreadgroup")]
		extern nuint MaxTotalThreadsPerThreadgroup { get; set; }

		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("stageInputDescriptor", ArgumentSemantic.Copy)]
		extern MTLStageInputOutputDescriptor StageInputDescriptor { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("buffers")]
		extern MTLPipelineBufferDescriptorArray Buffers { get; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (14, 0)]
		[Export ("supportIndirectCommandBuffers")]
		extern bool SupportIndirectCommandBuffers { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[Deprecated (PlatformName.MacCatalyst, 15, 0, message: "Use 'PreloadedLibraries' instead.")]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("insertLibraries", ArgumentSemantic.Copy)]
		extern IMTLDynamicLibrary [] InsertLibraries { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("binaryArchives", ArgumentSemantic.Copy)]
		extern IMTLBinaryArchive [] BinaryArchives { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("linkedFunctions", ArgumentSemantic.Copy)]
		extern MTLLinkedFunctions LinkedFunctions { get; set; }

		[iOS (14, 0), TV (17, 0)]
		[MacCatalyst (14, 0)]
		[Export ("supportAddingBinaryFunctions")]
		extern bool SupportAddingBinaryFunctions { get; set; }

		[iOS (14, 0), TV (17, 0)]
		[MacCatalyst (14, 0)]
		[Export ("maxCallStackDepth")]
		extern nuint MaxCallStackDepth { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("preloadedLibraries", ArgumentSemantic.Copy)]
		extern IMTLDynamicLibrary [] PreloadedLibraries { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("shaderValidation")]
		extern MTLShaderValidation ShaderValidation { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class MTLStageInputOutputDescriptor : NSCopying {
		[Static]
		[Export ("stageInputOutputDescriptor")]
		public static extern MTLStageInputOutputDescriptor Create ();

		[Export ("layouts")]
		public extern MTLBufferLayoutDescriptorArray Layouts { get; }

		[Export ("attributes")]
		public extern MTLAttributeDescriptorArray Attributes { get; }

		[Export ("indexType", ArgumentSemantic.Assign)]
		public extern MTLIndexType IndexType { get; set; }

		[Export ("indexBufferIndex")]
		public extern nuint IndexBufferIndex { get; set; }

		[Export ("reset")]
		public extern void Reset ();
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public class MTLType: NSObject {
		[Export ("dataType")]
		public extern MTLDataType DataType { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (MTLType))]
	class MTLPointerType: MTLType {
		[Export ("elementType")]
		extern MTLDataType ElementType { get; }

		[Export ("access")]
		extern MTLArgumentAccess Access { get; }

		[Export ("alignment")]
		extern nuint Alignment { get; }

		[Export ("dataSize")]
		extern nuint DataSize { get; }

		[Export ("elementIsArgumentBuffer")]
		extern bool ElementIsArgumentBuffer { get; }

		[NullAllowed, Export ("elementStructType")]
		extern MTLStructType ElementStructType { get; }

		[NullAllowed, Export ("elementArrayType")]
		extern MTLArrayType ElementArrayType { get; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (MTLType))]
	class MTLTextureReferenceType: MTLType {
		[Export ("textureDataType")]
		extern MTLDataType TextureDataType { get; }

		[Export ("textureType")]
		extern MTLTextureType TextureType { get; }

		[Export ("access")]
		extern MTLArgumentAccess Access { get; }

		[Export ("isDepthTexture")]
		extern bool IsDepthTexture { get; }
	}

	[MacCatalyst (13, 1)]
	interface IMTLCaptureScope { }

	/// <summary>Custom capture scope boundary for debugging from Xcode.</summary>
	[MacCatalyst (13, 1)]
#if NET
	[Protocol, Model]
#else
	[Protocol, Model (AutoGeneratedName = true)]
#endif
	[BaseType (typeof (NSObject))]
	class MTLCaptureScope: NSObject {
		[Abstract]
		[Export ("beginScope")]
		extern void BeginScope ();

		[Abstract]
		[Export ("endScope")]
		extern void EndScope ();

		[Abstract]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[Abstract]
		[Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract]
		[NullAllowed, Export ("commandQueue")]
		extern IMTLCommandQueue CommandQueue { get; }
	}


	/// <summary>Manages GPU captures for apps launched from Xcode.</summary>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	class MTLCaptureManager: NSObject {
		[Static]
		[Export ("sharedCaptureManager")]
		static extern MTLCaptureManager Shared { get; }

		[Export ("newCaptureScopeWithDevice:")]
		[return: Release]
		extern IMTLCaptureScope CreateNewCaptureScope (IMTLDevice device);

		[Export ("newCaptureScopeWithCommandQueue:")]
		[return: Release]
		extern IMTLCaptureScope CreateNewCaptureScope (IMTLCommandQueue commandQueue);


		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'StartCapture (MTLCaptureDescriptor, NSError)' instead.")]
		[Export ("startCaptureWithDevice:")]
		extern void StartCapture (IMTLDevice device);


		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'StartCapture (MTLCaptureDescriptor, NSError)' instead.")]
		[Export ("startCaptureWithCommandQueue:")]
		extern void StartCapture (IMTLCommandQueue commandQueue);


		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'StartCapture (MTLCaptureDescriptor, NSError)' instead.")]
		[Export ("startCaptureWithScope:")]
		extern void StartCapture (IMTLCaptureScope captureScope);

		[Export ("stopCapture")]
		extern void StopCapture ();

		[NullAllowed, Export ("defaultCaptureScope", ArgumentSemantic.Strong)]
		extern IMTLCaptureScope DefaultCaptureScope { get; set; }

		[Export ("isCapturing")]
		extern bool IsCapturing { get; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("supportsDestination:")]
		extern bool SupportsDestination (MTLCaptureDestination destination);

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("startCaptureWithDescriptor:error:")]
		extern bool StartCapture (MTLCaptureDescriptor descriptor, [NullAllowed] out NSError error);
	}

	/// <summary>Contains a mutability description for a buffer.</summary>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLPipelineBufferDescriptor : NSCopying {
		[Export ("mutability", ArgumentSemantic.Assign)]
		public extern MTLMutability Mutability { get; set; }
	}

	/// <summary>An array of buffer mutability descriptors.</summary>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	public partial class MTLPipelineBufferDescriptorArray: NSObject {
		[Internal]
		[Export ("objectAtIndexedSubscript:")]
		public extern MTLPipelineBufferDescriptor GetObject (nuint bufferIndex);

		[Internal]
		[Export ("setObject:atIndexedSubscript:")]
		public extern void SetObject ([NullAllowed] MTLPipelineBufferDescriptor buffer, nuint bufferIndex);
	}

	/// <summary>An description of an argument inside an argument buffer.</summary>
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLArgumentDescriptor : NSCopying {
		[Static]
		[Export ("argumentDescriptor")]
		extern static MTLArgumentDescriptor Create ();

		[Export ("dataType", ArgumentSemantic.Assign)]
		extern MTLDataType DataType { get; set; }

		[Export ("index")]
		extern nuint Index { get; set; }

		[Export ("arrayLength")]
		extern nuint ArrayLength { get; set; }

		[Export ("access", ArgumentSemantic.Assign)]
		extern MTLArgumentAccess Access { get; set; }

		[Export ("textureType", ArgumentSemantic.Assign)]
		extern MTLTextureType TextureType { get; set; }

		[Export ("constantBlockAlignment")]
		extern nuint ConstantBlockAlignment { get; set; }
	}

	public interface IMTLArgumentEncoder { }

	/// <summary>Encodes data into argument buffers.</summary>
	[MacCatalyst (13, 1)]
	[Protocol]
	class MTLArgumentEncoder {
		[Abstract]
		[Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[Abstract]
		[Export ("encodedLength")]
		extern nuint EncodedLength { get; }

		[Abstract]
		[Export ("alignment")]
		extern nuint Alignment { get; }

		[Abstract]
		[Export ("setArgumentBuffer:offset:")]
		extern void SetArgumentBuffer ([NullAllowed] IMTLBuffer argumentBuffer, nuint offset);

		[Abstract]
		[Export ("setArgumentBuffer:startOffset:arrayElement:")]
		extern void SetArgumentBuffer ([NullAllowed] IMTLBuffer argumentBuffer, nuint startOffset, nuint arrayElement);

		[Abstract]
		[Export ("setBuffer:offset:atIndex:")]
		extern void SetBuffer ([NullAllowed] IMTLBuffer buffer, nuint offset, nuint index);

#if NET
		[Abstract]
		[Export ("setBuffers:offsets:withRange:")]
		extern void SetBuffers (IntPtr buffers, IntPtr offsets, NSRange range);
#else
		[Abstract]
		[Export ("setBuffers:offsets:withRange:")]
		void SetBuffers (IMTLBuffer [] buffers, IntPtr offsets, NSRange range);
#endif

		[Abstract]
		[Export ("setTexture:atIndex:")]
		extern void SetTexture ([NullAllowed] IMTLTexture texture, nuint index);

		[Abstract]
		[Export ("setTextures:withRange:")]
		extern void SetTextures (IMTLTexture [] textures, NSRange range);

		[Abstract]
		[Export ("setSamplerState:atIndex:")]
		extern void SetSamplerState ([NullAllowed] IMTLSamplerState sampler, nuint index);

		[Abstract]
		[Export ("setSamplerStates:withRange:")]
		extern void SetSamplerStates (IMTLSamplerState [] samplers, NSRange range);

		[Abstract]
		[Export ("constantDataAtIndex:")]
		extern IntPtr GetConstantData (nuint index);

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setRenderPipelineState:atIndex:")]
		extern void SetRenderPipelineState ([NullAllowed] IMTLRenderPipelineState pipeline, nuint index);

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setRenderPipelineStates:withRange:")]
		extern void SetRenderPipelineStates (IMTLRenderPipelineState [] pipelines, NSRange range);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setIndirectCommandBuffer:atIndex:")]
		extern void SetIndirectCommandBuffer ([NullAllowed] IMTLIndirectCommandBuffer indirectCommandBuffer, nuint index);

		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setIndirectCommandBuffers:withRange:")]
		extern void SetIndirectCommandBuffers (IMTLIndirectCommandBuffer [] buffers, NSRange range);

#if MONOMAC || NET
		[Abstract]
#endif
		[Export ("newArgumentEncoderForBufferAtIndex:")]
		[return: NullAllowed]
		[return: Release]
		extern IMTLArgumentEncoder CreateArgumentEncoder (nuint index);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setComputePipelineState:atIndex:")]
		extern void SetComputePipelineState ([NullAllowed] IMTLComputePipelineState pipeline, nuint index);

		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
#if NET
		[Abstract]
#endif
		[Export ("setComputePipelineStates:withRange:")]
		extern void SetComputePipelineStates (IMTLComputePipelineState [] pipelines, NSRange range);

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setAccelerationStructure:atIndex:")]
		extern void SetAccelerationStructure ([NullAllowed] IMTLAccelerationStructure accelerationStructure, nuint index);

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setVisibleFunctionTable:atIndex:")]
		extern void SetVisibleFunctionTable ([NullAllowed] IMTLVisibleFunctionTable visibleFunctionTable, nuint index);

		[iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Abstract (GenerateExtensionMethod = true)]
		[Export ("setVisibleFunctionTables:withRange:")]
		extern void SetVisibleFunctionTables (IMTLVisibleFunctionTable [] visibleFunctionTables, NSRange range);

		[Abstract (GenerateExtensionMethod = true)]
		[Mac (11, 0), iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("setIntersectionFunctionTable:atIndex:")]
		extern void SetIntersectionFunctionTable ([NullAllowed] IMTLIntersectionFunctionTable intersectionFunctionTable, nuint index);

		[Abstract (GenerateExtensionMethod = true)]
		[Mac (11, 0), iOS (14, 0), TV (16, 0), MacCatalyst (14, 0)]
		[Export ("setIntersectionFunctionTables:withRange:")]
		extern void SetIntersectionFunctionTables (IMTLIntersectionFunctionTable [] intersectionFunctionTables, NSRange range);

	}

	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[TV (14, 5)]
	[BaseType (typeof (NSObject))]
	class MTLTileRenderPipelineColorAttachmentDescriptor : NSCopying {
		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		extern MTLPixelFormat PixelFormat { get; set; }
	}

	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[TV (14, 5)]
	[BaseType (typeof (NSObject))]
	class MTLTileRenderPipelineColorAttachmentDescriptorArray: NSObject {
		[Internal]
		[Export ("objectAtIndexedSubscript:")]
		extern MTLTileRenderPipelineColorAttachmentDescriptor GetObject (nuint attachmentIndex);

		[Internal]
		[Export ("setObject:atIndexedSubscript:")]
		extern void SetObject (MTLTileRenderPipelineColorAttachmentDescriptor attachment, nuint attachmentIndex);
	}

	interface IMTLBinaryArchive { }

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class MTLBinaryArchive {

		[Abstract]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[Abstract]
		[Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract]
		[Export ("addComputePipelineFunctionsWithDescriptor:error:")]
		extern bool AddComputePipelineFunctions (MTLComputePipelineDescriptor descriptor, [NullAllowed] out NSError error);

		[Abstract]
		[Export ("addRenderPipelineFunctionsWithDescriptor:error:")]
		extern bool AddRenderPipelineFunctions (MTLRenderPipelineDescriptor descriptor, [NullAllowed] out NSError error);

#if !TVOS || NET
		[Abstract]
#endif
		[TV (14, 5)]
		[MacCatalyst (14, 0)]
		[Export ("addTileRenderPipelineFunctionsWithDescriptor:error:")]
		extern bool AddTileRenderPipelineFunctions (MTLTileRenderPipelineDescriptor descriptor, [NullAllowed] out NSError error);

		[Abstract]
		[Export ("serializeToURL:error:")]
		extern bool Serialize (NSUrl url, [NullAllowed] out NSError error);

#if NET
		[Abstract]
#endif
		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("addFunctionWithDescriptor:library:error:")]
		extern bool AddFunctionWithDescriptor (MTLFunctionDescriptor descriptor, IMTLLibrary library, [NullAllowed] out NSError error);

#if NET
		[Abstract]
#endif
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("addMeshRenderPipelineFunctionsWithDescriptor:error:")]
		extern bool AddMeshRenderPipelineFunctions (MTLMeshRenderPipelineDescriptor descriptor, out NSError error);

#if NET
		[Abstract]
#endif
		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("addLibraryWithDescriptor:error:")]
		extern bool AddLibrary (MTLStitchedLibraryDescriptor descriptor, out NSError error);
	}


	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[TV (14, 5)]
	[BaseType (typeof (NSObject))]
	partial class MTLTileRenderPipelineDescriptor : NSCopying {
		[NullAllowed]
		[Export ("label")]
		extern string Label { get; set; }

		[Export ("tileFunction", ArgumentSemantic.Strong)]
		extern IMTLFunction TileFunction { get; set; }

		[Export ("rasterSampleCount")]
		extern nuint RasterSampleCount { get; set; }

		[Export ("colorAttachments")]
		extern MTLTileRenderPipelineColorAttachmentDescriptorArray ColorAttachments { get; }

		[Export ("threadgroupSizeMatchesTileSize")]
		extern bool ThreadgroupSizeMatchesTileSize { get; set; }

		[Export ("tileBuffers")]
		extern MTLPipelineBufferDescriptorArray TileBuffers { get; }

		[MacCatalyst (14, 0)]
		[Export ("maxTotalThreadsPerThreadgroup")]
		extern nuint MaxTotalThreadsPerThreadgroup { get; set; }

		[Export ("reset")]
		extern void Reset ();

		[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[NullAllowed, Export ("binaryArchives", ArgumentSemantic.Copy)]
		extern IMTLBinaryArchive [] BinaryArchives { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0), TV (17, 0)]
		[Export ("supportAddingBinaryFunctions")]
		extern bool SupportAddingBinaryFunctions { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("preloadedLibraries", ArgumentSemantic.Copy)]
		extern IMTLDynamicLibrary [] PreloadedLibraries { get; set; }

		[iOS (14, 0), MacCatalyst (15, 0), TV (17, 0)]
		[Export ("maxCallStackDepth")]
		extern nuint MaxCallStackDepth { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("linkedFunctions", ArgumentSemantic.Copy)]
		extern MTLLinkedFunctions LinkedFunctions { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("shaderValidation")]
		extern MTLShaderValidation ShaderValidation { get; set; }
	}

	interface IMTLEvent { }

	[MacCatalyst (13, 1)]
	[Protocol]
	class MTLEvent {
		[Abstract]
		[NullAllowed, Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	//[DesignatedDefaultCtor]
	class MTLSharedEventListener: NSObject {
		[Export ("initWithDispatchQueue:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (DispatchQueue dispatchQueue);

		[Export ("dispatchQueue")]
		extern DispatchQueue DispatchQueue { get; }
	}

	delegate void MTLSharedEventNotificationBlock (IMTLSharedEvent @event, ulong value);

	interface IMTLSharedEvent { }

	[MacCatalyst (13, 1)]
	[Protocol]
	class MTLSharedEvent : MTLEvent {
		[Abstract]
		[Export ("notifyListener:atValue:block:")]
		extern void NotifyListener (MTLSharedEventListener listener, ulong atValue, MTLSharedEventNotificationBlock block);

		[Abstract]
		[Export ("newSharedEventHandle")]
		[return: Release]
		extern MTLSharedEventHandle CreateSharedEventHandle ();

		[Abstract]
		[Export ("signaledValue")]
		extern ulong SignaledValue { get; set; }

		[Mac (14, 4), iOS (17, 4), TV (17, 4), MacCatalyst (17, 4)]
#if NET
		[Abstract]
#endif
		[Export ("waitUntilSignaledValue:timeoutMS:")]
		extern bool WaitUntilSignaledValue (ulong value, ulong milliseconds);
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLSharedEventHandle : NSCoding {
		[NullAllowed, Export ("label")]
		extern string Label { get; }
	}

	interface IMTLIndirectRenderCommand { }

	[MacCatalyst (13, 1)]
	[Protocol]
	class MTLIndirectRenderCommand {

#if MONOMAC && !NET
		[Abstract]
#endif
#if NET
		[Abstract]
#endif
		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("setRenderPipelineState:")]
		extern void SetRenderPipelineState (IMTLRenderPipelineState pipelineState);

		[Abstract]
		[Export ("setVertexBuffer:offset:atIndex:")]
		extern void SetVertexBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[Abstract]
		[Export ("setFragmentBuffer:offset:atIndex:")]
		extern void SetFragmentBuffer (IMTLBuffer buffer, nuint offset, nuint index);

#if !TVOS || NET
		[Abstract]
#endif
		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("drawPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:")]
		extern void DrawPatches (nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, [NullAllowed] IMTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, nuint instanceCount, nuint baseInstance, IMTLBuffer buffer, nuint offset, nuint instanceStride);

#if !TVOS || NET
		[Abstract]
#endif
		[TV (14, 5)]
		[MacCatalyst (13, 1)]
		[Export ("drawIndexedPatches:patchStart:patchCount:patchIndexBuffer:patchIndexBufferOffset:controlPointIndexBuffer:controlPointIndexBufferOffset:instanceCount:baseInstance:tessellationFactorBuffer:tessellationFactorBufferOffset:tessellationFactorBufferInstanceStride:")]
		extern void DrawIndexedPatches (nuint numberOfPatchControlPoints, nuint patchStart, nuint patchCount, [NullAllowed] IMTLBuffer patchIndexBuffer, nuint patchIndexBufferOffset, IMTLBuffer controlPointIndexBuffer, nuint controlPointIndexBufferOffset, nuint instanceCount, nuint baseInstance, IMTLBuffer buffer, nuint offset, nuint instanceStride);

		[Abstract]
		[Export ("drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:")]
		extern void DrawPrimitives (MTLPrimitiveType primitiveType, nuint vertexStart, nuint vertexCount, nuint instanceCount, nuint baseInstance);

		[Abstract]
		[Export ("drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:")]
		extern void DrawIndexedPrimitives (MTLPrimitiveType primitiveType, nuint indexCount, MTLIndexType indexType, IMTLBuffer indexBuffer, nuint indexBufferOffset, nuint instanceCount, nint baseVertex, nuint baseInstance);

		[Abstract]
		[Export ("reset")]
		extern void Reset ();

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setVertexBuffer:offset:attributeStride:atIndex:")]
		extern void SetVertexBuffer (IMTLBuffer buffer, nuint offset, nuint stride, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (18, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectThreadgroupMemoryLength:atIndex:")]
		extern void SetObjectThreadgroupMemoryLength (nuint length, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (18, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setObjectBuffer:offset:atIndex:")]
		extern void SetObjectBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (18, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setMeshBuffer:offset:atIndex:")]
		extern void SetMeshBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[Mac (14, 0), iOS (17, 0), TV (18, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("drawMeshThreadgroups:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:")]
		extern void DrawMeshThreadgroups (MTLSize threadgroupsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup);

		[Mac (14, 0), iOS (17, 0), TV (18, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("drawMeshThreads:threadsPerObjectThreadgroup:threadsPerMeshThreadgroup:")]
		extern void DrawMeshThreads (MTLSize threadsPerGrid, MTLSize threadsPerObjectThreadgroup, MTLSize threadsPerMeshThreadgroup);

		[Mac (14, 0), iOS (17, 0), TV (18, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setBarrier")]
		extern void SetBarrier ();

		[Mac (14, 0), iOS (17, 0), TV (18, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("clearBarrier")]
		extern void ClearBarrier ();
	}

	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLIndirectCommandBufferDescriptor : NSCopying {
		[Export ("commandTypes", ArgumentSemantic.Assign)]
		extern MTLIndirectCommandType CommandTypes { get; set; }

		[iOS (13, 0), TV (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("inheritPipelineState")]
		extern bool InheritPipelineState { get; set; }

		[Export ("inheritBuffers")]
		extern bool InheritBuffers { get; set; }

		[Export ("maxVertexBufferBindCount")]
		extern nuint MaxVertexBufferBindCount { get; set; }

		[Export ("maxFragmentBufferBindCount")]
		extern nuint MaxFragmentBufferBindCount { get; set; }

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
		[Export ("maxKernelBufferBindCount")]
		extern nuint MaxKernelBufferBindCount { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("maxKernelThreadgroupMemoryBindCount")]
		extern nuint MaxKernelThreadgroupMemoryBindCount { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("maxObjectBufferBindCount")]
		extern nuint MaxObjectBufferBindCount { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("maxMeshBufferBindCount")]
		extern nuint MaxMeshBufferBindCount { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("maxObjectThreadgroupMemoryBindCount")]
		extern nuint MaxObjectThreadgroupMemoryBindCount { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("supportDynamicAttributeStride")]
		extern bool SupportDynamicAttributeStride { get; set; }

		[Mac (13, 0), iOS (16, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("supportRayTracing")]
		extern bool SupportRayTracing { get; set; }

	}

	interface IMTLIndirectCommandBuffer { }

	[MacCatalyst (13, 1)]
	[Protocol]
	class MTLIndirectCommandBuffer : MTLResource {
		[Abstract]
		[Export ("size")]
		extern nuint Size { get; }

		[Abstract]
		[Export ("resetWithRange:")]
		extern void Reset (NSRange range);

		[Abstract]
		[Export ("indirectRenderCommandAtIndex:")]
		extern IMTLIndirectRenderCommand GetCommand (nuint commandIndex);

#if NET
		[Abstract]
#endif
		[TV (13, 0), iOS (13, 0)]
		[MacCatalyst (13, 1)]
		[Export ("indirectComputeCommandAtIndex:")]
		extern IMTLIndirectComputeCommand GetIndirectComputeCommand (nuint commandIndex);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("gpuResourceID")]
		extern MTLResourceId GpuResourceID { get; }
	}

	[iOS (13, 0), TV (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	//[DisableDefaultCtor]
	public partial interface IMTLDevice  {
		[Export ("device")]
		public extern IMTLDevice Device { get; }

		[NullAllowed, Export ("label")]
		public extern string Label { get; }
	}

	[Introduced (PlatformName.MacCatalyst, 13, 4)]
	[TV (16, 0), iOS (13, 0)]
	[BaseType (typeof (NSObject))]
	class MTLRasterizationRateSampleArray {
		[Export ("objectAtIndexedSubscript:")]
		extern NSNumber GetObject (nuint index);

		[Export ("setObject:atIndexedSubscript:")]
		extern void SetObject (NSNumber value, nuint index);
	}

	[Introduced (PlatformName.MacCatalyst, 13, 4)]
	[TV (16, 0), iOS (13, 0)]
	[BaseType (typeof (NSObject))]
	class MTLRasterizationRateMapDescriptor : NSCopying {
		[Static]
		[Export ("rasterizationRateMapDescriptorWithScreenSize:")]
		extern static  MTLRasterizationRateMapDescriptor Create (MTLSize screenSize);

		[Static]
		[Export ("rasterizationRateMapDescriptorWithScreenSize:layer:")]
		extern static MTLRasterizationRateMapDescriptor Create (MTLSize screenSize, MTLRasterizationRateLayerDescriptor layer);

		[Static]
		[Export ("rasterizationRateMapDescriptorWithScreenSize:layerCount:layers:")]
		extern static MTLRasterizationRateMapDescriptor Create (MTLSize screenSize, nuint layerCount, out MTLRasterizationRateLayerDescriptor layers);

		[Export ("layerAtIndex:")]
		[return: NullAllowed]
		extern MTLRasterizationRateLayerDescriptor GetLayer (nuint layerIndex);

		[Export ("setLayer:atIndex:")]
		extern void SetLayer ([NullAllowed] MTLRasterizationRateLayerDescriptor layer, nuint layerIndex);

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("layers")]
		extern MTLRasterizationRateLayerArray Layers { get; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("screenSize", ArgumentSemantic.Assign)]
		extern MTLSize ScreenSize { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("layerCount")]
		extern nuint LayerCount { get; }
	}

	[Introduced (PlatformName.MacCatalyst, 13, 4)]
	[TV (16, 0), iOS (13, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	class MTLRasterizationRateLayerDescriptor : NSCopying {

		[Export ("initWithSampleCount:")]
		[DesignatedInitializer]
		extern NativeHandle Constructor (MTLSize sampleCount);

		[Internal]
		[Export ("initWithSampleCount:horizontal:vertical:")]
		extern NativeHandle Constructor (MTLSize sampleCount, IntPtr horizontal, IntPtr vertical);

		[MacCatalyst (15, 0)]
		[Internal]
		[Export ("horizontalSampleStorage")]
		extern IntPtr _HorizontalSampleStorage { get; }

		[MacCatalyst (15, 0)]
		[Internal]
		[Export ("verticalSampleStorage")]
		extern IntPtr _VerticalSampleStorage { get; }

		[MacCatalyst (15, 0)]
		[Export ("horizontal")]
		extern MTLRasterizationRateSampleArray Horizontal { get; }

		[MacCatalyst (15, 0)]
		[Export ("vertical")]
		extern MTLRasterizationRateSampleArray Vertical { get; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("maxSampleCount")]
		extern MTLSize MaxSampleCount { get; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("sampleCount", ArgumentSemantic.Assign)]
		extern MTLSize SampleCount { get; set; }
	}

	[Introduced (PlatformName.MacCatalyst, 13, 4)]
	[TV (16, 0), iOS (13, 0)]
	[BaseType (typeof (NSObject))]
	class  MTLRasterizationRateLayerArray: NSObject {
		[Export ("objectAtIndexedSubscript:")]
		[return: NullAllowed]
		extern MTLRasterizationRateLayerDescriptor GetObject (nuint layerIndex);

		[Export ("setObject:atIndexedSubscript:")]
		extern void SetObject ([NullAllowed] MTLRasterizationRateLayerDescriptor layer, nuint layerIndex);
	}

	interface IMTLRasterizationRateMap { }

	[Introduced (PlatformName.MacCatalyst, 13, 4)]
	[TV (16, 0), iOS (13, 0)]
	[Protocol]
	class MTLRasterizationRateMap {
		[Abstract]
		[Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract]
		[NullAllowed, Export ("label")]
		extern string Label { get; }

		[Abstract]
		[Export ("screenSize")]
		extern MTLSize ScreenSize { get; }

		[Abstract]
		[Export ("physicalGranularity")]
		extern MTLSize PhysicalGranularity { get; }

		[Abstract]
		[Export ("layerCount")]
		extern nuint LayerCount { get; }

		[Abstract]
		[Export ("parameterBufferSizeAndAlign")]
		extern MTLSizeAndAlign ParameterBufferSizeAndAlign { get; }

		[Abstract]
		[Export ("copyParameterDataToBuffer:offset:")]
		extern void CopyParameterData (IMTLBuffer buffer, nuint offset);

		[Abstract]
		[Export ("physicalSizeForLayer:")]
		extern MTLSize GetPhysicalSize (nuint layerIndex);

		[Abstract]
		[Export ("mapScreenToPhysicalCoordinates:forLayer:")]
		extern MTLCoordinate2D MapScreenToPhysicalCoordinates (MTLCoordinate2D screenCoordinates, nuint layerIndex);

		[Abstract]
		[Export ("mapPhysicalToScreenCoordinates:forLayer:")]
		extern MTLCoordinate2D MapPhysicalToScreenCoordinates (MTLCoordinate2D physicalCoordinates, nuint layerIndex);
	}

	interface IMTLResourceStateCommandEncoder { }

	[Introduced (PlatformName.MacCatalyst, 14, 0)]
	[iOS (13, 0), TV (16, 0)]
	[Protocol]
	class MTLResourceStateCommandEncoder : MTLCommandEncoder {
#if !MONOMAC && !__MACCATALYST__
		[Abstract]
#endif
		[Export ("updateTextureMappings:mode:regions:mipLevels:slices:numRegions:")]
		extern void Update (IMTLTexture texture, MTLSparseTextureMappingMode mode, IntPtr regions, IntPtr mipLevels, IntPtr slices, nuint numRegions);

#if !MONOMAC && !__MACCATALYST__
		[Abstract]
#endif
		[Export ("updateTextureMapping:mode:region:mipLevel:slice:")]
		extern void Update (IMTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, nuint mipLevel, nuint slice);

#if !MONOMAC && !__MACCATALYST__
		[Abstract]
#endif
		[Export ("updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:")]
		extern void Update (IMTLTexture texture, MTLSparseTextureMappingMode mode, IMTLBuffer indirectBuffer, nuint indirectBufferOffset);

#if !MONOMAC && !__MACCATALYST__
		[Abstract]
#endif
		[Export ("updateFence:")]
		extern void Update (IMTLFence fence);

#if !MONOMAC && !__MACCATALYST__
		[Abstract]
#endif
		[Export ("waitForFence:")]
		extern void Wait (IMTLFence fence);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		// @optional in macOS and Mac Catalyst
#if NET && !__MACOS__ && !__MACCATALYST__
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:")]
		extern void MoveTextureMappings (IMTLTexture sourceTexture, nuint sourceSlice, nuint sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, IMTLTexture destinationTexture, nuint destinationSlice, nuint destinationLevel, MTLOrigin destinationOrigin);
	}

	[iOS (13, 0), TV (13, 0)]
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSObject))]
	class MTLCaptureDescriptor : NSCopying {
		[NullAllowed, Export ("captureObject", ArgumentSemantic.Strong)]
		extern NSObject CaptureObject { get; set; }

		[Export ("destination", ArgumentSemantic.Assign)]
		extern MTLCaptureDestination Destination { get; set; }

		[NullAllowed, Export ("outputURL", ArgumentSemantic.Copy)]
		extern NSUrl OutputUrl { get; set; }
	}

	interface IMTLIndirectComputeCommand { }

	[TV (13, 0), iOS (13, 0)]
	[MacCatalyst (13, 1)]
	[Protocol]
	class MTLIndirectComputeCommand {
		[Abstract]
		[Export ("setComputePipelineState:")]
		extern void SetComputePipelineState (IMTLComputePipelineState pipelineState);

		[Abstract]
		[Export ("setKernelBuffer:offset:atIndex:")]
		extern void SetKernelBuffer (IMTLBuffer buffer, nuint offset, nuint index);

		[Abstract]
		[Export ("concurrentDispatchThreadgroups:threadsPerThreadgroup:")]
		extern void ConcurrentDispatchThreadgroups (MTLSize threadgroupsPerGrid, MTLSize threadsPerThreadgroup);

		[Abstract]
		[Export ("concurrentDispatchThreads:threadsPerThreadgroup:")]
		extern void ConcurrentDispatchThreads (MTLSize threadsPerGrid, MTLSize threadsPerThreadgroup);

		[Abstract]
		[Export ("setBarrier")]
		extern void SetBarrier ();

		[Abstract]
		[Export ("clearBarrier")]
		extern void ClearBarrier ();

		[Abstract]
		[Export ("reset")]
		extern void Reset ();

		[Abstract]
		[Export ("setThreadgroupMemoryLength:atIndex:")]
		extern void SetThreadgroupMemoryLength (nuint length, nuint index);

		[Abstract]
		[Export ("setStageInRegion:")]
		extern void SetStageInRegion (MTLRegion region);

		[iOS (14, 0), TV (14, 0)]
		[MacCatalyst (14, 0)]
#if NET
		[Abstract]
#endif
		[Export ("setImageblockWidth:height:")]
		extern void SetImageblock (nuint width, nuint height);

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setKernelBuffer:offset:attributeStride:atIndex:")]
		extern void SetKernelBuffer (IMTLBuffer buffer, nuint offset, nuint stride, nuint index);
	}

	interface IMTLCounter { }

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
#if !NET
	[BaseType (typeof (NSObject))]
#endif
	class MTLCounter {
		[Abstract]
		[Export ("name")]
		extern string Name { get; }
	}

	public interface IMTLCounterSet: INativeObject { }

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
#if !NET
	[BaseType (typeof (NSObject))]
#endif
	class MTLCounterSet: NSObject {
		[Abstract]
		[Export ("name")]
		extern string Name { get; }

		[Abstract]
		[Export ("counters", ArgumentSemantic.Copy)]
		extern IMTLCounter [] Counters { get; }
	}

	public interface IMTLCounterSampleBuffer: INativeObject { }

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
#if !NET
	[BaseType (typeof (NSObject))]
#endif
	interface MTLCounterSampleBuffer {
		[Abstract]
		[Export ("device")]
		IMTLDevice Device { get; }

		[Abstract]
		[Export ("label")]
		string Label { get; }

		[Abstract]
		[Export ("sampleCount")]
		nuint SampleCount { get; }

		[Abstract]
		[Export ("resolveCounterRange:")]
		[return: NullAllowed]
		NSData ResolveCounterRange (NSRange range);
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLCounterSampleBufferDescriptor : NSCopying {
		[NullAllowed]
		[Export ("counterSet", ArgumentSemantic.Retain)]
		public extern IMTLCounterSet CounterSet { get; set; }

		[Export ("label")]
		public extern string Label { get; set; }

		[Export ("storageMode", ArgumentSemantic.Assign)]
		public extern MTLStorageMode StorageMode { get; set; }

		[Export ("sampleCount")]
		public extern nuint SampleCount { get; set; }
	}

	[iOS (14, 0), NoTV]
	[MacCatalyst (14, 0)]
	interface IMTLAccelerationStructure { }

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class  MTLAccelerationStructure : MTLResource {
		[Abstract]
		[Export ("size")]
		extern nuint Size { get; }

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Abstract]
		[Export ("gpuResourceID")]
		extern MTLResourceId GpuResourceId { get; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (MTLAccelerationStructureGeometryDescriptor))]
	interface MTLAccelerationStructureBoundingBoxGeometryDescriptor {
		[NullAllowed, Export ("boundingBoxBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer BoundingBoxBuffer { get; set; }

		[Export ("boundingBoxBufferOffset")]
		nuint BoundingBoxBufferOffset { get; set; }

		[Export ("boundingBoxStride")]
		nuint BoundingBoxStride { get; set; }

		[Export ("boundingBoxCount")]
		nuint BoundingBoxCount { get; set; }

		[Static]
		[Export ("descriptor")]
		MTLAccelerationStructureBoundingBoxGeometryDescriptor Create ();
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	class MTLAccelerationStructureDescriptor : NSCopying {
		[Mac (14, 0), iOS (17, 0), MacCatalyst (17, 0), TV (17, 0)]
		[Export ("usage", ArgumentSemantic.Assign)]
		extern MTLAccelerationStructureUsage Usage { get; set; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	class MTLAccelerationStructureGeometryDescriptor : NSCopying {
		[Export ("intersectionFunctionTableOffset")]
		extern nuint IntersectionFunctionTableOffset { get; set; }

		[Export ("opaque")]
		extern bool Opaque { get; set; }

		[Export ("allowDuplicateIntersectionFunctionInvocation")]
		extern bool AllowDuplicateIntersectionFunctionInvocation { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[NullAllowed, Export ("primitiveDataBuffer", ArgumentSemantic.Retain)]
		extern IMTLBuffer PrimitiveDataBuffer { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("primitiveDataBufferOffset")]
		extern nuint PrimitiveDataBufferOffset { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("primitiveDataStride")]
		extern nuint PrimitiveDataStride { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("primitiveDataElementSize")]
		extern nuint PrimitiveDataElementSize { get; set; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (MTLAccelerationStructureGeometryDescriptor))]
	interface MTLAccelerationStructureTriangleGeometryDescriptor {
		[NullAllowed, Export ("vertexBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer VertexBuffer { get; set; }

		[Export ("vertexBufferOffset")]
		nuint VertexBufferOffset { get; set; }

		[Export ("vertexStride")]
		nuint VertexStride { get; set; }

		[NullAllowed, Export ("indexBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer IndexBuffer { get; set; }

		[Export ("indexBufferOffset")]
		nuint IndexBufferOffset { get; set; }

		[Export ("indexType", ArgumentSemantic.Assign)]
		MTLIndexType IndexType { get; set; }

		[Export ("triangleCount")]
		nuint TriangleCount { get; set; }

		[Static]
		[Export ("descriptor")]
		MTLAccelerationStructureTriangleGeometryDescriptor Create ();

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
		[Export ("vertexFormat", ArgumentSemantic.Assign)]
		MTLAttributeFormat VertexFormat { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
		[NullAllowed, Export ("transformationMatrixBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer TransformationMatrixBuffer { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0), TV (16, 0)]
		[Export ("transformationMatrixBufferOffset")]
		nuint TransformationMatrixBufferOffset { get; set; }

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("transformationMatrixLayout")]
		MTLMatrixLayout TransformationMatrixLayout { get; set; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	class MTLBinaryArchiveDescriptor : NSCopying {
		[NullAllowed, Export ("url", ArgumentSemantic.Copy)]
		extern NSUrl Url { get; set; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	class MTLBlitPassDescriptor : NSCopying {
		[Static]
		[Export ("blitPassDescriptor")]
		extern MTLBlitPassDescriptor Create ();

		[Export ("sampleBufferAttachments")]
		extern MTLBlitPassSampleBufferAttachmentDescriptorArray SampleBufferAttachments { get; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLBlitPassSampleBufferAttachmentDescriptor : NSCopying {
		[NullAllowed, Export ("sampleBuffer", ArgumentSemantic.Retain)]
		public extern IMTLCounterSampleBuffer? SampleBuffer { get; set; }

		[Export ("startOfEncoderSampleIndex")]
		public extern nuint StartOfEncoderSampleIndex { get; set; }

		[Export ("endOfEncoderSampleIndex")]
		public extern nuint EndOfEncoderSampleIndex { get; set; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLBlitPassSampleBufferAttachmentDescriptorArray: NSObject {
		[Export ("objectAtIndexedSubscript:")]
		public extern MTLBlitPassSampleBufferAttachmentDescriptor GetObject (nuint attachmentIndex);

		[Export ("setObject:atIndexedSubscript:")]
		public extern void SetObject ([NullAllowed] MTLBlitPassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex);
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	class MTLCommandBufferDescriptor : NSCopying {

		[Field ("MTLCommandBufferEncoderInfoErrorKey")]
		extern NSString BufferEncoderInfoErrorKey { get; }

		[Export ("retainedReferences")]
		extern bool RetainedReferences { get; set; }

		[Export ("errorOptions", ArgumentSemantic.Assign)]
		extern MTLCommandBufferErrorOption ErrorOptions { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("logState", ArgumentSemantic.Retain), NullAllowed]
		extern IMTLLogState LogState { get; set; }

	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	class MTLComputePassDescriptor : NSCopying {
		[Static]
		[Export ("computePassDescriptor")]
		extern MTLComputePassDescriptor Create ();

		[Export ("dispatchType", ArgumentSemantic.Assign)]
		extern MTLDispatchType DispatchType { get; set; }

		[Export ("sampleBufferAttachments")]
		extern MTLComputePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments { get; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLComputePassSampleBufferAttachmentDescriptor : NSCopying {

		[NullAllowed, Export ("sampleBuffer", ArgumentSemantic.Retain)]
		public extern IMTLCounterSampleBuffer? SampleBuffer { get; set; }

		[Export ("startOfEncoderSampleIndex")]
		public extern nuint StartOfEncoderSampleIndex { get; set; }

		[Export ("endOfEncoderSampleIndex")]
		public extern nuint EndOfEncoderSampleIndex { get; set; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLComputePassSampleBufferAttachmentDescriptorArray: NSObject {
		[Export ("objectAtIndexedSubscript:")]
		public extern MTLComputePassSampleBufferAttachmentDescriptor GetObject (nuint attachmentIndex);

		[Export ("setObject:atIndexedSubscript:")]
		public extern void SetObject ([NullAllowed] MTLComputePassSampleBufferAttachmentDescriptor? attachment, nuint attachmentIndex);
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	class MTLFunctionDescriptor : NSCopying {
		[Static]
		[Export ("functionDescriptor")]
		extern MTLFunctionDescriptor Create ();

		[NullAllowed, Export ("name")]
		extern string Name { get; set; }

		[NullAllowed, Export ("specializedName")]
		extern string SpecializedName { get; set; }

		[NullAllowed, Export ("constantValues", ArgumentSemantic.Copy)]
		extern MTLFunctionConstantValues ConstantValues { get; set; }

		[Export ("options", ArgumentSemantic.Assign)]
		extern MTLFunctionOptions Options { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("binaryArchives", ArgumentSemantic.Copy)]
		extern IMTLBinaryArchive [] BinaryArchives { get; set; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (MTLAccelerationStructureDescriptor))]
	interface MTLInstanceAccelerationStructureDescriptor {
		[NullAllowed, Export ("instanceDescriptorBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer InstanceDescriptorBuffer { get; set; }

		[Export ("instanceDescriptorBufferOffset")]
		nuint InstanceDescriptorBufferOffset { get; set; }

		[Export ("instanceDescriptorStride")]
		nuint InstanceDescriptorStride { get; set; }

		[Export ("instanceCount")]
		nuint InstanceCount { get; set; }

		[NullAllowed, Export ("instancedAccelerationStructures", ArgumentSemantic.Retain)]
		IMTLAccelerationStructure [] InstancedAccelerationStructures { get; set; }

		[Static]
		[Export ("descriptor")]
		MTLInstanceAccelerationStructureDescriptor Create ();

		[iOS (15, 0), MacCatalyst (15, 0), TV (17, 0)]
		[Export ("instanceDescriptorType", ArgumentSemantic.Assign)]
		MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("motionTransformBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer MotionTransformBuffer { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("motionTransformBufferOffset")]
		nuint MotionTransformBufferOffset { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("motionTransformCount")]
		nuint MotionTransformCount { get; set; }

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("instanceTransformationMatrixLayout")]
		MTLMatrixLayout InstanceTransformationMatrixLayout { get; set; }

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("motionTransformType")]
		MTLTransformType MotionTransformType { get; set; }

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("motionTransformStride")]
		nuint MotionTransformStride { get; set; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (MTLFunctionDescriptor))]
	class MTLIntersectionFunctionDescriptor : NSCopying { }

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	class MTLIntersectionFunctionTableDescriptor : NSCopying {
		[Static]
		[Export ("intersectionFunctionTableDescriptor")]
		extern MTLIntersectionFunctionTableDescriptor Create ();

		[Export ("functionCount")]
		extern nuint FunctionCount { get; set; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	class MTLLinkedFunctions : NSCopying {
		[Static]
		[Export ("linkedFunctions")]
		extern MTLLinkedFunctions Create ();

		[NullAllowed, Export ("functions", ArgumentSemantic.Copy)]
		extern IMTLFunction [] Functions { get; set; }

		[TV (17, 0)]
		[MacCatalyst (13, 1)]
		[NullAllowed, Export ("binaryFunctions", ArgumentSemantic.Copy)]
		extern IMTLFunction [] BinaryFunctions { get; set; }
		 
		[NullAllowed, Export ("groups", ArgumentSemantic.Copy)]
		extern NSDictionary<NSString, NSArray<IMTLFunction>> Groups { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("privateFunctions", ArgumentSemantic.Copy)]
		extern IMTLFunction [] PrivateFunctions { get; set; }

		[iOS (15, 0), NoTV, MacCatalyst (15, 0)]
		[Export ("instanceDescriptorType", ArgumentSemantic.Assign)]
		extern MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[NullAllowed, Export ("motionTransformBuffer", ArgumentSemantic.Retain)]
		extern IMTLBuffer MotionTransformBuffer { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("motionTransformBufferOffset")]
		extern nuint MotionTransformBufferOffset { get; set; }

		[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
		[Export ("motionTransformCount")]
		extern nuint MotionTransformCount { get; set; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (MTLAccelerationStructureDescriptor))]
	interface MTLPrimitiveAccelerationStructureDescriptor {
		[NullAllowed, Export ("geometryDescriptors", ArgumentSemantic.Retain)]
		MTLAccelerationStructureGeometryDescriptor [] GeometryDescriptors { get; set; }

		[Static]
		[Export ("descriptor")]
		MTLPrimitiveAccelerationStructureDescriptor Create ();

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("motionStartBorderMode", ArgumentSemantic.Assign)]
		MTLMotionBorderMode MotionStartBorderMode { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("motionEndBorderMode", ArgumentSemantic.Assign)]
		MTLMotionBorderMode MotionEndBorderMode { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("motionStartTime")]
		float MotionStartTime { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("motionEndTime")]
		float MotionEndTime { get; set; }

		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("motionKeyframeCount")]
		nuint MotionKeyframeCount { get; set; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLRenderPassSampleBufferAttachmentDescriptor : NSCopying {
		[NullAllowed, Export ("sampleBuffer", ArgumentSemantic.Retain)]
		public extern IMTLCounterSampleBuffer? SampleBuffer { get; set; }

		[Export ("startOfVertexSampleIndex")]
		public extern nuint StartOfVertexSampleIndex { get; set; }

		[Export ("endOfVertexSampleIndex")]
		public extern nuint EndOfVertexSampleIndex { get; set; }

		[Export ("startOfFragmentSampleIndex")]
		public extern nuint StartOfFragmentSampleIndex { get; set; }

		[Export ("endOfFragmentSampleIndex")]
		public extern nuint EndOfFragmentSampleIndex { get; set; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLRenderPassSampleBufferAttachmentDescriptorArray: NSObject {
		[Export ("objectAtIndexedSubscript:")]
		public extern MTLRenderPassSampleBufferAttachmentDescriptor GetObject (nuint attachmentIndex);

		[Export ("setObject:atIndexedSubscript:")]
		public extern void SetObject ([NullAllowed] MTLRenderPassSampleBufferAttachmentDescriptor? attachment, nuint attachmentIndex);

	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	public partial class MTLResourceStatePassDescriptor : NSCopying {
		[Static]
		[Export ("resourceStatePassDescriptor")]
		public static extern MTLResourceStatePassDescriptor Create ();

		[Export ("sampleBufferAttachments")]
		public extern MTLResourceStatePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments { get; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLResourceStatePassSampleBufferAttachmentDescriptor : NSCopying {
		[NullAllowed, Export ("sampleBuffer", ArgumentSemantic.Retain)]
		public extern IMTLCounterSampleBuffer? SampleBuffer { get; set; }

		[Export ("startOfEncoderSampleIndex")]
		public extern nuint StartOfEncoderSampleIndex { get; set; }

		[Export ("endOfEncoderSampleIndex")]
		public extern nuint EndOfEncoderSampleIndex { get; set; }
	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[BaseType (typeof (NSObject))]
	public partial class MTLResourceStatePassSampleBufferAttachmentDescriptorArray: NSObject {
		[Export ("objectAtIndexedSubscript:")]
		public extern MTLResourceStatePassSampleBufferAttachmentDescriptor GetObject (nuint attachmentIndex);

		[Export ("setObject:atIndexedSubscript:")]
		public extern void SetObject ([NullAllowed] MTLResourceStatePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex);

	}

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject))]
	class MTLVisibleFunctionTableDescriptor : NSCopying {
		[Static]
		[Export ("visibleFunctionTableDescriptor")]
		static extern MTLVisibleFunctionTableDescriptor Create ();

		[Export ("functionCount")]
		extern nuint FunctionCount { get; set; }
	}

	interface IMTLFunctionHandle { }

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class MTLFunctionHandle {
		[Abstract]
		[Export ("functionType")]
		extern MTLFunctionType FunctionType { get; }

		[Abstract]
		[Export ("name")]
		extern string Name { get; }

		[Abstract]
		[Export ("device")]
		extern IMTLDevice Device { get; }
	}

	interface IMTLAccelerationStructureCommandEncoder { }

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class MTLAccelerationStructureCommandEncoder : MTLCommandEncoder {
		[Abstract]
		[Export ("buildAccelerationStructure:descriptor:scratchBuffer:scratchBufferOffset:")]
		extern void BuildAccelerationStructure (IMTLAccelerationStructure accelerationStructure, MTLAccelerationStructureDescriptor descriptor, IMTLBuffer scratchBuffer, nuint scratchBufferOffset);

		[Abstract]
		[Export ("refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:")]
		extern void RefitAccelerationStructure (IMTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, [NullAllowed] IMTLAccelerationStructure destinationAccelerationStructure, IMTLBuffer scratchBuffer, nuint scratchBufferOffset);

		[Abstract]
		[Export ("copyAccelerationStructure:toAccelerationStructure:")]
		extern void CopyAccelerationStructure (IMTLAccelerationStructure sourceAccelerationStructure, IMTLAccelerationStructure destinationAccelerationStructure);

		[Abstract]
		[Export ("writeCompactedAccelerationStructureSize:toBuffer:offset:")]
		extern void WriteCompactedAccelerationStructureSize (IMTLAccelerationStructure accelerationStructure, IMTLBuffer buffer, nuint offset);

		[Abstract]
		[Export ("copyAndCompactAccelerationStructure:toAccelerationStructure:")]
		extern void CopyAndCompactAccelerationStructure (IMTLAccelerationStructure sourceAccelerationStructure, IMTLAccelerationStructure destinationAccelerationStructure);

		[Abstract]
		[Export ("updateFence:")]
		extern void UpdateFence (IMTLFence fence);

		[Abstract]
		[Export ("waitForFence:")]
		extern void WaitForFence (IMTLFence fence);

		[Abstract]
		[Export ("useResource:usage:")]
		extern void UseResource (IMTLResource resource, MTLResourceUsage usage);

		[Abstract]
		[Export ("useResources:count:usage:")]
		extern void UseResources (IMTLResource [] resources, nuint count, MTLResourceUsage usage);

		[Abstract]
		[Export ("useHeap:")]
		extern void UseHeap (IMTLHeap heap);

		[Abstract]
		[Export ("useHeaps:count:")]
		extern void UseHeaps (IMTLHeap [] heaps, nuint count);

		[Abstract]
		[Export ("sampleCountersInBuffer:atSampleIndex:withBarrier:")]
#if NET
		extern void SampleCountersInBuffer (IMTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#else
		void SampleCountersInBuffer (MTLCounterSampleBuffer sampleBuffer, nuint sampleIndex, bool barrier);
#endif

#if NET
		[Abstract]
#endif
		[iOS (15, 0), MacCatalyst (15, 0)]
		[Export ("writeCompactedAccelerationStructureSize:toBuffer:offset:sizeDataType:")]
		extern void WriteCompactedAccelerationStructureSize (IMTLAccelerationStructure accelerationStructure, IMTLBuffer buffer, nuint offset, MTLDataType sizeDataType);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("refitAccelerationStructure:descriptor:destination:scratchBuffer:scratchBufferOffset:options:")]
		extern void RefitAccelerationStructure (IMTLAccelerationStructure sourceAccelerationStructure, MTLAccelerationStructureDescriptor descriptor, [NullAllowed] IMTLAccelerationStructure destinationAccelerationStructure, [NullAllowed] IMTLBuffer scratchBuffer, nuint scratchBufferOffset, MTLAccelerationStructureRefitOptions options);

	}

	interface IMTLVisibleFunctionTable { }

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class MTLVisibleFunctionTable : MTLResource {
		[Abstract]
		[Export ("setFunction:atIndex:")]
		extern void SetFunction ([NullAllowed] IMTLFunctionHandle function, nuint index);

		[Abstract]
		[Export ("setFunctions:withRange:")]
		extern void SetFunctions (IMTLFunctionHandle [] functions, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("gpuResourceID")]
		extern MTLResourceId GpuResourceId { get; }
	}

	public interface IMTLIntersectionFunctionTable: INativeObject { }

	[iOS (14, 0), TV (16, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class MTLIntersectionFunctionTable : MTLResource {
		[Abstract]
		[Export ("setBuffer:offset:atIndex:")]
		extern void SetBuffer ([NullAllowed] IMTLBuffer buffer, nuint offset, nuint index);

		[Abstract]
		[Export ("setBuffers:offsets:withRange:")]
		extern void SetBuffers (IntPtr /* IMTLBuffer[] */ buffers, /* nuint[]*/ IntPtr offsets, NSRange range);

		[Abstract]
		[Export ("setFunction:atIndex:")]
		extern void SetFunction ([NullAllowed] IMTLFunctionHandle function, nuint index);

		[Abstract]
		[Export ("setFunctions:withRange:")]
		extern void SetFunctions (IMTLFunctionHandle [] functions, NSRange range);

		[Abstract]
		[Export ("setOpaqueTriangleIntersectionFunctionWithSignature:atIndex:")]
		extern void SetOpaqueTriangleIntersectionFunction (MTLIntersectionFunctionSignature signature, nuint index);

		[Abstract]
		[Export ("setOpaqueTriangleIntersectionFunctionWithSignature:withRange:")]
		extern void SetOpaqueTriangleIntersectionFunction (MTLIntersectionFunctionSignature signature, NSRange range);

		[Abstract]
		[Export ("setVisibleFunctionTable:atBufferIndex:")]
		extern void SetVisibleFunctionTable ([NullAllowed] IMTLVisibleFunctionTable functionTable, nuint bufferIndex);

		[Abstract]
		[Export ("setVisibleFunctionTables:withBufferRange:")]
		extern void SetVisibleFunctionTables (IMTLVisibleFunctionTable [] functionTables, NSRange bufferRange);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setOpaqueCurveIntersectionFunctionWithSignature:atIndex:")]
		extern void SetOpaqueCurveIntersectionFunction (MTLIntersectionFunctionSignature signature, nuint index);

#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("setOpaqueCurveIntersectionFunctionWithSignature:withRange:")]
		extern void SetOpaqueCurveIntersectionFunction (MTLIntersectionFunctionSignature signature, NSRange range);

		[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
#if NET
		[Abstract (GenerateExtensionMethod = true)]
#endif
		[Export ("gpuResourceID")]
		extern MTLResourceId GpuResourceId { get; }
	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class MTLCommandBufferEncoderInfo {

		[Abstract]
		[Export ("label")]
		extern string Label { get; }

		[Abstract]
		[Export ("debugSignposts")]
		extern string [] DebugSignposts { get; }

		[Abstract]
		[Export ("errorState")]
		extern MTLCommandEncoderErrorState ErrorState { get; }
	}

	interface IMTLDynamicLibrary { }

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	class MTLDynamicLibrary {

		[Abstract]
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[Abstract]
		[Export ("device")]
		extern IMTLDevice Device { get; }

		[Abstract]
		[Export ("installName")]
		extern string InstallName { get; }

		[Abstract]
		[Export ("serializeToURL:error:")]
		extern bool Serialize (NSUrl url, [NullAllowed] out NSError error);
	}

	interface IMTLLogContainer { }

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	interface MTLLogContainer : INSFastEnumeration {

	}

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	interface MTLFunctionLog {
		[Abstract]
		[Export ("type")]
		MTLFunctionLogType Type { get; }

		[Abstract]
		[NullAllowed, Export ("encoderLabel")]
		string EncoderLabel { get; }

		[Abstract]
		[NullAllowed, Export ("function")]
		IMTLFunction Function { get; }

		[Abstract]
		[NullAllowed, Export ("debugLocation")]
		IMTLFunctionLogDebugLocation DebugLocation { get; }
	}

	interface IMTLFunctionLogDebugLocation { }

	[iOS (14, 0), TV (14, 0)]
	[MacCatalyst (14, 0)]
	[Protocol]
	interface MTLFunctionLogDebugLocation {
		[Abstract]
		[NullAllowed, Export ("functionName")]
		string FunctionName { get; }

		[Abstract]
		[NullAllowed, Export ("URL")]
		NSUrl Url { get; }

		[Abstract]
		[Export ("line")]
		nuint Line { get; }

		[Abstract]
		[Export ("column")]
		nuint Column { get; }
	}

	[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	class MTLStitchedLibraryDescriptor : NSCopying {
		[Export ("functionGraphs", ArgumentSemantic.Copy)]
		extern MTLFunctionStitchingGraph [] FunctionGraphs { get; set; }

		[Export ("functions", ArgumentSemantic.Copy)]
		extern IMTLFunction [] Functions { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("binaryArchives", ArgumentSemantic.Copy)]
		extern IMTLBinaryArchive [] BinaryArchives { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("options")]
		extern MTLStitchedLibraryOptions Options { get; set; }
	}

	[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	class MTLRenderPipelineFunctionsDescriptor : NSCopying {
		[NullAllowed, Export ("vertexAdditionalBinaryFunctions", ArgumentSemantic.Copy)]
		extern IMTLFunction [] VertexAdditionalBinaryFunctions { get; set; }

		[NullAllowed, Export ("fragmentAdditionalBinaryFunctions", ArgumentSemantic.Copy)]
		extern IMTLFunction [] FragmentAdditionalBinaryFunctions { get; set; }

		[NullAllowed, Export ("tileAdditionalBinaryFunctions", ArgumentSemantic.Copy)]
		extern IMTLFunction [] TileAdditionalBinaryFunctions { get; set; }
	}

	[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	class MTLMotionKeyframeData: NSObject {
		[NullAllowed, Export ("buffer", ArgumentSemantic.Retain)]
		extern IMTLBuffer Buffer { get; set; }

		[Export ("offset")]
		extern nuint Offset { get; set; }

		[Static]
		[Export ("data")]
		static extern MTLMotionKeyframeData Create ();
	}

	[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	class MTLFunctionStitchingNode : NSCopying { }

	interface IMTLFunctionStitchingNode { }

	[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
	[Protocol] // From Apple Docs: Your app does not define classes that implement this protocol. Model is not needed
	class MTLFunctionStitchingAttribute : NSCopying { }

	interface IMTLFunctionStitchingAttribute { }

	[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
	class MTLFunctionStitchingAttributeAlwaysInline : MTLFunctionStitchingAttribute { }

	[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	class MTLFunctionStitchingInputNode : MTLFunctionStitchingNode {
		[Export ("argumentIndex")]
		extern nuint ArgumentIndex { get; set; }

		[Export ("initWithArgumentIndex:")]
		extern NativeHandle Constructor (nuint argument);
	}

	[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	class MTLFunctionStitchingGraph : NSCopying {
		[Export ("functionName")]
		extern string FunctionName { get; set; }

		[Export ("nodes", ArgumentSemantic.Copy)]
		extern MTLFunctionStitchingFunctionNode [] Nodes { get; set; }

		[NullAllowed, Export ("outputNode", ArgumentSemantic.Retain)]
		extern MTLFunctionStitchingFunctionNode OutputNode { get; set; }

		[Export ("attributes", ArgumentSemantic.Copy)]
		extern IMTLFunctionStitchingAttribute [] Attributes { get; set; }

		[Export ("initWithFunctionName:nodes:outputNode:attributes:")]
		extern NativeHandle Constructor (string functionName, MTLFunctionStitchingFunctionNode [] nodes, [NullAllowed] MTLFunctionStitchingFunctionNode outputNode, IMTLFunctionStitchingAttribute [] attributes);
	}

	[iOS (15, 0), TV (15, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	class MTLFunctionStitchingFunctionNode : MTLFunctionStitchingNode {
		[Export ("name")]
		extern string Name { get; set; }

		[Export ("arguments", ArgumentSemantic.Copy)]
		extern IMTLFunctionStitchingNode [] Arguments { get; set; }

		[Export ("controlDependencies", ArgumentSemantic.Copy)]
		extern MTLFunctionStitchingFunctionNode [] ControlDependencies { get; set; }

		[Export ("initWithName:arguments:controlDependencies:")]
		extern NativeHandle Constructor (string name, IMTLFunctionStitchingNode [] arguments, MTLFunctionStitchingFunctionNode [] controlDependencies);
	}

	[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (MTLAccelerationStructureGeometryDescriptor))]
	class MTLAccelerationStructureMotionTriangleGeometryDescriptor {
		[Export ("vertexBuffers", ArgumentSemantic.Copy)]
		extern MTLMotionKeyframeData [] VertexBuffers { get; set; }

		[Export ("vertexStride")]
		extern nuint VertexStride { get; set; }

		[NullAllowed, Export ("indexBuffer", ArgumentSemantic.Retain)]
		extern IMTLBuffer IndexBuffer { get; set; }

		[Export ("indexBufferOffset")]
		extern nuint IndexBufferOffset { get; set; }

		[Export ("indexType", ArgumentSemantic.Assign)]
		extern MTLIndexType IndexType { get; set; }

		[Export ("triangleCount")]
		extern nuint TriangleCount { get; set; }

		[Static]
		[Export ("descriptor")]
		static extern MTLAccelerationStructureMotionTriangleGeometryDescriptor Create ();

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("vertexFormat", ArgumentSemantic.Assign)]
		extern MTLAttributeFormat VertexFormat { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[NullAllowed, Export ("transformationMatrixBuffer", ArgumentSemantic.Retain)]
		extern IMTLBuffer TransformationMatrixBuffer { get; set; }

		[Mac (13, 0), iOS (16, 0), MacCatalyst (16, 0)]
		[Export ("transformationMatrixBufferOffset")]
		extern nuint TransformationMatrixBufferOffset { get; set; }

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("transformationMatrixLayout")]
		extern MTLMatrixLayout TransformationMatrixLayout { get; set; }
	}

	[iOS (15, 0), TV (16, 0), MacCatalyst (15, 0)]
	[BaseType (typeof (MTLAccelerationStructureGeometryDescriptor))]
	class MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor {
		[Export ("boundingBoxBuffers", ArgumentSemantic.Copy)]
		extern MTLMotionKeyframeData [] BoundingBoxBuffers { get; set; }

		[Export ("boundingBoxStride")]
		extern nuint BoundingBoxStride { get; set; }

		[Export ("boundingBoxCount")]
		extern nuint BoundingBoxCount { get; set; }

		[Static]
		[Export ("descriptor")]
		static extern MTLAccelerationStructureMotionBoundingBoxGeometryDescriptor Create ();
	}

	interface IMTLBinding { }

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[Protocol]
	interface MTLBinding {
		[Abstract]
		[Export ("name")]
		string Name { get; }

		[Abstract]
		[Export ("type")]
		MTLBindingType Type { get; }

		[Abstract]
		[Export ("access")]
		MTLBindingAccess Access { get; }

		[Abstract]
		[Export ("index")]
		nuint Index { get; }

		[Abstract]
		[Export ("used")]
		bool Used { [Bind ("isUsed")] get; }

		[Abstract]
		[Export ("argument")]
		bool Argument { [Bind ("isArgument")] get; }
	}

	interface IMTLBufferBinding { }

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[Protocol]
	interface MTLBufferBinding : MTLBinding {
		[Abstract]
		[Export ("bufferAlignment")]
		nuint BufferAlignment { get; }

		[Abstract]
		[Export ("bufferDataSize")]
		nuint BufferDataSize { get; }

		[Abstract]
		[Export ("bufferDataType")]
		MTLDataType BufferDataType { get; }

		[Abstract]
		[NullAllowed, Export ("bufferStructType")]
		MTLStructType BufferStructType { get; }

		[Abstract]
		[NullAllowed, Export ("bufferPointerType")]
		MTLPointerType BufferPointerType { get; }
	}


	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[Protocol]
	interface MTLObjectPayloadBinding : MTLBinding {
		[Abstract]
		[Export ("objectPayloadAlignment")]
		nuint ObjectPayloadAlignment { get; }

		[Abstract]
		[Export ("objectPayloadDataSize")]
		nuint ObjectPayloadDataSize { get; }
	}

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[Protocol]
	interface MTLTextureBinding : MTLBinding {
		[Abstract]
		[Export ("textureType")]
		MTLTextureType TextureType { get; }

		[Abstract]
		[Export ("textureDataType")]
		MTLDataType TextureDataType { get; }

		[Abstract]
		[Export ("depthTexture")]
		bool DepthTexture { [Bind ("isDepthTexture")] get; }

		[Abstract]
		[Export ("arrayLength")]
		nuint ArrayLength { get; }
	}

	[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
	[BaseType (typeof (MTLAccelerationStructureGeometryDescriptor))]
	interface MTLAccelerationStructureCurveGeometryDescriptor {
		[NullAllowed, Export ("controlPointBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer ControlPointBuffer { get; set; }

		[Export ("controlPointBufferOffset")]
		nuint ControlPointBufferOffset { get; set; }

		[Export ("controlPointCount")]
		nuint ControlPointCount { get; set; }

		[Export ("controlPointStride")]
		nuint ControlPointStride { get; set; }

		[Export ("controlPointFormat", ArgumentSemantic.Assign)]
		MTLAttributeFormat ControlPointFormat { get; set; }

		[NullAllowed, Export ("radiusBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer RadiusBuffer { get; set; }

		[Export ("radiusBufferOffset")]
		nuint RadiusBufferOffset { get; set; }

		[Export ("radiusFormat", ArgumentSemantic.Assign)]
		MTLAttributeFormat RadiusFormat { get; set; }

		[Export ("radiusStride")]
		nuint RadiusStride { get; set; }

		[NullAllowed, Export ("indexBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer IndexBuffer { get; set; }

		[Export ("indexBufferOffset")]
		nuint IndexBufferOffset { get; set; }

		[Export ("indexType", ArgumentSemantic.Assign)]
		MTLIndexType IndexType { get; set; }

		[Export ("segmentCount")]
		nuint SegmentCount { get; set; }

		[Export ("segmentControlPointCount")]
		nuint SegmentControlPointCount { get; set; }

		[Export ("curveType", ArgumentSemantic.Assign)]
		MTLCurveType CurveType { get; set; }

		[Export ("curveBasis", ArgumentSemantic.Assign)]
		MTLCurveBasis CurveBasis { get; set; }

		[Export ("curveEndCaps", ArgumentSemantic.Assign)]
		MTLCurveEndCaps CurveEndCaps { get; set; }

		[Static]
		[Export ("descriptor")]
		MTLAccelerationStructureCurveGeometryDescriptor GetDescriptor ();
	}

	[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
	[BaseType (typeof (MTLAccelerationStructureGeometryDescriptor))]
	interface MTLAccelerationStructureMotionCurveGeometryDescriptor {
		[Export ("controlPointBuffers", ArgumentSemantic.Copy)]
		MTLMotionKeyframeData [] ControlPointBuffers { get; set; }

		[Export ("controlPointCount")]
		nuint ControlPointCount { get; set; }

		[Export ("controlPointStride")]
		nuint ControlPointStride { get; set; }

		[Export ("controlPointFormat", ArgumentSemantic.Assign)]
		MTLAttributeFormat ControlPointFormat { get; set; }

		[Export ("radiusBuffers", ArgumentSemantic.Copy)]
		MTLMotionKeyframeData [] RadiusBuffers { get; set; }

		[Export ("radiusFormat", ArgumentSemantic.Assign)]
		MTLAttributeFormat RadiusFormat { get; set; }

		[Export ("radiusStride")]
		nuint RadiusStride { get; set; }

		[NullAllowed, Export ("indexBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer IndexBuffer { get; set; }

		[Export ("indexBufferOffset")]
		nuint IndexBufferOffset { get; set; }

		[Export ("indexType", ArgumentSemantic.Assign)]
		MTLIndexType IndexType { get; set; }

		[Export ("segmentCount")]
		nuint SegmentCount { get; set; }

		[Export ("segmentControlPointCount")]
		nuint SegmentControlPointCount { get; set; }

		[Export ("curveType", ArgumentSemantic.Assign)]
		MTLCurveType CurveType { get; set; }

		[Export ("curveBasis", ArgumentSemantic.Assign)]
		MTLCurveBasis CurveBasis { get; set; }

		[Export ("curveEndCaps", ArgumentSemantic.Assign)]
		MTLCurveEndCaps CurveEndCaps { get; set; }

		[Static]
		[Export ("descriptor")]
		MTLAccelerationStructureMotionCurveGeometryDescriptor GetDescriptor ();
	}

	[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
	[BaseType (typeof (NSObject))]
	class MTLArchitecture : NSCopying {
		[Export ("name")]
		extern string Name { get; }
	}

	[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
	[BaseType (typeof (MTLAccelerationStructureDescriptor))]
	interface MTLIndirectInstanceAccelerationStructureDescriptor {
		[NullAllowed, Export ("instanceDescriptorBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer InstanceDescriptorBuffer { get; set; }

		[Export ("instanceDescriptorBufferOffset")]
		nuint InstanceDescriptorBufferOffset { get; set; }

		[Export ("instanceDescriptorStride")]
		nuint InstanceDescriptorStride { get; set; }

		[Export ("maxInstanceCount")]
		nuint MaxInstanceCount { get; set; }

		[NullAllowed, Export ("instanceCountBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer InstanceCountBuffer { get; set; }

		[Export ("instanceCountBufferOffset")]
		nuint InstanceCountBufferOffset { get; set; }

		[Export ("instanceDescriptorType", ArgumentSemantic.Assign)]
		MTLAccelerationStructureInstanceDescriptorType InstanceDescriptorType { get; set; }

		[NullAllowed, Export ("motionTransformBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer MotionTransformBuffer { get; set; }

		[Export ("motionTransformBufferOffset")]
		nuint MotionTransformBufferOffset { get; set; }

		[Export ("maxMotionTransformCount")]
		nuint MaxMotionTransformCount { get; set; }

		[NullAllowed, Export ("motionTransformCountBuffer", ArgumentSemantic.Retain)]
		IMTLBuffer MotionTransformCountBuffer { get; set; }

		[Export ("motionTransformCountBufferOffset")]
		nuint MotionTransformCountBufferOffset { get; set; }

		[Static]
		[Export ("descriptor")]
		MTLIndirectInstanceAccelerationStructureDescriptor GetDescriptor ();

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("instanceTransformationMatrixLayout")]
		MTLMatrixLayout InstanceTransformationMatrixLayout { get; set; }

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("motionTransformType")]
		MTLTransformType MotionTransformType { get; set; }

		[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
		[Export ("motionTransformStride")]
		nuint MotionTransformStride { get; set; }
	}

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[BaseType (typeof (NSObject))]
	class MTLMeshRenderPipelineDescriptor : NSCopying {
		[NullAllowed, Export ("label")]
		extern string Label { get; set; }

		[NullAllowed, Export ("objectFunction", ArgumentSemantic.Strong)]
		extern IMTLFunction ObjectFunction { get; set; }

		[NullAllowed, Export ("meshFunction", ArgumentSemantic.Strong)]
		extern IMTLFunction MeshFunction { get; set; }

		[NullAllowed, Export ("fragmentFunction", ArgumentSemantic.Strong)]
		extern IMTLFunction FragmentFunction { get; set; }

		[Export ("maxTotalThreadsPerObjectThreadgroup")]
		extern nuint MaxTotalThreadsPerObjectThreadgroup { get; set; }

		[Export ("maxTotalThreadsPerMeshThreadgroup")]
		extern nuint MaxTotalThreadsPerMeshThreadgroup { get; set; }

		[Export ("objectThreadgroupSizeIsMultipleOfThreadExecutionWidth")]
		extern bool ObjectThreadgroupSizeIsMultipleOfThreadExecutionWidth { get; set; }

		[Export ("meshThreadgroupSizeIsMultipleOfThreadExecutionWidth")]
		extern bool MeshThreadgroupSizeIsMultipleOfThreadExecutionWidth { get; set; }

		[Export ("payloadMemoryLength")]
		extern nuint PayloadMemoryLength { get; set; }

		[Export ("maxTotalThreadgroupsPerMeshGrid")]
		extern nuint MaxTotalThreadgroupsPerMeshGrid { get; set; }

		[Export ("objectBuffers")]
		extern MTLPipelineBufferDescriptorArray ObjectBuffers { get; }

		[Export ("meshBuffers")]
		extern MTLPipelineBufferDescriptorArray MeshBuffers { get; }

		[Export ("fragmentBuffers")]
		extern MTLPipelineBufferDescriptorArray FragmentBuffers { get; }

		[Export ("rasterSampleCount")]
		extern nuint RasterSampleCount { get; set; }

		[Export ("alphaToCoverageEnabled")]
		extern bool AlphaToCoverageEnabled { [Bind ("isAlphaToCoverageEnabled")] get; set; }

		[Export ("alphaToOneEnabled")]
		extern bool AlphaToOneEnabled { [Bind ("isAlphaToOneEnabled")] get; set; }

		[Export ("rasterizationEnabled")]
		extern bool RasterizationEnabled { [Bind ("isRasterizationEnabled")] get; set; }

		[Export ("maxVertexAmplificationCount")]
		extern nuint MaxVertexAmplificationCount { get; set; }

		[Export ("colorAttachments")]
		extern MTLRenderPipelineColorAttachmentDescriptorArray ColorAttachments { get; }

		[Export ("depthAttachmentPixelFormat", ArgumentSemantic.Assign)]
		extern MTLPixelFormat DepthAttachmentPixelFormat { get; set; }

		[Export ("stencilAttachmentPixelFormat", ArgumentSemantic.Assign)]
		extern MTLPixelFormat StencilAttachmentPixelFormat { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[Export ("supportIndirectCommandBuffers")]
		extern bool SupportIndirectCommandBuffers { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[NullAllowed, Export ("objectLinkedFunctions", ArgumentSemantic.Copy)]
		extern MTLLinkedFunctions ObjectLinkedFunctions { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[NullAllowed, Export ("meshLinkedFunctions", ArgumentSemantic.Copy)]
		extern MTLLinkedFunctions MeshLinkedFunctions { get; set; }

		[Mac (14, 0), iOS (17, 0), TV (17, 0), MacCatalyst (17, 0)]
		[NullAllowed, Export ("fragmentLinkedFunctions", ArgumentSemantic.Copy)]
		extern MTLLinkedFunctions FragmentLinkedFunctions { get; set; }

		[Export ("reset")]
		extern void Reset ();

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("binaryArchives", ArgumentSemantic.Copy), NullAllowed]
		extern IMTLBinaryArchive [] BinaryArchives { get; set; }

		[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
		[Export ("shaderValidation")]
		extern MTLShaderValidation ShaderValidation { get; set; }
	}

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[BaseType (typeof (NSObject))]
	class MTLAccelerationStructurePassSampleBufferAttachmentDescriptor : NSCopying {
		[NullAllowed, Export ("sampleBuffer", ArgumentSemantic.Retain)]
		extern IMTLCounterSampleBuffer SampleBuffer { get; set; }

		[Export ("startOfEncoderSampleIndex")]
		extern nuint StartOfEncoderSampleIndex { get; set; }

		[Export ("endOfEncoderSampleIndex")]
		extern nuint EndOfEncoderSampleIndex { get; set; }
	}

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[BaseType (typeof (NSObject))]
	interface MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray {
		[Export ("objectAtIndexedSubscript:")]
		MTLAccelerationStructurePassSampleBufferAttachmentDescriptor GetObject (nuint attachmentIndex);

		[Export ("setObject:atIndexedSubscript:")]
		void SetObject ([NullAllowed] MTLAccelerationStructurePassSampleBufferAttachmentDescriptor attachment, nuint attachmentIndex);
	}

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[BaseType (typeof (NSObject))]
	class MTLAccelerationStructurePassDescriptor : NSCopying {
		[Static]
		[Export ("accelerationStructurePassDescriptor")]
		extern MTLAccelerationStructurePassDescriptor AccelerationStructurePassDescriptor { get; }

		[Export ("sampleBufferAttachments")]
		extern MTLAccelerationStructurePassSampleBufferAttachmentDescriptorArray SampleBufferAttachments { get; }
	}

	[Mac (13, 0), iOS (16, 0), TV (16, 0), MacCatalyst (16, 0)]
	[Protocol]
	interface MTLThreadgroupBinding : MTLBinding {
		[Abstract]
		[Export ("threadgroupMemoryAlignment")]
		nuint ThreadgroupMemoryAlignment { get; }

		[Abstract]
		[Export ("threadgroupMemoryDataSize")]
		nuint ThreadgroupMemoryDataSize { get; }
	}

	[Native]
	[Mac (15, 0), TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum MTLMatrixLayout : long {
		ColumnMajor = 0,
		RowMajor = 1,
	}

	[Native]
	[Mac (15, 0), TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum MTLTransformType : long {
		PackedFloat4x3 = 0,
		Component = 1,
	}

	[Protocol (BackwardsCompatibleCodeGeneration = false)]
	[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
	class MTLAllocation {
		[Abstract]
		[Export ("allocatedSize")]
		extern nuint AllocatedSize { get; }
	}

	public interface IMTLAllocation: INativeObject { }

	[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
	[BaseType (typeof (NSObject))]
	class MTLCommandQueueDescriptor : NSCopying {
		[Export ("maxCommandBufferCount")]
		nuint MaxCommandBufferCount { get; set; }

		[Export ("logState", ArgumentSemantic.Retain), NullAllowed]
		IMTLLogState LogState { get; set; }
	}

	[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	//[BackingFieldType (typeof (nint))]
	enum NSDeviceCertification {
		[Field ("NSDeviceCertificationiPhonePerformanceGaming")]
		iPhonePerformanceGaming,
	}

	[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	//[BackingFieldType (typeof (nint))]
	enum NSProcessPerformanceProfile {
		[Field ("NSProcessPerformanceProfileDefault")]
		Default,

		[Field ("NSProcessPerformanceProfileSustained")]
		Sustained,
	}

	[TV (18, 0), Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0)]
	//[Category]
	[BaseType (typeof (NSProcessInfo))]
	interface NSProcessInfo_NSDeviceCertification {
		[Export ("isDeviceCertifiedFor:")]
		bool IsDeviceCertifiedFor (NSDeviceCertification performanceTier);

		[Export ("hasPerformanceProfile:")]
		bool HasPerformanceProfile (NSProcessPerformanceProfile performanceProfile);
	}

	[Flags]
	[Native]
	[Mac (15, 0), TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum MTLStitchedLibraryOptions : ulong {
		None = 0,
		FailOnBinaryArchiveMiss = 1 << 0,
		StoreLibraryInMetalPipelinesScript = 1 << 1,
	}

	[Native]
	[Mac (15, 0), TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum MTLMathMode : long {
		Safe = 0,
		Relaxed = 1,
		Fast = 2,
	}

	[Native]
	[Mac (15, 0), TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum MTLMathFloatingPointFunctions : long {
		Fast = 0,
		Precise = 1,
	}

	[Native]
	[Mac (15, 0), TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum MTLLogLevel : long {
		Undefined,
		Debug,
		Info,
		Notice,
		Error,
		Fault,
	}

	delegate void MTLLogStateLogHandler ([NullAllowed] string subSystem, [NullAllowed] string category, MTLLogLevel logLevel, string message);

	[Protocol (BackwardsCompatibleCodeGeneration = false)]
	[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
	interface MTLLogState {
		[Abstract]
		[Export ("addLogHandler:")]
		void AddLogHandler (MTLLogStateLogHandler handler);
	}

	interface IMTLLogState { }

	[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
	[BaseType (typeof (NSObject))]
	class MTLLogStateDescriptor : NSCopying {
		[Export ("level", ArgumentSemantic.Assign)]
		extern MTLLogLevel Level { get; set; }

		[Export ("bufferSize", ArgumentSemantic.Assign)]
		extern nint BufferSize { get; set; }
	}

	[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
	[ErrorDomain ("MTLLogStateErrorDomain")]
	[Native]
	enum MTLLogStateError : ulong {
		InvalidSize = 1,
		Invalid = 2,
	}

	[Native]
	[Mac (15, 0), TV (18, 0), iOS (18, 0), MacCatalyst (18, 0)]
	enum MTLShaderValidation : long {
		Default = 0,
		Enabled = 1,
		Disabled = 2,
	}

	[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
	[BaseType (typeof (NSObject))]
	class MTLResidencySetDescriptor : NSCopying {
		[Export ("label", ArgumentSemantic.Copy), NullAllowed]
		extern string Label { get; set; }

		[Export ("initialCapacity")]
		extern nuint InitialCapacity { get; set; }
	}

	[Protocol (BackwardsCompatibleCodeGeneration = false)]
	[Mac (15, 0), iOS (18, 0), MacCatalyst (18, 0), TV (18, 0)]
	interface MTLResidencySet {
		[Abstract]
		[Export ("device")]
		IMTLDevice Device { get; }

		[Abstract]
		[Export ("label"), NullAllowed]
		string Label { get; }

		[Abstract]
		[Export ("allocatedSize")]
		ulong AllocatedSize { get; }

		[Abstract]
		[Export ("requestResidency")]
		void RequestResidency ();

		[Abstract]
		[Export ("endResidency")]
		void EndResidency ();

		[Abstract]
		[Export ("addAllocation:")]
		void AddAllocation (IMTLAllocation allocation);

		[Abstract]
		[Export ("addAllocations:count:")]
		void AddAllocations (IntPtr allocations, nuint count);

		[Abstract]
		[Export ("removeAllocation:")]
		void RemoveAllocation (IMTLAllocation allocation);

		[Abstract]
		[Export ("removeAllocations:count:")]
		void RemoveAllocations (IntPtr allocations, nuint count);

		[Abstract]
		[Export ("removeAllAllocations")]
		void RemoveAllAllocations ();

		[Abstract]
		[Export ("containsAllocation:")]
		bool ContainsAllocation (IMTLAllocation allocation);

		[Abstract]
		[Export ("allAllocations", ArgumentSemantic.Copy)]
		IMTLAllocation [] AllAllocations { get; }

		[Abstract]
		[Export ("allocationCount")]
		nuint AllocationCount { get; }

		[Abstract]
		[Export ("commit")]
		void Commit ();
	}

	public partial interface IMTLResidencySet { }
}
