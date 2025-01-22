using System.Text;

namespace CoreLibs;

public enum PlatformName : byte {
    None,
    MacOSX,
    iOS,
    WatchOS,
    TvOS,
    MacCatalyst,
}

public enum AvailabilityKind {
	Introduced,
	Deprecated,
	Obsoleted,
	Unavailable,
}

public enum PlatformArchitecture : byte {
	None = 0x00,
	Arch32 = 0x01,
	Arch64 = 0x02,
	All = 0xff
}

public sealed class ObsoletedAttribute : AvailabilityBaseAttribute {
	public ObsoletedAttribute (PlatformName platform, string message = null)
		: base (AvailabilityKind.Obsoleted, platform, null, message)
	{
	}

	public ObsoletedAttribute (PlatformName platform, int majorVersion, int minorVersion, string message = null)
		: base (AvailabilityKind.Obsoleted, platform, new Version (majorVersion, minorVersion), message)
	{
	}

	public ObsoletedAttribute (PlatformName platform, int majorVersion, int minorVersion, int subminorVersion, string message = null)
		: base (AvailabilityKind.Obsoleted, platform, new Version (majorVersion, minorVersion, subminorVersion), message)
	{
	}
}

public abstract class AvailabilityBaseAttribute : Attribute {
	public AvailabilityKind AvailabilityKind { get; private set; }
	public PlatformName Platform { get; private set; }
	public Version Version { get; private set; }
	public string Message { get; private set; }

	internal AvailabilityBaseAttribute ()
	{
	}

	internal AvailabilityBaseAttribute (
		AvailabilityKind availabilityKind,
		PlatformName platform,
		Version version,
		string message)
	{
		AvailabilityKind = availabilityKind;
		Platform = platform;
		Version = version;
		Message = message;
	}

	void GeneratePlatformDefine (StringBuilder builder)
	{
		switch (Platform) {
		case PlatformName.iOS:
			builder.AppendLine ("#if __IOS__");
			break;
		case PlatformName.TvOS:
			builder.AppendLine ("#if __TVOS__");
			break;
		case PlatformName.WatchOS:
			builder.AppendLine ("#if __WATCHOS__");
			break;
		case PlatformName.MacOSX:
			builder.AppendLine ("#if __MACOS__");
			break;
		case PlatformName.MacCatalyst:
			builder.AppendLine ("#if __MACCATALYST__ && !__IOS__");
			break;
		default:
			throw new NotSupportedException ($"Unknown platform: {Platform}");
		}
	}

	void GenerateUnsupported (StringBuilder builder)
	{
		builder.Append ("[UnsupportedOSPlatform (\"");
		GeneratePlatformNameAndVersion (builder);
		builder.Append ("\"");
		if (!String.IsNullOrEmpty (Message))
			builder.Append (", \"").Append (Message).Append ('"');

		builder.AppendLine (")]");
	}

	void GenerateDeprecated (StringBuilder builder)
	{
		builder.Append ("[ObsoletedOSPlatform (\"");
		GeneratePlatformNameAndVersion (builder);
		builder.Append ("\"");
		if (!String.IsNullOrEmpty (Message))
			builder.Append (", \"").Append (Message).Append ('"');
		builder.AppendLine (")]");
	}

	void GenerateSupported (StringBuilder builder)
	{
#if BGENERATOR
		// If the version is less than or equal to the min version for the platform in question,
		// the version is redundant, so just skip it.
		if (Version is not null && Version <= Xamarin.SdkVersions.GetMinVersion (Platform.AsApplePlatform ()))
			Version = null;
#endif

		builder.Append ("[SupportedOSPlatform (\"");
		GeneratePlatformNameAndVersion (builder);
		builder.AppendLine ("\")]");
	}

