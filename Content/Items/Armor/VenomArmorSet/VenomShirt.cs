using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.VenomArmor
{
    public class VenomShirt : ModItem
    {
        public static readonly int MaxMinionIncrease = 1;
        public static readonly int SummonDamageIncrease = 10;
        public static readonly int WhipRangeIncrease = 10;
        
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxMinionIncrease, SummonDamageIncrease, WhipRangeIncrease);

        

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 20); // How many coins the item is worth
            Item.rare = ItemRarityID.Lime; // The rarity of the item
            Item.defense = 17; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += MaxMinionIncrease;
            player.GetDamage(DamageClass.Summon) += SummonDamageIncrease / 100f;
            player.whipRangeMultiplier += WhipRangeIncrease / 100f;
            
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TikiShirt)
                .AddIngredient(ItemID.VialofVenom, 30)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}