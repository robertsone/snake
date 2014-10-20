using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    class Snake
    {
        string der = "LEFT";
        public List<Vector2> snake = new List<Vector2>();
        private Texture2D snakeTexture;
        int updatetimer = 0;
        bool lose = false;
        int toadd = 0;
        int snakesize = 16;

        public Snake(Texture2D texture, Vector2 location)
        {
            this.snakeTexture = texture;

            snake.Add(location);
            snake.Add(location + new Vector2(0, 1));
            snake.Add(location + new Vector2(0, 2));
            snake.Add(location + new Vector2(0, 3));
            snake.Add(location + new Vector2(0, 4));
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.Down) && der != "UP")
                der = "DOWN";
            if (kb.IsKeyDown(Keys.Left) && der != "RIGHT")
                der = "LEFT";
            if (kb.IsKeyDown(Keys.Up) && der != "DOWN")
                der = "UP";
            if (kb.IsKeyDown(Keys.Right) && der != "LEFT")
                der = "RIGHT";

            updatetimer += 1;
            if (updatetimer >= 5 && lose != true)
            {
                updatetimer = 0;
                for (int i = 0; i < snake.Count; i++)
                {
                    int newi = snake.Count - i - 1;
                    if (newi != 0)
                        if (toadd >= 1 && newi == snake.Count - 1)
                        {
                            toadd -= 1;
                            snake.Add(snake[newi]);
                            snake[newi] = snake[newi - 1];

                        }
                        else
                        {
                            snake[newi] = snake[newi - 1];
                        }
                    else
                    {

                        if (der == "DOWN")
                        {
                            snake[0] = new Vector2(snake[0].X, snake[0].Y + 1);
                        }
                        if (der == "LEFT")
                        {
                            snake[0] = new Vector2(snake[0].X - 1, snake[0].Y);
                        }
                        if (der == "UP")
                        {
                            snake[0] = new Vector2(snake[0].X, snake[0].Y - 1);
                        }
                        if (der == "RIGHT")
                        {
                            snake[0] = new Vector2(snake[0].X + 1, snake[0].Y);
                        }
                    }

                }
            }
            for (int i = 0; i < snake.Count; i++)
            {
                if (snake[0] == snake[i] && i != 0)
                {
                    lose = true;
                    int thing = i;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < snake.Count; i++)
            {
                spriteBatch.Draw(snakeTexture, new Rectangle((int)snake[i].X * snakesize, (int)snake[i].Y * snakesize, snakesize, snakesize), new Rectangle(0, 0, snakesize, snakesize), Color.Red);
            }
        }
    }
}
