using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ComputeShader : ShaderProgram
{
    private readonly Vector3i _numGroups;

    public ComputeShader(string path, Vector3i numGroups) : base(new Shader[] {new(path, ShaderType.ComputeShader)})
    {
        _numGroups = numGroups;
    }

    protected override void OnUse()
    {
        GL.DispatchCompute(_numGroups.X, _numGroups.Y, _numGroups.Z);
        GL.MemoryBarrier(MemoryBarrierFlags.AllBarrierBits);
    }
}