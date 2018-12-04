using guncleric.Actors.Interfaces;
using guncleric.Display;
using guncleric.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric.Actors.Concrete
{
    public class Prop : IActor, ISingleSprite
    {
        public Prop(char sprite, int x, int y, int z=0)
        {
            Sprite = sprite;
            Location = new Vector3(x, y, z);
        }

        public char Sprite { get; }

        public Vector3 Location { get; }
    }
}
