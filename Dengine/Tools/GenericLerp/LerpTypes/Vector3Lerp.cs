using OpenTK.Mathematics;

public class Vector3Lerp : ILerp<Vector3>
{
    public Vector3 Evaluate(Vector3 first, Vector3 second, float lerp)
    {
        return Vector3.Lerp(first, second, lerp);
    }
}