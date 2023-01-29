using OpenTK.Graphics.OpenGL;

public class UniformMatrixArray : IUniform<float[]>
{
    public void SetValue(int id, float[] value)
    {
        GL.UniformMatrix4(id, value.Length / 16, true, value);
    }
}