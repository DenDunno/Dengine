using System.Drawing;
using OpenTK.Graphics.OpenGL;

public class ColorUniform : IUniform<Color>
{
    public void SetValue(int id, Color value)
    {
        GL.Uniform3(id, value.ToVector3());
    }
}