
var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var worldFactory = new WorldFactory(window);
var world = worldFactory.Create();
var keyboardInput = new KeyboardInput(new Dictionary<string, Action>());

Task.Run(keyboardInput.Listen);
world.Initialize();
window.Run(world);