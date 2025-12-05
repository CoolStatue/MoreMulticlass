using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Players;
using MoreMulticlass.Content.Debuffs;
using Terraria.DataStructures;

public class ChummyArmorWeakHoming : GlobalProjectile
{
    /*
    // code for changing damage of projectiles themselves, not needed
    public override void OnSpawn(Projectile projectile, IEntitySource source)
    {
        if (projectile.owner != Main.myPlayer)
            return;
            
        if (!Main.player[projectile.owner].GetModPlayer<MoreMulticlassModPlayer>().hasChummySet)
            return;

        if (!projectile.friendly || projectile.damage <= 0)
            return;

        // Avoid modifying minions, whips, yoyos, etc.
        if (projectile.minion || projectile.sentry || projectile.aiStyle == ProjAIStyleID.Yoyo
            || projectile.aiStyle == ProjAIStyleID.Spear || projectile.aiStyle == ProjAIStyleID.ShortSword)
            return;

    }
    */
    public override void PostAI(Projectile projectile)
    {



        if (projectile.owner != Main.myPlayer)
            return;

        if (!Main.player[projectile.owner].GetModPlayer<MoreMulticlassModPlayer>().hasChummySet)
            return;

        if (!projectile.friendly || projectile.damage <= 0)
            return;
        if (projectile.minion || projectile.sentry || projectile.aiStyle == ProjAIStyleID.Yoyo
            || projectile.aiStyle == ProjAIStyleID.Spear || projectile.aiStyle == ProjAIStyleID.ShortSword)
            return;


        

        // Avoid modifying minions, whips, yoyos, etc.
        if (projectile.minion || projectile.sentry || projectile.aiStyle == ProjAIStyleID.Yoyo
            || projectile.aiStyle == ProjAIStyleID.Spear || projectile.aiStyle == ProjAIStyleID.ShortSword)
            return;

        

        float homingRange = 100f;
        float homingStrength = 0.1f;

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