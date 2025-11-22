using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PirateArmorSet
{
    public class PiratePantsOverride : GlobalItem
    {
        public static readonly int MaxMinionIncrease = 1;
        public static readonly int MoveSpeedBonus = 7;

        
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.PiratePants;



        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.GlobalItems.PiratePantsOverride.Tooltip");

            tooltips.Add(new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText, MaxMinionIncrease, MoveSpeedBonus)));
        }

        public override void SetDefaults(Item item)
        {
            item.defense = 8;
            item.vanity = false;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.maxMinions += MaxMinionIncrease;
            player.moveSpeed += MoveSpeedBonus / 100f;
            // TODO figure out how to implement ammo conservation
            
        }
    }
}
