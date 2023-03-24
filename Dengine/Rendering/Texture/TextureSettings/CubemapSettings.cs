using OpenTK.Graphics.OpenGL;

public class CubemapSettings : TextureSettings
{
    public CubemapSettings() : base(TextureTarget.TextureCubeMap, GenerateMipmapTarget.TextureCubeMap, new TexParameter[]
    {
        new(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear),
        new(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear),
        new(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge),
        new(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge),
        new(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (int)TextureWrapMode.ClampToEdge),
    })
    {
    }
}