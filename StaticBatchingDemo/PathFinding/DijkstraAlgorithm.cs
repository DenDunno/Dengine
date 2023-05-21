using OpenTK.Mathematics;

public class DijkstraAlgorithm : PathFindingAlgorithm
{
    private readonly Dictionary<Vector2i, float> _minDistanceToEveryVertex = new();
    private readonly Dictionary<Vector2i, bool> _visitedVertices = new();
    
    public DijkstraAlgorithm(HashSet<Vector2i> freeCells) : base(freeCells)
    {
    }

    protected override List<Vector2i> OnExecute()
    {
        Initialize();
        Run();
        return BuildPath();
    }

    private void Initialize()
    {
        _minDistanceToEveryVertex.Clear();
        _visitedVertices.Clear();

        foreach (Vector2i freeCell in FreeCells)
        {
            _minDistanceToEveryVertex.Add(freeCell, float.MaxValue);
            _visitedVertices.Add(freeCell, false);
        }

        _minDistanceToEveryVertex[Start] = 0;
    }
    
    private void Run()
    {
        for (Vector2i? targetPoint = GetTargetPoint(); targetPoint != null; targetPoint = GetTargetPoint())
        {
            TrySetNewMinPath(targetPoint.Value);

            _visitedVertices[targetPoint.Value] = true;
        }
    }
    
    private Vector2i? GetTargetPoint()
    {
        Vector2i? targetPoint = null;
        var min = float.MaxValue;

        foreach (Vector2i freeCell in FreeCells)
        {
            if (_visitedVertices[freeCell] == false && _minDistanceToEveryVertex[freeCell] < min)
            {
                min = _minDistanceToEveryVertex[freeCell];
                targetPoint = freeCell;
            }
        }

        return targetPoint;
    }

    private void TrySetNewMinPath(Vector2i targetPoint)
    {
        foreach (Vector2i neighbour in GetNeighbours(targetPoint))
        {
            float distanceToNewVertex = _minDistanceToEveryVertex[targetPoint] + 1;

            if (distanceToNewVertex < _minDistanceToEveryVertex[neighbour])
            {
                _minDistanceToEveryVertex[neighbour] = distanceToNewVertex;
            }
        }
    }
    
    private List<Vector2i> GetNeighbours(Vector2i node)
    {
        List<Vector2i> result = new();
        
        TryAddNeighbour(result, new Vector2i(node.X + 1, node.Y));
        TryAddNeighbour(result, new Vector2i(node.X - 1, node.Y));
        TryAddNeighbour(result, new Vector2i(node.X, node.Y + 1));
        TryAddNeighbour(result, new Vector2i(node.X, node.Y - 1));

        return result;
    }

    private void TryAddNeighbour(List<Vector2i> container, Vector2i node)
    {
        if (FreeCells.Contains(node) && _visitedVertices[node] == false)
        {
            container.Add(node);
        }
    }
    
    private List<Vector2i> BuildPath()
    {
        List<Vector2i> result = new() { Target };
        Vector2i current = Target;

        foreach (KeyValuePair<Vector2i,bool> visitedVertex in _visitedVertices)
        {
            _visitedVertices[visitedVertex.Key] = false;
        }
        
        while (current != Start)
        {
            foreach (Vector2i neighbour in GetNeighbours(current))
            {
                float distanceToNewVertex = _minDistanceToEveryVertex[current] - 1;
                
                if (_minDistanceToEveryVertex[neighbour] - distanceToNewVertex < 0.0001f)
                {
                    result.Add(neighbour);
                    current = neighbour;
                    _minDistanceToEveryVertex[current] = distanceToNewVertex;
                    break;
                }
            }
        }

        result.Reverse();

        return result;
    }
}