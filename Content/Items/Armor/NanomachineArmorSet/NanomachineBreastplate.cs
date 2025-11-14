using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.NanomachineArmorSet
{
    [AutoloadEquip(EquipType.Body)]
    public class NanomachineBreastplate : ModItem
    {
        public static readonly int GenericDmgIncrease = 7;
        public static readonly int GenericCritIncrease = 5;
        public static readonly int MaxManaIncrease = 60;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GenericDmgIncrease, GenericCritIncrease, MaxManaIncrease);

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
            player.statManaMax2 += MaxManaIncrease;
            player.GetDamage(DamageClass.Generic) += GenericDmgIncrease / 100f;
			player.GetCritChance(DamageClass.Generic) += GenericCritIncrease; //Increases player's Ranged Crit Chance 
        }

        public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Nanites, 200)
                .AddIngredient(ItemID.ChlorophyteBar, 20)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

    }
}