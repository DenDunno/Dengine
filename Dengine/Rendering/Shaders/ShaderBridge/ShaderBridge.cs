using System.Drawing;
using OpenTK.Mathematics;

public class ShaderBridge
{
    private readonly ShaderUniforms _uniforms;
    private readonly ShaderStorageBlockBridge _storageBridge;

    public ShaderBridge(int shaderProgramId)
    {
        _uniforms = new ShaderUniforms(shaderProgramId);
        _storageBridge = new ShaderStorageBlockBridge(shaderProgramId);
    }

    public void BindShaderStorageBlock(string blockName, int bindingPoint) => _storageBridge.BindShaderStorageBlock(blockName, bindingPoint);
    
    public void BindUniformBlock(string blockName, int bindingPoint) => _storageBridge.BindUniformBlock(blockName, bindingPoint);

    public void SetMatrix4Array(string name, float[] value) => _uniforms.SetValue(name, value, Uniforms.UniformMatrixArray);
    
    public void SetVector4Array(string name, float[] value) => _uniforms.SetValue(name, value, Uniforms.Vector4Array);

    public void SetColorArray(string name, Color[] value) => _uniforms.SetValue(name, value, Uniforms.Uniform4);
    
    public void SetFloatArray(string name, float[] value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);
    
    public void SetVector3(string name, Vector3 value) => _uniforms.SetValue(name, value, Uniforms.Uniform3);

    public void SetMatrix4(string name, Matrix4 value) => _uniforms.SetValue(name, value, Uniforms.Uniform4);

    public void SetVector4(string name, Vector4 value) => _uniforms.SetValue(name, value, Uniforms.Uniform4);

    public void SetIntArray(string name, int[] value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);
    
    public void SetColor(string name, Color value) => _uniforms.SetValue(name, value, Uniforms.Uniform4);

    public void SetFloat(string name, float value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);

    public void SetInt(string name, int value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);
}