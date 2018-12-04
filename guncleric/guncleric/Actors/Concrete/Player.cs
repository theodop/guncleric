using guncleric.Actors.Interfaces;
using guncleric.Display;
using guncleric.Input;
using guncleric.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric.Actors.Concrete
{
    public class Player : IActor, ISingleSprite, IRespondsToInput
    {
        public char Sprite { get; } = '@';

        public Vector3 Location { get; private set; } = new Vector3(0, 0, 0);

        public void GiveInput(GunClericInputCommand input)
        {
            if (input.HasFlag(GunClericInputCommand.Up))
            {
                Location = Location.MoveUp();
            }
            else if (input.HasFlag(GunClericInputCommand.Down))
            {
                Location = Location.MoveDown();
            }
            else if (input.HasFlag(GunClericInputCommand.Left))
            {
                Location = Location.MoveLeft();
            }
            else if (input.HasFlag(GunClericInputCommand.Right))
            {
                Location = Location.MoveRight();
            }
        }
    }
}
