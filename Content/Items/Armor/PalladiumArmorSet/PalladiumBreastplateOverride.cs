using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PalladiumArmorSet
{
    public class PalladiumBreastplateOverride : GlobalItem
    {

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.PalladiumBreastplate; 
        public static readonly int MaxHealthIncrease = 40;
        public static readonly int HPRegenIncrease = 1;

        public override void SetDefaults(Item item)
        {
            item.defense = 11;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.statLifeMax2 += MaxHealthIncrease;
            player.lifeRegen += HPRegenIncrease;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.GlobalItems.PalladiumBreastplateOverride.Tooltip");

            tooltips.Add(new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText, MaxHealthIncrease, HPRegenIncrease)));
        }


    }
}