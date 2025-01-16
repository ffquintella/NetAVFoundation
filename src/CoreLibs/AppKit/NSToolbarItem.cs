//
// NSToolbarItem.cs: Support for the NSToolbarItem class
//
// Author:
//   Johan Hammar
//
using System;
using ObjCRuntime;
using Foundation;

#nullable enable

namespace AppKit {

	public partial class NSToolbarItem {
		NSObject? target;
		Selector? action;

		public event EventHandler Activated {
			add {
				target = ActionDispatcher.SetupAction (target, value);
				action = ActionDispatcher.Action;
				//MarkDirty ();
				//Target = target;
				//Action = action;
			}

			remove {
				ActionDispatcher.RemoveAction (target, value);
				target = null;
				action = null;
				//MarkDirty ();
			}
		}

	}
}
