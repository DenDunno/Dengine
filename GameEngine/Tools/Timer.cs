
public class Timer
{
    public static float Time { get; private set; }
        
    public static void Update(float deltaTime)
    {
        Time += deltaTime;
    }
}