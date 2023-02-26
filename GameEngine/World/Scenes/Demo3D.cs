using System.Drawing;
using OpenTK.Mathematics;

public class Demo3D : IWorldFactory
{
    private Light _light = null!;

    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new PerspectiveProjection());
        _light = new Light(new Transform(), camera.Transform, Color.Aqua);
        
        return new List<GameObject>()
        {
            CreateCube("Controlling cube", new Vector3(-2, 2, 0), Vector3.Zero),
            CreateCube("Cube1", new Vector3(2, 2, 0), new Vector3(0, 45, 45)),
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.CreateSkybox("Storm", camera),
            GameObjectFactory.Point(_light, _light.Transform)
        };
    }

    private GameObject CreateCube(string name, Vector3 position, Vector3 rotation)
    {
        RenderData renderData = new()
        {
            Transform = new Transform(position, Quaternion.FromEulerAngles(rotation)),
            Mesh = MeshBuilder.Cube(1f),
            Material = new LitMaterial(new LitMaterialData()
            {
                Base = new Texture2D(Paths.GetTexture("crate.png")),
                Color = Color.White
            })
        };

        _light.Add(renderData.Material.Bridge);
        
        return new GameObject(new GameObjectData(name, renderData.Transform)
        {
            Drawable = new Model(renderData),
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(renderData.Transform, Vector3.UnitZ, 1f)
            }
        });
    }
}