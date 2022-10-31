using OpenTK.Mathematics;

namespace GameEngine.Extensions;

public static class VectorExtensions
{
    public static float[] ToFloatArray(this Vector3[] array)
    {
        var result = new float[array.Length * 3];

        for (int i = 0; i < array.Length; ++i)
        {
            result[i] = array[i].X;
            result[i + 1] = array[i].Y;
            result[i + 2] = array[i].Z;
        }

        return result;
    }
    
    public static float[] ToFloatArray(this Vector2[] array)
    {
        var result = new float[array.Length * 2];

        for (int i = 0; i < array.Length; ++i)
        {
            result[i] = array[i].X;
            result[i + 1] = array[i].Y;
        }

        return result;
    }
}