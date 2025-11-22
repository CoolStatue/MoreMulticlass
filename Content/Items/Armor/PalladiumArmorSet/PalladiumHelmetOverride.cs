using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PalladiumArmorSet
{
    public class PalladiumHelmetOverride : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.PalladiumHelmet; 

        
        public static readonly int HPRegenIncrease = 1;

        public override void SetDefaults(Item item)
        {
            item.defense = 6;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.lifeRegen += HPRegenIncrease;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.GlobalItems.PalladiumHelmetOverride.Tooltip");

            tooltips.Add(new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText, HPRegenIncrease)));
        }
    }

    
}