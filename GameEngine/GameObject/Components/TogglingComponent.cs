
public abstract class TogglingComponent : IGameComponent
{
    public bool Enabled = true;

    void IGameComponent.Update(float deltaTime)
    {
        if (Enabled)
        {
            OnUpdate(deltaTime);
        }
    }

    protected abstract void OnUpdate(float deltaTime);
}