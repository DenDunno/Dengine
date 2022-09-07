
var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var worldFactory = new WorldFactory(window);
var world = worldFactory.Create();

var physicsSimulation = new PhysicsSimulation(0.02f, new List<Rigidbody>());
physicsSimulation.Run();
world.Initialize();
window.Run(world);