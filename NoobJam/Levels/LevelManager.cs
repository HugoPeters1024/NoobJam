using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NoobJam
{
    class LevelManager
    {
        Dictionary<string, Level> levels;
        Level currentLevel;

        public LevelManager()
        {
            levels = new Dictionary<string, Level>();
            levels.Add("menu", new LevelMenu(this));
            levels.Add("play", new PlayableLevel(this));
            levels.Add("editor", new LevelEditor(this));
            currentLevel = levels["play"];
        }


        public void ChangeLevel(string level)
        {
            try
            {
                currentLevel = levels[level];
            }
            catch
            {
                throw new Exception("Unvalid level identifier, check the LevelManager dictionary");
            }
        }

        public void Update(GameTime gameTime)
        {
            currentLevel.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Begin(SpriteSortMode.Deferred,
                           BlendState.AlphaBlend,
                           null,
                           null,
                           null,
                           null,
                           currentLevel.camera.get_transformation(Game1.graphics.GraphicsDevice /*Send the variable that has your graphic device here*/));
            currentLevel.Draw(batch);
            batch.End();
        }


    }
}
