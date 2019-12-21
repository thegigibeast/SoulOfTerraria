using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Head)]
    public class TopazIllusionistsHat : ArmorBase
    {
        public override int Defense => 11;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 4, silver: 25);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicHat);
            recipe.AddIngredient(ItemID.Topaz, 15);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
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
            DisplayName.SetDefault("Topaz Illusionist's Hat");
            Tooltip.SetDefault("14% increased casting speed and critical strike chance\nIncreases maximum mana by 60");
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicSpeed += 0.14f;
            player.magicCrit += 14;
            player.statManaMax2 += 60;
        }
    }
}
