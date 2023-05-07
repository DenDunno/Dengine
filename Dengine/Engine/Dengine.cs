
public static class Dengine
{
    public static void Run(IWorldFactory worldFactory)
    {
        WindowFactory windowFactory = new();
        Window window = windowFactory.Create();
        WindowSettings.Setup(window);
        
        List<GameObject> gameObjects = worldFactory.CreateGameObjects();
        World world = new(gameObjects);
        WorldBrowser.Setup(gameObjects);

        Engine engine = new(window, world, new Editor(window, world));
        engine.Initialize();
        engine.Run();
    }
}