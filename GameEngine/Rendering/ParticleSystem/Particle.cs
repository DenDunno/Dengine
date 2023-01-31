using OpenTK.Mathematics;

public struct Particle
{
    public Transform Transform;
    public Vector3 Velocity;
    public float ElapsedTime;
    public readonly float[] Color = {1,1,1,0};
    public bool Enabled = false;

    public Particle()
    {
        Transform = new Transform();
        Velocity = Vector3.Zero;
        ElapsedTime = 0;
    }
}