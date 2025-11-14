using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using MoreMulticlass.Content.Players;
using Microsoft.Xna.Framework;
using MoreMulticlass.Content.Projectiles;


public class SlashGlobalItem : GlobalItem
{
    public override bool InstancePerEntity => true;
    public override bool? UseItem(Item item, Player player)
    {
        

        var modPlayer = player.GetModPlayer<MoreMulticlassModPlayer>();

        if (modPlayer.hasNanomachineSet 
            && item.DamageType == DamageClass.Melee 
            // && item.useStyle == ItemUseStyleID.Swing 
            && modPlayer.NanomachineMeleeProjectileCooldown <= 0
            )
        {
            if (player.whoAmI == Main.myPlayer 
                // && player.itemAnimation == player.itemAnimationMax - 1 
                )
            {
                modPlayer.NanomachineMeleeProjectileCooldown = 20;
                Vector2 velocity = player.DirectionTo(Main.MouseWorld) * 10f;
                Projectile.NewProjectile(
                    player.GetSource_ItemUse(item),
                    player.Center + new Vector2(player.direction, 0f) * 40f,
                    velocity,
                    ModContent.ProjectileType<NanomachineSetMeleeProjectile>(),
                    (int)(item.damage * 1.2f),
                    item.knockBack,
                    player.whoAmI
                );
            }
        }

        return null;
    }
}
