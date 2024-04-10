using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgWspolbiezne.Model
{
    public class Ball(ushort radius, ushort x, ushort y, short vx, short vy, Color color)
    {
        public ushort Radius { get; } = radius;
        public ushort X { get; set; } = x;
        public ushort Y { get; set; } = y;
        public short Vx { get; set; } = vx;
        public short Vy { get; set; } = vy;
        public Color Color { get; } = color;

        public void Move ()
        {
            X += (ushort)Vx;
            Y += (ushort)Vy;
        }
    }
}
