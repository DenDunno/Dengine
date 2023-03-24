using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Uniform3 : IUniform<Vector3>
{
    public void SetValue(int id, Vector3 value)
    {
        GL.Uniform3(id, value);
    }
}