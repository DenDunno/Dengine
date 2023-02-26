
public class Texture2D : Texture
{
    public Texture2D(string path) : base(new Texture2DSettings(), new TextureFromFile(path, new PNG()))
    {
    }
}