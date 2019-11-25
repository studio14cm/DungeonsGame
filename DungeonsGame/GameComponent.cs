using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace bulletStorm3
{
    public class bullet : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Texture2D texture;
        SpriteBatch spriteBatch;

        public Vector2 координаты, ScreenSize;
        public bool начатьдвижение, удалятьможно = false;
        public float угол, шаг = 8f;

        public bullet(Game game, Vector2 ScreenSize, float угол, Texture2D texture, SpriteBatch spriteBatch)
            : base(game)
        {
            this.ScreenSize = ScreenSize;
            this.координаты = new Vector2(ScreenSize.X / 2, ScreenSize.Y / 2);
            начатьдвижение = true;
            this.угол = угол;
            this.texture = texture;
            this.spriteBatch = spriteBatch;
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            if (начатьдвижение)
                координаты += new Vector2(шаг * (float)Math.Cos(угол), шаг * (float)Math.Sin(угол));
            if ((координаты.X < -10) || (координаты.Y < -10) || (координаты.X > ScreenSize.X + 10) || (координаты.Y > ScreenSize.Y + 10))
                удалятьможно = true;
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, координаты, new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White, угол, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 1f);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}