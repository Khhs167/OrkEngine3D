namespace OrkEngine3D.Graphics.SILK;

public abstract class GraphicsHandler
{

    internal GraphicsContext context;
    
    public abstract void Init();
    public abstract void Render();
    public abstract void Update();
    public abstract void Resize();
    public abstract void Unload();
}