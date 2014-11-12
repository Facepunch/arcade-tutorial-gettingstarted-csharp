using System;
using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Player : Entity
    {
        public new Main Game { get { return (Main) base.Game; } }

        protected Sprite _sprite;

        // constructor
        public Player()
        {

        }

        // called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);

        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            Image image = graphics.GetImage("Resources", "player");

            // add a Sprite to this Entity, it will be automatically rendered when this entity is
            // set it's offset such that it's centered
            _sprite = Add(new Sprite(image, Game.Swatches.Player), new Vector2i(-image.Width / 2, -image.Height / 2));
        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);

        }
    }
}
