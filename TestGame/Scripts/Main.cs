using GameAPI;
using GameAPI.BudgetBoy;
using ResourceLibrary;

namespace Games.TestGame
{
    [GameInfo(
        Title = "TestGame",
        AuthorName = "YourName",
        AuthorContact = "your@email.com",

        UpdateRate = 60
    )]
    [GraphicsInfo(Width = 256, Height = 192)]
    public class Main : Game
    {
        public Swatches Swatches { get; private set; }

        protected override void OnLoadPalette(PaletteBuilder builder)
        {
            Swatches = new Swatches(builder);
        }

        protected override void OnReset()
        {
            SetStage(new GameStage(this));
        }
    }
}
