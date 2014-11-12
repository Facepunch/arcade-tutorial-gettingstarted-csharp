using System.Collections;
using System.Collections.Generic;

using GameAPI;
using GameAPI.BudgetBoy;

namespace Games.TestGame
{
    public class GameStage : Stage
    {
        public new Main Game { get { return (Main) base.Game; } }

        Player _player;
        List<Bullet> _bullets = new List<Bullet>();

        float _elapsedTime;

        // called when this stage is created
        public GameStage(Main game) : base(game)
        {
            // create a new Player object and add it to this stage at depth 0
            _player = Add(new Player(), 0);

            _player.Position = new Vector2f(40f, 40f);
        }

        // called when this stage is entered
        protected override void OnEnter()
        {
            Graphics.SetClearColor(Game.Swatches.ClearColor); // set the background color

            StartCoroutine(SpawnBullets);
        }

        // called each tick
        protected override void OnUpdate()
        {
            base.OnUpdate();

            // keep track of how much time has elapsed this round
            _elapsedTime += (float)Timestep;

            // check collision between player and bullets
            foreach(Bullet bullet in _bullets)
            {
                // check distance from each bullet to the player
                float distSqr = (bullet.Position - _player.Position).LengthSquared;
                if(distSqr < 140.0f)
                {
                    // player's dead, restart game
                    Game.SetStage(new TitleStage(Game));
                }
            }
        }

        // called when this stage is rendered
        protected override void OnRender()
        {
            base.OnRender();

        }

        IEnumerator SpawnBullets()
        {
            while(true)
            {
                // wait
                float delay = Mathf.Max(0.5f - _elapsedTime * 0.01f, 0.05f);
                yield return Delay(delay);

                // spawn bullet
                float PADDING = 10.0f;

                // create a bullet moving downward
                Vector2f bulletPos = new Vector2f(Mathf.Random(PADDING, Graphics.Width - PADDING), Graphics.Height + PADDING);
                AddBullet(bulletPos, true);

                // create a bullet moving upward
                bulletPos = new Vector2f(Mathf.Random(PADDING, Graphics.Width - PADDING), -PADDING);
                AddBullet(bulletPos, false);
            }
        }

        void AddBullet(Vector2f pos, bool movingDownward)
        {
            Bullet bullet = Add(new Bullet(movingDownward, _elapsedTime), 1);
            bullet.Position = pos;

            // save the bullet to our list so we can keep track of it
            _bullets.Add(bullet);
        }

        public void RemoveBullet(Bullet bullet)
        {
            // remove the bullet from our list (we no longer want to keep track of it)
            _bullets.Remove(bullet);

            // remove the bullet from the stage (this destroys it)
            Remove(bullet);
        }
    }
}
