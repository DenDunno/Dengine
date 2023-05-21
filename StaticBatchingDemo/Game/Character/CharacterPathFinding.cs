using System.Diagnostics;
using OpenTK.Mathematics;

public class CharacterPathFinding
{
    private readonly PathFindingAlgorithm _pathFinding;
    private readonly Transform _character;
    private readonly Transform _cherry;
    private readonly Stopwatch _stopwatch = new();
    
    public CharacterPathFinding(Transform character, Transform cherry, HashSet<Vector2i> freeCells)
    {
        _character = character;
        _cherry = cherry;
        _pathFinding = new AStarAlgorithm(freeCells);
    }

    public List<Vector2i> Evaluate()
    {
        Vector2i start = _character.Position.ToVector2I();
        Vector2i target = _cherry.Position.ToVector2I();
        
        _stopwatch.Restart();
        
        List<Vector2i> path = _pathFinding.Execute(start, target);
        
        _stopwatch.Stop();
        DengineConsole.Instance.Log($"Path evaluation took: {_stopwatch.ElapsedMilliseconds} mls");

        return path;
    }
}