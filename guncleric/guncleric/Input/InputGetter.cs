using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric.Input
{
    public class InputGetter
    {
        public GunClericInputCommand GetCommandFromConsole(ConsoleKeyInfo keyInfo)
        {
            var input = GunClericInputCommand.None;

            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    input |= GunClericInputCommand.Left;
                    break;
                case ConsoleKey.D:
                    input |= GunClericInputCommand.Right;
                    break;
                case ConsoleKey.W:
                    input |= GunClericInputCommand.Up;
                    break;
                case ConsoleKey.S:
                    input |= GunClericInputCommand.Down;
                    break;
            }

            return input;
        }
    }
}
