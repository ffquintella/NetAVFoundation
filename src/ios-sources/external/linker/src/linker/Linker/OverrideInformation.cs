using System.Diagnostics;
using System.Reflection.Metadata;
using MethodDefinition = Mono.Cecil.MethodDefinition;
using TypeDefinition = Mono.Cecil.TypeDefinition;

namespace Mono.Linker {
	[DebuggerDisplay ("{Override}")]
	public class OverrideInformation {
		public readonly MethodDefinition Base;
		public readonly MethodDefinition Override;
		public readonly InterfaceImplementation? MatchingInterfaceImplementation;

		public OverrideInformation (MethodDefinition @base, MethodDefinition @override, InterfaceImplementation? matchingInterfaceImplementation = null)
		{
			Base = @base;
			Override = @override;
			MatchingInterfaceImplementation = matchingInterfaceImplementation;
		}

		public bool IsOverrideOfInterfaceMember {
			get {
				if (MatchingInterfaceImplementation is not null)
					return true;

				return Base.DeclaringType.IsInterface;
			}
		}

		public TypeDefinition InterfaceType {
			get {
				if (!IsOverrideOfInterfaceMember)
					return null;

				if (MatchingInterfaceImplementation is not null)
					return MatchingInterfaceImplementation.InterfaceType.Resolve ();

				return Base.DeclaringType;
			}
		}
	}
}
