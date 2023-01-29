using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Uniform4 : IUniform<Matrix4>, IUniform<float[]>
{
    public void SetValue(int id, Matrix4 value)
    {
        GL.UniformMatrix4(id, true, ref value);
    }

    public void SetValue(int id, float[] value)
    {
        GL.Uniform4(id, value.Length / 4, value);
    }
}