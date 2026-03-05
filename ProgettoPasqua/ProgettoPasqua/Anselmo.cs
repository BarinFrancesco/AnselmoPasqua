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
        public MyStak<Uovo> PilaUova;
        public readonly SemaphoreSlim mutex;
        public int MaxEggs { get; set; }
        public static int totaleggs = 0;

        public Anselmo(Fabbrica fabbrica)
        {
            Factory = fabbrica;
            mutex = Factory.MutexUova;
            PilaUova = new MyStak<Uovo>();
        }

        public async Task GetEggs(int n)
        {
            MaxEggs = n;
            while (totaleggs < MaxEggs)
            {

                await mutex.WaitAsync();

                if (Factory.CodaUova.IsEmpty()) //se non c'è nessun uovo in coda aspetta
                {
                    mutex.Release();
                    await Task.Delay(100);
                    continue;
                }

                Uovo newEgg = Factory.CodaUova.Dequeue();
                mutex.Release();  //va a prendere l'ultimo uovo

                if (CheckEggs(newEgg))
                {
                    PilaUova.push(newEgg);
                    totaleggs++;

                    Console.WriteLine($"Anselmo ha aggiunto Uovo{newEgg.ID} alla pila({totaleggs} elementi) ");
                } else
                {

                    newEgg.Paint(); //se non ha i criteri viene ridipinto e rimesso in coda

                    await mutex.WaitAsync();
                    Factory.CodaUova.Enqueue(newEgg);
                    mutex.Release();
                    
                    Console.WriteLine($"Uovo{newEgg.ID} Respinto, nuovi colori Colore1:{newEgg.FirstColor}, Colore2:{newEgg.SecondColor}");
                }

                await Task.Delay(Random.Shared.Next(750, 1500));
            }
            

        }


        public bool CheckEggs(Uovo NewEgg)
        {
            if (PilaUova.isEmpty()) //se la pila è vuota allora è sempre vera
                return true;

            Uovo LastEgg = PilaUova.peek();
            //if (LastEgg == null)
              //  return true;

            if(LastEgg.FirstColor == NewEgg.FirstColor || LastEgg.FirstColor == NewEgg.SecondColor ||
               LastEgg.SecondColor == NewEgg.FirstColor || LastEgg.SecondColor == NewEgg.SecondColor) //se c'è un colore in comune
                return true;

            return false; //se non c'è nesun colore in comune allora false
        }
    }
}
