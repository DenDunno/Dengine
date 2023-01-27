using System.Drawing;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class ShaderBridge
{
    private readonly int _shaderProgramId;
    private readonly Dictionary<string, int> _uniformLocations = new();
    private readonly Dictionary<Type, IUniformWrapper> _uniforms = new()
    {
        {typeof(Matrix4), new Matrix4Uniform()},
        {typeof(Vector3), new Vector3Uniform()},
        {typeof(Color), new ColorUniform()},
        {typeof(float), new FloatUniform()},
        {typeof(int), new IntUniform()},
    };
    
    public ShaderBridge(int shaderProgramId)
    {
        _shaderProgramId = shaderProgramId;
    }

    public void SetValue<T>(string name, T value)
    {
        GL.UseProgram(_shaderProgramId);
        TryAddUniformId(name);
        SetValue(_uniformLocations[name], value);
    }

    private void TryAddUniformId(string name)
    {
        if (_uniformLocations.ContainsKey(name) == false)
        {
            _uniformLocations[name] = GL.GetUniformLocation(_shaderProgramId, name);
        }
    }

    private void SetValue<T>(int id, T value)
    {
        IUniform<T> uniform = (IUniform<T>)_uniforms[typeof(T)];
        
        uniform.SetValue(id, value);
    }
}