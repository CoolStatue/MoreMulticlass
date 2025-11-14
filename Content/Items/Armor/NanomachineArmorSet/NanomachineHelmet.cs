using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;



namespace MoreMulticlass.Content.Items.Armor.NanomachineArmorSet
{
    [AutoloadEquip(EquipType.Head)]

    public class NanomachineHelmet : ModItem
    {
        public static readonly int GenericDmgIncrease = 3;
        public static readonly int GenericCritIncrease = 3;
        public static readonly int MaxMinionIncrease = 1;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GenericDmgIncrease, GenericCritIncrease, MaxMinionIncrease);

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

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 18; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += MaxMinionIncrease;
            player.GetDamage(DamageClass.Generic) += GenericDmgIncrease / 100f;
            player.GetCritChance(DamageClass.Generic) += GenericCritIncrease; //Increases player's Ranged Crit Chance 
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<NanomachineBreastplate>() 
				&& legs.type == ModContent.ItemType<NanomachineLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "Increases dealt damage by 20%"
            player.GetModPlayer<MoreMulticlassModPlayer>().hasNanomachineSet = true;
			
		}

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Nanites, 100)
                .AddIngredient(ItemID.ChlorophyteBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

    }
}

