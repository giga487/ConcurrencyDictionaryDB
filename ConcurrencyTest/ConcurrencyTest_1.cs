using ConcurrencyData.Interface;
using ConcurrencyData.Manager;
using ConcurrencyData.TestObject;

namespace ConcurrencyTest
{
    [TestClass]
    public class ConcurrencyTest_1
    {
        static DataManager _DataManager = new DataManager()
        {
            Name = "TEST"
        };

        static int N => 1_000;

        [TestMethod]
        public void AddNObjects()
        {
            for (int i = 0; i < N; i++)
            {
                string name = $"NAME{i}";
                var simple = new SimpleData() { Name = name };
                simple.Objects[$"TEST{i}"] = new SimpleData()
                {
                    Name = "TO_READ"
                };

                _DataManager.Add(name, simple);
            }
        }

        [DoNotParallelize]
        [TestMethod]
        public void ReadNObjects()
        {
            for (int i = 0; i < N; i++)
            {
                string name = $"NAME{i}";
                var t = _DataManager.Get(name);

                if (t is null)
                {
                    Assert.Fail();
                }
            }
        }
    }
}