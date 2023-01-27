using OpenTK.Graphics.OpenGL;

public class FloatUniform : IUniform<float>
{
    public void SetValue(int id, float value)
    {
        GL.Uniform1(id, value);
    }
}