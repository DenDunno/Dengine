
public class ParticlesBuffer
{
    public readonly float[] Matrices;
    public readonly float[] Colors;

    public ParticlesBuffer(int pool)
    {
        Matrices = new float[16 * pool];
        Colors = Enumerable.Repeat(1f, 4 * pool).ToArray();
    }
}