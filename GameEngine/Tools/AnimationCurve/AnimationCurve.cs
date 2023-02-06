
public class AnimationCurve<T>
{
    private readonly IReadOnlyList<CurvePart<T>> _parts;

    public AnimationCurve(T constant) : this(constant, constant, EasingFunctions.Linear)
    {
    }
    
    public AnimationCurve(T first, T second) : this(first, second, EasingFunctions.Linear)
    {
    }

    private AnimationCurve(T first, T second, IEasingFunction easingFunction)
    {
        _parts = new[]
        {
            new CurvePart<T>()
            {
                FirstKey = new CurveKey<T>(first, 0),
                SecondKey = new CurveKey<T>(second, 1),
                EasingFunction = easingFunction
            }
        };
    }

    public AnimationCurve(IReadOnlyList<CurvePart<T>> parts)
    {
        _parts = parts;
    }

    public T GetValue(float lerp)
    {
        if (lerp is > 1 or < 0)
        {
            throw new ArgumentException ($"Lerp must be between 0 - 1. Input = {lerp}");
        }

        for (int i = 0; i < _parts.Count; ++i)
        {
            if (_parts[i].InRange(lerp))
            {
                return _parts[i].Evaluate(lerp);
            }
        }

        throw new ArgumentException ("Bad curve was created");
    }
}