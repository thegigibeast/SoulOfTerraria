using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SoulOfTerraria
{
    public class SoulOfTerrariaPlayer : ModPlayer
    {
        public bool amberSet;
        public bool amethystHat;
        public float amethystHatBonus;
        public bool illusionistSuit;
        public float magicKnockback;
        public float magicSpeed;
        public float magicVelocity;
        public bool rubySet;

        public override void GetWeaponKnockback(Item item, ref float knockback)
        {
            if (item.magic)
            {
                knockback *= 1 + magicKnockback;
            }
        }

        public override void OnEnterWorld(Player player)
        {
            amethystHatBonus = Main.rand.NextFloat(0.11f, 0.33f);
        }

        public override void ResetEffects()
        {
            amberSet = false;
            amethystHat = false;
            illusionistSuit = false;
            magicKnockback = 0f;
            magicSpeed = 0f;
            magicVelocity = 0f;
            rubySet = false;
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.magic)
            {
                speedX *= 1 + magicVelocity;
                speedY *= 1 + magicVelocity;

                if (amethystHat)
                {
                    amethystHatBonus = Main.rand.NextFloat(0.11f, 0.33f);
                }

                if (amberSet && Main.rand.NextFloat() < 0.3f)
                {
                    speedX *= 0.7f;
                    speedY *= 0.7f;
                    knockBack *= 2;
                }

                if (illusionistSuit)
                {
                    var projIndex = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
                    var projectile = Main.projectile[projIndex];
                    if (projectile.penetrate > 0)
                    {
                        projectile.penetrate *= 2;
                    }

                    return false;
                }
            }

            return base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (amethystHat)
            {
                player.magicDamage += amethystHatBonus;
                magicVelocity += amethystHatBonus;
            }
        }

        public override float UseTimeMultiplier(Item item)
        {
            if (item.magic)
            {
                return base.UseTimeMultiplier(item) * (1 + magicSpeed);
            }

            return base.UseTimeMultiplier(item);
        }
    }
}
