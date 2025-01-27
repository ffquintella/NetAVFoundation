using ObjCRuntime;

namespace CoreLibs.Foundation;


[AttributeUsage (AttributeTargets.Class)]
public class ClassTypeAttribute: Attribute
{
    
    public ClassTypeAttribute(Type topType, Runtime.MTTypeFlags typeFlags)
    {
        TopType = topType;
        TypeFlags = typeFlags;
    }
    
    public ClassTypeAttribute( Runtime.MTTypeFlags typeFlags)
    {
        TopType = null;
        TypeFlags = typeFlags;
    }
    
    public Type? TopType { get; set; }
    public Runtime.MTTypeFlags TypeFlags { get; set; }
    
}