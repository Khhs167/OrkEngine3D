namespace OrkEngine3D.Objects;

public class Object : ICloneable
{
    public string Name;
    public string ID;

    private static readonly ObjectPool Pool = new ObjectPool();

    public static Object Instantiate(Object template)
    {
        Object o = (Object)template.Clone();
        o.ID = Pool.AddObject(o);
        return o;
    }
    
    public static Object Instantiate<T>() where T : Object, new()
    {
        Object o = new T();
        o.ID = Pool.AddObject(o);
        return o;
    }

    private Object()
    {
        this.Name = "";
        this.ID = "";
    }


    public object Clone()
    {
        return this.MemberwiseClone();
    }
}