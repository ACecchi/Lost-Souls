using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Lost_Souls
{
    class Zombie
    {
        Vector2 Position;         // Stores enemy position.
        Animation EnemyAnimation; // Stores keyframe animation.
        bool FacingLeft;          // Flag for enemy direction.
        float Speed;              // Enemy movement speed.
        float Radius;             // Bounding circle radius.
        int WindowWidth;          // Stores screen width.

    /*************************************************************************************************************************************/

        public Zombie(GraphicsDevice device, Vector2 startPosition, Animation anim, float speed)
        {
                // Set position
            this.Position = startPosition;

                // Setup enemy animation.
            this.EnemyAnimation = anim; // new Animation(startPosition);
            this.EnemyAnimation.SetScale = 0.65f;

                // Let enemy class know window dimensions.
            this.WindowWidth = device.Viewport.Width;
            //this.WindowHeight = device.Viewport.Height;

            this.Speed = speed;
            this.Radius = 55.0f;
        }

    /*************************************************************************************************************************************/

            // Position accessor.
        //public Vector2 GetPosition
        //{
        //    get
        //    {
        //        Vector2 temp = Position;
        //        return temp;
        //    }
        //}

    /*************************************************************************************************************************************/

            // FacingLeft accessor.
        //public bool GetFacingLeft
        //{
        //    get
        //    {
        //        bool temp = FacingLeft;
        //        return temp;
        //    }
        //}

    /*************************************************************************************************************************************/

            // FacingLeft mutator.
        //public bool SetFacingLeft
        //{
        //    set
        //    {
        //        this.FacingLeft = value;
        //    }
        //}

    /*************************************************************************************************************************************/

            // Radius accessor.
        public float GetRadius
        {
            get
            {
                float temp = Radius;
                return temp;
            }
        }

    /*************************************************************************************************************************************/
   
            // Add sprite to animation cell list.
        public void AddCell(Texture2D cellPicture, int id)
        {
            EnemyAnimation.AddCell(cellPicture, id);
        }

    /*************************************************************************************************************************************/

            // Set enemy moving left.
        public void SetMovementLeft()
        {
            FacingLeft = true;
            EnemyAnimation.SetMoveLeft();
            EnemyAnimation.LoopAll(0.7f);
        }

    /*************************************************************************************************************************************/

            // Set enemy moving right.
        public void SetMovementRight()
        {
            FacingLeft = false;
            EnemyAnimation.SetMoveRight();
            EnemyAnimation.LoopAll(0.7f);
        }

    /*************************************************************************************************************************************/

            // If hit by fireball, return the fireball index.
        public int CollisionFireBall(List<FireBall> fireballs)
        {
            for (int idx = 0; idx < fireballs.Count; ++idx)
            {
                if ((fireballs[idx].GetPosition - Position).Length() < Radius)
                    return idx;
            }

            return -1;
        }

        /*************************************************************************************************************************************/

        // Update enemy animation based on screen boundaries.
        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Position.X -= Speed * elapsed;
            //SetMovementLeft();
            //EnemyAnimation.Update(gameTime);

            if (Position.X <= WindowWidth)
            {
                SetMovementLeft();
                Position.X -= Speed * elapsed;
                //EnemyAnimation.SetPosition(Position);
                EnemyAnimation.Update(gameTime);
            }

            if (Position.X <= 0 && FacingLeft == true)
            {
                SetMovementRight();
                Position.X += Speed * elapsed;
                //EnemyAnimation.SetPosition(Position);
                EnemyAnimation.Update(gameTime);
            }
        }

    /*************************************************************************************************************************************/

            // Draw enemy sprite/animations.
        public void Draw(SpriteBatch batch)
        {
            EnemyAnimation.SetPosition(Position);
            EnemyAnimation.Draw(batch);
        }

    /*************************************************************************************************************************************/

    } // class: Zombie
} // namespace: Lost_Souls
