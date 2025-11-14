using System;
using Humanizer;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MoreMulticlass.Content.Buffs;

namespace MoreMulticlass.Content.Items.Armor.SkeletonVikingArmorSet
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class SkeletonVikingHelmet : ModItem
	{
		public static readonly int RangedCritBonus = 5;



		//ForSetBonus

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(RangedCritBonus);

		public static LocalizedText SetBonusText { get; private set; }

		public override void SetStaticDefaults()
		{
			// If your head equipment should draw hair while drawn, use one of the following:
			// ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
			// ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
			// ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
			// ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;

			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs();
		}

        public override void UpdateEquip(Player player)
        {
			base.UpdateEquip(player);
			
			player.GetCritChance(DamageClass.Ranged) += RangedCritBonus; //Increases player's Ranged Crit Chance 
        }


		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 4; // The amount of defense the item will give when equipped
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<SkeletonVikingBreastplate>() 
				&& legs.type == ModContent.ItemType<SkeletonVikingLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "Increases dealt damage by 20%"

			// player.GetDamage(DamageClass.Ranged) += SetBonusRangedDamageBonus / 100f; // Increase Ranged dmg


			if (player.statLife < player.statLifeMax2 * 0.25f)
            {
				player.AddBuff(ModContent.BuffType<BerserkerRage>(), 2);
            }
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		/*
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.ChumBucket, 10)
				.AddTile(TileID.Anvils)
				.Register();
		}
		*/
	}
}
