using OpenTK.Mathematics;

public class LightData
{
    public readonly Vector3 LightColor;
    public readonly Texture Texture;
    public readonly Vector3 Position;

    public LightData(Vector3 lightColor, Texture texture, Vector3 position)
    {
        LightColor = lightColor;
        Texture = texture;
        Position = position;
    }
}