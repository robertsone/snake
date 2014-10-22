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

        List <Snake> snakes;
        Vector2 food = new Vector2(10,10);
        int snakesize = 16;
        Color color=Color.Yellow;
        int colorcounter = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        public Color getcolor()
        {
            Color color= Color.Yellow;
            int number = rand.Next(1, 12);
            if (number == 1) color = Color.Aqua;
            if (number == 2) color = Color.White;
            if (number == 3) color = Color.Gray;
            if (number == 4) color = Color.Green;
            if (number == 5) color = Color.Black;
            if (number == 6) color = Color.Blue;
            if (number == 7) color = Color.Yellow;
            if (number == 8) color = Color.Magenta;
            if (number == 9) color = Color.Lavender;
            if (number == 10) color = Color.Maroon;
            if (number == 11) color = Color.Purple;
            if (number == 12) color = Color.Pink;
            return color;
        }
        
        protected override void Initialize()
        {
            


            base.Initialize();
        }

        
        protected override void LoadContent()
        {

            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            squareTexture = Content.Load<Texture2D>(@"SQUARE");

            snakes = new List<Snake>();

            snakes.Add(new Snake(squareTexture, new Vector2(45, 15), snakesize, Keys.Up, Keys.Down, Keys.Left, Keys.Right));
            snakes.Add(new Snake(squareTexture, new Vector2(5, 15), snakesize, Keys.W, Keys.S, Keys.A, Keys.D));


        }

       
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < snakes.Count; i++)
            {
                for (int j = 0; j < snakes.Count; j++)
                {
                    
                    //if (i != j)
                    {
                        int index = snakes[i].isColliding(snakes[j]);

                        if (index != -1)
                        {
                            for (int k = snakes[j].segments.Count-1; k >= index; k--)
                            {
                                snakes[j].segments.RemoveAt(k);
                            }
                        }
                    }
                }

                if (snakes[i].Location == food)
                {
                    food = new Vector2(rand.Next(1, 49), rand.Next(1, 29));
                    snakes[i].Grow(rand.Next(0,5));
                }

                snakes[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            colorcounter += 1;
            if (colorcounter >= 60)
            {
                color = getcolor();
                colorcounter = 0;
            }
            GraphicsDevice.Clear(color);
            

            spriteBatch.Begin();

            for (int i = 0; i < snakes.Count; i++)
            {
                snakes[i].Draw(spriteBatch);
            }
            spriteBatch.Draw(squareTexture, new Rectangle((int)food.X * snakesize, (int)food.Y * snakesize, snakesize, snakesize), new Rectangle(0, 0, snakesize, snakesize), Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
