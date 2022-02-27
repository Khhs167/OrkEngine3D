namespace OrkEngine3D.Objects;

public class Object : ICloneable
{
    public string Name;
    public string Id;

    private static readonly ObjectPool Pool = new ObjectPool();

    public static Object Instantiate(Object template)
    {
        Object o = (Object)template.Clone();
        o.Id = Pool.AddObject(o);
        return o;
    }
    
    public static T Instantiate<T>() where T : Object, new()
    {
        T o = new T();
        o.Id = Pool.AddObject(o);
        return o;
    }

    private protected Object()
    {
        this.Name = "";
        this.Id = "";
    }


    public object Clone()
    {
        return this.MemberwiseClone();
    }
}