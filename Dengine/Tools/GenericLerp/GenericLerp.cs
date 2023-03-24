using System.Drawing;
using OpenTK.Mathematics;

public static class GenericLerp
{
    private static readonly Dictionary<Type, ILerpWrapper> _lerpFunction = new()
    {
        {typeof(float), new FloatLerp()},
        {typeof(Color), new ColorLerp()},
        {typeof(Vector3), new Vector3Lerp()},
    };
        
    public static T Evaluate<T>(T first, T second, float lerp)
    {
        ILerp<T> lerpFunction = (ILerp<T>)_lerpFunction[typeof(T)];
        
        return lerpFunction.Evaluate(first, second, lerp);
    }
}