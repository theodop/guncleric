using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric.Input
{
    [Flags]
    public enum GunClericInputCommand
    {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
    }
}
