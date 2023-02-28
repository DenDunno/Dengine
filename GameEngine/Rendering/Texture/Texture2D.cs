
public class Texture2D : Texture
{
    public readonly Texture2DData Data;

    public Texture2D(string path) : this(new TextureFromFile(path, new PNG()))
    {
    }

    public Texture2D(ITextureSource source) : base(new Texture2DSettings(), source)
    {
        Data = new Texture2DData(Id);
    }
}