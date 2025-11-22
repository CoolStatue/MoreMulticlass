using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PalladiumArmorSet
{
    public class MyRecipeChanges : ModSystem
{
    public override void PostAddRecipes()
    {
        foreach (Recipe recipe in Main.recipe)
        {
            if (recipe.createItem.type == ItemID.PalladiumBreastplate 
                || recipe.createItem.type == ItemID.PalladiumLeggings
                || recipe.createItem.type == ItemID.PalladiumMask
                || recipe.createItem.type == ItemID.PalladiumHelmet
                || recipe.createItem.type == ItemID.PalladiumHeadgear)
            {
                // Remove recipe
                recipe.DisableRecipe();
            }
            
        }

        //Create our new recipes

        Recipe newRecipe = Recipe.Create(ItemID.PalladiumBreastplate, 1);
        newRecipe.AddIngredient(ItemID.PalladiumBar, 40);
        newRecipe.AddTile(TileID.Anvils);
        newRecipe.Register();

        newRecipe = Recipe.Create(ItemID.PalladiumLeggings, 1);
        newRecipe.AddIngredient(ItemID.PalladiumBar, 30);
        newRecipe.AddTile(TileID.Anvils);
        newRecipe.Register();

        newRecipe = Recipe.Create(ItemID.PalladiumMask, 1);
        newRecipe.AddIngredient(ItemID.PalladiumBar, 20);
        newRecipe.AddTile(TileID.Anvils);
        newRecipe.Register();

        newRecipe = Recipe.Create(ItemID.PalladiumHeadgear, 1);
        newRecipe.AddIngredient(ItemID.PalladiumBar, 20);
        newRecipe.AddTile(TileID.Anvils);
        newRecipe.Register();

        newRecipe = Recipe.Create(ItemID.PalladiumHelmet, 1);
        newRecipe.AddIngredient(ItemID.PalladiumBar, 20);
        newRecipe.AddTile(TileID.Anvils);
        newRecipe.Register();
    }
}

}