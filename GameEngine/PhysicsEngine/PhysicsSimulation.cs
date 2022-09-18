
public class PhysicsSimulation
{
    private readonly float _deltaTime;
    private readonly Dynamics _dynamics;
    private readonly CollisionDetection _collisionDetection;
    
    public PhysicsSimulation(float deltaTime, Rigidbody[] rigidbodies)
    {
        _deltaTime = deltaTime;
        _dynamics = new Dynamics(rigidbodies.Where(rigidbody => rigidbody.IsDynamic), deltaTime);
        _collisionDetection = new CollisionDetection(rigidbodies);
    }
    
    public void Run()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                _dynamics.ApplyGravity();
                _collisionDetection.CheckCollision();

                await Task.Delay(TimeSpan.FromSeconds(_deltaTime));
            }
        });
    }
}