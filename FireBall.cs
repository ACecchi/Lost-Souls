using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lost_Souls
{
    class FireBall
    {
        Vector2 Position;             // Stores fireball position.
        Texture2D Picture;            // Stores fireball sprite.
        float Speed;                  // Movement speed.
        SpriteEffects SpriteEffects;  // Animation options.

    /*************************************************************************************************************************************/

            // Creates fireball and initialize all member variables.
        public FireBall(Texture2D firePicture, Vector2 startPosition, float updateSpeed)
        {
            this.Position = startPosition;
            this.Picture = firePicture;
            this.Speed = updateSpeed;
            this.SpriteEffects = SpriteEffects.None;
        }

    /*************************************************************************************************************************************/

            // Position accessor.
        public Vector2 GetPosition
        {
            get
            {
                Vector2 temp = Position;
                return temp;
            }
        }

    /*************************************************************************************************************************************/

        public void SetMoveLeft()
        {
            SpriteEffects = SpriteEffects.FlipHorizontally;
        }

    /*************************************************************************************************************************************/

        public void SetMoveRight()
        {
            SpriteEffects = SpriteEffects.None;
        }

    /*************************************************************************************************************************************/

            // Update fireball position.
        public void Update(GameTime gameTime)
        {
            Position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    /*************************************************************************************************************************************/

            // Draw the fireball
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Picture, Position, null, Color.White, 0.0f, new Vector2(10.0f, 10.0f), 0.6f, SpriteEffects, 1.0f);
        }

    /*************************************************************************************************************************************/

    } // class: FireBall
} // namespace: Lost_Souls
