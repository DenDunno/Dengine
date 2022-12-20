
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
        float coolDown = Timer.Time - _clock;
        _clock = Timer.Time;
        _fps = 0;

        return (int)(temp / coolDown);
    }
}