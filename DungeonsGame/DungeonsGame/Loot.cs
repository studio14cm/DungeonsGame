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
    class Loot
    {
        public Texture2D Texture { get; set; }

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

        public bool WasTaken { get; set; } = false;


        public Loot(Texture2D coin, Rectangle rectangle)
        {
            Texture = coin;

            this.rectangle = rectangle;
        }
        public Loot(Texture2D coin, Rectangle rectangle, Position position)
        {
            Texture = coin;

            this.rectangle = rectangle;

            X = position.X;

            Y = position.Y;
        }

        public void SetPosition(Position position)
        {
            X = position.X;

            Y = position.Y;
        }


    }
}
