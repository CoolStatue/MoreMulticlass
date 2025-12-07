using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using MoreMulticlass.Content.Players;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Projectiles;
using Terraria.DataStructures;
using System;

public class NanomachineWhipEffect : GlobalProjectile
{
    public override bool InstancePerEntity => true;

    public override void OnSpawn(Projectile projectile, IEntitySource source)
    {
        if (projectile.owner < 0 || projectile.owner >= Main.maxPlayers)
            return;

        Player player = Main.player[projectile.owner];
        var modPlayer = player.GetModPlayer<MoreMulticlassModPlayer>();






        if (modPlayer.hasNanomachineSet &&
            projectile.DamageType == DamageClass.SummonMeleeSpeed)
        {
            Vector2 randomDirection;
            for (int i = 0; i < 5; i++) // spawn 5 projectiles every swing
            {
                
                randomDirection = Main.rand.NextVector2Unit(); // re-randomize
                randomDirection = Vector2.Normalize(randomDirection); // re-normalize
                Projectile.NewProjectile(
                    projectile.GetSource_Death(),
                    projectile.Center + new Vector2(projectile.width / 2, projectile.height / 2),
                    randomDirection,
                    ModContent.ProjectileType<NanomachineSetWhipProjectile>(),
                    Math.Max(
                        (int)(projectile.damage * 0.05), // total of +25% dmg from 5 projectiles
                        2
                    ),
                    0f,
                    projectile.owner
                );   
            }
            


            
        }
        
    }

}