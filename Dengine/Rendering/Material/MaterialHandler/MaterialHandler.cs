
public abstract class MaterialHandler
{
    protected readonly ShaderBridge Bridge;

    protected MaterialHandler(ShaderBridge bridge)
    {
        Bridge = bridge;
    }

    public virtual void Initialize() { }
    public virtual void Use() { }
    public virtual void Dispose() { }
}