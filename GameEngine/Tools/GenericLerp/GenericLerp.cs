using System.Drawing;

public static class GenericLerp
{
    private static readonly Dictionary<Type, ILerpWrapper> _lerpFunction = new()
    {
        {typeof(float), new FloatLerp()},
        {typeof(Color), new ColorLerp()}
    };
        
    public static T Evaluate<T>(T first, T second, float lerp)
    {
        if (_lerpFunction.TryGetValue(typeof(T), out ILerpWrapper? lerpWrapper))
        {
            ILerp<T> lerpFunction = (ILerp<T>)lerpWrapper;

            return lerpFunction.Evaluate(first, second, lerp);
        }

        throw new ArgumentException($"Type {typeof(T)} has no lerp implementation");
    }
}