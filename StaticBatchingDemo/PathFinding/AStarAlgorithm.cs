using OpenTK.Mathematics;

public class AStarAlgorithm : PathFindingAlgorithm
{
    private readonly Dictionary<Vector2i, float> _predictedCostToTargetFromNode = new();
    private readonly Dictionary<Vector2i, float> _costToNode = new();
    private readonly Dictionary<Vector2i, Vector2i> _path = new();
    private readonly HashSet<Vector2i> _closedNodes = new();
    private readonly HashSet<Vector2i> _openedNodes = new();

    public AStarAlgorithm(HashSet<Vector2i> freeCells) : base(freeCells)
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
        _closedNodes.Clear();
        _openedNodes.Clear();
        _costToNode.Clear();
        _predictedCostToTargetFromNode.Clear();
        _path.Clear();
        
        _openedNodes.Add(Start);
        _costToNode[Start] = 0;
        _predictedCostToTargetFromNode[Start] = _costToNode[Start] + GetRealDistanceToTarget(Start);
    }

    private void Run()
    {
        while (_openedNodes.IsNotEmpty())
        {
            Vector2i current = GetOpenedNodeWithMinPredictedPath();

            _openedNodes.Remove(current);
            _closedNodes.Add(current);
            
            if (current == Target)
            {
                return;
            }
            
            foreach (Vector2i neighbour in GetNeighbours(current))
            {
                _path[neighbour] = current;
                _costToNode[neighbour] = _costToNode[current] + 1;
                _predictedCostToTargetFromNode[neighbour] = _costToNode[neighbour] + GetRealDistanceToTarget(neighbour);
                _openedNodes.Add(neighbour);
            }
        }
    }

    private List<Vector2i> BuildPath()
    {
        List<Vector2i> result = new();
        Vector2i node = Target;

        if (_closedNodes.Contains(Target)) // success
        {
            while (node != Start)
            {
                result.Add(node);
                node = _path[node];
            }   
        }

        result.Add(Start);
        result.Reverse();
        
        return result;
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
        if (_closedNodes.Contains(node) == false && FreeCells.Contains(node))
        {
            container.Add(node);
        }
    }

    private Vector2i GetOpenedNodeWithMinPredictedPath()
    {
        float min = float.MaxValue;
        Vector2i node = Vector2i.Zero;
        
        foreach (Vector2i openedNode in _openedNodes)
        {
            if (_predictedCostToTargetFromNode[openedNode] < min)
            {
                min = _predictedCostToTargetFromNode[openedNode];
                node = openedNode;
            } 
        }

        return node;
    }

    private float GetRealDistanceToTarget(Vector2i node)
    {
        return Vector2.Distance(Target, node);
    }
}