using System;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Bullet : Entity
    {
        public new Main Game { get { return (Main) base.Game; } }

        protected Sprite _sprite;

        float _moveSpeed;

        // constructor
        public Bullet()
        {
            _moveSpeed = Mathf.Random(30.0f, 40.0f);
        }

        // called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);

        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            Image image = graphics.GetImage("Resources", "bullet");
            _sprite = Add(new Sprite(image, Game.Swatches.Bullet), new Vector2i(-image.Width / 2, -image.Height / 2));
        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);

            // change position
            Y -= _moveSpeed * (float)dt;

            // keep player within screen boundary
            CheckBounds();
        }

        void CheckBounds()
        {
            Vector2f gameSize = (Vector2f)Stage.Game.Graphics.Size;
            Vector2f mySize = (Vector2f)_sprite.Size;

            if(Y < -mySize.Y * 0.5f)
            {
                Debug.Log("bullet removed: " + Position);
                Stage.Remove(this); // tell our containing scene to get rid of us when we are fully out of bounds
            }
        }
    }
}
