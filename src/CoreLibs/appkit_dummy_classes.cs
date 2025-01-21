using CoreLibs;
using Foundation;

namespace AppKit
{
    [NoMacCatalyst]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor] // An uncaught exception was raised: +[NSPasteboard alloc]: unrecognized selector sent to class 0xac3dcbf0
    public partial interface NSPasteboard // NSPasteboard does _not_ implement NSPasteboardReading/NSPasteboardWriting
    {

    }

    [NoMacCatalyst]
    [BaseType(typeof(NSObject))]
    public class NSDraggingImageComponent: NSObject
    {
    }

    [NoMacCatalyst]
    [BaseType(typeof(NSView))]
    public partial class NSRulerView: NSView
    {
    }

    [NoMacCatalyst]
    [BaseType(typeof(NSObject))]
    public class NSRulerMarker : NSCopying
    {
    }

    [MacCatalyst(13, 1)]
    [BaseType(typeof(NSObject))]
    public class NSTouchBarItem : NSCoding
    {
    }

    [NoMacCatalyst]
    [BaseType(typeof(NSTouchBarItem))]
    public class NSCandidateListTouchBarItem: NSTouchBarItem
    {
    }

    [BaseType(typeof(NSView))]
    public partial class NSScrollView : NSTextFinderBarContainer
    {
    }
    
    public interface INSTextFinderBarContainer { }

    [NoMacCatalyst]
    [BaseType(typeof(NSObject)), Model, Protocol]
    public partial class NSTextFinderBarContainer
    {
    }

}