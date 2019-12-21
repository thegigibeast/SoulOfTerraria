using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items
{
    public class SoulOfTerrariaGlobalItem : GlobalItem
    {
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.magic)
            {
                speedX *= 1 + player.GetModPlayer<SoulOfTerrariaPlayer>().magicVelocity;
                speedY *= 1 + player.GetModPlayer<SoulOfTerrariaPlayer>().magicVelocity;

                if (player.GetModPlayer<SoulOfTerrariaPlayer>().amethystHat)
                {
                    player.GetModPlayer<SoulOfTerrariaPlayer>().amethystHatBonus = Main.rand.NextFloat(0.11f, 0.33f);
                }

            }

            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