	void GeneratePlatformNameAndVersion (StringBuilder builder)
	{
		switch (Platform) {
		case PlatformName.iOS:
			builder.Append ("ios");
			break;
		case PlatformName.TvOS:
			builder.Append ("tvos");
			break;
		case PlatformName.WatchOS:
			builder.Append ("watchos");
			break;
		case PlatformName.MacOSX:
			builder.Append ("macos"); // no 'x'
			break;
		case PlatformName.MacCatalyst:
			builder.Append ("maccatalyst");
			break;
		default:
			throw new NotSupportedException ($"Unknown platform: {Platform}");
		}

		if (Version is not null)
			builder.Append (Version.ToString (Version.Build >= 0 ? 3 : 2));
	}

	public override string ToString ()
	{
		var builder = new StringBuilder ();
		switch (AvailabilityKind) {
		case AvailabilityKind.Introduced:
			GenerateSupported (builder);
			break;
		case AvailabilityKind.Deprecated:
			GenerateDeprecated (builder);
			break;
		case AvailabilityKind.Obsoleted:
			GenerateUnsupported (builder);
			break;
		case AvailabilityKind.Unavailable:
			GenerateUnsupported (builder);
			break;
		}
		return builder.ToString ();
	}
}

public sealed partial  class DeprecatedAttribute : AvailabilityBaseAttribute {
    public DeprecatedAttribute (PlatformName platform, string message = null)
        : base (AvailabilityKind.Deprecated, platform, null, message)
    {
    }
    
    public DeprecatedAttribute (PlatformName platform, int majorVersion, int minorVersion)
	    : base (AvailabilityKind.Deprecated, platform, new Version (majorVersion, minorVersion), null)
    {
    }

    public DeprecatedAttribute (PlatformName platform, int majorVersion, int minorVersion, string message = null)
        : base (AvailabilityKind.Deprecated, platform, new Version (majorVersion, minorVersion), message)
    {
    }

    public DeprecatedAttribute (PlatformName platform, int majorVersion, int minorVersion, int subminorVersion, string message = null)
        : base (AvailabilityKind.Deprecated, platform, new Version (majorVersion, minorVersion, subminorVersion), message)
    {
    }
    
}

public sealed class MacCatalystAttribute : IntroducedAttribute {
	public MacCatalystAttribute (byte major, byte minor)
		: base (PlatformName.MacCatalyst, (int) major, (int) minor)
	{
	}

	public MacCatalystAttribute (byte major, byte minor, byte subminor)
		: base (PlatformName.MacCatalyst, (int) major, (int) minor, subminor)
	{
	}
}

public class IntroducedAttribute : AvailabilityBaseAttribute {
	public IntroducedAttribute (PlatformName platform, string message = null)
		: base (AvailabilityKind.Introduced, platform, null, message)
	{
	}

	public IntroducedAttribute (PlatformName platform, int majorVersion, int minorVersion, string message = null)
		: base (AvailabilityKind.Introduced, platform, new Version (majorVersion, minorVersion), message)
	{
	}

	public IntroducedAttribute (PlatformName platform, int majorVersion, int minorVersion, int subminorVersion, string message = null)
		: base (AvailabilityKind.Introduced, platform, new Version (majorVersion, minorVersion, subminorVersion), message)
	{
	}
}

public class BaseTypeAttribute : Attribute {
	public BaseTypeAttribute (Type t)
	{
		BaseType = t;
	}
	public Type BaseType { get; set; }
	public string Name { get; set; }
	public Type [] Events { get; set; }
	public string [] Delegates { get; set; }
	public bool Singleton { get; set; }

	// If set, the code will keep a reference in the EnsureXXX method for
	// delegates and will clear the reference to the object in the method
	// referenced by KeepUntilRef.   Currently uses an ArrayList, so this
	// is not really designed as a workaround for systems that create
	// too many objects, but two cases in particular that users keep
	// trampling on: UIAlertView and UIActionSheet
	public string KeepRefUntil { get; set; }
}

