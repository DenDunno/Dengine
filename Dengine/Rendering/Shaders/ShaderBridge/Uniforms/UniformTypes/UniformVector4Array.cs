using OpenTK.Graphics.OpenGL;

public class UniformVector4Array : IUniform<float[]>
{
    public void SetValue(int id, float[] value)
    {
        GL.Uniform4(id, value.Length / 4, value);
    }
}