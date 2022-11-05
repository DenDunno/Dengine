
WindowFactory windowFactory = new();
Window window = windowFactory.Create();

WorldFactory worldFactory = new(window);
World world = worldFactory.Create();

Commands commands = new(window);
KeyboardInput keyboardInput = new(commands);

keyboardInput.Listen();
world.Initialize();
window.Run(world);