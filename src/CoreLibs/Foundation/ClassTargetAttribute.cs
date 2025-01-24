using System.Runtime.CompilerServices;

namespace CoreLibs.Foundation;

[AttributeUsage (AttributeTargets.Class)]
public sealed class ClassTargetAttribute : Attribute
{
    public ClassTargetAttribute ( string dllPath)
    {
        DllPath = dllPath;
        
    }
    
    public string DllPath { get; set; }
    
}