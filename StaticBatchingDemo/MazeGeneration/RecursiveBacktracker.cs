using OpenTK.Mathematics;

public class RecursiveBacktracker
{
    private readonly HashSet<Vector2i> _freeCells;
    private readonly Stack<Vector2i> _openedTiles = new();
    private readonly List<Vector2i> _neighbours = new();
    private Vector2i _mapMaxTile;
    
    public RecursiveBacktracker(HashSet<Vector2i> freeCells)
    {
        _freeCells = freeCells;
    }

    public void Evaluate(int rows, int columns)
    {
        Random random = new(); 
        Vector2i current = MapGraphToMap(random.Next(0, columns), random.Next(0, rows));
        _mapMaxTile = MapGraphToMap(columns - 1, rows - 1);
        _openedTiles.Push(current);
        _freeCells.Add(current);
        
        while (_openedTiles.IsNotEmpty())
        {
            if (TryFindNeighbours(current))
            {
                Vector2i neighbour = _neighbours.GetRandomElement();
                Vector2i direction = neighbour - current;
                Vector2i intermediateCell = current + direction / 2;
                current = neighbour;

                _openedTiles.Push(current);
                _freeCells.Add(neighbour);
                _freeCells.Add(intermediateCell);
            }
            else
            {
                current = _openedTiles.Pop();
            }
        }
    }

    private Vector2i MapGraphToMap(int x, int y)
    {
        return 2 * new Vector2i(x, y) + Vector2i.One;
    }
    
    private bool TryFindNeighbours(Vector2i current)
    {
        _neighbours.Clear();
        TryAddNeighbour(current + Vector2i.UnitX * 2);
        TryAddNeighbour(current - Vector2i.UnitX * 2);
        TryAddNeighbour(current + Vector2i.UnitY * 2);
        TryAddNeighbour(current - Vector2i.UnitY * 2);

        return _neighbours.IsNotEmpty();
    }
    
    private void TryAddNeighbour(Vector2i neighbour)
    {
        bool notPassed = _freeCells.Contains(neighbour) == false;
        
        bool inMapRange = neighbour.X >= 0 && neighbour.X <= _mapMaxTile.X && 
                          neighbour.Y >= 0 && neighbour.Y <= _mapMaxTile.Y;
            
        if (notPassed && inMapRange)
        {
            _neighbours.Add(neighbour);
        }
    }
}