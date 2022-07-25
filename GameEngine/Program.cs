
Object triangle = Primitives.Triangle;
triangle.Transform.Rotate();
var updateCycle = new UpdateCycle(new List<IUpdatable>()
{
    
}, 
new List<IDrawable>()
{
    triangle
});

var windowFactory = new WindowFactory();
var window = windowFactory.Create();

window.FrameRendering += updateCycle.Update;
window.Run();