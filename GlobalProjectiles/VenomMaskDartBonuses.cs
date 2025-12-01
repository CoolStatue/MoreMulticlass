using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MoreMulticlass.Content.Items.Armor.VenomArmorSet;
using MoreMulticlass.Content.Players;


    public class VenomMaskDartBonuses : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            // Make sure the projectile is from a player
            if (projectile.owner < 0 || projectile.owner >= Main.maxPlayers)
                return;

            Player player = Main.player[projectile.owner];
            var modPlayer = player.GetModPlayer<MoreMulticlassModPlayer>();

            if (modPlayer.hasVenomMask && IsDart(projectile))
            {
                projectile.CritChance += VenomMask.DartCritIncrease;
                projectile.damage = (int)(((100 + VenomMask.DartDamageIncrease) / 100f) * projectile.damage);
            }
            
        }

        public static bool IsDart(Projectile projectile)
        {
            if (projectile.type == ProjectileID.IchorDart
                || projectile.type == ProjectileID.CursedDart
                || projectile.type == ProjectileID.CrystalDart
                || projectile.type == ProjectileID.PoisonDartBlowgun
                || projectile.type == ProjectileID.Seed) 
            {
                return true;
            }
            return false;
        }
    }
