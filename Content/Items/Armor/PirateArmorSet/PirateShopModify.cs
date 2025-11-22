using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class PirateShopModify : GlobalNPC
{
    public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
    {
        if (npc.type == NPCID.Pirate)
        {
            foreach (var item in items)
            {
                if (item.type == ItemID.PirateHat ||
                    item.type == ItemID.PirateShirt ||
                    item.type == ItemID.PiratePants)
                {
                    item.shopCustomPrice = 150000; // 15 gold
                }
            }
        }
    }
}