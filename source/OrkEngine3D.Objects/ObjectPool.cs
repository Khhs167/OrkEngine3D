using OrkEngine3D.Diagnostics.Logging;

namespace OrkEngine3D.Objects;

public class ObjectPool
{
    private Dictionary<string, Object> objects = new Dictionary<string, Object>();
    public static readonly int MaxObjects = Int32.MaxValue;
    private static readonly Logger Logger = Logger.Get("ObjectPool", "Objects");

    public string AddObject(Object o)
    {
        string id = Guid.NewGuid().ToString();
        objects.Add(id, o);

        return id;
    }

    public Object? GetObject(string id)
    {
        if (!objects.ContainsKey(id))
        {
            Logger.Log(LogMessageType.ERROR, "Tried to fetch invalid object " + id);
            return null;
        }

        return objects[id];
    }
}