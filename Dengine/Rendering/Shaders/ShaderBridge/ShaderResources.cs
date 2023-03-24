using OpenTK.Graphics.OpenGL;

public class ShaderResources
{
    private readonly int _shaderProgramId;

    public ShaderResources(int shaderProgramId)
    {
        _shaderProgramId = shaderProgramId;
    }
    
    public int GetIndex(ProgramInterface programInterface, string name)
    {
        return GL.GetProgramResourceIndex(_shaderProgramId, programInterface, name);
    }
}