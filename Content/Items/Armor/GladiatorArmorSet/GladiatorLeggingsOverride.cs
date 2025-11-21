using System.Collections.Generic;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.GladiatorArmorSet
{
    public class GladiatorLeggingsOverride : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.GladiatorLeggings;
        }

        public override void SetDefaults(Item item)
        {
            item.defense = 4; // 1 less than vanilla
        }
    }
}