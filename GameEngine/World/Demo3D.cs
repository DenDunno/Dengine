using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Demo3D : WorldFactory
{
    private Light _light = null!;
    
    public Demo3D(PlayerInput playerInput) : base(playerInput)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            CreateSkybox("Storm"),
            CreateLight(),
            CreateCube("Controlling cube", new Vector3(-2, 2, 0), true, Vector3.Zero),
            CreateCube("Cube1", new Vector3(2, 2, 0), false, new Vector3(0, 45, 45)),
        };
    }

    private GameObject CreateLight()
    {
        Transform transform = new();
        _light = new Light(transform, CameraTransform, Color.White);
        
        return new GameObject(new GameObjectData("Light", transform)
        {
            Components = new List<IGameComponent>()
            {
                _light
            }
        });
    }

    private GameObject CreateCube(string name, Vector3 position, bool isControlling, Vector3 rotation)
    {
        RenderData renderData = new()
        {
            Transform = new Transform(position, Quaternion.FromEulerAngles(rotation)),
            Mesh = MeshBuilder.Cube(1f),
            BufferUsageHint = BufferUsageHint.StaticDraw,
            Material = new LitMaterial(new LitMaterialData()
            {
                //Base = new Texture(Paths.GetTexture("crate.png")),
                Color = Color.White
            })
        };

        _light.Add(renderData.Material);
        
        return new GameObject(new GameObjectData(name, renderData.Transform)
        {
            Model = new Model(renderData),
            Components = GetComponents(isControlling, renderData.Transform)
        });
    }
    
    private List<IGameComponent> GetComponents(bool isControlling, Transform transform)
    {
        List<IGameComponent> components = new()
        {
            new Rigidbody(transform)
        };

        if (isControlling)
        {
            components.Add(new ObjectControlling(transform, Input.Keyboard));
        }

        return components;
    }
}