using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

var windowFactory = new WindowFactory();
var window = windowFactory.Create();
var timer = new Timer(window);
var camera = new Camera(window.KeyboardState, window.MouseState);
var transform1 = new Transform(new Vector3(-1f, 0, -1.45f));
var transform2 = new Transform(new Vector3(1f, 0, -1.45f));

var renderData = new RenderData()
{
    Transform = transform1,
    AttributePointers = new[] 
    {
        new AttributePointer(0, 3, 8, 0),
        new AttributePointer(1, 2, 8, 3),
        new AttributePointer(2, 3, 8, 5)
    },
    Mesh = Primitives.Cube(0.5f),
    ShaderProgram = new ShaderProgram(new Shader[]
    {
        new("Shaders/vert.glsl", ShaderType.VertexShader),
        new("Shaders/colorFrag.glsl", ShaderType.FragmentShader)
    })
};

var renderData1 = new RenderData()
{
    Transform = transform2,
    AttributePointers = new[]
    {
        new AttributePointer(0, 3, 8, 0),
        new AttributePointer(1, 2, 8, 3),
        new AttributePointer(2, 3, 8, 5)
    },
    Mesh = Primitives.Cube(0.5f),
    ShaderProgram = new ShaderProgram(new Shader[]
    {
        new("Shaders/vert.glsl", ShaderType.VertexShader),
        new("Shaders/frag.glsl", ShaderType.FragmentShader)
    })
};

var cubeStatic = new FlatModel(renderData);
var cubeTexture = new ModelWithTexture(new FlatModel(renderData1), new Texture("Resources/wood.png"));
var cubeAnimation1 = new CubeAnimation(transform1);
var cubeAnimation2 = new CubeAnimation(transform2);

var initializable = new IInitializable[] { cubeStatic, cubeTexture};
var drawables =  new IDrawable[] {cubeStatic, cubeTexture};
var updatables = new IUpdatable[] {timer, cubeAnimation1, cubeAnimation2, camera};
var world = new World(initializable, updatables, drawables, camera);
var keyboardInput = new KeyboardInput(new Dictionary<string, Action>());

Task.Run(keyboardInput.Listen);
world.Initialize();
window.Run(world);