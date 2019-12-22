using Terraria;
using Terraria.ModLoader;

namespace SoulOfTerraria
{
	public class SoulOfTerraria : Mod
	{
		public SoulOfTerraria()
		{
		}

        public override void Load()
        {
            if (!Main.dedServ)
            {
                AddEquipTexture(null, EquipType.Legs, "IllusionistSuit_Legs", "SoulOfTerraria/Items/Armor/Illusionist/IllusionistSuit_Legs");
            }
        }
    }
}