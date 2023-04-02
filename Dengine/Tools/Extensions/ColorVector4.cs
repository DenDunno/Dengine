using System.Drawing;
using System.Numerics;

// System.Color is a managed type. This is a workaround to use Color in unmanaged structs
public struct ColorVector4  
{
    public Vector4 Value = Vector4.One;

    public ColorVector4(Color color)
    {
        Value = new Vector4(color.R, color.G, color.B, color.A) / 255;
    }
}