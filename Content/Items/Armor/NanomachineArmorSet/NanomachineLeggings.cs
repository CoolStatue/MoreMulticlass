using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.NanomachineArmorSet
{
    [AutoloadEquip(EquipType.Legs)]
    public class NanomachineLeggings : ModItem
    {
        public static readonly int GenericDmgIncrease = 5;
        public static readonly int MoveSpeedIncrease = 15;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GenericDmgIncrease, MoveSpeedIncrease);

		public static LocalizedText SetBonusText { get; private set; }

        

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 20; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            
            player.GetDamage(DamageClass.Generic) += GenericDmgIncrease / 100f;
            player.moveSpeed += MoveSpeedIncrease / 100f;
        }

        public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Nanites, 150)
                .AddIngredient(ItemID.ChlorophyteBar, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
    }
}