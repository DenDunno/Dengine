using OpenTK.Mathematics;

var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var camera = new Camera(new Vector3(0, 1.5f, 3), window.AspectRatio);
var updateObjectsFactory = new UpdateObjectsFactory(window, camera);

var updateObjects = updateObjectsFactory.Create();
var physicsSimulation = new PhysicsSimulation(1 / 60f, updateObjects.Rigidbodies);
var world = new World(camera, updateObjects.GameObjects);

world.Initialize();
physicsSimulation.Run();
window.Run(world);