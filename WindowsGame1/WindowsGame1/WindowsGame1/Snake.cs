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
        string der = "UP";
        public List<Vector2> segments = new List<Vector2>();
        private Texture2D snakeTexture;
        int updatetimer = 0;
        bool lose = false;
        int toadd = 0;
        int snakesize = 16;

        Keys up, down, left, right;

        public Snake(Texture2D texture, Vector2 location, int snakesize, Keys up, Keys down, Keys left, Keys right)
        {
            this.snakeTexture = texture;
            segments.Add(location);
            segments.Add(location + new Vector2(0, 1));
            segments.Add(location + new Vector2(0, 2));
            segments.Add(location + new Vector2(0, 3));
            segments.Add(location + new Vector2(0, 4));

            this.snakesize = snakesize;

            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;

        }

        public Vector2 Location
        {
            get { return segments[0]; }
        }
        public void finishgame()
        {
            while (true)
            {
            }
        }
        public void Grow(int amount)
        {
            toadd = amount;

        }


        public int isColliding(Snake other)
        {
            for (int i = 1; i < other.segments.Count; i++)
            {
                if (this.segments[0] == other.segments[i])
                {
                    return i; 
                }
            }

            return -1;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(down) && der != "UP")
                der = "DOWN";
            if (kb.IsKeyDown(left) && der != "RIGHT")
                der = "LEFT";
            if (kb.IsKeyDown(up) && der != "DOWN")
                der = "UP";
            if (kb.IsKeyDown(right) && der != "LEFT")
                der = "RIGHT";

            updatetimer += 1;
            if (updatetimer >= 5 && lose != true)
            {
                updatetimer = 0;

                
                for (int i = 0; i < toadd; i++)
                {
                    segments.Add(segments[0]);
                }

                toadd = 0;

                for (int i = segments.Count - 1; i > 0; i--)
                {
                    segments[i] = segments[i - 1];
                }

                if (der == "DOWN")
                {
                    segments[0] = new Vector2(segments[0].X, segments[0].Y + 1);
                }
                if (der == "LEFT")
                {
                    segments[0] = new Vector2(segments[0].X - 1, segments[0].Y);
                }
                if (der == "UP")
                {
                    segments[0] = new Vector2(segments[0].X, segments[0].Y - 1);
                }
                if (der == "RIGHT")
                {
                    segments[0] = new Vector2(segments[0].X + 1, segments[0].Y);
                }
                


                /*
                for (int i = 0; i < segments.Count; i++)
                {
                    int newi = segments.Count - i - 1;
                    if (newi != 0)
                        if (toadd >= 1 && newi == segments.Count - 1)
                        {
                            toadd -= 1;
                            segments.Add(segments[newi]);
                            segments[newi] = segments[newi - 1];

                        }
                        else
                        {
                            segments[newi] = segments[newi - 1];
                        }
                    else
                    {

                        if (der == "DOWN")
                        {
                            segments[0] = new Vector2(segments[0].X, segments[0].Y + 1);
                        }
                        if (der == "LEFT")
                        {
                            segments[0] = new Vector2(segments[0].X - 1, segments[0].Y);
                        }
                        if (der == "UP")
                        {
                            segments[0] = new Vector2(segments[0].X, segments[0].Y - 1);
                        }
                        if (der == "RIGHT")
                        {
                            segments[0] = new Vector2(segments[0].X + 1, segments[0].Y);
                        }
                    }

                }
                */
            }

            for (int i = 0; i < segments.Count; i++)
            {
                if (segments[0] == segments[i] && i != 0)
                {
                    //finishgame();
                    int thing = i;
                }
                if (segments[i].X > 50)
                {
                    segments[i] = new Vector2(segments[i].X - 51, segments[i].Y);
                }
                else if (segments[i].X < -1)
                {
                    segments[i] = new Vector2(segments[i].X + 51, segments[i].Y);
                }
                else if (segments[i].Y > 30)
                {
                    segments[i] = new Vector2(segments[i].X, segments[i].Y-31);
                }
                else if (segments[i].Y < -1)
                {
                    segments[i] = new Vector2(segments[i].X, segments[i].Y+31);
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < segments.Count; i++)
            {
                spriteBatch.Draw(snakeTexture, new Rectangle((int)segments[i].X * snakesize, (int)segments[i].Y * snakesize, snakesize, snakesize), new Rectangle(0, 0, snakesize, snakesize), Color.Red);
            }
        }
    }
}
