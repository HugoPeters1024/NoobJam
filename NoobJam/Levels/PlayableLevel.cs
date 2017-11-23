using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam {
    class PlayableLevel : Level {

        Map map;
        Texture2D light;
        Player player;
        int tick = 0;

        public PlayableLevel(LevelManager m) : base(m) {
            Add(map = new Map(50, 32));
            camera = new Camera(this);
            Add(player= new Player(new Vector2(64), map));
            map.Load(this, player);
            for (int y=0; y<map.Height; ++y)
                for(int x=0; x<map.Width; ++x)
                    if (!map.Get(x, y))
                        if (Operators.rand.Next(8) == 0)
                            Add(new Collectable(player) { position = new Vector2(x, y)*32 });
            Add(new Exit(player, this) { position = new Vector2(map.Width-1, map.Height-3) * new Vector2(32) });
            camera.follow = player;
            camera.Zoom = 2f;
            light = AssetManager.LoadSprite("lightsource");

        }

        public override void Update(GameTime gameTime)
        {
            if (player.Invincable)
                camera.Zoom += (float)Math.Sin(tick++ / 1f) * 0.02f * player.godtimer/120f;

            if (!player.Alive)
            {
                Manager.ChangeLevel("menu");
                Manager.ResetLevel("play");
            }
            base.Update(gameTime);
        }

        public override void DrawUI(SpriteBatch batch)
        {
            base.DrawUI(batch);
            batch.Draw(Operators.t, new Rectangle(0, Game1.ScreenSize.Y - 128, Game1.ScreenSize.X, 128), Color.Black);
            batch.DrawString(AssetManager.LoadFont("ButtonFont"), "score: " + player.score.ToString(), new Vector2(25, Game1.ScreenSize.Y - 80), Color.White);
            batch.Draw(Operators.t, new Rectangle(20, Game1.ScreenSize.Y - 60, (int)(player.health * 1.5f), 32), new Color((100 - player.health) * 2.55f, player.health * 2.55f, 0));
            batch.DrawString(AssetManager.LoadFont("ButtonFont"), "health: " + player.health.ToString(), new Vector2(25, Game1.ScreenSize.Y - 58), new Color(new Vector3(((100f-player.health)/100f))));
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.End(); // Sets blend state
            BlendState previousState = Game1.graphics.GraphicsDevice.BlendState; // Retrieve it

            BlendState bsSubtract = new BlendState
            {
                ColorSourceBlend = Blend.SourceAlpha,
                ColorDestinationBlend = Blend.One,
                ColorBlendFunction = BlendFunction.ReverseSubtract,
                AlphaSourceBlend = Blend.SourceAlpha,
                AlphaDestinationBlend = Blend.One,
                AlphaBlendFunction = BlendFunction.ReverseSubtract
            };

            batch.Begin(SpriteSortMode.Deferred,
                           bsSubtract,
                           null,
                           null,
                           null,
                           null,
                           camera.get_transformation(Game1.graphics.GraphicsDevice /*Send the variable that has your graphic device here*/));
            //batch.Draw(light, player.position - new Vector2(256), Color.White);
            batch.Draw(light, player.position, null, null, light.Bounds.Center.toVector(), 0.0f, new Vector2(3), Color.White, SpriteEffects.None, 0);
            batch.End();
            batch.Begin(SpriteSortMode.Deferred, previousState); // Re-use it
        }
    }
}
