
var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var transform = new Transform();
var camera = new Camera(window.KeyboardState, window.MouseState, transform);

var rectangle = new Rectangle();
rectangle.Init();

var drawables =  new IDrawable[] {rectangle};
var updatables = new IUpdatable[] {camera};

var world = new World(drawables, updatables, camera);
var keyboardInput = new KeyboardInput(new Dictionary<string, Action>());

Task.Run(keyboardInput.Listen);
window.Run(world);