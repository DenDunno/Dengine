using OpenTK.Graphics.OpenGL;

public class ShaderStorageBlockBridge
{
    private readonly int _shaderProgramId;

    public ShaderStorageBlockBridge(int shaderProgramId)
    {
        _shaderProgramId = shaderProgramId;
    }

    public void BindShaderStorageBlock(string blockName, int bindingPoint)
    {
        int index = GL.GetProgramResourceIndex(_shaderProgramId, ProgramInterface.ShaderStorageBlock, blockName);
        GL.ShaderStorageBlockBinding(_shaderProgramId, index, bindingPoint);
    }
    
    public void BindUniformBlock(string blockName, int bindingPoint)
    {
        int index = GL.GetUniformBlockIndex(_shaderProgramId, blockName);
        GL.UniformBlockBinding(_shaderProgramId, index, bindingPoint);
    }
}