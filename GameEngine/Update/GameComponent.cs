
public abstract class GameComponent : IUpdatable
{
    private bool _enabled;

    public void Toggle()
    {
        _enabled = !_enabled;
    }
    
    public void Enable()
    {
        _enabled = true;
    }
    
    public void Disable()
    {
        _enabled = false;
    }
    
    void IUpdatable.Update(float deltaTime)
    {
        if (_enabled)
        {
            OnUpdate(deltaTime);
        }
    }

    protected abstract void OnUpdate(float deltaTime);
}