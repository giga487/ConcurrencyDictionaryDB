using ConcurrencyData.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyData.TestObject
{
    public class SimpleData : IDeviceObject
    {
        public string Name { get; set; } = "DEF";
        public int Value { get; set; } = 0;
        public Type Type { get; set; } = typeof(SimpleData);
        public Dictionary<string, IDeviceObject> Objects { get; set; } = new Dictionary<string, IDeviceObject>();
    }
}
