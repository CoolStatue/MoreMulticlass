using System.Collections.Generic;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.DjinnArmorSet
{
    public class DjinnsCurseOverride : GlobalItem
    {
       
        
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.DjinnsCurse;



        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // Only affect Iron Helmet
            if (item.type != ItemID.DjinnsCurse)
                return;

            // Find the vanilla tooltip line
            TooltipLine vanillaLine = tooltips.Find(
                t => t.Mod == "Terraria" && t.Name == "Tooltip0"
            );

            // Remove it if found
            if (vanillaLine != null)
                tooltips.Remove(vanillaLine);


            string tooltipText = Language.GetTextValue("Mods.MoreMulticlass.GlobalItems.DjinnsCurseOverride.Tooltip");

            tooltips.Add(new TooltipLine(Mod, "Buffed",
                string.Format(tooltipText)));
        }

        public override void SetDefaults(Item item)
        {
            item.defense = 8;
            item.vanity = false;
        }

        public override void UpdateEquip(Item item, Player player)
        {
            player.GetModPlayer<MoreMulticlassModPlayer>().hasDjinnsCurse = true;

        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.DjinnsCurse, 1)
                .AddIngredient(ItemID.SoulofNight, 8)
                .AddIngredient(ItemID.SoulofFlight, 8)
                .AddIngredient(ItemID.DarkShard, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
