
public class FPSCounter
{
    private int _fps;
    private float _clock;
    public int Value { get; private set; }
    
    public void Update()
    {
        _fps++;
    }

    public void UpdateValue()
    {
        int temp = _fps;
        float coolDown = Clock.Time - _clock;
        _clock = Clock.Time;
        _fps = 0;

        Value = (int) (temp / coolDown);
    }
}