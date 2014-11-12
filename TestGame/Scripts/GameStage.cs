using System.Collections;
using System.Collections.Generic;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class GameStage : Stage
    {
        public new Main Game { get { return (Main) base.Game; } }

        // called when this stage is created
        public GameStage(Main game) : base(game)
        {
            Debug.Log("GameStage constructed");

            Player player = Add(new Player(), 0);
            player.Position = new Vector2f(40f, 40f);
        }

        // called when this stage is entered
        protected override void OnEnter()
        {
            Debug.Log("GameStage entered");

            Graphics.SetClearColor(Game.Swatches.ClearColor);
        }

        // called each tick
        protected override void OnUpdate()
        {
            base.OnUpdate();

        }

        // called when this stage is rendered
        protected override void OnRender()
        {
            base.OnRender();

        }
    }
}
