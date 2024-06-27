using ConcurrencyData.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyData.Manager
{
    public class DataManager
    {
        public string Name { get; set; }
        private ConcurrentDictionary<string, IDeviceObject> _data { get; set; } = new ConcurrentDictionary<string, IDeviceObject>();
        public ConcurrentDictionary<string, IDeviceObject> Data => _data;
        public DataManager()
        {

        }

        public bool Add(string key, IDeviceObject deviceObject, bool ovrd = false)
        {
            if (deviceObject is null)
                return false;

            if (ovrd)
            {
                _data[key] = deviceObject;
            }

            return _data.TryAdd(key, deviceObject);
        }

        public void Clear() 
        {
            _data.Clear(); 
        }

        public IDeviceObject? Get(string key)
        {
            if (_data.TryGetValue(key, out IDeviceObject? deviceObject))
            {
                return deviceObject;
            }

            return null;
        }
    }
}
