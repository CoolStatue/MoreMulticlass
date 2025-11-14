using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace MoreMulticlass
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class MoreMulticlass : Mod
	{
		public static ModKeybind ArmorSetAbility;

		public override void Load()
		{
			ArmorSetAbility = KeybindLoader.RegisterKeybind(this, "Armor Set Ability", "Z");
		}

		public override void Unload()
		{
			ArmorSetAbility = null;
		}

	}
}
