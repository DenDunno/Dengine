
public class ParticleSystemMaterial : Material
{
    public ParticleSystemMaterial() : base(Paths.GetShader("Particles/vert"), Paths.GetShader("Particles/frag"))
    {
    }
}