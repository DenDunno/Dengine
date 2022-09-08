using OpenTK.Mathematics;

var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var camera = new Camera(Vector3.UnitZ * 3);
var updateObjectsFactory = new UpdateObjectsFactory(window, camera);

var updateObjects = updateObjectsFactory.Create();
var physicsSimulation = new PhysicsSimulation(0.02f, updateObjects.Rigidbodies);
var world = new World(camera, updateObjects.GameObjects);

world.Initialize();
physicsSimulation.Run();
window.Run(world);