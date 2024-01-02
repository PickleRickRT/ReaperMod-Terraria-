using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.CodeAnalysis;

namespace ReaperMod.Projectiles
{
    public class GlaiveProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.netImportant = true; //assure que le projo est sync entre les joueurs
            Projectile.width = 108;
            Projectile.height = 108;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true; // Used for hit cooldown changes in the ai hook
            Projectile.usesOwnerMeleeHitCD = true;
            Projectile.timeLeft = 60;
        }
        
        public override void AI()
        {

            Player player = Main.player[Projectile.owner];

            if (player.active && !player.dead)
            {
                Vector2 targetPosition = player.Center;
                float speed = 10f; // Adjust as needed
                Vector2 moveDirection = targetPosition - Projectile.Center;
                moveDirection.Normalize();
                Projectile.velocity = moveDirection * speed;

                // Face the player
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }
            else
            {
                // If the player is not active or dead, destroy the projectile
                Projectile.Kill();
            }         
            

        }
    }
}
