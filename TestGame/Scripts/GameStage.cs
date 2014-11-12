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
            // create a new Player object and add it to this stage at depth 0
            Player player = Add(new Player(), 0);

            player.Position = new Vector2f(40f, 40f);
        }

        // called when this stage is entered
        protected override void OnEnter()
        {
            Graphics.SetClearColor(Game.Swatches.ClearColor);
            StartCoroutine(SpawnBullets);
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

        IEnumerator SpawnBullets()
        {
            while(true)
            {
                // wait
                yield return Delay(0.5f);

                // spawn bullet
                float PADDING = 10.0f;

                // create a bullet moving downward
                Vector2f bulletPos = new Vector2f(Mathf.Random(PADDING, Graphics.Width - PADDING), Graphics.Height + PADDING);
                Bullet bullet = Add(new Bullet(true), 1);
                bullet.Position = bulletPos;

                // create a bullet moving upward
                bulletPos = new Vector2f(Mathf.Random(PADDING, Graphics.Width - PADDING), -PADDING);
                bullet = Add(new Bullet(false), 1);
                bullet.Position = bulletPos;
            }
        }
    }
}
