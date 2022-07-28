using OpenTK.Graphics.OpenGL;

var windowFactory = new WindowFactory();
var window = windowFactory.Create();

var cameraTransform = new Transform();
var cameraGameObject = new GameObject(cameraTransform, new IUpdatable[] { new CameraMovement(window, cameraTransform)});

var shaderProgram = new ShaderProgram();
var shader = new Shader(shaderProgram, "Shaders/vertex.glsl", ShaderType.VertexShader);
shader.Load();
shaderProgram.Link();

var gameObjects = new List<GameObject>() {Primitives.Cube(), cameraGameObject};
var world = new World(gameObjects);
var updateCycle = new UpdateCycle(world);
var keyboardInput = new KeyboardInput(new Dictionary<string, Action>());

Task.Run(keyboardInput.Listen);
window.Run(updateCycle);