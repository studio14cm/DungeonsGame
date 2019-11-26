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
        Loot loot;

        int coins;

        Color color = Color.CornflowerBlue;

        List<GameComponent> ds = new List<GameComponent>();

        Player player;

        Container cont;

        SpriteFont MainFont;

        public Texture2D PersonWalkBack { get; set; }
        public Texture2D PersonWalkForward { get; set; }
        public Texture2D PersonWalkLeft { get; set; }
        public Texture2D PersonWalkRight { get; set; }
        public Texture2D PersonStanding { get; set; }

        Texture2D Background;

        public Vector2 position = Vector2.Zero;

        public Point PersonSize { get; set; }
        
        Point currentFrame = new Point(0, 0);
        Point spriteSize = new Point(3, 1);
        Point spriteSizeStanding = new Point(7, 1);

        public int count = 0;

        int Coins
        {
            get
            {
                return coins;
            }
            set
            {
                if (value < 0)
                    coins = 0;
                else
                    coins += value;
            }
        }

        public Game1()
        {
            Window.Title = "Dungeons";
            Content.RootDirectory = "Content";

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            cont = new Container(new Line(10, graphics.PreferredBackBufferWidth-10), new Line(10, graphics.PreferredBackBufferHeight-10));

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

           
            Rock = Content.Load<Texture2D>("Rock");
            Background = Content.Load<Texture2D>("background");

            loot= new Loot(Content.Load<Texture2D>("Rock"), new Rectangle(0,0, 60, 60),Position.ComputePosition(cont));

            player = new Player (
                PersonWalkBack = Content.Load<Texture2D>("walkBack"), 
                PersonWalkForward = Content.Load<Texture2D>("walkForward"), 
                PersonWalkLeft = Content.Load<Texture2D>("walkLeft"), 
                PersonWalkRight = Content.Load<Texture2D>("walkRight"), 
                Content.Load<Texture2D>("standing"), 

                new Rectangle(30, cont.Height.X2/2, 155, 170));

            player.Direction = Direction.Right;

            MainFont = Content.Load<SpriteFont>("Main");
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
                if (loot.WasTaken)
                {
                    loot.SetPosition(Position.ComputePosition(cont));

                    loot.WasTaken = false;
                }

                player.Moving(gameTime, 4);

                if (player.personPosition.X < 0)
                    player.personPosition.X = 0;
                if (player.personPosition.Y < 0)
                    player.personPosition.Y = 0;
                if (player.personPosition.X > graphics.PreferredBackBufferWidth)
                {

                }
               
                if (player.personPosition.Y > Window.ClientBounds.Height)
                {

                }
                    
                base.Update(gameTime);

                if (player.Rectangle.Intersects(loot.Rectangle))
                {
                    loot.WasTaken = true;
                    Coins++;
                }
                
            }
                
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            spriteBatch.Draw(Background,
                new Vector2(0, 0),
               null,
               Color.White,
               0,
               Vector2.Zero,
               1f,
               SpriteEffects.None,
               0);
            if (player.count == 1)
            {
                player.DrawLeft(gameTime, spriteBatch);
                player.DrawLeftRectangle(gameTime, spriteBatch);

                count = 0;
            }
            else if (player.count == 2)
            {
                player.DrawRight(gameTime, spriteBatch);
                player.DrawRightRectangle(gameTime, spriteBatch);

                count = 0;
            }
            else if (player.count == 3)
            {
                player.DrawUp(gameTime,spriteBatch);
                player.DrawUpRectangle(gameTime, spriteBatch);

                count = 0;
            }
            else if (player.count == 4)
            {
                player.DrawDown(gameTime, spriteBatch);
                player.DrawDownRectangle(gameTime, spriteBatch);

                count = 0;
            }
            else if (player.count == 5)
            {
                player.DrawStanding(gameTime, spriteBatch);
                player.DrawStandingRectangle(gameTime, spriteBatch);
                count = 0;
            }

            spriteBatch.Draw(loot.Texture, loot.Rectangle, Color.White);
            spriteBatch.DrawString(MainFont, $"Score : {Coins}", new Vector2(10, 7), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
