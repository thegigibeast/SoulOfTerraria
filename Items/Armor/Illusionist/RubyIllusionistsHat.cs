using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Head)]
    public class RubyIllusionistsHat : ArmorBase
    {
        public override int Defense => 17;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 5);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicHat);
            recipe.AddIngredient(ItemID.Ruby, 15);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
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
            DisplayName.SetDefault("Ruby Illusionist's Hat");
            Tooltip.SetDefault("10% increased magic damage\n9% increased magic critical strike chance\nIncreases maximum mana by 80");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "10% increased casting speed\nMagic projectiles burst into Molotov fragments when destroyed";
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicSpeed += 0.1f;
            player.GetModPlayer<SoulOfTerrariaPlayer>().rubySet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.1f;
            player.magicCrit += 9;
            player.statManaMax2 += 80;
        }
    }
}
