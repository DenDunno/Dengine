
public class PhysicsSimulation
{
    private readonly float _deltaTime;
    private readonly Dynamics _dynamics;

    public PhysicsSimulation(float deltaTime, IEnumerable<Rigidbody> rigidbodies)
    {
        _deltaTime = deltaTime;
        _dynamics = new Dynamics(rigidbodies.Where(rigidbody => rigidbody.IsDynamic), deltaTime);
    }
    
    public void Run()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                _dynamics.ApplyGravity();

                await Task.Delay(TimeSpan.FromSeconds(_deltaTime));
            }
        });
    }
}