
public class LocalTimer : Timer
{
    private float _time;
    
    public LocalTimer(float rate) : base(rate)
    {
    }

    public void AddDelta(float deltaTime)
    {
        _time += deltaTime;
    }

    public override float Time => _time;
}