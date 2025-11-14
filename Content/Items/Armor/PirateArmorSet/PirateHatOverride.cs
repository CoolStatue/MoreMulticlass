using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PirateArmorSet
{
    public class PirateHatOverride : GlobalItem
    {
        public static readonly int SummonDamageIncrease = 13;
        public static readonly int RangedCritIncrease = 13;

        
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.PirateHat;



        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.ItemTooltips.PirateHatOverride");

            tooltips.Add(new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText, SummonDamageIncrease, RangedCritIncrease)));
        }

        public override void SetDefaults(Item item)
        {
            item.defense = 3;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetDamage(DamageClass.Summon) += SummonDamageIncrease / 100f;
            player.GetCritChance(DamageClass.Ranged) += RangedCritIncrease;
            // TODO figure out how to implement ammo conservation

        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (body.type == ItemID.PirateShirt
                && legs.type == ItemID.PiratePants)
            {
                return "pirate set";
            }
            return "";
        }
        
        public override void UpdateArmorSet(Player player, string str)
        {
            if (str == "pirate set")
            {
                // player.statLifeMax2 += 400; // TODO MAKE THE ACTUAL SET BONUS

                player.GetModPlayer<MoreMulticlassModPlayer>().summonsApplyMarked = true;
            }
        }

    }
}
