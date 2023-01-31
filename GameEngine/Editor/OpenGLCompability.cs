using OpenTK.Graphics.OpenGL;

public class OpenGLCompability
{
    private readonly float _apiVersion;
    private readonly HashSet<string> _extensions;

    public OpenGLCompability()
    {
        _apiVersion = GetApiVersion();
        _extensions = GetExtensions();
    }

    private float GetApiVersion()
    {
        int major = GL.GetInteger(GetPName.MajorVersion);
        int minor = GL.GetInteger(GetPName.MinorVersion);

        return float.Parse($"{major}{minor}") / 10;
    }
    
    private static HashSet<string> GetExtensions()
    {
        HashSet<string> extensions = new(GL.GetInteger(GetPName.NumExtensions));

        for (int i = 0; i < GL.GetInteger(GetPName.NumExtensions); i++)
        {
            extensions.Add(GL.GetString(StringNameIndexed.Extensions, i));
        }

        return extensions;
    }

    public void ThrowIfExtensionNotAvailable(string extension, double version)
    {
        if (_apiVersion < version && _extensions.Contains(extension) == false)
        {
            throw new NotSupportedException($"Your system does not support {extension}");
        }
    }
}