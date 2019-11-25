using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using DungeonsGame;



namespace DungeonsGame
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 RockPosition = Vector2.Zero;
        Texture2D Wall;
        Texture2D Rock;
        Point currentFrameRock = new Point(0, 0);
        Point spriteSizeRock = new Point(1, 1);
        //Texture2D Background; //фоновое изображения для меню
        //float ScaleFone = 1.0F; // масштаб фона. То есть отношение
        // высоты экрана к высоте рисунка.
        //int DeltaXFon1 = 0; //сдвиг изображения фона от 0 влево.
        // так, что бы оно оказалось в центре
        //int rock = 0;

        Color color = Color.CornflowerBlue;

        List<GameComponent> ds = new List<GameComponent>();

        Player player;

        Container cont;

        public Texture2D PersonWalkBack { get; set; }
        public Texture2D PersonWalkForward { get; set; }
        public Texture2D PersonWalkLeft { get; set; }
        public Texture2D PersonWalkRight { get; set; }
        public Texture2D PersonStanding { get; set; }

        public Vector2 position = Vector2.Zero;
        public Point PersonSize { get; set; }
        
        Point currentFrame = new Point(0, 0);
        Point spriteSize = new Point(3, 1);
        Point spriteSizeStanding = new Point(7, 1);

        public int count = 0;

        public Game1()
        {
            Window.Title = "Dungeons";
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            cont = new Container(new Line(10, graphics.PreferredBackBufferWidth), new Line(10, graphics.PreferredBackBufferHeight));

           // graphics.IsFullScreen = true;
            this.IsMouseVisible = true;
            

        }
        

        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Wall = Content.Load<Texture2D>("wall");
            Rock = Content.Load<Texture2D>("Rock");

            player = new Player (PersonWalkBack = Content.Load<Texture2D>("walkBack"), PersonWalkForward = Content.Load<Texture2D>("walkForward"), PersonWalkLeft = Content.Load<Texture2D>("walkLeft"), PersonWalkRight = Content.Load<Texture2D>("walkRight"), Content.Load<Texture2D>("standing"), new Rectangle(600, 600, 30, 30));

            player.Direction = Direction.Right;
        }

      
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (IsActive)
            {

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                    Exit();

                player.Moving(gameTime, 4);

                if (player.personPosition.X < 0)
                    player.personPosition.X = 0;
                if (player.personPosition.Y < 0)
                    player.personPosition.Y = 0;
                if (player.personPosition.X > graphics.PreferredBackBufferWidth)
                    player.personPosition.X = cont.Width.X2;
                if (player.personPosition.Y > Window.ClientBounds.Height)
                    player.personPosition.Y = cont.Height.X2;
                base.Update(gameTime);
            }
                
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            spriteBatch.Draw(Wall,
                new Vector2(0, 0),
               null,
               Color.White,
               0,
               Vector2.Zero,
               1.067f,
               SpriteEffects.None,
               0);

            spriteBatch.End();
            if (player.count == 1)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                player.DrawLeft(gameTime, spriteBatch);

                spriteBatch.End();

                count = 0;
            }
            else if (player.count == 2)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                player.DrawRight(gameTime, spriteBatch);

                spriteBatch.End();

                count = 0;
            }
            else if (player.count == 3)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                player.DrawUp(gameTime,spriteBatch);

                spriteBatch.End();

                count = 0;
            }
            else if (player.count == 4)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                player.DrawDown(gameTime, spriteBatch);

                spriteBatch.End();

                count = 0;
            }
            else if (player.count == 5)
            {
                spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

                player.DrawStanding(gameTime, spriteBatch);

                spriteBatch.End();

                count = 0;
            }
            // отрисовка спрайта
            base.Draw(gameTime);
        }
    }
}
