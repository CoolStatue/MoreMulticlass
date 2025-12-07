using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using System;
using Microsoft.Xna.Framework;

namespace MoreMulticlass.Content.Projectiles
{
    
    public class NanomachineSetWhipProjectile : ModProjectile
    {

        readonly int maxAccelerationframes = 20;
        int currframe = 0;
        Color dust_color = new Color(11.4f, 82.7f, 88.6f); 
        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 150; // lasts 2.5 seconds
            Projectile.DamageType = DamageClass.Summon;
            Projectile.ignoreWater = false;
            
            
        }

        public override void AI()
        {
            
            float gravity = 0.3f;
            // projectile accelerates
            currframe += 1;
            if (currframe <= maxAccelerationframes)
            {
                Projectile.velocity = Projectile.velocity * 1.05f;
            }
            
            Projectile.velocity.Y += gravity;

            
            
            // Add a flashy dust trail
            for (int i = 0; i < 2; i++) // spawns 2 dust every frame
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Cloud,
                    Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 150, dust_color, 1.2f);
            }
            
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            const float elasticity = 0.9f;
            // If the X velocity changed because we hit a vertical wall, invert X
            if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > 0.01f)
            {
                Projectile.velocity.X = -oldVelocity.X * elasticity;
            }

            // If the Y velocity changed because we hit a horizontal surface, invert Y
            if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > 0.01f)
            {
                Projectile.velocity.Y = -oldVelocity.Y * elasticity;
            }

            // Return false to prevent default death behavior (we want it to keep existing)
            return false;
        }



    }
}