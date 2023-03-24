using System.Drawing;
using OpenTK.Mathematics;

class ColorLerp : ILerp<Color>
{
    public Color Evaluate(Color first, Color second, float lerp)
    {
        Vector4 firstColor = first.ToVector255(); 
        Vector4 secondColor = second.ToVector255();

        return Vector4.Lerp(firstColor, secondColor, lerp).ToColor();
    }
}