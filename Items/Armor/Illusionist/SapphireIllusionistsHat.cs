using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Head)]
    public class SapphireIllusionistsHat : ArmorBase
    {
        public override int Defense => 15;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 4, silver: 50);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicHat);
            recipe.AddIngredient(ItemID.Sapphire, 15);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
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
            DisplayName.SetDefault("Sapphire Illusionist's Hat");
            Tooltip.SetDefault("25% increased magic velocity\n12% increased magic critical strike chance\nIncreases maximum mana by 60");
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicVelocity += 0.25f;
            player.magicCrit += 12;
            player.statManaMax2 += 60;
        }
    }
}
