
public class FPSCounter : IUpdatable
{
    private readonly Window _window;
    private float _clock;
    private int _fps;
    
    public FPSCounter(Window window)
    {
        _window = window;
    }
    
    void IUpdatable.Update(float deltaTime)
    {
        _fps++;
        
        if (Timer.Time > _clock + 1)
        {
            _clock = Timer.Time;
            _window.Title = $"FPS = {_fps}";
            _fps = 0;
        }
    }
}