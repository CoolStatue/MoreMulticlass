using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using MoreMulticlass.Content.Items.Miscellaneous;


namespace MoreMulticlass.GlobalNPCs
{
    public class ArmorShardDropGlobalNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.GreekSkeleton)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HopliteArmorShard>(), 1, 1, 2)); 
                // 100% chance to drop 1-2 shards
            }

            if (npc.type == NPCID.UndeadViking)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingArmorShard>(), 1, 1, 2));
            }
            
            if (npc.type == NPCID.IceBat
                || npc.type == NPCID.SnowFlinx)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VikingArmorShard>(), 4, 1, 2));
            }
        }
    }
}