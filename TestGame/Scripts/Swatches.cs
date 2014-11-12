using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Swatches
    {
        public readonly SwatchIndex ClearColor;
        public readonly SwatchIndex Player;

        public Swatches(PaletteBuilder palette)
        {
            ClearColor = palette.Add(0x111111, 0x111111, 0x111111);
            Player = palette.Add(0xcccccc, 0x222222, 0xcc0000);
        }
    }
}
