
public abstract class Timer
{
    public readonly float Rate;
    private float _clock;

    protected Timer(float rate)
    {
        Rate = rate;
    }

    public bool Elapsed => Time >= Value;
    public float Value => _clock + Rate;
    
    public void Reset()
    {
        _clock = Time;
    }

    public abstract float Time { get; }
}