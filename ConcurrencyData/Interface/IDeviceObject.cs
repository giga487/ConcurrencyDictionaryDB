namespace ConcurrencyData.Interface
{
    public interface IDeviceObject
    {
        string Name { get; }
        Type Type { get; }
        Dictionary<string, IDeviceObject> Objects { get; }
    }
}
