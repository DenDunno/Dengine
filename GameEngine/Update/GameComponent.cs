
public abstract class GameComponent : IUpdatable
{
    public bool Enabled = true;

    void IUpdatable.Update(float deltaTime)
    {
        if (Enabled)
        {
            OnUpdate(deltaTime);
        }
    }

    protected abstract void OnUpdate(float deltaTime);
}