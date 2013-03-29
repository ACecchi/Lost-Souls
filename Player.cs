using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lost_Souls
{
    class Player
    {
        Vector2 Position;          // Stores player position.
        Texture2D PlayerTexture;   // Stores player sprite.
        Animation PlayerAnimation; // Stores keyframe animation.
        bool SwordAttack;          // Flag for sword attack.
        bool FireBallAttack;       // Flag for fireball attack.
        bool FacingLeft;           // Flag for player direction.
        int WindowWidth;           // Window width for bounding.

    /*************************************************************************************************************************************/

            // Creates player and initializes all member variables.
        public Player(GraphicsDevice device, Vector2 position, Texture2D texture)
        {
                // Set position and texture.
            this.Position = position;
            this.PlayerTexture = texture;

                // Setup player animation.
            this.PlayerAnimation = new Animation();//position);
            this.PlayerAnimation.SetScale = 0.75f;
            this.PlayerAnimation.SetSpriteOrigin = new Vector2(texture.Width / 2, texture.Height / 2);
            this.PlayerAnimation.Stop();

                // Initialize player flags.
            this.SwordAttack = false;
            this.FireBallAttack = false;
            this.FacingLeft = false;

                // Let player class know window dimensions.
            this.WindowWidth = device.Viewport.Width;
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

            // PlayerTexture accessor.
        public Texture2D GetTexture
        {
            get
            {
                Texture2D temp = PlayerTexture;
                return temp;
            }
        }

    /*************************************************************************************************************************************/

            // SwordAttack accessor.
        public bool GetSwordAttack
        {
            get
            {
                bool temp = SwordAttack;
                return temp;
            }
        }

    /*************************************************************************************************************************************/

            // FireBallAttack accessor.
        public bool GetFireBallAttack
        {
            get
            {
                bool temp = FireBallAttack;
                return temp;
            }
        }

    /*************************************************************************************************************************************/

            // FacingLeft accessor.
        public bool GetFacingLeft
        {
            get
            {
                bool temp = FacingLeft;
                return temp;
            }
        }

    /*************************************************************************************************************************************/

            // SwordAttack mutator.
        public bool SetSwordAttack
        {
            set
            {
                this.SwordAttack = value;
            }
        }

    /*************************************************************************************************************************************/

            // FireBallAttack mutator.
        public bool SetFireBallAttack
        {
            set
            {
                this.FireBallAttack = value;
            }
        }

    /*************************************************************************************************************************************/

            // Add sprite to animation cell list.
        public void AddCell(Texture2D cellPicture, int id)
        {
            PlayerAnimation.AddCell(cellPicture, id);
        }

    /*************************************************************************************************************************************/

            // Move player right.
        public void MoveRight()
        {
            FacingLeft = false;
            PlayerAnimation.SetMoveRight();
            PlayerAnimation.Loop(1, 8, 0.7f);
            Position.X += 2.5f;
            
        }

    /*************************************************************************************************************************************/

            // Move player left.
        public void MoveLeft()
        {
            FacingLeft = true;
            PlayerAnimation.SetMoveLeft();
            PlayerAnimation.Loop(1, 8, 0.7f);
            Position.X -= 5.0f;
            
        }

    /*************************************************************************************************************************************/
            
            // Sword attack when facing right.
        public void AttackRight()
        {
            PlayerAnimation.PlayAll(33, 0.7f); 
        }

    /*************************************************************************************************************************************/

            // Sword attack when facing left.
        public void AttackLeft()
        {
            PlayerAnimation.SetMoveLeft();
            PlayerAnimation.PlayAll(33, 0.7f);
        }

    /*************************************************************************************************************************************/

            // Fireball attack when facing right.
        public void FireballRight()
        {
            PlayerAnimation.PlayAll(23, 0.7f);
        }


    /*************************************************************************************************************************************/

            // Fireball attack when facing left.
        public void FireballLeft()
        {
            PlayerAnimation.SetMoveLeft();
            PlayerAnimation.PlayAll(23, 0.7f);
        }

    /*************************************************************************************************************************************/

            // Shows player texture when not moving.
        public void Stop()
        {
            PlayerAnimation.Stop();
            PlayerAnimation.GoToFrame(0);
        }

    /*************************************************************************************************************************************/

            // Updates player animation based on screen boundaries.
        public void Update(GameTime gameTime)
        {
            PlayerAnimation.Update(gameTime);

            if (Position.X < 0) 
                Position.X = 0.0f;

            if (Position.X > WindowWidth)
                Position.X = WindowWidth;
        }

    /*************************************************************************************************************************************/

            // Draws player sprite/animations.
        public void Draw(SpriteBatch batch)
        {
            PlayerAnimation.SetPosition(Position);
            PlayerAnimation.Draw(batch);
        }

    /*************************************************************************************************************************************/

    } // class: Player
} // namespace: Lost_Souls
