using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Swatches
    {
        public readonly SwatchIndex ClearColor;
        public readonly SwatchIndex Player;
        public readonly SwatchIndex Bullet;

        public readonly SwatchIndex White;

        public Swatches(PaletteBuilder palette)
        {
            ClearColor = palette.Add(0x111111, 0x111111, 0x111111);
            Player = palette.Add(0xcccccc, 0x222222, 0xcc0000);
            Bullet = palette.Add(0xcc4444, 0x992222, 0xff0000);

            White = palette.Add(0xffffff, 0xffffff, 0xffffff);
        }
    }
}
