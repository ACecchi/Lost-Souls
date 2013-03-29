using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Lost_Souls
{
    class Background
    {
        public Rectangle Size;               // Background size.
        public float Scale;                  // Background scale.
        public Vector2 Position;             // Background position.
        private Texture2D BackgroundTexture; // Background sprite.

    /*************************************************************************************************************************************/

            // Creates background object and intializes member variables.
        public Background()
        {
            this.Size = new Rectangle();
            this.Scale = 1.0f;
            this.Position = new Vector2(0.0f, 0.0f);
            this.BackgroundTexture = null;
        }

    /*************************************************************************************************************************************/

            // Loads the individual background sprite.
        public void LoadContent(ContentManager contentManager, String assetName)
        {
            BackgroundTexture = contentManager.Load<Texture2D>(assetName);
            Size = new Rectangle(0, 0, (int)(BackgroundTexture.Width * Scale), (int)(BackgroundTexture.Height * Scale));
        }

    /*************************************************************************************************************************************/
            
            // Draws the background.
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(BackgroundTexture, Position, new Rectangle(0, 0, BackgroundTexture.Width, BackgroundTexture.Height), 
                       Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

    /*************************************************************************************************************************************/

    } // class: Background
} // namespace: Lost_Souls
