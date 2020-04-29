using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Terrain.Generator;
using Terrain.Models;

namespace Terrain2DViewer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TerrainViewer : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Generator generator;


        Texture2D whiteTexture;

        public TerrainViewer()
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
            generator = new Generator();
            generator.Initialize();
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

            // TODO: use this.Content to load your game content here
            whiteTexture = new Texture2D(GraphicsDevice, 1, 1);
            whiteTexture.SetData(new[] { Color.White });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightYellow);

            // TODO: Add your drawing code here
            Draw(generator.Terrain, gameTime);
            base.Draw(gameTime);
        }

        private void Draw(TerrainBase terrain, GameTime gameTime)
        {
            spriteBatch.Begin();
            var heightMap = terrain.HeightMap;
            for(int i = 0; i< terrain.X; i++)
            {
                for(int j = 0; j < terrain.Y; j++)
                {
                    Draw(terrain, heightMap[i, j], i, j);
                }
            }
            spriteBatch.End();
        }

        private void Draw(TerrainBase terrain, int h, int i, int j)
        {
            var rect = new Rectangle(i * 5, j * 5, 5, 5);
            if (h % 2 == 0)
            {
                spriteBatch.Draw(whiteTexture, rect, Color.LimeGreen);
            }
            else
            {
                spriteBatch.Draw(whiteTexture, rect, Color.LightSalmon);
            }
        }
    }
}
