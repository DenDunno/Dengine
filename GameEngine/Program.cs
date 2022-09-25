
var windowFactory = new WindowFactory();
var window = windowFactory.Create();

var updateCycleFactory = new UpdateCycleFactory(window);
var updateCycle = updateCycleFactory.Create();

var commands = new Commands(window);
var keyboardInput = new KeyboardInput(commands);

keyboardInput.Listen();
updateCycle.Initialize();
updateCycle.Run();