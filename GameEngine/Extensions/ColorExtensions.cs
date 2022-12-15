using System.Drawing;
using OpenTK.Mathematics;

public static class ColorExtensions
{
    public static Vector3 ToVector(this Color color)
    {
        return new Vector3(color.R, color.G, color.B) / 255f;
    }
}