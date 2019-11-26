using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsGame
{
    class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Position(int x,int y)
        {
            X = x;

            Y = y;
        }

        public static Position ComputePosition(Container container)
        {
            Random r = new Random();

            return new Position(r.Next(container.Width.X1, container.Width.X2),
                                r.Next(container.Height.X1,container.Height.X2));
        }
    }
}
