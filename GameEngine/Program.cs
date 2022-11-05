
WindowFactory windowFactory = new();
Window window = windowFactory.Create();

WorldFactory worldFactory = new Demo3DFactory(window);
World world = worldFactory.Create();

Commands commands = new(window);
KeyboardInput keyboardInput = new(commands);

keyboardInput.Listen();
world.Initialize();
window.Run(world);