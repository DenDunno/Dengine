using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Uniform2 : IUniform<Vector2>
{
    public void SetValue(int id, Vector2 value)
    {
        GL.Uniform2(id, value);
    }
}