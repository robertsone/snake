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

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random rand = new Random();
        
        Texture2D squareTexture;

        Snake snake;
        Vector2 food = new Vector2(10,10);
        int snakesize = 16;

        bool spawnfood = true;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            


            base.Initialize();
        }

        
        protected override void LoadContent()
        {

            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            squareTexture = Content.Load<Texture2D>(@"SQUARE");

            snake = new Snake(squareTexture, new Vector2(20, 20));

        }

       
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {

            /*
            if (snake[0] == food)
            {
                spawnfood = true;
                toadd = 2;
            }
            */

            if (spawnfood == true)
            {
                food = new Vector2(rand.Next(1,49), rand.Next(1,29));
                spawnfood = false;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            snake.Update(gameTime);

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            snake.Draw(spriteBatch);

            spriteBatch.Draw(squareTexture, new Rectangle((int)food.X * snakesize, (int)food.Y * snakesize, snakesize, snakesize), new Rectangle(0, 0, snakesize, snakesize), Color.Green);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
