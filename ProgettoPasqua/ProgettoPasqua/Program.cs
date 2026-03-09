using LMyDataStructures;
namespace ProgettoPasqua
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            SemaphoreSlim mutex = new SemaphoreSlim(1, 1);
            MyQueue<Uovo> coda = new MyQueue<Uovo>();
            List<Task> lista = new List<Task>();


            Console.WriteLine("Inizio Programma");
            Console.WriteLine("Per favore inserire Il numero di uova da nascondere");
            int n = 10;
            while (!int.TryParse(Console.ReadLine(), out n) || n<=0 || n>30)
            {
                Console.WriteLine("Per favore inserire un numero positivo minore di 30: ");
            }

            Fabbrica xx = new Fabbrica(mutex, coda);
            Anselmo anselmo = new Anselmo(xx);

            lista.Add(xx.GenerateEgg(n));
            lista.Add(anselmo.GetEggs(n));
            

            await Task.WhenAll(lista);
        }
    }
}