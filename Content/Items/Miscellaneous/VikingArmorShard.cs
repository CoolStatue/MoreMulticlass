using Terraria;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Miscellaneous
{
    public class VikingArmorShard : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.value = 5;
            Item.consumable = false;
        }
    }
}