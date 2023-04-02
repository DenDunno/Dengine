using OpenTK.Mathematics;

public struct LightData
{
    [EditorField] public ColorVector4 Color = new();
    public Vector4 Position = new();
    [EditorField] public float Specular = 0.75f;
    [EditorField] public float Diffuse = 1.65f;
    [EditorField] public float Ambient = 0.4f;
    
    #pragma warning disable CS0169
    private float _padding; // std140 layout
    #pragma warning restore CS0169
    
    public LightData()
    {
    }
}