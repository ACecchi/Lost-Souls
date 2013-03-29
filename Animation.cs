using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lost_Souls
{
    struct AnimationCell
    {
        public Texture2D Cell; // Individual keyframe.
        public int ID;         // Keyframe ID.

            // Creates animation cell and intialized member variables.
        public AnimationCell(Texture2D sprite, int id)
        {
            this.Cell = sprite;
            this.ID = id;
        }
    }

    /*************************************************************************************************************************************/

    class Animation
    {
        Vector2 Position;             // Sprite position.
        Vector2 SpriteOrigin;         // Sprite origin.
        SpriteEffects SpriteEffects;  // Animation options.
        List<AnimationCell> CellList; // Keyframe list.
        bool Looping;                 // Is looping?
        bool Stopped;                 // Is stopped?
        bool Playing;                 // Is playing?
        int CurrentCell;              // Current cell animating.
        float Scale;                  // Sprite scale.
        float TimeShift;              // 
        float TotalTime;              // 
        int Start;                    // Frame to start with.
        int End;                      // Frame to end with.

    /*************************************************************************************************************************************/

            // Create animation object and initialize member variables.
        public Animation()
        {
            this.Position = new Vector2(0.0f, 0.0f);
            this.SpriteOrigin = new Vector2(0.0f, 0.0f);
            this.SpriteEffects = SpriteEffects.None;
            this.CellList = new List<AnimationCell>();
            this.Looping = false;
            this.Stopped = false;
            this.Playing = false;
            this.CurrentCell = 0;
            this.Scale = 1.0f;
            this.TimeShift = 0.0f;
            this.TotalTime = 0.0f;
            this.Start = 0;
            this.End = 0;
        }

    /*************************************************************************************************************************************/

            // Scale mutator.
        public float SetScale
        {
            set
            {
                Scale = value;
            }
        }

    /*************************************************************************************************************************************/

            // SpriteOrigin mutator.
        public Vector2 SetSpriteOrigin
        {
            set
            {
                SpriteOrigin = value;
            }
        }

    /*************************************************************************************************************************************/

            // Position mutator.
        public void SetPosition(Vector2 position)
        {
            this.Position = position;
        }

    /*************************************************************************************************************************************/

            // Mirror Spite when moving left.
        public void SetMoveLeft()
        {
            SpriteEffects = SpriteEffects.FlipHorizontally;
        }

    /*************************************************************************************************************************************/

            // No effects when moving right.
        public void SetMoveRight()
        {
            SpriteEffects = SpriteEffects.None;
        }

    /*************************************************************************************************************************************/

            // Jump to a particular frame.
        public void GoToFrame(int number)
        {
            if (Playing) 
                return;

            if (number < 0 || number >= CellList.Count) 
                return;

            CurrentCell = number;
        }

    /*************************************************************************************************************************************/

            // Add individual sprites to the cell list for animation.
        public void AddCell(Texture2D cellPicture, int id)
        {
            AnimationCell cell = new AnimationCell(cellPicture, id);
            CellList.Add(cell);
        }

    /*************************************************************************************************************************************/
            
            // 
        public void LoopAll(float seconds)
        {
            if (Playing) 
                return;

            Stopped = false;

            if (Looping) 
                return;

            Looping = true;
            Start = 0;
            End = CellList.Count - 1;

            CurrentCell = Start;
            TimeShift = seconds / (float)CellList.Count;
        }

    /*************************************************************************************************************************************/

            // 
        public void Loop(int start, int end, float seconds)
        {
            if (Playing) 
                return;

            Stopped = false;

            if (Looping) 
                return;

            Looping = true;
            this.Start = start;
            this.End = end;

            CurrentCell = start;
            float difference = (float)end - (float)start;

            TimeShift = seconds / difference;
        }

    /*************************************************************************************************************************************/

            // 
        public void PlayAll(int start, float seconds)
        {
            if (Playing) 
                return;

            GoToFrame(start);
            Stopped = false;
            Looping = false;
            Playing = true;
            End = CellList.Count - 1;

            TimeShift = seconds / CellList.Count;
        }

    /*************************************************************************************************************************************/

            // 
        //public void Play(int start, int end, float seconds)
        //{
        //    if (Playing) 
        //        return;

        //    GoToFrame(start);

        //    Stopped = false;
        //    Looping = false;
        //    Playing = true;
        //    this.Start = start;
        //    this.End = end;

        //    float difference = (float)end - (float)start;
        //    TimeShift = seconds / difference;
        //}

    /*************************************************************************************************************************************/
        
            // 
        public void Stop()
        {
            if (Playing) 
                return;

            Stopped = true;
            Looping = false;
            TotalTime = 0.0f;
            TimeShift = 0.0f;
        }

    /*************************************************************************************************************************************/

            // 
        public void Update(GameTime gameTime)
        {
            if (Stopped) 
                return;

            TotalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (TotalTime > TimeShift)
            {
                TotalTime = 0.0f;

                CurrentCell++;
                if (Looping)
                {
                    if (CurrentCell > End) 
                        CurrentCell = Start;
                }

                if (CurrentCell > End)
                {
                    CurrentCell = End;
                    Playing = false;
                }
            }
        }

    /*************************************************************************************************************************************/

            // 
        public void Draw(SpriteBatch batch)
        {
            if (CellList.Count == 0 || CurrentCell < 0 || CellList.Count <= CurrentCell) 
                return;

            batch.Draw(CellList[CurrentCell].Cell, Position, null, Color.White, 0.0f, 
                       SpriteOrigin, new Vector2(Scale, Scale), SpriteEffects, 0.0f);
        }

    /*************************************************************************************************************************************/

    } // class: Animation
} // namespace: Lost_Souls
