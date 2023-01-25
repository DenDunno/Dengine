
public struct CurveKey<T>
{
    public readonly T Value;
    public readonly float Lerp;

    public CurveKey(T value, float lerp)
    {
        Value = value;
        Lerp = lerp;
    }
}