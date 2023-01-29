using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Uniform3 : IUniform<Vector3>, IUniform<Color>
{
    public void SetValue(int id, Vector3 value)
    {
        GL.Uniform3(id, value);
    }

    public void SetValue(int id, Color value)
    {
        GL.Uniform3(id, value.ToVector3());
    }
}