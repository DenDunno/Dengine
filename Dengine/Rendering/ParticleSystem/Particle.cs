using OpenTK.Mathematics;

public struct Particle
{
    public Vector4 Position = Vector4.Zero;
    public Vector4 Rotation = Vector4.Zero;
    public Vector4 Velocity = Algorithms.RandomVector2().ToVector4();
    public Vector4 Color = new(1, 1, 1, 0);
    public float Scale = 1;
    public float ElapsedTime = 0;
    public int Enabled = 0;
    
#pragma warning disable CS0169
    private int _padding; // std430 layout
#pragma warning restore CS0169
    
    public Particle()
    {
    }
}