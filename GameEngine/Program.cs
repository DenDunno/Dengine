using OpenTK.Mathematics;

var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var camera = new Camera(new Vector3(55, 55, 55));
var updateObjectsFactory = new UpdateObjectsFactory(window, camera);

var updateObjects = updateObjectsFactory.Create();
var physicsSimulation = new PhysicsSimulation(1 / 60f, updateObjects.Rigidbodies);
var world = new World(camera, updateObjects.GameObjects);

world.Initialize();
//physicsSimulation.Run();
window.Run(world);