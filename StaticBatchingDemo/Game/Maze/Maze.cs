using OpenTK.Mathematics;

public class Maze : IGameComponent
{
    public readonly HashSet<Vector2i> FreeCells = new();
    private readonly HashSet<Vector2i> _obstacles = new();
    private readonly MazeGeneration _mazeGeneration;
    private readonly MazeView _view;

    public Maze(Transform transform)
    {
        _mazeGeneration = new MazeGeneration(_obstacles, FreeCells);
        _view = new MazeView(transform, _obstacles);
    }

    void IGameComponent.Initialize()
    {
        _view.Instantiate();
    }
    
    public void Generate(int rows, int columns)
    {
        Release();
        _mazeGeneration.Evaluate(rows, columns);
        _view.Regenerate();
    }

    private void Release()
    {
        FreeCells.Clear();
        _obstacles.Clear();
    }
}