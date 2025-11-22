using Terraria;
using Terraria.ID;
using MoreMulticlass.Content.Items.Miscellaneous;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.ModSystems
{
    public class MoreMulticlassRecipeGroups : ModSystem
    {
        public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.PlatinumBar, ItemID.GoldBar);
			RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), group);
		}

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.GladiatorLeggings, 1);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 16);
            recipe.AddIngredient(ModContent.ItemType<HopliteArmorShard>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = Recipe.Create(ItemID.GladiatorBreastplate, 1);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 20);
            recipe.AddIngredient(ModContent.ItemType<HopliteArmorShard>(), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            
            recipe = Recipe.Create(ItemID.GladiatorHelmet, 1);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 14);
            recipe.AddIngredient(ModContent.ItemType<HopliteArmorShard>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }
}