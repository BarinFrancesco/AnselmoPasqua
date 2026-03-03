using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMyDataStructures;

namespace ProgettoPasqua
{
    public class Uovo
    {

        private static int count = 0;

        public int ID { get; private set; }
        public Colori FirstColor { get; private set; }
        public Colori SecondColor { get; private set; }

        public Uovo()
        {
            ID = count;
            count++;
            Paint();
        }

        public void Paint()
        {
            FirstColor = (Colori)Random.Shared.Next(0, Enum.GetValues<Colori>().Length); //sceglie un valore random tra 0 e il massimo numero, e lo "casta" in enum
            SecondColor = (Colori)Random.Shared.Next(0, Enum.GetValues<Colori>().Length);
        }
    }
}
