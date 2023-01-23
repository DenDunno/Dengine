
public static class Dengine
{
    public static void Run(IWorldFactory worldFactory)
    {
        WindowFactory windowFactory = new();
        Window window = windowFactory.Create();
        
        List<GameObject> gameObjects = worldFactory.CreateGameObjects(window.Input);
        World world = new(gameObjects);
        WorldBrowser.Setup(world);

        Engine engine = new(window, world, new Editor(window, world));
        engine.Initialize();
        engine.Run();
    }
}