
var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var camera = new Camera(window.KeyboardState, window.MouseState);
var cube = new Cube();
var drawables =  new IDrawable[] {cube};
var updatables = new IUpdatable[] {camera};
var world = new World(drawables, updatables, camera);
var keyboardInput = new KeyboardInput(new Dictionary<string, Action>());

Task.Run(keyboardInput.Listen);
cube.Init();
window.Run(world);