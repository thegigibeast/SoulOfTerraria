using Terraria.ID;
using Terraria.ModLoader;

namespace SoulOfTerraria.Items
{
    public abstract class ItemBase : ModItem
    {
        public virtual int Rare => ItemRarityID.White;
        public virtual int Value => 0;

        public sealed override void SetDefaults()
        {
            var texture = mod.GetTexture(Texture.Remove(0, mod.Name.Length + 1));

            item.height = texture.Height;
            item.rare = Rare;
            item.value = Value;
            item.width = texture.Width;

            SetItemDefaults();
        }

        public virtual void SetItemDefaults() { }
    }
}
