using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Map;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Miscellaneous
{
    public class SandstormSummon : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.maxStack = Item.CommonMaxStack;
            Item.value = 0;
            Item.consumable = false;
            Item.useTime = 30;
            Item.useAnimation = 90;
            
        }

        public override void UseAnimation(Player player)
        {
            base.UseAnimation(player);
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Sandstorm.StartSandstorm();
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ItemID.SandBlock, 300)
                .AddIngredient(ItemID.FossilOre, 30)
                .AddIngredient(ItemID.SoulofFlight, 5)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}