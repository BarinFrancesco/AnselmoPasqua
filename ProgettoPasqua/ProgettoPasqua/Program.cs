using LMyDataStructures;
namespace ProgettoPasqua
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            SemaphoreSlim mutex = new SemaphoreSlim(1, 1);
            MyQueue<Uovo> coda = new MyQueue<Uovo>();
            //MyStak<Uovo> pila = new MyStak<Uovo>();
            List<Task> lista = new List<Task>();


            Console.WriteLine("Hello, World!");
            int n = 10; 
            Fabbrica xx = new Fabbrica(mutex, coda);
            Anselmo anselmo = new Anselmo(xx);

            lista.Add(xx.GenerateEgg(n));
            lista.Add(anselmo.GetEggs(n));
            

            await Task.WhenAll(lista);
        }
    }
}