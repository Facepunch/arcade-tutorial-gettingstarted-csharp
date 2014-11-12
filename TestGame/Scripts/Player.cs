using System;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class Player : Entity
    {
        public new Main Game { get { return (Main) base.Game; } }

        protected Sprite _sprite;
        Animation _walkAnim;

        float _moveSpeed;
        Axis2 _moveAxis;

        // constructor
        public Player()
        {
            _moveSpeed = 50.0f;
        }

        // called when this entity is added to a stage
        protected override void OnEnterStage(Stage stage)
        {
            base.OnEnterStage(stage);

            _moveAxis = stage.Game.Controls.RightAnalog;
        }

        protected override void OnLoadGraphics(Graphics graphics)
        {
            _walkAnim = graphics.GetAnimation("Resources", "player_#")(0, 1);
            _walkAnim.Period = 0.25f;
            _walkAnim.IsPaused = true;

            Image image = _walkAnim.GetFrame(0);
            _sprite = Add(new Sprite(_walkAnim, Game.Swatches.Player), new Vector2i(-image.Width / 2, -image.Height / 2));
        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);

            // change position
            if(_moveAxis.X.IsPositive)
                X += _moveSpeed * (float)dt;
            else if(_moveAxis.X.IsNegative)
                X -= _moveSpeed * (float)dt;

            if(_moveAxis.Y.IsPositive)
                Y += _moveSpeed * (float)dt;
            else if(_moveAxis.Y.IsNegative)
                Y -= _moveSpeed * (float)dt;

            // start/stop movement animation
            if(_moveAxis.JustBecameZero)
            {
                _walkAnim.Reset();
                _walkAnim.IsPaused = true;
            }
            else if(_moveAxis.JustBecameNonzero)
            {
                _walkAnim.IsPaused = false;
            }

            // flip to face x-axis movement direction
            if(_moveAxis.X.IsPositive)
                _sprite.FlipX = false; // image is already facing to the right
            else if(_moveAxis.X.IsNegative)
                _sprite.FlipX = true;

            // keep player within screen boundary
            CheckBounds();
        }

        void CheckBounds()
        {
            Vector2f gameSize = (Vector2f)Stage.Game.Graphics.Size;
            Vector2f mySize = (Vector2f)_sprite.Size;

            if(X < mySize.X * 0.5f)
                X = mySize.X * 0.5f;
            else if(X > gameSize.X - mySize.X * 0.5f)
                X = gameSize.X - mySize.X * 0.5f;

            if(Y < mySize.Y * 0.5f)
                Y = mySize.Y * 0.5f;
            else if(Y > gameSize.Y - mySize.Y * 0.5f)
                Y = gameSize.Y - mySize.Y * 0.5f;
        }
    }
}
