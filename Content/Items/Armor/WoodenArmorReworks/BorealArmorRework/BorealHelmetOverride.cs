using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PirateArmorSet
{
    public class BorealHelmetOverride : GlobalItem
    {
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.BorealWoodHelmet
                && body.type == ItemID.BorealWoodBreastplate
                && legs.type == ItemID.BorealWoodGreaves)
            {
                return "boreal";
            }
            else
            {
                return "";
            }
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "boreal")
            {
                player.AddBuff(BuffID.Warmth, 2);
                player.setBonus = Language.GetTextValue("Mods.MoreMulticlass.ArmorSetBonus.BorealWoodSet");
            }

        }
    }
}