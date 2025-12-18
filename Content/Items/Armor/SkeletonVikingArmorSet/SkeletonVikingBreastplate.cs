using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MoreMulticlass.Content.Items.Miscellaneous;

namespace MoreMulticlass.Content.Items.Armor.SkeletonVikingArmorSet
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting a X_Body.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class SkeletonVikingBreastplate : ModItem
	{
		public static readonly int MeleeDamageIncrease = 5;
		

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MeleeDamageIncrease );

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 5; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.Chilled] = true; // Make the player immune to Chilled

			player.GetDamage(DamageClass.Melee) += MeleeDamageIncrease / 100f; // Melee Damage buff
		}
		
		

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<VikingArmorShard>(), 4)
				.AddIngredient(ItemID.IronBar, 20)
				.AddTile(TileID.Anvils)
				.Register();

			CreateRecipe()
				.AddIngredient(ModContent.ItemType<VikingArmorShard>(), 4)
				.AddIngredient(ItemID.LeadBar, 20)
				.AddTile(TileID.Anvils)
				.Register();
		}


	}
}
