
public class Timer : IUpdatable
{
    public static float Time { get; private set; }
    public static readonly float FixedDeltaTime = 0.01f;
        
    void IUpdatable.Update(float deltaTime)
    {
        Time += deltaTime;
    }
}