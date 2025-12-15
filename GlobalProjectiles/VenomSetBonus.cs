using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using MoreMulticlass.Content.Items.Armor.VenomArmorSet;
using MoreMulticlass.Content.Players;
using MoreMulticlass.Content.Debuffs;
using Microsoft.Xna.Framework;

public class VenomSetBonus : GlobalProjectile
{
    public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (projectile.owner < 0 || projectile.owner >= Main.maxPlayers)
            return;


        if (Main.player[projectile.owner].GetModPlayer<MoreMulticlassModPlayer>().hasVenomSet
            && IsDart(projectile))
        {
            target.AddBuff(ModContent.BuffType<VenomParalysed>(), 
                            5 * 60);   // 5 seconds
        }

        
    }

    public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
    {
        if (projectile.owner < 0 || projectile.owner >= Main.maxPlayers)
            return;
        if (target.HasBuff<VenomParalysed>() && projectile.DamageType == DamageClass.Summon)
        {
            modifiers.DefenseEffectiveness *= 0;
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