public sealed class NoMacCatalystAttribute : UnavailableAttribute {
	public NoMacCatalystAttribute ()
		: base (PlatformName.MacCatalyst)
	{
	}
}

public class UnavailableAttribute : AvailabilityBaseAttribute {
	public UnavailableAttribute (PlatformName platform, string message = null)
		: base (AvailabilityKind.Unavailable, platform, null, message)
	{
	}
}

public class NullAllowedAttribute : Attribute {
	public NullAllowedAttribute () { }
}

public class DisableDefaultCtorAttribute : DefaultCtorVisibilityAttribute {
	public DisableDefaultCtorAttribute () : base (Visibility.Disabled) { }
}

public enum Visibility {
	Public,
	Protected,
	Internal,
	ProtectedInternal,
	Private,
	Disabled
}

public class DefaultCtorVisibilityAttribute : Attribute {
	public DefaultCtorVisibilityAttribute (Visibility visibility)
	{
		this.Visibility = visibility;
	}

	public Visibility Visibility { get; set; }
}

public sealed class TVAttribute : IntroducedAttribute {
	public TVAttribute (byte major, byte minor)
		: base (PlatformName.TvOS, (int) major, (int) minor)
	{
	}

	public TVAttribute (byte major, byte minor, byte subminor)
		: base (PlatformName.TvOS, (int) major, (int) minor, subminor)
	{
	}
}

public sealed class WatchAttribute : IntroducedAttribute {
	public WatchAttribute (byte major, byte minor)
		: base (PlatformName.WatchOS, (int) major, (int) minor)
	{
	}

	public WatchAttribute (byte major, byte minor, byte subminor)
		: base (PlatformName.WatchOS, (int) major, (int) minor, subminor)
	{
	}
}

public sealed class NoiOSAttribute : UnavailableAttribute {
	public NoiOSAttribute ()
		: base (PlatformName.iOS)
	{
	}
}

public sealed class NoWatchAttribute : UnavailableAttribute {
	public NoWatchAttribute ()
		: base (PlatformName.WatchOS)
	{
	}
}

public sealed class NoTVAttribute : UnavailableAttribute {
	public NoTVAttribute ()
		: base (PlatformName.TvOS)
	{
	}
}

sealed class MacAttribute : IntroducedAttribute {
	public MacAttribute (byte major, byte minor)
		: base (PlatformName.MacOSX, (int) major, (int) minor)
	{
	}

	

	public MacAttribute (byte major, byte minor, byte subminor)
		: base (PlatformName.MacOSX, (int) major, (int) minor, subminor)
	{
	}
	
}

sealed class iOSAttribute : IntroducedAttribute {
	public iOSAttribute (byte major, byte minor)
		: base (PlatformName.iOS, (int) major, (int) minor)
	{
	}
	
	public iOSAttribute (byte major, byte minor, byte subminor)
		: base (PlatformName.iOS, (int) major, (int) minor, subminor)
	{
	}


}

public class PartialAttribute : Attribute {
	public PartialAttribute () { }
}

public class StaticAttribute : Attribute {
	public StaticAttribute () { }
}

public class WrapAttribute : Attribute {
	public WrapAttribute (string methodname, bool isVirtual = false)
	{
		MethodName = methodname;
		IsVirtual = isVirtual;
	}

	public string MethodName { get; set; }
	public bool IsVirtual { get; set; }
}

public class InternalAttribute : Attribute {
	public InternalAttribute () { }
}

public sealed class NoMacAttribute : UnavailableAttribute {
	public NoMacAttribute ()
		: base (PlatformName.MacOSX)
	{
	}
}

[AttributeUsage (AttributeTargets.Interface | AttributeTargets.Property, AllowMultiple = false)]
public class StrongDictionaryAttribute : Attribute {
	public StrongDictionaryAttribute ()
	{
	}
	public StrongDictionaryAttribute (string typeWithKeys)
	{
		TypeWithKeys = typeWithKeys;
		Suffix = "Key";
	}
	public string TypeWithKeys;
	public string Suffix;
}

