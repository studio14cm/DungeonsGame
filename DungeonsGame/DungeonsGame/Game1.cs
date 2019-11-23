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
        Texture2D PersonStanding;
        Texture2D Wall;
        Texture2D Rock;
        Vector2 position = Vector2.Zero;
        Vector2 RockPosition;
        float speed = 4.5f;
        float speedOfRock = 10f;
        int frameWidth = 155;
        int frameHeight = 170;
        int frameWidthStanding = 162;
        int frameHeightStanding = 170;
        Point currentFrame = new Point(0, 0);
        Point spriteSize = new Point(3, 1);
        Point spriteSizeStanding = new Point(7, 1);
        Point currentFrameRock = new Point(0, 0);
        Point spriteSizeRock = new Point(1, 1);
        Point PersonSize;
        Vector2 PersonPosition;
        int currentTime = 0; // сколько времени прошло
        int period = 140; // период обновления в миллисекундах
        int count = 0;
        //Texture2D Background; //фоновое изображения для меню
        //float ScaleFone = 1.0F; // масштаб фона. То есть отношение
                                // высоты экрана к высоте рисунка.
        //int DeltaXFon1 = 0; //сдвиг изображения фона от 0 влево.
                            // так, что бы оно оказалось в центре
        int rock = 0;
        KeyboardState state;
        KeyboardState oldstate;
        Color color = Color.CornflowerBlue;




        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            this.IsMouseVisible = true;
            PersonPosition = new Vector2(Window.ClientBounds.Width / 2, 0);

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
            PersonStanding = Content.Load<Texture2D>("standing");
            Wall = Content.Load<Texture2D>("wall");
            Rock = Content.Load<Texture2D>("Rock");
            PersonSize = new Point(PersonWalkRight.Width, PersonWalkRight.Height);

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
            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > Window.ClientBounds.Width)
                position.X = 0;
            if (position.Y > Window.ClientBounds.Height)
                position.Y = PersonPosition.Y - Window.ClientBounds.Height;
          
            if (keyboardState.IsKeyDown(Keys.A))
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
                
            if (keyboardState.IsKeyDown(Keys.D))
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
                
            if (keyboardState.IsKeyDown(Keys.W))
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
                
            if (keyboardState.IsKeyDown(Keys.S))
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
            if ((keyboardState.IsKeyUp(Keys.S)&& (keyboardState.IsKeyUp(Keys.W)&& (keyboardState.IsKeyUp(Keys.A)&& (keyboardState.IsKeyUp(Keys.D))))))
            {
                count = 5;
                // добавляем к текущему времени прошедшее время
                currentTime += gameTime.ElapsedGameTime.Milliseconds;
                // если текущее время превышает период обновления спрайта
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

            state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                rock = 3;
                RockPosition.X -= speedOfRock;
            }

            if (state.IsKeyDown(Keys.Right))
            {
                rock = 4;
                while (true)
                {
                    RockPosition.X += speedOfRock;
                    if (state.IsKeyUp(Keys.Right))
                    { break; }
                }
                
                
            }

            if (state.IsKeyDown(Keys.Up))
            {
                rock = 2;
                RockPosition.Y -= speedOfRock;
                
            }

            if (state.IsKeyDown(Keys.Down))
            {
                rock = 1;
                RockPosition.Y += speedOfRock; 
            }

            oldstate = state;

            base.Update(gameTime);
        }
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            spriteBatch.Draw(Wall,
                new Vector2(0, 0),
               //(Window.ClientBounds.Width / 2),
               //(Window.ClientBounds.Height / 4)),
               null,
               Color.White,
               0,
               Vector2.Zero,
               1.067f,
               SpriteEffects.None,
               0);
            spriteBatch.End();
            // отрисовка спрайта
            
            if (count == 1)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkBack, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1.3f, SpriteEffects.None, 1);
                spriteBatch.End();
                count = 0;
            }
            else if (count == 2)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkForward, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1.3f, SpriteEffects.None, 1);
                spriteBatch.End();
                count = 0;
            }
            else if (count == 3)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkLeft, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1.3f, SpriteEffects.None, 1);
                spriteBatch.End();
                count = 0;
            }
            else if (count == 4)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonWalkRight, position,
                    new Rectangle(currentFrame.X * frameWidth,
                        currentFrame.Y * frameHeight,
                        frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero,
                    1.3f, SpriteEffects.None, 1);
                spriteBatch.End();
                count = 0;
            }
            else if (count == 5)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(PersonStanding, position,
                    new Rectangle(currentFrame.X * frameWidthStanding,
                        currentFrame.Y * frameHeightStanding,
                        frameWidthStanding, frameHeightStanding),
                    Color.White, 0, Vector2.Zero,
                    1.3f, SpriteEffects.None, 1);
                spriteBatch.End();
                count = 0;
            }
            if (rock == 1)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
                spriteBatch.Draw(Rock, RockPosition, new Rectangle(currentFrameRock.X * frameWidth,
                        currentFrameRock.Y * frameHeight,
                        frameWidth, frameHeight), Color.White);
                spriteBatch.End();
                RockPosition.Y = position.Y;
                RockPosition.X = position.X;
                rock = 0;
            }
            else if (rock == 2)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(Rock, RockPosition, new Rectangle(currentFrameRock.X * frameWidth,
                        currentFrameRock.Y * frameHeight,
                        frameWidth, frameHeight), Color.White);
                spriteBatch.End();
                rock = 0;
                RockPosition = position;
            }
            else if (rock == 3)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(Rock, RockPosition, new Rectangle(currentFrameRock.X * frameWidth,
                        currentFrameRock.Y * frameHeight,
                        frameWidth, frameHeight), Color.White);
                spriteBatch.End();
                rock = 0;
                RockPosition = position;
            }
            else if (rock == 4)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                spriteBatch.Draw(Rock, RockPosition, new Rectangle(currentFrameRock.X * frameWidth,
                        currentFrameRock.Y * frameHeight,
                        frameWidth, frameHeight), Color.White);
                spriteBatch.End();
                rock = 0;
                RockPosition = position;
            }

            //else if (count == 6)
            //{
            //    spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            //
            //    spriteBatch.Draw(PersonShooting, position,
            //        new Rectangle(currentFrame.X * frameWidth,
            //            currentFrame.Y * frameHeight,
            //            frameWidth, frameHeight),
            //        Color.White, 0, Vector2.Zero,
            //        1.5f, SpriteEffects.None, 1);
            //    spriteBatch.End();
            //    count = 0;
            //}

            base.Draw(gameTime);
        }
    }
}
