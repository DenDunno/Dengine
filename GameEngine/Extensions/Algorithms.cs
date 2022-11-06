using OpenTK.Mathematics;

public static class Algorithms
{
    public static Vector3 Min(Vector3 first, Vector3 second)
    {
        return new Vector3(MathF.Min(first.X, second.X), MathF.Min(first.Y, second.Y), MathF.Min(first.Z, second.Z));
    }
    
    public static Vector3 Max(Vector3 first, Vector3 second)
    {
        return new Vector3(MathF.Max(first.X, second.X), MathF.Max(first.Y, second.Y), MathF.Max(first.Z, second.Z));
    }

    public static Vector3 GetNormal(Vector3 direction)
    {
        return new Vector3(-direction.Y, direction.X, 0).Normalized();
    }

    public static (Vector3, Vector3) CreateOrthonormalBasis(Vector3 firstAxis)
    {
        Vector3 secondAxis = GetNormal(firstAxis);
        Vector3 thirdAxis = Vector3.Cross(firstAxis, secondAxis);

        return (secondAxis, thirdAxis);
    }
}