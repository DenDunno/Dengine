
WindowFactory windowFactory = new();
Window window = windowFactory.Create();

WorldFactory worldFactory = new ManyCubesWorld(window.Input);
World world = worldFactory.Create();

Engine engine = new(window, world, new Editor(window, world));
engine.Initialize();
engine.Run();