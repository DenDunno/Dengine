using OpenTK.Graphics.OpenGL;

public class IntUniform : IUniform<int>
{
    public void SetValue(int id, int value)
    {
        GL.Uniform1(id, value);
    }
}