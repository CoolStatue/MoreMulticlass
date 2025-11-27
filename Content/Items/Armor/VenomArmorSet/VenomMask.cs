using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.VenomArmorSet
{
    [AutoloadEquip(EquipType.Head)]
    public class VenomMask : ModItem
    {
        public static readonly int DartDamageIncrease = 35; 
        //TODO has to be implemented as a GlobalProjectile
        public static readonly int DartCritIncrease = 15;
        public static readonly int SetBonusMaxMinionIncrease = 1;

         public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DartDamageIncrease, DartCritIncrease);

        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            // If your head equipment should draw hair while drawn, use one of the following:
            // ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            // ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;

            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(SetBonusMaxMinionIncrease);
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(gold: 20);
            Item.rare = ItemRarityID.Lime;
            Item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MoreMulticlassModPlayer>().hasVenomMask = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<VenomMask>()
                && body.type == ModContent.ItemType<VenomShirt>()
                && legs.type == ModContent.ItemType<VenomPants>() ;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.maxMinions += SetBonusMaxMinionIncrease;
            player.GetModPlayer<MoreMulticlassModPlayer>().hasVenomSet = true;
            // TODO add more of the set bonus
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TikiMask)
                .AddIngredient(ItemID.VialofVenom, 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

    }
}