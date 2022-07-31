using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class ShaderBridge
{
    private readonly int _id;
    private readonly Dictionary<string, int> _uniformLocations = new();

    public ShaderBridge(int id)
    {
        _id = id;
    }

    public void LoadUniforms()
    {
        GL.GetProgram(_id, GetProgramParameterName.ActiveUniforms, out int numberOfUniforms); 
        
        for (var i = 0; i < numberOfUniforms; i++)
        {
            string? key = GL.GetActiveUniform(_id, i, out _, out _);
            int location = GL.GetUniformLocation(_id, key);
            _uniformLocations.Add(key, location);
        }
    }
    
    public void SetMatrix4(string name, Matrix4 data)
    {
        GL.UseProgram(_id);
        GL.UniformMatrix4(_uniformLocations[name], true, ref data);
    }
}