using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MoreMulticlass.Content.Buffs;
using MoreMulticlass.Content.Items.Miscellaneous;

namespace MoreMulticlass.Content.Items.Armor.SkeletonVikingArmorSet
{
    public class SkeletonVikingHelmetOverride : GlobalItem
    {

        public static readonly int RangedCritBonus = 5;

        

		// public static LocalizedText SetBonusText { get; private set; }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {

            int lastTooltip = tooltips.FindLastIndex(
                t => t.Mod == "Terraria" && t.Name.StartsWith("Defense")
            );

            

            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.GlobalItems.SkeletonVikingHelmetOverride.Tooltip");

            // tooltips.Add(new TooltipLine(Mod, "Buffed",
            //     string.Format(tooltipText, RangedCritBonus)));

            tooltips.Insert(lastTooltip + 1, new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText, RangedCritBonus)));
        }

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ItemID.VikingHelmet;
        }

        public override void SetDefaults(Item item)
        {
            item.width = 18; // Width of the item
            item.height = 18; // Height of the item
            item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            item.rare = ItemRarityID.Green; // The rarity of the item
            item.defense = 4;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetCritChance(DamageClass.Ranged) += RangedCritBonus; //Increases player's Ranged Crit Chance 

        }

        public override string IsArmorSet(Item head, Item body, Item legs)
        {   
            if (head.type == ItemID.VikingHelmet
                && body.type == ModContent.ItemType<SkeletonVikingBreastplate>()
                && legs.type == ModContent.ItemType<SkeletonVikingLeggings>())
            {
                
                return "skeleton viking set";
            }
            return "";
        }
        
        public override void UpdateArmorSet(Player player, string str)
        {
            
            if (str == "skeleton viking set")
            {
                
                // player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "Increases dealt damage by 20%"
                // player.statLifeMax2 += 400; // TODO MAKE THE ACTUAL SET BONUS
                
                
                if (player.statLife < player.statLifeMax2 * 0.25f)
                {
                    
                    player.AddBuff(ModContent.BuffType<BerserkerRage>(), 2);
                   
                }

                player.setBonus = Language.GetTextValue("Mods.MoreMulticlass.ArmorSetBonus.SkeletonVikingSet");
                
            }
        }
        
        public override void AddRecipes() {
			Recipe recipe = Recipe.Create(ItemID.VikingHelmet)
				.AddIngredient(ModContent.ItemType<VikingArmorShard>(), 2)
				.AddIngredient(ItemID.IronBar, 10)
				.AddTile(TileID.Anvils)
				.Register();

			recipe = Recipe.Create(ItemID.VikingHelmet)
				.AddIngredient(ModContent.ItemType<VikingArmorShard>(), 2)
				.AddIngredient(ItemID.LeadBar, 10)
				.AddTile(TileID.Anvils)
				.Register();
		}

    }
}