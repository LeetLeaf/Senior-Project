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
        //Texture2D playerTexture;
        //Texture2D inventoryTexture;
        SpriteFont gameFont;

        Player userPlayer = null;
        Enemy testCharacter = null;
        Sword basicSword = null;
        MapBase currentMap = null;

        public static Dictionary<string, Texture2D> Textures { get; set; }

        //List<IMoveable> movingElements;
        //List<Item> itemsAvailable;
        //List<IRenderable> imovableObjects;

        static Game1()
        {
            Textures = new Dictionary<string, Texture2D>();
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
            

            
            
            //movingElements = new List<IMoveable>();
            //imovableObjects = new List<IRenderable>();
            //itemsAvailable = new List<Item>();
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
            Textures.Add("player", Content.Load<Texture2D>(@"images/Hero Sprite Sheet"));
            Textures.Add("inventory", Content.Load<Texture2D>(@"images/Inventory"));
            Textures.Add("sword", Content.Load<Texture2D>(@"images/Sword"));
            Textures.Add("blackKnight", Content.Load<Texture2D>(@"images/Black Knight Sheet"));

            gameFont = Content.Load<SpriteFont>(@"font\gameFont");

            currentMap = new BeginingMap(spriteBatch, new Rectangle(0,0, Window.ClientBounds.Width, Window.ClientBounds.Height));

            userPlayer = new Player(Textures["player"], new Vector2(0, 0), Textures["inventory"],gameFont,currentMap);

            currentMap.LoadContent(userPlayer,currentMap);
            //testCharacter = new Enemy(playerTexture, new Vector2(100, 100));
            //basicSword = new Sword("Basic Sword", Textures["sword"], new Vector2(200, 50), ItemType.Weapon);

            //movingElements.Add(userPlayer);
            
            //movingElements.Add(testCharacter);

            //itemsAvailable.Add(basicSword);
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

            foreach (IMoveable moveElement in currentMap.MovingElements)
            {
                foreach (IRenderable staticObject in currentMap.ImmovableObjects)
                {
                    if (moveElement.Collide(staticObject.CollisionRec))
                    {
                        //TODO: What to do here
                    }
                }


                foreach (IMoveable otherElement in currentMap.MovingElements.Where(
                m => !m.Equals(moveElement) &&
                m.CanCollide))
                {
                    if (moveElement.Collide(otherElement.CollisionRec))
                    {
                        moveElement.CollisionAction(otherElement);

                    }
                }

                foreach (Item item in currentMap.ItemsAvailable)
                {
                    if (moveElement.Collide(item.CollisionRec)&& item.CanCollide)
                    {
                        moveElement.CollisionActionItem(item);
                    }
                }

                moveElement.Update(gameTime);

            }
            foreach (Item item in currentMap.ItemsAvailable)
            {
                item.Update(gameTime);
            }

            //TODO: does this need to be resolved.
            //foreach (IRenderable staticObject in imovableObjects)
            //{
            //    staticObject.Update()
            //}


            // TODO: Add your update logic here
            //userPlayer.Update(gameTime);

            //Collision Test
            //if (userPlayer.Collide(testCharacter.CollisionRec))
            //    this.Exit();
            //if (userPlayer.Collide(basicSword.CollisionRec))
            //{
            //    basicSword.isPickedUp = true;
            //    playerItems.InventoryList.Add(basicSword);

            //}
            //basicSword.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentMap.Draw(gameTime);


            spriteBatch.Begin();
            if (userPlayer.showItems)
                userPlayer.PlayerItems.Draw(spriteBatch, Window.ClientBounds);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
