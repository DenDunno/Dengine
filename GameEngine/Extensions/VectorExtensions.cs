using System.Drawing;
using OpenTK.Mathematics;

public static class VectorExtensions
{
    public static float Dot(this Vector3 first, Vector3 second)
    {
        return Vector3.Dot(first, second);
    }

    public static Vector3 Negated(this Vector3 vector3)
    {
        return -vector3;
    }

    public static System.Numerics.Vector3 LerpByAxis(this System.Numerics.Vector3 vector3, float first, float second)
    {
        return new System.Numerics.Vector3()
        {
            X = Algorithms.Lerp(first, second, vector3.X),
            Y = Algorithms.Lerp(first, second, vector3.Y),
            Z = Algorithms.Lerp(first, second, vector3.Z)
        };
    }

    public static Color ToColor(this Vector4 vector4)
    {
        return Color.FromArgb((int)vector4.W, (int)vector4.X, (int)vector4.Y, (int)vector4.Z);
    }
    
    public static System.Numerics.Vector3 ToNumeric(this Vector3 vector3)
    {
        return new System.Numerics.Vector3(vector3.X, vector3.Y, vector3.Z);
    }
    
    public static Vector3 ToOpenTk(this System.Numerics.Vector3 vector3)
    {
        return new Vector3(vector3.X, vector3.Y, vector3.Z);
    }
    
    public static Vector2 ToOpenTk(this System.Numerics.Vector2 vector2)
    {
        return new Vector2(vector2.X, vector2.Y);
    }

    public static Vector3 ToVector3(this Vector2 vector2)
    {
        return new Vector3(vector2.X, vector2.Y, 0);
    }
    
    public static Vector2i ToVector2I(this Vector3 vector3)
    {
        return new Vector2i((int)Math.Round(vector3.X), (int)Math.Round(vector3.Y));
    }

    public static Vector3 ToVector3(this Vector2i vector2I, float z = 0)
    {
        return new Vector3(vector2I.X, vector2I.Y, z);
    }

    public static void MoveTowards(this ref Vector3 start, Vector3 target, float maxDistanceDelta)
    {
        Vector3 direction = target - start;
        float magnitude = direction.Length;

        if (magnitude <= maxDistanceDelta || magnitude == 0f)
        {
            start = target;
        }
        else
        {
            start += direction / magnitude * maxDistanceDelta; 
        }
    }
    
    public static void MoveTowards2D(this ref Vector3 start, Vector3 target, float maxDistanceDelta)
    {
        float z = start.Z;
        
        MoveTowards(ref start, target, maxDistanceDelta);
        
        start.Z = z;
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