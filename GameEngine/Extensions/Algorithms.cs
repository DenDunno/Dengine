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
    
    public static Vector3 LeftTriple(Vector3 a, Vector3 b, Vector3 c)
    {
        float bcDot = b.Dot(c);
        float acDot = a.Dot(c);

        return b * acDot - a * bcDot;
    }

    public static Vector3[] MultiplyPointsWithMatrix4(Matrix4 matrix4, Vector3[] from, Vector3[] to)
    {
        return MultiplyWithMatrix4(ref matrix4, from, to, false);
    }
    
    public static Vector3[] MultiplyDirectionsWithMatrix4(Matrix4 matrix4, Vector3[] from, Vector3[] to)
    {
        return MultiplyWithMatrix4(ref matrix4, from, to, true);
    }
    
    public static Vector3 MultiplyPointWithMatrix4(Matrix4 matrix4, Vector3 point)
    {
        return MultiplyWithMatrix4(ref matrix4, point, false);
    }
    
    public static Vector3 MultiplyDirectionWithMatrix4(Matrix4 matrix4, Vector3 direction)
    {
        return MultiplyWithMatrix4(ref matrix4, direction, true);
    }
    
    private static Vector3 MultiplyWithMatrix4(ref Matrix4 matrix4, Vector3 vector3, bool isDirection)
    {
        int w = isDirection ? 0 : 1;
        Vector4 vector4 = new(vector3, w);
        Vector3 result = (vector4 * matrix4).Xyz;
        
        if (isDirection)
        {
            result.Normalize();
        }

        return result;
    }
    
    private static Vector3[] MultiplyWithMatrix4(ref Matrix4 matrix4, Vector3[] from, Vector3[] to, bool isDirection)
    {
        for (int i = 0; i < from.Length; ++i)
        {
            to[i] = MultiplyWithMatrix4(ref matrix4, from[i], isDirection);
        }

        return to;
    }
    
    public static float Lerp(float firstFloat, float secondFloat, float lerp)
    {
        float result = firstFloat * (1 - lerp) + secondFloat * lerp;

        if (result > secondFloat)
        {
            result = secondFloat;
        }

        return result;
    }

    public static int RandomSign()
    {
        return Random.Shared.Next(0, 2) * 2 - 1;
    }
    
    public static Vector2 RandomVector2()
    {
        return RandomVector3().ToVector2().Normalized();
    }
    
    public static Vector3 RandomVector3()
    {
        float z = Random.Shared.NextSingle() * 2.0f - 1.0f;
        float a = Random.Shared.NextSingle() * 2.0f * MathF.PI;
        float r = MathF.Sqrt(1.0f - z * z);
        float x = r * MathF.Cos(a);
        float y = r * MathF.Sin(a);

        return new Vector3(x, y, z).Normalized();
    }

    public static float RandomFloat()
    {
        return Random.Shared.NextSingle() * 2.0f - 1.0f;
    }
    
    public static float InverseLerp(float start, float end, float value)
    {
        return (value - start) / (end - start);
    }

    public static float Clamp(int start, int end, float value)
    {
        if (value < start)
            value = start;

        if (value > end)
            value = end;
        
        return value;
    }

    public static void Swap(ref float first, ref float second)
    {
        (first, second) = (second, first);
    }
}