using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PirateArmorSet
{
    public class PalmwoodHelmetOverride : GlobalItem
    {
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.PalmWoodHelmet
                && body.type == ItemID.PalmWoodBreastplate
                && legs.type == ItemID.PalmWoodGreaves)
            {
                return "palmwood";
            }
            else
            {
                return "";
            }
        }
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "palmwood")
            {
                player.AddBuff(BuffID.Flipper, 2);
                player.statDefense -= 1;
                player.setBonus = Language.GetTextValue("Mods.MoreMulticlass.ArmorSetBonus.PalmWoodSet");
            }

        }
    }
}