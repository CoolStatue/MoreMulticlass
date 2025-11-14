using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace MoreMulticlass.Content.Projectiles
{
    public class NanomachineSetMeleeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 40; // lasts 2/3 of a second
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            // Rotate to face velocity direction
            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.velocity = new Microsoft.Xna.Framework.Vector2(0f);

            // fade out over time
            Projectile.alpha += 10;
            if (Projectile.alpha > 255)
                Projectile.Kill();
            /*
            // Add a flashy dust trail
            for (int i = 0; i < 2; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.FireworkFountain_Red,
                    Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 150, default, 1.2f);
            }
            */
        }
    }

}
