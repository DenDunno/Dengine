
public class FPSCounter : IGameComponent
{
    private int _fps;
    private float _clock;

    public void Update(float deltaTime)
    {
        _fps++;
    }

    public int GetValue()
    {
        int temp = _fps;
        float tempClock = _clock;
        _fps = 0;
        _clock = 0;
        
        return (int)(temp / 0.25f);
    }
}