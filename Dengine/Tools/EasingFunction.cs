
public static class EasingFunctions
{
    public static readonly InOutQuad InOutQuad = new();
    public static readonly Linear Linear = new();
}

public interface IEasingFunction
{
    float Evaluate(float x);
}

public class InOutQuad : IEasingFunction
{
    public float Evaluate(float x)
    {
        return x < 0.5 ? 2 * x * x : 1 - MathF.Pow(-2 * x + 2, 2) / 2;
    }
}

public class Linear : IEasingFunction
{
    public float Evaluate(float x)
    {
        return x;
    }
}