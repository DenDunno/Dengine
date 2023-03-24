using OpenTK.Windowing.Common.Input;
using StbImageSharp;

public class Icon
{
    private readonly string _path;
    private readonly Window _window;

    public Icon(string path, Window window)
    {
        _path = Paths.GetTexture(path);
        _window = window;
    }

    public void Load()
    {
        using Stream stream = File.OpenRead(_path);
        ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
        _window.Icon = new WindowIcon(new Image(image.Width, image.Height, image.Data));
    }
}