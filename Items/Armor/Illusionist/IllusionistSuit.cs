using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items.Armor.Illusionist
{
    [AutoloadEquip(EquipType.Body)]
    public class IllusionistSuit : ArmorBase
    {
        public override int Defense => 25;
        public override int Rare => ItemRarityID.Pink;
        public override int Value => Item.sellPrice(gold: 6);

        public override void AddRecipes()
        {
            var recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TuxedoShirt);
            recipe.AddIngredient(ItemID.TuxedoPants);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            drawHands = true;
        }

        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            equipSlot = mod.GetEquipSlot("IllusionistSuit_Legs", EquipType.Legs);
        }

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("15% increased magic damage, casting speed, and movement speed\n100% increased magic pierce");
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.15f;
            player.GetModPlayer<SoulOfTerrariaPlayer>().magicSpeed += 0.15f;
            player.moveSpeed += 0.15f;
            player.GetModPlayer<SoulOfTerrariaPlayer>().illusionistSuit = true;
        }
    }
}
