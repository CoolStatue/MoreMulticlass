using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MoreMulticlass.Content.Buffs
{
    public class BerserkerRage : ModBuff
    {
        public override LocalizedText DisplayName => base.DisplayName.WithFormatArgs();
        public override LocalizedText Description => base.Description.WithFormatArgs();

        public static readonly int RangedDamageBonus = 20;
        public static readonly int MeleeDamageBonus = 20;
        


        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = true; // hide timer


        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Ranged) += RangedDamageBonus / 100f;
            player.GetDamage(DamageClass.Melee) += MeleeDamageBonus / 100f;

            if (Main.rand.NextBool(4))
            {
                Vector2 position = player.Center + new Vector2(
                    Main.rand.NextFloat(-player.width / 2f, player.width / 2f),
                    Main.rand.NextFloat(-player.height / 2f, player.height / 2f)
                );

                int dust = Dust.NewDust(
                    position,
                    0, 0,
                    DustID.Blood,      // red/orange fire dust
                    0f, 0f,           // initial velocity
                    150,              // alpha (transparency)
                    default,          // color override (none)
                    1.2f              // scale
                );

                Main.dust[dust].noGravity = true; // floaty effect
                Main.dust[dust].velocity *= 0.5f; // gentle movement
                Main.dust[dust].color = Color.Red; // make sure it's red


            }
        }
    }
}