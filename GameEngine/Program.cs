
WindowFactory windowFactory = new();
Window window = windowFactory.Create();

WorldFactory worldFactory = new ObjPreviewWorld(window);
World world = worldFactory.Create();

Commands commands = new(window, world);
KeyboardInput keyboardInput = new(commands);

keyboardInput.Listen();
world.Initialize();
window.Run(world);