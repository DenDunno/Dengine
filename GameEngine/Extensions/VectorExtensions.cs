using OpenTK.Mathematics;

public static class VectorExtensions
{
    public static float Dot(this Vector3 first, Vector3 second)
    {
        return Vector3.Dot(first, second);
    }
    
    public static void Negate(this Vector3 vector3)
    {
        vector3 = -vector3;
    }
    
    public static Vector3 Negated(this Vector3 vector3)
    {
        return -vector3;
    }

    public static System.Numerics.Vector3 ToNumeric(this Vector3 vector3)
    {
        return new System.Numerics.Vector3(vector3.X, vector3.Y, vector3.Z);
    }
    
    public static Vector3 ToOpenTk(this System.Numerics.Vector3 vector3)
    {
        return new Vector3(vector3.X, vector3.Y, vector3.Z);
    }

    public static float[] ToFloatArray(this Vector3[] array)
    {
        float[] result = new float[array.Length * 3];

        for (int i = 0, j = 0; i < array.Length; ++i, j += 3)
        {
            result[j] = array[i].X;
            result[j + 1] = array[i].Y;
            result[j + 2] = array[i].Z;
        }

        return result;
    }
    
    public static float[] ToFloatArray(this Vector2[] array)
    {
        float[] result = new float[array.Length * 2];

        for (int i = 0, j = 0; i < array.Length; ++i, j += 2)
        {
            result[j] = array[i].X;
            result[j + 1] = array[i].Y;
        }

        return result;
    }
}