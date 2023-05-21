using OpenTK.Mathematics;

public class MazeGeneration
{
    private readonly HashSet<Vector2i> _obstacles;
    private readonly HashSet<Vector2i> _freeCells;
    private readonly RecursiveBacktracker _recursiveBacktracker;
    
    public MazeGeneration(HashSet<Vector2i> obstacles, HashSet<Vector2i> freeCells)
    {
        _obstacles = obstacles;
        _freeCells = freeCells;
        _recursiveBacktracker = new RecursiveBacktracker(freeCells);
    }
    
    public void Evaluate(int rows, int columns)
    {
        _recursiveBacktracker.Evaluate(rows, columns);
        EvaluateObstacles(rows, columns);
    }

    private void EvaluateObstacles(int rows, int columns)
    {
        int mapRows = rows * 2 + 1;
        int mapColumns = columns * 2 + 1;
        
        for (int i = 0; i < mapRows; ++i)
        {
            for (int j = 0; j < mapColumns; ++j)
            {
                Vector2i tile = new(j, i);
                
                if (_freeCells.Contains(tile) == false)
                {
                    _obstacles.Add(tile);
                }
            }
        }
    }
}