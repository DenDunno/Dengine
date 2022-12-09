
public class FPSCounter : IUpdatable
{
    private int _fps;
    private float _clock;

    public int Value { get; private set; }
    
    public void Update(float deltaTime)
    {
        _fps++;
        
        if (Timer.Time > _clock + 1)
        {
            _clock = Timer.Time;
            Value = _fps;
            _fps = 0;
        }
    }
}