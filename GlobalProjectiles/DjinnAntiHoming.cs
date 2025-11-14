using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Players;
using MoreMulticlass.Content.Debuffs;

public class DjinnAntiHoming : GlobalProjectile
{
    public override void PostAI(Projectile projectile)
    {

        if (!Main.player[projectile.owner].GetModPlayer<MoreMulticlassModPlayer>().hasDjinnSet)
            return;

        if (projectile.owner != Main.myPlayer)
            return;

        if (!projectile.friendly || projectile.damage <= 0)
            return;

        // Avoid modifying minions, whips, yoyos, etc.
        if (projectile.minion || projectile.sentry || projectile.aiStyle == ProjAIStyleID.Yoyo)
            return;


        float homingRange = 500f;
        float homingStrength = -0.12f;

        NPC target = projectile.FindTargetWithinRange(homingRange);

        if (target != null)
        {
            Vector2 desired = target.Center - projectile.Center;
            desired.Normalize();
            desired *= projectile.velocity.Length();

            // Smooth turning
            projectile.velocity = Vector2.Lerp(projectile.velocity, desired, homingStrength);

        }


        
    }
}