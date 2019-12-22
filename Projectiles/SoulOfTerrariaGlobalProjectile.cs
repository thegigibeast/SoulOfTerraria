using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Projectiles
{
    public class SoulOfTerrariaGlobalProjectile : GlobalProjectile
    {
        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (projectile.owner == Main.myPlayer)
            {
                var player = Main.player[projectile.owner];
                if (projectile.magic && player.GetModPlayer<SoulOfTerrariaPlayer>().rubySet)
                {
                    for (var i = 0; i < 6; i++)
                    {
                        float speedX = (0f - projectile.velocity.X) * Main.rand.Next(20, 50) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                        float speedY = (0f - Math.Abs(projectile.velocity.Y)) * Main.rand.Next(30, 50) * 0.01f + Main.rand.Next(-20, 5) * 0.4f;
                        Projectile.NewProjectile(projectile.Center.X + speedX, projectile.Center.Y + speedY, speedX, speedY, ProjectileID.MolotovFire + Main.rand.Next(3), (int)(projectile.damage * 0.66), 0f, projectile.owner);
                    }
                }
            }
        }
    }
}
