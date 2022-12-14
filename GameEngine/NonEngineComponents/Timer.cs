
public class Timer : IGameComponent
{
    public static float Time { get; private set; }
        
    void IGameComponent.Update(float deltaTime)
    {
        Time += deltaTime;
    }
}