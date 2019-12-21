using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Head)]
    public class DiamondIllusionistsHat : ArmorBase
    {
        public override int Defense => 12;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 5, silver: 50);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicHat);
            recipe.AddIngredient(ItemID.Diamond, 15);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawAltHair = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Illusionist's Hat");
            Tooltip.SetDefault("8% increased magic damage, critical strike chance, knockback, casting speed and velocity\nIncreases maximum mana by 100");
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.08f;
            player.magicCrit += 8;
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicKnockback += 0.08f;
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicSpeed += 0.08f;
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicVelocity += 0.08f;
            player.statManaMax2 += 100;
        }
    }
}
