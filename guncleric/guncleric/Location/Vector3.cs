using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric.Location
{
    public struct Vector3
    {
        public int X;
        public int Y;
        public int Z;

        public Vector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 MoveUp(int amount = 1)
        {
            return new Vector3(X, Y - 1, Z);
        }

        public Vector3 MoveDown(int amount = 1)
        {
            return new Vector3(X, Y + 1, Z);
        }

        public Vector3 MoveLeft(int amount = 1)
        {
            return new Vector3(X - 1, Y, Z);
        }

        public Vector3 MoveRight(int amount = 1)
        {
            return new Vector3(X + 1, Y, Z);
        }
    }
}
