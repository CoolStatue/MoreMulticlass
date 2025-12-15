using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using MoreMulticlass.Content.Players;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Projectiles;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Terraria.Audio;


public class SlashGlobalItem : GlobalItem
{
    public override bool InstancePerEntity => true;
    public override bool? UseItem(Item item, Player player)
    {
        

        var modPlayer = player.GetModPlayer<MoreMulticlassModPlayer>();

        if (modPlayer.hasNanomachineSet 
            && item.DamageType == DamageClass.Melee 
            // && item.useStyle == ItemUseStyleID.Swing 
            && modPlayer.NanomachineMeleeProjectileCooldown <= 0
            )
        {
            if (player.whoAmI == Main.myPlayer 
                // && player.itemAnimation == player.itemAnimationMax - 1 
                )
            {
                SoundEngine.PlaySound(SoundID.Item71, player.position);
                modPlayer.NanomachineMeleeProjectileCooldown = 20;
                Vector2 velocity = player.DirectionTo(Main.MouseWorld) * 10f;
                Projectile.NewProjectile(
                    player.GetSource_ItemUse(item),
                    player.Center + player.DirectionTo(Main.MouseWorld).SafeNormalize(Vector2.One) * 80f,
                    velocity,
                    ModContent.ProjectileType<NanomachineSetMeleeProjectile>(),
                    (int)(item.damage * 0.2f),
                    item.knockBack,
                    player.whoAmI
                );
            }
        }

        return null;
    }
}
