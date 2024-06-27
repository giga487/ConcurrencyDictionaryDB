using ConcurrencyData.Manager;
using ConcurrencyData.TestObject;

namespace MainProgramTest
{
    internal class Program
    {
        static string name = "Test{0}";
        static DataManager _manager = new DataManager() { Name = "Test" };
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

            for (int i = 0; i < N; i++)
            {
                var nameT = string.Format(name, i);
                _manager.Add(string.Format(nameT, i), new SimpleData()
                {
                    Name = nameT
                });
            }

            Task.Run(() => Updater());
            Task.Run(() => Reader());
            Task.Run(() => Reader());
            Task.Run(() => Reader());


            while (true)
            {
                Console.ReadLine();
            }
        }

        static int N = 10;
        public async static void Updater()
        {
            while (true)
            {
                for (int i = 0; i < N; i++)
                {
                    var nameT = string.Format(name, i);
                    SimpleData? data = (SimpleData)_manager.Get(nameT) ?? null;
                    data.Value++;

                    await Task.Delay(100);
                }

                await Task.Delay(500);
            }

        }
        public async static void Reader()
        {
            while (true)
            {
                for (int i = 0; i < N; i++)
                {
                    var nameT = string.Format(name, i);
                    var data = (SimpleData)_manager.Get(nameT);
                    Console.WriteLine($"{data.Name} => {data.Value}");

                    await Task.Delay(200);
                }
            }
        }
    }
}
