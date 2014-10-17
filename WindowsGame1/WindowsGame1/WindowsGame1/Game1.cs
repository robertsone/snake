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
        List<Vector2> snake = new List<Vector2>();
        Texture2D squareTexture;
        int updatetimer = 0;
        int snakesize = 16;
        string der = "UP";

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

            snake.Add(new Vector2(1, 1));
            snake.Add(new Vector2(1, 2));
            snake.Add(new Vector2(2, 2));
            snake.Add(new Vector2(2, 3));
            snake.Add(new Vector2(2, 4));

        }

       
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.Down) || der == "DOWN")
                der = "DOWN";
            else if (kb.IsKeyDown(Keys.Left) || der == "LEFT")
                der = "LEFT";
            else if (kb.IsKeyDown(Keys.Up) || der == "UP")
                der = "UP";
            else if (kb.IsKeyDown(Keys.Right) || der == "RIGHT")
                der = "RIGHT";

            updatetimer += 1;
            if (updatetimer >= 10)
            {
                updatetimer = 0;
                for (int i = 0; i < snake.Count; i++)
                {
                    int newi = snake.Count - i-1;
                    if (newi != 0)
                        snake[newi] = snake[newi - 1];
                    else
                    {

                        if (der == "DOWN")
                        {
                            der = "DOWN";
                            snake[0] = new Vector2(snake[0].X, snake[0].Y + 1);
                        }
                        else if (der == "LEFT")
                        {
                            der = "LEFT";
                            snake[0] = new Vector2(snake[0].X - 1, snake[0].Y);
                        }
                        else if (der == "UP")
                        {
                            der = "UP";
                            snake[0] = new Vector2(snake[0].X, snake[0].Y - 1);
                        }
                        else if (der == "RIGHT")
                        {
                            der = "RIGHT";
                            snake[0] = new Vector2(snake[0].X + 1, snake[0].Y);
                        }
                    }

                }
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            for (int i = 0; i<snake.Count; i++)
            {
                spriteBatch.Draw(squareTexture, new Rectangle((int)snake[i].X * snakesize, (int)snake[i].Y * snakesize, snakesize, snakesize), new Rectangle(0, 0, snakesize, snakesize), Color.Red);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
