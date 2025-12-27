using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Players;
using MoreMulticlass.Content.Debuffs;
using Terraria.Audio;

public class NanomachineMageEffect : GlobalProjectile
{

    public override void OnKill(Projectile projectile, int timeLeft)
    {
        // Make sure the projectile is from a player
        if (projectile.owner < 0 || projectile.owner >= Main.maxPlayers)
            return;

        Player player = Main.player[projectile.owner];
        var modPlayer = player.GetModPlayer<MoreMulticlassModPlayer>();

        if (projectile.DamageType == DamageClass.Magic && modPlayer.hasNanomachineSet)
        {
            Projectile.NewProjectile(
                projectile.GetSource_Death(),
                projectile.Center,
                new Vector2(0f),  // new projectile velocity
                ProjectileID.Electrosphere,        // the projectile to spawn
                projectile.damage / 5,        // 0.2f the damage
                0f, //no knockback
                projectile.owner
            );

            SoundEngine.PlaySound(SoundID.Item94, projectile.Center);
        }

    }
}