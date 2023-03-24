
public class GlobalTimer : Timer
{
    public GlobalTimer(float rate, Action action) : base(rate, action)
    {
    }

    public override float Time => Clock.Time;
}