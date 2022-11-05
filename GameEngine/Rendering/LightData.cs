using OpenTK.Mathematics;

public class LightData
{
    public readonly Vector3 LightColor;
    public readonly Texture Texture;
    public readonly Vector3 LightPosition;

    public LightData(Vector3 lightColor, Texture texture, Vector3 lightPosition)
    {
        LightColor = lightColor;
        Texture = texture;
        LightPosition = lightPosition;
    }
}