using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonsGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D PersonWalkBack;
        Texture2D PersonWalkForward;
        Texture2D PersonWalkLeft;
        Texture2D PersonWalkRight;
        Vector2 position = Vector2.Zero;
        float speed = 2f;
        int frameWidth = 160;
        int frameHeight = 170;
        Point currentFrame = new Point(0, 0);
        Point spriteSize = new Point(3, 1);
        int currentTime = 0; // сколько времени прошло
        int period = 140; // период обновления в миллисекундах
        int count = 0;
        



        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            this.IsMouseVisible = true;
            
        }
        

        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PersonWalkBack = Content.Load<Texture2D>("walkBack");
            PersonWalkForward = Content.Load<Texture2D>("walkForward");
            PersonWalkLeft = Content.Load<Texture2D>("walkLeft");
            PersonWalkRight = Content.Load<Texture2D>("walkRight");

        }

      
        protected override void UnloadContent()
        {
            
        }

      
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                count = 3;
                position.X -= speed;
                // добавляем к текущему времени прошедшее время
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                // если текущее время превышает период обновления спрайта
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
                
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                count = 4;
                position.X += speed;
                // добавляем к текущему времени прошедшее время
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                // если текущее время превышает период обновления спрайта
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
                
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                count = 2;
                position.Y -= speed;
                // добавляем к текущему времени прошедшее время
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                // если текущее время превышает период обновления спрайта
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
                
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                count = 1;
                position.Y += speed;
                // добавляем к текущему времени прошедшее время
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                // если текущее время превышает период обновления спрайта
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
                

           

            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // отрисовка спрайта
            if (count == 1)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkBack, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1, SpriteEffects.None, 0);

                spriteBatch.End();
            }
            else if (count == 2)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkForward, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1, SpriteEffects.None, 0);

                spriteBatch.End();
            }
            else if (count == 3)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkLeft, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1, SpriteEffects.None, 0);

                spriteBatch.End();
            }
            else if (count == 4)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkRight, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1, SpriteEffects.None, 0);

                spriteBatch.End();
            }


            base.Draw(gameTime);
        }
    }
}
