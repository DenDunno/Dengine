
var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var cameraFactory = new CameraFactory(window.KeyboardState, window.MouseState);

var gameObjects = new List<GameObject>() {cameraFactory.Create()};
var world = new World(gameObjects);
var updateCycle = new UpdateCycle(world);
var keyboardInput = new KeyboardInput(new Dictionary<string, Action>());

Task.Run(keyboardInput.Listen);
window.Run(updateCycle);