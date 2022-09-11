using OpenTK.Graphics.OpenGL4;
using StbImageSharp;
using PixelFormat = OpenTK.Graphics.OpenGL4.PixelFormat;

public class Cubemap : TextureBase
{
    private readonly List<string> _paths;
    private readonly TextureTarget[] _targets;

    public Cubemap(List<string> paths) : base(TextureTarget.TextureCubeMap)
    {
        _paths = paths;
        _targets = new[]
        {
            TextureTarget.TextureCubeMapPositiveX,
            TextureTarget.TextureCubeMapNegativeX,
            TextureTarget.TextureCubeMapPositiveY,
            TextureTarget.TextureCubeMapNegativeY,
            TextureTarget.TextureCubeMapPositiveZ,
            TextureTarget.TextureCubeMapNegativeZ
        };
    }

    public override void Load()
    {
        for (int i = 0; i < _paths.Count; ++i)
        {
            using Stream stream = File.OpenRead(_paths[i]);
            ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha); 
            GL.TexImage2D(_targets[i], 0, PixelInternalFormat.Rgb, image.Width, image.Height, 0, PixelFormat.Rgb, PixelType.UnsignedByte, image.Data);
        }

        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (int)TextureWrapMode.ClampToEdge);
        GL.GenerateMipmap(GenerateMipmapTarget.TextureCubeMap);
    }

    public override void Use(TextureUnit unit = TextureUnit.Texture0)
    {
        GL.ActiveTexture(unit);
        Bind();
    }
}