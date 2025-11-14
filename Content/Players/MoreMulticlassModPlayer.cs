using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameInput;
using MoreMulticlass;
using Microsoft.Build.Tasks;
using System;

namespace MoreMulticlass.Content.Players
{
    public class MoreMulticlassModPlayer : ModPlayer
    {
        public bool hasWyvernSet;
        public bool hasNanomachineSet;
        public bool hasDjinnSet;
        public int NanomachineMeleeProjectileCooldown = 0;
        public bool summonsApplyMarked;
        private bool dashing;
        private int dashTimer;
        private const int DashDuration = 15; // frames
        private const int DashCooldown = 60; // frames
        //private const int DiagDashDuration = 10; // frames
        //private const int DiagDashCooldown = 180; // frames
        private int dashCooldownTimer;

        private bool touchedGround = true;

        public override void ResetEffects()
        {
            hasWyvernSet = false;
            summonsApplyMarked = false;
            hasNanomachineSet = false;
            hasDjinnSet = false;
            if (NanomachineMeleeProjectileCooldown > 0)
            {
                NanomachineMeleeProjectileCooldown--;
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            // This uses Terraria's built-in armor ability key (default: Z)
            if (hasWyvernSet && dashCooldownTimer == 0 && !dashing &&
                MoreMulticlass.ArmorSetAbility.JustPressed && touchedGround)
            {
                PerformDiagonalDash();
            }
        }

        private void PerformDiagonalDash() // Dash for Wyvern Armor
        {
            dashing = true;
            

            dashTimer = DashDuration;
            dashCooldownTimer = DashCooldown;

            // Determine direction: diagonally based on movement keys
            float dashSpeed = 12f;
            //Vector2 dashDir = Vector2.Zero;
            /*
            if (Player.controlUp && Player.controlRight) dashDir = new Vector2(1, -1);
            else if (Player.controlUp && Player.controlLeft) dashDir = new Vector2(-1, -1);
            else if (Player.controlDown && Player.controlRight) dashDir = new Vector2(1, 1);
            else if (Player.controlDown && Player.controlLeft) dashDir = new Vector2(-1, 1);
            else dashDir = new Vector2(Player.direction, 0); // fallback: horizontal dash
            */
            Vector2 dashDir = new Vector2(Player.direction, -0.5f);

            dashDir.Normalize();
            Player.velocity = dashDir * dashSpeed;

            SoundEngine.PlaySound(SoundID.Item74, Player.position); // dash sound

            touchedGround = false;
        }

        public override void PreUpdateMovement()
        {
            if (dashCooldownTimer > 0)
                dashCooldownTimer--;

            if (dashing)
            {
                dashTimer--;

                if (dashTimer <= 0)
                    dashing = false;
            }
        }

        public override void PostUpdate()
        {
            if (!this.touchedGround)
            {
                this.touchedGround = IsOnGround(Player);
            }
            
        }

        public bool IsOnGround(Player player)
        {
            // Case 1: Resting on a solid tile
            int tileX = (int)(player.Center.X / 16f);
            int tileY = (int)((player.position.Y + player.height + 1) / 16f);
            Tile tileBelow = Framing.GetTileSafely(tileX, tileY);
            bool onSolidTile = tileBelow.HasTile && (Main.tileSolid[tileBelow.TileType] || Main.tileSolidTop[tileBelow.TileType]);

            // Case 2: Attached to a grappling hook
            bool isHooked = player.grapCount > 0;

            // Case 3: On a mount that can stand on ground
            bool onMount = player.mount.Active && !player.mount.Cart;

            // Case 4: On a minecart track
            bool onTrack = player.onTrack;

            // Case 5: Velocity grounded tolerance
            bool velocityStill = Math.Abs(player.velocity.Y) < 0.05f;

            // Combine checks
            return (onSolidTile && velocityStill) || isHooked || onMount || onTrack;
        }

    }
}
