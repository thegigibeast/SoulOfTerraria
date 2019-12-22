using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Head)]
    public class AmberIllusionistsHat : ArmorBase
    {
        public override int Defense => 18;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 5, silver: 25);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicHat);
            recipe.AddIngredient(ItemID.Amber, 15);
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
            DisplayName.SetDefault("Amber Illusionist's Hat");
            Tooltip.SetDefault("15% increased magic damage and knockback\nIncreases maximum mana by 90");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Magic attacks have a 30% chance of moving 30% slower but dealing double knockback";
            player.GetModPlayer<SoulOfTerrariaPlayer>().amberSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.15f;
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicKnockback += 0.15f;
            player.statManaMax2 += 90;
        }
    }
}
