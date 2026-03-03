using LMyDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoPasqua
{
    public class Anselmo
    {
        public Fabbrica Factory;
        public MyQueue<Uovo> CodaUovaPropria;

        public Anselmo(Fabbrica fabbrica)
        {
            Factory = fabbrica;
        }

        public void GetEggs()
        {

        }

    }
}
