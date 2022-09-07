
public class Timer : IUpdatable
{
    public static float Time { get; private set; }

    void IUpdatable.Update(float deltaTime)
    {
        Time += deltaTime;
    }
}