using OpenTK.Mathematics;

public class MazeView
{
    private readonly ObstacleSpawner _obstacleSpawner;
    private readonly HashSet<Vector2i> _obstacles;
    private readonly GameObject _view;

    public MazeView(Transform transform, HashSet<Vector2i> obstacles)
    {
        _obstacles = obstacles;
        _obstacleSpawner = new ObstacleSpawner();
        _view = new GameObject(new GameObjectData("Maze view", transform));
    }

    public void Instantiate()
    {
        WorldBrowser.Add(_view);
    }

    public void Regenerate()
    {
        Mesh mesh = GetMazeMesh();
        _view.Dispose();
        _view.Data.Drawable = new Model(new RenderData(mesh, new LitMaterial(new LitMaterialData()
        {
            Base = new Texture2D(Paths.GetTexture("tiles.png")),
        }))
        {
            Transform = _view.Data.Transform
        });
        _view.Data.Drawable.Initialize();
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