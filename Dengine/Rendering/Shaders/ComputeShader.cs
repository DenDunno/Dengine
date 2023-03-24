using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ComputeShader : ShaderProgram
{
    public ComputeShader(string path) : base(new Shader[] {new(path, ShaderType.ComputeShader)})
    {
    }
    
    public void Dispatch(Vector3i numGroups)
    {
        Use();
        GL.DispatchCompute(numGroups.X, numGroups.Y, numGroups.Z);
        GL.MemoryBarrier(MemoryBarrierFlags.AllBarrierBits);
    }
}