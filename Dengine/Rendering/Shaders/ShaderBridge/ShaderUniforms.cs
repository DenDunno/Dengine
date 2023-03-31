using System.Diagnostics;
using OpenTK.Graphics.OpenGL;

public class ShaderUniforms
{
    private readonly Dictionary<string, int> _uniformLocations = new();
    private readonly int _shaderProgramId;

    public ShaderUniforms(int shaderProgramId)
    {
        _shaderProgramId = shaderProgramId;
    }
    
    public void SetValue<T>(string name, T value, IUniform<T> uniformFunction)
    {
        GL.UseProgram(_shaderProgramId);
        TryAddUniformId(name);
        uniformFunction.SetValue(_uniformLocations[name], value);
        HandleError(name, value!.ToString()!);
    }

    private void TryAddUniformId(string name)
    {
        if (_uniformLocations.ContainsKey(name) == false)
        {
            _uniformLocations[name] = GL.GetUniformLocation(_shaderProgramId, name);
        }
    }

    private void HandleError(string name, string value)
    {
        ErrorCode errorCode = GL.GetError();
        
        if (errorCode != ErrorCode.NoError)
        {
            DengineConsole.Instance.LogError($"{errorCode}: \tName = \"{name}\" \tIndex = {_uniformLocations[name]} \tValue = {value}");
            Debugger.Break();
        }
    }
}