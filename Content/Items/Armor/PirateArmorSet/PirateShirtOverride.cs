using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PirateArmorSet
{
    public class PirateShirtOverride : GlobalItem
    {
        public static readonly int MaxMinionIncrease = 1;

        public static readonly int RangedDmgIncrease = 8;

        
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.PirateShirt;



        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.ItemTooltips.PirateShirtOverride");

            tooltips.Add(new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText, MaxMinionIncrease, RangedDmgIncrease)));
        }

        public override void SetDefaults(Item item)
        {
            item.defense = 14;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.maxMinions += MaxMinionIncrease;
            player.GetDamage(DamageClass.Ranged) += RangedDmgIncrease / 100f;
            
        }
    }
}
