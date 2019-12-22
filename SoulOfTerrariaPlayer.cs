using Terraria;
using Terraria.ModLoader;

namespace SoulOfTerraria
{
    public class SoulOfTerrariaPlayer : ModPlayer
    {
        public bool amethystHat;
        public float amethystHatBonus;
        public float magicKnockback;
        public float magicSpeed;
        public float magicVelocity;

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
            amethystHat = false;
            magicKnockback = 0f;
            magicSpeed = 0f;
            magicVelocity = 0f;
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
