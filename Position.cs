using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Position
    {
        public int X;
        public int Y;

        public void Zero() { X = 0; Y = 0; }
        public void Forward() => X++;
        public void Backward() => X--;
        public void Upward() => Y++;
        public void Downward() => Y--;
    }

    public enum Direction
    {
        Forward,
        Backward,
        Upward,
        Downward
    }
}