// Used for mandatory methods that must be implemented in a [Model].
[AttributeUsage (AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true)]
public class AbstractAttribute : Attribute {
	public AbstractAttribute () { }
#if !XAMCORE_5_0
	// We don't generate extension methods for required members by default,
	// but we might have to in order to keep backwards compatibility for
	// members that switched from optional to required (because we used to
	// generate the extension method because the member was optional).
	public bool GenerateExtensionMethod { get; set; }
#endif
}

// If the enum is used to represent error code then this attribute can be used to
// generate an extension type that will return the associated error domain based
// on the field name (given as a parameter)
[AttributeUsage (AttributeTargets.Enum)]
public class ErrorDomainAttribute : Attribute {

	public ErrorDomainAttribute (string domain)
	{
		ErrorDomain = domain;
	}

	public ErrorDomainAttribute (string domain, string libraryName)
	{
		ErrorDomain = domain;
		LibraryName = libraryName;
	}

	public string ErrorDomain { get; set; }
	public string LibraryName { get; set; }
}

public class MarshalNativeExceptionsAttribute : Attribute {
}

public class SealedAttribute : Attribute {
	public SealedAttribute () { }
}

public class DelegateNameAttribute : Attribute {
	public DelegateNameAttribute (string s)
	{
		Name = s;
	}

	public string Name { get; set; }
}

public class EventArgsAttribute : Attribute {
	public EventArgsAttribute (string s)
	{
		ArgName = s;
	}
	public EventArgsAttribute (string s, bool skip)
	{
		ArgName = s;
		SkipGeneration = skip;
	}
	public EventArgsAttribute (string s, bool skip, bool fullname)
	{
		ArgName = s;
		SkipGeneration = skip;
		FullName = fullname;
	}

	public string ArgName { get; set; }
	public bool SkipGeneration { get; set; }
	public bool FullName { get; set; }
}

[AttributeUsage (AttributeTargets.Property, AllowMultiple = true)]
public class NotificationAttribute : Attribute {
	public NotificationAttribute (Type t) { Type = t; }
	public NotificationAttribute (Type t, string notificationCenter) { Type = t; NotificationCenter = notificationCenter; }
	public NotificationAttribute (string notificationCenter) { NotificationCenter = notificationCenter; }
	public NotificationAttribute () { }

	public Type Type { get; set; }
	public string NotificationCenter { get; set; }
}

public class PostSnippetAttribute : SnippetAttribute {
	public PostSnippetAttribute (string s) : base (s) { }
}

