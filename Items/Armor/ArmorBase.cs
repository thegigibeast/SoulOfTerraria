namespace SoulOfTerraria.Items.Armor
{
    public abstract class ArmorBase : ItemBase
    {
        public abstract int Defense { get; }

        public sealed override void SetItemDefaults()
        {
            item.defense = Defense;

            SetArmorDefaults();
        }

        public virtual void SetArmorDefaults() { }
    }
}
