
public class CurvePart<T>
{
    public CurveKey<T> FirstKey { get; init; }
    public CurveKey<T> SecondKey { get; init; }
    public IEasingFunction EasingFunction { get; init; } = EasingFunctions.Linear;

    public bool InRange(float lerp)
    {
        if (FirstKey.Lerp >= SecondKey.Lerp)
        {
            throw new Exception($"Bad curve was created. {FirstKey.Lerp} must be greater than {SecondKey.Lerp}");
        }
        
        return lerp >= FirstKey.Lerp && lerp <= SecondKey.Lerp;
    }
    
    public T Evaluate(float lerp)
    {
        lerp = Algorithms.InverseLerp(FirstKey.Lerp, SecondKey.Lerp, lerp);
        lerp = EasingFunction.Evaluate(lerp);
        
        return GenericLerp.Evaluate(FirstKey.Value, SecondKey.Value, lerp);
    }
}