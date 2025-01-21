using System;
using System.Net.NetworkInformation;
using ObjCRuntime;

#nullable enable

namespace Metal {

	public partial interface IMTLCommandBuffer: INativeObject {

		/// <summary>Marks the specified residency sets as part of the current command buffer execution.</summary>
		/// <param name="residencySets">The residency sets to mark.</param>
		public void UseResidencySets (params IMTLResidencySet [] residencySets)
		{
			NativeObjectExtensions.CallWithPointerToFirstElementAndCount (residencySets, nameof (residencySets), UseResidencySets);
		}

		public void UseResidencySets(IntPtr p1, UIntPtr p2)
		{
			throw new NotImplementedException();
		}
	}
}
