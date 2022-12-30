
public class TexturesViewer 
{
    private readonly IReadOnlyCollection<string> _extensions = new[] { "jpg", "png" };
    private readonly string _textureFolderPath = Paths.GetTexture(string.Empty);
    private readonly List<string> _textures = new();

    public IReadOnlyCollection<string> Textures => _textures;

    public void Init()
    {
        IEnumerable<string> texturesPath = GetAllTexturesPath();
        FillCollection(texturesPath);
    }

    private IEnumerable<string> GetAllTexturesPath()
    {
        return Directory.EnumerateFiles(_textureFolderPath, "*.*", SearchOption.AllDirectories)
                        .Where(files => _extensions.Contains(Path.GetExtension(files)
                        .TrimStart('.')
                        .ToLowerInvariant()));
    }

    private void FillCollection(IEnumerable<string> texturesPath)
    {
        foreach (string path in texturesPath)
        {
            _textures.Add(path);
        }
    }
}