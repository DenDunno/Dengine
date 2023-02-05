
public class GlobalTimer : Timer
{
    public GlobalTimer(float rate) : base(rate)
    {
    }

    public override float Time => Clock.Time;
}