
public class Timer : IUpdatable
{
    private readonly Window _window;
    
    public Timer(Window window)
    {
        _window = window;
    }
    
    public static float Time { get; private set; }

    void IUpdatable.Update(float deltaTime)
    {
        Time += deltaTime;
    }
}