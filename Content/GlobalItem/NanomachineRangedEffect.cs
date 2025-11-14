using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using MoreMulticlass.Content.Players;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Projectiles;

public class NanomachineRangedEffectGlobalItem : GlobalItem
{
    public override bool InstancePerEntity => true;

    public override bool? UseItem(Item item, Player player)
    {
        var modPlayer = player.GetModPlayer<MoreMulticlassModPlayer>();

        if (modPlayer.hasNanomachineSet 
            && item.DamageType == DamageClass.Ranged 
            // && item.useStyle == ItemUseStyleID.Swing 
            // && modPlayer.NanomachineMeleeProjectileCooldown <= 0
            )
        {
            if (player.whoAmI == Main.myPlayer 
                // && player.itemAnimation == player.itemAnimationMax - 1 
                )
            {
                // modPlayer.NanomachineMeleeProjectileCooldown = 60;
                Vector2 velocity = player.DirectionTo(Main.MouseWorld);
                Vector2 topBulletOffset = new Vector2(0f, -80f);
                Vector2 bottomBulletOffset = new Vector2(0f, 80f);

                float velocityMult = 10f;

                Projectile.NewProjectile(
                    player.GetSource_ItemUse(item),
                    player.Center + topBulletOffset,
                    (player.Center + topBulletOffset).DirectionTo(Main.MouseWorld) * velocityMult,
                    ProjectileID.NanoBullet,
                    (int)(item.damage * 0.1f),
                    item.knockBack,
                    player.whoAmI
                );

                
                Projectile.NewProjectile(
                    player.GetSource_ItemUse(item),
                    player.Center + bottomBulletOffset,
                    (player.Center + bottomBulletOffset).DirectionTo(Main.MouseWorld) * velocityMult,
                    ProjectileID.NanoBullet,
                    (int)(item.damage * 0.1f),
                    item.knockBack,
                    player.whoAmI
                );
            }
        }

        return null;
    }
}
