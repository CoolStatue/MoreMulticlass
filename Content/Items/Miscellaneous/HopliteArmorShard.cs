using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Miscellaneous
{
    public class HopliteArmorShard : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.value = 5;
            Item.consumable = false;
        }
    }
}