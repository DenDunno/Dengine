using OpenTK.Mathematics;

public struct LightData
{
    [EditorField] public Vector4 Color = Vector4.One;
    [EditorField] public float Specular = 0.75f;
    [EditorField] public float Diffuse = 1.65f;
    [EditorField] public float Ambient = 0.4f;
    public Vector4 Position = new();

    public LightData()
    {
    }
}