namespace OrkEngine3D.Objects.Game;

public class ScriptedObject : Object
{
    /// <summary>
    /// This function runs every frame of the game, once the engine has loaded.
    /// <remarks>This function is NOT for any physics interactions. Please utilize <see cref="PhysicsStep"/> instead.</remarks>
    /// <remarks>For Step-based physics, please utilize the PhysicsQueue, or make your own!</remarks>
    /// </summary>
    public virtual void Step()
    {
        
    }
    
    /// <summary>
    /// Runs at the start of every scene.
    /// </summary>
    public virtual void Start()
    {
        
    }
    
    /// <summary>
    /// Runs every single time the game object is enabled
    /// </summary>
    public virtual void OnEnable()
    {
        
    }
    
    /// <summary>
    /// Runs every physics step.
    /// <remarks>Use this for any physics</remarks>
    /// </summary>
    public virtual void PhysicsStep()
    {
        
    }
}