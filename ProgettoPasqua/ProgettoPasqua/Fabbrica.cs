using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMyDataStructures;
namespace ProgettoPasqua
{
    public class Fabbrica
    {
        public MyQueue<Uovo> CodaUova;
        public readonly SemaphoreSlim MutexUova;
        public int MaxEggs { get; set; }
        public Fabbrica (SemaphoreSlim Mutex, MyQueue<Uovo> Coda )
        {
            MutexUova = Mutex;
            CodaUova = Coda;
        }

        public async Task GenerateEgg(int n)
        {
            MaxEggs = n;

            for(int i=0; i<MaxEggs; i++)
            {
                Uovo UovoNuovo = new Uovo();

                await MutexUova.WaitAsync();
                CodaUova.Enqueue(UovoNuovo);
                Console.WriteLine($"La fabbrica ha prodotto l'uovo N {UovoNuovo.ID}, Colore1:{UovoNuovo.FirstColor} Colore2:{UovoNuovo.SecondColor}");
                MutexUova.Release();
                await Task.Delay(Random.Shared.Next(750, 1500));
            }
            
        }

    }
}
