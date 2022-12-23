using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ManyCubesWorld : WorldFactory
{
    private Light _light = null!;
    private readonly Transform _parent = new();
    private readonly int _cubeDimensionSize = 10;
    private readonly RenderData _cubeCachedRenderData = new()
    {
        Mesh = MeshBuilder.Cube(1f),
        BufferUsageHint = BufferUsageHint.StaticDraw,
        Material = new LitMaterial(new LitMaterialData()
        {
            Texture = new Texture(Paths.GetTexture("crate.png")),
            Color = Color.White
        })
    };
    
    public ManyCubesWorld(PlayerInput playerInput) : base(playerInput)
    {
    }

    protected override List<GameObject> CreateGameObjects()
    {
        List<GameObject> result =  new()
        {
            CreateSkybox("Storm"),
            CreateLight(),
            CreateParent(),
        };

        for (int i = 0; i < _cubeDimensionSize; ++i)
        {
            for (int j = 0; j < _cubeDimensionSize; ++j)
            {
                for (int k = 0; k < _cubeDimensionSize; ++k)
                {
                    result.Add(CreateCube("Cube", new Vector3(i, j, k) * 4f));
                }
            }
        }

        return result;
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

    private GameObject CreateCube(string name, Vector3 position)
    {
        _cubeCachedRenderData.Transform = new Transform(position, _parent);

        int rotationSign = (int)(position.X + position.Y + position.Z) % 2 * 2 - 1;
        _light.Add(_cubeCachedRenderData.Material);
        
        return new GameObject(new GameObjectData(name, _cubeCachedRenderData.Transform)
        {
            Model = new Model(_cubeCachedRenderData),
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(_cubeCachedRenderData.Transform, Vector3.One * rotationSign, 1f)
            }
        });
    }

    private GameObject CreateParent()
    {
        return new GameObject(new GameObjectData("Parent", _parent)
        {
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(_parent, Vector3.One, 0.2f),
            }
        });
    }
}