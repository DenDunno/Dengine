
public static class Dengine
{
    public static void Run(WorldFactory worldFactory)
    {
        WindowFactory windowFactory = new();
        Window window = windowFactory.Create();
        
        World world = worldFactory.Create(window.Input);
        WorldBrowser worldBrowser = new(world);
        
        Engine engine = new(window, world, new Editor(window, world));
        engine.Initialize();
        engine.Run();
    }
}