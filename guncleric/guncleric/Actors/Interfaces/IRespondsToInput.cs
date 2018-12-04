using guncleric.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric.Actors.Interfaces
{
    interface IRespondsToInput
    {
        void GiveInput(GunClericInputCommand input);
    }
}
