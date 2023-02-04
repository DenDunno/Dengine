using OpenTK.Graphics.OpenGL;

public class Uniform1 : IUniform<float>, IUniform<int>
{
    public void SetValue(int id, int value) 
    {
        GL.Uniform1(id, value);
    }
    
    public void SetValue(int id, float value) 
    {
        GL.Uniform1(id, value);
    }
}