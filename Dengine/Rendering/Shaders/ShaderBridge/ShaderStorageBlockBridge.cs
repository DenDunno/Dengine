using OpenTK.Graphics.OpenGL;

public class ShaderStorageBlockBridge
{
    private readonly int _shaderProgramId;

    public ShaderStorageBlockBridge(int shaderProgramId)
    {
        _shaderProgramId = shaderProgramId;
    }

    public void BindToPoint(int blockIndex, int point)
    {
        GL.ShaderStorageBlockBinding(_shaderProgramId, blockIndex, point);
    }
}