using System;
using CoreLibs;
using ObjCRuntime;
using Foundation;

#nullable enable

namespace AppKit {

	public partial class NSSliderTouchBarItem {
		// If you modify, also search for other other XM_ACTIVATED_COPY and update as well
		NSObject? target;
		Selector? action;

		public event EventHandler Activated {
			add {
				target = ActionDispatcher.SetupAction (Target, value);
				action = ActionDispatcher.Action;
				MarkDirty ();
				Target = target;
				Action = action;
			}

			remove {
				ActionDispatcher.RemoveAction (Target, value);
				target = null;
				action = null;
				MarkDirty ();
			}
		}
	}
	
	[MacCatalyst (13, 1)]
	[BaseType (typeof (NSTouchBarItem))]
	//[DisableDefaultCtor]
	public partial class NSSliderTouchBarItem: NSTouchBarItem {
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		public extern NativeHandle Constructor (string identifier);

		[NoMacCatalyst]
		[Export ("slider", ArgumentSemantic.Strong)]
		extern NSSlider Slider { get; set; }

		[NullAllowed, Export ("label")]
		public extern string Label { get; set; }

		[NullAllowed, Export ("minimumValueAccessory", ArgumentSemantic.Strong)]
		extern NSSliderAccessory? MinimumValueAccessory { get; set; }

		[NullAllowed, Export ("maximumValueAccessory", ArgumentSemantic.Strong)]
		extern NSSliderAccessory? MaximumValueAccessory { get; set; }

		[Export ("valueAccessoryWidth")]
		public extern nfloat ValueAccessoryWidth { get; set; }

		[NullAllowed, Export ("target", ArgumentSemantic.Weak)]
		public extern NSObject? Target { get; set; }

		[NullAllowed, Export ("action", ArgumentSemantic.Assign)]
		public extern Selector? Action { get; set; }

		[NullAllowed]
		[Export ("customizationLabel")]
		public extern string? CustomizationLabel { get; set; }

		[NoMacCatalyst]
		[Export ("view")]
		extern INSUserInterfaceCompression View { get; }

		[MacCatalyst (13, 1)]
		[Export ("doubleValue")]
		public extern double DoubleValue { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("minimumSliderWidth")]
		public extern nfloat MinimumSliderWidth { get; set; }

		[MacCatalyst (13, 1)]
		[Export ("maximumSliderWidth")]
		public extern nfloat MaximumSliderWidth { get; set; }
	}
}
