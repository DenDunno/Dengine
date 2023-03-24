
public abstract class TogglingComponent : IGameComponent
{
    [EditorField] public bool Enabled = true;

    void IGameComponent.Update(float deltaTime)
    {
        if (Enabled)
        {
            OnUpdate(deltaTime);
        }
    }
    
    void IGameComponent.Initialize()
    {
        OnInitialize();
    }

    protected virtual void OnInitialize() {}
    protected abstract void OnUpdate(float deltaTime);
}