[AttributeUsage (AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public class SnippetAttribute : Attribute {
	public SnippetAttribute (string s)
	{
		Code = s;
	}
	public string Code { get; set; }

	public bool Optimizable { get; set; }
}

[AttributeUsage (AttributeTargets.All, AllowMultiple = true)]
public class PostGetAttribute : Attribute {
	public PostGetAttribute (string name)
	{
		MethodName = name;
	}

	public string MethodName { get; set; }
}

public class BindAttribute : Attribute {
	public BindAttribute (string sel)
	{
		Selector = sel;
	}
	public string Selector { get; set; }

	// By default [Bind] makes non-virtual methods
	public bool Virtual { get; set; }
}

// flags the backing field for the property to with .NET's [ThreadStatic] property
public class IsThreadStaticAttribute : Attribute {
	public IsThreadStaticAttribute () { }
}

public class PreSnippetAttribute : SnippetAttribute {
	public PreSnippetAttribute (string s) : base (s) { }
}

[AttributeUsage (AttributeTargets.Method, AllowMultiple = false)]
public class AsyncAttribute : Attribute {

	//This will automagically generate the async method.
	//This works with 4 kinds of callbacks: (), (NSError), (result), (result, NSError)
	public AsyncAttribute () { }

	//This works with 2 kinds of callbacks: (...) and (..., NSError).
	//Parameters are passed in order to a constructor in resultType
	public AsyncAttribute (Type resultType)
	{
		ResultType = resultType;
	}

	//This works with 2 kinds of callbacks: (...) and (..., NSError).
	//Parameters are passed in order to a result type that is automatically created if size > 1
	//The generated method is named after the @methodName
	public AsyncAttribute (string methodName)
	{
		MethodName = methodName;
	}

	public Type ResultType { get; set; }
	public string MethodName { get; set; }
	public string ResultTypeName { get; set; }
	public string PostNonResultSnippet { get; set; }
}

// When applied to a method or property, flags the resulting generated code as internal
public sealed class ProtectedAttribute : Attribute {
}

public class OverrideAttribute : Attribute {
	public OverrideAttribute () { }
}

// Makes the result use the `new' attribtue
public class NewAttribute : Attribute {
	public NewAttribute () { }
}

//
// This attribute is a convenience shorthand for settings the
// [EditorBrowsable (EditorBrowsableState.Advanced)] flags
//
public class AdvancedAttribute : Attribute {
	public AdvancedAttribute () { }
}

public class EventNameAttribute : Attribute {
	public EventNameAttribute (string s)
	{
		EvtName = s;
	}
	public string EvtName { get; set; }
}

//
// Indicates that this array should be turned into a params
//
[AttributeUsage (AttributeTargets.Parameter, AllowMultiple = false)]
public class ParamsAttribute : Attribute {
}

public class AutoreleaseAttribute : Attribute {
	public AutoreleaseAttribute () { }
}

[AttributeUsage (AttributeTargets.Method)]
public class MarshalDirectiveAttribute : Attribute {
	public string NativePrefix { get; set; }
	public string NativeSuffix { get; set; }
	public string Library { get; set; }
}

public class DefaultValueFromArgumentAttribute : Attribute {
	public DefaultValueFromArgumentAttribute (string s)
	{
		Argument = s;
	}
	public string Argument { get; set; }
}

public class NoDefaultValueAttribute : Attribute {
}

public class IgnoredInDelegateAttribute : Attribute {
}

//
// Apply this attribute to a class to add methods that in Objective-C
// are added as categories
//
// Use the BaseType attribute to reference which class this is extending
//
// Like this:
//   [Category]
//   [BaseType (typeof (UIView))]
//   interface UIViewExtensions {
//     [Export ("method_in_the_objective_c_category")]
//     void ThisWillBecome_a_c_sharp_extension_method_in_class_UIViewExtensions ();
// }
[AttributeUsage (AttributeTargets.Interface, AllowMultiple = false)]
public class CategoryAttribute : Attribute {
#if !NET
	public bool AllowStaticMembers;
#endif
	public CategoryAttribute () { }
#if !NET
	[Obsolete ("Inline the static members in this category in the category's class (and remove this obsolete once fixed)")]
	public CategoryAttribute (bool allowStaticMembers)
	{
		AllowStaticMembers = allowStaticMembers;
	}
#endif
}

//
// Apple this attribute to ObjC types where the default `init` selector 
// is decorated with `NS_DESIGNATED_INITIALIZER`
//
// The generator will produce a `[DesignatedInitializer]` when generating the
// default constructor when `[DesignatedDefaultCtor]` is present on the type
//
[AttributeUsage (AttributeTargets.Interface, AllowMultiple = false)]
public class DesignatedDefaultCtorAttribute : Attribute {
	public DesignatedDefaultCtorAttribute ()
	{
	}
}

//
// Code to run from a generated Dispose method, before any generated code is executed
// Adding this attribute will, by default, make the method non-optimizable by the SDK tools
//
[AttributeUsage (AttributeTargets.Interface, AllowMultiple = true)]
public class DisposeAttribute : SnippetAttribute {
	public DisposeAttribute (string s) : base (s) { }
}
