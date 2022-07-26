
var triangle = Primitives.Triangle;
var coordinateSystem = new DrawableWithSwitching(new CoordinateSystem(), true);
var camera = new Camera();
var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var mouseInput = new MouseInput(window.MouseState, camera);
var keyboardInput = new KeyboardInput(new Dictionary<string, Action>()
{
    {"show cs", coordinateSystem.Show},
    {"hide cs", coordinateSystem.Hide},
});

var updateCycle = new UpdateCycle(new List<IUpdatable>()
{
    mouseInput, camera
}, 
new List<IDrawable>()
{
    triangle, coordinateSystem
});

float angle = 0;

window.FrameRendering += updateCycle.Update;
window.FrameRendering += delta =>
{
    angle += delta;
    
    if (angle >= 360)
        angle = 0;
    
    triangle.Transform.Rotate(0, 0, delta);
    triangle.Transform.SetPosition(MathF.Sin(angle), MathF.Cos(angle), 0);
};

Task.Run(keyboardInput.Listen);
window.Run();