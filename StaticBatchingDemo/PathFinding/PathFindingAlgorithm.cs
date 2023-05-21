using OpenTK.Mathematics;

public abstract class PathFindingAlgorithm
{
    protected readonly HashSet<Vector2i> FreeCells;
    protected Vector2i Target;
    protected Vector2i Start;

    protected PathFindingAlgorithm(HashSet<Vector2i> freeCells)
    {
        FreeCells = freeCells;
    }

    public List<Vector2i> Execute(Vector2i start, Vector2i target)
    {
        Start = start;
        Target = target;

        return OnExecute();
    }

    protected abstract List<Vector2i> OnExecute();
}