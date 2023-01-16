using System.Drawing;
using OpenTK.Mathematics;

public class Demo3D : WorldFactory
{
    private Light _light = null!;

    protected override List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new PerspectiveProjection());
        _light = new Light(new Transform(), camera.Transform, Color.Aqua);
        
        return new List<GameObject>()
        {
            CreateCube("Controlling cube", new Vector3(-2, 2, 0), true, Vector3.Zero),
            CreateCube("Cube1", new Vector3(2, 2, 0), false, new Vector3(0, 45, 45)),
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.CreateSkybox("Storm", camera),
            GameObjectFactory.Point(_light, _light.Transform)
        };
    }

    private GameObject CreateCube(string name, Vector3 position, bool isControlling, Vector3 rotation)
    {
        RenderData renderData = new()
        {
            Transform = new Transform(position, Quaternion.FromEulerAngles(rotation)),
            Mesh = MeshBuilder.Cube(1f),
            Material = new LitMaterial(new LitMaterialData()
            {
                Base = new Texture(Paths.GetTexture("crate.png")),
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
        else
        {
            components.Add(new RotationAnimation(transform, Vector3.One, 0.5f));
        }

        return components;
    }
}