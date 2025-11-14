using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Players;
using MoreMulticlass.Content.Debuffs;

public class MarkedApplyingSummonProjectileGlobalProjectile : GlobalProjectile
{
    public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
    {
        // Make sure the projectile is from a player
        if (projectile.owner < 0 || projectile.owner >= Main.maxPlayers)
            return;

        Player player = Main.player[projectile.owner];
        var modPlayer = player.GetModPlayer<MoreMulticlassModPlayer>();

        // Check: only for summon damage and if the armor set is active
        if (projectile.DamageType == DamageClass.Summon && modPlayer.summonsApplyMarked)
        {
            // Apply your custom debuff
            target.AddBuff(ModContent.BuffType<Marked>(), 150); // 2.5 seconds (60 ticks per second)
        }
    }
}
