using System.Drawing;
using OpenTK.Mathematics;

public class ShaderBridge
{
    private readonly ShaderUniforms _uniforms;

    public ShaderBridge(int shaderProgramId)
    {
        _uniforms = new ShaderUniforms(shaderProgramId);
    }
    
    public void SetMatrix4Array(string name, float[] value) => _uniforms.SetValue(name, value, Uniforms.UniformMatrixArray);
    
    public void SetVector4Array(string name, float[] value) => _uniforms.SetValue(name, value, Uniforms.Vector4Array);

    public void SetVector3(string name, Vector3 value) => _uniforms.SetValue(name, value, Uniforms.Uniform3);

    public void SetMatrix4(string name, Matrix4 value) => _uniforms.SetValue(name, value, Uniforms.Uniform4);
    
    public void SetColor(string name, Color value) => _uniforms.SetValue(name, value, Uniforms.Uniform3);
    
    public void SetFloat(string name, float value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);

    public void SetInt(string name, int value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);
}