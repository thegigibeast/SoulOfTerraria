using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Head)]
    public class AmethystIllusionistsHat : ArmorBase
    {
        public override int Defense => 10;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 4);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicHat);
            recipe.AddIngredient(ItemID.Amethyst, 15);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
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
            DisplayName.SetDefault("Amethyst Illusionist's Hat");
            Tooltip.SetDefault("11% to 33% increased magic damage and velocity, random with each shot\nIncreases maximum mana by 40");
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<SoulOfTerrariaPlayer>().amethystHat = true;
            player.statManaMax2 += 40;
        }
    }
}
