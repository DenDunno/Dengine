using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ShaderBridge
{
    private readonly ShaderUniforms _uniforms;
    private readonly ShaderResources _resources;
    private readonly ShaderStorageBlockBridge _ssboBridge;

    public ShaderBridge(int shaderProgramId)
    {
        _uniforms = new ShaderUniforms(shaderProgramId);
        _resources = new ShaderResources(shaderProgramId);
        _ssboBridge = new ShaderStorageBlockBridge(shaderProgramId);
    }

    public void BindShaderStorageBlockToPoint(string blockName, int bindingPoint)
    {
        int index = GetResourceIndex(ProgramInterface.ShaderStorageBlock, blockName);
        BindShaderStorageBlockToPoint(index, bindingPoint);
    }

    public void BindShaderStorageBlockToPoint(int blockIndex, int bindingPoint) => _ssboBridge.BindToPoint(blockIndex, bindingPoint);
    
    public int GetResourceIndex(ProgramInterface @interface, string name) => _resources.GetIndex(@interface, name);
    
    public void SetMatrix4Array(string name, float[] value) => _uniforms.SetValue(name, value, Uniforms.UniformMatrixArray);
    
    public void SetVector4Array(string name, float[] value) => _uniforms.SetValue(name, value, Uniforms.Vector4Array);

    public void SetVector3(string name, Vector3 value) => _uniforms.SetValue(name, value, Uniforms.Uniform3);

    public void SetMatrix4(string name, Matrix4 value) => _uniforms.SetValue(name, value, Uniforms.Uniform4);
    
    public void SetColor(string name, Color value) => _uniforms.SetValue(name, value, Uniforms.Uniform3);
    
    public void SetFloat(string name, float value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);

    public void SetInt(string name, int value) => _uniforms.SetValue(name, value, Uniforms.Uniform1);
}