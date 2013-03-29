using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lost_Souls
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager Graphics; // Graphics device.
        SpriteBatch SpriteBatch;        // SpriteBatch for drawing.
        Player Loki;                    // Player instance.
        Texture2D PlayerFireBall;       // FireBall sprite.
        Background BackgroundPicture1;  // Background sprite.
        Background BackgroundPicture2;  // Background sprite.
        Background BackgroundPicture3;  // Background sprite.
        Background BackgroundPicture4;  // Background sprite.
        Animation ZombieAnimation;      // Store zombie animation.
        List<Zombie> ZombieList;        // List for zombies.
        List<FireBall> FireBallList;    // List for fireballs.
        float ButtonFireDelay;          // Input/Animation delay.
        float TotalTime;                // Total game time.

    /*************************************************************************************************************************************/

        public Game1()
        {
                // Initialize graphics device and set root directory and window size.
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SetWindowSize(1200, 600);
        }

    /*************************************************************************************************************************************/

        protected override void Initialize()
        {
                // Initialize game objects.
            ZombieAnimation = new Animation();
            ZombieList = new List<Zombie>();
            FireBallList = new List<FireBall>();

                // Initialize background sprites.
            BackgroundPicture1 = new Background();
            BackgroundPicture2 = new Background();
            BackgroundPicture3 = new Background();
            BackgroundPicture4 = new Background();

                // Create main character.
            Loki = new Player(Graphics.GraphicsDevice, 
                              new Vector2(600.0f, 475.0f), 
                              Content.Load<Texture2D>("Knight/Knight1")); 

                // Initialize misc game variables.
            ButtonFireDelay = 0.0f;
            TotalTime = 0.0f;
            CreateZombie();

            base.Initialize();
        }

    /*************************************************************************************************************************************/

        protected override void LoadContent()
        {
                // Initialize SpriteBatch.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

                // Load background sprites.
            BackgroundPicture1.LoadContent(this.Content, "Background/Level1");
            BackgroundPicture2.LoadContent(this.Content, "Background/Level2");
            BackgroundPicture3.LoadContent(this.Content, "Background/Level3");
            BackgroundPicture4.LoadContent(this.Content, "Background/Level4");

                // Set background positions.
            BackgroundPicture1.Position = new Vector2(0, 0);
            BackgroundPicture2.Position = new Vector2(BackgroundPicture1.Position.X + BackgroundPicture1.Size.Width, 0);
            BackgroundPicture3.Position = new Vector2(BackgroundPicture2.Position.X + BackgroundPicture2.Size.Width, 0);
            BackgroundPicture4.Position = new Vector2(BackgroundPicture3.Position.X + BackgroundPicture3.Size.Width, 0);

                // Load main character walking sprites and add to animation cell list.
            Texture2D Walking0 = Content.Load<Texture2D>("Knight/Knight1"); Loki.AddCell(Walking0, 0);
            Texture2D Walking1 = Content.Load<Texture2D>("Knight/Knight2"); Loki.AddCell(Walking1, 1);
            Texture2D Walking2 = Content.Load<Texture2D>("Knight/Knight3"); Loki.AddCell(Walking2, 2);
            Texture2D Walking3 = Content.Load<Texture2D>("Knight/Knight4"); Loki.AddCell(Walking3, 3);
            Texture2D Walking4 = Content.Load<Texture2D>("Knight/Knight5"); Loki.AddCell(Walking4, 4);
            Texture2D Walking5 = Content.Load<Texture2D>("Knight/Knight6"); Loki.AddCell(Walking5, 5);
            Texture2D Walking6 = Content.Load<Texture2D>("Knight/Knight7"); Loki.AddCell(Walking6, 6);
            Texture2D Walking7 = Content.Load<Texture2D>("Knight/Knight8"); Loki.AddCell(Walking7, 7);
            Texture2D Walking8 = Content.Load<Texture2D>("Knight/Knight9"); Loki.AddCell(Walking8, 8);

                // Load main character sword attack sprites and add to animation cell list.
            Texture2D Attack1  = Content.Load<Texture2D>("Knight/Sword1");  Loki.AddCell(Attack1,  23);
            Texture2D Attack2  = Content.Load<Texture2D>("Knight/Sword2");  Loki.AddCell(Attack2,  24);
            Texture2D Attack3  = Content.Load<Texture2D>("Knight/Sword3");  Loki.AddCell(Attack3,  25);
            Texture2D Attack4  = Content.Load<Texture2D>("Knight/Sword4");  Loki.AddCell(Attack4,  26);
            Texture2D Attack5  = Content.Load<Texture2D>("Knight/Sword5");  Loki.AddCell(Attack5,  27);
            Texture2D Attack6  = Content.Load<Texture2D>("Knight/Sword6");  Loki.AddCell(Attack6,  28);
            Texture2D Attack7  = Content.Load<Texture2D>("Knight/Sword7");  Loki.AddCell(Attack7,  29);
            Texture2D Attack8  = Content.Load<Texture2D>("Knight/Sword8");  Loki.AddCell(Attack8,  30);
            Texture2D Attack9  = Content.Load<Texture2D>("Knight/Sword9");  Loki.AddCell(Attack9,  31);
            Texture2D Attack10 = Content.Load<Texture2D>("Knight/Sword10"); Loki.AddCell(Attack10, 32);

                // Load main character fireball attack sprites and add to animation cell list.
            Texture2D FireBall1 = Content.Load<Texture2D>("Knight/Fireball1"); Loki.AddCell(FireBall1, 33);
            Texture2D FireBall2 = Content.Load<Texture2D>("Knight/Fireball2"); Loki.AddCell(FireBall2, 34);
            Texture2D FireBall3 = Content.Load<Texture2D>("Knight/Fireball3"); Loki.AddCell(FireBall3, 35);
            Texture2D FireBall4 = Content.Load<Texture2D>("Knight/Fireball4"); Loki.AddCell(FireBall4, 36);
            Texture2D FireBall5 = Content.Load<Texture2D>("Knight/Fireball5"); Loki.AddCell(FireBall5, 37);
            Texture2D FireBall6 = Content.Load<Texture2D>("Knight/Fireball6"); Loki.AddCell(FireBall6, 38);
            Texture2D FireBall7 = Content.Load<Texture2D>("Knight/Fireball7"); Loki.AddCell(FireBall7, 39);
            Texture2D FireBall8 = Content.Load<Texture2D>("Knight/Fireball8"); Loki.AddCell(FireBall8, 40);

                // Load fireball sprite.
            PlayerFireBall = Content.Load<Texture2D>("Knight/Fireball");

                // Load enemy walking sprite and add to animation cell list.
            Texture2D zWalking0  = Content.Load<Texture2D>("Zombie/Zombie1");  ZombieAnimation.AddCell(zWalking0, 9);
            Texture2D zWalking1  = Content.Load<Texture2D>("Zombie/Zombie2");  ZombieAnimation.AddCell(zWalking1, 10);
            Texture2D zWalking2  = Content.Load<Texture2D>("Zombie/Zombie3");  ZombieAnimation.AddCell(zWalking2, 11);
            Texture2D zWalking3  = Content.Load<Texture2D>("Zombie/Zombie4");  ZombieAnimation.AddCell(zWalking3, 12);
            Texture2D zWalking4  = Content.Load<Texture2D>("Zombie/Zombie5");  ZombieAnimation.AddCell(zWalking4, 13);
            Texture2D zWalking5  = Content.Load<Texture2D>("Zombie/Zombie6");  ZombieAnimation.AddCell(zWalking5, 14);
            Texture2D zWalking6  = Content.Load<Texture2D>("Zombie/Zombie7");  ZombieAnimation.AddCell(zWalking6, 15);
            Texture2D zWalking7  = Content.Load<Texture2D>("Zombie/Zombie8");  ZombieAnimation.AddCell(zWalking7, 16);
            Texture2D zWalking8  = Content.Load<Texture2D>("Zombie/Zombie9");  ZombieAnimation.AddCell(zWalking8, 17);
            Texture2D zWalking9  = Content.Load<Texture2D>("Zombie/Zombie10"); ZombieAnimation.AddCell(zWalking9, 18);
            Texture2D zWalking10 = Content.Load<Texture2D>("Zombie/Zombie11"); ZombieAnimation.AddCell(zWalking10, 19);
            Texture2D zWalking11 = Content.Load<Texture2D>("Zombie/Zombie12"); ZombieAnimation.AddCell(zWalking11, 20);
            Texture2D zWalking12 = Content.Load<Texture2D>("Zombie/Zombie13"); ZombieAnimation.AddCell(zWalking12, 21);
            Texture2D zWalking13 = Content.Load<Texture2D>("Zombie/Zombie14"); ZombieAnimation.AddCell(zWalking13, 22);         
        }

    /*************************************************************************************************************************************/

        protected override void UnloadContent()
        {

        }

    /*************************************************************************************************************************************/

        protected override void Update(GameTime gameTime)
        {
                // Allows the game to exit
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
                this.Exit();

            // Update game time.
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TotalTime += elapsed;
            ButtonFireDelay -= elapsed;

                // Create zombies based on time.
            //ZombieCreationTimer();
            
                // Update game logic.
            UpdateInput(gameTime);
            Loki.Update(gameTime);

            for (int idx = 0; idx < ZombieList.Count; ++idx)
            {
                ZombieList[idx].Update(gameTime);

                int collision = ZombieList[idx].CollisionFireBall(FireBallList);

                if (collision != -1)
                {
                    ZombieList.RemoveAt(idx);
                    FireBallList.RemoveAt(idx);
                }
            }

            for (int idx = 0; idx < FireBallList.Count; ++idx)
                FireBallList[idx].Update(gameTime);

            base.Update(gameTime);
        }

    /*************************************************************************************************************************************/

        public void UpdateInput(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

                // Walk left if player is pressing "A".
            if (keyState.IsKeyDown(Keys.A))
            {
                Loki.MoveLeft();
            }

                // Walk right and scroll background if player is pressing "D".
            if (keyState.IsKeyDown(Keys.D))
            {
                Loki.MoveRight();
                BackgroundUpdate(gameTime);
            }

                // Attack right when player is pressing "Right Shift" and facing right.
            if (keyState.IsKeyDown(Keys.RightShift) && Loki.GetFacingLeft == false)
            {
                Loki.AttackRight();
            }

                // Attack left when player is pressing "Right Shift" and facing left.
            if (keyState.IsKeyDown(Keys.RightShift) && Loki.GetFacingLeft == true)
            {
                Loki.AttackLeft();
            }

                // Throw fireball right when player is pressing "Right Control" and facing right.
            if (keyState.IsKeyDown(Keys.RightControl) && Loki.GetFacingLeft == false)
            {
                if (ButtonFireDelay <= 0.0f)
                {
                    Loki.FireballRight();
                    FireBall shot = new FireBall(PlayerFireBall, new Vector2(Loki.GetPosition.X + 10.0f, Loki.GetPosition.Y - 40.0f), 650.0f);
                    shot.SetMoveRight();
                    FireBallList.Add(shot);
                    ButtonFireDelay = 0.75f;
                }
            }

                // Throw fireball left when player is pressing "Right Control" and facing left.
            if (keyState.IsKeyDown(Keys.RightControl) && Loki.GetFacingLeft == true)
            {
                if (ButtonFireDelay <= 0.0f)
                {
                    Loki.FireballLeft();
                    FireBall shot = new FireBall(PlayerFireBall, new Vector2(Loki.GetPosition.X + 10.0f, Loki.GetPosition.Y - 40.0f), -725.0f);
                    shot.SetMoveLeft();
                    FireBallList.Add(shot);
                    ButtonFireDelay = 0.75f;
                }
            }

                // Stand still if player is not pressing any buttons.
            if (!keyState.IsKeyDown(Keys.A) && !keyState.IsKeyDown(Keys.D) && !keyState.IsKeyDown(Keys.RightControl) && !keyState.IsKeyDown(Keys.RightShift))
            {
                Loki.Stop();
            }
        }

    /*************************************************************************************************************************************/

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(); // Start drawing.

                // Draw background.
            BackgroundPicture1.Draw(SpriteBatch);
            BackgroundPicture2.Draw(SpriteBatch);
            BackgroundPicture3.Draw(SpriteBatch);
            BackgroundPicture4.Draw(SpriteBatch);

                // Draw player and zombie.
            Loki.Draw(SpriteBatch);

                // Draw all zombies
            foreach (Zombie zombie in ZombieList)
                zombie.Draw(SpriteBatch);

                // Draw all fireballs.
            foreach (FireBall fireball in FireBallList)
                fireball.Draw(SpriteBatch);

            SpriteBatch.End(); // End drawing.

            base.Draw(gameTime);
        }

    /*************************************************************************************************************************************/

            // Set window size and apply changes.
        public void SetWindowSize(int x, int y)
        {
            Graphics.PreferredBackBufferWidth = x;
            Graphics.PreferredBackBufferHeight = y;
            Graphics.ApplyChanges();
        }

    /*************************************************************************************************************************************/
        
            // Create new enemy, set movement, and add to enemy list.
        public void CreateZombie()
        {
            Zombie enemy = new Zombie(Graphics.GraphicsDevice, new Vector2(1200.0f, 384.0f), ZombieAnimation, 150.0f);
            ZombieList.Add(enemy);
        }

    /*************************************************************************************************************************************/

            // Create enemy based on time.
        //public void ZombieCreationTimer()
        //{
        //    if (TotalTime > 1.0f && TotalTime < 1.01f)
        //        CreateZombie();

        //    if (TotalTime > 2.2f && TotalTime < 2.21f)
        //    {
        //        for (int i = 0; i < 4; i++)
        //            CreateZombie();
        //    }

        //    if (TotalTime > 7.2f && TotalTime < 7.21f)
        //    {
        //        for (int i = 0; i < 4; i++)
        //            CreateZombie();
        //    }
        //}

    /*************************************************************************************************************************************/
            // Update background position to give a "scrolling" effect.
        private void BackgroundUpdate(GameTime gameTime)
        {
            if (BackgroundPicture1.Position.X < -BackgroundPicture1.Size.Width)
                BackgroundPicture1.Position.X = BackgroundPicture1.Position.X + BackgroundPicture4.Size.Width;

            if (BackgroundPicture2.Position.X < -BackgroundPicture2.Size.Width)
                BackgroundPicture2.Position.X = BackgroundPicture1.Position.X + BackgroundPicture1.Size.Width;

            if (BackgroundPicture3.Position.X < -BackgroundPicture3.Size.Width)
                BackgroundPicture3.Position.X = BackgroundPicture2.Position.X + BackgroundPicture2.Size.Width;

            if (BackgroundPicture4.Position.X < -BackgroundPicture4.Size.Width)
                BackgroundPicture4.Position.X = BackgroundPicture3.Position.X + BackgroundPicture3.Size.Width;

            Vector2 aDirection = new Vector2(-1, 0);
            Vector2 aSpeed = new Vector2(160, 0);

            BackgroundPicture1.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            BackgroundPicture2.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            BackgroundPicture3.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            BackgroundPicture4.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    /*************************************************************************************************************************************/

    } // class: Game1
} // namespace: Lost_Souls