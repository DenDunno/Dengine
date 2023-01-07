
[HideInInspector]
public class Timer : IGameComponent
{
    public static float Time { get; private set; }
        
    public void Update(float deltaTime)
    {
        Time += deltaTime;
    }
}