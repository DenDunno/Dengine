
public abstract class Timer
{
    public readonly float Rate;
    private readonly Action _callBack;
    private float _clock;

    protected Timer(float rate, Action callBack)
    {
        _callBack = callBack;
        Rate = rate;
    }

    public float Difference => Time - _clock;
    private bool Elapsed => Time >= _clock + Rate;
    
    public void Update(float deltaTime)
    {
        OnUpdate(deltaTime);
        
        if (Elapsed)
        {
            _callBack();
            _clock = Time;
        }
    }

    protected virtual void OnUpdate(float deltaTime) {}
    public abstract float Time { get; }
}