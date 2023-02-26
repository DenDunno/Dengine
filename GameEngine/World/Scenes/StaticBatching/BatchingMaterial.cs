
public class BatchingMaterial : Material
{
    public BatchingMaterial() : base(Paths.GetShader("Batching/vert"), Paths.GetShader("Batching/frag"))
    {
    }
}