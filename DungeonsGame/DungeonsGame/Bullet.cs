using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DungeonsGame
{
    class Bullet : Game
    {
        Texture2D Rock;

        Point currentFrame = new Point(0, 0);
        Point spriteSize = new Point(1, 1);

        public Vector2 rockPosition = Vector2.Zero;

        int frameWidth = 155;
        int frameHeight = 170;

        int currentTime = 0; // сколько времени прошло
        int period = 140; // период обновления в миллисекундах

        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
            }
        }

        public int X
        {
            get
            {
                return rectangle.X;
            }
            set
            {
                rectangle.X = value;
            }
        }

        public int Y
        {
            get
            {
                return rectangle.Y;
            }
            set
            {
                rectangle.Y = value;
            }
        }

        SpriteBatch spriteBatch;

        public Bullet(Texture2D texture, Rectangle rectangle)
        {
            Rock = texture;

            this.rectangle = rectangle;

            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 400);
        }

        public void LoadContent()
        {
            Content.RootDirectory = "Content";

            Rock = Content.Load<Texture2D>("Rock");

        }

        public void UpdateFrame(GameTime gameTime)
        {
            if (currentTime > period)
            {
                currentTime -= period; // вычитаем из текущего времени период обновления
                ++currentFrame.X; // переходим к следующему фрейму в спрайте
                if (currentFrame.X >= spriteSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= spriteSize.Y)
                        currentFrame.Y = 0;
                }
            }

        }
        public int count = 0;

        public void Shoot(GameTime gameTime, int speed)
        {

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                rockPosition.X -= speed;
                UpdateFrame(gameTime);
                count = 1;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                rockPosition.X += speed;
                UpdateFrame(gameTime);
                count = 2;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                rockPosition.Y -= speed;
                UpdateFrame(gameTime);
                count = 3;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                rockPosition.Y += speed;
                UpdateFrame(gameTime);
                count = 4;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                UpdateFrame(gameTime);
                count = 5;
            }
        }
    }
}
