using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Uniform4 : IUniform<Matrix4>
{
    public void SetValue(int id, Matrix4 value)
    {
        GL.UniformMatrix4(id, true, ref value);
    }
}