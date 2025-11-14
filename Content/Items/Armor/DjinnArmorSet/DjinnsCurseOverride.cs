using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.DjinnArmorSet
{
    public class DjinnsCurseOverride : GlobalItem
    {
       
        
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.DjinnsCurse;



        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.ItemTooltips.PirateShirtOverride");

            tooltips.Add(new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText)));
        }

        public override void SetDefaults(Item item)
        {
            item.defense = 8;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            
            
        }
    }
}
