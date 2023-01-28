
public class ParticleSystemMaterial : Material
{
    public ParticleSystemMaterial() : base(Paths.GetShader("particleSystemVert"), Paths.GetShader("particleSystemFrag"))
    {
    }
}