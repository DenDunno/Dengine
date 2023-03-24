
public static class Paths
{
    private static readonly string _resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Resources/");

    public static string GetModel(string modelName)
    {
        return $"{_resourcesPath}Models/{modelName}.obj";
    }
    
    public static string GetTexture(string textureName)
    {
        return $"{_resourcesPath}Textures/{textureName}";
    }
    
    public static string[] GetTexturesInFolder(string folderName)
    {
        return Directory.GetFiles($"{_resourcesPath}Textures/{folderName}");
    }
    
    public static string GetShader(string shaderName)
    {
        return $"{_resourcesPath}Shaders/{shaderName}.glsl";
    }
    
    public static List<string> GetSkybox(string skyboxName)
    {
        string[] files = Directory.GetFiles($"{_resourcesPath}Skyboxes/{skyboxName}");
        string extension = Path.GetExtension(files[0]);
            
        return new List<string>()
        {
            $"{_resourcesPath}Skyboxes/{skyboxName}/right{extension}",
            $"{_resourcesPath}Skyboxes/{skyboxName}/left{extension}",
            $"{_resourcesPath}Skyboxes/{skyboxName}/top{extension}",
            $"{_resourcesPath}Skyboxes/{skyboxName}/bottom{extension}",
            $"{_resourcesPath}Skyboxes/{skyboxName}/back{extension}",
            $"{_resourcesPath}Skyboxes/{skyboxName}/front{extension}",
        };
    }
}