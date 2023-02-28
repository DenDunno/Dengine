using OpenTK.Graphics.OpenGL;

public class CubemapLoading : ITextureSource
{
    private readonly TextureFromFile[] _textureFromFiles;

    public CubemapLoading(IReadOnlyList<string> paths)
    {
        JPEG format = new();
        
        _textureFromFiles = new TextureFromFile[]
        {
            new(paths[0], format, TextureTarget.TextureCubeMapPositiveX),
            new(paths[1], format, TextureTarget.TextureCubeMapNegativeX),
            new(paths[2], format, TextureTarget.TextureCubeMapPositiveY),
            new(paths[3], format, TextureTarget.TextureCubeMapNegativeY),
            new(paths[4], format, TextureTarget.TextureCubeMapPositiveZ),
            new(paths[5], format, TextureTarget.TextureCubeMapNegativeZ)
        };
    }
    
    public void Load()
    {
        foreach (TextureFromFile textureFromFile in _textureFromFiles)
        {
            textureFromFile.Load();
        }
    }
}