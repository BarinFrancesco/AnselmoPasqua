/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LMyDataStructures;
namespace ProgettoPasqua
{
    public class MyCuncurrentQueue<T>
    {
        private MyQueue<T> Coda;
        private SemaphoreSlim Mutex;

        public MyCuncurrentQueue()
        {
            Mutex = new SemaphoreSlim(1, 1);
            Coda = new MyQueue<T>();
        }

        public async void Enqueue( T element)
        {
            await Mutex.WaitAsync();
            Coda.Enqueue(element);
            Mutex.Release();

            //Coda.Clear;
            //Coda.Dequeue;
            Coda.Peek;
            Coda.Clear;
            Coda.IsEmpty;
                
        }

        public async Task<T> Dequeue() //controlla caso vuota
        {
            T temp;
            await Mutex.WaitAsync();
            temp = Coda.Dequeue();
            Mutex.Release();

            return temp;
        }
         
        public async void Clear()
        {
            await Mutex.WaitAsync();
            Coda.Clear();
            Mutex.Release();
        }

    }
}
*/