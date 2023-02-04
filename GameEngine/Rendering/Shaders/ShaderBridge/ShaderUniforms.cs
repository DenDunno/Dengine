using System.Diagnostics;
using OpenTK.Graphics.OpenGL;

public class ShaderUniforms
{
    private readonly int _shaderProgramId;
    private readonly Dictionary<string, int> _uniformLocations = new();
    
    public ShaderUniforms(int shaderProgramId)
    {
        _shaderProgramId = shaderProgramId;
    }
    
    public void SetValue<T>(string name, T value, IUniform<T> uniformFunction)
    {
        GL.UseProgram(_shaderProgramId);
        TryAddUniformId(name);
        uniformFunction.SetValue(_uniformLocations[name], value);
        HandleError();
    }

    private void TryAddUniformId(string name)
    {
        if (_uniformLocations.ContainsKey(name) == false)
        {
            _uniformLocations[name] = GL.GetUniformLocation(_shaderProgramId, name);
        }
    }

    private void HandleError()
    {
        ErrorCode errorCode = GL.GetError();
        
        if (errorCode != ErrorCode.NoError)
        {
            DengineConsole.LogError(errorCode);
            Debugger.Break();
        }
    }
}