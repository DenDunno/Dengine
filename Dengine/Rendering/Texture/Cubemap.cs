
public class Cubemap : Texture
{
    public Cubemap(IReadOnlyList<string> paths) : base(new CubemapSettings(), new CubemapLoading(paths))
    {
    }
}