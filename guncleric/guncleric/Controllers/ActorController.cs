using guncleric.Actors.Interfaces;
using guncleric.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric.Controllers
{
    public class ActorController
    {
        private LinkedList<IActor> _actors = new LinkedList<IActor>();

        public IEnumerable<T> GetActorsOfType<T>()
        {
            return _actors.Where(x => x is T).Cast<T>();
        }

        public void AddActor(IActor actor)
        {
            _actors.AddLast(actor);
        }

        public void GiveInput(GunClericInputCommand input)
        {
            foreach (var actor in GetActorsOfType<IRespondsToInput>())
            {
                actor.GiveInput(input);
            }
        }
    }
}
