
public static class Paths
{
    private static readonly string _resourcesPath = Path.GetFullPath(@"..\..\..\..\Resources\");

    public static string GetModel(string modelName)
    {
        return $"{_resourcesPath}Model\\{modelName}";
    }
    
    public static string GetTexture(string textureName)
    {
        return $"{_resourcesPath}Textures\\{textureName}";
    }
    
    public static string GetShader(string shaderName)
    {
        return $"{_resourcesPath}Shaders\\{shaderName}.glsl";
    }
    
    public static List<string> GetSkybox(string skyboxName)
    {
        return new List<string>()
        {
            $"{_resourcesPath}Skyboxes\\{skyboxName}/right.jpg",
            $"{_resourcesPath}Skyboxes\\{skyboxName}/left.jpg",
            $"{_resourcesPath}Skyboxes\\{skyboxName}/top.jpg",
            $"{_resourcesPath}Skyboxes\\{skyboxName}/bottom.jpg",
            $"{_resourcesPath}Skyboxes\\{skyboxName}/back.jpg",
            $"{_resourcesPath}Skyboxes\\{skyboxName}/front.jpg",
        };
    }
}