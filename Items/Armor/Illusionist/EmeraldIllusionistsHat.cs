using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Head)]
    public class EmeraldIllusionistsHat : ArmorBase
    {
        public override int Defense => 14;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 4, silver: 75);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicHat);
            recipe.AddIngredient(ItemID.Emerald, 15);
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

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<IllusionistSuit>();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Illusionist's Hat");
            Tooltip.SetDefault("21% increased casting speed and knockback\nIncreases maximum mana by 80");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases jump height and flight time by 21%";
            player.jumpSpeedBoost += 0.504f;
            player.wingTimeMax = (int)(player.wingTimeMax * 1.21f);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicSpeed += 0.21f;
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicKnockback += 0.21f;
            player.statManaMax2 += 80;
        }
    }
}
