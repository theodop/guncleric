using guncleric.Actors.Concrete;
using guncleric.Controllers;
using guncleric.Display;
using guncleric.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guncleric
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var inputGetter = new InputGetter();
            var actorController = new ActorController();
            actorController.AddActor(new Player());
            actorController.AddActor(new Prop('x', 10, 10));

            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                var input = inputGetter.GetCommandFromConsole(key);
                actorController.GiveInput(input);

                Console.Clear();

                foreach(var actor in actorController.GetActorsOfType<ISingleSprite>())
                {
                    Console.SetCursorPosition(actor.Location.X, actor.Location.Y);
                    Console.Write(actor.Sprite);
                }
            }
        }
    }
}
