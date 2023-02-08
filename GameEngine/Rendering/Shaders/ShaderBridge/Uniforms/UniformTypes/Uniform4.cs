using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Uniform4 : IUniform<Matrix4>, IUniform<Vector4>, IUniform<Color>, IUniform<Color[]>
{
    public void SetValue(int id, Matrix4 value)
    {
        GL.UniformMatrix4(id, true, ref value);
    }
    
    public void SetValue(int id, Vector4 value)
    {
        GL.Uniform4(id, value);
    }

    public void SetValue(int id, Color value)
    {
        GL.Uniform4(id, value);
    }

    public void SetValue(int id, Color[] value)
    {
        GL.Uniform4(id, value.Length, value.ToFloatArray());
    }
}