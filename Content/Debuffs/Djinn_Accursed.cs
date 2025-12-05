using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Items.Armor.DjinnArmorSet;

namespace MoreMulticlass.Content.Debuffs
{
    public class Accursed : ModBuff
    {
        public override LocalizedText DisplayName => base.DisplayName.WithFormatArgs();
        public override LocalizedText Description => base.Description.WithFormatArgs();

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false; // show timer


        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            // Emit dust for visual feedback
            int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Cloud, 0, 0, 0, Color.Purple);
            Main.dust[dust].noGravity = true;
            //TODO add particles
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //TODO add particles
            int dust = Dust.NewDust(player.position, player.width, player.height, DustID.Cloud , 0, 0, 0, Color.DarkRed);
            Main.dust[dust].noGravity = true;
            player.GetDamage(DamageClass.Generic) += DjinnHelmet.SetProjDamageBoost / 100f ;
            
        }
    
    }
}