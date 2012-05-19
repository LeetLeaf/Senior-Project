using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace com.Kyle.Keebler
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D player;
        /* 
        Point playerFrameSize = new Point(18,32);
        Point playerCurrentFrame = new Point(0, 0);
        Point playerIdleFrames = new Point(3,0);
        */
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 120;
        Player userPlayer = new Player();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = Content.Load<Texture2D>(@"images/Mario");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape)) this.Exit();
            
            // TODO: Add your update logic here
            if(keyState.IsKeyDown(Keys.Down))
            {
                userPlayer.PlayerPosY += 10;
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                userPlayer.PlayerPosY -= 10;
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                userPlayer.PlayerPosX -= 10;
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                userPlayer.PlayerPosX += 10;
            }
            //Mario Commands
            //
            //Mario Idle
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++userPlayer.PlayerCurrentFrameX;
                if (userPlayer.PlayerCurrentFrameX >= userPlayer.PlayerIdleFramesX)
                {
                    userPlayer.PlayerCurrentFrameX = 0;
                    ++userPlayer.PlayerCurrentFrameY;
                    if (userPlayer.PlayerCurrentFrameY >= userPlayer.PlayerIdleFramesY)
                        userPlayer.PlayerCurrentFrameY = 0;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(255,255,1));

            spriteBatch.Begin();
            spriteBatch.Draw(player, new Vector2(userPlayer.PlayerPosX,userPlayer.PlayerPosY),
                new Rectangle(userPlayer.PlayerCurrentFrameX * userPlayer.PlayerFrameSizeX,
                    userPlayer.PlayerCurrentFrameY * userPlayer.PlayerFrameSizeY, userPlayer.PlayerFrameSizeX, userPlayer.PlayerFrameSizeY) 
                ,Color.White,0,Vector2.Zero,
                1, SpriteEffects.None, 0);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
