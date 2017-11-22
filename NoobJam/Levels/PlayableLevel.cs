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
        int tick;
        Texture2D light;
        Player player;

        public PlayableLevel(LevelManager m) : base(m) {
            Add(map = new Map(50, 32));
            map.Load();
            camera = new Camera(this);
            Add(player = new Player(new Vector2(32), map));
            camera.follow = player;
            camera.Zoom = 1.5f;
            tick = 0;
            light = AssetManager.LoadSprite("lightsource");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
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
