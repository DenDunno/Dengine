using OpenTK.Mathematics;

public class MazeView
{
    private readonly ObstacleSpawner _obstacleSpawner;
    private readonly HashSet<Vector2i> _obstacles;
    private readonly Transform _transform;
    private readonly Material _material;
    private GameObject _view = null!;

    public MazeView(Transform transform, HashSet<Vector2i> obstacles)
    {
        _transform = transform;
        _obstacles = obstacles;
        _obstacleSpawner = new ObstacleSpawner();
        _material = new LitMaterial(new LitMaterialData()
        {
            Base = new Texture2D(Paths.GetTexture("tiles.png"))
        });
    }

    public void Instantiate()
    {
        _view = new GameObject(new GameObjectData("Maze view", _transform));
        WorldBrowser.Add(_view);
    }

    public void Regenerate()
    {
        Mesh mesh = GetMazeMesh();
        _view.Data.Drawable.Dispose();
        _view.Data.Drawable = new Model(new RenderData(mesh, new LitMaterial(new LitMaterialData()
        {
            Base = new Texture2D(Paths.GetTexture("tiles.png"))
        })));
        _view.Data.Drawable.Initialize();
        _view.Data.Components.Clear();
        _view.Data.Components.Add(_view.Data.Drawable);
    }
    
    private Mesh GetMazeMesh()
    {
        Mesh[] tiles = new Mesh[_obstacles.Count];
        
        int index = 0;
        foreach (Vector2i obstacle in _obstacles)
        {
            tiles[index] = _obstacleSpawner.Create(obstacle, GetNeighbours(obstacle));
            ++index;
        }

        return StaticBatching.Concatenate(tiles);
    }
    
    private TileNeighbours GetNeighbours(Vector2i tile)
    {
        return new TileNeighbours()
        {
            Top = _obstacles.Contains(new Vector2i(tile.X, tile.Y + 1)),
            Left = _obstacles.Contains(new Vector2i(tile.X - 1, tile.Y)),
            Right = _obstacles.Contains(new Vector2i(tile.X + 1, tile.Y)),
            Bottom = _obstacles.Contains(new Vector2i(tile.X, tile.Y - 1)),
            
            TopLeft = _obstacles.Contains(new Vector2i(tile.X - 1, tile.Y + 1)),
            TopRight = _obstacles.Contains(new Vector2i(tile.X + 1, tile.Y + 1)),
            BottomLeft = _obstacles.Contains(new Vector2i(tile.X - 1, tile.Y - 1)),
            BottomRight = _obstacles.Contains(new Vector2i(tile.X + 1, tile.Y - 1))
        };
    }
}