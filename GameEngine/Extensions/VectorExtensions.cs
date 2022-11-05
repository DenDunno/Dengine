using OpenTK.Mathematics;

namespace GameEngine.Extensions;

public static class VectorExtensions
{
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