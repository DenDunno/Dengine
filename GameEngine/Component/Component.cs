
public class Component : IUpdatable
{
    private readonly IUpdatable _logic;
    private bool _enabled;

    public Component(IUpdatable logic)
    {
        _logic = logic;
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
            _logic.Update(deltaTime);
        }
    }
}