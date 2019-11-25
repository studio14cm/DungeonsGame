using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace DungeonsGame
{
    public class Player : Game1
    {

        public Vector2 personPosition = Vector2.Zero;

        int frameWidth = 155;
        int frameHeight = 170;

        int frameWidthStanding = 162;
        int frameHeightStanding = 170;

        Point currentFrame = new Point(0, 0);
        Point spriteSize = new Point(3, 1);
        Point spriteSizeStanding = new Point(7, 1);


        int currentTime = 0; // сколько времени прошло
        int period = 140; // период обновления в миллисекундах

        public Direction Direction { get; set; }

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

        public Player(Texture2D texture, Texture2D texture1, Texture2D texture2, Texture2D texture3, Texture2D texture4 ,Rectangle rectangle)
        {
            PersonWalkBack = texture;
            PersonWalkForward = texture1;
            PersonWalkLeft = texture2;
            PersonWalkRight = texture3;
            PersonStanding = texture4;

            this.rectangle = rectangle;

            TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 400);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PersonWalkBack = Content.Load<Texture2D>("walkBack");
            PersonWalkForward = Content.Load<Texture2D>("walkForward");
            PersonWalkLeft = Content.Load<Texture2D>("walkLeft");
            PersonWalkRight = Content.Load<Texture2D>("walkRight");
            PersonStanding = Content.Load<Texture2D>("standing");

            PersonSize = new Point(PersonWalkRight.Width, PersonWalkRight.Height);
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
        public void UpdateFrameStanding(GameTime gameTime)
        {
            if (currentTime > period)
            {
                currentTime -= period; // вычитаем из текущего времени период обновления
                ++currentFrame.X; // переходим к следующему фрейму в спрайте
                if (currentFrame.X >= spriteSizeStanding.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= spriteSizeStanding.Y)
                        currentFrame.Y = 0;
                }
            }
        }

        public void Moving(GameTime gameTime, int speed)
        {

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                personPosition.X -= speed;
                UpdateFrame(gameTime);
                count = 1;
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                personPosition.X += speed;
                UpdateFrame(gameTime);
                count = 2;
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                personPosition.Y -= speed;
                UpdateFrame(gameTime);
                count = 3;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                personPosition.Y += speed;
                UpdateFrame(gameTime);
                count = 4;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                UpdateFrameStanding(gameTime);
                count = 5;
            }

        }

        public void DrawStanding(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PersonStanding, personPosition , new Rectangle(currentFrame.X * frameWidthStanding,
                    currentFrame.Y * frameHeightStanding,
                    frameWidthStanding, frameHeightStanding), Color.White ,0 ,Vector2.Zero, 1.3f, SpriteEffects.None, 0);
        }
        public void DrawRight(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PersonWalkRight, personPosition, new Rectangle(currentFrame.X * frameWidth,
                    currentFrame.Y * frameHeight,
                    frameWidth, frameHeight), Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0);
        }
        public void DrawLeft(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PersonWalkLeft, personPosition, new Rectangle(currentFrame.X * frameWidth,
                    currentFrame.Y * frameHeight,
                    frameWidth, frameHeight), Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0);
        }
        public void DrawUp(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PersonWalkForward, personPosition, new Rectangle(currentFrame.X * frameWidth,
                    currentFrame.Y * frameHeight,
                    frameWidth, frameHeight), Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0);
        }
        public void DrawDown(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PersonWalkBack, personPosition, new Rectangle(currentFrame.X * frameWidth,
                    currentFrame.Y * frameHeight,
                    frameWidth, frameHeight), Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, 0);
        }
    }
}

