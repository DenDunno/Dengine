using System.Drawing;
using OpenTK.Mathematics;

public static class ColorExtensions
{
    public static Vector3 ToVector3(this Color color)
    {
        return new Vector3(color.R, color.G, color.B) / 255f;
    }
    
    public static Vector4 ToVector4(this Color color)
    {
        return new Vector4(color.R, color.G, color.B, color.A);
    }
    
    public static Vector4 ToVector255(this Color color)
    {
        return new Vector4(color.R, color.G, color.B, color.A);
    }

    public static uint ToUint(this Color color)
    {
        uint result = color.A;
        result <<= 8;
        result += color.B;
        result <<= 8; 
        result += color.G;
        result <<= 8;
        result += color.R;
        
        return result;
    }

    public static Color ToColor(this uint value)
    {
        return Color.FromArgb((byte)((value >> 24) & 0xFF),
            (byte)((value >> 16) & 0xFF),
            (byte)((value >> 8) & 0xFF),
            (byte) (value & 0xFF));
    }
}