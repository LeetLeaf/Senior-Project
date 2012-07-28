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
using com.Kyle.Keebler.Characters;
using com.Kyle.Keebler.Map;
using com.Kyle.Keebler.Items;

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

        Camera camera;

        Player userPlayer = null;
        Enemy testCharacter = null;
        Sword basicSword = null;
        MapBase currentMap = null;

        private bool fullScreen = false;

        public static Dictionary<string, Texture2D> Textures { get; set; }
        public static SpriteFont gameFont { get; set; }
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

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = fullScreen;




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
            camera = new Camera(GraphicsDevice.Viewport);

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
            Textures.Add("mario", Content.Load<Texture2D>(@"images/Mario"));
            Textures.Add("tiles", Content.Load<Texture2D>(@"images/Tiles"));
            Textures.Add("dungeonTiles", Content.Load<Texture2D>(@"images/DungeonTiles"));
            Textures.Add("textBox", Content.Load<Texture2D>(@"images/TextBox"));
            Textures.Add("chest", Content.Load<Texture2D>(@"images/Chest"));
            Textures.Add("heartFull", Content.Load<Texture2D>(@"images/Heart Full"));
            Textures.Add("heartHalf",Content.Load<Texture2D>(@"images/Heart Half"));
            Textures.Add("heartEmpty", Content.Load<Texture2D>(@"images/Heart Empty"));

            gameFont = Content.Load<SpriteFont>(@"font\gameFont");

            currentMap = new Dungeon1(spriteBatch, new Rectangle(156, 116, Window.ClientBounds.Width, Window.ClientBounds.Height));

            userPlayer = new Player(Textures["player"], new Vector2(0, 0), Textures["inventory"], gameFont, currentMap);
            

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
            if (Keyboard.GetState().IsKeyDown(Keys.F1)) fullScreen = !fullScreen;
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Escape)) this.Exit();

            //foreach (IMoveable moveElement in currentMap.MovingElements)
            //{
            //    foreach (IRenderable staticObject in currentMap.ImmovableObjects)
            //    {
            //        if (moveElement.Collide(staticObject.CollisionRec))
            //        {
            //            TODO: What to do here
            //        }
            //    }


            //    foreach (IMoveable otherElement in currentMap.MovingElements.Where(
            //    m => !m.Equals(moveElement) &&
            //    m.CanCollide))
            //    {
            //        if (moveElement.Collide(otherElement.CollisionRec))
            //        {
            //            moveElement.CollisionAction(otherElement);

            //        }
            //    }

            //    foreach (Item item in currentMap.ItemsAvailable)
            //    {
            //        if (moveElement.Collide(item.CollisionRec) && item.CanCollide)
            //        {
            //            moveElement.CollisionActionItem(item);
            //        }
            //    }

            //    foreach (IRenderable staticObject in currentMap.ImmovableObjects)
            //    {
            //        if (moveElement.Collide(staticObject.CollisionRec))
            //        {
            //            moveElement.CanMove = false;
            //            Character character = moveElement as Character;
            //            character.BoundryCollisionReverse(staticObject.CollisionRec);
            //            character.KnockBack(Utilities.FlipDirection(Utilities.DirectionTo(staticObject, character)), 2);
            //            moveElement.CollisionAction(staticObject);
            //        }
            //    }

            //    moveElement.Update(gameTime);
                

            //}
            //foreach (Item item in currentMap.ItemsAvailable)
            //{
            //    item.Update(gameTime);
            //}

            currentMap.Update(gameTime);

            camera.Update(gameTime, userPlayer, Window.ClientBounds);
            userPlayer.setCamera(camera);


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
                null,null,null,null,camera.transform);
            currentMap.Draw(gameTime);
            if (userPlayer.showItems)
                userPlayer.PlayerItems.Draw(spriteBatch, Window.ClientBounds);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
