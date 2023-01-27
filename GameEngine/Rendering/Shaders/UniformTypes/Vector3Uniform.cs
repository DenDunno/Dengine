using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Vector3Uniform : IUniform<Vector3>
{
    public void SetValue(int id, Vector3 value)
    {
        GL.Uniform3(id, value);
    }
}