using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.DjinnArmorSet
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting a X_Body.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class DjinnHelmet : ModItem
	{


        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs();

        
        
        public static LocalizedText SetBonusText { get; private set; }

        public static readonly int SetProjDamageBoost = 50; // no longer projectile exclusive
		public override void SetStaticDefaults()
		{
			// If your head equipment should draw hair while drawn, use one of the following:
			// ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
			// ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
			// ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
			// ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;

			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(SetProjDamageBoost);
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 5; // The amount of defense the item will give when equipped
		}

        public override void UpdateEquip(Player player)
        {
            // player.buffImmune[BuffID.Bleeding] = true; // Make the player immune to Bleeding

        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<DjinnBreastplate>() 
				&& legs.type == ItemID.DjinnsCurse;
		}
		
		public override void UpdateArmorSet(Player player) {
            player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: 
            player.GetModPlayer<MoreMulticlassModPlayer>().hasDjinnSet = true;
            player.GetModPlayer<MoreMulticlassModPlayer>().DjinnArmorSetProjDmgBonus = SetProjDamageBoost;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.SoulofNight, 8)
				.AddIngredient(ItemID.DarkShard, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
        
	}
}
