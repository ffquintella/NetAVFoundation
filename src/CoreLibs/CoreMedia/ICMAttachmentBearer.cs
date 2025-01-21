#nullable enable

using ObjCRuntime;

namespace CoreMedia {

	// empty partial class used as a marker to state which CM objects DO support the API
#if !NET
	[Watch (6, 0)]
#endif
	public partial interface ICMAttachmentBearer : INativeObject { }

}
