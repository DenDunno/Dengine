using System.Drawing;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class ShaderBridge
{
    private readonly int _shaderProgramId;
    private readonly Dictionary<string, int> _uniformLocations = new();

    public ShaderBridge(int shaderProgramId)
    {
        _shaderProgramId = shaderProgramId;
    }

    public void LoadUniforms()
    {
        GL.GetProgram(_shaderProgramId, GetProgramParameterName.ActiveUniforms, out int numberOfUniforms); 
        
        for (int i = 0; i < numberOfUniforms; i++)
        {
            string? key = GL.GetActiveUniform(_shaderProgramId, i, out _, out _);
            int location = GL.GetUniformLocation(_shaderProgramId, key);
            _uniformLocations.Add(key, location);
        }
    }
    
    public void SetMatrix4(string name, Matrix4 data)
    {
        GL.UseProgram(_shaderProgramId);
        GL.UniformMatrix4(_uniformLocations[name], true, ref data);
    }
   
    public void SetVector3(string name, Vector3 data)
    {
        GL.UseProgram(_shaderProgramId);
        GL.Uniform3(_uniformLocations[name], data);
    }

    public void SetColor(string name, Color color)
    {
        SetVector3(name, color.ToVector());
    }

    public void SetFloat(string name, float value)
    {
        GL.UseProgram(_shaderProgramId);
        GL.Uniform1(_uniformLocations[name], value);
    }
}