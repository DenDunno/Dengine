
public class LocalTimer : Timer
{
    private float _time;
    
    public LocalTimer(float rate, Action action) : base(rate, action)
    {
    }

    protected override void OnUpdate(float deltaTime)
    {
        _time += deltaTime;
    }

    public override float Time => _time;
}