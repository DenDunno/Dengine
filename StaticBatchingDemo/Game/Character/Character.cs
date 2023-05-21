using System.Drawing;
using OpenTK.Mathematics;

public class Character : TogglingComponent
{
    public readonly Transform Transform;
    [EditorField] private readonly float _speed = 2f;
    private readonly float _rotationSpeed = 9f;
    private readonly CharacterPathFinding _pathFinding;
    private List<Vector2i> _path = new();
    private int _currentWayPoint;
    
    public Character(Cherry cherry, Maze maze, Transform transform)
    {
        _pathFinding = new CharacterPathFinding(transform, cherry.Transform, maze.FreeCells);
        Transform = transform;
    }

    private bool IsChasing => _currentWayPoint < _path.Count;
    private Vector3 Target => _path[_currentWayPoint].ToVector3();
    
    public void CalculatePath()
    {
        _path = _pathFinding.Evaluate();
        _currentWayPoint = 0;
    }

    protected override void OnUpdate(float deltaTime)
    {
        if (IsChasing)
        {
            Gizmo.Instance.DrawPath(_path, Color.Chartreuse, -0.1f);
            RotateToTarget(deltaTime);
            MoveThePath(deltaTime);
        }
    }

    private void MoveThePath(float deltaTime)
    {
        Transform.Position.MoveTowards2D(Target, _speed * deltaTime);

        if (Vector3.Distance(Transform.Position, Target) <= 0.001f)
        {
            _currentWayPoint++;
        }
    }

    private void RotateToTarget(float deltaTime)
    {
        Vector3 direction = Target - Transform.Position;
        Quaternion rotation = Quaternion.FromAxisAngle(Vector3.UnitZ, MathF.Atan2(direction.Y, direction.X));

        Transform.Rotation = Quaternion.Slerp(Transform.Rotation, rotation, _rotationSpeed * deltaTime);
    }
}