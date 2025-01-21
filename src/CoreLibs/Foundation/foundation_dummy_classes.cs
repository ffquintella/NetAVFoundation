using CoreLibs;

namespace Foundation
{
    [BaseType(typeof(NSObject))] 
    // An uncaught exception was raised: *** -range cannot be sent to an abstract object of class NSTextCheckingResult: Create a concrete instance!
    public partial class NSTextCheckingResult :  NSCopying
    {
    }

    [BaseType(typeof(NSObject))]
    // Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: *** -[__NSArrayM insertObject:atIndex:]: object cannot be nil
    public partial class NSOrthography :  NSCopying
    {
    }
}