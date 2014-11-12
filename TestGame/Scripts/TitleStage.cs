using System.Collections;
using System.Collections.Generic;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class TitleStage : Stage
    {
        public new Main Game { get { return (Main) base.Game; } }

        // called when this stage is created
        public TitleStage(Main game) : base(game)
        {

        }

        // called when this stage is entered
        protected override void OnEnter()
        {
            Graphics.SetClearColor(Game.Swatches.ClearColor); // set the background color

            // get the bitmap font resource
            Image font = Graphics.GetImage("Resources", "font");
            int TEXT_DEPTH = 0;

            // create and add text to the stage for the game's title
            Text titleText = Add(new Text(font, Game.Swatches.White), TEXT_DEPTH);
            titleText.Value = "TEST GAME";
            titleText.Position = Graphics.Size / 2 + new Vector2i(-titleText.Width / 2, 30);

            // create and add text to the stage for the game's instructions
            Text instructionText = Add(new Text(font, Game.Swatches.White), TEXT_DEPTH);
            instructionText.Value = "press A to start";
            instructionText.Position = Graphics.Size / 2 + new Vector2i(-instructionText.Width / 2, -30);
        }

        // called each tick
        protected override void OnUpdate()
        {
            base.OnUpdate();

            // start the game when the A button is pressed (not actually the "A" key on the keyboard, defaults to Z)
            if(Controls.A.JustPressed)
                Game.SetStage(new GameStage(Game));
        }

        // called when this stage is rendered
        protected override void OnRender()
        {
            base.OnRender();

        }
    }
}
