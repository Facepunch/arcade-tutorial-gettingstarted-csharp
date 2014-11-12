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

        bool _isMovingDownward;

        // constructor
        public Bullet(bool movingDownward, float elapsedTime)
        {
            // the longer the round goes, the faster bullets can go
            float maxSpeed = Mathf.Min(40.0f + (elapsedTime * 1.5f), 400.0f);

            _moveSpeed = Mathf.Random(40.0f, maxSpeed);
            _isMovingDownward = movingDownward;
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

            if(!_isMovingDownward)
                _sprite.FlipY = true;
        }

        protected override void OnUpdate(double dt)
        {
            base.OnUpdate(dt);

            // change position
            if(_isMovingDownward)
                Y -= _moveSpeed * (float)dt;
            else
                Y += _moveSpeed * (float)dt;

            // keep player within screen boundary
            CheckBounds();
        }

        void CheckBounds()
        {
            Vector2f gameSize = (Vector2f)Stage.Game.Graphics.Size;
            Vector2f mySize = (Vector2f)_sprite.Size;

            // tell our containing scene to get rid of us when we are fully out of bounds
            if(_isMovingDownward && Y < -mySize.Y * 0.5f)
                ((GameStage)Stage).RemoveBullet(this); // need to cast our Stage to the GameStage subclass to use GameStage-specific methods
            else if(!_isMovingDownward && Y > gameSize.Y + mySize.Y * 0.5f)
                ((GameStage)Stage).RemoveBullet(this);
        }
    }
}
